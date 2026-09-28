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
public class TR_SALE_RTN_UAE : Form
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
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

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
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tNewPrint")]
	private TextBox _tNewPrint;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string WappAcName;

	private string WappMobile;

	private string WappMsg;

	private string AdminWappMsg;

	private string TblData;

	private string TblDetl;

	private string TblIdtl;

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

	private DataTable RsBarDetl;

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

	private const int cDesign = 4;

	private const int cSize = 5;

	private const int cHmId = 6;

	private const int cBagWt = 7;

	private const int cPcs = 8;

	private const int cGrWt = 9;

	private const int cOthWt = 10;

	private const int cNetWt = 11;

	private const int cGhtPrc = 12;

	private const int cGhtWt = 13;

	private const int cTouch = 14;

	private const int cWestPrc = 15;

	private const int cFine = 16;

	private const int cSlRatWith = 17;

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

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cHmAmt2 = 4;

	private const int cHmTax2 = 5;

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
	[AccessedThroughProperty("lblTrfrOpen")]
	private virtual Label _lblTrfrOpen;

	internal virtual Label lblTrfrOpen
	{
		get
		{
			return _lblTrfrOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblTrfrOpen = value;
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

	public TR_SALE_RTN_UAE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_RTN_UAE_Load;
		((Form)this).Deactivate += TR_SALE_RTN_UAE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_RTN_UAE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_RTN_UAE_KeyDown);
		((Form)this).Activated += TR_SALE_RTN_UAE_Activated;
		((Form)this).Closed += TR_SALE_RTN_UAE_Closed;
		((Control)this).DoubleClick += TR_SALE_RTN_UAE_DoubleClick;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_RTN_UAE_KeyUp);
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
		//IL_0446: Unknown result type (might be due to invalid IL or missing references)
		//IL_0450: Expected O, but got Unknown
		//IL_0502: Unknown result type (might be due to invalid IL or missing references)
		//IL_050c: Expected O, but got Unknown
		//IL_058f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0599: Expected O, but got Unknown
		//IL_0636: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_06ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f8: Expected O, but got Unknown
		//IL_077f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0789: Expected O, but got Unknown
		//IL_0824: Unknown result type (might be due to invalid IL or missing references)
		//IL_082e: Expected O, but got Unknown
		//IL_08bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c7: Expected O, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Expected O, but got Unknown
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e7: Expected O, but got Unknown
		//IL_0a4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a54: Expected O, but got Unknown
		//IL_0afd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b07: Expected O, but got Unknown
		//IL_0c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c2e: Expected O, but got Unknown
		//IL_0d39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Expected O, but got Unknown
		//IL_0da6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db0: Expected O, but got Unknown
		//IL_0f42: Unknown result type (might be due to invalid IL or missing references)
		//IL_101a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1024: Expected O, but got Unknown
		//IL_10d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10da: Expected O, but got Unknown
		//IL_11d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dc: Expected O, but got Unknown
		//IL_12ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f7: Expected O, but got Unknown
		//IL_1374: Unknown result type (might be due to invalid IL or missing references)
		//IL_137e: Expected O, but got Unknown
		//IL_1442: Unknown result type (might be due to invalid IL or missing references)
		//IL_144c: Expected O, but got Unknown
		//IL_14f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14fd: Expected O, but got Unknown
		//IL_15f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1602: Expected O, but got Unknown
		//IL_1663: Unknown result type (might be due to invalid IL or missing references)
		//IL_166d: Expected O, but got Unknown
		//IL_1779: Unknown result type (might be due to invalid IL or missing references)
		//IL_1783: Expected O, but got Unknown
		//IL_185b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1865: Expected O, but got Unknown
		//IL_1901: Unknown result type (might be due to invalid IL or missing references)
		//IL_190b: Expected O, but got Unknown
		//IL_1a46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a50: Expected O, but got Unknown
		//IL_1a9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa5: Expected O, but got Unknown
		//IL_1b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2c: Expected O, but got Unknown
		//IL_1bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb7: Expected O, but got Unknown
		//IL_1c81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8b: Expected O, but got Unknown
		//IL_1d32: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3c: Expected O, but got Unknown
		//IL_1dbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc7: Expected O, but got Unknown
		//IL_1e4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e59: Expected O, but got Unknown
		//IL_1f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f17: Expected O, but got Unknown
		//IL_1fcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fd5: Expected O, but got Unknown
		//IL_2077: Unknown result type (might be due to invalid IL or missing references)
		//IL_2081: Expected O, but got Unknown
		//IL_2102: Unknown result type (might be due to invalid IL or missing references)
		//IL_210c: Expected O, but got Unknown
		//IL_21d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e0: Expected O, but got Unknown
		//IL_223e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2248: Expected O, but got Unknown
		//IL_22da: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e4: Expected O, but got Unknown
		//IL_2369: Unknown result type (might be due to invalid IL or missing references)
		//IL_2373: Expected O, but got Unknown
		//IL_2413: Unknown result type (might be due to invalid IL or missing references)
		//IL_241d: Expected O, but got Unknown
		//IL_24cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_24d5: Expected O, but got Unknown
		//IL_26c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cb: Expected O, but got Unknown
		//IL_2778: Unknown result type (might be due to invalid IL or missing references)
		//IL_2782: Expected O, but got Unknown
		//IL_2811: Unknown result type (might be due to invalid IL or missing references)
		//IL_281b: Expected O, but got Unknown
		//IL_28c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d3: Expected O, but got Unknown
		//IL_2962: Unknown result type (might be due to invalid IL or missing references)
		//IL_296c: Expected O, but got Unknown
		//IL_2a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a24: Expected O, but got Unknown
		//IL_2ad2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2adc: Expected O, but got Unknown
		//IL_2b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b75: Expected O, but got Unknown
		//IL_2c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c0e: Expected O, but got Unknown
		//IL_2c9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ca6: Expected O, but got Unknown
		//IL_2d53: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d5d: Expected O, but got Unknown
		//IL_2e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e1b: Expected O, but got Unknown
		//IL_2ecf: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed9: Expected O, but got Unknown
		//IL_2f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f6e: Expected O, but got Unknown
		//IL_301c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3026: Expected O, but got Unknown
		//IL_30fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_3108: Expected O, but got Unknown
		//IL_31a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_31ae: Expected O, but got Unknown
		//IL_32af: Unknown result type (might be due to invalid IL or missing references)
		//IL_32b9: Expected O, but got Unknown
		//IL_3367: Unknown result type (might be due to invalid IL or missing references)
		//IL_3371: Expected O, but got Unknown
		//IL_33ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_3409: Expected O, but got Unknown
		//IL_34bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_34c7: Expected O, but got Unknown
		//IL_3575: Unknown result type (might be due to invalid IL or missing references)
		//IL_357f: Expected O, but got Unknown
		//IL_3654: Unknown result type (might be due to invalid IL or missing references)
		//IL_365e: Expected O, but got Unknown
		//IL_36fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3704: Expected O, but got Unknown
		//IL_3853: Unknown result type (might be due to invalid IL or missing references)
		//IL_385d: Expected O, but got Unknown
		//IL_38d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e1: Expected O, but got Unknown
		//IL_3992: Unknown result type (might be due to invalid IL or missing references)
		//IL_399c: Expected O, but got Unknown
		//IL_3a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a99: Expected O, but got Unknown
		//IL_3be8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bf2: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE_RTN_UAE));
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
		TEXT_ENTRY_2 = new TextBox();
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
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		btnIsuNo = new SimpleButton();
		Label12 = new Label();
		tIsuNo = new TextBox();
		Label14 = new Label();
		nCrDays = new TextBox();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label15 = new Label();
		tNewPrint = new TextBox();
		WebBrowser1 = new WebBrowser();
		lblItStock = new Label();
		lblTrfrOpen = new Label();
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
		((Control)PanelAdd).SuspendLayout();
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
		lblBook.Text = "Sales Rtn UAE";
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
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(474, 3);
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
		((Control)lblItem).Location = new Point(326, 293);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(392, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(431, 367);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 8;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 320);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(710, 133);
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
		((Control)MSG_TOT).Location = new Point(14, 273);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 100);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1162, 172);
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
		((Control)tItDesc).Location = new Point(96, 292);
		((TextBoxBase)tItDesc).MaxLength = 50;
		((Control)tItDesc).Name = "tItDesc";
		((Control)tItDesc).Size = new Size(220, 22);
		((Control)tItDesc).TabIndex = 7;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 292);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(79, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Print Name";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(732, 317);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 243);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(924, 393);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
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
		btnIsuNo.Text = "B";
		((BaseControl)btnIsuNo).ToolTip = "Bill Help";
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(572, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(64, 20);
		((Control)Label12).TabIndex = 1213;
		Label12.Text = "Bill No";
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
		((Control)this).Controls.Add((Control)(object)lblTrfrOpen);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)tNewPrint);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
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
		((Control)this).Name = "TR_SALE_RTN_UAE";
		((Form)this).Text = "Sales Rtn UAE";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
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
		if ((Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) == 0.0))
		{
			mSG_IDTL[CRow, 11] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 20]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) == 0.0))
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 11]), "0.000");
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
				MSG[MSG.Row, 10] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 11] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - Conversion.Val(MSG[MSG.Row, 10])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 35] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 36] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - Conversion.Val(MSG[MSG.Row, 35])), "0.000");
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
				MSG[MSG.Row, 11] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - num2), "0.000");
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
		mSG.Cols = 88;
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
			mSG[4] = (int)Math.Round(1300.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
			{
				mSG[5] = (int)Math.Round(1200.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "Size";
			}
			else
			{
				mSG[5] = (int)Math.Round(800.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "Size";
			}
			mSG[6] = (int)Math.Round(900.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "HuId";
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "BagWt";
			mSG[8] = (int)Math.Round(700.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Pcs";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "GrWt";
			mSG[10] = (int)Math.Round(800.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "LsWt";
			mSG[11] = (int)Math.Round(1000.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "NetWt";
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
			mSG[12] = (int)Math.Round(750.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Ght%";
			mSG[13] = (int)Math.Round(850.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "GhtWt";
			mSG[14] = (int)Math.Round(850.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Touch";
			mSG[15] = (int)Math.Round(850.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "West%";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "Fine";
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
			mSG[17] = (int)Math.Round(1000.0 * ColCon);
			mSG[17] = 3;
			mSG[0, 17] = "RatWith";
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
			mSG[29] = (int)Math.Round(1200.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "TotAmt";
			mSG[30] = (int)Math.Round(700.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Tax%";
			mSG[31] = (int)Math.Round(1200.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "NetAmt";
			mSG[32] = 0;
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
				mSG_TOT[0, 4] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
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
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]);
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
		mSG[mSG.Row, 86] = "N";
		mSG[mSG.Row, 87] = "N";
		mSG[mSG.Row, 17] = "N";
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
				if ((mSG.Col != 3) & (mSG.Col != 4) & (mSG.Col != 5))
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
			case 17:
			case 21:
			case 48:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 12:
			case 14:
			case 15:
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
			case 9:
			case 10:
			case 11:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0))
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 7:
			case 13:
			case 16:
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
		case 4:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if (Operators.CompareString(MSG[MSG.Row, 1], "", false) == 0)
			{
				if (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
		case 5:
		case 6:
		case 17:
		case 34:
		case 48:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 21:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			CommPassTotal();
			break;
		case 8:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			CommPassTotal();
			break;
		case 12:
		case 14:
		case 15:
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
		case 10:
		case 35:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 7:
		case 9:
		case 11:
		case 13:
		case 16:
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
				case 17513:
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
							goto IL_02e6;
						case 27:
							goto IL_0300;
						case 28:
						case 29:
						case 30:
							goto IL_0352;
						case 31:
							goto IL_0369;
						case 32:
							goto IL_03a4;
						case 33:
							goto IL_03dc;
						case 34:
						case 35:
						case 36:
							goto IL_0429;
						case 37:
							goto IL_0488;
						case 38:
							goto IL_04a2;
						case 39:
							goto IL_04da;
						case 40:
							goto IL_0532;
						case 41:
						case 42:
							goto IL_054d;
						case 43:
							goto IL_0588;
						case 44:
							goto IL_05a2;
						case 45:
							goto IL_05bc;
						case 46:
							goto IL_060c;
						case 47:
						case 48:
							goto IL_0666;
						case 49:
						case 50:
							goto IL_06a0;
						case 51:
							goto IL_06f3;
						case 52:
							goto IL_071d;
						case 53:
						case 54:
							goto IL_0739;
						case 55:
						case 56:
							goto IL_078f;
						case 57:
							goto IL_07ca;
						case 58:
							goto IL_07e4;
						case 59:
							goto IL_07fe;
						case 60:
							goto IL_0836;
						case 61:
							goto IL_089f;
						case 63:
							goto IL_0927;
						case 62:
						case 64:
						case 65:
						case 66:
							goto IL_0962;
						case 67:
							goto IL_099d;
						case 68:
							goto IL_09b7;
						case 69:
							goto IL_09ef;
						case 70:
							goto IL_0a58;
						case 71:
						case 72:
						case 73:
							goto IL_0ae0;
						case 74:
							goto IL_0b1b;
						case 75:
							goto IL_0b35;
						case 76:
							goto IL_0b6d;
						case 77:
							goto IL_0bd6;
						case 78:
						case 79:
						case 80:
							goto IL_0c5e;
						case 81:
							goto IL_0c9d;
						case 82:
						case 83:
							goto IL_0ced;
						case 84:
							goto IL_0d3d;
						case 85:
						case 86:
							goto IL_0d8d;
						case 87:
							goto IL_0dc8;
						case 88:
							goto IL_0e00;
						case 89:
							goto IL_0e69;
						case 91:
							goto IL_0ef1;
						case 90:
						case 92:
						case 93:
						case 94:
							goto IL_0f2c;
						case 95:
							goto IL_0f67;
						case 96:
							goto IL_0f9f;
						case 97:
							goto IL_1008;
						case 98:
						case 99:
						case 100:
							goto IL_1090;
						case 101:
							goto IL_10cb;
						case 102:
							goto IL_1103;
						case 103:
							goto IL_116c;
						case 104:
						case 105:
						case 106:
							goto IL_11f4;
						case 107:
							goto IL_1233;
						case 108:
						case 109:
							goto IL_1283;
						case 110:
							goto IL_1291;
						case 111:
							goto IL_12a9;
						case 112:
							goto IL_12d0;
						case 114:
							goto IL_12ed;
						case 115:
							goto IL_1314;
						case 117:
							goto IL_1332;
						case 120:
							goto IL_1354;
						case 121:
							goto IL_1373;
						case 122:
							goto IL_138b;
						case 123:
							goto IL_13f4;
						case 124:
							goto IL_146e;
						case 125:
							goto IL_1493;
						case 127:
							goto IL_14d8;
						case 130:
							goto IL_14f7;
						case 133:
							goto IL_1518;
						case 134:
							goto IL_1537;
						case 136:
							goto IL_1558;
						case 113:
						case 116:
						case 118:
						case 119:
						case 126:
						case 128:
						case 129:
						case 131:
						case 132:
						case 135:
						case 137:
						case 138:
						case 139:
							goto IL_1577;
						case 140:
							goto IL_15ee;
						case 141:
							goto IL_1629;
						case 142:
							goto IL_1647;
						case 144:
							goto IL_1695;
						case 146:
							goto IL_16f1;
						case 148:
							goto IL_175b;
						case 150:
							goto IL_17c5;
						case 151:
							goto IL_17e4;
						case 153:
							goto IL_182c;
						case 143:
						case 145:
						case 147:
						case 149:
						case 152:
						case 154:
						case 155:
						case 156:
							goto IL_188a;
						case 157:
						case 158:
							goto IL_18a8;
						case 159:
							goto IL_18c2;
						case 160:
							goto IL_197f;
						case 162:
							goto IL_19cd;
						case 164:
							goto IL_1a28;
						case 166:
							goto IL_1a91;
						case 168:
							goto IL_1af7;
						case 161:
						case 163:
						case 165:
						case 167:
						case 169:
						case 170:
							goto IL_1b53;
						case 171:
						case 172:
						case 173:
							goto IL_1b92;
						case 174:
							goto IL_1bf4;
						case 175:
							goto IL_1c2f;
						case 176:
							goto IL_1c94;
						case 177:
							goto IL_1cb5;
						case 178:
							goto IL_1ce1;
						case 179:
							goto IL_1cfd;
						case 180:
							goto IL_1d19;
						case 181:
						case 182:
						case 183:
						case 184:
							goto IL_1d3b;
						case 185:
							goto IL_1d5f;
						case 186:
							goto IL_1d94;
						case 187:
							goto IL_1dbb;
						case 188:
						case 189:
						case 190:
							goto IL_1ddc;
						case 191:
							goto IL_1e3e;
						case 192:
							goto IL_1e7a;
						case 194:
							goto IL_1edd;
						case 196:
							goto IL_1f3a;
						case 197:
							goto IL_1f59;
						case 199:
							goto IL_1fb5;
						case 202:
							goto IL_202a;
						case 204:
							goto IL_20a8;
						case 206:
							goto IL_2103;
						case 193:
						case 195:
						case 198:
						case 200:
						case 201:
						case 203:
						case 205:
						case 207:
						case 208:
							goto IL_2174;
						case 209:
							goto IL_21af;
						case 211:
							goto IL_21d2;
						case 212:
							goto IL_2219;
						case 214:
							goto IL_2267;
						case 216:
							goto IL_22c7;
						case 217:
							goto IL_22e6;
						case 219:
							goto IL_2345;
						case 222:
							goto IL_23bd;
						case 224:
							goto IL_243b;
						case 213:
						case 215:
						case 218:
						case 220:
						case 221:
						case 223:
						case 225:
						case 226:
							goto IL_2499;
						case 210:
						case 227:
						case 228:
						case 229:
							goto IL_24d7;
						case 230:
							goto IL_252a;
						case 231:
						case 232:
							goto IL_2591;
						case 233:
							goto IL_25bd;
						case 234:
						case 235:
							goto IL_2610;
						case 236:
							goto IL_2642;
						case 237:
							goto IL_2698;
						case 238:
							goto IL_26fd;
						case 240:
							goto IL_2752;
						case 239:
						case 241:
						case 242:
							goto IL_278e;
						case 243:
							goto IL_27bd;
						case 244:
						case 245:
							goto IL_282a;
						case 246:
							goto IL_2846;
						case 247:
							goto IL_2862;
						case 248:
							goto IL_287e;
						case 249:
							goto IL_289a;
						case 251:
							goto IL_28bd;
						case 252:
							goto IL_28d7;
						case 253:
							goto IL_290d;
						case 254:
						case 255:
							goto IL_292b;
						case 256:
							goto IL_295d;
						case 257:
							goto IL_298c;
						case 258:
							goto IL_29ee;
						case 259:
							goto IL_2a66;
						case 260:
							goto IL_2a95;
						case 265:
							goto IL_2afd;
						case 266:
							goto IL_2b2f;
						case 267:
							goto IL_2b68;
						case 268:
							goto IL_2bb1;
						case 272:
							goto IL_2c1e;
						case 273:
							goto IL_2c67;
						case 261:
						case 262:
						case 263:
						case 264:
						case 269:
						case 270:
						case 271:
						case 274:
						case 275:
						case 276:
						case 277:
							goto IL_2ccd;
						case 278:
							goto IL_2cff;
						case 279:
							goto IL_2d1b;
						case 280:
							goto IL_2d37;
						case 282:
						case 283:
							goto IL_2d5d;
						case 284:
							goto IL_2daa;
						case 286:
							goto IL_2df8;
						case 288:
							goto IL_2e58;
						case 290:
							goto IL_2ec6;
						case 292:
							goto IL_2f34;
						case 293:
							goto IL_2f53;
						case 295:
							goto IL_2f9f;
						case 285:
						case 287:
						case 289:
						case 291:
						case 294:
						case 296:
						case 297:
						case 298:
							goto IL_3001;
						case 299:
						case 300:
							goto IL_303e;
						case 301:
							goto IL_307c;
						case 302:
							goto IL_30d3;
						case 304:
							goto IL_3121;
						case 306:
							goto IL_3181;
						case 307:
							goto IL_31a0;
						case 309:
							goto IL_31ff;
						case 312:
							goto IL_3277;
						case 314:
							goto IL_32f5;
						case 303:
						case 305:
						case 308:
						case 310:
						case 311:
						case 313:
						case 315:
						case 316:
							goto IL_3353;
						case 317:
							goto IL_338e;
						case 318:
							goto IL_33e1;
						case 319:
						case 320:
						case 321:
						case 322:
						case 323:
							goto IL_3444;
						case 324:
							goto IL_346e;
						case 325:
						case 326:
							goto IL_34ed;
						case 327:
							goto IL_3519;
						case 250:
						case 328:
						case 329:
						case 330:
							goto IL_3599;
						case 331:
							goto IL_35c5;
						case 332:
						case 333:
							goto IL_3644;
						case 334:
							goto IL_3670;
						case 335:
						case 336:
							goto IL_36ad;
						case 337:
							goto IL_36df;
						case 338:
							goto IL_370c;
						case 339:
							goto IL_3728;
						case 340:
							goto IL_3793;
						case 341:
							goto IL_37e3;
						case 342:
						case 343:
							goto IL_3852;
						case 344:
							goto IL_3884;
						case 345:
							goto IL_38d1;
						case 347:
							goto IL_3927;
						case 348:
							goto IL_3978;
						case 349:
							goto IL_3997;
						case 351:
							goto IL_39ec;
						case 354:
							goto IL_3a5a;
						case 355:
							goto IL_3aa8;
						case 357:
							goto IL_3b09;
						case 358:
							goto IL_3b57;
						case 360:
							goto IL_3bac;
						case 346:
						case 350:
						case 352:
						case 353:
						case 356:
						case 359:
						case 361:
						case 362:
						case 363:
							goto IL_3c16;
						case 364:
							goto IL_3c6c;
						case 365:
							goto IL_3c98;
						case 366:
						case 367:
							goto IL_3cf5;
						case 368:
							goto IL_3d0f;
						case 369:
							goto IL_3d6a;
						case 370:
							goto IL_3da5;
						case 371:
						case 372:
						case 373:
							goto IL_3dc5;
						case 376:
							goto IL_3e06;
						case 374:
						case 375:
						case 377:
						case 378:
							goto IL_3e43;
						case 379:
							goto IL_3e46;
						case 380:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 12:
						case 281:
						case 381:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_3e06:
					num2 = 376;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 29]), "0.00");
					goto IL_3e43;
					IL_3e43:
					val = null;
					goto IL_3e46;
					IL_3dc5:
					num2 = 373;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_3e43;
					IL_3e46:
					num2 = 379;
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
					if (Conversion.Val(val[val.Row, 9]) > CurItGwtStk)
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
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 59]))
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
					val[val.Row, 59] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_0166;
					IL_0166:
					num2 = 19;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_01b4;
					IL_01b4:
					num2 = 20;
					val[val.Row, 36] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 35])), "0.000");
					goto IL_0202;
					IL_0202:
					num2 = 21;
					val[val.Row, 86] = "N";
					goto IL_021d;
					IL_021d:
					num2 = 23;
					if ((Operators.CompareString(DC_Main.MsMetalType, "S", false) == 0) & (val[7] != 0))
					{
						goto IL_0248;
					}
					goto IL_0352;
					IL_0248:
					num2 = 24;
					if ((Conversion.Val(val[val.Row, 7]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_029a;
					}
					goto IL_0352;
					IL_029a:
					num2 = 25;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) * Conversion.Val(val[val.Row, 8])), "0.000");
					goto IL_02e6;
					IL_02e6:
					num2 = 26;
					val[val.Row, 77] = Conversions.ToString(0);
					goto IL_0300;
					IL_0300:
					num2 = 27;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_0352;
					IL_0352:
					num2 = 30;
					if (val.Col == 10)
					{
						goto IL_0369;
					}
					goto IL_0429;
					IL_0369:
					num2 = 31;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 77]))
					{
						goto IL_03a4;
					}
					goto IL_0429;
					IL_03a4:
					num2 = 32;
					val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_03dc;
					IL_03dc:
					num2 = 33;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(TEXT_ENTRY.Text)), "0.000");
					goto IL_0429;
					IL_0429:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 61])) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0488;
					}
					goto IL_054d;
					IL_0488:
					num2 = 37;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_04a2;
					IL_04a2:
					num2 = 38;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.00");
					goto IL_04da;
					IL_04da:
					num2 = 39;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 12]) / 100.0), "0.000");
					goto IL_0532;
					IL_0532:
					num2 = 40;
					val[val.Row, 86] = "N";
					goto IL_054d;
					IL_054d:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_0588;
					}
					goto IL_06a0;
					IL_0588:
					num2 = 43;
					val[val.Row, 24] = Conversions.ToString(0);
					goto IL_05a2;
					IL_05a2:
					num2 = 44;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_05bc;
					IL_05bc:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_060c;
					}
					goto IL_0666;
					IL_060c:
					num2 = 46;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 12]) / 100.0), "0.000");
					goto IL_0666;
					IL_0666:
					num2 = 48;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_06a0;
					IL_06a0:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_06f3;
					}
					goto IL_078f;
					IL_06f3:
					num2 = 51;
					if (Conversion.Val((object)val[24]) >= 0.0)
					{
						goto IL_071d;
					}
					goto IL_0739;
					IL_071d:
					num2 = 52;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_0739;
					IL_0739:
					num2 = 54;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_078f;
					IL_078f:
					num2 = 56;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_07ca;
					}
					goto IL_0962;
					IL_07ca:
					num2 = 57;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_07e4;
					IL_07e4:
					num2 = 58;
					val[val.Row, 69] = Conversions.ToString(0);
					goto IL_07fe;
					IL_07fe:
					num2 = 59;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_0836;
					IL_0836:
					num2 = 60;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_089f;
					}
					goto IL_0927;
					IL_089f:
					num2 = 61;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0962;
					IL_0927:
					num2 = 63;
					val[val.Row, 16] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_0962;
					IL_0962:
					num2 = 66;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_099d;
					}
					goto IL_0ae0;
					IL_099d:
					num2 = 67;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_09b7;
					IL_09b7:
					num2 = 68;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.00");
					goto IL_09ef;
					IL_09ef:
					num2 = 69;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0a58;
					}
					goto IL_0ae0;
					IL_0a58:
					num2 = 70;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0ae0;
					IL_0ae0:
					num2 = 73;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_0b1b;
					}
					goto IL_0c5e;
					IL_0b1b:
					num2 = 74;
					val[val.Row, 75] = Conversions.ToString(0);
					goto IL_0b35;
					IL_0b35:
					num2 = 75;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_0b6d;
					IL_0b6d:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0bd6;
					}
					goto IL_0c5e;
					IL_0bd6:
					num2 = 77;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0c5e;
					IL_0c5e:
					num2 = 80;
					if (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) == 0.0)
					{
						goto IL_0c9d;
					}
					goto IL_0ced;
					IL_0c9d:
					num2 = 81;
					val[val.Row, 16] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_0ced;
					IL_0ced:
					num2 = 83;
					if ((Conversion.Val(val[val.Row, 35]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0d3d;
					}
					goto IL_0d8d;
					IL_0d3d:
					num2 = 84;
					val[val.Row, 36] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 35])), "0.000");
					goto IL_0d8d;
					IL_0d8d:
					num2 = 86;
					if (Conversion.Val(val[val.Row, 36]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_0dc8;
					}
					goto IL_0f2c;
					IL_0dc8:
					num2 = 87;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.000");
					goto IL_0e00;
					IL_0e00:
					num2 = 88;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_0e69;
					}
					goto IL_0ef1;
					IL_0e69:
					num2 = 89;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_0f2c;
					IL_0ef1:
					num2 = 91;
					val[val.Row, 41] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.000");
					goto IL_0f2c;
					IL_0f2c:
					num2 = 94;
					if (Conversion.Val(val[val.Row, 39]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_0f67;
					}
					goto IL_1090;
					IL_0f67:
					num2 = 95;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 39]), "0.00");
					goto IL_0f9f;
					IL_0f9f:
					num2 = 96;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_1008;
					}
					goto IL_1090;
					IL_1008:
					num2 = 97;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_1090;
					IL_1090:
					num2 = 100;
					if (Conversion.Val(val[val.Row, 40]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_10cb;
					}
					goto IL_11f4;
					IL_10cb:
					num2 = 101;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 40]), "0.00");
					goto IL_1103;
					IL_1103:
					num2 = 102;
					if ((Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) != 0.0) & (Conversion.Val(val[val.Row, 36]) != 0.0))
					{
						goto IL_116c;
					}
					goto IL_11f4;
					IL_116c:
					num2 = 103;
					val[val.Row, 41] = Strings.Format((object)((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])) * (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])) / 100.0), "0.000");
					goto IL_11f4;
					IL_11f4:
					num2 = 106;
					if (Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40]) == 0.0)
					{
						goto IL_1233;
					}
					goto IL_1283;
					IL_1233:
					num2 = 107;
					val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 38])), "0.000");
					goto IL_1283;
					IL_1283:
					num2 = 109;
					num5 = 0.0;
					goto IL_1291;
					IL_1291:
					num2 = 110;
					if (val[17] > 0)
					{
						goto IL_12a9;
					}
					goto IL_1354;
					IL_12a9:
					num2 = 111;
					if (Operators.CompareString(val[val.Row, 17], "G", false) == 0)
					{
						goto IL_12d0;
					}
					goto IL_12ed;
					IL_12d0:
					num2 = 112;
					num5 = Conversion.Val(val[val.Row, 9]);
					goto IL_1577;
					IL_12ed:
					num2 = 114;
					if (Operators.CompareString(val[val.Row, 17], "F", false) == 0)
					{
						goto IL_1314;
					}
					goto IL_1332;
					IL_1314:
					num2 = 115;
					num5 = Conversion.Val(val[val.Row, 16]);
					goto IL_1577;
					IL_1332:
					num2 = 117;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_1577;
					IL_1354:
					num2 = 120;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_1373;
					}
					goto IL_1518;
					IL_1373:
					num2 = 121;
					if (val[16] != 0)
					{
						goto IL_138b;
					}
					goto IL_14f7;
					IL_138b:
					num2 = 122;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_13f4;
					}
					goto IL_14d8;
					IL_13f4:
					num2 = 123;
					num5 = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000"));
					goto IL_146e;
					IL_146e:
					num2 = 124;
					val[val.Row, 16] = Strings.Format((object)num5, "0.000");
					goto IL_1493;
					IL_1493:
					num2 = 125;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1577;
					IL_14d8:
					num2 = 127;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_1577;
					IL_14f7:
					num2 = 130;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_1577;
					IL_1518:
					num2 = 133;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "G", false) == 0)
					{
						goto IL_1537;
					}
					goto IL_1558;
					IL_1537:
					num2 = 134;
					num5 = Conversion.Val(val[val.Row, 9]);
					goto IL_1577;
					IL_1558:
					num2 = 136;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_1577;
					IL_1577:
					num2 = 139;
					if ((Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 75])) & (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_15ee;
					}
					goto IL_18a8;
					IL_15ee:
					num2 = 140;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_1629;
					IL_1629:
					num2 = 141;
					val[val.Row, 76] = Conversions.ToString(0);
					goto IL_1647;
					IL_1647:
					num2 = 142;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_16f1;
					case "K":
						goto IL_175b;
					default:
						goto IL_17c5;
					}
					goto IL_1695;
					IL_17c5:
					num2 = 150;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_17e4;
					}
					goto IL_182c;
					IL_17e4:
					num2 = 151;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_188a;
					IL_182c:
					num2 = 153;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 13])) * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_188a;
					IL_175b:
					num2 = 148;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 18]) / 1000.0), digits), "0.00");
					goto IL_188a;
					IL_16f1:
					num2 = 146;
					val[val.Row, 19] = Strings.Format((object)Math.Round((num5 + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 18]) / 10.0), digits), "0.00");
					goto IL_188a;
					IL_1695:
					num2 = 144;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 18]), digits), "0.00");
					goto IL_188a;
					IL_188a:
					num2 = 156;
					val[val.Row, 86] = "N";
					goto IL_18a8;
					IL_18a8:
					num2 = 158;
					if (val.Col == 19)
					{
						goto IL_18c2;
					}
					goto IL_1b92;
					IL_18c2:
					num2 = 159;
					if ((Conversion.Val(val[val.Row, 18]) == 0.0) | ((Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 75])) & (Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 8]) != 0.0)))
					{
						goto IL_197f;
					}
					goto IL_1b92;
					IL_197f:
					num2 = 160;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_1a28;
					case "K":
						goto IL_1a91;
					default:
						goto IL_1af7;
					}
					goto IL_19cd;
					IL_1af7:
					num2 = 168;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / num5 + Conversion.Val(val[val.Row, 13]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1b53;
					IL_1a91:
					num2 = 166;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 13])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1b53;
					IL_1a28:
					num2 = 164;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / (num5 + Conversion.Val(val[val.Row, 13])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_1b53;
					IL_19cd:
					num2 = 162;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 8]), DC_Main.MsItmRateRof), "0.00");
					goto IL_1b53;
					IL_1b53:
					num2 = 170;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_1b92;
					IL_1b92:
					num2 = 173;
					if ((Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 76])) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_1bf4;
					}
					goto IL_1d3b;
					IL_1bf4:
					num2 = 174;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_1c2f;
					IL_1c2f:
					num2 = 175;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * Conversion.Val(val[val.Row, 20]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1c94;
					IL_1c94:
					num2 = 176;
					if (0u - ((val.Col == 20) ? 1u : 0u) != 0)
					{
						goto IL_1cb5;
					}
					goto IL_1d3b;
					IL_1cb5:
					num2 = 177;
					if (Conversion.Val(val[val.Row, 20]) == 0.0)
					{
						goto IL_1ce1;
					}
					goto IL_1d3b;
					IL_1ce1:
					num2 = 178;
					val[val.Row, 76] = "";
					goto IL_1cfd;
					IL_1cfd:
					num2 = 179;
					val[val.Row, 22] = "";
					goto IL_1d19;
					IL_1d19:
					num2 = 180;
					val[val.Row, 23] = "";
					goto IL_1d3b;
					IL_1d3b:
					num2 = 184;
					if ((val.Col == 21) & (val[21] != 0))
					{
						goto IL_1d5f;
					}
					goto IL_1ddc;
					IL_1d5f:
					num2 = 185;
					if (Operators.CompareString(val[val.Row, 21], val[val.Row, 78], false) != 0)
					{
						goto IL_1d94;
					}
					goto IL_1ddc;
					IL_1d94:
					num2 = 186;
					val[val.Row, 78] = val[val.Row, 21];
					goto IL_1dbb;
					IL_1dbb:
					num2 = 187;
					val[val.Row, 69] = Conversions.ToString(0);
					goto IL_1ddc;
					IL_1ddc:
					num2 = 190;
					if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 69]) != Conversion.Val(val[val.Row, 22])))
					{
						goto IL_1e3e;
					}
					goto IL_21d2;
					IL_1e3e:
					num2 = 191;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1e7a;
					IL_1e7a:
					num2 = 192;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_1f3a;
					case "K":
						goto IL_202a;
					case "G":
						goto IL_20a8;
					default:
						goto IL_2103;
					}
					goto IL_1edd;
					IL_2103:
					num2 = 206;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_2174;
					IL_20a8:
					num2 = 204;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_2174;
					IL_202a:
					num2 = 202;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 22]) / 1000.0), digits2), "0.00");
					goto IL_2174;
					IL_1f3a:
					num2 = 196;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1f59;
					}
					goto IL_1fb5;
					IL_1f59:
					num2 = 197;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_2174;
					IL_1fb5:
					num2 = 199;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_2174;
					IL_1edd:
					num2 = 194;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 22]), digits2), "0.00");
					goto IL_2174;
					IL_2174:
					num2 = 208;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_21af;
					IL_21af:
					num2 = 209;
					val[val.Row, 86] = "N";
					goto IL_24d7;
					IL_21d2:
					num2 = 211;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
					{
						goto IL_2219;
					}
					goto IL_24d7;
					IL_2219:
					num2 = 212;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_22c7;
					case "K":
						goto IL_23bd;
					default:
						goto IL_243b;
					}
					goto IL_2267;
					IL_243b:
					num2 = 224;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_2499;
					IL_23bd:
					num2 = 222;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2499;
					IL_22c7:
					num2 = 216;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_22e6;
					}
					goto IL_2345;
					IL_22e6:
					num2 = 217;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_2499;
					IL_2345:
					num2 = 219;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), DC_Main.MsLbrRof), "0.00");
					goto IL_2499;
					IL_2267:
					num2 = 214;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_2499;
					IL_2499:
					num2 = 226;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_24d7;
					IL_24d7:
					num2 = 229;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_252a;
					}
					goto IL_2591;
					IL_252a:
					num2 = 230;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) * Conversion.Val(val[val.Row, 27]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_2591;
					IL_2591:
					num2 = 232;
					if (Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_25bd;
					}
					goto IL_2610;
					IL_25bd:
					num2 = 233;
					val[val.Row, 33] = Strings.Format((object)(Conversion.Val(val[val.Row, 43]) + Conversion.Val(val[val.Row, 44])), "0.0");
					goto IL_2610;
					IL_2610:
					num2 = 235;
					if (Conversion.Val(val[val.Row, 26]) != 0.0)
					{
						goto IL_2642;
					}
					goto IL_28bd;
					IL_2642:
					num2 = 236;
					if ((Conversion.Val(val[val.Row, 27]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_2698;
					}
					goto IL_2752;
					IL_2698:
					num2 = 237;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 26]) * Conversion.Val(val[val.Row, 27]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_26fd;
					IL_26fd:
					num2 = 238;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 26]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_278e;
					IL_2752:
					num2 = 240;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 26]), "0.00");
					goto IL_278e;
					IL_278e:
					num2 = 242;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_27bd;
					}
					goto IL_282a;
					IL_27bd:
					num2 = 243;
					val[val.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) / (Conversion.Val(val[val.Row, 30]) + 100.0) * 100.0, 0), "0.00");
					goto IL_282a;
					IL_282a:
					num2 = 245;
					val[val.Row, 18] = "";
					goto IL_2846;
					IL_2846:
					num2 = 246;
					val[val.Row, 19] = "";
					goto IL_2862;
					IL_2862:
					num2 = 247;
					val[val.Row, 23] = "";
					goto IL_287e;
					IL_287e:
					num2 = 248;
					val[val.Row, 22] = "";
					goto IL_289a;
					IL_289a:
					num2 = 249;
					val[val.Row, 25] = "";
					goto IL_3599;
					IL_28bd:
					num2 = 251;
					if (val.Col == 29)
					{
						goto IL_28d7;
					}
					goto IL_3444;
					IL_28d7:
					num2 = 252;
					if (Conversion.Val(val[val.Row, 29]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_290d;
					}
					goto IL_292b;
					IL_290d:
					num2 = 253;
					val[val.Row, 86] = "N";
					goto IL_292b;
					IL_292b:
					num2 = 255;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_295d;
					}
					goto IL_2afd;
					IL_295d:
					num2 = 256;
					if (Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_298c;
					}
					goto IL_2ccd;
					IL_298c:
					num2 = 257;
					if (Conversion.Val(TEXT_ENTRY.Text) < Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 23]))
					{
						goto IL_29ee;
					}
					goto IL_2ccd;
					IL_29ee:
					num2 = 258;
					val[val.Row, 28] = Strings.Format((object)(Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) + Conversion.Val(val[val.Row, 23]) - Conversion.Val(TEXT_ENTRY.Text)), "0.00");
					goto IL_2a66;
					IL_2a66:
					num2 = 259;
					if (Conversion.Val(val[val.Row, 27]) != 0.0)
					{
						goto IL_2a95;
					}
					goto IL_2ccd;
					IL_2a95:
					num2 = 260;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 28]) * 100.0 / Conversion.Val(val[val.Row, 23])), "0.00");
					goto IL_2ccd;
					IL_2afd:
					num2 = 265;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_2b2f;
					}
					goto IL_2c1e;
					IL_2b2f:
					num2 = 266;
					if (Conversion.Val(val[val.Row, 29]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_2b68;
					}
					goto IL_2ccd;
					IL_2b68:
					num2 = 267;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]))
					{
						goto IL_2bb1;
					}
					goto IL_2ccd;
					IL_2bb1:
					num2 = 268;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_2ccd;
					IL_2c1e:
					num2 = 272;
					if (Conversion.Val(TEXT_ENTRY.Text) > Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]))
					{
						goto IL_2c67;
					}
					goto IL_2ccd;
					IL_2c67:
					num2 = 273;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_2ccd;
					IL_2ccd:
					num2 = 277;
					if (Conversion.Val(val[val.Row, 23]) <= 0.0)
					{
						goto IL_2cff;
					}
					goto IL_303e;
					IL_2cff:
					num2 = 278;
					val[val.Row, 23] = "";
					goto IL_2d1b;
					IL_2d1b:
					num2 = 279;
					val[val.Row, 22] = "";
					goto IL_2d37;
					IL_2d37:
					num2 = 280;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "HM240NPPK", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_2d5d;
					IL_2d5d:
					num2 = 283;
					val[val.Row, 19] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25])), "0.00");
					goto IL_2daa;
					IL_2daa:
					num2 = 284;
					switch (val[val.Row, 51])
					{
					case "P":
						break;
					case "1":
						goto IL_2e58;
					case "K":
						goto IL_2ec6;
					default:
						goto IL_2f34;
					}
					goto IL_2df8;
					IL_2f34:
					num2 = 292;
					if (Operators.CompareString(DC_Main.MsSlAmtType, "F", false) == 0)
					{
						goto IL_2f53;
					}
					goto IL_2f9f;
					IL_2f53:
					num2 = 293;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / num5, DC_Main.MsItmRateRof), "0.00");
					goto IL_3001;
					IL_2f9f:
					num2 = 295;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 13])), DC_Main.MsItmRateRof), "0.00");
					goto IL_3001;
					IL_2ec6:
					num2 = 290;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 13])) * 1000.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3001;
					IL_2e58:
					num2 = 288;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / (num5 + Conversion.Val(val[val.Row, 13])) * 10.0, DC_Main.MsItmRateRof), "0.00");
					goto IL_3001;
					IL_2df8:
					num2 = 286;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsItmRateRof), "0.00");
					goto IL_3001;
					IL_3001:
					num2 = 298;
					val[val.Row, 75] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_303e;
					IL_303e:
					num2 = 300;
					if (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_307c;
					}
					goto IL_3444;
					IL_307c:
					num2 = 301;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_30d3;
					}
					goto IL_3444;
					IL_30d3:
					num2 = 302;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "N":
						goto IL_3181;
					case "K":
						goto IL_3277;
					default:
						goto IL_32f5;
					}
					goto IL_3121;
					IL_32f5:
					num2 = 314;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_3353;
					IL_3277:
					num2 = 312;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_3353;
					IL_3181:
					num2 = 306;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_31a0;
					}
					goto IL_31ff;
					IL_31a0:
					num2 = 307;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_3353;
					IL_31ff:
					num2 = 309;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), DC_Main.MsLbrRof), "0.00");
					goto IL_3353;
					IL_3121:
					num2 = 304;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_3353;
					IL_3353:
					num2 = 316;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_338e;
					IL_338e:
					num2 = 317;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_33e1;
					}
					goto IL_3444;
					IL_33e1:
					num2 = 318;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.000");
					goto IL_3444;
					IL_3444:
					num2 = 323;
					if (Operators.CompareString(val[val.Row, 86], "N", false) == 0)
					{
						goto IL_346e;
					}
					goto IL_34ed;
					IL_346e:
					num2 = 324;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_34ed;
					IL_34ed:
					num2 = 326;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_3519;
					}
					goto IL_3599;
					IL_3519:
					num2 = 327;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_3599;
					IL_3599:
					num2 = 330;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_35c5;
					}
					goto IL_3644;
					IL_35c5:
					num2 = 331;
					val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 28])), "0.00");
					goto IL_3644;
					IL_3644:
					num2 = 333;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_3670;
					}
					goto IL_36ad;
					IL_3670:
					num2 = 334;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 29]), "0.00");
					goto IL_36ad;
					IL_36ad:
					num2 = 336;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_36df;
					}
					goto IL_3e06;
					IL_36df:
					num2 = 337;
					if (Operators.CompareString(val[val.Row, 86], "N", false) == 0)
					{
						goto IL_370c;
					}
					goto IL_3e43;
					IL_370c:
					num2 = 338;
					val[val.Row, 86] = "Y";
					goto IL_3728;
					IL_3728:
					num2 = 339;
					val[val.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) / (Conversion.Val(val[val.Row, 30]) + 100.0) * 100.0, 0), "0.00");
					goto IL_3793;
					IL_3793:
					num2 = 340;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 28]) == 0.0))
					{
						goto IL_37e3;
					}
					goto IL_3852;
					IL_37e3:
					num2 = 341;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 31]) - Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 25]), 0), "0.00");
					goto IL_3852;
					IL_3852:
					num2 = 343;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_3884;
					}
					goto IL_3c16;
					IL_3884:
					num2 = 344;
					if ((Operators.CompareString(val[val.Row, 21], "P", false) == 0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_38d1;
					}
					goto IL_3927;
					IL_38d1:
					num2 = 345;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8])), "0.00");
					goto IL_3c16;
					IL_3927:
					num2 = 347;
					if ((Operators.CompareString(val[val.Row, 21], "N", false) == 0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_3978;
					}
					goto IL_3a5a;
					IL_3978:
					num2 = 348;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_3997;
					}
					goto IL_39ec;
					IL_3997:
					num2 = 349;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11])), "0.00");
					goto IL_3c16;
					IL_39ec:
					num2 = 351;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13]))), "0.00");
					goto IL_3c16;
					IL_3a5a:
					num2 = 354;
					if ((Operators.CompareString(val[val.Row, 21], "K", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_3aa8;
					}
					goto IL_3b09;
					IL_3aa8:
					num2 = 355;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]) * 1000.0), "0.00");
					goto IL_3c16;
					IL_3b09:
					num2 = 357;
					if ((Operators.CompareString(val[val.Row, 21], "G", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_3b57;
					}
					goto IL_3bac;
					IL_3b57:
					num2 = 358;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9])), "0.00");
					goto IL_3c16;
					IL_3bac:
					num2 = 360;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13]))), "0.00");
					goto IL_3c16;
					IL_3c16:
					num2 = 363;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_3c6c;
					}
					goto IL_3dc5;
					IL_3c6c:
					num2 = 364;
					if (Conversion.Val(val[val.Row, 30]) == 0.0)
					{
						goto IL_3c98;
					}
					goto IL_3cf5;
					IL_3c98:
					num2 = 365;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_3cf5;
					IL_3cf5:
					num2 = 367;
					if (val.Col == 30)
					{
						goto IL_3d0f;
					}
					goto IL_3dc5;
					IL_3d0f:
					num2 = 368;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_3d6a;
					IL_3d6a:
					num2 = 369;
					val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_3da5;
					IL_3da5:
					num2 = 370;
					val[val.Row, 86] = "Y";
					goto IL_3dc5;
					end_IL_0001_2:
					break;
				}
				num2 = 380;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 17513;
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
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ad: Invalid comparison between Unknown and I4
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Invalid comparison between Unknown and I4
		//IL_04e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d6: Invalid comparison between Unknown and I4
		//IL_0627: Unknown result type (might be due to invalid IL or missing references)
		//IL_062a: Invalid comparison between Unknown and I4
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a6: Invalid comparison between Unknown and I4
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Invalid comparison between Unknown and I4
		//IL_0752: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Invalid comparison between Unknown and I4
		//IL_2e65: Unknown result type (might be due to invalid IL or missing references)
		//IL_36b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
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
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 55] = DC_Main.ColValue[2];
									mSG[mSG.Row, 68] = DC_Main.ColValue[2];
									tItDesc.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[3];
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
									mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 45] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 45] = "";
									mSG[mSG.Row, 1] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
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
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
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
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
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
							AxMSFlexGrid obj5 = mSG;
							int i = DC_Main.i;
							object Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"");
							obj5[i, 42] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							AxMSFlexGrid obj6 = mSG;
							int i2 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"");
							obj6[i2, 43] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
							AxMSFlexGrid obj7 = mSG;
							int i3 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"");
							obj7[i3, 33] = Strings.Format((object)DC_Main.Fnv(ref Value), "0.00");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							AxMSFlexGrid obj8 = mSG;
							int i4 = DC_Main.i;
							Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"");
							obj8[i4, 49] = Strings.Format((object)DC_Main.Fnv(ref Value), "0");
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
						int num5 = 0;
						int num6 = DtIdtl.Rows.Count - 1;
						int num7 = num6;
						for (int j = 0; j <= num7; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num5][23], (object)Conversion.Val(mSG[DC_Main.i, 50]), false))
							{
								DtIdtl.Rows[num5].Delete();
								DtIdtl.AcceptChanges();
								num5--;
							}
							num5++;
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
									AxMSFlexGrid obj9 = mSG;
									int row2 = mSG.Row;
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
									obj9[row2, 18] = Strings.Format(RuntimeHelpers.GetObjectValue(obj12), "0.00");
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
							double num8 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num8 != 0.0) & (Conversion.Val(mSG[mSG.Row, 22]) == 0.0))
							{
								AxMSFlexGrid obj13 = mSG;
								int row3 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
								double num9 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj13[row3, 22] = Strings.Format((object)num9, "0.00");
							}
							if (mSG[20] != 0)
							{
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
								double num10 = DC_Main.Fnv(ref Value);
								dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								if ((num10 != 0.0) & (Conversion.Val(mSG[mSG.Row, 20]) == 0.0))
								{
									AxMSFlexGrid obj14 = mSG;
									int row4 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
									double num11 = DC_Main.Fnv(ref Value);
									dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
									obj14[row4, 20] = Strings.Format((object)num11, "0.00");
								}
							}
						}
						mSG[mSG.Row, 2] = TEXT_ENTRY.Text;
						if (Operators.CompareString(tItDesc.Text, "", false) == 0)
						{
							tItDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						((Control)TEXT_ENTRY).Visible = false;
						ItmStk(mSG.Row);
						((Control)tItDesc).Focus();
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
					case 9:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 51], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 17:
						if ((Operators.CompareString(TEXT_ENTRY.Text, "F", false) != 0) | (Operators.CompareString(TEXT_ENTRY.Text, "G", false) != 0) | (Operators.CompareString(TEXT_ENTRY.Text, "N", false) != 0) | (Operators.CompareString(TEXT_ENTRY.Text, "P", false) != 0))
						{
							mSG[mSG.Row, 17] = "N";
						}
						break;
					case 19:
						if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(mSG[mSG.Row, 19]))
						{
							mSG[mSG.Row, 18] = Conversions.ToString(0);
							mSG[mSG.Row, 75] = Conversions.ToString(0);
						}
						break;
					case 30:
					case 31:
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

	private void TR_SALE_RTN_UAE_Load(object sender, EventArgs e)
	{
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_1013: Unknown result type (might be due to invalid IL or missing references)
		//IL_1018: Unknown result type (might be due to invalid IL or missing references)
		//IL_1022: Expected O, but got Unknown
		//IL_1047: Unknown result type (might be due to invalid IL or missing references)
		//IL_104c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1056: Expected O, but got Unknown
		//IL_107b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_108a: Expected O, but got Unknown
		//IL_10c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d8: Expected O, but got Unknown
		//IL_10f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1101: Expected O, but got Unknown
		//IL_111b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1120: Unknown result type (might be due to invalid IL or missing references)
		//IL_112a: Expected O, but got Unknown
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_1149: Unknown result type (might be due to invalid IL or missing references)
		//IL_1153: Expected O, but got Unknown
		//IL_117b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1182: Expected O, but got Unknown
		//IL_126e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1273: Unknown result type (might be due to invalid IL or missing references)
		//IL_127d: Expected O, but got Unknown
		//IL_1305: Unknown result type (might be due to invalid IL or missing references)
		//IL_130a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1314: Expected O, but got Unknown
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b8: Expected O, but got Unknown
		//IL_1442: Unknown result type (might be due to invalid IL or missing references)
		//IL_1447: Unknown result type (might be due to invalid IL or missing references)
		//IL_1451: Expected O, but got Unknown
		//IL_1476: Unknown result type (might be due to invalid IL or missing references)
		//IL_147b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1485: Expected O, but got Unknown
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
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj23 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj24 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj25 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblTrfrOpen).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((ButtonBase)chkRateUnFix).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj26 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj28 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj29 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj33 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj34 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj35 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj36 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj37 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj38 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj39 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblTrfrOpen).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				((ButtonBase)chkRateUnFix).BackColor = Color.Cornsilk;
				Label obj40 = lblBook;
				object? obj41 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj40).ForeColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj42 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj43 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj44 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj45 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj46 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj47 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj48 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj49 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj50 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj51 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj53 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj54 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj55 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
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
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue3, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
						{
							NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
			if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0)
			{
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
				((Control)Label12).Visible = false;
				((Control)tIsuNo).Visible = false;
				((Control)tIsuDbCd).Visible = false;
				((Control)tIsuYrCd).Visible = false;
				((Control)btnIsuNo).Visible = false;
			}
			else
			{
				TblData = "SL_DATA";
				TblDetl = "SL_DETL_RTN";
				TblIdtl = "SL_IDTL";
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
		lblItStock.Text = "Itm Stock :";
		((Control)PanelAdd).Visible = false;
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
		lblItem.Text = "Item :";
		DC_Main.MsOldPurc = false;
		DC_Main.MsOldPurcSl = false;
		OldGoldPurcAmt = 0.0;
		OldSilverPurcAmt = 0.0;
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
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG2_CLEAR();
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
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num3 = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num3)
			{
				DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
				DC_Main.M++;
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0)
				{
					MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
					MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
					MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
					MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
					AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL[10, 3] = Strings.Format((object)num, "0.00");
					AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL2[11, 3] = Strings.Format((object)num2, "0.00");
				}
				else
				{
					MSG2_TOTAL[6, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_TOT_AMT"])), "0.00");
					MSG2_TOTAL[7, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CHQ_AMT"])), "0.00");
					MSG2_TOTAL[8, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CARD_AMT"])), "0.00");
					MSG2_TOTAL[9, 3] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RTN_CASH_AMT"])), "0.00");
					AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["RTN_KASAR_AMT"]);
					double num3 = DC_Main.Fnv(ref Value);
					dataRow["RTN_KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL3[10, 3] = Strings.Format((object)Conversion.Val((object)num3), "0.00");
					AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
					Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["RTN_BILL_OS"]);
					double num4 = DC_Main.Fnv(ref Value);
					dataRow["RTN_BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL4[11, 3] = Strings.Format((object)Conversion.Val((object)num4), "0.00");
					tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
					tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
					tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
				}
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM " + TblDetl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
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
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_WITH"], (object)""));
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
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
				int num5 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num5)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM " + TblIdtl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				EntryMode = "E";
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]) + Conversion.Val(MSG2_TOTAL[11, 3]);
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 36]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 23]) + Conversion.Val(MSG2_TOTAL[11, 3]);
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

	private void TR_SALE_RTN_UAE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_RTN_UAE_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0298: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.DefaulterAc(tAcCode.Text);
		if ((Operators.CompareString(DC_Main.MsDefaulterAc, "Y", false) == 0) & (Conversion.Val(MSG2_TOTAL[11, 3]) > 0.0))
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
		if (!chkRateUnFix.Checked && Conversion.Val(MSG2_TOTAL[0, 3]) == 0.0)
		{
			Interaction.MsgBox((object)"Please Insert Item Value Nat Amount  = 0 and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(MSG_TOT[0, 26]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 31]) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
			dataRow2["NET_AMT"] = 0;
			dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0)
			{
				dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
				dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
				dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
				dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
				dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
				dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[11, 3]);
				dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			}
			else
			{
				dataRow2["RTN_NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
				dataRow2["RTN_TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
				dataRow2["RTN_CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
				dataRow2["RTN_CARD_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
				dataRow2["RTN_CASH_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow2["RTN_KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
				dataRow2["RTN_BILL_OS"] = Conversion.Val(MSG2_TOTAL[11, 3]);
				dataRow2["LBR_AMT"] = 0;
				dataRow2["OTH_AMT"] = 0;
				dataRow2["TOT_AMT"] = 0;
				dataRow2["CHQ_AMT"] = 0;
				dataRow2["CARD_AMT"] = 0;
				dataRow2["ADV_AMT"] = 0;
				dataRow2["CRNT_ADJ_AMT"] = 0;
				dataRow2["OLD_GL_AMT"] = 0;
				dataRow2["OLD_SL_AMT"] = 0;
				dataRow2["SCHM_AMT"] = 0;
				dataRow2["CASH_AMT"] = 0;
				dataRow2["UPI_AMT"] = 0;
				dataRow2["CASH_PAID"] = 0;
				dataRow2["KASAR_AMT"] = 0;
				dataRow2["BILL_OS"] = 0;
				dataRow2["OLD_GL"] = 0;
				dataRow2["OLD_SL"] = 0;
				dataRow2["SCHM_AC"] = "";
				dataRow2["CARD_ADJ"] = "N";
				dataRow2["ISU_NO"] = tIsuNo.Text;
				dataRow2["ISU_LC_CODE"] = DC_Main.MLc_code;
				dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
				dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
				dataRow2["MOB_ENTRY_SAVE"] = "Y";
			}
			dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];
			dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
			dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["HM_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["HM_TAX_CODE"] = MSG2_TOTAL[5, 4];
			dataRow2["HM_TAX_PRC"] = Conversion.Val(MSG2_TOTAL[5, 2]);
			dataRow2["HM_TAX_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["ROF_AMT"] = 0;
			dataRow2["CARD_AC"] = MSG2_TOTAL[8, 4];
			dataRow2["BANK_AC"] = MSG2_TOTAL[7, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[7, 2];
			dataRow2["BANK_NAME"] = tBankName.Text;
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
		DC_Main.ExeQuteDc("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.RsQry = "SELECT * FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow3 = RsDetl.NewRow();
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG = MSG;
				if ((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 26]) + (Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 23]) + Conversion.Val(mSG[DC_Main.i, 31])) != 0.0))
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
					dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
					dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 5];
					dataRow3["HM_ID"] = mSG[DC_Main.i, 6];
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 8]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 9]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 10]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 11]);
					dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 12]);
					dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 15]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 16]);
					dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 20]);
					dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 21];
					dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 22]);
					dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 23]);
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow3["RATE_WITH"] = mSG[DC_Main.i, 17];
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 18]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 26]);
					dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
					dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 30]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 31]);
					dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 33]);
					dataRow3["KR_NAME"] = mSG[DC_Main.i, 34];
					dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 51];
					dataRow3["IT_TYPE"] = mSG[DC_Main.i, 52];
					dataRow3["PR_CODE"] = mSG[DC_Main.i, 54];
					dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 68];
					dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 45]);
					dataRow3["HM_ID2"] = mSG[DC_Main.i, 79];
					dataRow3["HM_ID3"] = mSG[DC_Main.i, 80];
					dataRow3["HM_ID4"] = mSG[DC_Main.i, 81];
					dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 82]);
					dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 83]);
					dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 84]);
					dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 85]);
					dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 87];
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["MAIN_USER"] = MainUser;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			DC_Main.ExeQuteDc("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18])) != 0.0)
				{
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["AC_CODE"] = tAcCode.Text;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = "S";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]));
					dataRow4["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]))), 1];
					dataRow4["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]))), 45]);
					dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
					dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
					dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
					dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
					dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
					dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]);
					dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]);
					dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
					dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]);
					dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
					dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
					dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
					dataRow4["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			if (Operators.CompareString(FormMainBook, "PURC RETURN", false) != 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow5 = RsBarDetl.NewRow();
				int num3 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num3)
				{
					AxMSFlexGrid mSG2 = MSG;
					if ((Conversion.Val(MSG[DC_Main.i, 8]) + Conversion.Val(MSG[DC_Main.i, 11]) + Conversion.Val(MSG[DC_Main.i, 31]) != 0.0) & (Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0))
					{
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						dataRow5["LC_CODE"] = DC_Main.MLc_code;
						dataRow5["CO_YEAR"] = DC_Main.MCo_year;
						dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow5["VCH_NO"] = tVchNo.Text;
						dataRow5["VCH_DATE"] = mVchDate.Text;
						dataRow5["STK_DATE"] = mVchDate.Text;
						dataRow5["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow5["AC_CODE"] = tAcCode.Text;
						dataRow5["VCH_TYPE"] = FormBookSname;
						dataRow5["INOUT_TYPE"] = FormBookInOut;
						dataRow5["ENTRY_TYPE"] = "P";
						dataRow5["BOOK_NAME"] = FormMainBook;
						dataRow5["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
						dataRow5["OLD_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 50]);
						dataRow5["IT_CODE"] = mSG2[DC_Main.i, 2];
						if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) == 0)
						{
							dataRow5["TAG_NO"] = "N";
						}
						else
						{
							dataRow5["TAG_NO"] = mSG2[DC_Main.i, 1];
						}
						dataRow5["TBL_CODE"] = mSG2[DC_Main.i, 3];
						dataRow5["DESIGN_NO"] = mSG2[DC_Main.i, 4];
						dataRow5["ITM_SIZE"] = mSG2[DC_Main.i, 5];
						dataRow5["HM_ID"] = mSG2[DC_Main.i, 6];
						dataRow5["ITM_PCS"] = Conversion.Val(mSG2[DC_Main.i, 8]);
						dataRow5["ITM_GWT"] = Conversion.Val(mSG2[DC_Main.i, 9]);
						dataRow5["ITM_OTH_WT"] = Conversion.Val(mSG2[DC_Main.i, 10]);
						dataRow5["ITM_NWT"] = Conversion.Val(mSG2[DC_Main.i, 11]);
						dataRow5["ITM_GHT_PRC"] = Conversion.Val(mSG2[DC_Main.i, 12]);
						dataRow5["ITM_GHT_WT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
						dataRow5["ITM_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 14]);
						dataRow5["ITM_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 15]);
						dataRow5["ITM_FINE"] = Conversion.Val(mSG2[DC_Main.i, 16]);
						dataRow5["KR_GHT_WT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
						dataRow5["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 14]);
						dataRow5["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 15]);
						dataRow5["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 16]);
						dataRow5["ITM_RATE"] = 0;
						dataRow5["ITM_AMT"] = 0;
						dataRow5["LBR_CODE"] = "";
						dataRow5["LBR_PRC"] = Conversion.Val(mSG2[DC_Main.i, 20]);
						dataRow5["LBR_TYPE"] = mSG2[DC_Main.i, 21];
						dataRow5["LBR_PRC"] = Conversion.Val(mSG2[DC_Main.i, 20]);
						dataRow5["LBR_RATE"] = Conversion.Val(mSG2[DC_Main.i, 22]);
						dataRow5["LBR_AMT"] = Conversion.Val(mSG2[DC_Main.i, 23]);
						dataRow5["OTH_AMT"] = Conversion.Val(mSG2[DC_Main.i, 25]);
						dataRow5["KR_COST"] = Conversion.Val(mSG2[DC_Main.i, 46]);
						dataRow5["TAG_COST"] = Conversion.Val(mSG2[DC_Main.i, 46]);
						dataRow5["ITM_MRP"] = Conversion.Val(mSG2[DC_Main.i, 26]);
						dataRow5["KR_NAME"] = mSG2[DC_Main.i, 34];
						dataRow5["RATE_TYPE"] = mSG2[DC_Main.i, 51];
						dataRow5["IT_TYPE"] = mSG2[DC_Main.i, 52];
						dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow5["PR_CODE"] = mSG2[DC_Main.i, 54];
						dataRow5["TAG_TYPE"] = mSG2[DC_Main.i, 53];
						dataRow5["KR_LBR_RATE"] = 0;
						dataRow5["KR_LBR_AMT"] = 0;
						dataRow5["KR_OTH_AMT"] = 0;
						dataRow5["TAG_SRNO"] = 0;
						if (Conversion.Val(mSG2[DC_Main.i, 45]) == 0.0)
						{
							mSG2[mSG2.Row, 45] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + "5" + DC_Main.MLc_code + MsVchSrno;
							dataRow5["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 45]);
						}
						else
						{
							dataRow5["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 45]);
						}
						dataRow5["TAG_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 49]);
						dataRow5["APR_ISU"] = "N";
						dataRow5["EMP_ISU"] = "N";
						dataRow5["DESIGN_IMG_ID"] = mSG2[DC_Main.i, 87];
						dataRow5["DATA_TYPE"] = "A";
						dataRow5["DATA_TRFR"] = "N";
						dataRow5["MAIN_USER"] = MainUser;
						RsBarDetl.Rows.Add(dataRow5);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
						RsBarDetl.Clear();
						DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SRNO = '" + Strings.Mid(mSG2[DC_Main.i, 45], 5, 6) + "' AND TAG_NO = '" + mSG2[DC_Main.i, 1] + "'";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Mid(mSG2[DC_Main.i, 45], 5, 6) + "','" + mSG2[DC_Main.i, 45] + "','" + mSG2[DC_Main.i, 1] + "','" + mSG2[DC_Main.i, 2] + "')";
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					mSG2 = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow6 = RsIdtl.NewRow();
				int num4 = DtIdtl.Rows.Count - 1;
				for (int j = 0; j <= num4; j++)
				{
					DataTable dtIdtl2 = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][10])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][11])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][18])) != 0.0)
					{
						dataRow6["CO_CODE"] = DC_Main.MCo_code;
						dataRow6["LC_CODE"] = DC_Main.MLc_code;
						dataRow6["CO_YEAR"] = DC_Main.MCo_year;
						dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow6["VCH_NO"] = tVchNo.Text;
						dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow6["VCH_DATE"] = mVchDate.Text;
						dataRow6["AC_CODE"] = tAcCode.Text;
						dataRow6["VCH_TYPE"] = FormBookSname;
						dataRow6["INOUT_TYPE"] = FormBookInOut;
						dataRow6["ENTRY_TYPE"] = "S";
						dataRow6["BOOK_NAME"] = FormMainBook;
						dataRow6["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]));
						dataRow6["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]))), 1];
						dataRow6["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]))), 45]);
						dataRow6["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][0]));
						dataRow6["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][1]);
						dataRow6["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][3]);
						dataRow6["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][4]);
						dataRow6["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][5]);
						dataRow6["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][6]);
						dataRow6["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][7]);
						dataRow6["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][8]);
						dataRow6["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][9]);
						dataRow6["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][10]));
						dataRow6["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][11]));
						dataRow6["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][20]));
						dataRow6["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12]));
						dataRow6["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][13]);
						dataRow6["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][14]));
						dataRow6["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][15]));
						dataRow6["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16]));
						dataRow6["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][17]));
						dataRow6["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][18]));
						dataRow6["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][19]));
						dataRow6["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][22]);
						dataRow6["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow6);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl2 = null;
				}
				if (Operators.CompareString(tAcCode.Text, "00045", false) != 0)
				{
					DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
					DC_Main.RsQry = "SELECT * FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
					RsBillOs = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow7 = RsBillOs.NewRow();
					if (Conversion.Val(MSG2_TOTAL[6, 4]) != 0.0)
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
						dataRow7["BILL_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
						dataRow7["REC_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]) - (Conversion.Val(MSG2_TOTAL[11, 3]) + Conversion.Val(MSG2_TOTAL[10, 3]));
						dataRow7["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
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
			}
			if (Operators.CompareString(DC_Main.MsOsBillSms, "Y", false) == 0)
			{
				WappMsg = "Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[11, 3])) + " " + SmsDetail;
			}
			else
			{
				WappMsg = SmsDetail;
			}
			AdminWappMsg = tAcName.Text + " Book = " + DC_Main.MCo_Book + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[6, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[11, 3]));
			if (Operators.CompareString(EntryMode, "E", false) == 0)
			{
				WappMsg = "";
				AdminWappMsg = "";
			}
			WappAcName = tAcName.Text;
			WappMobile = tMobile.Text;
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE A SET  A.ZERO_RATED_AMT = B.ZeroRated FROM " + TblData + " AS A  INNER JOIN(Select B.CO_CODE, LC_CODE, CO_YEAR, CO_BOOK, VCH_NO, SUM(ITM_AMT) As ZeroRated   FROM " + TblDetl + " AS B,ITEM_MAST AS C WHERE B.CO_CODE = C.CO_CODE And B.IT_CODE =  C.IT_CODE And C.TAX_FREE_ITEM = 'Y'  GROUP BY B.CO_CODE, B.LC_CODE, B.CO_YEAR, B.CO_BOOK, B.VCH_NO) As B On A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE  And A.CO_YEAR = B.CO_YEAR And A.CO_BOOK = B.CO_BOOK And A.VCH_NO = B.VCH_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0)
			{
				Ac_Ledr.Purc_Rtn_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.Purc_Rtn_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Purc_Rtn_GST(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Purc_Rtn_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Dm_PrRtn_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			else
			{
				Ac_Ledr.SaleReturn_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.SaleReturn_RojMel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Sales_Rtn_GST(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.SaleReturn_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Dm_Sale_Return_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
			DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,TAX_AMT FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND TAX_AMT <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["TAX_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false))))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					int num5 = 0;
					int num6 = dataTable2.Rows.Count - 1;
					for (num5 = 0; num5 <= num6; num5++)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dataTable2.Rows[num5]["NET_AMT"], (object)0, false))
						{
							double num7 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(dataTable2.Rows[num5]["NET_AMT"], DC_Main.Rshlp.Rows[0]["TAX_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
								2
							}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + TblDetl + " SET IT_TAX_AMT = " + Conversions.ToString(num7) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable2.Rows[num5]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable2.Rows[num5]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable2.Rows[num5]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable2.Rows[num5]["SR_NO"]), (object)"")));
						}
					}
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE " + TblDetl + " SET IT_TAX_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
				}
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
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,TOT_AMT,CASH_AMT+CARD_AMT+CHQ_AMT+KASAR_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM " + TblData + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,'',NET_AMT,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM " + TblDetl + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BILL_OS_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SALE_RTN_UAE_KeyDown(object sender, KeyEventArgs e)
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
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM " + TblData + " AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
			}
			string rptName = ((Operators.CompareString(FormMainBook, "PURC RETURN", false) != 0) ? "SalesRtnBillUae" : ((Operators.CompareString(FormBookType, "T", false) != 0) ? "PrRtnBill" : "PrRtnBillGst"));
			DC_Main.MsWappPrintType = "AmtBal";
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.RptFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
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
		if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PrRtnBillGst.RPT";
				string rptName = "PrRtnBillGst";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PrRtnBill.RPT";
				string rptName = "PrRtnBill";
			}
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesRtnBillUae.RPT";
			string rptName = "SalesRtnBillUae.RPT";
		}
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
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

	private void TR_SALE_RTN_UAE_Activated(object sender, EventArgs e)
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
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,TOT_AMT As BillAmtR FROM " + TblData + " AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
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
		//IL_0bb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbb: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7a: Expected O, but got Unknown
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
					MSG_IDTL.Rows += 1;
					num++;
				}
			}
			ItmStk(MSG.Row);
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 87], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
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
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					Image image;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					PicImage.Image = image;
				}
				else if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
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
						ProjectData.ClearProjectError();
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
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
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
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_CODE MasterAcL,B.AC_NAME As AcMastNameL,A.AC_CODE As VchAcL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,TOT_AMT As BillAmtR FROM " + TblData + " AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.AC_NAME <> A.AC_NAME AND A.AC_CODE <> '00045'  ORDER BY A.VCH_NO";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_SALE_RTN_UAE_Closed(object sender, EventArgs e)
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
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM " + TblData + " WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
				case 10:
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
			while (DC_Main.i <= 11);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Tcs Amt : ";
			mSG2_TOTAL[4, 0] = "Lbr Amt : ";
			mSG2_TOTAL[5, 0] = "Lbr Tax : ";
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
				if ((Operators.CompareString(DC_Main.MsEstmateBankLock, "Y", false) == 0) & (Operators.CompareString(FormBookType, "T", false) != 0))
				{
					if ((mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 8))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 11))
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b4a: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				default:
					if (unchecked((int)keyCode) == 112)
					{
					}
					break;
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
		if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
		{
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 23]) + Conversion.Val(MSG_TOT[0, 25]), DC_Main.MsTotAmtRof), "0.00");
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
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 19]), DC_Main.MsTotAmtRof), "0.00");
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
		if (Operators.CompareString(EntryMode, "A", false) == 0)
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
							mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
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
		if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
		{
			mSG2_TOTAL[9, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]), 0), "0.00");
			mSG2_TOTAL[11, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[9, 1]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3])), "0.00");
		}
		else
		{
			mSG2_TOTAL[11, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[9, 1]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3])), "0.00");
		}
		if (CustOpAmt > 0.0)
		{
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[11, 3]);
			}
			else
			{
				CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[11, 3]);
			}
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = 0.0 - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[11, 3]));
		}
		else
		{
			CustClAmt = 0.0 - Conversion.Val(mSG2_TOTAL[11, 3]);
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

	private void tIsuNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Invalid comparison between Unknown and I4
		if (Operators.CompareString(FormMainBook, "PURC RETURN", false) == 0 || (int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "SELECT B.*,A.AC_NAME,C.IT_NAME,C.GR_CODE aS RateGr,A.AC_NAME,A.RATE_UNFIX,D.MAIN_BOOK As RtnMainBook FROM ((SL_DATA AS A LEFT JOIN SL_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO) LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY B.SR_NO";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsDetl.Rows.Count == 0)
		{
			btnIsuNo_Click(btnIsuNo, new EventArgs());
			return;
		}
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["AC_CODE"], (object)""));
		tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["AC_NAME"], (object)""));
		if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[0]["RATE_UNFIX"], (object)""), (object)"Y", false))
		{
			chkRateUnFix.Checked = true;
		}
		else
		{
			chkRateUnFix.Checked = false;
		}
		if ((int)Interaction.MsgBox((object)"All Sales Tag In This Voucher Import?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.i = 0;
			MsVchSrno = "";
			AxMSFlexGrid mSG = MSG;
			checked
			{
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
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
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
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GHT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_COST"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					AxMSFlexGrid obj = mSG;
					int num = DC_Main.i + 1;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["ISU_SRNO"]);
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["ISU_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					obj[num, 74] = Conversions.ToString(num2);
					mSG[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 56] = "E";
					mSG[DC_Main.i + 1, 86] = "Y";
					mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					if (DC_Main.i + 1 == 1 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RtnMainBook"], (object)""), (object)"ITEM SALES", false))
					{
						mSG[DC_Main.i + 1, 30] = "";
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAX_TYPE"], (object)""), (object)"A", false))
						{
							AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["TAX_PRC"]);
							double num3 = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							mSG2_TOTAL[2, 2] = Strings.Format((object)num3, "0.00");
							MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAX_CODE"], (object)""));
							DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 4] + "'";
							DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.RsAc.Rows.Count > 0)
							{
								MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
							}
						}
						else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAX_TYPE"], (object)""), (object)"L", false))
						{
							AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
							Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.i])["TAX_PRC"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							mSG2_TOTAL2[5, 2] = Strings.Format((object)num4, "0.00");
							MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAX_CODE"], (object)""));
							DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[5, 4] + "'";
							DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.RsAc.Rows.Count > 0)
							{
								MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
							}
						}
						else
						{
							MSG2_TOTAL[5, 1] = "";
							MSG2_TOTAL[5, 2] = "";
							MSG2_TOTAL[5, 4] = "";
						}
					}
					if (Operators.CompareString(MsVchSrno, "", false) == 0)
					{
						DC_Main.RsQry = "Select Max(TAG_SRNO) AS SrNo FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' Having Max(TAG_SRNO) > 0";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							MsVchSrno = "000001";
						}
						else
						{
							MsVchSrno = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SrNo"])) + 1.0), "000000");
						}
					}
					else
					{
						MsVchSrno = Strings.Format((object)(Conversion.Val(MsVchSrno) + 1.0), "000000");
					}
					mSG[DC_Main.i + 1, 45] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + "5" + DC_Main.MLc_code + MsVchSrno;
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				MSG_TOT_FILL();
				BILL_TOTAL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num5 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num5)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
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
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldAcCode = tAcCode.Text;
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			((Control)tAcCode).Focus();
		}
	}

	private void btnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,B.BOOK_NAME As BookL,A.TOT_AMT As BillAmtR,A.CO_YEAR As YearL,A.CO_BOOK As CoBookL FROM  " + TblData + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK IN ('SALES','ITEM SALES','B2B SALES')  ORDER BY A.VCH_DATE,A.VCH_NO DESC";
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

	private void nCrDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
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

	private void TR_SALE_RTN_UAE_DoubleClick(object sender, EventArgs e)
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

	private void TR_SALE_RTN_UAE_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_IDTL).SelectionLength = Strings.Len(TEXT_IDTL.Text);
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
