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
using System.Threading;
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
public class TR_SALE_HM : Form
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
	[AccessedThroughProperty("tItDesc")]
	private TextBox _tItDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_OLD")]
	private AxMSFlexGrid _MSG_OLD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_OLD")]
	private TextBox _TEXT_OLD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

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
	[AccessedThroughProperty("MSG_ORD")]
	private AxMSFlexGrid _MSG_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ORD")]
	private TextBox _TEXT_ORD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPanNo")]
	private TextBox _tPanNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tNewPrint")]
	private TextBox _tNewPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblTrfrOpen")]
	private Label _lblTrfrOpen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTrfr")]
	private SimpleButton _btnTrfr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrNo")]
	private TextBox _tTrfrNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_UPI")]
	private AxMSFlexGrid _MSG_UPI;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_UPI")]
	private TextBox _TEXT_UPI;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string MoBook;

	private string MoVch;

	private string DataTrfr;

	private string WappAcName;

	private string WappMobile;

	private string WappMsg;

	private string AdminWappMsg;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private double ColHight;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string AcGstType;

	private bool MobileSearch;

	private string SmsDetail;

	private double CurItGwtStk;

	private bool OsAmtSave;

	private double AcTcsAmt;

	private double OldTcsPrc;

	private bool UpiTypeAdd;

	private string MainDbCd;

	private string MainVchNo;

	private string MainHdVchNo;

	private string OldAcCode;

	private double CustOpAmt;

	private double CustClAmt;

	private double LessAdvAmt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private double OldGoldPurcAmt;

	private double OldSilverPurcAmt;

	private double OlsSchmAmt;

	private double OldNetAmt;

	private double OldTaxPrc;

	private string MsVchSrno;

	private string FormPrintFile;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsOldDetl;

	private DataTable RsImg;

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

	private const int cCounter = 3;

	private const int cOrderNo = 4;

	private const int cDesign = 5;

	private const int cSize = 6;

	private const int cHmId = 7;

	private const int cBagWt = 8;

	private const int cPcs = 9;

	private const int cGrWt = 10;

	private const int cOthWt = 11;

	private const int cNetWt = 12;

	private const int cGhtPrc = 13;

	private const int cGhtWt = 14;

	private const int cTouch = 15;

	private const int cWestPrc = 16;

	private const int cFine = 17;

	private const int cItRate = 18;

	private const int cItAmt = 19;

	private const int cLbrPrc = 20;

	private const int cLbrType = 21;

	private const int cLbrRate = 22;

	private const int cLbrAmt = 23;

	private const int cGhtAmt = 24;

	private const int cOthAmt = 25;

	private const int cMrp = 26;

	private const int cLbrDiscPrc = 27;

	private const int cLbrDiscAmt = 28;

	private const int cTotAmt = 29;

	private const int cTaxPrc = 30;

	private const int cNetAmt = 31;

	private const int cHmAmt = 32;

	private const int cPrCost = 33;

	private const int cKrName = 34;

	private const int cKrOthWt = 35;

	private const int cKrNetWt = 36;

	private const int cKrGhatPrc = 37;

	private const int cKrGhatWt = 38;

	private const int cKrTouch = 39;

	private const int cKrWestPrc = 40;

	private const int cKrFine = 41;

	private const int cKrLRate = 42;

	private const int cKrLAmt = 43;

	private const int cKrOthAmt = 44;

	private const int cVchSrno = 45;

	private const int cTagCost = 46;

	private const int cMargin = 47;

	private const int cImageTake = 48;

	private const int cTagSrNo = 49;

	private const int cOldSrNo = 50;

	private const int cRateType = 51;

	private const int cItType = 52;

	private const int cTagType = 53;

	private const int cPrCode = 54;

	private const int cItName = 55;

	private const int cEntryMod = 56;

	private const int cOldTagType = 57;

	private const int cOldPrCode = 58;

	private const int cOldGrWt = 59;

	private const int cOldNtWt = 60;

	private const int cOldGhatPrc = 61;

	private const int cOldGhatWt = 62;

	private const int cOldTouch = 63;

	private const int cOldWestPrc = 64;

	private const int cOldKrNetWt = 65;

	private const int cOldKrTouch = 66;

	private const int cOldKrWest = 67;

	private const int cItDesc = 68;

	private const int cOldLbrRate = 69;

	private const int cOldLbrAmt = 70;

	private const int cIsuNo = 71;

	private const int cIsuYrCd = 72;

	private const int cIsuDbCd = 73;

	private const int cIsuSrNo = 74;

	private const int cOldItRate = 75;

	private const int cOldLbrPrc = 76;

	private const int cOldOthWt = 77;

	private const int cOldLbrType = 78;

	private const int cHmId2 = 79;

	private const int cHmId3 = 80;

	private const int cHmId4 = 81;

	private const int cHmIdWt = 82;

	private const int cHmId2Wt = 83;

	private const int cHmId3Wt = 84;

	private const int cHmId4wt = 85;

	private const int cOldValChange = 86;

	private const int cDesignImgId = 87;

	private const int cOrdYrCd = 88;

	private const int cOrdDbCd = 89;

	private const int cOrdSrNo = 90;

	private const int cOrdTagStkAdd = 91;

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

	private const int c1GrWt = 11;

	private const int c1ConPrc = 12;

	private const int c1RateType = 13;

	private const int c1ItRate = 14;

	private const int c1ItmAmt = 15;

	private const int c1LbrRate = 16;

	private const int c1LbrAmt = 17;

	private const int c1NetAmt = 18;

	private const int c1ConWt = 19;

	private const int c1KrWt = 20;

	private const int c1KrConWt = 21;

	private const int c1ItType = 22;

	private const int c1RowSr = 23;

	private const int c1OldKrWt = 24;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cHmAmt2 = 4;

	private const int cHmTax2 = 5;

	private const int cTot2 = 6;

	private const int cChq2 = 7;

	private const int cCard2 = 8;

	private const int cOrder2 = 9;

	private const int cOldGold2 = 10;

	private const int cOldSl2 = 11;

	private const int cSchem2 = 12;

	private const int cCash2 = 13;

	private const int cCashPaid2 = 14;

	private const int cKasar2 = 15;

	private const int cOs2 = 16;

	private const int cUrSrNo = 0;

	private const int cUrItCode = 1;

	private const int cUrItName = 2;

	private const int cUrPcs = 3;

	private const int cUrGrWt = 4;

	private const int cUrLess = 5;

	private const int cUrNetWt = 6;

	private const int cUrTouch = 7;

	private const int cUrFine = 8;

	private const int cUrRate = 9;

	private const int cUrNetAmt = 10;

	private const int cUrItType = 11;

	private const int cUrOldGwt = 12;

	private const int cUrOldLess = 13;

	private const int cOrSrNo = 0;

	private const int cOrVchNo = 1;

	private const int cOrVchAmt = 2;

	private const int cOrLc = 3;

	private const int cOrYrCd = 4;

	private const int cOrDbCd = 5;

	private const int cOrAcCode = 6;

	private const int cOrHdVchNo = 7;

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
			EventHandler eventHandler = tEmpCode_TextChanged;
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox tItDesc
	{
		[CompilerGenerated]
		get
		{
			return _tItDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItDesc_KeyDown);
			TextBox val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItDesc = value;
			val2 = _tItDesc;
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

	internal virtual AxMSFlexGrid MSG_OLD
	{
		[CompilerGenerated]
		get
		{
			return _MSG_OLD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_OLD_ClickEvent;
			EventHandler eventHandler2 = MSG_OLD_EnterCell;
			EventHandler eventHandler3 = MSG_OLD_LeaveCell;
			AxMSFlexGrid val = _MSG_OLD;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_OLD = value;
			val = _MSG_OLD;
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

	internal virtual TextBox TEXT_OLD
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_OLD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_OLD_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_OLD_KeyDown);
			TextBox val2 = _TEXT_OLD;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_OLD = value;
			val2 = _TEXT_OLD;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tBankName
	{
		[CompilerGenerated]
		get
		{
			return _tBankName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBankName_KeyDown);
			TextBox val2 = _tBankName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBankName = value;
			val2 = _tBankName;
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
			EventHandler eventHandler = btnIsuNo_Click;
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
			EventHandler eventHandler = tIsuNo_TextChanged;
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

	internal virtual TextBox tPanNo
	{
		[CompilerGenerated]
		get
		{
			return _tPanNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPanNo_KeyDown);
			TextBox val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPanNo = value;
			val2 = _tPanNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnTagSet
	{
		[CompilerGenerated]
		get
		{
			return _btnTagSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTagSet_Click;
			SimpleButton val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagSet = value;
			val = _btnTagSet;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintfile")]
	private virtual ComboBox _cboPrintfile;

	internal virtual ComboBox cboPrintfile
	{
		get
		{
			return _cboPrintfile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintfile = value;
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

	internal virtual TextBox tNewPrint
	{
		[CompilerGenerated]
		get
		{
			return _tNewPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tNewPrint_KeyDown);
			TextBox val2 = _tNewPrint;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tNewPrint = value;
			val2 = _tNewPrint;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("WebBrowser1")]
	private virtual WebBrowser _WebBrowser1;

	internal virtual WebBrowser WebBrowser1
	{
		get
		{
			return _WebBrowser1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_WebBrowser1 = value;
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

	internal virtual Label lblTrfrOpen
	{
		[CompilerGenerated]
		get
		{
			return _lblTrfrOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = lblTrfrOpen_Click;
			Label val = _lblTrfrOpen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_lblTrfrOpen = value;
			val = _lblTrfrOpen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlTrfrVch")]
	private virtual Panel _PnlTrfrVch;

	internal virtual Panel PnlTrfrVch
	{
		get
		{
			return _PnlTrfrVch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlTrfrVch = value;
		}
	}

	internal virtual SimpleButton btnTrfr
	{
		[CompilerGenerated]
		get
		{
			return _btnTrfr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnTrfr_Click;
			SimpleButton val = _btnTrfr;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTrfr = value;
			val = _btnTrfr;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrYrCd")]
	private virtual TextBox _tTrfrYrCd;

	internal virtual TextBox tTrfrYrCd
	{
		get
		{
			return _tTrfrYrCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTrfrYrCd = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTrfrDbCd")]
	private virtual TextBox _tTrfrDbCd;

	internal virtual TextBox tTrfrDbCd
	{
		get
		{
			return _tTrfrDbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTrfrDbCd = value;
		}
	}

	internal virtual TextBox tTrfrNo
	{
		[CompilerGenerated]
		get
		{
			return _tTrfrNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTrfrNo_KeyDown);
			TextBox val2 = _tTrfrNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTrfrNo = value;
			val2 = _tTrfrNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("chkRateUnFix")]
	private virtual CheckBox _chkRateUnFix;

	internal virtual CheckBox chkRateUnFix
	{
		get
		{
			return _chkRateUnFix;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_chkRateUnFix = value;
		}
	}

	public TR_SALE_HM()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_HM_Load;
		((Form)this).Deactivate += TR_SALE_HM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_HM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_HM_KeyDown);
		((Form)this).Activated += TR_SALE_HM_Activated;
		((Form)this).Closed += TR_SALE_HM_Closed;
		((Control)this).DoubleClick += TR_SALE_HM_DoubleClick;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_HM_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
		LessAdvAmt = 0.0;
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
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_0540: Expected O, but got Unknown
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05fc: Expected O, but got Unknown
		//IL_067f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0689: Expected O, but got Unknown
		//IL_0726: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Expected O, but got Unknown
		//IL_07de: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e8: Expected O, but got Unknown
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_0914: Unknown result type (might be due to invalid IL or missing references)
		//IL_091e: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Expected O, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad7: Expected O, but got Unknown
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b44: Expected O, but got Unknown
		//IL_0bed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf7: Expected O, but got Unknown
		//IL_0d14: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1e: Expected O, but got Unknown
		//IL_0e29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e33: Expected O, but got Unknown
		//IL_0e96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea0: Expected O, but got Unknown
		//IL_1032: Unknown result type (might be due to invalid IL or missing references)
		//IL_1121: Unknown result type (might be due to invalid IL or missing references)
		//IL_112b: Expected O, but got Unknown
		//IL_11d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e0: Expected O, but got Unknown
		//IL_128c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1296: Expected O, but got Unknown
		//IL_138e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1398: Expected O, but got Unknown
		//IL_14a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b3: Expected O, but got Unknown
		//IL_1530: Unknown result type (might be due to invalid IL or missing references)
		//IL_153a: Expected O, but got Unknown
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1608: Expected O, but got Unknown
		//IL_16af: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b9: Expected O, but got Unknown
		//IL_17b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17bb: Expected O, but got Unknown
		//IL_181c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1826: Expected O, but got Unknown
		//IL_192f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1939: Expected O, but got Unknown
		//IL_1a11: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1b: Expected O, but got Unknown
		//IL_1ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac1: Expected O, but got Unknown
		//IL_1bfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c06: Expected O, but got Unknown
		//IL_1c51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c5b: Expected O, but got Unknown
		//IL_1cd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce2: Expected O, but got Unknown
		//IL_1d63: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6d: Expected O, but got Unknown
		//IL_1e37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e41: Expected O, but got Unknown
		//IL_1ee8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef2: Expected O, but got Unknown
		//IL_1f73: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f7d: Expected O, but got Unknown
		//IL_2005: Unknown result type (might be due to invalid IL or missing references)
		//IL_200f: Expected O, but got Unknown
		//IL_20c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cd: Expected O, but got Unknown
		//IL_2181: Unknown result type (might be due to invalid IL or missing references)
		//IL_218b: Expected O, but got Unknown
		//IL_222d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2237: Expected O, but got Unknown
		//IL_22b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c2: Expected O, but got Unknown
		//IL_238c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2396: Expected O, but got Unknown
		//IL_23fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2407: Expected O, but got Unknown
		//IL_2462: Unknown result type (might be due to invalid IL or missing references)
		//IL_246c: Expected O, but got Unknown
		//IL_250b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2515: Expected O, but got Unknown
		//IL_25a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25b1: Expected O, but got Unknown
		//IL_2636: Unknown result type (might be due to invalid IL or missing references)
		//IL_2640: Expected O, but got Unknown
		//IL_26e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_26ea: Expected O, but got Unknown
		//IL_2798: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a2: Expected O, but got Unknown
		//IL_298e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2998: Expected O, but got Unknown
		//IL_2a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a4f: Expected O, but got Unknown
		//IL_2ade: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae8: Expected O, but got Unknown
		//IL_2b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba0: Expected O, but got Unknown
		//IL_2c2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c39: Expected O, but got Unknown
		//IL_2ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cf1: Expected O, but got Unknown
		//IL_2d9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2da9: Expected O, but got Unknown
		//IL_2e38: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e42: Expected O, but got Unknown
		//IL_2ed1: Unknown result type (might be due to invalid IL or missing references)
		//IL_2edb: Expected O, but got Unknown
		//IL_2f69: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f73: Expected O, but got Unknown
		//IL_3020: Unknown result type (might be due to invalid IL or missing references)
		//IL_302a: Expected O, but got Unknown
		//IL_30de: Unknown result type (might be due to invalid IL or missing references)
		//IL_30e8: Expected O, but got Unknown
		//IL_31b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c2: Expected O, but got Unknown
		//IL_321d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3227: Expected O, but got Unknown
		//IL_32b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_32c3: Expected O, but got Unknown
		//IL_334e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3358: Expected O, but got Unknown
		//IL_3406: Unknown result type (might be due to invalid IL or missing references)
		//IL_3410: Expected O, but got Unknown
		//IL_34e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_34f2: Expected O, but got Unknown
		//IL_358e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3598: Expected O, but got Unknown
		//IL_3699: Unknown result type (might be due to invalid IL or missing references)
		//IL_36a3: Expected O, but got Unknown
		//IL_3751: Unknown result type (might be due to invalid IL or missing references)
		//IL_375b: Expected O, but got Unknown
		//IL_37e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_37f3: Expected O, but got Unknown
		//IL_38a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38b1: Expected O, but got Unknown
		//IL_393f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3949: Expected O, but got Unknown
		//IL_3a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a19: Expected O, but got Unknown
		//IL_3aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3af8: Expected O, but got Unknown
		//IL_3b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9e: Expected O, but got Unknown
		//IL_3ced: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cf7: Expected O, but got Unknown
		//IL_3d71: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d7b: Expected O, but got Unknown
		//IL_3e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e36: Expected O, but got Unknown
		//IL_3f29: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f33: Expected O, but got Unknown
		//IL_418f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4199: Expected O, but got Unknown
		//IL_426e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4278: Expected O, but got Unknown
		//IL_4311: Unknown result type (might be due to invalid IL or missing references)
		//IL_431b: Expected O, but got Unknown
		//IL_4428: Unknown result type (might be due to invalid IL or missing references)
		//IL_4432: Expected O, but got Unknown
		//IL_44cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_44d5: Expected O, but got Unknown
		//IL_456d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4577: Expected O, but got Unknown
		//IL_4601: Unknown result type (might be due to invalid IL or missing references)
		//IL_460b: Expected O, but got Unknown
		//IL_4756: Unknown result type (might be due to invalid IL or missing references)
		//IL_4760: Expected O, but got Unknown
		//IL_4803: Unknown result type (might be due to invalid IL or missing references)
		//IL_480d: Expected O, but got Unknown
		//IL_4869: Unknown result type (might be due to invalid IL or missing references)
		//IL_4873: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE_HM));
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
		chkWapp = new CheckBox();
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
		tItDesc = new TextBox();
		Label5 = new Label();
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_OLD = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_OLD = new TextBox();
		tBankName = new TextBox();
		Label7 = new Label();
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
		LOpAmt = new Label();
		LClAmt = new Label();
		MSG_ORD = new AxMSFlexGrid();
		TEXT_ORD = new TextBox();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		btnIsuNo = new SimpleButton();
		Label12 = new Label();
		tIsuNo = new TextBox();
		Label14 = new Label();
		nCrDays = new TextBox();
		tPanNo = new TextBox();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label15 = new Label();
		tNewPrint = new TextBox();
		WebBrowser1 = new WebBrowser();
		lblItStock = new Label();
		lblTrfrOpen = new Label();
		PnlTrfrVch = new Panel();
		btnTrfr = new SimpleButton();
		tTrfrYrCd = new TextBox();
		tTrfrDbCd = new TextBox();
		tTrfrNo = new TextBox();
		Label19 = new Label();
		PnlUpi = new Panel();
		TEXT_UPI = new TextBox();
		MSG_UPI = new AxMSFlexGrid();
		chkRateUnFix = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_OLD).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_ORD).BeginInit();
		((Control)PnlTrfrVch).SuspendLayout();
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
		lblBook.Text = "Sales";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 39);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(229, 40);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 41);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(105, 39);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 39);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 39);
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
		((Control)PnlBotam).TabIndex = 15;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkHuIdPrint);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkHuIdPrint).BackColor = Color.Transparent;
		((Control)chkHuIdPrint).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkHuIdPrint).ForeColor = Color.Black;
		((Control)chkHuIdPrint).Location = new Point(474, 3);
		((Control)chkHuIdPrint).Name = "chkHuIdPrint";
		((Control)chkHuIdPrint).RightToLeft = (RightToLeft)0;
		((Control)chkHuIdPrint).Size = new Size(98, 27);
		((Control)chkHuIdPrint).TabIndex = 5;
		((ButtonBase)chkHuIdPrint).Text = "HuId Print";
		((ButtonBase)chkHuIdPrint).UseVisualStyleBackColor = false;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(370, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(98, 26);
		((Control)chkWapp).TabIndex = 7;
		((ButtonBase)chkWapp).Text = "Whatsapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
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
		((Control)TEXT_ENTRY).Location = new Point(782, 147);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 6;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(326, 214);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(392, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(444, 318);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 8;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 242);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(710, 113);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(12, 463);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(115, 74);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 191);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1161, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 97);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1162, 93);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1176, 367);
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
		((Control)BtnF1).Location = new Point(187, 39);
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
		((Control)tAcCode).Location = new Point(312, 68);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 68);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(326, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(230, 67);
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
		((Control)tEmpCode).Location = new Point(225, 463);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 11;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(288, 463);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(140, 463);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(140, 517);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(225, 520);
		((TextBoxBase)tVchDesc).MaxLength = 250;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(279, 37);
		((Control)tVchDesc).TabIndex = 14;
		((TextBoxBase)tItDesc).BackColor = Color.White;
		((Control)tItDesc).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItDesc).Location = new Point(96, 213);
		((TextBoxBase)tItDesc).MaxLength = 50;
		((Control)tItDesc).Name = "tItDesc";
		((Control)tItDesc).Size = new Size(220, 22);
		((Control)tItDesc).TabIndex = 7;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 213);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Print Name";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(732, 214);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 344);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_OLD).Location = new Point(12, 363);
		((Control)MSG_OLD).Name = "MSG_OLD";
		((AxHost)MSG_OLD).OcxState = (State)componentResourceManager.GetObject("MSG_OLD.OcxState");
		((Control)MSG_OLD).Size = new Size(710, 93);
		((Control)MSG_OLD).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(934, 382);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_OLD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_OLD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_OLD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_OLD).ForeColor = Color.White;
		((Control)TEXT_OLD).Location = new Point(378, 414);
		((Control)TEXT_OLD).Name = "TEXT_OLD";
		((Control)TEXT_OLD).Size = new Size(100, 18);
		((Control)TEXT_OLD).TabIndex = 10;
		((Control)TEXT_OLD).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(225, 491);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(172, 23);
		((Control)tBankName).TabIndex = 12;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(140, 490);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 68);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(105, 68);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 2;
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
		((Control)PanelAdd).Location = new Point(312, 93);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 155);
		((Control)PanelAdd).TabIndex = 5;
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
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1021, 74);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1206;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(574, 537);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1209;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)MSG_ORD).Location = new Point(511, 463);
		((Control)MSG_ORD).Name = "MSG_ORD";
		((AxHost)MSG_ORD).OcxState = (State)componentResourceManager.GetObject("MSG_ORD.OcxState");
		((Control)MSG_ORD).Size = new Size(211, 72);
		((Control)MSG_ORD).TabIndex = 1210;
		((TextBoxBase)TEXT_ORD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ORD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ORD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ORD).ForeColor = Color.White;
		((Control)TEXT_ORD).Location = new Point(596, 486);
		((Control)TEXT_ORD).Name = "TEXT_ORD";
		((Control)TEXT_ORD).Size = new Size(75, 18);
		((Control)TEXT_ORD).TabIndex = 1211;
		((Control)TEXT_ORD).Visible = false;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuYrCd).Location = new Point(724, 39);
		((TextBoxBase)tIsuYrCd).MaxLength = 8;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(76, 22);
		((Control)tIsuYrCd).TabIndex = 1216;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuDbCd).Location = new Point(804, 39);
		((TextBoxBase)tIsuDbCd).MaxLength = 8;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(76, 22);
		((Control)tIsuDbCd).TabIndex = 1215;
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
		((Control)btnIsuNo).Location = new Point(886, 38);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(35, 23);
		((Control)btnIsuNo).TabIndex = 1214;
		btnIsuNo.Text = "A";
		((BaseControl)btnIsuNo).ToolTip = "Approval Help";
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(572, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(64, 20);
		((Control)Label12).TabIndex = 1213;
		Label12.Text = "Apr No";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuNo).Location = new Point(644, 39);
		((TextBoxBase)tIsuNo).MaxLength = 8;
		((Control)tIsuNo).Name = "tIsuNo";
		((TextBoxBase)tIsuNo).ReadOnly = true;
		((Control)tIsuNo).Size = new Size(76, 22);
		((Control)tIsuNo).TabIndex = 1212;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(401, 492);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(53, 20);
		((Control)Label14).TabIndex = 1217;
		Label14.Text = "CrDay";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(459, 491);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(45, 23);
		((Control)nCrDays).TabIndex = 13;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tPanNo).BackColor = Color.White;
		((Control)tPanNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tPanNo).ForeColor = Color.Maroon;
		((Control)tPanNo).Location = new Point(836, 520);
		((TextBoxBase)tPanNo).MaxLength = 12;
		((Control)tPanNo).Name = "tPanNo";
		((Control)tPanNo).Size = new Size(171, 23);
		((Control)tPanNo).TabIndex = 1218;
		((Control)tPanNo).Visible = false;
		((BaseStyleControl)btnTagSet).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTagSet).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTagSet).Appearance.Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagSet).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTagSet).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagSet).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTagSet).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTagSet).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnTagSet).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTagSet).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTagSet).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTagSet).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTagSet).AppearancePressed.Options.UseFont = true;
		((Control)btnTagSet).Location = new Point(1125, 41);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(44, 24);
		((Control)btnTagSet).TabIndex = 1220;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		cboPrintfile.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(1006, 41);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(113, 24);
		((Control)cboPrintfile).TabIndex = 1219;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(949, 44);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(51, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Print";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tNewPrint).BackColor = Color.White;
		((Control)tNewPrint).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tNewPrint).Location = new Point(1175, 42);
		((TextBoxBase)tNewPrint).MaxLength = 50;
		((Control)tNewPrint).Name = "tNewPrint";
		((Control)tNewPrint).Size = new Size(125, 23);
		((Control)tNewPrint).TabIndex = 1222;
		((Control)tNewPrint).Visible = false;
		((Control)WebBrowser1).Location = new Point(1196, 490);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(101, 63);
		((Control)WebBrowser1).TabIndex = 1223;
		((Control)lblItStock).BackColor = Color.Transparent;
		((Control)lblItStock).Font = new Font("Tahoma", 9f);
		((Control)lblItStock).ForeColor = Color.Blue;
		lblItStock.ImeMode = (ImeMode)0;
		((Control)lblItStock).Location = new Point(12, 540);
		((Control)lblItStock).Name = "lblItStock";
		((Control)lblItStock).Size = new Size(205, 20);
		((Control)lblItStock).TabIndex = 1224;
		lblItStock.Text = "Itm Stock :";
		lblItStock.TextAlign = (ContentAlignment)16;
		((Control)lblTrfrOpen).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblTrfrOpen).Location = new Point(1133, 5);
		((Control)lblTrfrOpen).Name = "lblTrfrOpen";
		((Control)lblTrfrOpen).Size = new Size(25, 23);
		((Control)lblTrfrOpen).TabIndex = 1225;
		lblTrfrOpen.Text = ".";
		lblTrfrOpen.TextAlign = (ContentAlignment)2;
		((Control)PnlTrfrVch).BackColor = Color.FromArgb(255, 224, 192);
		PnlTrfrVch.BorderStyle = (BorderStyle)2;
		((Control)PnlTrfrVch).Controls.Add((Control)(object)btnTrfr);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrYrCd);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrDbCd);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)tTrfrNo);
		((Control)PnlTrfrVch).Controls.Add((Control)(object)Label19);
		((Control)PnlTrfrVch).Location = new Point(724, 37);
		((Control)PnlTrfrVch).Name = "PnlTrfrVch";
		((Control)PnlTrfrVch).Size = new Size(447, 52);
		((Control)PnlTrfrVch).TabIndex = 1226;
		((Control)PnlTrfrVch).Visible = false;
		((BaseStyleControl)btnTrfr).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTrfr).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTrfr).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnTrfr).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTrfr).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTrfr).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTrfr).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTrfr).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTrfr).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTrfr).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTrfr).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTrfr).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTrfr).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTrfr).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTrfr).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTrfr).AppearancePressed.Options.UseFont = true;
		((Control)btnTrfr).Location = new Point(324, 8);
		((BaseControl)btnTrfr).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTrfr).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTrfr).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTrfr).Name = "btnTrfr";
		((Control)btnTrfr).Size = new Size(97, 32);
		((Control)btnTrfr).TabIndex = 3;
		btnTrfr.Text = "Transfer";
		((BaseControl)btnTrfr).ToolTip = "Party Help";
		((TextBoxBase)tTrfrYrCd).BackColor = Color.White;
		((Control)tTrfrYrCd).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrYrCd).ForeColor = Color.Maroon;
		((Control)tTrfrYrCd).Location = new Point(222, 14);
		((TextBoxBase)tTrfrYrCd).MaxLength = 10;
		((Control)tTrfrYrCd).Name = "tTrfrYrCd";
		((TextBoxBase)tTrfrYrCd).ReadOnly = true;
		((Control)tTrfrYrCd).Size = new Size(88, 23);
		((Control)tTrfrYrCd).TabIndex = 2;
		((TextBoxBase)tTrfrDbCd).BackColor = Color.White;
		((Control)tTrfrDbCd).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrDbCd).ForeColor = Color.Maroon;
		((Control)tTrfrDbCd).Location = new Point(145, 14);
		((TextBoxBase)tTrfrDbCd).MaxLength = 3;
		((Control)tTrfrDbCd).Name = "tTrfrDbCd";
		((TextBoxBase)tTrfrDbCd).ReadOnly = true;
		((Control)tTrfrDbCd).Size = new Size(70, 23);
		((Control)tTrfrDbCd).TabIndex = 1;
		((TextBoxBase)tTrfrNo).BackColor = Color.White;
		((Control)tTrfrNo).Font = new Font("Tahoma", 9.75f);
		((TextBoxBase)tTrfrNo).ForeColor = Color.Maroon;
		((Control)tTrfrNo).Location = new Point(69, 14);
		((TextBoxBase)tTrfrNo).MaxLength = 10;
		((Control)tTrfrNo).Name = "tTrfrNo";
		((Control)tTrfrNo).Size = new Size(71, 23);
		((Control)tTrfrNo).TabIndex = 0;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9f, (FontStyle)1);
		((Control)Label19).ForeColor = Color.Maroon;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(15, 14);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(50, 20);
		((Control)Label19).TabIndex = 1158;
		Label19.Text = "VchNo";
		Label19.TextAlign = (ContentAlignment)64;
		((Control)PnlUpi).Controls.Add((Control)(object)TEXT_UPI);
		((Control)PnlUpi).Controls.Add((Control)(object)MSG_UPI);
		((Control)PnlUpi).Location = new Point(9, 208);
		((Control)PnlUpi).Name = "PnlUpi";
		((Control)PnlUpi).Size = new Size(717, 352);
		((Control)PnlUpi).TabIndex = 1227;
		((Control)PnlUpi).Visible = false;
		((TextBoxBase)TEXT_UPI).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_UPI).BorderStyle = (BorderStyle)0;
		((Control)TEXT_UPI).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_UPI).ForeColor = Color.White;
		((Control)TEXT_UPI).Location = new Point(308, 167);
		((Control)TEXT_UPI).Name = "TEXT_UPI";
		((Control)TEXT_UPI).Size = new Size(100, 18);
		((Control)TEXT_UPI).TabIndex = 11;
		((Control)TEXT_UPI).Visible = false;
		((Control)MSG_UPI).Location = new Point(7, 6);
		((Control)MSG_UPI).Name = "MSG_UPI";
		((AxHost)MSG_UPI).OcxState = (State)componentResourceManager.GetObject("MSG_UPI.OcxState");
		((Control)MSG_UPI).Size = new Size(702, 339);
		((Control)MSG_UPI).TabIndex = 0;
		((ButtonBase)chkRateUnFix).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkRateUnFix).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkRateUnFix).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkRateUnFix).Location = new Point(93, 8);
		((Control)chkRateUnFix).Name = "chkRateUnFix";
		((Control)chkRateUnFix).RightToLeft = (RightToLeft)0;
		((Control)chkRateUnFix).Size = new Size(116, 19);
		((Control)chkRateUnFix).TabIndex = 1235;
		((ButtonBase)chkRateUnFix).Text = "Rate UnFix";
		((ButtonBase)chkRateUnFix).UseVisualStyleBackColor = false;
		((Control)chkRateUnFix).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkRateUnFix);
		((Control)this).Controls.Add((Control)(object)PnlUpi);
		((Control)this).Controls.Add((Control)(object)PnlTrfrVch);
		((Control)this).Controls.Add((Control)(object)lblTrfrOpen);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)tNewPrint);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)tPanNo);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)TEXT_ORD);
		((Control)this).Controls.Add((Control)(object)MSG_ORD);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)TEXT_OLD);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_OLD);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItDesc);
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
		((Control)this).Name = "TR_SALE_HM";
		((Form)this).Text = "Sales Hm";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_OLD).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_ORD).EndInit();
		((Control)PnlTrfrVch).ResumeLayout(false);
		((Control)PnlTrfrVch).PerformLayout();
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
			mSG_UPI[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_UPI[1] = 0;
			mSG_UPI[0, 1] = "AcCode";
			mSG_UPI[2] = (int)Math.Round(3300.0 * ColCon);
			mSG_UPI[2] = 0;
			mSG_UPI[0, 2] = "Upi Bank Name";
			mSG_UPI[3] = (int)Math.Round(1500.0 * ColCon);
			mSG_UPI[3] = 0;
			mSG_UPI[0, 3] = "UpiType";
			mSG_UPI[4] = (int)Math.Round(2500.0 * ColCon);
			mSG_UPI[4] = 0;
			mSG_UPI[0, 4] = "Upi Id";
			mSG_UPI[5] = (int)Math.Round(1400.0 * ColCon);
			mSG_UPI[5] = 7;
			mSG_UPI[0, 5] = "UpiAmt";
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
			MSG2_TOTAL[13, 1] = Strings.Format((object)num2, "0.00");
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
							MSG2_TOTAL.Row = 13;
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
								DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.AC_GR in( '19','22','23','21','02') AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 AND A.AC_GR in( '19','22','23','21','02') ORDER BY C.AC_NAME ";
							}
							else
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR in( '19','22','23') ORDER BY A.AC_NAME";
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
						DC_Main.RsQry = "SELECT UPI_TYPE  From UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND UPI_TYPE = '" + TEXT_UPI.Text + "' ORDER BY UPI_TYPE";
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
		mSG_ORD.Cols = 8;
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
			mSG_ORD[1] = (int)Math.Round(1100.0 * ColCon);
			mSG_ORD[1] = 0;
			mSG_ORD[0, 1] = "Ord No";
			mSG_ORD[2] = (int)Math.Round(1250.0 * ColCon);
			mSG_ORD[2] = 7;
			mSG_ORD[0, 2] = "Ord Amt";
			mSG_ORD[4] = 0;
			mSG_ORD[5] = 0;
			mSG_ORD[6] = 0;
			mSG_ORD[7] = 0;
			mSG_ORD[3] = 0;
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
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
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
					if (mSG_ORD.Col < 18)
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
						((Control)TEXT_ORD).Visible = false;
						MSG2_TOTAL.Col = 3;
						MSG2_TOTAL.Row = 10;
						MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					}
					if (!((Operators.CompareString(TEXT_ORD.Text, "", false) == 0) | (Operators.CompareString(TEXT_ORD.Text, mSG_ORD[mSG_ORD.Row, 1], false) != 0)))
					{
						break;
					}
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG_ORD[mSG_ORD.Row, 4] + "' AND CO_BOOK = '" + mSG_ORD[mSG_ORD.Row, 5] + "' AND VCH_NO = '" + TEXT_ORD.Text + "' ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count == 0)
					{
						DC_Main.RsQry = "SELECT A.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS OrderDtL,A.ADV_AMT AS AmountR,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmountR ,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON  A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  GROUP BY A.AC_NAME,A.AC_CODE,A.VCH_NO,A.VCH_DATE,A.ADV_AMT,A.CO_YEAR,A.CO_BOOK,A.HD_VCH_NO HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END) > 0  ORDER BY A.VCH_DATE,A.VCH_NO ";
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[10];
						DC_Main.ColWidth[0] = 320.0;
						DC_Main.ColWidth[1] = 100.0;
						DC_Main.ColWidth[2] = 95.0;
						DC_Main.ColWidth[3] = 130.0;
						DC_Main.ColWidth[4] = 115.0;
						DC_Main.ColWidth[5] = 115.0;
						DC_Main.ColWidth[6] = 0.0;
						DC_Main.ColWidth[7] = 0.0;
						DC_Main.ColWidth[8] = 0.0;
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (!DC_Main.HelpClose)
						{
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ORD.Text = DC_Main.ColValue[2];
								mSG_ORD[mSG_ORD.Row, 4] = DC_Main.ColValue[6];
								mSG_ORD[mSG_ORD.Row, 5] = DC_Main.ColValue[7];
								mSG_ORD[mSG_ORD.Row, 6] = DC_Main.ColValue[1];
								mSG_ORD[mSG_ORD.Row, 7] = DC_Main.ColValue[8];
								mSG_ORD[mSG_ORD.Row, 3] = DC_Main.MLc_code;
								LessAdvAmt = Conversions.ToDouble(DC_Main.ColValue[5]);
							}
							((Control)TEXT_ORD).Focus();
						}
					}
					else
					{
						mSG_ORD[mSG_ORD.Row, 1] = TEXT_ORD.Text;
						mSG_ORD[mSG_ORD.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
						mSG_ORD[mSG_ORD.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
						AxMSFlexGrid obj = mSG_ORD;
						int row = mSG_ORD.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["ADV_AMT"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["ADV_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 2] = Strings.Format((object)(num - LessAdvAmt), "0.00");
						mSG_ORD[mSG_ORD.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
						mSG_ORD[mSG_ORD.Row, 3] = DC_Main.MLc_code;
						LessAdvAmt = 0.0;
						BILL_TOTAL();
					}
					return;
				case 2:
					if (mSG_ORD.Row == mSG_ORD.Rows - 1)
					{
						mSG_ORD[mSG_ORD.Row, 2] = Strings.Format((object)Conversion.Val(TEXT_ORD.Text), "0.00");
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

	private void MSG_OLD_CLEAR()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD.Clear();
		mSG_OLD.Cols = 14;
		mSG_OLD.FixedRows = 1;
		mSG_OLD.Rows = 2;
		mSG_OLD.Row = 1;
		mSG_OLD[0] = 0;
		mSG_OLD[1] = 0;
		mSG_OLD.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_OLD[0] = (int)Math.Round(500.0 * ColCon);
			mSG_OLD[0] = 3;
			mSG_OLD[0, 0] = "Sr";
			mSG_OLD[1] = (int)Math.Round(900.0 * ColCon);
			mSG_OLD[1] = 0;
			mSG_OLD[0, 1] = "ItCode";
			mSG_OLD[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_OLD[2] = 0;
			mSG_OLD[0, 2] = "ItName";
			mSG_OLD[3] = (int)Math.Round(600.0 * ColCon);
			mSG_OLD[3] = 7;
			mSG_OLD[0, 3] = "Pcs";
			mSG_OLD[4] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[4] = 7;
			mSG_OLD[0, 4] = "GrWt";
			mSG_OLD[5] = (int)Math.Round(800.0 * ColCon);
			mSG_OLD[5] = 7;
			mSG_OLD[0, 5] = "LsWt";
			mSG_OLD[6] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[6] = 7;
			mSG_OLD[0, 6] = "NetWt";
			mSG_OLD[7] = (int)Math.Round(700.0 * ColCon);
			mSG_OLD[7] = 3;
			mSG_OLD[0, 7] = "Touch";
			mSG_OLD[8] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[8] = 7;
			mSG_OLD[0, 8] = "Fine";
			mSG_OLD[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_OLD[9] = 7;
			mSG_OLD[0, 9] = "Rate";
			mSG_OLD[10] = (int)Math.Round(1100.0 * ColCon);
			mSG_OLD[10] = 7;
			mSG_OLD[0, 10] = "NetAmt";
			mSG_OLD[11] = 0;
			mSG_OLD[12] = 0;
			mSG_OLD[13] = 0;
			mSG_OLD.Row = 1;
			mSG_OLD.Col = 1;
			((Control)TEXT_OLD).Visible = false;
			mSG_OLD[0] = (int)Math.Round(325.0 * ColCon);
			mSG_OLD[1] = (int)Math.Round(300.0 * ColCon);
			mSG_OLD.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Old();
			mSG_OLD = null;
		}
	}

	private void CommPassAdd_Old()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD[mSG_OLD.Row, 0] = Conversions.ToString(mSG_OLD.Row);
		mSG_OLD = null;
	}

	private void TEXT_OLD_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_OLD_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Invalid comparison between Unknown and I4
		//IL_0100: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Invalid comparison between Unknown and I4
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Invalid comparison between Unknown and I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Invalid comparison between Unknown and I4
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG_OLD.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG_OLD[mSG_OLD.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_OLD.Text = "";
					Interaction.MsgBox((object)"Record Is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_OLD.Col > 1)
				{
					mSG_OLD.Col = checked(mSG_OLD.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_OLD.Col < 18)
				{
					mSG_OLD.Col = checked(mSG_OLD.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_OLD.Row > 1)
				{
					mSG_OLD.Row = checked(mSG_OLD.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_OLD.Row < mSG_OLD.Rows - 1)
					{
						mSG_OLD.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_OLD.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_OLD.Text, "", false) == 0)
						{
							((Control)TEXT_OLD).Visible = false;
							MSG2_TOTAL.Col = 3;
							MSG2_TOTAL.Row = 12;
							MSG2_TOTAL_EnterCell(MSG2_TOTAL, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_OLD.Text + "'";
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
									TEXT_OLD.Text = DC_Main.ColValue[1];
									mSG_OLD[mSG_OLD.Row, 1] = DC_Main.ColValue[1];
									mSG_OLD[mSG_OLD.Row, 2] = DC_Main.ColValue[0];
									mSG_OLD[mSG_OLD.Row, 11] = DC_Main.ColValue[4];
								}
								((Control)TEXT_OLD).Focus();
							}
							return;
						}
						mSG_OLD[mSG_OLD.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_OLD[mSG_OLD.Row, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						break;
					case 10:
						if (mSG_OLD.Row == mSG_OLD.Rows - 1)
						{
							mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
							CommPassTotal_Old(mSG_OLD.Row);
							MsgClearIdtl = true;
							mSG_OLD.Rows += 1;
							mSG_OLD.Row += 1;
							MsgClearIdtl = false;
							mSG_OLD.Col = 1;
							CommPassAdd_Old();
							((Control)TEXT_OLD).Visible = true;
							((Control)TEXT_OLD).Focus();
						}
						else
						{
							mSG_OLD.Row += 1;
							mSG_OLD.Col = 1;
							((Control)TEXT_OLD).Visible = true;
							((Control)TEXT_OLD).Focus();
						}
						return;
					}
					if (mSG_OLD.Col < mSG_OLD.Cols - 1)
					{
						mSG_OLD.Col += 1;
					}
					((Control)TEXT_OLD).Visible = true;
					((Control)TEXT_OLD).Focus();
				}
			}
		}
		mSG_OLD = null;
	}

	private void MSG_OLD_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		checked
		{
			if (mSG_OLD.CellWidth >= 0)
			{
				((Control)TEXT_OLD).Left = (int)Math.Round((double)((Control)mSG_OLD).Left + (double)mSG_OLD.CellLeft / 15.0);
				((Control)TEXT_OLD).Top = (int)Math.Round((double)((Control)mSG_OLD).Top + (double)mSG_OLD.CellTop / 15.0);
				((Control)TEXT_OLD).Width = (int)Math.Round((double)mSG_OLD.CellWidth / 15.0);
				((Control)TEXT_OLD).Height = (int)Math.Round((double)mSG_OLD.CellHeight / 15.0);
				TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
				((Control)TEXT_OLD).Visible = true;
				((TextBoxBase)TEXT_OLD).SelectAll();
				((Control)TEXT_OLD).Focus();
				mSG_OLD = null;
			}
		}
	}

	private void MSG_OLD_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		checked
		{
			if (!((mSG_OLD.Row == 0) | (mSG_OLD.CellWidth <= 0)) && mSG_OLD[mSG_OLD.Col] != 0)
			{
				((Control)TEXT_OLD).Left = (int)Math.Round((double)((Control)mSG_OLD).Left + (double)mSG_OLD.CellLeft / 15.0);
				((Control)TEXT_OLD).Top = (int)Math.Round((double)((Control)mSG_OLD).Top + (double)mSG_OLD.CellTop / 15.0);
				((Control)TEXT_OLD).Width = (int)Math.Round((double)mSG_OLD.CellWidth / 15.0);
				((Control)TEXT_OLD).Height = (int)Math.Round((double)mSG_OLD.CellHeight / 15.0);
				((Control)TEXT_OLD).Visible = true;
				((TextBoxBase)TEXT_OLD).ReadOnly = false;
				switch (MSG_OLD.Col)
				{
				case 0:
				case 1:
					((TextBoxBase)TEXT_OLD).MaxLength = 5;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_OLD).MaxLength = 50;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_OLD).MaxLength = 6;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0");
					break;
				case 7:
				case 9:
				case 10:
					((TextBoxBase)TEXT_OLD).MaxLength = 10;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0.00");
					break;
				case 4:
				case 5:
				case 6:
				case 8:
					((TextBoxBase)TEXT_OLD).MaxLength = 10;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0.000");
					break;
				}
				mSG_OLD = null;
				((TextBoxBase)TEXT_OLD).SelectAll();
			}
		}
	}

	private void MSG_OLD_LeaveCell(object sender, EventArgs e)
	{
		if (!MsgClearIdtl && MSG_OLD.Row != 0 && MSG_OLD[MSG_OLD.Col] != 0 && ((Control)TEXT_OLD).Visible)
		{
			AxMSFlexGrid mSG_OLD = MSG_OLD;
			switch (MSG_OLD.Col)
			{
			case 0:
			case 1:
			case 2:
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = TEXT_OLD.Text;
				break;
			case 3:
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0");
				CommPassTotal_Old(mSG_OLD.Row);
				break;
			case 7:
			case 9:
			case 10:
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				CommPassTotal_Old(mSG_OLD.Row);
				break;
			case 4:
			case 5:
			case 6:
			case 8:
				mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.000");
				CommPassTotal_Old(mSG_OLD.Row);
				break;
			}
			mSG_OLD = null;
		}
	}

	private void CommPassTotal_Old(int CRow)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		if (Conversion.Val(mSG_OLD[CRow, 4]) != Conversion.Val(mSG_OLD[CRow, 12]))
		{
			mSG_OLD[CRow, 12] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 4]), "0.000");
			mSG_OLD[CRow, 6] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 4]) - Conversion.Val(mSG_OLD[CRow, 5])), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 5]) != Conversion.Val(mSG_OLD[CRow, 13]))
		{
			mSG_OLD[CRow, 13] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 5]), "0.000");
			mSG_OLD[CRow, 6] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 4]) - Conversion.Val(mSG_OLD[CRow, 5])), "0.000");
		}
		if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 8]) == 0.0)
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]) != 0.0)
		{
			mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 9]), 0), "0.00");
		}
		if (((Conversion.Val(mSG_OLD[CRow, 10]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 8]) != 0.0)) && mSG_OLD.Col == 10)
		{
			mSG_OLD[CRow, 9] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[CRow, 8])), "0.00");
			mSG_OLD[CRow, 10] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
		}
		BILL_TOTAL();
		mSG_OLD = null;
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 25;
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
			mSG_IDTL[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "Weight";
			mSG_IDTL[12] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "Con%";
			mSG_IDTL[13] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[13] = 3;
			mSG_IDTL[0, 13] = "P/W";
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "Rate";
			mSG_IDTL[15] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "ItAmt";
			mSG_IDTL[16] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "LbrRate";
			mSG_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "LbrAmt";
			mSG_IDTL[18] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "NetAmt";
			mSG_IDTL[19] = 0;
			mSG_IDTL[0, 19] = "ConWt";
			mSG_IDTL[20] = 0;
			mSG_IDTL[0, 20] = "KrWt";
			mSG_IDTL[21] = 0;
			mSG_IDTL[0, 21] = "KrConWt";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "ItType";
			mSG_IDTL[23] = 0;
			mSG_IDTL[0, 23] = "RowSrNo";
			mSG_IDTL[24] = 0;
			mSG_IDTL[0, 24] = "OldKrWt";
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
		mSG_IDTL[mSG_IDTL.Row, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 50]));
		checked
		{
			if (mSG_IDTL.Row > 1)
			{
				DataView dataView = new DataView(DC_Main.RsClIdtl);
				if (dataView.Count > 0)
				{
					int num = mSG_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NEW_NAME = '" + mSG_IDTL[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG_IDTL[mSG_IDTL.Row, DC_Main.M] = mSG_IDTL[mSG_IDTL.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG_IDTL = null;
		}
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
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Invalid comparison between Unknown and I4
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Invalid comparison between Unknown and I4
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Invalid comparison between Unknown and I4
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Invalid comparison between Unknown and I4
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0241: Invalid comparison between Unknown and I4
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0703: Unknown result type (might be due to invalid IL or missing references)
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
				if (mSG_IDTL.Col < 18)
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
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.00");
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
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 14]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 18:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 18] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
				case 13:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 12:
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 11:
				case 19:
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
			case 13:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 12:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 11:
			case 19:
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
		if (Conversion.Val(mSG_IDTL[CRow, 20]) != Conversion.Val(mSG_IDTL[CRow, 24]))
		{
			mSG_IDTL[CRow, 24] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 20]), "0.000");
			mSG_IDTL[CRow, 11] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 20]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
		{
			mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 19] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
		{
			mSG_IDTL[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 20]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 21] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 13], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 11]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 13], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 14])))) != 0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0)
		{
			if (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0)
			{
				mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.00");
			}
			else
			{
				mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
			}
		}
		if (Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17])), "0.00");
		}
		checked
		{
			int num = mSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			double num2 = default(double);
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			while (DC_Main.M <= num)
			{
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 19]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 21]);
				if (Operators.CompareString(mSG_IDTL[DC_Main.M, 1], "HM", false) == 0)
				{
					if (Conversion.Val(mSG_IDTL[DC_Main.M, 18]) != 0.0)
					{
						MSG[MSG.Row, 32] = Strings.Format((object)Conversion.Val(mSG_IDTL[DC_Main.M, 18]), "0.00");
					}
					num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
				}
				else
				{
					num5 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
				}
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 11] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 12] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 11])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 35] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 36] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 35])), "0.000");
			}
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 25] = Strings.Format((object)num5, "0.00");
			}
			else if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
			{
				MSG[MSG.Row, 25] = "";
			}
			double num6 = default(double);
			if (num6 != 0.0)
			{
				MSG[MSG.Row, 44] = Strings.Format((object)num6, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 12] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - num2), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num7 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num7; i++)
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
						DtIdtl.Rows[i][11] = mSG_IDTL[CRow, 11];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][21] = mSG_IDTL[CRow, 21];
						DtIdtl.Rows[i][22] = mSG_IDTL[CRow, 22];
						DtIdtl.Rows[i][23] = mSG_IDTL[CRow, 23];
						DtIdtl.Rows[i][24] = mSG_IDTL[CRow, 24];
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
					dr[11] = mSG_IDTL[CRow, 11];
					dr[20] = mSG_IDTL[CRow, 20];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[17] = mSG_IDTL[CRow, 17];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[21] = mSG_IDTL[CRow, 21];
					dr[22] = mSG_IDTL[CRow, 22];
					dr[23] = mSG_IDTL[CRow, 23];
					dr[24] = mSG_IDTL[CRow, 24];
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
		mSG.Cols = 92;
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
			mSG[2] = (int)Math.Round(850.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[3] = (int)Math.Round(900.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Counter";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG[4] = (int)Math.Round(1000.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			else
			{
				mSG[4] = 0;
			}
			mSG[5] = (int)Math.Round(1300.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Design";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
			{
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "Size";
			}
			else
			{
				mSG[6] = (int)Math.Round(800.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "Size";
			}
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "HuId";
			mSG[8] = (int)Math.Round(800.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "BagWt";
			mSG[9] = (int)Math.Round(700.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Pcs";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "GrWt";
			mSG[11] = (int)Math.Round(800.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "LsWt";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "NetWt";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrOthWt";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrNwt";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrGht%";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "KrGht";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "KrTouch";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrWst%";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "KrFine";
			mSG[13] = (int)Math.Round(750.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Ght%";
			mSG[14] = (int)Math.Round(850.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "GhtWt";
			mSG[15] = (int)Math.Round(850.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "Touch";
			mSG[16] = (int)Math.Round(850.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "West%";
			mSG[17] = (int)Math.Round(1000.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "Fine";
			mSG[20] = (int)Math.Round(800.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Lbr%";
			mSG[21] = (int)Math.Round(750.0 * ColCon);
			mSG[21] = 3;
			mSG[0, 21] = "LType";
			mSG[22] = (int)Math.Round(900.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "LbrRate";
			mSG[23] = (int)Math.Round(950.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "LbrAmt";
			mSG[24] = (int)Math.Round(950.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "GhtAmt";
			mSG[25] = (int)Math.Round(900.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "OthAmt";
			mSG[33] = (int)Math.Round(950.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "PrCost";
			mSG[42] = (int)Math.Round(0.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "KrLRate";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "KrLAmt";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "KrOthAmt";
			mSG[18] = (int)Math.Round(1000.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "ItRate";
			mSG[19] = (int)Math.Round(1100.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "ItAmt";
			mSG[46] = (int)Math.Round(0.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "TagCost";
			mSG[47] = (int)Math.Round(0.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "Margin";
			mSG[26] = (int)Math.Round(900.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Mrp";
			mSG[27] = (int)Math.Round(850.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "LDisc%";
			mSG[28] = (int)Math.Round(950.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "LDiscAmt";
			mSG[29] = (int)Math.Round(1100.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "TotAmt";
			mSG[30] = (int)Math.Round(600.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Tax%";
			mSG[31] = (int)Math.Round(1100.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "NetAmt";
			mSG[32] = (int)Math.Round(1000.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "HmAmt";
			mSG[48] = (int)Math.Round(0.0 * ColCon);
			mSG[48] = 3;
			mSG[0, 48] = "Image";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrCode";
			mSG[49] = 0;
			mSG[50] = 0;
			mSG[51] = 0;
			mSG[52] = 0;
			mSG[53] = 0;
			mSG[54] = 0;
			mSG[45] = 0;
			mSG[55] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
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
			mSG[74] = 0;
			mSG[72] = 0;
			mSG[73] = 0;
			mSG[75] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			mSG[78] = 0;
			mSG[79] = 0;
			mSG[80] = 0;
			mSG[81] = 0;
			mSG[82] = 0;
			mSG[83] = 0;
			mSG[84] = 0;
			mSG[85] = 0;
			mSG[86] = 0;
			mSG[87] = 0;
			mSG[88] = 0;
			mSG[89] = 0;
			mSG[90] = 0;
			mSG[91] = 0;
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
			MsgLastCol = 32;
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
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 5] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.00");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.00");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.00");
					mSG_TOT[0, 46] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 46]) + Conversion.Val(MSG[DC_Main.M, 46]))), "0.00");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.000");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 31]) + Conversion.Val(MSG[DC_Main.M, 31]))), "0.00");
					mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.00");
					mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.000");
					mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.000");
					mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.000");
					mSG_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 41]) + Conversion.Val(MSG[DC_Main.M, 41]))), "0.000");
					mSG_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 43]) + Conversion.Val(MSG[DC_Main.M, 43]))), "0.00");
					mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.00");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 21] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 50] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 50] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 50]) + 1.0);
		}
		mSG[mSG.Row, 56] = "A";
		mSG[mSG.Row, 48] = "N";
		mSG[mSG.Row, 91] = "N";
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK014NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK017NSAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0))
		{
			mSG[mSG.Row, 30] = "3.00";
		}
		mSG[mSG.Row, 86] = "N";
		mSG[mSG.Row, 87] = "N";
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
				if ((mSG.Col != 3) & (mSG.Col != 5) & (mSG.Col != 6))
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
			case 34:
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
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 21:
			case 48:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 9:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 13:
			case 15:
			case 16:
			case 20:
			case 39:
			case 40:
			case 47:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 26:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0))
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 18:
			case 19:
			case 22:
			case 23:
			case 24:
			case 25:
			case 27:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 42:
			case 43:
			case 44:
			case 46:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 10:
			case 11:
			case 12:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0))
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 8:
			case 14:
			case 17:
			case 35:
			case 36:
			case 37:
			case 38:
			case 41:
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
		if (UpDown || MsgClear || MSG.Row == 0 || MSG[MSG.Col] == 0 || !((Control)TEXT_ENTRY).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		switch (MSG.Col)
		{
		case 2:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 5:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if (Operators.CompareString(MSG[MSG.Row, 1], "", false) == 0)
			{
				if (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
		case 3:
		case 4:
		case 6:
		case 7:
		case 34:
		case 48:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 21:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			CommPassTotal();
			break;
		case 9:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			CommPassTotal();
			break;
		case 13:
		case 15:
		case 16:
		case 20:
		case 39:
		case 40:
		case 47:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 29:
			CommPassTotal();
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			break;
		case 18:
		case 19:
		case 22:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 30:
		case 31:
		case 32:
		case 33:
		case 42:
		case 43:
		case 44:
		case 46:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 11:
		case 35:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 8:
		case 10:
		case 12:
		case 14:
		case 17:
		case 36:
		case 37:
		case 38:
		case 41:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal();
			break;
		}
		mSG = null;
	}

	private void CommPassTotal()
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int digits = default(int);
		int digits2 = default(int);
		double num5 = default(double);
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
				case 17089:
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
							goto IL_000f;
						case 4:
							goto IL_0014;
						case 5:
							goto IL_002f;
						case 6:
							goto IL_0033;
						case 7:
						case 8:
							goto IL_003b;
						case 9:
							goto IL_0045;
						case 10:
							goto IL_0061;
						case 11:
							goto IL_0087;
						case 13:
						case 14:
						case 15:
							goto IL_00bf;
						case 16:
							goto IL_00fa;
						case 17:
							goto IL_0114;
						case 18:
							goto IL_012e;
						case 19:
							goto IL_0166;
						case 20:
							goto IL_01b4;
						case 21:
							goto IL_0202;
						case 22:
						case 23:
							goto IL_021d;
						case 24:
							goto IL_0248;
						case 25:
							goto IL_029a;
						case 26:
							goto IL_02e7;
						case 27:
							goto IL_0301;
						case 28:
						case 29:
						case 30:
							goto IL_0353;
						case 31:
							goto IL_036a;
						case 32:
							goto IL_03a5;
						case 33:
							goto IL_03dd;
						case 34:
						case 35:
						case 36:
							goto IL_042a;
						case 37:
							goto IL_0489;
						case 38:
							goto IL_04a3;
						case 39:
							goto IL_04db;
						case 40:
							goto IL_0533;
						case 41:
						case 42:
							goto IL_054e;
						case 43:
							goto IL_0589;
						case 44:
							goto IL_05a3;
						case 45:
							goto IL_05bd;
						case 46:
							goto IL_060d;
						case 47:
						case 48:
							goto IL_0667;
						case 49:
						case 50:
							goto IL_06a1;
						case 51:
							goto IL_06f4;
						case 52:
							goto IL_071e;
						case 53:
						case 54:
							goto IL_073a;
						case 55:
						case 56:
							goto IL_0790;
						case 57:
							goto IL_07cb;
						case 58:
							goto IL_07e5;
						case 59:
							goto IL_07ff;
						case 60:
							goto IL_0837;
						case 61:
							goto IL_08a0;
						case 63:
							goto IL_0928;
						case 62:
						case 64:
						case 65:
						case 66:
							goto IL_0963;
						case 67:
							goto IL_099e;
						case 68:
							goto IL_09b8;
						case 69:
							goto IL_09f0;
						case 70:
							goto IL_0a59;
						case 71:
						case 72:
						case 73:
							goto IL_0ae1;
						case 74:
							goto IL_0b1c;
						case 75:
							goto IL_0b36;
						case 76:
							goto IL_0b6e;
						case 77:
							goto IL_0bd7;
						case 78:
						case 79:
						case 80:
							goto IL_0c5f;
						case 81:
							goto IL_0c9e;
						case 82:
						case 83:
							goto IL_0cee;
						case 84:
							goto IL_0d3e;
						case 85:
						case 86:
							goto IL_0d8e;
						case 87:
							goto IL_0dc9;
						case 88:
							goto IL_0e01;
						case 89:
							goto IL_0e6a;
						case 91:
							goto IL_0ef2;
						case 90:
						case 92:
						case 93:
						case 94:
							goto IL_0f2d;
						case 95:
							goto IL_0f68;
						case 96:
							goto IL_0fa0;
						case 97:
							goto IL_1009;
						case 98:
						case 99:
						case 100:
							goto IL_1091;
						case 101:
							goto IL_10cc;
						case 102:
							goto IL_1104;
						case 103:
							goto IL_116d;
						case 104:
						case 105:
						case 106:
							goto IL_11f5;
						case 107:
							goto IL_1234;
						case 108:
						case 109:
							goto IL_1284;
						case 110:
							goto IL_1292;
						case 111:
							goto IL_12b1;
						case 112:
							goto IL_12c9;
						case 113:
							goto IL_1332;
						case 114:
							goto IL_13ac;
						case 115:
							goto IL_13d1;
						case 117:
							goto IL_1416;
						case 120:
							goto IL_1435;
						case 123:
							goto IL_1453;
						case 124:
							goto IL_146f;
						case 126:
							goto IL_148d;
						case 116:
						case 118:
						case 119:
						case 121:
						case 122:
						case 125:
						case 127:
						case 128:
							goto IL_14a8;
						case 129:
							goto IL_1520;
						case 130:
							goto IL_155b;
						case 131:
							goto IL_1579;
						case 133:
							goto IL_15c7;
						case 135:
							goto IL_1624;
						case 137:
							goto IL_168e;
						case 139:
							goto IL_16f8;
						case 140:
							goto IL_1717;
						case 142:
							goto IL_175f;
						case 132:
						case 134:
						case 136:
						case 138:
						case 141:
						case 143:
						case 144:
						case 145:
							goto IL_17bd;
						case 146:
						case 147:
							goto IL_17db;
						case 148:
							goto IL_17f5;
						case 149:
							goto IL_18b3;
						case 151:
							goto IL_1901;
						case 153:
							goto IL_195d;
						case 155:
							goto IL_19c6;
						case 157:
							goto IL_1a2c;
						case 150:
						case 152:
						case 154:
						case 156:
						case 158:
						case 159:
							goto IL_1a88;
						case 160:
						case 161:
						case 162:
							goto IL_1ac7;
						case 163:
							goto IL_1b29;
						case 164:
							goto IL_1b64;
						case 165:
							goto IL_1bc9;
						case 166:
							goto IL_1bea;
						case 167:
							goto IL_1c16;
						case 168:
							goto IL_1c32;
						case 169:
							goto IL_1c4e;
						case 170:
						case 171:
						case 172:
						case 173:
							goto IL_1c70;
						case 174:
							goto IL_1c94;
						case 175:
							goto IL_1cc9;
						case 176:
							goto IL_1cf0;
						case 177:
						case 178:
						case 179:
							goto IL_1d11;
						case 180:
							goto IL_1d73;
						case 181:
							goto IL_1daf;
						case 183:
							goto IL_1e12;
						case 185:
							goto IL_1e70;
						case 186:
							goto IL_1e8f;
						case 188:
							goto IL_1eeb;
						case 191:
							goto IL_1f60;
						case 193:
							goto IL_1fde;
						case 195:
							goto IL_2039;
						case 182:
						case 184:
						case 187:
						case 189:
						case 190:
						case 192:
						case 194:
						case 196:
						case 197:
							goto IL_20aa;
						case 198:
							goto IL_20e5;
						case 200:
							goto IL_2108;
						case 201:
							goto IL_214f;
						case 203:
							goto IL_219d;
						case 205:
							goto IL_21fe;
						case 206:
							goto IL_221d;
						case 208:
							goto IL_227c;
						case 211:
							goto IL_22f4;
						case 213:
							goto IL_2372;
						case 202:
						case 204:
						case 207:
						case 209:
						case 210:
						case 212:
						case 214:
						case 215:
							goto IL_23d0;
						case 199:
						case 216:
						case 217:
						case 218:
							goto IL_240e;
						case 219:
							goto IL_2461;
						case 220:
						case 221:
							goto IL_24c8;
						case 222:
							goto IL_24f4;
						case 223:
						case 224:
							goto IL_2547;
						case 225:
							goto IL_2579;
						case 226:
							goto IL_25cf;
						case 227:
							goto IL_2634;
						case 229:
							goto IL_2689;
						case 228:
						case 230:
						case 231:
							goto IL_26c5;
						case 232:
							goto IL_26f4;
						case 233:
						case 234:
							goto IL_2761;
						case 235:
							goto IL_277d;
						case 236:
							goto IL_2799;
						case 237:
							goto IL_27b5;
						case 238:
							goto IL_27d1;
						case 240:
							goto IL_27f4;
						case 241:
							goto IL_280e;
						case 242:
							goto IL_2844;
						case 243:
						case 244:
							goto IL_2862;
						case 245:
							goto IL_2894;
						case 246:
							goto IL_28c3;
						case 247:
							goto IL_2925;
						case 248:
							goto IL_299d;
						case 249:
							goto IL_29cc;
						case 254:
							goto IL_2a34;
						case 255:
							goto IL_2a66;
						case 256:
							goto IL_2a9f;
						case 257:
							goto IL_2ae8;
						case 261:
							goto IL_2b55;
						case 262:
							goto IL_2b9e;
						case 250:
						case 251:
						case 252:
						case 253:
						case 258:
						case 259:
						case 260:
						case 263:
						case 264:
						case 265:
						case 266:
							goto IL_2c04;
						case 267:
							goto IL_2c36;
						case 268:
							goto IL_2c52;
						case 269:
							goto IL_2c6e;
						case 271:
						case 272:
							goto IL_2c94;
						case 273:
							goto IL_2ce1;
						case 275:
							goto IL_2d2f;
						case 277:
							goto IL_2d90;
						case 279:
							goto IL_2dfe;
						case 281:
							goto IL_2e6c;
						case 282:
							goto IL_2e8b;
						case 284:
							goto IL_2ed7;
						case 274:
						case 276:
						case 278:
						case 280:
						case 283:
						case 285:
						case 286:
						case 287:
							goto IL_2f39;
						case 288:
						case 289:
							goto IL_2f76;
						case 290:
							goto IL_2fb4;
						case 291:
							goto IL_300b;
						case 293:
							goto IL_3059;
						case 295:
							goto IL_30ba;
						case 296:
							goto IL_30d9;
						case 298:
							goto IL_3138;
						case 301:
							goto IL_31b0;
						case 303:
							goto IL_322e;
						case 292:
						case 294:
						case 297:
						case 299:
						case 300:
						case 302:
						case 304:
						case 305:
							goto IL_328c;
						case 306:
							goto IL_32c7;
						case 307:
							goto IL_331a;
						case 308:
						case 309:
						case 310:
						case 311:
						case 312:
							goto IL_337d;
						case 313:
							goto IL_33a7;
						case 314:
						case 315:
							goto IL_3426;
						case 316:
							goto IL_3452;
						case 239:
						case 317:
						case 318:
						case 319:
							goto IL_34d2;
						case 320:
							goto IL_34fe;
						case 321:
						case 322:
							goto IL_353b;
						case 323:
							goto IL_356d;
						case 324:
							goto IL_359a;
						case 325:
							goto IL_35b6;
						case 326:
							goto IL_3621;
						case 327:
							goto IL_3671;
						case 328:
						case 329:
							goto IL_36e0;
						case 330:
							goto IL_3712;
						case 331:
							goto IL_3760;
						case 333:
							goto IL_37b7;
						case 334:
							goto IL_3808;
						case 335:
							goto IL_3827;
						case 337:
							goto IL_387c;
						case 340:
							goto IL_38ea;
						case 341:
							goto IL_3938;
						case 343:
							goto IL_3999;
						case 344:
							goto IL_39e7;
						case 346:
							goto IL_3a3c;
						case 332:
						case 336:
						case 338:
						case 339:
						case 342:
						case 345:
						case 347:
						case 348:
						case 349:
							goto IL_3aa6;
						case 350:
							goto IL_3afc;
						case 351:
							goto IL_3b28;
						case 352:
						case 353:
							goto IL_3b85;
						case 354:
							goto IL_3b9f;
						case 355:
							goto IL_3bfa;
						case 356:
							goto IL_3c35;
						case 357:
						case 358:
						case 359:
							goto IL_3c55;
						case 362:
							goto IL_3c96;
						case 360:
						case 361:
						case 363:
						case 364:
							goto IL_3cd3;
						case 365:
							goto IL_3cd6;
						case 366:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 12:
						case 270:
						case 367:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_3c96:
					num2 = 362;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 29]), "0.00");
					goto IL_3cd3;
					IL_3cd3:
					val = null;
					goto IL_3cd6;
					IL_3c55:
					num2 = 359;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_3cd3;
					IL_3cd6:
					num2 = 365;
					MSG_TOT_FILL();
					break;
					IL_000b:
					num2 = 2;
					digits = 0;
					goto IL_000f;
					IL_000f:
					num2 = 3;
					digits2 = 0;
					goto IL_0014;
					IL_0014:
					num2 = 4;
					if (Operators.CompareString(DC_Main.MsAllRofRemove, "Y", false) == 0)
					{
						goto IL_002f;
					}
					goto IL_003b;
					IL_002f:
					num2 = 5;
					digits = 2;
					goto IL_0033;
					IL_0033:
					num2 = 6;
					digits2 = 2;
					goto IL_003b;
					IL_003b:
					num2 = 8;
					val = MSG;
					goto IL_0045;
					IL_0045:
					num2 = 9;
					if (Operators.CompareString(DC_Main.MsNegativeStkSale, "N", false) == 0)
					{
						goto IL_0061;
					}
					goto IL_00bf;
					IL_0061:
					num2 = 10;
					if (Conversion.Val(val[val.Row, 10]) > CurItGwtStk)
					{
						goto IL_0087;
					}
					goto IL_00bf;
					IL_0087:
					num2 = 11;
					Interaction.MsgBox((object)("Negative Stock is Not Allow Curent Stock = " + Strings.Format((object)CurItGwtStk, "0.000") + " "), (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_00bf:
					num2 = 15;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 59]))
					{
						goto IL_00fa;
					}
					goto IL_021d;
					IL_00fa:
					num2 = 16;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_0114;
					IL_0114:
					num2 = 17;
					val[val.Row, 69] = Conversions.ToString(0);
					goto IL_012e;
					IL_012e:
					num2 = 18;
					val[val.Row, 59] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_0166;
					IL_0166:
					num2 = 19;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_01b4;
					IL_01b4:
					num2 = 20;
					val[val.Row, 36] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 35])), "0.000");
					goto IL_0202;
					IL_0202:
					num2 = 21;
					val[val.Row, 86] = "N";
					goto IL_021d;
					IL_021d:
					num2 = 23;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[8] != 0))
					{
						goto IL_0248;
					}
					goto IL_0353;
					IL_0248:
					num2 = 24;
					if ((Conversion.Val(val[val.Row, 8]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_029a;
					}
					goto IL_0353;
					IL_029a:
					num2 = 25;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_02e7;
					IL_02e7:
					num2 = 26;
					val[val.Row, 77] = Conversions.ToString(0);
					goto IL_0301;
					IL_0301:
					num2 = 27;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_0353;
					IL_0353:
					num2 = 30;
					if (val.Col == 11)
					{
						goto IL_036a;
					}
					goto IL_042a;
					IL_036a:
					num2 = 31;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 77]))
					{
						goto IL_03a5;
					}
					goto IL_042a;
					IL_03a5:
					num2 = 32;
					val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_03dd;
					IL_03dd:
					num2 = 33;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_042a;
					IL_042a:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 61])) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0489;
					}
					goto IL_054e;
					IL_0489:
					num2 = 37;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_04a3;
					IL_04a3:
					num2 = 38;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.00");
					goto IL_04db;
					IL_04db:
					num2 = 39;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 13]) / 100.0), "0.000");
					goto IL_0533;
					IL_0533:
					num2 = 40;
					val[val.Row, 86] = "N";
					goto IL_054e;
					IL_054e:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_0589;
					}
					goto IL_06a1;
					IL_0589:
					num2 = 43;
					val[val.Row, 24] = Conversions.ToString(0);
					goto IL_05a3;
					IL_05a3:
					num2 = 44;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_05bd;
					IL_05bd:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_060d;
					}
					goto IL_0667;
					IL_060d:
					num2 = 46;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 13]) / 100.0), "0.000");
					goto IL_0667;
					IL_0667:
					num2 = 48;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
					goto IL_06a1;
					IL_06a1:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_06f4;
					}
					goto IL_0790;
					IL_06f4:
					num2 = 51;
					if (Conversion.Val((object)val[24]) >= 0.0)
					{
						goto IL_071e;
					}
					goto IL_073a;
					IL_071e:
					num2 = 52;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_073a;
					IL_073a:
					num2 = 54;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_0790;
					IL_0790:
					num2 = 56;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_07cb;
					}
					goto IL_0963;
					IL_07cb:
					num2 = 57;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_07e5;
					IL_07e5:
					num2 = 58;
					val[val.Row, 69] = Conversions.ToString(0);
					goto IL_07ff;
					IL_07ff:
					num2 = 59;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_0837;
					IL_0837:
					num2 = 60;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_08a0;
					}
					goto IL_0928;
					IL_08a0:
					num2 = 61;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_0963;
					IL_0928:
					num2 = 63;
					val[val.Row, 17] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_0963;
					IL_0963:
					num2 = 66;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_099e;
					}
					goto IL_0ae1;
					IL_099e:
					num2 = 67;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_09b8;
					IL_09b8:
					num2 = 68;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_09f0;
					IL_09f0:
					num2 = 69;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0a59;
					}
					goto IL_0ae1;
					IL_0a59:
					num2 = 70;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_0ae1;
					IL_0ae1:
					num2 = 73;
					if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_0b1c;
					}
					goto IL_0c5f;
					IL_0b1c:
					num2 = 74;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_0b36;
					IL_0b36:
					num2 = 75;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_0b6e;
					IL_0b6e:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0bd7;
					}
					goto IL_0c5f;
					IL_0bd7:
					num2 = 77;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_0c5f;
					IL_0c5f:
					num2 = 80;
					if (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) == 0.0)
					{
						goto IL_0c9e;
					}
					goto IL_0cee;
					IL_0c9e:
					num2 = 81;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_0cee;
					IL_0cee:
					num2 = 83;
					if ((Conversion.Val(val[val.Row, 35]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_0d3e;
					}
					goto IL_0d8e;
					IL_0d3e:
					num2 = 84;
					val[val.Row, 36] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 35])), "0.000");
					goto IL_0d8e;
					IL_0d8e:
					num2 = 86;
					if (Conversion.Val(val[val.Row, 36]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_0dc9;
					}
					goto IL_0f2d;
					IL_0dc9:
					num2 = 87;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.000");
					goto IL_0e01;
					IL_0e01:
					num2 = 88;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_0e6a;
					}
					goto IL_0ef2;
					IL_0e6a:
					num2 = 89;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_0f2d;
					IL_0ef2:
					num2 = 91;
					val[val.Row, 41] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.000");
					goto IL_0f2d;
					IL_0f2d:
					num2 = 94;
					if (Conversion.Val(val[val.Row, 39]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_0f68;
					}
					goto IL_1091;
					IL_0f68:
					num2 = 95;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 39]), "0.00");
					goto IL_0fa0;
					IL_0fa0:
					num2 = 96;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_1009;
					}
					goto IL_1091;
					IL_1009:
					num2 = 97;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_1091;
					IL_1091:
					num2 = 100;
					if (Conversion.Val(val[val.Row, 40]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_10cc;
					}
					goto IL_11f5;
					IL_10cc:
					num2 = 101;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 40]), "0.00");
					goto IL_1104;
					IL_1104:
					num2 = 102;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_116d;
					}
					goto IL_11f5;
					IL_116d:
					num2 = 103;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_11f5;
					IL_11f5:
					num2 = 106;
					if (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) == 0.0)
					{
						goto IL_1234;
					}
					goto IL_1284;
					IL_1234:
					num2 = 107;
					val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])), "0.000");
					goto IL_1284;
					IL_1284:
					num2 = 109;
					num5 = 0.0;
					goto IL_1292;
					IL_1292:
					num2 = 110;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_12b1;
					}
					goto IL_1453;
					IL_12b1:
					num2 = 111;
					if (val[17] != 0)
					{
						goto IL_12c9;
					}
					goto IL_1435;
					IL_12c9:
					num2 = 112;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_1332;
					}
					goto IL_1416;
					IL_1332:
					num2 = 113;
					num5 = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000"));
					goto IL_13ac;
					IL_13ac:
					num2 = 114;
					val[val.Row, 17] = Strings.Format((object)num5, "0.000");
					goto IL_13d1;
					IL_13d1:
					num2 = 115;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_14a8;
					IL_1416:
					num2 = 117;
					num5 = Conversion.Val(val[val.Row, 12]);
					goto IL_14a8;
					IL_1435:
					num2 = 120;
					num5 = Conversion.Val(val[val.Row, 12]);
					goto IL_14a8;
					IL_1453:
					num2 = 123;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0)
					{
						goto IL_146f;
					}
					goto IL_148d;
					IL_146f:
					num2 = 124;
					num5 = Conversion.Val(val[val.Row, 10]);
					goto IL_14a8;
					IL_148d:
					num2 = 126;
					num5 = Conversion.Val(val[val.Row, 12]);
					goto IL_14a8;
					IL_14a8:
					num2 = 128;
					if ((Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 75])) & (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_1520;
					}
					goto IL_17db;
					IL_1520:
					num2 = 129;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_155b;
					IL_155b:
					num2 = 130;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_1579;
					IL_1579:
					num2 = 131;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_1624;
					case "K":
						goto IL_168e;
					default:
						goto IL_16f8;
					}
					goto IL_15c7;
					IL_16f8:
					num2 = 139;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_1717;
					}
					goto IL_175f;
					IL_1717:
					num2 = 140;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_17bd;
					IL_175f:
					num2 = 142;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 14])) * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_17bd;
					IL_168e:
					num2 = 137;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 18]) / 1000.0), digits), "0.00");
					goto IL_17bd;
					IL_1624:
					num2 = 135;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 18]) / 10.0), digits), "0.00");
					goto IL_17bd;
					IL_15c7:
					num2 = 133;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_17bd;
					IL_17bd:
					num2 = 145;
					val[val.Row, 86] = "N";
					goto IL_17db;
					IL_17db:
					num2 = 147;
					if (val.Col == 19)
					{
						goto IL_17f5;
					}
					goto IL_1ac7;
					IL_17f5:
					num2 = 148;
					if ((Conversion.Val(val[val.Row, 18]) == 0.0) | ((Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 75])) & (Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 9]) != 0.0)))
					{
						goto IL_18b3;
					}
					goto IL_1ac7;
					IL_18b3:
					num2 = 149;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_195d;
					case "K":
						goto IL_19c6;
					default:
						goto IL_1a2c;
					}
					goto IL_1901;
					IL_1a2c:
					num2 = 157;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5 + Conversion.Val(val[val.Row, 14]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1a88;
					IL_19c6:
					num2 = 155;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 14])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1a88;
					IL_195d:
					num2 = 153;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 14])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1a88;
					IL_1901:
					num2 = 151;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 9]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1a88;
					IL_1a88:
					num2 = 159;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_1ac7;
					IL_1ac7:
					num2 = 162;
					if ((Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 76])) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_1b29;
					}
					goto IL_1c70;
					IL_1b29:
					num2 = 163;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_1b64;
					IL_1b64:
					num2 = 164;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * Conversion.Val(val[val.Row, 20]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1bc9;
					IL_1bc9:
					num2 = 165;
					if (0u - ((val.Col == 20) ? 1u : 0u) != 0)
					{
						goto IL_1bea;
					}
					goto IL_1c70;
					IL_1bea:
					num2 = 166;
					if (Conversion.Val(val[val.Row, 20]) == 0.0)
					{
						goto IL_1c16;
					}
					goto IL_1c70;
					IL_1c16:
					num2 = 167;
					val[val.Row, 76] = "";
					goto IL_1c32;
					IL_1c32:
					num2 = 168;
					val[val.Row, 22] = "";
					goto IL_1c4e;
					IL_1c4e:
					num2 = 169;
					val[val.Row, 23] = "";
					goto IL_1c70;
					IL_1c70:
					num2 = 173;
					if ((val.Col == 21) & (val[21] != 0))
					{
						goto IL_1c94;
					}
					goto IL_1d11;
					IL_1c94:
					num2 = 174;
					if (Operators.CompareString(val[val.Row, 21], val[val.Row, 78], false) != 0)
					{
						goto IL_1cc9;
					}
					goto IL_1d11;
					IL_1cc9:
					num2 = 175;
					val[val.Row, 78] = val[val.Row, 21];
					goto IL_1cf0;
					IL_1cf0:
					num2 = 176;
					val[val.Row, 69] = Conversions.ToString(0);
					goto IL_1d11;
					IL_1d11:
					num2 = 179;
					if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 69]) != Conversion.Val(val[val.Row, 22])))
					{
						goto IL_1d73;
					}
					goto IL_2108;
					IL_1d73:
					num2 = 180;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1daf;
					IL_1daf:
					num2 = 181;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_1e70;
					case "K":
						goto IL_1f60;
					case "G":
						goto IL_1fde;
					default:
						goto IL_2039;
					}
					goto IL_1e12;
					IL_2039:
					num2 = 195;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_20aa;
					IL_1fde:
					num2 = 193;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_20aa;
					IL_1f60:
					num2 = 191;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 22]) / 1000.0), digits2), "0.00");
					goto IL_20aa;
					IL_1e70:
					num2 = 185;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1e8f;
					}
					goto IL_1eeb;
					IL_1e8f:
					num2 = 186;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_20aa;
					IL_1eeb:
					num2 = 188;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_20aa;
					IL_1e12:
					num2 = 183;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_20aa;
					IL_20aa:
					num2 = 197;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_20e5;
					IL_20e5:
					num2 = 198;
					val[val.Row, 86] = "N";
					goto IL_240e;
					IL_2108:
					num2 = 200;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
					{
						goto IL_214f;
					}
					goto IL_240e;
					IL_214f:
					num2 = 201;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_21fe;
					case "K":
						goto IL_22f4;
					default:
						goto IL_2372;
					}
					goto IL_219d;
					IL_2372:
					num2 = 213;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_23d0;
					IL_22f4:
					num2 = 211;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_23d0;
					IL_21fe:
					num2 = 205;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_221d;
					}
					goto IL_227c;
					IL_221d:
					num2 = 206;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_23d0;
					IL_227c:
					num2 = 208;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), DC_Main.MsLbrRof), "0.00");
					goto IL_23d0;
					IL_219d:
					num2 = 203;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_23d0;
					IL_23d0:
					num2 = 215;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_240e;
					IL_240e:
					num2 = 218;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_2461;
					}
					goto IL_24c8;
					IL_2461:
					num2 = 219;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) * Conversion.Val(val[val.Row, 27]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_24c8;
					IL_24c8:
					num2 = 221;
					if (Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_24f4;
					}
					goto IL_2547;
					IL_24f4:
					num2 = 222;
					val[val.Row, 33] = Strings.Format((object)(Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44])), "0.0");
					goto IL_2547;
					IL_2547:
					num2 = 224;
					if (Conversion.Val(val[val.Row, 26]) != 0.0)
					{
						goto IL_2579;
					}
					goto IL_27f4;
					IL_2579:
					num2 = 225;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_25cf;
					}
					goto IL_2689;
					IL_25cf:
					num2 = 226;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 26]) * Conversion.Val(val[val.Row, 27]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2634;
					IL_2634:
					num2 = 227;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_26c5;
					IL_2689:
					num2 = 229;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_26c5;
					IL_26c5:
					num2 = 231;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_26f4;
					}
					goto IL_2761;
					IL_26f4:
					num2 = 232;
					val[val.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) / (Conversion.Val(val[val.Row, 30]) + 100.0) * 100.0, 0), "0.00");
					goto IL_2761;
					IL_2761:
					num2 = 234;
					val[val.Row, 18] = "";
					goto IL_277d;
					IL_277d:
					num2 = 235;
					val[val.Row, 19] = "";
					goto IL_2799;
					IL_2799:
					num2 = 236;
					val[val.Row, 23] = "";
					goto IL_27b5;
					IL_27b5:
					num2 = 237;
					val[val.Row, 22] = "";
					goto IL_27d1;
					IL_27d1:
					num2 = 238;
					val[val.Row, 25] = "";
					goto IL_34d2;
					IL_27f4:
					num2 = 240;
					if (val.Col == 29)
					{
						goto IL_280e;
					}
					goto IL_337d;
					IL_280e:
					num2 = 241;
					if (Conversion.Val(val[val.Row, 29]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2844;
					}
					goto IL_2862;
					IL_2844:
					num2 = 242;
					val[val.Row, 86] = "N";
					goto IL_2862;
					IL_2862:
					num2 = 244;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_2894;
					}
					goto IL_2a34;
					IL_2894:
					num2 = 245;
					if (Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_28c3;
					}
					goto IL_2c04;
					IL_28c3:
					num2 = 246;
					if (Conversion.Val(TEXT_ENTRY.Text) < Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_2925;
					}
					goto IL_2c04;
					IL_2925:
					num2 = 247;
					val[val.Row, 28] = Strings.Format((object)(Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(TEXT_ENTRY.Text)), "0.00");
					goto IL_299d;
					IL_299d:
					num2 = 248;
					if (Conversion.Val(val[val.Row, 27]) != 0.0)
					{
						goto IL_29cc;
					}
					goto IL_2c04;
					IL_29cc:
					num2 = 249;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 28]) * 100.0 / Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2c04;
					IL_2a34:
					num2 = 254;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_2a66;
					}
					goto IL_2b55;
					IL_2a66:
					num2 = 255;
					if (Conversion.Val(val[val.Row, 29]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2a9f;
					}
					goto IL_2c04;
					IL_2a9f:
					num2 = 256;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]))
					{
						goto IL_2ae8;
					}
					goto IL_2c04;
					IL_2ae8:
					num2 = 257;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_2c04;
					IL_2b55:
					num2 = 261;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]))
					{
						goto IL_2b9e;
					}
					goto IL_2c04;
					IL_2b9e:
					num2 = 262;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_2c04;
					IL_2c04:
					num2 = 266;
					if (Conversion.Val(val[val.Row, 23]) <= 0.0)
					{
						goto IL_2c36;
					}
					goto IL_2f76;
					IL_2c36:
					num2 = 267;
					val[val.Row, 23] = "";
					goto IL_2c52;
					IL_2c52:
					num2 = 268;
					val[val.Row, 22] = "";
					goto IL_2c6e;
					IL_2c6e:
					num2 = 269;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM240NPPK", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_2c94;
					IL_2c94:
					num2 = 272;
					val[val.Row, 19] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25])), "0.00");
					goto IL_2ce1;
					IL_2ce1:
					num2 = 273;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_2d90;
					case "K":
						goto IL_2dfe;
					default:
						goto IL_2e6c;
					}
					goto IL_2d2f;
					IL_2e6c:
					num2 = 281;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_2e8b;
					}
					goto IL_2ed7;
					IL_2e8b:
					num2 = 282;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_2f39;
					IL_2ed7:
					num2 = 284;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 14])), DC_Main.MsItmRateRof), "0.00");
					goto IL_2f39;
					IL_2dfe:
					num2 = 279;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 14])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_2f39;
					IL_2d90:
					num2 = 277;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 14])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_2f39;
					IL_2d2f:
					num2 = 275;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsItmRateRof), "0.00");
					goto IL_2f39;
					IL_2f39:
					num2 = 287;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_2f76;
					IL_2f76:
					num2 = 289;
					if (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_2fb4;
					}
					goto IL_337d;
					IL_2fb4:
					num2 = 290;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_300b;
					}
					goto IL_337d;
					IL_300b:
					num2 = 291;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_30ba;
					case "K":
						goto IL_31b0;
					default:
						goto IL_322e;
					}
					goto IL_3059;
					IL_322e:
					num2 = 303;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_328c;
					IL_31b0:
					num2 = 301;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_328c;
					IL_30ba:
					num2 = 295;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_30d9;
					}
					goto IL_3138;
					IL_30d9:
					num2 = 296;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 12]), DC_Main.MsLbrRof), "0.00");
					goto IL_328c;
					IL_3138:
					num2 = 298;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), DC_Main.MsLbrRof), "0.00");
					goto IL_328c;
					IL_3059:
					num2 = 293;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_328c;
					IL_328c:
					num2 = 305;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_32c7;
					IL_32c7:
					num2 = 306;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_331a;
					}
					goto IL_337d;
					IL_331a:
					num2 = 307;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.000");
					goto IL_337d;
					IL_337d:
					num2 = 312;
					if (Operators.CompareString(val[val.Row, 86], "N", false) == 0)
					{
						goto IL_33a7;
					}
					goto IL_3426;
					IL_33a7:
					num2 = 313;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_3426;
					IL_3426:
					num2 = 315;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_3452;
					}
					goto IL_34d2;
					IL_3452:
					num2 = 316;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_34d2;
					IL_34d2:
					num2 = 319;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_34fe;
					}
					goto IL_353b;
					IL_34fe:
					num2 = 320;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 29]), "0.00");
					goto IL_353b;
					IL_353b:
					num2 = 322;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_356d;
					}
					goto IL_3c96;
					IL_356d:
					num2 = 323;
					if (Operators.CompareString(val[val.Row, 86], "N", false) == 0)
					{
						goto IL_359a;
					}
					goto IL_3cd3;
					IL_359a:
					num2 = 324;
					val[val.Row, 86] = "Y";
					goto IL_35b6;
					IL_35b6:
					num2 = 325;
					val[val.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) / (Conversion.Val(val[val.Row, 30]) + 100.0) * 100.0, 0), "0.00");
					goto IL_3621;
					IL_3621:
					num2 = 326;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 28]) == 0.0))
					{
						goto IL_3671;
					}
					goto IL_36e0;
					IL_3671:
					num2 = 327;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 31]) - Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 25]), 0), "0.00");
					goto IL_36e0;
					IL_36e0:
					num2 = 329;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_3712;
					}
					goto IL_3aa6;
					IL_3712:
					num2 = 330;
					if ((Operators.CompareString(val[val.Row, 21], "P", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_3760;
					}
					goto IL_37b7;
					IL_3760:
					num2 = 331;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9])), "0.00");
					goto IL_3aa6;
					IL_37b7:
					num2 = 333;
					if ((Operators.CompareString(val[val.Row, 21], "N", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_3808;
					}
					goto IL_38ea;
					IL_3808:
					num2 = 334;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_3827;
					}
					goto IL_387c;
					IL_3827:
					num2 = 335;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 12])), "0.00");
					goto IL_3aa6;
					IL_387c:
					num2 = 337;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14]))), "0.00");
					goto IL_3aa6;
					IL_38ea:
					num2 = 340;
					if ((Operators.CompareString(val[val.Row, 21], "K", false) == 0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_3938;
					}
					goto IL_3999;
					IL_3938:
					num2 = 341;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 10]) * 1000.0), "0.00");
					goto IL_3aa6;
					IL_3999:
					num2 = 343;
					if ((Operators.CompareString(val[val.Row, 21], "G", false) == 0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_39e7;
					}
					goto IL_3a3c;
					IL_39e7:
					num2 = 344;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 10])), "0.00");
					goto IL_3aa6;
					IL_3a3c:
					num2 = 346;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14]))), "0.00");
					goto IL_3aa6;
					IL_3aa6:
					num2 = 349;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_3afc;
					}
					goto IL_3c55;
					IL_3afc:
					num2 = 350;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_3b28;
					}
					goto IL_3b85;
					IL_3b28:
					num2 = 351;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_3b85;
					IL_3b85:
					num2 = 353;
					if (val.Col == 30)
					{
						goto IL_3b9f;
					}
					goto IL_3c55;
					IL_3b9f:
					num2 = 354;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_3bfa;
					IL_3bfa:
					num2 = 355;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_3c35;
					IL_3c35:
					num2 = 356;
					val[val.Row, 86] = "Y";
					goto IL_3c55;
					end_IL_0001_2:
					break;
				}
				num2 = 366;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 17089;
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
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Invalid comparison between Unknown and I4
		//IL_209b: Unknown result type (might be due to invalid IL or missing references)
		//IL_209e: Invalid comparison between Unknown and I4
		//IL_20b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b2: Invalid comparison between Unknown and I4
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c7: Invalid comparison between Unknown and I4
		//IL_1fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2118: Unknown result type (might be due to invalid IL or missing references)
		//IL_211b: Invalid comparison between Unknown and I4
		//IL_2194: Unknown result type (might be due to invalid IL or missing references)
		//IL_2197: Invalid comparison between Unknown and I4
		//IL_21e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_21eb: Invalid comparison between Unknown and I4
		//IL_2243: Unknown result type (might be due to invalid IL or missing references)
		//IL_2246: Invalid comparison between Unknown and I4
		//IL_1ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_4ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_5aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_56e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_57ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c97: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				if (Operators.CompareString(mSG[mSG.Row, 71], "", false) != 0)
				{
					DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 72] + "' AND CO_BOOK = '" + mSG[mSG.Row, 73] + "' AND VCH_NO = '" + mSG[mSG.Row, 71] + "' AND SR_NO = '" + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 74])) + "' ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 45])) + " ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 50]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][23])) == Conversion.Val(mSG[mSG.Row, 50]))
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
					int num3 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num3)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					if (mSG.Row == mSG.Rows - 1)
					{
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							mSG[mSG.Row, 50] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 50] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 50]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			checked
			{
				if (mSG.Col == 1)
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
						mSG[mSG.Row, 4] = "";
						mSG[mSG.Row, 88] = "";
						mSG[mSG.Row, 89] = "";
						mSG[mSG.Row, 90] = "";
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					TEXT_ENTRY.Text = DC_Main.ColValue[2];
					if (Operators.CompareString(DC_Main.ColValue[13], "Y", false) != 0)
					{
						int num4 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num4)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 4] = DC_Main.ColValue[0];
						mSG[mSG.Row, 55] = DC_Main.ColValue[4];
						mSG[mSG.Row, 68] = DC_Main.ColValue[4];
						tItDesc.Text = DC_Main.ColValue[4];
						mSG[mSG.Row, 2] = DC_Main.ColValue[5];
						mSG[mSG.Row, 5] = DC_Main.ColValue[3];
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[mSG.Row, 26] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
						mSG[mSG.Row, 45] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[9]));
						mSG[mSG.Row, 88] = DC_Main.ColValue[10];
						mSG[mSG.Row, 89] = DC_Main.ColValue[11];
						mSG[mSG.Row, 90] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					DC_Main.i = 0;
					DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.ColValue[10] + "' AND CO_BOOK = '" + DC_Main.ColValue[11] + "' AND VCH_NO = '" + DC_Main.ColValue[0] + "' AND OLD_SRNO = '" + DC_Main.ColValue[12] + "'";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (RsDetl.Rows.Count > 0)
					{
						int num5 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num5)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 4] = DC_Main.ColValue[0];
						mSG[mSG.Row, 88] = DC_Main.ColValue[10];
						mSG[mSG.Row, 89] = DC_Main.ColValue[11];
						mSG[mSG.Row, 90] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[mSG.Row, 55] = DC_Main.ColValue[4];
						mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG[mSG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						mSG[mSG.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID"], (object)""));
						mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						mSG[mSG.Row, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
						mSG[mSG.Row, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[mSG.Row, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[mSG.Row, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG[mSG.Row, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG[mSG.Row, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG[mSG.Row, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[mSG.Row, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[mSG.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[mSG.Row, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[mSG.Row, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[mSG.Row, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
						mSG[mSG.Row, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
						mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
						mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG[mSG.Row, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG[mSG.Row, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[mSG.Row, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[mSG.Row, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID2"], (object)""));
						mSG[mSG.Row, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID3"], (object)""));
						mSG[mSG.Row, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HM_ID4"], (object)""));
						mSG[mSG.Row, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID_WT"])), "0.000");
						mSG[mSG.Row, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID2_WT"])), "0.000");
						mSG[mSG.Row, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID3_WT"])), "0.000");
						mSG[mSG.Row, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["HM_ID4_WT"])), "0.000");
						mSG[mSG.Row, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["DESIGN_IMG_ID"], (object)""));
						mSG[mSG.Row, 91] = "Y";
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 45] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 50]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
							dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
							dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
					}
				}
				if (mSG.Col == 18)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME AS AcNameL,A.VCH_DATE AS OrderDtL,A.VCH_NO AS OrderNoL, B.ITM_REMARK AS ItemNameL,B.DESIGN_NO AS DesignL,B.ITM_GWT AS GrWtW,B.ITM_RATE AS RateR ,B.LBR_RATE AS LbrRateR,LBR_AMT As LbrAmtR FROM SL_ORD_DATA AS A INNER JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.ADV_AMT - A.ORD_ADJ_AMT > 0  OR B.TAG_SALE = 'N' AND A.AC_CODE IN ('00020','" + tAcCode.Text + "') ORDER BY A.VCH_DATE DESC ";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[10];
					DC_Main.ColWidth[0] = 250.0;
					DC_Main.ColWidth[1] = 120.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 200.0;
					DC_Main.ColWidth[3] = 200.0;
					DC_Main.ColWidth[4] = 150.0;
					DC_Main.ColWidth[5] = 100.0;
					DC_Main.ColWidth[6] = 100.0;
					DC_Main.ColWidth[7] = 100.0;
					DC_Main.ColWidth[8] = 100.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[6];
						mSG[mSG.Row, 18] = DC_Main.ColValue[6];
						mSG[mSG.Row, 22] = DC_Main.ColValue[7];
						if (Conversion.Val(mSG[mSG.Row, 23]) == 0.0)
						{
							mSG[mSG.Row, 23] = DC_Main.ColValue[8];
						}
						((Control)TEXT_ENTRY).Focus();
						return;
					}
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
					case 1:
					{
						if (Operators.CompareString(FormBookInOut, "O", false) != 0)
						{
							break;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Conversion.Val(mSG[mSG.Row, 45]) == 0.0))
						{
							mSG[mSG.Row, 1] = "";
						}
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 45]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 45]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 45]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 45]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
							}
							else if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select C.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND C.EMP_ISU <> 'Y'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC"));
							}
							else
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
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
									mSG[mSG.Row, 5] = DC_Main.ColValue[0];
								}
								else
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 5] = DC_Main.ColValue[1];
								}
								mSG[mSG.Row, 55] = DC_Main.ColValue[2];
								mSG[mSG.Row, 68] = DC_Main.ColValue[2];
								tItDesc.Text = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[3];
								mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 45] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 45] = "";
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
						mSG[mSG.Row, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
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
								mSG[mSG.Row, 55] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 5] = DC_Main.ColValue[3];
								mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 45] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 45]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""), (object)"", false))
							{
								mSG[DC_Main.i, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
								tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
							}
							else
							{
								mSG[DC_Main.i, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
								tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							}
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) == 0.0 && ((Conversion.Val(mSG[mSG.Row, 18]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 26]) == 0.0) & (DC_Main.RtView != null)))
							{
								DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
								if (DC_Main.RtView.Count > 0)
								{
									mSG[mSG.Row, 75] = Conversions.ToString(0);
									if (Operators.CompareString(mSG[DC_Main.i, 51], "G", false) == 0)
									{
										mSG[mSG.Row, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
										{
											Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
											2
										}, (string[])null, (Type[])null, (bool[])null)), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 51], "K", false) == 0)
									{
										mSG[mSG.Row, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
										{
											Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
											0
										}, (string[])null, (Type[])null, (bool[])null)), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 51], "1", false) == 0)
									{
										AxMSFlexGrid obj9 = mSG;
										int row6 = mSG.Row;
										Type? typeFromHandle2 = typeof(Math);
										DataRowView dataRowView;
										object[] obj10 = new object[2]
										{
											(dataRowView = DC_Main.RtView[0])["GR_RATE"],
											0
										};
										object[] array = obj10;
										bool[] obj11 = new bool[2] { true, false };
										bool[] array2 = obj11;
										object obj12 = NewLateBinding.LateGet((object)null, typeFromHandle2, "Round", obj10, (string[])null, (Type[])null, obj11);
										if (array2[0])
										{
											dataRowView["GR_RATE"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
										}
										obj9[row6, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(obj12), "0.00");
									}
								}
								else
								{
									mSG[mSG.Row, 18] = "";
								}
							}
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_PRC"], (object)"")), "0.00");
							if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"", false))
							{
								mSG[DC_Main.i, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							}
							mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_RATE"], (object)"")), "0.00");
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OTH_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
							AxMSFlexGrid obj13 = mSG;
							int i = DC_Main.i;
							object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"");
							obj13[i, 42] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							AxMSFlexGrid obj14 = mSG;
							int i2 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"");
							obj14[i2, 43] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
							AxMSFlexGrid obj15 = mSG;
							int i3 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
							obj15[i3, 33] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							AxMSFlexGrid obj16 = mSG;
							int i4 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
							obj16[i4, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
							mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Rshlp.Rows[0]["IT_NAME"]), (object)""));
							mSG[DC_Main.i, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[DC_Main.i, 80] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[DC_Main.i, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[DC_Main.i, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[DC_Main.i, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[DC_Main.i, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[DC_Main.i, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG[DC_Main.i, 87] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
						}
						int num15 = 0;
						int num16 = DtIdtl.Rows.Count - 1;
						int num17 = num16;
						for (int j = 0; j <= num17; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num15][23], (object)Conversion.Val(mSG[DC_Main.i, 50]), false))
							{
								DtIdtl.Rows[num15].Delete();
								DtIdtl.AcceptChanges();
								num15--;
							}
							num15++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[mSG.Row, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG[mSG.Row, 45]), (object)" "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[23] = Conversion.Val(MSG[mSG.Row, 50]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
							dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
							dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (Operators.CompareString(DC_Main.MsSlRowChange, "Y", false) == 0)
						{
							CommPassTotal();
							if (mSG.Row == mSG.Rows - 1)
							{
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								MsgClear = false;
								mSG.Col = 1;
								CommPassAdd();
								return;
							}
						}
						break;
					}
					case 2:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + FormItmType + "'"))), (object)" AND IT_CODE = '"), (object)TEXT_ENTRY.Text), (object)"' "));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND A.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.IT_NAME"));
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
									mSG[mSG.Row, 55] = DC_Main.ColValue[0];
									mSG[mSG.Row, 54] = DC_Main.ColValue[3];
									mSG[mSG.Row, 52] = DC_Main.ColValue[4];
									mSG[mSG.Row, 53] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if ((Conversion.Val(mSG[mSG.Row, 18]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 26]) == 0.0) & (DC_Main.RtView != null))
						{
							DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
							if (DC_Main.RtView.Count > 0)
							{
								if (Operators.CompareString(mSG[mSG.Row, 51], "G", false) == 0)
								{
									mSG[mSG.Row, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
									{
										Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
										2
									}, (string[])null, (Type[])null, (bool[])null)), "0.00");
								}
								else if (Operators.CompareString(mSG[mSG.Row, 51], "K", false) == 0)
								{
									mSG[mSG.Row, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
									{
										Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
										0
									}, (string[])null, (Type[])null, (bool[])null)), "0.00");
								}
								else if (Operators.CompareString(mSG[mSG.Row, 51], "1", false) == 0)
								{
									AxMSFlexGrid obj = mSG;
									int row = mSG.Row;
									Type? typeFromHandle = typeof(Math);
									DataRowView dataRowView;
									object[] obj2 = new object[2]
									{
										(dataRowView = DC_Main.RtView[0])["GR_RATE"],
										0
									};
									object[] array = obj2;
									bool[] obj3 = new bool[2] { true, false };
									bool[] array2 = obj3;
									object obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Round", obj2, (string[])null, (Type[])null, obj3);
									if (array2[0])
									{
										dataRowView["GR_RATE"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
									}
									obj[row, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0.00");
								}
							}
							else
							{
								mSG[mSG.Row, 18] = "";
							}
						}
						if (Operators.CompareString(mSG[mSG.Row, 1], "", false) == 0)
						{
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Tbl.Rows[0]["IT_NAME"]), (object)""));
						}
						if (Operators.CompareString(mSG[mSG.Row, 56], "A", false) == 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num6 != 0.0) & (Conversion.Val(mSG[mSG.Row, 22]) == 0.0))
							{
								AxMSFlexGrid obj5 = mSG;
								int row2 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
								double num7 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj5[row2, 22] = Strings.Format((object)num7, "0.00");
							}
							if (mSG[20] != 0)
							{
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
								double num8 = DC_Main.Fnv(ref Value);
								dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								if ((num8 != 0.0) & (Conversion.Val(mSG[mSG.Row, 20]) == 0.0))
								{
									AxMSFlexGrid obj6 = mSG;
									int row3 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
									double num9 = DC_Main.Fnv(ref Value);
									dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
									obj6[row3, 20] = Strings.Format((object)num9, "0.00");
								}
							}
						}
						mSG[mSG.Row, 2] = TEXT_ENTRY.Text;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG[mSG.Row, 2] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["AC_TOUCH"]);
								double num10 = DC_Main.Fnv(ref Value);
								dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["AC_WEST"]);
								double num11 = DC_Main.Fnv(ref Value);
								dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								if (num10 + num11 != 0.0)
								{
									if (Conversion.Val(mSG[mSG.Row, 15]) == 0.0)
									{
										AxMSFlexGrid obj7 = mSG;
										int row4 = mSG.Row;
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["AC_TOUCH"]);
										double num12 = DC_Main.Fnv(ref Value);
										dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
										obj7[row4, 15] = Strings.Format((object)num12, "0.00");
									}
									if (Conversion.Val(mSG[mSG.Row, 16]) == 0.0)
									{
										AxMSFlexGrid obj8 = mSG;
										int row5 = mSG.Row;
										Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["AC_WEST"]);
										double num13 = DC_Main.Fnv(ref Value);
										dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
										obj8[row5, 16] = Strings.Format((object)num13, "0.00");
									}
									if (((Conversion.Val(mSG[mSG.Row, 12]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 15]) != 0.0)) && Conversion.Val(mSG[mSG.Row, 17]) == 0.0)
									{
										mSG[mSG.Row, 17] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 12]) * (Conversion.Val(mSG[mSG.Row, 15]) + Conversion.Val(mSG[mSG.Row, 16])) / 100.0), "0.000");
									}
								}
							}
						}
						if (Operators.CompareString(tItDesc.Text, "", false) == 0)
						{
							tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						((Control)TEXT_ENTRY).Visible = false;
						ItmStk(mSG.Row);
						((Control)tItDesc).Focus();
						return;
					case 4:
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 4], false) != 0) & (mSG[4] != 0)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.ORD_NO As OrdNoL,D.AC_NAME As AcNameL,A.TAG_NO AS TagNoL,A.DESIGN_NO AS DesignNoL,C.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.ORD_YRCD As OrdYrCdL,A.ORD_DBCD As OrdDbCdL,A.ORD_SRNO As OrdSrNoL From ((BAR_DETL AS A LEFT JOIN SL_ORD_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.ORD_YRCD = B.CO_YEAR AND A.ORD_DBCD = B.CO_BOOK AND A.ORD_NO = B.VCH_NO AND A.ORD_SRNO = B.OLD_SRNO)LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE =  C.IT_CODE)  LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND  A.LC_CODE = '" + DC_Main.MLc_code + "' and A.ORD_NO <> '' AND B.TAG_SALE = 'N' AND A.ORD_AC = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)"  ORDER BY A.ORD_NO,A.TAG_NO"));
						DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.ColWidth = new double[14];
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
						DC_Main.HelpSelect = 1;
						((Form)MyProject.Forms.MS_HELP).ShowDialog();
						if (DC_Main.HelpClose)
						{
							return;
						}
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							TEXT_ENTRY.Text = DC_Main.ColValue[0];
							mSG[mSG.Row, 4] = DC_Main.ColValue[0];
							mSG[mSG.Row, 55] = DC_Main.ColValue[4];
							mSG[mSG.Row, 68] = DC_Main.ColValue[4];
							tItDesc.Text = DC_Main.ColValue[4];
							if (Operators.CompareString(mSG[mSG.Row, 1], DC_Main.ColValue[2], false) != 0)
							{
								Interaction.MsgBox((object)"Order TagNo Is Not Valid...", (MsgBoxStyle)0, (object)null);
								TEXT_ENTRY.Text = "";
								mSG[mSG.Row, 4] = "";
								mSG[mSG.Row, 88] = "";
								mSG[mSG.Row, 89] = "";
								mSG[mSG.Row, 90] = "";
							}
							else
							{
								mSG[mSG.Row, 1] = DC_Main.ColValue[2];
								mSG[mSG.Row, 2] = DC_Main.ColValue[5];
								mSG[mSG.Row, 5] = DC_Main.ColValue[3];
								mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
								mSG[mSG.Row, 26] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
								mSG[mSG.Row, 45] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[9]));
								mSG[mSG.Row, 88] = DC_Main.ColValue[10];
								mSG[mSG.Row, 89] = DC_Main.ColValue[11];
								mSG[mSG.Row, 90] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[12]));
								((Control)TEXT_ENTRY).Focus();
							}
						}
						else
						{
							TEXT_ENTRY.Text = "";
							mSG[mSG.Row, 4] = "";
							mSG[mSG.Row, 88] = "";
							mSG[mSG.Row, 89] = "";
							mSG[mSG.Row, 90] = "";
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					case 3:
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
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 10:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 51], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 19:
						if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(mSG[mSG.Row, 19]))
						{
							mSG[mSG.Row, 18] = Conversions.ToString(0);
							mSG[mSG.Row, 75] = Conversions.ToString(0);
						}
						break;
					case 32:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
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
		mSG = null;
	}

	private void ItmStk(int Row)
	{
		DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY A.IT_CODE ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			CurItGwtStk = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.000"));
		}
		else
		{
			CurItGwtStk = 0.0;
			lblItStock.Text = "Itm Stk :";
		}
	}

	private void TR_SALE_HM_Load(object sender, EventArgs e)
	{
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_16ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c9: Expected O, but got Unknown
		//IL_16ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16fd: Expected O, but got Unknown
		//IL_1722: Unknown result type (might be due to invalid IL or missing references)
		//IL_1727: Unknown result type (might be due to invalid IL or missing references)
		//IL_1731: Expected O, but got Unknown
		//IL_1756: Unknown result type (might be due to invalid IL or missing references)
		//IL_175b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1765: Expected O, but got Unknown
		//IL_178a: Unknown result type (might be due to invalid IL or missing references)
		//IL_178f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1799: Expected O, but got Unknown
		//IL_17be: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cd: Expected O, but got Unknown
		//IL_180c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1811: Unknown result type (might be due to invalid IL or missing references)
		//IL_181b: Expected O, but got Unknown
		//IL_1835: Unknown result type (might be due to invalid IL or missing references)
		//IL_183a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1844: Expected O, but got Unknown
		//IL_185e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1863: Unknown result type (might be due to invalid IL or missing references)
		//IL_186d: Expected O, but got Unknown
		//IL_1887: Unknown result type (might be due to invalid IL or missing references)
		//IL_188c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1896: Expected O, but got Unknown
		//IL_18b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18bf: Expected O, but got Unknown
		//IL_18d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18de: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e8: Expected O, but got Unknown
		//IL_1902: Unknown result type (might be due to invalid IL or missing references)
		//IL_1907: Unknown result type (might be due to invalid IL or missing references)
		//IL_1911: Expected O, but got Unknown
		//IL_1939: Unknown result type (might be due to invalid IL or missing references)
		//IL_1940: Expected O, but got Unknown
		//IL_1a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a30: Expected O, but got Unknown
		//IL_1ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Expected O, but got Unknown
		//IL_1b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b6b: Expected O, but got Unknown
		//IL_1c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c28: Expected O, but got Unknown
		//IL_1cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cbf: Expected O, but got Unknown
		//IL_1ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ce9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cf3: Expected O, but got Unknown
		//IL_1d20: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2a: Expected O, but got Unknown
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
		ColHight = 1.0 + num2;
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
			foreach (object control3 in ((Control)PanelAdd).Controls)
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
			foreach (object control4 in ((Control)PnlUpi).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				Label obj4 = lblTrfrOpen;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				TextBox obj6 = tHdVchNo;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((TextBoxBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				CheckBox obj8 = chkRateUnFix;
				object? obj9 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj8).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				Label obj10 = lblBook;
				object? obj11 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj10).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj13 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj14 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj15 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj16 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj17 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj18 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj19 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj20 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj21 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_OLD2 = MSG_OLD;
				object? obj23 = colorConverter.ConvertFromString("DarkGray");
				mSG_OLD2.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_OLD3 = MSG_OLD;
				object? obj24 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_OLD3.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj25 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj26 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj27 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_ORD = MSG_ORD;
				object? obj28 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_ORD2 = MSG_ORD;
				object? obj29 = colorConverter.ConvertFromString("DarkGray");
				mSG_ORD2.BackColorBkg = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_ORD3 = MSG_ORD;
				object? obj30 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_ORD3.BackColorFixed = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_UPI = MSG_UPI;
				object? obj31 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_UPI2 = MSG_UPI;
				object? obj32 = colorConverter.ConvertFromString("DarkGray");
				mSG_UPI2.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_UPI3 = MSG_UPI;
				object? obj33 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_UPI3.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj34 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblTrfrOpen).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((ButtonBase)chkRateUnFix).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj35 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj36 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj37 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj38 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj39 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj40 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj41 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj42 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj43 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj44 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_OLD4 = MSG_OLD;
				object? obj45 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD4.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_OLD5 = MSG_OLD;
				object? obj46 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_OLD5.BackColorBkg = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_OLD6 = MSG_OLD;
				object? obj47 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_OLD6.BackColorFixed = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj48 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj49 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_ORD4 = MSG_ORD;
				object? obj51 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD4.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG_ORD5 = MSG_ORD;
				object? obj52 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_ORD5.BackColorBkg = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG_ORD6 = MSG_ORD;
				object? obj53 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_ORD6.BackColorFixed = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG_UPI4 = MSG_UPI;
				object? obj54 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI4.BackColor = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG_UPI5 = MSG_UPI;
				object? obj55 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_UPI5.BackColorBkg = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG_UPI6 = MSG_UPI;
				object? obj56 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_UPI6.BackColorFixed = ((obj56 != null) ? ((Color)obj56) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj57 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblTrfrOpen).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				((ButtonBase)chkRateUnFix).BackColor = Color.Cornsilk;
				Label obj58 = lblBook;
				object? obj59 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj58).ForeColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj60 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj61 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj62 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj63 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj64 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj65 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj66 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj67 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj68 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj69 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AxMSFlexGrid mSG_OLD7 = MSG_OLD;
				object? obj70 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD7.BackColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AxMSFlexGrid mSG_OLD8 = MSG_OLD;
				object? obj71 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_OLD8.BackColorBkg = ((obj71 != null) ? ((Color)obj71) : default(Color));
				AxMSFlexGrid mSG_OLD9 = MSG_OLD;
				object? obj72 = colorConverter.ConvertFromString("Cornsilk");
				mSG_OLD9.BackColorFixed = ((obj72 != null) ? ((Color)obj72) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj73 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj74 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj75 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG_ORD7 = MSG_ORD;
				object? obj76 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_ORD7.BackColor = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG_ORD8 = MSG_ORD;
				object? obj77 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_ORD8.BackColorBkg = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AxMSFlexGrid mSG_ORD9 = MSG_ORD;
				object? obj78 = colorConverter.ConvertFromString("Cornsilk");
				mSG_ORD9.BackColorFixed = ((obj78 != null) ? ((Color)obj78) : default(Color));
				AxMSFlexGrid mSG_UPI7 = MSG_UPI;
				object? obj79 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI7.BackColor = ((obj79 != null) ? ((Color)obj79) : default(Color));
				AxMSFlexGrid mSG_UPI8 = MSG_UPI;
				object? obj80 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_UPI8.BackColorBkg = ((obj80 != null) ? ((Color)obj80) : default(Color));
				AxMSFlexGrid mSG_UPI9 = MSG_UPI;
				object? obj81 = colorConverter.ConvertFromString("Cornsilk");
				mSG_UPI9.BackColorFixed = ((obj81 != null) ? ((Color)obj81) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj82 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj82 != null) ? ((Color)obj82) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_OLD).AutoSize = false;
				((TextBoxBase)TEXT_ORD).AutoSize = false;
				((TextBoxBase)TEXT_UPI).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_OLD).Font = new Font(((Control)TEXT_OLD).Font.FontFamily, (float)num3, ((Control)TEXT_OLD).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ORD).Font = new Font(((Control)TEXT_ORD).Font.FontFamily, (float)num3, ((Control)TEXT_ORD).Font.Style);
				((Control)TEXT_UPI).Font = new Font(((Control)TEXT_UPI).Font.FontFamily, (float)num3, ((Control)TEXT_UPI).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_OLD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_OLD.Font.Style);
				MSG_ORD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_ORD.Font.Style);
				MSG_UPI.Font = new Font("Segoe UI Semibold", (float)num3, MSG_UPI.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
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
					foreach (object control6 in ((Control)PnlBotam).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue4, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
						{
							NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)tAdd1).Font.Size * (1.0 + num2));
				Font font3 = ((Control)tAdd1).Font;
				try
				{
					foreach (object control7 in ((Control)PanelAdd).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
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
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)chkRateUnFix).Visible = true;
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				((Control)lblTrfrOpen).Visible = true;
			}
			BtnCancel_Click(BtnCancel, new EventArgs());
			DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = 'L' ORDER BY MSG_TYPE ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				SmsDetail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["MSG_DETL"], (object)""));
			}
			else
			{
				SmsDetail = "Thank You For Buy Ornaments With " + DC_Main.MCo_Name + " Have A Nice Day..";
			}
			DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ORDER BY PRINT_FILE";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			cboPrintfile.Items.Add((object)"");
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num4 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						FormPrintFile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '01'  AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ORDER BY PRINT_FILE";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				cboPrintfile.Items.Add((object)"");
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num5 = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num5)
					{
						cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
						{
							FormPrintFile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
						}
						DC_Main.X++;
					}
				}
			}
			cboPrintfile.SelectedIndex = 0;
			cboPrintfile.Text = FormPrintFile;
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
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
		DC_Main.MsSlAdj = false;
		chkHuIdPrint.Checked = false;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		tTrfrNo.Text = "";
		tTrfrDbCd.Text = "";
		tTrfrYrCd.Text = "";
		((Control)tTrfrNo).Enabled = true;
		((Control)PnlTrfrVch).Visible = false;
		lblItStock.Text = "Itm Stock :";
		((Control)PanelAdd).Visible = false;
		tPanNo.Text = "";
		((Control)tPanNo).Visible = false;
		OsAmtSave = false;
		tEmpCode.Text = "001";
		UsUPdate = "N";
		UsDelete = "N";
		chkWapp.Checked = false;
		UpiTypeAdd = false;
		chkRateUnFix.Checked = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		LessAdvAmt = 0.0;
		OlsSchmAmt = 0.0;
		OldNetAmt = 0.0;
		OldTaxPrc = 0.0;
		CurItGwtStk = 0.0;
		AcTcsAmt = 0.0;
		OldTcsPrc = 0.0;
		MoBook = "";
		MoVch = "";
		DC_Main.MsOldPurc = false;
		DC_Main.MsOldPurcSl = false;
		OldGoldPurcAmt = 0.0;
		OldSilverPurcAmt = 0.0;
		tAcCode.Text = "00045";
		AcGstType = "L";
		cboPrintfile.Text = FormPrintFile;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_OLD).Visible = false;
		((Control)TEXT_ORD).Visible = false;
		((Control)TEXT_UPI).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_OLD_CLEAR();
		MSG_ORD_CLEAR();
		MSG2_CLEAR();
		MSG_UPI_CLEAR();
		CommPassAddUpi();
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
				DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsTax.Rows.Count > 0)
				{
					TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL[5, 2] = Strings.Format((object)num, "0.00");
					MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
		}
		else if ((Operators.CompareString(FormBookType, "T", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
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
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		if ((Operators.CompareString(FormBookType, "T", false) == 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK169NPVK", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '13'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[5, 2] = Strings.Format((object)num3, "0.00");
				MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		if ((Operators.CompareString(FormBookType, "T", false) == 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VS332NUBU", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '11'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num4 = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL4[5, 2] = Strings.Format((object)num4, "0.00");
				MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num5 = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num5)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
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
		DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]))), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				OldTaxPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"])), "0.00"));
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				OldTcsPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000"));
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_AMT"]), "0.00");
				MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HM_TAX_CODE"], (object)""));
				MSG2_TOTAL[5, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_PRC"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["HM_TAX_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADV_AMT"]), "0.00");
				MSG2_TOTAL[10, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00");
				OldGoldPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00"));
				MSG2_TOTAL[11, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00");
				OldSilverPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00"));
				MSG2_TOTAL[12, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00");
				OlsSchmAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00"));
				MSG2_TOTAL[13, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				MSG2_TOTAL[13, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UPI_AMT"]), "0.00");
				MSG2_TOTAL[14, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_PAID"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[15, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[16, 3] = Strings.Format((object)num2, "0.00");
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["OLD_GL"]);
				double num3 = DC_Main.Fnv(ref Value);
				dataRow["OLD_GL"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL3[10, 2] = Strings.Format((object)num3, "0.000");
				MSG2_TOTAL[11, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL"]), "0.000");
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
				MSG2_TOTAL[12, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SCHM_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[12, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[12, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[5, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
				tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
				tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["USER_DELETE"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["RATE_UNFIX"], (object)""), (object)"Y", false))
				{
					chkRateUnFix.Checked = true;
				}
				else
				{
					chkRateUnFix.Checked = false;
				}
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
				DC_Main.RsQry = "SELECT SUM(TOT_AMT) As TOT_AMT FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)"")), "0.00"));
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TOT_AMT"], (object)"")), "0.00"));
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
					mSG[DC_Main.i + 1, 50] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GHT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num4 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num5 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num4, 74] = Conversions.ToString(num5);
					mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 89] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					AxMSFlexGrid obj2 = mSG;
					int num6 = DC_Main.i + 1;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ORD_SRNO"]);
					double num7 = DC_Main.Fnv(ref Value);
					dataRow["ORD_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj2[num6, 90] = Conversions.ToString(num7);
					mSG[DC_Main.i + 1, 91] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_TAG_STK_ADD"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 56] = "E";
					mSG[DC_Main.i + 1, 86] = "Y";
					mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				tItDesc.Text = MSG[1, 68];
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num8 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num8)
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
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				DC_Main.RsQry = "SELECT A.* FROM SL_PR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsOldDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				while (DC_Main.i < RsOldDetl.Rows.Count)
				{
					mSG_OLD[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_OLD[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_OLD[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG_OLD[DC_Main.i + 1, 3] = Conversions.ToString(RsOldDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_OLD[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_OLD.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_OLD.Rows > 2)
				{
					mSG_OLD.Rows -= 1;
				}
				mSG_OLD = null;
				DC_Main.i = 0;
				DC_Main.RsQry = "Select * From SL_ORD_ADJ WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'  Order By Sr_No";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				while (DC_Main.i < dataTable.Rows.Count)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					mSG_ORD[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_ORD[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_HD_VCH_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG_ORD[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_LC"], (object)""));
					mSG_ORD[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_AC_CODE"], (object)""));
					mSG_ORD[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG_ORD[DC_Main.i + 1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[DC_Main.i]["ORD_AMT"]), "0.00");
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
				EntryMode = "E";
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]) + Conversion.Val(MSG2_TOTAL[16, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]) + Conversion.Val(MSG2_TOTAL[16, 3]);
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

	private void TR_SALE_HM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_HM_KeyPress(object sender, KeyPressEventArgs e)
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_528f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_5265: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0339: Unknown result type (might be due to invalid IL or missing references)
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Invalid comparison between Unknown and I4
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_075b: Unknown result type (might be due to invalid IL or missing references)
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.DefaulterAc(tAcCode.Text);
		if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[16, 3]) > 0.0))
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because This Party Is in Defaulter List...Please Change It First In AcMast...", (MsgBoxStyle)0, (object)null);
			DC_Main.MsDefaulterAc = "N";
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
		if (Operators.CompareString(tAcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)tAcCode).Focus();
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		MSG_TOT_FILL();
		if (Conversion.Val(MSG2_TOTAL[0, 3]) + Conversion.Val(MSG_TOT[0, 23]) == 0.0)
		{
			Interaction.MsgBox((object)"Please Insert Item Value Nat Amount  = 0 and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK033NPVK", false) == 0 && ((Conversion.Val(MSG2_TOTAL[16, 3]) != 0.0) & !OsAmtSave))
		{
			if ((int)Interaction.MsgBox((object)("This Bill Outstanding Amount =  " + Strings.Format((object)Conversion.Val(MSG2_TOTAL[16, 3]), "0.00") + " ...You Want to Save It ?"), (MsgBoxStyle)260, (object)DC_Main.MsgTitle) == 6)
			{
				OsAmtSave = true;
				((Control)BtnSave).Enabled = true;
				((Control)BtnSave).Focus();
			}
			else
			{
				((Control)BtnSave).Enabled = true;
				((Control)BtnSave).Focus();
			}
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[0, 3]) >= DC_Main.MsPanCardVal) & (Operators.CompareString(DC_Main.MCo_BookType, "T", false) == 0))
		{
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				Interaction.MsgBox((object)(("Please Select Party Account Because Bill Value > " + Conversions.ToString(DC_Main.MsPanCardVal)) ?? ""), (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				tAcCode.Text = "";
				((Control)tAcCode).Focus();
				return;
			}
			DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsAc.Rows.Count > 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_PANNO"], (object)""), (object)"", false))
			{
				Interaction.MsgBox((object)(("Please Insert Party PanNo in Party mast...BIll Value > " + Conversions.ToString(DC_Main.MsPanCardVal)) ?? ""), (MsgBoxStyle)0, (object)null);
				((Control)BtnSave).Enabled = true;
				((Control)tPanNo).Visible = true;
				((Control)tPanNo).Focus();
				return;
			}
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		Module_Save.SlTran = null;
		checked
		{
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Module_Save.SlTran = DC_Main.Dc.BeginTransaction();
				Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				Module_Save.ExeQuteDcSave("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				if (Conversion.Val(MSG_TOT[0, 26]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 31]) != 0.0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ", Module_Save.SlTran);
					DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
					DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow["VCH_NO"] = tHdVchNo.Text;
					dataRow["BOOK_NAME"] = FormName;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
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
					dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
					dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
					dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
					dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
					dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
					dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];
					dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
					dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
					dataRow2["ROF_AMT"] = 0;
					dataRow2["HM_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
					dataRow2["HM_TAX_CODE"] = MSG2_TOTAL[5, 4];
					dataRow2["HM_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[5, 2]);
					dataRow2["HM_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
					dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 23]);
					dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 25]);
					dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
					dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
					dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow2["ADV_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow2["CRNT_ADJ_AMT"] = 0;
					dataRow2["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow2["OLD_SL_AMT"] = Conversion.Val(MSG2_TOTAL[11, 3]);
					dataRow2["SCHM_AMT"] = Conversion.Val(MSG2_TOTAL[12, 3]);
					if (Operators.CompareString(FormBookType, "T", false) != 0)
					{
						dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[13, 3]);
					}
					else if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
					{
						if (Conversion.Val(MSG2_TOTAL[10, 3]) + Conversion.Val(MSG2_TOTAL[11, 3]) < Conversion.Val(MSG2_TOTAL[13, 3]))
						{
							dataRow2["CASH_AMT"] = Strings.Format((object)Math.Round(Conversion.Val(MSG2_TOTAL[13, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]) + Conversion.Val(MSG2_TOTAL[11, 3]), 0), "0.00");
						}
						else
						{
							dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]) - Conversion.Val(MSG2_TOTAL[9, 3]) - Conversion.Val(MSG2_TOTAL[15, 3]);
						}
					}
					else
					{
						dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[13, 3]);
					}
					dataRow2["UPI_AMT"] = Conversion.Val(MSG2_TOTAL[13, 1]);
					dataRow2["CASH_PAID"] = Conversion.Val(MSG2_TOTAL[14, 3]);
					dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[15, 3]);
					dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[16, 3]);
					dataRow2["OLD_GL"] = Conversion.Val(MSG2_TOTAL[10, 2]);
					dataRow2["OLD_SL"] = Conversion.Val(MSG2_TOTAL[11, 2]);
					dataRow2["CARD_AC"] = MSG2_TOTAL[8, 4];
					dataRow2["BANK_AC"] = MSG2_TOTAL[7, 4];
					dataRow2["CHQ_NO"] = MSG2_TOTAL[7, 2];
					dataRow2["SCHM_AC"] = MSG2_TOTAL[12, 4];
					dataRow2["BANK_NAME"] = tBankName.Text;
					dataRow2["CARD_ADJ"] = "N";
					dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);
					dataRow2["ADD1"] = tAdd1.Text;
					dataRow2["ADD2"] = tAdd2.Text;
					dataRow2["ADD3"] = tAdd3.Text;
					dataRow2["CITY"] = tCity.Text;
					dataRow2["MOBILE"] = tMobile.Text;
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
					dataRow2["RTN_TOT_AMT"] = 0;
					dataRow2["RTN_CHQ_AMT"] = 0;
					dataRow2["RTN_CARD_AMT"] = 0;
					dataRow2["RTN_CASH_AMT"] = 0;
					dataRow2["RTN_KASAR_AMT"] = 0;
					dataRow2["RTN_BILL_OS"] = 0;
					dataRow2["ISU_NO"] = tIsuNo.Text;
					dataRow2["ISU_LC_CODE"] = DC_Main.MLc_code;
					dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
					dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
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
					dataRow2["MOB_ENTRY_SAVE"] = "Y";
					if (chkRateUnFix.Checked)
					{
						dataRow2["RATE_UNFIX"] = "Y";
					}
					else
					{
						dataRow2["RATE_UNFIX"] = "N";
					}
					dataRow2["OZ_RATE"] = 0;
					dataRow2["OZ_CONV"] = 0;
					dataRow2["FX_RATE"] = 0;
					dataRow2["FX_CODE"] = "";
					dataRow2["MTL_RATE"] = 0;
					RsData.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
					RsData.Clear();
				}
				DC_Main.RsQry = "SELECT * FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow3 = RsDetl.NewRow();
				int num = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num)
				{
					AxMSFlexGrid mSG = MSG;
					if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 26]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 10]) + Conversion.Val(mSG[DC_Main.i, 23]) + Conversion.Val(mSG[DC_Main.i, 31]) != 0.0))
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
						dataRow3["ENTRY_TYPE"] = "S";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 50]);
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
						{
							dataRow3["TAG_NO"] = "N";
							if (Operators.CompareString(mSG[DC_Main.i, 3], "", false) == 0)
							{
								dataRow3["TBL_CODE"] = "001";
							}
						}
						else
						{
							dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
							dataRow3["TBL_CODE"] = mSG[DC_Main.i, 3];
						}
						dataRow3["ORD_NO"] = mSG[DC_Main.i, 4];
						dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 5];
						dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
						dataRow3["HM_ID"] = mSG[DC_Main.i, 7];
						dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 9]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 10]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 11]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 17]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 21];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 22]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 23]);
						dataRow3["GHT_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
						dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 18]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 26]);
						dataRow3["DISC_PRC"] = Conversion.Val(mSG[DC_Main.i, 27]);
						dataRow3["DISC_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
						dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 30]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 31]);
						dataRow3["HM_AMT"] = Conversion.Val(mSG[DC_Main.i, 32]);
						dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 36]);
						dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 39]);
						dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 40]);
						dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 41]);
						dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 33]);
						dataRow3["KR_NAME"] = mSG[DC_Main.i, 34];
						dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 51];
						dataRow3["IT_TYPE"] = mSG[DC_Main.i, 52];
						dataRow3["PR_CODE"] = mSG[DC_Main.i, 54];
						dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 68];
						dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 45]);
						dataRow3["ISU_NO"] = mSG[DC_Main.i, 71];
						dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
						dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 72];
						dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 73];
						dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 74]);
						dataRow3["HM_ID2"] = mSG[DC_Main.i, 79];
						dataRow3["HM_ID3"] = mSG[DC_Main.i, 80];
						dataRow3["HM_ID4"] = mSG[DC_Main.i, 81];
						dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 82]);
						dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 83]);
						dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 84]);
						dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 85]);
						dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 87];
						dataRow3["ORD_LC_CODE"] = DC_Main.MLc_code;
						dataRow3["ORD_YRCD"] = mSG[DC_Main.i, 88];
						dataRow3["ORD_DBCD"] = mSG[DC_Main.i, 89];
						dataRow3["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 90]);
						dataRow3["ORD_TAG_STK_ADD"] = mSG[DC_Main.i, 91];
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow3["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
				if (Operators.CompareString(DC_Main.MsSlBillImg, "Y", false) == 0)
				{
					DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
					int num2 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num2)
					{
						AxMSFlexGrid mSG2 = MSG;
						if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0)
						{
							DC_Main.MsImageNo = mSG2[DC_Main.i, 1] + "_" + mSG2[DC_Main.i, 45];
							DC_Main.MsImageType = "TagImage";
							DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
							if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
							{
								PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
								MemoryStream memoryStream = new MemoryStream();
								PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
								byte[] buffer = memoryStream.GetBuffer();
								DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG2[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 45]))) ?? "";
								DataTable dataTable2 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
								Module_Save.MsInsertDataSave(Module_Save.SlTran);
								DataRow dataRow4 = dataTable2.NewRow();
								dataRow4["CO_CODE"] = DC_Main.MCo_code;
								dataRow4["LC_CODE"] = DC_Main.MLc_code;
								dataRow4["TAG_NO"] = mSG2[DC_Main.i, 1];
								dataRow4["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 45]);
								dataRow4["TAG_IMAGE"] = buffer;
								dataTable2.Rows.Add(dataRow4);
								((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
								dataTable2.Clear();
							}
						}
						mSG2 = null;
						DC_Main.i++;
					}
				}
				DC_Main.RsQry = "SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow5 = RsIdtl.NewRow();
				int num3 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18])) != 0.0)
					{
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						dataRow5["LC_CODE"] = DC_Main.MLc_code;
						dataRow5["CO_YEAR"] = DC_Main.MCo_year;
						dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow5["VCH_NO"] = tVchNo.Text;
						dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow5["VCH_DATE"] = mVchDate.Text;
						dataRow5["AC_CODE"] = tAcCode.Text;
						dataRow5["VCH_TYPE"] = FormBookSname;
						dataRow5["INOUT_TYPE"] = FormBookInOut;
						dataRow5["ENTRY_TYPE"] = "S";
						dataRow5["BOOK_NAME"] = FormMainBook;
						dataRow5["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]));
						dataRow5["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]))), 1];
						dataRow5["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]))), 45]);
						dataRow5["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
						dataRow5["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
						dataRow5["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
						dataRow5["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
						dataRow5["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
						dataRow5["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
						dataRow5["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
						dataRow5["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]);
						dataRow5["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]);
						dataRow5["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
						dataRow5["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
						dataRow5["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
						dataRow5["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
						dataRow5["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]);
						dataRow5["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
						dataRow5["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
						dataRow5["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
						dataRow5["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
						dataRow5["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
						dataRow5["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
						dataRow5["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
						dataRow5["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow5);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl = null;
				}
				Module_Save.ExeQuteDcSave("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				RsOldDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow6 = RsOldDetl.NewRow();
				int num4 = MSG_OLD.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num4)
				{
					AxMSFlexGrid mSG_OLD = MSG_OLD;
					if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 10]) != 0.0) & (Operators.CompareString(MSG_OLD[DC_Main.i, 1], "", false) != 0))
					{
						dataRow6["CO_CODE"] = DC_Main.MCo_code;
						dataRow6["LC_CODE"] = DC_Main.MLc_code;
						dataRow6["CO_YEAR"] = DC_Main.MCo_year;
						dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow6["VCH_NO"] = tVchNo.Text;
						dataRow6["VCH_DATE"] = mVchDate.Text;
						dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow6["AC_CODE"] = tAcCode.Text;
						dataRow6["VCH_TYPE"] = FormBookSname;
						dataRow6["INOUT_TYPE"] = FormBookInOut;
						dataRow6["ENTRY_TYPE"] = "A";
						dataRow6["BOOK_NAME"] = FormMainBook;
						dataRow6["SR_NO"] = Conversion.Val(mSG_OLD[DC_Main.i, 0]);
						dataRow6["IT_CODE"] = mSG_OLD[DC_Main.i, 1];
						dataRow6["IT_TYPE"] = mSG_OLD[DC_Main.i, 11];
						dataRow6["IT_DESC"] = mSG_OLD[DC_Main.i, 2];
						dataRow6["ITM_PCS"] = Conversion.Val(mSG_OLD[DC_Main.i, 3]);
						dataRow6["ITM_GWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 4]);
						dataRow6["ITM_OTH_WT"] = Conversion.Val(mSG_OLD[DC_Main.i, 5]);
						dataRow6["ITM_NWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 6]);
						dataRow6["ITM_TOUCH"] = Conversion.Val(mSG_OLD[DC_Main.i, 7]);
						dataRow6["ITM_FINE"] = Conversion.Val(mSG_OLD[DC_Main.i, 8]);
						dataRow6["ITM_RATE"] = Conversion.Val(mSG_OLD[DC_Main.i, 9]);
						dataRow6["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 10]);
						dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow6["MAIN_USER"] = MainUser;
						RsOldDetl.Rows.Add(dataRow6);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsOldDetl);
						RsOldDetl.Clear();
					}
					mSG_OLD = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
				DataTable dataTable3 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow7 = dataTable3.NewRow();
				if (Conversion.Val(MSG2_TOTAL[9, 3]) != 0.0)
				{
					AxMSFlexGrid mSG_ORD = MSG_ORD;
					int num5 = MSG_ORD.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num5)
					{
						if (Conversion.Val(MSG_ORD[DC_Main.i, 2]) != 0.0)
						{
							dataRow7["CO_CODE"] = DC_Main.MCo_code;
							dataRow7["LC_CODE"] = DC_Main.MLc_code;
							dataRow7["CO_YEAR"] = DC_Main.MCo_year;
							dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow7["VCH_NO"] = tVchNo.Text;
							dataRow7["SR_NO"] = DC_Main.i;
							dataRow7["VCH_DATE"] = mVchDate.Text;
							dataRow7["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow7["AC_CODE"] = tAcCode.Text;
							dataRow7["AC_NAME"] = tAcName.Text;
							dataRow7["VCH_TYPE"] = FormBookSname;
							dataRow7["INOUT_TYPE"] = FormBookInOut;
							dataRow7["ENTRY_TYPE"] = "S";
							dataRow7["BOOK_NAME"] = FormMainBook;
							dataRow7["ORD_HD_VCH_NO"] = mSG_ORD[DC_Main.i, 7];
							dataRow7["ORD_NO"] = mSG_ORD[DC_Main.i, 1];
							dataRow7["ORD_LC"] = mSG_ORD[DC_Main.i, 3];
							dataRow7["ORD_YRCD"] = mSG_ORD[DC_Main.i, 4];
							dataRow7["ORD_DBCD"] = mSG_ORD[DC_Main.i, 5];
							dataRow7["ORD_AC_CODE"] = mSG_ORD[DC_Main.i, 6];
							dataRow7["ORD_SIGN"] = "-";
							dataRow7["ORD_AMT"] = Conversion.Val(mSG_ORD[DC_Main.i, 2]);
							dataRow7["PAID_AC"] = "";
							dataRow7["PAID_AMT"] = 0;
							dataRow7["ORD_BAL_AMT"] = 0;
							dataRow7["ORD_GOLD"] = 0;
							dataRow7["ORD_SILVER"] = 0;
							dataRow7["KASAR_AMT"] = 0;
							dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow7["DATA_TRFR"] = "N";
							dataRow7["EMP_CODE"] = tEmpCode.Text;
							dataRow7["IT_DESC"] = "";
							dataRow7["MAIN_USER"] = MainUser;
							dataTable3.Rows.Add(dataRow7);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable3);
							dataTable3.Clear();
						}
						DC_Main.i++;
					}
					mSG_ORD = null;
				}
				if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.SlTran);
					DC_Main.RsQry = "SELECT * FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					RsBillOs = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
					Module_Save.MsInsertDataSave(Module_Save.SlTran);
					DataRow dataRow8 = RsBillOs.NewRow();
					if (Conversion.Val(MSG2_TOTAL[6, 3]) != 0.0)
					{
						dataRow8["CO_CODE"] = DC_Main.MCo_code;
						dataRow8["LC_CODE"] = DC_Main.MLc_code;
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow8["VCH_NO"] = tVchNo.Text;
						dataRow8["SR_NO"] = 1;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						dataRow8["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow8["AC_CODE"] = tAcCode.Text;
						dataRow8["VCH_TYPE"] = FormBookSname;
						dataRow8["INOUT_TYPE"] = FormBookInOut;
						dataRow8["ENTRY_TYPE"] = "O";
						dataRow8["BOOK_NAME"] = FormMainBook;
						dataRow8["BILL_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
						dataRow8["OLD_ADJ_AMT"] = 0;
						dataRow8["REC_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]) - (Conversion.Val(MSG2_TOTAL[16, 3]) + Conversion.Val(MSG2_TOTAL[15, 3]));
						dataRow8["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[15, 3]);
						dataRow8["BILL_GOLD"] = 0;
						dataRow8["OLD_ADJ_GOLD"] = 0;
						dataRow8["REC_GOLD"] = 0;
						dataRow8["KASAR_GOLD"] = 0;
						dataRow8["BILL_SILVER"] = 0;
						dataRow8["OLD_ADJ_SILVER"] = 0;
						dataRow8["REC_SILVER"] = 0;
						dataRow8["KASAR_SILVER"] = 0;
						dataRow8["BILL_LC"] = DC_Main.MLc_code;
						dataRow8["BILL_YRCD"] = DC_Main.MCo_year;
						dataRow8["BILL_DBCD"] = DC_Main.MCo_Book;
						dataRow8["BILL_NO"] = tVchNo.Text;
						dataRow8["BILL_HD_VCH_NO"] = tHdVchNo.Text;
						dataRow8["BILL_SRNO"] = 1;
						dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow8["MAIN_USER"] = MainUser;
						dataRow8["DATA_TRFR"] = "N";
						dataRow8["DATA_TYPE"] = "A";
						RsBillOs.Rows.Add(dataRow8);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBillOs);
						RsBillOs.Clear();
					}
				}
				DC_Main.RsQry = "DELETE FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow9 = RsDetl.NewRow();
				int num6 = MSG_UPI.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num6)
				{
					if ((Operators.CompareString(MSG_UPI[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(MSG_UPI[DC_Main.i, 5]) != 0.0))
					{
						dataRow9["CO_CODE"] = DC_Main.MCo_code;
						dataRow9["LC_CODE"] = DC_Main.MLc_code;
						dataRow9["CO_YEAR"] = DC_Main.MCo_year;
						dataRow9["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow9["VCH_NO"] = tVchNo.Text;
						dataRow9["SR_NO"] = DC_Main.i;
						dataRow9["AC_CODE"] = tAcCode.Text;
						dataRow9["VCH_DATE"] = mVchDate.Text;
						dataRow9["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow9["UPI_AC_CODE"] = MSG_UPI[DC_Main.i, 1];
						dataRow9["UPI_AC_NAME"] = MSG_UPI[DC_Main.i, 2];
						dataRow9["UPI_TYPE"] = MSG_UPI[DC_Main.i, 3];
						dataRow9["UPI_ID"] = MSG_UPI[DC_Main.i, 4];
						dataRow9["UPI_AMT"] = Conversion.Val(MSG_UPI[DC_Main.i, 5]);
						RsDetl.Rows.Add(dataRow9);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					DC_Main.i++;
				}
				string text = "";
				string text2 = "";
				string text3 = "";
				if ((Operators.CompareString(DC_Main.SmsPwd, "", false) != 0) & (Operators.CompareString(DC_Main.SmsId, "", false) != 0))
				{
					if (((Operators.CompareString(DC_Main.MsAdminSms, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)) && Operators.CompareString(DC_Main.MsAdminMobile, "", false) != 0)
					{
						text = tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[16, 3]));
						if (Operators.CompareString(DC_Main.SmsLink, "001", false) == 0)
						{
							text2 = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + DC_Main.MsAdminMobile + "&message=" + text + "&sender=JEWELL&route=1";
						}
						else if ((Operators.CompareString(DC_Main.SmsLink, "002", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "012", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "022", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "032", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "042", false) == 0))
						{
							text2 = "https://sms.mobileadz.in/api/push.json?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + DC_Main.MsAdminMobile + "&text=" + text;
						}
						WebBrowser1.Navigate(text2);
						WebBrowser1.Refresh();
					}
					if (((Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0)) && Operators.CompareString(tMobile.Text, "", false) != 0)
					{
						text3 = ((Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) != 0) ? SmsDetail : ("Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[16, 3])) + " " + SmsDetail));
						if (Operators.CompareString(DC_Main.SmsLink, "001", false) == 0)
						{
							text2 = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + tMobile.Text + "&message=" + text3 + "&sender=JEWELL&route=1";
						}
						else if ((Operators.CompareString(DC_Main.SmsLink, "002", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "012", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "022", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "032", false) == 0) | (Operators.CompareString(DC_Main.SmsLink, "042", false) == 0))
						{
							text2 = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + tMobile.Text + "&text=" + text3;
						}
						WebBrowser1.Navigate(text2);
						WebBrowser1.Refresh();
					}
				}
				if (Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) == 0)
				{
					WappMsg = "Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[16, 3])) + " " + SmsDetail;
				}
				else
				{
					WappMsg = SmsDetail;
				}
				AdminWappMsg = tAcName.Text + " Book = " + DC_Main.MCo_Book + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[16, 3]));
				if (Operators.CompareString(EntryMode, "E", false) == 0)
				{
					WappMsg = "";
					AdminWappMsg = "";
				}
				WappAcName = tAcName.Text;
				WappMobile = tMobile.Text;
				DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'Y'  FROM SL_ORD_DETL,SL_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.LC_CODE = A.LC_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y' FROM APR_DETL,SL_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'N' FROM SL_DETL,BAR_DETL AS B WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					DC_Main.RsQry = "UPDATE A SET  A.ZERO_RATED_AMT = B.ZeroRated FROM SL_DATA AS A  INNER JOIN(Select B.CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SUM(ITM_AMT) As ZeroRated   FROM SL_DETL AS B,ITEM_MAST AS C WHERE B.CO_CODE = C.CO_CODE And B.IT_CODE =  C.IT_CODE And C.TAX_FREE_ITEM = 'Y'  GROUP BY B.CO_CODE, B.LC_CODE, B.CO_YEAR, B.CO_BOOK, B.VCH_NO) As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE  And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + tVchNo.Text + "'";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				}
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Ledr.Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Rojmel.Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Tax.Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.Dm_Sale_Detl(DC_Main.MCo_Book, tVchNo.Text);
				if (Operators.CompareString(MoVch, "", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'", Module_Save.SlTran);
					Module_Save.ExeQuteDcSave("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'", Module_Save.SlTran);
				}
				Module_Save.SlTran.Commit();
				DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,TAX_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND TAX_AMT <> 0 ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["TAX_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false))))
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
						DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						int num7 = 0;
						int num8 = dataTable4.Rows.Count - 1;
						for (num7 = 0; num7 <= num8; num7++)
						{
							if (Operators.ConditionalCompareObjectNotEqual(dataTable4.Rows[num7]["NET_AMT"], (object)0, false))
							{
								double num9 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
								{
									Operators.DivideObject(Operators.MultiplyObject(dataTable4.Rows[num7]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
									2
								}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
								DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_TAX_AMT = " + Conversions.ToString(num9) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable4.Rows[num7]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable4.Rows[num7]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[num7]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable4.Rows[num7]["SR_NO"]), (object)"")));
							}
						}
					}
					else
					{
						DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_DETL SET IT_TAX_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
					}
				}
				Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
				}
				CurPrnVch = tVchNo.Text;
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
				DC_Main.RsQry = "SELECT TOT_AMT FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.MsAcAmtOpBal > 0.0)
					{
						DC_Main.MsAcAmtOpBal -= Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TOT_AMT"])), "0.00"));
					}
					else if (DC_Main.MsAcAmtOpBal < 0.0)
					{
						DC_Main.MsAcAmtOpBal += Conversions.ToDouble(Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TOT_AMT"])), "0.00"));
					}
				}
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.SlTran.Rollback();
					Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
					Module_Save.SlTran = null;
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
		//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,TOT_AMT,OLD_GL_AMT+OLD_SL_AMT+CASH_AMT+CARD_AMT+CHQ_AMT-CASH_PAID+KASAR_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,'',NET_AMT,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM SL_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE SL_ORD_DETL  SET SL_ORD_DETL.TAG_SALE = 'N'  FROM SL_ORD_DETL,SL_DETL AS A WHERE SL_ORD_DETL.CO_CODE = A.CO_CODE AND SL_ORD_DETL.VCH_NO = A.ORD_NO AND SL_ORD_DETL.CO_YEAR = A.ORD_YRCD AND SL_ORD_DETL.CO_BOOK = A.ORD_DBCD AND SL_ORD_DETL.OLD_SRNO = A.ORD_SRNO  AND A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,SL_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM SL_DETL,BAR_DETL AS B WHERE SL_DETL.CO_CODE = B.CO_CODE AND SL_DETL.LC_CODE = B.LC_CODE AND SL_DETL.TAG_NO = B.TAG_NO  AND SL_DETL.VCH_SRNO = B.VCH_SRNO AND SL_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND SL_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND SL_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND SL_DETL.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.RsQry = "SELECT * FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[0]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)"'")));
			}
			DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SALE_HM_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
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
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsCustSms, "Y", false) == 0) & (Operators.CompareString(WappMsg, "", false) != 0))
		{
			WappReport();
			Thread.Sleep(3000);
		}
		Application.DoEvents();
		if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsAdminSms, "Y", false) == 0) & (Operators.CompareString(DC_Main.MsAdminMobile, "", false) != 0))
		{
			AdminWappReport();
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
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.MsCustMail = "";
			if (Operators.CompareString(tMobile.Text, "", false) == 0)
			{
				DC_Main.MsCustWappNo = "";
			}
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM SL_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				if (Operators.CompareString(tMobile.Text, "", false) == 0)
				{
					DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
				}
			}
			string rptName = ((!chkHuIdPrint.Checked) ? cboPrintfile.Text : "RtlHuidPrint");
			if (Operators.CompareString(DC_Main.MsWappSlPrint, "Y", false) == 0)
			{
				DC_Main.RptName = "SlBillWapp";
			}
			else
			{
				DC_Main.RptName = rptName;
			}
			DC_Main.MsWappPrintType = "AmtBal";
			if (!chkHuIdPrint.Checked)
			{
				DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
				DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			}
			DC_Main.RptFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
		{
			DC_Main.RptName = "SalesBillDubai";
			DC_Main.RptFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT3 = new UT_REPORT();
			((Control)uT_REPORT3).Show();
			((Control)uT_REPORT3).Focus();
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		if (chkHuIdPrint.Checked)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\RtlHuidPrint.RPT";
			string rptName = "RtlHuidPrint";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
			string rptName = cboPrintfile.Text;
		}
		Cr.SelectionFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + CurPrnVch + "'";
		if (!chkHuIdPrint.Checked)
		{
			Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		}
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					Cr[(short)1] = "InVoiceType = 'ACCOUNT COPY'";
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				}
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
				{
					Cr[(short)1] = "InVoiceType = 'PARTY COPY'";
				}
				else
				{
					Cr[(short)1] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				}
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

	private async void WappReport()
	{
		if ((Strings.Len(WappMobile) > 5) & (Operators.CompareString(WappMsg, "", false) != 0))
		{
			try
			{
				if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
				{
					MessageRequest val = new MessageRequest();
					val.Phone = DC_Main.MsCountryId + WappMobile;
					val.Message = WappMsg;
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
		WappMsg = "";
		WappAcName = "";
		WappMobile = "";
	}

	private async void AdminWappReport()
	{
		try
		{
			if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) != 0)
			{
				MessageRequest val = new MessageRequest();
				val.Phone = DC_Main.MsCountryId + DC_Main.MsAdminMobile;
				val.Message = AdminWappMsg;
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
		AdminWappMsg = "";
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	private void TR_SALE_HM_Activated(object sender, EventArgs e)
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
			if ((Operators.CompareString(DC_Main.MsCode, "", false) != 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0))
			{
				tAcCode.Text = DC_Main.MsCode;
			}
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if (DC_Main.MsSlAdj & (DC_Main.MsSlSchmAdj != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			MSG2_TOTAL[12, 3] = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			DC_Main.MsSlSchmAdj = 0.0;
		}
		if ((DC_Main.MsOldPurcSl & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0)) && Conversion.Val(MSG2_TOTAL[11, 3]) == 0.0)
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[11, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[11, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
		}
		else if (DC_Main.MsOldPurc & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[10, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[10, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
		}
		else
		{
			((ContainerControl)this).ActiveControl = CurActCtrl;
			CurActCtrl.Focus();
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 150.0;
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
		//IL_0b85: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8f: Expected O, but got Unknown
		//IL_0903: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Expected O, but got Unknown
		//IL_0a44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Expected O, but got Unknown
		//IL_0d1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		if (Operators.CompareString(MSG[MSG.Row, 81], "", false) != 0)
		{
			lblItem.Text = "Itm : " + MSG[MSG.Row, 55] + "  Hu2 : " + MSG[MSG.Row, 79] + "  Hu3 : " + MSG[MSG.Row, 80] + "  Hu4 : " + MSG[MSG.Row, 81];
		}
		else if (Operators.CompareString(MSG[MSG.Row, 80], "", false) != 0)
		{
			lblItem.Text = "Itm : " + MSG[MSG.Row, 55] + "  Hu2 : " + MSG[MSG.Row, 79] + "  Hu3 : " + MSG[MSG.Row, 80];
		}
		else if (Operators.CompareString(MSG[MSG.Row, 79], "", false) != 0)
		{
			lblItem.Text = "Itm : " + MSG[MSG.Row, 55] + "  Hu2 : " + MSG[MSG.Row, 79];
		}
		else
		{
			lblItem.Text = "Itm : " + MSG[MSG.Row, 55];
		}
		tItDesc.Text = MSG[MSG.Row, 68];
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 50]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23])))
				{
					MSG_IDTL[num, 0] = Conversions.ToString(num);
					MSG_IDTL[num, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
					MSG_IDTL[num, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
					MSG_IDTL[num, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
					MSG_IDTL[num, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
					MSG_IDTL[num, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
					MSG_IDTL[num, 6] = Conversions.ToString(DtIdtl.Rows[i][6]);
					MSG_IDTL[num, 7] = Conversions.ToString(DtIdtl.Rows[i][7]);
					MSG_IDTL[num, 8] = Conversions.ToString(DtIdtl.Rows[i][8]);
					MSG_IDTL[num, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
					MSG_IDTL[num, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
					MSG_IDTL[num, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
					MSG_IDTL[num, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
					MSG_IDTL[num, 12] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][12], (object)""));
					MSG_IDTL[num, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
					MSG_IDTL[num, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
					MSG_IDTL[num, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
					MSG_IDTL[num, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
					MSG_IDTL[num, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
					MSG_IDTL[num, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
					MSG_IDTL[num, 21] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][21], (object)""));
					MSG_IDTL[num, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
					MSG_IDTL[num, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
					MSG_IDTL[num, 24] = Conversions.ToString(DtIdtl.Rows[i][24]);
					MSG_IDTL.Rows += 1;
					num++;
				}
			}
			ItmStk(MSG.Row);
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 87], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 87] + "' AND IMAGE_TYPE = 'D'";
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
				DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 45];
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
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 45]))) ?? "";
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
							Image image;
							using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
							{
								image = Image.FromStream(stream);
							}
							PicImage.Image = image;
						}
						ProjectData.ClearProjectError();
					}
				}
				else
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 45]))) ?? "";
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
						Image image2;
						using (Stream stream2 = File.OpenRead(DC_Main.MsImagePath))
						{
							image2 = Image.FromStream(stream2);
						}
						PicImage.Image = image2;
					}
				}
			}
			MSG_IDTL[num, 0] = Conversions.ToString(num);
			MSG_IDTL[num, 23] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 50]));
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
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
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
		if (!(((int)e.KeyCode == 86) & e.Control))
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_CODE MasterAcL,B.AC_NAME As AcMastNameL,A.AC_CODE As VchAcL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.AC_NAME <> A.AC_NAME AND A.AC_CODE <> '00045'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 0.0;
		DC_Main.ColWidth[5] = 300.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 150.0;
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

	private void TR_SALE_HM_Closed(object sender, EventArgs e)
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
		//IL_25fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2604: Invalid comparison between Unknown and I4
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_27e9: Unknown result type (might be due to invalid IL or missing references)
		if (((int)e.KeyCode == 112) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			tAcCode.Text = "";
			tAcName.Text = "";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,TOT_AMT As BillAmtR,A.CO_BOOK As MBookL FROM (SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  C.WITH_MOBILE_ENTRY = 'Y'  ORDER BY A.VCH_NO";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,B.AC_REF_NAME As RefByL,TOT_AMT As BillAmtR,A.CO_BOOK As MBookL FROM (SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_BOOK = C.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND (A.CO_BOOK = '033' OR C.WITH_MOBILE_ENTRY = 'Y' ) ORDER BY A.VCH_NO";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[8];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 250.0;
			DC_Main.ColWidth[5] = 120.0;
			DC_Main.ColWidth[6] = 100.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose || DC_Main.HelpClose)
			{
				return;
			}
			checked
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					CLEAR_DATA();
					MoBook = DC_Main.ColValue[6];
					MoVch = DC_Main.ColValue[0];
					DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + MoBook + "' AND VCH_NO = '" + MoVch + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (RsData.Rows.Count > 0)
					{
						tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
						tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
						DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
						DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.RsAc.Rows.Count > 0)
						{
							tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
						}
						OldAcCode = tAcCode.Text;
						tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
						AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
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
						DC_Main.MsAcGoldOpBal = 0.0;
						DC_Main.MsAcSilverOpBal = 0.0;
						DC_Main.MsAcAmtClBal = 0.0;
						DC_Main.MsAcGoldClBal = 0.0;
						DC_Main.MsAcSilverClBal = 0.0;
					}
					DtIdtl.Clear();
					DtIdtl.Reset();
					FilRow = 0;
					int num = MSG_IDTL.Cols - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
					{
						DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
						DC_Main.M++;
					}
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.PR_CODE,B.RATE_TYPE,B.IT_TYPE FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + MoBook + "' AND A.VCH_NO = '" + MoVch + "' ORDER BY A.SR_NO";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < RsDetl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 50] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"", false))
						{
							mSG[DC_Main.i + 1, 1] = "";
							mSG[DC_Main.i + 1, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
							mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							if (Conversion.Val(mSG[DC_Main.i + 1, 31]) == 0.0)
							{
								mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
							}
							mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
							mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
							mSG[DC_Main.i + 1, 45] = Conversions.ToString(0);
						}
						else
						{
							mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
							mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
							mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), RsDetl.Rows[DC_Main.i]["TAG_NO"]), (object)""), (object)"' AND A.ITM_GWT = '"), RsDetl.Rows[DC_Main.i]["ITM_GWT"]), (object)"' ORDER BY A.VCH_TIME DESC "));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
								mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
								mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
								mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
								mSG[DC_Main.i + 1, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
								mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
								mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""), (object)"", false))
								{
									mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
								}
								mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
								AxMSFlexGrid obj = mSG;
								int num2 = DC_Main.i + 1;
								object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"");
								obj[num2, 42] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								AxMSFlexGrid obj2 = mSG;
								int num3 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"");
								obj2[num3, 43] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
								AxMSFlexGrid obj3 = mSG;
								int num4 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
								obj3[num4, 33] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
								mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
								mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
								AxMSFlexGrid obj4 = mSG;
								int num5 = DC_Main.i + 1;
								Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
								obj4[num5, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
								mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
								mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
								mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
								mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
								if (Conversion.Val(mSG[DC_Main.i + 1, 31]) == 0.0)
								{
									mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
								}
								lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)" Itm : ", DC_Main.Rshlp.Rows[0]["IT_NAME"]), (object)""));
								mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
								mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
								mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
								mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
								mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
								mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
								mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[DC_Main.i + 1, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG[DC_Main.i + 1, 45]), (object)" "));
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.M = 0;
							while (DC_Main.M < DC_Main.Rshlp.Rows.Count)
							{
								dr = DtIdtl.NewRow();
								dr[23] = Conversion.Val(MSG[DC_Main.i + 1, 50]);
								dr[0] = DC_Main.M + 1;
								dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CODE"], (object)"");
								dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"], (object)"");
								dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_CODE"], (object)"");
								dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_NAME"], (object)"");
								dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_COLOR"], (object)"");
								dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_SIZE"], (object)"");
								dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_ORIGIN"], (object)"");
								dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_REMARK"], (object)"");
								dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["DM_SFNO"], (object)"");
								dr[10] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_PCS"]);
								dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_GWT"])), "0.000");
								dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_WT"])), "0.000");
								dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CON_PRC"])), "0.000");
								dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_RATE_TYPE"], (object)"");
								dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_RATE"])), "0.00");
								dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_AMT"])), "0.00");
								dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_LBR_RATE"])), "0.00");
								dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_LBR_AMT"])), "0.00");
								dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NET_AMT"])), "0.00");
								dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_CON_WT"])), "0.000");
								dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["KR_CON_WT"], (object)"")), "0.000");
								dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["IT_TYPE"], (object)"");
								dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["KR_WT"])), "0.000");
								DtIdtl.Rows.Add(dr);
								DC_Main.M++;
							}
						}
						ItmStk(MSG.Row);
						CommPassTotal();
						mSG.Rows += 1;
						DC_Main.i++;
					}
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					mSG = null;
				}
				else
				{
					MoBook = "";
					MoVch = "";
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
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
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.LC_CODE,A.AC_NAME";
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
			if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			}
			if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
			{
				OldAcCode = tAcCode.Text;
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CR_DAYS"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
				if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
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
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
			}
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				((Control)tAcName).Focus();
				return;
			}
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
		mSG2_TOTAL.Rows = 17;
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
				case 16:
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
				case 10:
				case 11:
				case 13:
				case 14:
				case 15:
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
				case 12:
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
			while (DC_Main.i <= 16);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tcs Amt : ";
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				mSG2_TOTAL[4, 0] = "Lbr Amt : ";
				mSG2_TOTAL[5, 0] = "Lbr Tax : ";
			}
			else
			{
				mSG2_TOTAL[4, 0] = "Hm Amt : ";
				mSG2_TOTAL[5, 0] = "Hm Tax : ";
			}
			mSG2_TOTAL[6, 0] = "Total Amt : ";
			mSG2_TOTAL[7, 0] = "Cheque Amt : ";
			mSG2_TOTAL[8, 0] = "Card Amt : ";
			mSG2_TOTAL[9, 0] = "Order Amt : ";
			mSG2_TOTAL[10, 0] = "Old Gold Amt : ";
			mSG2_TOTAL[11, 0] = "Old Silver Amt : ";
			mSG2_TOTAL[12, 0] = "Scheme Amt : ";
			mSG2_TOTAL[13, 0] = "Cash Amt : ";
			mSG2_TOTAL[14, 0] = "Cash Paid Amt : ";
			mSG2_TOTAL[15, 0] = "Kasar Amt : ";
			mSG2_TOTAL[16, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 16) | (mSG2_TOTAL.Row == 11) | (mSG2_TOTAL.Row == 10))
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
				if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 12))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 16) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 11) | (mSG2_TOTAL.Row == 10))
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
					if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 16))
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
			if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 12))
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_0539: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c0b: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				default:
					if (unchecked((int)keyCode) != 112 || mSG2_TOTAL.Row != 13 || MSG2_TOTAL.Col != 1)
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
					if (((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8) | (mSG2_TOTAL.Row == 12)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
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
							else if (mSG2_TOTAL.Row == 12)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '04')  ORDER BY A.AC_NAME";
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
									mSG2_TOTAL.Row = 5;
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
								mSG2_TOTAL.Row = 5;
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
							mSG2_TOTAL.Row = 5;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
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
									mSG2_TOTAL.Row = 5;
									mSG2_TOTAL.Col = 1;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 5;
								mSG2_TOTAL.Col = 1;
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
							mSG2_TOTAL.Row = 5;
							mSG2_TOTAL.Col = 1;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row != 5)
					{
						break;
					}
					if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
									mSG2_TOTAL[5, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									OldTcsPrc = 111.0;
									mSG2_TOTAL[5, 4] = DC_Main.ColValue[2];
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "";
									mSG2_TOTAL[5, 1] = "";
									mSG2_TOTAL[5, 2] = "";
									mSG2_TOTAL[5, 3] = "";
									mSG2_TOTAL[5, 4] = "";
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
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 5:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 7;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 2:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 7;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 13:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 14:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 9:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							MSG_ORD.Row = 1;
							MSG_ORD.Col = 1;
							MSG_ORD_EnterCell(MSG_ORD, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = false;
							((Control)TEXT_ORD).Focus();
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
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
					case 11:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if (Operators.CompareString(FormBookType, "T", false) == 0)
							{
								if (!DC_Main.MsOldPurc & (OldGoldPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 10))
								{
									DC_Main.MsSlAcCode = tAcCode.Text;
									DC_Main.CustUrdName = tAcName.Text;
									DC_Main.MsOldPurc = true;
									DC_Main.MsSlBill = tVchNo.Text;
									DC_Main.MsSlBillHdNo = tHdVchNo.Text;
									DC_Main.MsSlYrCd = DC_Main.MCo_year;
									DC_Main.MsSlDbCd = DC_Main.MCo_Book;
									DC_Main.CurBook = "043";
									DC_Main.CurBookType = "T";
									DC_Main.CurBookName = "Gold URD Purchase";
									DC_Main.CurBookItm = "G";
									DC_Main.CurBookMain = "PURCHASE";
									DC_Main.CurBookSname = "GLURD";
									DC_Main.CurBookInOut = "I";
									if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
									{
										TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
										((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC_HM).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC_HM).Show();
										((Control)tR_PURC_HM).Focus();
									}
									else
									{
										TR_PURC tR_PURC = new TR_PURC();
										((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC).Show();
										((Control)tR_PURC).Focus();
									}
									return;
								}
								if (!DC_Main.MsOldPurcSl & (OldSilverPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 11))
								{
									DC_Main.MsSlAcCode = tAcCode.Text;
									DC_Main.CustUrdName = tAcName.Text;
									DC_Main.MsOldPurcSl = true;
									DC_Main.MsSlBill = tVchNo.Text;
									DC_Main.MsSlBillHdNo = tHdVchNo.Text;
									DC_Main.MsSlYrCd = DC_Main.MCo_year;
									DC_Main.MsSlDbCd = DC_Main.MCo_Book;
									DC_Main.CurBook = "044";
									DC_Main.CurBookType = "T";
									DC_Main.CurBookName = "Silver URD Purchase";
									DC_Main.CurBookItm = "S";
									DC_Main.CurBookMain = "PURCHASE";
									DC_Main.CurBookSname = "SLURD";
									DC_Main.CurBookInOut = "I";
									if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
									{
										TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
										((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC_HM2).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC_HM2).Show();
										((Control)tR_PURC_HM2).Focus();
									}
									else
									{
										TR_PURC tR_PURC2 = new TR_PURC();
										((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
										DC_Main.TotOpenForm++;
										((Form)tR_PURC2).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
										((Control)tR_PURC2).Show();
										((Control)tR_PURC2).Focus();
									}
									return;
								}
								break;
							}
							MSG_OLD.Row = 1;
							MSG_OLD.Col = 1;
							MSG_OLD_EnterCell(MSG_OLD, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = false;
							return;
						}
						BILL_TOTAL();
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 15:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					case 12:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0))
							{
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
							}
							else if (!DC_Main.MsSlAdj & (OlsSchmAmt != Conversion.Val(TEXT_ENTRY_2.Text)))
							{
								DC_Main.MsSlBill = tVchNo.Text;
								DC_Main.MsSlBillHdNo = tHdVchNo.Text;
								DC_Main.MsSlAcCode = tAcCode.Text;
								DC_Main.MsSlYrCd = DC_Main.MCo_year;
								DC_Main.MsSlDbCd = DC_Main.MCo_Book;
								DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[6, 3]);
								DC_Main.MsSlAdj = true;
								DC_Main.CurBookHelp("MEMB ADJUST");
								if (Operators.CompareString(DC_Main.CurBook, "", false) != 0)
								{
									TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
									((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
									DC_Main.TotOpenForm++;
									((Form)tR_MEMB_ADJ).Text = DC_Main.MsUserRightForm + " " + Conversions.ToString(DC_Main.TotOpenForm);
									((Control)tR_MEMB_ADJ).Show();
									((Control)tR_MEMB_ADJ).Focus();
								}
							}
							else
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								BILL_TOTAL();
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Visible = true;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
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
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 23]), DC_Main.MsTotAmtRof), "0.00");
			if (Conversion.Val(mSG2_TOTAL[5, 2]) != 0.0)
			{
				mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[4, 3]) * Conversion.Val(mSG2_TOTAL[5, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
		}
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "VS332NUBU", false) == 0)
		{
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 23]), DC_Main.MsTotAmtRof), "0.00");
			if (Conversion.Val(mSG2_TOTAL[5, 2]) != 0.0)
			{
				mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[4, 3]) * Conversion.Val(mSG2_TOTAL[5, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
		}
		else
		{
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 32]), 0), "0.00");
			if (Conversion.Val(mSG2_TOTAL[5, 2]) != 0.0)
			{
				mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[4, 3]) * Conversion.Val(mSG2_TOTAL[5, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			}
		}
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 31]) - Conversion.Val(MSG_TOT[0, 23]), DC_Main.MsTotAmtRof), "0.00");
		}
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "VS332NUBU", false) == 0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 31]) - Conversion.Val(MSG_TOT[0, 23]), DC_Main.MsTotAmtRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 31]), 0), "0.00");
		}
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 23]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if ((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) != OldNetAmt) | (Conversion.Val(mSG2_TOTAL[2, 2]) != OldTaxPrc))
		{
			OldNetAmt = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]);
			OldTaxPrc = Conversion.Val(mSG2_TOTAL[2, 2]);
			OldTcsPrc = 111.0;
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
		}
		if ((Operators.CompareString(EntryMode, "A", false) == 0) & (Operators.CompareString(tAcCode.Text, "00045", false) != 0))
		{
			if (AcTcsAmt + (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3])) - Conversion.Val(mSG2_TOTAL[1, 3]) > 5000000.0)
			{
				if ((OldTcsPrc != Conversion.Val(MSG2_TOTAL[3, 2])) & (Operators.CompareString(MSG2_TOTAL[3, 4], "00", false) != 0))
				{
					if (Operators.CompareString(FormBookType, "T", false) == 0)
					{
						DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '20'";
						DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.RsTax.Rows.Count > 0)
						{
							TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
							MSG2_TOTAL[3, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
							AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
							double num = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							mSG2_TOTAL2[3, 2] = Strings.Format((object)num, "0.000");
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
							double num2 = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							OldTcsPrc = Conversions.ToDouble(Strings.Format((object)num2, "0.000"));
							MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
							double num3 = 5000000.0 - AcTcsAmt;
							double num4 = 0.0;
							num4 = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + num3);
							if (num3 > 0.0)
							{
								mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round(num4 * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
							}
							else
							{
								mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
							}
						}
					}
				}
				else if (Operators.CompareString(MSG2_TOTAL[3, 4], "00", false) == 0)
				{
					MSG2_TOTAL[3, 3] = "";
				}
			}
		}
		else if (OldTcsPrc != Conversion.Val(MSG2_TOTAL[3, 2]))
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
		mSG2_TOTAL[6, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]), DC_Main.MsTotAmtRof), "0.00");
		mSG2_TOTAL[9, 3] = "";
		checked
		{
			int num5 = MSG_ORD.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) + Conversion.Val(MSG_ORD[DC_Main.M, 2])), "0.00");
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MCo_BookType, "M", false) == 0)
			{
				mSG2_TOTAL[10, 2] = "";
				mSG2_TOTAL[10, 3] = "";
				mSG2_TOTAL[11, 2] = "";
				mSG2_TOTAL[11, 3] = "";
				int num6 = MSG_OLD.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num6)
				{
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 11], "G", false) == 0)
					{
						mSG2_TOTAL[10, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");
						mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[10, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 10])), "0.00");
					}
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 11], "S", false) == 0)
					{
						mSG2_TOTAL[11, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[11, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 6])), "0.000");
						mSG2_TOTAL[11, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[11, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 10])), "0.00");
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				if (Conversion.Val(mSG2_TOTAL[10, 3]) + Conversion.Val(mSG2_TOTAL[11, 3]) > Conversion.Val(mSG2_TOTAL[6, 3]))
				{
					mSG2_TOTAL[14, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[10, 3]) + Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]), 0), "0.00");
					mSG2_TOTAL[13, 3] = "";
					mSG2_TOTAL[16, 3] = "0.00";
				}
				else
				{
					mSG2_TOTAL[13, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[15, 3]), 0), "0.00");
					mSG2_TOTAL[16, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[13, 1]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]) - Conversion.Val(mSG2_TOTAL[13, 3]) + Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[15, 3])), "0.00");
				}
			}
			else
			{
				mSG2_TOTAL[16, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[13, 1]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3]) - Conversion.Val(mSG2_TOTAL[12, 3]) - Conversion.Val(mSG2_TOTAL[13, 3]) + Conversion.Val(mSG2_TOTAL[14, 3]) - Conversion.Val(mSG2_TOTAL[15, 3])), "0.00");
			}
			if (CustOpAmt > 0.0)
			{
				if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
				{
					CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[16, 3]);
				}
				else
				{
					CustClAmt = CustOpAmt - (Conversion.Val(mSG2_TOTAL[16, 3]) + Conversion.Val(mSG2_TOTAL[9, 3]));
				}
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = 0.0 - (Math.Abs(CustOpAmt) + (Conversion.Val(mSG2_TOTAL[16, 3]) + Conversion.Val(mSG2_TOTAL[9, 3])));
			}
			else
			{
				CustClAmt = 0.0 - Conversion.Val(mSG2_TOTAL[16, 3]);
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
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		if (Strings.Len(tAcName.Text) > 3)
		{
			MobileSearch = true;
		}
		else
		{
			MobileSearch = false;
		}
		if (!((Strings.Len(tAcName.Text) >= 2) & !MobileSearch & Versioned.IsNumeric((object)tAcName.Text)))
		{
			return;
		}
		DC_Main.MsMobileLen = tAcName.Text;
		MobileSearch = true;
		DC_Main.RsQry = "SELECT A.AC_MOBILE As MobileL,A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND SUBSTRING(A.AC_MOBILE,1,2)  = '" + Strings.Mid(tAcName.Text, 1, 2) + "'  ORDER BY A.AC_MOBILE";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 120.0;
		DC_Main.ColWidth[1] = 300.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (DC_Main.HelpClose)
		{
			return;
		}
		if (DC_Main.MsCreat)
		{
			MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();
			((Form)mS_ADD_MAST).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)mS_ADD_MAST).Show();
			((Control)mS_ADD_MAST).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			tAcName.Text = DC_Main.ColValue[1];
			tAdd1.Text = DC_Main.ColValue[3];
			tCity.Text = DC_Main.ColValue[4];
			tMobile.Text = DC_Main.ColValue[0];
		}
		MobileSearch = false;
		((Control)tAcName).Focus();
	}

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Invalid comparison between Unknown and I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Invalid comparison between Unknown and I4
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[6];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				MS_ADD_MAST mS_ADD_MAST = new MS_ADD_MAST();
				((Form)mS_ADD_MAST).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)mS_ADD_MAST).Show();
				((Control)mS_ADD_MAST).Focus();
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tAcName.Text = DC_Main.ColValue[0];
				tAdd1.Text = DC_Main.ColValue[2];
				tCity.Text = DC_Main.ColValue[3];
				tMobile.Text = DC_Main.ColValue[4];
			}
			((Control)tAcName).Focus();
		}
		else
		{
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
			else
			{
				MSG.Col = 1;
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
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
		if ((int)e.KeyCode == 13)
		{
			((Control)PanelAdd).Visible = false;
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tItDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 3;
			MSG[MSG.Row, 68] = tItDesc.Text;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tEmpCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tIsuNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int num5 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					AxMSFlexGrid obj;
					int num6;
					Type? typeFromHandle;
					object[] obj2;
					DataRowView dataRowView;
					object[] array;
					bool[] obj3;
					bool[] array2;
					object obj4;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (unchecked((int)e.KeyCode) != 13)
						{
							goto end_IL_0001;
						}
						goto IL_0015;
					case 7027:
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
								goto IL_0015;
							case 3:
								goto IL_0094;
							case 4:
								goto IL_00a5;
							case 5:
								goto IL_00bf;
							case 7:
								goto IL_00da;
							case 8:
								goto IL_0111;
							case 9:
								goto IL_0151;
							case 10:
								goto IL_0163;
							case 11:
								goto IL_017e;
							case 12:
								goto IL_01b6;
							case 13:
								goto IL_01bf;
							case 14:
								goto IL_01c9;
							case 17:
								goto IL_01d9;
							case 18:
								goto IL_01f8;
							case 19:
								goto IL_022f;
							case 20:
								goto IL_0270;
							case 21:
								goto IL_02b1;
							case 22:
								goto IL_02f2;
							case 23:
								goto IL_0342;
							case 24:
								goto IL_0382;
							case 25:
								goto IL_03c3;
							case 26:
								goto IL_03ff;
							case 28:
								goto IL_041b;
							case 27:
							case 29:
							case 30:
								goto IL_045c;
							case 31:
								goto IL_049c;
							case 32:
								goto IL_04dc;
							case 33:
								goto IL_051c;
							case 34:
								goto IL_055c;
							case 35:
								goto IL_05a6;
							case 36:
								goto IL_05dd;
							case 37:
								goto IL_0628;
							case 38:
								goto IL_0673;
							case 39:
								goto IL_06be;
							case 40:
								goto IL_0709;
							case 41:
								goto IL_0754;
							case 42:
								goto IL_079f;
							case 43:
								goto IL_07ea;
							case 44:
								goto IL_0835;
							case 45:
								goto IL_0880;
							case 46:
								goto IL_08cb;
							case 47:
								goto IL_0916;
							case 48:
								goto IL_0961;
							case 49:
								goto IL_09ac;
							case 50:
								goto IL_09ed;
							case 51:
								goto IL_0a38;
							case 52:
								goto IL_0a83;
							case 53:
								goto IL_0ace;
							case 54:
								goto IL_0b19;
							case 55:
								goto IL_0b5a;
							case 56:
								goto IL_0ba7;
							case 57:
								goto IL_0bbb;
							case 58:
								goto IL_0c00;
							case 59:
								goto IL_0c19;
							case 60:
								goto IL_0c40;
							case 62:
								goto IL_0cb4;
							case 63:
								goto IL_0cdb;
							case 65:
								goto IL_0d4f;
							case 66:
								goto IL_0d79;
							case 69:
								goto IL_0e15;
							case 61:
							case 64:
							case 67:
							case 68:
							case 70:
							case 71:
							case 72:
							case 73:
								goto IL_0e33;
							case 74:
								goto IL_0e7e;
							case 75:
								goto IL_0ec9;
							case 76:
								goto IL_0f14;
							case 77:
								goto IL_0f5f;
							case 78:
								goto IL_0fa0;
							case 79:
								goto IL_0fe1;
							case 80:
								goto IL_1022;
							case 81:
								goto IL_1063;
							case 82:
								goto IL_10a4;
							case 83:
								goto IL_10bd;
							case 84:
								goto IL_10cf;
							case 85:
								goto IL_10d9;
							case 86:
								goto IL_10ed;
							case 15:
							case 16:
							case 87:
								goto IL_10fd;
							case 88:
								goto IL_111f;
							case 89:
								goto IL_1134;
							case 90:
								goto IL_1137;
							case 91:
								goto IL_1141;
							case 92:
								goto IL_1150;
							case 93:
								goto IL_115f;
							case 94:
								goto IL_1169;
							case 95:
								goto IL_1183;
							case 96:
								goto IL_11a8;
							case 97:
								goto IL_11c0;
							case 98:
								goto IL_1240;
							case 99:
								goto IL_1253;
							case 102:
								goto IL_1261;
							case 103:
								goto IL_1275;
							case 104:
								goto IL_12aa;
							case 105:
								goto IL_12de;
							case 106:
								goto IL_1317;
							case 107:
								goto IL_1350;
							case 108:
								goto IL_1389;
							case 109:
								goto IL_13c2;
							case 110:
								goto IL_13fb;
							case 111:
								goto IL_1434;
							case 112:
								goto IL_146d;
							case 113:
								goto IL_14a6;
							case 114:
								goto IL_14e0;
							case 115:
								goto IL_1515;
							case 116:
								goto IL_155e;
							case 117:
								goto IL_15a7;
							case 118:
								goto IL_15f0;
							case 119:
								goto IL_162a;
							case 120:
								goto IL_1673;
							case 121:
								goto IL_16bc;
							case 122:
								goto IL_1705;
							case 123:
								goto IL_174e;
							case 124:
								goto IL_1797;
							case 125:
								goto IL_17e0;
							case 126:
								goto IL_182e;
							case 127:
								goto IL_1868;
							case 128:
								goto IL_18b1;
							case 129:
								goto IL_18ce;
							case 100:
							case 101:
							case 130:
								goto IL_18e1;
							case 131:
								goto IL_1904;
							case 132:
								goto IL_1911;
							case 133:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 6:
							case 134:
							case 135:
							case 136:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_10a4:
						num2 = 82;
						val[DC_Main.i + 1, 56] = "A";
						goto IL_10bd;
						IL_10bd:
						num2 = 83;
						val.Row = DC_Main.i + 1;
						goto IL_10cf;
						IL_1063:
						num2 = 81;
						val[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						goto IL_10a4;
						IL_10cf:
						num2 = 84;
						CommPassTotal();
						goto IL_10d9;
						IL_0015:
						num2 = 2;
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.GR_CODE aS RateGr FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND ISU_REC = 'N'";
						goto IL_0094;
						IL_0094:
						num2 = 3;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_00a5;
						IL_00a5:
						num2 = 4;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_00bf;
						}
						goto IL_00da;
						IL_00bf:
						num2 = 5;
						btnIsuNo_Click(btnIsuNo, new EventArgs());
						goto end_IL_0001;
						IL_00da:
						num2 = 7;
						tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
						goto IL_0111;
						IL_0111:
						num2 = 8;
						DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
						goto IL_0151;
						IL_0151:
						num2 = 9;
						DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0163;
						IL_0163:
						num2 = 10;
						if (DC_Main.RsAc.Rows.Count > 0)
						{
							goto IL_017e;
						}
						goto IL_01b6;
						IL_017e:
						num2 = 11;
						tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
						goto IL_01b6;
						IL_01b6:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_01bf;
						IL_01bf:
						num2 = 13;
						DC_Main.i = 0;
						goto IL_01c9;
						IL_01c9:
						num2 = 14;
						val = MSG;
						goto IL_10fd;
						IL_10fd:
						num2 = 16;
						if (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							goto IL_01d9;
						}
						goto IL_111f;
						IL_111f:
						num2 = 88;
						val.Rows -= 1;
						goto IL_1134;
						IL_1134:
						val = null;
						goto IL_1137;
						IL_1137:
						num2 = 90;
						MSG_TOT_FILL();
						goto IL_1141;
						IL_1141:
						num2 = 91;
						DtIdtl.Clear();
						goto IL_1150;
						IL_1150:
						num2 = 92;
						DtIdtl.Reset();
						goto IL_115f;
						IL_115f:
						num2 = 93;
						FilRow = 0;
						goto IL_1169;
						IL_1169:
						num2 = 94;
						num5 = MSG_IDTL.Cols - 1;
						DC_Main.M = 0;
						goto IL_11b7;
						IL_11b7:
						if (DC_Main.M <= num5)
						{
							goto IL_1183;
						}
						goto IL_11c0;
						IL_11c0:
						num2 = 97;
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
						goto IL_1240;
						IL_1240:
						num2 = 98;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1253;
						IL_1253:
						num2 = 99;
						DC_Main.i = 0;
						goto IL_18e1;
						IL_18e1:
						num2 = 101;
						if (DC_Main.i < RsIdtl.Rows.Count)
						{
							goto IL_1261;
						}
						goto IL_1904;
						IL_1904:
						num2 = 131;
						MsgOldRow = 0;
						goto IL_1911;
						IL_1911:
						num2 = 132;
						MSG_RowColChange(MSG, new EventArgs());
						break;
						IL_1261:
						num2 = 102;
						dr = DtIdtl.NewRow();
						goto IL_1275;
						IL_1275:
						num2 = 103;
						dr[23] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
						goto IL_12aa;
						IL_12aa:
						num2 = 104;
						dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
						goto IL_12de;
						IL_12de:
						num2 = 105;
						dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
						goto IL_1317;
						IL_1317:
						num2 = 106;
						dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
						goto IL_1350;
						IL_1350:
						num2 = 107;
						dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
						goto IL_1389;
						IL_1389:
						num2 = 108;
						dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
						goto IL_13c2;
						IL_13c2:
						num2 = 109;
						dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
						goto IL_13fb;
						IL_13fb:
						num2 = 110;
						dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
						goto IL_1434;
						IL_1434:
						num2 = 111;
						dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
						goto IL_146d;
						IL_146d:
						num2 = 112;
						dr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
						goto IL_14a6;
						IL_14a6:
						num2 = 113;
						dr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
						goto IL_14e0;
						IL_14e0:
						num2 = 114;
						dr[10] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
						goto IL_1515;
						IL_1515:
						num2 = 115;
						dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
						goto IL_155e;
						IL_155e:
						num2 = 116;
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
						goto IL_15a7;
						IL_15a7:
						num2 = 117;
						dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
						goto IL_15f0;
						IL_15f0:
						num2 = 118;
						dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						goto IL_162a;
						IL_162a:
						num2 = 119;
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
						goto IL_1673;
						IL_1673:
						num2 = 120;
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
						goto IL_16bc;
						IL_16bc:
						num2 = 121;
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
						goto IL_1705;
						IL_1705:
						num2 = 122;
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
						goto IL_174e;
						IL_174e:
						num2 = 123;
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
						goto IL_1797;
						IL_1797:
						num2 = 124;
						dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
						goto IL_17e0;
						IL_17e0:
						num2 = 125;
						dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
						goto IL_182e;
						IL_182e:
						num2 = 126;
						dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						goto IL_1868;
						IL_1868:
						num2 = 127;
						dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
						goto IL_18b1;
						IL_18b1:
						num2 = 128;
						DtIdtl.Rows.Add(dr);
						goto IL_18ce;
						IL_18ce:
						num2 = 129;
						DC_Main.i++;
						goto IL_18e1;
						IL_1183:
						num2 = 95;
						DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
						goto IL_11a8;
						IL_11a8:
						num2 = 96;
						DC_Main.M++;
						goto IL_11b7;
						IL_01d9:
						num2 = 17;
						val[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						goto IL_01f8;
						IL_01f8:
						num2 = 18;
						val[DC_Main.i + 1, 50] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
						goto IL_022f;
						IL_022f:
						num2 = 19;
						val[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
						goto IL_0270;
						IL_0270:
						num2 = 20;
						val[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"], (object)""));
						goto IL_02b1;
						IL_02b1:
						num2 = 21;
						val[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"], (object)""));
						goto IL_02f2;
						IL_02f2:
						num2 = 22;
						val[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"], (object)"")), "0");
						goto IL_0342;
						IL_0342:
						num2 = 23;
						val[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
						goto IL_0382;
						IL_0382:
						num2 = 24;
						val[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
						goto IL_03c3;
						IL_03c3:
						num2 = 25;
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
						{
							goto IL_03ff;
						}
						goto IL_041b;
						IL_03ff:
						num2 = 26;
						val[DC_Main.i + 1, 1] = "";
						goto IL_045c;
						IL_041b:
						num2 = 28;
						val[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
						goto IL_045c;
						IL_045c:
						num2 = 30;
						val[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						goto IL_049c;
						IL_049c:
						num2 = 31;
						val[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						goto IL_04dc;
						IL_04dc:
						num2 = 32;
						val[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						goto IL_051c;
						IL_051c:
						num2 = 33;
						val[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
						goto IL_055c;
						IL_055c:
						num2 = 34;
						val[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						goto IL_05a6;
						IL_05a6:
						num2 = 35;
						val[DC_Main.i + 1, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
						goto IL_05dd;
						IL_05dd:
						num2 = 36;
						val[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						goto IL_0628;
						IL_0628:
						num2 = 37;
						val[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						goto IL_0673;
						IL_0673:
						num2 = 38;
						val[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						goto IL_06be;
						IL_06be:
						num2 = 39;
						val[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						goto IL_0709;
						IL_0709:
						num2 = 40;
						val[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						goto IL_0754;
						IL_0754:
						num2 = 41;
						val[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						goto IL_079f;
						IL_079f:
						num2 = 42;
						val[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						goto IL_07ea;
						IL_07ea:
						num2 = 43;
						val[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						goto IL_0835;
						IL_0835:
						num2 = 44;
						val[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						goto IL_0880;
						IL_0880:
						num2 = 45;
						val[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						goto IL_08cb;
						IL_08cb:
						num2 = 46;
						val[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						goto IL_0916;
						IL_0916:
						num2 = 47;
						val[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						goto IL_0961;
						IL_0961:
						num2 = 48;
						val[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						goto IL_09ac;
						IL_09ac:
						num2 = 49;
						val[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						goto IL_09ed;
						IL_09ed:
						num2 = 50;
						val[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						goto IL_0a38;
						IL_0a38:
						num2 = 51;
						val[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						goto IL_0a83;
						IL_0a83:
						num2 = 52;
						val[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						goto IL_0ace;
						IL_0ace:
						num2 = 53;
						val[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						goto IL_0b19;
						IL_0b19:
						num2 = 54;
						val[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						goto IL_0b5a;
						IL_0b5a:
						num2 = 55;
						if ((Conversion.Val(val[DC_Main.i + 1, 18]) == 0.0) & (Conversion.Val(val[DC_Main.i + 1, 26]) == 0.0))
						{
							goto IL_0ba7;
						}
						goto IL_0e33;
						IL_0ba7:
						num2 = 56;
						if (DC_Main.RtView != null)
						{
							goto IL_0bbb;
						}
						goto IL_0e33;
						IL_0bbb:
						num2 = 57;
						DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[DC_Main.i]["RateGr"]), (object)"'"));
						goto IL_0c00;
						IL_0c00:
						num2 = 58;
						if (DC_Main.RtView.Count > 0)
						{
							goto IL_0c19;
						}
						goto IL_0e15;
						IL_0c19:
						num2 = 59;
						if (Operators.CompareString(val[DC_Main.i + 1, 51], "G", false) == 0)
						{
							goto IL_0c40;
						}
						goto IL_0cb4;
						IL_0c40:
						num2 = 60;
						val[DC_Main.i + 1, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
							2
						}, (string[])null, (Type[])null, (bool[])null)), "0.00");
						goto IL_0e33;
						IL_0cb4:
						num2 = 62;
						if (Operators.CompareString(val[DC_Main.i + 1, 51], "K", false) == 0)
						{
							goto IL_0cdb;
						}
						goto IL_0d4f;
						IL_0cdb:
						num2 = 63;
						val[DC_Main.i + 1, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
						{
							Operators.DivideObject(DC_Main.RtView[0]["GR_RATE"], (object)10),
							0
						}, (string[])null, (Type[])null, (bool[])null)), "0.00");
						goto IL_0e33;
						IL_0d4f:
						num2 = 65;
						if (Operators.CompareString(val[DC_Main.i + 1, 51], "1", false) == 0)
						{
							goto IL_0d79;
						}
						goto IL_0e33;
						IL_0d79:
						num2 = 66;
						obj = val;
						num6 = DC_Main.i + 1;
						typeFromHandle = typeof(Math);
						obj2 = new object[2]
						{
							(dataRowView = DC_Main.RtView[0])["GR_RATE"],
							0
						};
						array = obj2;
						obj3 = new bool[2] { true, false };
						array2 = obj3;
						obj4 = NewLateBinding.LateGet((object)null, typeFromHandle, "Round", obj2, (string[])null, (Type[])null, obj3);
						if (array2[0])
						{
							dataRowView["GR_RATE"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
						}
						obj[num6, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(obj4), "0.00");
						goto IL_0e33;
						IL_10ed:
						num2 = 86;
						DC_Main.i++;
						goto IL_10fd;
						IL_10d9:
						num2 = 85;
						val.Rows += 1;
						goto IL_10ed;
						IL_0e15:
						num2 = 69;
						val[DC_Main.i + 1, 18] = "";
						goto IL_0e33;
						IL_0e33:
						num2 = 73;
						val[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						goto IL_0e7e;
						IL_0e7e:
						num2 = 74;
						val[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						goto IL_0ec9;
						IL_0ec9:
						num2 = 75;
						val[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						goto IL_0f14;
						IL_0f14:
						num2 = 76;
						val[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						goto IL_0f5f;
						IL_0f5f:
						num2 = 77;
						val[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
						goto IL_0fa0;
						IL_0fa0:
						num2 = 78;
						val[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						goto IL_0fe1;
						IL_0fe1:
						num2 = 79;
						val[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						goto IL_1022;
						IL_1022:
						num2 = 80;
						val[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						goto IL_1063;
						end_IL_0001_3:
						break;
					}
					num2 = 133;
					((Control)tAcCode).Focus();
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj5) when (obj5 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj5);
				try0001_dispatch = 7027;
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

	private void btnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.AC_NAME As PartyNameL,COUNT(*) As TagQtyM,A.CO_YEAR As YearL,A.CO_BOOK As BookL FROM (APR_DETL AS A   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'APR ISU'  AND A.ISU_REC = 'N' GROUP BY A.VCH_NO,A.VCH_DATE,C.AC_NAME,A.CO_YEAR,A.CO_BOOK ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 250.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 110.0;
		DC_Main.ColWidth[5] = 90.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tIsuNo.Text = DC_Main.ColValue[0];
				tIsuYrCd.Text = DC_Main.ColValue[4];
				tIsuDbCd.Text = DC_Main.ColValue[5];
				((Control)tIsuNo).Focus();
			}
			else
			{
				((Control)tIsuNo).Focus();
			}
		}
	}

	private void nCrDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tPanNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13 && Operators.CompareString(tPanNo.Text, "", false) != 0)
		{
			DC_Main.ExeQuteDc("UPDATE AC_MAST SET AC_PANNO = '" + tPanNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'");
			Interaction.MsgBox((object)"Pancard is Update...", (MsgBoxStyle)0, (object)null);
			((Control)tPanNo).Visible = false;
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnTagSet_Click(object sender, EventArgs e)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		FormPrintFile = cboPrintfile.Text;
		Interaction.MsgBox((object)"Print Report Default Set", (MsgBoxStyle)0, (object)null);
	}

	private void TR_SALE_HM_DoubleClick(object sender, EventArgs e)
	{
		((Control)tNewPrint).Visible = true;
	}

	private void tNewPrint_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + tNewPrint.Text + "' AND PRINT_TYPE = '" + FormMainBook + "' AND BOOK_TYPE = '" + FormBookType + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "INSERT INTO PRINT_MAST(CO_CODE,PRINT_TYPE,PRINT_FILE,PRINT_SET_A,BOOK_TYPE) VALUES ('01','" + FormMainBook + "','" + tNewPrint.Text + "','N','" + FormBookType + "')";
				DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				Interaction.MsgBox((object)"New Report is Insert ok...Please This Form Close And Reopen...", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"This Report is Alrady Exsist...", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void tTrfrNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(EntryMode, "A", false) != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT * FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME AS CustNameL,VCH_NO AS VchNoL,replace(convert(NVARCHAR,VCH_DATE, 103), ' ', '/') AS VchDateL ,B.BOOK_NAME As BookL,A.AC_CODE,A.CO_BOOK As BookL ,A.CO_YEAR As YearL,A.TOT_AMT As BillAmtR FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.MAIN_BOOK = 'SALES' AND A.CO_BOOK <> '" + DC_Main.MCo_Book + "' ORDER BY A.CO_BOOK,A.VCH_NO ";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 350.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 120.0;
			DC_Main.ColWidth[3] = 200.0;
			DC_Main.ColWidth[4] = 0.0;
			DC_Main.ColWidth[5] = 0.0;
			DC_Main.ColWidth[6] = 0.0;
			DC_Main.ColWidth[7] = 110.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tTrfrNo.Text = DC_Main.ColValue[1];
				tAcName.Text = DC_Main.ColValue[3];
				tAcCode.Text = DC_Main.ColValue[4];
				tTrfrDbCd.Text = DC_Main.ColValue[5];
				tTrfrYrCd.Text = DC_Main.ColValue[6];
				((Control)tTrfrNo).Focus();
			}
			else
			{
				((Control)tTrfrNo).Focus();
			}
		}
		else
		{
			((Control)tTrfrNo).Enabled = false;
			MainDbCd = DC_Main.MCo_Book;
			MainVchNo = tVchNo.Text;
			MainHdVchNo = tHdVchNo.Text;
			DC_Main.MCo_Book = tTrfrDbCd.Text;
			tVchNo.Text = tTrfrNo.Text;
			DISPLAY_DATA();
			((Control)BtnSave).Enabled = false;
			DC_Main.MCo_Book = MainDbCd;
			tVchNo.Text = MainVchNo;
			tHdVchNo.Text = MainHdVchNo;
		}
	}

	private void lblTrfrOpen_Click(object sender, EventArgs e)
	{
		((Control)PnlTrfrVch).Visible = true;
		((Control)tTrfrNo).Focus();
	}

	private void btnTrfr_Click(object sender, EventArgs e)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0714: Unknown result type (might be due to invalid IL or missing references)
		if (!((Operators.CompareString(tTrfrDbCd.Text, "", false) == 0) & (Operators.CompareString(tTrfrNo.Text, "", false) == 0)) && (int)Interaction.MsgBox((object)"Are You Sour To Transfer Voucher ?", (MsgBoxStyle)292, (object)"DataCare Message") == 6)
		{
			DC_Main.ExeQuteDc("UPDATE SL_DATA SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_DETL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_IDTL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_ORD_ADJ SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE SL_PR_DETL SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("UPDATE BILL_OS_DATA SET VCH_NO = '" + tVchNo.Text + "',CO_BOOK = '" + DC_Main.MCo_Book + "',HD_VCH_NO = '" + tHdVchNo.Text + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tTrfrYrCd.Text + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tTrfrDbCd.Text + "' AND VCH_NO = '" + tTrfrNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			Ac_Ledr.Sales_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Rojmel.Sales_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Tax.Sales_GST(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Stock.Sale_Stk(DC_Main.MCo_Book, tVchNo.Text);
			Interaction.MsgBox((object)"Voucher are transferred sucessfully...", (MsgBoxStyle)0, (object)null);
			CLEAR_DATA();
			((Control)PnlTrfrVch).Visible = false;
		}
	}

	private void TR_SALE_HM_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_OLD", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_OLD).SelectionStart = 0;
			((TextBoxBase)TEXT_OLD).SelectionLength = Strings.Len(TEXT_OLD.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}
}
