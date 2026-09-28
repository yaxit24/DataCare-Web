using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Management;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
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
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;
using QRCoder;
using TagitSDK;

namespace DataCareNext;

[DesignerGenerated]
public class TR_TAG_OPBL : Form
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
	[AccessedThroughProperty("BtnImgC")]
	private SimpleButton _BtnImgC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgS")]
	private SimpleButton _BtnImgS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgD")]
	private SimpleButton _BtnImgD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("FlowLayoutPanel1")]
	private FlowLayoutPanel _FlowLayoutPanel1;

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
	[AccessedThroughProperty("btnTagSet")]
	private SimpleButton _btnTagSet;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLableSkip")]
	private TextBox _nLableSkip;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer _Timer1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("SerialPort1")]
	private SerialPort _SerialPort1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId2")]
	private TextBox _tHmId2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt")]
	private TextBox _nHmWt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt2")]
	private TextBox _nHmWt2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt3")]
	private TextBox _nHmWt3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId3")]
	private TextBox _tHmId3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt4")]
	private TextBox _nHmWt4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId4")]
	private TextBox _tHmId4;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItType")]
	private ComboBox _cboItType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tLotNo")]
	private TextBox _tLotNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagReNumber")]
	private SimpleButton _btnTagReNumber;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnNewTagImg")]
	private SimpleButton _btnNewTagImg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOldNewtag")]
	private SimpleButton _btnOldNewtag;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboDataType")]
	private ComboBox _cboDataType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRfid")]
	private SimpleButton _btnRfid;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnJesonGen")]
	private SimpleButton _btnJesonGen;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnLastYearIdtl")]
	private SimpleButton _btnLastYearIdtl;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMainStkToBarDetl")]
	private SimpleButton _btnMainStkToBarDetl;

	private Queue<string> Q;

	private TagitDevices tagitObject;

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

	private string CurRptTagNo;

	private bool WeightPortOpen;

	private bool StkSaleVchDel;

	private bool ItCodeLock;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private double ToDayGlRate;

	private double ToDaySlRate;

	private bool ToDayRateFill;

	private string CurTagNo;

	private string MsVchSrno;

	private string OldTagItm;

	private string TmpEntryMode;

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

	private string MaxVchNo;

	private string LastVchNo;

	private const int cSrNo = 0;

	private const int cJdtDesign = 1;

	private const int cMfgOrdNo = 2;

	private const int cItCode = 3;

	private const int cOrdNo = 4;

	private const int cTagNo = 5;

	private const int cCounter = 6;

	private const int cDesign = 7;

	private const int cStyle = 8;

	private const int cColor = 9;

	private const int cSize = 10;

	private const int cHmId = 11;

	private const int cBagWt = 12;

	private const int cPcs = 13;

	private const int cGrWt = 14;

	private const int cOthWt = 15;

	private const int cNetWt = 16;

	private const int cKrOthWt = 17;

	private const int cKrNetWt = 18;

	private const int cKrGhatPrc = 19;

	private const int cKrGhatWt = 20;

	private const int cKrTouch = 21;

	private const int cKrWestPrc = 22;

	private const int cKrFine = 23;

	private const int cLbrCode = 24;

	private const int cGhtPrc = 25;

	private const int cGhtWt = 26;

	private const int cTouch = 27;

	private const int cWestPrc = 28;

	private const int cFine = 29;

	private const int cLbrPrc = 30;

	private const int cLbrType = 31;

	private const int cLbrRate = 32;

	private const int cLbrAmt = 33;

	private const int cOthAmt = 34;

	private const int cKrLRate = 35;

	private const int cKrLAmt = 36;

	private const int cKrOthAmt = 37;

	private const int cSlType = 38;

	private const int cKrOthRate = 39;

	private const int cKrOthFine = 40;

	private const int cKrTotFine = 41;

	private const int cKrGwtTouch = 42;

	private const int cItRate = 43;

	private const int cItAmt = 44;

	private const int cPrCost = 45;

	private const int cTagCost = 46;

	private const int cMainMargin = 47;

	private const int cMainMrp = 48;

	private const int cMargin = 49;

	private const int cMrp = 50;

	private const int cImageTake = 51;

	private const int cItRemark = 52;

	private const int cKrName = 53;

	private const int cJdtNet = 54;

	private const int cGhatWt = 55;

	private const int cKundan = 56;

	private const int cKndTch = 57;

	private const int cKndNwt = 58;

	private const int cWax = 59;

	private const int cKrWax = 60;

	private const int cTagSrNo = 61;

	private const int cOldSrNo = 62;

	private const int cRateType = 63;

	private const int cItType = 64;

	private const int cTagType = 65;

	private const int cPrCode = 66;

	private const int cVchSrno = 67;

	private const int cItName = 68;

	private const int cEntryMod = 69;

	private const int cOldTagType = 70;

	private const int cOldPrCode = 71;

	private const int cOldGrWt = 72;

	private const int cOldNtWt = 73;

	private const int cOldGhatPrc = 74;

	private const int cOldGhatWt = 75;

	private const int cOldTouch = 76;

	private const int cOldWestPrc = 77;

	private const int cOldKrNetWt = 78;

	private const int cOldKrTouch = 79;

	private const int cOldKrWest = 80;

	private const int cAprIsu = 81;

	private const int cHmId2 = 82;

	private const int cHmId3 = 83;

	private const int cHmId4 = 84;

	private const int cHmIdWt = 85;

	private const int cHmId2Wt = 86;

	private const int cHmId3Wt = 87;

	private const int cHmId4Wt = 88;

	private const int cDataType = 89;

	private const int cOrdSrNo = 90;

	private const int cOrdYrcd = 91;

	private const int cOrdDbCd = 92;

	private const int cOrdName = 93;

	private const int cOrdAc = 94;

	private const int cOrLcCode = 95;

	private const int cOldMargin = 96;

	private const int cOldTagNo = 97;

	private const int cOldMainMargin = 98;

	private const int cOldKrGhatWt = 99;

	private const int cEmpIsu = 100;

	private const int cDesignImgId = 101;

	private const int cStkDate = 102;

	private const int cMfgYrcd = 103;

	private const int cMfgDbCd = 104;

	private const int cMfgNo = 105;

	private const int cMfgSrNo = 106;

	private const int cMfgCustOrdNo = 107;

	private const int cOldKrOthRate = 108;

	private const int cLotTouch = 109;

	private const int cLotWest = 110;

	private const int cLotFine = 111;

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

	private const int c1MotiPcs = 10;

	private const int c1MotiWt = 11;

	private const int c1Pcs = 12;

	private const int c1PcsWt = 13;

	private const int c1KrActWt = 14;

	private const int c1KrActPrc = 15;

	private const int c1KrWt = 16;

	private const int c1KrPrc = 17;

	private const int c1KrLsWt = 18;

	private const int c1GrWt = 19;

	private const int c1ConPrc = 20;

	private const int c1RateType = 21;

	private const int c1ItRate = 22;

	private const int c1ItmAmt = 23;

	private const int c1DiscPrc = 24;

	private const int c1DiscAmt = 25;

	private const int c1KrConPrc = 26;

	private const int c1KrRateType = 27;

	private const int c1KrRate = 28;

	private const int c1KrAmt = 29;

	private const int c1KrLRate = 30;

	private const int c1KrLAmt = 31;

	private const int c1LbrRate = 32;

	private const int c1LbrAmt = 33;

	private const int c1NetAmt = 34;

	private const int c1ConWt = 35;

	private const int c1KrConWt = 36;

	private const int c1ItType = 37;

	private const int c1RowSr = 38;

	private const int c1oldKrWt = 39;

	private const int c1oldGrWt = 40;

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

	internal virtual SimpleButton BtnImgC
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgC_Click;
			SimpleButton val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgC = value;
			val = _BtnImgC;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgS
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgS;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgS_Click;
			SimpleButton val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgS = value;
			val = _BtnImgS;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnImgD
	{
		[CompilerGenerated]
		get
		{
			return _BtnImgD;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnImgD_Click;
			SimpleButton val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnImgD = value;
			val = _BtnImgD;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual FlowLayoutPanel FlowLayoutPanel1
	{
		[CompilerGenerated]
		get
		{
			return _FlowLayoutPanel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = FlowLayoutPanel1_DoubleClick;
			FlowLayoutPanel val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_FlowLayoutPanel1 = value;
			val = _FlowLayoutPanel1;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
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
			EventHandler eventHandler = BtnTagSet_Click;
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

	internal virtual TextBox nLableSkip
	{
		[CompilerGenerated]
		get
		{
			return _nLableSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLableSkip_KeyDown);
			TextBox val2 = _nLableSkip;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nLableSkip = value;
			val2 = _nLableSkip;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItName")]
	private virtual TextBox _tItName;

	internal virtual TextBox tItName
	{
		get
		{
			return _tItName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItName = value;
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

	internal virtual System.Windows.Forms.Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = Timer1_Tick;
			System.Windows.Forms.Timer val = _Timer1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_Timer1 = value;
			val = _Timer1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	internal virtual SerialPort SerialPort1
	{
		[CompilerGenerated]
		get
		{
			return _SerialPort1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			SerialDataReceivedEventHandler val = new SerialDataReceivedEventHandler(SerialPort1_DataReceived);
			SerialPort val2 = _SerialPort1;
			if (val2 != null)
			{
				val2.DataReceived -= val;
			}
			_SerialPort1 = value;
			val2 = _SerialPort1;
			if (val2 != null)
			{
				val2.DataReceived += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nItNwt")]
	private virtual TextBox _nItNwt;

	internal virtual TextBox nItNwt
	{
		get
		{
			return _nItNwt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nItNwt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nitGwt")]
	private virtual TextBox _nitGwt;

	internal virtual TextBox nitGwt
	{
		get
		{
			return _nitGwt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nitGwt = value;
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
	[AccessedThroughProperty("nPcs")]
	private virtual TextBox _nPcs;

	internal virtual TextBox nPcs
	{
		get
		{
			return _nPcs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPcs = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PictureBox1")]
	private virtual PictureBox _PictureBox1;

	internal virtual PictureBox PictureBox1
	{
		get
		{
			return _PictureBox1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PictureBox1 = value;
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

	internal virtual TextBox tHmId2
	{
		[CompilerGenerated]
		get
		{
			return _tHmId2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId2_KeyDown);
			EventHandler eventHandler = tHmId2_TextChanged;
			TextBox val2 = _tHmId2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tHmId2 = value;
			val2 = _tHmId2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	internal virtual TextBox nHmWt
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt_KeyDown);
			TextBox val2 = _nHmWt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt = value;
			val2 = _nHmWt;
			if (val2 != null)
			{
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

	internal virtual TextBox nHmWt2
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt2_KeyDown);
			TextBox val2 = _nHmWt2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt2 = value;
			val2 = _nHmWt2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nHmWt3
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt3_KeyDown);
			TextBox val2 = _nHmWt3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt3 = value;
			val2 = _nHmWt3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tHmId3
	{
		[CompilerGenerated]
		get
		{
			return _tHmId3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId3_KeyDown);
			TextBox val2 = _tHmId3;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId3 = value;
			val2 = _tHmId3;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nHmWt4
	{
		[CompilerGenerated]
		get
		{
			return _nHmWt4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nHmWt4_KeyDown);
			TextBox val2 = _nHmWt4;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nHmWt4 = value;
			val2 = _nHmWt4;
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

	internal virtual TextBox tHmId4
	{
		[CompilerGenerated]
		get
		{
			return _tHmId4;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tHmId4_KeyDown);
			TextBox val2 = _tHmId4;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId4 = value;
			val2 = _tHmId4;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual ComboBox cboItType
	{
		[CompilerGenerated]
		get
		{
			return _cboItType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboItType_KeyDown);
			ComboBox val2 = _cboItType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboItType = value;
			val2 = _cboItType;
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

	internal virtual SimpleButton btnExel
	{
		[CompilerGenerated]
		get
		{
			return _btnExel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExel_Click;
			SimpleButton val = _btnExel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExel = value;
			val = _btnExel;
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

	internal virtual TextBox tLotNo
	{
		[CompilerGenerated]
		get
		{
			return _tLotNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLotNo_KeyDown);
			EventHandler eventHandler = tLotNo_TextChanged;
			TextBox val2 = _tLotNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tLotNo = value;
			val2 = _tLotNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnTagReNumber
	{
		[CompilerGenerated]
		get
		{
			return _btnTagReNumber;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagReNumber_Click;
			SimpleButton val = _btnTagReNumber;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagReNumber = value;
			val = _btnTagReNumber;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnNewTagImg
	{
		[CompilerGenerated]
		get
		{
			return _btnNewTagImg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnNewTagImg_Click;
			SimpleButton val = _btnNewTagImg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnNewTagImg = value;
			val = _btnNewTagImg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnOldNewtag
	{
		[CompilerGenerated]
		get
		{
			return _btnOldNewtag;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOldNewtag_Click;
			SimpleButton val = _btnOldNewtag;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOldNewtag = value;
			val = _btnOldNewtag;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual ComboBox cboDataType
	{
		[CompilerGenerated]
		get
		{
			return _cboDataType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = CboDataType_SelectedIndexChanged;
			KeyEventHandler val = new KeyEventHandler(cboDataType_KeyDown);
			ComboBox val2 = _cboDataType;
			if (val2 != null)
			{
				val2.SelectedIndexChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_cboDataType = value;
			val2 = _cboDataType;
			if (val2 != null)
			{
				val2.SelectedIndexChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDataType")]
	private virtual Label _lblDataType;

	internal virtual Label lblDataType
	{
		get
		{
			return _lblDataType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDataType = value;
		}
	}

	internal virtual SimpleButton btnRfid
	{
		[CompilerGenerated]
		get
		{
			return _btnRfid;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnRfid_Click;
			SimpleButton val = _btnRfid;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRfid = value;
			val = _btnRfid;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnJesonGen
	{
		[CompilerGenerated]
		get
		{
			return _btnJesonGen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnJesonGen_Click;
			SimpleButton val = _btnJesonGen;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnJesonGen = value;
			val = _btnJesonGen;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboPrintType")]
	private virtual ComboBox _cboPrintType;

	internal virtual ComboBox cboPrintType
	{
		get
		{
			return _cboPrintType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboPrintType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPrintType")]
	private virtual Label _lblPrintType;

	internal virtual Label lblPrintType
	{
		get
		{
			return _lblPrintType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPrintType = value;
		}
	}

	internal virtual SimpleButton btnLastYearIdtl
	{
		[CompilerGenerated]
		get
		{
			return _btnLastYearIdtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLastYearIdtl_Click;
			SimpleButton val = _btnLastYearIdtl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnLastYearIdtl = value;
			val = _btnLastYearIdtl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnMainStkToBarDetl
	{
		[CompilerGenerated]
		get
		{
			return _btnMainStkToBarDetl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnMainStkToBarDetl_Click;
			SimpleButton val = _btnMainStkToBarDetl;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMainStkToBarDetl = value;
			val = _btnMainStkToBarDetl;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblStkBook")]
	private virtual Label _lblStkBook;

	internal virtual Label lblStkBook
	{
		get
		{
			return _lblStkBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblStkBook = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblStkVch")]
	private virtual Label _lblStkVch;

	internal virtual Label lblStkVch
	{
		get
		{
			return _lblStkVch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblStkVch = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLotTouch")]
	private virtual TextBox _nLotTouch;

	internal virtual TextBox nLotTouch
	{
		get
		{
			return _nLotTouch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLotTouch = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nLotWestPrc")]
	private virtual TextBox _nLotWestPrc;

	internal virtual TextBox nLotWestPrc
	{
		get
		{
			return _nLotWestPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLotWestPrc = value;
		}
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
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Expected O, but got Unknown
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Expected O, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Expected O, but got Unknown
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Expected O, but got Unknown
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected O, but got Unknown
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Expected O, but got Unknown
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Expected O, but got Unknown
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0117: Expected O, but got Unknown
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Expected O, but got Unknown
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Expected O, but got Unknown
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected O, but got Unknown
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_0179: Unknown result type (might be due to invalid IL or missing references)
		//IL_0183: Expected O, but got Unknown
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Expected O, but got Unknown
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Expected O, but got Unknown
		//IL_01b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ef: Expected O, but got Unknown
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fb: Expected O, but got Unknown
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Expected O, but got Unknown
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0221: Unknown result type (might be due to invalid IL or missing references)
		//IL_022b: Expected O, but got Unknown
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0243: Expected O, but got Unknown
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Expected O, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Expected O, but got Unknown
		//IL_0275: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_028d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Expected O, but got Unknown
		//IL_0299: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		//IL_02a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02af: Expected O, but got Unknown
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Expected O, but got Unknown
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Expected O, but got Unknown
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02eb: Expected O, but got Unknown
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f7: Expected O, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0303: Expected O, but got Unknown
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Expected O, but got Unknown
		//IL_0311: Unknown result type (might be due to invalid IL or missing references)
		//IL_031b: Expected O, but got Unknown
		//IL_031d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0329: Unknown result type (might be due to invalid IL or missing references)
		//IL_0333: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_033f: Expected O, but got Unknown
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Expected O, but got Unknown
		//IL_034d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0357: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_0365: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Expected O, but got Unknown
		//IL_0371: Unknown result type (might be due to invalid IL or missing references)
		//IL_037b: Expected O, but got Unknown
		//IL_037d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0387: Expected O, but got Unknown
		//IL_0389: Unknown result type (might be due to invalid IL or missing references)
		//IL_0393: Expected O, but got Unknown
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
		//IL_039f: Expected O, but got Unknown
		//IL_03a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ab: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Expected O, but got Unknown
		//IL_03b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c3: Expected O, but got Unknown
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Expected O, but got Unknown
		//IL_03d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03db: Expected O, but got Unknown
		//IL_03dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Expected O, but got Unknown
		//IL_03f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ff: Expected O, but got Unknown
		//IL_04bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c7: Expected O, but got Unknown
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0584: Expected O, but got Unknown
		//IL_0607: Unknown result type (might be due to invalid IL or missing references)
		//IL_0611: Expected O, but got Unknown
		//IL_06ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b8: Expected O, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected O, but got Unknown
		//IL_0805: Unknown result type (might be due to invalid IL or missing references)
		//IL_080f: Expected O, but got Unknown
		//IL_08aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b4: Expected O, but got Unknown
		//IL_0943: Unknown result type (might be due to invalid IL or missing references)
		//IL_094d: Expected O, but got Unknown
		//IL_09b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ba: Expected O, but got Unknown
		//IL_0a63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6d: Expected O, but got Unknown
		//IL_0ad0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ada: Expected O, but got Unknown
		//IL_0b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8d: Expected O, but got Unknown
		//IL_0caa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb4: Expected O, but got Unknown
		//IL_0dbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc9: Expected O, but got Unknown
		//IL_0e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e36: Expected O, but got Unknown
		//IL_0ff6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1050: Unknown result type (might be due to invalid IL or missing references)
		//IL_105a: Expected O, but got Unknown
		//IL_1178: Unknown result type (might be due to invalid IL or missing references)
		//IL_1182: Expected O, but got Unknown
		//IL_136f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1379: Expected O, but got Unknown
		//IL_13ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1409: Expected O, but got Unknown
		//IL_14c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d2: Expected O, but got Unknown
		//IL_15c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d2: Expected O, but got Unknown
		//IL_16e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16eb: Expected O, but got Unknown
		//IL_1768: Unknown result type (might be due to invalid IL or missing references)
		//IL_1772: Expected O, but got Unknown
		//IL_1833: Unknown result type (might be due to invalid IL or missing references)
		//IL_183d: Expected O, but got Unknown
		//IL_18e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ef: Expected O, but got Unknown
		//IL_19f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_19fd: Expected O, but got Unknown
		//IL_1a5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a68: Expected O, but got Unknown
		//IL_1abd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac7: Expected O, but got Unknown
		//IL_1b78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b82: Expected O, but got Unknown
		//IL_1c33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3d: Expected O, but got Unknown
		//IL_1da5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1daf: Expected O, but got Unknown
		//IL_1e87: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e91: Expected O, but got Unknown
		//IL_1f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f37: Expected O, but got Unknown
		//IL_2079: Unknown result type (might be due to invalid IL or missing references)
		//IL_2083: Expected O, but got Unknown
		//IL_20fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2107: Expected O, but got Unknown
		//IL_21d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e2: Expected O, but got Unknown
		//IL_22b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_22c1: Expected O, but got Unknown
		//IL_235d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2367: Expected O, but got Unknown
		//IL_247c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2486: Expected O, but got Unknown
		//IL_253a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2544: Expected O, but got Unknown
		//IL_25ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_25f6: Expected O, but got Unknown
		//IL_263e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2648: Expected O, but got Unknown
		//IL_26cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_26d9: Expected O, but got Unknown
		//IL_276a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2774: Expected O, but got Unknown
		//IL_2832: Unknown result type (might be due to invalid IL or missing references)
		//IL_283c: Expected O, but got Unknown
		//IL_28db: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e5: Expected O, but got Unknown
		//IL_2996: Unknown result type (might be due to invalid IL or missing references)
		//IL_29a0: Expected O, but got Unknown
		//IL_2a1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a25: Expected O, but got Unknown
		//IL_2aad: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ab7: Expected O, but got Unknown
		//IL_2b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b72: Expected O, but got Unknown
		//IL_2c1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c25: Expected O, but got Unknown
		//IL_2cba: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cc4: Expected O, but got Unknown
		//IL_2d82: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8c: Expected O, but got Unknown
		//IL_2ec3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ecd: Expected O, but got Unknown
		//IL_2f62: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f6c: Expected O, but got Unknown
		//IL_301d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3027: Expected O, but got Unknown
		//IL_30a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_30b2: Expected O, but got Unknown
		//IL_3129: Unknown result type (might be due to invalid IL or missing references)
		//IL_3133: Expected O, but got Unknown
		//IL_31e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_31f1: Expected O, but got Unknown
		//IL_327f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3289: Expected O, but got Unknown
		//IL_3304: Unknown result type (might be due to invalid IL or missing references)
		//IL_330e: Expected O, but got Unknown
		//IL_33c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_33cc: Expected O, but got Unknown
		//IL_344e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3458: Expected O, but got Unknown
		//IL_34d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_34dd: Expected O, but got Unknown
		//IL_3591: Unknown result type (might be due to invalid IL or missing references)
		//IL_359b: Expected O, but got Unknown
		//IL_364a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3654: Expected O, but got Unknown
		//IL_36c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_36d1: Expected O, but got Unknown
		//IL_3779: Unknown result type (might be due to invalid IL or missing references)
		//IL_3783: Expected O, but got Unknown
		//IL_3841: Unknown result type (might be due to invalid IL or missing references)
		//IL_384b: Expected O, but got Unknown
		//IL_38ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_38d4: Expected O, but got Unknown
		//IL_39f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_39fa: Expected O, but got Unknown
		//IL_3b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b20: Expected O, but got Unknown
		//IL_3c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c7f: Expected O, but got Unknown
		//IL_3d06: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d10: Expected O, but got Unknown
		//IL_3dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dcc: Expected O, but got Unknown
		//IL_3edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ee5: Expected O, but got Unknown
		//IL_4001: Unknown result type (might be due to invalid IL or missing references)
		//IL_400b: Expected O, but got Unknown
		//IL_4130: Unknown result type (might be due to invalid IL or missing references)
		//IL_413a: Expected O, but got Unknown
		//IL_41da: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e4: Expected O, but got Unknown
		//IL_4298: Unknown result type (might be due to invalid IL or missing references)
		//IL_42a2: Expected O, but got Unknown
		//IL_434a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4354: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_TAG_OPBL));
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
		btnExel = new SimpleButton();
		btnRfid = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		cboPrintType = new ComboBox();
		lblPrintType = new Label();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		lblItem = new Label();
		TEXT_IDTL = new TextBox();
		MSG_IDTL = new AxMSFlexGrid();
		PicImage = new PictureBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		BtnImgC = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgD = new SimpleButton();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		BtnF1 = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label6 = new Label();
		btnTagSet = new SimpleButton();
		Label1 = new Label();
		nLableSkip = new TextBox();
		Cr = new AxCrystalReport();
		tItCode = new TextBox();
		tItName = new TextBox();
		Label3 = new Label();
		tVchDesc = new TextBox();
		Label4 = new Label();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label5 = new Label();
		Timer1 = new System.Windows.Forms.Timer(components);
		SerialPort1 = new SerialPort(components);
		nItNwt = new TextBox();
		nitGwt = new TextBox();
		Label15 = new Label();
		nPcs = new TextBox();
		PictureBox1 = new PictureBox();
		tHdVchNo = new TextBox();
		Label7 = new Label();
		tHmId2 = new TextBox();
		nHmWt = new TextBox();
		Label8 = new Label();
		nHmWt2 = new TextBox();
		nHmWt3 = new TextBox();
		Label9 = new Label();
		tHmId3 = new TextBox();
		nHmWt4 = new TextBox();
		Label10 = new Label();
		tHmId4 = new TextBox();
		cboItType = new ComboBox();
		Label11 = new Label();
		Label12 = new Label();
		tLotNo = new TextBox();
		btnTagReNumber = new SimpleButton();
		btnNewTagImg = new SimpleButton();
		btnOldNewtag = new SimpleButton();
		cboDataType = new ComboBox();
		lblDataType = new Label();
		btnJesonGen = new SimpleButton();
		btnLastYearIdtl = new SimpleButton();
		btnMainStkToBarDetl = new SimpleButton();
		lblStkBook = new Label();
		lblStkVch = new Label();
		nLotTouch = new TextBox();
		nLotWestPrc = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)PictureBox1).BeginInit();
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
		((Control)lblBook).TabIndex = 17;
		lblBook.Text = "Tag Oppning";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(289, 40);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(213, 42);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(73, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)64;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImageAlign = (ContentAlignment)64;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 41);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(86, 40);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(458, 40);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(81, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(370, 40);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(81, 23);
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
		((Control)PnlBotam).Controls.Add((Control)(object)btnRfid);
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
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		btnExel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)btnExel).Location = new Point(730, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 30;
		btnExel.Text = "&Exel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnRfid).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnRfid).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnRfid).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnRfid).Appearance.Options.UseForeColor = true;
		btnRfid.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)btnRfid.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)btnRfid).Location = new Point(633, 3);
		((BaseControl)btnRfid).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnRfid).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnRfid).Name = "btnRfid";
		((Control)btnRfid).Size = new Size(91, 37);
		((Control)btnRfid).TabIndex = 31;
		btnRfid.Text = "&Rfid";
		((BaseButton)btnRfid).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnRfid).Visible = false;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)cboPrintType);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)lblPrintType);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(157, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(470, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		cboPrintType.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintType.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintType).FormattingEnabled = true;
		((Control)cboPrintType).Location = new Point(367, 3);
		cboPrintType.MaxLength = 5;
		((Control)cboPrintType).Name = "cboPrintType";
		((Control)cboPrintType).Size = new Size(100, 24);
		((Control)cboPrintType).TabIndex = 1242;
		((Control)cboPrintType).Visible = false;
		((Control)lblPrintType).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblPrintType).ForeColor = Color.Black;
		lblPrintType.ImageAlign = (ContentAlignment)64;
		lblPrintType.ImeMode = (ImeMode)0;
		((Control)lblPrintType).Location = new Point(263, 0);
		((Control)lblPrintType).Name = "lblPrintType";
		((Control)lblPrintType).Size = new Size(98, 30);
		((Control)lblPrintType).TabIndex = 1243;
		lblPrintType.Text = "Print Type";
		lblPrintType.TextAlign = (ContentAlignment)64;
		((Control)lblPrintType).Visible = false;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(110, 3);
		((BaseControl)BtnLast).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnLast).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnLast).Name = "BtnLast";
		((Control)BtnLast).Size = new Size(41, 37);
		((Control)BtnLast).TabIndex = 29;
		BtnLast.Text = ">";
		((BaseButton)BtnLast).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnFirst).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnFirst).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnFirst).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnFirst).Appearance.Options.UseForeColor = true;
		((Control)BtnFirst).Location = new Point(63, 3);
		((BaseControl)BtnFirst).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnFirst).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnFirst).Name = "BtnFirst";
		((Control)BtnFirst).Size = new Size(41, 37);
		((Control)BtnFirst).TabIndex = 28;
		BtnFirst.Text = "<";
		((BaseButton)BtnFirst).ToolTipAnchor = (ToolTipAnchor)1;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(546, 192);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(607, 69);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(275, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(499, 427);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 13;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 369);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(973, 146);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(992, 369);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(178, 146);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(13, 318);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1162, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 97);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 220);
		((Control)MSG).TabIndex = 1135;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(1003, 521);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(40, 34);
		((Control)BtnImgC).TabIndex = 18;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(1058, 521);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(40, 34);
		((Control)BtnImgS).TabIndex = 19;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(1113, 521);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(40, 34);
		((Control)BtnImgD).TabIndex = 20;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1157, 522);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(12, 32);
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
		((Control)BtnF1).Location = new Point(168, 40);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(1007, 67);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(113, 24);
		((Control)cboPrintfile).TabIndex = 1150;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(895, 68);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(106, 20);
		((Control)Label6).TabIndex = 1151;
		Label6.Text = "Print file Name";
		Label6.TextAlign = (ContentAlignment)16;
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
		((Control)btnTagSet).Location = new Point(1126, 66);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(44, 24);
		((Control)btnTagSet).TabIndex = 1152;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(856, 529);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(80, 20);
		((Control)Label1).TabIndex = 1154;
		Label1.Text = "Lable Skip";
		Label1.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nLableSkip).BackColor = Color.White;
		((Control)nLableSkip).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLableSkip).Location = new Point(945, 529);
		((TextBoxBase)nLableSkip).MaxLength = 15;
		((Control)nLableSkip).Name = "nLableSkip";
		((Control)nLableSkip).Size = new Size(39, 22);
		((Control)nLableSkip).TabIndex = 1153;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1269, 60);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(288, 70);
		((TextBoxBase)tItCode).MaxLength = 5;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(63, 22);
		((Control)tItCode).TabIndex = 4;
		((Control)tItCode).Visible = false;
		((TextBoxBase)tItName).BackColor = Color.White;
		((Control)tItName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tItName).Location = new Point(357, 70);
		((TextBoxBase)tItName).MaxLength = 8;
		((Control)tItName).Name = "tItName";
		((Control)tItName).Size = new Size(246, 22);
		((Control)tItName).TabIndex = 1161;
		((Control)tItName).Visible = false;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(218, 71);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(64, 20);
		((Control)Label3).TabIndex = 1160;
		Label3.Text = "Itm Code";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label3).Visible = false;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(448, 521);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(373, 38);
		((Control)tVchDesc).TabIndex = 15;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(376, 538);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1168;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(89, 536);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 14;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(152, 536);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 22);
		((Control)tEmpName).TabIndex = 1167;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(14, 538);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(69, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Employee";
		Label5.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(988, 38);
		((TextBoxBase)nItNwt).MaxLength = 10;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(74, 23);
		((Control)nItNwt).TabIndex = 1226;
		nItNwt.TextAlign = (HorizontalAlignment)1;
		((Control)nItNwt).Visible = false;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(907, 38);
		((TextBoxBase)nitGwt).MaxLength = 10;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(76, 23);
		((Control)nitGwt).TabIndex = 1225;
		nitGwt.TextAlign = (HorizontalAlignment)1;
		((Control)nitGwt).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(783, 40);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1224;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label15).Visible = false;
		((TextBoxBase)nPcs).BackColor = Color.White;
		((Control)nPcs).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPcs).Location = new Point(855, 38);
		((TextBoxBase)nPcs).MaxLength = 8;
		((Control)nPcs).Name = "nPcs";
		((TextBoxBase)nPcs).ReadOnly = true;
		((Control)nPcs).Size = new Size(47, 23);
		((Control)nPcs).TabIndex = 1227;
		nPcs.TextAlign = (HorizontalAlignment)1;
		((Control)nPcs).Visible = false;
		((Control)PictureBox1).Location = new Point(1205, 97);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(56, 48);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 1228;
		PictureBox1.TabStop = false;
		((Control)PictureBox1).Visible = false;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(24, 9);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 1229;
		((Control)tHdVchNo).Visible = false;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(17, 341);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(52, 20);
		((Control)Label7).TabIndex = 1230;
		Label7.Text = "HuWt";
		Label7.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId2).BackColor = Color.White;
		((Control)tHmId2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId2).Location = new Point(205, 341);
		((TextBoxBase)tHmId2).MaxLength = 10;
		((Control)tHmId2).Name = "tHmId2";
		((Control)tHmId2).Size = new Size(65, 23);
		((Control)tHmId2).TabIndex = 7;
		((TextBoxBase)nHmWt).BackColor = Color.Linen;
		((Control)nHmWt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt).Location = new Point(75, 341);
		((TextBoxBase)nHmWt).MaxLength = 10;
		((Control)nHmWt).Name = "nHmWt";
		((Control)nHmWt).Size = new Size(65, 23);
		((Control)nHmWt).TabIndex = 6;
		nHmWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(148, 342);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(54, 20);
		((Control)Label8).TabIndex = 1233;
		Label8.Text = "HuId2";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nHmWt2).BackColor = Color.Linen;
		((Control)nHmWt2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt2).Location = new Point(272, 341);
		((TextBoxBase)nHmWt2).MaxLength = 10;
		((Control)nHmWt2).Name = "nHmWt2";
		((Control)nHmWt2).Size = new Size(65, 23);
		((Control)nHmWt2).TabIndex = 8;
		nHmWt2.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)nHmWt3).BackColor = Color.Linen;
		((Control)nHmWt3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt3).Location = new Point(468, 341);
		((TextBoxBase)nHmWt3).MaxLength = 10;
		((Control)nHmWt3).Name = "nHmWt3";
		((Control)nHmWt3).Size = new Size(65, 23);
		((Control)nHmWt3).TabIndex = 10;
		nHmWt3.TextAlign = (HorizontalAlignment)1;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(344, 343);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(54, 20);
		((Control)Label9).TabIndex = 1236;
		Label9.Text = "HuId3";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId3).BackColor = Color.White;
		((Control)tHmId3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId3).Location = new Point(401, 341);
		((TextBoxBase)tHmId3).MaxLength = 10;
		((Control)tHmId3).Name = "tHmId3";
		((Control)tHmId3).Size = new Size(65, 23);
		((Control)tHmId3).TabIndex = 9;
		((TextBoxBase)nHmWt4).BackColor = Color.Linen;
		((Control)nHmWt4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt4).Location = new Point(666, 341);
		((TextBoxBase)nHmWt4).MaxLength = 10;
		((Control)nHmWt4).Name = "nHmWt4";
		((Control)nHmWt4).Size = new Size(65, 23);
		((Control)nHmWt4).TabIndex = 12;
		nHmWt4.TextAlign = (HorizontalAlignment)1;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(542, 342);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(54, 20);
		((Control)Label10).TabIndex = 1239;
		Label10.Text = "HuId4";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId4).BackColor = Color.White;
		((Control)tHmId4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId4).Location = new Point(599, 341);
		((TextBoxBase)tHmId4).MaxLength = 10;
		((Control)tHmId4).Name = "tHmId4";
		((Control)tHmId4).Size = new Size(65, 23);
		((Control)tHmId4).TabIndex = 11;
		cboItType.AutoCompleteMode = (AutoCompleteMode)2;
		cboItType.AutoCompleteSource = (AutoCompleteSource)256;
		cboItType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboItType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboItType).FormattingEnabled = true;
		((Control)cboItType).Location = new Point(86, 68);
		cboItType.MaxLength = 5;
		((Control)cboItType).Name = "cboItType";
		((Control)cboItType).Size = new Size(116, 24);
		((Control)cboItType).TabIndex = 2;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImageAlign = (ContentAlignment)64;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(11, 68);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(65, 20);
		((Control)Label11).TabIndex = 1241;
		Label11.Text = "It Type";
		Label11.TextAlign = (ContentAlignment)64;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(535, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(66, 20);
		((Control)Label12).TabIndex = 1242;
		Label12.Text = "Lot No";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label12).Visible = false;
		((TextBoxBase)tLotNo).BackColor = Color.White;
		((Control)tLotNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tLotNo).Location = new Point(609, 39);
		((TextBoxBase)tLotNo).MaxLength = 10;
		((Control)tLotNo).Name = "tLotNo";
		((Control)tLotNo).Size = new Size(76, 23);
		((Control)tLotNo).TabIndex = 3;
		((Control)tLotNo).Visible = false;
		((BaseStyleControl)btnTagReNumber).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagReNumber).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagReNumber).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagReNumber).Appearance.Options.UseForeColor = true;
		btnTagReNumber.ImageOptions.Location = (ImageLocation)1;
		((Control)btnTagReNumber).Location = new Point(1190, 423);
		((BaseControl)btnTagReNumber).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagReNumber).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagReNumber).Name = "btnTagReNumber";
		((Control)btnTagReNumber).Size = new Size(119, 37);
		((Control)btnTagReNumber).TabIndex = 1243;
		btnTagReNumber.Text = "&Tag Re Number";
		((BaseButton)btnTagReNumber).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnTagReNumber).Visible = false;
		((BaseStyleControl)btnNewTagImg).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnNewTagImg).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnNewTagImg).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnNewTagImg).Appearance.Options.UseForeColor = true;
		btnNewTagImg.ImageOptions.Location = (ImageLocation)1;
		((Control)btnNewTagImg).Location = new Point(1190, 470);
		((BaseControl)btnNewTagImg).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnNewTagImg).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnNewTagImg).Name = "btnNewTagImg";
		((Control)btnNewTagImg).Size = new Size(119, 37);
		((Control)btnNewTagImg).TabIndex = 1244;
		btnNewTagImg.Text = "New Tag Img";
		((BaseButton)btnNewTagImg).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnNewTagImg).Visible = false;
		((BaseStyleControl)btnOldNewtag).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnOldNewtag).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnOldNewtag).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnOldNewtag).Appearance.Options.UseForeColor = true;
		btnOldNewtag.ImageOptions.Location = (ImageLocation)1;
		((Control)btnOldNewtag).Location = new Point(1190, 513);
		((BaseControl)btnOldNewtag).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnOldNewtag).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnOldNewtag).Name = "btnOldNewtag";
		((Control)btnOldNewtag).Size = new Size(119, 37);
		((Control)btnOldNewtag).TabIndex = 1245;
		btnOldNewtag.Text = "Old New Tag";
		((BaseButton)btnOldNewtag).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnOldNewtag).Visible = false;
		cboDataType.AutoCompleteMode = (AutoCompleteMode)2;
		cboDataType.AutoCompleteSource = (AutoCompleteSource)256;
		cboDataType.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboDataType).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboDataType).FormattingEnabled = true;
		((Control)cboDataType).Location = new Point(1069, 37);
		cboDataType.MaxLength = 5;
		((Control)cboDataType).Name = "cboDataType";
		((Control)cboDataType).Size = new Size(51, 24);
		((Control)cboDataType).TabIndex = 1246;
		((Control)cboDataType).Visible = false;
		((Control)lblDataType).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblDataType).ForeColor = Color.Black;
		lblDataType.ImeMode = (ImeMode)0;
		((Control)lblDataType).Location = new Point(1126, 35);
		((Control)lblDataType).Name = "lblDataType";
		((Control)lblDataType).Size = new Size(51, 20);
		((Control)lblDataType).TabIndex = 1247;
		lblDataType.Text = "DType";
		lblDataType.TextAlign = (ContentAlignment)16;
		((Control)lblDataType).Visible = false;
		((BaseStyleControl)btnJesonGen).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnJesonGen).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnJesonGen).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnJesonGen).Appearance.Options.UseForeColor = true;
		btnJesonGen.ImageOptions.Location = (ImageLocation)1;
		((Control)btnJesonGen).Location = new Point(1190, 380);
		((BaseControl)btnJesonGen).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnJesonGen).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnJesonGen).Name = "btnJesonGen";
		((Control)btnJesonGen).Size = new Size(119, 37);
		((Control)btnJesonGen).TabIndex = 1248;
		btnJesonGen.Text = "&Jeson Creat";
		((BaseButton)btnJesonGen).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnLastYearIdtl).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnLastYearIdtl).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnLastYearIdtl).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnLastYearIdtl).Appearance.Options.UseForeColor = true;
		btnLastYearIdtl.ImageOptions.Location = (ImageLocation)1;
		((Control)btnLastYearIdtl).Location = new Point(1190, 235);
		((BaseControl)btnLastYearIdtl).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnLastYearIdtl).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnLastYearIdtl).Name = "btnLastYearIdtl";
		((Control)btnLastYearIdtl).Size = new Size(119, 37);
		((Control)btnLastYearIdtl).TabIndex = 1249;
		btnLastYearIdtl.Text = "&LastYear Idtl";
		((BaseButton)btnLastYearIdtl).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnLastYearIdtl).Visible = false;
		((BaseStyleControl)btnMainStkToBarDetl).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnMainStkToBarDetl).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnMainStkToBarDetl).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMainStkToBarDetl).Appearance.Options.UseForeColor = true;
		btnMainStkToBarDetl.ImageOptions.Location = (ImageLocation)1;
		((Control)btnMainStkToBarDetl).Location = new Point(1190, 280);
		((BaseControl)btnMainStkToBarDetl).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnMainStkToBarDetl).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMainStkToBarDetl).Name = "btnMainStkToBarDetl";
		((Control)btnMainStkToBarDetl).Size = new Size(119, 37);
		((Control)btnMainStkToBarDetl).TabIndex = 1250;
		btnMainStkToBarDetl.Text = "Stk to Vch Imp";
		((BaseControl)btnMainStkToBarDetl).ToolTip = "Main Stock to BarDetl Import";
		((BaseButton)btnMainStkToBarDetl).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnMainStkToBarDetl).Visible = false;
		((Control)lblStkBook).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblStkBook).ForeColor = Color.Black;
		lblStkBook.ImeMode = (ImeMode)0;
		((Control)lblStkBook).Location = new Point(1211, 153);
		((Control)lblStkBook).Name = "lblStkBook";
		((Control)lblStkBook).Size = new Size(54, 20);
		((Control)lblStkBook).TabIndex = 1251;
		lblStkBook.Text = "..";
		lblStkBook.TextAlign = (ContentAlignment)32;
		((Control)lblStkVch).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblStkVch).ForeColor = Color.Black;
		lblStkVch.ImeMode = (ImeMode)0;
		((Control)lblStkVch).Location = new Point(1211, 190);
		((Control)lblStkVch).Name = "lblStkVch";
		((Control)lblStkVch).Size = new Size(54, 20);
		((Control)lblStkVch).TabIndex = 1252;
		lblStkVch.Text = "..";
		lblStkVch.TextAlign = (ContentAlignment)32;
		((TextBoxBase)nLotTouch).BackColor = Color.White;
		((Control)nLotTouch).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLotTouch).Location = new Point(690, 39);
		((TextBoxBase)nLotTouch).MaxLength = 8;
		((Control)nLotTouch).Name = "nLotTouch";
		((TextBoxBase)nLotTouch).ReadOnly = true;
		((Control)nLotTouch).Size = new Size(44, 23);
		((Control)nLotTouch).TabIndex = 1253;
		nLotTouch.TextAlign = (HorizontalAlignment)1;
		((Control)nLotTouch).Visible = false;
		((TextBoxBase)nLotWestPrc).BackColor = Color.White;
		((Control)nLotWestPrc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLotWestPrc).Location = new Point(739, 39);
		((TextBoxBase)nLotWestPrc).MaxLength = 8;
		((Control)nLotWestPrc).Name = "nLotWestPrc";
		((TextBoxBase)nLotWestPrc).ReadOnly = true;
		((Control)nLotWestPrc).Size = new Size(45, 23);
		((Control)nLotWestPrc).TabIndex = 1254;
		nLotWestPrc.TextAlign = (HorizontalAlignment)1;
		((Control)nLotWestPrc).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)mDay);
		((Control)this).Controls.Add((Control)(object)nLotWestPrc);
		((Control)this).Controls.Add((Control)(object)nLotTouch);
		((Control)this).Controls.Add((Control)(object)lblStkVch);
		((Control)this).Controls.Add((Control)(object)lblStkBook);
		((Control)this).Controls.Add((Control)(object)btnMainStkToBarDetl);
		((Control)this).Controls.Add((Control)(object)btnLastYearIdtl);
		((Control)this).Controls.Add((Control)(object)btnJesonGen);
		((Control)this).Controls.Add((Control)(object)cboDataType);
		((Control)this).Controls.Add((Control)(object)lblDataType);
		((Control)this).Controls.Add((Control)(object)btnOldNewtag);
		((Control)this).Controls.Add((Control)(object)btnNewTagImg);
		((Control)this).Controls.Add((Control)(object)btnTagReNumber);
		((Control)this).Controls.Add((Control)(object)tLotNo);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)cboItType);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)nHmWt4);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)tHmId4);
		((Control)this).Controls.Add((Control)(object)nHmWt3);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)tHmId3);
		((Control)this).Controls.Add((Control)(object)nHmWt2);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nHmWt);
		((Control)this).Controls.Add((Control)(object)tHmId2);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)nPcs);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)tItName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)nLableSkip);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)BtnF1);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)TEXT_IDTL);
		((Control)this).Controls.Add((Control)(object)MSG_IDTL);
		((Control)this).Controls.Add((Control)(object)lblItem);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)MSG);
		((Control)this).Controls.Add((Control)(object)mTime);
		((Control)this).Controls.Add((Control)(object)mVchDate);
		((Control)this).Controls.Add((Control)(object)lblBDate);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)tVchNo);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "TR_TAG_OPBL";
		((Form)this).Text = "Tag Oppning";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	public TR_TAG_OPBL()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Expected O, but got Unknown
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Expected O, but got Unknown
		((Form)this).Load += TR_TAG_OPBL_Load;
		((Form)this).Deactivate += TR_TAG_OPBL_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_TAG_OPBL_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_TAG_OPBL_KeyDown);
		((Form)this).Activated += TR_TAG_OPBL_Activated;
		((Form)this).Closed += TR_TAG_OPBL_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_TAG_OPBL_KeyUp);
		Q = new Queue<string>();
		tagitObject = new TagitDevices();
		WeightPortOpen = false;
		StkSaleVchDel = false;
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		InitializeComponent();
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 41;
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
			mSG_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
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
				mSG_IDTL[0, 8] = "DmRemark";
				mSG_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_IDTL[9] = 0;
				mSG_IDTL[0, 9] = "DmSfNo";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[10] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[10] = 7;
				mSG_IDTL[0, 10] = "MotiPs";
				mSG_IDTL[11] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[11] = 7;
				mSG_IDTL[0, 11] = "MotiWt";
			}
			else
			{
				mSG_IDTL[10] = 0;
				mSG_IDTL[0, 10] = "MotiPs";
				mSG_IDTL[11] = 0;
				mSG_IDTL[0, 11] = "MotiWt";
			}
			mSG_IDTL[12] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "Pcs";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[13] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[13] = 7;
				mSG_IDTL[0, 13] = "PcsWt";
			}
			else
			{
				mSG_IDTL[13] = (int)Math.Round(800.0 * ColCon);
				mSG_IDTL[13] = 7;
				mSG_IDTL[0, 13] = "PcsWt";
			}
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "KrAWt";
			mSG_IDTL[15] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "KrA%";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0))
			{
				mSG_IDTL[16] = 0;
				mSG_IDTL[17] = 0;
			}
			else
			{
				mSG_IDTL[16] = (int)Math.Round(900.0 * ColCon);
				mSG_IDTL[16] = 7;
				mSG_IDTL[0, 16] = "KrWt";
				mSG_IDTL[17] = (int)Math.Round(800.0 * ColCon);
				mSG_IDTL[17] = 7;
				mSG_IDTL[0, 17] = "KrLs%";
			}
			mSG_IDTL[18] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[18] = 7;
			mSG_IDTL[0, 18] = "KrLsWt";
			mSG_IDTL[19] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "Weight";
			mSG_IDTL[20] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[20] = 7;
			mSG_IDTL[0, 20] = "Con%";
			mSG_IDTL[21] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[21] = 3;
			mSG_IDTL[0, 21] = "P/W";
			mSG_IDTL[22] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[22] = 7;
			mSG_IDTL[0, 22] = "Rate";
			mSG_IDTL[23] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[23] = 7;
			mSG_IDTL[0, 23] = "ItAmt";
			mSG_IDTL[24] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[24] = 7;
			mSG_IDTL[0, 24] = "Disc%";
			mSG_IDTL[25] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[25] = 7;
			mSG_IDTL[0, 25] = "DiscAmt";
			mSG_IDTL[26] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[26] = 7;
			mSG_IDTL[0, 26] = "KrCon%";
			mSG_IDTL[27] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[27] = 3;
			mSG_IDTL[0, 27] = "KrP/W";
			mSG_IDTL[28] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[28] = 7;
			mSG_IDTL[0, 28] = "PRate";
			mSG_IDTL[29] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[29] = 7;
			mSG_IDTL[0, 29] = "PAmt";
			mSG_IDTL[30] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[30] = 7;
			mSG_IDTL[0, 30] = "KrLRate";
			mSG_IDTL[31] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[31] = 7;
			mSG_IDTL[0, 31] = "KrLAmt";
			mSG_IDTL[32] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[32] = 7;
			mSG_IDTL[0, 32] = "LbrRate";
			mSG_IDTL[33] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[33] = 7;
			mSG_IDTL[0, 33] = "LbrAmt";
			mSG_IDTL[34] = (int)Math.Round(1050.0 * ColCon);
			mSG_IDTL[34] = 7;
			mSG_IDTL[0, 34] = "NetAmt";
			mSG_IDTL[35] = 0;
			mSG_IDTL[0, 35] = "ConWt";
			mSG_IDTL[36] = 0;
			mSG_IDTL[0, 36] = "KrConWt";
			mSG_IDTL[37] = 0;
			mSG_IDTL[0, 37] = "ItType";
			mSG_IDTL[38] = 0;
			mSG_IDTL[0, 38] = "RowSrNo";
			mSG_IDTL[39] = 0;
			mSG_IDTL[0, 39] = "OldKrWt";
			mSG_IDTL[40] = 0;
			mSG_IDTL[0, 40] = "OldGrWt";
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
		mSG_IDTL[mSG_IDTL.Row, 38] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 62]));
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
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e9: Invalid comparison between Unknown and I4
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_021e: Invalid comparison between Unknown and I4
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Invalid comparison between Unknown and I4
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Invalid comparison between Unknown and I4
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b0: Invalid comparison between Unknown and I4
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((Operators.CompareString(UserDelete, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				return;
			}
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = DtIdtl.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 38])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
				if (mSG_IDTL.Col < 34)
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
							MSG.Col = 15;
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
									mSG_IDTL[mSG_IDTL.Row, 37] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 20]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						if (Operators.CompareString(MSG[MSG.Row, 69], "A", false) != 0)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 34]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
						}
						else if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 22]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))) && Operators.CompareString(mSG_IDTL[mSG_IDTL.Row, 21], "", false) == 0)
						{
							mSG_IDTL[mSG_IDTL.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""));
						}
						break;
					case 3:
					{
						if (Operators.CompareString(TEXT_IDTL.Text, "", false) == 0 || mSG_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_IDTL.Text + "'";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable.Rows.Count == 0)
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
						mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_CODE"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 22]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					}
					case 13:
						if (mSG_IDTL[14] > 0)
						{
							if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
							{
								mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
							}
						}
						else if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
						}
						break;
					case 19:
						if (!((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) == 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) == 0.0)))
						{
						}
						break;
					case 34:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 34] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
							mSG_IDTL[mSG_IDTL.Row, 34] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							((Control)TEXT_IDTL).Visible = false;
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
			case 21:
			case 27:
				((TextBoxBase)TEXT_IDTL).MaxLength = 1;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 10:
			case 12:
				((TextBoxBase)TEXT_IDTL).MaxLength = 6;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
				break;
			case 20:
			case 26:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
				break;
			case 15:
			case 17:
			case 22:
			case 23:
			case 24:
			case 25:
			case 28:
			case 29:
			case 30:
			case 31:
			case 32:
			case 33:
			case 34:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
				break;
			case 11:
			case 14:
			case 16:
			case 18:
			case 19:
			case 35:
			case 36:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
				break;
			case 13:
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
		case 7:
		case 8:
		case 9:
		case 21:
		case 27:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
			break;
		case 10:
		case 12:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 20:
		case 26:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 15:
		case 17:
		case 22:
		case 23:
		case 24:
		case 25:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 34:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 11:
		case 14:
		case 16:
		case 18:
		case 19:
		case 35:
		case 36:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 13:
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
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0))
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) / Conversion.Val(mSG_IDTL[CRow, 10])), "0.000000");
			}
			else
			{
				mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 11]) / Conversion.Val(mSG_IDTL[CRow, 10])), "0.0000");
			}
		}
		if (mSG_IDTL[14] > 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0))
			{
				mSG_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 13])), "0.000");
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15]) / 100.0), "0.000");
			}
			else if (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
			}
			if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
			{
				mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 17]) / 100.0), "0.000");
				mSG_IDTL[CRow, 40] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 14]) != Conversion.Val(mSG_IDTL[CRow, 39])) & (Conversion.Val(mSG_IDTL[CRow, 19]) == 0.0))
			{
				mSG_IDTL[CRow, 39] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
				mSG_IDTL[CRow, 19] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 19]) != Conversion.Val(mSG_IDTL[CRow, 40])) & (Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0))
			{
				mSG_IDTL[CRow, 40] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
				mSG_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0))
			{
				mSG_IDTL[CRow, 35] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 20])), "0.000");
			}
			else
			{
				mSG_IDTL[CRow, 35] = Conversions.ToString(0);
			}
			if (Conversion.Val((object)mSG_IDTL[26]) > 0.0)
			{
				if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 26]) != 0.0))
				{
					mSG_IDTL[CRow, 36] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 26])), "0.000");
				}
				else
				{
					mSG_IDTL[CRow, 36] = Conversions.ToString(0);
				}
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0))
			{
				mSG_IDTL[CRow, 36] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 20])), "0.000");
			}
			else
			{
				mSG_IDTL[CRow, 36] = Conversions.ToString(0);
			}
		}
		else
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 13])), "0.000");
			}
			if (mSG_IDTL[18] > 0)
			{
				if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
				{
					mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 17]) / 100.0), "0.000");
					mSG_IDTL[CRow, 40] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
				}
				mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) - Conversion.Val(mSG_IDTL[CRow, 18])), "0.000");
			}
			else
			{
				if (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
				{
					mSG_IDTL[CRow, 19] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 17]) / 100.0), "0.000");
					mSG_IDTL[CRow, 40] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
				}
				if (Conversion.Val(mSG_IDTL[CRow, 16]) != Conversion.Val(mSG_IDTL[CRow, 39]))
				{
					mSG_IDTL[CRow, 39] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
					mSG_IDTL[CRow, 19] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
				}
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 19]) != Conversion.Val(mSG_IDTL[CRow, 40])) & (Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0))
			{
				mSG_IDTL[CRow, 40] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
				mSG_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0))
			{
				mSG_IDTL[CRow, 35] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 20])), "0.000");
			}
			else
			{
				mSG_IDTL[CRow, 35] = Conversions.ToString(0);
			}
			if (Conversion.Val((object)mSG_IDTL[26]) > 0.0)
			{
				if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 26]) != 0.0))
				{
					mSG_IDTL[CRow, 36] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 26])), "0.000");
				}
				else
				{
					mSG_IDTL[CRow, 36] = Conversions.ToString(0);
				}
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 20]) != 0.0))
			{
				mSG_IDTL[CRow, 36] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 20])), "0.000");
			}
			else
			{
				mSG_IDTL[CRow, 36] = Conversions.ToString(0);
			}
			if ((Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0))
			{
				mSG_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 19]), "0.000");
			}
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 21], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 19]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 22]) != 0.0))
			{
				mSG_IDTL[CRow, 23] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 22]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 22]) != 0.0))
			{
				mSG_IDTL[CRow, 23] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 22]) * Conversion.Val(mSG_IDTL[CRow, 19])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 21], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 22])))) != 0)
		{
			mSG_IDTL[CRow, 23] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 22]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 22]) != 0.0)
		{
			mSG_IDTL[CRow, 23] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 22]) * Conversion.Val(mSG_IDTL[CRow, 19])), "0.00");
		}
		if (Conversion.Val((object)mSG_IDTL[27]) > 0.0)
		{
			if (Operators.CompareString(mSG_IDTL[CRow, 27], "", false) == 0)
			{
				if ((Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0))
				{
					mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
				}
				else if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0))
				{
					mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
				}
			}
			else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 27], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 28])))) != 0)
			{
				mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0)
			{
				mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
			}
		}
		else if (Operators.CompareString(mSG_IDTL[CRow, 21], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0))
			{
				mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0))
			{
				mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 21], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 28])))) != 0)
		{
			mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 28]) != 0.0)
		{
			mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 28]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
		}
		if (Conversion.Val((object)mSG_IDTL[24]) > 0.0 && ((Conversion.Val(mSG_IDTL[CRow, 24]) != 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 23]) != 0.0)))
		{
			mSG_IDTL[mSG_IDTL.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 23]) * Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 24]) / 100.0, 0), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 32]) != 0.0)
		{
			mSG_IDTL[CRow, 33] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 32]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 30]) != 0.0)
		{
			mSG_IDTL[CRow, 31] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 30]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 23]) + Conversion.Val(mSG_IDTL[CRow, 33]) != 0.0)
		{
			mSG_IDTL[CRow, 34] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) - Conversion.Val(mSG_IDTL[CRow, 25]) + Conversion.Val(mSG_IDTL[CRow, 33])), "0.00");
		}
		checked
		{
			int num5 = MSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 35]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 36]);
				num += Conversion.Val(mSG_IDTL[DC_Main.M, 34]);
				num2 = num2 + Conversion.Val(mSG_IDTL[DC_Main.M, 29]) + Conversion.Val(mSG_IDTL[DC_Main.M, 31]);
				if ((Operators.CompareString(mSG_IDTL[DC_Main.M, 1], "WX", false) == 0) & (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0))
				{
					MSG[MSG.Row, 59] = Strings.Format((object)Conversion.Val(mSG_IDTL[DC_Main.M, 19]), "0.000");
				}
				DC_Main.M++;
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 15] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 16] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 14]) - Conversion.Val(MSG[MSG.Row, 15])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 17] = Strings.Format((object)num4, "0.000");
				MSG[MSG.Row, 18] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 14]) - Conversion.Val(MSG[MSG.Row, 17])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 34] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 16] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 14]) - num3), "0.000");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 37] = Strings.Format((object)num2, "0.00");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])) == Conversion.Val(mSG_IDTL[CRow, 38])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
						DtIdtl.Rows[i][12] = mSG_IDTL[CRow, 12];
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
						DtIdtl.Rows[i][24] = mSG_IDTL[CRow, 24];
						DtIdtl.Rows[i][25] = mSG_IDTL[CRow, 25];
						DtIdtl.Rows[i][26] = mSG_IDTL[CRow, 26];
						DtIdtl.Rows[i][27] = mSG_IDTL[CRow, 27];
						DtIdtl.Rows[i][28] = mSG_IDTL[CRow, 28];
						DtIdtl.Rows[i][29] = mSG_IDTL[CRow, 29];
						DtIdtl.Rows[i][30] = mSG_IDTL[CRow, 30];
						DtIdtl.Rows[i][31] = mSG_IDTL[CRow, 31];
						DtIdtl.Rows[i][32] = mSG_IDTL[CRow, 32];
						DtIdtl.Rows[i][33] = mSG_IDTL[CRow, 33];
						DtIdtl.Rows[i][34] = mSG_IDTL[CRow, 34];
						DtIdtl.Rows[i][35] = mSG_IDTL[CRow, 35];
						DtIdtl.Rows[i][36] = mSG_IDTL[CRow, 36];
						DtIdtl.Rows[i][37] = mSG_IDTL[CRow, 37];
						DtIdtl.Rows[i][38] = mSG_IDTL[CRow, 38];
						DtIdtl.Rows[i][39] = mSG_IDTL[CRow, 39];
						DtIdtl.Rows[i][40] = mSG_IDTL[CRow, 40];
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
					dr[12] = mSG_IDTL[CRow, 12];
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
					dr[24] = mSG_IDTL[CRow, 24];
					dr[25] = mSG_IDTL[CRow, 25];
					dr[26] = mSG_IDTL[CRow, 26];
					dr[27] = mSG_IDTL[CRow, 27];
					dr[28] = mSG_IDTL[CRow, 28];
					dr[29] = mSG_IDTL[CRow, 29];
					dr[30] = mSG_IDTL[CRow, 30];
					dr[31] = mSG_IDTL[CRow, 31];
					dr[32] = mSG_IDTL[CRow, 32];
					dr[33] = mSG_IDTL[CRow, 33];
					dr[34] = mSG_IDTL[CRow, 34];
					dr[35] = mSG_IDTL[CRow, 35];
					dr[36] = mSG_IDTL[CRow, 36];
					dr[37] = mSG_IDTL[CRow, 37];
					dr[38] = mSG_IDTL[CRow, 38];
					dr[39] = mSG_IDTL[CRow, 39];
					dr[40] = mSG_IDTL[CRow, 40];
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
		mSG.Cols = 112;
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
			mSG[3] = (int)Math.Round(900.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItCode";
			mSG[5] = (int)Math.Round(1200.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "TagNo";
			mSG[6] = (int)Math.Round(900.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Counter";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
			{
				mSG[1] = (int)Math.Round(1200.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "Design";
				mSG[7] = 0;
			}
			else
			{
				mSG[1] = 0;
				mSG[7] = (int)Math.Round(1300.0 * ColCon);
				mSG[7] = 0;
				mSG[0, 7] = "Design";
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG[8] = (int)Math.Round(1200.0 * ColCon);
				mSG[8] = 0;
				mSG[0, 8] = "Style";
			}
			else
			{
				mSG[8] = 0;
			}
			mSG[9] = (int)Math.Round(1100.0 * ColCon);
			mSG[9] = 0;
			mSG[0, 9] = "Color";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK050NEVK", false) == 0)
			{
				mSG[10] = (int)Math.Round(1200.0 * ColCon);
				mSG[10] = 0;
				mSG[0, 10] = "Size";
			}
			else
			{
				mSG[10] = (int)Math.Round(800.0 * ColCon);
				mSG[10] = 0;
				mSG[0, 10] = "Size";
			}
			mSG[11] = (int)Math.Round(900.0 * ColCon);
			mSG[11] = 0;
			mSG[0, 11] = "HuId";
			mSG[12] = (int)Math.Round(800.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "BagWt";
			mSG[13] = (int)Math.Round(700.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Pcs";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "GrWt";
			mSG[15] = (int)Math.Round(900.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "LsWt";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "NetWt";
			mSG[17] = (int)Math.Round(1000.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "KrOthWt";
			mSG[18] = (int)Math.Round(1000.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "KrNwt";
			mSG[19] = (int)Math.Round(1000.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "KrGht%";
			mSG[20] = (int)Math.Round(1000.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "KrGht";
			if ((Operators.CompareString(DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
			{
				mSG[21] = 0;
				mSG[22] = 0;
				mSG[23] = 0;
			}
			else
			{
				mSG[21] = (int)Math.Round(900.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "KrTouch";
				mSG[22] = (int)Math.Round(900.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "KrWst%";
				mSG[23] = (int)Math.Round(900.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "KrFine";
			}
			mSG[25] = (int)Math.Round(750.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Ght%";
			mSG[26] = (int)Math.Round(850.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "GhtWt";
			mSG[27] = (int)Math.Round(850.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "Touch";
			mSG[28] = (int)Math.Round(850.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "West%";
			mSG[29] = (int)Math.Round(1000.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "Fine";
			mSG[24] = (int)Math.Round(800.0 * ColCon);
			mSG[24] = 3;
			mSG[0, 24] = "LCode";
			mSG[30] = (int)Math.Round(800.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Lbr%";
			mSG[31] = (int)Math.Round(800.0 * ColCon);
			mSG[31] = 3;
			mSG[0, 31] = "LType";
			mSG[32] = (int)Math.Round(900.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "LbrRate";
			mSG[33] = (int)Math.Round(950.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "LbrAmt";
			mSG[34] = (int)Math.Round(1000.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "OthAmt";
			mSG[35] = (int)Math.Round(900.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrLRate";
			mSG[36] = (int)Math.Round(1000.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrLAmt";
			mSG[37] = (int)Math.Round(1100.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrOthAmt";
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
			{
				mSG[17] = 0;
				mSG[18] = 0;
				mSG[35] = 0;
				mSG[36] = 0;
				mSG[37] = 0;
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
			{
				mSG[38] = (int)Math.Round(700.0 * ColCon);
				mSG[38] = 3;
				mSG[0, 38] = "SlType";
				mSG[39] = (int)Math.Round(1000.0 * ColCon);
				mSG[39] = 7;
				mSG[0, 39] = "OthRate";
				mSG[40] = (int)Math.Round(1000.0 * ColCon);
				mSG[40] = 7;
				mSG[0, 40] = "OthFine";
				mSG[41] = (int)Math.Round(1000.0 * ColCon);
				mSG[41] = 7;
				mSG[0, 41] = "TotFine";
				mSG[42] = (int)Math.Round(1000.0 * ColCon);
				mSG[42] = 7;
				mSG[0, 42] = "GwtTouch";
			}
			else
			{
				mSG[38] = 0;
				mSG[39] = 0;
				mSG[40] = 0;
				mSG[41] = 0;
				mSG[42] = 0;
			}
			mSG[43] = (int)Math.Round(1000.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "ItRate";
			mSG[44] = (int)Math.Round(1100.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "ItAmt";
			mSG[45] = (int)Math.Round(1000.0 * ColCon);
			mSG[45] = 7;
			mSG[0, 45] = "PrCost";
			mSG[46] = (int)Math.Round(1100.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "TagCost";
			mSG[47] = (int)Math.Round(925.0 * ColCon);
			mSG[47] = 7;
			mSG[0, 47] = "MMargin";
			mSG[48] = (int)Math.Round(1000.0 * ColCon);
			mSG[48] = 7;
			mSG[0, 48] = "MainMrp";
			mSG[49] = (int)Math.Round(800.0 * ColCon);
			mSG[49] = 7;
			mSG[0, 49] = "Margin";
			mSG[50] = (int)Math.Round(1000.0 * ColCon);
			mSG[50] = 7;
			mSG[0, 50] = "Mrp";
			mSG[51] = (int)Math.Round(750.0 * ColCon);
			mSG[51] = 3;
			mSG[0, 51] = "Image";
			mSG[52] = (int)Math.Round(2200.0 * ColCon);
			mSG[52] = 0;
			mSG[0, 52] = "Remark";
			mSG[53] = (int)Math.Round(800.0 * ColCon);
			mSG[53] = 7;
			mSG[0, 53] = "KrCod";
			if (DC_Main.MsTagVchSrnoUpdate)
			{
				mSG[67] = (int)Math.Round(1500.0 * ColCon);
				mSG[67] = 3;
				mSG[0, 67] = "TagId";
			}
			else
			{
				mSG[67] = 0;
			}
			if (Operators.CompareString(FormMainBook, "JDTR TAG", false) != 0)
			{
				mSG[54] = 0;
				mSG[55] = 0;
				mSG[56] = 0;
				mSG[57] = 0;
				mSG[58] = 0;
				mSG[59] = 0;
				mSG[60] = 0;
			}
			mSG[61] = 0;
			mSG[62] = 0;
			mSG[63] = 0;
			mSG[64] = 0;
			mSG[65] = 0;
			mSG[66] = 0;
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
			mSG[82] = 0;
			mSG[83] = 0;
			mSG[84] = 0;
			mSG[85] = 0;
			mSG[86] = 0;
			mSG[87] = 0;
			mSG[88] = 0;
			mSG[89] = 0;
			mSG[4] = 0;
			mSG[90] = 0;
			mSG[91] = 0;
			mSG[92] = 0;
			mSG[93] = 0;
			mSG[94] = 0;
			mSG[95] = 0;
			mSG[96] = 0;
			mSG[97] = 0;
			mSG[98] = 0;
			mSG[99] = 0;
			mSG[100] = 0;
			mSG[101] = 0;
			mSG[102] = 0;
			mSG[103] = 0;
			mSG[104] = 0;
			mSG[105] = 0;
			mSG[106] = 0;
			mSG[107] = 0;
			mSG[108] = 0;
			mSG[109] = 0;
			mSG[110] = 0;
			mSG[111] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.MsMfgType, "B", false) == 0) | (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0))
			{
				mSG[4] = (int)Math.Round(900.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			if ((Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
			{
				mSG[2] = (int)Math.Round(900.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "MfgOrd";
				mSG[4] = (int)Math.Round(0.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			else if ((Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
			{
				mSG[2] = (int)Math.Round(900.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "MfgNo";
				mSG[4] = (int)Math.Round(0.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			else
			{
				mSG[2] = (int)Math.Round(0.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "MfgOrd";
			}
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			if ((Operators.CompareString(FormMainBook, "MFG TAG", false) == 0) & (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0))
			{
				mSG[4] = (int)Math.Round(900.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			if ((Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
			{
				mSG[4] = 0;
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
			}
			if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0)
			{
				mSG[4] = (int)Math.Round(900.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "OrdNo";
				mSG[17] = (int)Math.Round(1000.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "KrOthWt";
				mSG[18] = (int)Math.Round(1000.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "KrNwt";
				mSG[21] = (int)Math.Round(900.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "KrTouch";
				mSG[22] = (int)Math.Round(900.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "KrWst%";
				mSG[23] = (int)Math.Round(900.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "KrFine";
				mSG[54] = (int)Math.Round(1000.0 * ColCon);
				mSG[54] = 7;
				mSG[0, 54] = "JdtWt";
				mSG[55] = (int)Math.Round(900.0 * ColCon);
				mSG[55] = 7;
				mSG[0, 55] = "JGhatWt";
				mSG[56] = (int)Math.Round(1000.0 * ColCon);
				mSG[56] = 7;
				mSG[0, 56] = "Kundan";
				mSG[57] = (int)Math.Round(0.0 * ColCon);
				mSG[57] = 7;
				mSG[0, 57] = "KndTch%";
				mSG[58] = (int)Math.Round(0.0 * ColCon);
				mSG[58] = 7;
				mSG[0, 58] = "KndNwt";
				mSG[59] = (int)Math.Round(1000.0 * ColCon);
				mSG[59] = 7;
				mSG[0, 59] = "Wax";
				mSG[60] = (int)Math.Round(1000.0 * ColCon);
				mSG[60] = 7;
				mSG[0, 60] = "KrWax";
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
				{
					mSG[7] = 0;
				}
			}
			MsgLastCol = 53;
			DC_Main.M = 54;
			while (DC_Main.M <= 45)
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[45] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 45;
					break;
				}
				DC_Main.M++;
			}
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
				mSG_TOT[0, 7] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.000");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.000");
					mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.00");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
					mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.00");
					mSG_TOT[0, 46] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 46]) + Conversion.Val(MSG[DC_Main.M, 46]))), "0.00");
					mSG_TOT[0, 50] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 50]) + Conversion.Val(MSG[DC_Main.M, 50]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.000");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.000");
					mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.00");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");
					mSG_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 45]) + Conversion.Val(MSG[DC_Main.M, 45]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 50]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		checked
		{
			mSG.Row = mSG.Rows - 1;
			mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
			mSG[mSG.Row, 13] = Conversions.ToString(1);
			mSG[mSG.Row, 31] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 62] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 62] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 62]) + 1.0);
			}
			int num = (int)Math.Round(Conversion.Val(mSG[mSG.Rows - 2, 62]) + 1.0);
			mSG[mSG.Row, 69] = "A";
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM290NAPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM446NAPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK095NAAK", false) == 0))
			{
				mSG[mSG.Row, 89] = cboDataType.Text;
			}
			else
			{
				mSG[mSG.Row, 89] = "A";
			}
			mSG[mSG.Row, 51] = "N";
			mSG[mSG.Row, 81] = "N";
			mSG[mSG.Row, 100] = "N";
			mSG[mSG.Row, 101] = "N";
			mSG[mSG.Row, 38] = "N";
			if ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (Conversion.Val(nLotTouch.Text) != 0.0))
			{
				mSG[mSG.Row, 21] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");
				mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");
				mSG[mSG.Row, 109] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");
				mSG[mSG.Row, 110] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");
			}
			MSG_IDTL_CLEAR();
			if (Operators.CompareString(MsVchSrno, "", false) == 0)
			{
				DC_Main.RsQry = "Select Max(TAG_SRNO) AS SrNo FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(TAG_SRNO) = 6 Having Max(TAG_SRNO) > 0";
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
			mSG[mSG.Row, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MsVchSrno;
			if (mSG.Row > 1)
			{
				if (mSG.Col == 3)
				{
					TEXT_ENTRY.Text = mSG[mSG.Row - 1, 3];
				}
				DataView dataView = new DataView(DC_Main.RsClDetl);
				if (dataView.Count > 0)
				{
					int num2 = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						dataView.RowFilter = "BOOK_NAME = 'TAG_DETL' AND COL_NEW_NAME = '" + mSG[0, DC_Main.M] + "'";
						if (dataView.Count > 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["COL_RPT"], (object)"Y", false))
						{
							mSG[mSG.Row, DC_Main.M] = mSG[mSG.Row - 1, DC_Main.M];
						}
						DC_Main.M++;
					}
				}
			}
			mSG = null;
		}
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
		UpDown = false;
		MsgOldRow = 0;
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
			switch (MSG.Col)
			{
			case 0:
			case 53:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 69], "E", false) == 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 2:
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 67:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 52:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 150;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 24:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 4;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
			case 7:
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 9:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 11:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 31:
			case 38:
			case 51:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 28:
			case 30:
			case 32:
			case 33:
			case 50:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (Operators.CompareString(mSG[mSG.Row, 24], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 13:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 21:
			case 22:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0 && Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 25:
			case 27:
			case 39:
			case 42:
			case 47:
			case 48:
			case 49:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 34:
			case 35:
			case 36:
			case 37:
			case 43:
			case 44:
			case 45:
			case 46:
			case 57:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 12:
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
			case 19:
			case 20:
			case 26:
			case 29:
			case 40:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 54:
			case 55:
			case 56:
			case 58:
			case 59:
			case 60:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
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
		case 3:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if ((Operators.CompareString(mSG[mSG.Row, 5], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 3], "", false) != 0))
			{
				NewTagNo(mSG.Row);
			}
			break;
		case 0:
		case 1:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
		case 10:
		case 11:
		case 24:
		case 31:
		case 38:
		case 51:
		case 52:
		case 53:
		case 67:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 13:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 21:
		case 22:
		case 25:
		case 27:
		case 28:
		case 30:
		case 47:
		case 48:
		case 49:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 39:
		case 42:
		case 43:
		case 44:
		case 45:
		case 46:
		case 50:
		case 57:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 15:
		case 17:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 12:
		case 14:
		case 16:
		case 18:
		case 19:
		case 20:
		case 23:
		case 26:
		case 29:
		case 40:
		case 41:
		case 54:
		case 55:
		case 56:
		case 58:
		case 59:
		case 60:
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
		string text = default(string);
		string text2 = default(string);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		double num5 = default(double);
		double num7 = default(double);
		string text3 = default(string);
		int num8 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					double num6;
					switch (try0001_dispatch)
					{
					default:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_000c;
					case 11891:
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
								goto IL_000c;
							case 3:
								goto IL_0015;
							case 4:
								goto IL_0033;
							case 5:
								goto IL_0059;
							case 6:
								goto IL_008c;
							case 7:
								goto IL_00b2;
							case 8:
								goto IL_00e5;
							case 9:
								goto IL_010b;
							case 10:
							case 11:
								goto IL_0141;
							case 12:
								goto IL_0178;
							case 13:
								goto IL_01ac;
							case 14:
								goto IL_01f4;
							case 15:
								goto IL_023c;
							case 16:
							case 17:
								goto IL_0256;
							case 18:
								goto IL_02a2;
							case 19:
							case 20:
								goto IL_02ec;
							case 21:
								goto IL_02ff;
							case 22:
								goto IL_0323;
							case 23:
								goto IL_033b;
							case 24:
							case 25:
							case 26:
								goto IL_0373;
							case 27:
								goto IL_03aa;
							case 28:
								goto IL_03de;
							case 29:
								goto IL_043e;
							case 31:
								goto IL_04bc;
							case 30:
							case 32:
							case 33:
								goto IL_04f1;
							case 34:
							case 35:
								goto IL_050b;
							case 36:
								goto IL_0557;
							case 37:
							case 38:
								goto IL_05ab;
							case 39:
								goto IL_05e2;
							case 40:
								goto IL_0616;
							case 41:
								goto IL_0676;
							case 42:
							case 43:
							case 44:
								goto IL_06f4;
							case 45:
								goto IL_072b;
							case 46:
								goto IL_075f;
							case 47:
								goto IL_07bf;
							case 48:
							case 49:
							case 50:
								goto IL_083d;
							case 51:
								goto IL_0878;
							case 52:
							case 53:
								goto IL_08c2;
							case 54:
								goto IL_091f;
							case 55:
							case 56:
								goto IL_099b;
							case 57:
								goto IL_09e7;
							case 59:
								goto IL_0a36;
							case 60:
								goto IL_0a61;
							case 61:
								goto IL_0a88;
							case 63:
								goto IL_0ac0;
							case 58:
							case 62:
							case 64:
							case 65:
							case 66:
								goto IL_0b0a;
							case 67:
								goto IL_0b41;
							case 68:
								goto IL_0b75;
							case 69:
								goto IL_0bd5;
							case 71:
								goto IL_0c53;
							case 70:
							case 72:
							case 73:
							case 74:
								goto IL_0c8a;
							case 75:
								goto IL_0ca6;
							case 76:
							case 77:
								goto IL_0cc0;
							case 78:
								goto IL_0cf7;
							case 79:
								goto IL_0d2b;
							case 80:
								goto IL_0d8b;
							case 81:
							case 82:
							case 83:
								goto IL_0e09;
							case 84:
								goto IL_0e40;
							case 85:
								goto IL_0e74;
							case 86:
								goto IL_0ed4;
							case 87:
							case 88:
							case 89:
								goto IL_0f52;
							case 90:
								goto IL_0f8d;
							case 91:
							case 92:
								goto IL_0fd7;
							case 93:
								goto IL_1034;
							case 94:
							case 95:
								goto IL_10b0;
							case 96:
								goto IL_10e7;
							case 97:
								goto IL_111b;
							case 98:
							case 99:
								goto IL_1197;
							case 100:
								goto IL_11d8;
							case 101:
								goto IL_11ff;
							case 102:
								goto IL_1233;
							case 103:
							case 104:
								goto IL_127d;
							case 105:
								goto IL_12a9;
							case 106:
								goto IL_12bf;
							case 107:
							case 108:
								goto IL_12ed;
							case 109:
								goto IL_131b;
							case 111:
								goto IL_1364;
							case 113:
								goto IL_13b8;
							case 114:
								goto IL_13d1;
							case 116:
								goto IL_141e;
							case 117:
								goto IL_1437;
							case 119:
								goto IL_1481;
							case 110:
							case 112:
							case 115:
							case 118:
							case 120:
							case 121:
							case 122:
								goto IL_14c3;
							case 123:
								goto IL_14f1;
							case 125:
								goto IL_153a;
							case 127:
								goto IL_158e;
							case 128:
								goto IL_15aa;
							case 130:
								goto IL_15ff;
							case 133:
								goto IL_166b;
							case 135:
								goto IL_16dd;
							case 124:
							case 126:
							case 129:
							case 131:
							case 132:
							case 134:
							case 136:
							case 137:
							case 138:
								goto IL_1733;
							case 139:
								goto IL_1786;
							case 141:
								goto IL_17d2;
							case 143:
								goto IL_1829;
							case 144:
								goto IL_1848;
							case 146:
								goto IL_189d;
							case 149:
								goto IL_1909;
							case 151:
								goto IL_197b;
							case 140:
							case 142:
							case 145:
							case 147:
							case 148:
							case 150:
							case 152:
							case 153:
							case 154:
								goto IL_19d1;
							case 155:
								goto IL_1a07;
							case 156:
								goto IL_1a5f;
							case 157:
								goto IL_1abe;
							case 158:
							case 159:
							case 160:
								goto IL_1b21;
							case 161:
								goto IL_1b6b;
							case 162:
								goto IL_1bca;
							case 163:
							case 164:
								goto IL_1c2b;
							case 165:
								goto IL_1c87;
							case 166:
								goto IL_1cbe;
							case 167:
							case 168:
								goto IL_1d24;
							case 169:
								goto IL_1d35;
							case 170:
								goto IL_1d84;
							case 171:
								goto IL_1dbe;
							case 172:
								goto IL_1df5;
							case 173:
							case 174:
							case 175:
								goto IL_1e5d;
							case 176:
								goto IL_1e77;
							case 177:
								goto IL_1ed3;
							case 178:
								goto IL_1f0a;
							case 179:
							case 180:
								goto IL_1f70;
							case 181:
								goto IL_1fcc;
							case 182:
								goto IL_2003;
							case 183:
							case 184:
							case 185:
								goto IL_206b;
							case 186:
								goto IL_208d;
							case 187:
								goto IL_20a2;
							case 188:
								goto IL_20af;
							case 189:
							case 190:
								goto IL_20be;
							case 191:
								goto IL_20e9;
							case 192:
								goto IL_2119;
							case 193:
								goto IL_2144;
							case 194:
								goto IL_219d;
							case 195:
								goto IL_21e2;
							case 196:
								goto IL_2212;
							case 197:
								goto IL_2249;
							case 199:
								goto IL_22a1;
							case 200:
								goto IL_22cb;
							case 201:
								goto IL_22f5;
							case 206:
								goto IL_2352;
							case 207:
								goto IL_237c;
							case 209:
								goto IL_239d;
							case 210:
								goto IL_23ec;
							case 198:
							case 202:
							case 203:
							case 204:
							case 205:
							case 208:
							case 211:
							case 212:
							case 213:
							case 214:
								goto IL_2441;
							case 215:
								goto IL_248c;
							case 216:
								goto IL_24b4;
							case 218:
								goto IL_250d;
							case 221:
								goto IL_256a;
							case 222:
								goto IL_259a;
							case 223:
								goto IL_25e5;
							case 224:
								goto IL_260d;
							case 226:
								goto IL_2666;
							case 217:
							case 219:
							case 220:
							case 225:
							case 227:
							case 228:
							case 229:
							case 230:
								goto IL_26bf;
							case 231:
								goto IL_26d0;
							case 232:
								goto IL_26dd;
							case 233:
								goto IL_2720;
							case 234:
								goto IL_2739;
							case 235:
								goto IL_2754;
							case 237:
								goto IL_2769;
							case 238:
								goto IL_2785;
							case 240:
								goto IL_279e;
							case 241:
								goto IL_27bb;
							case 243:
								goto IL_27d4;
							case 244:
								goto IL_27f1;
							case 246:
								goto IL_280a;
							case 247:
								goto IL_2827;
							case 249:
								goto IL_2840;
							case 250:
								goto IL_285d;
							case 252:
								goto IL_2876;
							case 253:
								goto IL_2893;
							case 255:
								goto IL_28ac;
							case 256:
								goto IL_28c9;
							case 258:
								goto IL_28e2;
							case 259:
								goto IL_28ff;
							case 261:
								goto IL_2918;
							case 262:
								goto IL_2935;
							case 264:
								goto IL_294b;
							case 265:
								goto IL_2969;
							case 267:
								goto IL_297f;
							case 268:
								goto IL_299c;
							case 236:
							case 239:
							case 242:
							case 245:
							case 248:
							case 251:
							case 254:
							case 257:
							case 260:
							case 263:
							case 266:
							case 269:
								goto IL_29b1;
							case 270:
								goto IL_29cf;
							case 271:
								goto IL_29e6;
							case 272:
							case 273:
							case 274:
								goto IL_29ff;
							case 275:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 276:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_299c:
						num2 = 268;
						text += "U";
						goto IL_29b1;
						IL_29b1:
						num2 = 269;
						DC_Main.M++;
						goto IL_29c3;
						IL_297f:
						num2 = 267;
						if (Operators.CompareString(text2, Conversions.ToString(0), false) == 0)
						{
							goto IL_299c;
						}
						goto IL_29b1;
						IL_29ff:
						val = null;
						break;
						IL_000c:
						num2 = 2;
						val = MSG;
						goto IL_0015;
						IL_0015:
						num2 = 3;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ038NSKJ", false) == 0)
						{
							goto IL_0033;
						}
						goto IL_0141;
						IL_0033:
						num2 = 4;
						if (Conversion.Val(val[val.Row, 27]) == 0.0)
						{
							goto IL_0059;
						}
						goto IL_008c;
						IL_0059:
						num2 = 5;
						val[val.Row, 27] = Strings.Format((object)Conversion.Val(val[val.Row, 21]), "0.00");
						goto IL_008c;
						IL_008c:
						num2 = 6;
						if (Conversion.Val(val[val.Row, 28]) == 0.0)
						{
							goto IL_00b2;
						}
						goto IL_00e5;
						IL_00b2:
						num2 = 7;
						val[val.Row, 28] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
						goto IL_00e5;
						IL_00e5:
						num2 = 8;
						if (Conversion.Val(val[val.Row, 29]) == 0.0)
						{
							goto IL_010b;
						}
						goto IL_0141;
						IL_010b:
						num2 = 9;
						val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.000");
						goto IL_0141;
						IL_0141:
						num2 = 11;
						if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 72]))
						{
							goto IL_0178;
						}
						goto IL_0256;
						IL_0178:
						num2 = 12;
						val[val.Row, 72] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
						goto IL_01ac;
						IL_01ac:
						num2 = 13;
						val[val.Row, 16] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) - Conversion.Val(val[val.Row, 15])), "0.000");
						goto IL_01f4;
						IL_01f4:
						num2 = 14;
						val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) - Conversion.Val(val[val.Row, 17])), "0.000");
						goto IL_023c;
						IL_023c:
						num2 = 15;
						val[val.Row, 96] = Conversions.ToString(0);
						goto IL_0256;
						IL_0256:
						num2 = 17;
						if ((Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
						{
							goto IL_02a2;
						}
						goto IL_02ec;
						IL_02a2:
						num2 = 18;
						val[val.Row, 16] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) - Conversion.Val(val[val.Row, 15])), "0.000");
						goto IL_02ec;
						IL_02ec:
						num2 = 20;
						if (val.Col == 15)
						{
							goto IL_02ff;
						}
						goto IL_0373;
						IL_02ff:
						num2 = 21;
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							goto IL_0323;
						}
						goto IL_0373;
						IL_0323:
						num2 = 22;
						val[val.Row, 73] = Conversions.ToString(0);
						goto IL_033b;
						IL_033b:
						num2 = 23;
						val[val.Row, 16] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.000");
						goto IL_0373;
						IL_0373:
						num2 = 26;
						if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 73]))
						{
							goto IL_03aa;
						}
						goto IL_050b;
						IL_03aa:
						num2 = 27;
						val[val.Row, 73] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.000");
						goto IL_03de;
						IL_03de:
						num2 = 28;
						if ((Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
						{
							goto IL_043e;
						}
						goto IL_04bc;
						IL_043e:
						num2 = 29;
						val[val.Row, 29] = Strings.Format((object)((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28])) / 100.0), "0.000");
						goto IL_04f1;
						IL_04bc:
						num2 = 31;
						val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.000");
						goto IL_04f1;
						IL_04f1:
						num2 = 33;
						val[val.Row, 96] = Conversions.ToString(0);
						goto IL_050b;
						IL_050b:
						num2 = 35;
						if ((Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
						{
							goto IL_0557;
						}
						goto IL_05ab;
						IL_0557:
						num2 = 36;
						val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 16]) * Conversion.Val(val[val.Row, 25]) / 100.0), "0.000");
						goto IL_05ab;
						IL_05ab:
						num2 = 38;
						if (Conversion.Val(val[val.Row, 27]) != Conversion.Val(val[val.Row, 76]))
						{
							goto IL_05e2;
						}
						goto IL_06f4;
						IL_05e2:
						num2 = 39;
						val[val.Row, 76] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
						goto IL_0616;
						IL_0616:
						num2 = 40;
						if ((Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
						{
							goto IL_0676;
						}
						goto IL_06f4;
						IL_0676:
						num2 = 41;
						val[val.Row, 29] = Strings.Format((object)((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28])) / 100.0), "0.000");
						goto IL_06f4;
						IL_06f4:
						num2 = 44;
						if (Conversion.Val(val[val.Row, 28]) != Conversion.Val(val[val.Row, 77]))
						{
							goto IL_072b;
						}
						goto IL_083d;
						IL_072b:
						num2 = 45;
						val[val.Row, 77] = Strings.Format((object)Conversion.Val(val[val.Row, 28]), "0.00");
						goto IL_075f;
						IL_075f:
						num2 = 46;
						if ((Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]) != 0.0) & (Conversion.Val(val[val.Row, 16]) != 0.0))
						{
							goto IL_07bf;
						}
						goto IL_083d;
						IL_07bf:
						num2 = 47;
						val[val.Row, 29] = Strings.Format((object)((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28])) / 100.0), "0.000");
						goto IL_083d;
						IL_083d:
						num2 = 50;
						if (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]) == 0.0)
						{
							goto IL_0878;
						}
						goto IL_08c2;
						IL_0878:
						num2 = 51;
						val[val.Row, 29] = Strings.Format((object)(Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])), "0.000");
						goto IL_08c2;
						IL_08c2:
						num2 = 53;
						if ((Conversion.Val(val[val.Row, 29]) == 0.0) & (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28]) != 0.0))
						{
							goto IL_091f;
						}
						goto IL_099b;
						IL_091f:
						num2 = 54;
						val[val.Row, 29] = Strings.Format((object)((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * (Conversion.Val(val[val.Row, 27]) + Conversion.Val(val[val.Row, 28])) / 100.0), "0.000");
						goto IL_099b;
						IL_099b:
						num2 = 56;
						if ((Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
						{
							goto IL_09e7;
						}
						goto IL_0a36;
						IL_09e7:
						num2 = 57;
						val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) - Conversion.Val(val[val.Row, 17])), "0.000");
						goto IL_0b0a;
						IL_0a36:
						num2 = 59;
						if (Conversion.Val((object)MSG_IDTL[16]) == 0.0)
						{
							goto IL_0a61;
						}
						goto IL_0ac0;
						IL_0a61:
						num2 = 60;
						if (Conversion.Val(val[val.Row, 18]) == 0.0)
						{
							goto IL_0a88;
						}
						goto IL_0b0a;
						IL_0a88:
						num2 = 61;
						val[val.Row, 18] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.000");
						goto IL_0b0a;
						IL_0ac0:
						num2 = 63;
						val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) - Conversion.Val(val[val.Row, 17])), "0.000");
						goto IL_0b0a;
						IL_0b0a:
						num2 = 66;
						if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 78]))
						{
							goto IL_0b41;
						}
						goto IL_0c8a;
						IL_0b41:
						num2 = 67;
						val[val.Row, 78] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.000");
						goto IL_0b75;
						IL_0b75:
						num2 = 68;
						if ((Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
						{
							goto IL_0bd5;
						}
						goto IL_0c53;
						IL_0bd5:
						num2 = 69;
						val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22])) / 100.0), "0.000");
						goto IL_0c8a;
						IL_0c53:
						num2 = 71;
						val[val.Row, 23] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.000");
						goto IL_0c8a;
						IL_0c8a:
						num2 = 74;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK168NEVK", false) == 0)
						{
							goto IL_0ca6;
						}
						goto IL_0cc0;
						IL_0ca6:
						num2 = 75;
						val[val.Row, 79] = Conversions.ToString(0);
						goto IL_0cc0;
						IL_0cc0:
						num2 = 77;
						if (Conversion.Val(val[val.Row, 21]) != Conversion.Val(val[val.Row, 79]))
						{
							goto IL_0cf7;
						}
						goto IL_0e09;
						IL_0cf7:
						num2 = 78;
						val[val.Row, 79] = Strings.Format((object)Conversion.Val(val[val.Row, 21]), "0.00");
						goto IL_0d2b;
						IL_0d2b:
						num2 = 79;
						if ((Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
						{
							goto IL_0d8b;
						}
						goto IL_0e09;
						IL_0d8b:
						num2 = 80;
						val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22])) / 100.0), "0.000");
						goto IL_0e09;
						IL_0e09:
						num2 = 83;
						if (Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 80]))
						{
							goto IL_0e40;
						}
						goto IL_0f52;
						IL_0e40:
						num2 = 84;
						val[val.Row, 80] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
						goto IL_0e74;
						IL_0e74:
						num2 = 85;
						if ((Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
						{
							goto IL_0ed4;
						}
						goto IL_0f52;
						IL_0ed4:
						num2 = 86;
						val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22])) / 100.0), "0.000");
						goto IL_0f52;
						IL_0f52:
						num2 = 89;
						if (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) == 0.0)
						{
							goto IL_0f8d;
						}
						goto IL_0fd7;
						IL_0f8d:
						num2 = 90;
						val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])), "0.000");
						goto IL_0fd7;
						IL_0fd7:
						num2 = 92;
						if ((Conversion.Val(val[val.Row, 23]) == 0.0) & (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) != 0.0))
						{
							goto IL_1034;
						}
						goto IL_10b0;
						IL_1034:
						num2 = 93;
						val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22])) / 100.0), "0.000");
						goto IL_10b0;
						IL_10b0:
						num2 = 95;
						if (Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 99]))
						{
							goto IL_10e7;
						}
						goto IL_1197;
						IL_10e7:
						num2 = 96;
						val[val.Row, 99] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.000");
						goto IL_111b;
						IL_111b:
						num2 = 97;
						val[val.Row, 23] = Strings.Format((object)((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22])) / 100.0), "0.000");
						goto IL_1197;
						IL_1197:
						num2 = 99;
						if (Conversion.Val(val[val.Row, 109]) + Conversion.Val(val[val.Row, 110]) != 0.0)
						{
							goto IL_11d8;
						}
						goto IL_127d;
						IL_11d8:
						num2 = 100;
						if (Conversion.Val(val[val.Row, 18]) == 0.0)
						{
							goto IL_11ff;
						}
						goto IL_1233;
						IL_11ff:
						num2 = 101;
						val[val.Row, 18] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.000");
						goto IL_1233;
						IL_1233:
						num2 = 102;
						val[val.Row, 111] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])), "0.000");
						goto IL_127d;
						IL_127d:
						num2 = 104;
						num5 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.000"));
						goto IL_12a9;
						IL_12a9:
						num2 = 105;
						if (num5 == 0.0)
						{
							goto IL_12bf;
						}
						goto IL_12ed;
						IL_12bf:
						num2 = 106;
						num5 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.000"));
						goto IL_12ed;
						IL_12ed:
						num2 = 108;
						if (Conversion.Val(val[val.Row, 43]) != 0.0)
						{
							goto IL_131b;
						}
						goto IL_14c3;
						IL_131b:
						num2 = 109;
						switch (val[val.Row, 63])
						{
						case "P":
							break;
						case "1":
							goto IL_13b8;
						case "K":
							goto IL_141e;
						default:
							goto IL_1481;
						}
						goto IL_1364;
						IL_1481:
						num2 = 119;
						val[val.Row, 44] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 43]), 0), "0.00");
						goto IL_14c3;
						IL_141e:
						num2 = 116;
						if (num5 != 0.0)
						{
							goto IL_1437;
						}
						goto IL_14c3;
						IL_1437:
						num2 = 117;
						val[val.Row, 44] = Strings.Format((object)Math.Round(num5 * (Conversion.Val(val[val.Row, 43]) / 1000.0), 0), "0.00");
						goto IL_14c3;
						IL_13b8:
						num2 = 113;
						if (num5 != 0.0)
						{
							goto IL_13d1;
						}
						goto IL_14c3;
						IL_13d1:
						num2 = 114;
						val[val.Row, 44] = Strings.Format((object)Math.Round(num5 * (Conversion.Val(val[val.Row, 43]) / 10.0), 0), "0.00");
						goto IL_14c3;
						IL_1364:
						num2 = 111;
						val[val.Row, 44] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 43]), 0), "0.00");
						goto IL_14c3;
						IL_14c3:
						num2 = 122;
						if (Conversion.Val(val[val.Row, 32]) != 0.0)
						{
							goto IL_14f1;
						}
						goto IL_1733;
						IL_14f1:
						num2 = 123;
						switch (val[val.Row, 31])
						{
						case "P":
							break;
						case "N":
							goto IL_158e;
						case "K":
							goto IL_166b;
						default:
							goto IL_16dd;
						}
						goto IL_153a;
						IL_16dd:
						num2 = 135;
						val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
						goto IL_1733;
						IL_166b:
						num2 = 133;
						val[val.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * (Conversion.Val(val[val.Row, 32]) / 1000.0), 0), "0.00");
						goto IL_1733;
						IL_158e:
						num2 = 127;
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							goto IL_15aa;
						}
						goto IL_15ff;
						IL_15aa:
						num2 = 128;
						val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 16]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
						goto IL_1733;
						IL_15ff:
						num2 = 130;
						val[val.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 26])) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
						goto IL_1733;
						IL_153a:
						num2 = 125;
						val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
						goto IL_1733;
						IL_1733:
						num2 = 138;
						if ((Conversion.Val(val[val.Row, 35]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
						{
							goto IL_1786;
						}
						goto IL_19d1;
						IL_1786:
						num2 = 139;
						switch (val[val.Row, 31])
						{
						case "P":
							break;
						case "N":
							goto IL_1829;
						case "K":
							goto IL_1909;
						default:
							goto IL_197b;
						}
						goto IL_17d2;
						IL_197b:
						num2 = 151;
						val[val.Row, 36] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 35]), 0), "0.00");
						goto IL_19d1;
						IL_1909:
						num2 = 149;
						val[val.Row, 36] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 35]) / 1000.0), 0), "0.00");
						goto IL_19d1;
						IL_1829:
						num2 = 143;
						if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
						{
							goto IL_1848;
						}
						goto IL_189d;
						IL_1848:
						num2 = 144;
						val[val.Row, 36] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * Conversion.Val(val[val.Row, 35]), 0), "0.00");
						goto IL_19d1;
						IL_189d:
						num2 = 146;
						val[val.Row, 36] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 20])) * Conversion.Val(val[val.Row, 35]), 0), "0.00");
						goto IL_19d1;
						IL_17d2:
						num2 = 141;
						val[val.Row, 36] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 35]), 0), "0.00");
						goto IL_19d1;
						IL_19d1:
						num2 = 154;
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM310NEPK", false) != 0) & (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) != 0))
						{
							goto IL_1a07;
						}
						goto IL_1b21;
						IL_1a07:
						num2 = 155;
						if (Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 44]) != 0.0)
						{
							goto IL_1a5f;
						}
						goto IL_1b21;
						IL_1a5f:
						num2 = 156;
						val[val.Row, 45] = Strings.Format((object)(Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 44])), "0.00");
						goto IL_1abe;
						IL_1abe:
						num2 = 157;
						val[val.Row, 46] = Strings.Format((object)(Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 44])), "0.00");
						goto IL_1b21;
						IL_1b21:
						num2 = 160;
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK052NSAK", false) == 0))
						{
							goto IL_1b6b;
						}
						goto IL_1c2b;
						IL_1b6b:
						num2 = 161;
						val[val.Row, 46] = Strings.Format((object)(Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 34])), "0.0");
						goto IL_1bca;
						IL_1bca:
						num2 = 162;
						val[val.Row, 45] = Strings.Format((object)(Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 34])), "0.0");
						goto IL_1c2b;
						IL_1c2b:
						num2 = 164;
						if ((Conversion.Val(val[val.Row, 46]) != 0.0) & (Conversion.Val(val[val.Row, 49]) != Conversion.Val(val[val.Row, 96])))
						{
							goto IL_1c87;
						}
						goto IL_1d24;
						IL_1c87:
						num2 = 165;
						val[val.Row, 96] = Strings.Format((object)Conversion.Val(val[val.Row, 49]), "0.00");
						goto IL_1cbe;
						IL_1cbe:
						num2 = 166;
						val[val.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 46]) * (1.0 + Conversion.Val(val[val.Row, 49]) / 100.0)), "0.00");
						goto IL_1d24;
						IL_1d24:
						num2 = 168;
						num6 = 1.0;
						goto IL_1d35;
						IL_1d35:
						num2 = 169;
						if ((Conversion.Val(val[val.Row, 46]) == 0.0) & (Conversion.Val(val[val.Row, 45]) != 0.0))
						{
							goto IL_1d84;
						}
						goto IL_1e5d;
						IL_1d84:
						num2 = 170;
						if (Conversion.Val(val[val.Row, 49]) != Conversion.Val(val[val.Row, 96]))
						{
							goto IL_1dbe;
						}
						goto IL_1e5d;
						IL_1dbe:
						num2 = 171;
						val[val.Row, 96] = Strings.Format((object)Conversion.Val(val[val.Row, 49]), "0.00");
						goto IL_1df5;
						IL_1df5:
						num2 = 172;
						val[val.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 45]) * (1.0 + Conversion.Val(val[val.Row, 49]) / 100.0)), "0.00");
						goto IL_1e5d;
						IL_1e5d:
						num2 = 175;
						if (val[48] != 0)
						{
							goto IL_1e77;
						}
						goto IL_206b;
						IL_1e77:
						num2 = 176;
						if ((Conversion.Val(val[val.Row, 45]) != 0.0) & (Conversion.Val(val[val.Row, 47]) != Conversion.Val(val[val.Row, 98])))
						{
							goto IL_1ed3;
						}
						goto IL_1f70;
						IL_1ed3:
						num2 = 177;
						val[val.Row, 98] = Strings.Format((object)Conversion.Val(val[val.Row, 47]), "0.00");
						goto IL_1f0a;
						IL_1f0a:
						num2 = 178;
						val[val.Row, 48] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 45]) * (1.0 + Conversion.Val(val[val.Row, 47]) / 100.0)), "0.00");
						goto IL_1f70;
						IL_1f70:
						num2 = 180;
						if ((Conversion.Val(val[val.Row, 48]) != 0.0) & (Conversion.Val(val[val.Row, 49]) != Conversion.Val(val[val.Row, 96])))
						{
							goto IL_1fcc;
						}
						goto IL_206b;
						IL_1fcc:
						num2 = 181;
						val[val.Row, 96] = Strings.Format((object)Conversion.Val(val[val.Row, 49]), "0.00");
						goto IL_2003;
						IL_2003:
						num2 = 182;
						val[val.Row, 50] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 48]) * (1.0 + Conversion.Val(val[val.Row, 49]) / 100.0)), "0.00");
						goto IL_206b;
						IL_206b:
						num2 = 185;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0)
						{
							goto IL_208d;
						}
						goto IL_29ff;
						IL_208d:
						num2 = 186;
						if (!ToDayRateFill)
						{
							goto IL_20a2;
						}
						goto IL_20be;
						IL_20a2:
						num2 = 187;
						ToDayRateFill = true;
						goto IL_20af;
						IL_20af:
						num2 = 188;
						TodayFineRate();
						goto IL_20be;
						IL_20be:
						num2 = 190;
						if (Operators.CompareString(val[val.Row, 64], "G", false) == 0)
						{
							goto IL_20e9;
						}
						goto IL_29ff;
						IL_20e9:
						num2 = 191;
						if (Conversion.Val(val[val.Row, 37]) != 0.0)
						{
							goto IL_2119;
						}
						goto IL_256a;
						IL_2119:
						num2 = 192;
						if (Operators.CompareString(val[val.Row, 69], "A", false) == 0)
						{
							goto IL_2144;
						}
						goto IL_2352;
						IL_2144:
						num2 = 193;
						if ((Conversion.Val(val[val.Row, 108]) != Conversion.Val(val[val.Row, 39])) | (Conversion.Val(val[val.Row, 39]) == 0.0))
						{
							goto IL_219d;
						}
						goto IL_2441;
						IL_219d:
						num2 = 194;
						if ((ToDayGlRate != 0.0) & (Conversion.Val(val[val.Row, 14]) != 0.0))
						{
							goto IL_21e2;
						}
						goto IL_2441;
						IL_21e2:
						num2 = 195;
						if (Conversion.Val(val[val.Row, 39]) != 0.0)
						{
							goto IL_2212;
						}
						goto IL_22a1;
						IL_2212:
						num2 = 196;
						val[val.Row, 108] = Strings.Format((object)Conversion.Val(val[val.Row, 39]), "0.00");
						goto IL_2249;
						IL_2249:
						num2 = 197;
						val[val.Row, 40] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) / Conversion.Val(val[val.Row, 39]), 3), "0.000");
						goto IL_2441;
						IL_22a1:
						num2 = 199;
						val[val.Row, 39] = Strings.Format((object)ToDayGlRate, "0.00");
						goto IL_22cb;
						IL_22cb:
						num2 = 200;
						val[val.Row, 108] = Strings.Format((object)ToDayGlRate, "0.00");
						goto IL_22f5;
						IL_22f5:
						num2 = 201;
						val[val.Row, 40] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) / Conversion.Val(val[val.Row, 39]), 3), "0.000");
						goto IL_2441;
						IL_2352:
						num2 = 206;
						if (Conversion.Val(val[val.Row, 39]) == 0.0)
						{
							goto IL_237c;
						}
						goto IL_239d;
						IL_237c:
						num2 = 207;
						val[val.Row, 40] = "";
						goto IL_2441;
						IL_239d:
						num2 = 209;
						if ((Conversion.Val(val[val.Row, 37]) != 0.0) & (Conversion.Val(val[val.Row, 39]) != 0.0))
						{
							goto IL_23ec;
						}
						goto IL_2441;
						IL_23ec:
						num2 = 210;
						val[val.Row, 40] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 37]) / Conversion.Val(val[val.Row, 39]), 3), "0.000");
						goto IL_2441;
						IL_2441:
						num2 = 214;
						val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 40])), "0.000");
						goto IL_248c;
						IL_248c:
						num2 = 215;
						if (Operators.CompareString(val[val.Row, 38], "G", false) == 0)
						{
							goto IL_24b4;
						}
						goto IL_250d;
						IL_24b4:
						num2 = 216;
						val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 41]) * 100.0 / Conversion.Val(val[val.Row, 14])), "0.00");
						goto IL_26bf;
						IL_250d:
						num2 = 218;
						val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 41]) * 100.0 / Conversion.Val(val[val.Row, 16])), "0.00");
						goto IL_26bf;
						IL_256a:
						num2 = 221;
						if (Conversion.Val(val[val.Row, 14]) != 0.0)
						{
							goto IL_259a;
						}
						goto IL_26bf;
						IL_259a:
						num2 = 222;
						val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 40])), "0.000");
						goto IL_25e5;
						IL_25e5:
						num2 = 223;
						if (Operators.CompareString(val[val.Row, 38], "G", false) == 0)
						{
							goto IL_260d;
						}
						goto IL_2666;
						IL_260d:
						num2 = 224;
						val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 41]) * 100.0 / Conversion.Val(val[val.Row, 14])), "0.00");
						goto IL_26bf;
						IL_2666:
						num2 = 226;
						val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 41]) * 100.0 / Conversion.Val(val[val.Row, 16])), "0.00");
						goto IL_26bf;
						IL_26bf:
						num2 = 230;
						num7 = 0.0;
						goto IL_26d0;
						IL_26d0:
						num2 = 231;
						text = "";
						goto IL_26dd;
						IL_26dd:
						num2 = 232;
						num7 = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(val[val.Row, 42]) + Conversion.Val(val[val.Row, 49])), "0.00"));
						goto IL_2720;
						IL_2720:
						num2 = 233;
						text3 = Strings.Format((object)num7, "0.00");
						goto IL_2739;
						IL_2739:
						num2 = 234;
						num8 = Strings.Len(text3);
						DC_Main.M = 1;
						goto IL_29c3;
						IL_29c3:
						if (DC_Main.M <= num8)
						{
							goto IL_2754;
						}
						goto IL_29cf;
						IL_29cf:
						num2 = 270;
						val[val.Row, 84] = text;
						goto IL_29e6;
						IL_29e6:
						num2 = 271;
						tHmId4.Text = text;
						goto IL_29ff;
						IL_2754:
						num2 = 235;
						text2 = Strings.Mid(text3, DC_Main.M, 1);
						goto IL_2769;
						IL_2769:
						num2 = 237;
						if (Operators.CompareString(text2, ".", false) == 0)
						{
							goto IL_2785;
						}
						goto IL_279e;
						IL_2785:
						num2 = 238;
						text += "|";
						goto IL_29b1;
						IL_279e:
						num2 = 240;
						if (Operators.CompareString(text2, Conversions.ToString(1), false) == 0)
						{
							goto IL_27bb;
						}
						goto IL_27d4;
						IL_27bb:
						num2 = 241;
						text += "B";
						goto IL_29b1;
						IL_27d4:
						num2 = 243;
						if (Operators.CompareString(text2, Conversions.ToString(2), false) == 0)
						{
							goto IL_27f1;
						}
						goto IL_280a;
						IL_27f1:
						num2 = 244;
						text += "O";
						goto IL_29b1;
						IL_280a:
						num2 = 246;
						if (Operators.CompareString(text2, Conversions.ToString(3), false) == 0)
						{
							goto IL_2827;
						}
						goto IL_2840;
						IL_2827:
						num2 = 247;
						text += "Y";
						goto IL_29b1;
						IL_2840:
						num2 = 249;
						if (Operators.CompareString(text2, Conversions.ToString(4), false) == 0)
						{
							goto IL_285d;
						}
						goto IL_2876;
						IL_285d:
						num2 = 250;
						text += "F";
						goto IL_29b1;
						IL_2876:
						num2 = 252;
						if (Operators.CompareString(text2, Conversions.ToString(5), false) == 0)
						{
							goto IL_2893;
						}
						goto IL_28ac;
						IL_2893:
						num2 = 253;
						text += "R";
						goto IL_29b1;
						IL_28ac:
						num2 = 255;
						if (Operators.CompareString(text2, Conversions.ToString(6), false) == 0)
						{
							goto IL_28c9;
						}
						goto IL_28e2;
						IL_28c9:
						num2 = 256;
						text += "I";
						goto IL_29b1;
						IL_28e2:
						num2 = 258;
						if (Operators.CompareString(text2, Conversions.ToString(7), false) == 0)
						{
							goto IL_28ff;
						}
						goto IL_2918;
						IL_28ff:
						num2 = 259;
						text += "E";
						goto IL_29b1;
						IL_2918:
						num2 = 261;
						if (Operators.CompareString(text2, Conversions.ToString(8), false) == 0)
						{
							goto IL_2935;
						}
						goto IL_294b;
						IL_2935:
						num2 = 262;
						text += "N";
						goto IL_29b1;
						IL_294b:
						num2 = 264;
						if (Operators.CompareString(text2, Conversions.ToString(9), false) == 0)
						{
							goto IL_2969;
						}
						goto IL_297f;
						IL_2969:
						num2 = 265;
						text += "D";
						goto IL_29b1;
						end_IL_0001_2:
						break;
					}
					num2 = 275;
					MSG_TOT_FILL();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 11891;
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

	private string GetComPortByFriendlyName(string friendlyContains)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Expected O, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		try
		{
			ManagementObjectSearcher val = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE Name IS NOT NULL");
			ManagementObjectEnumerator enumerator = default(ManagementObjectEnumerator);
			try
			{
				enumerator = val.Get().GetEnumerator();
				while (enumerator.MoveNext())
				{
					ManagementObject val2 = (ManagementObject)enumerator.Current;
					object objectValue = RuntimeHelpers.GetObjectValue(((ManagementBaseObject)val2)["Name"]);
					if (objectValue == null)
					{
						continue;
					}
					string text = objectValue.ToString();
					if (text.IndexOf(friendlyContains, StringComparison.OrdinalIgnoreCase) >= 0 && text.IndexOf("COM", StringComparison.OrdinalIgnoreCase) >= 0)
					{
						Match match = Regex.Match(text, "COM\\d+", RegexOptions.IgnoreCase);
						if (match.Success)
						{
							return match.Value;
						}
					}
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			ProjectData.ClearProjectError();
		}
		return null;
	}

	private void WeightScal()
	{
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsWeightPort, "0", false) == 0)
		{
			return;
		}
		SerialPort val = new SerialPort();
		string comPortByFriendlyName = GetComPortByFriendlyName("CH340");
		if (string.IsNullOrEmpty(comPortByFriendlyName))
		{
			string[] portNames = SerialPort.GetPortNames();
			MessageBox.Show("Available ports: " + string.Join(", ", portNames));
			return;
		}
		try
		{
			val.PortName = comPortByFriendlyName;
			val.BaudRate = 9600;
			val.DataBits = 8;
			val.Parity = (Parity)0;
			val.StopBits = (StopBits)1;
			val.Open();
			Timer1.Start();
			WeightPortOpen = true;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			try
			{
				SerialPort1.BaudRate = 2400;
				SerialPort1.DataBits = 7;
				SerialPort1.Parity = (Parity)0;
				SerialPort1.StopBits = (StopBits)1;
				SerialPort1.PortName = DC_Main.MsWeightPort;
				SerialPort1.Open();
				Timer1.Start();
				WeightPortOpen = true;
			}
			catch (Exception ex3)
			{
				ProjectData.SetProjectError(ex3);
				Exception ex4 = ex3;
				MessageBox.Show("Port open error: " + ex4.Message);
				ProjectData.ClearProjectError();
			}
			((Control)BtnSave).Enabled = true;
			ProjectData.ClearProjectError();
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		int num = 0;
		string text = "";
		string text2 = "";
		if (Operators.CompareString(DC_Main.MsWeightPort, "0", false) == 0)
		{
			return;
		}
		lock (Q)
		{
			while (Q.Count > 0)
			{
				if (MSG.Col != 14)
				{
					continue;
				}
				text = Q.Dequeue();
				if (Operators.CompareString(text, "", false) == 0)
				{
					break;
				}
				num = 1;
				do
				{
					if ((Versioned.IsNumeric((object)Strings.Mid(text, num, 1)) | (Operators.CompareString(Strings.Mid(text, num, 1), ".", false) == 0)) && ((Operators.CompareString(Strings.Mid(text, num, 1), "+", false) != 0) & (Operators.CompareString(Strings.Mid(text, num, 1), "\r", false) != 0)))
					{
						text2 += Strings.Mid(text, num, 1);
					}
					if (num >= Strings.Len(text))
					{
						break;
					}
					num = checked(num + 1);
				}
				while (num <= 20);
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(text2), "0.000");
			}
		}
	}

	private void SerialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		Q.Enqueue(SerialPort1.ReadExisting());
	}

	private void TEXT_ENTRY_TextChanged(object sender, EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f7: Invalid comparison between Unknown and I4
		//IL_1478: Unknown result type (might be due to invalid IL or missing references)
		//IL_147b: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_148d: Unknown result type (might be due to invalid IL or missing references)
		//IL_148f: Invalid comparison between Unknown and I4
		//IL_14a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a4: Invalid comparison between Unknown and I4
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1570: Unknown result type (might be due to invalid IL or missing references)
		//IL_1573: Invalid comparison between Unknown and I4
		//IL_15ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ef: Invalid comparison between Unknown and I4
		//IL_05ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_167f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1682: Invalid comparison between Unknown and I4
		//IL_172e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1731: Invalid comparison between Unknown and I4
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_12be: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1959: Unknown result type (might be due to invalid IL or missing references)
		//IL_63d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b36: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c92: Invalid comparison between Unknown and I4
		//IL_04e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_7a0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ceb: Unknown result type (might be due to invalid IL or missing references)
		//IL_73a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_5da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_6dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2569: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_5f9c: Invalid comparison between Unknown and I4
		//IL_1a21: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_275b: Unknown result type (might be due to invalid IL or missing references)
		//IL_62c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_62d1: Expected O, but got Unknown
		//IL_434c: Unknown result type (might be due to invalid IL or missing references)
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
			if ((Operators.CompareString(UserDelete, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				return;
			}
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO  = '" + mSG[mSG.Row, 5] + "'  AND VCH_SRNO =  " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 67])) + " AND ITM_SIGN = '-'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"You Cant Delete This Tag Because Tag Use in Book = ", DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)" And VchNo = "), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)" Transection...."), (MsgBoxStyle)0, (object)null);
					return;
				}
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 62]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][38])) == Conversion.Val(mSG[mSG.Row, 62]))
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
					DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,OLD_SRNO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,KR_NAME,TAG_NO,ITM_GWT,ITM_NWT,IT_TYPE,LBR_AMT,OTH_AMT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM BAR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND TAG_NO = '" + mSG[mSG.Row, 5] + "'";
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
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
							mSG[mSG.Row, 62] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 62] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 62]) + 1.0);
						}
					}
					mSG[mSG.Row, 67] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MsVchSrno;
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 3)
			{
				ItCodeLock = false;
			}
			if (mSG.Col == 39)
			{
				mSG[mSG.Row, 108] = Conversions.ToString(1);
			}
			if (mSG.Col == 7)
			{
				if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT  IT_DESIGN as DesignL From ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 3] + "' GROUP BY IT_DESIGN ORDER BY IT_DESIGN";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[2];
					DC_Main.ColWidth[0] = 350.0;
					DC_Main.HelpSelect = 1;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
					}
					return;
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,A.ITM_STYLE As StyleL,BOOK_NAME As BookNameL,A.DIE_NO As RemarkL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 3] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,A.ITM_STYLE As StyleL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 3] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[13];
				DC_Main.ColWidth[0] = 120.0;
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.ColWidth[2] = 110.0;
				DC_Main.ColWidth[3] = 150.0;
				DC_Main.ColWidth[4] = 90.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.ColWidth[6] = 100.0;
				DC_Main.ColWidth[7] = 80.0;
				DC_Main.ColWidth[8] = 80.0;
				DC_Main.ColWidth[9] = 80.0;
				DC_Main.ColWidth[10] = 90.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[0];
					mSG[mSG.Row, 7] = DC_Main.ColValue[0];
					mSG[mSG.Row, 8] = DC_Main.ColValue[1];
					mSG[mSG.Row, 10] = DC_Main.ColValue[4];
					mSG[mSG.Row, 53] = DC_Main.ColValue[5];
					if (Operators.CompareString(mSG[mSG.Row, 69], "E", false) != 0)
					{
						if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
						{
							mSG[mSG.Row, 27] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
						{
							mSG[mSG.Row, 28] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[9]) != 0.0)
						{
							mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[9]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[9]) == 0.0 && Conversion.Val(DC_Main.ColValue[10]) != 0.0)
						{
							mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[10]), "0.00");
						}
					}
					mSG[mSG.Row, 101] = DC_Main.ColValue[11];
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				else
				{
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 7] = "";
					mSG[mSG.Row, 101] = "N";
				}
				((Control)TEXT_ENTRY).Focus();
				return;
			}
			if (mSG.Col == 14)
			{
				if (Operators.CompareString(DC_Main.MsWeightPort, "0", false) != 0)
				{
					if (WeightPortOpen)
					{
						SerialPort1.Close();
						Timer1.Stop();
					}
					WeightScal();
				}
				else if (Conversion.Val(nHmWt.Text) != 0.0)
				{
					TEXT_ENTRY.Text = Conversions.ToString(Conversion.Val(nHmWt.Text) + Conversion.Val(nHmWt2.Text) + Conversion.Val(nHmWt3.Text) + Conversion.Val(nHmWt4.Text));
				}
			}
			if ((mSG.Col == 16) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				DC_Main.RsQry = ("SELECT A.IT_CODE,A.LBR_CODE,B.LBR_CATG,B.LBR_VAL FROM ITM_WT_MAST AS A LEFT JOIN LBR_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LBR_CODE = B.LBR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + mSG[mSG.Row, 3] + "' AND A.LBR_CODE <> '' AND A.FROM_WT <= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 14])) + " AND A.TO_WT >= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 14]))) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					mSG[mSG.Row, 32] = "";
					mSG[mSG.Row, 33] = "";
					mSG[mSG.Row, 30] = "";
					mSG[mSG.Row, 25] = "";
					mSG[mSG.Row, 28] = "";
					mSG[mSG.Row, 50] = "";
					mSG[mSG.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CODE"], (object)""));
					switch (Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CATG"], (object)"")), 1, 2))
					{
					case "01":
						mSG[mSG.Row, 32] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "02":
						mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "03":
						mSG[mSG.Row, 33] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "04":
						mSG[mSG.Row, 28] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "05":
						mSG[mSG.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "06":
						mSG[mSG.Row, 31] = "K";
						mSG[mSG.Row, 32] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "07":
						mSG[mSG.Row, 50] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					}
					CommPassTotal();
				}
				else
				{
					Interaction.MsgBox((object)"No LabCode Found Please Update Itm Stock Limit Mast and Try..", (MsgBoxStyle)0, (object)null);
				}
			}
			if (mSG.Col == 53)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_SHORT <> '' ORDER BY AC_NAME";
				}
				else if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
				{
					DC_Main.RsQry = "SELECT '' As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
				}
				else
				{
					DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[3];
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
				{
					DC_Main.ColWidth[0] = 1.0;
				}
				else
				{
					DC_Main.ColWidth[0] = 400.0;
				}
				DC_Main.ColWidth[1] = 100.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						mSG[mSG.Row, 53] = DC_Main.ColValue[1];
					}
					((Control)TEXT_ENTRY).Focus();
				}
				return;
			}
			if (mSG.Col == 4)
			{
				DC_Main.RsQry = "SELECT A.ISU_AC_NAME as CustNameL,A.ISU_NO As VchNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE as SizeL,A.ISU_SRNO AS SrNoM,A.ISU_YRCD As YearL,A.ISU_DBCD As BookL,A.ISU_AC_CODE,C.AC_NAME As KrgrL,A.IT_CODE as ItCodeL,C.AC_SHORT As AcShortL,A.VCH_DATE As RecDateM,'' As ColorL,A.ISU_LC_CODE As OrdLcM FROM (APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'KARIGAR ORDER' AND A.ISU_REC = 'N'  UNION ALL SELECT F.AC_NAME as CustNameL,D.VCH_NO As VchNoL,D.DESIGN_NO As DesignL,E.IT_NAME As ItNameL,D.ITM_REMARK AS OrderDesc,D.ITM_SIZE as SizeL,D.OLD_SRNO AS SrNoM,D.CO_YEAR As YearL,D.CO_BOOK As BookL,D.AC_CODE,'' As KrgrL,D.IT_CODE as ItCodeL,'' As AcShortL,D.VCH_DATE,D.ITM_COLOR,D.LC_CODE FROM (SL_ORD_DATA AS F INNER JOIN SL_ORD_DETL AS D ON F.CO_CODE = D.CO_CODE AND F.LC_CODE = D.LC_CODE AND F.CO_YEAR = D.CO_YEAR AND F.CO_BOOK = D.CO_BOOK AND F.VCH_NO = D.VCH_NO) LEFT JOIN ITEM_MAST AS E ON D.CO_CODE = E.CO_CODE AND D.IT_CODE = E.IT_CODE WHERE D.CO_CODE = '" + DC_Main.MCo_code + "' AND D.LC_CODE = '" + DC_Main.MLc_code + "' AND D.TAG_GEN = 'N' AND D.DESIGN_ISU = 'N' ";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[17];
				DC_Main.ColWidth[0] = 240.0;
				DC_Main.ColWidth[1] = 70.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 160.0;
				DC_Main.ColWidth[4] = 160.0;
				DC_Main.ColWidth[5] = 90.0;
				DC_Main.ColWidth[6] = 60.0;
				DC_Main.ColWidth[7] = 0.0;
				DC_Main.ColWidth[8] = 0.0;
				DC_Main.ColWidth[9] = 0.0;
				DC_Main.ColWidth[10] = 110.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.ColWidth[13] = 100.0;
				DC_Main.ColWidth[14] = 90.0;
				DC_Main.ColWidth[15] = 60.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						mSG[mSG.Row, 90] = DC_Main.ColValue[6];
						mSG[mSG.Row, 91] = DC_Main.ColValue[7];
						mSG[mSG.Row, 92] = DC_Main.ColValue[8];
						mSG[mSG.Row, 93] = DC_Main.ColValue[0];
						mSG[mSG.Row, 94] = DC_Main.ColValue[9];
						mSG[mSG.Row, 95] = DC_Main.ColValue[15];
						mSG[mSG.Row, 7] = DC_Main.ColValue[2];
						mSG[mSG.Row, 10] = DC_Main.ColValue[5];
						mSG[mSG.Row, 53] = DC_Main.ColValue[12];
						mSG[mSG.Row, 9] = DC_Main.ColValue[14];
					}
					else
					{
						mSG[mSG.Row, 90] = "";
						mSG[mSG.Row, 91] = "";
						mSG[mSG.Row, 92] = "";
						mSG[mSG.Row, 93] = "";
						mSG[mSG.Row, 94] = "";
						mSG[mSG.Row, 95] = "";
					}
					((Control)TEXT_ENTRY).Focus();
				}
				return;
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
				checked
				{
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
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
							mSG.Col -= 1;
						}
					}
					else if (mSG.Col > 2)
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
				}
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
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				if (mSG.Row > 1)
				{
					MsgOldRow = 0;
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						UpDown = true;
						CommPassTotal();
					}
					mSG.Row = checked(mSG.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
				checked
				{
					if (mSG.Row >= mSG.Rows - 1)
					{
						return;
					}
					MsgOldRow = 0;
					if (MsTxtDelete)
					{
						MsTxtDelete = false;
					}
					else
					{
						if (mSG.Col != 53)
						{
							UpDown = true;
						}
						CommPassTotal();
					}
					mSG.Row += 1;
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG.Col)
					{
					case 3:
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "' "), Interaction.IIf(cboItType.SelectedIndex == 2, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItType.Text, 1, 1) + "'"))), (object)""));
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE as ItCodeL, B.GR_NAME AS GroupL,A.PR_CODE As PrCodeL,A.IT_TYPE As ItTypeL,A.TAG_TYPE As TagTypeL  FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'"), Interaction.IIf(cboItType.SelectedIndex == 2, (object)"", (object)("AND A.IT_TYPE = '" + Strings.Mid(cboItType.Text, 1, 1) + "'"))), (object)" ORDER BY A.IT_NAME"));
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
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								if (Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) != 0 && ((Operators.CompareString(mSG[mSG.Row, 69], "E", false) == 0) & (Operators.CompareString(Strings.Mid(TEXT_ENTRY.Text, 1, 2), Strings.Mid(mSG[mSG.Row, 3], 1, 2), false) != 0)))
								{
									if (ItCodeLock)
									{
										Interaction.MsgBox((object)"You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...", (MsgBoxStyle)0, (object)null);
										TEXT_ENTRY.Text = mSG[mSG.Row, 3];
										((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
										((Control)TEXT_ENTRY).Focus();
										return;
									}
									ItCodeLock = true;
								}
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								mSG[mSG.Row, 68] = DC_Main.ColValue[0];
								mSG[mSG.Row, 66] = DC_Main.ColValue[3];
								mSG[mSG.Row, 64] = DC_Main.ColValue[4];
								mSG[mSG.Row, 65] = DC_Main.ColValue[5];
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) != 0 && ((Operators.CompareString(mSG[mSG.Row, 69], "E", false) == 0) & (Operators.CompareString(Strings.Mid(TEXT_ENTRY.Text, 1, 2), Strings.Mid(mSG[mSG.Row, 3], 1, 2), false) != 0)))
						{
							Interaction.MsgBox((object)"You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...", (MsgBoxStyle)0, (object)null);
							TEXT_ENTRY.Text = mSG[mSG.Row, 3];
							((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if (mSG[12] != 0 && ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
						{
							AxMSFlexGrid obj = mSG;
							int row = mSG.Row;
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_BAG_WT"]);
							double num8 = DC_Main.Fnv(ref Value);
							dataRow["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
							obj[row, 12] = Strings.Format((object)num8, "0.000");
						}
						if ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (mSG.Row == mSG.Rows - 1) & (Operators.CompareString(mSG[mSG.Row, 63], "P", false) == 0))
						{
							mSG[mSG.Row, 31] = "P";
						}
						else if (Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0)
						{
							mSG[mSG.Row, 31] = DC_Main.MsLbrType;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 65], mSG[mSG.Row, 70], false) != 0) | (Operators.CompareString(mSG[mSG.Row, 66], mSG[mSG.Row, 71], false) != 0))
						{
							mSG[mSG.Row, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 5] = "";
							mSG[mSG.Row, 61] = "";
						}
						if (Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0)
						{
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
							double num9 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num9 != 0.0) & (Conversion.Val(mSG[mSG.Row, 32]) == 0.0))
							{
								AxMSFlexGrid obj2 = mSG;
								int row2 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
								double num10 = DC_Main.Fnv(ref Value);
								dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								obj2[row2, 32] = Strings.Format((object)num10, "0.00");
							}
							if (mSG[30] != 0)
							{
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
								double num11 = DC_Main.Fnv(ref Value);
								dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								if ((num11 != 0.0) & (Conversion.Val(mSG[mSG.Row, 30]) == 0.0))
								{
									AxMSFlexGrid obj3 = mSG;
									int row3 = mSG.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
									double num12 = DC_Main.Fnv(ref Value);
									dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
									obj3[row3, 30] = Strings.Format((object)num12, "0.00");
								}
							}
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_TOUCH"]);
							double num13 = DC_Main.Fnv(ref Value);
							dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num13 != 0.0) & (Conversion.Val(mSG[mSG.Row, 27]) == 0.0))
							{
								AxMSFlexGrid obj4 = mSG;
								int row4 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_TOUCH"]);
								double num14 = DC_Main.Fnv(ref Value);
								dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								obj4[row4, 27] = Strings.Format((object)num14, "0.00");
							}
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_WEST"]);
							double num15 = DC_Main.Fnv(ref Value);
							dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num15 != 0.0) & (Conversion.Val(mSG[mSG.Row, 28]) == 0.0))
							{
								AxMSFlexGrid obj5 = mSG;
								int row5 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_WEST"]);
								double num16 = DC_Main.Fnv(ref Value);
								dataRow["IT_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								obj5[row5, 28] = Strings.Format((object)num16, "0.00");
							}
						}
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						break;
					case 2:
					{
						if (Operators.CompareString(FormMainBook, "MFG TAG", false) != 0)
						{
							break;
						}
						string text5 = "";
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 2], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 103] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 104] + "' AND A.OLD_SRNO = '" + mSG[mSG.Row, 106] + "' AND A.VCH_NO = '" + TEXT_ENTRY.Text + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
							{
								DC_Main.RsQry = "Select A.TAG_NO AS LotTagL,B.IT_NAME As ItNameL,C.AC_NAME as KrNameL,A.VCH_NO As VchNoL,A.ENTRY_TYPE AS MfgTypeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR aS YearL,A.CO_BOOK BookL,A.IT_CODE as ItCodeL,D.AC_NAME As CustNameL,A.LOT_NO As ItmLotM From ((MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.KR_CODE = C.AC_CODE)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_ADJ = 'N' AND INOUT_TYPE = 'I' ORDER BY ENTRY_TYPE,A.DESIGN_NO";
							}
							else
							{
								DC_Main.RsQry = "Select A.DESIGN_NO AS DesignL,B.IT_NAME As ItNameL,C.AC_NAME as KrNameL,A.VCH_NO As VchNoL,A.ENTRY_TYPE AS MfgTypeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR aS YearL,A.CO_BOOK BookL,A.IT_CODE as ItCodeL,D.AC_NAME As CustNameL,A.LOT_NO As LotNoM From ((MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.KR_CODE = C.AC_CODE)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_ADJ = 'N' AND INOUT_TYPE = 'I' ORDER BY ENTRY_TYPE,A.DESIGN_NO";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[14];
							DC_Main.ColWidth[0] = 105.0;
							DC_Main.ColWidth[1] = 180.0;
							DC_Main.ColWidth[2] = 225.0;
							DC_Main.ColWidth[3] = 90.0;
							DC_Main.ColWidth[4] = 80.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 100.0;
							DC_Main.ColWidth[7] = 80.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[10] = 0.0;
							DC_Main.ColWidth[11] = 200.0;
							DC_Main.ColWidth[12] = 110.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[3];
								mSG[mSG.Row, 3] = DC_Main.ColValue[10];
								mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
								mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
								mSG[mSG.Row, 103] = DC_Main.ColValue[8];
								mSG[mSG.Row, 104] = DC_Main.ColValue[9];
								mSG[mSG.Row, 106] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[7]));
								((Control)TEXT_ENTRY).Focus();
								return;
							}
							break;
						}
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
						int num17 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num17)
						{
							if (Operators.CompareString(mSG[mSG.Row, 2], "", false) != 0 && ((Operators.CompareString(mSG[DC_Main.X, 2], mSG[mSG.Row, 2], false) == 0) & (Conversion.Val(mSG[DC_Main.X, 106]) == Conversion.Val(mSG[mSG.Row, 106])) & (mSG.Row != DC_Main.X)))
							{
								Interaction.MsgBox((object)"Duplicate Entry", (MsgBoxStyle)0, (object)null);
								TEXT_ENTRY.Text = "";
								mSG[mSG.Row, 3] = "";
								mSG[mSG.Row, 14] = "";
								mSG[mSG.Row, 16] = "";
								mSG[mSG.Row, 2] = "";
								mSG[mSG.Row, 103] = "";
								mSG[mSG.Row, 104] = "";
								mSG[mSG.Row, 106] = Conversions.ToString(0);
								return;
							}
							DC_Main.X++;
						}
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[DC_Main.i, 105] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
							{
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							}
							else
							{
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							}
							mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 13] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 91] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
							mSG[DC_Main.i, 92] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
							mSG[DC_Main.i, 90] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ORD_SRNO"]);
							mSG[DC_Main.i, 94] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
							mSG[DC_Main.i, 107] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TOT_GHT"])), "0.000");
							if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ITM_TOUCH,ITM_WEST_PRC FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LOT_NO = '"), DC_Main.Rshlp.Rows[0]["LOT_NO"]), (object)""), (object)"'"));
								DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Tbl.Rows.Count > 0)
								{
									mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ITM_TOUCH"])), "0.00");
									mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ITM_WEST_PRC"])), "0.00");
								}
								else
								{
									mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								}
							}
							else
							{
								mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							}
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							text5 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ENTRY_TYPE"], (object)""));
						}
						int num18 = 0;
						int num19 = DtIdtl.Rows.Count - 1;
						int num20 = num19;
						for (int j = 0; j <= num20; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num18][38], (object)Conversion.Val(mSG[DC_Main.i, 62]), false))
							{
								DtIdtl.Rows[num18].Delete();
								DtIdtl.AcceptChanges();
								num18--;
							}
							num18++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 103] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 104] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 105] + "' AND A.SR_NO = " + mSG[mSG.Row, 106] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[38] = Conversion.Val(MSG[mSG.Row, 62]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = "";
							dr[4] = "";
							dr[5] = "";
							dr[6] = "";
							dr[7] = "";
							dr[8] = "";
							dr[9] = "";
							dr[10] = 0;
							dr[11] = 0;
							dr[12] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[13] = 0;
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[15] = 0;
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[17] = 0;
							dr[18] = 0;
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[24] = 0;
							dr[25] = 0;
							dr[26] = 0;
							dr[27] = "";
							dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])) == 0.0)
							{
								dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							}
							dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"], (object)"")), "0.000");
							dr[37] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						break;
					}
					case 1:
					case 4:
					{
						string text = "";
						if (!((Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)))
						{
							break;
						}
						string text2 = Conversions.ToString(Interaction.IIf(mSG.Col == 1, (object)mSG[mSG.Row, 1], (object)mSG[mSG.Row, 4]));
						if (!Conversions.ToBoolean(Operators.AndObject((object)(Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0), Operators.CompareObjectNotEqual((object)TEXT_ENTRY.Text, Interaction.IIf(mSG.Col == 1, (object)mSG[mSG.Row, 1], (object)mSG[mSG.Row, 4]), false))))
						{
							break;
						}
						if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
						{
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 103] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 104] + "' AND A.OLD_SRNO = '" + mSG[mSG.Row, 106] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 105] + "' AND A.DESIGN_NO = '" + TEXT_ENTRY.Text + "'";
						}
						else if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
						{
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 91] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 92] + "' AND A.OLD_SRNO = '" + mSG[mSG.Row, 90] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 4] + "' AND A.DESIGN_NO = '" + TEXT_ENTRY.Text + "'";
						}
						else
						{
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 91] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 92] + "' AND A.OLD_SRNO = '" + mSG[mSG.Row, 90] + "' AND A.VCH_NO = '" + TEXT_ENTRY.Text + "' AND A.DESIGN_NO = '" + mSG[mSG.Row, 7] + "'";
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "Select A.DESIGN_NO AS DesignL,B.IT_NAME As ItNameL,C.AC_NAME as KrNameL,A.VCH_NO As VchNoL,A.ENTRY_TYPE AS EntryTypeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR aS YearL,A.CO_BOOK BookL,A.IT_CODE as ItCodeL,A.ENTRY_TYPE As EntTypeL From (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_ADJ = 'N' AND ENTRY_TYPE IN ('G','J','F','C','P') AND INOUT_TYPE = 'I' ORDER BY ENTRY_TYPE,A.DESIGN_NO";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[13];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 250.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 100.0;
							DC_Main.ColWidth[4] = 90.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 100.0;
							DC_Main.ColWidth[7] = 90.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[10] = 0.0;
							DC_Main.ColWidth[11] = 0.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 105] = DC_Main.ColValue[3];
									mSG[mSG.Row, 3] = DC_Main.ColValue[10];
									mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
									mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
									mSG[mSG.Row, 103] = DC_Main.ColValue[8];
									mSG[mSG.Row, 104] = DC_Main.ColValue[9];
									mSG[mSG.Row, 106] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[7]));
									text = DC_Main.ColValue[11];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 105] = "";
									mSG[mSG.Row, 103] = "";
									mSG[mSG.Row, 104] = "";
									mSG[mSG.Row, 106] = "";
									TEXT_ENTRY.Text = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							else if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 3] = DC_Main.ColValue[10];
								}
								else
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[3];
									mSG[mSG.Row, 7] = DC_Main.ColValue[0];
								}
								mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
								mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
								mSG[mSG.Row, 91] = DC_Main.ColValue[8];
								mSG[mSG.Row, 92] = DC_Main.ColValue[9];
								mSG[mSG.Row, 90] = Conversions.ToString(Conversion.Val(DC_Main.ColValue[7]));
								text = DC_Main.ColValue[11];
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 4] = "";
								mSG[mSG.Row, 91] = "";
								mSG[mSG.Row, 92] = "";
								mSG[mSG.Row, 90] = "";
								TEXT_ENTRY.Text = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						int num4 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num4)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 5], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 13] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ITM_NWT FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DESIGN_NO = '"), DC_Main.Rshlp.Rows[0]["DESIGN_NO"]), (object)""), (object)"' AND BOOK_NAME = 'GHAT REC'"));
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								mSG[DC_Main.i, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["ITM_NWT"])), "0.000");
							}
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT ITM_GWT,KR_KUNDAN_WT,KR_WAX_WT FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND DESIGN_NO = '"), DC_Main.Rshlp.Rows[0]["DESIGN_NO"]), (object)""), (object)"' AND BOOK_NAME = 'JDTR REC'"));
							dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count > 0)
							{
								mSG[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["KR_KUNDAN_WT"])), "0.000");
								mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["KR_WAX_WT"])), "0.000");
								mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["KR_WAX_WT"])), "0.000");
							}
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(mSG[DC_Main.i, 23]) != 0.0))
							{
								mSG[mSG.Row, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG[mSG.Row, 23]) * 100.0 / Conversion.Val(mSG[mSG.Row, 18]))), "0.00");
								mSG[mSG.Row, 79] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG[mSG.Row, 23]) * 100.0 / Conversion.Val(mSG[mSG.Row, 18]))), "0.00");
							}
							mSG[DC_Main.i, 36] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OLD_LBR_AMT"]))), "0.00");
							if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK322NSVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK134NEVK", false) == 0))
							{
								if (Operators.CompareString(mSG[DC_Main.i, 31], "G", false) == 0)
								{
									mSG[DC_Main.i, 35] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 36]) / Conversion.Val(mSG[DC_Main.i, 14])), "0.00");
								}
								else
								{
									mSG[DC_Main.i, 35] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 36]) / Conversion.Val(mSG[DC_Main.i, 16])), "0.00");
								}
							}
							mSG[DC_Main.i, 37] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OLD_OTH"]))), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK322NSVK", false) != 0)
							{
								mSG[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							}
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
							{
								mSG[mSG.Row, 91] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
								mSG[mSG.Row, 92] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
								mSG[mSG.Row, 90] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)"")));
								mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
								mSG[mSG.Row, 94] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
							}
							text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ENTRY_TYPE"], (object)""));
						}
						int num5 = 0;
						int num6 = DtIdtl.Rows.Count - 1;
						int num7 = num6;
						for (int i = 0; i <= num7; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num5][38], (object)Conversion.Val(mSG[DC_Main.i, 62]), false))
							{
								DtIdtl.Rows[num5].Delete();
								DtIdtl.AcceptChanges();
								num5--;
							}
							num5++;
						}
						MSG_IDTL_CLEAR();
						if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
						{
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 103] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 104] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 105] + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "' AND A.ENTRY_TYPE = '" + text + "' AND A.INOUT_TYPE = 'I' ";
						}
						else if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
						{
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 91] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 92] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 4] + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "' AND A.ENTRY_TYPE = '" + text + "' AND A.INOUT_TYPE = 'I' ";
						}
						else
						{
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 91] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 92] + "' AND A.VCH_NO = '" + TEXT_ENTRY.Text + "' AND A.TAG_NO = '" + mSG[mSG.Row, 7] + "' AND A.ENTRY_TYPE = '" + text + "' AND A.INOUT_TYPE = 'I' ";
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[38] = Conversion.Val(MSG[mSG.Row, 62]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = "";
							dr[4] = "";
							dr[5] = "";
							dr[6] = "";
							dr[7] = "";
							dr[8] = "";
							dr[9] = "";
							dr[10] = 0;
							dr[11] = 0;
							dr[12] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[13] = 0;
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[15] = 0;
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[17] = 0;
							dr[18] = 0;
							dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[24] = 0;
							dr[25] = 0;
							dr[26] = 0;
							dr[27] = "";
							dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])) == 0.0)
							{
								dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							}
							dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"], (object)"")), "0.000");
							dr[37] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						break;
					}
					case 8:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "SELECT MODEL_NAME  From MODEL_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND MODEL_NAME = '" + TEXT_ENTRY.Text + "' ";
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
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								return;
							}
						}
						break;
					case 9:
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row - 1, 9], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "SELECT ITM_COLOR  From BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ITM_COLOR = '" + TEXT_ENTRY.Text + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0 && unchecked((int)Interaction.MsgBox((object)"Add New Color ? ", (MsgBoxStyle)292, (object)"Message")) != 6)
						{
							DC_Main.RsQry = "SELECT DISTINCT ITM_COLOR as ColorL From BAR_DETL ORDER BY ITM_COLOR";
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
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
							}
						}
						break;
					case 7:
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
						{
							int num21 = mSG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num21)
							{
								if ((Operators.CompareString(mSG[DC_Main.X, 7], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Design No", (MsgBoxStyle)0, (object)null);
									return;
								}
								DC_Main.X++;
							}
							DC_Main.RsQry = "SELECT DESIGN_NO  From BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DESIGN_NO = '" + TEXT_ENTRY.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if ((DC_Main.Rshlp.Rows.Count != 0) & (Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0))
							{
								Interaction.MsgBox((object)"Duplicate Design No", (MsgBoxStyle)0, (object)null);
								return;
							}
							break;
						}
						if ((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 7], "", false) != 0))
						{
							mSG[mSG.Row, 101] = "N";
							MsgOldRow = 0;
						}
						if (Operators.CompareString(DC_Main.MsDesignMastHelp, "Y", false) == 0)
						{
							if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row - 1, 7], false) != 0)))
							{
								break;
							}
							DC_Main.RsQry = "SELECT LBR_RATE,LBR_AMT,DESIGN_NO  From BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND DESIGN_NO = '" + TEXT_ENTRY.Text + "' ORDER BY VCH_DATE DESC";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								if (unchecked((int)Interaction.MsgBox((object)"Add New Design ? ", (MsgBoxStyle)292, (object)"Message")) != 6)
								{
									DC_Main.RsQry = "SELECT DISTINCT DESIGN_NO as DesignL From BAR_DETL ORDER BY DESIGN_NO";
									DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
									DC_Main.ColWidth = new double[2];
									DC_Main.ColWidth[0] = 350.0;
									DC_Main.HelpSelect = 1;
									DC_Main.HelpSelect = 1;
									((Form)MyProject.Forms.MS_HELP).ShowDialog();
									if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[0];
									}
									return;
								}
							}
							else if (Operators.CompareString(DC_Main.MsMfgType, "B", false) == 0)
							{
								if (Conversion.Val(mSG[mSG.Row, 32]) == 0.0)
								{
									mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
								}
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])) == 0.0)
								{
									mSG[mSG.Row, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
								}
							}
						}
						else
						{
							if (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row - 1, 7], false) != 0)
							{
								break;
							}
							mSG[mSG.Row, 101] = mSG[mSG.Row - 1, 101];
							if (Operators.CompareString(mSG[mSG.Row - 1, 101], "N", false) == 0)
							{
								break;
							}
							DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 101] + "' AND IMAGE_TYPE = 'D'";
							RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
							if (RsImg.Rows.Count > 0)
							{
								if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
								{
									PicImage.Image = null;
									return;
								}
								object obj6 = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
								byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj6));
								object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
								PicImage.Image = (Image)objectValue;
							}
						}
						break;
					case 6:
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
									mSG[mSG.Row, 6] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 11:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0)
						{
							mSG[mSG.Row, 11] = TEXT_ENTRY.Text;
							((Control)nHmWt).Focus();
							return;
						}
						break;
					case 14:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(MSG[MSG.Row, 63], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && ((Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)) && mSG.Row == mSG.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 3] + "' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 7], "", false) == 0, (object)" AND IT_DESIGN = 'N' ", (object)("AND IT_DESIGN = '" + mSG[mSG.Row, 7] + "'"))), (object)" AND FROM_WT <= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)" AND TO_WT >= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)""));
							}
							else
							{
								DC_Main.RsQry = ("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 3] + "' AND FROM_WT <= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " AND TO_WT >= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text))) ?? "";
							}
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_CODE"], (object)""), (object)"", false))
								{
									mSG[mSG.Row, 32] = "";
									mSG[mSG.Row, 33] = "";
									mSG[mSG.Row, 30] = "";
									mSG[mSG.Row, 25] = "";
									mSG[mSG.Row, 28] = "";
									mSG[mSG.Row, 50] = "";
									mSG[mSG.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_CODE"], (object)""));
								}
								else if (Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_AMT"], (object)"")) != 0.0)
								{
									mSG[mSG.Row, 31] = "";
									mSG[mSG.Row, 32] = "";
									mSG[mSG.Row, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_AMT"], (object)"")), "0.00");
								}
								else
								{
									if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"F", false))
									{
										mSG[mSG.Row, 31] = "";
										mSG[mSG.Row, 32] = "";
										mSG[mSG.Row, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_AMT"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"G", false))
									{
										mSG[mSG.Row, 31] = "G";
										mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"K", false))
									{
										mSG[mSG.Row, 31] = "G";
										mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"P", false))
									{
										mSG[mSG.Row, 31] = "P";
										mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else
									{
										mSG[mSG.Row, 31] = "N";
										mSG[mSG.Row, 32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_PRC"], (object)"")), "0.00");
									mSG[mSG.Row, 25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["GHT_PRC"], (object)"")), "0.00");
								}
							}
						}
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0)
						{
							MSG_IDTL.Row = 1;
						}
						else
						{
							MSG_IDTL.Row = 1;
						}
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 24:
					{
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						string text3 = mSG[mSG.Row, 24];
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_ENTRY.Text + "'";
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
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									text4 = Strings.Mid(DC_Main.ColValue[0], 1, 2);
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						if (Operators.CompareString(text3, TEXT_ENTRY.Text, false) != 0)
						{
							mSG[mSG.Row, 32] = "";
							mSG[mSG.Row, 33] = "";
							mSG[mSG.Row, 30] = "";
							mSG[mSG.Row, 25] = "";
							mSG[mSG.Row, 28] = "";
							mSG[mSG.Row, 50] = "";
						}
						text4 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG[mSG.Row, 24] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text4)
						{
						case "01":
							mSG[mSG.Row, 32] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG[mSG.Row, 33] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG[mSG.Row, 28] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "05":
							mSG[mSG.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG[mSG.Row, 31] = "K";
							mSG[mSG.Row, 32] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG[mSG.Row, 50] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal();
						break;
					}
					case 51:
						if (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) == 0)
						{
							DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + MSG[MSG.Row, 67];
							DC_Main.MsImageType = "TagImage";
							DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
							if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
							{
								UT_WEB_CAM uT_WEB_CAM = new UT_WEB_CAM();
								((Form)uT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
								((Control)uT_WEB_CAM).Show();
								((Control)uT_WEB_CAM).Focus();
								return;
							}
						}
						break;
					case 53:
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK134NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK056NEVK", false) == 0))
						{
							DC_Main.RsQry = "SELECT AC_SHORT FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_SHORT = '" + TEXT_ENTRY.Text + "' AND AC_SHORT <> ''";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT AC_NAME As KarigarL,AC_SHORT as CodeL  FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_SHORT <> '' ORDER BY AC_NAME";
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
										mSG[mSG.Row, 53] = DC_Main.ColValue[1];
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
						}
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 53] = TEXT_ENTRY.Text;
							if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
							{
								TempSave((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));
							}
							if (Operators.CompareString(DC_Main.MsTagRowAutoPrint, "Y", false) == 0)
							{
								TagLastRowPrint((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));
							}
							if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG[mSG.Row, 5] + "','" + mSG[mSG.Row, 67] + "','" + mSG[mSG.Row, 65] + "','" + mSG[mSG.Row, 66] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG[mSG.Row, 5] + "','" + mSG[mSG.Row, 67] + "','" + mSG[mSG.Row, 65] + "','" + mSG[mSG.Row, 66] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							else if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
							{
								if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
								{
									DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','OLD','" + tVchNo.Text + "','" + mSG[mSG.Row, 5] + "','" + mSG[mSG.Row, 67] + "','" + mSG[mSG.Row, 65] + "','" + mSG[mSG.Row, 66] + "')";
									DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								}
								else if (Operators.CompareString(mSG[mSG.Row, 69], "A", false) == 0)
								{
									DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG[mSG.Row, 5] + "','" + mSG[mSG.Row, 67] + "','" + mSG[mSG.Row, 65] + "','" + mSG[mSG.Row, 66] + "')";
									DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								}
							}
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
							{
								mSG.Col = 1;
							}
							else if (((Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0) | (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
							{
								mSG.Col = 2;
							}
							else
							{
								mSG.Col = 3;
							}
							MsgClear = false;
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
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0 && Operators.CompareString(FormMainBook, "TAG GEN", false) == 0 && Conversion.Val(nitGwt.Text) < Conversion.Val(MSG_TOT[0, 14]))
					{
						Interaction.MsgBox((object)"You Cant Generate New Tag Plese Add Stock First", (MsgBoxStyle)0, (object)null);
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

	private void TagLastRowPrint(int L)
	{
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Expected O, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
		DC_Main.ExeQuteDc("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_STYLE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L) + " ");
		if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
		{
			QRCodeGenerator val = new QRCodeGenerator();
			QRCodeData val2 = val.CreateQrCode(MSG[L, 5], (ECCLevel)2, false, false, (EciMode)0, -1);
			QRCode val3 = new QRCode(val2);
			PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
			MemoryStream memoryStream = new MemoryStream();
			PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
			byte[] value = memoryStream.ToArray();
			DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[L, 5] + "' AND VCH_SRNO = " + MSG[L, 67] + " ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = dataTable.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["SR_NO"] = L;
			dataRow["TAG_NO"] = MSG[L, 5];
			dataRow["VCH_SRNO"] = Conversion.Val(MSG[L, 67]);
			dataRow["TAG_IMAGE"] = value;
			dataTable.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
			dataTable.Clear();
		}
		DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
		Cr.SelectionFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
		Cr.Destination = (DestinationConstants)1;
		Cr.Action = -1;
		DC_Main.MsPrintStatus = false;
	}

	private void TempSave(int L)
	{
		if (Operators.CompareString(TmpEntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
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
			DC_Main.RsQry = "DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if ((Conversion.Val(MSG_TOT[0, 50]) != 0.0) | (Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 34]) != 0.0))
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
				DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow2 = RsData.NewRow();
				dataRow2["CO_CODE"] = DC_Main.MCo_code;
				dataRow2["LC_CODE"] = DC_Main.MLc_code;
				dataRow2["CO_YEAR"] = DC_Main.MCo_year;
				dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow2["VCH_NO"] = tVchNo.Text;
				dataRow2["VCH_DATE"] = mVchDate.Text;
				dataRow2["STK_IT_CODE"] = tItCode.Text;
				dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
				dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow2["EMP_CODE"] = tEmpCode.Text;
				dataRow2["VCH_DESC"] = tVchDesc.Text;
				dataRow2["DATA_TRFR"] = "N";
				dataRow2["MAIN_USER"] = MainUser;
				RsData.Rows.Add(dataRow2);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
				RsData.Clear();
			}
			TmpEntryMode = "E";
		}
		DC_Main.RsQry = ("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = ("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow3 = RsDetl.NewRow();
		AxMSFlexGrid mSG = MSG;
		if ((Operators.CompareString(mSG[L, 3], "", false) != 0) & (Operators.CompareString(mSG[L, 5], "", false) != 0) & (Conversion.Val(mSG[L, 50]) + Conversion.Val(mSG[L, 14]) != 0.0))
		{
			dataRow3["CO_CODE"] = DC_Main.MCo_code;
			dataRow3["LC_CODE"] = DC_Main.MLc_code;
			dataRow3["CO_YEAR"] = DC_Main.MCo_year;
			dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow3["VCH_NO"] = tVchNo.Text;
			dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow3["VCH_DATE"] = mVchDate.Text;
			dataRow3["STK_DATE"] = mVchDate.Text;
			dataRow3["VCH_TYPE"] = FormBookSname;
			dataRow3["INOUT_TYPE"] = FormBookInOut;
			dataRow3["ENTRY_TYPE"] = "O";
			dataRow3["BOOK_NAME"] = FormMainBook;
			dataRow3["SR_NO"] = Conversion.Val(mSG[L, 0]);
			dataRow3["OLD_SRNO"] = Conversion.Val(mSG[L, 62]);
			dataRow3["IT_CODE"] = mSG[L, 3];
			dataRow3["TAG_NO"] = mSG[L, 5];
			dataRow3["TBL_CODE"] = mSG[L, 6];
			dataRow3["DESIGN_NO"] = mSG[L, 7];
			dataRow3["ITM_SIZE"] = mSG[L, 10];
			dataRow3["ITM_STYLE"] = mSG[L, 8];
			dataRow3["HM_ID"] = mSG[L, 11];
			dataRow3["BAG_WT"] = Conversion.Val(mSG[L, 12]);
			dataRow3["ITM_PCS"] = Conversion.Val(mSG[L, 13]);
			dataRow3["ITM_GWT"] = Conversion.Val(mSG[L, 14]);
			dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[L, 15]);
			dataRow3["ITM_NWT"] = Conversion.Val(mSG[L, 16]);
			dataRow3["KR_OTH_WT"] = Conversion.Val(mSG[L, 17]);
			dataRow3["KR_NET_WT"] = Conversion.Val(mSG[L, 18]);
			dataRow3["KR_GHT_PRC"] = Conversion.Val(mSG[L, 19]);
			dataRow3["KR_GHT_WT"] = Conversion.Val(mSG[L, 20]);
			dataRow3["KR_TOUCH"] = Conversion.Val(mSG[L, 21]);
			dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[L, 22]);
			dataRow3["KR_FINE"] = Conversion.Val(mSG[L, 23]);
			dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[L, 25]);
			dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[L, 26]);
			dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[L, 27]);
			dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[L, 28]);
			dataRow3["ITM_FINE"] = Conversion.Val(mSG[L, 29]);
			dataRow3["LBR_PRC"] = Conversion.Val(mSG[L, 30]);
			dataRow3["LBR_TYPE"] = mSG[L, 31];
			dataRow3["LBR_RATE"] = Conversion.Val(mSG[L, 32]);
			dataRow3["LBR_AMT"] = Conversion.Val(mSG[L, 33]);
			dataRow3["OTH_AMT"] = Conversion.Val(mSG[L, 34]);
			dataRow3["KR_LBR_RATE"] = Conversion.Val(mSG[L, 35]);
			dataRow3["KR_LBR_AMT"] = Conversion.Val(mSG[L, 36]);
			dataRow3["KR_OTH_AMT"] = Conversion.Val(mSG[L, 37]);
			dataRow3["KR_COST"] = Conversion.Val(mSG[L, 45]);
			dataRow3["ITM_RATE"] = Conversion.Val(mSG[L, 43]);
			dataRow3["ITM_AMT"] = Conversion.Val(mSG[L, 44]);
			dataRow3["TAG_COST"] = Conversion.Val(mSG[L, 46]);
			dataRow3["ITM_MARGIN"] = Conversion.Val(mSG[L, 49]);
			dataRow3["ITM_MRP"] = Conversion.Val(mSG[L, 50]);
			dataRow3["ITM_REMARK"] = mSG[L, 52];
			dataRow3["KR_NAME"] = mSG[L, 53];
			dataRow3["TAG_SRNO"] = Conversion.Val(mSG[L, 61]);
			dataRow3["RATE_TYPE"] = mSG[L, 63];
			dataRow3["IT_TYPE"] = mSG[L, 64];
			dataRow3["TAG_TYPE"] = mSG[L, 65];
			dataRow3["PR_CODE"] = mSG[L, 66];
			if (Conversion.Val(mSG[L, 67]) == 0.0)
			{
				dataRow3["VCH_SRNO"] = DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tVchNo.Text + Conversions.ToString(Conversion.Val(mSG[L, 62]));
			}
			else
			{
				dataRow3["VCH_SRNO"] = Conversion.Val(mSG[L, 67]);
			}
			if (Operators.CompareString(mSG[L, 81], "", false) == 0)
			{
				dataRow3["APR_ISU"] = "N";
			}
			else
			{
				dataRow3["APR_ISU"] = mSG[L, 81];
			}
			dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow3["DATA_TRFR"] = "N";
			dataRow3["DATA_TYPE"] = mSG[L, 89];
			dataRow3["HM_ID2"] = mSG[L, 82];
			dataRow3["HM_ID3"] = mSG[L, 83];
			dataRow3["HM_ID4"] = mSG[L, 84];
			dataRow3["HM_ID_WT"] = Conversion.Val(mSG[L, 85]);
			dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[L, 86]);
			dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[L, 87]);
			dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[L, 88]);
			dataRow3["MAIN_USER"] = MainUser;
			RsDetl.Rows.Add(dataRow3);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
			RsDetl.Clear();
			DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SRNO = '" + Strings.Mid(mSG[L, 67], 7, 6) + "' AND TAG_NO = '" + mSG[L, 5] + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + Strings.Mid(mSG[L, 67], 7, 6) + "','" + mSG[L, 67] + "','" + mSG[L, 5] + "','" + mSG[L, 3] + "')";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		mSG = null;
		DC_Main.RsQry = ("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = ("SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow4 = RsIdtl.NewRow();
		checked
		{
			int num = MSG_IDTL.Rows - 1;
			for (int i = 1; i <= num; i++)
			{
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				if (Conversion.Val(mSG_IDTL[i, 12]) + Conversion.Val(mSG_IDTL[i, 19]) + Conversion.Val(mSG_IDTL[i, 34]) != 0.0)
				{
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = "O";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = L;
					dataRow4["TAG_NO"] = MSG[L, 5];
					if (Conversion.Val(MSG[L, 67]) == 0.0)
					{
						dataRow4["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MSG[L, 62];
					}
					else
					{
						dataRow4["VCH_SRNO"] = MSG[L, 67];
					}
					dataRow4["ISR_NO"] = Conversion.Val(mSG_IDTL[i, 0]);
					dataRow4["IT_CODE"] = mSG_IDTL[i, 1];
					dataRow4["DM_CODE"] = mSG_IDTL[i, 3];
					dataRow4["DM_NAME"] = mSG_IDTL[i, 4];
					dataRow4["DM_COLOR"] = mSG_IDTL[i, 5];
					dataRow4["DM_SIZE"] = mSG_IDTL[i, 6];
					dataRow4["DM_ORIGIN"] = mSG_IDTL[i, 7];
					dataRow4["DM_REMARK"] = mSG_IDTL[i, 8];
					dataRow4["DM_SFNO"] = mSG_IDTL[i, 9];
					dataRow4["IT_PCS"] = Conversion.Val(mSG_IDTL[i, 12]);
					dataRow4["IT_PCS_WT"] = Conversion.Val(mSG_IDTL[i, 13]);
					dataRow4["IT_GWT"] = Conversion.Val(mSG_IDTL[i, 19]);
					dataRow4["KR_ACT_WT"] = Conversion.Val(mSG_IDTL[i, 14]);
					dataRow4["KR_ACT_PRC"] = Conversion.Val(mSG_IDTL[i, 15]);
					dataRow4["KR_WT"] = Conversion.Val(mSG_IDTL[i, 16]);
					dataRow4["KR_LESS_PRC"] = Conversion.Val(mSG_IDTL[i, 17]);
					dataRow4["KR_LESS_WT"] = Conversion.Val(mSG_IDTL[i, 18]);
					dataRow4["IT_CON_PRC"] = Conversion.Val(mSG_IDTL[i, 20]);
					dataRow4["IT_RATE_TYPE"] = mSG_IDTL[i, 21];
					dataRow4["IT_RATE"] = Conversion.Val(mSG_IDTL[i, 22]);
					dataRow4["IT_AMT"] = Conversion.Val(mSG_IDTL[i, 23]);
					dataRow4["IT_DISC_PRC"] = Conversion.Val(mSG_IDTL[i, 24]);
					dataRow4["IT_DISC_AMT"] = Conversion.Val(mSG_IDTL[i, 25]);
					dataRow4["KR_CON_PRC"] = Conversion.Val(mSG_IDTL[i, 26]);
					dataRow4["KR_RATE_TYPE"] = mSG_IDTL[i, 27];
					dataRow4["KR_RATE"] = Conversion.Val(mSG_IDTL[i, 28]);
					dataRow4["KR_AMT"] = Conversion.Val(mSG_IDTL[i, 29]);
					dataRow4["KR_LBR_RATE"] = Conversion.Val(mSG_IDTL[i, 30]);
					dataRow4["KR_LBR_AMT"] = Conversion.Val(mSG_IDTL[i, 31]);
					dataRow4["IT_LBR_RATE"] = Conversion.Val(mSG_IDTL[i, 32]);
					dataRow4["IT_LBR_AMT"] = Conversion.Val(mSG_IDTL[i, 33]);
					dataRow4["IT_NET_AMT"] = Conversion.Val(mSG_IDTL[i, 34]);
					dataRow4["IT_CON_WT"] = Conversion.Val(mSG_IDTL[i, 35]);
					dataRow4["IT_TYPE"] = mSG_IDTL[i, 37];
					dataRow4["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				mSG_IDTL = null;
			}
		}
	}

	private void RepitTagNo(int Y)
	{
		double num = 0.0;
		if (Operators.CompareString(OldTagItm, MSG[Y, 66] + MSG[Y, 65], false) != 0)
		{
			OldTagItm = MSG[Y, 66] + MSG[Y, 65];
			if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = 'OLD' ");
			}
			else
			{
				DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = 'OLD' ");
			}
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				if (Operators.CompareString(EntryMode, "A", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> 'N' AND SUBSTRING(TAG_NO,1,2) = '" + MSG[Y, 66] + "' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 65] + "' AND  B.PR_CODE = '" + MSG[Y, 66] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 66]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 65]), (object)"'"));
				}
				else
				{
					DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 65] + "' AND  B.PR_CODE = '" + MSG[Y, 66] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO";
				}
			}
			else if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 65] + "' AND  B.PR_CODE = '" + MSG[Y, 66] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 66]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 65]), (object)"'"));
			}
			else if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 65] + "' AND  B.PR_CODE = '" + MSG[Y, 66] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 66]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 65]), (object)"'"));
			}
			else
			{
				DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 65] + "' AND  B.PR_CODE = '" + MSG[Y, 66] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO ";
			}
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		checked
		{
			DataTable dataTable;
			DataTable dataTable2;
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,4) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG[Y, 65] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "0001";
					int num2 = 1;
					int num3 = 0;
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND  PR_CODE = '" + MSG[Y, 66] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num = Conversion.Val(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 4));
						num3++;
						if ((double)num3 != num)
						{
							CurRptTagNo = Strings.Format((object)num3, "0000");
							break;
						}
						DC_Main.X++;
					}
					if (num3 >= num2)
					{
						CurRptTagNo = Strings.Format((object)(num3 + 1), "0000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num2 = (int)Math.Round(a);
					int num3 = 0;
					CurRptTagNo = Strings.Format((object)(num2 + 1), "0000");
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND  PR_CODE = '" + MSG[Y, 66] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num4 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num = Conversion.Val(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 7));
						num3++;
						if ((double)num3 != num)
						{
							CurRptTagNo = Strings.Format((object)num3, "0000");
							num4 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num4 != Conversion.Val((object)num3))
					{
						CurRptTagNo = Strings.Format((object)(num3 + 1), "0000");
					}
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,5) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG[Y, 66] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG[Y, 65] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "00001";
					int num2 = 1;
					int num3 = 0;
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND  PR_CODE = '" + MSG[Y, 66] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num = Conversion.Val(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable2.Rows[DC_Main.X]["TAG_NO"], (object)"")), 4, 5));
						num3++;
						if ((double)num3 != num)
						{
							CurRptTagNo = Strings.Format((object)num3, "00000");
							break;
						}
						DC_Main.X++;
					}
					if (num3 >= num2)
					{
						CurRptTagNo = Strings.Format((object)(num3 + 1), "00000");
					}
				}
				else
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["SrNo"]);
					double a2 = DC_Main.Fnv(ref Value);
					dataRow["SrNo"] = RuntimeHelpers.GetObjectValue(Value);
					int num2 = (int)Math.Round(a2);
					int num3 = 0;
					CurRptTagNo = Strings.Format((object)(num2 + 1), "00000");
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 65] + "' AND  PR_CODE = '" + MSG[Y, 66] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num5 = 0.0;
					DC_Main.X = 0;
					while (DC_Main.X < dataTable2.Rows.Count)
					{
						num = Conversion.Val(Strings.Mid(Conversions.ToString(dataTable2.Rows[DC_Main.X]["TAG_NO"]), 4, 5));
						num3++;
						if ((double)num3 != num)
						{
							CurRptTagNo = Strings.Format((object)num3, "00000");
							num5 = Conversions.ToDouble(CurRptTagNo);
							break;
						}
						DC_Main.X++;
					}
					if (num5 != Conversion.Val((object)num3))
					{
						CurRptTagNo = Strings.Format((object)(num3 + 1), "00000");
					}
				}
			}
			MSG[Y, 61] = Conversions.ToString(Conversion.Val(CurRptTagNo));
			MSG[Y, 5] = MSG[Y, 66] + MSG[Y, 65] + CurRptTagNo;
			TEXT_ENTRY.Text = MSG[Y, 5];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(MSG[Y, 66], "", false) == 0)
		{
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0) & (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0))
		{
			DC_Main.NewYearTagGen(MSG[Y, 66], MSG[Y, 65]);
			MSG[Y, 5] = DC_Main.MsNewTagNo;
			return;
		}
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			RepitTagNo(Y);
			return;
		}
		if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
		{
			string tagPrefix = "";
			if (Operators.CompareString(Module_Save.MsRendomWithPrCode, "Y", false) == 0)
			{
				tagPrefix = MSG[Y, 66] + MSG[Y, 65];
			}
			string text = Module_Save.RendomTagGen(DC_Main.MCo_Book, tagPrefix);
			if (Operators.CompareString(text, "", false) != 0)
			{
				MSG[Y, 5] = text;
				TEXT_ENTRY.Text = text;
			}
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG[Y, 66] + "'  AND TAG_TYPE = '" + mSG[Y, 65] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=9  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG[Y, 66] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG[Y, 65] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
			else
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG[Y, 66] + "'  AND TAG_TYPE = '" + mSG[Y, 65] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=10  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG[Y, 66] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG[Y, 65] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
		}
		else if ((Operators.CompareString(DC_Main.MCo_Type, "", false) != 0) & (Operators.CompareString(DC_Main.MCo_Type, "P", false) != 0))
		{
			DC_Main.RsQry = "Select SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) As TAG_SRNO FROM SRNO_MAST As A LEFT JOIN ITEM_MAST As B On A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG[Y, 66] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG[Y, 65] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
		}
		else
		{
			DC_Main.RsQry = "SELECT TOP 2 TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG[Y, 66] + "'  AND TAG_TYPE = '" + mSG[Y, 65] + "' GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
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
		else if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			if (dataTable.Rows.Count > 1)
			{
				if (Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) > Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[1]["TAG_SRNO"], (object)"")))
				{
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["TAG_SRNO"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
					CurTagNo = Strings.Format((object)(num + 1.0), "0000");
				}
				else
				{
					object Value = Operators.ConcatenateObject(dataTable.Rows[1]["TAG_SRNO"], (object)"");
					CurTagNo = Strings.Format((object)(DC_Main.Fnv(ref Value) + 1.0), "0000");
				}
			}
			else
			{
				object Value = Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"");
				CurTagNo = Strings.Format((object)(DC_Main.Fnv(ref Value) + 1.0), "0000");
			}
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				CurTagNo = Strings.Format((object)Conversion.Val(CurTagNo), "0000");
			}
			else
			{
				CurTagNo = Strings.Format((object)Conversion.Val(CurTagNo), "00000");
			}
		}
		else if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			DataRow dataRow;
			object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["TAG_SRNO"]);
			double num2 = DC_Main.Fnv(ref Value);
			dataRow["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
			CurTagNo = Strings.Format((object)(num2 + 1.0), "0000");
		}
		else
		{
			DataRow dataRow;
			object Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable.Rows[0])["TAG_SRNO"]);
			double num3 = DC_Main.Fnv(ref Value);
			dataRow["TAG_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
			CurTagNo = Strings.Format((object)(num3 + 1.0), "00000");
		}
		checked
		{
			int num4 = mSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num4)
			{
				if (Operators.CompareString(mSG[Y, 5], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG[DC_Main.i, 66], mSG[Y, 66], false) == 0) & (Operators.CompareString(mSG[DC_Main.i, 65], mSG[Y, 65], false) == 0) & (Conversion.Val(mSG[DC_Main.i, 61]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG[DC_Main.i, 61]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 61]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 61]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG[mSG.Row, 61] = CurTagNo;
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG[mSG.Row, 5] = mSG[Y, 66] + mSG[Y, 65] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG[mSG.Row, 5] = mSG[Y, 66] + mSG[Y, 65] + CurTagNo;
			}
			mSG = null;
			dataTable.Clear();
		}
	}

	private void TR_TAG_OPBL_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d0b: Expected O, but got Unknown
		//IL_0d30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3f: Expected O, but got Unknown
		//IL_0d7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d83: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8d: Expected O, but got Unknown
		//IL_0da7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db6: Expected O, but got Unknown
		//IL_0dd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddf: Expected O, but got Unknown
		//IL_0e07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0e: Expected O, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eae: Expected O, but got Unknown
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f45: Expected O, but got Unknown
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc2: Expected O, but got Unknown
		//IL_104a: Unknown result type (might be due to invalid IL or missing references)
		//IL_104f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1059: Expected O, but got Unknown
		//IL_107e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1083: Unknown result type (might be due to invalid IL or missing references)
		//IL_108d: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
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
			((Control)MSG_IDTL).Top = ((Control)nHmWt).Bottom + 7;
			((Control)PicImage).Height = ((Control)MSG_IDTL).Height;
			((Control)PicImage).Top = ((Control)MSG_IDTL).Top;
			((Control)BtnImgC).Top = ((Control)PicImage).Bottom + 5;
			((Control)BtnImgS).Top = ((Control)PicImage).Bottom + 5;
			((Control)BtnImgD).Top = ((Control)PicImage).Bottom + 5;
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
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj10 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj11 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj12 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				object? obj13 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG_IDTL2 = MSG_IDTL;
				object? obj14 = colorConverter.ConvertFromString("DarkGray");
				mSG_IDTL2.BackColorBkg = ((obj14 != null) ? ((Color)obj14) : default(Color));
				AxMSFlexGrid mSG_IDTL3 = MSG_IDTL;
				object? obj15 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_IDTL3.BackColorFixed = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj16 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj19 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj20 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj23 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj25 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj26 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)btnTagSet).Appearance;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				appearance2.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				ComboBox obj28 = cboPrintfile;
				object? obj29 = colorConverter.ConvertFromString("233, 235, 240");
				obj28.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj31 = lblBook;
				object? obj32 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj31).ForeColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj33 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj36 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj38 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj39 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj41 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj42 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AppearanceObject appearance3 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj43 = colorConverter.ConvertFromString("238, 244, 236");
				appearance3.BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AppearanceObject appearance4 = ((BaseStyleControl)btnTagSet).Appearance;
				object? obj44 = colorConverter.ConvertFromString("Cornsilk");
				appearance4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				ComboBox obj45 = cboPrintfile;
				object? obj46 = colorConverter.ConvertFromString("Cornsilk");
				obj45.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0)))
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
			if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'QR' ORDER BY PRINT_FILE";
			}
			else
			{
				DC_Main.RsQry = "SELECT * FROM PRINT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'TAG' ORDER BY PRINT_FILE";
			}
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			string text = "";
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboPrintfile.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboPrintfile.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_SET_A"], (object)""), (object)"Y", false))
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["PRINT_FILE"], (object)""));
					}
					DC_Main.X++;
				}
				cboPrintfile.SelectedIndex = 0;
			}
			else
			{
				cboPrintfile.Items.Add((object)"");
			}
			cboPrintfile.Text = text;
			if ((Operators.CompareString(DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
			{
				((Control)nLotTouch).Visible = false;
				((Control)nLotWestPrc).Visible = false;
			}
			else
			{
				((Control)nLotTouch).Visible = true;
				((Control)nLotWestPrc).Visible = true;
			}
			if (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0)
			{
				((Control)nLotTouch).Visible = false;
				((Control)nLotWestPrc).Visible = false;
			}
			if (Operators.CompareString(DC_Main.MsItmMfg, "Y", false) == 0)
			{
				((Control)Label12).Visible = true;
				((Control)tLotNo).Visible = true;
				((Control)nLotTouch).Visible = true;
				((Control)nLotWestPrc).Visible = true;
			}
			cboItType.Items.Add((object)"Gold");
			cboItType.Items.Add((object)"Silver");
			cboItType.Items.Add((object)"All");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItType.SelectedIndex = 0;
			}
			else
			{
				cboItType.SelectedIndex = 1;
			}
			cboPrintType.Items.Add((object)"Gold");
			cboPrintType.Items.Add((object)"Silver");
			cboPrintType.Items.Add((object)"Diamond");
			cboPrintType.Items.Add((object)"Platinum");
			cboPrintType.Items.Add((object)"Emitation");
			cboPrintType.Items.Add((object)"RealStone");
			cboPrintType.Items.Add((object)"Other");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboPrintType.SelectedIndex = 0;
			}
			else
			{
				cboPrintType.SelectedIndex = 1;
			}
			cboDataType.Items.Add((object)"A");
			cboDataType.Items.Add((object)"B");
			cboDataType.SelectedIndex = 0;
			if (((Operators.CompareString(DC_Main.SSRegSrNo, "HM290NAPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM446NAPK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "AK095NAAK", false) == 0)) & (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0))
			{
				((Control)lblDataType).Visible = true;
				((Control)cboDataType).Visible = true;
			}
			if ((Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) & (Operators.CompareString(DC_Main.MsDataType, "C", false) == 0))
			{
				((Control)lblDataType).Visible = true;
				((Control)cboDataType).Visible = true;
			}
			DC_Main.RsQry = "SELECT A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.OLD_SRNO,A.TAG_NO,A.IT_CODE,B.PR_CODE,B.IT_TYPE,B.TAG_TYPE,A.VCH_SRNO FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.VCH_SRNO = 0 OR A.PR_CODE = '' OR A.IT_TYPE = ''";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			while (DC_Main.M < DC_Main.Tbl.Rows.Count)
			{
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["VCH_SRNO"], (object)""), (object)0, false))
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET VCH_SRNO = " + Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), 6, 4)), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), (object)",PR_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["PR_CODE"]), (object)"',IT_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_TYPE"]), (object)"',TAG_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_TYPE"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"' AND VCH_SRNO = 0")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_IDTL SET VCH_SRNO = " + Strings.Mid(Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), 6, 4)), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), DC_Main.Tbl.Rows[DC_Main.M]["OLD_SRNO"]), (object)" WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"' AND VCH_SRNO = 0")));
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET TAG_SRNO = RIGHT(TAG_NO,4) WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
						DC_Main.ExeQuteDc(DC_Main.RsQry);
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAR_DETL SET TAG_SRNO = RIGHT(TAG_NO,5) WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'"));
					}
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"UPDATE BAR_DETL SET PR_CODE = '", DC_Main.Tbl.Rows[DC_Main.M]["PR_CODE"]), (object)"',IT_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_TYPE"]), (object)"',TAG_TYPE = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_TYPE"]), (object)"' WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND TAG_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"' ")));
				}
				DC_Main.M++;
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				((Control)Label7).Visible = false;
				((Control)nHmWt).Visible = false;
				((Control)Label8).Visible = false;
				((Control)tHmId2).Visible = false;
				((Control)nHmWt2).Visible = false;
				((Control)Label9).Visible = false;
				((Control)tHmId3).Visible = false;
				((Control)nHmWt3).Visible = false;
				((Control)Label10).Visible = false;
				((Control)tHmId4).Visible = false;
				((Control)nHmWt4).Visible = false;
			}
			switch (DC_Main.SSRegSrNo)
			{
			case "HM340NEKU":
			case "VK142NEVK":
			case "HM285NEKU":
			case "HM407NEKU":
			case "VK191NEVK":
			case "VK052NEVK":
			case "HM328NEKU":
			case "HM427NEHP":
			case "HM606NEKU":
			case "VK113NEVK":
			case "VK250NEPH":
			case "VK253NEVK":
			case "VK106NEVK":
			case "VK289NEPH":
			case "AK011NEAK":
			case "HM287NEKU":
			case "VK272NAST":
			case "HM776NUKU":
				((Control)btnRfid).Visible = true;
				((Control)lblPrintType).Visible = true;
				((Control)cboPrintType).Visible = true;
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(380.0 * ColCon);
				break;
			default:
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(460.0 * ColCon);
				break;
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
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		StkSaleVchDel = false;
		UsUPdate = "N";
		UsDelete = "N";
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		OldValTot = 0.0;
		NewValTot = 0.0;
		OldTagItm = "";
		((Control)BtnSave).Enabled = true;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) == 0)
		{
			cboDataType.SelectedIndex = 1;
		}
		else
		{
			cboDataType.SelectedIndex = 0;
		}
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		ToDayRateFill = false;
		ItCodeLock = true;
		if (Operators.CompareString(FormMainBook, "TAG GEN", false) == 0)
		{
			((Control)tItCode).Visible = true;
			((Control)tItName).Visible = true;
			((Control)Label3).Visible = true;
			((Control)Label15).Visible = true;
			((Control)nPcs).Visible = true;
			((Control)nItNwt).Visible = true;
			((Control)nitGwt).Visible = true;
			if (Operators.CompareString(DC_Main.MsPurcLot, "Y", false) == 0)
			{
				((Control)Label12).Visible = true;
				((Control)tLotNo).Visible = true;
				if ((Operators.CompareString(DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
				{
					((Control)nLotTouch).Visible = false;
					((Control)nLotWestPrc).Visible = false;
				}
				else
				{
					((Control)nLotTouch).Visible = true;
					((Control)nLotWestPrc).Visible = true;
				}
			}
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
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
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			TmpEntryMode = "A";
			EntryMode = "A";
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HD_VCH_NO"], (object)""));
				tLotNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LOT_NO"], (object)""));
				DC_Main.RsQry = "Select A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As WestPrc FROM PR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.LOT_NO = '" + tLotNo.Text + "'    UNION ALL Select ITM_TOUCH,ITM_WEST_PRC FROM KR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND LOT_NO = '" + tLotNo.Text + "'   ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					nLotTouch.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItTouch"]), "0.00");
					nLotWestPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WestPrc"]), "0.00");
				}
				tItCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["STK_IT_CODE"], (object)""));
				DC_Main.RsQry = "SELECT IT_NAME FROM ITEM_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["IT_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsIt = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsIt.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsIt.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_DESC"], (object)""));
				MainUser = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_USER"], (object)""));
				UsUPdate = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_UPDATE"], (object)""));
				UsDelete = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["USER_DELETE"], (object)""));
				DataTrfr = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DATA_TRFR"], (object)""));
				if (Operators.CompareString(DC_Main.MCo_Book, "000", false) != 0 && Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RE_TRFR"], (object)""), (object)"Y", false))
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
				EntryMode = "E";
				TmpEntryMode = "E";
				if (Operators.CompareString(MsVchSrno, "", false) == 0)
				{
					DC_Main.RsQry = "Select Max(TAG_SRNO) AS SrNo FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND LEN(TAG_SRNO) = 6 Having Max(TAG_SRNO) > 0";
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
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 102] = Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.i]["STK_DATE"]), "dd/MM/yyyy");
					if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					}
					else
					{
						mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 99] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 109] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 110] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 111] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_COST"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SL_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 108] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOT_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GWT_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["MAIN_MARGIN_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 98] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["MAIN_MARGIN_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["MAIN_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG[DC_Main.i + 1, 96] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_SRNO"])), "0");
					mSG[DC_Main.i + 1, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"])), "0");
					mSG[DC_Main.i + 1, 81] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["APR_ISU"], (object)""));
					mSG[DC_Main.i + 1, 69] = "E";
					mSG[DC_Main.i + 1, 89] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 82] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 83] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 84] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 86] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 87] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 88] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 90] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_SRNO"], (object)"")), "0");
					mSG[DC_Main.i + 1, 91] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 92] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 94] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_AC"], (object)""));
					mSG[DC_Main.i + 1, 95] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_LC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_JDT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_WT"])), "0.000");
					mSG[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_NET"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 100] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["EMP_ISU"], (object)""));
					mSG[DC_Main.i + 1, 101] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					if ((Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
					{
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_NO"], (object)""));
						mSG[DC_Main.i + 1, 105] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_NO"], (object)""));
						mSG[DC_Main.i + 1, 107] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ORD_NO"], (object)""));
					}
					else
					{
						mSG[DC_Main.i + 1, 105] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 103] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 104] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 106] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MFG_SRNO"], (object)"")), "0");
					mSG[DC_Main.i + 1, 97] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["SF_NO"], (object)""));
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
				int num = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[38] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[8] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[9] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[10] = 0;
					dr[11] = 0;
					dr[12] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
					if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
					{
						dr[13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"], (object)"")), "0.000000");
					}
					else
					{
						dr[13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"], (object)"")), "0.0000");
					}
					dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_WT"], (object)"")), "0.000");
					dr[15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_PRC"], (object)"")), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"], (object)"")), "0.000");
					dr[17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"], (object)"")), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_WT"], (object)"")), "0.000");
					dr[39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"], (object)"")), "0.000");
					dr[19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
					dr[40] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
					dr[20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"], (object)"")), "0.000");
					dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"], (object)"")), "0.00");
					dr[23] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"], (object)"")), "0.00");
					dr[24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_DISC_PRC"], (object)"")), "0.00");
					dr[25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_DISC_AMT"], (object)"")), "0.00");
					dr[26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_PRC"], (object)"")), "0.000");
					dr[27] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_RATE_TYPE"], (object)"");
					dr[28] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_RATE"], (object)"")), "0.00");
					dr[29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_AMT"], (object)"")), "0.00");
					dr[30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_RATE"], (object)"")), "0.00");
					dr[31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_AMT"], (object)"")), "0.00");
					dr[32] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"], (object)"")), "0.00");
					dr[33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"], (object)"")), "0.00");
					dr[34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"], (object)"")), "0.00");
					dr[35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"], (object)"")), "0.000");
					dr[36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[37] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 50]);
				NewValTot = Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 18]) + Conversion.Val(MSG_TOT[0, 34]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 50]);
				OldTagItm = "";
				EntryMode = "E";
				TmpEntryMode = "E";
				((TextBoxBase)tVchNo).ReadOnly = true;
				((Control)mVchDate).Focus();
			}
			else
			{
				((Control)mVchDate).Focus();
				EntryMode = "A";
				TmpEntryMode = "A";
			}
		}
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((DC_Main.M == 1) & (Conversion.Val(MSG[DC_Main.M, 14]) + Conversion.Val(MSG[DC_Main.M, 50]) == 0.0))
					{
						((Form)this).Close();
						return;
					}
					if (Operators.CompareString(MSG[DC_Main.M, 69], "A", false) == 0)
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			((Form)this).Close();
		}
	}

	private void TR_TAG_OPBL_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_TAG_OPBL_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_373a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_3710: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0575: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b9: Expected O, but got Unknown
		//IL_24da: Unknown result type (might be due to invalid IL or missing references)
		//IL_24e1: Expected O, but got Unknown
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Strings.Len(tVchNo.Text) < 2)
		{
			Interaction.MsgBox((object)"Please Change VchNo its Not Valid......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
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
			((Control)BtnSave).Enabled = true;
			((Control)tEmpCode).Focus();
			return;
		}
		if (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0)
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not Grater Then Closing Date... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Error Found : Please Enter Book Detail First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		checked
		{
			if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if (Operators.CompareString(MSG[DC_Main.M, 6], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Counter Code and Try Because It is Mandatory...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						MSG.Row = DC_Main.M;
						MSG.Col = 6;
						MSG_EnterCell(MSG, new EventArgs());
						((Control)BtnSave).Enabled = true;
						((Control)TEXT_ENTRY).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			if ((Operators.CompareString(FormMainBook, "TAG GEN", false) == 0) & (Operators.CompareString(tItCode.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Stock item code Insert First...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				((Control)BtnSave).Enabled = true;
				((Control)tItCode).Focus();
				return;
			}
			((Control)BtnSave).Enabled = false;
			Application.DoEvents();
			DC_Main.MsTagVchSrnoUpdate = false;
			if (Operators.CompareString(EntryMode, "A", false) == 0 && Operators.CompareString(TmpEntryMode, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
						tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
					}
				}
				DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
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
			MSG_TOT_FILL();
			Module_Save.TagEntTran = null;
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Module_Save.TagEntTran = DC_Main.Dc.BeginTransaction();
				DC_Main.RsQry = "DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				DC_Main.RsQry = "DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				DC_Main.RsQry = "DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				if ((Conversion.Val(MSG_TOT[0, 50]) != 0.0) | (Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 34]) != 0.0))
				{
					Module_Save.ExeQuteDcSave("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ", Module_Save.TagEntTran);
					DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
					DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					Module_Save.MsInsertDataSave(Module_Save.TagEntTran);
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow["VCH_NO"] = tHdVchNo.Text;
					dataRow["BOOK_NAME"] = FormName;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					Module_Save.MsInsertDataSave(Module_Save.TagEntTran);
					DataRow dataRow2 = RsData.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_YEAR"] = DC_Main.MCo_year;
					dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["VCH_NO"] = tVchNo.Text;
					dataRow2["VCH_DATE"] = mVchDate.Text;
					dataRow2["STK_IT_CODE"] = tItCode.Text;
					dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow2["LOT_NO"] = tLotNo.Text;
					dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow2["EMP_CODE"] = tEmpCode.Text;
					dataRow2["VCH_DESC"] = tVchDesc.Text;
					if (Operators.CompareString(DC_Main.MCo_Book, "000", false) == 0)
					{
						if (Operators.CompareString(DataTrfr, "", false) == 0)
						{
							DataTrfr = "N";
						}
						dataRow2["DATA_TRFR"] = DataTrfr;
					}
					else
					{
						dataRow2["DATA_TRFR"] = "N";
						if (Operators.CompareString(DataTrfr, "Y", false) == 0)
						{
							dataRow2["RE_TRFR"] = "Y";
						}
						else
						{
							dataRow2["RE_TRFR"] = "N";
						}
					}
					dataRow2["MAIN_USER"] = MainUser;
					dataRow2["USER_UPDATE"] = "N";
					dataRow2["USER_DELETE"] = "N";
					RsData.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
					RsData.Clear();
				}
				DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				Module_Save.MsInsertDataSave(Module_Save.TagEntTran);
				DataRow dataRow3 = RsDetl.NewRow();
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					AxMSFlexGrid mSG = MSG;
					if ((Operators.CompareString(mSG[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 5], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 50]) + Conversion.Val(mSG[DC_Main.i, 14]) + Conversion.Val(mSG[DC_Main.i, 33]) + Conversion.Val(mSG[DC_Main.i, 34]) != 0.0))
					{
						dataRow3["CO_CODE"] = DC_Main.MCo_code;
						dataRow3["LC_CODE"] = DC_Main.MLc_code;
						dataRow3["CO_YEAR"] = DC_Main.MCo_year;
						dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow3["VCH_NO"] = tVchNo.Text;
						dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow3["VCH_DATE"] = mVchDate.Text;
						if (Operators.CompareString(mSG[DC_Main.i, 69], "E", false) != 0)
						{
							dataRow3["STK_DATE"] = mVchDate.Text;
						}
						else
						{
							dataRow3["STK_DATE"] = mSG[DC_Main.i, 102];
						}
						dataRow3["VCH_TYPE"] = FormBookSname;
						dataRow3["INOUT_TYPE"] = FormBookInOut;
						dataRow3["ENTRY_TYPE"] = "O";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["LOT_NO"] = tLotNo.Text;
						dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 62]);
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 3];
						dataRow3["TAG_NO"] = mSG[DC_Main.i, 5];
						dataRow3["TBL_CODE"] = mSG[DC_Main.i, 6];
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
						{
							dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 1];
						}
						else
						{
							dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 7];
						}
						dataRow3["ITM_STYLE"] = mSG[DC_Main.i, 8];
						dataRow3["ITM_COLOR"] = mSG[DC_Main.i, 9];
						dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 10];
						dataRow3["HM_ID"] = mSG[DC_Main.i, 11];
						dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow3["KR_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 17]);
						if (Conversion.Val((object)mSG[18]) == 0.0)
						{
							dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 16]);
						}
						else
						{
							if (Conversion.Val(mSG[DC_Main.i, 18]) == 0.0)
							{
								dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 16]);
							}
							dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 18]);
						}
						if (Conversion.Val(mSG[DC_Main.i, 21]) == 0.0)
						{
							if ((mSG[21] == 0) & (Operators.CompareString(tLotNo.Text, "", false) != 0) & (Conversion.Val(nLotTouch.Text) != 0.0))
							{
								if (Operators.CompareString(mSG[DC_Main.i, 69], "A", false) == 0)
								{
									dataRow3["KR_TOUCH"] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");
									dataRow3["KR_WEST_PRC"] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");
									if ((Conversion.Val(mSG[DC_Main.i, 18]) != 0.0) & (Conversion.Val(nLotTouch.Text) != 0.0))
									{
										dataRow3["KR_FINE"] = Strings.Format((object)((Conversion.Val(mSG[DC_Main.i, 18]) + Conversion.Val(mSG[DC_Main.i, 20])) * (Conversion.Val(nLotTouch.Text) + Conversion.Val(nLotWestPrc.Text)) / 100.0), "0.00");
									}
								}
								else if (Conversion.Val(mSG[DC_Main.i, 109]) != 0.0)
								{
									dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 109]);
									dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 110]);
									dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 111]);
								}
							}
							else
							{
								dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 27]);
								dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 28]);
								dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 29]);
							}
						}
						else
						{
							dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 21]);
							dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 22]);
							dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 23]);
						}
						dataRow3["KR_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow3["KR_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 25]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 26]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 27]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 28]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 29]);
						dataRow3["LBR_CODE"] = mSG[DC_Main.i, 24];
						dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 30]);
						dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 31];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 32]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 33]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 34]);
						dataRow3["KR_LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 35]);
						dataRow3["KR_LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 36]);
						dataRow3["KR_OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 37]);
						dataRow3["KR_COST"] = Conversion.Val(mSG[DC_Main.i, 45]);
						dataRow3["SL_TYPE"] = mSG[DC_Main.i, 38];
						dataRow3["KR_OTH_RATE"] = Conversion.Val(mSG[DC_Main.i, 39]);
						dataRow3["KR_OTH_FINE"] = Conversion.Val(mSG[DC_Main.i, 40]);
						dataRow3["KR_TOT_FINE"] = Conversion.Val(mSG[DC_Main.i, 41]);
						dataRow3["KR_GWT_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 42]);
						dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 43]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 44]);
						if (Operators.CompareString(DC_Main.SSRegSrNo, "AK019NEAK", false) == 0)
						{
							if (mSG[46] == 0)
							{
								dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 45]);
							}
							else
							{
								dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 46]);
							}
						}
						else
						{
							dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 46]);
						}
						dataRow3["MAIN_MARGIN_PRC"] = Conversion.Val(mSG[DC_Main.i, 47]);
						dataRow3["MAIN_MRP"] = Conversion.Val(mSG[DC_Main.i, 48]);
						dataRow3["ITM_MARGIN"] = Conversion.Val(mSG[DC_Main.i, 49]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 50]);
						dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 52];
						dataRow3["KR_NAME"] = mSG[DC_Main.i, 53];
						dataRow3["TAG_SRNO"] = Conversion.Val(mSG[DC_Main.i, 61]);
						dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 63];
						dataRow3["IT_TYPE"] = mSG[DC_Main.i, 64];
						dataRow3["TAG_TYPE"] = mSG[DC_Main.i, 65];
						dataRow3["PR_CODE"] = mSG[DC_Main.i, 66];
						if (Conversion.Val(mSG[DC_Main.i, 67]) == 0.0)
						{
							dataRow3["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MSG[DC_Main.i, 62];
						}
						else
						{
							dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 67]);
						}
						if (Operators.CompareString(mSG[DC_Main.i, 81], "", false) == 0)
						{
							dataRow3["APR_ISU"] = "N";
						}
						else
						{
							dataRow3["APR_ISU"] = mSG[DC_Main.i, 81];
						}
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow3["DATA_TRFR"] = "N";
						dataRow3["DATA_TYPE"] = mSG[DC_Main.i, 89];
						dataRow3["HM_ID2"] = mSG[DC_Main.i, 82];
						dataRow3["HM_ID3"] = mSG[DC_Main.i, 83];
						dataRow3["HM_ID4"] = mSG[DC_Main.i, 84];
						dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 85]);
						dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 86]);
						dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 87]);
						dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 88]);
						dataRow3["ORD_NO"] = mSG[DC_Main.i, 4];
						dataRow3["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 90]);
						dataRow3["ORD_YRCD"] = mSG[DC_Main.i, 91];
						dataRow3["ORD_DBCD"] = mSG[DC_Main.i, 92];
						dataRow3["ORD_AC"] = mSG[DC_Main.i, 94];
						dataRow3["ORD_LC_CODE"] = mSG[DC_Main.i, 95];
						dataRow3["SF_NO"] = mSG[DC_Main.i, 97];
						dataRow3["JDT_JDT_WT"] = Conversion.Val(mSG[DC_Main.i, 54]);
						dataRow3["JDT_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 55]);
						dataRow3["JDT_KUN_WT"] = Conversion.Val(mSG[DC_Main.i, 56]);
						dataRow3["JDT_KUN_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 57]);
						dataRow3["JDT_KUN_NET"] = Conversion.Val(mSG[DC_Main.i, 58]);
						dataRow3["JDT_WAX_WT"] = Conversion.Val(mSG[DC_Main.i, 59]);
						dataRow3["KR_WAX_WT"] = Conversion.Val(mSG[DC_Main.i, 60]);
						dataRow3["EMP_ISU"] = mSG[DC_Main.i, 100];
						dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 101];
						dataRow3["MAIN_USER"] = MainUser;
						if ((Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0) & (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0))
						{
							dataRow3["MFG_NO"] = mSG[DC_Main.i, 2];
							dataRow3["ORD_NO"] = mSG[DC_Main.i, 107];
						}
						else
						{
							dataRow3["MFG_NO"] = mSG[DC_Main.i, 105];
						}
						dataRow3["MFG_YRCD"] = mSG[DC_Main.i, 103];
						dataRow3["MFG_DBCD"] = mSG[DC_Main.i, 104];
						dataRow3["MFG_SRNO"] = Conversion.Val(mSG[DC_Main.i, 106]);
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG = null;
					DC_Main.i++;
				}
				int num3 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num3)
				{
					AxMSFlexGrid mSG2 = MSG;
					if (Operators.CompareString(mSG2[DC_Main.i, 97], "", false) != 0)
					{
						DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SRNO = '" + mSG2[DC_Main.i, 61] + "' AND TAG_NO = '" + mSG2[DC_Main.i, 5] + "'";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
						DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + mSG2[DC_Main.i, 61] + "','" + mSG2[DC_Main.i, 67] + "','" + mSG2[DC_Main.i, 5] + "','" + mSG2[DC_Main.i, 3] + "')";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					}
					else
					{
						DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + mSG2[DC_Main.i, 61] + "','" + mSG2[DC_Main.i, 67] + "','" + mSG2[DC_Main.i, 5] + "','" + mSG2[DC_Main.i, 3] + "')";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					}
					mSG2 = null;
					DC_Main.i++;
				}
				if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM IMAGE_DATA", Module_Save.TagEntTran);
					DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
					DataTable dataTable2 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					Module_Save.MsInsertDataSave(Module_Save.TagEntTran);
					DataRow dataRow4 = dataTable2.NewRow();
					int num4 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num4)
					{
						AxMSFlexGrid mSG3 = MSG;
						if ((Operators.CompareString(mSG3[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(mSG3[DC_Main.i, 5], "", false) != 0) & (Conversion.Val(mSG3[DC_Main.i, 50]) + Conversion.Val(mSG3[DC_Main.i, 14]) != 0.0))
						{
							QRCodeGenerator val = new QRCodeGenerator();
							QRCodeData val2 = val.CreateQrCode(MSG[DC_Main.i, 5], (ECCLevel)2, false, false, (EciMode)0, -1);
							QRCode val3 = new QRCode(val2);
							PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
							MemoryStream memoryStream = new MemoryStream();
							PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
							byte[] value = memoryStream.ToArray();
							dataRow4["CO_CODE"] = DC_Main.MCo_code;
							dataRow4["LC_CODE"] = DC_Main.MLc_code;
							dataRow4["SR_NO"] = DC_Main.i;
							dataRow4["TAG_NO"] = MSG[DC_Main.i, 5];
							dataRow4["VCH_SRNO"] = Conversion.Val(MSG[DC_Main.i, 67]);
							dataRow4["TAG_IMAGE"] = value;
							dataTable2.Rows.Add(dataRow4);
							((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
							dataTable2.Clear();
						}
						mSG3 = null;
						DC_Main.i++;
					}
				}
				DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				Module_Save.MsInsertDataSave(Module_Save.TagEntTran);
				DataRow dataRow5 = RsIdtl.NewRow();
				int num5 = 0;
				int num6 = 1;
				int num7 = 0;
				bool flag = false;
				if (DtIdtl.Rows.Count > 0)
				{
					DataView dataView = new DataView(DtIdtl);
					dataView.Sort = "RowSrNo Asc";
					DtIdtl = dataView.ToTable();
				}
				int num8 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num8; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][34])) != 0.0)
					{
						if ((double)num7 != Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])))
						{
							num7 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])));
							num6 = 1;
						}
						int num9 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num9)
						{
							if (Conversion.Val(MSG[DC_Main.M, 62]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])))
							{
								num5 = DC_Main.M;
								flag = false;
								break;
							}
							flag = true;
							DC_Main.M++;
						}
						if (!flag)
						{
							dataRow5["CO_CODE"] = DC_Main.MCo_code;
							dataRow5["LC_CODE"] = DC_Main.MLc_code;
							dataRow5["CO_YEAR"] = DC_Main.MCo_year;
							dataRow5["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow5["VCH_NO"] = tVchNo.Text;
							dataRow5["VCH_DATE"] = mVchDate.Text;
							dataRow5["VCH_TYPE"] = FormBookSname;
							dataRow5["INOUT_TYPE"] = FormBookInOut;
							dataRow5["ENTRY_TYPE"] = "O";
							dataRow5["BOOK_NAME"] = FormMainBook;
							dataRow5["SR_NO"] = Conversion.Val(MSG[num5, 62]);
							dataRow5["TAG_NO"] = MSG[num5, 5];
							if (Conversion.Val(MSG[num5, 67]) == 0.0)
							{
								dataRow5["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MSG[num5, 62];
							}
							else
							{
								dataRow5["VCH_SRNO"] = Conversion.Val(MSG[num5, 67]);
							}
							dataRow5["ISR_NO"] = num6;
							dataRow5["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
							dataRow5["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
							dataRow5["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
							dataRow5["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
							dataRow5["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
							dataRow5["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
							dataRow5["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]);
							dataRow5["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]);
							dataRow5["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
							dataRow5["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
							dataRow5["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]));
							dataRow5["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
							dataRow5["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
							dataRow5["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
							dataRow5["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
							dataRow5["KR_LESS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
							dataRow5["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
							dataRow5["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]);
							dataRow5["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
							dataRow5["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]));
							dataRow5["IT_DISC_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][24]));
							dataRow5["IT_DISC_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25]));
							dataRow5["KR_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26]));
							dataRow5["KR_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][27]);
							dataRow5["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][28]));
							dataRow5["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29]));
							dataRow5["KR_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][30]));
							dataRow5["KR_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][31]));
							dataRow5["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][32]));
							dataRow5["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][33]));
							dataRow5["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][34]));
							dataRow5["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][35]));
							dataRow5["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][36]));
							dataRow5["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][37]);
							dataRow5["MAIN_USER"] = MainUser;
							num6++;
							RsIdtl.Rows.Add(dataRow5);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
							RsIdtl.Clear();
						}
					}
					dtIdtl = null;
				}
				if (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0)
				{
					DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'Y' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.MFG_YRCD  AND MFG_DETL.CO_BOOK = B.MFG_DBCD AND MFG_DETL.VCH_NO = B.MFG_NO AND MFG_DETL.OLD_SRNO = B.MFG_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
					Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				}
				if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0)
				{
					if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
					{
						DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'Y' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.MFG_YRCD  AND MFG_DETL.CO_BOOK = B.MFG_DBCD AND MFG_DETL.VCH_NO = B.MFG_NO AND MFG_DETL.OLD_SRNO = B.MFG_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
						DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'Y' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					}
					else
					{
						DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'Y' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.ORD_YRCD  AND MFG_DETL.CO_BOOK = B.ORD_DBCD AND MFG_DETL.VCH_NO = B.ORD_NO AND MFG_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
					}
				}
				DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'Y' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				Ac_Stock.Tag_Opbl_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				Ac_Stock.TagGen_Lot(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.TagEntTran);
				Ac_Stock.Dm_Tag_Detl(DC_Main.MCo_Book, tVchNo.Text);
				Module_Save.ExeQuteDcSave("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ", Module_Save.TagEntTran);
				Module_Save.TagEntTran.Commit();
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
				}
				CurPrnVch = tVchNo.Text;
				CLEAR_DATA();
				BtnPrint_Click(BtnPrint, new EventArgs());
				CurPrnVch = "";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.TagEntTran.Rollback();
					Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
					Module_Save.TagEntTran = null;
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0192: Invalid comparison between Unknown and I4
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a6: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) != 0 && !StkSaleVchDel)
		{
			DC_Main.RsQry = "SELECT * FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO IN (SELECT TAG_NO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "') AND ITM_SIGN = '-'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete This Voucher Because  Tag Use in Sales Transection....", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,'',0,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM BAR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
		DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (Operators.CompareString(FormMainBook, "MFG TAG", false) == 0)
		{
			DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.MFG_YRCD  AND MFG_DETL.CO_BOOK = B.MFG_DBCD AND MFG_DETL.VCH_NO = B.MFG_NO AND MFG_DETL.OLD_SRNO = B.MFG_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		if (Operators.CompareString(FormMainBook, "JDTR TAG", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
			{
				DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.MFG_YRCD  AND MFG_DETL.CO_BOOK = B.MFG_DBCD AND MFG_DETL.VCH_NO = B.MFG_NO AND MFG_DETL.OLD_SRNO = B.MFG_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'N' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,BAR_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.ORD_YRCD  AND MFG_DETL.CO_BOOK = B.ORD_DBCD AND MFG_DETL.VCH_NO = B.ORD_NO AND MFG_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
		}
		DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'N' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 5] + "' AND VCH_SRNO = '" + MSG[DC_Main.M, 67] + "'");
				DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + MSG[DC_Main.M, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.M, 67]))) ?? "";
				DC_Main.ExeQuteImg(DC_Main.RsQry);
				DC_Main.M++;
			}
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_TAG_OPBL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			checked
			{
				if (OldValTot == NewValTot)
				{
					((Form)this).Close();
				}
				else if (((Control)TEXT_ENTRY).Visible)
				{
					MSG_LeaveCell(MSG, new EventArgs());
					MSG.Row = MSG.Rows - 1;
					MSG.Col = 0;
					((Control)TEXT_ENTRY).Visible = false;
					MSG_TOT_FILL();
					((Control)tEmpCode).Focus();
				}
				else if (((Control)TEXT_IDTL).Visible)
				{
					((Control)TEXT_IDTL).Visible = false;
					MSG.Col += 1;
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + CurPrnVch + "'," + Conversions.ToString(DC_Main.i) + ",'00',0)";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.i++;
			}
			if ((Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0) & (Operators.CompareString(EntryMode, "E", false) == 0) & (MSG.Rows > 1))
			{
				DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					QRCodeGenerator val = new QRCodeGenerator();
					QRCodeData val2 = val.CreateQrCode(MSG[DC_Main.M, 5], (ECCLevel)2, false, false, (EciMode)0, -1);
					QRCode val3 = new QRCode(val2);
					PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
					MemoryStream memoryStream = new MemoryStream();
					PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
					byte[] value = memoryStream.ToArray();
					DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 5] + "' AND VCH_SRNO = " + MSG[DC_Main.M, 67] + " ";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["SR_NO"] = DC_Main.M;
					dataRow["TAG_NO"] = MSG[DC_Main.M, 5];
					dataRow["VCH_SRNO"] = Conversion.Val(MSG[DC_Main.M, 67]);
					dataRow["TAG_IMAGE"] = value;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					DC_Main.M++;
				}
			}
			DC_Main.ExeQuteDc("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + CurPrnVch + "'");
			DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			((Form)MyProject.Forms.MS_PRINT).ShowDialog();
			if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsCustMail = "";
				DC_Main.MsCustWappNo = "";
				string text = cboPrintfile.Text;
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptName = text;
				DC_Main.RptFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "'";
				if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
				{
					Module_Save.PrintReportDirect();
					Application.DoEvents();
				}
				else
				{
					Module_Save.ShowReportPreview();
				}
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + cboPrintfile.Text + ".RPT";
				Cr.SelectionFormula = "{TAG_PRINT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' ";
				if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
				{
					Cr.Destination = (DestinationConstants)1;
					Cr.Action = -1;
				}
				else
				{
					Cr.Destination = (DestinationConstants)0;
					Cr.WindowState = (WindowStateConstants)2;
					Cr.Action = -1;
					Cr.PageZoom((short)DC_Main.MsPrintZoom);
				}
				DC_Main.MsPrintStatus = false;
			}
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0 && MSG.Row != 1)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((Operators.CompareString(MSG[DC_Main.M, 69], "A", false) == 0) & (Conversion.Val(MSG[DC_Main.M, 50]) + Conversion.Val(MSG[DC_Main.M, 14]) != 0.0))
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			CLEAR_DATA();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_TAG_OPBL_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(DC_Main.MsSoftHang, "Y", false) == 0)
		{
			DC_Main.SoftLoad();
		}
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
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			Image image;
			using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
			{
				image = Image.FromStream(stream);
			}
			PicImage.Image = image;
			Mobile_image_Save(MSG.Row);
		}
		else
		{
			PicImage.Image = null;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			TEXT_ENTRY.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
			((Control)TEXT_ENTRY).Focus();
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT VCH_NO As VchNoL,replace(convert(NVARCHAR,VCH_DATE, 103), ' ', '/') AS VchDateL,STK_IT_CODE As StkItCodeL,VCH_DESC As RemarkL,MAIN_USER As UserL FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 130.0;
		DC_Main.ColWidth[2] = 100.0;
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
		//IL_10ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f7: Expected O, but got Unknown
		//IL_0d99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0da3: Expected O, but got Unknown
		//IL_0f9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected O, but got Unknown
		//IL_1298: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a2: Expected O, but got Unknown
		if (MsgClear || MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 68] + " : It Name";
		tHmId2.Text = MSG[MSG.Row, 82];
		tHmId3.Text = MSG[MSG.Row, 83];
		tHmId4.Text = MSG[MSG.Row, 84];
		nHmWt.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 85]), "0.000");
		nHmWt2.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 86]), "0.000");
		nHmWt3.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 87]), "0.000");
		nHmWt4.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 88]), "0.000");
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
				if (Conversion.Val(MSG[MSG.Row, 62]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][38])))
				{
					MSG_IDTL[num4, 0] = Conversions.ToString(num4);
					MSG_IDTL[num4, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
					MSG_IDTL[num4, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
					MSG_IDTL[num4, 3] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][3], (object)""));
					MSG_IDTL[num4, 4] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][4], (object)""));
					MSG_IDTL[num4, 5] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][5], (object)""));
					MSG_IDTL[num4, 6] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][6], (object)""));
					MSG_IDTL[num4, 7] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][7], (object)""));
					MSG_IDTL[num4, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][8], (object)""));
					MSG_IDTL[num4, 9] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][9], (object)""));
					MSG_IDTL[num4, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
					MSG_IDTL[num4, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
					MSG_IDTL[num4, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
					MSG_IDTL[num4, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
					MSG_IDTL[num4, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
					MSG_IDTL[num4, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
					MSG_IDTL[num4, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
					MSG_IDTL[num4, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num4, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
					MSG_IDTL[num4, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
					MSG_IDTL[num4, 20] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][20], (object)""));
					MSG_IDTL[num4, 21] = Conversions.ToString(DtIdtl.Rows[i][21]);
					MSG_IDTL[num4, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
					MSG_IDTL[num4, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
					MSG_IDTL[num4, 24] = Conversions.ToString(DtIdtl.Rows[i][24]);
					MSG_IDTL[num4, 25] = Conversions.ToString(DtIdtl.Rows[i][25]);
					MSG_IDTL[num4, 26] = Conversions.ToString(DtIdtl.Rows[i][26]);
					MSG_IDTL[num4, 27] = Conversions.ToString(DtIdtl.Rows[i][27]);
					MSG_IDTL[num4, 28] = Conversions.ToString(DtIdtl.Rows[i][28]);
					MSG_IDTL[num4, 29] = Conversions.ToString(DtIdtl.Rows[i][29]);
					MSG_IDTL[num4, 30] = Conversions.ToString(DtIdtl.Rows[i][30]);
					MSG_IDTL[num4, 31] = Conversions.ToString(DtIdtl.Rows[i][31]);
					MSG_IDTL[num4, 32] = Conversions.ToString(DtIdtl.Rows[i][32]);
					MSG_IDTL[num4, 33] = Conversions.ToString(DtIdtl.Rows[i][33]);
					MSG_IDTL[num4, 34] = Conversions.ToString(DtIdtl.Rows[i][34]);
					MSG_IDTL[num4, 35] = Conversions.ToString(DtIdtl.Rows[i][35]);
					MSG_IDTL[num4, 36] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][36], (object)""));
					MSG_IDTL[num4, 37] = Conversions.ToString(DtIdtl.Rows[i][37]);
					MSG_IDTL[num4, 38] = Conversions.ToString(DtIdtl.Rows[i][38]);
					MSG_IDTL[num4, 39] = Conversions.ToString(DtIdtl.Rows[i][39]);
					MSG_IDTL[num4, 40] = Conversions.ToString(DtIdtl.Rows[i][40]);
					num += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][34]));
					num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][35]));
					num3 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][36], (object)""));
					MSG_IDTL.Rows += 1;
					num4++;
				}
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 15] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 16] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 14]) - Conversion.Val(MSG[MSG.Row, 15])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 17] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 18] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 14]) - Conversion.Val(MSG[MSG.Row, 17])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 34] = Strings.Format((object)num, "0.00");
			}
			CommPassTotal();
			if ((Operators.CompareString(MSG[MSG.Row, 101], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 7], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 101] + "' AND IMAGE_TYPE = 'D'";
				RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				if (RsImg.Rows.Count > 0)
				{
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
					{
						PicImage.Image = null;
						return;
					}
					object obj = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
					byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
					object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
					PicImage.Image = (Image)objectValue;
				}
				else
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 101];
					DC_Main.MsImageType = "TagImage";
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
			}
			else
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + MSG[MSG.Row, 67];
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				PicImage.Image = null;
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
				{
					try
					{
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 67]))) ?? "";
						RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (RsImg.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								ProjectData.ClearProjectError();
								return;
							}
							object obj2 = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
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
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 67]))) ?? "";
					RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					if (RsImg.Rows.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
						{
							PicImage.Image = null;
							return;
						}
						object obj3 = Operators.ConcatenateObject(RsImg.Rows[0]["MOB_IMAGE"], (object)"");
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
			MSG_IDTL[num4, 0] = Conversions.ToString(num4);
			MSG_IDTL[num4, 38] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 62]));
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
				SendKeys.Send("{tab}");
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image image;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						PicImage.Image = image;
						((Control)PicImage).Refresh();
						GC.Collect();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 217:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 217;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Expected O, but got Unknown
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0505: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					((FileDialog)DlgOpen).Filter = "JPEG (*.jpg)|*.jpg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
					{
						goto end_IL_0001;
					}
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						if (PicImage.Image != null)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
						}
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
					if (Operators.CompareString(FileSystem.Dir(Application.StartupPath + "\\temp.jpg", (FileAttribute)0), "", false) != 0)
					{
						FileSystem.Kill(Application.StartupPath + "\\temp.jpg");
					}
					float num3 = float.Parse(Conversions.ToString(1));
					Bitmap val = new Bitmap(PicImage.Image);
					int width = ((Image)val).Width;
					num3 = ((width > 5000) ? float.Parse(Conversions.ToString(0.5)) : ((width > 4500) ? float.Parse(Conversions.ToString(0.6)) : ((width > 4000) ? float.Parse(Conversions.ToString(0.7)) : ((width > 3500) ? float.Parse(Conversions.ToString(0.8)) : ((width > 3000) ? float.Parse(Conversions.ToString(0.75)) : ((width > 2500) ? float.Parse(Conversions.ToString(0.8)) : ((width <= 2000) ? float.Parse(Conversions.ToString(1)) : float.Parse(Conversions.ToString(0.9)))))))));
					checked
					{
						Bitmap val2 = new Bitmap((int)Math.Round((float)((Image)val).Width * num3), (int)Math.Round((float)((Image)val).Height * num3));
						Graphics val3 = Graphics.FromImage((Image)(object)val2);
						val3.SmoothingMode = (SmoothingMode)2;
						val3.InterpolationMode = (InterpolationMode)7;
						val3.PixelOffsetMode = (PixelOffsetMode)2;
						val3.DrawImage((Image)(object)val, 0, 0, ((Image)val2).Width + 1, ((Image)val2).Height + 1);
						PicImage.Image = (Image)(object)val2;
						PicImage.Image.Save(Application.StartupPath + "\\temp.jpg");
						long num4 = FileSystem.FileLen(Application.StartupPath + "\\temp.jpg");
						string text;
						if (num4 < 1000)
						{
							text = " Bytes";
						}
						else if (num4 > 1000000)
						{
							num4 = (long)Conversion.Int((double)num4 / 1000000.0);
							text = " Mb";
						}
						else
						{
							num4 = (long)Conversion.Int((double)num4 / 1000.0);
							text = " Kb";
						}
						string text2 = Conversions.ToString(num4) + text;
						int num5 = 100;
						if (Operators.CompareString(text, " Kb", false) != 0)
						{
							double num6 = Conversion.Val((object)num4);
							num5 = ((num6 > 30.0) ? 20 : ((num6 > 25.0) ? 30 : ((num6 > 20.0) ? 35 : ((num6 > 15.0) ? 40 : ((num6 > 10.0) ? 50 : ((num6 > 7.0) ? 55 : ((num6 > 5.0) ? 70 : ((num6 > 3.0) ? 75 : ((num6 > 2.0) ? 80 : ((!(num6 > 1.0)) ? 90 : 85))))))))));
						}
						Bitmap val4 = (Bitmap)Image.FromFile(Application.StartupPath + "\\temp.jpg");
						Ac_Image.SaveJPGWithCompressionSetting(PicImage.Image, DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg", num5);
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						((Image)val4).Dispose();
						Mobile_image_Save(MSG.Row);
						goto end_IL_0001;
					}
				}
				case 1457:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1457;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					ProjectData.ClearProjectError();
					num2 = 2;
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
					{
						goto end_IL_0001;
					}
					DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 67]))) ?? "";
					DC_Main.ExeQuteImg(DC_Main.RsQry);
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
						((Control)PicImage).Refresh();
						GC.Collect();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
					{
						DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + MSG[MSG.Row, 67];
						string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
						Ac_Image.FtpDeleteFile(ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
					}
					PicImage.Image = null;
					goto end_IL_0001;
				case 551:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit...."), (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 551;
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

	private void BtnFirst_Click(object sender, EventArgs e)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((Operators.CompareString(MSG[DC_Main.M, 69], "A", false) == 0) & (Conversion.Val(MSG[DC_Main.M, 50]) + Conversion.Val(MSG[DC_Main.M, 14]) != 0.0))
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			if (Conversion.Val(tVchNo.Text) < 2.0)
			{
				return;
			}
			string text = Strings.Format((object)(Conversion.Val(tVchNo.Text) - 1.0), "00000");
			DC_Main.i = 1;
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if ((Operators.CompareString(MSG[DC_Main.M, 69], "A", false) == 0) & (Conversion.Val(MSG[DC_Main.M, 50]) + Conversion.Val(MSG[DC_Main.M, 14]) != 0.0))
					{
						Interaction.MsgBox((object)"Please Save Voucher Befoure Exit...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						((Control)BtnSave).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			if (Conversion.Val(tVchNo.Text) >= Conversion.Val(LastVchNo))
			{
				Interaction.MsgBox((object)"Last Record...", (MsgBoxStyle)0, (object)null);
				((Control)tVchNo).Focus();
				return;
			}
			string text = Strings.Format((object)(Conversions.ToDouble(tVchNo.Text) + 1.0), "00000");
			DC_Main.i = 1;
			do
			{
				DC_Main.RsQry = "SELECT VCH_NO FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_TAG_OPBL_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		DC_Main.MsTagVchSrnoUpdate = false;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
		}
		if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
		}
		if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
		{
			DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void BtnTagSet_Click(object sender, EventArgs e)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
		{
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'QR' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = 'QR'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'N' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_TYPE = 'TAG' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE PRINT_MAST SET PRINT_SET_A = 'Y' WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND PRINT_FILE = '" + cboPrintfile.Text + "' AND PRINT_TYPE = 'TAG'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		Interaction.MsgBox((object)"Tag Print Report Default Set", (MsgBoxStyle)0, (object)null);
	}

	private void tLableSkip_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnPrint).Focus();
		}
	}

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + tItCode.Text + "' "), Interaction.IIf(cboItType.SelectedIndex == 2, (object)"", (object)("AND IT_TYPE = '" + Strings.Mid(cboItType.Text, 1, 1) + "'"))), (object)""));
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.IT_NAME As ItemNameL,A.IT_CODE As ItCodeL,B.GR_NAME AS GroupL FROM ITEM_MAST AS A LEFT JOIN GROUP_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(cboItType.SelectedIndex == 2, (object)"", (object)("AND A.IT_TYPE = '" + Strings.Mid(cboItType.Text, 1, 1) + "'"))), (object)"  ORDER BY IT_NAME"));
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 220.0;
			DC_Main.ColWidth[3] = 280.0;
			DC_Main.ColWidth[4] = 120.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tItCode.Text = DC_Main.ColValue[1];
					tItName.Text = DC_Main.ColValue[0];
				}
				((Control)tItCode).Focus();
			}
			return;
		}
		tItName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
		{
			MSG.Col = 1;
		}
		else
		{
			MSG.Col = 2;
		}
		MSG.Row = 1;
		MSG_EnterCell(MSG, new EventArgs());
		DC_Main.RsQry = "Select IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As Pcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS NetWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + tItCode.Text + "'  and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY IT_CODE";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			nPcs.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Pcs"]), "0");
			nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GrWt"]), "0.000");
			nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"]), "0.000");
		}
		else
		{
			nPcs.Text = Conversions.ToString(0);
			nitGwt.Text = Conversions.ToString(0);
			nItNwt.Text = Conversions.ToString(0);
		}
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM BAR_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save(int ImgRow)
	{
		AxMSFlexGrid mSG = MSG;
		DC_Main.MsImageNo = mSG[ImgRow, 5] + "_" + mSG[ImgRow, 67];
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
			using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
			{
				Image val = Image.FromStream(stream);
			}
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
				{
					string ftpuri = DC_Main.MsUrlPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
				}
				else
				{
					string ftpuri2 = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri2, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
				}
			}
			MemoryStream memoryStream = new MemoryStream();
			PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
			byte[] buffer = memoryStream.GetBuffer();
			string value = Convert.ToBase64String(buffer);
			DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[ImgRow, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[ImgRow, 67]))) ?? "";
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[ImgRow, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[ImgRow, 67]))) ?? "";
			RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = RsImg.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["TAG_NO"] = mSG[ImgRow, 5];
			dataRow["VCH_SRNO"] = Conversion.Val(mSG[ImgRow, 67]);
			dataRow["IMAGE_TYPE"] = "T";
			dataRow["MOB_IMAGE"] = value;
			RsImg.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
			RsImg.Clear();
		}
		mSG = null;
	}

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void nHmWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(nHmWt.Text, "", false) != 0)
			{
				nHmWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG.Col = 13;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void nHmWt2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId2.Text, "", false) != 0) & (Operators.CompareString(nHmWt2.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId2 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(nHmWt2.Text, "", false) != 0)
			{
				nHmWt2.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt2.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG.Col = 13;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void nHmWt3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId3.Text, "", false) != 0) & (Operators.CompareString(nHmWt3.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId3 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Operators.CompareString(nHmWt3.Text, "", false) != 0)
			{
				nHmWt3.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt3.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				HmDetlFeel();
				MSG.Col = 13;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void nHmWt4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId4.Text, "", false) != 0) & (Operators.CompareString(nHmWt4.Text, "", false) == 0))
			{
				Interaction.MsgBox((object)"Please Insert HmId4 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Conversions.ToDouble(nHmWt4.Text) != 0.0)
			{
				nHmWt4.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt4.Text)), "0.000");
				HmDetlFeel();
				MSG.Col = 13;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			else
			{
				HmDetlFeel();
				MSG.Col = 13;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void HmDetlFeel()
	{
		MSG[MSG.Row, 82] = tHmId2.Text;
		MSG[MSG.Row, 83] = tHmId3.Text;
		MSG[MSG.Row, 84] = tHmId4.Text;
		MSG[MSG.Row, 85] = nHmWt.Text;
		MSG[MSG.Row, 86] = nHmWt2.Text;
		MSG[MSG.Row, 87] = nHmWt3.Text;
		MSG[MSG.Row, 88] = nHmWt4.Text;
	}

	private void tHmId2_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId2.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			MSG.Col = 13;
			MSG.Row = MSG.Row;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tHmId3_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId3.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			MSG.Col = 13;
			MSG.Row = MSG.Row;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tHmId4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			DC_Main.MsTagVchSrnoUpdate = true;
		}
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId4.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			MSG.Col = 13;
			MSG.Row = MSG.Row;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void FlowLayoutPanel1_DoubleClick(object sender, EventArgs e)
	{
		StkSaleVchDel = true;
		((Control)btnTagReNumber).Visible = true;
		((Control)btnNewTagImg).Visible = true;
		((Control)btnOldNewtag).Visible = true;
		((Control)btnRfid).Visible = true;
		((Control)lblPrintType).Visible = true;
		((Control)cboPrintType).Visible = true;
		((Control)FlowLayoutPanel1).Width = 383;
		((Control)btnLastYearIdtl).Visible = true;
		((Control)btnMainStkToBarDetl).Visible = true;
	}

	~TR_TAG_OPBL()
	{
		((Component)this).Finalize();
	}

	private void cboItType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (cboItType.SelectedIndex == 0)
		{
			cboPrintType.SelectedIndex = 0;
		}
		else if (cboItType.SelectedIndex == 1)
		{
			cboPrintType.SelectedIndex = 1;
		}
		else
		{
			cboPrintType.SelectedIndex = 2;
		}
		if (Operators.CompareString(FormMainBook, "TAG GEN", false) == 0)
		{
			SendKeys.Send("{tab}");
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
		{
			MSG.Col = 1;
		}
		else
		{
			MSG.Col = 2;
		}
		MSG.Row = 1;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void TR_TAG_OPBL_KeyUp(object sender, KeyEventArgs e)
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

	private void BtnExel_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		object obj = default(object);
		object obj2 = default(object);
		object obj3 = default(object);
		int num6 = default(int);
		int num7 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		string text = default(string);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					object obj4;
					object[] obj5;
					object[] array;
					bool[] obj6;
					bool[] array2;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1665:
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
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_0042;
							case 7:
								goto IL_0059;
							case 8:
								goto IL_008b;
							case 9:
								goto IL_00b3;
							case 10:
								goto IL_00bc;
							case 11:
								goto IL_00e4;
							case 12:
								goto IL_0117;
							case 13:
								goto IL_011d;
							case 14:
								goto IL_015c;
							case 15:
								goto IL_016b;
							case 16:
								goto IL_0185;
							case 17:
								goto IL_018b;
							case 18:
								goto IL_01d4;
							case 19:
								goto IL_01e3;
							case 20:
								goto IL_01fb;
							case 21:
								goto IL_0205;
							case 22:
								goto IL_0258;
							case 23:
								goto IL_02ad;
							case 24:
								goto IL_0305;
							case 25:
								goto IL_0373;
							case 26:
								goto IL_03b6;
							case 27:
								goto IL_03e5;
							case 28:
								goto IL_0428;
							case 29:
								goto IL_0469;
							case 30:
								goto IL_0488;
							case 31:
								goto IL_04a6;
							case 32:
								goto IL_04fc;
							case 33:
								goto IL_052a;
							case 34:
								goto IL_0544;
							case 36:
								goto IL_0557;
							case 37:
								goto IL_0578;
							case 38:
								goto IL_0592;
							case 39:
								goto IL_0598;
							case 40:
								goto IL_059e;
							case 41:
								goto IL_05a3;
							case 42:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 35:
							case 43:
							case 44:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0185:
						num2 = 16;
						num5 = 0;
						goto IL_018b;
						IL_018b:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 1,
							num5 + 1,
							MSG[DC_Main.i, num5]
						}, (string[])null, (Type[])null);
						goto IL_01d4;
						IL_05a3:
						num2 = 41;
						GC.Collect();
						break;
						IL_01d4:
						num2 = 18;
						num5++;
						if (num5 <= 53)
						{
							goto IL_018b;
						}
						goto IL_01e3;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						((Control)this).Cursor = Cursors.WaitCursor;
						goto IL_0042;
						IL_0042:
						num2 = 6;
						obj2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_0059;
						IL_0059:
						num2 = 7;
						obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_008b;
						IL_008b:
						num2 = 8;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00b3;
						IL_00b3:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00bc;
						IL_00bc:
						num2 = 10;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00e4;
						IL_00e4:
						num2 = 11;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0117;
						IL_0117:
						num2 = 12;
						num6 = 0;
						goto IL_011d;
						IL_011d:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							MSG[0, num6]
						}, (string[])null, (Type[])null);
						goto IL_015c;
						IL_015c:
						num2 = 14;
						num6++;
						if (num6 <= 53)
						{
							goto IL_011d;
						}
						goto IL_016b;
						IL_016b:
						num2 = 15;
						num7 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_01f2;
						IL_01f2:
						if (DC_Main.i <= num7)
						{
							goto IL_0185;
						}
						goto IL_01fb;
						IL_01fb:
						num2 = 20;
						colorConverter = new ColorConverter();
						goto IL_0205;
						IL_0205:
						num2 = 21;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0258;
						IL_0258:
						num2 = 22;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_02ad;
						IL_02ad:
						num2 = 23;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_0305;
						IL_0305:
						num2 = 24;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0373;
						IL_0373:
						num2 = 25;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_03b6;
						IL_03b6:
						num2 = 26;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_03e5;
						IL_03e5:
						num2 = 27;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0428;
						IL_0428:
						num2 = 28;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0469;
						IL_0469:
						num2 = 29;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VS124NEVS", false) == 0)
						{
							goto IL_0488;
						}
						goto IL_0557;
						IL_0488:
						num2 = 30;
						text = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\TagEntry.xlsx";
						goto IL_04a6;
						IL_04a6:
						num2 = 31;
						obj4 = obj;
						obj5 = new object[1] { text };
						array = obj5;
						obj6 = new bool[1] { true };
						array2 = obj6;
						NewLateBinding.LateCall(obj4, (Type)null, "SaveAs", obj5, (string[])null, (Type[])null, obj6, true);
						if (array2[0])
						{
							text = (string)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(string));
						}
						goto IL_04fc;
						IL_01e3:
						num2 = 19;
						DC_Main.i++;
						goto IL_01f2;
						IL_04fc:
						num2 = 32;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Close", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_052a;
						IL_052a:
						num2 = 33;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0544;
						IL_0544:
						num2 = 34;
						((Control)this).Cursor = Cursors.Default;
						goto end_IL_0001_3;
						IL_0557:
						num2 = 36;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0578;
						IL_0578:
						num2 = 37;
						NewLateBinding.LateCall(obj2, (Type)null, "Quit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0592;
						IL_0592:
						num2 = 38;
						obj = null;
						goto IL_0598;
						IL_0598:
						num2 = 39;
						obj3 = null;
						goto IL_059e;
						IL_059e:
						num2 = 40;
						obj2 = null;
						goto IL_05a3;
						end_IL_0001_2:
						break;
					}
					num2 = 42;
					((Control)this).Cursor = Cursors.Default;
					break;
				}
				end_IL_0001:;
			}
			catch (object obj7) when (obj7 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj7);
				try0001_dispatch = 1665;
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

	private void tLotNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_02d7: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLotNo.Text, "", false) != 0)
		{
			DC_Main.RsQry = "SELECT LOT_NO,IT_CODE FROM LOT_DETL AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOT_NO = '" + tLotNo.Text + "' GROUP BY LOT_NO,IT_CODE HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS+A.IT_GWT ELSE -A.IT_PCS+A.IT_GWT END) > 0 ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsItmMfg, "Y", false) == 0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.LOT_NO As LotNoL,B.IT_NAME As ItNameL,A.IT_CODE As ItCodeL,MAX(D.KrCode) AS KrCode,  SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE 0 END) As LotPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE 0 END),3) As LogGwtW,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE 0 END),3) As LotNwtW,   SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_PCS ELSE 0 END) As AdjPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_GWT ELSE 0 END),3) As AdjPcsW,ROUND(SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_NWT ELSE 0 END),3) As AdjNwtW,   SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) As BalPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE -A.IT_GWT END),3) As BalGwtW,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE -A.IT_NWT END),3) As BalNwtW   FROM ((LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON B.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)  LEFT JOIN(SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,KR_CODE As KrCode,LOT_NO,IT_SIGN FROM LOT_DETL) AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_YEAR = D.CO_YEAR AND A.CO_BOOK = D.CO_BOOK AND A.VCH_NO = D.VCH_NO AND A.LOT_NO = D.LOT_NO AND D.IT_SIGN = '+'  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.LOT_NO,B.IT_NAME,A.IT_CODE "), (object)" HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS+A.IT_GWT ELSE -A.IT_PCS+A.IT_GWT END) > 0  "));
				}
				else
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.LOT_NO As LotNoL,B.IT_NAME As ItNameL,A.IT_CODE As ItCodeL,MAX(D.KrCode) AS KrCode,  SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE 0 END) As LotPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE 0 END),3) As LogGwtW,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE 0 END),3) As LotNwtW,   SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_PCS ELSE 0 END) As AdjPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_GWT ELSE 0 END),3) As AdjPcsW,ROUND(SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_NWT ELSE 0 END),3) As AdjNwtW,   SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) As BalPcsM,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE -A.IT_GWT END),3) As BalGwtW,ROUND(SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE -A.IT_NWT END),3) As BalNwtW   FROM ((LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON B.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)  LEFT JOIN(SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,KR_CODE As KrCode,LOT_NO,IT_SIGN FROM LOT_DETL) AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_YEAR = D.CO_YEAR AND A.CO_BOOK = D.CO_BOOK AND A.VCH_NO = D.VCH_NO AND A.LOT_NO = D.LOT_NO AND D.IT_SIGN = '+'  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" GROUP BY A.LOT_NO,B.IT_NAME,A.IT_CODE "), (object)" HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) > 0  "));
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[14];
				DC_Main.ColWidth[0] = 100.0;
				DC_Main.ColWidth[1] = 150.0;
				DC_Main.ColWidth[2] = 80.0;
				DC_Main.ColWidth[3] = 70.0;
				DC_Main.ColWidth[4] = 70.0;
				DC_Main.ColWidth[5] = 80.0;
				DC_Main.ColWidth[6] = 80.0;
				DC_Main.ColWidth[7] = 70.0;
				DC_Main.ColWidth[8] = 80.0;
				DC_Main.ColWidth[9] = 80.0;
				DC_Main.ColWidth[10] = 70.0;
				DC_Main.ColWidth[11] = 80.0;
				DC_Main.ColWidth[12] = 80.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						tLotNo.Text = DC_Main.ColValue[0];
						tItCode.Text = DC_Main.ColValue[2];
						tItName.Text = DC_Main.ColValue[1];
						nPcs.Text = DC_Main.ColValue[10];
						nitGwt.Text = Strings.Format((object)Conversion.Val(DC_Main.ColValue[11]), "0.000");
						nItNwt.Text = Strings.Format((object)Conversion.Val(DC_Main.ColValue[12]), "0.000");
					}
					((TextBoxBase)tLotNo).SelectAll();
				}
				return;
			}
			DC_Main.RsQry = "Select A.LOT_NO,A.IT_CODE,B.IT_NAME,SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_PCS ELSE -A.IT_PCS END) As Pcs,SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT ELSE -A.IT_GWT END) As GrWt, SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE -A.IT_NWT END) AS NetWt FROM LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LOT_NO = '" + tLotNo.Text + "' GROUP BY A.LOT_NO,A.IT_CODE,B.IT_NAME HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_GWT+A.IT_PCS ELSE -(A.IT_GWT+A.IT_PCS) END) > 0 ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				tItCode.Text = Conversions.ToString(dataTable.Rows[0]["IT_CODE"]);
				tItName.Text = Conversions.ToString(dataTable.Rows[0]["IT_NAME"]);
				nPcs.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["Pcs"]), "0");
				nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GrWt"]), "0.000");
				nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["NetWt"]), "0.000");
				DC_Main.RsQry = "Select A.ITM_TOUCH As ItTouch,A.ITM_WEST_PRC As WestPrc,B.AC_SHORT As KrName FROM PR_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LOT_NO = '" + tLotNo.Text + "'  UNION ALL Select C.ITM_TOUCH,C.ITM_WEST_PRC,D.AC_SHORT FROM KR_DETL AS C LEFT JOIN AC_MAST AS D ON C.CO_CODE = D.CO_CODE AND C.AC_CODE = D.AC_CODE WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LOT_NO = '" + tLotNo.Text + "' ";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					nLotTouch.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["ItTouch"]), "0.00");
					nLotWestPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["WestPrc"]), "0.00");
					if (Operators.CompareString(MSG[1, 69], "A", false) == 0)
					{
						MSG[1, 21] = Strings.Format((object)Conversion.Val(nLotTouch.Text), "0.00");
						MSG[1, 22] = Strings.Format((object)Conversion.Val(nLotWestPrc.Text), "0.00");
						MSG[1, 53] = Conversions.ToString(dataTable.Rows[0]["KrName"]);
					}
				}
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0) | (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0))
				{
					MSG.Col = 1;
				}
				else
				{
					MSG.Col = 2;
				}
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
			}
			else
			{
				nPcs.Text = Conversions.ToString(0);
				nitGwt.Text = Conversions.ToString(0);
				nItNwt.Text = Conversions.ToString(0);
			}
			((Control)TEXT_ENTRY).Focus();
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnTagReNumber_Click(object sender, EventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"This Item Tag No Re Numbaring ?", (MsgBoxStyle)20, (object)null) != 6)
		{
			return;
		}
		if (Operators.CompareString(Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy"), Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy"), false) >= 0)
		{
			Interaction.MsgBox((object)"This Is Not a Oppning Tag Voucher....You Cant Re Numbaring This Voucher...", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "";
		DC_Main.RsQry = "SELECT TAG_TYPE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[1, 3] + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
		}
		int num = 0;
		checked
		{
			int num2 = MSG.Rows - 1;
			for (int i = 1; i <= num2; i++)
			{
				AxMSFlexGrid mSG = MSG;
				if (Operators.CompareString(mSG[i, 97], "", false) == 0)
				{
					mSG[i, 97] = mSG[i, 5];
					mSG[i, 5] = "";
					mSG[i, 61] = "";
					if (Operators.CompareString(text, "", false) != 0)
					{
						mSG[i, 65] = text;
					}
				}
				else
				{
					num++;
				}
				mSG = null;
			}
			if (num > 0)
			{
				Interaction.MsgBox((object)"This Voucher Tag is Already Re Numbering...", (MsgBoxStyle)0, (object)null);
				return;
			}
			DC_Main.RsQry = "SELECT * FROM SRNO_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND IT_CODE = 'ABCDE' ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count == 0)
			{
				DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','0','0','ABC1234','ABCDE')";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + MSG[1, 66] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + MSG[1, 65] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
			dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			string text2 = ((dataTable.Rows.Count <= 0) ? "0" : Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)""))));
			int num3 = MSG.Rows - 1;
			for (int i = 1; i <= num3; i++)
			{
				AxMSFlexGrid mSG2 = MSG;
				mSG2.Row = i;
				if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
				{
					string tagPrefix = "";
					if (Operators.CompareString(Module_Save.MsRendomWithPrCode, "Y", false) == 0)
					{
						tagPrefix = MSG[i, 66] + MSG[i, 65];
					}
					string text3 = Module_Save.RendomTagGen(DC_Main.MCo_Book, tagPrefix);
					if (Operators.CompareString(text3, "", false) != 0)
					{
						MSG[i, 5] = text3;
						text2 = text3;
					}
					mSG2[i, 61] = Conversions.ToString(Conversion.Val(text2));
					mSG2[i, 66] = mSG2[i, 66];
					mSG2[i, 64] = mSG2[i, 64];
					mSG2[i, 65] = mSG2[i, 65];
					Application.DoEvents();
				}
				else
				{
					text2 = ((Operators.CompareString(DC_Main.MsVbImport, "Y", false) != 0) ? Strings.Format((object)(Conversion.Val(text2) + 1.0), "00000") : Strings.Format((object)(Conversion.Val(text2) + 1.0), "0000"));
					mSG2[i, 61] = Conversions.ToString(Conversion.Val(text2));
					mSG2[i, 66] = mSG2[i, 66];
					mSG2[i, 64] = mSG2[i, 64];
					mSG2[i, 65] = mSG2[i, 65];
					mSG2[i, 5] = mSG2[i, 66] + mSG2[i, 65] + text2;
				}
				mSG2 = null;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnNewTagImg_Click(object sender, EventArgs e)
	{
		//IL_02a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0186: Expected O, but got Unknown
		int num = 0;
		checked
		{
			int num2 = MSG.Rows - 1;
			for (int i = 1; i <= num2; i++)
			{
				AxMSFlexGrid mSG = MSG;
				if (Operators.CompareString(MSG[i, 97], "", false) != 0)
				{
					num++;
					DC_Main.RsQry = ("UPDATE TAG_IMAGE_DATA SET TAG_NO = '" + mSG[i, 5] + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[i, 97] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[i, 67]))) ?? "";
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					DC_Main.MsImageType = "TagImage";
					DC_Main.MsImageNo = MSG[i, 97] + "_" + MSG[i, 67];
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						Image val = Image.FromFile(DC_Main.MsImagePath);
						PicImage.Image = (Image)new Bitmap(val);
						val.Dispose();
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					else
					{
						PicImage.Image = null;
					}
					if (PicImage.Image != null)
					{
						DC_Main.MsImageNo = MSG[i, 5] + "_" + MSG[i, 67];
						PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
						PicImage.Image.Dispose();
						PicImage.Image = null;
						DC_Main.MsImagePath = "";
					}
					Thread.Sleep(300);
				}
				mSG = null;
			}
			if (num > 0)
			{
				Interaction.MsgBox((object)"Process are Complite....", (MsgBoxStyle)0, (object)null);
			}
			else
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void BtnOldNewtag_Click(object sender, EventArgs e)
	{
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagReNumberVch.RPT";
		Cr.SelectionFormula = "{BAR_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {BAR_DETL.LC_CODE} = '" + DC_Main.MLc_code + "' AND {BAR_DETL.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {BAR_DETL.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {BAR_DETL.VCH_NO} = '" + CurPrnVch + "'";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		DC_Main.MsPrintStatus = false;
	}

	private void CboDataType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			MSG[checked(MSG.Rows - 1), 89] = cboDataType.Text;
		}
	}

	private void cboDataType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)mVchDate).Focus();
		}
	}

	private void btnRfid_Click(object sender, EventArgs e)
	{
		switch (DC_Main.SSRegSrNo)
		{
		case "HM407NEKU":
		case "HM285NEKU":
		case "HM340NEKU":
		case "VK191NEVK":
		case "VK142NEVK":
		case "VK052NEVK":
		case "HM328NEKU":
		case "HM427NEHP":
		case "HM606NEKU":
		case "VK113NEVK":
		case "VK250NEPH":
		case "VK253NEVK":
		case "VK106NEVK":
		case "VK289NEPH":
		case "AK011NEAK":
		case "HM287NEKU":
		case "VK272NAST":
		case "HM776NUKU":
			MordenJwTag();
			return;
		}
		string text = "\"";
		string text2 = "";
		string text3 = "";
		string text4 = "Gold";
		checked
		{
			int num = MSG.Rows - 1;
			for (int i = 1; i <= num; i++)
			{
				DC_Main.RsQry = "Select GR_CODE,IT_TYPE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[i, 3] + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text2 = "";
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text2 = Conversions.ToString(DC_Main.Tbl.Rows[0]["GR_CODE"]);
					if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)"G", false))
					{
						cboPrintType.SelectedIndex = 0;
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)"S", false))
					{
						cboPrintType.SelectedIndex = 1;
					}
					else if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)"D", false))
					{
						cboPrintType.SelectedIndex = 3;
					}
					else
					{
						cboPrintType.SelectedIndex = 3;
					}
				}
				if (cboPrintType.SelectedIndex == 0)
				{
					text4 = "Gold";
				}
				else if (cboPrintType.SelectedIndex == 1)
				{
					text4 = "Silver";
				}
				else if (cboPrintType.SelectedIndex == 2)
				{
					text4 = "Diamond";
				}
				else if (cboPrintType.SelectedIndex == 3)
				{
					text4 = "Platinum";
				}
				else if (cboPrintType.SelectedIndex == 4)
				{
					text4 = "Emitation";
				}
				else if (cboPrintType.SelectedIndex == 5)
				{
					text4 = "RealStone";
				}
				else if (cboPrintType.SelectedIndex == 6)
				{
					text4 = "Other";
				}
				DC_Main.RsQry = ("SELECT IT_CODE,IT_PCS,IT_CON_WT,IT_NET_AMT FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 5] + "' AND VCH_SRNO = " + MSG[i, 67]) ?? "";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text3 = "";
				int num2 = 0;
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					if (DC_Main.Tbl.Rows.Count > 5)
					{
						DC_Main.M = 0;
						do
						{
							text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CON_WT"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"]), (object)"")));
							DC_Main.M++;
						}
						while (DC_Main.M <= 4);
					}
					else
					{
						int num3 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num3)
						{
							text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CON_WT"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"]), (object)"")));
							DC_Main.M++;
						}
					}
					num2 = DC_Main.M;
					int m = num2;
					DC_Main.M = m;
					while (DC_Main.M <= 6)
					{
						text3 += ",";
						DC_Main.M++;
					}
					if (Operators.CompareString(text3, "", false) != 0)
					{
						text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
					}
				}
				else
				{
					text3 = ",,,,,,";
				}
				if ((Operators.CompareString(text4, "Gold", false) == 0) | (Operators.CompareString(text4, "Diamond", false) == 0) | (Operators.CompareString(text4, "Platinum", false) == 0))
				{
					if (Operators.CompareString(DC_Main.MsWorkType, "W", false) == 0)
					{
						text = text + text2 + ",";
						text = text + MSG[i, 5] + ",";
						text = ((Operators.CompareString(MSG[i, 10], "", false) == 0) ? (text + MSG[i, 10] + ",") : (text + "S :" + MSG[i, 10] + ","));
						text = text + MSG[i, 11] + ",";
						text = text + MSG[i, 82] + ",";
						text = text + MSG[i, 83] + ",";
						text = text + MSG[i, 84] + ",";
						text = text + "G :" + MSG[i, 14] + ",";
						text = text + "L :" + MSG[i, 15] + ",";
						text = text + "N :" + MSG[i, 16] + ",";
						text = text + "W :" + MSG[i, 28] + ",";
						text = text + "Lrt :" + MSG[i, 32] + ",";
						text = ((Conversion.Val(MSG[i, 50]) == 0.0) ? (text + "OAmt :" + MSG[i, 34] + ",") : (text + "Mrp :" + MSG[i, 50] + ","));
						text = string.Concat(text, "Kr :" + MSG[i, 53]);
						text = text + text3 + ",";
						text = text + text4 + ";";
						continue;
					}
					text = text + text2 + ",";
					text = text + MSG[i, 5] + ",";
					text = ((Operators.CompareString(MSG[i, 10], "", false) == 0) ? (text + MSG[i, 10] + ",") : (text + "S :" + MSG[i, 10] + ","));
					text = text + MSG[i, 11] + ",";
					text = text + MSG[i, 82] + ",";
					text = text + MSG[i, 83] + ",";
					text = text + MSG[i, 84] + ",";
					text = text + "G :" + MSG[i, 14] + ",";
					text = text + "L :" + MSG[i, 15] + ",";
					text = text + "N :" + MSG[i, 16] + ",";
					if (Operators.CompareString(MSG[i, 24], "", false) != 0)
					{
						text += ",";
						text = text + "Cod :" + MSG[i, 24] + ",";
						text += ",";
					}
					else if (Conversion.Val(MSG[i, 50]) != 0.0)
					{
						text += ",";
						text += ",";
						text = text + "Mrp :" + MSG[i, 50] + ",";
					}
					else
					{
						text += ",";
						text = text + "Lrt :" + MSG[i, 32] + ",";
						text = text + "OAmt :" + MSG[i, 34] + ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 53]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
				else if (Operators.CompareString(text4, "Silver", false) == 0)
				{
					text3 = ",,,,,,";
					text = text + text2 + ",";
					text = text + MSG[i, 5] + ",";
					text = ((Operators.CompareString(MSG[i, 10], "", false) == 0) ? (text + MSG[i, 10] + ",") : (text + "S :" + MSG[i, 10] + ","));
					text += ",";
					text += ",";
					text += ",";
					text += ",";
					text = text + "G :" + MSG[i, 14] + ",";
					text = text + "L :" + MSG[i, 15] + ",";
					text = text + "N :" + MSG[i, 16] + ",";
					text += ",";
					if (Operators.CompareString(MSG[i, 24], "", false) == 0)
					{
						text = ((Operators.CompareString(MSG[i, 32], "", false) != 0) ? (text + "Lrt :" + MSG[i, 32] + ",") : (text + "LAmt :" + MSG[i, 33] + ","));
						text = ((Conversion.Val(MSG[i, 50]) != 0.0) ? (text + "Mrp :" + MSG[i, 50] + ",") : (text + ","));
					}
					else
					{
						text = text + "Cod :" + MSG[i, 24] + ",";
						text += ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 53]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
				else
				{
					text3 = ",,,,,,";
					text = text + text2 + ",";
					text = text + MSG[i, 5] + ",";
					text = ((Operators.CompareString(MSG[i, 10], "", false) == 0) ? (text + MSG[i, 10] + ",") : (text + "S :" + MSG[i, 10] + ","));
					text += ",";
					text += ",";
					text += ",";
					text += ",";
					text = text + "G :" + MSG[i, 14] + ",";
					text = text + "L :" + MSG[i, 15] + ",";
					text = text + "N :" + MSG[i, 16] + ",";
					text += ",";
					if (Operators.CompareString(MSG[i, 24], "", false) == 0)
					{
						text = ((Operators.CompareString(MSG[i, 32], "", false) != 0) ? (text + "Lrt :" + MSG[i, 32] + ",") : (text + "LAmt :" + MSG[i, 33] + ","));
						text = ((Conversion.Val(MSG[i, 50]) != 0.0) ? (text + "Mrp :" + MSG[i, 50] + ",") : (text + ","));
					}
					else
					{
						text = text + "Cod :" + MSG[i, 24] + ",";
						text += ",";
					}
					text = string.Concat(text, "Kr :" + MSG[i, 53]);
					text = text + text3 + ",";
					text = text + text4 + ";";
				}
			}
			text += "\"";
			string text5 = "C:\\Tagit";
			if (!Directory.Exists(text5))
			{
				Directory.CreateDirectory(text5);
			}
			string text6 = "GoldTag1";
			File.WriteAllText(text5 + "\\" + text6 + ".txt", text);
			string text7 = "";
			switch (DC_Main.SSRegSrNo)
			{
			case "HM340NEKU":
				text7 = "Rushab";
				break;
			case "VK142NEVK":
				text7 = "Radhika";
				break;
			case "HM285NEKU":
				text7 = "Madina";
				break;
			case "HM407NEKU":
				text7 = "Modern";
				break;
			}
			string text8 = text;
			bool flag = tagitObject.PrintTags(text8, text7);
		}
	}

	private void MordenJwTag()
	{
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "Gold";
		checked
		{
			int num = MSG.Rows - 1;
			for (int i = 1; i <= num; i++)
			{
				if (Operators.CompareString(MSG[i, 5], "", false) == 0)
				{
					continue;
				}
				DC_Main.RsQry = "SELECT GR_CODE,IT_TYPE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[i, 3] + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				text2 = "";
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					text2 = Conversions.ToString(DC_Main.Tbl.Rows[0]["GR_CODE"]);
				}
				if (cboPrintType.SelectedIndex == 0)
				{
					text4 = "Gold";
				}
				else if (cboPrintType.SelectedIndex == 1)
				{
					text4 = "Silver";
				}
				else if (cboPrintType.SelectedIndex == 2)
				{
					text4 = "Diamond";
				}
				else if (cboPrintType.SelectedIndex == 3)
				{
					text4 = "Platinum";
				}
				else if (cboPrintType.SelectedIndex == 4)
				{
					text4 = "Emitation";
				}
				else if (cboPrintType.SelectedIndex == 5)
				{
					text4 = "RealStone";
				}
				else if (cboPrintType.SelectedIndex == 6)
				{
					text4 = "Other";
				}
				int num2 = 0;
				if (cboPrintType.SelectedIndex == 2)
				{
					DC_Main.RsQry = ("SELECT IT_CODE,DM_ORIGIN,DM_COLOR,IT_GWT,IT_PCS,DM_SFNO,DM_REMARK FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 5] + "' AND VCH_SRNO = " + MSG[i, 67]) ?? "";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text3 = "";
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK272NAST", false) == 0))
						{
							int num3 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.M = 0;
							while (DC_Main.M <= num3)
							{
								text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)"")));
								DC_Main.M++;
							}
							num2 = DC_Main.M;
							int m = num2;
							DC_Main.M = m;
							while (DC_Main.M <= 9)
							{
								text3 += ",";
								DC_Main.M++;
							}
						}
						else if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0))
						{
							int num4 = DC_Main.Tbl.Rows.Count - 1;
							DC_Main.M = 0;
							while (DC_Main.M <= num4)
							{
								text3 = Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)" / "), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)" / "), DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"]), (object)"")));
								DC_Main.M++;
							}
							num2 = DC_Main.M;
							int m2 = num2;
							DC_Main.M = m2;
							while (DC_Main.M <= 9)
							{
								text3 += ",";
								DC_Main.M++;
							}
						}
						else
						{
							if (DC_Main.Tbl.Rows.Count > 2)
							{
								DC_Main.M = 0;
								do
								{
									text3 = ((!((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM328NEKU", false) == 0))) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)""), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))));
									num2 += 3;
									DC_Main.M++;
								}
								while (DC_Main.M <= 1);
							}
							else
							{
								int num5 = DC_Main.Tbl.Rows.Count - 1;
								DC_Main.M = 0;
								while (DC_Main.M <= num5)
								{
									text3 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) != 0) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_ORIGIN"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_REMARK"]), (object)","), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")))));
									num2 += 3;
									DC_Main.M++;
								}
							}
							if (num2 > DC_Main.M)
							{
								int m3 = num2;
								DC_Main.M = m3;
								while (DC_Main.M <= 9)
								{
									text3 += ",";
									DC_Main.M++;
								}
							}
						}
						text3 += ",";
						if (Operators.CompareString(text3, "", false) != 0)
						{
							text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
						}
					}
					else
					{
						text3 = ",,,,,,,,,,";
					}
				}
				else
				{
					DC_Main.RsQry = ("Select IT_CODE,IT_PCS,IT_GWT,IT_NET_AMT,DM_COLOR,DM_SFNO FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[i, 5] + "' AND VCH_SRNO = " + MSG[i, 67]) ?? "";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					text3 = "";
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						int num6 = DC_Main.Tbl.Rows.Count - 1;
						DC_Main.M = 0;
						while (DC_Main.M <= num6)
						{
							text3 = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) != 0) ? ((Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) != 0) ? Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)"/"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"])), "0")), (object)""))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_COLOR"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["DM_SFNO"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)""))), (object)"")))) : Conversions.ToString(Operators.AddObject((object)text3, Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)",", DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"/"), DC_Main.Tbl.Rows[DC_Main.M]["IT_PCS"]), (object)"/"), (object)Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.M]["IT_GWT"], (object)"")), "0.00")), (object)"/"), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["IT_NET_AMT"])), "0")), (object)""))));
							DC_Main.M++;
						}
						num2 = DC_Main.M;
						int m4 = num2;
						DC_Main.M = m4;
						while (DC_Main.M <= 10)
						{
							text3 += ",";
							DC_Main.M++;
						}
						if (Operators.CompareString(text3, "", false) != 0)
						{
							text3 = Strings.Mid(text3, 1, Strings.Len(text3) - 1);
						}
					}
					else
					{
						text3 = ",,,,,,,,,,";
					}
				}
				string text5 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 13]) == 0.0, (object)"", (object)MSG[i, 13]));
				string text6 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 14]) == 0.0, (object)"", (object)MSG[i, 14]));
				string text7 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 15]) == 0.0, (object)"", (object)MSG[i, 15]));
				string text8 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 16]) == 0.0, (object)"", (object)MSG[i, 16]));
				string text9 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 25]) == 0.0, (object)"", (object)MSG[i, 25]));
				string text10 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 26]) == 0.0, (object)"", (object)MSG[i, 26]));
				string text11 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 27]) == 0.0, (object)"", (object)MSG[i, 27]));
				string text12 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 28]) == 0.0, (object)"", (object)MSG[i, 28]));
				string text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 29]) == 0.0, (object)"", (object)MSG[i, 29]));
				string text14 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 30]) == 0.0, (object)"", (object)MSG[i, 30]));
				string text15 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 32]) == 0.0, (object)"", (object)MSG[i, 32]));
				string text16 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 33]) == 0.0, (object)"", (object)MSG[i, 33]));
				string text17 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 34]) == 0.0, (object)"", (object)MSG[i, 34]));
				string text18 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 50]) == 0.0, (object)"", (object)Strings.Format((object)Conversion.Val(MSG[i, 50]), "0")));
				string text19 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 45]) == 0.0, (object)"", (object)Strings.Format((object)Conversion.Val(MSG[i, 45]), "0")));
				string text20 = Conversions.ToString(0);
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
				{
					text11 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 21]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 21]), "0.00"), (object)""));
					text12 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 22]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 22]), "0.00"), (object)""));
					text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 23]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 23]), "0.00"), (object)""));
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM407NEKU", false) == 0)
				{
					text6 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 14]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 14]), "0.00"), (object)""));
					text7 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 15]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 15]), "0.00"), (object)""));
					text8 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 16]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 16]), "0.00"), (object)""));
					text13 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 29]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 29]), "0.00"), (object)""));
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) == 0)
				{
					string text21 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 21]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 21]), "0.00"), (object)""));
					string text22 = Conversions.ToString(Interaction.IIf(Conversion.Val(MSG[i, 22]) != 0.0, (object)Strings.Format((object)Conversion.Val(MSG[i, 22]), "0.00"), (object)""));
					DC_Main.RsQry = "SELECT ADD_TOUCH FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + text2 + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						text20 = Conversions.ToString(Math.Round(Conversion.Val(text21) + Conversion.Val(text22) + Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["ADD_TOUCH"], (object)"")), 0));
					}
				}
				text = text + MSG[i, 5] + ",";
				text = text + text2 + ",";
				text = text + MSG[i, 3] + ",";
				text = text + MSG[i, 68] + ",";
				text = text + MSG[i, 7] + ",";
				text = text + MSG[i, 10] + ",";
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK272NAST", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0))
				{
					if (Operators.CompareString(MSG[i, 38], "G", false) == 0)
					{
						text = text + text6 + ",";
						text += ",";
						text += ",";
					}
					else
					{
						text = text + text6 + ",";
						text = text + text7 + ",";
						text = text + text8 + ",";
					}
				}
				else
				{
					text = text + text6 + ",";
					text = text + text7 + ",";
					text = text + text8 + ",";
				}
				text = text + text9 + ",";
				text = text + text10 + ",";
				text = text + text11 + ",";
				text = text + text12 + ",";
				text = text + text13 + ",";
				text = (((Operators.CompareString(DC_Main.SSRegSrNo, "VK191NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK272NAST", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)) ? (text + MSG[i, 38] + ",") : ((Operators.CompareString(DC_Main.SSRegSrNo, "AK011NEAK", false) != 0) ? (text + MSG[i, 24] + ",") : (text + text5 + ",")));
				text = text + text14 + ",";
				text = text + text15 + ",";
				text = text + text16 + ",";
				text = text + text17 + ",";
				text = text + text18 + ",";
				text = text + text19 + ",";
				text = text + MSG[i, 11] + ",";
				text = text + MSG[i, 82] + ",";
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM427NEHP", false) == 0)
				{
					text = text + MSG[i, 6] + ",";
					text = text + Strings.Mid(MSG[i, 102], 7, 4) + Strings.Mid(MSG[i, 102], 4, 2) + Strings.Mid(MSG[i, 102], 1, 2) + ",";
				}
				else
				{
					text = text + MSG[i, 83] + ",";
					text = ((Operators.CompareString(DC_Main.SSRegSrNo, "HM606NEKU", false) == 0) ? (text + MSG[i, 6] + ",") : ((Operators.CompareString(DC_Main.SSRegSrNo, "VK289NEPH", false) != 0) ? (text + MSG[i, 84] + ",") : (text + "00" + Strings.Mid(MSG[i, 102], 4, 2) + Strings.Mid(MSG[i, 102], 1, 2) + Strings.Mid(MSG[i, 102], 9, 2) + "09" + text20 + "9" + MSG[i, 53] + ",")));
				}
				text += MSG[i, 53] ?? "";
				text = text + text3 + ",";
				text = text + text4 + ";";
			}
			text = text ?? "";
			string text23 = "C:\\Tagit";
			if (!Directory.Exists(text23))
			{
				Directory.CreateDirectory(text23);
			}
			string text24 = "GoldTag1";
			File.WriteAllText(text23 + "\\" + text24 + ".txt", text);
			string text25 = "";
			switch (DC_Main.SSRegSrNo)
			{
			case "HM340NEKU":
				text25 = "Rushab";
				break;
			case "VK142NEVK":
				text25 = "Radhika";
				break;
			case "HM285NEKU":
				text25 = "Madina";
				break;
			case "HM407NEKU":
				text25 = "Modern";
				break;
			case "VK191NEVK":
				text25 = "Devi Pavitra";
				break;
			case "VK052NEVK":
				text25 = "HANUMAN JEWELLERS";
				break;
			case "HM328NEKU":
				text25 = "Swapnil";
				break;
			case "HM427NEHP":
				text25 = "Devi Pavitra Hyd";
				break;
			case "HM606NEKU":
				text25 = "SRI ANDHRA";
				break;
			case "VK113NEVK":
				text25 = "VAIJNATH";
				break;
			case "VK250NEPH":
				text25 = "PANCHRATNA";
				break;
			case "VK253NEVK":
				text25 = "KAJRIJEW";
				break;
			case "VK106NEVK":
				text25 = "MAHALAXMIJEW";
				break;
			case "VK289NEPH":
				text25 = "MUKUTASRI";
				break;
			case "AK011NEAK":
				text25 = "MAYURA";
				break;
			case "HM287NEKU":
				text25 = "ABHUSHAN";
				break;
			case "VK272NAST":
				text25 = "ALMUJAWRT";
				break;
			case "HM776NUKU":
				text25 = "SWASTIK";
				break;
			}
			string text26 = text;
			bool flag = tagitObject.PrintTags(text26, text25);
		}
	}

	private void btnJesonGen_Click(object sender, EventArgs e)
	{
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		DcPrintClass dcPrintClass = new DcPrintClass();
		List<ClassTagList> list = new List<ClassTagList>();
		checked
		{
			int num = MSG.Rows - 1;
			for (int i = 1; i <= num; i++)
			{
				List<TagOthDetail> list2 = new List<TagOthDetail>();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON  A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.TAG_NO = '" + MSG[i, 5] + "' ORDER BY A.SR_NO,A.ISR_NO";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				int num2 = DC_Main.Tbl.Rows.Count - 1;
				for (int j = 0; j <= num2; j++)
				{
					TagOthDetail item = new TagOthDetail
					{
						OtSrNo = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["ISR_NO"])),
						OtItCode = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_CODE"])),
						OtItName = Convert.ToString(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_NAME"])),
						OtPcs = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_PCS"])),
						OtGwt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_GWT"])),
						OtRate = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_RATE"])),
						OtAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_AMT"])),
						OtNetAmt = Convert.ToDecimal(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[j]["IT_NET_AMT"]))
					};
					list2.Add(item);
				}
				ClassTagList item2 = new ClassTagList
				{
					SlNo = Convert.ToString(MSG[i, 0]),
					ItCode = Convert.ToString(MSG[i, 3]),
					TagNo = Convert.ToString(MSG[i, 5]),
					Pcs = Convert.ToDecimal(Conversion.Val(MSG[i, 13])),
					GrWt = Convert.ToDecimal(Conversion.Val(MSG[i, 14])),
					OthWt = Convert.ToDecimal(Conversion.Val(MSG[i, 15])),
					NetWt = Convert.ToDecimal(Conversion.Val(MSG[i, 16])),
					Touch = Convert.ToDecimal(Conversion.Val(MSG[i, 27])),
					West = Convert.ToDecimal(Conversion.Val(MSG[i, 28])),
					Fine = Convert.ToDecimal(Conversion.Val(MSG[i, 29])),
					lbrPrc = Convert.ToDecimal(Conversion.Val(MSG[i, 30])),
					lbrRate = Convert.ToDecimal(Conversion.Val(MSG[i, 32])),
					lbrAmt = Convert.ToDecimal(Conversion.Val(MSG[i, 33])),
					OthAmt = Convert.ToDecimal(Conversion.Val(MSG[i, 34])),
					NetAmt = Convert.ToDecimal(Conversion.Val(MSG[i, 34])),
					KrName = Convert.ToString(MSG[i, 53]),
					TagOth = list2
				};
				list.Add(item2);
			}
			dcPrintClass.TagList = list;
			string text = "DcTagPrint";
			string contents = JsonConvert.SerializeObject((object)dcPrintClass, (Formatting)1);
			File.WriteAllText(DC_Main.MSImageSavePath + "\\" + text + ".Json", contents);
			Interaction.MsgBox((object)"Tag List Is Generate Successfully...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
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
				case 351:
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
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 7:
						case 8:
							goto end_IL_0001_3;
						}
						goto default;
					}
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
					IL_000b:
					num2 = 2;
					DC_Main.RsQry = "SELECT TOP(1) FINE_GL_RATE,FINE_SL_RATE,VCH_DATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND SR_NO = 1  ORDER BY VCH_DATE DESC";
					goto IL_006f;
					IL_0095:
					num2 = 5;
					ToDayGlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_GL_RATE"], (object)"")) / 10.0), "0.00"));
					break;
					end_IL_0001_2:
					break;
				}
				num2 = 6;
				ToDaySlRate = Conversions.ToDouble(Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["FINE_SL_RATE"], (object)"")) / 1000.0), "0.00"));
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 351;
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

	private void BtnLastYearIdtl_Click(object sender, EventArgs e)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0e31: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Missing Tag Other Detail Import From Last Year... ?", (MsgBoxStyle)20, (object)null) != 6)
		{
			return;
		}
		DC_Main.RsQry = "SELECT * FROM BOOK_IDTL WHERE SR_NO = 100";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			DC_Main.MsTrfrIp = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_BOOK"], (object)""));
			DC_Main.MsTrfrPwd = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["SVR_PWD"], (object)""));
			DC_Main.MsTrfrSvr = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
			DC_Main.MsTrfrSvrMast = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		}
		DC_Main.CnTr.ConnectionString = ("Data Source=" + DC_Main.MsTrfrIp + ";Initial Catalog=" + DC_Main.MsTrfrSvr + ";Persist Security Info=True;User ID=sa;Password=" + DC_Main.MsTrfrPwd) ?? "";
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = ("SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 62]))) ?? "";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.*,B.IT_TYPE FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + MSG[DC_Main.i, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 67])) + " ORDER BY A.ISR_NO ";
					RsDetl = OpenRecordsetTrfr(DC_Main.RsQry);
					DC_Main.R = 0;
					while (DC_Main.R < RsDetl.Rows.Count)
					{
						object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,  DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,KR_LESS_PRC,IT_GWT,IT_CON_PRC,  IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,  DM_NAME,DM_ORIGIN,DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 62])) + "," + Conversions.ToString(DC_Main.R + 1) + ",'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "',  '"), RsDetl.Rows[DC_Main.R]["VCH_TYPE"]), (object)"','I','O','"), (object)FormMainBook), (object)"','','"), (object)MSG[DC_Main.i, 5]), (object)"',"), (object)Conversion.Val(MSG[DC_Main.i, 67])), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["IT_TYPE"]), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_CODE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SIZE"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_SFNO"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_LEB"]), (object)"',");
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS"]);
						double num2 = DC_Main.Fnv(ref Value);
						dataRow["IT_PCS"] = RuntimeHelpers.GetObjectValue(Value);
						object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num2), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_PCS_WT"]);
						double num3 = DC_Main.Fnv(ref Value);
						dataRow["IT_PCS_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num3), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_WT"]);
						double num4 = DC_Main.Fnv(ref Value);
						dataRow["KR_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num4), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LESS_PRC"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["KR_LESS_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)num5), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_GWT"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["IT_GWT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_PRC"]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow["IT_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_CON_WT"]);
						double num8 = DC_Main.Fnv(ref Value);
						dataRow["IT_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num8), (object)",'"), RsDetl.Rows[DC_Main.R]["IT_RATE_TYPE"]), (object)"',");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_RATE"]);
						double num9 = DC_Main.Fnv(ref Value);
						dataRow["IT_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num9), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_AMT"]);
						double num10 = DC_Main.Fnv(ref Value);
						dataRow["IT_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num10), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_RATE"]);
						double num11 = DC_Main.Fnv(ref Value);
						dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num11), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_LBR_AMT"]);
						double num12 = DC_Main.Fnv(ref Value);
						dataRow["IT_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num12), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["IT_NET_AMT"]);
						double num13 = DC_Main.Fnv(ref Value);
						dataRow["IT_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num13), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_PRC"]);
						double num14 = DC_Main.Fnv(ref Value);
						dataRow["KR_CON_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num14), (object)", "), (object)" ");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_CON_WT"]);
						double num15 = DC_Main.Fnv(ref Value);
						dataRow["KR_CON_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_RATE"]);
						double num16 = DC_Main.Fnv(ref Value);
						dataRow["KR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_AMT"]);
						double num17 = DC_Main.Fnv(ref Value);
						dataRow["KR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_RATE"]);
						double num18 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_LBR_AMT"]);
						double num19 = DC_Main.Fnv(ref Value);
						dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)num19), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_NET_AMT"]);
						double num20 = DC_Main.Fnv(ref Value);
						dataRow["KR_NET_AMT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num20), (object)",'");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["MAIN_USER"]);
						double num21 = DC_Main.Fnv(ref Value);
						dataRow["MAIN_USER"] = RuntimeHelpers.GetObjectValue(Value);
						object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num21), (object)"', "), (object)" '"), RsDetl.Rows[DC_Main.R]["DM_NAME"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_ORIGIN"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_REMARK"]), (object)"','"), RsDetl.Rows[DC_Main.R]["DM_COLOR"]), (object)"',");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_ACT_WT"]);
						double num22 = DC_Main.Fnv(ref Value);
						dataRow["KR_ACT_WT"] = RuntimeHelpers.GetObjectValue(Value);
						object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num22), (object)",");
						Value = RuntimeHelpers.GetObjectValue((dataRow = RsDetl.Rows[DC_Main.R])["KR_ACT_PRC"]);
						double num23 = DC_Main.Fnv(ref Value);
						dataRow["KR_ACT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num23), (object)")"));
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.R++;
					}
				}
				DC_Main.i++;
			}
			Interaction.MsgBox((object)"Data Import Is Ok...", (MsgBoxStyle)0, (object)null);
		}
	}

	public DataTable OpenRecordsetTrfr(string sql)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		DC_Main.NewTbl = new DataTable();
		DC_Main.Da = new SqlDataAdapter(sql, DC_Main.CnTr);
		((DbDataAdapter)(object)DC_Main.Da).Fill(DC_Main.NewTbl);
		return DC_Main.NewTbl;
	}

	private void btnMainStkToBarDetl_Click(object sender, EventArgs e)
	{
		//IL_20c7: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,COUNT(*) As MainStk FROM MAIN_STOCK  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND ITM_SIGN = '+' AND TAG_NO <> 'N' GROUP BY CO_BOOK,VCH_NO ORDER BY CO_BOOK,VCH_NO";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT COUNT(*) As BarStk FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["MainStk"])) > Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["BarStk"])))
					{
						Application.DoEvents();
						lblStkBook.Text = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]);
						lblStkVch.Text = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]);
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE,B.TAG_TYPE,B.PR_CODE FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY  SR_NO"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						int num2 = DC_Main.Rshlp.Rows.Count - 1;
						DC_Main.i = 0;
						while (DC_Main.i <= num2)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM BAR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"' AND A.SR_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"]), (object)"'"));
							DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable2.Rows.Count == 0)
							{
								DataTable rshlp = DC_Main.Rshlp;
								object obj = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID, SL_TYPE,KR_OTH_RATE,KR_OTH_FINE,KR_TOT_FINE,KR_GWT_TOUCH) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), rshlp.Rows[DC_Main.i]["CO_BOOK"]), (object)"','"), rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"',"), rshlp.Rows[DC_Main.i]["SR_NO"]), (object)","), rshlp.Rows[DC_Main.i]["SR_NO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.i]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp.Rows[DC_Main.i]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp.Rows[DC_Main.i]["VCH_TYPE"]), (object)"','I','"), rshlp.Rows[DC_Main.i]["TR_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.i]["BOOK_NAME"]), (object)"','"), rshlp.Rows[DC_Main.i]["AC_CODE"]), (object)"','"), rshlp.Rows[DC_Main.i]["IT_CODE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"','','"), rshlp.Rows[DC_Main.i]["DESIGN_NO"]), (object)"','"), rshlp.Rows[DC_Main.i]["TBL_CODE"]), (object)"','"), rshlp.Rows[DC_Main.i]["ITM_SIZE"]), (object)"',");
								DataRow dataRow;
								object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_PCS"]);
								double num3 = DC_Main.Fnv(ref Value);
								dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
								object obj2 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj, (object)num3), (object)",0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_GWT"]);
								double num4 = DC_Main.Fnv(ref Value);
								dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj3 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj2, (object)num4), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_GWT"]);
								double num5 = DC_Main.Fnv(ref Value);
								dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj4 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj3, (object)num5), (object)"-");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_NWT"]);
								double value = DC_Main.Fnv(ref Value);
								dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj5 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj4, (object)Math.Abs(value)), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_NWT"]);
								double num6 = DC_Main.Fnv(ref Value);
								dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj6 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj5, (object)num6), (object)", "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["GHT_PRC"]);
								double num7 = DC_Main.Fnv(ref Value);
								dataRow["GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								object obj7 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj6, (object)num7), (object)",0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_TOUCH"]);
								double num8 = DC_Main.Fnv(ref Value);
								dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								object obj8 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj7, (object)num8), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_WEST"]);
								double num9 = DC_Main.Fnv(ref Value);
								dataRow["ITM_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								object obj9 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj8, (object)num9), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_FINE"]);
								double num10 = DC_Main.Fnv(ref Value);
								dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj10 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj9, (object)num10), (object)",0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["LBR_RATE"]);
								double num11 = DC_Main.Fnv(ref Value);
								dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj11 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj10, (object)num11), (object)",'G', "), (object)" ");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["LBR_AMT"]);
								double num12 = DC_Main.Fnv(ref Value);
								dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj12 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj11, (object)num12), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["OTH_AMT"]);
								double num13 = DC_Main.Fnv(ref Value);
								dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj13 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj12, (object)num13), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_RATE"]);
								double num14 = DC_Main.Fnv(ref Value);
								dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj14 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj13, (object)num14), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_AMT"]);
								double num15 = DC_Main.Fnv(ref Value);
								dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj15 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj14, (object)num15), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_COST"]);
								double num16 = DC_Main.Fnv(ref Value);
								dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
								object obj16 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj15, (object)num16), (object)",0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_MRP"]);
								double num17 = DC_Main.Fnv(ref Value);
								dataRow["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
								object obj17 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj16, (object)num17), (object)",'','', "), (object)" '',");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["ITM_GWT"]);
								double num18 = DC_Main.Fnv(ref Value);
								dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj18 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj17, (object)num18), (object)"-");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_NWT"]);
								double value2 = DC_Main.Fnv(ref Value);
								dataRow["KR_NWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj19 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj18, (object)Math.Abs(value2)), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_NWT"]);
								double num19 = DC_Main.Fnv(ref Value);
								dataRow["KR_NWT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj20 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj19, (object)num19), (object)",0,0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_TOUCH"]);
								double num20 = DC_Main.Fnv(ref Value);
								dataRow["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
								object obj21 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj20, (object)num20), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_WEST"]);
								double num21 = DC_Main.Fnv(ref Value);
								dataRow["KR_WEST"] = RuntimeHelpers.GetObjectValue(Value);
								object obj22 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj21, (object)num21), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_FINE"]);
								double num22 = DC_Main.Fnv(ref Value);
								dataRow["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
								object obj23 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj22, (object)num22), (object)", "), (object)" 0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_LBR_AMT"]);
								double num23 = DC_Main.Fnv(ref Value);
								dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj24 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj23, (object)num23), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_OTH_AMT"]);
								double num24 = DC_Main.Fnv(ref Value);
								dataRow["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
								object obj25 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj24, (object)num24), (object)",");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["KR_COST"]);
								double num25 = DC_Main.Fnv(ref Value);
								dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
								object obj26 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj25, (object)num25), (object)",0,");
								Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp.Rows[DC_Main.i])["VCH_SRNO"]);
								double num26 = DC_Main.Fnv(ref Value);
								dataRow["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj26, (object)num26), (object)",'','"), rshlp.Rows[DC_Main.i]["IT_TYPE"]), (object)"', "), (object)" '"), rshlp.Rows[DC_Main.i]["TAG_TYPE"]), (object)"','"), rshlp.Rows[DC_Main.i]["PR_CODE"]), (object)"','N','',0,'','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"','','','','','','', "), (object)" 0,0,0,0,'"), rshlp.Rows[DC_Main.i]["DATA_TYPE"]), (object)"','Y','', "), (object)" 0,0,0,0,0,0,0,0,0,'N','','', "), (object)" '',0,0,0,0)"));
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								rshlp = null;
							}
							DC_Main.i++;
						}
					}
				}
				else
				{
					Application.DoEvents();
					lblStkBook.Text = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]);
					lblStkVch.Text = Conversions.ToString(DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]);
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"' ORDER BY  SR_NO"));
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					int num27 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num27)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_TYPE,B.TAG_TYPE,B.PR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' and A.CO_BOOK = '"), DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"]), (object)"' AND A.VCH_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"]), (object)"' AND A.SR_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["SR_NO"]), (object)"'"));
						DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable2.Rows.Count == 0)
						{
							DataTable rshlp2 = DC_Main.Rshlp;
							object obj27 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,  VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,  TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,  ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,LBR_TYPE,  LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,  KR_NAME,KR_OTH_WT,KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,  KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,  TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,MAIN_USER,ADD_USER,DATA_TRFR,  HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID,HM_ID2,HM_ID3,HM_ID4,  HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,DATA_TYPE,APP_TRFR,ITM_COLOR,  MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID, SL_TYPE,KR_OTH_RATE,KR_OTH_FINE,KR_TOT_FINE,KR_GWT_TOUCH) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','"), rshlp2.Rows[DC_Main.i]["CO_BOOK"]), (object)"','"), rshlp2.Rows[DC_Main.i]["VCH_NO"]), (object)"',"), rshlp2.Rows[DC_Main.i]["SR_NO"]), (object)","), rshlp2.Rows[DC_Main.i]["SR_NO"]), (object)", "), (object)" '"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.i]["VCH_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.i]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), (object)Strings.Format(RuntimeHelpers.GetObjectValue(rshlp2.Rows[DC_Main.i]["STK_DATE"]), "MM/dd/yyyy")), (object)"','"), rshlp2.Rows[DC_Main.i]["VCH_TYPE"]), (object)"','I','"), rshlp2.Rows[DC_Main.i]["ENTRY_TYPE"]), (object)"','"), rshlp2.Rows[DC_Main.i]["BOOK_NAME"]), (object)"','"), rshlp2.Rows[DC_Main.i]["AC_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.i]["IT_CODE"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.i]["TAG_NO"]), (object)"','','"), rshlp2.Rows[DC_Main.i]["DESIGN_NO"]), (object)"','"), rshlp2.Rows[DC_Main.i]["TBL_CODE"]), (object)"','"), rshlp2.Rows[DC_Main.i]["ITM_SIZE"]), (object)"',");
							DataRow dataRow;
							object Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_PCS"]);
							double num28 = DC_Main.Fnv(ref Value);
							dataRow["ITM_PCS"] = RuntimeHelpers.GetObjectValue(Value);
							object obj28 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj27, (object)num28), (object)",0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_GWT"]);
							double num29 = DC_Main.Fnv(ref Value);
							dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj29 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj28, (object)num29), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_GWT"]);
							double num30 = DC_Main.Fnv(ref Value);
							dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj30 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj29, (object)num30), (object)"-");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_NWT"]);
							double value3 = DC_Main.Fnv(ref Value);
							dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj31 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj30, (object)Math.Abs(value3)), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_NWT"]);
							double num31 = DC_Main.Fnv(ref Value);
							dataRow["ITM_NWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj32 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj31, (object)num31), (object)", "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["GHT_PRC"]);
							double num32 = DC_Main.Fnv(ref Value);
							dataRow["GHT_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj33 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj32, (object)num32), (object)",0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_TOUCH"]);
							double num33 = DC_Main.Fnv(ref Value);
							dataRow["ITM_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj34 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj33, (object)num33), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_WEST_PRC"]);
							double num34 = DC_Main.Fnv(ref Value);
							dataRow["ITM_WEST_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							object obj35 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj34, (object)num34), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_FINE"]);
							double num35 = DC_Main.Fnv(ref Value);
							dataRow["ITM_FINE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj36 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj35, (object)num35), (object)",0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["LBR_RATE"]);
							double num36 = DC_Main.Fnv(ref Value);
							dataRow["LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj37 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj36, (object)num36), (object)",'G', "), (object)" ");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["LBR_AMT"]);
							double num37 = DC_Main.Fnv(ref Value);
							dataRow["LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj38 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj37, (object)num37), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["OTH_AMT"]);
							double num38 = DC_Main.Fnv(ref Value);
							dataRow["OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj39 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj38, (object)num38), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_RATE"]);
							double num39 = DC_Main.Fnv(ref Value);
							dataRow["ITM_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj40 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj39, (object)num39), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_AMT"]);
							double num40 = DC_Main.Fnv(ref Value);
							dataRow["ITM_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj41 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj40, (object)num40), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_COST"]);
							double num41 = DC_Main.Fnv(ref Value);
							dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj42 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj41, (object)num41), (object)",0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_MRP"]);
							double num42 = DC_Main.Fnv(ref Value);
							dataRow["ITM_MRP"] = RuntimeHelpers.GetObjectValue(Value);
							object obj43 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj42, (object)num42), (object)",'','', "), (object)" '"), rshlp2.Rows[DC_Main.i]["KR_NAME"]), (object)"',");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["ITM_GWT"]);
							double num43 = DC_Main.Fnv(ref Value);
							dataRow["ITM_GWT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj44 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj43, (object)num43), (object)"-");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_NET_WT"]);
							double value4 = DC_Main.Fnv(ref Value);
							dataRow["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj45 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj44, (object)Math.Abs(value4)), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_NET_WT"]);
							double num44 = DC_Main.Fnv(ref Value);
							dataRow["KR_NET_WT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj46 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj45, (object)num44), (object)",0,0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_TOUCH"]);
							double num45 = DC_Main.Fnv(ref Value);
							dataRow["KR_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							object obj47 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj46, (object)num45), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_WEST"]);
							double num46 = DC_Main.Fnv(ref Value);
							dataRow["KR_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj48 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj47, (object)num46), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_FINE"]);
							double num47 = DC_Main.Fnv(ref Value);
							dataRow["KR_FINE"] = RuntimeHelpers.GetObjectValue(Value);
							object obj49 = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj48, (object)num47), (object)", "), (object)" 0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_LBR_AMT"]);
							double num48 = DC_Main.Fnv(ref Value);
							dataRow["KR_LBR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj50 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj49, (object)num48), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_OTH_AMT"]);
							double num49 = DC_Main.Fnv(ref Value);
							dataRow["KR_OTH_AMT"] = RuntimeHelpers.GetObjectValue(Value);
							object obj51 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj50, (object)num49), (object)",");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["KR_COST"]);
							double num50 = DC_Main.Fnv(ref Value);
							dataRow["KR_COST"] = RuntimeHelpers.GetObjectValue(Value);
							object obj52 = Operators.ConcatenateObject(Operators.ConcatenateObject(obj51, (object)num50), (object)",0,");
							Value = RuntimeHelpers.GetObjectValue((dataRow = rshlp2.Rows[DC_Main.i])["VCH_SRNO"]);
							double num51 = DC_Main.Fnv(ref Value);
							dataRow["VCH_SRNO"] = RuntimeHelpers.GetObjectValue(Value);
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(obj52, (object)num51), (object)",'','"), rshlp2.Rows[DC_Main.i]["IT_TYPE"]), (object)"', "), (object)" '"), rshlp2.Rows[DC_Main.i]["TAG_TYPE"]), (object)"','"), rshlp2.Rows[DC_Main.i]["PR_CODE"]), (object)"','N','',0,'','','','"), (object)DC_Main.MCo_User), (object)"','"), (object)DC_Main.MCo_User), (object)"','N', "), (object)" '"), rshlp2.Rows[DC_Main.i]["VCH_NO"]), (object)"','','','','','','', "), (object)" 0,0,0,0,'"), rshlp2.Rows[DC_Main.i]["DATA_TYPE"]), (object)"','Y','', "), (object)" 0,0,0,0,0,0,0,0,0,'N','','', "), (object)" '',0,0,0,0)"));
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							rshlp2 = null;
						}
						DC_Main.i++;
					}
				}
				DC_Main.M++;
			}
			Interaction.MsgBox((object)"Main Stock Tabel To BarDetl Stock Import Ok....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void tHmId2_TextChanged(object sender, EventArgs e)
	{
	}

	private void tLotNo_TextChanged(object sender, EventArgs e)
	{
	}
}
