using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web.Script.Serialization;
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
using Newtonsoft.Json;
using QRCoder;
using RestSharp;

namespace DataCareNext;

[DesignerGenerated]
public class TR_SL_EBILL : Form
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
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItRemark")]
	private TextBox _tItRemark;

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
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlEInvoice")]
	private Panel _pnlEInvoice;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEdata")]
	private SimpleButton _btnEdata;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTokanGen")]
	private SimpleButton _btnTokanGen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnEExit")]
	private SimpleButton _btnEExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnIrnGen")]
	private SimpleButton _btnIrnGen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnePrint")]
	private SimpleButton _btnePrint;

	private object eInDetail;

	private object JsonObj;

	private object IRNResp;

	private object IRNData;

	private JavaScriptSerializer serializer;

	private string AuthToken;

	private string ASPID;

	private string ASPPwd;

	private string GSTIN;

	private string eInvUserId;

	private string eInvPwd;

	private string eCoLegalName;

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

	private double TotDrFine;

	private string CoStateCode;

	private double OldTcsPrc;

	private double AcTcsAmt;

	private double OldNetAmt;

	private bool CompnyAndParyDetail;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OrdGold;

	private double OrdSilver;

	private string OldAcCode;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private double RecAdjAmt;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsImg;

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

	private double VpAdjAmt;

	private string MaxVchNo;

	private string LastVchNo;

	private bool RowChang;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItCode = 2;

	private const int cDesign = 3;

	private const int cBagWt = 4;

	private const int cPcs = 5;

	private const int cGrWt = 6;

	private const int cOthWt = 7;

	private const int cNetWt = 8;

	private const int cTouch = 9;

	private const int cWestPrc = 10;

	private const int cFine = 11;

	private const int cItRate = 12;

	private const int cItAmt = 13;

	private const int cLbrPrc = 14;

	private const int cLbrType = 15;

	private const int cLbrRate = 16;

	private const int cLbrAmt = 17;

	private const int cOthAmt = 18;

	private const int cMrp = 19;

	private const int cDiscPrc = 20;

	private const int cDiscAmt = 21;

	private const int cTaxableAmt = 22;

	private const int cTaxableRate = 23;

	private const int cTaxCode = 24;

	private const int cTaxPrc = 25;

	private const int cIgstAmt = 26;

	private const int cCgstAmt = 27;

	private const int cSgstAmt = 28;

	private const int cNetAmt = 29;

	private const int cHmId = 30;

	private const int cCounter = 31;

	private const int cSize = 32;

	private const int cGhtPrc = 33;

	private const int cGhtWt = 34;

	private const int cKrName = 35;

	private const int cKrOthWt = 36;

	private const int cKrNetWt = 37;

	private const int cKrGhatPrc = 38;

	private const int cKrGhatWt = 39;

	private const int cKrTouch = 40;

	private const int cKrWestPrc = 41;

	private const int cKrFine = 42;

	private const int cKrLRate = 43;

	private const int cKrLAmt = 44;

	private const int cKrOthAmt = 45;

	private const int cPrCost = 46;

	private const int cVchSrno = 47;

	private const int cTagCost = 48;

	private const int cMargin = 49;

	private const int cImageTake = 50;

	private const int cTagSrNo = 51;

	private const int cOldSrNo = 52;

	private const int cRateType = 53;

	private const int cItType = 54;

	private const int cTagType = 55;

	private const int cPrCode = 56;

	private const int cItName = 57;

	private const int cEntryMod = 58;

	private const int cOldTagType = 59;

	private const int cOldPrCode = 60;

	private const int cOldGrWt = 61;

	private const int cOldNtWt = 62;

	private const int cOldGhatPrc = 63;

	private const int cOldGhatWt = 64;

	private const int cOldTouch = 65;

	private const int cOldWestPrc = 66;

	private const int cOldKrNetWt = 67;

	private const int cOldKrTouch = 68;

	private const int cOldKrWest = 69;

	private const int cItRemark = 70;

	private const int cOrdDesignIsu = 71;

	private const int cOrdTagGen = 72;

	private const int cOrdTagSale = 73;

	private const int cHmId2 = 74;

	private const int cHmId3 = 75;

	private const int cHmId4 = 76;

	private const int cHmIdWt = 77;

	private const int cHmId2Wt = 78;

	private const int cHmId3Wt = 79;

	private const int cHmId4wt = 80;

	private const int cDesignImgId = 81;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmSize = 5;

	private const int c1DmSfNo = 6;

	private const int c1Pcs = 7;

	private const int c1GrWt = 8;

	private const int c1ConPrc = 9;

	private const int c1RateType = 10;

	private const int c1ItRate = 11;

	private const int c1ItmAmt = 12;

	private const int c1LbrRate = 13;

	private const int c1LbrAmt = 14;

	private const int c1NetAmt = 15;

	private const int c1ConWt = 16;

	private const int c1KrWt = 17;

	private const int c1KrConWt = 18;

	private const int c1ItType = 19;

	private const int c1RowSr = 20;

	private const int cNetAmt2 = 0;

	private const int cIGST2 = 1;

	private const int cCGST2 = 2;

	private const int cSGST2 = 3;

	private const int cTcs2 = 4;

	private const int cRof2 = 5;

	private const int cTot2 = 6;

	private const int cTds2 = 7;

	private const int cCash2 = 8;

	private const int cChq2 = 9;

	private const int cCard2 = 10;

	private const int cKasarAmt2 = 11;

	private const int cOs2 = 12;

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
			EventHandler eventHandler = tVchDesc_TextChanged;
			EventHandler eventHandler2 = tVchDesc_DoubleClick;
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).DoubleClick += eventHandler2;
			}
		}
	}

	internal virtual TextBox tItRemark
	{
		[CompilerGenerated]
		get
		{
			return _tItRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItRemark_KeyDown);
			TextBox val2 = _tItRemark;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItRemark = value;
			val2 = _tItRemark;
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TBillNo_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tBillNo_KeyDown);
			TextBox val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tBillNo = value;
			val2 = _tBillNo;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
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
	[AccessedThroughProperty("tAcType")]
	private virtual TextBox _tAcType;

	internal virtual TextBox tAcType
	{
		get
		{
			return _tAcType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblVchIrn")]
	private virtual Label _lblVchIrn;

	internal virtual Label lblVchIrn
	{
		get
		{
			return _lblVchIrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblVchIrn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchIrnNo")]
	private virtual TextBox _tVchIrnNo;

	internal virtual TextBox tVchIrnNo
	{
		get
		{
			return _tVchIrnNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tVchIrnNo = value;
		}
	}

	internal virtual Panel pnlEInvoice
	{
		[CompilerGenerated]
		get
		{
			return _pnlEInvoice;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = pnlEInvoice_DoubleClick;
			Panel val = _pnlEInvoice;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_pnlEInvoice = value;
			val = _pnlEInvoice;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label33")]
	private virtual Label _Label33;

	internal virtual Label Label33
	{
		get
		{
			return _Label33;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label33 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TxtBoxError")]
	private virtual TextBox _TxtBoxError;

	internal virtual TextBox TxtBoxError
	{
		get
		{
			return _TxtBoxError;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TxtBoxError = value;
		}
	}

	internal virtual SimpleButton btnEdata
	{
		[CompilerGenerated]
		get
		{
			return _btnEdata;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEdata_Click;
			SimpleButton val = _btnEdata;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEdata = value;
			val = _btnEdata;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnTokanGen
	{
		[CompilerGenerated]
		get
		{
			return _btnTokanGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTokanGen_Click;
			SimpleButton val = _btnTokanGen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTokanGen = value;
			val = _btnTokanGen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicEQr")]
	private virtual PictureBox _PicEQr;

	internal virtual PictureBox PicEQr
	{
		get
		{
			return _PicEQr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PicEQr = value;
		}
	}

	internal virtual SimpleButton btnEExit
	{
		[CompilerGenerated]
		get
		{
			return _btnEExit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnEExit_Click;
			SimpleButton val = _btnEExit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnEExit = value;
			val = _btnEExit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnIrnGen
	{
		[CompilerGenerated]
		get
		{
			return _btnIrnGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIrnGen_Click;
			SimpleButton val = _btnIrnGen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnIrnGen = value;
			val = _btnIrnGen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label32")]
	private virtual Label _Label32;

	internal virtual Label Label32
	{
		get
		{
			return _Label32;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label32 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTokan")]
	private virtual TextBox _tTokan;

	internal virtual TextBox tTokan
	{
		get
		{
			return _tTokan;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTokan = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBoxResponce")]
	private virtual RichTextBox _tBoxResponce;

	internal virtual RichTextBox tBoxResponce
	{
		get
		{
			return _tBoxResponce;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBoxResponce = value;
		}
	}

	internal virtual SimpleButton btnePrint
	{
		[CompilerGenerated]
		get
		{
			return _btnePrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnePrint_Click;
			SimpleButton val = _btnePrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnePrint = value;
			val = _btnePrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mAckDt")]
	private virtual MaskedTextBox _mAckDt;

	internal virtual MaskedTextBox mAckDt
	{
		get
		{
			return _mAckDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_mAckDt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAckDt")]
	private virtual Label _lblAckDt;

	internal virtual Label lblAckDt
	{
		get
		{
			return _lblAckDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAckDt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAckNo")]
	private virtual Label _lblAckNo;

	internal virtual Label lblAckNo
	{
		get
		{
			return _lblAckNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAckNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAckNo")]
	private virtual TextBox _tAckNo;

	internal virtual TextBox tAckNo
	{
		get
		{
			return _tAckNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAckNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblIrn")]
	private virtual Label _lblIrn;

	internal virtual Label lblIrn
	{
		get
		{
			return _lblIrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblIrn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIrnNo")]
	private virtual TextBox _tIrnNo;

	internal virtual TextBox tIrnNo
	{
		get
		{
			return _tIrnNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tIrnNo = value;
		}
	}

	public TR_SL_EBILL()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Expected O, but got Unknown
		((Form)this).Load += TR_SL_EBILL_Load;
		((Form)this).Deactivate += TR_SL_EBILL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SL_EBILL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SL_EBILL_KeyDown);
		((Form)this).Activated += TR_SL_EBILL_Activated;
		((Form)this).Closed += TR_SL_EBILL_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_SL_EBILL_KeyUp);
		serializer = new JavaScriptSerializer();
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
		//IL_0416: Unknown result type (might be due to invalid IL or missing references)
		//IL_0420: Expected O, but got Unknown
		//IL_04d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04dc: Expected O, but got Unknown
		//IL_055f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0569: Expected O, but got Unknown
		//IL_0606: Unknown result type (might be due to invalid IL or missing references)
		//IL_0610: Expected O, but got Unknown
		//IL_06be: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected O, but got Unknown
		//IL_074f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fe: Expected O, but got Unknown
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Expected O, but got Unknown
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_0a1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a24: Expected O, but got Unknown
		//IL_0acd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad7: Expected O, but got Unknown
		//IL_0bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfe: Expected O, but got Unknown
		//IL_0d09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d13: Expected O, but got Unknown
		//IL_0d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d80: Expected O, but got Unknown
		//IL_0f12: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd1: Expected O, but got Unknown
		//IL_10c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d3: Expected O, but got Unknown
		//IL_11e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ee: Expected O, but got Unknown
		//IL_126b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1275: Expected O, but got Unknown
		//IL_1339: Unknown result type (might be due to invalid IL or missing references)
		//IL_1343: Expected O, but got Unknown
		//IL_1523: Unknown result type (might be due to invalid IL or missing references)
		//IL_152d: Expected O, but got Unknown
		//IL_1605: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Expected O, but got Unknown
		//IL_16ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b5: Expected O, but got Unknown
		//IL_17ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d4: Expected O, but got Unknown
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Expected O, but got Unknown
		//IL_18e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ea: Expected O, but got Unknown
		//IL_19b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19be: Expected O, but got Unknown
		//IL_1a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a6f: Expected O, but got Unknown
		//IL_1aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af9: Expected O, but got Unknown
		//IL_1b81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8b: Expected O, but got Unknown
		//IL_1c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c49: Expected O, but got Unknown
		//IL_1cfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d07: Expected O, but got Unknown
		//IL_1da6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db0: Expected O, but got Unknown
		//IL_1e31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e3b: Expected O, but got Unknown
		//IL_1ef9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f03: Expected O, but got Unknown
		//IL_1f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8a: Expected O, but got Unknown
		//IL_2038: Unknown result type (might be due to invalid IL or missing references)
		//IL_2042: Expected O, but got Unknown
		//IL_20bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c7: Expected O, but got Unknown
		//IL_217b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2185: Expected O, but got Unknown
		//IL_223c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2246: Expected O, but got Unknown
		//IL_22fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2304: Expected O, but got Unknown
		//IL_23b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c2: Expected O, but got Unknown
		//IL_2479: Unknown result type (might be due to invalid IL or missing references)
		//IL_2483: Expected O, but got Unknown
		//IL_2560: Unknown result type (might be due to invalid IL or missing references)
		//IL_256a: Expected O, but got Unknown
		//IL_25ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d8: Expected O, but got Unknown
		//IL_263f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2649: Expected O, but got Unknown
		//IL_26ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_26b7: Expected O, but got Unknown
		//IL_2718: Unknown result type (might be due to invalid IL or missing references)
		//IL_2722: Expected O, but got Unknown
		//IL_2773: Unknown result type (might be due to invalid IL or missing references)
		//IL_277d: Expected O, but got Unknown
		//IL_2818: Unknown result type (might be due to invalid IL or missing references)
		//IL_2822: Expected O, but got Unknown
		//IL_28d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28dd: Expected O, but got Unknown
		//IL_2b66: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b70: Expected O, but got Unknown
		//IL_2c1d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c27: Expected O, but got Unknown
		//IL_2cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cd0: Expected O, but got Unknown
		//IL_2da5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2daf: Expected O, but got Unknown
		//IL_2e48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e52: Expected O, but got Unknown
		//IL_2f83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f8d: Expected O, but got Unknown
		//IL_3062: Unknown result type (might be due to invalid IL or missing references)
		//IL_306c: Expected O, but got Unknown
		//IL_3105: Unknown result type (might be due to invalid IL or missing references)
		//IL_310f: Expected O, but got Unknown
		//IL_323c: Unknown result type (might be due to invalid IL or missing references)
		//IL_32d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_32dc: Expected O, but got Unknown
		//IL_33b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_33bb: Expected O, but got Unknown
		//IL_3454: Unknown result type (might be due to invalid IL or missing references)
		//IL_345e: Expected O, but got Unknown
		//IL_3593: Unknown result type (might be due to invalid IL or missing references)
		//IL_359d: Expected O, but got Unknown
		//IL_3672: Unknown result type (might be due to invalid IL or missing references)
		//IL_367c: Expected O, but got Unknown
		//IL_3715: Unknown result type (might be due to invalid IL or missing references)
		//IL_371f: Expected O, but got Unknown
		//IL_3837: Unknown result type (might be due to invalid IL or missing references)
		//IL_3841: Expected O, but got Unknown
		//IL_38ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_38f8: Expected O, but got Unknown
		//IL_39fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a04: Expected O, but got Unknown
		//IL_3ad9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ae3: Expected O, but got Unknown
		//IL_3b7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b86: Expected O, but got Unknown
		//IL_3c9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ca8: Expected O, but got Unknown
		//IL_3d2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d39: Expected O, but got Unknown
		//IL_3dea: Unknown result type (might be due to invalid IL or missing references)
		//IL_3df4: Expected O, but got Unknown
		//IL_3ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eaf: Expected O, but got Unknown
		//IL_3f34: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f3e: Expected O, but got Unknown
		//IL_3fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ff9: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SL_EBILL));
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
		PicImage = new PictureBox();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		BtnF1 = new SimpleButton();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		tVchDesc = new TextBox();
		tItRemark = new TextBox();
		Label5 = new Label();
		TEXT_ENTRY_2 = new TextBox();
		Label8 = new Label();
		tBillNo = new TextBox();
		LOpAmt = new Label();
		LClAmt = new Label();
		LOpSilver = new Label();
		LOpGold = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		Cr = new AxCrystalReport();
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_IDTL = new AxMSFlexGrid();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		tAcType = new TextBox();
		lblVchIrn = new Label();
		tVchIrnNo = new TextBox();
		pnlEInvoice = new Panel();
		Label33 = new Label();
		TxtBoxError = new TextBox();
		btnEdata = new SimpleButton();
		btnTokanGen = new SimpleButton();
		PicEQr = new PictureBox();
		btnEExit = new SimpleButton();
		btnIrnGen = new SimpleButton();
		Label32 = new Label();
		tTokan = new TextBox();
		tBoxResponce = new RichTextBox();
		btnePrint = new SimpleButton();
		mAckDt = new MaskedTextBox();
		lblAckDt = new Label();
		lblAckNo = new Label();
		tAckNo = new TextBox();
		lblIrn = new Label();
		tIrnNo = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((Control)pnlEInvoice).SuspendLayout();
		((ISupportInitialize)PicEQr).BeginInit();
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
		lblBook.Text = "E Invoice";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(313, 42);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(228, 43);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(94, 42);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(484, 42);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(395, 42);
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
		((Control)PnlBotam).TabIndex = 10;
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
		((Control)TEXT_ENTRY).Location = new Point(924, 185);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(351, 319);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(369, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(431, 393);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 6;
		((Control)TEXT_IDTL).Visible = false;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(13, 471);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(111, 81);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
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
		((Control)BtnF1).Location = new Point(176, 42);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(313, 71);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(395, 71);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(324, 23);
		((Control)tAcName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(229, 71);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Party Ac";
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
		((Control)tEmpCode).Location = new Point(221, 476);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 8;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(284, 475);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(146, 476);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(147, 508);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(221, 509);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(279, 43);
		((Control)tVchDesc).TabIndex = 9;
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(80, 319);
		((TextBoxBase)tItRemark).MaxLength = 100;
		((Control)tItRemark).Name = "tItRemark";
		((Control)tItRemark).Size = new Size(265, 23);
		((Control)tItRemark).TabIndex = 5;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 320);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(60, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Remark ";
		Label5.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(940, 416);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 7;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 70);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(94, 71);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 2;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1018, 38);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(571, 490);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1210;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1018, 81);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(148, 20);
		((Control)LOpSilver).TabIndex = 1223;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1018, 59);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(148, 20);
		((Control)LOpGold).TabIndex = 1222;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(573, 530);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(148, 20);
		((Control)LClSilver).TabIndex = 1225;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(572, 510);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(148, 20);
		((Control)lClGold).TabIndex = 1224;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 393);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((Control)MSG2_TOTAL).Location = new Point(728, 290);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 267);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_IDTL).Location = new Point(12, 351);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(708, 112);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)MSG_TOT).Location = new Point(14, 272);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(11, 106);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 164);
		((Control)MSG).TabIndex = 1135;
		((TextBoxBase)tAcType).BackColor = Color.White;
		((Control)tAcType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcType).Location = new Point(725, 71);
		((TextBoxBase)tAcType).MaxLength = 8;
		((Control)tAcType).Name = "tAcType";
		((TextBoxBase)tAcType).ReadOnly = true;
		((Control)tAcType).Size = new Size(35, 23);
		((Control)tAcType).TabIndex = 1226;
		tAcType.TextAlign = (HorizontalAlignment)2;
		((Control)lblVchIrn).BackColor = Color.Transparent;
		((Control)lblVchIrn).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblVchIrn).ForeColor = Color.Black;
		lblVchIrn.ImeMode = (ImeMode)0;
		((Control)lblVchIrn).Location = new Point(573, 43);
		((Control)lblVchIrn).Name = "lblVchIrn";
		((Control)lblVchIrn).Size = new Size(36, 20);
		((Control)lblVchIrn).TabIndex = 1236;
		lblVchIrn.Text = "Irn :";
		lblVchIrn.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchIrnNo).BackColor = Color.White;
		((Control)tVchIrnNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchIrnNo).Location = new Point(613, 42);
		((TextBoxBase)tVchIrnNo).MaxLength = 100;
		((Control)tVchIrnNo).Name = "tVchIrnNo";
		((Control)tVchIrnNo).Size = new Size(381, 22);
		((Control)tVchIrnNo).TabIndex = 1235;
		((Control)pnlEInvoice).BackColor = Color.Lavender;
		pnlEInvoice.BorderStyle = (BorderStyle)2;
		((Control)pnlEInvoice).Controls.Add((Control)(object)Label33);
		((Control)pnlEInvoice).Controls.Add((Control)(object)TxtBoxError);
		((Control)pnlEInvoice).Controls.Add((Control)(object)btnEdata);
		((Control)pnlEInvoice).Controls.Add((Control)(object)btnTokanGen);
		((Control)pnlEInvoice).Controls.Add((Control)(object)PicEQr);
		((Control)pnlEInvoice).Controls.Add((Control)(object)btnEExit);
		((Control)pnlEInvoice).Controls.Add((Control)(object)btnIrnGen);
		((Control)pnlEInvoice).Controls.Add((Control)(object)Label32);
		((Control)pnlEInvoice).Controls.Add((Control)(object)tTokan);
		((Control)pnlEInvoice).Controls.Add((Control)(object)tBoxResponce);
		((Control)pnlEInvoice).Controls.Add((Control)(object)btnePrint);
		((Control)pnlEInvoice).Controls.Add((Control)(object)mAckDt);
		((Control)pnlEInvoice).Controls.Add((Control)(object)lblAckDt);
		((Control)pnlEInvoice).Controls.Add((Control)(object)lblAckNo);
		((Control)pnlEInvoice).Controls.Add((Control)(object)tAckNo);
		((Control)pnlEInvoice).Controls.Add((Control)(object)lblIrn);
		((Control)pnlEInvoice).Controls.Add((Control)(object)tIrnNo);
		((Control)pnlEInvoice).Location = new Point(11, 106);
		((Control)pnlEInvoice).Name = "pnlEInvoice";
		((Control)pnlEInvoice).Size = new Size(902, 381);
		((Control)pnlEInvoice).TabIndex = 1237;
		((Control)pnlEInvoice).Visible = false;
		((Control)Label33).BackColor = Color.Transparent;
		((Control)Label33).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label33).ForeColor = Color.Black;
		Label33.ImeMode = (ImeMode)0;
		((Control)Label33).Location = new Point(3, 40);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(79, 20);
		((Control)Label33).TabIndex = 1183;
		Label33.Text = "Error LIst";
		Label33.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TxtBoxError).BackColor = Color.White;
		((Control)TxtBoxError).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TxtBoxError).Location = new Point(94, 38);
		((TextBoxBase)TxtBoxError).MaxLength = 100;
		((Control)TxtBoxError).Name = "TxtBoxError";
		((Control)TxtBoxError).Size = new Size(500, 22);
		((Control)TxtBoxError).TabIndex = 1182;
		((BaseStyleControl)btnEdata).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnEdata).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnEdata).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnEdata).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnEdata).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnEdata).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnEdata).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnEdata).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnEdata).Appearance.Options.UseForeColor = true;
		((BaseButton)btnEdata).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnEdata).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnEdata).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnEdata).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnEdata).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnEdata).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnEdata).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnEdata).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnEdata).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnEdata).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnEdata).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnEdata).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnEdata).AppearancePressed.Options.UseFont = true;
		((Control)btnEdata).Location = new Point(801, 281);
		((BaseControl)btnEdata).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnEdata).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnEdata).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnEdata).Name = "btnEdata";
		((Control)btnEdata).Size = new Size(86, 32);
		((Control)btnEdata).TabIndex = 1181;
		btnEdata.Text = "Get E Data";
		((Control)btnEdata).Visible = false;
		((BaseStyleControl)btnTokanGen).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTokanGen).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTokanGen).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnTokanGen).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTokanGen).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTokanGen).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTokanGen).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTokanGen).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTokanGen).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTokanGen).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTokanGen).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTokanGen).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTokanGen).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTokanGen).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTokanGen).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTokanGen).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTokanGen).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTokanGen).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTokanGen).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnTokanGen).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTokanGen).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTokanGen).AppearancePressed.Options.UseFont = true;
		((Control)btnTokanGen).Location = new Point(605, 281);
		((BaseControl)btnTokanGen).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTokanGen).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTokanGen).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTokanGen).Name = "btnTokanGen";
		((Control)btnTokanGen).Size = new Size(86, 32);
		((Control)btnTokanGen).TabIndex = 1180;
		btnTokanGen.Text = "Get Tokan";
		((BaseControl)btnTokanGen).ToolTip = "Irn Gen";
		PicEQr.BorderStyle = (BorderStyle)2;
		PicEQr.ImeMode = (ImeMode)0;
		((Control)PicEQr).Location = new Point(605, 13);
		((Control)PicEQr).Margin = new Padding(2);
		((Control)PicEQr).Name = "PicEQr";
		((Control)PicEQr).Size = new Size(280, 251);
		PicEQr.TabIndex = 1179;
		PicEQr.TabStop = false;
		((BaseStyleControl)btnEExit).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnEExit).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnEExit).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnEExit).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnEExit).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnEExit).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnEExit).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnEExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnEExit).Appearance.Options.UseForeColor = true;
		((BaseButton)btnEExit).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnEExit).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnEExit).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnEExit).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnEExit).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnEExit).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnEExit).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnEExit).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnEExit).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnEExit).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnEExit).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnEExit).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnEExit).AppearancePressed.Options.UseFont = true;
		((Control)btnEExit).Location = new Point(703, 323);
		((BaseControl)btnEExit).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnEExit).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnEExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnEExit).Name = "btnEExit";
		((Control)btnEExit).Size = new Size(86, 32);
		((Control)btnEExit).TabIndex = 1178;
		btnEExit.Text = "Exit";
		((BaseControl)btnEExit).ToolTip = "Irn Gen";
		((BaseStyleControl)btnIrnGen).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnIrnGen).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnIrnGen).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnIrnGen).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnIrnGen).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnIrnGen).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnIrnGen).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnIrnGen).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnIrnGen).Appearance.Options.UseForeColor = true;
		((BaseButton)btnIrnGen).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnIrnGen).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnIrnGen).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnIrnGen).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnIrnGen).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnIrnGen).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnIrnGen).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnIrnGen).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnIrnGen).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnIrnGen).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnIrnGen).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnIrnGen).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnIrnGen).AppearancePressed.Options.UseFont = true;
		((Control)btnIrnGen).Location = new Point(703, 281);
		((BaseControl)btnIrnGen).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIrnGen).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIrnGen).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIrnGen).Name = "btnIrnGen";
		((Control)btnIrnGen).Size = new Size(86, 32);
		((Control)btnIrnGen).TabIndex = 1177;
		btnIrnGen.Text = "Irn Gen";
		((BaseControl)btnIrnGen).ToolTip = "Irn Gen";
		((Control)Label32).BackColor = Color.Transparent;
		((Control)Label32).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label32).ForeColor = Color.Black;
		Label32.ImeMode = (ImeMode)0;
		((Control)Label32).Location = new Point(8, 12);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(79, 20);
		((Control)Label32).TabIndex = 1176;
		Label32.Text = "AuthToken";
		Label32.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tTokan).BackColor = Color.White;
		((Control)tTokan).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tTokan).Location = new Point(94, 10);
		((TextBoxBase)tTokan).MaxLength = 100;
		((Control)tTokan).Name = "tTokan";
		((Control)tTokan).Size = new Size(500, 22);
		((Control)tTokan).TabIndex = 1175;
		((Control)tBoxResponce).Location = new Point(94, 66);
		((Control)tBoxResponce).Name = "tBoxResponce";
		((Control)tBoxResponce).Size = new Size(500, 172);
		((Control)tBoxResponce).TabIndex = 1174;
		tBoxResponce.Text = "";
		((BaseStyleControl)btnePrint).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnePrint).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnePrint).Appearance.Font = new Font("Arial", 11.25f);
		((BaseStyleControl)btnePrint).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnePrint).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnePrint).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnePrint).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnePrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnePrint).Appearance.Options.UseForeColor = true;
		((BaseButton)btnePrint).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnePrint).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnePrint).AppearanceHovered.Font = new Font("Arial", 11.25f);
		((BaseButton)btnePrint).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnePrint).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnePrint).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnePrint).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnePrint).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnePrint).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnePrint).AppearancePressed.Font = new Font("Arial", 11.25f);
		((BaseButton)btnePrint).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnePrint).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnePrint).AppearancePressed.Options.UseFont = true;
		((Control)btnePrint).Location = new Point(605, 323);
		((BaseControl)btnePrint).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnePrint).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnePrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnePrint).Name = "btnePrint";
		((Control)btnePrint).Size = new Size(86, 32);
		((Control)btnePrint).TabIndex = 1173;
		btnePrint.Text = "e Print";
		((BaseControl)btnePrint).ToolTip = "e Invoice Print";
		((TextBoxBase)mAckDt).BackColor = Color.White;
		((Control)mAckDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mAckDt).Location = new Point(94, 303);
		mAckDt.Mask = "00/00/0000";
		((Control)mAckDt).Name = "mAckDt";
		((Control)mAckDt).Size = new Size(76, 23);
		((Control)mAckDt).TabIndex = 1171;
		mAckDt.ValidatingType = typeof(DateTime);
		((Control)lblAckDt).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblAckDt).ForeColor = Color.Black;
		lblAckDt.ImeMode = (ImeMode)0;
		((Control)lblAckDt).Location = new Point(17, 303);
		((Control)lblAckDt).Name = "lblAckDt";
		((Control)lblAckDt).Size = new Size(71, 20);
		((Control)lblAckDt).TabIndex = 1172;
		lblAckDt.Text = "Ack Date";
		lblAckDt.TextAlign = (ContentAlignment)64;
		((Control)lblAckNo).BackColor = Color.Transparent;
		((Control)lblAckNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAckNo).ForeColor = Color.Black;
		lblAckNo.ImeMode = (ImeMode)0;
		((Control)lblAckNo).Location = new Point(39, 274);
		((Control)lblAckNo).Name = "lblAckNo";
		((Control)lblAckNo).Size = new Size(49, 20);
		((Control)lblAckNo).TabIndex = 1170;
		lblAckNo.Text = "Ack No";
		lblAckNo.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAckNo).BackColor = Color.White;
		((Control)tAckNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAckNo).Location = new Point(94, 272);
		((TextBoxBase)tAckNo).MaxLength = 100;
		((Control)tAckNo).Name = "tAckNo";
		((Control)tAckNo).Size = new Size(285, 22);
		((Control)tAckNo).TabIndex = 1169;
		((Control)lblIrn).BackColor = Color.Transparent;
		((Control)lblIrn).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblIrn).ForeColor = Color.Black;
		lblIrn.ImeMode = (ImeMode)0;
		((Control)lblIrn).Location = new Point(39, 244);
		((Control)lblIrn).Name = "lblIrn";
		((Control)lblIrn).Size = new Size(49, 20);
		((Control)lblIrn).TabIndex = 1168;
		lblIrn.Text = "Irn No";
		lblIrn.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tIrnNo).BackColor = Color.White;
		((Control)tIrnNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tIrnNo).Location = new Point(94, 244);
		((TextBoxBase)tIrnNo).MaxLength = 100;
		((Control)tIrnNo).Name = "tIrnNo";
		((Control)tIrnNo).Size = new Size(500, 22);
		((Control)tIrnNo).TabIndex = 1167;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)pnlEInvoice);
		((Control)this).Controls.Add((Control)(object)lblVchIrn);
		((Control)this).Controls.Add((Control)(object)tVchIrnNo);
		((Control)this).Controls.Add((Control)(object)tAcType);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItRemark);
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
		((Control)this).Name = "TR_SL_EBILL";
		((Form)this).Text = "E Invoice";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((Control)pnlEInvoice).ResumeLayout(false);
		((Control)pnlEInvoice).PerformLayout();
		((ISupportInitialize)PicEQr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 82;
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
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[2] = (int)Math.Round(1000.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[3] = (int)Math.Round(1300.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Design";
			mSG[4] = (int)Math.Round(800.0 * ColCon);
			mSG[4] = 7;
			mSG[0, 4] = "BagWt";
			mSG[5] = (int)Math.Round(700.0 * ColCon);
			mSG[5] = 7;
			mSG[0, 5] = "Pcs";
			mSG[6] = (int)Math.Round(1000.0 * ColCon);
			mSG[6] = 7;
			mSG[0, 6] = "GrWt";
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "LsWt";
			mSG[8] = (int)Math.Round(1000.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "NetWt";
			mSG[9] = (int)Math.Round(850.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Touch";
			mSG[10] = (int)Math.Round(850.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "West%";
			mSG[11] = (int)Math.Round(1000.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "Fine";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "ItRate";
			mSG[13] = (int)Math.Round(1100.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "ItAmt";
			mSG[14] = (int)Math.Round(800.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Lbr%";
			mSG[15] = (int)Math.Round(800.0 * ColCon);
			mSG[15] = 3;
			mSG[0, 15] = "LType";
			mSG[16] = (int)Math.Round(900.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "LbrRate";
			mSG[17] = (int)Math.Round(950.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "LbrAmt";
			mSG[18] = (int)Math.Round(1000.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "OthAmt";
			mSG[19] = (int)Math.Round(900.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "Mrp";
			mSG[20] = (int)Math.Round(900.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Disc%";
			mSG[21] = (int)Math.Round(900.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "DiscAmt";
			mSG[22] = (int)Math.Round(1200.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "TxblAmt";
			mSG[23] = (int)Math.Round(1100.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "TxblRate";
			mSG[24] = (int)Math.Round(1000.0 * ColCon);
			mSG[24] = 3;
			mSG[0, 24] = "TxCode";
			mSG[25] = (int)Math.Round(800.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Tax%";
			mSG[26] = (int)Math.Round(1000.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "IGSTamt";
			mSG[27] = (int)Math.Round(1000.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "CGSTamt";
			mSG[28] = (int)Math.Round(1000.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "SGSTamt";
			mSG[29] = (int)Math.Round(1200.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "NetAmt";
			mSG[30] = (int)Math.Round(900.0 * ColCon);
			mSG[30] = 3;
			mSG[0, 30] = "HuId";
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[33] = 0;
			mSG[34] = 0;
			mSG[35] = 0;
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
			mSG[72] = 0;
			mSG[73] = 0;
			mSG[74] = 0;
			mSG[75] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			mSG[78] = 0;
			mSG[79] = 0;
			mSG[80] = 0;
			mSG[81] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'E_SALE' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 29;
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
			((Control)TEXT_ENTRY).Visible = false;
		}
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 21;
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
			mSG_IDTL[7] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[7] = 7;
			mSG_IDTL[0, 7] = "Pcs";
			mSG_IDTL[8] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[8] = 7;
			mSG_IDTL[0, 8] = "Weight";
			mSG_IDTL[9] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[9] = 7;
			mSG_IDTL[0, 9] = "Con%";
			mSG_IDTL[10] = (int)Math.Round(700.0 * ColCon);
			mSG_IDTL[10] = 3;
			mSG_IDTL[0, 10] = "P/W";
			mSG_IDTL[11] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "Rate";
			mSG_IDTL[12] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "ItAmt";
			mSG_IDTL[13] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "LbrRate";
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "LbrAmt";
			mSG_IDTL[15] = (int)Math.Round(1150.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "NetAmt";
			mSG_IDTL[16] = 0;
			mSG_IDTL[0, 16] = "ConWt";
			mSG_IDTL[17] = 0;
			mSG_IDTL[0, 17] = "KrWt";
			mSG_IDTL[18] = 0;
			mSG_IDTL[0, 18] = "KrConWt";
			mSG_IDTL[19] = 0;
			mSG_IDTL[0, 19] = "ItType";
			mSG_IDTL[20] = 0;
			mSG_IDTL[0, 20] = "RowSrNo";
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
		mSG_IDTL[mSG_IDTL.Row, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 52]));
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 20])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
				if (mSG_IDTL.Col < 15)
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
									mSG_IDTL[mSG_IDTL.Row, 19] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 19] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
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
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 11]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 15:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
				case 6:
					((TextBoxBase)TEXT_IDTL).MaxLength = 15;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 10:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 9:
				case 11:
				case 12:
				case 13:
				case 14:
				case 15:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 8:
				case 16:
				case 17:
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
			case 10:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 7:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 9:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 8:
			case 16:
			case 17:
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
		if ((Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 8]) == 0.0))
		{
			mSG_IDTL[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 17]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) == 0.0))
		{
			mSG_IDTL[CRow, 17] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 8]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 9]) != 0.0))
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 9])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 16] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 9]) != 0.0))
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 17]) * Conversion.Val(mSG_IDTL[CRow, 9])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 18] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 10], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 8]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0))
			{
				mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0))
			{
				mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 8])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 10], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 11])))) != 0)
		{
			mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0)
		{
			mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) * Conversion.Val(mSG_IDTL[CRow, 8])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0)
		{
			mSG_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 13]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 12]) + Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) + Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
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
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 16]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 15]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 7] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 8] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 6]) - Conversion.Val(MSG[MSG.Row, 7])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 36] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 37] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 6]) - Conversion.Val(MSG[MSG.Row, 36])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 18] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 45] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 8] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 6]) - num2), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])) == Conversion.Val(mSG_IDTL[CRow, 20])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
						DtIdtl.Rows[i][17] = mSG_IDTL[CRow, 17];
						DtIdtl.Rows[i][9] = mSG_IDTL[CRow, 9];
						DtIdtl.Rows[i][10] = mSG_IDTL[CRow, 10];
						DtIdtl.Rows[i][11] = mSG_IDTL[CRow, 11];
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
						DtIdtl.Rows[i][13] = mSG_IDTL[CRow, 13];
						DtIdtl.Rows[i][14] = mSG_IDTL[CRow, 14];
						DtIdtl.Rows[i][15] = mSG_IDTL[CRow, 15];
						DtIdtl.Rows[i][16] = mSG_IDTL[CRow, 16];
						DtIdtl.Rows[i][18] = mSG_IDTL[CRow, 18];
						DtIdtl.Rows[i][19] = mSG_IDTL[CRow, 19];
						DtIdtl.Rows[i][20] = mSG_IDTL[CRow, 20];
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
					dr[17] = mSG_IDTL[CRow, 17];
					dr[9] = mSG_IDTL[CRow, 9];
					dr[10] = mSG_IDTL[CRow, 10];
					dr[11] = mSG_IDTL[CRow, 11];
					dr[12] = mSG_IDTL[CRow, 12];
					dr[13] = mSG_IDTL[CRow, 13];
					dr[14] = mSG_IDTL[CRow, 14];
					dr[15] = mSG_IDTL[CRow, 15];
					dr[16] = mSG_IDTL[CRow, 16];
					dr[18] = mSG_IDTL[CRow, 18];
					dr[19] = mSG_IDTL[CRow, 19];
					dr[20] = mSG_IDTL[CRow, 20];
					DtIdtl.Rows.Add(dr);
				}
			}
			mSG_IDTL = null;
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
			int num = MSG.Cols - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				mSG_TOT[0, DC_Main.M] = "";
				DC_Main.M++;
			}
			TotDrFine = 0.0;
			mSG_TOT[0, 3] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0");
				mSG_TOT[0, 4] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 4]) + Conversion.Val(MSG[DC_Main.M, 4]))), "0.000");
				mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0.000");
				mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
				mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
				mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.000");
				mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
				mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.00");
				mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.00");
				mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.00");
				mSG_TOT[0, 48] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 48]) + Conversion.Val(MSG[DC_Main.M, 48]))), "0.00");
				mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.000");
				mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.00");
				mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.00");
				mSG_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 27]) + Conversion.Val(MSG[DC_Main.M, 27]))), "0.00");
				mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.00");
				mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
				mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.000");
				mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.000");
				mSG_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 39]) + Conversion.Val(MSG[DC_Main.M, 39]))), "0.000");
				mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.000");
				mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.00");
				mSG_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 45]) + Conversion.Val(MSG[DC_Main.M, 45]))), "0.00");
				mSG_TOT[0, 46] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 46]) + Conversion.Val(MSG[DC_Main.M, 46]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 13]) == 0.0)
				{
					TotDrFine += Conversion.Val(MSG[DC_Main.M, 11]);
				}
				DC_Main.M++;
			}
			mSG_TOT = null;
			NewValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 17]);
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			mSG.Row = mSG.Rows - 1;
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
			mSG[mSG.Row, 5] = Conversions.ToString(1);
			mSG[mSG.Row, 15] = DC_Main.MsLbrType;
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ025NBKJ", false) == 0) & (Operators.CompareString(DC_Main.MCo_Book, "162", false) == 0))
			{
				mSG[mSG.Row, 24] = "11";
				mSG[mSG.Row, 25] = "5.00";
			}
			else
			{
				mSG[mSG.Row, 24] = "10";
				mSG[mSG.Row, 25] = "3.00";
			}
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 52] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 52] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 52]) + 1.0);
			}
			mSG[mSG.Row, 58] = "A";
			mSG[mSG.Row, 50] = "N";
			mSG[mSG.Row, 71] = "N";
			mSG[mSG.Row, 72] = "N";
			mSG[mSG.Row, 73] = "N";
			mSG[mSG.Row, 81] = "N";
			MSG_IDTL_CLEAR();
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
		if (MsgClear)
		{
			return;
		}
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (mSG[mSG.Col] == 0)
			{
				TEXT_ENTRY.Text = "";
				if ((mSG.Col != 31) & (mSG.Col != 3) & (mSG.Col != 32))
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
			case 35:
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
			case 31:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 24:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 2;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
			case 32:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 15:
			case 50:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 30:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 12:
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 11;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 9:
			case 10:
			case 14:
			case 20:
			case 22:
			case 33:
			case 40:
			case 41:
			case 49:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 13:
			case 16:
			case 17:
			case 18:
			case 19:
			case 25:
			case 26:
			case 27:
			case 28:
			case 29:
			case 43:
			case 44:
			case 45:
			case 46:
			case 48:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 4:
			case 6:
			case 7:
			case 8:
			case 34:
			case 36:
			case 37:
			case 38:
			case 39:
			case 42:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 11:
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
		case 24:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 3:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if (Operators.CompareString(MSG[MSG.Row, 1], "", false) == 0)
			{
				if (Operators.CompareString(MSG[MSG.Row, 3], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
		case 15:
		case 30:
		case 31:
		case 32:
		case 35:
		case 50:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 5:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 12:
		case 23:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal();
			break;
		case 9:
		case 10:
		case 14:
		case 20:
		case 21:
		case 33:
		case 40:
		case 41:
		case 49:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 13:
		case 16:
		case 17:
		case 18:
		case 19:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 43:
		case 44:
		case 45:
		case 46:
		case 48:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 22:
			CommPassTotal();
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			break;
		case 7:
		case 36:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 4:
		case 6:
		case 8:
		case 11:
		case 34:
		case 37:
		case 38:
		case 39:
		case 42:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal();
			break;
		}
		mSG = null;
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
				case 9804:
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
							goto IL_0108;
						case 9:
							goto IL_0151;
						case 10:
						case 11:
							goto IL_0198;
						case 12:
							goto IL_01e3;
						case 13:
						case 14:
							goto IL_0236;
						case 15:
							goto IL_026c;
						case 16:
							goto IL_029f;
						case 17:
							goto IL_02fe;
						case 19:
							goto IL_037b;
						case 18:
						case 20:
						case 21:
						case 22:
							goto IL_03b1;
						case 23:
							goto IL_03e8;
						case 24:
							goto IL_041c;
						case 25:
							goto IL_047b;
						case 26:
						case 27:
						case 28:
							goto IL_04f8;
						case 29:
							goto IL_052f;
						case 30:
							goto IL_0563;
						case 31:
							goto IL_05c2;
						case 32:
						case 33:
						case 34:
							goto IL_063f;
						case 35:
							goto IL_067a;
						case 36:
						case 37:
							goto IL_06c3;
						case 38:
							goto IL_070e;
						case 39:
						case 40:
							goto IL_0757;
						case 41:
							goto IL_078e;
						case 42:
							goto IL_07c2;
						case 43:
							goto IL_0822;
						case 45:
							goto IL_08a0;
						case 44:
						case 46:
						case 47:
						case 48:
							goto IL_08d7;
						case 49:
							goto IL_090e;
						case 50:
							goto IL_0942;
						case 51:
							goto IL_09a2;
						case 52:
						case 53:
						case 54:
							goto IL_0a20;
						case 55:
							goto IL_0a57;
						case 56:
							goto IL_0a8b;
						case 57:
							goto IL_0aeb;
						case 58:
						case 59:
						case 60:
							goto IL_0b69;
						case 61:
							goto IL_0ba4;
						case 62:
						case 63:
							goto IL_0bee;
						case 64:
							goto IL_0c64;
						case 66:
							goto IL_0cad;
						case 68:
							goto IL_0d00;
						case 70:
							goto IL_0db7;
						case 72:
							goto IL_0e6e;
						case 65:
						case 67:
						case 69:
						case 71:
						case 73:
						case 74:
						case 75:
							goto IL_0f1a;
						case 76:
							goto IL_0f30;
						case 77:
							goto IL_0fb1;
						case 79:
							goto IL_0ffa;
						case 81:
							goto IL_104a;
						case 83:
							goto IL_10a4;
						case 85:
							goto IL_10fb;
						case 78:
						case 80:
						case 82:
						case 84:
						case 86:
						case 87:
						case 88:
						case 89:
							goto IL_114c;
						case 90:
							goto IL_1162;
						case 91:
							goto IL_118f;
						case 92:
							goto IL_11df;
						case 94:
							goto IL_1228;
						case 96:
							goto IL_127f;
						case 97:
							goto IL_129b;
						case 99:
							goto IL_12f0;
						case 102:
							goto IL_135c;
						case 104:
							goto IL_13ce;
						case 93:
						case 95:
						case 98:
						case 100:
						case 101:
						case 103:
						case 105:
						case 106:
						case 107:
						case 108:
						case 109:
							goto IL_1428;
						case 110:
							goto IL_1474;
						case 111:
						case 112:
							goto IL_14d2;
						case 113:
							goto IL_1500;
						case 115:
							goto IL_1549;
						case 117:
							goto IL_159c;
						case 118:
							goto IL_15b8;
						case 120:
							goto IL_1609;
						case 123:
							goto IL_1671;
						case 125:
							goto IL_16df;
						case 114:
						case 116:
						case 119:
						case 121:
						case 122:
						case 124:
						case 126:
						case 127:
						case 128:
							goto IL_1731;
						case 129:
							goto IL_177c;
						case 130:
							goto IL_1795;
						case 131:
							goto IL_17cc;
						case 132:
							goto IL_1828;
						case 133:
							goto IL_1855;
						case 134:
							goto IL_186f;
						case 135:
							goto IL_1889;
						case 136:
							goto IL_18bd;
						case 137:
							goto IL_1906;
						case 139:
							goto IL_1952;
						case 141:
							goto IL_19a8;
						case 143:
							goto IL_1a08;
						case 145:
							goto IL_1a65;
						case 138:
						case 140:
						case 142:
						case 144:
						case 146:
						case 147:
						case 148:
							goto IL_1aba;
						case 149:
							goto IL_1b0d;
						case 151:
							goto IL_1b59;
						case 153:
							goto IL_1bb3;
						case 154:
							goto IL_1bd2;
						case 156:
							goto IL_1c2a;
						case 159:
							goto IL_1c99;
						case 161:
							goto IL_1d0e;
						case 150:
						case 152:
						case 155:
						case 157:
						case 158:
						case 160:
						case 162:
						case 163:
							goto IL_1d65;
						case 164:
							goto IL_1db4;
						case 165:
						case 166:
						case 167:
						case 168:
						case 169:
							goto IL_1e11;
						case 170:
							goto IL_1e70;
						case 171:
							goto IL_1ea0;
						case 172:
							goto IL_1ed7;
						case 174:
							goto IL_1f27;
						case 175:
							goto IL_1f53;
						case 176:
							goto IL_1f9e;
						case 178:
							goto IL_1fef;
						case 179:
							goto IL_203d;
						case 173:
						case 177:
						case 180:
						case 181:
						case 182:
							goto IL_208a;
						case 183:
							goto IL_20dc;
						case 184:
							goto IL_2104;
						case 185:
							goto IL_2163;
						case 186:
							goto IL_217d;
						case 188:
							goto IL_219e;
						case 189:
							goto IL_2207;
						case 190:
							goto IL_2270;
						case 187:
						case 191:
						case 192:
						case 193:
							goto IL_228d;
						case 194:
							goto IL_2307;
						case 195:
							goto IL_2309;
						case 196:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 197:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_228d:
					num2 = 193;
					val[val.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 26]) + Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]), 0), "0.00");
					goto IL_2307;
					IL_2307:
					val = null;
					goto IL_2309;
					IL_2270:
					num2 = 190;
					val[val.Row, 26] = "";
					goto IL_228d;
					IL_2309:
					num2 = 195;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 6]) != Conversion.Val(val[val.Row, 61]))
					{
						goto IL_004a;
					}
					goto IL_0108;
					IL_004a:
					num2 = 4;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 6]), "0.000");
					goto IL_007c;
					IL_007c:
					num2 = 5;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_00c0;
					IL_00c0:
					num2 = 6;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 36])), "0.000");
					goto IL_0108;
					IL_0108:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 7]) != 0.0) & (Conversion.Val(val[val.Row, 6]) != 0.0))
					{
						goto IL_0151;
					}
					goto IL_0198;
					IL_0151:
					num2 = 9;
					val[val.Row, 8] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_0198;
					IL_0198:
					num2 = 11;
					if ((Conversion.Val(val[val.Row, 33]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_01e3;
					}
					goto IL_0236;
					IL_01e3:
					num2 = 12;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 33]) / 100.0), "0.000");
					goto IL_0236;
					IL_0236:
					num2 = 14;
					if (Conversion.Val(val[val.Row, 8]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_026c;
					}
					goto IL_03b1;
					IL_026c:
					num2 = 15;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.000");
					goto IL_029f;
					IL_029f:
					num2 = 16;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_02fe;
					}
					goto IL_037b;
					IL_02fe:
					num2 = 17;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10])) / 100.0), "0.000");
					goto IL_03b1;
					IL_037b:
					num2 = 19;
					val[val.Row, 11] = Strings.Format((object)Conversion.Val(val[val.Row, 8]), "0.000");
					goto IL_03b1;
					IL_03b1:
					num2 = 22;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_03e8;
					}
					goto IL_04f8;
					IL_03e8:
					num2 = 23;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.00");
					goto IL_041c;
					IL_041c:
					num2 = 24;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_047b;
					}
					goto IL_04f8;
					IL_047b:
					num2 = 25;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10])) / 100.0), "0.000");
					goto IL_04f8;
					IL_04f8:
					num2 = 28;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_052f;
					}
					goto IL_063f;
					IL_052f:
					num2 = 29;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.00");
					goto IL_0563;
					IL_0563:
					num2 = 30;
					if ((Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_05c2;
					}
					goto IL_063f;
					IL_05c2:
					num2 = 31;
					val[val.Row, 11] = Strings.Format((object)((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10])) / 100.0), "0.000");
					goto IL_063f;
					IL_063f:
					num2 = 34;
					if (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 10]) == 0.0)
					{
						goto IL_067a;
					}
					goto IL_06c3;
					IL_067a:
					num2 = 35;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])), "0.000");
					goto IL_06c3;
					IL_06c3:
					num2 = 37;
					if ((Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 6]) != 0.0))
					{
						goto IL_070e;
					}
					goto IL_0757;
					IL_070e:
					num2 = 38;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 36])), "0.000");
					goto IL_0757;
					IL_0757:
					num2 = 40;
					if (Conversion.Val(val[val.Row, 37]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_078e;
					}
					goto IL_08d7;
					IL_078e:
					num2 = 41;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.000");
					goto IL_07c2;
					IL_07c2:
					num2 = 42;
					if ((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_0822;
					}
					goto IL_08a0;
					IL_0822:
					num2 = 43;
					val[val.Row, 42] = Strings.Format((object)((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 39])) * (Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41])) / 100.0), "0.000");
					goto IL_08d7;
					IL_08a0:
					num2 = 45;
					val[val.Row, 42] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.000");
					goto IL_08d7;
					IL_08d7:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 40]) != Conversion.Val(val[val.Row, 68]))
					{
						goto IL_090e;
					}
					goto IL_0a20;
					IL_090e:
					num2 = 49;
					val[val.Row, 68] = Strings.Format((object)Conversion.Val(val[val.Row, 40]), "0.00");
					goto IL_0942;
					IL_0942:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_09a2;
					}
					goto IL_0a20;
					IL_09a2:
					num2 = 51;
					val[val.Row, 42] = Strings.Format((object)((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 39])) * (Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41])) / 100.0), "0.000");
					goto IL_0a20;
					IL_0a20:
					num2 = 54;
					if (Conversion.Val(val[val.Row, 41]) != Conversion.Val(val[val.Row, 69]))
					{
						goto IL_0a57;
					}
					goto IL_0b69;
					IL_0a57:
					num2 = 55;
					val[val.Row, 69] = Strings.Format((object)Conversion.Val(val[val.Row, 41]), "0.00");
					goto IL_0a8b;
					IL_0a8b:
					num2 = 56;
					if ((Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_0aeb;
					}
					goto IL_0b69;
					IL_0aeb:
					num2 = 57;
					val[val.Row, 42] = Strings.Format((object)((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 39])) * (Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41])) / 100.0), "0.000");
					goto IL_0b69;
					IL_0b69:
					num2 = 60;
					if (Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41]) == 0.0)
					{
						goto IL_0ba4;
					}
					goto IL_0bee;
					IL_0ba4:
					num2 = 61;
					val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 39])), "0.000");
					goto IL_0bee;
					IL_0bee:
					num2 = 63;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_0c64;
					}
					goto IL_0f1a;
					IL_0c64:
					num2 = 64;
					switch (val[val.Row, 53])
					{
					case "P":
						break;
					case "1":
						goto IL_0d00;
					case "K":
						goto IL_0db7;
					default:
						goto IL_0e6e;
					}
					goto IL_0cad;
					IL_0e6e:
					num2 = 72;
					val[val.Row, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
					{
						Operators.MultiplyObject(Interaction.IIf(val[11] > 0, (object)Conversion.Val(val[val.Row, 11]), (object)Conversion.Val(val[val.Row, 8])), (object)Conversion.Val(val[val.Row, 12])),
						0
					}, (string[])null, (Type[])null, (bool[])null)), "0.00");
					goto IL_0f1a;
					IL_0db7:
					num2 = 70;
					val[val.Row, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
					{
						Operators.MultiplyObject(Interaction.IIf(val[11] > 0, (object)Conversion.Val(val[val.Row, 11]), (object)Conversion.Val(val[val.Row, 8])), (object)(Conversion.Val(val[val.Row, 12]) / 1000.0)),
						0
					}, (string[])null, (Type[])null, (bool[])null)), "0.00");
					goto IL_0f1a;
					IL_0d00:
					num2 = 68;
					val[val.Row, 13] = Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
					{
						Operators.MultiplyObject(Interaction.IIf(val[11] > 0, (object)Conversion.Val(val[val.Row, 11]), (object)Conversion.Val(val[val.Row, 8])), (object)(Conversion.Val(val[val.Row, 12]) / 10.0)),
						0
					}, (string[])null, (Type[])null, (bool[])null)), "0.00");
					goto IL_0f1a;
					IL_0cad:
					num2 = 66;
					val[val.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 5]) * Conversion.Val(val[val.Row, 12]), 0), "0.00");
					goto IL_0f1a;
					IL_0f1a:
					num2 = 75;
					if (val.Col == 13)
					{
						goto IL_0f30;
					}
					goto IL_114c;
					IL_0f30:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 12]) == 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 6]) + Conversion.Val(val[val.Row, 5]) != 0.0))
					{
						goto IL_0fb1;
					}
					goto IL_114c;
					IL_0fb1:
					num2 = 77;
					switch (val[val.Row, 53])
					{
					case "P":
						break;
					case "1":
						goto IL_104a;
					case "K":
						goto IL_10a4;
					default:
						goto IL_10fb;
					}
					goto IL_0ffa;
					IL_10fb:
					num2 = 85;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 8]), 3), "0.000");
					goto IL_114c;
					IL_10a4:
					num2 = 83;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 8]) * 1000.0, 3), "0.000");
					goto IL_114c;
					IL_104a:
					num2 = 81;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 8]) * 10.0, 3), "0.000");
					goto IL_114c;
					IL_0ffa:
					num2 = 79;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_ENTRY.Text) / Conversion.Val(val[val.Row, 5]), 3), "0.000");
					goto IL_114c;
					IL_114c:
					num2 = 89;
					if (val.Col == 17)
					{
						goto IL_1162;
					}
					goto IL_1428;
					IL_1162:
					num2 = 90;
					if (Conversion.Val(val[val.Row, 17]) != 0.0)
					{
						goto IL_118f;
					}
					goto IL_1428;
					IL_118f:
					num2 = 91;
					if ((Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
					{
						goto IL_11df;
					}
					goto IL_1428;
					IL_11df:
					num2 = 92;
					switch (val[val.Row, 15])
					{
					case "P":
						break;
					case "N":
						goto IL_127f;
					case "K":
						goto IL_135c;
					default:
						goto IL_13ce;
					}
					goto IL_1228;
					IL_13ce:
					num2 = 104;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 6]), DC_Main.MsLbrRof), "0.00");
					goto IL_1428;
					IL_135c:
					num2 = 102;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1428;
					IL_127f:
					num2 = 96;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_129b;
					}
					goto IL_12f0;
					IL_129b:
					num2 = 97;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_1428;
					IL_12f0:
					num2 = 99;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])), DC_Main.MsLbrRof), "0.00");
					goto IL_1428;
					IL_1228:
					num2 = 94;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 5]), DC_Main.MsLbrRof), "0.00");
					goto IL_1428;
					IL_1428:
					num2 = 109;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_1474;
					}
					goto IL_14d2;
					IL_1474:
					num2 = 110;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 14]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_14d2;
					IL_14d2:
					num2 = 112;
					if (Conversion.Val(val[val.Row, 16]) != 0.0)
					{
						goto IL_1500;
					}
					goto IL_1731;
					IL_1500:
					num2 = 113;
					switch (val[val.Row, 15])
					{
					case "P":
						break;
					case "N":
						goto IL_159c;
					case "K":
						goto IL_1671;
					default:
						goto IL_16df;
					}
					goto IL_1549;
					IL_16df:
					num2 = 125;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 6]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1731;
					IL_1671:
					num2 = 123;
					val[val.Row, 17] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 16]) / 1000.0), 0), "0.00");
					goto IL_1731;
					IL_159c:
					num2 = 117;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_15b8;
					}
					goto IL_1609;
					IL_15b8:
					num2 = 118;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1731;
					IL_1609:
					num2 = 120;
					val[val.Row, 17] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1731;
					IL_1549:
					num2 = 115;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 5]) * Conversion.Val(val[val.Row, 16]), 0), "0.00");
					goto IL_1731;
					IL_1731:
					num2 = 128;
					val[val.Row, 46] = Strings.Format((object)(Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 45])), "0.0");
					goto IL_177c;
					IL_177c:
					num2 = 129;
					if (val.Col == 22)
					{
						goto IL_1795;
					}
					goto IL_1e11;
					IL_1795:
					num2 = 130;
					if (Conversion.Val(val[val.Row, 22]) != Conversion.Val(TEXT_ENTRY.Text))
					{
						goto IL_17cc;
					}
					goto IL_1e11;
					IL_17cc:
					num2 = 131;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 18]) - Conversion.Val(val[val.Row, 13])), "0.00");
					goto IL_1828;
					IL_1828:
					num2 = 132;
					if (Conversion.Val(val[val.Row, 17]) < 0.0)
					{
						goto IL_1855;
					}
					goto IL_1aba;
					IL_1855:
					num2 = 133;
					val[val.Row, 17] = "";
					goto IL_186f;
					IL_186f:
					num2 = 134;
					val[val.Row, 16] = "";
					goto IL_1889;
					IL_1889:
					num2 = 135;
					val[val.Row, 22] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_18bd;
					IL_18bd:
					num2 = 136;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_1906;
					IL_1906:
					num2 = 137;
					switch (val[val.Row, 53])
					{
					case "P":
						break;
					case "1":
						goto IL_19a8;
					case "K":
						goto IL_1a08;
					default:
						goto IL_1a65;
					}
					goto IL_1952;
					IL_1a65:
					num2 = 145;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) / Conversion.Val(val[val.Row, 8]), 3), "0.000");
					goto IL_1aba;
					IL_1a08:
					num2 = 143;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) / Conversion.Val(val[val.Row, 8]) * 1000.0, 3), "0.000");
					goto IL_1aba;
					IL_19a8:
					num2 = 141;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) / Conversion.Val(val[val.Row, 8]) * 10.0, 3), "0.000");
					goto IL_1aba;
					IL_1952:
					num2 = 139;
					val[val.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) / Conversion.Val(val[val.Row, 5]), 3), "0.000");
					goto IL_1aba;
					IL_1aba:
					num2 = 148;
					if ((Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
					{
						goto IL_1b0d;
					}
					goto IL_1e11;
					IL_1b0d:
					num2 = 149;
					switch (val[val.Row, 15])
					{
					case "P":
						break;
					case "N":
						goto IL_1bb3;
					case "K":
						goto IL_1c99;
					default:
						goto IL_1d0e;
					}
					goto IL_1b59;
					IL_1d0e:
					num2 = 161;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 6]), DC_Main.MsLbrRof), "0.00");
					goto IL_1d65;
					IL_1c99:
					num2 = 159;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1d65;
					IL_1bb3:
					num2 = 153;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1bd2;
					}
					goto IL_1c2a;
					IL_1bd2:
					num2 = 154;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_1d65;
					IL_1c2a:
					num2 = 156;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / (Conversion.Val(val[val.Row, 8]) + Conversion.Val(val[val.Row, 34])), DC_Main.MsLbrRof), "0.00");
					goto IL_1d65;
					IL_1b59:
					num2 = 151;
					val[val.Row, 16] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) / Conversion.Val(val[val.Row, 5]), DC_Main.MsLbrRof), "0.00");
					goto IL_1d65;
					IL_1d65:
					num2 = 163;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_1db4;
					}
					goto IL_1e11;
					IL_1db4:
					num2 = 164;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 16]) * 100.0 / Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_1e11;
					IL_1e11:
					num2 = 169;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 13])), "0.00");
					goto IL_1e70;
					IL_1e70:
					num2 = 170;
					if (Conversion.Val(val[val.Row, 19]) != 0.0)
					{
						goto IL_1ea0;
					}
					goto IL_1f27;
					IL_1ea0:
					num2 = 171;
					val[val.Row, 22] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_1ed7;
					IL_1ed7:
					num2 = 172;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) / Conversion.Val(val[val.Row, 5])), "0.000");
					goto IL_208a;
					IL_1f27:
					num2 = 174;
					if (Conversion.Val(val[val.Row, 6]) == 0.0)
					{
						goto IL_1f53;
					}
					goto IL_1fef;
					IL_1f53:
					num2 = 175;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_1f9e;
					IL_1f9e:
					num2 = 176;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) / Conversion.Val(val[val.Row, 5])), "0.000");
					goto IL_208a;
					IL_1fef:
					num2 = 178;
					if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_203d;
					}
					goto IL_208a;
					IL_203d:
					num2 = 179;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) / Conversion.Val(val[val.Row, 8])), "0.000");
					goto IL_208a;
					IL_208a:
					num2 = 182;
					if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 25]) != 0.0))
					{
						goto IL_20dc;
					}
					goto IL_228d;
					IL_20dc:
					num2 = 183;
					if (Operators.CompareString(tAcType.Text, "I", false) == 0)
					{
						goto IL_2104;
					}
					goto IL_219e;
					IL_2104:
					num2 = 184;
					val[val.Row, 26] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * Conversion.Val(val[val.Row, 25]) / 100.0, DC_Main.MsTaxRof), "0.00");
					goto IL_2163;
					IL_2163:
					num2 = 185;
					val[val.Row, 27] = "";
					goto IL_217d;
					IL_217d:
					num2 = 186;
					val[val.Row, 28] = "";
					goto IL_228d;
					IL_219e:
					num2 = 188;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 25]) / 2.0) / 100.0, DC_Main.MsTaxRof), "0.00");
					goto IL_2207;
					IL_2207:
					num2 = 189;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 22]) * (Conversion.Val(val[val.Row, 25]) / 2.0) / 100.0, DC_Main.MsTaxRof), "0.00");
					goto IL_2270;
					end_IL_0001_2:
					break;
				}
				num2 = 196;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 9804;
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
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cd: Invalid comparison between Unknown and I4
		//IL_08e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e4: Invalid comparison between Unknown and I4
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e4: Invalid comparison between Unknown and I4
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Invalid comparison between Unknown and I4
		//IL_090a: Unknown result type (might be due to invalid IL or missing references)
		//IL_090d: Invalid comparison between Unknown and I4
		//IL_095e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Invalid comparison between Unknown and I4
		//IL_09da: Unknown result type (might be due to invalid IL or missing references)
		//IL_09dd: Invalid comparison between Unknown and I4
		//IL_0a2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a31: Invalid comparison between Unknown and I4
		//IL_0a89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8c: Invalid comparison between Unknown and I4
		//IL_08d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_3418: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_122b: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG.Col == 22)
			{
				double num = Conversion.Val(mSG[mSG.Row, 22]);
				double num2 = Conversion.Val(mSG[mSG.Row, 25]);
				TEXT_ENTRY.Text = Strings.Format((object)Math.Round(num / (num2 + 100.0) * 100.0, 0), "0.00");
				mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				if (Conversion.Val(mSG[mSG.Row, 17]) != 0.0)
				{
					mSG[mSG.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 22]) - Conversion.Val(mSG[mSG.Row, 13]) - Conversion.Val(mSG[mSG.Row, 18]), 0), "0.00");
					if ((Operators.CompareString(mSG[mSG.Row, 15], "P", false) == 0) & (Conversion.Val(mSG[mSG.Row, 5]) != 0.0))
					{
						mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / Conversion.Val(mSG[mSG.Row, 5])), "0.00");
					}
					else if ((Operators.CompareString(mSG[mSG.Row, 15], "N", false) == 0) & (Conversion.Val(mSG[mSG.Row, 8]) != 0.0))
					{
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / Conversion.Val(mSG[mSG.Row, 8])), "0.00");
						}
						else
						{
							mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / (Conversion.Val(mSG[mSG.Row, 8]) + Conversion.Val(mSG[mSG.Row, 34]))), "0.00");
						}
					}
					else if ((Operators.CompareString(mSG[mSG.Row, 15], "K", false) == 0) & (Conversion.Val(mSG[mSG.Row, 6]) != 0.0))
					{
						mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / Conversion.Val(mSG[mSG.Row, 6]) * 1000.0), "0.00");
					}
					else if ((Operators.CompareString(mSG[mSG.Row, 15], "G", false) == 0) & (Conversion.Val(mSG[mSG.Row, 6]) != 0.0))
					{
						mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / Conversion.Val(mSG[mSG.Row, 6])), "0.00");
					}
					else
					{
						mSG[mSG.Row, 16] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 17]) / (Conversion.Val(mSG[mSG.Row, 8]) + Conversion.Val(mSG[mSG.Row, 34]))), "0.00");
					}
				}
				else
				{
					mSG[mSG.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 22]) - Conversion.Val(mSG[mSG.Row, 18]), 0), "0.00");
					if ((Conversion.Val(mSG[mSG.Row, 13]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 6]) + Conversion.Val(mSG[mSG.Row, 5]) != 0.0))
					{
						switch (mSG[mSG.Row, 53])
						{
						case "P":
							mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 13]) / Conversion.Val(mSG[mSG.Row, 5]), 3), "0.000");
							break;
						case "1":
							mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 13]) / Conversion.Val(mSG[mSG.Row, 8]) * 10.0, 3), "0.000");
							break;
						case "K":
							mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 13]) / Conversion.Val(mSG[mSG.Row, 8]) * 1000.0, 3), "0.000");
							break;
						default:
							mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 13]) / Conversion.Val(mSG[mSG.Row, 8]), 3), "0.000");
							break;
						}
					}
				}
				CommPassTotal();
				return;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num3 = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 52]));
					List<DataRow> list = new List<DataRow>();
					int num4 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num4)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][20])) == Conversion.Val(mSG[mSG.Row, 52]))
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
							mSG[mSG.Row, 52] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 52] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 52]) + 1.0);
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
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 47]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 47]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 47]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 47]))) ?? ""))), (object)"  AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" AND C.EMP_ISU <> 'Y'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
							}
							else
							{
								DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
							}
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
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 57] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 3] = DC_Main.ColValue[3];
									mSG[mSG.Row, 6] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 8] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 47] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 47] = "";
									mSG[mSG.Row, 1] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
						int num7 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num7)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						if (DC_Main.Rshlp.Rows.Count > 1)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC"));
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
								mSG[mSG.Row, 57] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 3] = DC_Main.ColValue[3];
								mSG[mSG.Row, 6] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 8] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 47] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 47]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 32] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG[DC_Main.i, 5] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 15] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							if ((Conversion.Val(mSG[mSG.Row, 12]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) == 0.0) & (DC_Main.RtView != null))
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
								DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								double num8 = default(double);
								if (dataTable2.Rows.Count > 0)
								{
									num8 = Conversions.ToDouble(dataTable2.Rows[0]["GR_RATE"]);
								}
								else
								{
									DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
									if (DC_Main.RtView.Count > 0)
									{
										num8 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
									}
								}
								if (num8 > 0.0)
								{
									if (Operators.CompareString(mSG[DC_Main.i, 53], "G", false) == 0)
									{
										mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num8 / 10.0, 2), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 53], "K", false) == 0)
									{
										mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num8 / 10.0, 0), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 53], "1", false) == 0)
									{
										mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num8, 0), "0.00");
									}
								}
								else
								{
									mSG[mSG.Row, 12] = "";
								}
							}
							mSG[DC_Main.i, 35] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
							mSG[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[mSG.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[mSG.Row, 74] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[mSG.Row, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[mSG.Row, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[mSG.Row, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[mSG.Row, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[mSG.Row, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[mSG.Row, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG[mSG.Row, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[mSG.Row, 1]), (object)"' AND A.VCH_SRNO = "), (object)mSG[mSG.Row, 47]), (object)" "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[20] = Conversion.Val(MSG[mSG.Row, 52]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[7] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[10] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						break;
					}
					case 2:
					{
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "'";
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
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[1];
									mSG[mSG.Row, 57] = DC_Main.ColValue[0];
									mSG[mSG.Row, 56] = DC_Main.ColValue[3];
									mSG[mSG.Row, 54] = DC_Main.ColValue[4];
									mSG[mSG.Row, 55] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VS023NPBU", false) != 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""), (object)"HM", false))
						{
							mSG[mSG.Row, 24] = "13";
							mSG[mSG.Row, 25] = "18.00";
						}
						if (!((Conversion.Val(mSG[mSG.Row, 12]) == 0.0) & (Conversion.Val(mSG[mSG.Row, 19]) == 0.0) & (DC_Main.RtView != null)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						double num6 = default(double);
						if (dataTable.Rows.Count > 0)
						{
							num6 = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
						}
						else
						{
							DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Tbl.Rows[0]["GR_CODE"]), (object)"'"));
							if (DC_Main.RtView.Count > 0)
							{
								num6 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
							}
						}
						if (num6 > 0.0)
						{
							if (Operators.CompareString(mSG[mSG.Row, 53], "G", false) == 0)
							{
								mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num6 / 10.0, 2), "0.00");
							}
							else if (Operators.CompareString(mSG[mSG.Row, 53], "K", false) == 0)
							{
								mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num6 / 10.0, 0), "0.00");
							}
							else if (Operators.CompareString(mSG[mSG.Row, 53], "1", false) == 0)
							{
								mSG[mSG.Row, 12] = Strings.Format((object)Math.Round(num6, 0), "0.00");
							}
						}
						else
						{
							mSG[mSG.Row, 12] = "";
						}
						break;
					}
					case 24:
					{
						DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + TEXT_ENTRY.Text + "'  ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcR, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE >= '10' ORDER BY A.TAX_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[4];
							DC_Main.ColWidth[0] = 250.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[2], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[2];
									mSG[mSG.Row, 24] = DC_Main.ColValue[2];
									mSG[mSG.Row, 25] = Strings.Format((object)DC_Main.ColValue[1], "0.00");
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						DataView dataView = new DataView(DC_Main.Rshlp);
						mSG[mSG.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
						dataView.RowFilter = "SR_NO = 0";
						mSG[mSG.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(dataView[0]["TAX_PRC"]), "0.00");
						CommPassTotal();
						break;
					}
					case 32:
						mSG[mSG.Row, 32] = TEXT_ENTRY.Text;
						((Control)TEXT_ENTRY).Visible = false;
						((Control)tItRemark).Focus();
						return;
					case 31:
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
									mSG[mSG.Row, 31] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 6:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 53], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 29:
					case 30:
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

	private void TR_SL_EBILL_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0f66: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f75: Expected O, but got Unknown
		//IL_0f9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa9: Expected O, but got Unknown
		//IL_0fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fdd: Expected O, but got Unknown
		//IL_101c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Unknown result type (might be due to invalid IL or missing references)
		//IL_102b: Expected O, but got Unknown
		//IL_1045: Unknown result type (might be due to invalid IL or missing references)
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1054: Expected O, but got Unknown
		//IL_106e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1073: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Expected O, but got Unknown
		//IL_1097: Unknown result type (might be due to invalid IL or missing references)
		//IL_109c: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a6: Expected O, but got Unknown
		//IL_10ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d5: Expected O, but got Unknown
		//IL_11b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c5: Expected O, but got Unknown
		//IL_124d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1252: Unknown result type (might be due to invalid IL or missing references)
		//IL_125c: Expected O, but got Unknown
		//IL_12f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1300: Expected O, but got Unknown
		//IL_138a: Unknown result type (might be due to invalid IL or missing references)
		//IL_138f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1399: Expected O, but got Unknown
		//IL_13be: Unknown result type (might be due to invalid IL or missing references)
		//IL_13c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_13cd: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)pnlEInvoice).Controls)
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
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj23 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj24 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj26 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj27 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj28 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj29 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj30 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj32 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj33 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj34 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj36 = lblBook;
				object? obj37 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj36).ForeColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj38 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj39 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj41 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj42 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj43 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj44 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj45 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj46 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj47 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj48 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj49 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj51 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue3, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
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
		mAckDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		OldValTot = 0.0;
		NewValTot = 0.0;
		RecAdjAmt = 0.0;
		VpAdjAmt = 0.0;
		AcTcsAmt = 0.0;
		OldTcsPrc = 0.0;
		OldNetAmt = 0.0;
		UsUPdate = "N";
		UsDelete = "N";
		CompnyAndParyDetail = false;
		CoStateCode = "";
		tAcType.Text = "L";
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		OrdGold = 0.0;
		OrdSilver = 0.0;
		TotDrFine = 0.0;
		OldAcCode = "";
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
		BtnEExit_Click(btnEExit, new EventArgs());
		DtIdtl.Clear();
		DtIdtl.Reset();
		FilRow = 0;
		checked
		{
			int num = MSG_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
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
				DC_Main.RsQry = "SELECT AC_NAME,AC_GST_TYPE FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
					tAcType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_GST_TYPE"], (object)""));
				}
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00"));
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				OldTcsPrc = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000"));
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				if (Operators.CompareString(DC_Main.MsSlTdsTax, "Y", false) == 0)
				{
					MSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TDS_CODE"], (object)""));
					MSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_PRC"]), "0.000");
					MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]), "0.00");
					DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[5, 4] + "'";
					DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsAc.Rows.Count > 0)
					{
						MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
					}
				}
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[10, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				MSG2_TOTAL[11, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KASAR_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[12, 3] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[9, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[9, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[9, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[9, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[10, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[10, 4] + "'";
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
				tVchIrnNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["IRN_NO"], (object)""));
				tAckNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ACK_NO"], (object)""));
				mAckDt.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
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
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 32] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAXABL_RATE"])), "0.000");
					mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAX_CODE"], (object)""));
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_IGST_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_CGST_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_SGST_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["GRAND_TOTAL"])), "0.00");
					mSG[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 74] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 60] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 58] = "E";
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
				int num2 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
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
					dr[20] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[7] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[10] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[19] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				if (Operators.CompareString(MSG[1, 1], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[1, 1] + "_" + MSG[1, 47];
					DC_Main.MsImageType = "TagImage";
				}
				else
				{
					DC_Main.MsImageNo = MSG[1, 3] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 17]);
				NewValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 17]);
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

	private void TR_SL_EBILL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SL_EBILL_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_2b95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b71: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (DC_Main.MsCashLimit > 0.0 && Operators.CompareString(tAcCode.Text, "00020", false) != 0)
		{
			DC_Main.LedrCash(tAcCode.Text, DC_Main.MCo_Book, tVchNo.Text);
			if (Conversion.Val(MSG2_TOTAL[8, 3]) + DC_Main.AcCash > DC_Main.MsCashLimit)
			{
				Interaction.MsgBox((object)("Cash Recieved Limit Amount = " + Conversions.ToString(DC_Main.MsCashLimit) + " \r\nOld Ledr Value Is " + Conversions.ToString(DC_Main.AcCash) + " \r\nAnd Total Cash Amount Is " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[8, 3]) + DC_Main.AcCash) + " You Can Not Receive More Then Cash Limit ..."), (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)tEmpCode).Focus();
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[9, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[9, 4], "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[10, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[10, 4], "", false) == 0))
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
				if ((Conversion.Val(MSG_TOT[0, 19]) != 0.0) | (Conversion.Val(MSG_TOT[0, 5]) + Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG2_TOTAL[11, 3]) != 0.0))
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
					dataRow2["DISC_PRC"] = 0;
					dataRow2["DISC_AMT"] = 0;
					dataRow2["TAX_CODE"] = "";
					dataRow2["TAX_PRC"] = 0;
					dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]) + Conversion.Val(MSG2_TOTAL[2, 3]) + Conversion.Val(MSG2_TOTAL[3, 3]);
					dataRow2["IGST_TAX"] = Conversion.Val(MSG2_TOTAL[1, 3]);
					dataRow2["CGST_TAX"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow2["SGST_TAX"] = Conversion.Val(MSG2_TOTAL[3, 3]);
					dataRow2["TCS_CODE"] = MSG2_TOTAL[4, 4];
					dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
					dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
					dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
					dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 17]);
					dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 18]);
					dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
					dataRow2["TDS_CODE"] = MSG2_TOTAL[7, 4];
					dataRow2["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[7, 2]);
					dataRow2["TDS_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
					dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow2["CARD_COM_AMT"] = Conversion.Val(MSG2_TOTAL[10, 2]);
					dataRow2["ADV_AMT"] = 0;
					dataRow2["CRNT_ADJ_AMT"] = 0;
					dataRow2["OLD_GL_AMT"] = 0;
					dataRow2["OLD_SL_AMT"] = 0;
					dataRow2["SCHM_AMT"] = 0;
					dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow2["CASH_PAID"] = 0;
					dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[11, 3]);
					dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[12, 3]);
					dataRow2["OLD_GL"] = 0;
					dataRow2["OLD_SL"] = 0;
					dataRow2["CARD_AC"] = MSG2_TOTAL[10, 4];
					dataRow2["BANK_AC"] = MSG2_TOTAL[9, 4];
					dataRow2["CHQ_NO"] = MSG2_TOTAL[9, 2];
					dataRow2["SCHM_AC"] = 0;
					dataRow2["POINT_VAL"] = 0;
					dataRow2["BANK_NAME"] = "";
					dataRow2["CARD_ADJ"] = 0;
					dataRow2["CR_DAYS"] = 0;
					dataRow2["AC_GST_TYPE"] = tAcType.Text;
					dataRow2["HM_AMT"] = 0;
					dataRow2["HM_TAX_CODE"] = "";
					dataRow2["HM_TAX_PRC"] = 0;
					dataRow2["HM_TAX_AMT"] = 0;
					dataRow2["RTN_TOT_AMT"] = 0;
					dataRow2["RTN_CHQ_AMT"] = 0;
					dataRow2["RTN_CARD_AMT"] = 0;
					dataRow2["RTN_CASH_AMT"] = 0;
					dataRow2["RTN_KASAR_AMT"] = 0;
					dataRow2["RTN_BILL_OS"] = 0;
					dataRow2["ISU_NO"] = "";
					dataRow2["ISU_LC_CODE"] = "";
					dataRow2["ISU_YRCD"] = "";
					dataRow2["ISU_DBCD"] = "";
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
					if (Operators.CompareString(DC_Main.MCo_Book, "025", false) == 0)
					{
						dataRow2["IRN_NO"] = tIrnNo.Text;
					}
					else
					{
						dataRow2["IRN_NO"] = "N";
					}
					dataRow2["ACK_NO"] = tAckNo.Text;
					dataRow2["ACK_DATE"] = mVchDate.Text;
					dataRow2["MOB_ENTRY_SAVE"] = "Y";
					dataRow2["RATE_UNFIX"] = "N";
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
					if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 19]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 6]) + Conversion.Val(mSG[DC_Main.i, 17]) + Conversion.Val(mSG[DC_Main.i, 18]) + Conversion.Val(mSG[DC_Main.i, 22]) != 0.0))
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
						dataRow3["ENTRY_TYPE"] = "O";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 52]);
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
						dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 70];
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
						{
							dataRow3["TAG_NO"] = "N";
						}
						else
						{
							dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
						}
						dataRow3["TBL_CODE"] = mSG[DC_Main.i, 31];
						dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 3];
						dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 32];
						dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 4]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 5]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 6]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 34]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 9]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 10]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 11]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 15];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 17]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 18]);
						dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 22]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 22]);
						dataRow3["TAXABL_RATE"] = Conversion.Val(mSG[DC_Main.i, 23]);
						dataRow3["TAX_CODE"] = mSG[DC_Main.i, 24];
						dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 25]);
						dataRow3["ITM_IGST_AMT"] = Conversion.Val(mSG[DC_Main.i, 26]);
						dataRow3["ITM_CGST_AMT"] = Conversion.Val(mSG[DC_Main.i, 27]);
						dataRow3["ITM_SGST_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
						dataRow3["IT_TAX_AMT"] = Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 27]) + Conversion.Val(mSG[DC_Main.i, 28]);
						dataRow3["GRAND_TOTAL"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow3["DISC_PRC"] = 0;
						dataRow3["DISC_AMT"] = 0;
						dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 37]);
						dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 40]);
						dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 41]);
						dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 42]);
						dataRow3["KR_NAME"] = mSG[DC_Main.i, 35];
						dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 53];
						dataRow3["IT_TYPE"] = mSG[DC_Main.i, 54];
						dataRow3["PR_CODE"] = mSG[DC_Main.i, 56];
						dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 47]);
						dataRow3["HM_ID"] = mSG[DC_Main.i, 30];
						dataRow3["HM_ID2"] = mSG[DC_Main.i, 74];
						dataRow3["HM_ID3"] = mSG[DC_Main.i, 75];
						dataRow3["HM_ID4"] = mSG[DC_Main.i, 76];
						dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 77]);
						dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 78]);
						dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 79]);
						dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 80]);
						dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 81];
						dataRow3["ORD_TAG_STK_ADD"] = "N";
						dataRow3["EMP_CODE"] = tEmpCode.Text;
						dataRow3["MAIN_USER"] = MainUser;
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Module_Save.MsInsertDataSave(Module_Save.SlTran);
				DataRow dataRow4 = RsIdtl.NewRow();
				int num2 = 0;
				int num3 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num3; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15])) != 0.0)
					{
						int num4 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])));
						int num5 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num5)
						{
							if ((double)num4 == Conversion.Val(MSG[DC_Main.M, 52]))
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
						dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["AC_CODE"] = tAcCode.Text;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "O";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
						if (Operators.CompareString(MSG[num2, 1], "", false) == 0)
						{
							dataRow4["TAG_NO"] = "N";
						}
						else
						{
							dataRow4["TAG_NO"] = MSG[num2, 1];
						}
						dataRow4["VCH_SRNO"] = Conversion.Val(MSG[num2, 47]);
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]);
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
						dataRow4["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl = null;
				}
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Ledr.EInvoice_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Rojmel.EInvoice_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.EInvoice_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Tax.EInvoice_GST(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.SlTran);
				Ac_Stock.Dm_Sale_eInv_Detl(DC_Main.MCo_Book, tVchNo.Text);
				Module_Save.SlTran.Commit();
				Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
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
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.SlTran.Rollback();
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
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Invalid comparison between Unknown and I4
		//IL_06fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Strings.Len(tIrnNo.Text) > 10)
		{
			Interaction.MsgBox((object)"You Cant Delete This Voucher Because Irn No Is Genrate.....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,0,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',0  FROM  (SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SL_EBILL_KeyDown(object sender, KeyEventArgs e)
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
				MSG2_TOTAL.Row = 8;
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
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
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\SalesBillA4Gst.RPT";
		Cr.SelectionFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + CurPrnVch + "'";
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

	private void TR_SL_EBILL_Activated(object sender, EventArgs e)
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
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_NO AS RefNoL,A.IRN_NO As IrnNoL,A.MAIN_USER As UserL,format(NET_AMT,'0.00') AS NetAmtR,format(TAX_AMT,'0.00') AS TaxAmtR,format(TOT_AMT,'0.00') AS TotAmtR,format(BILL_OS,'0.00') AS OsAmtR FROM SL_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[11];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 80.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 100.0;
		DC_Main.ColWidth[8] = 100.0;
		DC_Main.ColWidth[9] = 0.0;
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
		//IL_09e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ef: Expected O, but got Unknown
		//IL_0708: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Expected O, but got Unknown
		//IL_08a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ad: Expected O, but got Unknown
		if (MsgClear || MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 57] + " : It Name";
		tItRemark.Text = MSG[MSG.Row, 70];
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 52]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])))
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
					MSG_IDTL[num, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
					MSG_IDTL[num, 9] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][9], (object)""));
					MSG_IDTL[num, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
					MSG_IDTL[num, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
					MSG_IDTL[num, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
					MSG_IDTL[num, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
					MSG_IDTL[num, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
					MSG_IDTL[num, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
					MSG_IDTL[num, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num, 18] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][18], (object)""));
					MSG_IDTL[num, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
					MSG_IDTL[num, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
					MSG_IDTL.Rows += 1;
					num++;
				}
			}
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 81], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 3], "", false) != 0))
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 81];
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
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 81] + "' AND IMAGE_TYPE = 'D'";
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
				DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 47];
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
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 47]))) ?? "";
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
			MSG_IDTL[num, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 52]));
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

	private void TR_SL_EBILL_Closed(object sender, EventArgs e)
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
		tAcType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
		tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcType.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
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
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
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
		mSG2_TOTAL.Rows = 13;
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
				switch (DC_Main.i)
				{
				case 0:
				case 6:
				case 12:
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
				case 7:
				case 8:
				case 9:
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
			while (DC_Main.i <= 12);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Igst Amt : ";
			mSG2_TOTAL[2, 0] = "Cgst Amt : ";
			mSG2_TOTAL[3, 0] = "Sgst Amt : ";
			mSG2_TOTAL[4, 0] = "Tcs Amt : ";
			mSG2_TOTAL[5, 0] = "Rof Amt : ";
			mSG2_TOTAL[6, 0] = "Total Amt : ";
			mSG2_TOTAL[7, 0] = "Tds Amt : ";
			mSG2_TOTAL[8, 0] = "Cash Amt : ";
			mSG2_TOTAL[9, 0] = "Cheque Amt : ";
			mSG2_TOTAL[10, 0] = "Card Amt : ";
			mSG2_TOTAL[11, 0] = "Ksr Amt : ";
			mSG2_TOTAL[12, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 12))
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 12) | (mSG2_TOTAL.Row == 1))
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
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 12) | (mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 3))
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
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0562: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f6: Unknown result type (might be due to invalid IL or missing references)
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
					if (mSG2_TOTAL.Row == 4)
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
										mSG2_TOTAL[4, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										OldTcsPrc = 111.0;
										mSG2_TOTAL[4, 4] = DC_Main.ColValue[2];
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
									mSG2_TOTAL.Row = 9;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 9;
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
							mSG2_TOTAL.Row = 9;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (mSG2_TOTAL.Row == 7)
					{
						if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND SR_NO = 0 AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE IN ('25','00') AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
										mSG2_TOTAL[7, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.000");
										OldTcsPrc = 111.0;
										mSG2_TOTAL[7, 4] = DC_Main.ColValue[2];
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										mSG2_TOTAL[7, 1] = "";
										mSG2_TOTAL[7, 2] = "";
										mSG2_TOTAL[7, 3] = "";
										mSG2_TOTAL[7, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 9;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 9;
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
							mSG2_TOTAL.Row = 9;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (!((mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 10)) || Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
					{
						break;
					}
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
					break;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 7:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row = 9;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 8:
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
					case 11:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
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
		mSG2_TOTAL[0, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 22]), "0.00");
		mSG2_TOTAL[1, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 26]), "0.00");
		mSG2_TOTAL[2, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 27]), "0.00");
		mSG2_TOTAL[3, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 28]), "0.00");
		if (OldNetAmt != Conversion.Val(MSG_TOT[0, 22]))
		{
			OldNetAmt = Conversion.Val(MSG_TOT[0, 22]);
			OldTcsPrc = 111.0;
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			if (AcTcsAmt + (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3])) - Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) > 5000000.0)
			{
				if ((OldTcsPrc != Conversion.Val(MSG2_TOTAL[4, 2])) & (Operators.CompareString(MSG2_TOTAL[4, 4], "00", false) != 0))
				{
					DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '20'";
					DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.RsTax.Rows.Count > 0)
					{
						TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
						MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
						AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
						double num = DC_Main.Fnv(ref Value);
						dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						mSG2_TOTAL2[4, 2] = Strings.Format((object)num, "0.000");
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						OldTcsPrc = Conversions.ToDouble(Strings.Format((object)num2, "0.000"));
						MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
						double num3 = 5000000.0 - AcTcsAmt;
						double num4 = 0.0;
						num4 = Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]) - num3;
						if (num3 > 0.0)
						{
							mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(num4 * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
						}
						else
						{
							mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
						}
					}
				}
				else if (Operators.CompareString(MSG2_TOTAL[4, 4], "00", false) == 0)
				{
					MSG2_TOTAL[4, 3] = "";
				}
			}
		}
		else if (OldTcsPrc != Conversion.Val(MSG2_TOTAL[4, 2]))
		{
			OldTcsPrc = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[4, 2]), "0.000"));
			if ((Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
			{
				mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
			}
			else
			{
				mSG2_TOTAL[4, 3] = "";
			}
		}
		mSG2_TOTAL[6, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(mSG2_TOTAL[4, 3])), "0.00");
		mSG2_TOTAL[5, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - (Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]))), "0.00");
		if ((Conversion.Val(mSG2_TOTAL[7, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0))
		{
			mSG2_TOTAL[7, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) * Conversion.Val(mSG2_TOTAL[7, 2]) / 100.0, 0), "0.00");
		}
		else
		{
			mSG2_TOTAL[7, 3] = "";
		}
		if (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)
		{
			mSG2_TOTAL[12, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]) - Conversion.Val(mSG2_TOTAL[10, 3]) - Conversion.Val(mSG2_TOTAL[11, 3])), "0.00");
		}
		if (CustOpAmt > 0.0)
		{
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[12, 3]);
			}
			else
			{
				CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[12, 3]);
			}
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = 0.0 - (Math.Abs(CustOpAmt) + Conversion.Val(mSG2_TOTAL[12, 3]));
		}
		else
		{
			CustClAmt = 0.0 - Conversion.Val(mSG2_TOTAL[12, 3]);
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

	private void TBillNo_TextChanged(object sender, EventArgs e)
	{
	}

	private void tBillNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_026f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Invalid comparison between Unknown and I4
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112 && Operators.CompareString(EntryMode, "E", false) == 0 && ((Operators.CompareString(FormMainBook, "E INVOICE", false) == 0) | (Operators.CompareString(FormMainBook, "E CRNT", false) == 0)))
		{
			DC_Main.RsQry = "SELECT * FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				tIrnNo.Text = "";
				tTokan.Text = File.ReadAllText(Application.StartupPath + "\\AuthToken.txt");
				tBoxResponce.Text = File.ReadAllText(Application.StartupPath + "\\GenIRN.txt");
				edataImport();
				if (CompnyAndParyDetail)
				{
					JsonGen();
					string text = "DcJson";
					tBoxResponce.Text = File.ReadAllText(DC_Main.MSImageSavePath + "\\" + text + ".Json");
					mAckDt.Text = mVchDate.Text;
					((Control)pnlEInvoice).Visible = true;
					GetAuthToken();
				}
			}
			else
			{
				tTokan.Text = File.ReadAllText(Application.StartupPath + "\\AuthToken.txt");
				Interaction.MsgBox((object)"No Need to Generate eInvoice its Alrady Exciest ....", (MsgBoxStyle)0, (object)null);
				tIrnNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IRN_NO"], (object)""));
				tAckNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ACK_NO"], (object)""));
				((Control)pnlEInvoice).Visible = true;
			}
		}
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

	private void BtnEExit_Click(object sender, EventArgs e)
	{
		tTokan.Text = "";
		TxtBoxError.Text = "";
		tBoxResponce.Text = "";
		tIrnNo.Text = "";
		tAckNo.Text = "";
		PicEQr.Image = null;
		((Control)pnlEInvoice).Visible = false;
	}

	private void BtnePrint_Click(object sender, EventArgs e)
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "UPDATE SL_DATA SET IRN_NO = '" + tIrnNo.Text + "',ACK_NO = '" + tAckNo.Text + "',ACK_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' FROM SL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
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
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DD017NSDD", false) == 0)
		{
			Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\EInvoice.RPT";
		Cr.SelectionFormula = "{SL_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_DATA.VCH_NO} = '" + tVchNo.Text + "'";
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

	private void tItRemark_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 5;
			MSG[MSG.Row, 70] = tItRemark.Text;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tVchDesc_TextChanged(object sender, EventArgs e)
	{
	}

	private void JsonGen()
	{
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		DcClass dcClass = new DcClass();
		DC_Main.RsQry = "SELECT * FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				ASPID = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_ID"]);
				ASPPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_PWD"]);
				GSTIN = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_GST_NO"]);
				eInvUserId = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_USER"]);
				eInvPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_PWD"]);
				eCoLegalName = Conversions.ToString(DC_Main.Tbl.Rows[0]["CO_LEGAL_NAME"]);
				DC_Main.RsQry = "SELECT B.BOOK_SR_NAME,VCH_NO,A.EMP_CODE,TOT_AMT,VCH_DATE FROM SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_SR_NAME"], (object)"/"), DC_Main.Tbl.Rows[0]["VCH_NO"]));
					if (Operators.CompareString(FormMainBook, "E CRNT", false) == 0)
					{
						dcClass.DocDtls.Typ = "CRN";
					}
					else
					{
						dcClass.DocDtls.Typ = "INV";
					}
					dcClass.DocDtls.No = text;
					dcClass.DocDtls.Dt = Convert.ToDateTime(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["VCH_DATE"])).ToShortDateString();
				}
				DC_Main.RsQry = "SELECT CO_GST_NO,CO_NAME,CO_ADD1,CO_ADD2,CO_CITY,CO_PIN,CO_STATE_CODE,CO_MOBILE,CO_MAIL FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					dcClass.SellerDtls.Gstin = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_GST_NO"]));
					dcClass.SellerDtls.LglNm = Conversions.ToString(Interaction.IIf(Operators.CompareString(eCoLegalName, "", false) != 0, (object)Convert.ToString(eCoLegalName), (object)Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_NAME"]))));
					dcClass.SellerDtls.TrdNm = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_NAME"]));
					dcClass.SellerDtls.Addr1 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_ADD1"]));
					dcClass.SellerDtls.Loc = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_CITY"]));
					dcClass.SellerDtls.Pin = Conversions.ToInteger(Convert.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_PIN"], (object)"")));
					dcClass.SellerDtls.Stcd = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_STATE_CODE"]));
				}
				DC_Main.RsQry = "SELECT A.AC_GSTNO, A.AC_NAME, A.AC_ADD1, A.AC_ADD2, A.AC_CITY, A.AC_PIN, B.STATE_CODE, A.AC_MOBILE, A.AC_EMAIL FROM AC_MAST AS A LEFT JOIN STATE_MAST AS B ON A.AC_STATE = B.STATE_NAME WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					dcClass.BuyerDtls.Gstin = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["AC_GSTNO"]));
					dcClass.BuyerDtls.LglNm = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["AC_NAME"]));
					dcClass.BuyerDtls.TrdNm = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["AC_NAME"]));
					dcClass.BuyerDtls.Pos = Convert.ToString(Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[0]["AC_GSTNO"]), 1, 2));
					dcClass.BuyerDtls.Addr1 = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["AC_ADD1"]));
					dcClass.BuyerDtls.Loc = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["AC_CITY"]));
					ClsBuyerDtls buyerDtls = dcClass.BuyerDtls;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["AC_PIN"]);
					double value = DC_Main.Fnv(ref Value);
					dataRow["AC_PIN"] = RuntimeHelpers.GetObjectValue(Value);
					buyerDtls.Pin = Convert.ToInt32(value);
					dcClass.BuyerDtls.Stcd = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["STATE_CODE"]));
				}
				if (dataTable.Rows.Count > 0)
				{
					dcClass.DispDtls.Nm = Conversions.ToString(Interaction.IIf(Operators.CompareString(eCoLegalName, "", false) != 0, (object)Convert.ToString(eCoLegalName), (object)Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_NAME"]))));
					dcClass.DispDtls.Addr1 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_ADD1"]));
					dcClass.DispDtls.Loc = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_CITY"]));
					ClsDispDtls dispDtls = dcClass.DispDtls;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["CO_PIN"]);
					double value2 = DC_Main.Fnv(ref Value);
					dataRow["CO_PIN"] = RuntimeHelpers.GetObjectValue(Value);
					dispDtls.Pin = Convert.ToInt32(value2);
					dcClass.DispDtls.Stcd = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_STATE_CODE"]));
				}
				if (dataTable.Rows.Count > 0)
				{
					dcClass.ShipDtls.Gstin = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_GST_NO"]));
					dcClass.ShipDtls.LglNm = Conversions.ToString(Interaction.IIf(Operators.CompareString(eCoLegalName, "", false) != 0, (object)Convert.ToString(eCoLegalName), (object)Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_NAME"]))));
					dcClass.ShipDtls.TrdNm = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_NAME"]));
					dcClass.ShipDtls.Addr1 = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_ADD1"]));
					dcClass.ShipDtls.Loc = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_CITY"]));
					ClsShipDtls shipDtls = dcClass.ShipDtls;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["CO_PIN"]);
					double value3 = DC_Main.Fnv(ref Value);
					dataRow["CO_PIN"] = RuntimeHelpers.GetObjectValue(Value);
					shipDtls.Pin = Convert.ToInt32(value3);
					dcClass.ShipDtls.Stcd = Convert.ToString(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CO_STATE_CODE"]));
				}
				DC_Main.RsQry = "SELECT B.TAX_PRC,A.IGST_TAX,B.VCH_NO,B.SR_NO,B.ITM_PCS,B.ITM_NWT,B.ITM_RATE,B.ITM_AMT,B.LBR_AMT,B.OTH_AMT,B.NET_AMT,B.ITM_IGST_AMT,B.ITM_CGST_AMT,B.ITM_SGST_AMT,B.TAXABL_RATE,B.GRAND_TOTAL,C.IT_NAME,C.HSN_CODE,C.UNIT_NAME FROM (SL_DATA AS A LEFT JOIN SL_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO)  LEFT JOIN ITEM_MAST AS C ON  B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY B.SR_NO";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				string isServc = "N";
				List<ClsItemList> list = new List<ClsItemList>();
				int num = DC_Main.Tbl.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["HSN_CODE"], (object)""), (object)"9997", false), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["HSN_CODE"], (object)""), (object)"9972", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[i]["HSN_CODE"], (object)""), (object)"998892", false))))
					{
						isServc = "Y";
					}
					num2 = ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["ITM_NWT"])) != 0.0) ? Conversions.ToDouble(DC_Main.Tbl.Rows[i]["ITM_NWT"]) : Conversions.ToDouble(DC_Main.Tbl.Rows[i]["ITM_PCS"]));
					ClsItemList clsItemList = new ClsItemList
					{
						SlNo = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["SR_NO"])),
						PrdDesc = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["IT_NAME"])),
						IsServc = isServc,
						HsnCd = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["HSN_CODE"])),
						Qty = Convert.ToDecimal(num2),
						FreeQty = default(decimal),
						Unit = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["UNIT_NAME"])),
						UnitPrice = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["TAXABL_RATE"])),
						TotAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["NET_AMT"])),
						Discount = default(decimal),
						PreTaxVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["NET_AMT"])),
						AssAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["NET_AMT"])),
						GstRt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["TAX_PRC"])),
						IgstAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["ITM_IGST_AMT"])),
						CgstAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["ITM_CGST_AMT"])),
						SgstAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["ITM_SGST_AMT"])),
						CesRt = default(decimal),
						CesAmt = default(decimal),
						CesNonAdvlAmt = default(decimal),
						StateCesRt = default(decimal),
						StateCesAmt = default(decimal),
						StateCesNonAdvlAmt = default(decimal),
						OthChrg = default(decimal),
						TotItemVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["GRAND_TOTAL"])),
						PrdSlNo = text
					};
					clsItemList.BchDtls.Nm = text;
					clsItemList.BchDtls.ExpDt = Convert.ToDateTime(DateAndTime.Now).ToShortDateString();
					clsItemList.BchDtls.WrDt = Convert.ToDateTime(DateAndTime.Now).ToShortDateString();
					list.Add(clsItemList);
				}
				dcClass.ItemList = list;
				DC_Main.RsQry = "SELECT NET_AMT,CGST_TAX,SGST_TAX,IGST_TAX,DISC_AMT,TOT_AMT,TCS_AMT FROM SL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					dcClass.ValDtls.AssVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["NET_AMT"]));
					dcClass.ValDtls.CgstVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["CGST_TAX"]));
					dcClass.ValDtls.SgstVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SGST_TAX"]));
					dcClass.ValDtls.IgstVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["IGST_TAX"]));
					dcClass.ValDtls.CesVal = default(decimal);
					dcClass.ValDtls.StCesVal = default(decimal);
					dcClass.ValDtls.Discount = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["DISC_AMT"]));
					dcClass.ValDtls.OthChrg = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TCS_AMT"]));
					dcClass.ValDtls.RndOffAmt = default(decimal);
					dcClass.ValDtls.TotInvVal = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TOT_AMT"]));
					dcClass.ValDtls.TotInvValFc = default(decimal);
				}
				ClsRefDtls clsRefDtls = new ClsRefDtls();
				ClsRefDtls clsRefDtls2 = new ClsRefDtls();
				clsRefDtls2.DocPerdDtls.InvStDt = dcClass.DocDtls.Dt;
				clsRefDtls2.DocPerdDtls.InvEndDt = dcClass.DocDtls.Dt;
				dcClass.RefDtls = clsRefDtls2;
				List<ClsPrecDocDtls> list2 = new List<ClsPrecDocDtls>();
				ClsPrecDocDtls clsPrecDocDtls = new ClsPrecDocDtls();
				clsPrecDocDtls.InvNo = dcClass.DocDtls.No;
				clsPrecDocDtls.InvDt = dcClass.DocDtls.Dt;
				list2.Add(clsPrecDocDtls);
				dcClass.RefDtls.PrecDocDtls = list2;
				string text2 = "DcJson";
				string contents = JsonConvert.SerializeObject((object)dcClass, (Formatting)1);
				File.WriteAllText(DC_Main.MSImageSavePath + "\\" + text2 + ".Json", contents);
			}
			else
			{
				Interaction.MsgBox((object)"Please Insert eid and epwd in Company Master... and Try", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void BtnIrnGen_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_1037: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_1026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_0378: Expected O, but got Unknown
		//IL_039c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0463: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_046a: Unknown result type (might be due to invalid IL or missing references)
		//IL_046d: Invalid comparison between Unknown and I4
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		//IL_0487: Invalid comparison between Unknown and I4
		//IL_0b5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Expected O, but got Unknown
		//IL_0b94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Expected O, but got Unknown
		//IL_0bad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb4: Expected O, but got Unknown
		if (Strings.Len(tIrnNo.Text) > 10)
		{
			Interaction.MsgBox((object)"No Need to Generate eInvoice its Alrady Exciest ....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			RestClient val = new RestClient();
			RestRequest val2 = new RestRequest();
			RestResponse val3 = new RestResponse();
			DC_Main.RsQry = "SELECT * FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				ASPID = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_ID"]);
				ASPPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_PWD"]);
				GSTIN = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_GST_NO"]);
				eInvUserId = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_USER"]);
				eInvPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_PWD"]);
				eCoLegalName = Conversions.ToString(DC_Main.Tbl.Rows[0]["CO_LEGAL_NAME"]);
				AuthToken = tTokan.Text;
				string path = Application.StartupPath + "\\GenIRN.txt";
				string text = tBoxResponce.Text;
				string uriString = ((Strings.Len(DC_Main.SSRegSrNo) != 1) ? ("https://einvapi.charteredinfo.com/eicore/dec/v1.03/Invoice?&aspid=" + ASPID + "&password=" + ASPPwd + "&Gstin=" + GSTIN + "&User_Name=" + eInvUserId + "&AuthToken=" + AuthToken + "&QrCodeSize=250") : ("https://gstsandbox.charteredinfo.com/eicore/dec/v1.03/Invoice?&aspid=" + ASPID + "&password=" + ASPPwd + "&Gstin=" + GSTIN + "&User_Name=" + eInvUserId + "&AuthToken=" + AuthToken + "&QrCodeSize=250"));
				Uri baseUrl = new Uri(uriString);
				val.BaseUrl = baseUrl;
				val2.Method = (Method)1;
				val2.AddHeader("Content-Type", "application/json; charset=utf-8");
				val2.AddParameter("application/json", (object)text, (ParameterType)4);
				val3 = (RestResponse)val.Execute((IRestRequest)(object)val2);
				if (Operators.CompareString(((RestResponseBase)val3).Content, "", false) == 0)
				{
					Interaction.MsgBox((object)((RestResponseBase)val3).ErrorMessage, (MsgBoxStyle)0, (object)null);
					return;
				}
				IRNResp = serializer.Deserialize<IRNClass>(((RestResponseBase)val3).Content);
				if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "status_cd", new object[0], (string[])null, (Type[])null, (bool[])null), (object)null, false))
				{
					if (!Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "status_cd", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"0", false), Operators.CompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "error", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "error_cd", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"GSP752", false))))
					{
						TxtBoxError.Text = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "error", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "message", new object[0], (string[])null, (Type[])null, (bool[])null));
						File.WriteAllText(path, text);
						return;
					}
					DialogResult val4 = MessageBox.Show("AuthToken is Expired, Do you want to regenerate AuthToken?", "TaxPro GST", (MessageBoxButtons)4);
					if ((int)val4 == 7)
					{
						File.WriteAllText(path, text);
						return;
					}
					if ((int)val4 == 6)
					{
						GetAuthToken();
						((BaseButton)btnIrnGen).PerformClick();
					}
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (object)null, false), Operators.CompareObjectNotEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"1", false))))
				{
					if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorCode", new object[0], (string[])null, (Type[])null, (bool[])null), (object)5002, false))
					{
						TxtBoxError.Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject((object)"Error Code: ", NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorCode", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)": "), NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorMessage", new object[0], (string[])null, (Type[])null, (bool[])null)));
						File.WriteAllText(path, text);
						return;
					}
					if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "status_cd", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"0", false), Operators.CompareObjectEqual(NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorCode", new object[0], (string[])null, (Type[])null, (bool[])null), (object)2150, false))))
					{
						string text2 = serializer.Serialize(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "InfoDtls", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Desc", new object[0], (string[])null, (Type[])null, (bool[])null)));
						IRNClass.Desc desc = serializer.Deserialize<IRNClass.Desc>(text2);
						TxtBoxError.Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject((object)"Error Code: ", NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorCode", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)": "), NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorMessage", new object[0], (string[])null, (Type[])null, (bool[])null)));
						tIrnNo.Text = desc.Irn;
						File.WriteAllText(path, text);
						return;
					}
				}
				if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"1", false))
				{
					TxtBoxError.Text = Conversions.ToString(Operators.AddObject(Operators.AddObject(Operators.AddObject((object)"Error Code: ", NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorCode", new object[0], (string[])null, (Type[])null, (bool[])null)), (object)": "), NewLateBinding.LateGet(NewLateBinding.LateGet(IRNResp, (Type)null, "ErrorDetails", new object[1] { 0 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "ErrorMessage", new object[0], (string[])null, (Type[])null, (bool[])null)));
					return;
				}
				IRNData = serializer.Deserialize<IRNData>(Conversions.ToString(NewLateBinding.LateGet(IRNResp, (Type)null, "Data", new object[0], (string[])null, (Type[])null, (bool[])null)));
				if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(IRNResp, (Type)null, "Status", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"1", false))
				{
					tBoxResponce.Text = Conversions.ToString(NewLateBinding.LateGet(IRNResp, (Type)null, "Data", new object[0], (string[])null, (Type[])null, (bool[])null));
					tIrnNo.Text = Conversions.ToString(NewLateBinding.LateGet(IRNData, (Type)null, "IRN", new object[0], (string[])null, (Type[])null, (bool[])null));
					File.WriteAllText(path, text);
					string path2 = Application.StartupPath + "/QR.jpg";
					byte[] array = Convert.FromBase64String(Conversions.ToString(NewLateBinding.LateGet(IRNData, (Type)null, "QRCodeImage", new object[0], (string[])null, (Type[])null, (bool[])null)));
					FileStream fileStream = new FileStream(path2, FileMode.Open, FileAccess.Read);
					PicEQr.Image = Image.FromStream((Stream)fileStream);
					fileStream.Close();
				}
				File.WriteAllText(path, text);
				File.WriteAllText(Application.StartupPath + "/IRNData.txt", Conversions.ToString(NewLateBinding.LateGet(IRNResp, (Type)null, "Data", new object[0], (string[])null, (Type[])null, (bool[])null)));
				if (Strings.Len(tIrnNo.Text) > 25)
				{
					tAckNo.Text = Strings.Mid(tBoxResponce.Text, 11, 15);
					mAckDt.Text = mVchDate.Text;
					DC_Main.RsQry = "UPDATE SL_DATA SET IRN_NO = '" + tIrnNo.Text + "',ACK_NO = '" + tAckNo.Text + "',ACK_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' FROM SL_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  AND A.VCH_NO ='" + tVchNo.Text + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					string path3 = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\IRNData.txt";
					try
					{
						string text3 = File.ReadAllText(path3);
						JavaScriptSerializer val5 = new JavaScriptSerializer();
						Dictionary<string, object> dictionary = val5.Deserialize<Dictionary<string, object>>(text3);
						if (dictionary.ContainsKey("SignedQRCode"))
						{
							string text4 = dictionary["SignedQRCode"].ToString();
							QRCodeGenerator val6 = new QRCodeGenerator();
							QRCodeData val7 = val6.CreateQrCode(text4, (ECCLevel)2, false, false, (EciMode)0, -1);
							QRCode val8 = new QRCode(val7);
							Bitmap graphic = val8.GetGraphic(2);
							MemoryStream memoryStream = new MemoryStream();
							((Image)graphic).Save((Stream)memoryStream, ImageFormat.Jpeg);
							byte[] value = memoryStream.ToArray();
							PicEQr.Image = (Image)(object)graphic;
							PicEQr.SizeMode = (PictureBoxSizeMode)4;
							DC_Main.ExeQuteDc("DELETE FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'");
							DC_Main.RsQry = "SELECT * FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'";
							RsImg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow = RsImg.NewRow();
							dataRow["CO_CODE"] = DC_Main.MCo_code;
							dataRow["LC_CODE"] = DC_Main.MLc_code;
							dataRow["CO_YEAR"] = DC_Main.MCo_year;
							dataRow["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow["VCH_NO"] = tVchNo.Text;
							dataRow["IRN_NO"] = tIrnNo.Text;
							dataRow["ACK_NO"] = tAckNo.Text;
							dataRow["ACK_DATE"] = mAckDt.Text;
							dataRow["QR_DATA"] = value;
							RsImg.Rows.Add(dataRow);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
							RsImg.Clear();
						}
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						MemoryStream memoryStream2 = new MemoryStream();
						PicEQr.Image.Save((Stream)memoryStream2, PicEQr.Image.RawFormat);
						byte[] buffer = memoryStream2.GetBuffer();
						DC_Main.ExeQuteDc("DELETE FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'");
						DC_Main.RsQry = "SELECT * FROM E_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  AND VCH_NO ='" + tVchNo.Text + "'";
						RsImg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow2 = RsImg.NewRow();
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow2["VCH_NO"] = tVchNo.Text;
						dataRow2["IRN_NO"] = tIrnNo.Text;
						dataRow2["ACK_NO"] = tAckNo.Text;
						dataRow2["ACK_DATE"] = mAckDt.Text;
						dataRow2["QR_DATA"] = buffer;
						RsImg.Rows.Add(dataRow2);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
						RsImg.Clear();
						ProjectData.ClearProjectError();
					}
				}
				Interaction.MsgBox((object)"eInvoice Generate Successfully....", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"Please Insert eid and epwd in Company Master... and Try", (MsgBoxStyle)0, (object)null);
			}
		}
		else
		{
			Interaction.MsgBox((object)"No Need to Generate eInvoice its Alrady Exciest ....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnTokanGen_Click(object sender, EventArgs e)
	{
		GetAuthToken();
	}

	private void GetAuthToken()
	{
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013e: Expected O, but got Unknown
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT * FROM E_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			ASPID = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_ID"]);
			ASPPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["ASP_PWD"]);
			GSTIN = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_GST_NO"]);
			eInvUserId = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_USER"]);
			eInvPwd = Conversions.ToString(DC_Main.Tbl.Rows[0]["E_LOGIN_PWD"]);
			eCoLegalName = Conversions.ToString(DC_Main.Tbl.Rows[0]["CO_LEGAL_NAME"]);
			RestClient val = new RestClient();
			RestRequest val2 = new RestRequest();
			RestResponse val3 = new RestResponse();
			string path = Application.StartupPath + "\\AuthToken.txt";
			string uriString = ((Strings.Len(DC_Main.SSRegSrNo) != 1) ? ("https://einvapi.charteredinfo.com/eivital/dec/v1.04/auth?aspid=" + ASPID + "&password=" + ASPPwd + "&Gstin=" + GSTIN + "&User_name=" + eInvUserId + "&eInvPwd=" + eInvPwd) : ("https://gstsandbox.charteredinfo.com/eivital/dec/v1.04/auth?aspid=" + ASPID + "&password=" + ASPPwd + "&Gstin=" + GSTIN + "&User_name=" + eInvUserId + "&eInvPwd=" + eInvPwd));
			Uri baseUrl = new Uri(uriString);
			val.BaseUrl = baseUrl;
			val2.Method = (Method)0;
			val3 = (RestResponse)val.Execute((IRestRequest)(object)val2);
			if (Operators.CompareString(((RestResponseBase)val3).Content, "", false) == 0)
			{
				Interaction.MsgBox((object)((RestResponseBase)val3).ErrorMessage, (MsgBoxStyle)0, (object)null);
				return;
			}
			JsonObj = serializer.Deserialize<AuthClass>(((RestResponseBase)val3).Content);
			if (Operators.ConditionalCompareObjectEqual(NewLateBinding.LateGet(JsonObj, (Type)null, "status_cd", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"0", false))
			{
				tBoxResponce.Text = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(JsonObj, (Type)null, "error", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "message", new object[0], (string[])null, (Type[])null, (bool[])null));
				return;
			}
			tTokan.Text = Conversions.ToString(NewLateBinding.LateGet(NewLateBinding.LateGet(JsonObj, (Type)null, "Data", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AuthToken", new object[0], (string[])null, (Type[])null, (bool[])null));
			Interaction.MsgBox((object)"Auth Token refreshed Succesfully", (MsgBoxStyle)0, (object)null);
			File.WriteAllText(path, tTokan.Text);
		}
		else
		{
			Interaction.MsgBox((object)"Please Insert eid and epwd in Company Master... and Try", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnEdata_Click(object sender, EventArgs e)
	{
		edataImport();
	}

	private void edataImport()
	{
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_026c: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		AuthToken = tTokan.Text;
		DC_Main.RsQry = "SELECT * FROM CO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			CoStateCode = Conversions.ToString(DC_Main.Tbl.Rows[0]["CO_STATE_CODE"]);
			if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_ADD1"], (object)""), (object)"", false), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_STATE_CODE"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_CITY"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_PIN"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_GST_NO"], (object)""), (object)"", false))))
			{
				Interaction.MsgBox((object)"Please Insert Salers Mandatary Field In Company Mast fild is (Address 1 , City , Pincod , Gst No , State Code)..  And Try", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			if (Operators.CompareString(CoStateCode, Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GSTNO"], (object)"")), 1, 2), false) != 0 && Operators.CompareString(tAcType.Text, "L", false) == 0)
			{
				Interaction.MsgBox((object)"This Party Is Inter State Party Change AcMast Gst Type (Inter state) and Voucher Save", (MsgBoxStyle)0, (object)null);
			}
			if (Conversions.ToBoolean(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.OrObject(Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_ADD1"], (object)""), (object)"", false), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_STATE"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CITY"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_PIN"], (object)""), (object)"", false)), Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GSTNO"], (object)""), (object)"", false))))
			{
				Interaction.MsgBox((object)"Please Insert Buyers Mandatary Field In Party Mast fild is (Address 1 , City , Pincod , Gst No , State )..  And Try", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET HSN_CODE = '7113' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE = 'G' AND (HSN_CODE = '' OR HSN_CODE IS NULL)");
		DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET HSN_CODE = '7113' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE = 'S' AND (HSN_CODE = '' OR HSN_CODE IS NULL)");
		DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET HSN_CODE = '9997' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = 'HM' AND (HSN_CODE = '' OR HSN_CODE IS NULL)");
		CompnyAndParyDetail = true;
	}

	private void pnlEInvoice_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnEdata).Visible = true;
		((Control)btnTokanGen).Visible = true;
	}

	private void TR_SL_EBILL_KeyUp(object sender, KeyEventArgs e)
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
