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
public class TR_SALE_RTN : Form
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
	[AccessedThroughProperty("MSG_RTN_IDTL")]
	private AxMSFlexGrid _MSG_RTN_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_RTN_IDTL")]
	private TextBox _TEXT_RTN_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgPrClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private string CurRatePar;

	private double LessAdvAmt;

	private double LessAdvNetWt;

	private double CrDrTot;

	private string CurRptTagNo;

	private bool EditOPen;

	private double OldNetAmt;

	private double OldTaxPrc;

	private string ItmDataType;

	private double SlOthAmtLess;

	private double PrOthAmtLess;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private DataTable VchOldData;

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

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsPrDetl;

	private DataTable RsBarDetl;

	private DataTable RsBarData;

	private DataTable RsBillOs;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private int RtnRow;

	private DataTable RtnIdtl;

	private DataRow Rtndr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private int RtnOldRow;

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

	private const int cSize = 5;

	private const int cHmId = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cOthWt = 9;

	private const int cNetWt = 10;

	private const int cGhtPrc = 11;

	private const int cGhtWt = 12;

	private const int cTouch = 13;

	private const int cWestPrc = 14;

	private const int cFine = 15;

	private const int cItRate = 16;

	private const int cItAmt = 17;

	private const int cLbrPrc = 18;

	private const int cLbrType = 19;

	private const int cLbrRate = 20;

	private const int cLbrAmt = 21;

	private const int cOthAmt = 22;

	private const int cMrp = 23;

	private const int cNetAmt = 24;

	private const int cOldSrNo = 25;

	private const int cEntryMod = 26;

	private const int cCounter = 27;

	private const int cKrName = 28;

	private const int cVchSrno = 29;

	private const int cItType = 30;

	private const int cTagType = 31;

	private const int cPrCode = 32;

	private const int cKrOthWt = 33;

	private const int cKrNetWt = 34;

	private const int cKrTouch = 35;

	private const int cKrWestPrc = 36;

	private const int cKrFine = 37;

	private const int cTagCost = 38;

	private const int cRateType = 39;

	private const int cOldItRate = 40;

	private const int cOldGrWt = 41;

	private const int cOldNtWt = 42;

	private const int cOldLbrPrc = 43;

	private const int cOldLbrRate = 44;

	private const int cOldLbrAmt = 45;

	private const int cOldNetAmt = 46;

	private const int cDesignImgId = 47;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmColor = 5;

	private const int c1DmSize = 6;

	private const int c1DmOrigin = 7;

	private const int c1DmRemark = 8;

	private const int c1DmSfNo = 9;

	private const int c1Pcs = 10;

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

	private const int cTot2 = 3;

	private const int cChq2 = 4;

	private const int cCard2 = 5;

	private const int cCash2 = 6;

	private const int cKasar2 = 7;

	private const int cOs2 = 8;

	private const int cPrSrNo = 0;

	private const int cPrItCode = 1;

	private const int cPrTagNo = 2;

	private const int cPrItName = 3;

	private const int cPrCounter = 4;

	private const int cPrDesign = 5;

	private const int cStyle = 6;

	private const int cPrSize = 7;

	private const int cPrHmId = 8;

	private const int cPrPcs = 9;

	private const int cPrGrWt = 10;

	private const int cPrOthWt = 11;

	private const int cPrNetWt = 12;

	private const int cPrLbrCode = 13;

	private const int cPrGhtPrc = 14;

	private const int cPrGhtWt = 15;

	private const int cPrTouch = 16;

	private const int cPrWestPrc = 17;

	private const int cPrFine = 18;

	private const int cPrRate = 19;

	private const int cPrItAmt = 20;

	private const int cPrLbrPrc = 21;

	private const int cPrLbrType = 22;

	private const int cPrLbrRate = 23;

	private const int cPrLbrAmt = 24;

	private const int cPrLbrDiscPrc = 25;

	private const int cPrLbrDiscAmt = 26;

	private const int cPrOthAmt = 27;

	private const int cPrMrp = 28;

	private const int cPrTagLbrCode = 29;

	private const int cPrTagLbrPrc = 30;

	private const int cPrTagLRate = 31;

	private const int cPrTagLAmt = 32;

	private const int cPrTagOthAmt = 33;

	private const int cPrTagCost = 34;

	private const int cPrTagMrp = 35;

	private const int cPrTotAmt = 36;

	private const int cPrTaxPrc = 37;

	private const int cPrNetAmt = 38;

	private const int cPrKrName = 39;

	private const int cPrVchSrNo = 40;

	private const int cPrOthRate = 41;

	private const int cPrOthFine = 42;

	private const int cPrItType = 43;

	private const int cPrRateType = 44;

	private const int cPrOldGwt = 45;

	private const int cPrOldNwt = 46;

	private const int cPrOldTouch = 47;

	private const int cPrOldWest = 48;

	private const int cPrOldRate = 49;

	private const int cPrAprIsu = 50;

	private const int cPrOldSrNo = 51;

	private const int cPrPrCode = 52;

	private const int cPrOldPrCode = 53;

	private const int cPrTagType = 54;

	private const int cPrOldTagType = 55;

	private const int cPrTagSrNo = 56;

	private const int cPrEntrymod = 57;

	private const int cPrOldLbrRate = 58;

	private const int cPrHmId2 = 59;

	private const int cPrHmId3 = 60;

	private const int cPrHmId4 = 61;

	private const int cPrHmIdWt = 62;

	private const int cPrHmId2Wt = 63;

	private const int cPrHmId3Wt = 64;

	private const int cPrHmId4wt = 65;

	private const int cPrOldLbrPrc = 66;

	private const int cPrOldTaxPrc = 67;

	private const int cPrEmpIsu = 68;

	private const int cPrDesignImgId = 69;

	private const int cPrDataType = 70;

	private const int cRiSrNo = 0;

	private const int cRiItCode = 1;

	private const int cRiItName = 2;

	private const int cRiDmCode = 3;

	private const int cRiDmName = 4;

	private const int cRiDmColor = 5;

	private const int cRiDmSize = 6;

	private const int cRiDmOrigin = 7;

	private const int cRiDmRemark = 8;

	private const int cRiDmSfNo = 9;

	private const int cRiPcs = 10;

	private const int cRiKrWt = 11;

	private const int cRiGrWt = 12;

	private const int cRiConPrc = 13;

	private const int cRiRateType = 14;

	private const int cRiItRate = 15;

	private const int cRiItmAmt = 16;

	private const int cRiLbrRate = 17;

	private const int cRiLbrAmt = 18;

	private const int cRiNetAmt = 19;

	private const int cRiConWt = 20;

	private const int cRiKrConWt = 21;

	private const int cRiItType = 22;

	private const int cRiRowSr = 23;

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
			EventHandler eventHandler4 = MSG_PR_Enter;
			EventHandler eventHandler5 = MSG_PR_RowColChange;
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				((Control)val).Enter -= eventHandler4;
				val.RowColChange -= eventHandler5;
			}
			_MSG_PR = value;
			val = _MSG_PR;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				((Control)val).Enter += eventHandler4;
				val.RowColChange += eventHandler5;
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

	internal virtual AxMSFlexGrid MSG_RTN_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_RTN_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_RTN_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_RTN_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_RTN_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_RTN_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_RTN_IDTL = value;
			val = _MSG_RTN_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_RTN_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_RTN_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_RTN_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_RTN_IDTL_KeyDown);
			TextBox val2 = _TEXT_RTN_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_RTN_IDTL = value;
			val2 = _TEXT_RTN_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuYrCd")]
	private virtual TextBox _tIsuYrCd;

	internal virtual TextBox tIsuYrCd
	{
		get
		{
			return _tIsuYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuDbCd")]
	private virtual TextBox _tIsuDbCd;

	internal virtual TextBox tIsuDbCd
	{
		get
		{
			return _tIsuDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIsuDbCd = value;
		}
	}

	internal virtual SimpleButton btnIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _btnIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIsuNo_Click;
			SimpleButton val = _btnIsuNo;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIsuNo = value;
			val = _btnIsuNo;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	internal virtual TextBox tIsuNo
	{
		[CompilerGenerated]
		get
		{
			return _tIsuNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TIsuNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tIsuNo_KeyDown);
			TextBox val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tIsuNo = value;
			val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("nAcCrAmt")]
	private virtual TextBox _nAcCrAmt;

	internal virtual TextBox nAcCrAmt
	{
		get
		{
			return _nAcCrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAcCrAmt = value;
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
	[AccessedThroughProperty("nAcDrAmt")]
	private virtual TextBox _nAcDrAmt;

	internal virtual TextBox nAcDrAmt
	{
		get
		{
			return _nAcDrAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAcDrAmt = value;
		}
	}

	public TR_SALE_RTN()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_RTN_Load;
		((Form)this).Deactivate += TR_SALE_RTN_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_RTN_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_RTN_KeyDown);
		((Form)this).Activated += TR_SALE_RTN_Activated;
		((Form)this).Closed += TR_SALE_RTN_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_RTN_KeyUp);
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		CrDrTot = 0.0;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		RtnIdtl = new DataTable();
		Rtndr = RtnIdtl.NewRow();
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
		//IL_036e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_042a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0434: Expected O, but got Unknown
		//IL_04b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c1: Expected O, but got Unknown
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_0616: Unknown result type (might be due to invalid IL or missing references)
		//IL_0620: Expected O, but got Unknown
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b1: Expected O, but got Unknown
		//IL_074c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0756: Expected O, but got Unknown
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Expected O, but got Unknown
		//IL_0852: Unknown result type (might be due to invalid IL or missing references)
		//IL_085c: Expected O, but got Unknown
		//IL_0905: Unknown result type (might be due to invalid IL or missing references)
		//IL_090f: Expected O, but got Unknown
		//IL_0972: Unknown result type (might be due to invalid IL or missing references)
		//IL_097c: Expected O, but got Unknown
		//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_0b4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b56: Expected O, but got Unknown
		//IL_0c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6b: Expected O, but got Unknown
		//IL_0cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd8: Expected O, but got Unknown
		//IL_0e6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f29: Expected O, but got Unknown
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Expected O, but got Unknown
		//IL_113c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1146: Expected O, but got Unknown
		//IL_11c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ca: Expected O, but got Unknown
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1295: Expected O, but got Unknown
		//IL_133c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1346: Expected O, but got Unknown
		//IL_1441: Unknown result type (might be due to invalid IL or missing references)
		//IL_144b: Expected O, but got Unknown
		//IL_14ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b6: Expected O, but got Unknown
		//IL_15bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c9: Expected O, but got Unknown
		//IL_16a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ab: Expected O, but got Unknown
		//IL_1747: Unknown result type (might be due to invalid IL or missing references)
		//IL_1751: Expected O, but got Unknown
		//IL_188c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1896: Expected O, but got Unknown
		//IL_18e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18eb: Expected O, but got Unknown
		//IL_1965: Unknown result type (might be due to invalid IL or missing references)
		//IL_196f: Expected O, but got Unknown
		//IL_19f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fa: Expected O, but got Unknown
		//IL_1ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acb: Expected O, but got Unknown
		//IL_1b72: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b7c: Expected O, but got Unknown
		//IL_1bfa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c04: Expected O, but got Unknown
		//IL_1c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c93: Expected O, but got Unknown
		//IL_1d44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4e: Expected O, but got Unknown
		//IL_1dff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e09: Expected O, but got Unknown
		//IL_1ebe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec8: Expected O, but got Unknown
		//IL_1f2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f39: Expected O, but got Unknown
		//IL_1f94: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Expected O, but got Unknown
		//IL_203d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2047: Expected O, but got Unknown
		//IL_20ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f8: Expected O, but got Unknown
		//IL_2146: Unknown result type (might be due to invalid IL or missing references)
		//IL_2150: Expected O, but got Unknown
		//IL_2201: Unknown result type (might be due to invalid IL or missing references)
		//IL_220b: Expected O, but got Unknown
		//IL_22d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_22df: Expected O, but got Unknown
		//IL_233a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2344: Expected O, but got Unknown
		//IL_23d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dc: Expected O, but got Unknown
		//IL_2467: Unknown result type (might be due to invalid IL or missing references)
		//IL_2471: Expected O, but got Unknown
		//IL_251f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2529: Expected O, but got Unknown
		//IL_2601: Unknown result type (might be due to invalid IL or missing references)
		//IL_260b: Expected O, but got Unknown
		//IL_26a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b1: Expected O, but got Unknown
		//IL_27b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_27bc: Expected O, but got Unknown
		//IL_286a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2874: Expected O, but got Unknown
		//IL_28fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2908: Expected O, but got Unknown
		//IL_29b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_29c3: Expected O, but got Unknown
		//IL_2a73: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a7d: Expected O, but got Unknown
		//IL_2b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b38: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE_RTN));
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
		LOpAmt = new Label();
		LClAmt = new Label();
		MSG_RTN_IDTL = new AxMSFlexGrid();
		TEXT_RTN_IDTL = new TextBox();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		btnIsuNo = new SimpleButton();
		Label12 = new Label();
		tIsuNo = new TextBox();
		Label23 = new Label();
		nAcCrAmt = new TextBox();
		Label20 = new Label();
		nAcDrAmt = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_PR).BeginInit();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((ISupportInitialize)MSG_RTN_IDTL).BeginInit();
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
		lblBook.Text = "Sales Return ";
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
		((Control)PnlBotam).TabIndex = 13;
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
		((Control)TEXT_ENTRY).Location = new Point(360, 122);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(597, 67);
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
		((Control)MSG_IDTL).Location = new Point(12, 197);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(934, 68);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(1071, 200);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(100, 63);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 179);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 94);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 84);
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
		((Control)tAcCode).Location = new Point(105, 65);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 65);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(379, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 64);
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
		((Control)tEmpCode).Location = new Point(91, 490);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(44, 23);
		((Control)tEmpCode).TabIndex = 10;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(141, 490);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(109, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(16, 491);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(12, 518);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(73, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(91, 518);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(285, 41);
		((Control)tVchDesc).TabIndex = 12;
		((Control)MSG2_TOTAL).Location = new Point(629, 376);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(541, 185);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(12, 271);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1159, 86);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(896, 388);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(394, 302);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).RightToLeft = (RightToLeft)0;
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 7;
		((Control)MSG_PR_TOT).Location = new Point(16, 357);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1153, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1057, 40);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(113, 20);
		((Control)LOpAmt).TabIndex = 1205;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(510, 541);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(113, 20);
		((Control)LClAmt).TabIndex = 1208;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_RTN_IDTL).Location = new Point(12, 376);
		((Control)MSG_RTN_IDTL).Name = "MSG_RTN_IDTL";
		((AxHost)MSG_RTN_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_RTN_IDTL.OcxState");
		((Control)MSG_RTN_IDTL).Size = new Size(611, 107);
		((Control)MSG_RTN_IDTL).TabIndex = 1213;
		((TextBoxBase)TEXT_RTN_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_RTN_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_RTN_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_RTN_IDTL).ForeColor = Color.White;
		((Control)TEXT_RTN_IDTL).Location = new Point(200, 403);
		((Control)TEXT_RTN_IDTL).Name = "TEXT_RTN_IDTL";
		((Control)TEXT_RTN_IDTL).RightToLeft = (RightToLeft)0;
		((Control)TEXT_RTN_IDTL).Size = new Size(100, 18);
		((Control)TEXT_RTN_IDTL).TabIndex = 8;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuYrCd).Location = new Point(749, 38);
		((TextBoxBase)tIsuYrCd).MaxLength = 8;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(76, 22);
		((Control)tIsuYrCd).TabIndex = 1221;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuDbCd).Location = new Point(829, 38);
		((TextBoxBase)tIsuDbCd).MaxLength = 8;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(76, 22);
		((Control)tIsuDbCd).TabIndex = 1220;
		((BaseStyleControl)btnIsuNo).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIsuNo).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIsuNo).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnIsuNo).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIsuNo).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIsuNo).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIsuNo).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIsuNo).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIsuNo).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIsuNo).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIsuNo).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIsuNo).AppearancePressed.Options.UseFont = true;
		((Control)btnIsuNo).Location = new Point(911, 37);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(35, 23);
		((Control)btnIsuNo).TabIndex = 1219;
		btnIsuNo.Text = "S";
		((BaseControl)btnIsuNo).ToolTip = "Sales Help";
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(579, 39);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(82, 20);
		((Control)Label12).TabIndex = 1218;
		Label12.Text = "Sale Bill";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuNo).Location = new Point(669, 38);
		((TextBoxBase)tIsuNo).MaxLength = 8;
		((Control)tIsuNo).Name = "tIsuNo";
		((TextBoxBase)tIsuNo).ReadOnly = true;
		((Control)tIsuNo).Size = new Size(76, 22);
		((Control)tIsuNo).TabIndex = 2;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Green;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(449, 490);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(79, 20);
		((Control)Label23).TabIndex = 1225;
		Label23.Text = "Ac Cr Amt";
		Label23.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nAcCrAmt).BackColor = Color.Beige;
		((Control)nAcCrAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nAcCrAmt).ForeColor = Color.Green;
		((Control)nAcCrAmt).Location = new Point(533, 488);
		((TextBoxBase)nAcCrAmt).MaxLength = 10;
		((Control)nAcCrAmt).Name = "nAcCrAmt";
		((TextBoxBase)nAcCrAmt).ReadOnly = true;
		((Control)nAcCrAmt).Size = new Size(90, 22);
		((Control)nAcCrAmt).TabIndex = 1222;
		nAcCrAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Maroon;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(449, 517);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(79, 20);
		((Control)Label20).TabIndex = 1224;
		Label20.Text = "Ac Dr Amt";
		Label20.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nAcDrAmt).BackColor = Color.Lavender;
		((Control)nAcDrAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nAcDrAmt).ForeColor = Color.FromArgb(192, 64, 0);
		((Control)nAcDrAmt).Location = new Point(533, 515);
		((TextBoxBase)nAcDrAmt).MaxLength = 10;
		((Control)nAcDrAmt).Name = "nAcDrAmt";
		((TextBoxBase)nAcDrAmt).ReadOnly = true;
		((Control)nAcDrAmt).Size = new Size(90, 22);
		((Control)nAcDrAmt).TabIndex = 1223;
		nAcDrAmt.TextAlign = (HorizontalAlignment)1;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)nAcCrAmt);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)nAcDrAmt);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)TEXT_RTN_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_RTN_IDTL);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
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
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_SALE_RTN";
		((Form)this).Text = "Sales Return";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_PR).EndInit();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((ISupportInitialize)MSG_RTN_IDTL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_RTN_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		mSG_RTN_IDTL.Clear();
		mSG_RTN_IDTL.Cols = 24;
		mSG_RTN_IDTL.FixedRows = 1;
		mSG_RTN_IDTL.Rows = 2;
		mSG_RTN_IDTL.Row = 0;
		mSG_RTN_IDTL[0] = 0;
		mSG_RTN_IDTL[1] = 0;
		mSG_RTN_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_RTN_IDTL[0] = (int)Math.Round(450.0 * ColCon);
			mSG_RTN_IDTL[0] = 3;
			mSG_RTN_IDTL[0, 0] = "Sr";
			mSG_RTN_IDTL[1] = (int)Math.Round(700.0 * ColCon);
			mSG_RTN_IDTL[1] = 0;
			mSG_RTN_IDTL[0, 1] = "Itm";
			mSG_RTN_IDTL[2] = (int)Math.Round(1750.0 * ColCon);
			mSG_RTN_IDTL[2] = 0;
			mSG_RTN_IDTL[0, 2] = "ItName";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_RTN_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_RTN_IDTL[3] = 0;
				mSG_RTN_IDTL[0, 3] = "DmCode";
				mSG_RTN_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_RTN_IDTL[4] = 0;
				mSG_RTN_IDTL[0, 4] = "DmName";
				mSG_RTN_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_RTN_IDTL[5] = 0;
				mSG_RTN_IDTL[0, 5] = "DmColor";
				mSG_RTN_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_RTN_IDTL[6] = 3;
				mSG_RTN_IDTL[0, 6] = "DmSize";
				mSG_RTN_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[7] = 0;
				mSG_RTN_IDTL[0, 7] = "DmOrigin";
				mSG_RTN_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[8] = 0;
				mSG_RTN_IDTL[0, 8] = "DmRemark";
				mSG_RTN_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_RTN_IDTL[9] = 0;
				mSG_RTN_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_RTN_IDTL[3] = 0;
				mSG_RTN_IDTL[0, 3] = "DmCode";
				mSG_RTN_IDTL[4] = 0;
				mSG_RTN_IDTL[0, 4] = "DmName";
				mSG_RTN_IDTL[5] = 0;
				mSG_RTN_IDTL[0, 5] = "DmColor";
				mSG_RTN_IDTL[6] = 0;
				mSG_RTN_IDTL[0, 6] = "DmSize";
				mSG_RTN_IDTL[7] = 0;
				mSG_RTN_IDTL[0, 7] = "DmOrigin";
				mSG_RTN_IDTL[8] = 0;
				mSG_RTN_IDTL[0, 8] = "Remark";
				mSG_RTN_IDTL[9] = 0;
				mSG_RTN_IDTL[0, 9] = "DmSfNo";
			}
			mSG_RTN_IDTL[10] = (int)Math.Round(650.0 * ColCon);
			mSG_RTN_IDTL[10] = 7;
			mSG_RTN_IDTL[0, 10] = "Pcs";
			mSG_RTN_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_RTN_IDTL[12] = 7;
			mSG_RTN_IDTL[0, 12] = "Gwt";
			mSG_RTN_IDTL[11] = (int)Math.Round(0.0 * ColCon);
			mSG_RTN_IDTL[11] = 7;
			mSG_RTN_IDTL[0, 11] = "KrWt";
			mSG_RTN_IDTL[13] = (int)Math.Round(750.0 * ColCon);
			mSG_RTN_IDTL[13] = 7;
			mSG_RTN_IDTL[0, 13] = "Con%";
			mSG_RTN_IDTL[14] = (int)Math.Round(700.0 * ColCon);
			mSG_RTN_IDTL[14] = 3;
			mSG_RTN_IDTL[0, 14] = "P/W";
			mSG_RTN_IDTL[15] = (int)Math.Round(800.0 * ColCon);
			mSG_RTN_IDTL[15] = 7;
			mSG_RTN_IDTL[0, 15] = "Rate";
			mSG_RTN_IDTL[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[16] = 7;
			mSG_RTN_IDTL[0, 16] = "ItAmt";
			mSG_RTN_IDTL[17] = (int)Math.Round(0.0 * ColCon);
			mSG_RTN_IDTL[17] = 7;
			mSG_RTN_IDTL[0, 17] = "LbrRate";
			mSG_RTN_IDTL[18] = (int)Math.Round(0.0 * ColCon);
			mSG_RTN_IDTL[18] = 7;
			mSG_RTN_IDTL[0, 18] = "LbrAmt";
			mSG_RTN_IDTL[19] = (int)Math.Round(1000.0 * ColCon);
			mSG_RTN_IDTL[19] = 7;
			mSG_RTN_IDTL[0, 19] = "NetAmt";
			mSG_RTN_IDTL[20] = 0;
			mSG_RTN_IDTL[0, 20] = "ConWt";
			mSG_RTN_IDTL[21] = 0;
			mSG_RTN_IDTL[0, 21] = "KrConWt";
			mSG_RTN_IDTL[22] = 0;
			mSG_RTN_IDTL[0, 22] = "ItType";
			mSG_RTN_IDTL[23] = 0;
			mSG_RTN_IDTL[0, 23] = "RowSrNo";
			mSG_RTN_IDTL.Row = 1;
			mSG_RTN_IDTL.Col = 0;
			((Control)TEXT_RTN_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_RTN_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_RTN_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_RTN_IDTL[DC_Main.M] = 0;
						}
						mSG_RTN_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_RTN_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_RTN_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_RTN_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Rtn_Idtl();
			mSG_RTN_IDTL = null;
		}
	}

	private void CommPassAdd_Rtn_Idtl()
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 0] = Conversions.ToString(mSG_RTN_IDTL.Row);
		mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 23] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 51]));
		mSG_RTN_IDTL = null;
	}

	private void MSG_RTN_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		checked
		{
			if (mSG_RTN_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_RTN_IDTL).Left = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Left + (double)mSG_RTN_IDTL.CellLeft / 15.0);
				((Control)TEXT_RTN_IDTL).Top = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Top + (double)mSG_RTN_IDTL.CellTop / 15.0);
				((Control)TEXT_RTN_IDTL).Width = (int)Math.Round((double)mSG_RTN_IDTL.CellWidth / 15.0);
				((Control)TEXT_RTN_IDTL).Height = (int)Math.Round((double)mSG_RTN_IDTL.CellHeight / 15.0);
				TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
				((Control)TEXT_RTN_IDTL).Visible = true;
				((Control)TEXT_PR).Visible = false;
				((Control)TEXT_ENTRY).Visible = false;
				((Control)TEXT_IDTL).Visible = false;
				((Control)TEXT_ENTRY_2).Visible = false;
				((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
				((Control)TEXT_RTN_IDTL).Focus();
				mSG_RTN_IDTL = null;
			}
		}
	}

	private void MSG_RTN_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		checked
		{
			if (mSG_RTN_IDTL[mSG_RTN_IDTL.Col] == 0)
			{
				TEXT_RTN_IDTL.Text = "";
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_RTN_IDTL[mSG_RTN_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_RTN_IDTL.Col > 1)
						{
							mSG_RTN_IDTL.Col -= 1;
						}
					}
					else if (mSG_RTN_IDTL.Col < mSG_RTN_IDTL.Cols - 1)
					{
						mSG_RTN_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (!((mSG_RTN_IDTL.Row == 0) | (mSG_RTN_IDTL.CellWidth <= 0)) && mSG_RTN_IDTL[mSG_RTN_IDTL.Col] != 0)
			{
				((Control)TEXT_RTN_IDTL).Left = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Left + (double)mSG_RTN_IDTL.CellLeft / 15.0);
				((Control)TEXT_RTN_IDTL).Top = (int)Math.Round((double)((Control)mSG_RTN_IDTL).Top + (double)mSG_RTN_IDTL.CellTop / 15.0);
				((Control)TEXT_RTN_IDTL).Width = (int)Math.Round((double)mSG_RTN_IDTL.CellWidth / 15.0);
				((Control)TEXT_RTN_IDTL).Height = (int)Math.Round((double)mSG_RTN_IDTL.CellHeight / 15.0);
				((Control)TEXT_RTN_IDTL).Visible = true;
				((TextBoxBase)TEXT_RTN_IDTL).ReadOnly = false;
				switch (MSG_RTN_IDTL.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 5;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 2:
				case 4:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 50;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 5:
				case 6:
				case 9:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 15;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 7:
				case 8:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 20;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 14:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 1;
					TEXT_RTN_IDTL.Text = mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 6;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0");
					break;
				case 13:
				case 15:
				case 16:
				case 17:
				case 18:
				case 19:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 10;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0.00");
					break;
				case 11:
				case 12:
				case 20:
					((TextBoxBase)TEXT_RTN_IDTL).MaxLength = 10;
					TEXT_RTN_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col]), "0.000");
					break;
				}
				mSG_RTN_IDTL = null;
				((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
			}
		}
	}

	private void MSG_RTN_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_RTN_IDTL.Row != 0 && MSG_RTN_IDTL[MSG_RTN_IDTL.Col] != 0 && ((Control)TEXT_RTN_IDTL).Visible)
		{
			AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
			switch (MSG_RTN_IDTL.Col)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 14:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = TEXT_RTN_IDTL.Text;
				break;
			case 10:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			case 13:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.00");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			case 11:
			case 12:
			case 20:
				mSG_RTN_IDTL[mSG_RTN_IDTL.Row, mSG_RTN_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.000");
				CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
				break;
			}
			mSG_RTN_IDTL = null;
		}
	}

	private void TEXT_RTN_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_RTN_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Invalid comparison between Unknown and I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Invalid comparison between Unknown and I4
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = RtnIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][23])) == Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][0])) == Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 0])))
						{
							RtnIdtl.Rows.Remove(RtnIdtl.Rows[i]);
							RtnIdtl.AcceptChanges();
							break;
						}
					}
					int num2 = mSG_RTN_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Rtn_Idtl(1);
					TEXT_RTN_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_RTN_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_RTN_IDTL.Col = checked(mSG_RTN_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_RTN_IDTL.Col < 19)
				{
					mSG_RTN_IDTL.Col = checked(mSG_RTN_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_RTN_IDTL.Row > 1)
				{
					mSG_RTN_IDTL.Row = checked(mSG_RTN_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_RTN_IDTL.Row < mSG_RTN_IDTL.Rows - 1)
					{
						mSG_RTN_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_RTN_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_RTN_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_RTN_IDTL).Visible = false;
							MSG_PR.Col += 1;
							MSG_PR_EnterCell(MSG_PR, new EventArgs());
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_RTN_IDTL.Text + "'";
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
									TEXT_RTN_IDTL.Text = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 22] = DC_Main.ColValue[4];
								}
								((Control)TEXT_RTN_IDTL).Focus();
							}
							return;
						}
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						break;
					case 3:
						if (Operators.CompareString(TEXT_RTN_IDTL.Text, "", false) == 0 || mSG_RTN_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_RTN_IDTL.Text + "'";
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
									TEXT_RTN_IDTL.Text = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_RTN_IDTL).Focus();
							}
							return;
						}
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_CODE"], (object)""));
						mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 15]) == 0.0)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 19:
						if (mSG_RTN_IDTL.Row == mSG_RTN_IDTL.Rows - 1)
						{
							mSG_RTN_IDTL[mSG_RTN_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(TEXT_RTN_IDTL.Text), "0.00");
							CommPassTotal_Rtn_Idtl(mSG_RTN_IDTL.Row);
							MsgClearIdtl = true;
							mSG_RTN_IDTL.Rows += 1;
							mSG_RTN_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_RTN_IDTL.Col = 1;
							CommPassAdd_Rtn_Idtl();
						}
						else
						{
							mSG_RTN_IDTL.Row += 1;
							mSG_RTN_IDTL.Col = 1;
							((Control)TEXT_RTN_IDTL).Visible = true;
							((Control)TEXT_RTN_IDTL).Focus();
						}
						return;
					}
					if (mSG_RTN_IDTL.Col < mSG_RTN_IDTL.Cols - 1)
					{
						mSG_RTN_IDTL.Col += 1;
					}
					((Control)TEXT_RTN_IDTL).Visible = true;
					((Control)TEXT_RTN_IDTL).Focus();
				}
			}
		}
		mSG_RTN_IDTL = null;
	}

	private void CommPassTotal_Rtn_Idtl(int CRow)
	{
		AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
		if ((Conversion.Val(mSG_RTN_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 12]) == 0.0))
		{
			mSG_RTN_IDTL[CRow, 12] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 11]), "0.000");
		}
		if ((Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 11]) == 0.0))
		{
			mSG_RTN_IDTL[CRow, 11] = Strings.Format((object)Conversion.Val(mSG_RTN_IDTL[CRow, 12]), "0.000");
		}
		if ((Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 13]) != 0.0))
		{
			mSG_RTN_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 12]) * Conversion.Val(mSG_RTN_IDTL[CRow, 13])), "0.000");
		}
		else
		{
			mSG_RTN_IDTL[CRow, 20] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_RTN_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 13]) != 0.0))
		{
			mSG_RTN_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 11]) * Conversion.Val(mSG_RTN_IDTL[CRow, 13])), "0.000");
		}
		else
		{
			mSG_RTN_IDTL[CRow, 21] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_RTN_IDTL[CRow, 14], "", false) == 0)
		{
			if ((Conversion.Val(mSG_RTN_IDTL[CRow, 12]) == 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 15]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 15]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_RTN_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_RTN_IDTL[CRow, 15]) != 0.0))
			{
				mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 15]) * Conversion.Val(mSG_RTN_IDTL[CRow, 12])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_RTN_IDTL[CRow, 14], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_RTN_IDTL[CRow, 15])))) != 0)
		{
			mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 15]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_RTN_IDTL[CRow, 15]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 15]) * Conversion.Val(mSG_RTN_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_RTN_IDTL[CRow, 17]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 17]) * Conversion.Val(mSG_RTN_IDTL[CRow, 10])), "0.00");
		}
		if (Conversion.Val(mSG_RTN_IDTL[CRow, 16]) + Conversion.Val(mSG_RTN_IDTL[CRow, 18]) != 0.0)
		{
			mSG_RTN_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_RTN_IDTL[CRow, 16]) + Conversion.Val(mSG_RTN_IDTL[CRow, 18])), "0.00");
		}
		checked
		{
			int num = mSG_RTN_IDTL.Rows - 1;
			DC_Main.M = 1;
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			while (DC_Main.M <= num)
			{
				num2 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 20]);
				num3 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 21]);
				num4 += Conversion.Val(mSG_RTN_IDTL[DC_Main.M, 19]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 11] = Strings.Format((object)num2, "0.000");
				MSG_PR[MSG_PR.Row, 12] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 10]) - Conversion.Val(MSG_PR[MSG_PR.Row, 11])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 27] = Strings.Format((object)num4, "0.00");
			}
			if (Operators.CompareString(mSG_RTN_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num5 = RtnIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][23])) == Conversion.Val(mSG_RTN_IDTL[CRow, 23])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][0])) == Conversion.Val(mSG_RTN_IDTL[CRow, 0])))
					{
						flag = true;
						RtnIdtl.Rows[i][0] = mSG_RTN_IDTL[CRow, 0];
						RtnIdtl.Rows[i][1] = mSG_RTN_IDTL[CRow, 1];
						RtnIdtl.Rows[i][2] = mSG_RTN_IDTL[CRow, 2];
						RtnIdtl.Rows[i][3] = mSG_RTN_IDTL[CRow, 3];
						RtnIdtl.Rows[i][4] = mSG_RTN_IDTL[CRow, 4];
						RtnIdtl.Rows[i][5] = mSG_RTN_IDTL[CRow, 5];
						RtnIdtl.Rows[i][6] = mSG_RTN_IDTL[CRow, 6];
						RtnIdtl.Rows[i][7] = mSG_RTN_IDTL[CRow, 7];
						RtnIdtl.Rows[i][8] = mSG_RTN_IDTL[CRow, 8];
						RtnIdtl.Rows[i][9] = mSG_RTN_IDTL[CRow, 9];
						RtnIdtl.Rows[i][10] = mSG_RTN_IDTL[CRow, 10];
						RtnIdtl.Rows[i][12] = mSG_RTN_IDTL[CRow, 12];
						RtnIdtl.Rows[i][11] = mSG_RTN_IDTL[CRow, 11];
						RtnIdtl.Rows[i][13] = mSG_RTN_IDTL[CRow, 13];
						RtnIdtl.Rows[i][14] = mSG_RTN_IDTL[CRow, 14];
						RtnIdtl.Rows[i][15] = mSG_RTN_IDTL[CRow, 15];
						RtnIdtl.Rows[i][16] = mSG_RTN_IDTL[CRow, 16];
						RtnIdtl.Rows[i][17] = mSG_RTN_IDTL[CRow, 17];
						RtnIdtl.Rows[i][18] = mSG_RTN_IDTL[CRow, 18];
						RtnIdtl.Rows[i][19] = mSG_RTN_IDTL[CRow, 19];
						RtnIdtl.Rows[i][20] = mSG_RTN_IDTL[CRow, 20];
						RtnIdtl.Rows[i][21] = mSG_RTN_IDTL[CRow, 21];
						RtnIdtl.Rows[i][22] = mSG_RTN_IDTL[CRow, 22];
						RtnIdtl.Rows[i][23] = mSG_RTN_IDTL[CRow, 23];
						break;
					}
				}
				if (!flag)
				{
					Rtndr = RtnIdtl.NewRow();
					Rtndr[0] = mSG_RTN_IDTL[CRow, 0];
					Rtndr[1] = mSG_RTN_IDTL[CRow, 1];
					Rtndr[2] = mSG_RTN_IDTL[CRow, 2];
					Rtndr[3] = mSG_RTN_IDTL[CRow, 3];
					Rtndr[4] = mSG_RTN_IDTL[CRow, 4];
					Rtndr[5] = mSG_RTN_IDTL[CRow, 5];
					Rtndr[6] = mSG_RTN_IDTL[CRow, 6];
					Rtndr[7] = mSG_RTN_IDTL[CRow, 7];
					Rtndr[8] = mSG_RTN_IDTL[CRow, 8];
					Rtndr[9] = mSG_RTN_IDTL[CRow, 9];
					Rtndr[10] = mSG_RTN_IDTL[CRow, 10];
					Rtndr[12] = mSG_RTN_IDTL[CRow, 12];
					Rtndr[11] = mSG_RTN_IDTL[CRow, 11];
					Rtndr[13] = mSG_RTN_IDTL[CRow, 13];
					Rtndr[14] = mSG_RTN_IDTL[CRow, 14];
					Rtndr[15] = mSG_RTN_IDTL[CRow, 15];
					Rtndr[16] = mSG_RTN_IDTL[CRow, 16];
					Rtndr[17] = mSG_RTN_IDTL[CRow, 17];
					Rtndr[18] = mSG_RTN_IDTL[CRow, 18];
					Rtndr[19] = mSG_RTN_IDTL[CRow, 19];
					Rtndr[20] = mSG_RTN_IDTL[CRow, 20];
					Rtndr[21] = mSG_RTN_IDTL[CRow, 21];
					Rtndr[22] = mSG_RTN_IDTL[CRow, 22];
					Rtndr[23] = mSG_RTN_IDTL[CRow, 23];
					RtnIdtl.Rows.Add(Rtndr);
				}
			}
			mSG_RTN_IDTL = null;
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		MsgPrClear = true;
		mSG_PR.Clear();
		mSG_PR.Cols = 71;
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
			mSG_PR[1] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[1] = 0;
			mSG_PR[0, 1] = "RecCode";
			mSG_PR[2] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[2] = 3;
			mSG_PR[0, 2] = "TagNo";
			mSG_PR[3] = (int)Math.Round(2200.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "Receive Item";
			mSG_PR[4] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Counter";
			mSG_PR[5] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[5] = 0;
			mSG_PR[0, 5] = "Design";
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG_PR[6] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "Style";
			}
			else
			{
				mSG_PR[6] = 0;
			}
			mSG_PR[7] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[7] = 0;
			mSG_PR[0, 7] = "Size";
			mSG_PR[8] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[8] = 0;
			mSG_PR[0, 8] = "HmId";
			mSG_PR[9] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "Pcs";
			mSG_PR[10] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "GrWt";
			mSG_PR[11] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "OthWt";
			mSG_PR[12] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "NetWt";
			mSG_PR[14] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[14] = 7;
			mSG_PR[0, 14] = "Ght%";
			mSG_PR[15] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "GhtWt";
			mSG_PR[16] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "Touch";
			mSG_PR[17] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "West%";
			mSG_PR[18] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "Fine";
			mSG_PR[19] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "Rate";
			mSG_PR[20] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "ItAmt";
			mSG_PR[13] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[13] = 3;
			mSG_PR[0, 13] = "LCode";
			mSG_PR[21] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[21] = 7;
			mSG_PR[0, 21] = "Lbr%";
			mSG_PR[22] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[22] = 3;
			mSG_PR[0, 22] = "Ltype";
			mSG_PR[23] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[23] = 7;
			mSG_PR[0, 23] = "LRate";
			mSG_PR[24] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "LAmt";
			mSG_PR[25] = (int)Math.Round(850.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "LDisc%";
			mSG_PR[26] = (int)Math.Round(950.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "LDiscAmt";
			mSG_PR[27] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "OthAmt";
			mSG_PR[28] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "RtnMrp";
			mSG_PR[29] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[29] = 3;
			mSG_PR[0, 29] = "TgLCode";
			mSG_PR[30] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[30] = 7;
			mSG_PR[0, 30] = "Tag%";
			mSG_PR[31] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "TagLRate";
			mSG_PR[32] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[32] = 7;
			mSG_PR[0, 32] = "TagLAmt";
			mSG_PR[33] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[33] = 7;
			mSG_PR[0, 33] = "TagOtAmt";
			mSG_PR[34] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[34] = 7;
			mSG_PR[0, 34] = "TagCost";
			mSG_PR[35] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[35] = 7;
			mSG_PR[0, 35] = "TagMrp";
			mSG_PR[36] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[36] = 7;
			mSG_PR[0, 36] = "TotAmt";
			mSG_PR[37] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[37] = 7;
			mSG_PR[0, 37] = "TaxPrc";
			mSG_PR[38] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[38] = 7;
			mSG_PR[0, 38] = "NetAmt";
			mSG_PR[39] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[39] = 3;
			mSG_PR[0, 39] = "KrCode";
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
			mSG_PR[50] = 0;
			mSG_PR[51] = 0;
			mSG_PR[52] = 0;
			mSG_PR[53] = 0;
			mSG_PR[54] = 0;
			mSG_PR[55] = 0;
			mSG_PR[56] = 0;
			mSG_PR[57] = 0;
			mSG_PR[58] = 0;
			mSG_PR[59] = 0;
			mSG_PR[60] = 0;
			mSG_PR[61] = 0;
			mSG_PR[62] = 0;
			mSG_PR[63] = 0;
			mSG_PR[64] = 0;
			mSG_PR[65] = 0;
			mSG_PR[66] = 0;
			mSG_PR[67] = 0;
			mSG_PR[68] = 0;
			mSG_PR[69] = 0;
			mSG_PR[70] = 0;
			mSG_PR.Row = 1;
			mSG_PR.Col = 1;
			((Control)TEXT_PR).Visible = false;
			MsgPrClear = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'SALES RETURNE' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
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
		mSG_PR[mSG_PR.Row, 22] = DC_Main.MsLbrType;
		mSG_PR[mSG_PR.Row, 50] = "N";
		mSG_PR[mSG_PR.Row, 57] = "A";
		mSG_PR[mSG_PR.Row, 9] = Conversions.ToString(1);
		mSG_PR[mSG_PR.Row, 68] = "N";
		mSG_PR[mSG_PR.Row, 69] = "N";
		mSG_PR[mSG_PR.Row, 70] = ItmDataType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(MSG_PR.Row);
		}
		else
		{
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(Conversion.Val(mSG_PR[checked(mSG_PR.Row - 1), 51]) + 1.0);
		}
		mSG_PR[mSG_PR.Row, 40] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm") + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 51]));
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
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_1e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e98: Invalid comparison between Unknown and I4
		//IL_1ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eeb: Invalid comparison between Unknown and I4
		//IL_03b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1a: Invalid comparison between Unknown and I4
		//IL_1c45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4f: Invalid comparison between Unknown and I4
		//IL_1f88: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8b: Invalid comparison between Unknown and I4
		//IL_2104: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d65: Unknown result type (might be due to invalid IL or missing references)
		//IL_2502: Unknown result type (might be due to invalid IL or missing references)
		//IL_2826: Unknown result type (might be due to invalid IL or missing references)
		//IL_2681: Unknown result type (might be due to invalid IL or missing references)
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
					int num = (int)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 51]));
					List<DataRow> list = new List<DataRow>();
					int num2 = RtnIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[DC_Main.M][23])) == Conversion.Val(mSG_PR[mSG_PR.Row, 51]))
						{
							list.Add(RtnIdtl.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						RtnIdtl.Rows.Remove(item);
						RtnIdtl.AcceptChanges();
					}
					int num3 = mSG_PR.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG_PR[mSG_PR.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_PR.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			checked
			{
				if ((mSG_PR.Col == 1) & (Operators.CompareString(tIsuNo.Text, "", false) != 0) & (Operators.CompareString(tIsuDbCd.Text, "", false) != 0) & (Operators.CompareString(TEXT_PR.Text, "", false) == 0))
				{
					DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.ITM_RATE As RateR,A.LBR_RATE As LbrRateR,A.IT_CODE As ItCodeL,A.VCH_SRNO As VchSrnoM FROM SL_DETL AS A  LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND TAG_NO NOT IN(SELECT B.TAG_NO FROM SL_DATA AS A LEFT JOIN SL_DETL_RTN AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + tIsuYrCd.Text + "' AND A.ISU_DBCD = '" + tIsuDbCd.Text + "' AND A.ISU_NO = '" + tIsuNo.Text + "') ORDER BY A.SR_NO";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[9];
					DC_Main.ColWidth[0] = 100.0;
					DC_Main.ColWidth[1] = 170.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 100.0;
					DC_Main.ColWidth[4] = 110.0;
					DC_Main.ColWidth[5] = 100.0;
					DC_Main.ColWidth[6] = 0.0;
					DC_Main.ColWidth[7] = 0.0;
					DC_Main.HelpSelect = 0;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_PR.Text = DC_Main.ColValue[6];
						mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[0];
						mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[1];
						mSG_PR[mSG_PR.Row, 1] = DC_Main.ColValue[6];
						mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[2]), "0.000");
						mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0.000");
						DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE As PrCode,B.IT_NAME From SL_DETL As A LEFT JOIN ITEM_MAST As B On A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND TAG_NO = '" + mSG_PR[mSG_PR.Row, 2] + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							DC_Main.i = mSG_PR.Row;
							mSG_PR[DC_Main.i, 0] = Conversions.ToString(mSG_PR.Row);
							mSG_PR[DC_Main.i, 51] = Conversions.ToString(mSG_PR.Row);
							TEXT_PR.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG_PR[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG_PR[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG_PR[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG_PR[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_STYLE"], (object)""));
							mSG_PR[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG_PR[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG_PR[DC_Main.i, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG_PR[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG_PR[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG_PR[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG_PR[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG_PR[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG_PR[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG_PR[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DISC_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DISC_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG_PR[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							mSG_PR[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG_PR[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG_PR[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TOT_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"])), "0.00");
							mSG_PR[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["NET_AMT"])), "0.00");
							mSG_PR[DC_Main.i, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG_PR[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[DC_Main.i, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG_PR[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG_PR[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG_PR[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG_PR[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG_PR[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG_PR[DC_Main.i, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG_PR[DC_Main.i, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG_PR[DC_Main.i, 50] = "N";
							mSG_PR[DC_Main.i, 68] = "N";
							mSG_PR[DC_Main.i, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							int num4 = 0;
							int num5 = DtIdtl.Rows.Count - 1;
							int num6 = num5;
							for (int i = 0; i <= num6; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(RtnIdtl.Rows[num4][23], (object)Conversion.Val(mSG_PR[DC_Main.i, 51]), false))
								{
									RtnIdtl.Rows[num4].Delete();
									RtnIdtl.AcceptChanges();
									num4--;
								}
								num4++;
							}
							MSG_IDTL_CLEAR();
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' AND TAG_NO = '" + mSG_PR[mSG_PR.Row, 2] + "' ORDER BY A.SR_NO,A.ISR_NO";
							RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.i = 0;
							while (DC_Main.i < RsIdtl.Rows.Count)
							{
								Rtndr = RtnIdtl.NewRow();
								Rtndr[23] = MSG_PR.Row;
								Rtndr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
								Rtndr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
								Rtndr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
								Rtndr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
								Rtndr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
								Rtndr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
								Rtndr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
								Rtndr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
								Rtndr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
								Rtndr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
								Rtndr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
								Rtndr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
								Rtndr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
								Rtndr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
								Rtndr[14] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
								Rtndr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
								Rtndr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
								Rtndr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
								Rtndr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
								Rtndr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
								Rtndr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
								Rtndr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
								Rtndr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
								RtnIdtl.Rows.Add(Rtndr);
								DC_Main.i++;
							}
						}
						RtnOldRow = 0;
						CommPassTotal_Pr(MSG_PR.Row);
						MSG_PR_RowColChange(MSG_PR, new EventArgs());
						MSG_PR_TOT_FILL();
						((Control)TEXT_PR).Focus();
					}
					else
					{
						mSG_PR[mSG_PR.Row, 1] = "";
						((Control)TEXT_PR).Focus();
					}
					return;
				}
				if (mSG_PR.Col == 5)
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[11];
					DC_Main.ColWidth[0] = 120.0;
					DC_Main.ColWidth[1] = 120.0;
					DC_Main.ColWidth[2] = 150.0;
					DC_Main.ColWidth[3] = 110.0;
					DC_Main.ColWidth[4] = 100.0;
					DC_Main.ColWidth[5] = 100.0;
					DC_Main.ColWidth[6] = 100.0;
					DC_Main.ColWidth[7] = 100.0;
					DC_Main.ColWidth[8] = 100.0;
					DC_Main.ColWidth[9] = 0.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_PR.Text = DC_Main.ColValue[0];
						mSG_PR[mSG_PR.Row, 5] = DC_Main.ColValue[0];
						mSG_PR[mSG_PR.Row, 7] = DC_Main.ColValue[3];
						mSG_PR[mSG_PR.Row, 39] = DC_Main.ColValue[4];
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (Conversion.Val(DC_Main.ColValue[5]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 16] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
							}
							if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
							}
						}
						mSG_PR[mSG_PR.Row, 69] = DC_Main.ColValue[9];
						RtnOldRow = 0;
						MSG_PR_RowColChange(MSG_PR, new EventArgs());
					}
					((Control)TEXT_PR).Focus();
					return;
				}
				TEXT_PR.Text = "";
				mSG_PR[mSG_PR.Row, 5] = "";
				mSG_PR[mSG_PR.Row, 69] = "N";
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
				if (mSG_PR.Col < 38)
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
				RtnOldRow = 0;
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
					RtnOldRow = 0;
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
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.IT_NAME";
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
									mSG_PR[mSG_PR.Row, 3] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 43] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""));
						mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR[mSG_PR.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 54], mSG_PR[mSG_PR.Row, 55], false) != 0) | (Operators.CompareString(mSG_PR[mSG_PR.Row, 52], mSG_PR[mSG_PR.Row, 53], false) != 0))
						{
							mSG_PR[mSG_PR.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG_PR[mSG_PR.Row, 2] = "";
							mSG_PR[mSG_PR.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						MsgOldRow = 0;
						break;
					case 4:
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_PR.Text + "'";
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 4] = DC_Main.ColValue[1];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						mSG_PR[mSG_PR.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 6:
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "SELECT MODEL_NAME  From MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MODEL_NAME = '" + TEXT_PR.Text + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT DISTINCT MODEL_NAME as StyleL From MODEL_MAST ORDER BY MODEL_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[2];
							DC_Main.ColWidth[0] = 350.0;
							DC_Main.HelpSelect = 1;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (DC_Main.MsCreat)
							{
								MS_STYLE mS_STYLE = new MS_STYLE();
								DC_Main.MsUserRightForm = "Style";
								((Form)mS_STYLE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
								((Control)mS_STYLE).Show();
								((Control)mS_STYLE).Focus();
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_PR.Text = DC_Main.ColValue[0];
								return;
							}
						}
						break;
					case 13:
					{
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						string text = mSG_PR[mSG_PR.Row, 13];
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_PR.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						string text2;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT LBR_CODE As LbrCodeL,LBR_CATG as CategoryL,LBR_VAL As LbrValueR  FROM LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LBR_CATG,LBR_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_PR.Text = DC_Main.ColValue[0];
									text2 = Strings.Mid(DC_Main.ColValue[0], 1, 2);
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						if (Operators.CompareString(text, TEXT_PR.Text, false) != 0)
						{
							mSG_PR[mSG_PR.Row, 23] = "";
							mSG_PR[mSG_PR.Row, 24] = "";
							mSG_PR[mSG_PR.Row, 21] = "";
							mSG_PR[mSG_PR.Row, 14] = "";
							mSG_PR[mSG_PR.Row, 17] = "";
							mSG_PR[mSG_PR.Row, 28] = "";
						}
						text2 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG_PR[mSG_PR.Row, 13] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						if (Operators.CompareString(mSG_PR[mSG_PR.Row, 29], "", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 29] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						}
						switch (text2)
						{
						case "01":
							mSG_PR[mSG_PR.Row, 23] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG_PR[mSG_PR.Row, 21] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG_PR[mSG_PR.Row, 24] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG_PR[mSG_PR.Row, 17] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "05":
							mSG_PR[mSG_PR.Row, 14] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG_PR[mSG_PR.Row, 22] = "K";
							mSG_PR[mSG_PR.Row, 23] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG_PR[mSG_PR.Row, 28] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal_Pr(mSG_PR.Row);
						break;
					}
					case 29:
					{
						if (Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							break;
						}
						string text3 = mSG_PR[mSG_PR.Row, 29];
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_PR.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						string text4;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT LBR_CODE As LbrCodeL,LBR_CATG as CategoryL,LBR_VAL As LbrValueR  FROM LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY LBR_CATG,LBR_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_PR.Text = DC_Main.ColValue[0];
									text4 = Strings.Mid(DC_Main.ColValue[0], 1, 2);
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						if (Operators.CompareString(text3, TEXT_PR.Text, false) != 0)
						{
							mSG_PR[mSG_PR.Row, 31] = "";
							mSG_PR[mSG_PR.Row, 32] = "";
							mSG_PR[mSG_PR.Row, 30] = "";
							mSG_PR[mSG_PR.Row, 35] = "";
						}
						text4 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG_PR[mSG_PR.Row, 29] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text4)
						{
						case "01":
							mSG_PR[mSG_PR.Row, 31] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG_PR[mSG_PR.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG_PR[mSG_PR.Row, 32] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG_PR[mSG_PR.Row, 31] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG_PR[mSG_PR.Row, 35] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal_Pr(mSG_PR.Row);
						break;
					}
					case 10:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 44], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
						CommPassTotal_Pr(mSG_PR.Row);
						((Control)TEXT_PR).Visible = false;
						MSG_RTN_IDTL.Row = MSG_RTN_IDTL.Rows - 1;
						MSG_RTN_IDTL.Col = 1;
						MSG_RTN_IDTL_EnterCell(MSG_RTN_IDTL, new EventArgs());
						((Control)TEXT_RTN_IDTL).Focus();
						((TextBoxBase)TEXT_RTN_IDTL).SelectAll();
						return;
					case 39:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG_PR[mSG_PR.Row, 2] + "','" + mSG_PR[mSG_PR.Row, 40] + "','" + mSG_PR[mSG_PR.Row, 54] + "','" + mSG_PR[mSG_PR.Row, 52] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							MsgPrClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							MsgPrClear = false;
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
			case 1:
			case 39:
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 13:
			case 29:
				((TextBoxBase)TEXT_PR).MaxLength = 4;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 8:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 5:
			case 7:
				((TextBoxBase)TEXT_PR).MaxLength = 20;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 22:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 25:
			case 26:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 30:
			case 31:
			case 32:
			case 35:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				if (Operators.CompareString(mSG_PR[mSG_PR.Row, 13], "", false) != 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 9:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 14:
			case 16:
			case 17:
			case 19:
			case 20:
			case 21:
			case 23:
			case 24:
			case 27:
			case 28:
			case 33:
			case 34:
			case 36:
			case 37:
			case 38:
			case 41:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 10:
			case 11:
			case 12:
			case 15:
			case 18:
			case 42:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			}
			mSG_PR = null;
			((TextBoxBase)TEXT_PR).SelectAll();
		}
	}

	private void MSG_PR_LeaveCell(object sender, EventArgs e)
	{
		if (MsgPrClear || MSG_PR.Row == 0 || MSG_PR[MSG_PR.Col] == 0 || !((Control)TEXT_PR).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		switch (MSG_PR.Col)
		{
		case 1:
			if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 2], "", false) == 0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "", false) != 0) & (mSG_PR.Row == checked(mSG_PR.Rows - 1)) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 57], "A", false) == 0))
			{
				NewTagNo(mSG_PR.Row);
			}
			break;
		case 21:
		case 23:
		case 24:
		case 25:
		case 26:
		case 28:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 0:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 13:
		case 22:
		case 29:
		case 39:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 9:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 14:
		case 16:
		case 17:
		case 19:
		case 20:
		case 27:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 41:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 10:
		case 11:
		case 12:
		case 15:
		case 18:
		case 42:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		}
		mSG_PR = null;
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			RepitTagNo(Y);
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Operators.CompareString(DC_Main.MCo_Type, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG_PR[Y, 52] + "'  AND B.TAG_TYPE = '" + mSG_PR[Y, 54] + "' ORDER BY A.TAG_NO DESC";
		}
		else
		{
			DC_Main.RsQry = "SELECT TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG_PR[Y, 52] + "'  AND TAG_TYPE = '" + mSG_PR[Y, 54] + "' ORDER BY TAG_SRNO DESC";
		}
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				CurTagNo = "0001";
			}
			else
			{
				CurTagNo = "00001";
			}
		}
		else if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
		}
		else
		{
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "00000");
		}
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 2], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 52], mSG_PR[Y, 52], false) == 0) & (Operators.CompareString(mSG_PR[DC_Main.i, 54], mSG_PR[Y, 54], false) == 0) & (Conversion.Val(mSG_PR[DC_Main.i, 56]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG_PR[DC_Main.i, 56]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG_PR[mSG_PR.Row, 56] = CurTagNo;
			mSG_PR[mSG_PR.Row, 2] = mSG_PR[Y, 52] + mSG_PR[Y, 43] + CurTagNo;
			mSG_PR = null;
			dataTable.Clear();
		}
	}

	private void RepitTagNo(int Y)
	{
		checked
		{
			DataTable dataTable;
			DataTable dataTable2;
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,4) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG_PR[Y, 52] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 54] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "0001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 54] + "' AND  PR_CODE = '" + MSG_PR[Y, 52] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 4));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "0000");
							break;
						}
						DC_Main.X++;
					}
					if (num2 >= num)
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "0000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num = (int)Math.Round(a);
					int num2 = 0;
					CurRptTagNo = Strings.Format((object)(num + 1), "0000");
					double num3 = 0.0;
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 54] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 52] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 43] + "' AND  PR_CODE = '" + MSG_PR[Y, 52] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num4 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 7));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "0000");
							num4 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num4 != Conversion.Val((object)num2))
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "0000");
					}
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,5) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG_PR[Y, 52] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG_PR[Y, 54] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "00001";
					int num = 1;
					int num2 = 0;
					double num3 = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO ,'',0 FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 54] + "' AND  PR_CODE = '" + MSG_PR[Y, 52] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 5));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "00000");
							break;
						}
						DC_Main.X++;
					}
					if (num2 >= num)
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "00000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a2 = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num = (int)Math.Round(a2);
					int num2 = 0;
					CurRptTagNo = Strings.Format((object)(num + 1), "00000");
					double num3 = 0.0;
					DC_Main.RsQry = "Select A.TAG_NO From MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND  A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.TAG_TYPE = '" + MSG_PR[Y, 54] + "' AND  B.PR_CODE = '" + MSG_PR[Y, 52] + "' AND B.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8   GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0   UNION ALL SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_TYPE = '" + MSG_PR[Y, 43] + "' AND  PR_CODE = '" + MSG_PR[Y, 52] + "' GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num5 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num3 = Conversions.ToDouble(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 5));
						num2++;
						if ((double)num2 != num3)
						{
							CurRptTagNo = Strings.Format((object)num2, "00000");
							num5 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num5 != Conversion.Val((object)num2))
					{
						CurRptTagNo = Strings.Format((object)(num2 + 1), "00000");
					}
				}
			}
			MSG_PR[Y, 56] = Conversions.ToString(Conversion.Val(CurRptTagNo));
			MSG_PR[Y, 2] = MSG_PR[Y, 52] + MSG_PR[Y, 54] + CurRptTagNo;
			TEXT_ENTRY.Text = MSG_PR[Y, 2];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void CommPassTotal_Pr(int CRow)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 15] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 14]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != Conversion.Val(mSG_PR[mSG_PR.Row, 45]))
		{
			mSG_PR[mSG_PR.Row, 45] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 10]), "0.000");
			mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) - Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) - Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != Conversion.Val(mSG_PR[mSG_PR.Row, 46]))
		{
			mSG_PR[mSG_PR.Row, 46] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 12]), "0.000");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) / 100.0), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 12]), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != Conversion.Val(mSG_PR[mSG_PR.Row, 47]))
		{
			mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 16]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != Conversion.Val(mSG_PR[mSG_PR.Row, 48]))
		{
			mSG_PR[mSG_PR.Row, 48] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 17]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])), "0.000");
		}
		double num;
		if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) != 0)
		{
			num = ((Operators.CompareString(DC_Main.MsSlAmtType, "G", false) != 0) ? (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) : Conversion.Val(mSG_PR[mSG_PR.Row, 10]));
		}
		else if (mSG_PR[18] != 0)
		{
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
			{
				num = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])) / 100.0), "0.000"));
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)num, "0.000");
			}
			else
			{
				num = Conversion.Val(mSG_PR[mSG_PR.Row, 12]);
			}
		}
		else
		{
			num = Conversion.Val(mSG_PR[mSG_PR.Row, 12]);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != Conversion.Val(mSG_PR[mSG_PR.Row, 49]))
		{
			mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 19]), "0.00");
			mSG_PR[mSG_PR.Row, 66] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (num + Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
		{
			switch (mSG_PR[mSG_PR.Row, 44])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 19]), 0), "0.00");
				break;
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != Conversion.Val(mSG_PR[mSG_PR.Row, 66])) & (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 66] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
			mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 19]) * Conversion.Val(mSG_PR[mSG_PR.Row, 21]) / 100.0, DC_Main.MsLbrRof), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 30]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 19]) * Conversion.Val(mSG_PR[mSG_PR.Row, 30]) / 100.0, DC_Main.MsLbrRof), "0.00");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != Conversion.Val(mSG_PR[mSG_PR.Row, 58]))
		{
			mSG_PR[mSG_PR.Row, 58] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 23]), "0.00");
			mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(0);
			switch (mSG_PR[mSG_PR.Row, 22])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 23]), 0), "0.00");
				break;
			}
		}
		else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
		{
			switch (mSG_PR[mSG_PR.Row, 22])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsLbrRof), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])), DC_Main.MsLbrRof), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * 1000.0, DC_Main.MsLbrRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 58] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 23]), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) * Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 100.0, DC_Main.MsLbrRof), "0.00");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0)
		{
			switch (mSG_PR[mSG_PR.Row, 22])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 31]), DC_Main.MsLbrRof), "0.00");
				break;
			case "N":
				if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 31]), DC_Main.MsLbrRof), "0.00");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * Conversion.Val(mSG_PR[mSG_PR.Row, 31]), DC_Main.MsLbrRof), "0.00");
				}
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / 1000.0), DC_Main.MsLbrRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * Conversion.Val(mSG_PR[mSG_PR.Row, 31]), DC_Main.MsLbrRof), "0.00");
				break;
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 28]) != 0.0)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 25]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 28]) * Conversion.Val(mSG_PR[mSG_PR.Row, 25]) / 100.0, DC_Main.MsLbrRof), "0.00");
				mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 23]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 28]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26])) / (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) + 100.0) * 100.0, 0), "0.00");
				mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 28]), "0.00");
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
			}
		}
		else
		{
			mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) + Conversion.Val(mSG_PR[mSG_PR.Row, 27]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20]) - Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) == 0.0)
			{
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
				if (mSG_PR.Col == 36)
				{
					if (Conversion.Val(TEXT_PR.Text) != Conversion.Val(mSG_PR[mSG_PR.Row, 36]))
					{
						mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(TEXT_PR.Text) - Conversion.Val(mSG_PR[mSG_PR.Row, 27]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20]) + Conversion.Val(mSG_PR[mSG_PR.Row, 26])), "0.00");
						if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) < 0.0)
						{
							mSG_PR[mSG_PR.Row, 24] = "";
						}
						if ((Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != 0.0))
						{
							switch (mSG_PR[mSG_PR.Row, 22])
							{
							case "P":
								mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsLbrRof), "0.00");
								break;
							case "N":
								if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
								{
									mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
								}
								else
								{
									mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])), DC_Main.MsLbrRof), "0.00");
								}
								break;
							case "K":
								mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15])) / 1000.0, DC_Main.MsLbrRof), "0.00");
								break;
							default:
								mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]), DC_Main.MsLbrRof), "0.00");
								break;
							}
							mSG_PR[mSG_PR.Row, 58] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 23]));
						}
					}
					mSG_PR[mSG_PR.Row, 36] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
					mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
					if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0))
					{
						mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 23]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 19])), "0.000");
					}
				}
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 37]) != Conversion.Val(mSG_PR[mSG_PR.Row, 67])) & (Conversion.Val(mSG_PR[mSG_PR.Row, 28]) == 0.0))
		{
			mSG_PR[mSG_PR.Row, 67] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 37]), "0.00");
			mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 37]) + 100.0) * 100.0, 0), "0.00");
			mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 38]) - Conversion.Val(mSG_PR[mSG_PR.Row, 20]) - Conversion.Val(mSG_PR[mSG_PR.Row, 27]), 0), "0.00");
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0)
			{
				if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.00");
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
				{
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.00");
					}
					else
					{
						mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.00");
					}
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10]) * 1000.0), "0.00");
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 22], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 10]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 23] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 10])), "0.00");
				}
				mSG_PR[mSG_PR.Row, 58] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 23]), "0.00");
			}
		}
		else
		{
			mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 36]), "0.00");
		}
		MSG_PR_TOT_FILL();
		BILL_TOTAL();
		mSG_PR = null;
	}

	private void MSG_PR_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				TotCrFine = 0.0;
				PrOthAmtLess = 0.0;
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				int num = MSG_PR.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_PR_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_PR_TOT[0, 5] = "Total :";
				int num2 = MSG_PR.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_PR_TOT[0, 9] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9])), "0");
					mSG_PR_TOT[0, 10] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10])), "0.000");
					mSG_PR_TOT[0, 11] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 11]) + Conversion.Val(MSG_PR[DC_Main.M, 11])), "0.000");
					mSG_PR_TOT[0, 12] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12])), "0.000");
					mSG_PR_TOT[0, 15] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 15]) + Conversion.Val(MSG_PR[DC_Main.M, 15])), "0.000");
					mSG_PR_TOT[0, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 18]) + Conversion.Val(MSG_PR[DC_Main.M, 18])), "0.000");
					mSG_PR_TOT[0, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 20]) + Conversion.Val(MSG_PR[DC_Main.M, 20])), "0.00");
					mSG_PR_TOT[0, 24] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 24]) + Conversion.Val(MSG_PR[DC_Main.M, 24])), "0.00");
					mSG_PR_TOT[0, 27] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 27]) + Conversion.Val(MSG_PR[DC_Main.M, 27])), "0.00");
					mSG_PR_TOT[0, 42] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 42]) + Conversion.Val(MSG_PR[DC_Main.M, 42])), "0.000");
					mSG_PR_TOT[0, 28] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 28]) + Conversion.Val(MSG_PR[DC_Main.M, 28])), "0.00");
					mSG_PR_TOT[0, 36] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 36]) + Conversion.Val(MSG_PR[DC_Main.M, 36])), "0.00");
					mSG_PR_TOT[0, 38] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 38]) + Conversion.Val(MSG_PR[DC_Main.M, 38])), "0.00");
					mSG_PR_TOT[0, 35] = Strings.Format((object)(Conversion.Val(mSG_PR_TOT[0, 35]) + Conversion.Val(MSG_PR[DC_Main.M, 35])), "0.00");
					DC_Main.M++;
				}
				mSG_PR_TOT = null;
			}
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
				mSG_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[5] = 0;
				mSG_IDTL[0, 5] = "DmColor";
				mSG_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[6] = 3;
				mSG_IDTL[0, 6] = "DmSize";
				mSG_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[7] = 0;
				mSG_IDTL[0, 7] = "DmOrigin";
				mSG_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[8] = 0;
				mSG_IDTL[0, 8] = "DmRemark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_IDTL[3] = 0;
				mSG_IDTL[0, 3] = "DmCode";
				mSG_IDTL[4] = 0;
				mSG_IDTL[0, 4] = "DmName";
				mSG_IDTL[5] = 0;
				mSG_IDTL[0, 5] = "DmColor";
				mSG_IDTL[6] = 0;
				mSG_IDTL[0, 6] = "DmSize";
				mSG_IDTL[7] = 0;
				mSG_IDTL[0, 7] = "DmOrigin";
				mSG_IDTL[8] = 0;
				mSG_IDTL[0, 8] = "Remark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			mSG_IDTL[10] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "Pcs";
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
		mSG_IDTL[mSG_IDTL.Row, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 25]));
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
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Invalid comparison between Unknown and I4
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Invalid comparison between Unknown and I4
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Invalid comparison between Unknown and I4
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0400: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
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
			if (!((mSG_IDTL.Row == 0) | (mSG_IDTL.CellWidth <= 0)) && mSG_IDTL[mSG_IDTL.Col] != 0)
			{
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
					((TextBoxBase)TEXT_IDTL).MaxLength = 15;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 6:
				case 7:
				case 8:
				case 9:
					((TextBoxBase)TEXT_IDTL).MaxLength = 20;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 14:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
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
				case 11:
				case 12:
				case 20:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				}
				mSG_IDTL = null;
				((TextBoxBase)TEXT_IDTL).SelectAll();
			}
		}
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
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 14:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
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
			case 11:
			case 12:
			case 20:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			}
			mSG_IDTL = null;
		}
	}

	private void CommPassTotal_Idtl(int CRow)
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
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
			if ((Conversion.Val(mSG_IDTL[CRow, 12]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 14], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 15])))) != 0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
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
				MSG[MSG.Row, 9] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 10] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 9])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 33] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 34] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 33])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 22] = Strings.Format((object)num4, "0.00");
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
		mSG.Cols = 48;
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
			mSG[0, 5] = "Size";
			mSG[6] = (int)Math.Round(900.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "HmId";
			mSG[7] = (int)Math.Round(650.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "Pcs";
			mSG[8] = (int)Math.Round(1050.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "GrWt";
			mSG[9] = (int)Math.Round(900.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "OthWt";
			mSG[10] = (int)Math.Round(1050.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "NetWt";
			mSG[13] = (int)Math.Round(850.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Touch";
			mSG[14] = (int)Math.Round(850.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "West%";
			mSG[11] = (int)Math.Round(750.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "Ght%";
			mSG[12] = (int)Math.Round(850.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "GhtWt";
			mSG[15] = (int)Math.Round(1100.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Fine";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "ItRate";
			mSG[17] = (int)Math.Round(1100.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "ItAmt";
			mSG[18] = (int)Math.Round(750.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "Lbr%";
			mSG[19] = (int)Math.Round(800.0 * ColCon);
			mSG[19] = 3;
			mSG[0, 19] = "LType";
			mSG[20] = (int)Math.Round(900.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "LbrRate";
			mSG[21] = (int)Math.Round(1100.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "LbrAmt";
			mSG[22] = (int)Math.Round(1000.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "OthAmt";
			mSG[24] = (int)Math.Round(1200.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "NetAmt";
			mSG[23] = (int)Math.Round(1100.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "Mrp";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VS014NSBU", false) == 0)
			{
				mSG[38] = (int)Math.Round(1000.0 * ColCon);
				mSG[38] = 3;
				mSG[0, 38] = "PrCost";
			}
			else
			{
				mSG[38] = (int)Math.Round(0.0 * ColCon);
				mSG[38] = 3;
				mSG[0, 38] = "TagCost";
			}
			mSG[28] = (int)Math.Round(0.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "KrCode";
			mSG[27] = (int)Math.Round(0.0 * ColCon);
			mSG[27] = 0;
			mSG[0, 27] = "Counter";
			mSG[33] = (int)Math.Round(0.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrOthWt";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrNwt";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrTouch";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrWst%";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrFine";
			mSG[25] = 0;
			mSG[30] = 0;
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[29] = 0;
			mSG[26] = 0;
			mSG[39] = 0;
			mSG[40] = 0;
			mSG[41] = 0;
			mSG[42] = 0;
			mSG[43] = 0;
			mSG[44] = 0;
			mSG[45] = 0;
			mSG[46] = 0;
			mSG[47] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'SALES' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 28;
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
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					mSG_TOT[0, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 21]) + Conversion.Val(MSG[DC_Main.M, 21]))), "0.00");
					mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.00");
					mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.00");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.000");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.000");
					mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.000");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 22]) + Conversion.Val(MSG_TOT[0, 21]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 7] = Conversions.ToString(1);
		mSG[mSG.Row, 19] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 25] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 25] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 25]) + 1.0);
		}
		mSG[mSG.Row, 26] = "A";
		mSG[mSG.Row, 47] = "N";
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
				if ((mSG.Col != 27) & (mSG.Col != 4))
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
			case 28:
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
			case 27:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
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
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 19:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 11:
			case 13:
			case 14:
			case 16:
			case 17:
			case 18:
			case 35:
			case 36:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 38:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 8:
			case 9:
			case 10:
			case 15:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 12:
			case 33:
			case 34:
			case 37:
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
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
			case 5:
			case 6:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 19:
			case 27:
			case 28:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 7:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 11:
			case 13:
			case 14:
			case 18:
			case 35:
			case 36:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 16:
			case 17:
			case 20:
			case 21:
			case 22:
			case 23:
			case 24:
			case 38:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 8:
			case 9:
			case 10:
			case 12:
			case 15:
			case 33:
			case 34:
			case 37:
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
				case 7681:
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
							goto IL_0061;
						case 6:
							goto IL_0093;
						case 7:
							goto IL_00d9;
						case 8:
						case 9:
							goto IL_0121;
						case 10:
							goto IL_016c;
						case 11:
						case 12:
							goto IL_01b5;
						case 13:
							goto IL_01ec;
						case 14:
							goto IL_0204;
						case 15:
							goto IL_0238;
						case 16:
							goto IL_0298;
						case 18:
							goto IL_0316;
						case 17:
						case 19:
						case 20:
						case 21:
							goto IL_034d;
						case 22:
							goto IL_03ad;
						case 24:
							goto IL_042b;
						case 23:
						case 25:
						case 26:
							goto IL_0460;
						case 27:
							goto IL_049b;
						case 28:
						case 29:
							goto IL_04e5;
						case 30:
							goto IL_0530;
						case 32:
							goto IL_057b;
						case 31:
						case 33:
						case 34:
							goto IL_05b0;
						case 35:
							goto IL_0610;
						case 37:
							goto IL_067a;
						case 36:
						case 38:
						case 39:
							goto IL_06af;
						case 40:
							goto IL_071a;
						case 41:
							goto IL_074f;
						case 43:
							goto IL_0798;
						case 45:
							goto IL_07eb;
						case 47:
							goto IL_0885;
						case 49:
							goto IL_091f;
						case 42:
						case 44:
						case 46:
						case 48:
						case 50:
						case 51:
						case 52:
							goto IL_09ae;
						case 53:
							goto IL_09c4;
						case 54:
							goto IL_0a71;
						case 56:
							goto IL_0aba;
						case 58:
							goto IL_0b0a;
						case 60:
							goto IL_0ba1;
						case 62:
							goto IL_0c38;
						case 55:
						case 57:
						case 59:
						case 61:
						case 63:
						case 64:
							goto IL_0cc2;
						case 65:
						case 66:
						case 67:
							goto IL_0cfa;
						case 68:
							goto IL_0d49;
						case 69:
							goto IL_0d7d;
						case 71:
							goto IL_0ddd;
						case 72:
							goto IL_0e07;
						case 73:
							goto IL_0e1e;
						case 74:
							goto IL_0e35;
						case 70:
						case 75:
						case 76:
						case 77:
							goto IL_0e4f;
						case 78:
							goto IL_0e7c;
						case 79:
							goto IL_0eb1;
						case 81:
							goto IL_0efa;
						case 83:
							goto IL_0f4d;
						case 84:
							goto IL_0f69;
						case 86:
							goto IL_0fbb;
						case 89:
							goto IL_1024;
						case 91:
							goto IL_1093;
						case 80:
						case 82:
						case 85:
						case 87:
						case 88:
						case 90:
						case 92:
						case 93:
						case 94:
							goto IL_10e5;
						case 95:
							goto IL_1112;
						case 96:
							goto IL_1158;
						case 98:
							goto IL_11a5;
						case 99:
							goto IL_11ef;
						case 100:
							goto IL_120b;
						case 102:
							goto IL_1257;
						case 105:
							goto IL_12ba;
						case 106:
							goto IL_1300;
						case 108:
							goto IL_1357;
						case 109:
							goto IL_139d;
						case 97:
						case 101:
						case 103:
						case 104:
						case 107:
						case 110:
						case 111:
							goto IL_13e5;
						case 112:
						case 113:
							goto IL_141b;
						case 114:
							goto IL_1448;
						case 115:
							goto IL_147c;
						case 116:
							goto IL_1493;
						case 117:
							goto IL_14aa;
						case 118:
							goto IL_14c1;
						case 119:
							goto IL_14d8;
						case 121:
							goto IL_14f6;
						case 122:
							goto IL_150c;
						case 123:
							goto IL_1565;
						case 124:
							goto IL_1596;
						case 125:
							goto IL_15bd;
						case 126:
						case 127:
							goto IL_15d7;
						case 128:
							goto IL_15fe;
						case 129:
						case 130:
							goto IL_161a;
						case 131:
							goto IL_1654;
						case 132:
							goto IL_16a7;
						case 134:
							goto IL_16f3;
						case 136:
							goto IL_174d;
						case 137:
							goto IL_176c;
						case 139:
							goto IL_17c5;
						case 142:
							goto IL_1835;
						case 144:
							goto IL_18ab;
						case 133:
						case 135:
						case 138:
						case 140:
						case 141:
						case 143:
						case 145:
						case 146:
							goto IL_1902;
						case 147:
							goto IL_1939;
						case 148:
							goto IL_1988;
						case 120:
						case 149:
						case 150:
						case 151:
						case 152:
						case 153:
						case 154:
							goto IL_19e6;
						case 155:
							goto IL_1a16;
						case 156:
							goto IL_1a30;
						case 157:
							goto IL_1a4a;
						case 158:
							goto IL_1a64;
						case 159:
							goto IL_1a7e;
						case 160:
							goto IL_1a98;
						case 162:
							goto IL_1ad3;
						case 161:
						case 163:
						case 164:
							goto IL_1b34;
						case 165:
							goto IL_1b36;
						case 166:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 167:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1ad3:
					num2 = 162;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 17])), "0.00");
					goto IL_1b34;
					IL_1b34:
					val = null;
					goto IL_1b36;
					IL_1a98:
					num2 = 160;
					val[val.Row, 24] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_1b34;
					IL_1b36:
					num2 = 165;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 8]) != Conversion.Val(val[val.Row, 41]))
					{
						goto IL_004a;
					}
					goto IL_0121;
					IL_004a:
					num2 = 4;
					val[val.Row, 40] = Conversions.ToString(0);
					goto IL_0061;
					IL_0061:
					num2 = 5;
					val[val.Row, 41] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.000");
					goto IL_0093;
					IL_0093:
					num2 = 6;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_00d9;
					IL_00d9:
					num2 = 7;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 33])), "0.000");
					goto IL_0121;
					IL_0121:
					num2 = 9;
					if ((Conversion.Val(val[val.Row, 9]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_016c;
					}
					goto IL_01b5;
					IL_016c:
					num2 = 10;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_01b5;
					IL_01b5:
					num2 = 12;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 42]))
					{
						goto IL_01ec;
					}
					goto IL_034d;
					IL_01ec:
					num2 = 13;
					val[val.Row, 40] = Conversions.ToString(0);
					goto IL_0204;
					IL_0204:
					num2 = 14;
					val[val.Row, 42] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_0238;
					IL_0238:
					num2 = 15;
					if ((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_0298;
					}
					goto IL_0316;
					IL_0298:
					num2 = 16;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_034d;
					IL_0316:
					num2 = 18;
					val[val.Row, 15] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_034d;
					IL_034d:
					num2 = 21;
					if ((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_03ad;
					}
					goto IL_042b;
					IL_03ad:
					num2 = 22;
					val[val.Row, 15] = Strings.Format((object)((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14])) / 100.0), "0.000");
					goto IL_0460;
					IL_042b:
					num2 = 24;
					val[val.Row, 15] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_0460;
					IL_0460:
					num2 = 26;
					if (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 14]) == 0.0)
					{
						goto IL_049b;
					}
					goto IL_04e5;
					IL_049b:
					num2 = 27;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_04e5;
					IL_04e5:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 33]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_0530;
					}
					goto IL_057b;
					IL_0530:
					num2 = 30;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) - Conversion.Val(val[val.Row, 33])), "0.000");
					goto IL_05b0;
					IL_057b:
					num2 = 32;
					val[val.Row, 34] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.000");
					goto IL_05b0;
					IL_05b0:
					num2 = 34;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 34]) != 0.0))
					{
						goto IL_0610;
					}
					goto IL_067a;
					IL_0610:
					num2 = 35;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 34]) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_06af;
					IL_067a:
					num2 = 37;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 34]), "0.000");
					goto IL_06af;
					IL_06af:
					num2 = 39;
					if ((Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 40])) & (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_071a;
					}
					goto IL_09ae;
					IL_071a:
					num2 = 40;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_074f;
					IL_074f:
					num2 = 41;
					switch (val[val.Row, 39])
					{
					case "P":
						break;
					case "1":
						goto IL_07eb;
					case "K":
						goto IL_0885;
					default:
						goto IL_091f;
					}
					goto IL_0798;
					IL_091f:
					num2 = 49;
					val[val.Row, 17] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12])) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_09ae;
					IL_0885:
					num2 = 47;
					val[val.Row, 17] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 16]) / 1000.0), 0), "0.00");
					goto IL_09ae;
					IL_07eb:
					num2 = 45;
					val[val.Row, 17] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 16]) / 10.0), 0), "0.00");
					goto IL_09ae;
					IL_0798:
					num2 = 43;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_09ae;
					IL_09ae:
					num2 = 52;
					if (val.Col == 17)
					{
						goto IL_09c4;
					}
					goto IL_0cfa;
					IL_09c4:
					num2 = 53;
					if ((Conversion.Val(val[val.Row, 16]) == 0.0) | ((Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 40])) & (Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 7]) != 0.0)))
					{
						goto IL_0a71;
					}
					goto IL_0cfa;
					IL_0a71:
					num2 = 54;
					switch (val[val.Row, 39])
					{
					case "P":
						break;
					case "1":
						goto IL_0b0a;
					case "K":
						goto IL_0ba1;
					default:
						goto IL_0c38;
					}
					goto IL_0aba;
					IL_0c38:
					num2 = 62;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12]), 0), "0.00");
					goto IL_0cc2;
					IL_0ba1:
					num2 = 60;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12])) * 1000.0, 0), "0.00");
					goto IL_0cc2;
					IL_0b0a:
					num2 = 58;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (Conversion.Val(val[val.Row, Conversions.ToInteger(Interaction.IIf(Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0, (object)8, (object)10))]) + Conversion.Val(val[val.Row, 12])) * 10.0, 0), "0.00");
					goto IL_0cc2;
					IL_0aba:
					num2 = 56;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 7]), 0), "0.00");
					goto IL_0cc2;
					IL_0cc2:
					num2 = 64;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_0cfa;
					IL_0cfa:
					num2 = 67;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
					{
						goto IL_0d49;
					}
					goto IL_0ddd;
					IL_0d49:
					num2 = 68;
					val[val.Row, 43] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0d7d;
					IL_0d7d:
					num2 = 69;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 16]) * Conversion.Val(val[val.Row, 18]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_0e4f;
					IL_0ddd:
					num2 = 71;
					if (Conversion.Val(val[val.Row, 43]) != 0.0)
					{
						goto IL_0e07;
					}
					goto IL_0e4f;
					IL_0e07:
					num2 = 72;
					val[val.Row, 43] = "";
					goto IL_0e1e;
					IL_0e1e:
					num2 = 73;
					val[val.Row, 20] = "";
					goto IL_0e35;
					IL_0e35:
					num2 = 74;
					val[val.Row, 21] = "";
					goto IL_0e4f;
					IL_0e4f:
					num2 = 77;
					if (Conversion.Val(val[val.Row, 20]) != 0.0)
					{
						goto IL_0e7c;
					}
					goto IL_10e5;
					IL_0e7c:
					num2 = 78;
					val[val.Row, 44] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_0eb1;
					IL_0eb1:
					num2 = 79;
					switch (val[val.Row, 19])
					{
					case "P":
						break;
					case "N":
						goto IL_0f4d;
					case "K":
						goto IL_1024;
					default:
						goto IL_1093;
					}
					goto IL_0efa;
					IL_1093:
					num2 = 91;
					val[val.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_10e5;
					IL_1024:
					num2 = 89;
					val[val.Row, 21] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * (Conversion.Val(val[val.Row, 20]) / 1000.0), 0), "0.00");
					goto IL_10e5;
					IL_0f4d:
					num2 = 83;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_0f69;
					}
					goto IL_0fbb;
					IL_0f69:
					num2 = 84;
					val[val.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_10e5;
					IL_0fbb:
					num2 = 86;
					val[val.Row, 21] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) * Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_10e5;
					IL_0efa:
					num2 = 81;
					val[val.Row, 21] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_10e5;
					IL_10e5:
					num2 = 94;
					if (Conversion.Val(val[val.Row, 21]) != 0.0)
					{
						goto IL_1112;
					}
					goto IL_141b;
					IL_1112:
					num2 = 95;
					if ((Operators.CompareString(val[val.Row, 19], "P", false) == 0) & (Conversion.Val(val[val.Row, 7]) != 0.0))
					{
						goto IL_1158;
					}
					goto IL_11a5;
					IL_1158:
					num2 = 96;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 7])), "0.00");
					goto IL_13e5;
					IL_11a5:
					num2 = 98;
					if ((Operators.CompareString(val[val.Row, 19], "N", false) == 0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_11ef;
					}
					goto IL_12ba;
					IL_11ef:
					num2 = 99;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_120b;
					}
					goto IL_1257;
					IL_120b:
					num2 = 100;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 10])), "0.00");
					goto IL_13e5;
					IL_1257:
					num2 = 102;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) / (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12]))), "0.00");
					goto IL_13e5;
					IL_12ba:
					num2 = 105;
					if ((Operators.CompareString(val[val.Row, 19], "K", false) == 0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_1300;
					}
					goto IL_1357;
					IL_1300:
					num2 = 106;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 8]) * 1000.0), "0.00");
					goto IL_13e5;
					IL_1357:
					num2 = 108;
					if ((Operators.CompareString(val[val.Row, 19], "G", false) == 0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_139d;
					}
					goto IL_13e5;
					IL_139d:
					num2 = 109;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 8])), "0.00");
					goto IL_13e5;
					IL_13e5:
					num2 = 111;
					val[val.Row, 44] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_141b;
					IL_141b:
					num2 = 113;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_1448;
					}
					goto IL_14f6;
					IL_1448:
					num2 = 114;
					val[val.Row, 24] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_147c;
					IL_147c:
					num2 = 115;
					val[val.Row, 16] = "";
					goto IL_1493;
					IL_1493:
					num2 = 116;
					val[val.Row, 17] = "";
					goto IL_14aa;
					IL_14aa:
					num2 = 117;
					val[val.Row, 21] = "";
					goto IL_14c1;
					IL_14c1:
					num2 = 118;
					val[val.Row, 20] = "";
					goto IL_14d8;
					IL_14d8:
					num2 = 119;
					val[val.Row, 22] = "";
					goto IL_19e6;
					IL_14f6:
					num2 = 121;
					if (val.Col == 24)
					{
						goto IL_150c;
					}
					goto IL_19e6;
					IL_150c:
					num2 = 122;
					val[val.Row, 21] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 22]) - Conversion.Val(val[val.Row, 17])), "0.00");
					goto IL_1565;
					IL_1565:
					num2 = 123;
					if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(val[val.Row, 46]))
					{
						goto IL_1596;
					}
					goto IL_15d7;
					IL_1596:
					num2 = 124;
					val[val.Row, 46] = Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text));
					goto IL_15bd;
					IL_15bd:
					num2 = 125;
					val[val.Row, 45] = Conversions.ToString(0);
					goto IL_15d7;
					IL_15d7:
					num2 = 127;
					if (Conversion.Val(val[val.Row, 21]) < 0.0)
					{
						goto IL_15fe;
					}
					goto IL_161a;
					IL_15fe:
					num2 = 128;
					val[val.Row, 21] = "";
					goto IL_161a;
					IL_161a:
					num2 = 130;
					if (Conversion.Val(val[val.Row, 21]) != Conversion.Val(val[val.Row, 45]))
					{
						goto IL_1654;
					}
					goto IL_19e6;
					IL_1654:
					num2 = 131;
					if ((Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 20]) != 0.0))
					{
						goto IL_16a7;
					}
					goto IL_19e6;
					IL_16a7:
					num2 = 132;
					switch (val[val.Row, 19])
					{
					case "P":
						break;
					case "N":
						goto IL_174d;
					case "K":
						goto IL_1835;
					default:
						goto IL_18ab;
					}
					goto IL_16f3;
					IL_18ab:
					num2 = 144;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_1902;
					IL_1835:
					num2 = 142;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) / (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1902;
					IL_174d:
					num2 = 136;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_176c;
					}
					goto IL_17c5;
					IL_176c:
					num2 = 137;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_1902;
					IL_17c5:
					num2 = 139;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) / (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 12])), DC_Main.MsLbrRof), "0.00");
					goto IL_1902;
					IL_16f3:
					num2 = 134;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) / Conversion.Val(val[val.Row, 7]), DC_Main.MsLbrRof), "0.00");
					goto IL_1902;
					IL_1902:
					num2 = 146;
					val[val.Row, 44] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_1939;
					IL_1939:
					num2 = 147;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
					{
						goto IL_1988;
					}
					goto IL_19e6;
					IL_1988:
					num2 = 148;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 20]) * 100.0 / Conversion.Val(val[val.Row, 16])), "0.000");
					goto IL_19e6;
					IL_19e6:
					num2 = 154;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_1a16;
					}
					goto IL_1ad3;
					IL_1a16:
					num2 = 155;
					val[val.Row, 20] = "";
					goto IL_1a30;
					IL_1a30:
					num2 = 156;
					val[val.Row, 16] = "";
					goto IL_1a4a;
					IL_1a4a:
					num2 = 157;
					val[val.Row, 21] = "";
					goto IL_1a64;
					IL_1a64:
					num2 = 158;
					val[val.Row, 17] = "";
					goto IL_1a7e;
					IL_1a7e:
					num2 = 159;
					val[val.Row, 22] = "";
					goto IL_1a98;
					end_IL_0001_2:
					break;
				}
				num2 = 166;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7681;
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
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0285: Unknown result type (might be due to invalid IL or missing references)
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Invalid comparison between Unknown and I4
		//IL_02b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Invalid comparison between Unknown and I4
		//IL_02d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d4: Invalid comparison between Unknown and I4
		//IL_0362: Unknown result type (might be due to invalid IL or missing references)
		//IL_0366: Invalid comparison between Unknown and I4
		//IL_0401: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Invalid comparison between Unknown and I4
		//IL_0472: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Invalid comparison between Unknown and I4
		//IL_04ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ee: Invalid comparison between Unknown and I4
		//IL_0822: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c64: Unknown result type (might be due to invalid IL or missing references)
		//IL_2539: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ab: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		Keys keyCode = default(Keys);
		List<DataRow> list = default(List<DataRow>);
		int num6 = default(int);
		List<DataRow>.Enumerator enumerator = default(List<DataRow>.Enumerator);
		DataRow current = default(DataRow);
		int num7 = default(int);
		int num8 = default(int);
		DataTable dataTable = default(DataTable);
		double num9 = default(double);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					int num5;
					int col;
					AxMSFlexGrid obj;
					int i;
					object Value;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						UpDown = false;
						goto IL_000b;
					case 12974:
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
								goto IL_0014;
							case 4:
								goto IL_001e;
							case 5:
								goto IL_0028;
							case 7:
								goto IL_0032;
							case 8:
								goto IL_004e;
							case 9:
								goto IL_0069;
							case 10:
								goto IL_0087;
							case 11:
								goto IL_0091;
							case 12:
								goto IL_00b0;
							case 13:
								goto IL_00f4;
							case 14:
							case 15:
								goto IL_0116;
							case 16:
								goto IL_012e;
							case 17:
								goto IL_0145;
							case 18:
								goto IL_015b;
							case 19:
								goto IL_016a;
							case 20:
								goto IL_017a;
							case 21:
								goto IL_018b;
							case 22:
								goto IL_01a0;
							case 23:
								goto IL_01ba;
							case 24:
								goto IL_01d2;
							case 25:
								goto IL_01eb;
							case 26:
								goto IL_0208;
							case 28:
								goto IL_022e;
							case 27:
							case 29:
							case 30:
							case 31:
								goto IL_0267;
							case 32:
								goto IL_027b;
							case 35:
								goto IL_0292;
							case 36:
								goto IL_02a1;
							case 38:
								goto IL_02b0;
							case 39:
								goto IL_02be;
							case 41:
								goto IL_02cd;
							case 42:
								goto IL_02df;
							case 43:
								goto IL_02f1;
							case 44:
								goto IL_0300;
							case 46:
								goto IL_030e;
							case 47:
								goto IL_0318;
							case 45:
							case 48:
							case 49:
								goto IL_0323;
							case 50:
								goto IL_0335;
							case 51:
								goto IL_0344;
							case 55:
								goto IL_035f;
							case 56:
								goto IL_0371;
							case 57:
								goto IL_038b;
							case 59:
								goto IL_039f;
							case 60:
								goto IL_03b8;
							case 61:
								goto IL_03c7;
							case 63:
								goto IL_03d5;
							case 62:
							case 64:
							case 65:
								goto IL_03e0;
							case 69:
								goto IL_03fe;
							case 70:
								goto IL_040d;
							case 71:
								goto IL_041f;
							case 72:
								goto IL_042e;
							case 74:
								goto IL_043c;
							case 73:
							case 75:
							case 76:
								goto IL_0447;
							case 77:
								goto IL_0451;
							case 81:
								goto IL_046f;
							case 82:
								goto IL_047e;
							case 83:
								goto IL_0497;
							case 84:
								goto IL_04a6;
							case 86:
								goto IL_04b4;
							case 85:
							case 87:
							case 88:
								goto IL_04bf;
							case 89:
								goto IL_04c9;
							case 93:
								goto IL_04e7;
							case 94:
								goto IL_04fa;
							case 96:
								goto IL_0542;
							case 97:
								goto IL_0562;
							case 98:
								goto IL_05a9;
							case 99:
								goto IL_05c1;
							case 100:
								goto IL_0679;
							case 101:
								goto IL_068b;
							case 102:
								goto IL_06a9;
							case 103:
								goto IL_06c5;
							case 105:
								goto IL_0704;
							case 104:
							case 106:
							case 107:
								goto IL_0740;
							case 108:
								goto IL_0752;
							case 109:
								goto IL_0761;
							case 110:
								goto IL_0774;
							case 111:
								goto IL_0787;
							case 112:
								goto IL_079a;
							case 113:
								goto IL_07ad;
							case 114:
								goto IL_07c0;
							case 115:
								goto IL_07d3;
							case 116:
								goto IL_07e6;
							case 117:
								goto IL_07f9;
							case 118:
								goto IL_080c;
							case 119:
								goto IL_0815;
							case 120:
								goto IL_0828;
							case 122:
								goto IL_083b;
							case 123:
								goto IL_0872;
							case 124:
								goto IL_088e;
							case 125:
								goto IL_08a4;
							case 127:
								goto IL_08c0;
							case 128:
								goto IL_08d6;
							case 126:
							case 129:
							case 130:
								goto IL_08f2;
							case 131:
								goto IL_090d;
							case 132:
								goto IL_0928;
							case 133:
								goto IL_094d;
							case 134:
								goto IL_0973;
							case 135:
								goto IL_098f;
							case 138:
								goto IL_09aa;
							case 139:
								goto IL_09c4;
							case 140:
								goto IL_09dd;
							case 144:
								goto IL_09fc;
							case 145:
								goto IL_0a14;
							case 146:
								goto IL_0a51;
							case 148:
							case 149:
								goto IL_0a6b;
							case 150:
								goto IL_0a86;
							case 151:
								goto IL_0ac4;
							case 152:
								goto IL_0ae5;
							case 153:
								goto IL_0b5b;
							case 154:
								goto IL_0b70;
							case 155:
								goto IL_0b82;
							case 156:
								goto IL_0b98;
							case 157:
								goto IL_0bae;
							case 158:
								goto IL_0bc4;
							case 159:
								goto IL_0bda;
							case 160:
								goto IL_0bf0;
							case 161:
								goto IL_0c06;
							case 162:
								goto IL_0c1c;
							case 163:
								goto IL_0c32;
							case 164:
								goto IL_0c48;
							case 165:
								goto IL_0c54;
							case 166:
								goto IL_0c6a;
							case 168:
								goto IL_0c80;
							case 169:
								goto IL_0ca4;
							case 170:
								goto IL_0cbd;
							case 171:
								goto IL_0cd8;
							case 172:
								goto IL_0cf3;
							case 173:
								goto IL_0d0e;
							case 174:
								goto IL_0d33;
							case 175:
								goto IL_0d59;
							case 176:
								goto IL_0d75;
							case 177:
							case 178:
							case 179:
								goto IL_0d8b;
							case 180:
								goto IL_0e1e;
							case 181:
								goto IL_0e33;
							case 182:
								goto IL_0e44;
							case 183:
								goto IL_0e65;
							case 184:
								goto IL_0ea1;
							case 185:
								goto IL_0edd;
							case 186:
								goto IL_0f19;
							case 187:
								goto IL_0f56;
							case 188:
								goto IL_0f92;
							case 189:
								goto IL_0fce;
							case 190:
								goto IL_100a;
							case 191:
								goto IL_103c;
							case 192:
								goto IL_1082;
							case 193:
								goto IL_10c9;
							case 194:
								goto IL_1110;
							case 195:
								goto IL_1157;
							case 196:
								goto IL_119e;
							case 197:
								goto IL_11e5;
							case 198:
								goto IL_122c;
							case 199:
								goto IL_1273;
							case 200:
								goto IL_12ba;
							case 201:
								goto IL_12f7;
							case 202:
								goto IL_134c;
							case 203:
								goto IL_13e2;
							case 204:
								goto IL_13f4;
							case 205:
								goto IL_140f;
							case 207:
								goto IL_143a;
							case 208:
								goto IL_147e;
							case 209:
								goto IL_1497;
							case 206:
							case 210:
							case 211:
							case 212:
								goto IL_14bc;
							case 213:
								goto IL_14d8;
							case 214:
								goto IL_14ff;
							case 216:
								goto IL_153b;
							case 217:
								goto IL_1562;
							case 219:
								goto IL_159b;
							case 220:
								goto IL_15c2;
							case 223:
								goto IL_15f3;
							case 215:
							case 218:
							case 221:
							case 222:
							case 224:
							case 225:
							case 226:
								goto IL_1610;
							case 227:
								goto IL_162a;
							case 228:
								goto IL_1671;
							case 229:
								goto IL_16b8;
							case 230:
								goto IL_16f5;
							case 231:
								goto IL_173c;
							case 232:
								goto IL_1756;
							case 233:
								goto IL_179d;
							case 234:
								goto IL_17e4;
							case 235:
								goto IL_182b;
							case 236:
								goto IL_1872;
							case 237:
								goto IL_18b9;
							case 238:
								goto IL_1900;
							case 239:
								goto IL_1950;
							case 240:
								goto IL_1997;
							case 241:
								goto IL_19d4;
							case 242:
								goto IL_1a11;
							case 243:
								goto IL_1a4e;
							case 244:
								goto IL_1a8b;
							case 245:
								goto IL_1ac8;
							case 246:
								goto IL_1b05;
							case 247:
								goto IL_1b40;
							case 248:
								goto IL_1b4d;
							case 249:
							case 250:
								goto IL_1b67;
							case 251:
								goto IL_1b70;
							case 252:
								goto IL_1b8a;
							case 253:
								goto IL_1b9c;
							case 254:
								goto IL_1bde;
							case 255:
								goto IL_1bfc;
							case 256:
								goto IL_1c0e;
							case 257:
							case 258:
								goto IL_1c1c;
							case 259:
								goto IL_1c28;
							case 260:
								goto IL_1c3d;
							case 261:
								goto IL_1c4a;
							case 262:
								goto IL_1cba;
							case 263:
								goto IL_1ccf;
							case 266:
								goto IL_1ce0;
							case 267:
								goto IL_1cf7;
							case 268:
								goto IL_1d28;
							case 269:
								goto IL_1d47;
							case 270:
								goto IL_1d82;
							case 271:
								goto IL_1dbd;
							case 272:
								goto IL_1df8;
							case 273:
								goto IL_1e33;
							case 274:
								goto IL_1e6e;
							case 275:
								goto IL_1ea9;
							case 276:
								goto IL_1ee4;
							case 277:
								goto IL_1f1f;
							case 278:
								goto IL_1f5b;
							case 279:
								goto IL_1f92;
							case 280:
								goto IL_1fdd;
							case 281:
								goto IL_2028;
							case 282:
								goto IL_2073;
							case 283:
								goto IL_20af;
							case 284:
								goto IL_20fa;
							case 285:
								goto IL_2145;
							case 286:
								goto IL_2190;
							case 287:
								goto IL_21db;
							case 288:
								goto IL_2226;
							case 289:
								goto IL_2271;
							case 290:
								goto IL_22c1;
							case 291:
								goto IL_22fd;
							case 292:
								goto IL_231a;
							case 264:
							case 265:
							case 293:
								goto IL_232d;
							case 294:
								goto IL_2352;
							case 295:
								goto IL_235f;
							case 296:
								goto IL_236c;
							case 297:
								goto IL_2384;
							case 302:
								goto IL_239c;
							case 303:
								goto IL_241e;
							case 304:
								goto IL_2433;
							case 305:
								goto IL_2454;
							case 306:
								goto IL_2473;
							case 307:
								goto IL_2488;
							case 308:
								goto IL_2499;
							case 309:
								goto IL_24af;
							case 310:
								goto IL_24c5;
							case 311:
								goto IL_24db;
							case 312:
								goto IL_24f1;
							case 313:
								goto IL_2507;
							case 314:
								goto IL_251d;
							case 315:
								goto IL_2529;
							case 316:
								goto IL_253f;
							case 318:
								goto IL_2555;
							case 319:
								goto IL_2579;
							case 320:
								goto IL_2592;
							case 321:
								goto IL_25ad;
							case 322:
								goto IL_25c8;
							case 323:
								goto IL_25e4;
							case 324:
								goto IL_2600;
							case 325:
							case 326:
								goto IL_261e;
							case 329:
								goto IL_263c;
							case 330:
								goto IL_2679;
							case 331:
								goto IL_26b7;
							case 332:
								goto IL_26f5;
							case 333:
								goto IL_2733;
							case 336:
								goto IL_2775;
							case 337:
								goto IL_27c9;
							case 338:
								goto IL_27de;
							case 339:
								goto IL_27ff;
							case 340:
								goto IL_283d;
							case 341:
								goto IL_2852;
							case 342:
								goto IL_2863;
							case 343:
								goto IL_2879;
							case 344:
								goto IL_288f;
							case 345:
								goto IL_289b;
							case 346:
								goto IL_28b1;
							case 348:
								goto IL_28c7;
							case 349:
								goto IL_28e8;
							case 350:
								goto IL_2901;
							case 351:
							case 352:
								goto IL_291f;
							case 355:
								goto IL_293a;
							case 358:
								goto IL_297f;
							case 359:
								goto IL_29a6;
							case 362:
								goto IL_29c4;
							case 363:
								goto IL_29f7;
							case 364:
								goto IL_2a04;
							case 365:
								goto IL_2a17;
							case 366:
								goto IL_2a36;
							case 367:
								goto IL_2a49;
							case 368:
								goto IL_2a61;
							case 369:
								goto IL_2a73;
							case 373:
								goto IL_2a91;
							case 374:
								goto IL_2ab0;
							case 375:
								goto IL_2abd;
							case 376:
								goto IL_2aca;
							case 377:
								goto IL_2adf;
							case 378:
								goto IL_2af4;
							case 379:
								goto IL_2b01;
							case 380:
								goto IL_2b1c;
							case 382:
								goto IL_2b33;
							case 381:
							case 383:
							case 384:
								goto IL_2b47;
							case 387:
								goto IL_2b5d;
							case 386:
							case 388:
							case 389:
								goto IL_2b73;
							case 390:
								goto IL_2b8e;
							case 392:
								goto IL_2ba5;
							case 391:
							case 393:
							case 394:
								goto IL_2bb9;
							case 395:
								goto IL_2bcc;
							case 95:
							case 137:
							case 142:
							case 143:
							case 298:
							case 299:
							case 300:
							case 301:
							case 328:
							case 334:
							case 335:
							case 354:
							case 356:
							case 357:
							case 361:
							case 371:
							case 372:
							case 397:
							case 398:
								goto IL_2be3;
							case 399:
								goto IL_2bff;
							case 400:
							case 401:
								goto IL_2c20;
							case 402:
								goto IL_2c33;
							case 6:
							case 33:
							case 34:
							case 37:
							case 40:
							case 54:
							case 68:
							case 80:
							case 92:
							case 403:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 52:
							case 53:
							case 58:
							case 66:
							case 67:
							case 78:
							case 79:
							case 90:
							case 91:
							case 121:
							case 136:
							case 141:
							case 147:
							case 167:
							case 317:
							case 327:
							case 347:
							case 353:
							case 360:
							case 370:
							case 385:
							case 396:
							case 404:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_2bcc:
						num2 = 395;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_297f:
						num2 = 358;
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							goto IL_29a6;
						}
						goto IL_29c4;
						IL_2bb9:
						num2 = 394;
						((Control)TEXT_ENTRY).Visible = true;
						goto IL_2bcc;
						IL_29a6:
						num2 = 359;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_000b:
						num2 = 2;
						Msgleft = false;
						goto IL_0014;
						IL_0014:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_001e;
						IL_001e:
						num2 = 4;
						val = MSG;
						goto IL_0028;
						IL_0028:
						num2 = 5;
						keyCode = e.KeyCode;
						goto IL_0032;
						IL_0032:
						num2 = 7;
						if (unchecked((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0)))))
						{
							goto IL_004e;
						}
						goto IL_0292;
						IL_004e:
						num2 = 8;
						if (unchecked((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null)) != 6)
						{
							break;
						}
						goto IL_0069;
						IL_0069:
						num2 = 9;
						num5 = (int)Math.Round(Conversion.Val(val[val.Row, 25]));
						goto IL_0087;
						IL_0087:
						num2 = 10;
						list = new List<DataRow>();
						goto IL_0091;
						IL_0091:
						num2 = 11;
						num6 = DtIdtl.Rows.Count - 1;
						DC_Main.M = 0;
						goto IL_0125;
						IL_0125:
						if (DC_Main.M <= num6)
						{
							goto IL_00b0;
						}
						goto IL_012e;
						IL_012e:
						num2 = 16;
						enumerator = list.GetEnumerator();
						goto IL_016d;
						IL_016d:
						if (enumerator.MoveNext())
						{
							current = enumerator.Current;
							goto IL_0145;
						}
						goto IL_017a;
						IL_017a:
						num2 = 20;
						((IDisposable)enumerator/*cast due to constrained. prefix*/).Dispose();
						goto IL_018b;
						IL_018b:
						num2 = 21;
						num7 = val.Cols - 1;
						DC_Main.M = 1;
						goto IL_01c9;
						IL_01c9:
						if (DC_Main.M <= num7)
						{
							goto IL_01a0;
						}
						goto IL_01d2;
						IL_01d2:
						num2 = 24;
						if (val.Row == val.Rows - 1)
						{
							goto IL_01eb;
						}
						goto IL_0267;
						IL_01eb:
						num2 = 25;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_0208;
						}
						goto IL_022e;
						IL_0208:
						num2 = 26;
						val[val.Row, 25] = Conversions.ToString(MSG.Row);
						goto IL_0267;
						IL_022e:
						num2 = 28;
						val[val.Row, 25] = Conversions.ToString(Conversion.Val(val[val.Rows - 2, 25]) + 1.0);
						goto IL_0267;
						IL_0267:
						num2 = 31;
						TEXT_ENTRY.Text = "";
						goto IL_027b;
						IL_027b:
						num2 = 32;
						Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
						break;
						IL_01a0:
						num2 = 22;
						val[val.Row, DC_Main.M] = "";
						goto IL_01ba;
						IL_01ba:
						num2 = 23;
						DC_Main.M++;
						goto IL_01c9;
						IL_29c4:
						num2 = 362;
						val[val.Row, 8] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						goto IL_29f7;
						IL_0145:
						num2 = 17;
						DtIdtl.Rows.Remove(current);
						goto IL_015b;
						IL_015b:
						num2 = 18;
						DtIdtl.AcceptChanges();
						goto IL_016a;
						IL_016a:
						num2 = 19;
						goto IL_016d;
						IL_00b0:
						num2 = 12;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][23])) == Conversion.Val(val[val.Row, 25]))
						{
							goto IL_00f4;
						}
						goto IL_0116;
						IL_00f4:
						num2 = 13;
						list.Add(DtIdtl.Rows[DC_Main.M]);
						goto IL_0116;
						IL_0116:
						num2 = 15;
						DC_Main.M++;
						goto IL_0125;
						IL_0292:
						num2 = 35;
						if (unchecked((int)keyCode) == 46)
						{
							goto IL_02a1;
						}
						goto IL_02b0;
						IL_02a1:
						num2 = 36;
						MsTxtDelete = true;
						break;
						IL_02b0:
						num2 = 38;
						if (unchecked((int)keyCode) == 8)
						{
							goto IL_02be;
						}
						goto IL_02cd;
						IL_02be:
						num2 = 39;
						MsTxtDelete = true;
						break;
						IL_02cd:
						num2 = 41;
						if (unchecked((int)keyCode) == 37)
						{
							goto IL_02df;
						}
						goto IL_035f;
						IL_02df:
						num2 = 42;
						if (val.Col <= 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_02f1;
						IL_02f1:
						num2 = 43;
						if (MsTxtDelete)
						{
							goto IL_0300;
						}
						goto IL_030e;
						IL_0300:
						num2 = 44;
						MsTxtDelete = false;
						goto IL_0323;
						IL_030e:
						num2 = 46;
						Msgleft = true;
						goto IL_0318;
						IL_0318:
						num2 = 47;
						UpDown = true;
						goto IL_0323;
						IL_0323:
						num2 = 49;
						val.Col -= 1;
						goto IL_0335;
						IL_0335:
						num2 = 50;
						((TextBoxBase)TEXT_ENTRY).SelectAll();
						goto IL_0344;
						IL_0344:
						num2 = 51;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_035f:
						num2 = 55;
						if (unchecked((int)keyCode) == 39)
						{
							goto IL_0371;
						}
						goto IL_03fe;
						IL_0371:
						num2 = 56;
						if (val.Col >= MsgLastCol)
						{
							goto IL_038b;
						}
						goto IL_039f;
						IL_038b:
						num2 = 57;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_039f:
						num2 = 59;
						if (val.Col >= val.Cols - 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_03b8;
						IL_03b8:
						num2 = 60;
						if (MsTxtDelete)
						{
							goto IL_03c7;
						}
						goto IL_03d5;
						IL_03c7:
						num2 = 61;
						MsTxtDelete = false;
						goto IL_03e0;
						IL_03d5:
						num2 = 63;
						UpDown = true;
						goto IL_03e0;
						IL_03e0:
						num2 = 65;
						val.Col += 1;
						goto end_IL_0001_3;
						IL_03fe:
						num2 = 69;
						if (unchecked((int)keyCode) == 38)
						{
							goto IL_040d;
						}
						goto IL_046f;
						IL_040d:
						num2 = 70;
						if (val.Row <= 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_041f;
						IL_041f:
						num2 = 71;
						if (MsTxtDelete)
						{
							goto IL_042e;
						}
						goto IL_043c;
						IL_042e:
						num2 = 72;
						MsTxtDelete = false;
						goto IL_0447;
						IL_043c:
						num2 = 74;
						UpDown = true;
						goto IL_0447;
						IL_0447:
						num2 = 76;
						MsgOldRow = 0;
						goto IL_0451;
						IL_0451:
						num2 = 77;
						val.Row -= 1;
						goto end_IL_0001_3;
						IL_046f:
						num2 = 81;
						if (unchecked((int)keyCode) == 40)
						{
							goto IL_047e;
						}
						goto IL_04e7;
						IL_047e:
						num2 = 82;
						if (val.Row >= val.Rows - 1)
						{
							goto end_IL_0001_3;
						}
						goto IL_0497;
						IL_0497:
						num2 = 83;
						if (MsTxtDelete)
						{
							goto IL_04a6;
						}
						goto IL_04b4;
						IL_04a6:
						num2 = 84;
						MsTxtDelete = false;
						goto IL_04bf;
						IL_04b4:
						num2 = 86;
						UpDown = true;
						goto IL_04bf;
						IL_04bf:
						num2 = 88;
						MsgOldRow = 0;
						goto IL_04c9;
						IL_04c9:
						num2 = 89;
						val.Row += 1;
						goto end_IL_0001_3;
						IL_04e7:
						num2 = 93;
						if (unchecked((int)keyCode) != 13)
						{
							break;
						}
						goto IL_04fa;
						IL_04fa:
						num2 = 94;
						col = val.Col;
						if (col <= 2)
						{
							if (col == 1)
							{
								goto IL_0542;
							}
							if (col == 2)
							{
								goto IL_239c;
							}
						}
						else
						{
							if (col == 8)
							{
								goto IL_297f;
							}
							if (col == 24)
							{
								goto IL_2a91;
							}
							if (col == 27)
							{
								goto IL_2775;
							}
						}
						goto IL_2be3;
						IL_29f7:
						num2 = 363;
						CommPassTotal();
						goto IL_2a04;
						IL_2a17:
						num2 = 365;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						goto IL_2a36;
						IL_239c:
						num2 = 302;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "' "), Interaction.IIf(Operators.CompareString(val[val.Row, 1], "", false) != 0, (object)"", (object)"AND BULK_SALE <> 'N'")), (object)""));
						goto IL_241e;
						IL_241e:
						num2 = 303;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2433;
						IL_2433:
						num2 = 304;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							goto IL_2454;
						}
						goto IL_263c;
						IL_2454:
						num2 = 305;
						DC_Main.RsQry = "SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND BULK_SALE <> 'N' ORDER BY A.IT_NAME";
						goto IL_2473;
						IL_2473:
						num2 = 306;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2488;
						IL_2488:
						num2 = 307;
						DC_Main.ColWidth = new double[7];
						goto IL_2499;
						IL_2499:
						num2 = 308;
						DC_Main.ColWidth[0] = 300.0;
						goto IL_24af;
						IL_24af:
						num2 = 309;
						DC_Main.ColWidth[1] = 100.0;
						goto IL_24c5;
						IL_24c5:
						num2 = 310;
						DC_Main.ColWidth[2] = 250.0;
						goto IL_24db;
						IL_24db:
						num2 = 311;
						DC_Main.ColWidth[3] = 0.0;
						goto IL_24f1;
						IL_24f1:
						num2 = 312;
						DC_Main.ColWidth[4] = 0.0;
						goto IL_2507;
						IL_2507:
						num2 = 313;
						DC_Main.ColWidth[5] = 0.0;
						goto IL_251d;
						IL_251d:
						num2 = 314;
						DC_Main.HelpSelect = 1;
						goto IL_2529;
						IL_2529:
						num2 = 315;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_253f;
						IL_253f:
						num2 = 316;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_2555;
						IL_2555:
						num2 = 318;
						if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							goto IL_2579;
						}
						goto IL_261e;
						IL_2579:
						num2 = 319;
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						goto IL_2592;
						IL_2592:
						num2 = 320;
						val[val.Row, 2] = DC_Main.ColValue[1];
						goto IL_25ad;
						IL_25ad:
						num2 = 321;
						val[val.Row, 3] = DC_Main.ColValue[0];
						goto IL_25c8;
						IL_25c8:
						num2 = 322;
						val[val.Row, 32] = DC_Main.ColValue[3];
						goto IL_25e4;
						IL_25e4:
						num2 = 323;
						val[val.Row, 30] = DC_Main.ColValue[4];
						goto IL_2600;
						IL_2600:
						num2 = 324;
						val[val.Row, 31] = DC_Main.ColValue[4];
						goto IL_261e;
						IL_261e:
						num2 = 326;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_263c:
						num2 = 329;
						val[val.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						goto IL_2679;
						IL_2679:
						num2 = 330;
						val[val.Row, 32] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						goto IL_26b7;
						IL_26b7:
						num2 = 331;
						val[val.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						goto IL_26f5;
						IL_26f5:
						num2 = 332;
						val[val.Row, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						goto IL_2733;
						IL_2733:
						num2 = 333;
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						goto IL_2be3;
						IL_0542:
						num2 = 96;
						if (Operators.CompareString(FormBookInOut, "I", false) == 0)
						{
							goto IL_0562;
						}
						goto IL_2be3;
						IL_0562:
						num2 = 97;
						if ((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) | (Operators.CompareString(TEXT_ENTRY.Text, val[val.Row, 1], false) != 0))
						{
							goto IL_05a9;
						}
						goto IL_2be3;
						IL_05a9:
						num2 = 98;
						val[val.Row, 29] = Conversions.ToString(0);
						goto IL_05c1;
						IL_05c1:
						num2 = 99;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(val[val.Row, 29]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(val[val.Row, 29]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						goto IL_0679;
						IL_2a73:
						num2 = 369;
						((TextBoxBase)TEXT_IDTL).SelectAll();
						goto end_IL_0001_3;
						IL_2a61:
						num2 = 368;
						((Control)TEXT_IDTL).Focus();
						goto IL_2a73;
						IL_0679:
						num2 = 100;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_068b;
						IL_068b:
						num2 = 101;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_06a9;
						}
						goto IL_09fc;
						IL_06a9:
						num2 = 102;
						if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
						{
							goto IL_06c5;
						}
						goto IL_0704;
						IL_06c5:
						num2 = 103;
						DC_Main.RsQry = "Select C.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC";
						goto IL_0740;
						IL_0704:
						num2 = 105;
						DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO <> 'N' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC";
						goto IL_0740;
						IL_0740:
						num2 = 107;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0752;
						IL_0752:
						num2 = 108;
						DC_Main.ColWidth = new double[10];
						goto IL_0761;
						IL_0761:
						num2 = 109;
						DC_Main.ColWidth[0] = 120.0;
						goto IL_0774;
						IL_0774:
						num2 = 110;
						DC_Main.ColWidth[1] = 120.0;
						goto IL_0787;
						IL_0787:
						num2 = 111;
						DC_Main.ColWidth[2] = 300.0;
						goto IL_079a;
						IL_079a:
						num2 = 112;
						DC_Main.ColWidth[3] = 100.0;
						goto IL_07ad;
						IL_07ad:
						num2 = 113;
						DC_Main.ColWidth[4] = 100.0;
						goto IL_07c0;
						IL_07c0:
						num2 = 114;
						DC_Main.ColWidth[5] = 100.0;
						goto IL_07d3;
						IL_07d3:
						num2 = 115;
						DC_Main.ColWidth[6] = 110.0;
						goto IL_07e6;
						IL_07e6:
						num2 = 116;
						DC_Main.ColWidth[7] = 0.0;
						goto IL_07f9;
						IL_07f9:
						num2 = 117;
						DC_Main.ColWidth[8] = 0.0;
						goto IL_080c;
						IL_080c:
						num2 = 118;
						DC_Main.HelpSelect = 1;
						goto IL_0815;
						IL_0815:
						num2 = 119;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_0828;
						IL_0828:
						num2 = 120;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_083b;
						IL_083b:
						num2 = 122;
						if ((Operators.CompareString(DC_Main.ColValue[0], "", false) != 0) | (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0))
						{
							goto IL_0872;
						}
						goto IL_09aa;
						IL_0872:
						num2 = 123;
						if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
						{
							goto IL_088e;
						}
						goto IL_08c0;
						IL_088e:
						num2 = 124;
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						goto IL_08a4;
						IL_08a4:
						num2 = 125;
						val[val.Row, 4] = DC_Main.ColValue[0];
						goto IL_08f2;
						IL_08c0:
						num2 = 127;
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						goto IL_08d6;
						IL_08d6:
						num2 = 128;
						val[val.Row, 4] = DC_Main.ColValue[1];
						goto IL_08f2;
						IL_08f2:
						num2 = 130;
						val[val.Row, 3] = DC_Main.ColValue[2];
						goto IL_090d;
						IL_090d:
						num2 = 131;
						val[val.Row, 2] = DC_Main.ColValue[3];
						goto IL_0928;
						IL_0928:
						num2 = 132;
						val[val.Row, 8] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
						goto IL_094d;
						IL_094d:
						num2 = 133;
						val[val.Row, 10] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
						goto IL_0973;
						IL_0973:
						num2 = 134;
						val[val.Row, 29] = DC_Main.ColValue[7];
						goto IL_098f;
						IL_098f:
						num2 = 135;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_09aa:
						num2 = 138;
						val[val.Row, 29] = "";
						goto IL_09c4;
						IL_09c4:
						num2 = 139;
						val[val.Row, 1] = "";
						goto IL_09dd;
						IL_09dd:
						num2 = 140;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_09fc:
						num2 = 144;
						num8 = val.Rows - 1;
						DC_Main.X = 1;
						goto IL_0a7d;
						IL_0a7d:
						if (DC_Main.X <= num8)
						{
							goto IL_0a14;
						}
						goto IL_0a86;
						IL_0a86:
						num2 = 150;
						val[val.Row, 29] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						goto IL_0ac4;
						IL_0ac4:
						num2 = 151;
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							goto IL_0ae5;
						}
						goto IL_0d8b;
						IL_0ae5:
						num2 = 152;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN SL_DETL_RTN AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
						goto IL_0b5b;
						IL_0b5b:
						num2 = 153;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0b70;
						IL_0b70:
						num2 = 154;
						DC_Main.ColWidth = new double[10];
						goto IL_0b82;
						IL_0b82:
						num2 = 155;
						DC_Main.ColWidth[0] = 120.0;
						goto IL_0b98;
						IL_0b98:
						num2 = 156;
						DC_Main.ColWidth[1] = 300.0;
						goto IL_0bae;
						IL_0bae:
						num2 = 157;
						DC_Main.ColWidth[2] = 100.0;
						goto IL_0bc4;
						IL_0bc4:
						num2 = 158;
						DC_Main.ColWidth[3] = 120.0;
						goto IL_0bda;
						IL_0bda:
						num2 = 159;
						DC_Main.ColWidth[4] = 100.0;
						goto IL_0bf0;
						IL_0bf0:
						num2 = 160;
						DC_Main.ColWidth[5] = 100.0;
						goto IL_0c06;
						IL_0c06:
						num2 = 161;
						DC_Main.ColWidth[6] = 110.0;
						goto IL_0c1c;
						IL_0c1c:
						num2 = 162;
						DC_Main.ColWidth[7] = 0.0;
						goto IL_0c32;
						IL_0c32:
						num2 = 163;
						DC_Main.ColWidth[8] = 0.0;
						goto IL_0c48;
						IL_0c48:
						num2 = 164;
						DC_Main.HelpSelect = 1;
						goto IL_0c54;
						IL_0c54:
						num2 = 165;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_0c6a;
						IL_0c6a:
						num2 = 166;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_0c80;
						IL_0c80:
						num2 = 168;
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							goto IL_0ca4;
						}
						goto IL_0d8b;
						IL_0ca4:
						num2 = 169;
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						goto IL_0cbd;
						IL_0cbd:
						num2 = 170;
						val[val.Row, 3] = DC_Main.ColValue[1];
						goto IL_0cd8;
						IL_0cd8:
						num2 = 171;
						val[val.Row, 2] = DC_Main.ColValue[0];
						goto IL_0cf3;
						IL_0cf3:
						num2 = 172;
						val[val.Row, 4] = DC_Main.ColValue[3];
						goto IL_0d0e;
						IL_0d0e:
						num2 = 173;
						val[val.Row, 8] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
						goto IL_0d33;
						IL_0d33:
						num2 = 174;
						val[val.Row, 10] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
						goto IL_0d59;
						IL_0d59:
						num2 = 175;
						val[val.Row, 29] = DC_Main.ColValue[7];
						goto IL_0d75;
						IL_0d75:
						num2 = 176;
						((Control)TEXT_ENTRY).Focus();
						goto IL_0d8b;
						IL_0d8b:
						num2 = 179;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)val[val.Row, 29]), (object)"' "));
						goto IL_0e1e;
						IL_0e1e:
						num2 = 180;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0e33;
						IL_0e33:
						num2 = 181;
						DC_Main.i = val.Row;
						goto IL_0e44;
						IL_0e44:
						num2 = 182;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0e65;
						}
						goto IL_1b67;
						IL_0e65:
						num2 = 183;
						val[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
						goto IL_0ea1;
						IL_0ea1:
						num2 = 184;
						val[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
						goto IL_0edd;
						IL_0edd:
						num2 = 185;
						val[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
						goto IL_0f19;
						IL_0f19:
						num2 = 186;
						val[DC_Main.i, 27] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
						goto IL_0f56;
						IL_0f56:
						num2 = 187;
						val[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
						goto IL_0f92;
						IL_0f92:
						num2 = 188;
						val[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
						goto IL_0fce;
						IL_0fce:
						num2 = 189;
						val[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
						goto IL_100a;
						IL_100a:
						num2 = 190;
						val[DC_Main.i, 7] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
						goto IL_103c;
						IL_103c:
						num2 = 191;
						val[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
						goto IL_1082;
						IL_1082:
						num2 = 192;
						val[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
						goto IL_10c9;
						IL_10c9:
						num2 = 193;
						val[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
						goto IL_1110;
						IL_1110:
						num2 = 194;
						val[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
						goto IL_1157;
						IL_1157:
						num2 = 195;
						val[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
						goto IL_119e;
						IL_119e:
						num2 = 196;
						val[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
						goto IL_11e5;
						IL_11e5:
						num2 = 197;
						val[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
						goto IL_122c;
						IL_122c:
						num2 = 198;
						val[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
						goto IL_1273;
						IL_1273:
						num2 = 199;
						val[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
						goto IL_12ba;
						IL_12ba:
						num2 = 200;
						val[DC_Main.i, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
						goto IL_12f7;
						IL_12f7:
						num2 = 201;
						if ((Conversion.Val(val[val.Row, 16]) == 0.0) & (Conversion.Val(val[val.Row, 23]) == 0.0) & (DC_Main.RtView != null))
						{
							goto IL_134c;
						}
						goto IL_1610;
						IL_134c:
						num2 = 202;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
						goto IL_13e2;
						IL_13e2:
						num2 = 203;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_13f4;
						IL_13f4:
						num2 = 204;
						if (dataTable.Rows.Count > 0)
						{
							goto IL_140f;
						}
						goto IL_143a;
						IL_140f:
						num2 = 205;
						num9 = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
						goto IL_14bc;
						IL_143a:
						num2 = 207;
						DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
						goto IL_147e;
						IL_147e:
						num2 = 208;
						if (DC_Main.RtView.Count > 0)
						{
							goto IL_1497;
						}
						goto IL_14bc;
						IL_1497:
						num2 = 209;
						num9 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
						goto IL_14bc;
						IL_14bc:
						num2 = 212;
						if (num9 > 0.0)
						{
							goto IL_14d8;
						}
						goto IL_15f3;
						IL_14d8:
						num2 = 213;
						if (Operators.CompareString(val[DC_Main.i, 39], "G", false) == 0)
						{
							goto IL_14ff;
						}
						goto IL_153b;
						IL_14ff:
						num2 = 214;
						val[val.Row, 16] = Strings.Format((object)Math.Round(num9 / 10.0, 2), "0.00");
						goto IL_1610;
						IL_153b:
						num2 = 216;
						if (Operators.CompareString(val[DC_Main.i, 39], "K", false) == 0)
						{
							goto IL_1562;
						}
						goto IL_159b;
						IL_1562:
						num2 = 217;
						val[val.Row, 16] = Strings.Format((object)Math.Round(num9 / 10.0, 0), "0.00");
						goto IL_1610;
						IL_159b:
						num2 = 219;
						if (Operators.CompareString(val[DC_Main.i, 39], "1", false) == 0)
						{
							goto IL_15c2;
						}
						goto IL_1610;
						IL_15c2:
						num2 = 220;
						val[val.Row, 16] = Strings.Format((object)Math.Round(num9, 0), "0.00");
						goto IL_1610;
						IL_15f3:
						num2 = 223;
						val[val.Row, 16] = "";
						goto IL_1610;
						IL_1610:
						num2 = 226;
						val[DC_Main.i, 40] = Conversions.ToString(0);
						goto IL_162a;
						IL_162a:
						num2 = 227;
						val[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
						goto IL_1671;
						IL_1671:
						num2 = 228;
						val[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
						goto IL_16b8;
						IL_16b8:
						num2 = 229;
						val[DC_Main.i, 19] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
						goto IL_16f5;
						IL_16f5:
						num2 = 230;
						val[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
						goto IL_173c;
						IL_173c:
						num2 = 231;
						val[DC_Main.i, 44] = Conversions.ToString(0);
						goto IL_1756;
						IL_1756:
						num2 = 232;
						val[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
						goto IL_179d;
						IL_179d:
						num2 = 233;
						val[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
						goto IL_17e4;
						IL_17e4:
						num2 = 234;
						val[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
						goto IL_182b;
						IL_182b:
						num2 = 235;
						val[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
						goto IL_1872;
						IL_1872:
						num2 = 236;
						val[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
						goto IL_18b9;
						IL_18b9:
						num2 = 237;
						val[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
						goto IL_1900;
						IL_1900:
						num2 = 238;
						obj = val;
						i = DC_Main.i;
						Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
						obj[i, 38] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
						goto IL_1950;
						IL_1950:
						num2 = 239;
						val[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
						goto IL_1997;
						IL_1997:
						num2 = 240;
						val[DC_Main.i, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
						goto IL_19d4;
						IL_19d4:
						num2 = 241;
						val[DC_Main.i, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
						goto IL_1a11;
						IL_1a11:
						num2 = 242;
						val[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
						goto IL_1a4e;
						IL_1a4e:
						num2 = 243;
						val[DC_Main.i, 32] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
						goto IL_1a8b;
						IL_1a8b:
						num2 = 244;
						val[DC_Main.i, 29] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						goto IL_1ac8;
						IL_1ac8:
						num2 = 245;
						val[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
						goto IL_1b05;
						IL_1b05:
						num2 = 246;
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						goto IL_1b40;
						IL_1b40:
						num2 = 247;
						MsgOldRow = 0;
						goto IL_1b4d;
						IL_1b4d:
						num2 = 248;
						MSG_RowColChange(MSG, new EventArgs());
						goto IL_1b67;
						IL_1b67:
						num2 = 250;
						num10 = 0;
						goto IL_1b70;
						IL_1b70:
						num2 = 251;
						num11 = DtIdtl.Rows.Count - 1;
						goto IL_1b8a;
						IL_1b8a:
						num2 = 252;
						num12 = num11;
						num13 = 0;
						goto IL_1c34;
						IL_1c34:
						if (num13 <= num12)
						{
							goto IL_1b9c;
						}
						goto IL_1c3d;
						IL_1c3d:
						num2 = 260;
						MSG_IDTL_CLEAR();
						goto IL_1c4a;
						IL_1c4a:
						num2 = 261;
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + val[val.Row, 1] + "' AND A.VCH_SRNO = " + val[val.Row, 29] + " ";
						goto IL_1cba;
						IL_1cba:
						num2 = 262;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1ccf;
						IL_1ccf:
						num2 = 263;
						DC_Main.i = 0;
						goto IL_232d;
						IL_232d:
						num2 = 265;
						if (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_1ce0;
						}
						goto IL_2352;
						IL_2352:
						num2 = 294;
						MsgOldRow = 0;
						goto IL_235f;
						IL_235f:
						num2 = 295;
						CommPassTotal();
						goto IL_236c;
						IL_236c:
						num2 = 296;
						MSG_RowColChange(MSG, new EventArgs());
						goto IL_2384;
						IL_2384:
						num2 = 297;
						MSG_TOT_FILL();
						goto IL_2be3;
						IL_1ce0:
						num2 = 266;
						dr = DtIdtl.NewRow();
						goto IL_1cf7;
						IL_1cf7:
						num2 = 267;
						dr[23] = Conversion.Val(MSG[val.Row, 25]);
						goto IL_1d28;
						IL_1d28:
						num2 = 268;
						dr[0] = DC_Main.i + 1;
						goto IL_1d47;
						IL_1d47:
						num2 = 269;
						dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
						goto IL_1d82;
						IL_1d82:
						num2 = 270;
						dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
						goto IL_1dbd;
						IL_1dbd:
						num2 = 271;
						dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
						goto IL_1df8;
						IL_1df8:
						num2 = 272;
						dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
						goto IL_1e33;
						IL_1e33:
						num2 = 273;
						dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
						goto IL_1e6e;
						IL_1e6e:
						num2 = 274;
						dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
						goto IL_1ea9;
						IL_1ea9:
						num2 = 275;
						dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
						goto IL_1ee4;
						IL_1ee4:
						num2 = 276;
						dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
						goto IL_1f1f;
						IL_1f1f:
						num2 = 277;
						dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
						goto IL_1f5b;
						IL_1f5b:
						num2 = 278;
						dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
						goto IL_1f92;
						IL_1f92:
						num2 = 279;
						dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
						goto IL_1fdd;
						IL_1fdd:
						num2 = 280;
						dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
						goto IL_2028;
						IL_2028:
						num2 = 281;
						dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
						goto IL_2073;
						IL_2073:
						num2 = 282;
						dr[14] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						goto IL_20af;
						IL_20af:
						num2 = 283;
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
						goto IL_20fa;
						IL_20fa:
						num2 = 284;
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
						goto IL_2145;
						IL_2145:
						num2 = 285;
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
						goto IL_2190;
						IL_2190:
						num2 = 286;
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
						goto IL_21db;
						IL_21db:
						num2 = 287;
						dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
						goto IL_2226;
						IL_2226:
						num2 = 288;
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
						goto IL_2271;
						IL_2271:
						num2 = 289;
						dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
						goto IL_22c1;
						IL_22c1:
						num2 = 290;
						dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						goto IL_22fd;
						IL_22fd:
						num2 = 291;
						DtIdtl.Rows.Add(dr);
						goto IL_231a;
						IL_231a:
						num2 = 292;
						DC_Main.i++;
						goto IL_232d;
						IL_1b9c:
						num2 = 253;
						if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num10][23], (object)Conversion.Val(val[DC_Main.i, 25]), false))
						{
							goto IL_1bde;
						}
						goto IL_1c1c;
						IL_1bde:
						num2 = 254;
						DtIdtl.Rows[num10].Delete();
						goto IL_1bfc;
						IL_1bfc:
						num2 = 255;
						DtIdtl.AcceptChanges();
						goto IL_1c0e;
						IL_1c0e:
						num2 = 256;
						num10--;
						goto IL_1c1c;
						IL_1c1c:
						num2 = 258;
						num10++;
						goto IL_1c28;
						IL_1c28:
						num2 = 259;
						num13++;
						goto IL_1c34;
						IL_0a14:
						num2 = 145;
						if ((Operators.CompareString(val[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (val.Row != DC_Main.X))
						{
							goto IL_0a51;
						}
						goto IL_0a6b;
						IL_0a51:
						num2 = 146;
						Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0a6b:
						num2 = 149;
						DC_Main.X++;
						goto IL_0a7d;
						IL_2a04:
						num2 = 364;
						((Control)TEXT_ENTRY).Visible = false;
						goto IL_2a17;
						IL_2a36:
						num2 = 366;
						MSG_IDTL.Col = 1;
						goto IL_2a49;
						IL_2a49:
						num2 = 367;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						goto IL_2a61;
						IL_2775:
						num2 = 336;
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "'  AND TABLE_CODE = '" + TEXT_ENTRY.Text + "'";
						goto IL_27c9;
						IL_27c9:
						num2 = 337;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_27de;
						IL_27de:
						num2 = 338;
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							goto IL_27ff;
						}
						goto IL_293a;
						IL_27ff:
						num2 = 339;
						DC_Main.RsQry = "SELECT TABLE_NAME As CounterL,TABLE_CODE as CodeL  FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY TABLE_NAME";
						goto IL_283d;
						IL_283d:
						num2 = 340;
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2852;
						IL_2852:
						num2 = 341;
						DC_Main.ColWidth = new double[3];
						goto IL_2863;
						IL_2863:
						num2 = 342;
						DC_Main.ColWidth[0] = 400.0;
						goto IL_2879;
						IL_2879:
						num2 = 343;
						DC_Main.ColWidth[1] = 100.0;
						goto IL_288f;
						IL_288f:
						num2 = 344;
						DC_Main.HelpSelect = 1;
						goto IL_289b;
						IL_289b:
						num2 = 345;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						goto IL_28b1;
						IL_28b1:
						num2 = 346;
						if (DC_Main.HelpClose)
						{
							goto end_IL_0001_3;
						}
						goto IL_28c7;
						IL_28c7:
						num2 = 348;
						if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
						{
							goto IL_28e8;
						}
						goto IL_291f;
						IL_28e8:
						num2 = 349;
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						goto IL_2901;
						IL_2901:
						num2 = 350;
						val[val.Row, 27] = DC_Main.ColValue[1];
						goto IL_291f;
						IL_291f:
						num2 = 352;
						((Control)TEXT_ENTRY).Focus();
						goto end_IL_0001_3;
						IL_293a:
						num2 = 355;
						val[val.Row, 27] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						goto IL_2be3;
						IL_2be3:
						num2 = 398;
						if (val.Col < val.Cols - 1)
						{
							goto IL_2bff;
						}
						goto IL_2c20;
						IL_2bff:
						num2 = 399;
						MSG.Col += 1;
						goto IL_2c20;
						IL_2c20:
						num2 = 401;
						((Control)TEXT_ENTRY).Visible = true;
						goto IL_2c33;
						IL_2c33:
						num2 = 402;
						((Control)TEXT_ENTRY).Focus();
						break;
						IL_2a91:
						num2 = 373;
						if (val.Row == val.Rows - 1)
						{
							goto IL_2ab0;
						}
						goto IL_2b5d;
						IL_2ab0:
						num2 = 374;
						CommPassTotal();
						goto IL_2abd;
						IL_2abd:
						num2 = 375;
						MsgClear = true;
						goto IL_2aca;
						IL_2aca:
						num2 = 376;
						val.Rows += 1;
						goto IL_2adf;
						IL_2adf:
						num2 = 377;
						val.Row += 1;
						goto IL_2af4;
						IL_2af4:
						num2 = 378;
						MsgClear = false;
						goto IL_2b01;
						IL_2b01:
						num2 = 379;
						if (MSG[1] == 0)
						{
							goto IL_2b1c;
						}
						goto IL_2b33;
						IL_2b1c:
						num2 = 380;
						MSG.Col = 2;
						goto IL_2b47;
						IL_2b33:
						num2 = 382;
						MSG.Col = 1;
						goto IL_2b47;
						IL_2b47:
						num2 = 384;
						CommPassAdd();
						goto end_IL_0001_3;
						IL_2b5d:
						num2 = 387;
						val.Row += 1;
						goto IL_2b73;
						IL_2b73:
						num2 = 389;
						if (MSG[1] == 0)
						{
							goto IL_2b8e;
						}
						goto IL_2ba5;
						IL_2b8e:
						num2 = 390;
						MSG.Col = 2;
						goto IL_2bb9;
						IL_2ba5:
						num2 = 392;
						MSG.Col = 1;
						goto IL_2bb9;
						end_IL_0001_2:
						break;
					}
					val = null;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj2) when (obj2 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj2);
				try0001_dispatch = 12974;
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

	private void TR_SALE_RTN_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_1248: Unknown result type (might be due to invalid IL or missing references)
		//IL_124d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1257: Expected O, but got Unknown
		//IL_127c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1281: Unknown result type (might be due to invalid IL or missing references)
		//IL_128b: Expected O, but got Unknown
		//IL_12b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12bf: Expected O, but got Unknown
		//IL_12e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f3: Expected O, but got Unknown
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_131d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1327: Expected O, but got Unknown
		//IL_1366: Unknown result type (might be due to invalid IL or missing references)
		//IL_136b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1375: Expected O, but got Unknown
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1394: Unknown result type (might be due to invalid IL or missing references)
		//IL_139e: Expected O, but got Unknown
		//IL_13b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_13bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c7: Expected O, but got Unknown
		//IL_13e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_13e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f0: Expected O, but got Unknown
		//IL_140a: Unknown result type (might be due to invalid IL or missing references)
		//IL_140f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Expected O, but got Unknown
		//IL_1433: Unknown result type (might be due to invalid IL or missing references)
		//IL_1438: Unknown result type (might be due to invalid IL or missing references)
		//IL_1442: Expected O, but got Unknown
		//IL_145c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1461: Unknown result type (might be due to invalid IL or missing references)
		//IL_146b: Expected O, but got Unknown
		//IL_1493: Unknown result type (might be due to invalid IL or missing references)
		//IL_149a: Expected O, but got Unknown
		//IL_1586: Unknown result type (might be due to invalid IL or missing references)
		//IL_158b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1595: Expected O, but got Unknown
		//IL_161d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1622: Unknown result type (might be due to invalid IL or missing references)
		//IL_162c: Expected O, but got Unknown
		//IL_16c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d0: Expected O, but got Unknown
		//IL_175a: Unknown result type (might be due to invalid IL or missing references)
		//IL_175f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1769: Expected O, but got Unknown
		//IL_178e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1793: Unknown result type (might be due to invalid IL or missing references)
		//IL_179d: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_RTN_IDTL = MSG_RTN_IDTL;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL2 = MSG_RTN_IDTL;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG_RTN_IDTL2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL3 = MSG_RTN_IDTL;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_RTN_IDTL3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_PR = MSG_PR;
				object? obj21 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_PR2 = MSG_PR;
				object? obj22 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_PR3 = MSG_PR;
				object? obj23 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_PR_TOT = MSG_PR_TOT;
				object? obj24 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_PR_TOT2 = MSG_PR_TOT;
				object? obj25 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR_TOT3 = MSG_PR_TOT;
				object? obj26 = colorConverter.ConvertFromString("Silver");
				mSG_PR_TOT3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj28 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj29 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
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
				AxMSFlexGrid mSG_RTN_IDTL4 = MSG_RTN_IDTL;
				object? obj41 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL4.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL5 = MSG_RTN_IDTL;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_RTN_IDTL5.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL6 = MSG_RTN_IDTL;
				object? obj43 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_RTN_IDTL6.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj44 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj45 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj46 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj47 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj48 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj49 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj51 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj53 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj54 = lblBook;
				object? obj55 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj54).ForeColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj56 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj57 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj58 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj59 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj60 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj61 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj62 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL7 = MSG_RTN_IDTL;
				object? obj63 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_RTN_IDTL7.BackColor = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL8 = MSG_RTN_IDTL;
				object? obj64 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_RTN_IDTL8.BackColorBkg = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_RTN_IDTL9 = MSG_RTN_IDTL;
				object? obj65 = colorConverter.ConvertFromString("Cornsilk");
				mSG_RTN_IDTL9.BackColorFixed = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj66 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj67 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj68 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj69 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj70 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj71 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj71 != null) ? ((Color)obj71) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj72 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj72 != null) ? ((Color)obj72) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj73 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj73 != null) ? ((Color)obj73) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj74 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj75 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj76 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj77 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj78 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj78 != null) ? ((Color)obj78) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_RTN_IDTL).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_RTN_IDTL).Font = new Font(((Control)TEXT_RTN_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_RTN_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_RTN_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_RTN_IDTL.Font.Style);
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
						if (unchecked((Operators.CompareString(val3.Name, "lblBook", false) != 0 && val3 is TextBox) || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_RTN_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
			DC_Main.RsQry = "SELECT DATA_TYPE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + FormBook + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				ItmDataType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["DATA_TYPE"], (object)""));
			}
			if (Operators.CompareString(ItmDataType, "", false) == 0)
			{
				ItmDataType = "A";
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
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		UsUPdate = "N";
		UsDelete = "N";
		OldValTot = 0.0;
		NewValTot = 0.0;
		TotCrFine = 0.0;
		TotDrFine = 0.0;
		SlOthAmtLess = 0.0;
		PrOthAmtLess = 0.0;
		LessAdvAmt = 0.0;
		LessAdvNetWt = 0.0;
		OldNetAmt = 0.0;
		OldTaxPrc = 0.0;
		EditOPen = false;
		CrDrTot = 0.0;
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
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		AcGstType = "L";
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		((Control)TEXT_RTN_IDTL).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_PR_CLEAR();
		MSG_RTN_IDTL_CLEAR();
		MSG2_CLEAR();
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
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num2 = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num2)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			RtnIdtl.Clear();
			RtnIdtl.Reset();
			RtnRow = 0;
			int num3 = MSG_RTN_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num3)
			{
				RtnIdtl.Columns.Add(MSG_RTN_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "'";
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			VchOldData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				EditOPen = true;
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				nAcDrAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"])), "0.00");
				MSG2_TOTAL[3, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"])), "0.00");
				MSG2_TOTAL[4, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"])), "0.00");
				MSG2_TOTAL[5, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"])), "0.00");
				MSG2_TOTAL[6, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"])), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[7, 4] = Strings.Format((object)Conversion.Val((object)num), "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[8, 4] = Strings.Format((object)Conversion.Val((object)num2), "0.00");
				nAcCrAmt.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_NET_AMT"])), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_NET_AMT"])), "0.00"));
				MSG2_TOTAL[2, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"])), "0.00");
				OldTaxPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"])), "0.00"));
				MSG2_TOTAL[2, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"])), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_TOT_AMT"])), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CHQ_AMT"])), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CARD_AMT"])), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CASH_AMT"])), "0.00");
				double num3 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CASH_AMT"])), "0.00"));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["RTN_KASAR_AMT"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["RTN_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[7, 3] = Strings.Format((object)Conversion.Val((object)num4), "0.00");
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["RTN_BILL_OS"]);
				double num5 = DC_Main.Fnv(ref Value);
				dataRow["RTN_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[8, 3] = Strings.Format((object)Conversion.Val((object)num5), "0.00");
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				MSG2_TOTAL[4, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[4, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[4, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[5, 5] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[5, 5] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
				tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
				tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
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
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				CustClAmt = DC_Main.MsAcAmtClBal;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
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
					mSG[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 39] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 32] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 29] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 26] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num6 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num6)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
					dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM SL_DETL_RTN AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsPrDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OLD_SRNO"])), "0");
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""), (object)"", false))
					{
						mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 9] = Conversions.ToString(RsPrDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_LBR_CODE"], (object)""));
					if (Operators.CompareString(mSG_PR[DC_Main.i + 1, 29], "", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 29] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 39] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 40] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
					mSG_PR[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG_PR[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG_PR[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsPrDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["APR_ISU"], (object)""));
					mSG_PR[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
					mSG_PR[DC_Main.i + 1, 57] = "E";
					mSG_PR[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsPrDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				RtnIdtl.Clear();
				RtnIdtl.Reset();
				RtnRow = 0;
				int num7 = MSG_RTN_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					RtnIdtl.Columns.Add(MSG_RTN_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					Rtndr = RtnIdtl.NewRow();
					Rtndr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					Rtndr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					Rtndr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					Rtndr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					Rtndr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					Rtndr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					Rtndr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					Rtndr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					Rtndr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					Rtndr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					Rtndr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					Rtndr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					Rtndr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					Rtndr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					Rtndr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					Rtndr[14] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					Rtndr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					Rtndr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					Rtndr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					Rtndr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					Rtndr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					Rtndr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					Rtndr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					Rtndr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					RtnIdtl.Rows.Add(Rtndr);
					DC_Main.i++;
				}
				if (MSG_PR.Rows >= 1 && Operators.CompareString(MSG_PR[1, 2], "", false) != 0)
				{
					MSG_PR.Row = 1;
					RtnOldRow = 0;
					MSG_PR_RowColChange(MSG_PR, new EventArgs());
				}
				if (MSG.Rows >= 1 && Operators.CompareString(MSG[1, 1], "", false) != 0)
				{
					MSG.Row = 1;
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				EditOPen = false;
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 22]) + Conversion.Val(MSG_TOT[0, 21]) + Conversion.Val(MSG2_TOTAL[8, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 22]) + Conversion.Val(MSG_TOT[0, 21]) + Conversion.Val(MSG2_TOTAL[8, 3]);
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

	private void TR_SALE_RTN_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_RTN_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0358: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_059f: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Unknown result type (might be due to invalid IL or missing references)
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_62df: Unknown result type (might be due to invalid IL or missing references)
		//IL_62e5: Invalid comparison between Unknown and I4
		//IL_6534: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int num5 = default(int);
		double num6 = default(double);
		DataTable dataTable = default(DataTable);
		DataRow dataRow = default(DataRow);
		DataRow dataRow2 = default(DataRow);
		DataRow dataRow3 = default(DataRow);
		int num7 = default(int);
		DataRow dataRow4 = default(DataRow);
		int num8 = default(int);
		int num9 = default(int);
		DataRow dataRow5 = default(DataRow);
		int num10 = default(int);
		DataRow dataRow6 = default(DataRow);
		DataRow dataRow7 = default(DataRow);
		int num11 = default(int);
		DataRow dataRow8 = default(DataRow);
		int num12 = default(int);
		int num13 = default(int);
		DataRow dataRow9 = default(DataRow);
		string text = default(string);
		int num14 = default(int);
		int num15 = default(int);
		int num16 = default(int);
		int num17 = default(int);
		int m = default(int);
		AxMSFlexGrid val2 = default(AxMSFlexGrid);
		AxMSFlexGrid val3 = default(AxMSFlexGrid);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					DataTable rtnIdtl;
					DataTable dtIdtl;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							goto IL_0032;
						}
						goto IL_0048;
					case 28999:
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
								goto IL_0032;
							case 4:
							case 5:
								goto IL_0048;
							case 6:
								goto IL_007d;
							case 7:
								goto IL_008c;
							case 9:
							case 10:
								goto IL_00a1;
							case 11:
								goto IL_00b5;
							case 12:
								goto IL_00ef;
							case 13:
								goto IL_00ff;
							case 15:
							case 16:
								goto IL_0113;
							case 17:
								goto IL_012f;
							case 18:
								goto IL_0154;
							case 19:
								goto IL_0178;
							case 20:
								goto IL_01a0;
							case 22:
							case 23:
							case 24:
							case 25:
								goto IL_021b;
							case 26:
								goto IL_0251;
							case 27:
								goto IL_0261;
							case 29:
							case 30:
								goto IL_0277;
							case 31:
								goto IL_02cf;
							case 32:
								goto IL_02df;
							case 34:
							case 35:
								goto IL_02f6;
							case 36:
								goto IL_034e;
							case 37:
								goto IL_035e;
							case 39:
							case 40:
								goto IL_0375;
							case 41:
								goto IL_03a6;
							case 42:
								goto IL_03b6;
							case 44:
							case 45:
								goto IL_03cd;
							case 46:
								goto IL_03ea;
							case 47:
							case 48:
								goto IL_040e;
							case 49:
								goto IL_041e;
							case 50:
								goto IL_046c;
							case 51:
								goto IL_0480;
							case 53:
							case 54:
								goto IL_0497;
							case 55:
								goto IL_04c0;
							case 56:
								goto IL_04e4;
							case 58:
							case 59:
								goto IL_04fb;
							case 60:
								goto IL_0518;
							case 61:
								goto IL_054a;
							case 62:
								goto IL_055a;
							case 64:
							case 65:
							case 66:
								goto IL_0573;
							case 67:
								goto IL_0595;
							case 68:
								goto IL_05a5;
							case 70:
							case 71:
								goto IL_05bc;
							case 72:
								goto IL_05db;
							case 73:
								goto IL_05f8;
							case 74:
								goto IL_0640;
							case 75:
								goto IL_0650;
							case 76:
								goto IL_0660;
							case 77:
								goto IL_0674;
							case 78:
								goto IL_0684;
							case 79:
								goto IL_0699;
							case 81:
							case 82:
								goto IL_06af;
							case 83:
							case 84:
								goto IL_06cc;
							case 85:
								goto IL_06d6;
							case 86:
								goto IL_06e0;
							case 87:
								goto IL_06ed;
							case 88:
								goto IL_0709;
							case 89:
							case 90:
								goto IL_0722;
							case 91:
								goto IL_0759;
							case 92:
								goto IL_0769;
							case 94:
							case 95:
								goto IL_0780;
							case 96:
								goto IL_0789;
							case 97:
								goto IL_07a9;
							case 98:
								goto IL_081d;
							case 99:
								goto IL_082f;
							case 100:
								goto IL_084d;
							case 101:
								goto IL_08a9;
							case 102:
								goto IL_08bb;
							case 103:
								goto IL_08d9;
							case 104:
								goto IL_0930;
							case 105:
							case 106:
							case 107:
								goto IL_0980;
							case 108:
								goto IL_09e2;
							case 109:
								goto IL_09f4;
							case 110:
								goto IL_0a12;
							case 111:
								goto IL_0a5d;
							case 112:
								goto IL_0a6f;
							case 113:
								goto IL_0a8a;
							case 114:
							case 115:
							case 116:
							case 117:
								goto IL_0adc;
							case 118:
								goto IL_0b51;
							case 119:
								goto IL_0bc6;
							case 120:
								goto IL_0c3b;
							case 121:
								goto IL_0c78;
							case 122:
								goto IL_0cdb;
							case 123:
								goto IL_0d3d;
							case 124:
								goto IL_0d4c;
							case 125:
								goto IL_0d55;
							case 126:
								goto IL_0d61;
							case 127:
								goto IL_0d76;
							case 128:
								goto IL_0d8b;
							case 129:
								goto IL_0da3;
							case 130:
								goto IL_0dc1;
							case 131:
								goto IL_0dda;
							case 132:
								goto IL_0def;
							case 133:
								goto IL_0e02;
							case 134:
								goto IL_0e10;
							case 135:
								goto IL_0e87;
							case 136:
								goto IL_0e9d;
							case 137:
								goto IL_0ea9;
							case 138:
								goto IL_0ebc;
							case 139:
								goto IL_0ed4;
							case 140:
								goto IL_0eec;
							case 141:
								goto IL_0f04;
							case 142:
								goto IL_0f1c;
							case 143:
								goto IL_0f3a;
							case 144:
								goto IL_0f58;
							case 145:
								goto IL_0f76;
							case 146:
								goto IL_0f94;
							case 147:
								goto IL_0fb2;
							case 148:
								goto IL_0fd0;
							case 149:
								goto IL_0ff8;
							case 150:
								goto IL_1011;
							case 151:
								goto IL_102a;
							case 152:
								goto IL_1043;
							case 153:
								goto IL_105c;
							case 154:
								goto IL_1075;
							case 155:
								goto IL_108e;
							case 156:
								goto IL_10a7;
							case 157:
								goto IL_10c0;
							case 158:
								goto IL_10d9;
							case 159:
								goto IL_10f2;
							case 160:
								goto IL_110b;
							case 161:
								goto IL_1136;
							case 162:
								goto IL_1161;
							case 163:
								goto IL_118b;
							case 164:
								goto IL_11b5;
							case 165:
								goto IL_11df;
							case 166:
								goto IL_11f8;
							case 167:
								goto IL_1222;
							case 168:
								goto IL_124c;
							case 169:
								goto IL_1276;
							case 170:
								goto IL_129e;
							case 171:
								goto IL_12c8;
							case 172:
								goto IL_12f2;
							case 173:
								goto IL_131c;
							case 174:
								goto IL_134b;
							case 175:
								goto IL_136b;
							case 176:
								goto IL_1395;
							case 177:
								goto IL_13ae;
							case 179:
								goto IL_13ce;
							case 180:
								goto IL_13e7;
							case 181:
								goto IL_141b;
							case 184:
								goto IL_1454;
							case 185:
								goto IL_146d;
							case 186:
								goto IL_1486;
							case 178:
							case 182:
							case 183:
							case 187:
							case 188:
								goto IL_14a0;
							case 189:
								goto IL_14b9;
							case 190:
								goto IL_14d1;
							case 191:
								goto IL_14ea;
							case 192:
								goto IL_1503;
							case 193:
								goto IL_152d;
							case 194:
								goto IL_1557;
							case 195:
								goto IL_1581;
							case 196:
								goto IL_15ab;
							case 197:
								goto IL_15d5;
							case 198:
								goto IL_15ff;
							case 199:
								goto IL_161f;
							case 200:
								goto IL_163f;
							case 201:
								goto IL_165f;
							case 202:
								goto IL_167d;
							case 203:
								goto IL_1695;
							case 204:
								goto IL_16b3;
							case 205:
								goto IL_16d1;
							case 206:
								goto IL_16e9;
							case 207:
								goto IL_1701;
							case 208:
								goto IL_1719;
							case 209:
								goto IL_1731;
							case 210:
								goto IL_1749;
							case 211:
								goto IL_1761;
							case 212:
								goto IL_1779;
							case 213:
								goto IL_1791;
							case 214:
								goto IL_17a9;
							case 215:
								goto IL_17c7;
							case 216:
								goto IL_17e5;
							case 217:
								goto IL_1818;
							case 218:
								goto IL_1830;
							case 219:
								goto IL_1850;
							case 221:
								goto IL_186b;
							case 220:
							case 222:
								goto IL_1883;
							case 223:
								goto IL_189c;
							case 224:
								goto IL_18b4;
							case 225:
								goto IL_18cc;
							case 226:
								goto IL_18e4;
							case 227:
								goto IL_18fc;
							case 228:
								goto IL_1915;
							case 229:
								goto IL_192e;
							case 230:
								goto IL_1947;
							case 231:
								goto IL_195f;
							case 232:
								goto IL_1978;
							case 233:
								goto IL_1991;
							case 234:
								goto IL_19a8;
							case 235:
							case 236:
								goto IL_19bc;
							case 237:
								goto IL_1a33;
							case 238:
								goto IL_1a49;
							case 239:
								goto IL_1a55;
							case 240:
								goto IL_1a68;
							case 241:
								goto IL_1a89;
							case 242:
								goto IL_1a97;
							case 243:
								goto IL_1b19;
							case 244:
								goto IL_1b31;
							case 245:
								goto IL_1b49;
							case 246:
								goto IL_1b61;
							case 247:
								goto IL_1b79;
							case 248:
								goto IL_1b97;
							case 249:
								goto IL_1bb5;
							case 250:
								goto IL_1bd3;
							case 251:
								goto IL_1bf1;
							case 252:
								goto IL_1c0a;
							case 253:
								goto IL_1c23;
							case 254:
								goto IL_1c3b;
							case 255:
								goto IL_1c54;
							case 256:
								goto IL_1c7e;
							case 257:
								goto IL_1ca9;
							case 258:
								goto IL_1cc9;
							case 259:
								goto IL_1ce9;
							case 260:
								goto IL_1d10;
							case 262:
								goto IL_1d2c;
							case 261:
							case 263:
							case 264:
								goto IL_1d4d;
							case 265:
								goto IL_1d6e;
							case 266:
								goto IL_1d8e;
							case 267:
								goto IL_1dae;
							case 268:
								goto IL_1dce;
							case 269:
								goto IL_1df8;
							case 270:
								goto IL_1e11;
							case 271:
								goto IL_1e3b;
							case 272:
								goto IL_1e66;
							case 273:
								goto IL_1e91;
							case 274:
								goto IL_1ebc;
							case 275:
								goto IL_1ee7;
							case 276:
								goto IL_1f12;
							case 277:
								goto IL_1f3d;
							case 278:
								goto IL_1f5e;
							case 279:
								goto IL_1f89;
							case 280:
								goto IL_1fb4;
							case 281:
								goto IL_1fdf;
							case 282:
								goto IL_2000;
							case 283:
								goto IL_202b;
							case 284:
								goto IL_2056;
							case 285:
								goto IL_2081;
							case 286:
								goto IL_20ac;
							case 287:
								goto IL_20c5;
							case 288:
								goto IL_20f0;
							case 289:
								goto IL_211b;
							case 290:
								goto IL_2146;
							case 291:
								goto IL_2171;
							case 292:
								goto IL_219c;
							case 293:
								goto IL_21c7;
							case 294:
								goto IL_21e8;
							case 295:
								goto IL_2209;
							case 296:
								goto IL_222a;
							case 297:
								goto IL_2255;
							case 298:
								goto IL_226d;
							case 299:
								goto IL_22a0;
							case 300:
								goto IL_22b9;
							case 301:
								goto IL_22d7;
							case 302:
								goto IL_22ef;
							case 303:
								goto IL_2310;
							case 304:
								goto IL_2329;
							case 305:
								goto IL_2340;
							case 306:
							case 307:
								goto IL_2355;
							case 308:
								goto IL_2358;
							case 309:
								goto IL_2376;
							case 310:
								goto IL_23ed;
							case 311:
								goto IL_2403;
							case 312:
								goto IL_240f;
							case 313:
								goto IL_2422;
							case 314:
								goto IL_2445;
							case 315:
								goto IL_2453;
							case 316:
								goto IL_24db;
							case 317:
								goto IL_24f3;
							case 318:
								goto IL_250b;
							case 319:
								goto IL_2523;
							case 320:
								goto IL_253b;
							case 321:
								goto IL_2559;
							case 322:
								goto IL_2577;
							case 323:
								goto IL_2595;
							case 324:
								goto IL_25b3;
							case 325:
								goto IL_25cc;
							case 326:
								goto IL_25e5;
							case 327:
								goto IL_25fd;
							case 328:
								goto IL_2616;
							case 329:
								goto IL_2651;
							case 330:
								goto IL_2699;
							case 331:
								goto IL_26ec;
							case 332:
								goto IL_2726;
							case 333:
								goto IL_2756;
							case 334:
								goto IL_2786;
							case 335:
								goto IL_27b6;
							case 336:
								goto IL_27e6;
							case 337:
								goto IL_2816;
							case 338:
								goto IL_2846;
							case 339:
								goto IL_2876;
							case 340:
								goto IL_28a7;
							case 341:
								goto IL_28e2;
							case 342:
								goto IL_291d;
							case 343:
								goto IL_2958;
							case 344:
								goto IL_2993;
							case 345:
								goto IL_29c4;
							case 346:
								goto IL_29ff;
							case 347:
								goto IL_2a3a;
							case 348:
								goto IL_2a75;
							case 349:
								goto IL_2ab0;
							case 350:
								goto IL_2aeb;
							case 351:
								goto IL_2b26;
							case 352:
								goto IL_2b57;
							case 353:
								goto IL_2b70;
							case 354:
								goto IL_2b89;
							case 355:
								goto IL_2ba0;
							case 356:
							case 357:
								goto IL_2bb5;
							case 358:
								goto IL_2bb8;
							case 359:
								goto IL_2bcd;
							case 360:
								goto IL_2c45;
							case 361:
								goto IL_2cbd;
							case 362:
								goto IL_2d35;
							case 363:
								goto IL_2dad;
							case 364:
								goto IL_2e12;
							case 365:
								goto IL_2e28;
							case 366:
								goto IL_2e34;
							case 367:
								goto IL_2e47;
							case 368:
								goto IL_2e68;
							case 369:
								goto IL_2e76;
							case 370:
								goto IL_2ee2;
							case 371:
								goto IL_2efa;
							case 372:
								goto IL_2f12;
							case 373:
								goto IL_2f2a;
							case 374:
								goto IL_2f42;
							case 375:
								goto IL_2f60;
							case 376:
								goto IL_2f7e;
							case 377:
								goto IL_2f9c;
							case 378:
								goto IL_2fba;
							case 379:
								goto IL_2fd3;
							case 380:
								goto IL_2fec;
							case 381:
								goto IL_3004;
							case 382:
								goto IL_301d;
							case 383:
								goto IL_3047;
							case 384:
								goto IL_3072;
							case 385:
								goto IL_3092;
							case 386:
								goto IL_30b2;
							case 387:
								goto IL_30d9;
							case 389:
								goto IL_30f5;
							case 388:
							case 390:
							case 391:
								goto IL_3116;
							case 392:
								goto IL_3136;
							case 393:
								goto IL_3156;
							case 394:
								goto IL_3176;
							case 395:
								goto IL_3196;
							case 396:
								goto IL_31b6;
							case 397:
								goto IL_31e1;
							case 398:
								goto IL_320c;
							case 399:
								goto IL_3237;
							case 400:
								goto IL_3262;
							case 401:
								goto IL_328d;
							case 402:
								goto IL_32b8;
							case 403:
								goto IL_32e3;
							case 404:
								goto IL_330e;
							case 405:
								goto IL_3339;
							case 406:
								goto IL_3364;
							case 407:
								goto IL_338f;
							case 408:
								goto IL_33b0;
							case 409:
								goto IL_33db;
							case 410:
								goto IL_33fc;
							case 411:
								goto IL_3427;
							case 412:
								goto IL_3452;
							case 413:
								goto IL_347d;
							case 414:
								goto IL_34a8;
							case 415:
								goto IL_34d3;
							case 416:
								goto IL_34fe;
							case 417:
								goto IL_351f;
							case 418:
								goto IL_354a;
							case 419:
								goto IL_3575;
							case 420:
								goto IL_35a0;
							case 421:
								goto IL_35cb;
							case 422:
								goto IL_35f6;
							case 423:
								goto IL_3621;
							case 424:
								goto IL_364c;
							case 425:
								goto IL_3677;
							case 426:
								goto IL_36a2;
							case 427:
								goto IL_36c3;
							case 428:
								goto IL_36f0;
							case 429:
								goto IL_37cb;
							case 431:
								goto IL_37fa;
							case 430:
							case 432:
							case 433:
								goto IL_3826;
							case 434:
								goto IL_3847;
							case 435:
								goto IL_3868;
							case 436:
								goto IL_3889;
							case 437:
								goto IL_38b4;
							case 438:
								goto IL_38d5;
							case 439:
								goto IL_38f6;
							case 440:
								goto IL_3917;
							case 441:
								goto IL_3942;
							case 442:
								goto IL_396d;
							case 443:
								goto IL_3998;
							case 444:
								goto IL_39c3;
							case 445:
								goto IL_39e4;
							case 446:
								goto IL_3a05;
							case 447:
								goto IL_3a26;
							case 448:
								goto IL_3a59;
							case 449:
								goto IL_3a72;
							case 450:
								goto IL_3a90;
							case 451:
								goto IL_3ab1;
							case 452:
								goto IL_3ad9;
							case 454:
								goto IL_3af5;
							case 453:
							case 455:
							case 456:
								goto IL_3b17;
							case 457:
								goto IL_3b30;
							case 458:
								goto IL_3b47;
							case 459:
							case 460:
								goto IL_3b5c;
							case 461:
								goto IL_3b5f;
							case 462:
								goto IL_3b7d;
							case 463:
								goto IL_3bf4;
							case 464:
								goto IL_3c0a;
							case 465:
								goto IL_3c16;
							case 466:
								goto IL_3c29;
							case 467:
								goto IL_3ca3;
							case 468:
								goto IL_3cbb;
							case 469:
								goto IL_3cd3;
							case 470:
								goto IL_3ceb;
							case 471:
								goto IL_3d03;
							case 472:
								goto IL_3d21;
							case 473:
								goto IL_3d3f;
							case 474:
								goto IL_3d57;
							case 475:
								goto IL_3d8a;
							case 476:
								goto IL_3da8;
							case 477:
								goto IL_3dc6;
							case 478:
								goto IL_3dde;
							case 479:
								goto IL_3df7;
							case 480:
								goto IL_3e10;
							case 481:
								goto IL_3e27;
							case 482:
							case 483:
								goto IL_3e3b;
							case 484:
								goto IL_3ea0;
							case 485:
								goto IL_3eb6;
							case 486:
								goto IL_3ec2;
							case 487:
								goto IL_3ed5;
							case 488:
								goto IL_3ef6;
							case 489:
								goto IL_3f04;
							case 490:
								goto IL_3f88;
							case 491:
								goto IL_3fa0;
							case 492:
								goto IL_3fb8;
							case 493:
								goto IL_3fd0;
							case 494:
								goto IL_3fe8;
							case 495:
								goto IL_4006;
							case 496:
								goto IL_4024;
							case 497:
								goto IL_4042;
							case 498:
								goto IL_4060;
							case 499:
								goto IL_407e;
							case 500:
								goto IL_4097;
							case 501:
								goto IL_40b0;
							case 502:
								goto IL_40c8;
							case 503:
								goto IL_40e1;
							case 504:
								goto IL_410b;
							case 505:
								goto IL_4136;
							case 506:
								goto IL_4156;
							case 507:
								goto IL_417d;
							case 509:
								goto IL_4199;
							case 508:
							case 510:
							case 511:
								goto IL_41ba;
							case 512:
								goto IL_41da;
							case 513:
								goto IL_41fa;
							case 514:
								goto IL_421a;
							case 515:
								goto IL_423a;
							case 516:
								goto IL_425a;
							case 517:
								goto IL_4285;
							case 518:
								goto IL_42b0;
							case 519:
								goto IL_42db;
							case 520:
								goto IL_4306;
							case 521:
								goto IL_4331;
							case 522:
								goto IL_435c;
							case 523:
								goto IL_4387;
							case 524:
								goto IL_43b2;
							case 525:
								goto IL_43dd;
							case 526:
								goto IL_4408;
							case 527:
								goto IL_4433;
							case 528:
								goto IL_445e;
							case 529:
								goto IL_4489;
							case 530:
								goto IL_44a2;
							case 531:
								goto IL_44bb;
							case 532:
								goto IL_44dc;
							case 533:
								goto IL_44fd;
							case 534:
								goto IL_4528;
							case 535:
								goto IL_4553;
							case 536:
								goto IL_457e;
							case 537:
								goto IL_45a9;
							case 538:
								goto IL_45d4;
							case 539:
								goto IL_45ff;
							case 540:
								goto IL_462a;
							case 541:
								goto IL_464b;
							case 542:
								goto IL_466c;
							case 543:
								goto IL_468d;
							case 544:
								goto IL_46c0;
							case 545:
								goto IL_46e1;
							case 546:
								goto IL_4702;
							case 547:
								goto IL_471b;
							case 548:
								goto IL_4734;
							case 549:
								goto IL_474d;
							case 550:
								goto IL_4766;
							case 551:
								goto IL_4793;
							case 552:
								goto IL_486e;
							case 554:
								goto IL_489d;
							case 553:
							case 555:
							case 556:
								goto IL_48c9;
							case 557:
								goto IL_48f4;
							case 558:
								goto IL_4915;
							case 559:
								goto IL_4936;
							case 560:
								goto IL_4957;
							case 561:
								goto IL_4978;
							case 562:
								goto IL_4999;
							case 563:
								goto IL_49ba;
							case 564:
								goto IL_49e5;
							case 565:
								goto IL_4a10;
							case 566:
								goto IL_4a3b;
							case 567:
								goto IL_4a66;
							case 568:
								goto IL_4a8e;
							case 570:
								goto IL_4aaa;
							case 569:
							case 571:
							case 572:
								goto IL_4acc;
							case 573:
								goto IL_4ae4;
							case 574:
								goto IL_4afd;
							case 575:
								goto IL_4b16;
							case 576:
								goto IL_4b2d;
							case 577:
							case 578:
								goto IL_4b42;
							case 579:
								goto IL_4b45;
							case 580:
								goto IL_4b63;
							case 581:
								goto IL_4bda;
							case 582:
								goto IL_4bf0;
							case 583:
								goto IL_4bfc;
							case 584:
								goto IL_4c0f;
							case 585:
								goto IL_4c32;
							case 586:
								goto IL_4c40;
							case 587:
								goto IL_4cc8;
							case 588:
								goto IL_4ce5;
							case 589:
								goto IL_4d2d;
							case 591:
							case 592:
								goto IL_4d3e;
							case 590:
							case 593:
								goto IL_4d59;
							case 594:
								goto IL_4d71;
							case 595:
								goto IL_4d89;
							case 596:
								goto IL_4da1;
							case 597:
								goto IL_4db9;
							case 598:
								goto IL_4dd7;
							case 599:
								goto IL_4df5;
							case 600:
								goto IL_4e13;
							case 601:
								goto IL_4e2c;
							case 602:
								goto IL_4e45;
							case 603:
								goto IL_4e5d;
							case 604:
								goto IL_4e76;
							case 605:
								goto IL_4ea2;
							case 606:
								goto IL_4ec3;
							case 607:
								goto IL_4eef;
							case 608:
								goto IL_4f29;
							case 609:
								goto IL_4f59;
							case 610:
								goto IL_4f89;
							case 611:
								goto IL_4fb9;
							case 612:
								goto IL_4fe9;
							case 613:
								goto IL_5019;
							case 614:
								goto IL_5049;
							case 615:
								goto IL_5079;
							case 616:
								goto IL_50aa;
							case 617:
								goto IL_50e5;
							case 618:
								goto IL_5120;
							case 619:
								goto IL_515b;
							case 620:
								goto IL_5196;
							case 621:
								goto IL_51c7;
							case 622:
								goto IL_5202;
							case 623:
								goto IL_523d;
							case 624:
								goto IL_5278;
							case 625:
								goto IL_52b3;
							case 626:
								goto IL_52ee;
							case 627:
								goto IL_5329;
							case 628:
								goto IL_535a;
							case 629:
								goto IL_5373;
							case 630:
								goto IL_538c;
							case 631:
								goto IL_53a3;
							case 632:
							case 633:
								goto IL_53b8;
							case 634:
								goto IL_53bb;
							case 635:
								goto IL_53d0;
							case 636:
								goto IL_53f8;
							case 637:
								goto IL_5470;
							case 638:
								goto IL_54d5;
							case 639:
								goto IL_54eb;
							case 640:
								goto IL_54f7;
							case 641:
								goto IL_550a;
							case 642:
								goto IL_5539;
							case 643:
								goto IL_5551;
							case 644:
								goto IL_5569;
							case 645:
								goto IL_5581;
							case 646:
								goto IL_5599;
							case 647:
								goto IL_55b7;
							case 648:
								goto IL_55d0;
							case 649:
								goto IL_55ee;
							case 650:
								goto IL_560c;
							case 651:
								goto IL_562a;
							case 652:
								goto IL_5643;
							case 653:
								goto IL_565c;
							case 654:
								goto IL_5674;
							case 655:
								goto IL_568d;
							case 656:
								goto IL_56b7;
							case 657:
								goto IL_5707;
							case 658:
								goto IL_5731;
							case 659:
								goto IL_574a;
							case 660:
								goto IL_5763;
							case 661:
								goto IL_577c;
							case 662:
								goto IL_5795;
							case 663:
								goto IL_57ae;
							case 664:
								goto IL_57c7;
							case 665:
								goto IL_57e0;
							case 666:
								goto IL_57f9;
							case 667:
								goto IL_5812;
							case 668:
								goto IL_582a;
							case 669:
								goto IL_5842;
							case 670:
								goto IL_585a;
							case 671:
								goto IL_5878;
							case 672:
								goto IL_5896;
							case 673:
								goto IL_58af;
							case 674:
								goto IL_58e2;
							case 675:
								goto IL_58fb;
							case 676:
								goto IL_5913;
							case 677:
								goto IL_592b;
							case 678:
								goto IL_5944;
							case 679:
								goto IL_595b;
							case 680:
							case 681:
							case 682:
								goto IL_5971;
							case 683:
								goto IL_59a7;
							case 684:
								goto IL_5a1e;
							case 685:
								goto IL_5a2f;
							case 686:
								goto IL_5aa6;
							case 687:
							case 688:
								goto IL_5ab9;
							case 689:
								goto IL_5b30;
							case 690:
								goto IL_5b41;
							case 691:
								goto IL_5b5d;
							case 692:
								goto IL_5bd4;
							case 693:
								goto IL_5be5;
							case 694:
								goto IL_5c01;
							case 695:
								goto IL_5c78;
							case 696:
								goto IL_5c89;
							case 697:
								goto IL_5ca5;
							case 698:
								goto IL_5d1c;
							case 699:
								goto IL_5d2d;
							case 700:
								goto IL_5d49;
							case 701:
								goto IL_5dc0;
							case 702:
								goto IL_5dd1;
							case 703:
								goto IL_5ded;
							case 704:
								goto IL_5e0a;
							case 705:
								goto IL_5e2c;
							case 706:
								goto IL_5e4f;
							case 707:
								goto IL_5ec6;
							case 708:
								goto IL_5edc;
							case 709:
								goto IL_5ee8;
							case 710:
								goto IL_5ef5;
							case 711:
								goto IL_5f1a;
							case 712:
								goto IL_5f79;
							case 713:
								goto IL_5f9a;
							case 714:
								goto IL_5fe1;
							case 715:
							case 716:
								goto IL_6015;
							case 717:
								goto IL_602a;
							case 718:
								goto IL_6046;
							case 719:
								goto IL_6068;
							case 720:
								goto IL_6216;
							case 721:
								goto IL_6227;
							case 722:
							case 723:
								goto IL_6236;
							case 724:
								goto IL_6254;
							case 725:
							case 726:
							case 727:
								goto IL_6269;
							case 728:
								goto IL_6289;
							case 729:
								goto IL_6296;
							case 731:
							case 732:
								goto IL_62aa;
							case 733:
								goto IL_62bb;
							case 734:
								goto IL_62ce;
							case 735:
								goto IL_62ed;
							case 737:
							case 738:
							case 739:
								goto IL_6303;
							case 740:
								goto IL_631a;
							case 741:
								goto IL_6356;
							case 742:
								goto IL_6367;
							case 743:
								goto IL_6378;
							case 744:
								goto IL_6389;
							case 745:
								goto IL_639a;
							case 746:
								goto IL_63ab;
							case 747:
								goto IL_63bc;
							case 748:
								goto IL_63c9;
							case 749:
								goto IL_63e1;
							case 750:
								goto IL_63f2;
							case 751:
								goto IL_6406;
							case 752:
								goto IL_641a;
							case 753:
								goto IL_642e;
							case 754:
								goto IL_6442;
							case 755:
								goto IL_6456;
							case 756:
								goto IL_646a;
							case 757:
								goto IL_647f;
							case 758:
								goto IL_6494;
							case 759:
								goto IL_64a9;
							case 760:
								goto IL_64be;
							case 761:
								goto end_IL_0001_2;
							case 763:
								num2 = 763;
								((Control)BtnSave).Enabled = true;
								goto case 764;
							case 764:
								num2 = 764;
								EntryMode = "E";
								goto case 765;
							case 765:
								num2 = 765;
								Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
								goto end_IL_0001_3;
							default:
								goto end_IL_0001;
							case 3:
							case 8:
							case 14:
							case 21:
							case 28:
							case 33:
							case 38:
							case 43:
							case 52:
							case 57:
							case 63:
							case 69:
							case 80:
							case 93:
							case 730:
							case 736:
							case 762:
							case 766:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_2340:
						num2 = 305;
						RsDetl.Clear();
						goto IL_2355;
						IL_2355:
						val = null;
						goto IL_2358;
						IL_2329:
						num2 = 304;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						goto IL_2340;
						IL_2358:
						num2 = 308;
						DC_Main.i++;
						goto IL_236a;
						IL_0032:
						num2 = 2;
						Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0048:
						num2 = 5;
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							goto IL_007d;
						}
						goto IL_00a1;
						IL_007d:
						num2 = 6;
						Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
						goto IL_008c;
						IL_008c:
						num2 = 7;
						((Control)tEmpCode).Focus();
						goto end_IL_0001_3;
						IL_00a1:
						num2 = 10;
						DC_Main.DefaulterAc(tAcCode.Text);
						goto IL_00b5;
						IL_00b5:
						num2 = 11;
						if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[8, 4]) > 0.0))
						{
							goto IL_00ef;
						}
						goto IL_0113;
						IL_00ef:
						num2 = 12;
						Interaction.MsgBox((object)"You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...", (MsgBoxStyle)0, (object)null);
						goto IL_00ff;
						IL_00ff:
						num2 = 13;
						DC_Main.MsDefaulterAc = "N";
						goto end_IL_0001_3;
						IL_0113:
						num2 = 16;
						if (DC_Main.MsCashLimit > 0.0)
						{
							goto IL_012f;
						}
						goto IL_021b;
						IL_012f:
						num2 = 17;
						if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
						{
							goto IL_0154;
						}
						goto IL_021b;
						IL_0154:
						num2 = 18;
						DC_Main.LedrCash(tAcCode.Text, DC_Main.MCo_Book, tVchNo.Text);
						goto IL_0178;
						IL_0178:
						num2 = 19;
						if (Conversion.Val(MSG2_TOTAL[6, 4]) + DC_Main.AcCash > DC_Main.MsCashLimit)
						{
							goto IL_01a0;
						}
						goto IL_021b;
						IL_01a0:
						num2 = 20;
						Interaction.MsgBox((object)("Cash Recieved Limit Amount = " + Conversions.ToString(DC_Main.MsCashLimit) + " \r\nOld Ledr Value Is " + Conversions.ToString(DC_Main.AcCash) + " \r\nAnd Total Cash Amount Is " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 4]) + DC_Main.AcCash) + " You Can Not Receive More Then Cash Limit ..."), (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_021b:
						num2 = 25;
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							goto IL_0251;
						}
						goto IL_0277;
						IL_0251:
						num2 = 26;
						Interaction.MsgBox((object)"Please Select Employee Code and Try....", (MsgBoxStyle)0, (object)null);
						goto IL_0261;
						IL_0261:
						num2 = 27;
						((Control)tEmpCode).Focus();
						goto end_IL_0001_3;
						IL_0277:
						num2 = 30;
						if ((Conversion.Val(MSG2_TOTAL[4, 3]) + Conversion.Val(MSG2_TOTAL[4, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[4, 5], "", false) == 0))
						{
							goto IL_02cf;
						}
						goto IL_02f6;
						IL_02cf:
						num2 = 31;
						Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
						goto IL_02df;
						IL_02df:
						num2 = 32;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_02f6:
						num2 = 35;
						if ((Conversion.Val(MSG2_TOTAL[5, 3]) + Conversion.Val(MSG2_TOTAL[5, 4]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[5, 5], "", false) == 0))
						{
							goto IL_034e;
						}
						goto IL_0375;
						IL_034e:
						num2 = 36;
						Interaction.MsgBox((object)"Please Select Card Bank Account And Try Because Card Amt <> 0......", (MsgBoxStyle)0, (object)null);
						goto IL_035e;
						IL_035e:
						num2 = 37;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_0375:
						num2 = 40;
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							goto IL_03a6;
						}
						goto IL_03cd;
						IL_03a6:
						num2 = 41;
						Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
						goto IL_03b6;
						IL_03b6:
						num2 = 42;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_03cd:
						num2 = 45;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_03ea;
						}
						goto IL_040e;
						IL_03ea:
						num2 = 46;
						mTime.Text = DateTime.Now.ToString("HH:mm:ss");
						goto IL_040e;
						IL_040e:
						num2 = 48;
						((Control)BtnSave).Enabled = false;
						goto IL_041e;
						IL_041e:
						num2 = 49;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							goto IL_046c;
						}
						goto IL_0497;
						IL_046c:
						num2 = 50;
						Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						goto IL_0480;
						IL_0480:
						num2 = 51;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_0497:
						num2 = 54;
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							goto IL_04c0;
						}
						goto IL_04fb;
						IL_04c0:
						num2 = 55;
						Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
						goto IL_04e4;
						IL_04e4:
						num2 = 56;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_04fb:
						num2 = 59;
						if (Operators.CompareString(UsUPdate, "Y", false) != 0)
						{
							goto IL_0518;
						}
						goto IL_0573;
						IL_0518:
						num2 = 60;
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							goto IL_054a;
						}
						goto IL_0573;
						IL_054a:
						num2 = 61;
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto IL_055a;
						IL_055a:
						num2 = 62;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_0573:
						num2 = 66;
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							goto IL_0595;
						}
						goto IL_05bc;
						IL_0595:
						num2 = 67;
						Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
						goto IL_05a5;
						IL_05a5:
						num2 = 68;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_05bc:
						num2 = 71;
						if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)
						{
							goto IL_05db;
						}
						goto IL_06cc;
						IL_05db:
						num2 = 72;
						num5 = MSG_PR.Rows - 1;
						DC_Main.M = 1;
						goto IL_06be;
						IL_06be:
						if (DC_Main.M <= num5)
						{
							goto IL_05f8;
						}
						goto IL_06cc;
						IL_05f8:
						num2 = 73;
						if ((Operators.CompareString(MSG_PR[DC_Main.M, 4], "", false) == 0) & (Operators.CompareString(MSG_PR[DC_Main.M, 1], "", false) != 0))
						{
							goto IL_0640;
						}
						goto IL_06af;
						IL_0640:
						num2 = 74;
						Interaction.MsgBox((object)"Please Insert Tag Entry Counter Code and Try Because It is Mandatory...", (MsgBoxStyle)0, (object)null);
						goto IL_0650;
						IL_0650:
						num2 = 75;
						((Control)BtnSave).Enabled = true;
						goto IL_0660;
						IL_0660:
						num2 = 76;
						MSG_PR.Row = DC_Main.M;
						goto IL_0674;
						IL_0674:
						num2 = 77;
						MSG_PR.Col = 4;
						goto IL_0684;
						IL_0684:
						num2 = 78;
						MSG_PR_EnterCell(MSG_PR, new EventArgs());
						goto IL_0699;
						IL_0699:
						num2 = 79;
						((Control)TEXT_PR).Focus();
						goto end_IL_0001_3;
						IL_06af:
						num2 = 82;
						DC_Main.M++;
						goto IL_06be;
						IL_06cc:
						num2 = 84;
						MSG_TOT_FILL();
						goto IL_06d6;
						IL_06d6:
						num2 = 85;
						MSG_PR_TOT_FILL();
						goto IL_06e0;
						IL_06e0:
						num2 = 86;
						num6 = 0.0;
						goto IL_06ed;
						IL_06ed:
						num2 = 87;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0)
						{
							goto IL_0709;
						}
						goto IL_0722;
						IL_0709:
						num2 = 88;
						num6 = Conversion.Val(MSG_PR_TOT[0, 18]);
						goto IL_0722;
						IL_0722:
						num2 = 90;
						if (Conversion.Val(nAcCrAmt.Text) + Conversion.Val(nAcDrAmt.Text) + num6 == 0.0)
						{
							goto IL_0759;
						}
						goto IL_0780;
						IL_0759:
						num2 = 91;
						Interaction.MsgBox((object)"Please Insert Item Value and try", (MsgBoxStyle)0, (object)null);
						goto IL_0769;
						IL_0769:
						num2 = 92;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_0780:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_0789;
						IL_0789:
						num2 = 96;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_07a9;
						}
						goto IL_0adc;
						IL_07a9:
						num2 = 97;
						DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_081d;
						IL_081d:
						num2 = 98;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_082f;
						IL_082f:
						num2 = 99;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_084d;
						}
						goto IL_0980;
						IL_084d:
						num2 = 100;
						DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
						goto IL_08a9;
						IL_08a9:
						num2 = 101;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_08bb;
						IL_08bb:
						num2 = 102;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_08d9;
						}
						goto IL_0980;
						IL_08d9:
						num2 = 103;
						Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
						goto IL_0930;
						IL_0930:
						num2 = 104;
						tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
						goto IL_0980;
						IL_0980:
						num2 = 107;
						DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_09e2;
						IL_09e2:
						num2 = 108;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_09f4;
						IL_09f4:
						num2 = 109;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0a12;
						}
						goto IL_0adc;
						IL_0a12:
						num2 = 110;
						DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
						goto IL_0a5d;
						IL_0a5d:
						num2 = 111;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0a6f;
						IL_0a6f:
						num2 = 112;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0a8a;
						}
						goto IL_0adc;
						IL_0a8a:
						num2 = 113;
						tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
						goto IL_0adc;
						IL_0adc:
						num2 = 117;
						DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_0b51;
						IL_0b51:
						num2 = 118;
						DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_0bc6;
						IL_0bc6:
						num2 = 119;
						DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_0c3b;
						IL_0c3b:
						num2 = 120;
						if (Conversion.Val(nAcDrAmt.Text) + Conversion.Val(nAcCrAmt.Text) + num6 != 0.0)
						{
							goto IL_0c78;
						}
						goto IL_19bc;
						IL_0c78:
						num2 = 121;
						DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
						goto IL_0cdb;
						IL_0cdb:
						num2 = 122;
						DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_0d3d;
						IL_0d3d:
						num2 = 123;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0d4c;
						IL_0d4c:
						num2 = 124;
						DC_Main.MsInsertData();
						goto IL_0d55;
						IL_0d55:
						num2 = 125;
						dataRow = dataTable.NewRow();
						goto IL_0d61;
						IL_0d61:
						num2 = 126;
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						goto IL_0d76;
						IL_0d76:
						num2 = 127;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						goto IL_0d8b;
						IL_0d8b:
						num2 = 128;
						dataRow["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_0da3;
						IL_0da3:
						num2 = 129;
						dataRow["VCH_NO"] = tHdVchNo.Text;
						goto IL_0dc1;
						IL_0dc1:
						num2 = 130;
						dataRow["BOOK_NAME"] = FormName;
						goto IL_0dda;
						IL_0dda:
						num2 = 131;
						dataTable.Rows.Add(dataRow);
						goto IL_0def;
						IL_0def:
						num2 = 132;
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
						goto IL_0e02;
						IL_0e02:
						num2 = 133;
						dataTable.Clear();
						goto IL_0e10;
						IL_0e10:
						num2 = 134;
						DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_0e87;
						IL_0e87:
						num2 = 135;
						RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0e9d;
						IL_0e9d:
						num2 = 136;
						DC_Main.MsInsertData();
						goto IL_0ea9;
						IL_0ea9:
						num2 = 137;
						dataRow2 = RsData.NewRow();
						goto IL_0ebc;
						IL_0ebc:
						num2 = 138;
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						goto IL_0ed4;
						IL_0ed4:
						num2 = 139;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						goto IL_0eec;
						IL_0eec:
						num2 = 140;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_0f04;
						IL_0f04:
						num2 = 141;
						dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_0f1c;
						IL_0f1c:
						num2 = 142;
						dataRow2["VCH_NO"] = tVchNo.Text;
						goto IL_0f3a;
						IL_0f3a:
						num2 = 143;
						dataRow2["AC_CODE"] = tAcCode.Text;
						goto IL_0f58;
						IL_0f58:
						num2 = 144;
						dataRow2["VCH_DATE"] = mVchDate.Text;
						goto IL_0f76;
						IL_0f76:
						num2 = 145;
						dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_0f94;
						IL_0f94:
						num2 = 146;
						dataRow2["AC_CODE"] = tAcCode.Text;
						goto IL_0fb2;
						IL_0fb2:
						num2 = 147;
						dataRow2["AC_NAME"] = tAcName.Text;
						goto IL_0fd0;
						IL_0fd0:
						num2 = 148;
						dataRow2["NET_AMT"] = Conversion.Val(nAcDrAmt.Text);
						goto IL_0ff8;
						IL_0ff8:
						num2 = 149;
						dataRow2["DISC_PRC"] = 0;
						goto IL_1011;
						IL_1011:
						num2 = 150;
						dataRow2["DISC_AMT"] = 0;
						goto IL_102a;
						IL_102a:
						num2 = 151;
						dataRow2["ROF_AMT"] = 0;
						goto IL_1043;
						IL_1043:
						num2 = 152;
						dataRow2["ADV_AMT"] = 0;
						goto IL_105c;
						IL_105c:
						num2 = 153;
						dataRow2["CRNT_ADJ_AMT"] = 0;
						goto IL_1075;
						IL_1075:
						num2 = 154;
						dataRow2["OLD_GL_AMT"] = 0;
						goto IL_108e;
						IL_108e:
						num2 = 155;
						dataRow2["OLD_SL_AMT"] = 0;
						goto IL_10a7;
						IL_10a7:
						num2 = 156;
						dataRow2["SCHM_AMT"] = 0;
						goto IL_10c0;
						IL_10c0:
						num2 = 157;
						dataRow2["OLD_GL"] = 0;
						goto IL_10d9;
						IL_10d9:
						num2 = 158;
						dataRow2["OLD_SL"] = 0;
						goto IL_10f2;
						IL_10f2:
						num2 = 159;
						dataRow2["AC_GST_TYPE"] = AcGstType;
						goto IL_110b;
						IL_110b:
						num2 = 160;
						dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 21]);
						goto IL_1136;
						IL_1136:
						num2 = 161;
						dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 22]);
						goto IL_1161;
						IL_1161:
						num2 = 162;
						dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);
						goto IL_118b;
						IL_118b:
						num2 = 163;
						dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 4]);
						goto IL_11b5;
						IL_11b5:
						num2 = 164;
						dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[5, 4]);
						goto IL_11df;
						IL_11df:
						num2 = 165;
						dataRow2["CARD_COM_AMT"] = 0;
						goto IL_11f8;
						IL_11f8:
						num2 = 166;
						dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 4]);
						goto IL_1222;
						IL_1222:
						num2 = 167;
						dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[7, 4]);
						goto IL_124c;
						IL_124c:
						num2 = 168;
						dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[8, 4]);
						goto IL_1276;
						IL_1276:
						num2 = 169;
						dataRow2["RTN_NET_AMT"] = Conversion.Val(nAcCrAmt.Text);
						goto IL_129e;
						IL_129e:
						num2 = 170;
						dataRow2["TAX_CODE"] = Conversion.Val(MSG2_TOTAL[2, 5]);
						goto IL_12c8;
						IL_12c8:
						num2 = 171;
						dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
						goto IL_12f2;
						IL_12f2:
						num2 = 172;
						dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
						goto IL_131c;
						IL_131c:
						num2 = 173;
						if (Conversion.Val(MSG2_TOTAL[2, 3]) != 0.0)
						{
							goto IL_134b;
						}
						goto IL_1454;
						IL_134b:
						num2 = 174;
						if (Operators.CompareString(AcGstType, "I", false) == 0)
						{
							goto IL_136b;
						}
						goto IL_13ce;
						IL_136b:
						num2 = 175;
						dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);
						goto IL_1395;
						IL_1395:
						num2 = 176;
						dataRow2["SGST_TAX"] = 0;
						goto IL_13ae;
						IL_13ae:
						num2 = 177;
						dataRow2["CGST_TAX"] = 0;
						goto IL_14a0;
						IL_13ce:
						num2 = 179;
						dataRow2["IGST_TAX"] = 0;
						goto IL_13e7;
						IL_13e7:
						num2 = 180;
						dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
						goto IL_141b;
						IL_141b:
						num2 = 181;
						dataRow2["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]) / 2.0;
						goto IL_14a0;
						IL_1454:
						num2 = 184;
						dataRow2["IGST_TAX"] = 0;
						goto IL_146d;
						IL_146d:
						num2 = 185;
						dataRow2["SGST_TAX"] = 0;
						goto IL_1486;
						IL_1486:
						num2 = 186;
						dataRow2["CGST_TAX"] = 0;
						goto IL_14a0;
						IL_14a0:
						num2 = 188;
						dataRow2["HM_AMT"] = 0;
						goto IL_14b9;
						IL_14b9:
						num2 = 189;
						dataRow2["HM_TAX_CODE"] = "";
						goto IL_14d1;
						IL_14d1:
						num2 = 190;
						dataRow2["HM_TAX_PRC"] = 0;
						goto IL_14ea;
						IL_14ea:
						num2 = 191;
						dataRow2["HM_TAX_AMT"] = 0;
						goto IL_1503;
						IL_1503:
						num2 = 192;
						dataRow2["RTN_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
						goto IL_152d;
						IL_152d:
						num2 = 193;
						dataRow2["RTN_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
						goto IL_1557;
						IL_1557:
						num2 = 194;
						dataRow2["RTN_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
						goto IL_1581;
						IL_1581:
						num2 = 195;
						dataRow2["RTN_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
						goto IL_15ab;
						IL_15ab:
						num2 = 196;
						dataRow2["RTN_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
						goto IL_15d5;
						IL_15d5:
						num2 = 197;
						dataRow2["RTN_BILL_OS"] = Conversion.Val(MSG2_TOTAL[8, 3]);
						goto IL_15ff;
						IL_15ff:
						num2 = 198;
						dataRow2["CARD_AC"] = MSG2_TOTAL[5, 5];
						goto IL_161f;
						IL_161f:
						num2 = 199;
						dataRow2["BANK_AC"] = MSG2_TOTAL[4, 5];
						goto IL_163f;
						IL_163f:
						num2 = 200;
						dataRow2["CHQ_NO"] = MSG2_TOTAL[4, 2];
						goto IL_165f;
						IL_165f:
						num2 = 201;
						dataRow2["ISU_NO"] = tIsuNo.Text;
						goto IL_167d;
						IL_167d:
						num2 = 202;
						dataRow2["ISU_LC_CODE"] = DC_Main.MLc_code;
						goto IL_1695;
						IL_1695:
						num2 = 203;
						dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
						goto IL_16b3;
						IL_16b3:
						num2 = 204;
						dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
						goto IL_16d1;
						IL_16d1:
						num2 = 205;
						dataRow2["BILL_NO"] = "";
						goto IL_16e9;
						IL_16e9:
						num2 = 206;
						dataRow2["CARD_ADJ"] = "N";
						goto IL_1701;
						IL_1701:
						num2 = 207;
						dataRow2["ADD1"] = "";
						goto IL_1719;
						IL_1719:
						num2 = 208;
						dataRow2["ADD2"] = "";
						goto IL_1731;
						IL_1731:
						num2 = 209;
						dataRow2["ADD3"] = "";
						goto IL_1749;
						IL_1749:
						num2 = 210;
						dataRow2["CITY"] = "";
						goto IL_1761;
						IL_1761:
						num2 = 211;
						dataRow2["MOBILE"] = "";
						goto IL_1779;
						IL_1779:
						num2 = 212;
						dataRow2["BANK_NAME"] = "";
						goto IL_1791;
						IL_1791:
						num2 = 213;
						dataRow2["SCHM_AC"] = "";
						goto IL_17a9;
						IL_17a9:
						num2 = 214;
						dataRow2["EMP_CODE"] = tEmpCode.Text;
						goto IL_17c7;
						IL_17c7:
						num2 = 215;
						dataRow2["VCH_DESC"] = tVchDesc.Text;
						goto IL_17e5;
						IL_17e5:
						num2 = 216;
						dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_1818;
						IL_1818:
						num2 = 217;
						dataRow2["DATA_TRFR"] = "N";
						goto IL_1830;
						IL_1830:
						num2 = 218;
						if (Operators.CompareString(DataTrfr, "Y", false) == 0)
						{
							goto IL_1850;
						}
						goto IL_186b;
						IL_1850:
						num2 = 219;
						dataRow2["RE_TRFR"] = "Y";
						goto IL_1883;
						IL_186b:
						num2 = 221;
						dataRow2["RE_TRFR"] = "N";
						goto IL_1883;
						IL_1883:
						num2 = 222;
						dataRow2["MAIN_USER"] = MainUser;
						goto IL_189c;
						IL_189c:
						num2 = 223;
						dataRow2["USER_UPDATE"] = "N";
						goto IL_18b4;
						IL_18b4:
						num2 = 224;
						dataRow2["USER_DELETE"] = "N";
						goto IL_18cc;
						IL_18cc:
						num2 = 225;
						dataRow2["MOB_ENTRY_SAVE"] = "Y";
						goto IL_18e4;
						IL_18e4:
						num2 = 226;
						dataRow2["RATE_UNFIX"] = "N";
						goto IL_18fc;
						IL_18fc:
						num2 = 227;
						dataRow2["OZ_RATE"] = 0;
						goto IL_1915;
						IL_1915:
						num2 = 228;
						dataRow2["OZ_CONV"] = 0;
						goto IL_192e;
						IL_192e:
						num2 = 229;
						dataRow2["FX_RATE"] = 0;
						goto IL_1947;
						IL_1947:
						num2 = 230;
						dataRow2["FX_CODE"] = "";
						goto IL_195f;
						IL_195f:
						num2 = 231;
						dataRow2["MTL_RATE"] = 0;
						goto IL_1978;
						IL_1978:
						num2 = 232;
						RsData.Rows.Add(dataRow2);
						goto IL_1991;
						IL_1991:
						num2 = 233;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
						goto IL_19a8;
						IL_19a8:
						num2 = 234;
						RsData.Clear();
						goto IL_19bc;
						IL_19bc:
						num2 = 236;
						DC_Main.RsQry = "SELECT * FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_1a33;
						IL_1a33:
						num2 = 237;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1a49;
						IL_1a49:
						num2 = 238;
						DC_Main.MsInsertData();
						goto IL_1a55;
						IL_1a55:
						num2 = 239;
						dataRow3 = RsDetl.NewRow();
						goto IL_1a68;
						IL_1a68:
						num2 = 240;
						num7 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_236a;
						IL_236a:
						if (DC_Main.i <= num7)
						{
							goto IL_1a89;
						}
						goto IL_2376;
						IL_2376:
						num2 = 309;
						DC_Main.RsQry = "SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_23ed;
						IL_23ed:
						num2 = 310;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2403;
						IL_2403:
						num2 = 311;
						DC_Main.MsInsertData();
						goto IL_240f;
						IL_240f:
						num2 = 312;
						dataRow4 = RsIdtl.NewRow();
						goto IL_2422;
						IL_2422:
						num2 = 313;
						num8 = DtIdtl.Rows.Count - 1;
						num9 = 0;
						goto IL_2bc4;
						IL_2bc4:
						if (num9 <= num8)
						{
							goto IL_2445;
						}
						goto IL_2bcd;
						IL_2bcd:
						num2 = 359;
						DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_2c45;
						IL_2c45:
						num2 = 360;
						DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_2cbd;
						IL_2cbd:
						num2 = 361;
						DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_2d35;
						IL_2d35:
						num2 = 362;
						DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_2dad;
						IL_2dad:
						num2 = 363;
						DC_Main.RsQry = "SELECT * FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_2e12;
						IL_2e12:
						num2 = 364;
						RsPrDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2e28;
						IL_2e28:
						num2 = 365;
						DC_Main.MsInsertData();
						goto IL_2e34;
						IL_2e34:
						num2 = 366;
						dataRow5 = RsPrDetl.NewRow();
						goto IL_2e47;
						IL_2e47:
						num2 = 367;
						num10 = MSG_PR.Rows - 1;
						DC_Main.i = 1;
						goto IL_3b71;
						IL_3b71:
						if (DC_Main.i <= num10)
						{
							goto IL_2e68;
						}
						goto IL_3b7d;
						IL_3b7d:
						num2 = 462;
						DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_3bf4;
						IL_3bf4:
						num2 = 463;
						RsBarData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_3c0a;
						IL_3c0a:
						num2 = 464;
						DC_Main.MsInsertData();
						goto IL_3c16;
						IL_3c16:
						num2 = 465;
						dataRow6 = RsBarData.NewRow();
						goto IL_3c29;
						IL_3c29:
						num2 = 466;
						if ((Conversion.Val(MSG_PR_TOT[0, 28]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 27]) != 0.0))
						{
							goto IL_3ca3;
						}
						goto IL_3e3b;
						IL_3ca3:
						num2 = 467;
						dataRow6["CO_CODE"] = DC_Main.MCo_code;
						goto IL_3cbb;
						IL_3cbb:
						num2 = 468;
						dataRow6["LC_CODE"] = DC_Main.MLc_code;
						goto IL_3cd3;
						IL_3cd3:
						num2 = 469;
						dataRow6["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_3ceb;
						IL_3ceb:
						num2 = 470;
						dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_3d03;
						IL_3d03:
						num2 = 471;
						dataRow6["VCH_NO"] = tVchNo.Text;
						goto IL_3d21;
						IL_3d21:
						num2 = 472;
						dataRow6["VCH_DATE"] = mVchDate.Text;
						goto IL_3d3f;
						IL_3d3f:
						num2 = 473;
						dataRow6["STK_IT_CODE"] = "";
						goto IL_3d57;
						IL_3d57:
						num2 = 474;
						dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_3d8a;
						IL_3d8a:
						num2 = 475;
						dataRow6["EMP_CODE"] = tEmpCode.Text;
						goto IL_3da8;
						IL_3da8:
						num2 = 476;
						dataRow6["VCH_DESC"] = tVchDesc.Text;
						goto IL_3dc6;
						IL_3dc6:
						num2 = 477;
						dataRow6["DATA_TRFR"] = "N";
						goto IL_3dde;
						IL_3dde:
						num2 = 478;
						dataRow6["MAIN_USER"] = MainUser;
						goto IL_3df7;
						IL_3df7:
						num2 = 479;
						RsBarData.Rows.Add(dataRow6);
						goto IL_3e10;
						IL_3e10:
						num2 = 480;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBarData);
						goto IL_3e27;
						IL_3e27:
						num2 = 481;
						RsBarData.Clear();
						goto IL_3e3b;
						IL_3e3b:
						num2 = 483;
						DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_3ea0;
						IL_3ea0:
						num2 = 484;
						RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_3eb6;
						IL_3eb6:
						num2 = 485;
						DC_Main.MsInsertData();
						goto IL_3ec2;
						IL_3ec2:
						num2 = 486;
						dataRow7 = RsBarDetl.NewRow();
						goto IL_3ed5;
						IL_3ed5:
						num2 = 487;
						num11 = MSG_PR.Rows - 1;
						DC_Main.i = 1;
						goto IL_4b57;
						IL_4b57:
						if (DC_Main.i <= num11)
						{
							goto IL_3ef6;
						}
						goto IL_4b63;
						IL_4b63:
						num2 = 580;
						DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_4bda;
						IL_4bda:
						num2 = 581;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_4bf0;
						IL_4bf0:
						num2 = 582;
						DC_Main.MsInsertData();
						goto IL_4bfc;
						IL_4bfc:
						num2 = 583;
						dataRow8 = RsIdtl.NewRow();
						goto IL_4c0f;
						IL_4c0f:
						num2 = 584;
						num12 = RtnIdtl.Rows.Count - 1;
						num13 = 0;
						goto IL_53c7;
						IL_53c7:
						if (num13 <= num12)
						{
							goto IL_4c32;
						}
						goto IL_53d0;
						IL_53d0:
						num2 = 635;
						if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
						{
							goto IL_53f8;
						}
						goto IL_5971;
						IL_53f8:
						num2 = 636;
						DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
						goto IL_5470;
						IL_5470:
						num2 = 637;
						DC_Main.RsQry = "SELECT * FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_54d5;
						IL_54d5:
						num2 = 638;
						RsBillOs = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_54eb;
						IL_54eb:
						num2 = 639;
						DC_Main.MsInsertData();
						goto IL_54f7;
						IL_54f7:
						num2 = 640;
						dataRow9 = RsBillOs.NewRow();
						goto IL_550a;
						IL_550a:
						num2 = 641;
						if (Conversion.Val(MSG2_TOTAL[3, 4]) != 0.0)
						{
							goto IL_5539;
						}
						goto IL_5971;
						IL_5539:
						num2 = 642;
						dataRow9["CO_CODE"] = DC_Main.MCo_code;
						goto IL_5551;
						IL_5551:
						num2 = 643;
						dataRow9["LC_CODE"] = DC_Main.MLc_code;
						goto IL_5569;
						IL_5569:
						num2 = 644;
						dataRow9["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_5581;
						IL_5581:
						num2 = 645;
						dataRow9["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_5599;
						IL_5599:
						num2 = 646;
						dataRow9["VCH_NO"] = tVchNo.Text;
						goto IL_55b7;
						IL_55b7:
						num2 = 647;
						dataRow9["SR_NO"] = 1;
						goto IL_55d0;
						IL_55d0:
						num2 = 648;
						dataRow9["VCH_DATE"] = mVchDate.Text;
						goto IL_55ee;
						IL_55ee:
						num2 = 649;
						dataRow9["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_560c;
						IL_560c:
						num2 = 650;
						dataRow9["AC_CODE"] = tAcCode.Text;
						goto IL_562a;
						IL_562a:
						num2 = 651;
						dataRow9["VCH_TYPE"] = FormBookSname;
						goto IL_5643;
						IL_5643:
						num2 = 652;
						dataRow9["INOUT_TYPE"] = FormBookInOut;
						goto IL_565c;
						IL_565c:
						num2 = 653;
						dataRow9["ENTRY_TYPE"] = "O";
						goto IL_5674;
						IL_5674:
						num2 = 654;
						dataRow9["BOOK_NAME"] = FormMainBook;
						goto IL_568d;
						IL_568d:
						num2 = 655;
						dataRow9["BILL_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]);
						goto IL_56b7;
						IL_56b7:
						num2 = 656;
						dataRow9["REC_AMT"] = Conversion.Val(MSG2_TOTAL[3, 4]) - (Conversion.Val(MSG2_TOTAL[8, 4]) + Conversion.Val(MSG2_TOTAL[7, 4]));
						goto IL_5707;
						IL_5707:
						num2 = 657;
						dataRow9["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[7, 4]);
						goto IL_5731;
						IL_5731:
						num2 = 658;
						dataRow9["BILL_GOLD"] = 0;
						goto IL_574a;
						IL_574a:
						num2 = 659;
						dataRow9["REC_GOLD"] = 0;
						goto IL_5763;
						IL_5763:
						num2 = 660;
						dataRow9["KASAR_GOLD"] = 0;
						goto IL_577c;
						IL_577c:
						num2 = 661;
						dataRow9["BILL_SILVER"] = 0;
						goto IL_5795;
						IL_5795:
						num2 = 662;
						dataRow9["REC_SILVER"] = 0;
						goto IL_57ae;
						IL_57ae:
						num2 = 663;
						dataRow9["KASAR_SILVER"] = 0;
						goto IL_57c7;
						IL_57c7:
						num2 = 664;
						dataRow9["OLD_ADJ_AMT"] = 0;
						goto IL_57e0;
						IL_57e0:
						num2 = 665;
						dataRow9["OLD_ADJ_GOLD"] = 0;
						goto IL_57f9;
						IL_57f9:
						num2 = 666;
						dataRow9["OLD_ADJ_SILVER"] = 0;
						goto IL_5812;
						IL_5812:
						num2 = 667;
						dataRow9["BILL_LC"] = DC_Main.MLc_code;
						goto IL_582a;
						IL_582a:
						num2 = 668;
						dataRow9["BILL_YRCD"] = DC_Main.MCo_year;
						goto IL_5842;
						IL_5842:
						num2 = 669;
						dataRow9["BILL_DBCD"] = DC_Main.MCo_Book;
						goto IL_585a;
						IL_585a:
						num2 = 670;
						dataRow9["BILL_NO"] = tVchNo.Text;
						goto IL_5878;
						IL_5878:
						num2 = 671;
						dataRow9["BILL_HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_5896;
						IL_5896:
						num2 = 672;
						dataRow9["BILL_SRNO"] = 1;
						goto IL_58af;
						IL_58af:
						num2 = 673;
						dataRow9["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_58e2;
						IL_58e2:
						num2 = 674;
						dataRow9["MAIN_USER"] = MainUser;
						goto IL_58fb;
						IL_58fb:
						num2 = 675;
						dataRow9["DATA_TRFR"] = "N";
						goto IL_5913;
						IL_5913:
						num2 = 676;
						dataRow9["DATA_TYPE"] = "A";
						goto IL_592b;
						IL_592b:
						num2 = 677;
						RsBillOs.Rows.Add(dataRow9);
						goto IL_5944;
						IL_5944:
						num2 = 678;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBillOs);
						goto IL_595b;
						IL_595b:
						num2 = 679;
						RsBillOs.Clear();
						goto IL_5971;
						IL_5971:
						num2 = 682;
						if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
						{
							goto IL_59a7;
						}
						goto IL_5ab9;
						IL_59a7:
						num2 = 683;
						DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.DATA_TYPE = C.DATA_TYPE FROM SL_DETL,BAR_DETL AS B,BOOK_DATA AS C WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = C.CO_CODE AND SL_DETL.LC_CODE = C.LC_CODE AND SL_DETL.CO_BOOK = C.CO_BOOK AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' AND SL_DETL.TAG_NO <> 'N' ";
						goto IL_5a1e;
						IL_5a1e:
						num2 = 684;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5a2f;
						IL_5a2f:
						num2 = 685;
						DC_Main.RsQry = "UPDATE MAIN_STOCK SET MAIN_STOCK.DATA_TYPE = C.DATA_TYPE FROM SL_DETL,MAIN_STOCK AS B,BOOK_DATA AS C WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = C.CO_CODE AND SL_DETL.LC_CODE = C.LC_CODE AND SL_DETL.CO_BOOK = C.CO_BOOK AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' AND SL_DETL.TAG_NO <> 'N' ";
						goto IL_5aa6;
						IL_5aa6:
						num2 = 686;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5ab9;
						IL_5ab9:
						num2 = 688;
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_5b30;
						IL_5b30:
						num2 = 689;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5b41;
						IL_5b41:
						num2 = 690;
						Ac_Ledr.SaleReturn_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_5b5d;
						IL_5b5d:
						num2 = 691;
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_5bd4;
						IL_5bd4:
						num2 = 692;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5be5;
						IL_5be5:
						num2 = 693;
						Ac_Rojmel.SaleReturn_RojMel(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_5c01;
						IL_5c01:
						num2 = 694;
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_5c78;
						IL_5c78:
						num2 = 695;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5c89;
						IL_5c89:
						num2 = 696;
						Ac_Stock.SaleReturn_Stk(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_5ca5;
						IL_5ca5:
						num2 = 697;
						DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_5d1c;
						IL_5d1c:
						num2 = 698;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5d2d;
						IL_5d2d:
						num2 = 699;
						Ac_Tax.Sales_Rtn_GST(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_5d49;
						IL_5d49:
						num2 = 700;
						DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_5dc0;
						IL_5dc0:
						num2 = 701;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_5dd1;
						IL_5dd1:
						num2 = 702;
						Ac_Stock.Dm_Sale_Return_Detl(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_5ded;
						IL_5ded:
						num2 = 703;
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						goto IL_5e0a;
						IL_5e0a:
						num2 = 704;
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
						{
							goto IL_5e2c;
						}
						goto IL_6269;
						IL_5e2c:
						num2 = 705;
						if (Operators.CompareString(EntryMode, "E", false) == 0)
						{
							goto IL_5e4f;
						}
						goto IL_6269;
						IL_5e4f:
						num2 = 706;
						DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_5ec6;
						IL_5ec6:
						num2 = 707;
						RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_5edc;
						IL_5edc:
						num2 = 708;
						DC_Main.TableCol();
						goto IL_5ee8;
						IL_5ee8:
						num2 = 709;
						text = "";
						goto IL_5ef5;
						IL_5ef5:
						num2 = 710;
						num14 = RsData.Columns.Count - 2;
						DC_Main.M = 0;
						goto IL_6248;
						IL_6248:
						if (DC_Main.M <= num14)
						{
							goto IL_5f1a;
						}
						goto IL_6254;
						IL_6254:
						num2 = 724;
						DC_Main.RsTblCol.Clear();
						goto IL_6269;
						IL_5f1a:
						num2 = 711;
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
						{
							goto IL_5f79;
						}
						goto IL_6236;
						IL_5f79:
						num2 = 712;
						num15 = DC_Main.RsTblCol.Rows.Count - 1;
						num16 = 0;
						goto IL_6021;
						IL_6021:
						if (num16 <= num15)
						{
							goto IL_5f9a;
						}
						goto IL_602a;
						IL_602a:
						num2 = 717;
						if (Operators.CompareString(text, "", false) == 0)
						{
							goto IL_6046;
						}
						goto IL_6068;
						IL_6046:
						num2 = 718;
						text = RsData.Columns[DC_Main.M].ColumnName;
						goto IL_6068;
						IL_6068:
						num2 = 719;
						DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text + "','" + Strings.Mid(Conversions.ToString(VchOldData.Rows[0][DC_Main.M]), 1, 50) + "','" + Strings.Mid(Conversions.ToString(RsData.Rows[0][DC_Main.M]), 1, 50) + "','N')";
						goto IL_6216;
						IL_6216:
						num2 = 720;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_6227;
						IL_6227:
						num2 = 721;
						text = "";
						goto IL_6236;
						IL_5f9a:
						num2 = 713;
						if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[num16]["TBL_COL_NAME"], false))
						{
							goto IL_5fe1;
						}
						goto IL_6015;
						IL_5fe1:
						num2 = 714;
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[num16]["COL_NAME"], (object)""));
						goto IL_6015;
						IL_6015:
						num2 = 716;
						num16++;
						goto IL_6021;
						IL_6236:
						num2 = 723;
						DC_Main.M++;
						goto IL_6248;
						IL_6269:
						num2 = 727;
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							goto IL_6289;
						}
						goto IL_62aa;
						IL_6289:
						num2 = 728;
						CLEAR_DATA();
						goto IL_6296;
						IL_6296:
						num2 = 729;
						((Form)this).Close();
						goto end_IL_0001_3;
						IL_62aa:
						num2 = 732;
						if (DC_Main.MsOpenSlRtn)
						{
							goto IL_62bb;
						}
						goto IL_6303;
						IL_62bb:
						num2 = 733;
						((Control)BtnSave).Enabled = true;
						goto IL_62ce;
						IL_62ce:
						num2 = 734;
						if (unchecked((int)Interaction.MsgBox((object)"Sales Return Print... ?", (MsgBoxStyle)260, (object)null)) == 7)
						{
							goto IL_62ed;
						}
						goto IL_6303;
						IL_62ed:
						num2 = 735;
						((Form)this).Close();
						goto end_IL_0001_3;
						IL_6303:
						num2 = 739;
						CurPrnVch = tVchNo.Text;
						goto IL_631a;
						IL_631a:
						num2 = 740;
						DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						goto IL_6356;
						IL_6356:
						num2 = 741;
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						goto IL_6367;
						IL_6367:
						num2 = 742;
						CustClAmt = DC_Main.MsAcAmtClBal;
						goto IL_6378;
						IL_6378:
						num2 = 743;
						CustOpGold = DC_Main.MsAcGoldOpBal;
						goto IL_6389;
						IL_6389:
						num2 = 744;
						CustClGold = DC_Main.MsAcGoldClBal;
						goto IL_639a;
						IL_639a:
						num2 = 745;
						CustOpSilver = DC_Main.MsAcSilverOpBal;
						goto IL_63ab;
						IL_63ab:
						num2 = 746;
						CustClSilver = DC_Main.MsAcSilverClBal;
						goto IL_63bc;
						IL_63bc:
						num2 = 747;
						CLEAR_DATA();
						goto IL_63c9;
						IL_63c9:
						num2 = 748;
						BtnPrint_Click(BtnPrint, new EventArgs());
						goto IL_63e1;
						IL_63e1:
						num2 = 749;
						CurPrnVch = "";
						goto IL_63f2;
						IL_63f2:
						num2 = 750;
						DC_Main.MsAcAmtOpBal = 0.0;
						goto IL_6406;
						IL_6406:
						num2 = 751;
						DC_Main.MsAcAmtClBal = 0.0;
						goto IL_641a;
						IL_641a:
						num2 = 752;
						DC_Main.MsAcGoldOpBal = 0.0;
						goto IL_642e;
						IL_642e:
						num2 = 753;
						DC_Main.MsAcGoldClBal = 0.0;
						goto IL_6442;
						IL_6442:
						num2 = 754;
						DC_Main.MsAcSilverOpBal = 0.0;
						goto IL_6456;
						IL_6456:
						num2 = 755;
						DC_Main.MsAcSilverClBal = 0.0;
						goto IL_646a;
						IL_646a:
						num2 = 756;
						CustOpAmt = 0.0;
						goto IL_647f;
						IL_647f:
						num2 = 757;
						CustClAmt = 0.0;
						goto IL_6494;
						IL_6494:
						num2 = 758;
						CustOpGold = 0.0;
						goto IL_64a9;
						IL_64a9:
						num2 = 759;
						CustClGold = 0.0;
						goto IL_64be;
						IL_64be:
						num2 = 760;
						CustOpSilver = 0.0;
						break;
						IL_4c32:
						num2 = 585;
						rtnIdtl = RtnIdtl;
						goto IL_4c40;
						IL_4c40:
						num2 = 586;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][19])) != 0.0)
						{
							goto IL_4cc8;
						}
						goto IL_53b8;
						IL_4cc8:
						num2 = 587;
						num17 = MSG_PR.Rows - 1;
						DC_Main.M = 1;
						goto IL_4d50;
						IL_4d50:
						if (DC_Main.M <= num17)
						{
							goto IL_4ce5;
						}
						goto IL_4d59;
						IL_4ce5:
						num2 = 588;
						if (Conversion.Val(MSG_PR[DC_Main.M, 51]) == Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][23])))
						{
							goto IL_4d2d;
						}
						goto IL_4d3e;
						IL_4d2d:
						num2 = 589;
						m = DC_Main.M;
						goto IL_4d59;
						IL_4d59:
						num2 = 593;
						dataRow8["CO_CODE"] = DC_Main.MCo_code;
						goto IL_4d71;
						IL_4d71:
						num2 = 594;
						dataRow8["LC_CODE"] = DC_Main.MLc_code;
						goto IL_4d89;
						IL_4d89:
						num2 = 595;
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_4da1;
						IL_4da1:
						num2 = 596;
						dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_4db9;
						IL_4db9:
						num2 = 597;
						dataRow8["VCH_NO"] = tVchNo.Text;
						goto IL_4dd7;
						IL_4dd7:
						num2 = 598;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						goto IL_4df5;
						IL_4df5:
						num2 = 599;
						dataRow8["AC_CODE"] = tAcCode.Text;
						goto IL_4e13;
						IL_4e13:
						num2 = 600;
						dataRow8["VCH_TYPE"] = FormBookSname;
						goto IL_4e2c;
						IL_4e2c:
						num2 = 601;
						dataRow8["INOUT_TYPE"] = FormBookInOut;
						goto IL_4e45;
						IL_4e45:
						num2 = 602;
						dataRow8["ENTRY_TYPE"] = "S";
						goto IL_4e5d;
						IL_4e5d:
						num2 = 603;
						dataRow8["BOOK_NAME"] = FormMainBook;
						goto IL_4e76;
						IL_4e76:
						num2 = 604;
						dataRow8["SR_NO"] = Conversion.Val(MSG_PR[m, 51]);
						goto IL_4ea2;
						IL_4ea2:
						num2 = 605;
						dataRow8["TAG_NO"] = MSG_PR[m, 2];
						goto IL_4ec3;
						IL_4ec3:
						num2 = 606;
						dataRow8["VCH_SRNO"] = Conversion.Val(MSG_PR[m, 40]);
						goto IL_4eef;
						IL_4eef:
						num2 = 607;
						dataRow8["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][0]));
						goto IL_4f29;
						IL_4f29:
						num2 = 608;
						dataRow8["IT_CODE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][1]);
						goto IL_4f59;
						IL_4f59:
						num2 = 609;
						dataRow8["DM_CODE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][3]);
						goto IL_4f89;
						IL_4f89:
						num2 = 610;
						dataRow8["DM_NAME"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][4]);
						goto IL_4fb9;
						IL_4fb9:
						num2 = 611;
						dataRow8["DM_COLOR"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][5]);
						goto IL_4fe9;
						IL_4fe9:
						num2 = 612;
						dataRow8["DM_SIZE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][6]);
						goto IL_5019;
						IL_5019:
						num2 = 613;
						dataRow8["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][7]);
						goto IL_5049;
						IL_5049:
						num2 = 614;
						dataRow8["DM_REMARK"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][8]);
						goto IL_5079;
						IL_5079:
						num2 = 615;
						dataRow8["DM_SFNO"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][9]);
						goto IL_50aa;
						IL_50aa:
						num2 = 616;
						dataRow8["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][10]));
						goto IL_50e5;
						IL_50e5:
						num2 = 617;
						dataRow8["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][12]));
						goto IL_5120;
						IL_5120:
						num2 = 618;
						dataRow8["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][11]));
						goto IL_515b;
						IL_515b:
						num2 = 619;
						dataRow8["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][13]));
						goto IL_5196;
						IL_5196:
						num2 = 620;
						dataRow8["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][14]);
						goto IL_51c7;
						IL_51c7:
						num2 = 621;
						dataRow8["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][15]));
						goto IL_5202;
						IL_5202:
						num2 = 622;
						dataRow8["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][16]));
						goto IL_523d;
						IL_523d:
						num2 = 623;
						dataRow8["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][17]));
						goto IL_5278;
						IL_5278:
						num2 = 624;
						dataRow8["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][18]));
						goto IL_52b3;
						IL_52b3:
						num2 = 625;
						dataRow8["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][19]));
						goto IL_52ee;
						IL_52ee:
						num2 = 626;
						dataRow8["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][20]));
						goto IL_5329;
						IL_5329:
						num2 = 627;
						dataRow8["IT_TYPE"] = RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[num13][22]);
						goto IL_535a;
						IL_535a:
						num2 = 628;
						dataRow8["MAIN_USER"] = MainUser;
						goto IL_5373;
						IL_5373:
						num2 = 629;
						RsIdtl.Rows.Add(dataRow8);
						goto IL_538c;
						IL_538c:
						num2 = 630;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						goto IL_53a3;
						IL_53a3:
						num2 = 631;
						RsIdtl.Clear();
						goto IL_53b8;
						IL_4d3e:
						num2 = 592;
						DC_Main.M++;
						goto IL_4d50;
						IL_53b8:
						rtnIdtl = null;
						goto IL_53bb;
						IL_53bb:
						num2 = 634;
						num13++;
						goto IL_53c7;
						IL_3ef6:
						num2 = 488;
						val2 = MSG_PR;
						goto IL_3f04;
						IL_3f04:
						num2 = 489;
						if ((Conversion.Val(MSG_PR[DC_Main.i, 9]) + Conversion.Val(MSG_PR[DC_Main.i, 12]) + Conversion.Val(MSG_PR[DC_Main.i, 38]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 2], "", false) != 0))
						{
							goto IL_3f88;
						}
						goto IL_4b42;
						IL_3f88:
						num2 = 490;
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						goto IL_3fa0;
						IL_3fa0:
						num2 = 491;
						dataRow7["LC_CODE"] = DC_Main.MLc_code;
						goto IL_3fb8;
						IL_3fb8:
						num2 = 492;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_3fd0;
						IL_3fd0:
						num2 = 493;
						dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_3fe8;
						IL_3fe8:
						num2 = 494;
						dataRow7["VCH_NO"] = tVchNo.Text;
						goto IL_4006;
						IL_4006:
						num2 = 495;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						goto IL_4024;
						IL_4024:
						num2 = 496;
						dataRow7["STK_DATE"] = mVchDate.Text;
						goto IL_4042;
						IL_4042:
						num2 = 497;
						dataRow7["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_4060;
						IL_4060:
						num2 = 498;
						dataRow7["AC_CODE"] = tAcCode.Text;
						goto IL_407e;
						IL_407e:
						num2 = 499;
						dataRow7["VCH_TYPE"] = FormBookSname;
						goto IL_4097;
						IL_4097:
						num2 = 500;
						dataRow7["INOUT_TYPE"] = FormBookInOut;
						goto IL_40b0;
						IL_40b0:
						num2 = 501;
						dataRow7["ENTRY_TYPE"] = "P";
						goto IL_40c8;
						IL_40c8:
						num2 = 502;
						dataRow7["BOOK_NAME"] = FormMainBook;
						goto IL_40e1;
						IL_40e1:
						num2 = 503;
						dataRow7["SR_NO"] = Conversion.Val(val2[DC_Main.i, 0]);
						goto IL_410b;
						IL_410b:
						num2 = 504;
						dataRow7["OLD_SRNO"] = Conversion.Val(val2[DC_Main.i, 51]);
						goto IL_4136;
						IL_4136:
						num2 = 505;
						dataRow7["IT_CODE"] = val2[DC_Main.i, 1];
						goto IL_4156;
						IL_4156:
						num2 = 506;
						if (Operators.CompareString(val2[DC_Main.i, 2], "", false) == 0)
						{
							goto IL_417d;
						}
						goto IL_4199;
						IL_417d:
						num2 = 507;
						dataRow7["TAG_NO"] = "N";
						goto IL_41ba;
						IL_4199:
						num2 = 509;
						dataRow7["TAG_NO"] = val2[DC_Main.i, 2];
						goto IL_41ba;
						IL_41ba:
						num2 = 511;
						dataRow7["TBL_CODE"] = val2[DC_Main.i, 4];
						goto IL_41da;
						IL_41da:
						num2 = 512;
						dataRow7["DESIGN_NO"] = val2[DC_Main.i, 5];
						goto IL_41fa;
						IL_41fa:
						num2 = 513;
						dataRow7["ITM_STYLE"] = val2[DC_Main.i, 6];
						goto IL_421a;
						IL_421a:
						num2 = 514;
						dataRow7["ITM_SIZE"] = val2[DC_Main.i, 7];
						goto IL_423a;
						IL_423a:
						num2 = 515;
						dataRow7["HM_ID"] = val2[DC_Main.i, 8];
						goto IL_425a;
						IL_425a:
						num2 = 516;
						dataRow7["ITM_PCS"] = Conversion.Val(val2[DC_Main.i, 9]);
						goto IL_4285;
						IL_4285:
						num2 = 517;
						dataRow7["ITM_GWT"] = Conversion.Val(val2[DC_Main.i, 10]);
						goto IL_42b0;
						IL_42b0:
						num2 = 518;
						dataRow7["ITM_OTH_WT"] = Conversion.Val(val2[DC_Main.i, 11]);
						goto IL_42db;
						IL_42db:
						num2 = 519;
						dataRow7["ITM_NWT"] = Conversion.Val(val2[DC_Main.i, 12]);
						goto IL_4306;
						IL_4306:
						num2 = 520;
						dataRow7["ITM_GHT_PRC"] = Conversion.Val(val2[DC_Main.i, 14]);
						goto IL_4331;
						IL_4331:
						num2 = 521;
						dataRow7["ITM_GHT_WT"] = Conversion.Val(val2[DC_Main.i, 15]);
						goto IL_435c;
						IL_435c:
						num2 = 522;
						dataRow7["ITM_TOUCH"] = Conversion.Val(val2[DC_Main.i, 16]);
						goto IL_4387;
						IL_4387:
						num2 = 523;
						dataRow7["ITM_WEST_PRC"] = Conversion.Val(val2[DC_Main.i, 17]);
						goto IL_43b2;
						IL_43b2:
						num2 = 524;
						dataRow7["ITM_FINE"] = Conversion.Val(val2[DC_Main.i, 18]);
						goto IL_43dd;
						IL_43dd:
						num2 = 525;
						dataRow7["KR_GHT_WT"] = Conversion.Val(val2[DC_Main.i, 15]);
						goto IL_4408;
						IL_4408:
						num2 = 526;
						dataRow7["KR_TOUCH"] = Conversion.Val(val2[DC_Main.i, 16]);
						goto IL_4433;
						IL_4433:
						num2 = 527;
						dataRow7["KR_WEST_PRC"] = Conversion.Val(val2[DC_Main.i, 17]);
						goto IL_445e;
						IL_445e:
						num2 = 528;
						dataRow7["KR_FINE"] = Conversion.Val(val2[DC_Main.i, 18]);
						goto IL_4489;
						IL_4489:
						num2 = 529;
						dataRow7["ITM_RATE"] = 0;
						goto IL_44a2;
						IL_44a2:
						num2 = 530;
						dataRow7["ITM_AMT"] = 0;
						goto IL_44bb;
						IL_44bb:
						num2 = 531;
						dataRow7["LBR_TYPE"] = val2[DC_Main.i, 22];
						goto IL_44dc;
						IL_44dc:
						num2 = 532;
						dataRow7["LBR_CODE"] = val2[DC_Main.i, 29];
						goto IL_44fd;
						IL_44fd:
						num2 = 533;
						dataRow7["LBR_PRC"] = Conversion.Val(val2[DC_Main.i, 30]);
						goto IL_4528;
						IL_4528:
						num2 = 534;
						dataRow7["LBR_RATE"] = Conversion.Val(val2[DC_Main.i, 31]);
						goto IL_4553;
						IL_4553:
						num2 = 535;
						dataRow7["LBR_AMT"] = Conversion.Val(val2[DC_Main.i, 32]);
						goto IL_457e;
						IL_457e:
						num2 = 536;
						dataRow7["OTH_AMT"] = Conversion.Val(val2[DC_Main.i, 33]);
						goto IL_45a9;
						IL_45a9:
						num2 = 537;
						dataRow7["KR_COST"] = Conversion.Val(val2[DC_Main.i, 34]);
						goto IL_45d4;
						IL_45d4:
						num2 = 538;
						dataRow7["TAG_COST"] = Conversion.Val(val2[DC_Main.i, 34]);
						goto IL_45ff;
						IL_45ff:
						num2 = 539;
						dataRow7["ITM_MRP"] = Conversion.Val(val2[DC_Main.i, 35]);
						goto IL_462a;
						IL_462a:
						num2 = 540;
						dataRow7["KR_NAME"] = val2[DC_Main.i, 39];
						goto IL_464b;
						IL_464b:
						num2 = 541;
						dataRow7["RATE_TYPE"] = val2[DC_Main.i, 44];
						goto IL_466c;
						IL_466c:
						num2 = 542;
						dataRow7["IT_TYPE"] = val2[DC_Main.i, 43];
						goto IL_468d;
						IL_468d:
						num2 = 543;
						dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_46c0;
						IL_46c0:
						num2 = 544;
						dataRow7["PR_CODE"] = val2[DC_Main.i, 52];
						goto IL_46e1;
						IL_46e1:
						num2 = 545;
						dataRow7["TAG_TYPE"] = val2[DC_Main.i, 54];
						goto IL_4702;
						IL_4702:
						num2 = 546;
						dataRow7["KR_LBR_RATE"] = 0;
						goto IL_471b;
						IL_471b:
						num2 = 547;
						dataRow7["KR_LBR_AMT"] = 0;
						goto IL_4734;
						IL_4734:
						num2 = 548;
						dataRow7["KR_OTH_AMT"] = 0;
						goto IL_474d;
						IL_474d:
						num2 = 549;
						dataRow7["TAG_SRNO"] = 0;
						goto IL_4766;
						IL_4766:
						num2 = 550;
						if (Conversion.Val(val2[DC_Main.i, 40]) == 0.0)
						{
							goto IL_4793;
						}
						goto IL_489d;
						IL_4793:
						num2 = 551;
						val2[DC_Main.i, 40] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm") + Conversions.ToString(Conversion.Val(val2[DC_Main.i, 51]));
						goto IL_486e;
						IL_486e:
						num2 = 552;
						dataRow7["VCH_SRNO"] = Conversion.Val(val2[DC_Main.i, 40]);
						goto IL_48c9;
						IL_489d:
						num2 = 554;
						dataRow7["VCH_SRNO"] = Conversion.Val(val2[DC_Main.i, 40]);
						goto IL_48c9;
						IL_48c9:
						num2 = 556;
						dataRow7["TAG_SRNO"] = Conversion.Val(val2[DC_Main.i, 56]);
						goto IL_48f4;
						IL_48f4:
						num2 = 557;
						dataRow7["APR_ISU"] = val2[DC_Main.i, 50];
						goto IL_4915;
						IL_4915:
						num2 = 558;
						dataRow7["EMP_ISU"] = val2[DC_Main.i, 68];
						goto IL_4936;
						IL_4936:
						num2 = 559;
						dataRow7["DESIGN_IMG_ID"] = val2[DC_Main.i, 69];
						goto IL_4957;
						IL_4957:
						num2 = 560;
						dataRow7["HM_ID2"] = val2[DC_Main.i, 59];
						goto IL_4978;
						IL_4978:
						num2 = 561;
						dataRow7["HM_ID3"] = val2[DC_Main.i, 60];
						goto IL_4999;
						IL_4999:
						num2 = 562;
						dataRow7["HM_ID4"] = val2[DC_Main.i, 61];
						goto IL_49ba;
						IL_49ba:
						num2 = 563;
						dataRow7["HM_ID_WT"] = Conversion.Val(val2[DC_Main.i, 62]);
						goto IL_49e5;
						IL_49e5:
						num2 = 564;
						dataRow7["HM_ID2_WT"] = Conversion.Val(val2[DC_Main.i, 63]);
						goto IL_4a10;
						IL_4a10:
						num2 = 565;
						dataRow7["HM_ID3_WT"] = Conversion.Val(val2[DC_Main.i, 64]);
						goto IL_4a3b;
						IL_4a3b:
						num2 = 566;
						dataRow7["HM_ID4_WT"] = Conversion.Val(val2[DC_Main.i, 65]);
						goto IL_4a66;
						IL_4a66:
						num2 = 567;
						if (Operators.CompareString(val2[DC_Main.i, 70], "", false) == 0)
						{
							goto IL_4a8e;
						}
						goto IL_4aaa;
						IL_4a8e:
						num2 = 568;
						dataRow7["DATA_TYPE"] = "A";
						goto IL_4acc;
						IL_4aaa:
						num2 = 570;
						dataRow7["DATA_TYPE"] = val2[DC_Main.i, 70];
						goto IL_4acc;
						IL_4acc:
						num2 = 572;
						dataRow7["DATA_TRFR"] = "N";
						goto IL_4ae4;
						IL_4ae4:
						num2 = 573;
						dataRow7["MAIN_USER"] = MainUser;
						goto IL_4afd;
						IL_4afd:
						num2 = 574;
						RsBarDetl.Rows.Add(dataRow7);
						goto IL_4b16;
						IL_4b16:
						num2 = 575;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
						goto IL_4b2d;
						IL_4b2d:
						num2 = 576;
						RsBarDetl.Clear();
						goto IL_4b42;
						IL_4b42:
						val2 = null;
						goto IL_4b45;
						IL_4b45:
						num2 = 579;
						DC_Main.i++;
						goto IL_4b57;
						IL_2e68:
						num2 = 368;
						val3 = MSG_PR;
						goto IL_2e76;
						IL_2e76:
						num2 = 369;
						if ((Conversion.Val(MSG_PR[DC_Main.i, 12]) + Conversion.Val(MSG_PR[DC_Main.i, 38]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
						{
							goto IL_2ee2;
						}
						goto IL_3b5c;
						IL_2ee2:
						num2 = 370;
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						goto IL_2efa;
						IL_2efa:
						num2 = 371;
						dataRow5["LC_CODE"] = DC_Main.MLc_code;
						goto IL_2f12;
						IL_2f12:
						num2 = 372;
						dataRow5["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_2f2a;
						IL_2f2a:
						num2 = 373;
						dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_2f42;
						IL_2f42:
						num2 = 374;
						dataRow5["VCH_NO"] = tVchNo.Text;
						goto IL_2f60;
						IL_2f60:
						num2 = 375;
						dataRow5["VCH_DATE"] = mVchDate.Text;
						goto IL_2f7e;
						IL_2f7e:
						num2 = 376;
						dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_2f9c;
						IL_2f9c:
						num2 = 377;
						dataRow5["AC_CODE"] = tAcCode.Text;
						goto IL_2fba;
						IL_2fba:
						num2 = 378;
						dataRow5["VCH_TYPE"] = FormBookSname;
						goto IL_2fd3;
						IL_2fd3:
						num2 = 379;
						dataRow5["INOUT_TYPE"] = FormBookInOut;
						goto IL_2fec;
						IL_2fec:
						num2 = 380;
						dataRow5["ENTRY_TYPE"] = "P";
						goto IL_3004;
						IL_3004:
						num2 = 381;
						dataRow5["BOOK_NAME"] = FormMainBook;
						goto IL_301d;
						IL_301d:
						num2 = 382;
						dataRow5["SR_NO"] = Conversion.Val(val3[DC_Main.i, 0]);
						goto IL_3047;
						IL_3047:
						num2 = 383;
						dataRow5["OLD_SRNO"] = Conversion.Val(val3[DC_Main.i, 51]);
						goto IL_3072;
						IL_3072:
						num2 = 384;
						dataRow5["IT_CODE"] = val3[DC_Main.i, 1];
						goto IL_3092;
						IL_3092:
						num2 = 385;
						dataRow5["ITM_REMARK"] = val3[DC_Main.i, 3];
						goto IL_30b2;
						IL_30b2:
						num2 = 386;
						if (Operators.CompareString(val3[DC_Main.i, 2], "", false) == 0)
						{
							goto IL_30d9;
						}
						goto IL_30f5;
						IL_30d9:
						num2 = 387;
						dataRow5["TAG_NO"] = "N";
						goto IL_3116;
						IL_30f5:
						num2 = 389;
						dataRow5["TAG_NO"] = val3[DC_Main.i, 2];
						goto IL_3116;
						IL_3116:
						num2 = 391;
						dataRow5["TBL_CODE"] = val3[DC_Main.i, 4];
						goto IL_3136;
						IL_3136:
						num2 = 392;
						dataRow5["DESIGN_NO"] = val3[DC_Main.i, 5];
						goto IL_3156;
						IL_3156:
						num2 = 393;
						dataRow5["ITM_STYLE"] = val3[DC_Main.i, 6];
						goto IL_3176;
						IL_3176:
						num2 = 394;
						dataRow5["ITM_SIZE"] = val3[DC_Main.i, 7];
						goto IL_3196;
						IL_3196:
						num2 = 395;
						dataRow5["HM_ID"] = val3[DC_Main.i, 8];
						goto IL_31b6;
						IL_31b6:
						num2 = 396;
						dataRow5["ITM_PCS"] = Conversion.Val(val3[DC_Main.i, 9]);
						goto IL_31e1;
						IL_31e1:
						num2 = 397;
						dataRow5["ITM_GWT"] = Conversion.Val(val3[DC_Main.i, 10]);
						goto IL_320c;
						IL_320c:
						num2 = 398;
						dataRow5["ITM_OTH_WT"] = Conversion.Val(val3[DC_Main.i, 11]);
						goto IL_3237;
						IL_3237:
						num2 = 399;
						dataRow5["ITM_NWT"] = Conversion.Val(val3[DC_Main.i, 12]);
						goto IL_3262;
						IL_3262:
						num2 = 400;
						dataRow5["ITM_GHT_PRC"] = Conversion.Val(val3[DC_Main.i, 14]);
						goto IL_328d;
						IL_328d:
						num2 = 401;
						dataRow5["ITM_GHT_WT"] = Conversion.Val(val3[DC_Main.i, 15]);
						goto IL_32b8;
						IL_32b8:
						num2 = 402;
						dataRow5["ITM_TOUCH"] = Conversion.Val(val3[DC_Main.i, 16]);
						goto IL_32e3;
						IL_32e3:
						num2 = 403;
						dataRow5["ITM_WEST_PRC"] = Conversion.Val(val3[DC_Main.i, 17]);
						goto IL_330e;
						IL_330e:
						num2 = 404;
						dataRow5["ITM_FINE"] = Conversion.Val(val3[DC_Main.i, 18]);
						goto IL_3339;
						IL_3339:
						num2 = 405;
						dataRow5["ITM_RATE"] = Conversion.Val(val3[DC_Main.i, 19]);
						goto IL_3364;
						IL_3364:
						num2 = 406;
						dataRow5["ITM_AMT"] = Conversion.Val(val3[DC_Main.i, 20]);
						goto IL_338f;
						IL_338f:
						num2 = 407;
						dataRow5["LBR_CODE"] = val3[DC_Main.i, 13];
						goto IL_33b0;
						IL_33b0:
						num2 = 408;
						dataRow5["LBR_PRC"] = Conversion.Val(val3[DC_Main.i, 21]);
						goto IL_33db;
						IL_33db:
						num2 = 409;
						dataRow5["LBR_TYPE"] = val3[DC_Main.i, 22];
						goto IL_33fc;
						IL_33fc:
						num2 = 410;
						dataRow5["LBR_RATE"] = Conversion.Val(val3[DC_Main.i, 23]);
						goto IL_3427;
						IL_3427:
						num2 = 411;
						dataRow5["LBR_AMT"] = Conversion.Val(val3[DC_Main.i, 24]);
						goto IL_3452;
						IL_3452:
						num2 = 412;
						dataRow5["DISC_PRC"] = Conversion.Val(val3[DC_Main.i, 25]);
						goto IL_347d;
						IL_347d:
						num2 = 413;
						dataRow5["DISC_AMT"] = Conversion.Val(val3[DC_Main.i, 26]);
						goto IL_34a8;
						IL_34a8:
						num2 = 414;
						dataRow5["OTH_AMT"] = Conversion.Val(val3[DC_Main.i, 27]);
						goto IL_34d3;
						IL_34d3:
						num2 = 415;
						dataRow5["ITM_MRP"] = Conversion.Val(val3[DC_Main.i, 28]);
						goto IL_34fe;
						IL_34fe:
						num2 = 416;
						dataRow5["TAG_LBR_CODE"] = val3[DC_Main.i, 29];
						goto IL_351f;
						IL_351f:
						num2 = 417;
						dataRow5["TAG_LBR_PRC"] = Conversion.Val(val3[DC_Main.i, 30]);
						goto IL_354a;
						IL_354a:
						num2 = 418;
						dataRow5["TAG_LBR_RATE"] = Conversion.Val(val3[DC_Main.i, 31]);
						goto IL_3575;
						IL_3575:
						num2 = 419;
						dataRow5["TAG_LBR_AMT"] = Conversion.Val(val3[DC_Main.i, 32]);
						goto IL_35a0;
						IL_35a0:
						num2 = 420;
						dataRow5["TAG_OTH_AMT"] = Conversion.Val(val3[DC_Main.i, 33]);
						goto IL_35cb;
						IL_35cb:
						num2 = 421;
						dataRow5["TAG_COST"] = Conversion.Val(val3[DC_Main.i, 34]);
						goto IL_35f6;
						IL_35f6:
						num2 = 422;
						dataRow5["TAG_MRP"] = Conversion.Val(val3[DC_Main.i, 35]);
						goto IL_3621;
						IL_3621:
						num2 = 423;
						dataRow5["TOT_AMT"] = Conversion.Val(val3[DC_Main.i, 36]);
						goto IL_364c;
						IL_364c:
						num2 = 424;
						dataRow5["TAX_PRC"] = Conversion.Val(val3[DC_Main.i, 37]);
						goto IL_3677;
						IL_3677:
						num2 = 425;
						dataRow5["NET_AMT"] = Conversion.Val(val3[DC_Main.i, 38]);
						goto IL_36a2;
						IL_36a2:
						num2 = 426;
						dataRow5["KR_NAME"] = val3[DC_Main.i, 39];
						goto IL_36c3;
						IL_36c3:
						num2 = 427;
						if (Conversion.Val(val3[DC_Main.i, 40]) == 0.0)
						{
							goto IL_36f0;
						}
						goto IL_37fa;
						IL_36f0:
						num2 = 428;
						val3[DC_Main.i, 40] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm") + Conversions.ToString(Conversion.Val(val3[DC_Main.i, 51]));
						goto IL_37cb;
						IL_37cb:
						num2 = 429;
						dataRow5["VCH_SRNO"] = Conversion.Val(val3[DC_Main.i, 40]);
						goto IL_3826;
						IL_37fa:
						num2 = 431;
						dataRow5["VCH_SRNO"] = Conversion.Val(val3[DC_Main.i, 40]);
						goto IL_3826;
						IL_3826:
						num2 = 433;
						dataRow5["RATE_TYPE"] = val3[DC_Main.i, 44];
						goto IL_3847;
						IL_3847:
						num2 = 434;
						dataRow5["PR_CODE"] = val3[DC_Main.i, 52];
						goto IL_3868;
						IL_3868:
						num2 = 435;
						dataRow5["TAG_TYPE"] = val3[DC_Main.i, 54];
						goto IL_3889;
						IL_3889:
						num2 = 436;
						dataRow5["TAG_SRNO"] = Conversion.Val(val3[DC_Main.i, 56]);
						goto IL_38b4;
						IL_38b4:
						num2 = 437;
						dataRow5["HM_ID2"] = val3[DC_Main.i, 59];
						goto IL_38d5;
						IL_38d5:
						num2 = 438;
						dataRow5["HM_ID3"] = val3[DC_Main.i, 60];
						goto IL_38f6;
						IL_38f6:
						num2 = 439;
						dataRow5["HM_ID4"] = val3[DC_Main.i, 61];
						goto IL_3917;
						IL_3917:
						num2 = 440;
						dataRow5["HM_ID_WT"] = Conversion.Val(val3[DC_Main.i, 62]);
						goto IL_3942;
						IL_3942:
						num2 = 441;
						dataRow5["HM_ID2_WT"] = Conversion.Val(val3[DC_Main.i, 63]);
						goto IL_396d;
						IL_396d:
						num2 = 442;
						dataRow5["HM_ID3_WT"] = Conversion.Val(val3[DC_Main.i, 64]);
						goto IL_3998;
						IL_3998:
						num2 = 443;
						dataRow5["HM_ID4_WT"] = Conversion.Val(val3[DC_Main.i, 65]);
						goto IL_39c3;
						IL_39c3:
						num2 = 444;
						dataRow5["APR_ISU"] = val3[DC_Main.i, 50];
						goto IL_39e4;
						IL_39e4:
						num2 = 445;
						dataRow5["EMP_ISU"] = val3[DC_Main.i, 68];
						goto IL_3a05;
						IL_3a05:
						num2 = 446;
						dataRow5["IT_TYPE"] = val3[DC_Main.i, 43];
						goto IL_3a26;
						IL_3a26:
						num2 = 447;
						dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_3a59;
						IL_3a59:
						num2 = 448;
						dataRow5["MAIN_USER"] = MainUser;
						goto IL_3a72;
						IL_3a72:
						num2 = 449;
						dataRow5["EMP_CODE"] = tEmpCode.Text;
						goto IL_3a90;
						IL_3a90:
						num2 = 450;
						dataRow5["DESIGN_IMG_ID"] = val3[DC_Main.i, 69];
						goto IL_3ab1;
						IL_3ab1:
						num2 = 451;
						if (Operators.CompareString(val3[DC_Main.i, 70], "", false) == 0)
						{
							goto IL_3ad9;
						}
						goto IL_3af5;
						IL_3ad9:
						num2 = 452;
						dataRow5["DATA_TYPE"] = "A";
						goto IL_3b17;
						IL_3af5:
						num2 = 454;
						dataRow5["DATA_TYPE"] = val3[DC_Main.i, 70];
						goto IL_3b17;
						IL_3b17:
						num2 = 456;
						RsPrDetl.Rows.Add(dataRow5);
						goto IL_3b30;
						IL_3b30:
						num2 = 457;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsPrDetl);
						goto IL_3b47;
						IL_3b47:
						num2 = 458;
						RsPrDetl.Clear();
						goto IL_3b5c;
						IL_3b5c:
						val3 = null;
						goto IL_3b5f;
						IL_3b5f:
						num2 = 461;
						DC_Main.i++;
						goto IL_3b71;
						IL_2445:
						num2 = 314;
						dtIdtl = DtIdtl;
						goto IL_2453;
						IL_2453:
						num2 = 315;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][19])) != 0.0)
						{
							goto IL_24db;
						}
						goto IL_2bb5;
						IL_24db:
						num2 = 316;
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						goto IL_24f3;
						IL_24f3:
						num2 = 317;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						goto IL_250b;
						IL_250b:
						num2 = 318;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_2523;
						IL_2523:
						num2 = 319;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_253b;
						IL_253b:
						num2 = 320;
						dataRow4["VCH_NO"] = tVchNo.Text;
						goto IL_2559;
						IL_2559:
						num2 = 321;
						dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_2577;
						IL_2577:
						num2 = 322;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						goto IL_2595;
						IL_2595:
						num2 = 323;
						dataRow4["AC_CODE"] = tAcCode.Text;
						goto IL_25b3;
						IL_25b3:
						num2 = 324;
						dataRow4["VCH_TYPE"] = FormBookSname;
						goto IL_25cc;
						IL_25cc:
						num2 = 325;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						goto IL_25e5;
						IL_25e5:
						num2 = 326;
						dataRow4["ENTRY_TYPE"] = "S";
						goto IL_25fd;
						IL_25fd:
						num2 = 327;
						dataRow4["BOOK_NAME"] = FormMainBook;
						goto IL_2616;
						IL_2616:
						num2 = 328;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][23]));
						goto IL_2651;
						IL_2651:
						num2 = 329;
						dataRow4["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][23]))), 1];
						goto IL_2699;
						IL_2699:
						num2 = 330;
						dataRow4["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][23]))), 29]);
						goto IL_26ec;
						IL_26ec:
						num2 = 331;
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][0]));
						goto IL_2726;
						IL_2726:
						num2 = 332;
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][1]);
						goto IL_2756;
						IL_2756:
						num2 = 333;
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][3]);
						goto IL_2786;
						IL_2786:
						num2 = 334;
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][4]);
						goto IL_27b6;
						IL_27b6:
						num2 = 335;
						dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][5]);
						goto IL_27e6;
						IL_27e6:
						num2 = 336;
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][6]);
						goto IL_2816;
						IL_2816:
						num2 = 337;
						dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][7]);
						goto IL_2846;
						IL_2846:
						num2 = 338;
						dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][8]);
						goto IL_2876;
						IL_2876:
						num2 = 339;
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][9]);
						goto IL_28a7;
						IL_28a7:
						num2 = 340;
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][10]));
						goto IL_28e2;
						IL_28e2:
						num2 = 341;
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][12]));
						goto IL_291d;
						IL_291d:
						num2 = 342;
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][11]));
						goto IL_2958;
						IL_2958:
						num2 = 343;
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][13]));
						goto IL_2993;
						IL_2993:
						num2 = 344;
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][14]);
						goto IL_29c4;
						IL_29c4:
						num2 = 345;
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][15]));
						goto IL_29ff;
						IL_29ff:
						num2 = 346;
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][16]));
						goto IL_2a3a;
						IL_2a3a:
						num2 = 347;
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][17]));
						goto IL_2a75;
						IL_2a75:
						num2 = 348;
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][18]));
						goto IL_2ab0;
						IL_2ab0:
						num2 = 349;
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][19]));
						goto IL_2aeb;
						IL_2aeb:
						num2 = 350;
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][20]));
						goto IL_2b26;
						IL_2b26:
						num2 = 351;
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num9][22]);
						goto IL_2b57;
						IL_2b57:
						num2 = 352;
						dataRow4["MAIN_USER"] = MainUser;
						goto IL_2b70;
						IL_2b70:
						num2 = 353;
						RsIdtl.Rows.Add(dataRow4);
						goto IL_2b89;
						IL_2b89:
						num2 = 354;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						goto IL_2ba0;
						IL_2ba0:
						num2 = 355;
						RsIdtl.Clear();
						goto IL_2bb5;
						IL_2bb5:
						dtIdtl = null;
						goto IL_2bb8;
						IL_2bb8:
						num2 = 358;
						num9++;
						goto IL_2bc4;
						IL_1a89:
						num2 = 241;
						val = MSG;
						goto IL_1a97;
						IL_1a97:
						num2 = 242;
						if (((Operators.CompareString(val[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(val[DC_Main.i, 23]) != 0.0)) | (Conversion.Val(val[DC_Main.i, 10]) + Conversion.Val(val[DC_Main.i, 22]) != 0.0))
						{
							goto IL_1b19;
						}
						goto IL_2355;
						IL_1b19:
						num2 = 243;
						dataRow3["CO_CODE"] = DC_Main.MCo_code;
						goto IL_1b31;
						IL_1b31:
						num2 = 244;
						dataRow3["LC_CODE"] = DC_Main.MLc_code;
						goto IL_1b49;
						IL_1b49:
						num2 = 245;
						dataRow3["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_1b61;
						IL_1b61:
						num2 = 246;
						dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_1b79;
						IL_1b79:
						num2 = 247;
						dataRow3["VCH_NO"] = tVchNo.Text;
						goto IL_1b97;
						IL_1b97:
						num2 = 248;
						dataRow3["VCH_DATE"] = mVchDate.Text;
						goto IL_1bb5;
						IL_1bb5:
						num2 = 249;
						dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_1bd3;
						IL_1bd3:
						num2 = 250;
						dataRow3["AC_CODE"] = tAcCode.Text;
						goto IL_1bf1;
						IL_1bf1:
						num2 = 251;
						dataRow3["VCH_TYPE"] = FormBookSname;
						goto IL_1c0a;
						IL_1c0a:
						num2 = 252;
						dataRow3["INOUT_TYPE"] = FormBookInOut;
						goto IL_1c23;
						IL_1c23:
						num2 = 253;
						dataRow3["ENTRY_TYPE"] = "C";
						goto IL_1c3b;
						IL_1c3b:
						num2 = 254;
						dataRow3["BOOK_NAME"] = FormMainBook;
						goto IL_1c54;
						IL_1c54:
						num2 = 255;
						dataRow3["SR_NO"] = Conversion.Val(val[DC_Main.i, 0]);
						goto IL_1c7e;
						IL_1c7e:
						num2 = 256;
						dataRow3["OLD_SRNO"] = Conversion.Val(val[DC_Main.i, 25]);
						goto IL_1ca9;
						IL_1ca9:
						num2 = 257;
						dataRow3["IT_CODE"] = val[DC_Main.i, 2];
						goto IL_1cc9;
						IL_1cc9:
						num2 = 258;
						dataRow3["ITM_REMARK"] = val[DC_Main.i, 3];
						goto IL_1ce9;
						IL_1ce9:
						num2 = 259;
						if (Operators.CompareString(val[DC_Main.i, 1], "", false) == 0)
						{
							goto IL_1d10;
						}
						goto IL_1d2c;
						IL_1d10:
						num2 = 260;
						dataRow3["TAG_NO"] = "N";
						goto IL_1d4d;
						IL_1d2c:
						num2 = 262;
						dataRow3["TAG_NO"] = val[DC_Main.i, 1];
						goto IL_1d4d;
						IL_1d4d:
						num2 = 264;
						dataRow3["TBL_CODE"] = val[DC_Main.i, 27];
						goto IL_1d6e;
						IL_1d6e:
						num2 = 265;
						dataRow3["DESIGN_NO"] = val[DC_Main.i, 4];
						goto IL_1d8e;
						IL_1d8e:
						num2 = 266;
						dataRow3["ITM_SIZE"] = val[DC_Main.i, 5];
						goto IL_1dae;
						IL_1dae:
						num2 = 267;
						dataRow3["HM_ID"] = val[DC_Main.i, 6];
						goto IL_1dce;
						IL_1dce:
						num2 = 268;
						dataRow3["ITM_PCS"] = Conversion.Val(val[DC_Main.i, 7]);
						goto IL_1df8;
						IL_1df8:
						num2 = 269;
						dataRow3["BAG_WT"] = 0;
						goto IL_1e11;
						IL_1e11:
						num2 = 270;
						dataRow3["ITM_GWT"] = Conversion.Val(val[DC_Main.i, 8]);
						goto IL_1e3b;
						IL_1e3b:
						num2 = 271;
						dataRow3["ITM_OTH_WT"] = Conversion.Val(val[DC_Main.i, 9]);
						goto IL_1e66;
						IL_1e66:
						num2 = 272;
						dataRow3["ITM_NWT"] = Conversion.Val(val[DC_Main.i, 10]);
						goto IL_1e91;
						IL_1e91:
						num2 = 273;
						dataRow3["ITM_GHT_WT"] = Conversion.Val(val[DC_Main.i, 12]);
						goto IL_1ebc;
						IL_1ebc:
						num2 = 274;
						dataRow3["ITM_TOUCH"] = Conversion.Val(val[DC_Main.i, 13]);
						goto IL_1ee7;
						IL_1ee7:
						num2 = 275;
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(val[DC_Main.i, 14]);
						goto IL_1f12;
						IL_1f12:
						num2 = 276;
						dataRow3["ITM_FINE"] = Conversion.Val(val[DC_Main.i, 15]);
						goto IL_1f3d;
						IL_1f3d:
						num2 = 277;
						dataRow3["RATE_TYPE"] = val[DC_Main.i, 39];
						goto IL_1f5e;
						IL_1f5e:
						num2 = 278;
						dataRow3["ITM_RATE"] = Conversion.Val(val[DC_Main.i, 16]);
						goto IL_1f89;
						IL_1f89:
						num2 = 279;
						dataRow3["ITM_AMT"] = Conversion.Val(val[DC_Main.i, 17]);
						goto IL_1fb4;
						IL_1fb4:
						num2 = 280;
						dataRow3["LBR_PRC"] = Conversion.Val(val[DC_Main.i, 18]);
						goto IL_1fdf;
						IL_1fdf:
						num2 = 281;
						dataRow3["LBR_TYPE"] = val[DC_Main.i, 19];
						goto IL_2000;
						IL_2000:
						num2 = 282;
						dataRow3["LBR_RATE"] = Conversion.Val(val[DC_Main.i, 20]);
						goto IL_202b;
						IL_202b:
						num2 = 283;
						dataRow3["LBR_AMT"] = Conversion.Val(val[DC_Main.i, 21]);
						goto IL_2056;
						IL_2056:
						num2 = 284;
						dataRow3["OTH_AMT"] = Conversion.Val(val[DC_Main.i, 22]);
						goto IL_2081;
						IL_2081:
						num2 = 285;
						dataRow3["NET_AMT"] = Conversion.Val(val[DC_Main.i, 24]);
						goto IL_20ac;
						IL_20ac:
						num2 = 286;
						dataRow3["HM_AMT"] = 0;
						goto IL_20c5;
						IL_20c5:
						num2 = 287;
						dataRow3["ITM_MRP"] = Conversion.Val(val[DC_Main.i, 23]);
						goto IL_20f0;
						IL_20f0:
						num2 = 288;
						dataRow3["TAG_COST"] = Conversion.Val(val[DC_Main.i, 38]);
						goto IL_211b;
						IL_211b:
						num2 = 289;
						dataRow3["KR_NET_WT"] = Conversion.Val(val[DC_Main.i, 34]);
						goto IL_2146;
						IL_2146:
						num2 = 290;
						dataRow3["KR_TOUCH"] = Conversion.Val(val[DC_Main.i, 35]);
						goto IL_2171;
						IL_2171:
						num2 = 291;
						dataRow3["KR_WEST_PRC"] = Conversion.Val(val[DC_Main.i, 36]);
						goto IL_219c;
						IL_219c:
						num2 = 292;
						dataRow3["KR_FINE"] = Conversion.Val(val[DC_Main.i, 37]);
						goto IL_21c7;
						IL_21c7:
						num2 = 293;
						dataRow3["KR_NAME"] = val[DC_Main.i, 28];
						goto IL_21e8;
						IL_21e8:
						num2 = 294;
						dataRow3["IT_TYPE"] = val[DC_Main.i, 30];
						goto IL_2209;
						IL_2209:
						num2 = 295;
						dataRow3["PR_CODE"] = val[DC_Main.i, 32];
						goto IL_222a;
						IL_222a:
						num2 = 296;
						dataRow3["VCH_SRNO"] = Conversion.Val(val[DC_Main.i, 29]);
						goto IL_2255;
						IL_2255:
						num2 = 297;
						dataRow3["DATA_TRFR"] = "N";
						goto IL_226d;
						IL_226d:
						num2 = 298;
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_22a0;
						IL_22a0:
						num2 = 299;
						dataRow3["MAIN_USER"] = MainUser;
						goto IL_22b9;
						IL_22b9:
						num2 = 300;
						dataRow3["EMP_CODE"] = tEmpCode.Text;
						goto IL_22d7;
						IL_22d7:
						num2 = 301;
						dataRow3["ORD_TAG_STK_ADD"] = "N";
						goto IL_22ef;
						IL_22ef:
						num2 = 302;
						dataRow3["DESIGN_IMG_ID"] = val[DC_Main.i, 47];
						goto IL_2310;
						IL_2310:
						num2 = 303;
						RsDetl.Rows.Add(dataRow3);
						goto IL_2329;
						end_IL_0001_2:
						break;
					}
					num2 = 761;
					CustClSilver = 0.0;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 28999;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bc: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,TOT_AMT,RTN_TOT_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','Sales RtnAmt' + '-' + STR(RTN_TOT_AMT) +' SalesAmt/'+ STR(TOT_AMT) FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_SRNO = '" + MSG[DC_Main.M, 29] + "' AND TAG_NO = '" + MSG[DC_Main.M, 1] + "'");
					DC_Main.M++;
				}
				DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_SALE_RTN_KeyDown(object sender, KeyEventArgs e)
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
				MSG2_TOTAL.Row = 2;
				if (Conversion.Val(MSG2_TOTAL[1, 3]) != 0.0)
				{
					MSG2_TOTAL.Col = 3;
				}
				else
				{
					MSG2_TOTAL.Col = 4;
				}
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
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM RATE_CUT_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,OLD_SRNO,'I',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE  FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "INSERT INTO RATE_CUT_ISU_REC(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ENTRY_TYPE,AC_CODE,IT_CODE,IT_DESC,TAG_NO,DESIGN_NO,  ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE) Select CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,'R',AC_CODE,IT_CODE,ITM_REMARK,TAG_NO,DESIGN_NO,  ITM_PCS,0,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,ITM_MRP,NET_AMT,RATE_TYPE,IT_TYPE  FROM SL_DETL_RTN WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnA4Gst.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnA4.RPT";
		}
		Cr.SelectionFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
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

	private void TR_SALE_RTN_Activated(object sender, EventArgs e)
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
		}
		else if (DC_Main.MsOpenSlRtn)
		{
			tAcCode.Text = DC_Main.MsSlAcCode;
			tAcName.Text = DC_Main.CustUrdName;
			DC_Main.RsQry = "SELECT VCH_NO,CO_BOOK FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MsSlDbCd + "' AND SL_BILL_NO = '" + DC_Main.MsSlBill + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_NO"], (object)""));
				DISPLAY_DATA();
				((Control)tVchNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
		else
		{
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
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.AC_CODE As AcCodeL FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 0.0;
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
		//IL_0c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c87: Expected O, but got Unknown
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_0b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b45: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 3] + " : It Name";
		MSG_IDTL_CLEAR();
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 1;
		checked
		{
			int num5 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num5; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 25]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
				{
					MSG_IDTL[num4, 0] = Conversions.ToString(num4);
					MSG_IDTL[num4, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
					MSG_IDTL[num4, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
					MSG_IDTL[num4, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
					MSG_IDTL[num4, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
					MSG_IDTL[num4, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
					MSG_IDTL[num4, 6] = Conversions.ToString(DtIdtl.Rows[i][6]);
					MSG_IDTL[num4, 7] = Conversions.ToString(DtIdtl.Rows[i][7]);
					MSG_IDTL[num4, 8] = Conversions.ToString(DtIdtl.Rows[i][8]);
					MSG_IDTL[num4, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
					MSG_IDTL[num4, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
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
				MSG[MSG.Row, 9] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 10] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 9])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 33] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 34] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 8]) - Conversion.Val(MSG[MSG.Row, 33])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 22] = Strings.Format((object)num, "0.00");
			}
			CommPassTotal();
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 47], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 47];
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
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 47] + "' AND IMAGE_TYPE = 'D'";
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
				DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 29];
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					Image image2;
					using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
					{
						image2 = Image.FromStream(stream2);
					}
					PicImage.Image = image2;
				}
				else if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 29]))) ?? "";
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
						ProjectData.ClearProjectError();
					}
				}
			}
			MSG_IDTL[num4, 0] = Conversions.ToString(num4);
			MSG_IDTL[num4, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 25]));
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
				((Control)tAcCode).Focus();
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
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_SALE_RTN_Closed(object sender, EventArgs e)
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
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			DC_Main.MsAcAmtOpBal = 0.0;
			DC_Main.MsAcAmtClBal = 0.0;
		}
		if (Operators.CompareString(tIsuNo.Text, "", false) != 0)
		{
			MSG_PR.Col = 1;
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
		else
		{
			MSG.Col = 1;
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM SL_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 9;
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
			DC_Main.i = 0;
			do
			{
				mSG2_TOTAL.Row = DC_Main.i;
				mSG2_TOTAL[DC_Main.i] = (int)Math.Round(300.0 * ColCon);
				switch (DC_Main.i)
				{
				case 1:
				case 7:
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
				case 3:
				case 4:
				case 6:
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
				case 5:
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
			while (DC_Main.i <= 8);
			mSG2_TOTAL[0, 3] = "Payment    ";
			mSG2_TOTAL[0, 4] = "Received    ";
			mSG2_TOTAL[1, 0] = "Net Amt : ";
			mSG2_TOTAL[2, 0] = "Sale Tax : ";
			mSG2_TOTAL[3, 0] = "Total Amt : ";
			mSG2_TOTAL[4, 0] = "Cheque Amt : ";
			mSG2_TOTAL[5, 0] = "Card Amt : ";
			mSG2_TOTAL[6, 0] = "Cash Amt : ";
			mSG2_TOTAL[7, 0] = "Kasar Amt : ";
			mSG2_TOTAL[8, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
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
				if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 2))
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
					if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
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
					if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 3) | (mSG2_TOTAL.Row == 8))
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
			if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
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
					if (((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 4)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 5)
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
					if (mSG2_TOTAL.Row != 2)
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
								mSG2_TOTAL.Row = 4;
								mSG2_TOTAL.Col = 4;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
							double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
							mSG2_TOTAL[mSG2_TOTAL.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 4;
							mSG2_TOTAL.Col = 4;
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
						mSG2_TOTAL.Row = 4;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 6:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
					case 5:
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
					case 7:
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
					case 6:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 4;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
					case 5:
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
					case 7:
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
		double num = 0.0;
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		nAcDrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 24]), 0), "0.00");
		nAcCrAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(MSG_PR_TOT[0, 38]), 0), "0.00");
		num = Conversion.Val(nAcCrAmt.Text) - Conversion.Val(nAcDrAmt.Text);
		if (num < 0.0)
		{
			mSG2_TOTAL[1, 4] = Strings.Format((object)Math.Abs(num), "0.00");
			mSG2_TOTAL[1, 3] = "";
		}
		else
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)num, "0.00");
			mSG2_TOTAL[1, 4] = "";
		}
		if ((Conversion.Val(mSG2_TOTAL[1, 3]) != OldNetAmt) | (Conversion.Val(mSG2_TOTAL[2, 2]) != OldTaxPrc))
		{
			OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[1, 3]), "0.00"));
			OldTaxPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[2, 2]), "0.00"));
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		mSG2_TOTAL[3, 4] = Strings.Format((object)Conversion.Val(mSG2_TOTAL[1, 4]), "0.00");
		mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0), "0.00");
		mSG2_TOTAL[8, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[7, 3])), "0.00");
		mSG2_TOTAL[8, 4] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[3, 4]) - Conversion.Val(mSG2_TOTAL[6, 4]) - Conversion.Val(mSG2_TOTAL[4, 4]) - Conversion.Val(mSG2_TOTAL[5, 4]) - Conversion.Val(mSG2_TOTAL[7, 4])), "0.00");
		if (!EditOPen)
		{
			if (num < 0.0)
			{
				mSG2_TOTAL[2, 3] = "";
				mSG2_TOTAL[3, 3] = "";
				mSG2_TOTAL[4, 3] = "";
				mSG2_TOTAL[5, 3] = "";
				mSG2_TOTAL[6, 3] = "";
				mSG2_TOTAL[7, 3] = "";
				mSG2_TOTAL[8, 3] = "";
			}
			else
			{
				mSG2_TOTAL[2, 4] = "";
				mSG2_TOTAL[3, 4] = "";
				mSG2_TOTAL[4, 4] = "";
				mSG2_TOTAL[5, 4] = "";
				mSG2_TOTAL[6, 4] = "";
				mSG2_TOTAL[7, 4] = "";
				mSG2_TOTAL[8, 4] = "";
			}
		}
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[8, 4]);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[8, 3]) - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[8, 4]));
		}
		else
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[8, 4]);
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
		mSG2_TOTAL = null;
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

	private void TEXT_ENTRY_2_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
		((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
	}

	private void TIsuNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Invalid comparison between Unknown and I4
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tIsuDbCd.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT * FROM SL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + tIsuYrCd.Text + "' AND A.ISU_DBCD = '" + tIsuDbCd.Text + "' AND A.ISU_NO = '" + tIsuNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
				Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"This Sales Bill Is All ready Import...In...", DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)" You Cant Re Ipmport...Please Select Single Item In Receive Item..."), (MsgBoxStyle)0, (object)null);
				((Control)tAcCode).Focus();
				return;
			}
		}
		DC_Main.RsQry = "SELECT B.*,A.AC_NAME,C.IT_NAME,C.GR_CODE aS RateGr,A.AC_NAME FROM (SL_DATA AS A LEFT JOIN SL_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO) LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY B.SR_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			BtnIsuNo_Click(btnIsuNo, new EventArgs());
			return;
		}
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
		if ((int)Interaction.MsgBox((object)"All Sales Tag In This Voucher Import?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.i = 0;
			MsVchSrno = "";
			AxMSFlexGrid mSG_PR = MSG_PR;
			checked
			{
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"])), "0");
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS014NSBU", false) == 0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])) != 0.0))
					{
						mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_PRC"])) > 0.0)
					{
						mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
						mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					}
					mSG_PR[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG_PR[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
					mSG_PR[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
					mSG_PR[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 50] = "N";
					mSG_PR[DC_Main.i + 1, 68] = "N";
					mSG_PR[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
					mSG_PR[DC_Main.i + 1, 70] = ItmDataType;
					mSG_PR[DC_Main.i + 1, 40] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm") + Conversions.ToString(Conversion.Val(mSG_PR[DC_Main.i + 1, 51]));
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
				RtnIdtl.Clear();
				RtnIdtl.Reset();
				RtnRow = 0;
				int num = MSG_RTN_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					RtnIdtl.Columns.Add(MSG_RTN_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					Rtndr = RtnIdtl.NewRow();
					Rtndr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					Rtndr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					Rtndr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					Rtndr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					Rtndr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					Rtndr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					Rtndr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					Rtndr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					Rtndr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					Rtndr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					Rtndr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					Rtndr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					Rtndr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					Rtndr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					Rtndr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					Rtndr[14] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					Rtndr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					Rtndr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					Rtndr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					Rtndr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					Rtndr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					Rtndr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					Rtndr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					Rtndr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					RtnIdtl.Rows.Add(Rtndr);
					DC_Main.i++;
				}
				RtnOldRow = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				OldAcCode = tAcCode.Text;
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			((Control)tAcCode).Focus();
		}
	}

	private void BtnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,B.BOOK_NAME As BookL,A.TOT_AMT As BillAmtR,A.CO_YEAR As YearL,A.CO_BOOK As CoBookL FROM  SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK = 'SALES'  ORDER BY A.VCH_DATE,A.VCH_NO DESC";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 150.0;
		DC_Main.ColWidth[4] = 120.0;
		DC_Main.ColWidth[5] = 0.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tIsuNo.Text = DC_Main.ColValue[0];
				tIsuYrCd.Text = DC_Main.ColValue[5];
				tIsuDbCd.Text = DC_Main.ColValue[6];
				((Control)tIsuNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
	}

	private void MSG_PR_Enter(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		//IL_06e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f0: Expected O, but got Unknown
		if (MSG_PR.Row == 0 || !((RtnOldRow != MSG_PR.Row) & !MsgPrClear))
		{
			return;
		}
		RtnOldRow = MSG_PR.Row;
		lblItem.Text = MSG_PR[MSG_PR.Row, 3] + " : It Name";
		MSG_RTN_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = RtnIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				int num3 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][23])));
				int num4 = (int)Math.Round(Conversion.Val(MSG_PR[MSG_PR.Row, 51]));
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 51]) == Conversion.Val(RuntimeHelpers.GetObjectValue(RtnIdtl.Rows[i][23])))
				{
					MSG_RTN_IDTL[num, 0] = Conversions.ToString(num);
					MSG_RTN_IDTL[num, 1] = Conversions.ToString(RtnIdtl.Rows[i][1]);
					MSG_RTN_IDTL[num, 2] = Conversions.ToString(RtnIdtl.Rows[i][2]);
					MSG_RTN_IDTL[num, 3] = Conversions.ToString(RtnIdtl.Rows[i][3]);
					MSG_RTN_IDTL[num, 4] = Conversions.ToString(RtnIdtl.Rows[i][4]);
					MSG_RTN_IDTL[num, 5] = Conversions.ToString(RtnIdtl.Rows[i][5]);
					MSG_RTN_IDTL[num, 6] = Conversions.ToString(RtnIdtl.Rows[i][6]);
					MSG_RTN_IDTL[num, 7] = Conversions.ToString(RtnIdtl.Rows[i][7]);
					MSG_RTN_IDTL[num, 8] = Conversions.ToString(RtnIdtl.Rows[i][8]);
					MSG_RTN_IDTL[num, 9] = Conversions.ToString(RtnIdtl.Rows[i][9]);
					MSG_RTN_IDTL[num, 10] = Conversions.ToString(RtnIdtl.Rows[i][10]);
					MSG_RTN_IDTL[num, 12] = Conversions.ToString(RtnIdtl.Rows[i][12]);
					MSG_RTN_IDTL[num, 11] = Conversions.ToString(RtnIdtl.Rows[i][11]);
					MSG_RTN_IDTL[num, 13] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][13], (object)""));
					MSG_RTN_IDTL[num, 14] = Conversions.ToString(RtnIdtl.Rows[i][14]);
					MSG_RTN_IDTL[num, 15] = Conversions.ToString(RtnIdtl.Rows[i][15]);
					MSG_RTN_IDTL[num, 16] = Conversions.ToString(RtnIdtl.Rows[i][16]);
					MSG_RTN_IDTL[num, 17] = Conversions.ToString(RtnIdtl.Rows[i][17]);
					MSG_RTN_IDTL[num, 18] = Conversions.ToString(RtnIdtl.Rows[i][18]);
					MSG_RTN_IDTL[num, 19] = Conversions.ToString(RtnIdtl.Rows[i][19]);
					MSG_RTN_IDTL[num, 20] = Conversions.ToString(RtnIdtl.Rows[i][20]);
					MSG_RTN_IDTL[num, 21] = Conversions.ToString(Operators.ConcatenateObject(RtnIdtl.Rows[i][21], (object)""));
					MSG_RTN_IDTL[num, 22] = Conversions.ToString(RtnIdtl.Rows[i][22]);
					MSG_RTN_IDTL[num, 23] = Conversions.ToString(RtnIdtl.Rows[i][23]);
					MSG_RTN_IDTL.Rows += 1;
					num++;
				}
			}
			PicImage.Image = null;
			if ((Operators.CompareString(MSG_PR[MSG_PR.Row, 69], "N", false) != 0) & (Operators.CompareString(MSG_PR[MSG_PR.Row, 5], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG_PR[MSG_PR.Row, 69] + "' AND IMAGE_TYPE = 'D'";
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
			else
			{
				if (Operators.CompareString(MSG_PR[MSG_PR.Row, 2], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG_PR[MSG_PR.Row, 2] + "_" + MSG_PR[MSG_PR.Row, 40];
					DC_Main.MsImageType = "TagImage";
				}
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				}
				else
				{
					PicImage.Image = null;
				}
			}
			MSG_RTN_IDTL[num, 0] = Conversions.ToString(num);
			MSG_RTN_IDTL[num, 23] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 51]));
		}
	}

	private void tVchNo_DoubleClick(object sender, EventArgs e)
	{
		((TextBoxBase)tVchNo).ReadOnly = false;
	}

	private void TR_SALE_RTN_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_RTN_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_RTN_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_RTN_IDTL).SelectionLength = Strings.Len(TEXT_RTN_IDTL.Text);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}
}
