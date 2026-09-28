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
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_PURC : Form
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
	[AccessedThroughProperty("BtnImgD")]
	private SimpleButton _BtnImgD;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgS")]
	private SimpleButton _BtnImgS;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnImgC")]
	private SimpleButton _BtnImgC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSlBill")]
	private TextBox _tSlBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboItemTyp")]
	private ComboBox _cboItemTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPartyFine")]
	private TextBox _nPartyFine;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG_PR_IDTL")]
	private AxMSFlexGrid _MSG_PR_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_PR_IDTL")]
	private TextBox _TEXT_PR_IDTL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt")]
	private TextBox _nHmWt;

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
	[AccessedThroughProperty("nHmWt3")]
	private TextBox _nHmWt3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId3")]
	private TextBox _tHmId3;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nHmWt2")]
	private TextBox _nHmWt2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tHmId2")]
	private TextBox _tHmId2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicBill")]
	private PictureBox _PicBill;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillDel")]
	private SimpleButton _btnBillDel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBillSelect")]
	private SimpleButton _btnBillSelect;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnbillCap")]
	private SimpleButton _btnbillCap;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBillImage")]
	private CheckBox _chkBillImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nCrDays")]
	private TextBox _nCrDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUpdate")]
	private SimpleButton _btnUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnQuot")]
	private SimpleButton _btnQuot;

	private string UsUPdate;

	private string UsDelete;

	private string DataTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearPr;

	private bool MsgClearIdtlPr;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private string CurRptTagNo;

	private int StkRow;

	private double PrOthAmtLess;

	private double OldNetAmt;

	private string BookDataType;

	private DataTable VchOldData;

	private double OldTdsPrc;

	private bool RowDelete;

	private bool LInkVchDelete;

	private double ToDayGlRate;

	private double ToDaySlRate;

	private string QtDbCd;

	private string QtNo;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private string OldTagItm;

	private bool ItCodeLock;

	private string TblData;

	private string TblDetl;

	private string TblIdtl;

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

	private DataTable RsBarData;

	private DataTable RsBarDetl;

	private DataTable RsBarIdtl;

	private DataTable RsOldDetl;

	private DataTable RsImg;

	private int FilRow;

	private DataTable DtIdtl;

	private DataRow dr;

	private bool Msgleft;

	private bool UpDown;

	private bool MsTxtDelete;

	private int MsgOldRow;

	private bool MsgIdtlLeft;

	private int FilRowPr;

	private DataTable DtIdtlPr;

	private DataRow drPr;

	private int MsgOldRowPr;

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

	private const int cPrSrNo = 0;

	private const int cPrItCode = 1;

	private const int cPrItName = 2;

	private const int cPrCounter = 3;

	private const int cPrDesign = 4;

	private const int cPrLotNo = 5;

	private const int cPrItmLot = 6;

	private const int cPrWithStk = 7;

	private const int cPrBagWt = 8;

	private const int cPrPcs = 9;

	private const int cPrBagTot = 10;

	private const int cPrPcsWt = 11;

	private const int cPrGrWt = 12;

	private const int cPrOthWt = 13;

	private const int cPrLossWt = 14;

	private const int cPrKundan = 15;

	private const int cPrKundanTch = 16;

	private const int cPrKundanFine = 17;

	private const int cPrNetWt = 18;

	private const int cPrGhtPrc = 19;

	private const int cPrGhtWt = 20;

	private const int cPrTouch = 21;

	private const int cPrWestPrc = 22;

	private const int cPrLessTch = 23;

	private const int cPrFine = 24;

	private const int cPrNetFine = 25;

	private const int cPrSilverFine = 26;

	private const int cPrConvRate = 27;

	private const int cPrConvPrc = 28;

	private const int cPrRate = 29;

	private const int cPrUrdRateType = 30;

	private const int cPrItAmt = 31;

	private const int cPrLbrPrc = 32;

	private const int cPrLbrType = 33;

	private const int cPrLbrRate = 34;

	private const int cPrLbrAmt = 35;

	private const int cPrOthAmt = 36;

	private const int cPrOthRate = 37;

	private const int cPrOthFine = 38;

	private const int cPrMrp = 39;

	private const int cPrTotAmt = 40;

	private const int cPrComPrc = 41;

	private const int cPrComAmt = 42;

	private const int cPrTaxPrc = 43;

	private const int cPrNetAmt = 44;

	private const int cPrItType = 45;

	private const int cPrRateType = 46;

	private const int cPrOldGwt = 47;

	private const int cPrOldNwt = 48;

	private const int cPrOldTouch = 49;

	private const int cPrOldWest = 50;

	private const int cPrOldRate = 51;

	private const int cPrOldLestch = 52;

	private const int cPrHmFine = 53;

	private const int cPrOldLbrRate = 54;

	private const int cPrcOldLbrAmt = 55;

	private const int cPrOldItAmt = 56;

	private const int cPrOldSrNo = 57;

	private const int cPrOldTaxPrc = 58;

	private const int cPrOldGhtWt = 59;

	private const int cPrCutPcs = 60;

	private const int cPrCutGwt = 61;

	private const int cPrCutNwt = 62;

	private const int cPrCutFine = 63;

	private const int cPrPrCode = 64;

	private const int cPrOldItCode = 65;

	private const int cPrOldBagTot = 66;

	private const int cPrOldKundan = 67;

	private const int cPrOldKundanPrc = 68;

	private const int cPrOldKundanFine = 69;

	private const int c2SrNo = 0;

	private const int c2ItCode = 1;

	private const int c2ItName = 2;

	private const int c2DmCode = 3;

	private const int c2DmName = 4;

	private const int c2DmColor = 5;

	private const int c2DmSize = 6;

	private const int c2DmOrigin = 7;

	private const int c2DmRemark = 8;

	private const int c2DmSfNo = 9;

	private const int c2MotiPcs = 10;

	private const int c2MotiWt = 11;

	private const int c2Pcs = 12;

	private const int c2PcsWt = 13;

	private const int c2GrWt = 14;

	private const int c2ConPrc = 15;

	private const int c2RateType = 16;

	private const int c2ItRate = 17;

	private const int c2ItmAmt = 18;

	private const int c2LbrRate = 19;

	private const int c2LbrAmt = 20;

	private const int c2NetAmt = 21;

	private const int c2ConWt = 22;

	private const int c2ItType = 23;

	private const int c2RowSr = 24;

	private const int cSrNo = 0;

	private const int cOrdNo = 1;

	private const int cItCode = 2;

	private const int cTagNo = 3;

	private const int cCounter = 4;

	private const int cDesign = 5;

	private const int cStyle = 6;

	private const int cSize = 7;

	private const int cHmId = 8;

	private const int cBagWt = 9;

	private const int cPcs = 10;

	private const int cGrWt = 11;

	private const int cOthWt = 12;

	private const int cNetWt = 13;

	private const int cKrOthWt = 14;

	private const int cKrNetWt = 15;

	private const int cKrGhatPrc = 16;

	private const int cKrGhatWt = 17;

	private const int cKrTouch = 18;

	private const int cKrWestPrc = 19;

	private const int cKrFine = 20;

	private const int cLbrCode = 21;

	private const int cGhtPrc = 22;

	private const int cGhtWt = 23;

	private const int cTouch = 24;

	private const int cWestPrc = 25;

	private const int cFine = 26;

	private const int cLbrPrc = 27;

	private const int cLbrType = 28;

	private const int cLbrRate = 29;

	private const int cLbrAmt = 30;

	private const int cOthAmt = 31;

	private const int cKrLRate = 32;

	private const int cKrLAmt = 33;

	private const int cKrOthAmt = 34;

	private const int cPrCost = 35;

	private const int cItRate = 36;

	private const int cItAmt = 37;

	private const int cTagCost = 38;

	private const int cMargin = 39;

	private const int cMrp = 40;

	private const int cImageTake = 41;

	private const int cItRemark = 42;

	private const int cEmpCode = 43;

	private const int cKrName = 44;

	private const int cTagSrNo = 45;

	private const int cOldSrNo = 46;

	private const int cRateType = 47;

	private const int cItType = 48;

	private const int cTagType = 49;

	private const int cPrCode = 50;

	private const int cVchSrno = 51;

	private const int cItName = 52;

	private const int cEntryMod = 53;

	private const int cOldTagType = 54;

	private const int cOldPrCode = 55;

	private const int cOldGrWt = 56;

	private const int cOldNtWt = 57;

	private const int cOldGhatPrc = 58;

	private const int cOldGhatWt = 59;

	private const int cOldTouch = 60;

	private const int cOldWestPrc = 61;

	private const int cOldKrNetWt = 62;

	private const int cOldKrTouch = 63;

	private const int cOldKrWest = 64;

	private const int cAprIsu = 65;

	private const int cHmId2 = 66;

	private const int cHmId3 = 67;

	private const int cHmId4 = 68;

	private const int cHmIdWt = 69;

	private const int cHmId2Wt = 70;

	private const int cHmId3Wt = 71;

	private const int cHmId4Wt = 72;

	private const int cDataType = 73;

	private const int cOrdSrNo = 74;

	private const int cOrdYrcd = 75;

	private const int cOrdDbCd = 76;

	private const int cOrdName = 77;

	private const int cOrdAc = 78;

	private const int cOrdLc = 79;

	private const int cEmpIsu = 80;

	private const int cRowValue = 81;

	private const int cRowText = 82;

	private const int cDesignImgId = 83;

	private const int cOldMargin = 84;

	private const int cLotTouch = 85;

	private const int cLotWest = 86;

	private const int cLotFine = 87;

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

	private const int c1KrWt = 14;

	private const int c1KrPrc = 15;

	private const int c1GrWt = 16;

	private const int c1ConPrc = 17;

	private const int c1RateType = 18;

	private const int c1ItRate = 19;

	private const int c1ItmAmt = 20;

	private const int c1KrConPrc = 21;

	private const int c1KrRateType = 22;

	private const int c1KrRate = 23;

	private const int c1KrAmt = 24;

	private const int c1LbrRate = 25;

	private const int c1LbrAmt = 26;

	private const int c1NetAmt = 27;

	private const int c1ConWt = 28;

	private const int c1KrConWt = 29;

	private const int c1ItType = 30;

	private const int c1RowSr = 31;

	private const int c1oldKrWt = 32;

	private const int c1oldGrWt = 33;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cTcs2 = 3;

	private const int cRof2 = 4;

	private const int cTot2 = 5;

	private const int cChq2 = 6;

	private const int cCard2 = 7;

	private const int cCash2 = 8;

	private const int cKasar2 = 9;

	private const int cOs2 = 10;

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
			EventHandler eventHandler2 = tAcCode_DoubleClick;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler2;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler2;
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
			EventHandler eventHandler = MSG_PR_RowColChange;
			EventHandler eventHandler2 = MSG_PR_ClickEvent;
			EventHandler eventHandler3 = MSG_PR_EnterCell;
			EventHandler eventHandler4 = MSG_PR_LeaveCell;
			EventHandler eventHandler5 = MSG_PR_Scroll;
			AxMSFlexGrid val = _MSG_PR;
			if (val != null)
			{
				val.RowColChange -= eventHandler;
				val.ClickEvent -= eventHandler2;
				val.EnterCell -= eventHandler3;
				val.LeaveCell -= eventHandler4;
				val.Scroll -= eventHandler5;
			}
			_MSG_PR = value;
			val = _MSG_PR;
			if (val != null)
			{
				val.RowColChange += eventHandler;
				val.ClickEvent += eventHandler2;
				val.EnterCell += eventHandler3;
				val.LeaveCell += eventHandler4;
				val.Scroll += eventHandler5;
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

	internal virtual TextBox tSlBill
	{
		[CompilerGenerated]
		get
		{
			return _tSlBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tSlBill_KeyDown);
			TextBox val2 = _tSlBill;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tSlBill = value;
			val2 = _tSlBill;
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
	[AccessedThroughProperty("tSlBill_DbCd")]
	private virtual TextBox _tSlBill_DbCd;

	internal virtual TextBox tSlBill_DbCd
	{
		get
		{
			return _tSlBill_DbCd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tSlBill_DbCd = value;
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

	internal virtual TextBox nPartyFine
	{
		[CompilerGenerated]
		get
		{
			return _nPartyFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPartyFine_KeyDown);
			TextBox val2 = _nPartyFine;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPartyFine = value;
			val2 = _nPartyFine;
			if (val2 != null)
			{
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
	[AccessedThroughProperty("lblOldFine")]
	private virtual Label _lblOldFine;

	internal virtual Label lblOldFine
	{
		get
		{
			return _lblOldFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOldFine = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlPrIdtl")]
	private virtual Panel _PnlPrIdtl;

	internal virtual Panel PnlPrIdtl
	{
		get
		{
			return _PnlPrIdtl;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlPrIdtl = value;
		}
	}

	internal virtual AxMSFlexGrid MSG_PR_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _MSG_PR_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = MSG_PR_IDTL_ClickEvent;
			EventHandler eventHandler2 = MSG_PR_IDTL_EnterCell;
			EventHandler eventHandler3 = MSG_PR_IDTL_LeaveCell;
			AxMSFlexGrid val = _MSG_PR_IDTL;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
			}
			_MSG_PR_IDTL = value;
			val = _MSG_PR_IDTL;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
			}
		}
	}

	internal virtual TextBox TEXT_PR_IDTL
	{
		[CompilerGenerated]
		get
		{
			return _TEXT_PR_IDTL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_PR_IDTL_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_PR_IDTL_KeyDown);
			TextBox val2 = _TEXT_PR_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_TEXT_PR_IDTL = value;
			val2 = _TEXT_PR_IDTL;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
				((Control)val2).KeyDown += val;
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
			TextBox val2 = _tHmId2;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tHmId2 = value;
			val2 = _tHmId2;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlBill")]
	private virtual Panel _pnlBill;

	internal virtual Panel pnlBill
	{
		get
		{
			return _pnlBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlBill = value;
		}
	}

	internal virtual PictureBox PicBill
	{
		[CompilerGenerated]
		get
		{
			return _PicBill;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicBill_DoubleClick;
			PictureBox val = _PicBill;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicBill = value;
			val = _PicBill;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillDel
	{
		[CompilerGenerated]
		get
		{
			return _btnBillDel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillDel_Click;
			SimpleButton val = _btnBillDel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillDel = value;
			val = _btnBillDel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnBillSelect
	{
		[CompilerGenerated]
		get
		{
			return _btnBillSelect;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnBillSelect_Click;
			SimpleButton val = _btnBillSelect;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBillSelect = value;
			val = _btnBillSelect;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnbillCap
	{
		[CompilerGenerated]
		get
		{
			return _btnbillCap;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnbillCap_Click;
			SimpleButton val = _btnbillCap;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnbillCap = value;
			val = _btnbillCap;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkBillImage
	{
		[CompilerGenerated]
		get
		{
			return _chkBillImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkBillImage_CheckedChanged;
			CheckBox val = _chkBillImage;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkBillImage = value;
			val = _chkBillImage;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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
			EventHandler eventHandler = nCrDays_TextChanged;
			TextBox val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nCrDays = value;
			val2 = _nCrDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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
	[AccessedThroughProperty("PnlUpdate")]
	private virtual Panel _PnlUpdate;

	internal virtual Panel PnlUpdate
	{
		get
		{
			return _PnlUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlUpdate = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("picAc")]
	private virtual PictureBox _picAc;

	internal virtual PictureBox picAc
	{
		get
		{
			return _picAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_picAc = value;
		}
	}

	internal virtual SimpleButton btnUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnUpdate_Click;
			SimpleButton val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUpdate = value;
			val = _btnUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UMobile")]
	private virtual Label _UMobile;

	internal virtual Label UMobile
	{
		get
		{
			return _UMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UGstNo")]
	private virtual Label _UGstNo;

	internal virtual Label UGstNo
	{
		get
		{
			return _UGstNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UGstNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UCity")]
	private virtual Label _UCity;

	internal virtual Label UCity
	{
		get
		{
			return _UCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UCity = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd3")]
	private virtual Label _UAdd3;

	internal virtual Label UAdd3
	{
		get
		{
			return _UAdd3;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd3 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd2")]
	private virtual Label _UAdd2;

	internal virtual Label UAdd2
	{
		get
		{
			return _UAdd2;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd2 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("UAdd1")]
	private virtual Label _UAdd1;

	internal virtual Label UAdd1
	{
		get
		{
			return _UAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_UAdd1 = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label26")]
	private virtual Label _Label26;

	internal virtual Label Label26
	{
		get
		{
			return _Label26;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label26 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label27")]
	private virtual Label _Label27;

	internal virtual Label Label27
	{
		get
		{
			return _Label27;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label27 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label28")]
	private virtual Label _Label28;

	internal virtual Label Label28
	{
		get
		{
			return _Label28;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label28 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label29")]
	private virtual Label _Label29;

	internal virtual Label Label29
	{
		get
		{
			return _Label29;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label29 = value;
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

	internal virtual SimpleButton btnQuot
	{
		[CompilerGenerated]
		get
		{
			return _btnQuot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnQuot_Click;
			SimpleButton val = _btnQuot;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnQuot = value;
			val = _btnQuot;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public TR_PURC()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_PURC_Load;
		((Form)this).Deactivate += TR_PURC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_PURC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_PURC_KeyDown);
		((Form)this).Activated += TR_PURC_Activated;
		((Form)this).Closed += TR_PURC_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_PURC_KeyUp);
		DtIdtl = new DataTable();
		dr = DtIdtl.NewRow();
		DtIdtlPr = new DataTable();
		drPr = DtIdtlPr.NewRow();
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
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0460: Expected O, but got Unknown
		//IL_0462: Unknown result type (might be due to invalid IL or missing references)
		//IL_046c: Expected O, but got Unknown
		//IL_046e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0478: Expected O, but got Unknown
		//IL_047a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Expected O, but got Unknown
		//IL_0486: Unknown result type (might be due to invalid IL or missing references)
		//IL_0490: Expected O, but got Unknown
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_049c: Expected O, but got Unknown
		//IL_049e: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a8: Expected O, but got Unknown
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b4: Expected O, but got Unknown
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_04ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d8: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e4: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_04f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fc: Expected O, but got Unknown
		//IL_04fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Expected O, but got Unknown
		//IL_050a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0514: Expected O, but got Unknown
		//IL_0516: Unknown result type (might be due to invalid IL or missing references)
		//IL_0520: Expected O, but got Unknown
		//IL_0522: Unknown result type (might be due to invalid IL or missing references)
		//IL_052c: Expected O, but got Unknown
		//IL_052e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0538: Expected O, but got Unknown
		//IL_053a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0544: Expected O, but got Unknown
		//IL_0546: Unknown result type (might be due to invalid IL or missing references)
		//IL_0550: Expected O, but got Unknown
		//IL_0552: Unknown result type (might be due to invalid IL or missing references)
		//IL_055c: Expected O, but got Unknown
		//IL_055e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0568: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Expected O, but got Unknown
		//IL_075a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Expected O, but got Unknown
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		//IL_088e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Expected O, but got Unknown
		//IL_0946: Unknown result type (might be due to invalid IL or missing references)
		//IL_0950: Expected O, but got Unknown
		//IL_09d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e1: Expected O, but got Unknown
		//IL_0a7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a86: Expected O, but got Unknown
		//IL_0b15: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1f: Expected O, but got Unknown
		//IL_0b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8c: Expected O, but got Unknown
		//IL_0c35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3f: Expected O, but got Unknown
		//IL_0ca2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected O, but got Unknown
		//IL_0d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Expected O, but got Unknown
		//IL_0e7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e86: Expected O, but got Unknown
		//IL_0f91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f9b: Expected O, but got Unknown
		//IL_0ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1008: Expected O, but got Unknown
		//IL_119a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1289: Unknown result type (might be due to invalid IL or missing references)
		//IL_1293: Expected O, but got Unknown
		//IL_134b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1355: Expected O, but got Unknown
		//IL_1402: Unknown result type (might be due to invalid IL or missing references)
		//IL_140c: Expected O, but got Unknown
		//IL_1504: Unknown result type (might be due to invalid IL or missing references)
		//IL_150e: Expected O, but got Unknown
		//IL_161f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1629: Expected O, but got Unknown
		//IL_16a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b0: Expected O, but got Unknown
		//IL_1774: Unknown result type (might be due to invalid IL or missing references)
		//IL_177e: Expected O, but got Unknown
		//IL_1826: Unknown result type (might be due to invalid IL or missing references)
		//IL_1830: Expected O, but got Unknown
		//IL_1928: Unknown result type (might be due to invalid IL or missing references)
		//IL_1932: Expected O, but got Unknown
		//IL_1996: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a0: Expected O, but got Unknown
		//IL_1aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ab3: Expected O, but got Unknown
		//IL_1b8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b95: Expected O, but got Unknown
		//IL_1c31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c3b: Expected O, but got Unknown
		//IL_1d76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d80: Expected O, but got Unknown
		//IL_1dcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd5: Expected O, but got Unknown
		//IL_1e52: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5c: Expected O, but got Unknown
		//IL_1edd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee7: Expected O, but got Unknown
		//IL_1fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fbb: Expected O, but got Unknown
		//IL_2062: Unknown result type (might be due to invalid IL or missing references)
		//IL_206c: Expected O, but got Unknown
		//IL_20ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f7: Expected O, but got Unknown
		//IL_217c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2186: Expected O, but got Unknown
		//IL_223a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2244: Expected O, but got Unknown
		//IL_22f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2302: Expected O, but got Unknown
		//IL_23bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c7: Expected O, but got Unknown
		//IL_242b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2435: Expected O, but got Unknown
		//IL_2490: Unknown result type (might be due to invalid IL or missing references)
		//IL_249a: Expected O, but got Unknown
		//IL_2539: Unknown result type (might be due to invalid IL or missing references)
		//IL_2543: Expected O, but got Unknown
		//IL_25d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_25db: Expected O, but got Unknown
		//IL_265d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2667: Expected O, but got Unknown
		//IL_2707: Unknown result type (might be due to invalid IL or missing references)
		//IL_2711: Expected O, but got Unknown
		//IL_27bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_27c9: Expected O, but got Unknown
		//IL_29b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29bf: Expected O, but got Unknown
		//IL_2a6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a76: Expected O, but got Unknown
		//IL_2b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b0f: Expected O, but got Unknown
		//IL_2bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bc7: Expected O, but got Unknown
		//IL_2c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c60: Expected O, but got Unknown
		//IL_2d0e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d18: Expected O, but got Unknown
		//IL_2dc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dd0: Expected O, but got Unknown
		//IL_2e5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e69: Expected O, but got Unknown
		//IL_2ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f02: Expected O, but got Unknown
		//IL_2f90: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f9a: Expected O, but got Unknown
		//IL_305d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3067: Expected O, but got Unknown
		//IL_30b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c3: Expected O, but got Unknown
		//IL_3174: Unknown result type (might be due to invalid IL or missing references)
		//IL_317e: Expected O, but got Unknown
		//IL_322f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3239: Expected O, but got Unknown
		//IL_32e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_32f0: Expected O, but got Unknown
		//IL_33a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ae: Expected O, but got Unknown
		//IL_3462: Unknown result type (might be due to invalid IL or missing references)
		//IL_346c: Expected O, but got Unknown
		//IL_3520: Unknown result type (might be due to invalid IL or missing references)
		//IL_352a: Expected O, but got Unknown
		//IL_35e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_35eb: Expected O, but got Unknown
		//IL_36a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ac: Expected O, but got Unknown
		//IL_3763: Unknown result type (might be due to invalid IL or missing references)
		//IL_376d: Expected O, but got Unknown
		//IL_37e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_37f1: Expected O, but got Unknown
		//IL_38a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_38ac: Expected O, but got Unknown
		//IL_3946: Unknown result type (might be due to invalid IL or missing references)
		//IL_3950: Expected O, but got Unknown
		//IL_39ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_39d4: Expected O, but got Unknown
		//IL_3a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9c: Expected O, but got Unknown
		//IL_3b3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b45: Expected O, but got Unknown
		//IL_3bf2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bfc: Expected O, but got Unknown
		//IL_3cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cb7: Expected O, but got Unknown
		//IL_3d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d4f: Expected O, but got Unknown
		//IL_3ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3de7: Expected O, but got Unknown
		//IL_3f52: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f5c: Expected O, but got Unknown
		//IL_3ffd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4007: Expected O, but got Unknown
		//IL_4051: Unknown result type (might be due to invalid IL or missing references)
		//IL_405b: Expected O, but got Unknown
		//IL_40d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_40dc: Expected O, but got Unknown
		//IL_418d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4197: Expected O, but got Unknown
		//IL_4212: Unknown result type (might be due to invalid IL or missing references)
		//IL_421c: Expected O, but got Unknown
		//IL_42d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_42da: Expected O, but got Unknown
		//IL_435c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4366: Expected O, but got Unknown
		//IL_43e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_43eb: Expected O, but got Unknown
		//IL_449f: Unknown result type (might be due to invalid IL or missing references)
		//IL_44a9: Expected O, but got Unknown
		//IL_452b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4535: Expected O, but got Unknown
		//IL_45b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_45ba: Expected O, but got Unknown
		//IL_466e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4678: Expected O, but got Unknown
		//IL_47ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_47f6: Expected O, but got Unknown
		//IL_48aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_48b4: Expected O, but got Unknown
		//IL_4965: Unknown result type (might be due to invalid IL or missing references)
		//IL_496f: Expected O, but got Unknown
		//IL_4ab1: Unknown result type (might be due to invalid IL or missing references)
		//IL_4abb: Expected O, but got Unknown
		//IL_4b49: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b53: Expected O, but got Unknown
		//IL_4e66: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e70: Expected O, but got Unknown
		//IL_4f8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f99: Expected O, but got Unknown
		//IL_504d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5057: Expected O, but got Unknown
		//IL_5108: Unknown result type (might be due to invalid IL or missing references)
		//IL_5112: Expected O, but got Unknown
		//IL_51c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_51cd: Expected O, but got Unknown
		//IL_527e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5288: Expected O, but got Unknown
		//IL_5339: Unknown result type (might be due to invalid IL or missing references)
		//IL_5343: Expected O, but got Unknown
		//IL_53f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_53fe: Expected O, but got Unknown
		//IL_54ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_54b6: Expected O, but got Unknown
		//IL_5566: Unknown result type (might be due to invalid IL or missing references)
		//IL_5570: Expected O, but got Unknown
		//IL_561e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5628: Expected O, but got Unknown
		//IL_56d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_56e0: Expected O, but got Unknown
		//IL_578e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5798: Expected O, but got Unknown
		//IL_5866: Unknown result type (might be due to invalid IL or missing references)
		//IL_5870: Expected O, but got Unknown
		//IL_5948: Unknown result type (might be due to invalid IL or missing references)
		//IL_5952: Expected O, but got Unknown
		//IL_59ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_59f8: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_PURC));
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
		chkBillImage = new CheckBox();
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
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_PR = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_PR = new TextBox();
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
		MSG_PR_TOT = new AxMSFlexGrid();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		LOpSilver = new Label();
		LOpGold = new Label();
		LOpAmt = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		tSlBill = new TextBox();
		Label5 = new Label();
		tSlBill_DbCd = new TextBox();
		cboItemTyp = new ComboBox();
		Label12 = new Label();
		nPartyFine = new TextBox();
		Label14 = new Label();
		Label15 = new Label();
		nitGwt = new TextBox();
		nItNwt = new TextBox();
		lblOldFine = new Label();
		PnlPrIdtl = new Panel();
		TEXT_PR_IDTL = new TextBox();
		MSG_PR_IDTL = new AxMSFlexGrid();
		nHmWt = new TextBox();
		Label16 = new Label();
		nHmWt4 = new TextBox();
		Label17 = new Label();
		tHmId4 = new TextBox();
		nHmWt3 = new TextBox();
		Label18 = new Label();
		tHmId3 = new TextBox();
		nHmWt2 = new TextBox();
		Label19 = new Label();
		tHmId2 = new TextBox();
		pnlBill = new Panel();
		btnBillDel = new SimpleButton();
		btnBillSelect = new SimpleButton();
		btnbillCap = new SimpleButton();
		PicBill = new PictureBox();
		nCrDays = new TextBox();
		Label22 = new Label();
		PnlUpdate = new Panel();
		picAc = new PictureBox();
		btnUpdate = new SimpleButton();
		UMobile = new Label();
		UGstNo = new Label();
		UCity = new Label();
		UAdd3 = new Label();
		UAdd2 = new Label();
		UAdd1 = new Label();
		Label23 = new Label();
		Label21 = new Label();
		Label26 = new Label();
		Label27 = new Label();
		Label28 = new Label();
		Label29 = new Label();
		btnQuot = new SimpleButton();
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
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_PR_TOT).BeginInit();
		((Control)PnlPrIdtl).SuspendLayout();
		((ISupportInitialize)MSG_PR_IDTL).BeginInit();
		((Control)pnlBill).SuspendLayout();
		((ISupportInitialize)PicBill).BeginInit();
		((Control)PnlUpdate).SuspendLayout();
		((ISupportInitialize)picAc).BeginInit();
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
		lblBook.Text = "Purchase";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 38);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(229, 39);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(22, 40);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(92, 38);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(91, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 38);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 38);
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
		((Control)PnlBotam).TabIndex = 21;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkBillImage);
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkBillImage).BackColor = Color.Transparent;
		((Control)chkBillImage).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkBillImage).ForeColor = Color.Black;
		((Control)chkBillImage).Location = new Point(456, 3);
		((Control)chkBillImage).Name = "chkBillImage";
		((Control)chkBillImage).RightToLeft = (RightToLeft)0;
		((Control)chkBillImage).Size = new Size(116, 27);
		((Control)chkBillImage).TabIndex = 6;
		((ButtonBase)chkBillImage).Text = "Bill Image";
		((ButtonBase)chkBillImage).UseVisualStyleBackColor = false;
		((Control)chkBillImage).Visible = false;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(331, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(119, 27);
		((Control)chkWapp).TabIndex = 9;
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
		((Control)TEXT_ENTRY).Location = new Point(827, 263);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 8;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(425, 474);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(182, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(187, 419);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 15;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 364);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(708, 104);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(12, 473);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(106, 86);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 312);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1154, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 202);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 108);
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
		((Control)BtnF1).Location = new Point(187, 38);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(33, 23);
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
		((Control)tAcCode).Location = new Point(312, 67);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 67);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(347, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(230, 66);
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
		((Control)tEmpCode).Location = new Point(248, 474);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(58, 23);
		((Control)tEmpCode).TabIndex = 17;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(310, 474);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(109, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(174, 474);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(167, 528);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(248, 529);
		((TextBoxBase)tVchDesc).MaxLength = 230;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(316, 31);
		((Control)tVchDesc).TabIndex = 20;
		((Control)MSG2_TOTAL).Location = new Point(729, 333);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 225);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_PR).Location = new Point(13, 96);
		((Control)MSG_PR).Name = "MSG_PR";
		((AxHost)MSG_PR).OcxState = (State)componentResourceManager.GetObject("MSG_PR.OcxState");
		((Control)MSG_PR).Size = new Size(1156, 85);
		((Control)MSG_PR).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(956, 454);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 16;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_PR).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR).ForeColor = Color.White;
		((Control)TEXT_PR).Location = new Point(797, 127);
		((Control)TEXT_PR).Name = "TEXT_PR";
		((Control)TEXT_PR).Size = new Size(100, 18);
		((Control)TEXT_PR).TabIndex = 6;
		((Control)TEXT_PR).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(248, 502);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(77, 23);
		((Control)tBankName).TabIndex = 18;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(167, 502);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 67);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(92, 67);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(91, 23);
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
		((Control)PanelAdd).Location = new Point(312, 97);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(408, 152);
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
		((Control)MSG_PR_TOT).Location = new Point(15, 181);
		((Control)MSG_PR_TOT).Name = "MSG_PR_TOT";
		((AxHost)MSG_PR_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_PR_TOT.OcxState");
		((Control)MSG_PR_TOT).Size = new Size(1152, 15);
		((Control)MSG_PR_TOT).TabIndex = 1179;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(122, 534);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 25);
		((Control)BtnImgD).TabIndex = 1182;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(122, 504);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 25);
		((Control)BtnImgS).TabIndex = 1181;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(122, 474);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 25);
		((Control)BtnImgC).TabIndex = 1180;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1020, 74);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(148, 20);
		((Control)LOpSilver).TabIndex = 1210;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1020, 54);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(148, 20);
		((Control)LOpGold).TabIndex = 1209;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1020, 34);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1208;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(577, 539);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(143, 20);
		((Control)LClSilver).TabIndex = 1213;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(577, 518);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(143, 20);
		((Control)lClGold).TabIndex = 1212;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(577, 497);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(143, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSlBill).BackColor = Color.White;
		((Control)tSlBill).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBill).Location = new Point(821, 67);
		((TextBoxBase)tSlBill).MaxLength = 8;
		((Control)tSlBill).Name = "tSlBill";
		((TextBoxBase)tSlBill).ReadOnly = true;
		((Control)tSlBill).Size = new Size(76, 23);
		((Control)tSlBill).TabIndex = 1214;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(750, 68);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(66, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Sl Bil No";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tSlBill_DbCd).BackColor = Color.White;
		((Control)tSlBill_DbCd).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSlBill_DbCd).Location = new Point(903, 67);
		((TextBoxBase)tSlBill_DbCd).MaxLength = 8;
		((Control)tSlBill_DbCd).Name = "tSlBill_DbCd";
		((TextBoxBase)tSlBill_DbCd).ReadOnly = true;
		((Control)tSlBill_DbCd).Size = new Size(76, 23);
		((Control)tSlBill_DbCd).TabIndex = 1216;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(654, 39);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(87, 22);
		((Control)cboItemTyp).TabIndex = 1217;
		((Control)cboItemTyp).Visible = false;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(571, 40);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(74, 20);
		((Control)Label12).TabIndex = 1218;
		Label12.Text = "Item Type";
		Label12.TextAlign = (ContentAlignment)64;
		((Control)Label12).Visible = false;
		((TextBoxBase)nPartyFine).BackColor = Color.White;
		((Control)nPartyFine).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPartyFine).Location = new Point(495, 501);
		((TextBoxBase)nPartyFine).MaxLength = 50;
		((Control)nPartyFine).Name = "nPartyFine";
		((Control)nPartyFine).Size = new Size(69, 23);
		((Control)nPartyFine).TabIndex = 1219;
		nPartyFine.TextAlign = (HorizontalAlignment)1;
		((Control)nPartyFine).Visible = false;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(425, 503);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(69, 20);
		((Control)Label14).TabIndex = 1220;
		Label14.Text = "Party Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((Control)Label14).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(750, 40);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(821, 40);
		((TextBoxBase)nitGwt).MaxLength = 8;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(76, 23);
		((Control)nitGwt).TabIndex = 1222;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(903, 40);
		((TextBoxBase)nItNwt).MaxLength = 8;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(76, 23);
		((Control)nItNwt).TabIndex = 1223;
		((Control)lblOldFine).BackColor = Color.Transparent;
		((Control)lblOldFine).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblOldFine).ForeColor = Color.Red;
		lblOldFine.ImeMode = (ImeMode)0;
		((Control)lblOldFine).Location = new Point(600, 475);
		((Control)lblOldFine).Name = "lblOldFine";
		((Control)lblOldFine).Size = new Size(120, 20);
		((Control)lblOldFine).TabIndex = 1225;
		lblOldFine.Text = "Old Itm Fine";
		lblOldFine.TextAlign = (ContentAlignment)64;
		((Control)lblOldFine).Visible = false;
		((Control)PnlPrIdtl).BackColor = SystemColors.ButtonHighlight;
		((Control)PnlPrIdtl).Controls.Add((Control)(object)TEXT_PR_IDTL);
		((Control)PnlPrIdtl).Controls.Add((Control)(object)MSG_PR_IDTL);
		((Control)PnlPrIdtl).Location = new Point(-9, 197);
		((Control)PnlPrIdtl).Name = "PnlPrIdtl";
		((Control)PnlPrIdtl).Size = new Size(1307, 133);
		((Control)PnlPrIdtl).TabIndex = 7;
		((Control)PnlPrIdtl).Visible = false;
		((TextBoxBase)TEXT_PR_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_PR_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_PR_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_PR_IDTL).ForeColor = Color.White;
		((Control)TEXT_PR_IDTL).Location = new Point(380, 66);
		((Control)TEXT_PR_IDTL).Name = "TEXT_PR_IDTL";
		((Control)TEXT_PR_IDTL).Size = new Size(100, 18);
		((Control)TEXT_PR_IDTL).TabIndex = 9;
		((Control)TEXT_PR_IDTL).Visible = false;
		((Control)MSG_PR_IDTL).Location = new Point(22, 7);
		((Control)MSG_PR_IDTL).Name = "MSG_PR_IDTL";
		((AxHost)MSG_PR_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_PR_IDTL.OcxState");
		((Control)MSG_PR_IDTL).Size = new Size(1069, 113);
		((Control)MSG_PR_IDTL).TabIndex = 0;
		((TextBoxBase)nHmWt).BackColor = Color.Linen;
		((Control)nHmWt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt).Location = new Point(69, 334);
		((TextBoxBase)nHmWt).MaxLength = 10;
		((Control)nHmWt).Name = "nHmWt";
		((Control)nHmWt).Size = new Size(65, 23);
		((Control)nHmWt).TabIndex = 8;
		nHmWt.TextAlign = (HorizontalAlignment)1;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(12, 334);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(49, 20);
		((Control)Label16).TabIndex = 1232;
		Label16.Text = "HuWt";
		Label16.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nHmWt4).BackColor = Color.Linen;
		((Control)nHmWt4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt4).Location = new Point(654, 334);
		((TextBoxBase)nHmWt4).MaxLength = 10;
		((Control)nHmWt4).Name = "nHmWt4";
		((Control)nHmWt4).Size = new Size(65, 23);
		((Control)nHmWt4).TabIndex = 14;
		nHmWt4.TextAlign = (HorizontalAlignment)1;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(530, 335);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(54, 20);
		((Control)Label17).TabIndex = 1248;
		Label17.Text = "HuId4";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId4).BackColor = Color.White;
		((Control)tHmId4).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId4).Location = new Point(587, 334);
		((TextBoxBase)tHmId4).MaxLength = 10;
		((Control)tHmId4).Name = "tHmId4";
		((Control)tHmId4).Size = new Size(65, 23);
		((Control)tHmId4).TabIndex = 13;
		((TextBoxBase)nHmWt3).BackColor = Color.Linen;
		((Control)nHmWt3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt3).Location = new Point(459, 334);
		((TextBoxBase)nHmWt3).MaxLength = 10;
		((Control)nHmWt3).Name = "nHmWt3";
		((Control)nHmWt3).Size = new Size(65, 23);
		((Control)nHmWt3).TabIndex = 12;
		nHmWt3.TextAlign = (HorizontalAlignment)1;
		((Control)Label18).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(335, 336);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(54, 20);
		((Control)Label18).TabIndex = 1247;
		Label18.Text = "HuId3";
		Label18.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId3).BackColor = Color.White;
		((Control)tHmId3).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId3).Location = new Point(391, 334);
		((TextBoxBase)tHmId3).MaxLength = 10;
		((Control)tHmId3).Name = "tHmId3";
		((Control)tHmId3).Size = new Size(65, 23);
		((Control)tHmId3).TabIndex = 11;
		((TextBoxBase)nHmWt2).BackColor = Color.Linen;
		((Control)nHmWt2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nHmWt2).Location = new Point(265, 334);
		((TextBoxBase)nHmWt2).MaxLength = 10;
		((Control)nHmWt2).Name = "nHmWt2";
		((Control)nHmWt2).Size = new Size(65, 23);
		((Control)nHmWt2).TabIndex = 10;
		nHmWt2.TextAlign = (HorizontalAlignment)1;
		((Control)Label19).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(141, 335);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(54, 20);
		((Control)Label19).TabIndex = 1246;
		Label19.Text = "HuId2";
		Label19.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tHmId2).BackColor = Color.White;
		((Control)tHmId2).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tHmId2).Location = new Point(198, 334);
		((TextBoxBase)tHmId2).MaxLength = 10;
		((Control)tHmId2).Name = "tHmId2";
		((Control)tHmId2).Size = new Size(65, 23);
		((Control)tHmId2).TabIndex = 9;
		((Control)pnlBill).BackColor = Color.FromArgb(255, 224, 192);
		pnlBill.BorderStyle = (BorderStyle)1;
		((Control)pnlBill).Controls.Add((Control)(object)btnBillDel);
		((Control)pnlBill).Controls.Add((Control)(object)btnBillSelect);
		((Control)pnlBill).Controls.Add((Control)(object)btnbillCap);
		((Control)pnlBill).Controls.Add((Control)(object)PicBill);
		((Control)pnlBill).Location = new Point(428, 326);
		((Control)pnlBill).Name = "pnlBill";
		((Control)pnlBill).Size = new Size(213, 242);
		((Control)pnlBill).TabIndex = 1249;
		((Control)pnlBill).Visible = false;
		btnBillDel.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnBillDel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnBillDel.ImageOptions.SvgImage");
		((Control)btnBillDel).Location = new Point(145, 198);
		((BaseControl)btnBillDel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnBillDel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillDel).Name = "btnBillDel";
		((Control)btnBillDel).Size = new Size(43, 32);
		((Control)btnBillDel).TabIndex = 1183;
		((BaseControl)btnBillDel).ToolTip = "Image Delete";
		btnBillSelect.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnBillSelect.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnBillSelect.ImageOptions.SvgImage");
		((Control)btnBillSelect).Location = new Point(84, 198);
		((BaseControl)btnBillSelect).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnBillSelect).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnBillSelect).Name = "btnBillSelect";
		((Control)btnBillSelect).Size = new Size(43, 32);
		((Control)btnBillSelect).TabIndex = 1182;
		((BaseControl)btnBillSelect).ToolTip = "Image Select";
		btnbillCap.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)btnbillCap.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnbillCap.ImageOptions.SvgImage");
		((Control)btnbillCap).Location = new Point(23, 198);
		((BaseControl)btnbillCap).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnbillCap).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnbillCap).Name = "btnbillCap";
		((Control)btnbillCap).Size = new Size(43, 32);
		((Control)btnbillCap).TabIndex = 1181;
		((BaseControl)btnbillCap).ToolTip = "Image Capture";
		((Control)PicBill).BackColor = SystemColors.ButtonHighlight;
		PicBill.BorderStyle = (BorderStyle)1;
		PicBill.ImeMode = (ImeMode)0;
		((Control)PicBill).Location = new Point(8, 8);
		((Control)PicBill).Name = "PicBill";
		((Control)PicBill).Size = new Size(195, 182);
		PicBill.SizeMode = (PictureBoxSizeMode)4;
		PicBill.TabIndex = 1139;
		PicBill.TabStop = false;
		((TextBoxBase)nCrDays).BackColor = Color.White;
		((Control)nCrDays).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nCrDays).Location = new Point(381, 501);
		((TextBoxBase)nCrDays).MaxLength = 3;
		((Control)nCrDays).Name = "nCrDays";
		((Control)nCrDays).Size = new Size(38, 23);
		((Control)nCrDays).TabIndex = 19;
		nCrDays.TextAlign = (HorizontalAlignment)2;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(326, 502);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(50, 20);
		((Control)Label22).TabIndex = 1251;
		Label22.Text = "CrDys";
		Label22.TextAlign = (ContentAlignment)64;
		((Control)PnlUpdate).BackColor = Color.FromArgb(255, 224, 192);
		PnlUpdate.BorderStyle = (BorderStyle)2;
		((Control)PnlUpdate).Controls.Add((Control)(object)picAc);
		((Control)PnlUpdate).Controls.Add((Control)(object)btnUpdate);
		((Control)PnlUpdate).Controls.Add((Control)(object)UMobile);
		((Control)PnlUpdate).Controls.Add((Control)(object)UGstNo);
		((Control)PnlUpdate).Controls.Add((Control)(object)UCity);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd3);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd2);
		((Control)PnlUpdate).Controls.Add((Control)(object)UAdd1);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label23);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label21);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label26);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label27);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label28);
		((Control)PnlUpdate).Controls.Add((Control)(object)Label29);
		((Control)PnlUpdate).Location = new Point(312, 96);
		((Control)PnlUpdate).Name = "PnlUpdate";
		((Control)PnlUpdate).Size = new Size(472, 220);
		((Control)PnlUpdate).TabIndex = 1252;
		((Control)PnlUpdate).Visible = false;
		((Control)picAc).BackColor = Color.SeaShell;
		picAc.BorderStyle = (BorderStyle)1;
		picAc.ImeMode = (ImeMode)0;
		((Control)picAc).Location = new Point(312, 62);
		((Control)picAc).Name = "picAc";
		((Control)picAc).Size = new Size(149, 149);
		picAc.SizeMode = (PictureBoxSizeMode)4;
		picAc.TabIndex = 1235;
		picAc.TabStop = false;
		((BaseStyleControl)btnUpdate).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnUpdate).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnUpdate).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnUpdate.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnUpdate).Location = new Point(199, 168);
		((BaseControl)btnUpdate).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnUpdate).Name = "btnUpdate";
		((Control)btnUpdate).Size = new Size(91, 37);
		((Control)btnUpdate).TabIndex = 1183;
		btnUpdate.Text = "&Update";
		((BaseButton)btnUpdate).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)UMobile).BackColor = Color.Transparent;
		((Control)UMobile).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UMobile).ForeColor = Color.Maroon;
		UMobile.ImeMode = (ImeMode)0;
		((Control)UMobile).Location = new Point(85, 133);
		((Control)UMobile).Name = "UMobile";
		((Control)UMobile).Size = new Size(220, 20);
		((Control)UMobile).TabIndex = 1180;
		UMobile.Text = ".";
		UMobile.TextAlign = (ContentAlignment)16;
		((Control)UGstNo).BackColor = Color.Transparent;
		((Control)UGstNo).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UGstNo).ForeColor = Color.Maroon;
		UGstNo.ImeMode = (ImeMode)0;
		((Control)UGstNo).Location = new Point(85, 109);
		((Control)UGstNo).Name = "UGstNo";
		((Control)UGstNo).Size = new Size(220, 20);
		((Control)UGstNo).TabIndex = 1179;
		UGstNo.Text = ".";
		UGstNo.TextAlign = (ContentAlignment)16;
		((Control)UCity).BackColor = Color.Transparent;
		((Control)UCity).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UCity).ForeColor = Color.Maroon;
		UCity.ImeMode = (ImeMode)0;
		((Control)UCity).Location = new Point(85, 85);
		((Control)UCity).Name = "UCity";
		((Control)UCity).Size = new Size(220, 20);
		((Control)UCity).TabIndex = 1177;
		UCity.Text = ".";
		UCity.TextAlign = (ContentAlignment)16;
		((Control)UAdd3).BackColor = Color.Transparent;
		((Control)UAdd3).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd3).ForeColor = Color.Maroon;
		UAdd3.ImeMode = (ImeMode)0;
		((Control)UAdd3).Location = new Point(85, 60);
		((Control)UAdd3).Name = "UAdd3";
		((Control)UAdd3).Size = new Size(220, 20);
		((Control)UAdd3).TabIndex = 1176;
		UAdd3.Text = ".";
		UAdd3.TextAlign = (ContentAlignment)16;
		((Control)UAdd2).BackColor = Color.Transparent;
		((Control)UAdd2).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd2).ForeColor = Color.Maroon;
		UAdd2.ImeMode = (ImeMode)0;
		((Control)UAdd2).Location = new Point(85, 35);
		((Control)UAdd2).Name = "UAdd2";
		((Control)UAdd2).Size = new Size(374, 20);
		((Control)UAdd2).TabIndex = 1175;
		UAdd2.Text = ".";
		UAdd2.TextAlign = (ContentAlignment)16;
		((Control)UAdd1).BackColor = Color.Transparent;
		((Control)UAdd1).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)UAdd1).ForeColor = Color.Maroon;
		UAdd1.ImeMode = (ImeMode)0;
		((Control)UAdd1).Location = new Point(85, 10);
		((Control)UAdd1).Name = "UAdd1";
		((Control)UAdd1).Size = new Size(374, 20);
		((Control)UAdd1).TabIndex = 1174;
		UAdd1.Text = ".";
		UAdd1.TextAlign = (ContentAlignment)16;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Maroon;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(21, 111);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(59, 20);
		((Control)Label23).TabIndex = 1171;
		Label23.Text = "Gst No  :";
		Label23.TextAlign = (ContentAlignment)64;
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Maroon;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(7, 134);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(73, 20);
		((Control)Label21).TabIndex = 1169;
		Label21.Text = "Mobile  :";
		Label21.TextAlign = (ContentAlignment)64;
		((Control)Label26).BackColor = Color.Transparent;
		((Control)Label26).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label26).ForeColor = Color.Maroon;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(21, 85);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(59, 20);
		((Control)Label26).TabIndex = 1166;
		Label26.Text = "City  :";
		Label26.TextAlign = (ContentAlignment)64;
		((Control)Label27).BackColor = Color.Transparent;
		((Control)Label27).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label27).ForeColor = Color.Maroon;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(21, 60);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(59, 20);
		((Control)Label27).TabIndex = 1163;
		Label27.Text = "Add 3  :";
		Label27.TextAlign = (ContentAlignment)64;
		((Control)Label28).BackColor = Color.Transparent;
		((Control)Label28).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Maroon;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(21, 35);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(59, 20);
		((Control)Label28).TabIndex = 1162;
		Label28.Text = "Add 2  :";
		Label28.TextAlign = (ContentAlignment)64;
		((Control)Label29).BackColor = Color.Transparent;
		((Control)Label29).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Maroon;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(21, 10);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(59, 20);
		((Control)Label29).TabIndex = 1158;
		Label29.Text = "Add 1  :";
		Label29.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)btnQuot).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnQuot).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnQuot).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnQuot).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnQuot).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnQuot).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnQuot).Appearance.Options.UseForeColor = true;
		((BaseButton)btnQuot).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnQuot).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnQuot).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnQuot).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnQuot).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnQuot).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnQuot).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnQuot).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnQuot).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnQuot).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnQuot).AppearancePressed.Options.UseFont = true;
		((Control)btnQuot).Location = new Point(187, 66);
		((BaseControl)btnQuot).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnQuot).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnQuot).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnQuot).Name = "btnQuot";
		((Control)btnQuot).Size = new Size(33, 23);
		((Control)btnQuot).TabIndex = 1253;
		btnQuot.Text = "Q";
		((BaseControl)btnQuot).ToolTip = "Sales Quotation";
		((Control)btnQuot).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnQuot);
		((Control)this).Controls.Add((Control)(object)PnlUpdate);
		((Control)this).Controls.Add((Control)(object)pnlBill);
		((Control)this).Controls.Add((Control)(object)nCrDays);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)lblItem);
		((Control)this).Controls.Add((Control)(object)nHmWt4);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)tHmId4);
		((Control)this).Controls.Add((Control)(object)nHmWt3);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)tHmId3);
		((Control)this).Controls.Add((Control)(object)nHmWt2);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)tHmId2);
		((Control)this).Controls.Add((Control)(object)nHmWt);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)PnlPrIdtl);
		((Control)this).Controls.Add((Control)(object)lblOldFine);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nPartyFine);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)tSlBill_DbCd);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tSlBill);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)MSG_PR_TOT);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
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
		((Control)this).Name = "TR_PURC";
		((Form)this).Text = "Purchase";
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
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_PR_TOT).EndInit();
		((Control)PnlPrIdtl).ResumeLayout(false);
		((Control)PnlPrIdtl).PerformLayout();
		((ISupportInitialize)MSG_PR_IDTL).EndInit();
		((Control)pnlBill).ResumeLayout(false);
		((ISupportInitialize)PicBill).EndInit();
		((Control)PnlUpdate).ResumeLayout(false);
		((ISupportInitialize)picAc).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_PR_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL.Clear();
		mSG_PR_IDTL.Cols = 25;
		mSG_PR_IDTL.FixedRows = 1;
		mSG_PR_IDTL.Rows = 2;
		mSG_PR_IDTL.Row = 0;
		mSG_PR_IDTL[0] = 0;
		mSG_PR_IDTL[1] = 0;
		mSG_PR_IDTL.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_PR_IDTL[0] = (int)Math.Round(500.0 * ColCon);
			mSG_PR_IDTL[0] = 3;
			mSG_PR_IDTL[0, 0] = "Sr";
			mSG_PR_IDTL[1] = (int)Math.Round(850.0 * ColCon);
			mSG_PR_IDTL[1] = 0;
			mSG_PR_IDTL[0, 1] = "ItCode";
			mSG_PR_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
			mSG_PR_IDTL[2] = 0;
			mSG_PR_IDTL[0, 2] = "ItName";
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
			{
				mSG_PR_IDTL[3] = (int)Math.Round(875.0 * ColCon);
				mSG_PR_IDTL[3] = 0;
				mSG_PR_IDTL[0, 3] = "DmCode";
				mSG_PR_IDTL[4] = (int)Math.Round(1700.0 * ColCon);
				mSG_PR_IDTL[4] = 0;
				mSG_PR_IDTL[0, 4] = "DmName";
				mSG_PR_IDTL[5] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[5] = 0;
				mSG_PR_IDTL[0, 5] = "DmColor";
				mSG_PR_IDTL[6] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[6] = 3;
				mSG_PR_IDTL[0, 6] = "DmSize";
				mSG_PR_IDTL[7] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[7] = 0;
				mSG_PR_IDTL[0, 7] = "DmOrigin";
				mSG_PR_IDTL[8] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[8] = 0;
				mSG_PR_IDTL[0, 8] = "DmRemark";
				mSG_PR_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[9] = 0;
				mSG_PR_IDTL[0, 9] = "DmSfNo";
			}
			else
			{
				mSG_PR_IDTL[3] = 0;
				mSG_PR_IDTL[0, 3] = "DmCode";
				mSG_PR_IDTL[4] = 0;
				mSG_PR_IDTL[0, 4] = "DmName";
				mSG_PR_IDTL[5] = 0;
				mSG_PR_IDTL[0, 5] = "DmColor";
				mSG_PR_IDTL[6] = 0;
				mSG_PR_IDTL[0, 6] = "DmSize";
				mSG_PR_IDTL[7] = 0;
				mSG_PR_IDTL[0, 7] = "DmOrigin";
				mSG_PR_IDTL[8] = 0;
				mSG_PR_IDTL[0, 8] = "DmRemark";
				mSG_PR_IDTL[9] = (int)Math.Round(1500.0 * ColCon);
				mSG_PR_IDTL[9] = 0;
				mSG_PR_IDTL[0, 9] = "DmSfNo";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_PR_IDTL[10] = (int)Math.Round(750.0 * ColCon);
				mSG_PR_IDTL[10] = 7;
				mSG_PR_IDTL[0, 10] = "MotiPs";
				mSG_PR_IDTL[11] = (int)Math.Round(750.0 * ColCon);
				mSG_PR_IDTL[11] = 7;
				mSG_PR_IDTL[0, 11] = "MotiWt";
			}
			else
			{
				mSG_PR_IDTL[10] = 0;
				mSG_PR_IDTL[0, 10] = "MotiPs";
				mSG_PR_IDTL[11] = 0;
				mSG_PR_IDTL[0, 11] = "MotiWt";
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_PR_IDTL[13] = (int)Math.Round(900.0 * ColCon);
				mSG_PR_IDTL[13] = 7;
				mSG_PR_IDTL[0, 13] = "PcsWt";
			}
			else
			{
				mSG_PR_IDTL[13] = (int)Math.Round(750.0 * ColCon);
				mSG_PR_IDTL[13] = 7;
				mSG_PR_IDTL[0, 13] = "PcsWt";
			}
			mSG_PR_IDTL[12] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[12] = 7;
			mSG_PR_IDTL[0, 12] = "Pcs";
			mSG_PR_IDTL[14] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR_IDTL[14] = 7;
			mSG_PR_IDTL[0, 14] = "Weight";
			mSG_PR_IDTL[15] = (int)Math.Round(750.0 * ColCon);
			mSG_PR_IDTL[15] = 7;
			mSG_PR_IDTL[0, 15] = "Con%";
			mSG_PR_IDTL[16] = (int)Math.Round(650.0 * ColCon);
			mSG_PR_IDTL[16] = 3;
			mSG_PR_IDTL[0, 16] = "P/W";
			mSG_PR_IDTL[17] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[17] = 7;
			mSG_PR_IDTL[0, 17] = "Rate";
			mSG_PR_IDTL[18] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[18] = 7;
			mSG_PR_IDTL[0, 18] = "ItAmt";
			mSG_PR_IDTL[19] = (int)Math.Round(850.0 * ColCon);
			mSG_PR_IDTL[19] = 7;
			mSG_PR_IDTL[0, 19] = "LbrRate";
			mSG_PR_IDTL[20] = (int)Math.Round(900.0 * ColCon);
			mSG_PR_IDTL[20] = 7;
			mSG_PR_IDTL[0, 20] = "LbrAmt";
			mSG_PR_IDTL[21] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR_IDTL[21] = 7;
			mSG_PR_IDTL[0, 21] = "NetAmt";
			mSG_PR_IDTL[22] = 0;
			mSG_PR_IDTL[0, 22] = "ConWt";
			mSG_PR_IDTL[23] = 0;
			mSG_PR_IDTL[0, 23] = "ItType";
			mSG_PR_IDTL[24] = 0;
			mSG_PR_IDTL[0, 24] = "RowSrNo";
			mSG_PR_IDTL.Row = 1;
			mSG_PR_IDTL.Col = 0;
			((Control)TEXT_PR_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			if (dataView.Count > 0)
			{
				int num = mSG_PR_IDTL.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_PR_IDTL[0, DC_Main.M] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_PR_IDTL[DC_Main.M] = 0;
						}
						mSG_PR_IDTL[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
					DC_Main.M++;
				}
			}
			mSG_PR_IDTL[0] = (int)Math.Round(325.0 * ColCon);
			mSG_PR_IDTL[1] = (int)Math.Round(300.0 * ColCon);
			mSG_PR_IDTL.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd_Pr_Idtl();
			mSG_PR_IDTL = null;
		}
	}

	private void CommPassAdd_Pr_Idtl()
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 0] = Conversions.ToString(mSG_PR_IDTL.Row);
		mSG_PR_IDTL[mSG_PR_IDTL.Row, 24] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 57]));
		mSG_PR_IDTL = null;
	}

	private void TEXT_PR_IDTL_TextChanged(object sender, EventArgs e)
	{
	}

	private void TEXT_PR_IDTL_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bc: Invalid comparison between Unknown and I4
		//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f1: Invalid comparison between Unknown and I4
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Invalid comparison between Unknown and I4
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Invalid comparison between Unknown and I4
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Invalid comparison between Unknown and I4
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_0283: Invalid comparison between Unknown and I4
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
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
					int num = DtIdtlPr.Rows.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 24])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 0])))
						{
							DtIdtlPr.Rows.Remove(DtIdtlPr.Rows[i]);
							break;
						}
					}
					int num2 = mSG_PR_IDTL.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_PR_IDTL[mSG_PR_IDTL.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					CommPassTotal_Pr_Idtl(1);
					TEXT_PR_IDTL.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG_PR_IDTL.Col > 1)
				{
					MsgIdtlLeft = true;
					mSG_PR_IDTL.Col = checked(mSG_PR_IDTL.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG_PR_IDTL.Col < 21)
				{
					mSG_PR_IDTL.Col = checked(mSG_PR_IDTL.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG_PR_IDTL.Row > 1)
				{
					mSG_PR_IDTL.Row = checked(mSG_PR_IDTL.Row - 1);
				}
				return;
			}
			if ((int)keyCode == 40)
			{
				checked
				{
					if (mSG_PR_IDTL.Row < mSG_PR_IDTL.Rows - 1)
					{
						mSG_PR_IDTL.Row += 1;
					}
					return;
				}
			}
			if ((int)keyCode == 13)
			{
				checked
				{
					switch (mSG_PR_IDTL.Col)
					{
					case 1:
						if (Operators.CompareString(TEXT_PR_IDTL.Text, "", false) == 0)
						{
							((Control)TEXT_PR_IDTL).Visible = false;
							MSG_PR.Col += 1;
							MSG_PR_EnterCell(MSG_PR, new EventArgs());
							((Control)TEXT_PR).Visible = true;
							((Control)TEXT_PR).Focus();
							return;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR_IDTL.Text + "'";
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
									TEXT_PR_IDTL.Text = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 1] = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 2] = DC_Main.ColValue[0];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 23] = DC_Main.ColValue[4];
								}
								((Control)TEXT_PR_IDTL).Focus();
							}
							return;
						}
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 23] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 17]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 15]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						break;
					case 3:
					{
						if (Operators.CompareString(TEXT_PR_IDTL.Text, "", false) == 0 || mSG_PR_IDTL[3] == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From DM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND DM_CODE = '" + TEXT_PR_IDTL.Text + "'";
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
									TEXT_PR_IDTL.Text = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 3] = DC_Main.ColValue[1];
									mSG_PR_IDTL[mSG_PR_IDTL.Row, 4] = DC_Main.ColValue[0];
								}
								((Control)TEXT_PR_IDTL).Focus();
							}
							return;
						}
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_CODE"], (object)""));
						mSG_PR_IDTL[mSG_PR_IDTL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["DM_NAME"], (object)""));
						if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 17]) == 0.0)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					}
					case 13:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 12]) != 0.0) & (Conversion.Val(TEXT_PR_IDTL.Text) != 0.0))
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 12]) * Conversion.Val(TEXT_PR_IDTL.Text)), "0.000");
						}
						break;
					case 14:
						if ((Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 12]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 14]) == 0.0))
						{
							if (Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, 21]) == 0.0)
							{
								mSG_PR_IDTL[mSG_PR_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 17] = "";
						}
						break;
					case 21:
						if (mSG_PR_IDTL.Row == mSG_PR_IDTL.Rows - 1)
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
							CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
							MsgClearIdtlPr = true;
							mSG_PR_IDTL.Rows += 1;
							mSG_PR_IDTL.Row += 1;
							MsgClearIdtlPr = false;
							mSG_PR_IDTL.Col = 1;
							CommPassAdd_Pr_Idtl();
						}
						else
						{
							mSG_PR_IDTL[mSG_PR_IDTL.Row, 21] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
							CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
							((Control)TEXT_PR_IDTL).Visible = false;
							mSG_PR_IDTL.Row += 1;
							mSG_PR_IDTL.Col = 1;
							((Control)TEXT_PR_IDTL).Visible = true;
							((Control)TEXT_PR_IDTL).Focus();
						}
						return;
					}
					if (mSG_PR_IDTL.Col < mSG_PR_IDTL.Cols - 1)
					{
						mSG_PR_IDTL.Col += 1;
					}
					((Control)TEXT_PR_IDTL).Visible = true;
					((Control)TEXT_PR_IDTL).Focus();
				}
			}
		}
		mSG_PR_IDTL = null;
	}

	private void MSG_PR_IDTL_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		checked
		{
			if (mSG_PR_IDTL.CellWidth >= 0)
			{
				((Control)TEXT_PR_IDTL).Left = (int)Math.Round((double)((Control)mSG_PR_IDTL).Left + (double)mSG_PR_IDTL.CellLeft / 15.0);
				((Control)TEXT_PR_IDTL).Top = (int)Math.Round((double)((Control)mSG_PR_IDTL).Top + (double)mSG_PR_IDTL.CellTop / 15.0);
				((Control)TEXT_PR_IDTL).Width = (int)Math.Round((double)mSG_PR_IDTL.CellWidth / 15.0);
				((Control)TEXT_PR_IDTL).Height = (int)Math.Round((double)mSG_PR_IDTL.CellHeight / 15.0);
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				((Control)TEXT_PR_IDTL).Visible = true;
				((Control)TEXT_ENTRY).Visible = false;
				((TextBoxBase)TEXT_PR_IDTL).SelectAll();
				((Control)TEXT_PR_IDTL).Focus();
				mSG_PR_IDTL = null;
			}
		}
	}

	private void MSG_PR_IDTL_EnterCell(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		checked
		{
			if (mSG_PR_IDTL[mSG_PR_IDTL.Col] == 0)
			{
				TEXT_PR_IDTL.Text = "";
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = "";
				DC_Main.M = 1;
				while (mSG_PR_IDTL[mSG_PR_IDTL.Col] == 0)
				{
					if (MsgIdtlLeft)
					{
						if (mSG_PR_IDTL.Col > 1)
						{
							mSG_PR_IDTL.Col -= 1;
						}
					}
					else if (mSG_PR_IDTL.Col < mSG_PR_IDTL.Cols - 1)
					{
						mSG_PR_IDTL.Col += 1;
					}
					DC_Main.M++;
					if (DC_Main.M > 10)
					{
						break;
					}
				}
			}
			if (((mSG_PR_IDTL.Row == 0) | (mSG_PR_IDTL.CellWidth <= 0)) || mSG_PR_IDTL[mSG_PR_IDTL.Col] == 0)
			{
				return;
			}
			((Control)TEXT_PR_IDTL).Left = (int)Math.Round((double)((Control)mSG_PR_IDTL).Left + (double)mSG_PR_IDTL.CellLeft / 15.0);
			((Control)TEXT_PR_IDTL).Top = (int)Math.Round((double)((Control)mSG_PR_IDTL).Top + (double)mSG_PR_IDTL.CellTop / 15.0);
			((Control)TEXT_PR_IDTL).Width = (int)Math.Round((double)mSG_PR_IDTL.CellWidth / 15.0);
			((Control)TEXT_PR_IDTL).Height = (int)Math.Round((double)mSG_PR_IDTL.CellHeight / 15.0);
			((Control)TEXT_PR_IDTL).Visible = true;
			((TextBoxBase)TEXT_PR_IDTL).ReadOnly = false;
			switch (MSG_PR_IDTL.Col)
			{
			case 0:
			case 1:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 5;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 8;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 2:
			case 4:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 50;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 15;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 6:
			case 7:
			case 8:
			case 9:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 20;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 16:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 1;
				TEXT_PR_IDTL.Text = mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col];
				break;
			case 10:
			case 12:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 6;
				TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0");
				break;
			case 15:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
				TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000");
				break;
			case 17:
			case 18:
			case 19:
			case 20:
			case 21:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
				TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.00");
				break;
			case 11:
			case 14:
			case 22:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
				TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000");
				break;
			case 13:
				((TextBoxBase)TEXT_PR_IDTL).MaxLength = 10;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
				{
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.000000");
				}
				else
				{
					TEXT_PR_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col]), "0.0000");
				}
				break;
			}
			mSG_PR_IDTL = null;
			((TextBoxBase)TEXT_PR_IDTL).SelectAll();
		}
	}

	private void MSG_PR_IDTL_LeaveCell(object sender, EventArgs e)
	{
		if (MsgClearIdtlPr || MSG_PR_IDTL.Row == 0 || MSG_PR_IDTL[MSG_PR_IDTL.Col] == 0 || !((Control)TEXT_PR_IDTL).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		switch (MSG_PR_IDTL.Col)
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
		case 16:
			mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = TEXT_PR_IDTL.Text;
			break;
		case 10:
		case 12:
			mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0");
			CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
			break;
		case 15:
			mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000");
			CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
			break;
		case 17:
		case 18:
		case 19:
		case 20:
		case 21:
			mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.00");
			CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
			break;
		case 11:
		case 14:
		case 22:
			mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000");
			CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
			break;
		case 13:
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.000000");
			}
			else
			{
				mSG_PR_IDTL[mSG_PR_IDTL.Row, mSG_PR_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_PR_IDTL.Text), "0.0000");
			}
			CommPassTotal_Pr_Idtl(mSG_PR_IDTL.Row);
			break;
		}
		mSG_PR_IDTL = null;
	}

	private void CommPassTotal_Pr_Idtl(int XRow)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 10]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 11]) != 0.0))
		{
			if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 11]) / Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.000000");
			}
			else
			{
				mSG_PR_IDTL[XRow, 13] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 11]) / Conversion.Val(mSG_PR_IDTL[XRow, 10])), "0.0000");
			}
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 13]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 14] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 12]) * Conversion.Val(mSG_PR_IDTL[XRow, 13])), "0.000");
		}
		if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 15]) != 0.0))
		{
			mSG_PR_IDTL[XRow, 22] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 14]) * Conversion.Val(mSG_PR_IDTL[XRow, 15])), "0.000");
		}
		else
		{
			mSG_PR_IDTL[XRow, 22] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_PR_IDTL[XRow, 16], "", false) == 0)
		{
			if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) == 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 12]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 12])), "0.00");
			}
			else if ((Conversion.Val(mSG_PR_IDTL[XRow, 14]) != 0.0) & (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0))
			{
				mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 14])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_PR_IDTL[XRow, 16], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_PR_IDTL[XRow, 17])))) != 0)
		{
			mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 12])), "0.00");
		}
		else if (Conversion.Val(mSG_PR_IDTL[XRow, 17]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 18] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 17]) * Conversion.Val(mSG_PR_IDTL[XRow, 14])), "0.00");
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 19]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 20] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 19]) * Conversion.Val(mSG_PR_IDTL[XRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_PR_IDTL[XRow, 18]) + Conversion.Val(mSG_PR_IDTL[XRow, 20]) != 0.0)
		{
			mSG_PR_IDTL[XRow, 21] = Strings.Format((object)(Conversion.Val(mSG_PR_IDTL[XRow, 18]) + Conversion.Val(mSG_PR_IDTL[XRow, 20])), "0.00");
		}
		checked
		{
			int num5 = mSG_PR_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 22]);
				num += Conversion.Val(mSG_PR_IDTL[DC_Main.M, 21]);
				DC_Main.M++;
			}
			if (num != 0.0)
			{
				MSG_PR[MSG_PR.Row, 36] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 13] = Strings.Format((object)num3, "0.000");
			}
			if (num3 != 0.0)
			{
				MSG_PR[MSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(MSG_PR[MSG_PR.Row, 12]) - num3), "0.000");
			}
			if (Operators.CompareString(mSG_PR_IDTL[XRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtlPr.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24])) == Conversion.Val(mSG_PR_IDTL[XRow, 24])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0])) == Conversion.Val(mSG_PR_IDTL[XRow, 0])))
					{
						flag = true;
						DtIdtlPr.Rows[i][0] = mSG_PR_IDTL[XRow, 0];
						DtIdtlPr.Rows[i][1] = mSG_PR_IDTL[XRow, 1];
						DtIdtlPr.Rows[i][2] = mSG_PR_IDTL[XRow, 2];
						DtIdtlPr.Rows[i][3] = mSG_PR_IDTL[XRow, 3];
						DtIdtlPr.Rows[i][4] = mSG_PR_IDTL[XRow, 4];
						DtIdtlPr.Rows[i][5] = mSG_PR_IDTL[XRow, 5];
						DtIdtlPr.Rows[i][6] = mSG_PR_IDTL[XRow, 6];
						DtIdtlPr.Rows[i][7] = mSG_PR_IDTL[XRow, 7];
						DtIdtlPr.Rows[i][8] = mSG_PR_IDTL[XRow, 8];
						DtIdtlPr.Rows[i][9] = mSG_PR_IDTL[XRow, 9];
						DtIdtlPr.Rows[i][10] = mSG_PR_IDTL[XRow, 10];
						DtIdtlPr.Rows[i][11] = mSG_PR_IDTL[XRow, 11];
						DtIdtlPr.Rows[i][12] = mSG_PR_IDTL[XRow, 12];
						DtIdtlPr.Rows[i][13] = mSG_PR_IDTL[XRow, 13];
						DtIdtlPr.Rows[i][14] = mSG_PR_IDTL[XRow, 14];
						DtIdtlPr.Rows[i][15] = mSG_PR_IDTL[XRow, 15];
						DtIdtlPr.Rows[i][16] = mSG_PR_IDTL[XRow, 16];
						DtIdtlPr.Rows[i][17] = mSG_PR_IDTL[XRow, 17];
						DtIdtlPr.Rows[i][18] = mSG_PR_IDTL[XRow, 18];
						DtIdtlPr.Rows[i][19] = mSG_PR_IDTL[XRow, 19];
						DtIdtlPr.Rows[i][20] = mSG_PR_IDTL[XRow, 20];
						DtIdtlPr.Rows[i][21] = mSG_PR_IDTL[XRow, 21];
						DtIdtlPr.Rows[i][22] = mSG_PR_IDTL[XRow, 22];
						DtIdtlPr.Rows[i][23] = mSG_PR_IDTL[XRow, 23];
						DtIdtlPr.Rows[i][24] = mSG_PR_IDTL[XRow, 24];
						break;
					}
				}
				if (!flag)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[0] = mSG_PR_IDTL[XRow, 0];
					drPr[1] = mSG_PR_IDTL[XRow, 1];
					drPr[2] = mSG_PR_IDTL[XRow, 2];
					drPr[3] = mSG_PR_IDTL[XRow, 3];
					drPr[4] = mSG_PR_IDTL[XRow, 4];
					drPr[5] = mSG_PR_IDTL[XRow, 5];
					drPr[6] = mSG_PR_IDTL[XRow, 6];
					drPr[7] = mSG_PR_IDTL[XRow, 7];
					drPr[8] = mSG_PR_IDTL[XRow, 8];
					drPr[9] = mSG_PR_IDTL[XRow, 9];
					drPr[10] = mSG_PR_IDTL[XRow, 10];
					drPr[11] = mSG_PR_IDTL[XRow, 11];
					drPr[12] = mSG_PR_IDTL[XRow, 12];
					drPr[13] = mSG_PR_IDTL[XRow, 13];
					drPr[14] = mSG_PR_IDTL[XRow, 14];
					drPr[15] = mSG_PR_IDTL[XRow, 15];
					drPr[16] = mSG_PR_IDTL[XRow, 16];
					drPr[17] = mSG_PR_IDTL[XRow, 17];
					drPr[18] = mSG_PR_IDTL[XRow, 18];
					drPr[19] = mSG_PR_IDTL[XRow, 19];
					drPr[20] = mSG_PR_IDTL[XRow, 20];
					drPr[21] = mSG_PR_IDTL[XRow, 21];
					drPr[22] = mSG_PR_IDTL[XRow, 22];
					drPr[23] = mSG_PR_IDTL[XRow, 23];
					drPr[24] = mSG_PR_IDTL[XRow, 24];
					DtIdtlPr.Rows.Add(drPr);
				}
			}
			mSG_PR_IDTL = null;
		}
	}

	private void MSG_PR_RowColChange(object sender, EventArgs e)
	{
		if (MsgClear || MSG_PR.Row == 0 || !((MsgOldRowPr != MSG_PR.Row) & !MsgClearPr))
		{
			return;
		}
		MsgOldRowPr = MSG_PR.Row;
		MSG_PR_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtlPr.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG_PR[MSG_PR.Row, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24])))
				{
					MSG_PR_IDTL[num, 0] = Conversions.ToString(num);
					MSG_PR_IDTL[num, 1] = Conversions.ToString(DtIdtlPr.Rows[i][1]);
					MSG_PR_IDTL[num, 2] = Conversions.ToString(DtIdtlPr.Rows[i][2]);
					MSG_PR_IDTL[num, 3] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][3], (object)""));
					MSG_PR_IDTL[num, 4] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][4], (object)""));
					MSG_PR_IDTL[num, 5] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][5], (object)""));
					MSG_PR_IDTL[num, 6] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][6], (object)""));
					MSG_PR_IDTL[num, 7] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][7], (object)""));
					MSG_PR_IDTL[num, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][8], (object)""));
					MSG_PR_IDTL[num, 9] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][9], (object)""));
					MSG_PR_IDTL[num, 10] = Conversions.ToString(DtIdtlPr.Rows[i][10]);
					MSG_PR_IDTL[num, 11] = Conversions.ToString(DtIdtlPr.Rows[i][11]);
					MSG_PR_IDTL[num, 12] = Conversions.ToString(DtIdtlPr.Rows[i][12]);
					MSG_PR_IDTL[num, 13] = Conversions.ToString(DtIdtlPr.Rows[i][13]);
					MSG_PR_IDTL[num, 14] = Conversions.ToString(DtIdtlPr.Rows[i][14]);
					MSG_PR_IDTL[num, 15] = Conversions.ToString(Operators.ConcatenateObject(DtIdtlPr.Rows[i][15], (object)""));
					MSG_PR_IDTL[num, 16] = Conversions.ToString(DtIdtlPr.Rows[i][16]);
					MSG_PR_IDTL[num, 17] = Conversions.ToString(DtIdtlPr.Rows[i][17]);
					MSG_PR_IDTL[num, 18] = Conversions.ToString(DtIdtlPr.Rows[i][18]);
					MSG_PR_IDTL[num, 19] = Conversions.ToString(DtIdtlPr.Rows[i][19]);
					MSG_PR_IDTL[num, 20] = Conversions.ToString(DtIdtlPr.Rows[i][20]);
					MSG_PR_IDTL[num, 21] = Conversions.ToString(DtIdtlPr.Rows[i][21]);
					MSG_PR_IDTL[num, 22] = Conversions.ToString(DtIdtlPr.Rows[i][22]);
					MSG_PR_IDTL[num, 23] = Conversions.ToString(DtIdtlPr.Rows[i][23]);
					MSG_PR_IDTL[num, 24] = Conversions.ToString(DtIdtlPr.Rows[i][24]);
					MSG_PR_IDTL.Rows += 1;
					num++;
				}
			}
			MSG_PR_IDTL[num, 0] = Conversions.ToString(num);
			MSG_PR_IDTL[num, 24] = Conversions.ToString(Conversion.Val(MSG_PR[MSG_PR.Row, 57]));
		}
	}

	private void MSG_PR_CLEAR()
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		mSG_PR.Clear();
		mSG_PR.Cols = 70;
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
			mSG_PR[0, 1] = "ItCode";
			mSG_PR[2] = (int)Math.Round(2300.0 * ColCon);
			mSG_PR[2] = 0;
			mSG_PR[0, 2] = "ItName";
			mSG_PR[3] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[3] = 0;
			mSG_PR[0, 3] = "Counter";
			mSG_PR[4] = (int)Math.Round(1300.0 * ColCon);
			mSG_PR[4] = 0;
			mSG_PR[0, 4] = "Design";
			if (Operators.CompareString(DC_Main.MsPurcLot, "Y", false) == 0)
			{
				mSG_PR[5] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[5] = 0;
				mSG_PR[0, 5] = "LotNo";
			}
			else
			{
				mSG_PR[5] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[5] = 0;
				mSG_PR[0, 5] = "LotNo";
			}
			if (Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0)
			{
				mSG_PR[6] = (int)Math.Round(1200.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "ItmLot";
			}
			else
			{
				mSG_PR[6] = (int)Math.Round(0.0 * ColCon);
				mSG_PR[6] = 0;
				mSG_PR[0, 6] = "ItmLot";
			}
			mSG_PR[7] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[7] = 3;
			mSG_PR[0, 7] = "WthStk";
			mSG_PR[8] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[8] = 7;
			mSG_PR[0, 8] = "BagWt";
			mSG_PR[9] = (int)Math.Round(700.0 * ColCon);
			mSG_PR[9] = 7;
			mSG_PR[0, 9] = "Pcs";
			mSG_PR[10] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[10] = 7;
			mSG_PR[0, 10] = "BagTot";
			mSG_PR[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[11] = 7;
			mSG_PR[0, 11] = "PsWt";
			mSG_PR[12] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[12] = 7;
			mSG_PR[0, 12] = "GrWt";
			mSG_PR[13] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[13] = 7;
			mSG_PR[0, 13] = "OthWt";
			mSG_PR[15] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[15] = 7;
			mSG_PR[0, 15] = "Kundan";
			mSG_PR[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[16] = 7;
			mSG_PR[0, 16] = "KunTch";
			mSG_PR[17] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[17] = 7;
			mSG_PR[0, 17] = "KunFine";
			mSG_PR[18] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[18] = 7;
			mSG_PR[0, 18] = "NetWt";
			mSG_PR[19] = (int)Math.Round(800.0 * ColCon);
			mSG_PR[19] = 7;
			mSG_PR[0, 19] = "Ght%";
			mSG_PR[20] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[20] = 7;
			mSG_PR[0, 20] = "GhtWt";
			mSG_PR[21] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[21] = 3;
			mSG_PR[0, 21] = "Touch";
			mSG_PR[22] = (int)Math.Round(750.0 * ColCon);
			mSG_PR[22] = 3;
			mSG_PR[0, 22] = "West%";
			mSG_PR[24] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[24] = 7;
			mSG_PR[0, 24] = "Fine";
			mSG_PR[25] = (int)Math.Round(1100.0 * ColCon);
			mSG_PR[25] = 7;
			mSG_PR[0, 25] = "NetFine";
			mSG_PR[53] = (int)Math.Round(0.0 * ColCon);
			mSG_PR[53] = 7;
			mSG_PR[0, 53] = "HmFine";
			mSG_PR[26] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[26] = 7;
			mSG_PR[0, 26] = "SlvFine";
			mSG_PR[27] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[27] = 7;
			mSG_PR[0, 27] = "ConRate";
			mSG_PR[28] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[28] = 7;
			mSG_PR[0, 28] = "Con%";
			mSG_PR[29] = (int)Math.Round(1000.0 * ColCon);
			mSG_PR[29] = 7;
			mSG_PR[0, 29] = "Rate";
			if ((Operators.CompareString(DC_Main.MCo_Book, "037", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "038", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "043", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "044", false) == 0))
			{
				mSG_PR[30] = (int)Math.Round(800.0 * ColCon);
				mSG_PR[30] = 3;
				mSG_PR[0, 30] = "RTyp";
			}
			else
			{
				mSG_PR[30] = 0;
				mSG_PR[30] = 7;
				mSG_PR[0, 30] = "RTyp";
			}
			mSG_PR[31] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[31] = 7;
			mSG_PR[0, 31] = "ItAmt";
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				mSG_PR[32] = 0;
				mSG_PR[33] = 0;
				mSG_PR[34] = 0;
				mSG_PR[35] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[35] = 7;
				mSG_PR[0, 35] = "LAmt";
				mSG_PR[36] = 0;
				mSG_PR[37] = 0;
				mSG_PR[38] = 0;
				mSG_PR[39] = 0;
				mSG_PR[41] = 0;
				mSG_PR[42] = 0;
				mSG_PR[5] = 0;
				mSG_PR[6] = 0;
				mSG_PR[7] = 0;
				mSG_PR[23] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[23] = 7;
				mSG_PR[0, 23] = "LesTch%";
				mSG_PR[14] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[14] = 7;
				mSG_PR[0, 14] = "LossWt";
				mSG_PR[15] = 0;
				mSG_PR[16] = 0;
				mSG_PR[17] = 0;
			}
			else
			{
				mSG_PR[32] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[32] = 7;
				mSG_PR[0, 32] = "Lbr%";
				mSG_PR[33] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[33] = 3;
				mSG_PR[0, 33] = "Ltype";
				mSG_PR[34] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[34] = 7;
				mSG_PR[0, 34] = "LRate";
				mSG_PR[35] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[35] = 7;
				mSG_PR[0, 35] = "LAmt";
				mSG_PR[36] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[36] = 7;
				mSG_PR[0, 36] = "OthAmt";
				mSG_PR[37] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[37] = 3;
				mSG_PR[0, 37] = "ORate";
				mSG_PR[38] = (int)Math.Round(1000.0 * ColCon);
				mSG_PR[38] = 7;
				mSG_PR[0, 38] = "OFine";
				mSG_PR[39] = (int)Math.Round(1100.0 * ColCon);
				mSG_PR[39] = 7;
				mSG_PR[0, 39] = "Mrp";
				mSG_PR[41] = (int)Math.Round(800.0 * ColCon);
				mSG_PR[41] = 7;
				mSG_PR[0, 41] = "Com%";
				mSG_PR[42] = (int)Math.Round(950.0 * ColCon);
				mSG_PR[42] = 7;
				mSG_PR[0, 42] = "ComAmt";
				mSG_PR[23] = 0;
				mSG_PR[14] = 0;
			}
			mSG_PR[40] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[40] = 7;
			mSG_PR[0, 40] = "TotAmt";
			mSG_PR[43] = (int)Math.Round(900.0 * ColCon);
			mSG_PR[43] = 7;
			mSG_PR[0, 43] = "TaxPrc";
			mSG_PR[44] = (int)Math.Round(1200.0 * ColCon);
			mSG_PR[44] = 7;
			mSG_PR[0, 44] = "NetAmt";
			mSG_PR[45] = 0;
			mSG_PR[46] = 0;
			mSG_PR[47] = 0;
			mSG_PR[48] = 0;
			mSG_PR[49] = 0;
			mSG_PR[50] = 0;
			mSG_PR[51] = 0;
			mSG_PR[52] = 0;
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
			mSG_PR[67] = 0;
			mSG_PR[68] = 0;
			mSG_PR[69] = 0;
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
					if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'KR_REC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					}
					else
					{
						dataView.RowFilter = " BOOK_NAME = 'PURC_AC' AND COL_NAME = '" + mSG_PR[0, DC_Main.M] + "'";
					}
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
		checked
		{
			mSG_PR.Row = mSG_PR.Rows - 1;
			mSG_PR[mSG_PR.Row, 0] = Conversions.ToString(mSG_PR.Row);
			mSG_PR[mSG_PR.Row, 33] = DC_Main.MsLbrType;
			mSG_PR[mSG_PR.Row, 30] = "F";
			if (Conversion.Val((object)mSG_PR[7]) > 0.0)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM007NEDM", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 7] = "Y";
				}
				else
				{
					mSG_PR[mSG_PR.Row, 7] = "N";
				}
			}
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0 && Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 3] = "002";
			}
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG_PR[mSG_PR.Row, 57] = Conversions.ToString(mSG_PR.Row);
			}
			else
			{
				mSG_PR[mSG_PR.Row, 57] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row - 1, 57]) + 1.0);
			}
			MSG_PR_IDTL_CLEAR();
			mSG_PR = null;
		}
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
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_021c: Invalid comparison between Unknown and I4
		//IL_092e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0931: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_0966: Invalid comparison between Unknown and I4
		//IL_0992: Unknown result type (might be due to invalid IL or missing references)
		//IL_0995: Invalid comparison between Unknown and I4
		//IL_178a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1791: Invalid comparison between Unknown and I4
		//IL_1794: Unknown result type (might be due to invalid IL or missing references)
		//IL_179b: Invalid comparison between Unknown and I4
		//IL_179f: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a6: Invalid comparison between Unknown and I4
		//IL_09c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c3: Invalid comparison between Unknown and I4
		//IL_09f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f8: Invalid comparison between Unknown and I4
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020c: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ff: Unknown result type (might be due to invalid IL or missing references)
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
			if ((Operators.CompareString(UserDelete, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
			{
				Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
				return;
			}
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 57]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtlPr.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[DC_Main.M][24])) == Conversion.Val(mSG_PR[mSG_PR.Row, 57]))
						{
							list.Add(DtIdtlPr.Rows[DC_Main.M]);
						}
						DC_Main.M++;
					}
					foreach (DataRow item in list)
					{
						DtIdtlPr.Rows.Remove(item);
						DtIdtlPr.AcceptChanges();
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
			if (mSG_PR.Col == 29)
			{
				if (Conversion.Val(TEXT_PR.Text) != 0.0)
				{
					return;
				}
				DC_Main.RsQry = "SELECT GR_PR_RATE FROM  RATE_MAST AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND B.IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				double num4 = default(double);
				if (dataTable.Rows.Count > 0)
				{
					num4 = Conversions.ToDouble(dataTable.Rows[0]["GR_PR_RATE"]);
				}
				if (num4 > 0.0)
				{
					if (Operators.CompareString(mSG_PR[mSG_PR.Row, 46], "G", false) == 0)
					{
						TEXT_PR.Text = Strings.Format((object)Math.Round(num4 / 10.0, 2), "0.00");
					}
					else if (Operators.CompareString(mSG_PR[mSG_PR.Row, 46], "K", false) == 0)
					{
						TEXT_PR.Text = Strings.Format((object)Math.Round(num4 / 10.0, 0), "0.00");
					}
					else if (Operators.CompareString(mSG_PR[mSG_PR.Row, 46], "1", false) == 0)
					{
						TEXT_PR.Text = Strings.Format((object)Math.Round(num4, 0), "0.00");
					}
				}
				else
				{
					mSG_PR[mSG_PR.Row, 29] = "";
				}
				return;
			}
			if (mSG_PR.Col == 5)
			{
				LotNoGen(mSG_PR.Row);
			}
			string text = mSG_PR[mSG_PR.Row, 64];
			if (mSG_PR.Col == 6)
			{
				ItmLotGen(mSG_PR.Row);
			}
			if ((mSG_PR.Col == 21) | (mSG_PR.Col == 22) | (mSG_PR.Col == 34))
			{
				DC_Main.RsQry = "SELECT * FROM TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'";
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (mSG_PR.Col == 21)
				{
					if (dataTable2.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0,0) ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_TOUCH = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'");
					}
				}
				else if (mSG_PR.Col == 22)
				{
					if (dataTable2.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "' ,'" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ," + Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 21])) + "," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ",0) ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_WEST = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' ");
					}
				}
				else if (mSG_PR.Col == 34)
				{
					if (dataTable2.Rows.Count == 0)
					{
						DC_Main.ExeQuteDc("INSERT INTO TOUCH_MAST (CO_CODE,LC_CODE,AC_CODE,AC_IT_CODE,AC_TOUCH,AC_WEST,AC_LBR_RATE) VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + tAcCode.Text + "', '" + mSG_PR[mSG_PR.Row, 1] + "' ,0,0," + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + ") ");
					}
					else
					{
						DC_Main.ExeQuteDc(" UPDATE TOUCH_MAST SET AC_LBR_RATE = " + Conversions.ToString(Conversion.Val(TEXT_PR.Text)) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND AC_CODE = '" + tAcCode.Text + "' AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "'");
					}
				}
				Interaction.MsgBox((object)"Touch Update...", (MsgBoxStyle)0, (object)null);
			}
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
				if (mSG_PR.Col < 44)
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
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_PR.Text + "' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND IT_TYPE = '" + FormItmType + "'"))), (object)""));
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
									TEXT_PR.Text = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 1] = DC_Main.ColValue[1];
									mSG_PR[mSG_PR.Row, 2] = DC_Main.ColValue[0];
									mSG_PR[mSG_PR.Row, 45] = DC_Main.ColValue[4];
									mSG_PR[mSG_PR.Row, 64] = DC_Main.ColValue[3];
								}
								((Control)TEXT_PR).Focus();
							}
							return;
						}
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							mSG_PR[mSG_PR.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						mSG_PR[mSG_PR.Row, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG_PR[mSG_PR.Row, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG_PR[mSG_PR.Row, 46] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						StkRow = 0;
						object Value;
						DataRow dataRow;
						if (Operators.CompareString(mSG_PR[mSG_PR.Row, 1], mSG_PR[mSG_PR.Row, 65], false) != 0)
						{
							mSG_PR[mSG_PR.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_CODE"], (object)""));
							mSG_PR[mSG_PR.Row, 5] = "";
							mSG_PR[mSG_PR.Row, 6] = "";
							DC_Main.RsQry = "Select IT_TOUCH,IT_WEST From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' ";
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0 && Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) + Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
							{
								if (Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_TOUCH"], (object)"")) != 0.0)
								{
									AxMSFlexGrid obj = mSG_PR;
									int row = mSG_PR.Row;
									Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable3.Rows[0])["IT_TOUCH"]);
									double num5 = DC_Main.Fnv(ref Value);
									dataRow["IT_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
									obj[row, 21] = Strings.Format((object)num5, "0.00");
								}
								if (Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")) != 0.0)
								{
									mSG_PR[mSG_PR.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["IT_WEST"], (object)"")), "0.00");
								}
								if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) > 0.0)
								{
									CommPassTotal_Pr(mSG_PR.Row);
								}
							}
						}
						if ((mSG_PR.Row == mSG_PR.Rows - 1) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 46], "P", false) == 0))
						{
							mSG_PR[mSG_PR.Row, 33] = "P";
							mSG_PR[mSG_PR.Row, 54] = Conversions.ToString(0);
						}
						if (!((Operators.CompareString(EntryMode, "E", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "L", false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "Select * From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_IT_CODE = '" + mSG_PR[mSG_PR.Row, 1] + "' AND AC_CODE  = '" + tAcCode.Text + "'";
						DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable4.Rows.Count <= 0)
						{
							break;
						}
						Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_TOUCH"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
						Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_WEST"]);
						double num7 = DC_Main.Fnv(ref Value);
						dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
						if (num6 + num7 != 0.0)
						{
							AxMSFlexGrid obj2 = mSG_PR;
							int row2 = mSG_PR.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_TOUCH"]);
							double num8 = DC_Main.Fnv(ref Value);
							dataRow["AC_TOUCH"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row2, 21] = Strings.Format((object)num8, "0.00");
							AxMSFlexGrid obj3 = mSG_PR;
							int row3 = mSG_PR.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_WEST"]);
							double num9 = DC_Main.Fnv(ref Value);
							dataRow["AC_WEST"] = RuntimeHelpers.GetObjectValue(Value);
							obj3[row3, 22] = Strings.Format((object)num9, "0.00");
							if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0))
							{
								mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22])) / 100.0), "0.000");
							}
						}
						Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_LBR_RATE"]);
						double num10 = DC_Main.Fnv(ref Value);
						dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						if ((num10 != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) == 0.0))
						{
							AxMSFlexGrid obj4 = mSG_PR;
							int row4 = mSG_PR.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = dataTable4.Rows[0])["AC_LBR_RATE"]);
							double num11 = DC_Main.Fnv(ref Value);
							dataRow["AC_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							obj4[row4, 34] = Strings.Format((object)num11, "0.00");
							if (Conversion.Val(Operators.ConcatenateObject(dataTable4.Rows[0]["AC_LBR_TYPE"], (object)"")) != 0.0)
							{
								mSG_PR[mSG_PR.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(dataTable4.Rows[0]["AC_LBR_TYPE"], (object)""));
							}
						}
						break;
					}
					case 12:
						if ((Conversion.Val(TEXT_PR.Text) == 0.0) & (Operators.CompareString(mSG_PR[mSG_PR.Row, 46], "P", false) != 0))
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) != 0)
						{
							((Control)PnlPrIdtl).Visible = true;
							mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
							((Control)TEXT_PR).Visible = false;
							MSG_PR_IDTL.Row = MSG_PR_IDTL.Rows - 1;
							MSG_PR_IDTL.Col = 1;
							MSG_PR_IDTL_EnterCell(MSG_PR_IDTL, new EventArgs());
							((Control)TEXT_PR_IDTL).Focus();
							((TextBoxBase)TEXT_PR_IDTL).SelectAll();
							return;
						}
						break;
					case 30:
						if ((Operators.CompareString(TEXT_PR.Text, "N", false) != 0) & (Operators.CompareString(TEXT_PR.Text, "F", false) != 0))
						{
							Interaction.MsgBox((object)"Please Slelect Rate type = N - Net Wise Or F - Fine Wise", (MsgBoxStyle)0, (object)null);
							return;
						}
						break;
					case 5:
						if (Operators.CompareString(DC_Main.SSRegSrNo, "DM012NEDM", false) == 0 && Operators.CompareString(TEXT_PR.Text, "", false) == 0)
						{
							((Control)TEXT_PR).Focus();
							return;
						}
						break;
					case 44:
						if (mSG_PR.Row == mSG_PR.Rows - 1)
						{
							mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
							CommPassTotal_Pr(mSG_PR.Row);
							MsgClear = true;
							mSG_PR.Rows += 1;
							mSG_PR.Row += 1;
							mSG_PR.Col = 1;
							MsgClear = false;
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
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13))
		{
			if (Operators.CompareString(MSG_PR[MSG_PR.Row, 1], "", false) != 0)
			{
				if (StkRow != MSG_PR.Row)
				{
					StkRow = MSG_PR.Row;
					DC_Main.RsQry = "Select IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS NetWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND IT_CODE = '" + MSG_PR[MSG_PR.Row, 1] + "'  and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' GROUP BY IT_CODE";
					DataTable dataTable5 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable5.Rows.Count > 0)
					{
						nitGwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable5.Rows[0]["GrWt"]), "0.000");
						nItNwt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable5.Rows[0]["NetWt"]), "0.000");
					}
					else
					{
						nitGwt.Text = Conversions.ToString(0);
						nItNwt.Text = Conversions.ToString(0);
					}
				}
			}
			else
			{
				nitGwt.Text = Conversions.ToString(0);
				nItNwt.Text = Conversions.ToString(0);
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
				if (MsgOldRowPr != MSG_PR.Row)
				{
					MsgOldRowPr = 0;
				}
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
				((TextBoxBase)TEXT_PR).MaxLength = 5;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_PR).MaxLength = 50;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_PR).MaxLength = 3;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_PR).MaxLength = 15;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				if (Operators.CompareString(EntryMode, "E", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 6:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				if (Operators.CompareString(EntryMode, "E", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 7:
			case 30:
			case 33:
				((TextBoxBase)TEXT_PR).MaxLength = 1;
				TEXT_PR.Text = mSG_PR[mSG_PR.Row, mSG_PR.Col];
				break;
			case 9:
				((TextBoxBase)TEXT_PR).MaxLength = 8;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0");
				break;
			case 21:
			case 22:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0)
				{
					TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				}
				else
				{
					TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				break;
			case 16:
			case 19:
			case 23:
			case 27:
			case 28:
			case 29:
			case 31:
			case 32:
			case 34:
			case 35:
			case 36:
			case 37:
			case 39:
			case 40:
			case 41:
			case 42:
			case 43:
			case 44:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.00");
				break;
			case 8:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 17:
			case 18:
			case 20:
			case 26:
			case 38:
			case 53:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				break;
			case 25:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				((TextBoxBase)TEXT_PR).ReadOnly = true;
				break;
			case 24:
				((TextBoxBase)TEXT_PR).MaxLength = 10;
				TEXT_PR.Text = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, mSG_PR.Col]), "0.000");
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
				{
					((TextBoxBase)TEXT_PR).ReadOnly = true;
				}
				if (Operators.CompareString(DC_Main.MsItmFineLock, "Y", false) == 0)
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
		if (MsgClear || MSG_PR.Row == 0 || MSG_PR[MSG_PR.Col] == 0 || !((Control)TEXT_PR).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_PR = MSG_PR;
		switch (MSG_PR.Col)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 30:
		case 33:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = TEXT_PR.Text;
			break;
		case 9:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 21:
		case 22:
			CommPassTotal_Pr(mSG_PR.Row);
			if (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0)
			{
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			}
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 16:
		case 19:
		case 23:
		case 27:
		case 28:
		case 29:
		case 31:
		case 32:
		case 34:
		case 35:
		case 36:
		case 37:
		case 39:
		case 40:
		case 41:
		case 42:
		case 43:
		case 44:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		case 8:
		case 10:
		case 11:
		case 12:
		case 13:
		case 14:
		case 15:
		case 17:
		case 18:
		case 20:
		case 24:
		case 25:
		case 26:
		case 38:
		case 53:
			mSG_PR[mSG_PR.Row, mSG_PR.Col] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.000");
			CommPassTotal_Pr(mSG_PR.Row);
			break;
		}
		mSG_PR = null;
	}

	private void CommPassTotal_Pr(int CRow)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 8]) != Conversion.Val(mSG_PR[mSG_PR.Row, 66]))
		{
			mSG_PR[mSG_PR.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 8]) * Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.000");
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
			}
		}
		if (Conversion.Val((object)mSG_PR[11]) > 0.0 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 11]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 12] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 11])), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != Conversion.Val(mSG_PR[mSG_PR.Row, 67]))
		{
			mSG_PR[mSG_PR.Row, 67] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 15]));
			mSG_PR[mSG_PR.Row, 48] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 49] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 50] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 16]) / 100.0), "0.000");
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != Conversion.Val(mSG_PR[mSG_PR.Row, 68]))
		{
			mSG_PR[mSG_PR.Row, 68] = Conversions.ToString(Conversion.Val(mSG_PR[mSG_PR.Row, 16]));
			mSG_PR[mSG_PR.Row, 48] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 49] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 50] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 16]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 15]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 15]) * Conversion.Val(mSG_PR[mSG_PR.Row, 16]) / 100.0), "0.000");
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 17] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 15]), "0.000");
				mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != Conversion.Val(mSG_PR[mSG_PR.Row, 47]))
		{
			mSG_PR[mSG_PR.Row, 47] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 12]), "0.000");
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 14]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 13]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 18] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) - (Conversion.Val(mSG_PR[mSG_PR.Row, 13]) + Conversion.Val(mSG_PR[mSG_PR.Row, 10]) + Conversion.Val(mSG_PR[mSG_PR.Row, 14]) + Conversion.Val(mSG_PR[mSG_PR.Row, 15]))), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != Conversion.Val(mSG_PR[mSG_PR.Row, 48]))
		{
			mSG_PR[mSG_PR.Row, 48] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 18]), "0.000");
			mSG_PR[mSG_PR.Row, 49] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 50] = Conversions.ToString(0);
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])) / 100.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
			}
			else
			{
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
			}
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 19]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 20] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) * Conversion.Val(mSG_PR[mSG_PR.Row, 19]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 59]) != Conversion.Val(mSG_PR[mSG_PR.Row, 20]))
		{
			mSG_PR[mSG_PR.Row, 59] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 20]), "0.000");
			mSG_PR[mSG_PR.Row, 49] = Conversions.ToString(0);
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != Conversion.Val(mSG_PR[mSG_PR.Row, 49]))
		{
			mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])) / 100.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
			}
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != Conversion.Val(mSG_PR[mSG_PR.Row, 50]))
		{
			mSG_PR[mSG_PR.Row, 50] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 22]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])) / 100.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
			}
			mSG_PR[mSG_PR.Row, 51] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != Conversion.Val(mSG_PR[mSG_PR.Row, 52]))
		{
			mSG_PR[mSG_PR.Row, 52] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 23]), "0.00");
			if ((Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 23]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])) / 100.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 21]) + Conversion.Val(mSG_PR[mSG_PR.Row, 22]) - Conversion.Val(mSG_PR[mSG_PR.Row, 23])) / 100.0 + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
		}
		else
		{
			mSG_PR[mSG_PR.Row, 25] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20]) + Conversion.Val(mSG_PR[mSG_PR.Row, 17])), "0.000");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 37]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 36]) != 0.0))
		{
			string text = mSG_PR[mSG_PR.Row, 46];
			if (Operators.CompareString(text, "1", false) != 0)
			{
				if (Operators.CompareString(text, "K", false) == 0)
				{
					mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) * 1000.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 37]), 3), "0.000");
				}
				else
				{
					mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) / Conversion.Val(mSG_PR[mSG_PR.Row, 37]), 3), "0.000");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 38] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 36]) * 10.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 37]), 3), "0.000");
			}
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 28]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 27]) / Conversion.Val(mSG_PR[mSG_PR.Row, 28]) * 100.0, 2), "0.000");
		}
		else if (Conversion.Val(mSG_PR[mSG_PR.Row, 27]) != 0.0)
		{
			mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 27]), "0.00");
		}
		double num = 0.0;
		num = ((Operators.CompareString(mSG_PR[mSG_PR.Row, 30], "N", false) == 0) ? (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) : ((Operators.CompareString(DC_Main.MsPrAmtType, "G", false) == 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 12]) : ((Operators.CompareString(DC_Main.MsPrAmtType, "N", false) != 0) ? Conversion.Val(mSG_PR[mSG_PR.Row, 24]) : (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])))));
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 51]) != Conversion.Val(mSG_PR[mSG_PR.Row, 29]))
		{
			mSG_PR[mSG_PR.Row, 58] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != Conversion.Val(mSG_PR[mSG_PR.Row, 51])) & (num + Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
		{
			mSG_PR[mSG_PR.Row, 51] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
			switch (mSG_PR[mSG_PR.Row, 46])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(num * (Conversion.Val(mSG_PR[mSG_PR.Row, 29]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(num * Conversion.Val(mSG_PR[mSG_PR.Row, 29]), 0), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 56] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 31]), "0.00");
			mSG_PR[mSG_PR.Row, 40] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) + Conversion.Val(mSG_PR[mSG_PR.Row, 36]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.00");
		}
		if (mSG_PR.Col == 31 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 29]) == 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0)))
		{
			switch (mSG_PR[mSG_PR.Row, 46])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsPrRateRof), "0.00");
				break;
			case "1":
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_PR.Text) / num, DC_Main.MsPrRateRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 51] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
		}
		if (Operators.CompareString(DC_Main.MsOldPurcTchGen, "Y", false) == 0 && ((Operators.CompareString(DC_Main.MCo_Book, "037", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "038", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "043", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "044", false) == 0)) && Operators.CompareString(mSG_PR[mSG_PR.Row, 30], "N", false) != 0 && mSG_PR.Col == 31 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 29]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 24]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(TEXT_PR.Text) * Conversion.Val(mSG_PR[mSG_PR.Row, 24]) / Conversion.Val(mSG_PR[mSG_PR.Row, 56]))), "0.000");
			mSG_PR[mSG_PR.Row, 21] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 24]) * 100.0 / Conversion.Val(mSG_PR[mSG_PR.Row, 18]))), "0.00");
			mSG_PR[mSG_PR.Row, 56] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Conversion.Val(TEXT_PR.Text), "0.00");
			mSG_PR[mSG_PR.Row, 49] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 21]), "0.00");
		}
		if ((Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 54]) != Conversion.Val(mSG_PR[mSG_PR.Row, 34])))
		{
			switch (mSG_PR[mSG_PR.Row, 33])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 9]) * Conversion.Val(mSG_PR[mSG_PR.Row, 34]), 0), "0.00");
				break;
			case "N":
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * Conversion.Val(mSG_PR[mSG_PR.Row, 34]), 0), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * Conversion.Val(mSG_PR[mSG_PR.Row, 34]), 0), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 54] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00");
		}
		else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 35]) != 0.0) & (Operators.CompareString(DC_Main.MsLbrGen, "Y", false) == 0))
		{
			switch (mSG_PR[mSG_PR.Row, 33])
			{
			case "P":
				mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsLbrRof), "0.00");
				break;
			case "N":
				mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 18]), DC_Main.MsLbrRof), "0.00");
				break;
			case "K":
				mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 18]) * 1000.0, DC_Main.MsLbrRof), "0.00");
				break;
			default:
				mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), DC_Main.MsLbrRof), "0.00");
				break;
			}
			mSG_PR[mSG_PR.Row, 54] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00");
		}
		if (mSG_PR.Col == 40)
		{
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 44]) != Conversion.Val(TEXT_PR.Text))
			{
				mSG_PR[mSG_PR.Row, 58] = Conversions.ToString(0);
			}
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 35]) != 0.0)
			{
				mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)(Conversion.Val(TEXT_PR.Text) - Conversion.Val(mSG_PR[mSG_PR.Row, 36]) - Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.00");
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 35]) < 0.0)
				{
					mSG_PR[mSG_PR.Row, 35] = "";
				}
				if (Conversion.Val(mSG_PR[mSG_PR.Row, 35]) != Conversion.Val(mSG_PR[mSG_PR.Row, 55]) && ((Conversion.Val(mSG_PR[mSG_PR.Row, 35]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 34]) != 0.0)))
				{
					switch (mSG_PR[mSG_PR.Row, 33])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), 2), "0.00");
						break;
					case "N":
						mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])), 2), "0.00");
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20])) * 1000.0, 2), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]), 2), "0.00");
						break;
					}
					double num2 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00"));
					mSG_PR[mSG_PR.Row, 54] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 34]), "0.00");
					mSG_PR[mSG_PR.Row, 55] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 35]), "0.00");
				}
			}
			else
			{
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 40]) - Conversion.Val(mSG_PR[mSG_PR.Row, 36])), "0.00");
				if ((Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
				{
					switch (mSG_PR[mSG_PR.Row, 46])
					{
					case "P":
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsPrRateRof), "0.00");
						break;
					case "1":
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
						break;
					case "K":
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
						break;
					default:
						mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num, DC_Main.MsPrRateRof), "0.00");
						break;
					}
					mSG_PR[mSG_PR.Row, 51] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
				}
			}
		}
		mSG_PR[mSG_PR.Row, 40] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) + Conversion.Val(mSG_PR[mSG_PR.Row, 36]) + Conversion.Val(mSG_PR[mSG_PR.Row, 31])), "0.00");
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0 && ((Conversion.Val(mSG_PR[mSG_PR.Row, 40]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 41]) != 0.0)))
		{
			mSG_PR[mSG_PR.Row, 42] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 40]) * Conversion.Val(mSG_PR[mSG_PR.Row, 41]) / 100.0), "0.00");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 43]) == 0.0)
		{
			mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 40]) + Conversion.Val(mSG_PR[mSG_PR.Row, 42])), "0.00");
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 43]) != Conversion.Val(mSG_PR[mSG_PR.Row, 58]))
		{
			mSG_PR[mSG_PR.Row, 58] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 43]), "0.00");
			mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)Math.Round((Conversion.Val(mSG_PR[mSG_PR.Row, 40]) + Conversion.Val(mSG_PR[mSG_PR.Row, 42])) / (Conversion.Val(mSG_PR[mSG_PR.Row, 43]) + 100.0) * 100.0, 0), "0.00");
			mSG_PR[mSG_PR.Row, 35] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 44]) - Conversion.Val(mSG_PR[mSG_PR.Row, 31]) - Conversion.Val(mSG_PR[mSG_PR.Row, 36]), 0), "0.00");
			if (Conversion.Val(mSG_PR[mSG_PR.Row, 35]) > 0.0)
			{
				if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 33], "P", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9])), "0.00");
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 33], "N", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / (Conversion.Val(mSG_PR[mSG_PR.Row, 18]) + Conversion.Val(mSG_PR[mSG_PR.Row, 20]))), "0.00");
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 33], "K", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12]) * 1000.0), "0.00");
				}
				else if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 33], "G", false) == 0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) != 0.0))
				{
					mSG_PR[mSG_PR.Row, 34] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 35]) / Conversion.Val(mSG_PR[mSG_PR.Row, 12])), "0.00");
				}
			}
			else if ((Conversion.Val(mSG_PR[mSG_PR.Row, 31]) != 0.0) & (Conversion.Val(mSG_PR[mSG_PR.Row, 12]) + Conversion.Val(mSG_PR[mSG_PR.Row, 9]) != 0.0))
			{
				mSG_PR[mSG_PR.Row, 35] = "";
				mSG_PR[mSG_PR.Row, 31] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 44]) - Conversion.Val(mSG_PR[mSG_PR.Row, 35]) - Conversion.Val(mSG_PR[mSG_PR.Row, 36]), 0), "0.00");
				switch (mSG_PR[mSG_PR.Row, 46])
				{
				case "P":
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / Conversion.Val(mSG_PR[mSG_PR.Row, 9]), DC_Main.MsPrRateRof), "0.00");
					break;
				case "1":
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num * 10.0, DC_Main.MsPrRateRof), "0.00");
					break;
				case "K":
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num * 1000.0, DC_Main.MsPrRateRof), "0.00");
					break;
				default:
					mSG_PR[mSG_PR.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 31]) / num, DC_Main.MsPrRateRof), "0.00");
					break;
				}
				mSG_PR[mSG_PR.Row, 51] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 29]), "0.00");
			}
		}
		else
		{
			mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)(Conversion.Val(mSG_PR[mSG_PR.Row, 40]) + Conversion.Val(mSG_PR[mSG_PR.Row, 42])), "0.00");
		}
		if (mSG_PR[30] != 0 && Operators.CompareString(mSG_PR[mSG_PR.Row, 30], "N", false) == 0)
		{
			if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0) & (Conversion.Val(mSG_PR[CRow, 18]) != 0.0) & (Conversion.Val(mSG_PR[CRow, 31]) != 0.0))
			{
				mSG_PR[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_PR[CRow, 31]) / ToDayGlRate / Conversion.Val(mSG_PR[CRow, 18]) * 100.0), "0.00");
			}
			if ((Operators.CompareString(mSG_PR[mSG_PR.Row, 1], "OS", false) == 0) & (ToDaySlRate != 0.0) & (Conversion.Val(mSG_PR[CRow, 18]) != 0.0) & (Conversion.Val(mSG_PR[CRow, 31]) != 0.0))
			{
				mSG_PR[CRow, 21] = Strings.Format((object)(Conversion.Val(mSG_PR[CRow, 31]) / ToDaySlRate / Conversion.Val(mSG_PR[CRow, 18]) * 100.0), "0.00");
			}
			if ((Conversion.Val(mSG_PR[CRow, 21]) != 0.0) & (Conversion.Val(mSG_PR[CRow, 18]) != 0.0))
			{
				mSG_PR[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_PR[CRow, 18]) * Conversion.Val(mSG_PR[CRow, 21]) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG_PR[mSG_PR.Row, 39]) != 0.0)
		{
			mSG_PR[mSG_PR.Row, 40] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 39]), "0.00");
			mSG_PR[mSG_PR.Row, 44] = Strings.Format((object)Conversion.Val(mSG_PR[mSG_PR.Row, 39]), "0.00");
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "KJ025NBKJ", false) == 0)
		{
			mSG_PR[mSG_PR.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(mSG_PR[mSG_PR.Row, 24]), 2), "0.000");
		}
		MSG_PR_TOT_FILL();
		BILL_TOTAL();
		mSG_PR = null;
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

	private void MSG_PR_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		PurcAcFine = 0.0;
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
			mSG_PR_TOT[0, 4] = "Total :";
			int num2 = MSG_PR.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_PR_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR[DC_Main.M, 9]))), "0");
				mSG_PR_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 8]) + Conversion.Val(MSG_PR[DC_Main.M, 8]))), "0.000");
				mSG_PR_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 10]) + Conversion.Val(MSG_PR[DC_Main.M, 10]))), "0.000");
				mSG_PR_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR[DC_Main.M, 12]))), "0.000");
				mSG_PR_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 13]) + Conversion.Val(MSG_PR[DC_Main.M, 13]))), "0.000");
				mSG_PR_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 14]) + Conversion.Val(MSG_PR[DC_Main.M, 14]))), "0.000");
				mSG_PR_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 18]) + Conversion.Val(MSG_PR[DC_Main.M, 18]))), "0.000");
				mSG_PR_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 20]) + Conversion.Val(MSG_PR[DC_Main.M, 20]))), "0.000");
				mSG_PR_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 24]) + Conversion.Val(MSG_PR[DC_Main.M, 24]))), "0.000");
				mSG_PR_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 25]) + Conversion.Val(MSG_PR[DC_Main.M, 25]))), "0.000");
				mSG_PR_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 31]) + Conversion.Val(MSG_PR[DC_Main.M, 31]))), "0.00");
				mSG_PR_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 35]) + Conversion.Val(MSG_PR[DC_Main.M, 35]))), "0.00");
				mSG_PR_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 36]) + Conversion.Val(MSG_PR[DC_Main.M, 36]))), "0.00");
				mSG_PR_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 39]) + Conversion.Val(MSG_PR[DC_Main.M, 39]))), "0.00");
				mSG_PR_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 42]) + Conversion.Val(MSG_PR[DC_Main.M, 42]))), "0.00");
				mSG_PR_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 40]) + Conversion.Val(MSG_PR[DC_Main.M, 40]))), "0.00");
				mSG_PR_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 44]) + Conversion.Val(MSG_PR[DC_Main.M, 44]))), "0.00");
				if (Conversion.Val(MSG_PR[DC_Main.M, 37]) != 0.0)
				{
					PrOthAmtLess += Conversion.Val(MSG_PR[DC_Main.M, 36]);
				}
				mSG_PR_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_PR_TOT[0, 38]) + Conversion.Val(MSG_PR[DC_Main.M, 38]))), "0.000");
				if (Conversion.Val(MSG_PR[DC_Main.M, 31]) == 0.0)
				{
					PurcAcFine += Conversion.Val(MSG_PR[DC_Main.M, 24]) + Conversion.Val(MSG_PR[DC_Main.M, 38]);
				}
				DC_Main.M++;
			}
			lblOldFine.Text = "Old Fine : " + Strings.Format((object)Conversion.Val(mSG_PR_TOT[0, 24]), "0.000");
			mSG_PR_TOT = null;
		}
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 34;
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
			mSG_IDTL[1] = (int)Math.Round(850.0 * ColCon);
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
				mSG_IDTL[0, 8] = "Remark";
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
				mSG_IDTL[13] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[13] = 7;
				mSG_IDTL[0, 13] = "PcsWt";
			}
			mSG_IDTL[14] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "KrWt";
			mSG_IDTL[15] = (int)Math.Round(800.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "KrLs%";
			mSG_IDTL[16] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "Weight";
			mSG_IDTL[17] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[17] = 7;
			mSG_IDTL[0, 17] = "Con%";
			mSG_IDTL[18] = (int)Math.Round(650.0 * ColCon);
			mSG_IDTL[18] = 3;
			mSG_IDTL[0, 18] = "P/W";
			mSG_IDTL[19] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[19] = 7;
			mSG_IDTL[0, 19] = "Rate";
			mSG_IDTL[20] = (int)Math.Round(1100.0 * ColCon);
			mSG_IDTL[20] = 7;
			mSG_IDTL[0, 20] = "ItAmt";
			mSG_IDTL[21] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[21] = 7;
			mSG_IDTL[0, 21] = "KrCon%";
			mSG_IDTL[22] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[22] = 3;
			mSG_IDTL[0, 22] = "KrP/W";
			mSG_IDTL[23] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[23] = 7;
			mSG_IDTL[0, 23] = "PRate";
			mSG_IDTL[24] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[24] = 7;
			mSG_IDTL[0, 24] = "PAmt";
			mSG_IDTL[25] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[25] = 7;
			mSG_IDTL[0, 25] = "LbrRate";
			mSG_IDTL[26] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[26] = 7;
			mSG_IDTL[0, 26] = "LbrAmt";
			mSG_IDTL[27] = (int)Math.Round(1100.0 * ColCon);
			mSG_IDTL[27] = 7;
			mSG_IDTL[0, 27] = "NetAmt";
			mSG_IDTL[28] = 0;
			mSG_IDTL[0, 28] = "ConWt";
			mSG_IDTL[29] = 0;
			mSG_IDTL[0, 29] = "KrConWt";
			mSG_IDTL[30] = 0;
			mSG_IDTL[0, 30] = "ItType";
			mSG_IDTL[31] = 0;
			mSG_IDTL[0, 31] = "RowSrNo";
			mSG_IDTL[32] = 0;
			mSG_IDTL[0, 32] = "OldKrWt";
			mSG_IDTL[33] = 0;
			mSG_IDTL[0, 33] = "OldGrWt";
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
		mSG_IDTL[mSG_IDTL.Row, 31] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 46]));
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
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08cd: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][31])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 31])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
				if (mSG_IDTL.Col < 27)
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
									mSG_IDTL[mSG_IDTL.Row, 30] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 17]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CON_PRC"], (object)"")), "0.000");
						}
						if (Operators.CompareString(MSG[MSG.Row, 53], "A", false) != 0)
						{
							break;
						}
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 27]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
						}
						else if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
						}
						if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""), (object)"F", false))) && Operators.CompareString(mSG_IDTL[mSG_IDTL.Row, 18], "", false) == 0)
						{
							mSG_IDTL[mSG_IDTL.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE_TYPE"], (object)""));
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
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 19]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 19] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					}
					case 13:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) != 0.0) & (Conversion.Val(TEXT_IDTL.Text) != 0.0))
						{
							mSG_IDTL[mSG_IDTL.Row, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) * Conversion.Val(TEXT_IDTL.Text)), "0.000");
						}
						break;
					case 16:
						if ((Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) == 0.0) & (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 16]) == 0.0))
						{
							if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 27]) == 0.0)
							{
								mSG_IDTL[mSG_IDTL.Row, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["OTH_RATE"], (object)"")), "0.00");
							}
							mSG_IDTL[mSG_IDTL.Row, 19] = "";
						}
						break;
					case 27:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 27] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
							mSG_IDTL[mSG_IDTL.Row, 27] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
			case 18:
			case 22:
				((TextBoxBase)TEXT_IDTL).MaxLength = 1;
				TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
				break;
			case 10:
			case 12:
				((TextBoxBase)TEXT_IDTL).MaxLength = 6;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
				break;
			case 17:
			case 21:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
				break;
			case 15:
			case 19:
			case 20:
			case 23:
			case 24:
			case 25:
			case 26:
			case 27:
				((TextBoxBase)TEXT_IDTL).MaxLength = 10;
				TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
				break;
			case 11:
			case 14:
			case 16:
			case 28:
			case 29:
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
		case 18:
		case 22:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
			break;
		case 10:
		case 12:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 17:
		case 21:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 15:
		case 19:
		case 20:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
			mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
			CommPassTotal_Idtl(mSG_IDTL.Row);
			break;
		case 11:
		case 14:
		case 16:
		case 28:
		case 29:
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
		if ((Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 13]) != 0.0))
		{
			mSG_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 13])), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 14]) != Conversion.Val(mSG_IDTL[CRow, 32])) & (Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0))
		{
			mSG_IDTL[CRow, 32] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
			mSG_IDTL[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 14]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 16]) != Conversion.Val(mSG_IDTL[CRow, 33])) & (Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0))
		{
			mSG_IDTL[CRow, 33] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
			mSG_IDTL[CRow, 14] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
		{
			mSG_IDTL[CRow, 28] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 17])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 28] = Conversions.ToString(0);
		}
		if (Conversion.Val((object)mSG_IDTL[21]) > 0.0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 21]) != 0.0))
			{
				mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 21])), "0.000");
			}
			else
			{
				mSG_IDTL[CRow, 29] = Conversions.ToString(0);
			}
		}
		else if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0))
		{
			mSG_IDTL[CRow, 29] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 17])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 29] = Conversions.ToString(0);
		}
		if (Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 15]) / 100.0), "0.000");
			mSG_IDTL[CRow, 33] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 16]), "0.000");
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 18], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 16]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0))
			{
				mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0))
			{
				mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 18], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 19])))) != 0)
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 19]) != 0.0)
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 19]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
		}
		if (Conversion.Val((object)mSG_IDTL[14]) <= 0.0)
		{
			if (Operators.CompareString(mSG_IDTL[CRow, 18], "", false) == 0)
			{
				if ((Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0))
				{
					mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
				}
				else if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0))
				{
					mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
				}
			}
			else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 18], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 23])))) != 0)
			{
				mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0)
			{
				mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 16])), "0.00");
			}
		}
		else if (Operators.CompareString(mSG_IDTL[CRow, 18], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 14]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0))
			{
				mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0))
			{
				mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 18], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 23])))) != 0)
		{
			mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 23]) != 0.0)
		{
			mSG_IDTL[CRow, 24] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 23]) * Conversion.Val(mSG_IDTL[CRow, 14])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 25]) != 0.0)
		{
			mSG_IDTL[CRow, 26] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 25]) * Conversion.Val(mSG_IDTL[CRow, 12])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 20]) + Conversion.Val(mSG_IDTL[CRow, 26]) != 0.0)
		{
			mSG_IDTL[CRow, 27] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 20]) + Conversion.Val(mSG_IDTL[CRow, 26])), "0.00");
		}
		checked
		{
			int num5 = mSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num5)
			{
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 28]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 29]);
				num += Conversion.Val(mSG_IDTL[DC_Main.M, 27]);
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 24]);
				DC_Main.M++;
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 12] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 13] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - Conversion.Val(MSG[MSG.Row, 12])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 14] = Strings.Format((object)num4, "0.000");
				MSG[MSG.Row, 15] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - Conversion.Val(MSG[MSG.Row, 14])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 31] = Strings.Format((object)num, "0.00");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 13] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - num3), "0.000");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 34] = Strings.Format((object)num2, "0.00");
				MSG[MSG.Row, 35] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 33]) + Conversion.Val(MSG[MSG.Row, 34])), "0.0");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][31])) == Conversion.Val(mSG_IDTL[CRow, 31])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
			mSG[2] = (int)Math.Round(900.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[3] = (int)Math.Round(1200.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "TagNo";
			mSG[1] = (int)Math.Round(900.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "OrdNo";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Counter";
			mSG[5] = (int)Math.Round(1300.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Design";
			if ((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "Style";
			}
			else
			{
				mSG[6] = 0;
			}
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "Size";
			mSG[8] = (int)Math.Round(900.0 * ColCon);
			mSG[8] = 0;
			mSG[0, 8] = "HuId";
			mSG[9] = (int)Math.Round(800.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "BagWt";
			mSG[10] = (int)Math.Round(700.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Pcs";
			mSG[11] = (int)Math.Round(1000.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "GrWt";
			mSG[12] = (int)Math.Round(900.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "LsWt";
			mSG[13] = (int)Math.Round(1000.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "NetWt";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "KrOthWt";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "KrNwt";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "KrGht%";
			mSG[17] = (int)Math.Round(1000.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "KrGht";
			if ((Operators.CompareString(DC_Main.MsUserKrTouchHide, "Y", false) == 0) & (Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0))
			{
				mSG[18] = 0;
				mSG[19] = 0;
				mSG[20] = 0;
			}
			else
			{
				mSG[18] = (int)Math.Round(900.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "KrTouch";
				mSG[19] = (int)Math.Round(900.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "KrWst%";
				mSG[20] = (int)Math.Round(900.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "KrFine";
			}
			mSG[22] = (int)Math.Round(750.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "Ght%";
			mSG[23] = (int)Math.Round(850.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "GhtWt";
			mSG[24] = (int)Math.Round(850.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "Touch";
			mSG[25] = (int)Math.Round(850.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "West%";
			mSG[26] = (int)Math.Round(1000.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Fine";
			mSG[21] = (int)Math.Round(800.0 * ColCon);
			mSG[21] = 3;
			mSG[0, 21] = "LCode";
			mSG[27] = (int)Math.Round(800.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "Lbr%";
			mSG[28] = (int)Math.Round(800.0 * ColCon);
			mSG[28] = 3;
			mSG[0, 28] = "LType";
			mSG[29] = (int)Math.Round(900.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "LbrRate";
			mSG[30] = (int)Math.Round(950.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "LbrAmt";
			mSG[31] = (int)Math.Round(1000.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "OthAmt";
			mSG[32] = (int)Math.Round(900.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "KrLRate";
			mSG[33] = (int)Math.Round(1000.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrLAmt";
			mSG[34] = (int)Math.Round(1100.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrOthAmt";
			mSG[35] = (int)Math.Round(950.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "PrCost";
			mSG[36] = (int)Math.Round(1000.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "ItRate";
			mSG[37] = (int)Math.Round(1100.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "ItAmt";
			mSG[38] = (int)Math.Round(1100.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "TagCost";
			mSG[39] = (int)Math.Round(800.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "Margin";
			mSG[40] = (int)Math.Round(950.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "Mrp";
			mSG[41] = (int)Math.Round(750.0 * ColCon);
			mSG[41] = 3;
			mSG[0, 41] = "Image";
			mSG[43] = (int)Math.Round(900.0 * ColCon);
			mSG[43] = 3;
			mSG[0, 43] = "EmpCod";
			mSG[44] = (int)Math.Round(800.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "KrCod";
			mSG[42] = (int)Math.Round(2200.0 * ColCon);
			mSG[42] = 0;
			mSG[0, 42] = "Remark";
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
			mSG[82] = 0;
			mSG[83] = 0;
			mSG[84] = 0;
			mSG[87] = 0;
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
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				mSG[24] = (int)Math.Round(850.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "Touch";
				mSG[26] = (int)Math.Round(1000.0 * ColCon);
				mSG[26] = 7;
				mSG[0, 26] = "Fine";
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				mSG[1] = (int)Math.Round(900.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "OrdNo";
			}
			MsgLastCol = 44;
			DC_Main.M = 45;
			while (DC_Main.M <= 35)
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[35] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 35;
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
				mSG_TOT[0, 5] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.000");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.000");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.00");
					mSG_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 31]) + Conversion.Val(MSG[DC_Main.M, 31]))), "0.00");
					mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.00");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.000");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
					mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.00");
					mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 30]);
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
			mSG[mSG.Row, 10] = Conversions.ToString(1);
			mSG[mSG.Row, 28] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 46] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 46] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 46]) + 1.0);
			}
			mSG[mSG.Row, 53] = "A";
			mSG[mSG.Row, 73] = BookDataType;
			mSG[mSG.Row, 41] = "N";
			mSG[mSG.Row, 65] = "N";
			mSG[mSG.Row, 80] = "N";
			mSG[mSG.Row, 83] = "N";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0 && Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				mSG[mSG.Row, 4] = "002";
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
			mSG[mSG.Row, 51] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MsVchSrno;
			if (mSG.Row > 1)
			{
				if (mSG.Col == 2)
				{
					TEXT_ENTRY.Text = mSG[mSG.Row - 1, 2];
				}
				DataView dataView = new DataView(DC_Main.RsClDetl);
				if (dataView.Count > 0)
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
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
		checked
		{
			if (mSG.CellWidth >= 0)
			{
				((Control)TEXT_ENTRY).Left = (int)Math.Round((double)((Control)mSG).Left + (double)mSG.CellLeft / 15.0);
				((Control)TEXT_ENTRY).Top = (int)Math.Round((double)((Control)mSG).Top + (double)mSG.CellTop / 15.0);
				((Control)TEXT_ENTRY).Width = (int)Math.Round((double)mSG.CellWidth / 15.0);
				if (MsgOldRow != MSG.Row)
				{
					MsgOldRow = 0;
				}
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
			case 2:
			case 44:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
			case 43:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 42:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					if (MSG.Row != 1)
					{
						((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
					}
				}
				else
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 5:
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 21:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 4;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 28:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 25:
			case 27:
			case 29:
			case 30:
			case 40:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (Operators.CompareString(mSG[mSG.Row, 21], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 18:
			case 19:
			case 22:
			case 24:
			case 39:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 31:
			case 32:
			case 33:
			case 34:
			case 35:
			case 36:
			case 37:
			case 38:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 9:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 17:
			case 20:
			case 23:
			case 26:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			}
			mSG = null;
			((TextBoxBase)TEXT_ENTRY).SelectAll();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
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
			if ((Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0) & (MSG.Row != 1))
			{
				if (Operators.CompareString(MSG[1, 3], "", false) != 0 && ((Operators.CompareString(mSG[mSG.Row, 3], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 2], "", false) != 0)))
				{
					NewTagNo(mSG.Row);
					DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
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
			else if ((Operators.CompareString(mSG[mSG.Row, 3], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 2], "", false) != 0))
			{
				NewTagNo(mSG.Row);
				DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
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
			break;
		case 0:
		case 1:
		case 3:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
		case 21:
		case 28:
		case 41:
		case 42:
		case 43:
		case 44:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 10:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 27:
		case 29:
		case 30:
		case 40:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 18:
		case 19:
		case 22:
		case 24:
		case 25:
		case 39:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 31:
		case 32:
		case 33:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 12:
		case 14:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 9:
		case 11:
		case 13:
		case 15:
		case 16:
		case 17:
		case 20:
		case 23:
		case 26:
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
				case 6322:
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
						case 16:
							goto IL_023e;
						case 17:
							goto IL_028a;
						case 18:
						case 19:
							goto IL_02d4;
						case 20:
							goto IL_030b;
						case 21:
							goto IL_033f;
						case 22:
							goto IL_039f;
						case 24:
							goto IL_041d;
						case 23:
						case 25:
						case 26:
						case 27:
							goto IL_0454;
						case 28:
							goto IL_04a0;
						case 29:
						case 30:
							goto IL_04f4;
						case 31:
							goto IL_052b;
						case 32:
							goto IL_055f;
						case 33:
							goto IL_05bf;
						case 34:
						case 35:
						case 36:
							goto IL_063d;
						case 37:
							goto IL_0674;
						case 38:
							goto IL_06a8;
						case 39:
							goto IL_0708;
						case 40:
						case 41:
						case 42:
							goto IL_0786;
						case 43:
							goto IL_07c1;
						case 44:
						case 45:
							goto IL_080b;
						case 46:
							goto IL_0857;
						case 48:
							goto IL_08a3;
						case 49:
							goto IL_08ca;
						case 47:
						case 50:
						case 51:
							goto IL_08ff;
						case 52:
							goto IL_0936;
						case 53:
							goto IL_096a;
						case 54:
							goto IL_09ca;
						case 56:
							goto IL_0a48;
						case 55:
						case 57:
						case 58:
						case 59:
							goto IL_0a7f;
						case 60:
							goto IL_0ab6;
						case 61:
							goto IL_0aea;
						case 62:
							goto IL_0b4a;
						case 63:
						case 64:
						case 65:
							goto IL_0bc8;
						case 66:
							goto IL_0bff;
						case 67:
							goto IL_0c33;
						case 68:
							goto IL_0c93;
						case 69:
						case 70:
						case 71:
							goto IL_0d11;
						case 72:
							goto IL_0d4c;
						case 73:
						case 74:
							goto IL_0d96;
						case 75:
							goto IL_0de6;
						case 77:
							goto IL_0e2f;
						case 79:
							goto IL_0e83;
						case 81:
							goto IL_0ee1;
						case 83:
							goto IL_0f3c;
						case 76:
						case 78:
						case 80:
						case 82:
						case 84:
						case 85:
						case 86:
							goto IL_0f8f;
						case 87:
							goto IL_0fbd;
						case 89:
							goto IL_1006;
						case 91:
							goto IL_105a;
						case 92:
							goto IL_1076;
						case 94:
							goto IL_10c8;
						case 97:
							goto IL_1131;
						case 99:
							goto IL_11a0;
						case 88:
						case 90:
						case 93:
						case 95:
						case 96:
						case 98:
						case 100:
						case 101:
						case 102:
							goto IL_11f3;
						case 103:
							goto IL_1243;
						case 105:
							goto IL_128c;
						case 107:
							goto IL_12e0;
						case 108:
							goto IL_12fc;
						case 110:
							goto IL_134e;
						case 113:
							goto IL_13b7;
						case 115:
							goto IL_1426;
						case 104:
						case 106:
						case 109:
						case 111:
						case 112:
						case 114:
						case 116:
						case 117:
						case 118:
							goto IL_1479;
						case 119:
							goto IL_14ce;
						case 120:
							goto IL_152a;
						case 121:
						case 122:
							goto IL_1588;
						case 123:
							goto IL_15b5;
						case 124:
							goto IL_15ec;
						case 125:
							goto IL_1620;
						case 126:
						case 127:
						case 128:
							goto IL_1686;
						case 129:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 130:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_15ec:
					num2 = 124;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 39]), "0.00");
					goto IL_1620;
					IL_1620:
					num2 = 125;
					val[val.Row, 40] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 38]) * (1.0 + Conversion.Val(val[val.Row, 39]) / 100.0)), "0.00");
					goto IL_1686;
					IL_15b5:
					num2 = 123;
					if (Conversion.Val(val[val.Row, 39]) != Conversion.Val(val[val.Row, 84]))
					{
						goto IL_15ec;
					}
					goto IL_1686;
					IL_1686:
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
					if (Conversion.Val(val[val.Row, 24]) == 0.0)
					{
						goto IL_0059;
					}
					goto IL_008c;
					IL_0059:
					num2 = 5;
					val[val.Row, 24] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_008c;
					IL_008c:
					num2 = 6;
					if (Conversion.Val(val[val.Row, 25]) == 0.0)
					{
						goto IL_00b2;
					}
					goto IL_00e5;
					IL_00b2:
					num2 = 7;
					val[val.Row, 25] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_00e5;
					IL_00e5:
					num2 = 8;
					if (Conversion.Val(val[val.Row, 26]) == 0.0)
					{
						goto IL_010b;
					}
					goto IL_0141;
					IL_010b:
					num2 = 9;
					val[val.Row, 26] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.000");
					goto IL_0141;
					IL_0141:
					num2 = 11;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 56]))
					{
						goto IL_0178;
					}
					goto IL_023e;
					IL_0178:
					num2 = 12;
					val[val.Row, 56] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_01ac;
					IL_01ac:
					num2 = 13;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_01f4;
					IL_01f4:
					num2 = 14;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_023e;
					IL_023e:
					num2 = 16;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_028a;
					}
					goto IL_02d4;
					IL_028a:
					num2 = 17;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_02d4;
					IL_02d4:
					num2 = 19;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 57]))
					{
						goto IL_030b;
					}
					goto IL_0454;
					IL_030b:
					num2 = 20;
					val[val.Row, 57] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_033f;
					IL_033f:
					num2 = 21;
					if ((Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_039f;
					}
					goto IL_041d;
					IL_039f:
					num2 = 22;
					val[val.Row, 26] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])) * (Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25])) / 100.0), "0.000");
					goto IL_0454;
					IL_041d:
					num2 = 24;
					val[val.Row, 26] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0454;
					IL_0454:
					num2 = 27;
					if ((Conversion.Val(val[val.Row, 22]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_04a0;
					}
					goto IL_04f4;
					IL_04a0:
					num2 = 28;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 22]) / 100.0), "0.000");
					goto IL_04f4;
					IL_04f4:
					num2 = 30;
					if (Conversion.Val(val[val.Row, 24]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_052b;
					}
					goto IL_063d;
					IL_052b:
					num2 = 31;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 24]), "0.00");
					goto IL_055f;
					IL_055f:
					num2 = 32;
					if ((Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_05bf;
					}
					goto IL_063d;
					IL_05bf:
					num2 = 33;
					val[val.Row, 26] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])) * (Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25])) / 100.0), "0.000");
					goto IL_063d;
					IL_063d:
					num2 = 36;
					if (Conversion.Val(val[val.Row, 25]) != Conversion.Val(val[val.Row, 61]))
					{
						goto IL_0674;
					}
					goto IL_0786;
					IL_0674:
					num2 = 37;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_06a8;
					IL_06a8:
					num2 = 38;
					if ((Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_0708;
					}
					goto IL_0786;
					IL_0708:
					num2 = 39;
					val[val.Row, 26] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])) * (Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25])) / 100.0), "0.000");
					goto IL_0786;
					IL_0786:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25]) == 0.0)
					{
						goto IL_07c1;
					}
					goto IL_080b;
					IL_07c1:
					num2 = 43;
					val[val.Row, 26] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])), "0.000");
					goto IL_080b;
					IL_080b:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0857;
					}
					goto IL_08a3;
					IL_0857:
					num2 = 46;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_08ff;
					IL_08a3:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 15]) == 0.0)
					{
						goto IL_08ca;
					}
					goto IL_08ff;
					IL_08ca:
					num2 = 49;
					val[val.Row, 15] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_08ff;
					IL_08ff:
					num2 = 51;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_0936;
					}
					goto IL_0a7f;
					IL_0936:
					num2 = 52;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_096a;
					IL_096a:
					num2 = 53;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_09ca;
					}
					goto IL_0a48;
					IL_09ca:
					num2 = 54;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0a7f;
					IL_0a48:
					num2 = 56;
					val[val.Row, 20] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_0a7f;
					IL_0a7f:
					num2 = 59;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_0ab6;
					}
					goto IL_0bc8;
					IL_0ab6:
					num2 = 60;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0aea;
					IL_0aea:
					num2 = 61;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_0b4a;
					}
					goto IL_0bc8;
					IL_0b4a:
					num2 = 62;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0bc8;
					IL_0bc8:
					num2 = 65;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_0bff;
					}
					goto IL_0d11;
					IL_0bff:
					num2 = 66;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_0c33;
					IL_0c33:
					num2 = 67;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_0c93;
					}
					goto IL_0d11;
					IL_0c93:
					num2 = 68;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0d11;
					IL_0d11:
					num2 = 71;
					if (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) == 0.0)
					{
						goto IL_0d4c;
					}
					goto IL_0d96;
					IL_0d4c:
					num2 = 72;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])), "0.000");
					goto IL_0d96;
					IL_0d96:
					num2 = 74;
					if ((Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 26]) != 0.0))
					{
						goto IL_0de6;
					}
					goto IL_0f8f;
					IL_0de6:
					num2 = 75;
					switch (val[val.Row, 47])
					{
					case "P":
						break;
					case "1":
						goto IL_0e83;
					case "K":
						goto IL_0ee1;
					default:
						goto IL_0f3c;
					}
					goto IL_0e2f;
					IL_0f3c:
					num2 = 83;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 26]) * Conversion.Val(val[val.Row, 36]), 0), "0.00");
					goto IL_0f8f;
					IL_0ee1:
					num2 = 81;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 26]) * (Conversion.Val(val[val.Row, 36]) / 1000.0), 0), "0.00");
					goto IL_0f8f;
					IL_0e83:
					num2 = 79;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 26]) * (Conversion.Val(val[val.Row, 36]) / 10.0), 0), "0.00");
					goto IL_0f8f;
					IL_0e2f:
					num2 = 77;
					val[val.Row, 37] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 36]), 0), "0.00");
					goto IL_0f8f;
					IL_0f8f:
					num2 = 86;
					if (Conversion.Val(val[val.Row, 29]) != 0.0)
					{
						goto IL_0fbd;
					}
					goto IL_11f3;
					IL_0fbd:
					num2 = 87;
					switch (val[val.Row, 28])
					{
					case "P":
						break;
					case "N":
						goto IL_105a;
					case "K":
						goto IL_1131;
					default:
						goto IL_11a0;
					}
					goto IL_1006;
					IL_11a0:
					num2 = 99;
					val[val.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 29]), 0), "0.00");
					goto IL_11f3;
					IL_1131:
					num2 = 97;
					val[val.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])) * (Conversion.Val(val[val.Row, 29]) / 1000.0), 0), "0.00");
					goto IL_11f3;
					IL_105a:
					num2 = 91;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1076;
					}
					goto IL_10c8;
					IL_1076:
					num2 = 92;
					val[val.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 29]), 0), "0.00");
					goto IL_11f3;
					IL_10c8:
					num2 = 94;
					val[val.Row, 30] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 23])) * Conversion.Val(val[val.Row, 29]), 0), "0.00");
					goto IL_11f3;
					IL_1006:
					num2 = 89;
					val[val.Row, 30] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 29]), 0), "0.00");
					goto IL_11f3;
					IL_11f3:
					num2 = 102;
					if ((Conversion.Val(val[val.Row, 32]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_1243;
					}
					goto IL_1479;
					IL_1243:
					num2 = 103;
					switch (val[val.Row, 28])
					{
					case "P":
						break;
					case "N":
						goto IL_12e0;
					case "K":
						goto IL_13b7;
					default:
						goto IL_1426;
					}
					goto IL_128c;
					IL_1426:
					num2 = 115;
					val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
					goto IL_1479;
					IL_13b7:
					num2 = 113;
					val[val.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 32]) / 1000.0), 0), "0.00");
					goto IL_1479;
					IL_12e0:
					num2 = 107;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_12fc;
					}
					goto IL_134e;
					IL_12fc:
					num2 = 108;
					val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
					goto IL_1479;
					IL_134e:
					num2 = 110;
					val[val.Row, 33] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
					goto IL_1479;
					IL_128c:
					num2 = 105;
					val[val.Row, 33] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 32]), 0), "0.00");
					goto IL_1479;
					IL_1479:
					num2 = 118;
					if (Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 37]) != 0.0)
					{
						goto IL_14ce;
					}
					goto IL_1588;
					IL_14ce:
					num2 = 119;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 37])), "0.00");
					goto IL_152a;
					IL_152a:
					num2 = 120;
					val[val.Row, 38] = Strings.Format((object)(Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 34]) + Conversion.Val(val[val.Row, 37])), "0.00");
					goto IL_1588;
					IL_1588:
					num2 = 122;
					if (Conversion.Val(val[val.Row, 38]) != 0.0)
					{
						goto IL_15b5;
					}
					goto IL_1686;
					end_IL_0001_2:
					break;
				}
				num2 = 129;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 6322;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TEXT_ENTRY_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Invalid comparison between Unknown and I4
		//IL_0cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Invalid comparison between Unknown and I4
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Invalid comparison between Unknown and I4
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cda: Invalid comparison between Unknown and I4
		//IL_0cec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Invalid comparison between Unknown and I4
		//IL_0d40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d43: Invalid comparison between Unknown and I4
		//IL_0667: Unknown result type (might be due to invalid IL or missing references)
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbf: Invalid comparison between Unknown and I4
		//IL_09dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e41: Invalid comparison between Unknown and I4
		//IL_0b86: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ecd: Invalid comparison between Unknown and I4
		//IL_1048: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_189d: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a3: Invalid comparison between Unknown and I4
		//IL_2705: Unknown result type (might be due to invalid IL or missing references)
		//IL_0430: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1110: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bce: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd8: Expected O, but got Unknown
		//IL_1cd1: Unknown result type (might be due to invalid IL or missing references)
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
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 46]));
					List<DataRow> list = new List<DataRow>();
					DC_Main.ExeQuteDc(("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 0]))) ?? "");
					DC_Main.ExeQuteDc(("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 0]))) ?? "");
					RowDelete = true;
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][31])) == Conversion.Val(mSG[mSG.Row, 46]))
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
							mSG[mSG.Row, 46] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 46] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 46]) + 1.0);
						}
					}
					mSG[mSG.Row, 51] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + MsVchSrno;
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 2)
			{
				ItCodeLock = false;
			}
			if (mSG.Col == 5)
			{
				if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT  IT_DESIGN as DesignL From ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' GROUP BY IT_DESIGN ORDER BY IT_DESIGN";
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
				DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 2] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
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
					TEXT_ENTRY.Text = DC_Main.ColValue[0];
					mSG[mSG.Row, 5] = DC_Main.ColValue[0];
					mSG[mSG.Row, 7] = DC_Main.ColValue[3];
					mSG[mSG.Row, 44] = DC_Main.ColValue[4];
					if (Operators.CompareString(mSG[mSG.Row, 53], "E", false) != 0)
					{
						if (Conversion.Val(DC_Main.ColValue[5]) != 0.0)
						{
							mSG[mSG.Row, 24] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
						{
							mSG[mSG.Row, 25] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
						{
							mSG[mSG.Row, 27] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
						{
							mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
						}
					}
					mSG[mSG.Row, 83] = DC_Main.ColValue[9];
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				else
				{
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 5] = "";
					mSG[mSG.Row, 83] = "N";
				}
				((Control)TEXT_ENTRY).Focus();
				return;
			}
			if (mSG.Col == 11 && Conversion.Val(nHmWt.Text) != 0.0)
			{
				TEXT_ENTRY.Text = Conversions.ToString(Conversion.Val(nHmWt.Text) + Conversion.Val(nHmWt2.Text) + Conversion.Val(nHmWt3.Text) + Conversion.Val(nHmWt4.Text));
			}
			if (mSG.Col == 44)
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
						mSG[mSG.Row, 44] = DC_Main.ColValue[1];
					}
					((Control)TEXT_ENTRY).Focus();
				}
				return;
			}
			if (mSG.Col == 1)
			{
				DC_Main.RsQry = "SELECT A.ISU_AC_NAME as CustNameL,A.ISU_NO As VchNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE as SizeL,A.ISU_SRNO AS SrNoM,A.ISU_YRCD As YearL,A.ISU_DBCD As BookL,A.ISU_AC_CODE,C.AC_NAME As KrgrL,A.IT_CODE as ItCodeL,C.AC_SHORT As AcShortL,A.ISU_LC_CODE As OrdLcM FROM (APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_BOOK = '051' AND A.ISU_REC = 'N' AND A.ISU_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[15];
				DC_Main.ColWidth[0] = 250.0;
				DC_Main.ColWidth[1] = 80.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 180.0;
				DC_Main.ColWidth[4] = 200.0;
				DC_Main.ColWidth[5] = 80.0;
				DC_Main.ColWidth[6] = 60.0;
				DC_Main.ColWidth[7] = 100.0;
				DC_Main.ColWidth[8] = 70.0;
				DC_Main.ColWidth[9] = 0.0;
				DC_Main.ColWidth[10] = 125.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.ColWidth[13] = 60.0;
				DC_Main.HelpSelect = 1;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (!DC_Main.HelpClose)
				{
					if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[1];
						mSG[mSG.Row, 2] = DC_Main.ColValue[11];
						mSG[mSG.Row, 74] = DC_Main.ColValue[6];
						mSG[mSG.Row, 75] = DC_Main.ColValue[7];
						mSG[mSG.Row, 76] = DC_Main.ColValue[8];
						mSG[mSG.Row, 77] = DC_Main.ColValue[0];
						mSG[mSG.Row, 78] = DC_Main.ColValue[9];
						mSG[mSG.Row, 79] = DC_Main.ColValue[13];
						mSG[mSG.Row, 5] = DC_Main.ColValue[2];
						mSG[mSG.Row, 7] = DC_Main.ColValue[5];
						mSG[mSG.Row, 44] = DC_Main.ColValue[12];
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
				if (Operators.CompareString(mSG[mSG.Row, mSG.Col], TEXT_ENTRY.Text, false) != 0)
				{
					MsTxtDelete = true;
				}
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
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[1];
								if (Operators.CompareString(DC_Main.SSRegSrNo, "VK217NEVK", false) != 0 && ((Operators.CompareString(mSG[mSG.Row, 53], "E", false) == 0) & (Operators.CompareString(Strings.Mid(TEXT_ENTRY.Text, 1, 2), Strings.Mid(mSG[mSG.Row, 2], 1, 2), false) != 0)))
								{
									if (ItCodeLock)
									{
										Interaction.MsgBox((object)"You Cant Change ItCode In Edit Mode Please Tag Transfer And Generate New Tag...", (MsgBoxStyle)0, (object)null);
										TEXT_ENTRY.Text = mSG[mSG.Row, 2];
										((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
										((Control)TEXT_ENTRY).Focus();
										return;
									}
									ItCodeLock = true;
								}
								mSG[mSG.Row, 2] = DC_Main.ColValue[1];
								mSG[mSG.Row, 52] = DC_Main.ColValue[0];
								mSG[mSG.Row, 50] = DC_Main.ColValue[3];
								mSG[mSG.Row, 48] = DC_Main.ColValue[4];
								mSG[mSG.Row, 49] = DC_Main.ColValue[5];
								mSG[mSG.Row, 54] = "";
								mSG[mSG.Row, 55] = "";
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 49] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						object Value;
						DataRow dataRow;
						if (mSG[9] != 0 && ((Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)))
						{
							AxMSFlexGrid obj2 = mSG;
							int row = mSG.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_BAG_WT"]);
							double num4 = DC_Main.Fnv(ref Value);
							dataRow["IT_BAG_WT"] = RuntimeHelpers.GetObjectValue(Value);
							obj2[row, 9] = Strings.Format((object)num4, "0.000");
						}
						if ((Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0) & (mSG.Row == mSG.Rows - 1) & (Operators.CompareString(mSG[mSG.Row, 47], "P", false) == 0))
						{
							mSG[mSG.Row, 28] = "P";
						}
						else if (Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0)
						{
							mSG[mSG.Row, 28] = DC_Main.MsLbrType;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 49], mSG[mSG.Row, 54], false) != 0) | (Operators.CompareString(mSG[mSG.Row, 50], mSG[mSG.Row, 55], false) != 0))
						{
							mSG[mSG.Row, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 3] = "";
							mSG[mSG.Row, 45] = "";
						}
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						if (Operators.CompareString(mSG[mSG.Row, 53], "A", false) != 0)
						{
							break;
						}
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
						if ((num5 != 0.0) & (Conversion.Val(mSG[mSG.Row, 29]) == 0.0))
						{
							AxMSFlexGrid obj3 = mSG;
							int row2 = mSG.Row;
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["IT_LBR_RATE"]);
							double num6 = DC_Main.Fnv(ref Value);
							dataRow["IT_LBR_RATE"] = RuntimeHelpers.GetObjectValue(Value);
							obj3[row2, 29] = Strings.Format((object)num6, "0.00");
						}
						if (mSG[27] != 0)
						{
							Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
							double num7 = DC_Main.Fnv(ref Value);
							dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
							if ((num7 != 0.0) & (Conversion.Val(mSG[mSG.Row, 27]) == 0.0))
							{
								AxMSFlexGrid obj4 = mSG;
								int row3 = mSG.Row;
								Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["LBR_PRC"]);
								double num8 = DC_Main.Fnv(ref Value);
								dataRow["LBR_PRC"] = RuntimeHelpers.GetObjectValue(Value);
								obj4[row3, 27] = Strings.Format((object)num8, "0.00");
							}
						}
						break;
					}
					case 5:
						if ((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 5], "", false) != 0))
						{
							mSG[mSG.Row, 83] = "N";
							MsgOldRow = 0;
						}
						if (Operators.CompareString(DC_Main.MsDesignMastHelp, "Y", false) == 0)
						{
							if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row - 1, 5], false) != 0)))
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
								if (Conversion.Val(mSG[mSG.Row, 29]) == 0.0)
								{
									mSG[mSG.Row, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
								}
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])) == 0.0)
								{
									mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
								}
							}
						}
						else
						{
							if (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row - 1, 5], false) != 0)
							{
								break;
							}
							mSG[mSG.Row, 83] = mSG[mSG.Row - 1, 83];
							if (Operators.CompareString(mSG[mSG.Row - 1, 83], "N", false) == 0)
							{
								break;
							}
							DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 83] + "' AND IMAGE_TYPE = 'D'";
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
						}
						break;
					case 43:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND EMP_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT EMP_NAME As EmpNameL,EMP_CODE as CodeL  FROM EMP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY EMP_CODE";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[3];
							DC_Main.ColWidth[0] = 300.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[1];
									mSG[mSG.Row, 43] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["EMP_CODE"], (object)""));
						break;
					case 4:
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
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 8:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0)
						{
							mSG[mSG.Row, 8] = TEXT_ENTRY.Text;
							((Control)nHmWt).Focus();
							return;
						}
						break;
					case 11:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(MSG[MSG.Row, 47], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && ((Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)) && mSG.Row == mSG.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 5], "", false) == 0, (object)" AND IT_DESIGN = 'N' ", (object)("AND IT_DESIGN = '" + mSG[mSG.Row, 5] + "'"))), (object)" AND FROM_WT <= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)" AND TO_WT >= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)""));
							}
							else
							{
								DC_Main.RsQry = ("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' AND FROM_WT <= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " AND TO_WT >= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text))) ?? "";
							}
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CODE"], (object)""), (object)"", false))
								{
									mSG[mSG.Row, 29] = "";
									mSG[mSG.Row, 30] = "";
									mSG[mSG.Row, 27] = "";
									mSG[mSG.Row, 22] = "";
									mSG[mSG.Row, 25] = "";
									mSG[mSG.Row, 40] = "";
									mSG[mSG.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CODE"], (object)""));
								}
								else
								{
									if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["LBR_TYPE"], (object)"F", false))
									{
										mSG[mSG.Row, 29] = "";
										mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_RATE"]), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["LBR_TYPE"], (object)"G", false))
									{
										mSG[mSG.Row, 28] = "G";
										mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_RATE"]), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["LBR_TYPE"], (object)"K", false))
									{
										mSG[mSG.Row, 28] = "G";
										mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_RATE"]), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable.Rows[0]["LBR_TYPE"], (object)"P", false))
									{
										mSG[mSG.Row, 28] = "P";
										mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_RATE"]), "0.00");
									}
									else
									{
										mSG[mSG.Row, 28] = "N";
										mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_RATE"]), "0.00");
									}
									mSG[mSG.Row, 27] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_PRC"]), "0.00");
									mSG[mSG.Row, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["GHT_PRC"]), "0.00");
								}
							}
						}
						mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 21:
					{
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						string text = mSG[mSG.Row, 21];
						DC_Main.RsQry = "Select * From LBR_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LBR_CODE = '" + TEXT_ENTRY.Text + "'";
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
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									text2 = Strings.Mid(DC_Main.ColValue[0], 1, 2);
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						if (Operators.CompareString(text, TEXT_ENTRY.Text, false) != 0)
						{
							mSG[mSG.Row, 29] = "";
							mSG[mSG.Row, 30] = "";
							mSG[mSG.Row, 27] = "";
							mSG[mSG.Row, 22] = "";
							mSG[mSG.Row, 25] = "";
							mSG[mSG.Row, 40] = "";
						}
						text2 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG[mSG.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text2)
						{
						case "01":
							mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG[mSG.Row, 27] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG[mSG.Row, 29] = "";
							mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG[mSG.Row, 25] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "05":
							mSG[mSG.Row, 22] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG[mSG.Row, 28] = "K";
							mSG[mSG.Row, 29] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG[mSG.Row, 40] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal();
						break;
					}
					case 6:
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
					case 41:
						if (Operators.CompareString(TEXT_ENTRY.Text, "Y", false) == 0)
						{
							DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
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
					case 44:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 44] = TEXT_ENTRY.Text;
							if (Operators.CompareString(DC_Main.MsTagRpt, "Y", false) == 0 && Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG[mSG.Row, 3] + "','" + mSG[mSG.Row, 51] + "','" + mSG[mSG.Row, 49] + "','" + mSG[mSG.Row, 50] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							if (Operators.CompareString(Module_Save.MsRendomTag, "Y", false) == 0)
							{
								DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,CO_BOOK,VCH_NO,TAG_NO,VCH_SRNO,TAG_TYPE,PR_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + mSG[mSG.Row, 3] + "','" + mSG[mSG.Row, 51] + "','" + mSG[mSG.Row, 49] + "','" + mSG[mSG.Row, 50] + "')";
								DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							}
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							mSG.Col = 2;
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

	private void RepitTagNo(int Y)
	{
		double num = 0.0;
		if (Operators.CompareString(OldTagItm, MSG[Y, 50] + MSG[Y, 49], false) != 0)
		{
			OldTagItm = MSG[Y, 50] + MSG[Y, 49];
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
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 49] + "' AND  B.PR_CODE = '" + MSG[Y, 50] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 50]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 49]), (object)"'"));
				}
				else
				{
					DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 49] + "' AND  B.PR_CODE = '" + MSG[Y, 50] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 7 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO  ";
				}
			}
			else if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 49] + "' AND  B.PR_CODE = '" + MSG[Y, 50] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 50]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 49]), (object)"'"));
			}
			else if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 49] + "' AND  B.PR_CODE = '" + MSG[Y, 50] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO   UNION ALL SELECT '" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',TAG_TYPE,PR_CODE,0,TAG_NO,"), Interaction.IIf(Operators.CompareString(DC_Main.MsTagVchAutoSave, "Y", false) == 0, (object)"'OLD'", (object)("'" + DC_Main.MCo_Book + "'"))), (object)" FROM BAR_DETL WHERE CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND CO_BOOK = '"), (object)DC_Main.MCo_Book), (object)"' AND VCH_NO = '"), (object)tVchNo.Text), (object)"' AND PR_CODE = '"), (object)MSG[Y, 50]), (object)"' AND TAG_TYPE = '"), (object)MSG[Y, 49]), (object)"'"));
			}
			else
			{
				DC_Main.RsQry = "INSERT INTO TAG_SET(CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,VCH_SRNO,TAG_NO,CO_BOOK)  Select CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,0,TAG_NO,'OLD' FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> 'N' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND TAG_NO IN(SELECT TAG_NO From MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.TAG_TYPE = '" + MSG[Y, 49] + "' AND  B.PR_CODE = '" + MSG[Y, 50] + "' AND A.IT_CODE <> ''  AND A.TAG_NO <> 'N' AND LEN(A.TAG_NO) = 8 AND A.CO_BOOK NOT IN ('018','019') GROUP BY A.TAG_NO HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0) GROUP BY CO_CODE,LC_CODE,TAG_TYPE,PR_CODE,TAG_NO  ";
			}
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		checked
		{
			DataTable dataTable;
			DataTable dataTable2;
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,4) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG[Y, 49] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "0001";
					int num2 = 1;
					int num3 = 0;
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND  PR_CODE = '" + MSG[Y, 50] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND  PR_CODE = '" + MSG[Y, 50] + "' AND LEN(TAG_NO) = 7 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
				DC_Main.RsQry = "SELECT TAG_NO,SUBSTRING(TAG_NO,4,5) AS SrNo FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + MSG[Y, 50] + "' AND TAG_NO <> '' AND TAG_TYPE = '" + MSG[Y, 49] + "' ORDER BY TAG_SRNO DESC";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count == 0)
				{
					CurRptTagNo = "00001";
					int num2 = 1;
					int num3 = 0;
					num = 0.0;
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND  PR_CODE = '" + MSG[Y, 50] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
					DC_Main.RsQry = "SELECT TAG_NO FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_TYPE = '" + MSG[Y, 49] + "' AND  PR_CODE = '" + MSG[Y, 50] + "' AND LEN(TAG_NO) = 8 GROUP BY TAG_NO ORDER BY TAG_NO  ";
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
			MSG[Y, 45] = Conversions.ToString(Conversion.Val(CurRptTagNo));
			MSG[Y, 3] = MSG[Y, 50] + MSG[Y, 49] + CurRptTagNo;
			TEXT_ENTRY.Text = MSG[Y, 3];
			dataTable.Clear();
			dataTable.Columns.Clear();
			dataTable2.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void LotNoGen(int Y)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		DC_Main.RsQry = "SELECT RIGHT(A.LOT_NO,5) AS TAG_SRNO FROM LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.PR_CODE = '" + mSG_PR[Y, 64] + "' AND LEN(A.LOT_NO) > 4 AND TRY_CAST(RIGHT(A.LOT_NO,5) AS INT) IS NOT NULL GROUP BY RIGHT(A.LOT_NO,5) ORDER BY RIGHT(A.LOT_NO,5) DESC";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((dataTable.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "00000") : "00001");
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 5], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 64], mSG_PR[Y, 64], false) == 0) & (Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 5], 5)) >= Conversion.Val(text))) && Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 5], 5)) + 1.0 > Conversion.Val(text))
				{
					text = Strings.Format((object)(Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 5], 5)) + 1.0), "00000");
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[Y, 5] = mSG_PR[Y, 64] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + text;
			}
			else
			{
				mSG_PR[Y, 5] = mSG_PR[Y, 64] + text;
			}
			TEXT_PR.Text = mSG_PR[Y, 5];
			mSG_PR = null;
			dataTable.Clear();
		}
	}

	private void ItmLotGen(int Y)
	{
		AxMSFlexGrid mSG_PR = MSG_PR;
		DC_Main.RsQry = "SELECT RIGHT(A.LOT_NO,4) AS TAG_SRNO FROM ITM_LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.PR_CODE = '" + mSG_PR[Y, 64] + "' AND SUBSTRING(LOT_NO,5,1) = '" + Strings.Mid(DC_Main.MCo_year, 4, 1) + "' GROUP BY RIGHT(A.LOT_NO,4) ORDER BY RIGHT(A.LOT_NO,4) DESC";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((dataTable.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "0000") : "0001");
		checked
		{
			int num = mSG_PR.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG_PR[Y, 6], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG_PR[DC_Main.i, 64], mSG_PR[Y, 64], false) == 0) & (Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 5)) >= Conversion.Val(text))) && Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 4)) + 1.0 > Conversion.Val(text))
				{
					text = Strings.Format((object)(Conversion.Val(Strings.Right(mSG_PR[DC_Main.i, 6], 4)) + 1.0), "0000");
				}
				DC_Main.i++;
			}
			string text2 = mSG_PR[Y, 64];
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 64] + Strings.Mid(mVchDate.Text, 4, 2) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + text;
			}
			else
			{
				mSG_PR[Y, 6] = mSG_PR[Y, 64] + Strings.Mid(mVchDate.Text, 4, 2) + Strings.Mid(DC_Main.MCo_year, 4, 1) + text;
			}
			TEXT_PR.Text = mSG_PR[Y, 6];
			mSG_PR = null;
			dataTable.Clear();
		}
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(MSG[Y, 50], "", false) == 0)
		{
			return;
		}
		string text = MSG[Y, 50];
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0) & (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0))
		{
			DC_Main.NewYearTagGen(MSG[Y, 50], MSG[Y, 49]);
			MSG[Y, 3] = DC_Main.MsNewTagNo;
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
				tagPrefix = MSG[Y, 50] + MSG[Y, 49];
			}
			string text2 = Module_Save.RendomTagGen(DC_Main.MCo_Book, tagPrefix);
			if (Operators.CompareString(text2, "", false) != 0)
			{
				MSG[Y, 3] = text2;
				TEXT_ENTRY.Text = text2;
			}
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if (Operators.CompareString(DC_Main.MsLastYearTagSires, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG[Y, 50] + "'  AND TAG_TYPE = '" + mSG[Y, 49] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=9  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG[Y, 50] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG[Y, 49] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
			else
			{
				DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG[Y, 50] + "'  AND TAG_TYPE = '" + mSG[Y, 49] + "'  AND LEN(TAG_NO) > 6 AND  LEN(TAG_NO) <=10  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG[Y, 50] + "' AND LEN(A.TAG_NO) > 6 AND LEN(A.TAG_NO) < =9 AND B.TAG_TYPE = '" + mSG[Y, 49] + "' ) AS X GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
			}
		}
		else if ((Operators.CompareString(DC_Main.MCo_Type, "", false) != 0) & (Operators.CompareString(DC_Main.MCo_Type, "P", false) != 0))
		{
			DC_Main.RsQry = "Select SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) As TAG_SRNO FROM SRNO_MAST As A LEFT JOIN ITEM_MAST As B On A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG[Y, 50] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG[Y, 49] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
		}
		else
		{
			DC_Main.RsQry = "SELECT TOP 2 TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG[Y, 50] + "'  AND TAG_TYPE = '" + mSG[Y, 49] + "' GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
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
					CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
				}
				else
				{
					CurTagNo = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[1]["TAG_SRNO"], (object)"")) + 1.0), "0000");
				}
			}
			else
			{
				CurTagNo = Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "0000");
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
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "0000");
		}
		else
		{
			CurTagNo = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TAG_SRNO"])) + 1.0), "00000");
		}
		checked
		{
			int num = mSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG[Y, 3], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG[DC_Main.i, 50], mSG[Y, 50], false) == 0) & (Operators.CompareString(mSG[DC_Main.i, 49], mSG[Y, 49], false) == 0) & (Conversion.Val(mSG[DC_Main.i, 45]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG[DC_Main.i, 45]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 45]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 45]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG[mSG.Row, 45] = CurTagNo;
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG[mSG.Row, 3] = mSG[Y, 50] + mSG[Y, 49] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG[mSG.Row, 3] = mSG[Y, 50] + mSG[Y, 49] + CurTagNo;
			}
			mSG = null;
			dataTable.Clear();
		}
	}

	private void TR_PURC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_1a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a95: Expected O, but got Unknown
		//IL_1aba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ac9: Expected O, but got Unknown
		//IL_1aee: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1afd: Expected O, but got Unknown
		//IL_1b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b31: Expected O, but got Unknown
		//IL_1b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b65: Expected O, but got Unknown
		//IL_1ba4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb3: Expected O, but got Unknown
		//IL_1bcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bdc: Expected O, but got Unknown
		//IL_1bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Expected O, but got Unknown
		//IL_1c1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c24: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c2e: Expected O, but got Unknown
		//IL_1c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c57: Expected O, but got Unknown
		//IL_1c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c76: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c80: Expected O, but got Unknown
		//IL_1c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca9: Expected O, but got Unknown
		//IL_1cd1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd8: Expected O, but got Unknown
		//IL_1dae: Unknown result type (might be due to invalid IL or missing references)
		//IL_1db3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dbd: Expected O, but got Unknown
		//IL_1e45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e54: Expected O, but got Unknown
		//IL_1eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef8: Expected O, but got Unknown
		//IL_1f85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f90: Expected O, but got Unknown
		//IL_201b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2020: Unknown result type (might be due to invalid IL or missing references)
		//IL_2026: Expected O, but got Unknown
		//IL_20ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_20b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_20bd: Expected O, but got Unknown
		//IL_20e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_20e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_20f1: Expected O, but got Unknown
		//IL_211e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2128: Expected O, but got Unknown
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
			foreach (object control4 in ((Control)PnlPrIdtl).Controls)
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
			foreach (object control5 in ((Control)PnlUpdate).Controls)
			{
				object objectValue4 = RuntimeHelpers.GetObjectValue(control5);
				object obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue4;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue4, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			foreach (object control6 in ((Control)pnlBill).Controls)
			{
				object objectValue5 = RuntimeHelpers.GetObjectValue(control6);
				object obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue5;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue5, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Control)MSG_TOT).Top = ((Control)MSG).Bottom + 1;
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				((Form)this).BackColor = Color.Silver;
				((Control)PnlPrIdtl).BackColor = Color.Silver;
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
				AxMSFlexGrid mSG_PR_IDTL = MSG_PR_IDTL;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL2 = MSG_PR_IDTL;
				object? obj25 = colorConverter.ConvertFromString("DarkGray");
				mSG_PR_IDTL2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL3 = MSG_PR_IDTL;
				object? obj26 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_PR_IDTL3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
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
				Panel pnlPrIdtl = PnlPrIdtl;
				object? obj31 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlPrIdtl).BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				Panel pnlUpdate = PnlUpdate;
				object? obj32 = colorConverter.ConvertFromString("200, 205, 210");
				((Control)pnlUpdate).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj35 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj36 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj38 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj39 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj41 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj42 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG_PR4 = MSG_PR;
				object? obj43 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR4.BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_PR5 = MSG_PR;
				object? obj44 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR5.BackColorBkg = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_PR6 = MSG_PR;
				object? obj45 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR6.BackColorFixed = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_PR_TOT4 = MSG_PR_TOT;
				object? obj46 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT4.BackColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_PR_TOT5 = MSG_PR_TOT;
				object? obj47 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT5.BackColorBkg = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_PR_TOT6 = MSG_PR_TOT;
				object? obj48 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_PR_TOT6.BackColorFixed = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL4 = MSG_PR_IDTL;
				object? obj49 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL4.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL5 = MSG_PR_IDTL;
				object? obj50 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_PR_IDTL5.BackColorBkg = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL6 = MSG_PR_IDTL;
				object? obj51 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_PR_IDTL6.BackColorFixed = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj52 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj53 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj54 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj54 != null) ? ((Color)obj54) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj55 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj55 != null) ? ((Color)obj55) : default(Color));
				Panel pnlPrIdtl2 = PnlPrIdtl;
				object? obj56 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlPrIdtl2).BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj57 = lblBook;
				object? obj58 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj57).ForeColor = ((obj58 != null) ? ((Color)obj58) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj59 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
				Panel pnlUpdate2 = PnlUpdate;
				object? obj60 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)pnlUpdate2).BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
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
				AxMSFlexGrid mSG_PR7 = MSG_PR;
				object? obj70 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR7.BackColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
				AxMSFlexGrid mSG_PR8 = MSG_PR;
				object? obj71 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR8.BackColorBkg = ((obj71 != null) ? ((Color)obj71) : default(Color));
				AxMSFlexGrid mSG_PR9 = MSG_PR;
				object? obj72 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR9.BackColorFixed = ((obj72 != null) ? ((Color)obj72) : default(Color));
				AxMSFlexGrid mSG_PR_TOT7 = MSG_PR_TOT;
				object? obj73 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT7.BackColor = ((obj73 != null) ? ((Color)obj73) : default(Color));
				AxMSFlexGrid mSG_PR_TOT8 = MSG_PR_TOT;
				object? obj74 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT8.BackColorBkg = ((obj74 != null) ? ((Color)obj74) : default(Color));
				AxMSFlexGrid mSG_PR_TOT9 = MSG_PR_TOT;
				object? obj75 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_PR_TOT9.BackColorFixed = ((obj75 != null) ? ((Color)obj75) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL7 = MSG_PR_IDTL;
				object? obj76 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_PR_IDTL7.BackColor = ((obj76 != null) ? ((Color)obj76) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL8 = MSG_PR_IDTL;
				object? obj77 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_PR_IDTL8.BackColorBkg = ((obj77 != null) ? ((Color)obj77) : default(Color));
				AxMSFlexGrid mSG_PR_IDTL9 = MSG_PR_IDTL;
				object? obj78 = colorConverter.ConvertFromString("Cornsilk");
				mSG_PR_IDTL9.BackColorFixed = ((obj78 != null) ? ((Color)obj78) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj79 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj79 != null) ? ((Color)obj79) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj80 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj80 != null) ? ((Color)obj80) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj81 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj81 != null) ? ((Color)obj81) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj82 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj82 != null) ? ((Color)obj82) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_PR).AutoSize = false;
				((TextBoxBase)TEXT_PR_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_PR).Font = new Font(((Control)TEXT_PR).Font.FontFamily, (float)num3, ((Control)TEXT_PR).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_PR_IDTL).Font = new Font(((Control)TEXT_PR_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_PR_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_PR.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_PR_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_PR_IDTL.Font.Style);
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_IDTL.Font = new Font("Segoe UI Semibold", (float)num3, MSG_IDTL.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control7 in ((Control)this).Controls)
					{
						Control val3 = control7;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_PR_IDTL", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY_2", false) != 0)))
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
					foreach (object control8 in ((Control)PnlBotam).Controls)
					{
						object objectValue6 = RuntimeHelpers.GetObjectValue(control8);
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue6, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkBillImage", false))
						{
							NewLateBinding.LateSet(objectValue6, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
						}
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				Font font3 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control9 in ((Control)PnlUpdate).Controls)
					{
						object objectValue7 = RuntimeHelpers.GetObjectValue(control9);
						NewLateBinding.LateSet(objectValue7, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				Font font4 = ((Control)UAdd1).Font;
				try
				{
					foreach (object control10 in ((Control)PanelAdd).Controls)
					{
						object objectValue8 = RuntimeHelpers.GetObjectValue(control10);
						NewLateBinding.LateSet(objectValue8, (Type)null, "Font", new object[1] { (object)new Font(font4.FontFamily, (float)num3, font4.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font4)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkBillImage).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
				if (DC_Main.ScreenHight > 1.0)
				{
					MSG_PR_TOT.ScrollBars = (ScrollBarsSettings)0;
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
			DC_Main.RsQry = "SELECT DATA_TYPE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				BookDataType = Conversions.ToString(DC_Main.Tbl.Rows[0]["DATA_TYPE"]);
			}
			if (Operators.CompareString(FormItmType, "", false) == 0)
			{
				FormItmType = "A";
			}
			if (Operators.CompareString(DC_Main.CurBookVch, "", false) != 0)
			{
				FormVchNo = DC_Main.CurBookVch;
			}
			if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				TblData = "KR_DATA";
				TblDetl = "KR_DETL";
				TblIdtl = "KR_IDTL";
				if ((Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
				{
					((Control)chkBillImage).Visible = true;
				}
				((Control)Label5).Visible = false;
				((Control)tSlBill).Visible = false;
				((Control)tSlBill_DbCd).Visible = false;
			}
			else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				TblData = "KR_DATA";
				TblDetl = "KR_DETL";
				TblIdtl = "KR_IDTL";
				((Control)Label5).Visible = false;
				((Control)tSlBill).Visible = false;
				((Control)tSlBill_DbCd).Visible = false;
				((Control)cboItemTyp).Visible = true;
				((Control)Label12).Visible = true;
				((Control)Label14).Visible = true;
				((Control)nPartyFine).Visible = true;
				((Control)lblOldFine).Visible = true;
			}
			else
			{
				if ((Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM099NSKU", false) == 0))
				{
					((Control)chkBillImage).Visible = true;
				}
				TblData = "PR_DATA";
				TblDetl = "PR_DETL";
				TblIdtl = "PR_IDTL";
				if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && Operators.CompareString(FormMainBook, "PR QUOT", false) != 0)
				{
					((Control)btnQuot).Visible = true;
				}
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
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
		DataTrfr = "N";
		lblItem.Text = "Item Name";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		chkWapp.Checked = false;
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		((Control)PanelAdd).Visible = false;
		((Control)PnlPrIdtl).Visible = false;
		QtDbCd = "";
		QtNo = "";
		UAdd1.Text = "";
		UAdd2.Text = "";
		UAdd3.Text = "";
		UCity.Text = "";
		UGstNo.Text = "";
		UMobile.Text = "";
		picAc.Image = null;
		RowDelete = false;
		((Control)PnlUpdate).Visible = false;
		picAc.Image = null;
		OldTdsPrc = 0.0;
		LInkVchDelete = false;
		ItCodeLock = true;
		if (VchOldData != null)
		{
			VchOldData.Clear();
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
		OldValTot = 0.0;
		NewValTot = 0.0;
		PrOthAmtLess = 0.0;
		OldNetAmt = 0.0;
		StkRow = 0;
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			tAcCode.Text = "00045";
		}
		else if (Operators.CompareString(FormMainBook, "PURCHASE", false) == 0)
		{
			if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ004NPKJ", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0) | (Operators.CompareString(DC_Main.MsCashPurcAc, "Y", false) == 0))
			{
				tAcCode.Text = "00050";
				tAcName.Text = "CASH PURCHASE A/C";
			}
			string mCo_Book = DC_Main.MCo_Book;
			if (Operators.CompareString(mCo_Book, "037", false) == 0 || Operators.CompareString(mCo_Book, "038", false) == 0)
			{
				tAcCode.Text = "00050";
				tAcName.Text = "CASH PURCHASE A/C";
			}
		}
		AcGstType = "L";
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		PicImage.Image = null;
		PicBill.Image = null;
		chkBillImage.Checked = false;
		((Control)pnlBill).Visible = false;
		DC_Main.MsBillImgPath = "";
		DC_Main.MsImagePath = "";
		UsUPdate = "N";
		UsDelete = "N";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_PR).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_PR_CLEAR();
		MSG_PR_IDTL_CLEAR();
		MSG2_CLEAR();
		OldTagItm = "";
		DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
		if (Operators.CompareString(FormBookType, "T", false) == 0)
		{
			if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DD038NEDD", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '11'";
				}
				else
				{
					DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '10'";
				}
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
			else if ((Operators.CompareString(FormBook, "043", false) != 0) & (Operators.CompareString(FormBook, "044", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '10'";
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
			DtIdtlPr.Clear();
			DtIdtlPr.Reset();
			FilRowPr = 0;
			int num4 = MSG_PR_IDTL.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num4)
			{
				DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
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
			TodayFineRate();
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				nPartyFine.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["PARTY_FINE"], (object)"")), "0.000");
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				if (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)
				{
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
					MSG2_TOTAL[5, 3] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]))), "0.00");
				}
				else
				{
					MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
					MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				}
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[9, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[10, 3] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[6, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[6, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[7, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
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
				tSlBill.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_NO"], (object)""));
				tSlBill_DbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_DBCD"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
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
				MSG_PR_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM " + TblDetl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""), (object)"", false))
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_LOT"], (object)""));
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["WITH_STOCK"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_TOT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_TOT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LOSS_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KUNDAN_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KUNDAN_TOUCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KUNDAN_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.000");
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.000");
						mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.000");
						mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					}
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					if ((Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) != 0.0) & (Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) != 0.0))
					{
						mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)((Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 20])) * (Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 22]) - Conversion.Val(mSG_PR[DC_Main.i + 1, 23])) / 100.0), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)(Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 20])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["URD_RATE_TYPE"]);
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["COMM_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["COMM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 46] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_PCS"])), "0");
					mSG_PR[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_FINE"])), "0.000");
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				MSG_PR_IDTL_CLEAR();
				DtIdtlPr.Clear();
				DtIdtlPr.Reset();
				FilRowPr = 0;
				int num3 = MSG_PR_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num3)
				{
					DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM " + TblIdtl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[24] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					drPr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					drPr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					drPr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					drPr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					drPr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					drPr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					drPr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					drPr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					drPr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					drPr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					drPr[10] = 0;
					drPr[11] = 0;
					drPr[12] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					drPr[13] = 0;
					drPr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					drPr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					drPr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					drPr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					drPr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					drPr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					drPr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					drPr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					drPr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					drPr[23] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				EntryMode = "E";
				DC_Main.RsQry = "SELECT A.* FROM SL_PR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsOldDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (RsOldDetl.Rows.Count > 0)
				{
					DC_Main.i = 0;
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < RsOldDetl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
						mSG[DC_Main.i + 1, 10] = Conversions.ToString(RsOldDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG.Rows += 1;
						DC_Main.i++;
					}
					if (mSG.Rows > 2)
					{
						mSG.Rows -= 1;
					}
					mSG = null;
				}
				else
				{
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
					RsBarDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					AxMSFlexGrid mSG2 = MSG;
					while (DC_Main.i < RsBarDetl.Rows.Count)
					{
						mSG2[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG2[DC_Main.i + 1, 46] = Conversions.ToString(RsBarDetl.Rows[DC_Main.i]["OLD_SRNO"]);
						mSG2[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG2[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG2[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
						mSG2[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG2[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						mSG2[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
						mSG2[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 10] = Conversions.ToString(RsBarDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG2[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG2[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG2[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG2[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG2[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.000");
						mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						mSG2[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 86] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 87] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_FINE"])), "0.00");
						mSG2[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG2[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG2[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG2[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG2[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG2[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
						mSG2[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
						mSG2[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
						mSG2[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["KR_COST"])), "0.00");
						mSG2[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG2[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
						mSG2[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
						mSG2[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
						mSG2[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
						mSG2[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						mSG2[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["EMP_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG2[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
						mSG2[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["TAG_SRNO"])), "0");
						mSG2[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 49] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0");
						mSG2[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["APR_ISU"], (object)""));
						mSG2[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
						mSG2[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
						mSG2[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
						mSG2[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
						mSG2[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
						mSG2[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
						mSG2[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_SRNO"], (object)"")), "0");
						mSG2[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
						mSG2[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
						mSG2[DC_Main.i + 1, 78] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_AC"], (object)""));
						mSG2[DC_Main.i + 1, 79] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["ORD_LC_CODE"], (object)""));
						mSG2[DC_Main.i + 1, 80] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
						mSG2[DC_Main.i + 1, 83] = Conversions.ToString(Operators.ConcatenateObject(RsBarDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
						mSG2[DC_Main.i + 1, 53] = "E";
						mSG2.Rows += 1;
						DC_Main.i++;
					}
					if (MSG.Rows > 2)
					{
						mSG2.Rows -= 1;
					}
					mSG2 = null;
				}
				MSG_TOT_FILL();
				DtIdtl.Clear();
				DtIdtl.Reset();
				FilRow = 0;
				int num4 = MSG_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num4)
				{
					DtIdtl.Columns.Add(MSG_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "Select A.*,B.IT_NAME FROM BAR_IDTL As A LEFT JOIN ITEM_MAST As B On A.CO_CODE = B.CO_CODE And  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsBarIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsBarIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[31] = RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[4] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[5] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[6] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[7] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[8] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[9] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[10] = 0;
					dr[11] = 0;
					dr[12] = RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_PCS"]);
					if (Operators.CompareString(DC_Main.SSRegSrNo, "DM119NEDG", false) == 0)
					{
						dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000000");
					}
					else
					{
						dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.0000");
					}
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					dr[18] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[21] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["KR_CON_PRC"], (object)"")), "0.000");
					dr[22] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["KR_RATE_TYPE"], (object)"");
					dr[23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
					dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
					dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsBarIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[30] = Operators.ConcatenateObject(RsBarIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				((Control)TEXT_PR_IDTL).Visible = false;
				((Control)PnlPrIdtl).Visible = false;
				OldValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 30]);
				NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 31]) + Conversion.Val(MSG_TOT[0, 30]);
				string text = "DhranImage";
				string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
				DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
				{
					PicBill.Image = Image.FromFile(DC_Main.MsBillImgPath);
				}
				DC_Main.MsBillImgPath = "";
				OldTagItm = "";
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (RowDelete)
		{
			Interaction.MsgBox((object)"Please First Save Voucher And Try Because Tag Row Is Delete But Vch Not Save...", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void TR_PURC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_PURC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_614a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_6126: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Unknown result type (might be due to invalid IL or missing references)
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0305: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_061e: Unknown result type (might be due to invalid IL or missing references)
		//IL_057a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Invalid comparison between Unknown and I4
		//IL_0504: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a07: Invalid comparison between Unknown and I4
		//IL_5ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ab9: Invalid comparison between Unknown and I4
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
		if ((Conversion.Val(MSG2_TOTAL[6, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[6, 4], "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[7, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[7, 4], "", false) == 0))
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
		checked
		{
			if (Operators.CompareString(DC_Main.MsCntrStk, "Y", false) == 0)
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if (Operators.CompareString(MSG[1, 3], "", false) != 0 && Operators.CompareString(MSG[DC_Main.M, 4], "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Tag Entry Counter Code and Try Because It is Mandatory...", (MsgBoxStyle)0, (object)null);
						((Control)BtnSave).Enabled = true;
						MSG.Row = DC_Main.M;
						MSG.Col = 3;
						MSG_EnterCell(MSG, new EventArgs());
						((Control)TEXT_PR).Focus();
						return;
					}
					DC_Main.M++;
				}
			}
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
				{
					if (Conversion.Val(MSG[1, 11]) == 0.0 && ((Conversion.Val(MSG_PR_TOT[0, 31]) == 0.0) & (Conversion.Val(nPartyFine.Text) == 0.0)))
					{
						Interaction.MsgBox((object)"ThenPlease Insert Fine In Party Fine.....", (MsgBoxStyle)0, (object)null);
						((Control)nPartyFine).Focus();
						((Control)BtnSave).Enabled = true;
						return;
					}
				}
				else if (((Conversion.Val(nPartyFine.Text) == 0.0) & (Conversion.Val(MSG_PR_TOT[0, 31]) == 0.0)) && unchecked((int)Interaction.MsgBox((object)"You Want Save Whout Party fine Value or item Amount Value", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
				{
					((Control)BtnSave).Enabled = true;
					return;
				}
			}
			MSG_TOT_FILL();
			if (Conversion.Val(MSG_PR_TOT[0, 35]) + (Conversion.Val(MSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 44])) == 0.0)
			{
				((Control)BtnSave).Enabled = true;
				Interaction.MsgBox((object)"Please Insert Party Entry And Try.....", (MsgBoxStyle)0, (object)null);
				((Control)tAcCode).Focus();
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
			Module_Save.PurcTran = null;
			try
			{
				if (DC_Main.Dc.State != ConnectionState.Open)
				{
					DC_Main.Dc.Open();
				}
				Module_Save.PurcTran = DC_Main.Dc.BeginTransaction();
				Module_Save.ExeQuteDcSave("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				Module_Save.ExeQuteDcSave("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				Module_Save.ExeQuteDcSave("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				if ((Conversion.Val(MSG_PR_TOT[0, 39]) != 0.0) | (Conversion.Val(MSG_PR_TOT[0, 9]) + Conversion.Val(MSG_PR_TOT[0, 12]) + Conversion.Val(MSG_PR_TOT[0, 44]) != 0.0))
				{
					Module_Save.ExeQuteDcSave("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "'", Module_Save.PurcTran);
					DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
					DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
					Module_Save.MsInsertDataSave(Module_Save.PurcTran);
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
					RsData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
					Module_Save.MsInsertDataSave(Module_Save.PurcTran);
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
					dataRow2["IT_TYPE"] = Strings.Mid(cboItemTyp.Text, 1, 1);
					if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
					{
						dataRow2["PARTY_FINE"] = Conversion.Val(nPartyFine.Text);
					}
					else
					{
						dataRow2["PARTY_FINE"] = PurcAcFine + Conversion.Val(MSG_PR_TOT[0, 38]);
					}
					dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
					dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
					dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
					dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
					dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
					dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
					dataRow2["TCS_CODE"] = MSG2_TOTAL[3, 4];
					dataRow2["TCS_PRC"] = Conversion.Val(MSG2_TOTAL[3, 2]);
					dataRow2["TCS_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
					if (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)
					{
						dataRow2["ROF_AMT"] = 0;
						dataRow2["TDS_CODE"] = MSG2_TOTAL[4, 4];
						dataRow2["TDS_PRC"] = Conversion.Val(MSG2_TOTAL[4, 2]);
						dataRow2["TDS_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
						dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]) + Conversion.Val(MSG2_TOTAL[4, 3]);
					}
					else
					{
						dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
						dataRow2["TDS_CODE"] = "";
						dataRow2["TDS_PRC"] = 0;
						dataRow2["TDS_AMT"] = 0;
						dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
					}
					dataRow2["LBR_AMT"] = Conversion.Val(MSG_PR_TOT[0, 35]);
					dataRow2["OTH_AMT"] = Conversion.Val(MSG_PR_TOT[0, 36]) - PrOthAmtLess;
					dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
					dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
					dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow2["CARD_AC"] = MSG2_TOTAL[7, 4];
					dataRow2["BANK_AC"] = MSG2_TOTAL[6, 4];
					dataRow2["CHQ_NO"] = MSG2_TOTAL[6, 2];
					dataRow2["BANK_NAME"] = tBankName.Text;
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
					dataRow2["CR_DAYS"] = Conversion.Val(nCrDays.Text);
					dataRow2["SL_BILL_NO"] = tSlBill.Text;
					dataRow2["SL_BILL_LC"] = DC_Main.MLc_code;
					dataRow2["SL_BILL_YRCD"] = DC_Main.MCo_year;
					dataRow2["SL_BILL_DBCD"] = tSlBill_DbCd.Text;
					dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow2["OZ_RATE"] = 0;
					dataRow2["OZ_CONV"] = 0;
					dataRow2["FX_RATE"] = 0;
					dataRow2["FX_CODE"] = "";
					dataRow2["MTL_RATE"] = 0;
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
				Module_Save.ExeQuteDcSave("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				DC_Main.RsQry = "SELECT * FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
				RsDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow3 = RsDetl.NewRow();
				int num2 = MSG_PR.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					AxMSFlexGrid mSG_PR = MSG_PR;
					if ((Conversion.Val(MSG_PR[DC_Main.i, 18]) + Conversion.Val(MSG_PR[DC_Main.i, 44]) != 0.0) & (Operators.CompareString(MSG_PR[DC_Main.i, 1], "", false) != 0))
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
						dataRow3["ENTRY_TYPE"] = "P";
						dataRow3["BOOK_NAME"] = FormMainBook;
						dataRow3["SR_NO"] = Conversion.Val(mSG_PR[DC_Main.i, 0]);
						dataRow3["OLD_SRNO"] = Conversion.Val(mSG_PR[DC_Main.i, 57]);
						dataRow3["IT_CODE"] = mSG_PR[DC_Main.i, 1];
						dataRow3["IT_DESC"] = mSG_PR[DC_Main.i, 2];
						dataRow3["TAG_NO"] = "N";
						dataRow3["TBL_CODE"] = mSG_PR[DC_Main.i, 3];
						dataRow3["DESIGN_NO"] = mSG_PR[DC_Main.i, 4];
						dataRow3["LOT_NO"] = mSG_PR[DC_Main.i, 5];
						dataRow3["ITM_LOT"] = mSG_PR[DC_Main.i, 6];
						dataRow3["ITM_SIZE"] = "";
						dataRow3["BAG_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 8]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 9]);
						dataRow3["BAG_TOT"] = Conversion.Val(mSG_PR[DC_Main.i, 10]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 12]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 13]);
						dataRow3["ITM_LOSS_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 14]);
						dataRow3["KUNDAN_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 15]);
						dataRow3["KUNDAN_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 16]);
						dataRow3["KUNDAN_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 17]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 18]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 19]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG_PR[DC_Main.i, 20]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG_PR[DC_Main.i, 21]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 22]);
						dataRow3["ITM_LESS_TCH"] = Conversion.Val(mSG_PR[DC_Main.i, 23]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 24]);
						dataRow3["SILVER_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 26]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 32]);
						dataRow3["LBR_TYPE"] = mSG_PR[DC_Main.i, 33];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 34]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 35]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 36]);
						dataRow3["ITM_OTH_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 37]);
						dataRow3["ITM_OTH_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 38]);
						dataRow3["CONV_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 27]);
						dataRow3["CONV_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 28]);
						dataRow3["MCX_RATE"] = 0;
						dataRow3["PRM_AMT"] = 0;
						dataRow3["PRM_DISC"] = 0;
						dataRow3["ITM_RATE"] = Conversion.Val(mSG_PR[DC_Main.i, 29]);
						dataRow3["URD_RATE_TYPE"] = mSG_PR[DC_Main.i, 30];
						dataRow3["ITM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 31]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG_PR[DC_Main.i, 39]);
						dataRow3["COMM_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 41]);
						dataRow3["COMM_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 42]);
						dataRow3["TOT_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 40]);
						dataRow3["TAX_PRC"] = Conversion.Val(mSG_PR[DC_Main.i, 43]);
						dataRow3["NET_AMT"] = Conversion.Val(mSG_PR[DC_Main.i, 44]);
						dataRow3["RATE_TYPE"] = mSG_PR[DC_Main.i, 46];
						dataRow3["IT_TYPE"] = mSG_PR[DC_Main.i, 45];
						dataRow3["PR_CODE"] = mSG_PR[DC_Main.i, 64];
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						if (mSG_PR[7] > 0)
						{
							dataRow3["WITH_STOCK"] = mSG_PR[DC_Main.i, 7];
							if (Operators.CompareString(mSG_PR[DC_Main.i, 7], "", false) == 0)
							{
								dataRow3["WITH_STOCK"] = "Y";
							}
						}
						else if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0) & (Operators.CompareString(DC_Main.MCo_Book, "037", false) == 0))
						{
							dataRow3["WITH_STOCK"] = "Y";
						}
						else if (Operators.CompareString(MSG[1, 3], "", false) != 0)
						{
							dataRow3["WITH_STOCK"] = "N";
						}
						else
						{
							dataRow3["WITH_STOCK"] = "Y";
						}
						dataRow3["SL_BILL_NO"] = tSlBill.Text;
						dataRow3["SL_BILL_LC"] = DC_Main.MLc_code;
						dataRow3["SL_BILL_YRCD"] = DC_Main.MCo_year;
						dataRow3["SL_BILL_DBCD"] = tSlBill_DbCd.Text;
						dataRow3["MAIN_USER"] = MainUser;
						if (Operators.CompareString(TblDetl, "PR_DETL", false) == 0)
						{
							dataRow3["TAG_NO"] = "";
							dataRow3["TAG_TOUCH"] = 0;
							dataRow3["TAG_WEST_PRC"] = 0;
							dataRow3["TAG_FINE"] = 0;
							dataRow3["TAG_LBR_PRC"] = 0;
							dataRow3["TAG_LBR_RATE"] = 0;
							dataRow3["TAG_LBR_AMT"] = 0;
							dataRow3["TAG_OTH_AMT"] = 0;
							dataRow3["TAG_COST"] = 0;
							dataRow3["TAG_MRP"] = 0;
							dataRow3["KR_NAME"] = "";
						}
						dataRow3["VCH_SRNO"] = 0;
						dataRow3["FINE_CUT_PCS"] = Conversion.Val(mSG_PR[DC_Main.i, 60]);
						dataRow3["FINE_CUT_GWT"] = Conversion.Val(mSG_PR[DC_Main.i, 61]);
						dataRow3["FINE_CUT_NWT"] = Conversion.Val(mSG_PR[DC_Main.i, 62]);
						dataRow3["FINE_CUT_FINE"] = Conversion.Val(mSG_PR[DC_Main.i, 63]);
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG_PR = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow4 = RsIdtl.NewRow();
				int num3 = 0;
				int num4 = DtIdtlPr.Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					DataTable dtIdtlPr = DtIdtlPr;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][21])) != 0.0)
					{
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["VCH_NO"] = tVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "P";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["AC_CODE"] = tAcCode.Text;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][24]));
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][0]));
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][1]);
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][3]);
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][4]);
						dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][5]);
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][6]);
						dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][7]);
						dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][8]);
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][9]);
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][12]));
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][14]));
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][15]));
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][16]);
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][17]));
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][18]));
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][19]));
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][20]));
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][21]));
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][22]));
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtlPr.Rows[i][23]);
						dataRow4["MAIN_USER"] = MainUser;
						RsIdtl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtlPr = null;
				}
				if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0 && Operators.CompareString(MSG[1, 3], "", false) == 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
					DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
					RsOldDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
					Module_Save.MsInsertDataSave(Module_Save.PurcTran);
					DataRow dataRow5 = RsOldDetl.NewRow();
					int num5 = MSG.Rows - 1;
					DC_Main.i = 1;
					while (DC_Main.i <= num5)
					{
						AxMSFlexGrid mSG = MSG;
						if ((Conversion.Val(mSG[DC_Main.i, 13]) + Conversion.Val(mSG[DC_Main.i, 26]) != 0.0) & (Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0))
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
							dataRow5["ENTRY_TYPE"] = "I";
							dataRow5["BOOK_NAME"] = FormMainBook;
							dataRow5["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
							dataRow5["IT_CODE"] = mSG[DC_Main.i, 2];
							dataRow5["IT_TYPE"] = mSG[DC_Main.i, 48];
							dataRow5["IT_DESC"] = mSG[DC_Main.i, 52];
							dataRow5["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 10]);
							dataRow5["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 11]);
							dataRow5["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 13]);
							dataRow5["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 24]);
							dataRow5["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 26]);
							dataRow5["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 36]);
							dataRow5["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 37]);
							dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow5["MAIN_USER"] = MainUser;
							RsOldDetl.Rows.Add(dataRow5);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsOldDetl);
							RsOldDetl.Clear();
						}
						mSG = null;
						DC_Main.i++;
					}
				}
				Module_Save.ExeQuteDcSave("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				Module_Save.ExeQuteDcSave("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				Module_Save.ExeQuteDcSave("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				DC_Main.RsQry = "SELECT * FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsBarData = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow6 = RsBarData.NewRow();
				if ((Conversion.Val(MSG_TOT[0, 40]) != 0.0) | (Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 31]) != 0.0))
				{
					dataRow6["CO_CODE"] = DC_Main.MCo_code;
					dataRow6["LC_CODE"] = DC_Main.MLc_code;
					dataRow6["CO_YEAR"] = DC_Main.MCo_year;
					dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow6["VCH_NO"] = tVchNo.Text;
					dataRow6["VCH_DATE"] = mVchDate.Text;
					dataRow6["STK_IT_CODE"] = "";
					dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow6["EMP_CODE"] = tEmpCode.Text;
					dataRow6["VCH_DESC"] = tVchDesc.Text;
					dataRow6["DATA_TRFR"] = "N";
					if (Operators.CompareString(DataTrfr, "Y", false) == 0)
					{
						dataRow6["RE_TRFR"] = "Y";
					}
					else
					{
						dataRow6["RE_TRFR"] = "N";
					}
					dataRow6["MAIN_USER"] = MainUser;
					RsBarData.Rows.Add(dataRow6);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsBarData);
					RsBarData.Clear();
				}
				int num6 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num6)
				{
					AxMSFlexGrid mSG2 = MSG;
					DC_Main.RsQry = ("SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 0]))) ?? "";
					RsBarDetl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
					Module_Save.MsInsertDataSave(Module_Save.PurcTran);
					DataRow dataRow7 = RsBarDetl.NewRow();
					if (((Operators.CompareString(mSG2[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG2[DC_Main.i, 3], "", false) != 0) & (Conversion.Val(mSG2[DC_Main.i, 40]) + Conversion.Val(mSG2[DC_Main.i, 11]) + Conversion.Val(mSG2[DC_Main.i, 31]) != 0.0)) | ((Operators.CompareString(mSG2[DC_Main.i, 28], "P", false) == 0) & (Conversion.Val(mSG2[DC_Main.i, 30]) != 0.0)))
					{
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						dataRow7["LC_CODE"] = DC_Main.MLc_code;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						dataRow7["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow7["VCH_NO"] = tVchNo.Text;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						dataRow7["STK_DATE"] = mVchDate.Text;
						dataRow7["AC_CODE"] = tAcCode.Text;
						dataRow7["VCH_TYPE"] = FormBookSname;
						dataRow7["INOUT_TYPE"] = FormBookInOut;
						dataRow7["ENTRY_TYPE"] = "P";
						dataRow7["BOOK_NAME"] = FormMainBook;
						dataRow7["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
						dataRow7["OLD_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 46]);
						dataRow7["IT_CODE"] = mSG2[DC_Main.i, 2];
						dataRow7["TAG_NO"] = mSG2[DC_Main.i, 3];
						dataRow7["TBL_CODE"] = mSG2[DC_Main.i, 4];
						dataRow7["DESIGN_NO"] = mSG2[DC_Main.i, 5];
						dataRow7["ITM_STYLE"] = mSG2[DC_Main.i, 6];
						dataRow7["ITM_SIZE"] = mSG2[DC_Main.i, 7];
						dataRow7["HM_ID"] = mSG2[DC_Main.i, 8];
						dataRow7["BAG_WT"] = Conversion.Val(mSG2[DC_Main.i, 9]);
						dataRow7["ITM_PCS"] = Conversion.Val(mSG2[DC_Main.i, 10]);
						dataRow7["ITM_GWT"] = Conversion.Val(mSG2[DC_Main.i, 11]);
						dataRow7["ITM_OTH_WT"] = Conversion.Val(mSG2[DC_Main.i, 12]);
						dataRow7["ITM_NWT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
						dataRow7["KR_OTH_WT"] = Conversion.Val(mSG2[DC_Main.i, 14]);
						dataRow7["KR_NET_WT"] = Conversion.Val(mSG2[DC_Main.i, 15]);
						dataRow7["KR_GHT_PRC"] = Conversion.Val(mSG2[DC_Main.i, 16]);
						dataRow7["KR_GHT_WT"] = Conversion.Val(mSG2[DC_Main.i, 17]);
						if (mSG2[18] <= 0)
						{
							dataRow7["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 85]);
							dataRow7["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 86]);
							dataRow7["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 87]);
						}
						else if (Conversion.Val(mSG2[DC_Main.i, 18]) == 0.0)
						{
							dataRow7["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 24]);
							dataRow7["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 25]);
							dataRow7["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 26]);
						}
						else
						{
							dataRow7["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 18]);
							dataRow7["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 19]);
							dataRow7["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 20]);
						}
						dataRow7["ITM_GHT_PRC"] = Conversion.Val(mSG2[DC_Main.i, 22]);
						dataRow7["ITM_GHT_WT"] = Conversion.Val(mSG2[DC_Main.i, 23]);
						dataRow7["ITM_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 24]);
						dataRow7["ITM_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 25]);
						dataRow7["ITM_FINE"] = Conversion.Val(mSG2[DC_Main.i, 26]);
						dataRow7["LBR_CODE"] = mSG2[DC_Main.i, 21];
						dataRow7["LBR_PRC"] = Conversion.Val(mSG2[DC_Main.i, 27]);
						dataRow7["LBR_TYPE"] = mSG2[DC_Main.i, 28];
						dataRow7["LBR_RATE"] = Conversion.Val(mSG2[DC_Main.i, 29]);
						dataRow7["LBR_AMT"] = Conversion.Val(mSG2[DC_Main.i, 30]);
						dataRow7["OTH_AMT"] = Conversion.Val(mSG2[DC_Main.i, 31]);
						dataRow7["KR_LBR_RATE"] = Conversion.Val(mSG2[DC_Main.i, 32]);
						dataRow7["KR_LBR_AMT"] = Conversion.Val(mSG2[DC_Main.i, 33]);
						dataRow7["KR_OTH_AMT"] = Conversion.Val(mSG2[DC_Main.i, 34]);
						dataRow7["KR_COST"] = Conversion.Val(mSG2[DC_Main.i, 35]);
						dataRow7["ITM_RATE"] = Conversion.Val(mSG2[DC_Main.i, 36]);
						dataRow7["ITM_AMT"] = Conversion.Val(mSG2[DC_Main.i, 37]);
						dataRow7["TAG_COST"] = Conversion.Val(mSG2[DC_Main.i, 38]);
						dataRow7["ITM_MARGIN"] = Conversion.Val(mSG2[DC_Main.i, 39]);
						dataRow7["ITM_MRP"] = Conversion.Val(mSG2[DC_Main.i, 40]);
						dataRow7["EMP_CODE"] = mSG2[DC_Main.i, 43];
						dataRow7["KR_NAME"] = mSG2[DC_Main.i, 44];
						dataRow7["ITM_REMARK"] = mSG2[DC_Main.i, 42];
						dataRow7["TAG_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 45]);
						dataRow7["RATE_TYPE"] = mSG2[DC_Main.i, 47];
						dataRow7["IT_TYPE"] = mSG2[DC_Main.i, 48];
						dataRow7["TAG_TYPE"] = mSG2[DC_Main.i, 49];
						dataRow7["PR_CODE"] = mSG2[DC_Main.i, 50];
						dataRow7["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 51]);
						if (Operators.CompareString(mSG2[DC_Main.i, 65], "", false) == 0)
						{
							dataRow7["APR_ISU"] = "N";
						}
						else
						{
							dataRow7["APR_ISU"] = mSG2[DC_Main.i, 65];
						}
						dataRow7["DATA_TYPE"] = mSG2[DC_Main.i, 73];
						dataRow7["HM_ID2"] = mSG2[DC_Main.i, 66];
						dataRow7["HM_ID3"] = mSG2[DC_Main.i, 67];
						dataRow7["HM_ID4"] = mSG2[DC_Main.i, 68];
						dataRow7["HM_ID_WT"] = Conversion.Val(mSG2[DC_Main.i, 69]);
						dataRow7["HM_ID2_WT"] = Conversion.Val(mSG2[DC_Main.i, 70]);
						dataRow7["HM_ID3_WT"] = Conversion.Val(mSG2[DC_Main.i, 71]);
						dataRow7["HM_ID4_WT"] = Conversion.Val(mSG2[DC_Main.i, 72]);
						dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow7["DATA_TRFR"] = "N";
						dataRow7["MAIN_USER"] = MainUser;
						dataRow7["ORD_NO"] = mSG2[DC_Main.i, 1];
						dataRow7["ORD_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 74]);
						dataRow7["ORD_YRCD"] = mSG2[DC_Main.i, 75];
						dataRow7["ORD_DBCD"] = mSG2[DC_Main.i, 76];
						dataRow7["ORD_AC"] = mSG2[DC_Main.i, 78];
						dataRow7["ORD_LC_CODE"] = mSG2[DC_Main.i, 79];
						if (Operators.CompareString(mSG2[DC_Main.i, 80], "", false) == 0)
						{
							dataRow7["EMP_ISU"] = "N";
						}
						else
						{
							dataRow7["EMP_ISU"] = mSG2[DC_Main.i, 80];
						}
						dataRow7["DESIGN_IMG_ID"] = mSG2[DC_Main.i, 83];
						RsBarDetl.Rows.Add(dataRow7);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBarDetl);
						RsBarDetl.Clear();
						DC_Main.RsQry = "DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_SRNO = '" + mSG2[DC_Main.i, 45] + "' AND TAG_NO = '" + mSG2[DC_Main.i, 3] + "'";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
						DC_Main.RsQry = "INSERT INTO SRNO_MAST (CO_CODE,LC_CODE,TAG_SRNO,VCH_SRNO,TAG_NO,IT_CODE) VALUES  ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + mSG2[DC_Main.i, 45] + "','" + mSG2[DC_Main.i, 51] + "','" + mSG2[DC_Main.i, 3] + "','" + mSG2[DC_Main.i, 2] + "')";
						Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
					}
					mSG2 = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsBarIdtl = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow8 = RsBarIdtl.NewRow();
				int num7 = 0;
				int num8 = 1;
				int num9 = 0;
				if (DtIdtl.Rows.Count > 0)
				{
					DataView dataView = new DataView(DtIdtl);
					dataView.Sort = "RowSrNo Asc";
					DtIdtl = dataView.ToTable();
				}
				int num10 = DtIdtl.Rows.Count - 1;
				for (int j = 0; j <= num10; j++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][14])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][27])) != 0.0)
					{
						if ((double)num9 != Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][31])))
						{
							num9 = (int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][31])));
							num8 = 1;
						}
						int rows = MSG.Rows;
						int num11 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num11)
						{
							if (Conversion.Val(MSG[DC_Main.M, 46]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][31])))
							{
								num7 = DC_Main.M;
								break;
							}
							DC_Main.M++;
						}
						dataRow8["CO_CODE"] = DC_Main.MCo_code;
						dataRow8["LC_CODE"] = DC_Main.MLc_code;
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						dataRow8["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow8["VCH_NO"] = tVchNo.Text;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						dataRow8["VCH_TYPE"] = FormBookSname;
						dataRow8["INOUT_TYPE"] = FormBookInOut;
						dataRow8["ENTRY_TYPE"] = "P";
						dataRow8["BOOK_NAME"] = FormMainBook;
						dataRow8["SR_NO"] = Conversion.Val(MSG[num7, 46]);
						dataRow8["TAG_NO"] = MSG[num7, 3];
						dataRow8["VCH_SRNO"] = Conversion.Val(MSG[num7, 51]);
						dataRow8["ISR_NO"] = num8;
						dataRow8["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][1]);
						dataRow8["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][3]);
						dataRow8["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][4]);
						dataRow8["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][5]);
						dataRow8["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][6]);
						dataRow8["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][7]);
						dataRow8["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][8]);
						dataRow8["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][9]);
						dataRow8["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12]));
						dataRow8["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][13]));
						dataRow8["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][14]));
						dataRow8["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][15]));
						dataRow8["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16]));
						dataRow8["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][17]));
						dataRow8["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][18]);
						dataRow8["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][19]));
						dataRow8["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][20]));
						dataRow8["KR_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][21]));
						dataRow8["KR_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][22]);
						dataRow8["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]));
						dataRow8["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][24]));
						dataRow8["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][25]));
						dataRow8["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][26]));
						dataRow8["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][27]));
						dataRow8["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][28]));
						dataRow8["KR_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][29]));
						dataRow8["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][30]);
						dataRow8["MAIN_USER"] = MainUser;
						num8++;
						RsBarIdtl.Rows.Add(dataRow8);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsBarIdtl);
						RsBarIdtl.Clear();
					}
					dtIdtl = null;
				}
				Module_Save.ExeQuteDcSave("DELETE FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				DC_Main.RsQry = "SELECT * FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				DataTable dataTable2 = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow9 = dataTable2.NewRow();
				int num12 = MSG_PR.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num12)
				{
					AxMSFlexGrid mSG_PR2 = MSG_PR;
					if ((Operators.CompareString(mSG_PR2[DC_Main.i, 1], "", false) != 0) & (Operators.CompareString(mSG_PR2[DC_Main.i, 6], "", false) != 0) & (Conversion.Val(mSG_PR2[DC_Main.i, 12]) != 0.0))
					{
						dataRow9["CO_CODE"] = DC_Main.MCo_code;
						dataRow9["LC_CODE"] = DC_Main.MLc_code;
						dataRow9["CO_YEAR"] = DC_Main.MCo_year;
						dataRow9["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow9["VCH_NO"] = tVchNo.Text;
						dataRow9["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow9["VCH_DATE"] = mVchDate.Text;
						if (Operators.CompareString(mSG_PR2[DC_Main.i, 53], "E", false) != 0)
						{
							dataRow9["STK_DATE"] = mVchDate.Text;
						}
						else
						{
							dataRow9["STK_DATE"] = mVchDate.Text;
						}
						dataRow9["LBR_PRC"] = 0;
						dataRow9["VCH_TYPE"] = FormBookSname;
						dataRow9["INOUT_TYPE"] = FormBookInOut;
						dataRow9["ENTRY_TYPE"] = "P";
						dataRow9["BOOK_NAME"] = FormMainBook;
						dataRow9["SR_NO"] = Conversion.Val(mSG_PR2[DC_Main.i, 0]);
						dataRow9["IT_CODE"] = mSG_PR2[DC_Main.i, 1];
						dataRow9["LOT_NO"] = mSG_PR2[DC_Main.i, 6];
						dataRow9["TBL_CODE"] = mSG_PR2[DC_Main.i, 3];
						dataRow9["DESIGN_NO"] = mSG_PR2[DC_Main.i, 4];
						dataRow9["ITM_SIZE"] = "";
						dataRow9["ITM_PCS"] = Conversion.Val(mSG_PR2[DC_Main.i, 9]);
						dataRow9["ITM_GWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 12]);
						dataRow9["ITM_OTH_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 13]);
						dataRow9["ITM_NWT"] = Conversion.Val(mSG_PR2[DC_Main.i, 18]);
						dataRow9["ITM_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 21]);
						dataRow9["ITM_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 22]);
						dataRow9["ITM_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 24]);
						dataRow9["KR_NET_WT"] = Conversion.Val(mSG_PR2[DC_Main.i, 18]);
						dataRow9["KR_TOUCH"] = Conversion.Val(mSG_PR2[DC_Main.i, 21]);
						dataRow9["KR_WEST_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 22]);
						dataRow9["KR_FINE"] = Conversion.Val(mSG_PR2[DC_Main.i, 24]);
						dataRow9["LBR_PRC"] = Conversion.Val(mSG_PR2[DC_Main.i, 32]);
						dataRow9["LBR_TYPE"] = mSG_PR2[DC_Main.i, 33];
						dataRow9["LBR_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 34]);
						dataRow9["LBR_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 35]);
						dataRow9["OTH_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 36]);
						dataRow9["ITM_RATE"] = Conversion.Val(mSG_PR2[DC_Main.i, 29]);
						dataRow9["ITM_AMT"] = Conversion.Val(mSG_PR2[DC_Main.i, 31]);
						dataRow9["ITM_REMARK"] = mSG_PR2[DC_Main.i, 2];
						dataRow9["KR_CODE"] = "";
						dataRow9["IT_TYPE"] = mSG_PR2[DC_Main.i, 45];
						dataRow9["PR_CODE"] = mSG_PR2[DC_Main.i, 64];
						dataRow9["DATA_TRFR"] = "N";
						dataRow9["DATA_TYPE"] = "A";
						dataRow9["DESIGN_IMG_ID"] = "N";
						dataRow9["MAIN_USER"] = MainUser;
						dataTable2.Rows.Add(dataRow9);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
						dataTable2.Clear();
					}
					mSG_PR2 = null;
					DC_Main.i++;
				}
				if (Operators.CompareString(QtNo, "", false) != 0)
				{
					Module_Save.ExeQuteDcSave("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.PurcTran);
					Module_Save.ExeQuteDcSave("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.PurcTran);
					Module_Save.ExeQuteDcSave("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'", Module_Save.PurcTran);
				}
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.ORD_LC_CODE AND APR_DETL.ISU_YRCD = B.ORD_YRCD  AND APR_DETL.ISU_DBCD = B.ORD_DBCD AND APR_DETL.ISU_NO = B.ORD_NO AND APR_DETL.ISU_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.CO_BOOK = '051' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'Y' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.ORD_LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					Ac_Ledr.Kr_Rec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					Ac_Ledr.OldSale_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				}
				else
				{
					Ac_Ledr.Purc_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				}
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					Ac_Rojmel.Kr_Rec_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					Ac_Rojmel.OldSale_RojMel(DC_Main.MCo_Book, tVchNo.Text);
				}
				else
				{
					Ac_Rojmel.Purc_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				}
				DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					Ac_Tax.Kr_Rec_GST(DC_Main.MCo_Book, tVchNo.Text);
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) != 0)
				{
					Ac_Tax.Purc_GST(DC_Main.MCo_Book, tVchNo.Text);
				}
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					Ac_Stock.Kr_Rec_Stk(DC_Main.MCo_Book, tVchNo.Text);
					Ac_Stock.Dm_KrRec_Detl(DC_Main.MCo_Book, tVchNo.Text);
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					Ac_Stock.OldSale_Stock(DC_Main.MCo_Book, tVchNo.Text);
				}
				else
				{
					Ac_Stock.Purc_Stk(DC_Main.MCo_Book, tVchNo.Text);
					Ac_Stock.Dm_Purc_Detl(DC_Main.MCo_Book, tVchNo.Text);
				}
				DC_Main.RsQry = "DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Ac_Stock.PrKr_Lot(DC_Main.MCo_Book, tVchNo.Text);
				Module_Save.PurcTran.Commit();
				Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
				unchecked
				{
					if (DC_Main.MsOldPurcSl)
					{
						if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
						{
							DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[5, 3]);
						}
						else
						{
							DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[10, 3]);
						}
						DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 18]);
						((Control)BtnSave).Enabled = true;
						if ((int)Interaction.MsgBox((object)"Old Silver Purchase Print... ?", (MsgBoxStyle)260, (object)null) == 7)
						{
							((Form)this).Close();
							return;
						}
					}
					else if (DC_Main.MsOldPurc)
					{
						if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
						{
							DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[5, 3]);
						}
						else
						{
							DC_Main.MsOldPurcAmt = Conversion.Val(MSG2_TOTAL[10, 3]);
						}
						DC_Main.MsOldPurcWt = Conversion.Val(MSG_PR_TOT[0, 18]);
						((Control)BtnSave).Enabled = true;
						if ((int)Interaction.MsgBox((object)"Old Gold Purchase Print... ?", (MsgBoxStyle)260, (object)null) == 7)
						{
							((Form)this).Close();
							return;
						}
					}
				}
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.TableCol();
					string text = "";
					int num13 = RsData.Columns.Count - 2;
					DC_Main.M = 0;
					while (DC_Main.M <= num13)
					{
						if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
						{
							int num14 = DC_Main.RsTblCol.Rows.Count - 1;
							for (int k = 0; k <= num14; k++)
							{
								if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[k]["TBL_COL_NAME"], false))
								{
									text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[k]["COL_NAME"], (object)""));
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
				RowDelete = false;
				if (Operators.CompareString(FormVchNo, "", false) != 0)
				{
					CLEAR_DATA();
					((Form)this).Close();
					return;
				}
				CurPrnVch = tVchNo.Text;
				DC_Main.ExeQuteDc("DELETE FROM TAG_SET WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
				DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
				CustOpAmt = DC_Main.MsAcAmtOpBal;
				CustClAmt = DC_Main.MsAcAmtClBal;
				CustOpGold = DC_Main.MsAcGoldOpBal;
				CustClGold = DC_Main.MsAcGoldClBal;
				CustOpSilver = DC_Main.MsAcSilverOpBal;
				CustClSilver = DC_Main.MsAcSilverClBal;
				CLEAR_DATA();
				BtnPrint_Click(BtnPrint, new EventArgs());
				if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
				{
					Thread.Sleep(3000);
					Application.DoEvents();
				}
				CurPrnVch = "";
				CustOpAmt = 0.0;
				CustClAmt = 0.0;
				CustOpGold = 0.0;
				CustClGold = 0.0;
				CustOpSilver = 0.0;
				CustClSilver = 0.0;
				DC_Main.MsAcAmtOpBal = 0.0;
				DC_Main.MsAcAmtClBal = 0.0;
				DC_Main.MsAcGoldOpBal = 0.0;
				DC_Main.MsAcGoldClBal = 0.0;
				DC_Main.MsAcSilverOpBal = 0.0;
				DC_Main.MsAcSilverClBal = 0.0;
				if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
				{
					((Form)this).Close();
				}
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				try
				{
					Module_Save.PurcTran.Rollback();
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
		//IL_014c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0294: Unknown result type (might be due to invalid IL or missing references)
		//IL_029a: Invalid comparison between Unknown and I4
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc6: Unknown result type (might be due to invalid IL or missing references)
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
		DC_Main.MsOldPurc = false;
		DC_Main.MsOldPurcSl = false;
		DC_Main.RsQry = "SELECT * FROM  MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO IN (SELECT TAG_NO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "') AND ITM_SIGN = '-'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox((object)"You Cant Delete This Voucher Because  Tag Use in Sales Transection....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT A.*,B.BOOK_NAME As LinkBook FROM " + TblData + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SL_BILL_DBCD = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' AND A.SL_BILL_NO <> '' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0 && !LInkVchDelete)
		{
			Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"You Cant Delete This Voucher Becouse Voucher Is Linkd With ", DC_Main.Tbl.Rows[0]["LinkBook"]), (object)" And Vch No = "), DC_Main.Tbl.Rows[0]["SL_BILL_NO"]), (object)"  Please Delete Then First ...."), (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,CASH_AMT+CARD_AMT+CHQ_AMT,TOT_AMT,IT_TYPE,0,PARTY_FINE,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM " + TblData + " AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,A.VCH_NO,SR_NO,A.VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,A.VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,A.NET_AMT,A.IT_TYPE,0,ITM_FINE,A.HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE FROM (PR_DATA AS C LEFT JOIN PR_DETL AS A ON C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND C.CO_YEAR = A.CO_YEAR AND C.CO_BOOK = A.CO_BOOK AND C.VCH_NO = A.VCH_NO)  LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				int num = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					DC_Main.ExeQuteDc("DELETE FROM SRNO_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_SRNO = '" + MSG[DC_Main.M, 51] + "' AND TAG_NO = '" + MSG[DC_Main.M, 3] + "'");
					DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + MSG[DC_Main.M, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.M, 51]))) ?? "";
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					DC_Main.M++;
				}
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.ORD_LC_CODE AND APR_DETL.ISU_YRCD = B.ORD_YRCD  AND APR_DETL.ISU_DBCD = B.ORD_DBCD AND APR_DETL.ISU_NO = B.ORD_NO AND APR_DETL.ISU_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.CO_BOOK = '051' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'N' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.ORD_LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM " + TblDetl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM " + TblIdtl + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_PURC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			checked
			{
				if (((Control)TEXT_PR).Visible)
				{
					MSG_PR_LeaveCell(MSG_PR, new EventArgs());
					MSG_PR.Row = MSG_PR.Rows - 1;
					MSG_PR.Col = 0;
					((Control)TEXT_PR).Visible = false;
					((Control)TEXT_PR_IDTL).Visible = false;
					((Control)PnlPrIdtl).Visible = false;
					MSG.Row = MSG.Rows - 1;
					MSG.Col = 1;
					MSG_EnterCell(MSG, new EventArgs());
					((Control)TEXT_ENTRY).Focus();
				}
				else if (((Control)TEXT_ENTRY).Visible)
				{
					MSG_LeaveCell(MSG, new EventArgs());
					MSG.Row = MSG.Rows - 1;
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
		string text = "";
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
			if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				text = ((Operators.CompareString(FormBookType, "T", false) != 0) ? "KrRecVch" : "KrRecVchGst");
			}
			else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				text = "OldItmSaleVch";
			}
			else
			{
				text = ((Operators.CompareString(FormBookType, "T", false) != 0) ? "PurcBillA4" : "PurcBillA4Gst");
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0)
				{
					text = "PurcBill" + DC_Main.MCo_Book;
				}
			}
			DC_Main.MsWappPrintType = "WithFine";
			DC_Main.RptName = text;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			if (Operators.CompareString(FormBookType, "T", false) != 0)
			{
				DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.000"));
				DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.000"));
				DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
				DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00"))));
			}
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
		Cr[(short)5] = "";
		if (Operators.CompareString(FormMainBook, "PR QUOT", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcQuot.RPT";
		}
		else
		{
			Cr[(short)0] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
			Cr[(short)1] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
			if (Operators.CompareString(FormBookType, "T", false) != 0)
			{
				Cr[(short)2] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
				Cr[(short)3] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
				Cr[(short)4] = ("OpSilver = " + Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
				Cr[(short)5] = ("ClSilver = " + Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
			}
			if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
			{
				if (Operators.CompareString(FormBookType, "T", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRecVchGst.RPT";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrRecVch.RPT";
				}
			}
			else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OldItmSaleVch.RPT";
			}
			else
			{
				if (Operators.CompareString(FormBookType, "T", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillA4Gst.RPT";
				}
				else
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBillA4.RPT";
				}
				if (Operators.CompareString(DC_Main.SSRegSrNo, "HM249NEHP", false) == 0)
				{
					Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\PurcBill" + DC_Main.MCo_Book + ".RPT";
					DC_Main.MsPrintDup = true;
				}
			}
		}
		Cr.SelectionFormula = "{" + TblData + ".CO_CODE} = '" + DC_Main.MCo_code + "' AND {" + TblData + ".LC_CODE} = '" + DC_Main.MLc_code + "' AND {" + TblData + ".CO_YEAR} = '" + DC_Main.MCo_year + "' AND {" + TblData + ".CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {" + TblData + ".VCH_NO} = '" + CurPrnVch + "'";
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (RowDelete)
		{
			Interaction.MsgBox((object)"Please First Save Voucher And Try Because Tag Row Is Delete But Vch Not Save...", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
			return;
		}
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_PURC_Activated(object sender, EventArgs e)
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
			((Control)TEXT_PR).Visible = false;
			((Control)mVchDate).Focus();
			return;
		}
		if (DC_Main.MsOldPurc | DC_Main.MsOldPurcSl)
		{
			tAcCode.Text = DC_Main.MsSlAcCode;
			if (Operators.CompareString(tAcCode.Text, "00045", false) == 0)
			{
				tAcCode.Text = "00050";
			}
			tAcName.Text = DC_Main.CustUrdName;
			tSlBill.Text = DC_Main.MsSlBill;
			tSlBill_DbCd.Text = DC_Main.MsSlDbCd;
			DC_Main.RsQry = "SELECT VCH_NO,CO_BOOK FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + tSlBill_DbCd.Text + "' AND SL_BILL_NO = '" + tSlBill.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_NO"], (object)""));
				DISPLAY_DATA();
				((Control)tVchNo).Focus();
			}
			return;
		}
		if (DC_Main.MsCreat)
		{
			DC_Main.MsCreat = false;
			if (Operators.CompareString(DC_Main.MsCode, "", false) == 0)
			{
				TEXT_ENTRY.Text = DC_Main.MsName;
				((Control)TEXT_ENTRY).Focus();
				return;
			}
			tAcCode.Text = DC_Main.MsCode;
			tAcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsBillImgPath, "", false) != 0))
		{
			PicBill.Image = Image.FromFile(DC_Main.MsBillImgPath);
			DC_Main.MsBillImgPath = "";
		}
		else
		{
			PicBill.Image = null;
			DC_Main.MsBillImgPath = "";
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
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "Select A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.BILL_NO As BillL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,SUM(C.ITM_PCS) As PcsM,SUM(C.ITM_GWT) As GrWtW,SUM(C.ITM_NWT) As NetWtW,A.PARTY_FINE As FineW,A.TOT_AMT As TotAmtR FROM (" + TblData + " AS A LEFT JOIN " + TblDetl + " AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.BILL_NO,A.VCH_DESC,A.MAIN_USER,A.PARTY_FINE,A.TOT_AMT ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[12];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 90.0;
		DC_Main.ColWidth[4] = 150.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 70.0;
		DC_Main.ColWidth[7] = 90.0;
		DC_Main.ColWidth[8] = 90.0;
		DC_Main.ColWidth[9] = 90.0;
		DC_Main.ColWidth[10] = 100.0;
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
		//IL_0c68: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c72: Expected O, but got Unknown
		//IL_09bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c5: Expected O, but got Unknown
		//IL_0b16: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b20: Expected O, but got Unknown
		//IL_0e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1d: Expected O, but got Unknown
		if (MsgClear || MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 52] + " : It Name";
		tHmId2.Text = MSG[MSG.Row, 66];
		tHmId3.Text = MSG[MSG.Row, 67];
		tHmId4.Text = MSG[MSG.Row, 68];
		nHmWt.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 69]), "0.000");
		nHmWt2.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 70]), "0.000");
		nHmWt3.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 71]), "0.000");
		nHmWt4.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 72]), "0.000");
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 46]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][31])))
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
					MSG_IDTL[num, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
					MSG_IDTL[num, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
					MSG_IDTL[num, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
					MSG_IDTL[num, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
					MSG_IDTL[num, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num, 17] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][17], (object)""));
					MSG_IDTL[num, 18] = Conversions.ToString(DtIdtl.Rows[i][18]);
					MSG_IDTL[num, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
					MSG_IDTL[num, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
					MSG_IDTL[num, 21] = Conversions.ToString(DtIdtl.Rows[i][21]);
					MSG_IDTL[num, 22] = Conversions.ToString(DtIdtl.Rows[i][22]);
					MSG_IDTL[num, 23] = Conversions.ToString(DtIdtl.Rows[i][23]);
					MSG_IDTL[num, 24] = Conversions.ToString(DtIdtl.Rows[i][24]);
					MSG_IDTL[num, 25] = Conversions.ToString(DtIdtl.Rows[i][25]);
					MSG_IDTL[num, 26] = Conversions.ToString(DtIdtl.Rows[i][26]);
					MSG_IDTL[num, 27] = Conversions.ToString(DtIdtl.Rows[i][27]);
					MSG_IDTL[num, 28] = Conversions.ToString(DtIdtl.Rows[i][28]);
					MSG_IDTL[num, 29] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][29], (object)""));
					MSG_IDTL[num, 30] = Conversions.ToString(DtIdtl.Rows[i][30]);
					MSG_IDTL[num, 31] = Conversions.ToString(DtIdtl.Rows[i][31]);
					MSG_IDTL[num, 32] = Conversions.ToString(DtIdtl.Rows[i][32]);
					MSG_IDTL[num, 33] = Conversions.ToString(DtIdtl.Rows[i][33]);
					MSG_IDTL.Rows += 1;
					num++;
				}
			}
			if ((Operators.CompareString(MSG[MSG.Row, 83], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0))
			{
				DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 83] + "' AND IMAGE_TYPE = 'D'";
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
			}
			else
			{
				PicImage.Image = null;
				DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
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
						DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 51]))) ?? "";
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
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 51]))) ?? "";
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
			MSG_IDTL[num, 0] = Conversions.ToString(num);
			MSG_IDTL[num, 31] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 46]));
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
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mVchDate;
		DC_Main.SetDate(ref MsDate);
		mVchDate = MsDate;
		if (!DC_Main.RongDate)
		{
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				((Control)cboItemTyp).Focus();
			}
			else
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

	private void TR_PURC_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void AcImgShow()
	{
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) == 0)
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + tAcCode.Text;
			}
			else
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
			}
		}
		else
		{
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + tAcCode.Text;
		}
		DC_Main.MsImageType = "AcImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
		if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
		{
			picAc.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			picAc.Image = null;
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gstt FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL,C.AC_ADD2 As Add2,C.AC_ADD3 As Add3,C.AC_GSTNO As Gst FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_ADD2,A.AC_ADD3,A.AC_GSTNO FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL,A.AC_ADD2 As Add2,A.AC_ADD3 As Add3,A.AC_GSTNO As Gst FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY A.AC_NAME";
			}
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[11];
			DC_Main.ColWidth[0] = 270.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 170.0;
			DC_Main.ColWidth[3] = 180.0;
			DC_Main.ColWidth[4] = 220.0;
			DC_Main.ColWidth[5] = 160.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 0.0;
			DC_Main.ColWidth[8] = 0.0;
			DC_Main.ColWidth[9] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (DC_Main.MsCreat)
			{
				if (Operators.CompareString(FormMainBook, "KARIGAR RECEIPT", false) == 0)
				{
					DC_Main.MsGrCode = "10";
				}
				else if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
				{
					DC_Main.MsGrCode = "10";
				}
				else if ((Operators.CompareString(DC_Main.MCo_Book, "043", false) == 0) | (Operators.CompareString(DC_Main.MCo_Book, "044", false) == 0))
				{
					DC_Main.MsGrCode = "20";
				}
				else
				{
					DC_Main.MsGrCode = "05";
				}
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
				if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
				{
					((Control)PnlUpdate).Visible = true;
					UAdd1.Text = DC_Main.ColValue[4];
					UAdd2.Text = DC_Main.ColValue[7];
					UAdd3.Text = DC_Main.ColValue[8];
					UCity.Text = DC_Main.ColValue[5];
					UGstNo.Text = DC_Main.ColValue[9];
					UMobile.Text = DC_Main.ColValue[6];
					AcImgShow();
				}
			}
			((Control)tAcCode).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)
		{
			((Control)PnlUpdate).Visible = false;
		}
		if (Operators.CompareString(tAcCode.Text, "00050", false) != 0)
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_SHORT"], (object)""), (object)"", false))
			{
				MSG[1, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_SHORT"], (object)""));
			}
			if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["WITH_TDS_TAX"], (object)""), (object)"Y", false), (object)(Operators.CompareString(EntryMode, "A", false) == 0))) && Operators.CompareString(FormBookType, "T", false) == 0 && ((Operators.CompareString(FormBook, "043", false) != 0) & (Operators.CompareString(FormBook, "044", false) != 0)))
			{
				DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '25'";
				DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsTax.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
					AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
					DataRow dataRow;
					object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
					double num = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL[4, 2] = Strings.Format((object)num, "0.00");
					MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
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
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			((Control)tAcName).Focus();
			return;
		}
		MSG_PR.Col = 1;
		MSG_PR.Row = 1;
		MSG_PR_EnterCell(MSG_PR, new EventArgs());
		((Control)TEXT_PR).Focus();
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
			if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
			{
				((Control)nPartyFine).Focus();
			}
			else
			{
				SendKeys.Send("{tab}");
			}
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
		mSG2_TOTAL.Rows = 11;
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
				case 5:
				case 10:
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj7 = mSG2_TOTAL;
						object? obj8 = colorConverter.ConvertFromString("233, 235, 240");
						obj7.CellBackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj9 = mSG2_TOTAL;
						object? obj10 = colorConverter.ConvertFromString("Cornsilk");
						obj9.CellBackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj11 = mSG2_TOTAL;
						object? obj12 = colorConverter.ConvertFromString("255, 224, 192");
						obj11.CellBackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
					}
					break;
				case 2:
				case 8:
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
			if (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)
			{
				mSG2_TOTAL[4, 0] = "Tds Amt : ";
			}
			else
			{
				mSG2_TOTAL[4, 0] = "Rof Amt : ";
			}
			mSG2_TOTAL[5, 0] = "Total Amt : ";
			mSG2_TOTAL[6, 0] = "Cheque Amt : ";
			mSG2_TOTAL[7, 0] = "Card Amt : ";
			mSG2_TOTAL[8, 0] = "Cash Amt : ";
			mSG2_TOTAL[9, 0] = "Kasar Amt : ";
			mSG2_TOTAL[10, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 10))
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
				if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 2))
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
					if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7))
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 10))
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
			if ((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7))
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
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
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
					if (((mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 7)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 6)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 7)
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
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
										mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
										mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
										OldNetAmt = 0.0;
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
								mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 3;
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
							mSG2_TOTAL.Row = 3;
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
								DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcW, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '20' AND A.SR_NO = 0 ORDER BY A.TAX_CODE";
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
										mSG2_TOTAL[3, 4] = DC_Main.ColValue[2];
										OldNetAmt = 0.0;
										BILL_TOTAL();
									}
									else
									{
										TEXT_ENTRY_2.Text = "";
										OldNetAmt = 0.0;
										mSG2_TOTAL[3, 1] = "";
										mSG2_TOTAL[3, 2] = "";
										mSG2_TOTAL[3, 3] = "";
										mSG2_TOTAL[3, 4] = "";
									}
									MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
									mSG2_TOTAL.Row = 4;
									mSG2_TOTAL.Col = 3;
									((Control)TEXT_ENTRY_2).Focus();
								}
							}
							else
							{
								mSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
								mSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 6;
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
							mSG2_TOTAL.Row = 6;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					}
					if (!((mSG2_TOTAL.Row == 4) & (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)))
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
								mSG2_TOTAL.Row = 6;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[4, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.000");
							mSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							mSG2_TOTAL[4, 3] = "";
							OldTdsPrc = 0.0;
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 6;
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
						mSG2_TOTAL.Row = 6;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 4:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 2;
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
					case 6:
					case 7:
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
					case 9:
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

	private void BILL_TOTAL()
	{
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		mSG2_TOTAL[0, 3] = Strings.Format((object)(Math.Round(Conversion.Val(MSG_PR_TOT[0, 44]), DC_Main.MsTotAmtRof) - PrOthAmtLess), "0.00");
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_PR_TOT[0, 35]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
		}
		if (OldNetAmt != Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00")))
		{
			OldNetAmt = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG2_TOTAL[0, 3]), "0.00"));
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			mSG2_TOTAL[3, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[2, 3])) * Conversion.Val(mSG2_TOTAL[3, 2]) / 100.0, 0), "0.00");
		}
		if (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)
		{
			if (((Conversion.Val(mSG2_TOTAL[4, 2]) != 0.0) & (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)) && OldTdsPrc != Conversion.Val(mSG2_TOTAL[4, 2]))
			{
				OldTdsPrc = Conversion.Val(mSG2_TOTAL[4, 2]);
				mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[4, 2]) / 100.0, 0), "0.00");
			}
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - (Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[4, 3])) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), DC_Main.MsTotAmtRof), "0.00");
		}
		else
		{
			mSG2_TOTAL[5, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) + Conversion.Val(mSG2_TOTAL[3, 3]), DC_Main.MsTotAmtRof), "0.00");
		}
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
		{
			mSG2_TOTAL[8, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[9, 3]), 0), "0.00");
		}
		mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3])), "0.00");
		if (Operators.CompareString(FormMainBook, "OLD ITEM SALES", false) == 0)
		{
			if (Conversion.Val(nPartyFine.Text) != 0.0)
			{
				CustClAmt = CustOpAmt;
			}
			else if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt - Conversion.Val(mSG2_TOTAL[10, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[10, 3]) + Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[10, 3]);
			}
			if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "G", false) == 0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold - Conversion.Val(nPartyFine.Text);
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = CustOpGold - Conversion.Val(nPartyFine.Text);
				}
				else
				{
					CustClGold = Conversion.Val(nPartyFine.Text);
				}
			}
			else
			{
				CustClGold = CustOpGold;
			}
			if (Operators.CompareString(Strings.Mid(cboItemTyp.Text, 1, 1), "S", false) == 0)
			{
				if (CustOpSilver > 0.0)
				{
					CustClSilver = CustOpSilver - Conversion.Val(nPartyFine.Text);
				}
				else if (CustOpGold < 0.0)
				{
					CustClSilver = CustOpGold - Conversion.Val(nPartyFine.Text);
				}
				else
				{
					CustClSilver = Conversion.Val(nPartyFine.Text);
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
			}
		}
		else
		{
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[10, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[10, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[10, 3]);
			}
			if (Operators.CompareString(FormItmType, "G", false) == 0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold + PurcAcFine;
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = PurcAcFine - Math.Abs(CustOpGold);
				}
				else
				{
					CustClGold = PurcAcFine;
				}
			}
			else
			{
				CustClGold = CustOpGold;
			}
			if (Operators.CompareString(FormItmType, "S", false) == 0)
			{
				if (CustOpSilver > 0.0)
				{
					CustClSilver = CustOpSilver + PurcAcFine;
				}
				else if (CustOpGold < 0.0)
				{
					CustClSilver = PurcAcFine - Math.Abs(CustOpSilver);
				}
				else
				{
					CustClSilver = PurcAcFine;
				}
			}
			else
			{
				CustClSilver = CustOpSilver;
			}
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
		if (Operators.CompareString(tAcCode.Text, "00050", false) == 0)
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
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Invalid comparison between Unknown and I4
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
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
			MSG_PR.Col = 1;
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
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
			MSG_PR.Col = 1;
			MSG_PR.Row = 1;
			MSG_PR_EnterCell(MSG_PR, new EventArgs());
			((Control)TEXT_PR).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0140: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
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
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 328:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Check Len Connection...You Cant Save Image...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 328;
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
					((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
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
						((Image)val4).Dispose();
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
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
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 51]))) ?? "";
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
			DC_Main.MsImageNo = MSG[MSG.Row, 3] + "_" + MSG[MSG.Row, 51];
			string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
			Ac_Image.FtpDeleteFile(ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
		}
		PicImage.Image = null;
	}

	private void MSG_PR_Scroll(object sender, EventArgs e)
	{
		if (MSG_PR_TOT.LeftCol != MSG_PR.LeftCol)
		{
			MSG_PR_TOT.LeftCol = MSG_PR.LeftCol;
			MSG_PR_TOT.ScrollTrack = MSG_PR.LeftCol != 0;
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

	private void nPartyFine_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPartyFine.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPartyFine.Text)), "0.000");
			BILL_TOTAL();
			((Control)tBankName).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save(int ImgRow)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int num = default(int);
		int num3 = default(int);
		DataRow dataRow = default(DataRow);
		string ftpuri = default(string);
		MemoryStream memoryStream = default(MemoryStream);
		byte[] buffer = default(byte[]);
		string value = default(string);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					val = MSG;
					goto IL_000c;
				case 976:
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
							goto IL_0037;
						case 5:
							goto IL_0043;
						case 6:
							goto IL_0085;
						case 7:
							goto IL_00a9;
						case 8:
							goto IL_00c1;
						case 9:
							goto IL_00dc;
						case 10:
							goto IL_00f5;
						case 11:
						case 12:
							goto IL_0111;
						case 13:
							goto IL_011b;
						case 14:
							goto IL_0141;
						case 15:
							goto IL_014d;
						case 16:
							goto IL_0159;
						case 17:
							goto IL_01c6;
						case 18:
							goto IL_01d4;
						case 19:
							goto IL_0241;
						case 20:
							goto IL_0254;
						case 21:
							goto IL_025d;
						case 22:
							goto IL_026d;
						case 23:
							goto IL_0282;
						case 24:
							goto IL_0297;
						case 25:
							goto IL_02af;
						case 26:
							goto IL_02d2;
						case 27:
							goto IL_02e7;
						case 28:
							goto IL_02f9;
						case 29:
							goto IL_030f;
						case 30:
							goto IL_0323;
						case 31:
						case 32:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 33:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0297:
					num2 = 24;
					dataRow["TAG_NO"] = val[ImgRow, 3];
					goto IL_02af;
					IL_02af:
					num2 = 25;
					dataRow["VCH_SRNO"] = Conversion.Val(val[ImgRow, 51]);
					goto IL_02d2;
					IL_0282:
					num2 = 23;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					goto IL_0297;
					IL_02d2:
					num2 = 26;
					dataRow["IMAGE_TYPE"] = "T";
					goto IL_02e7;
					IL_000c:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					DC_Main.MsImageNo = val[ImgRow, 3] + "_" + val[ImgRow, 51];
					goto IL_0037;
					IL_0037:
					num2 = 4;
					DC_Main.MsImageType = "TagImage";
					goto IL_0043;
					IL_0043:
					num2 = 5;
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					goto IL_0085;
					IL_0085:
					num2 = 6;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
					{
						break;
					}
					goto IL_00a9;
					IL_00a9:
					num2 = 7;
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
					goto IL_00c1;
					IL_00c1:
					num2 = 8;
					if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
					{
						goto IL_00dc;
					}
					goto IL_0111;
					IL_00dc:
					num2 = 9;
					ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
					goto IL_00f5;
					IL_00f5:
					num2 = 10;
					Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
					goto IL_0111;
					IL_0111:
					num2 = 12;
					memoryStream = new MemoryStream();
					goto IL_011b;
					IL_011b:
					num2 = 13;
					PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
					goto IL_0141;
					IL_0141:
					num2 = 14;
					buffer = memoryStream.GetBuffer();
					goto IL_014d;
					IL_014d:
					num2 = 15;
					value = Convert.ToBase64String(buffer);
					goto IL_0159;
					IL_0159:
					num2 = 16;
					DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + val[ImgRow, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(val[ImgRow, 51]))) ?? "";
					goto IL_01c6;
					IL_02f9:
					num2 = 28;
					RsImg.Rows.Add(dataRow);
					goto IL_030f;
					IL_02e7:
					num2 = 27;
					dataRow["MOB_IMAGE"] = value;
					goto IL_02f9;
					IL_01c6:
					num2 = 17;
					DC_Main.ExeQuteImg(DC_Main.RsQry);
					goto IL_01d4;
					IL_01d4:
					num2 = 18;
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + val[ImgRow, 3] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(val[ImgRow, 51]))) ?? "";
					goto IL_0241;
					IL_0323:
					num2 = 30;
					RsImg.Clear();
					break;
					IL_030f:
					num2 = 29;
					((DbDataAdapter)(object)DC_Main.Da).Update(RsImg);
					goto IL_0323;
					IL_0241:
					num2 = 19;
					RsImg = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					goto IL_0254;
					IL_0254:
					num2 = 20;
					DC_Main.MsInsertData();
					goto IL_025d;
					IL_025d:
					num2 = 21;
					dataRow = RsImg.NewRow();
					goto IL_026d;
					IL_026d:
					num2 = 22;
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					goto IL_0282;
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
				try0001_dispatch = 976;
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

	private void nHmWt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Conversion.Val(nHmWt.Text) != 0.0)
			{
				nHmWt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt.Text)), "0.000");
				HmDetlFeel();
				((Control)tHmId2).Focus();
			}
			else
			{
				MSG.Col = 10;
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
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId2.Text, "", false) != 0) & (Conversion.Val(nHmWt2.Text) == 0.0))
			{
				Interaction.MsgBox((object)"Please Insert HmId2 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Conversion.Val(nHmWt2.Text) != 0.0)
			{
				nHmWt2.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt2.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				MSG.Col = 10;
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
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId3.Text, "", false) != 0) & (Conversion.Val(nHmWt3.Text) == 0.0))
			{
				Interaction.MsgBox((object)"Please Insert HmId3 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Conversion.Val(nHmWt3.Text) != 0.0)
			{
				nHmWt3.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt3.Text)), "0.000");
				HmDetlFeel();
				SendKeys.Send("{tab}");
			}
			else
			{
				MSG.Col = 10;
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
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			if ((Operators.CompareString(tHmId4.Text, "", false) != 0) & (Conversion.Val(nHmWt4.Text) == 0.0))
			{
				Interaction.MsgBox((object)"Please Insert HmId4 Weight and try...", (MsgBoxStyle)0, (object)null);
			}
			else if (Conversion.Val(nHmWt4.Text) != 0.0)
			{
				nHmWt4.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nHmWt4.Text)), "0.000");
				HmDetlFeel();
				MSG.Col = 10;
				MSG.Row = MSG.Row;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
		}
	}

	private void HmDetlFeel()
	{
		MSG[MSG.Row, 66] = tHmId2.Text;
		MSG[MSG.Row, 67] = tHmId3.Text;
		MSG[MSG.Row, 68] = tHmId4.Text;
		MSG[MSG.Row, 69] = nHmWt.Text;
		MSG[MSG.Row, 70] = nHmWt2.Text;
		MSG[MSG.Row, 71] = nHmWt3.Text;
		MSG[MSG.Row, 72] = nHmWt4.Text;
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
			MSG.Col = 10;
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
			MSG.Col = 10;
			MSG.Row = MSG.Row;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tHmId4_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			LInkVchDelete = true;
			((TextBoxBase)tSlBill).ReadOnly = false;
			((TextBoxBase)tSlBill_DbCd).ReadOnly = false;
			Interaction.MsgBox((object)"Now You Can Edit Or Delete Linkd Purchase Bill With Sales Bill....", (MsgBoxStyle)0, (object)null);
		}
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(tHmId4.Text, "", false) != 0)
			{
				HmDetlFeel();
				SendKeys.Send("{tab}");
				return;
			}
			MSG.Col = 10;
			MSG.Row = MSG.Row;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void chkBillImage_CheckedChanged(object sender, EventArgs e)
	{
		if (((Control)pnlBill).Visible)
		{
			((Control)pnlBill).Visible = false;
		}
		else
		{
			((Control)pnlBill).Visible = true;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void btnBillSelect_Click(object sender, EventArgs e)
	{
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
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
					((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
					((FileDialog)DlgOpen).Title = "Open Image File";
					string text = "DhranImage";
					string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
					DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
					if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
					{
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
						{
							PicBill.Image.Dispose();
							PicBill.Image = null;
							FileSystem.Kill(DC_Main.MsBillImgPath);
						}
						PicBill.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
						PicBill.Image.Save(DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg");
						DC_Main.MsBillImgPath = "";
					}
					goto end_IL_0001;
				}
				case 430:
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
				try0001_dispatch = 430;
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
	private void btnBillDel_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_011f: Unknown result type (might be due to invalid IL or missing references)
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
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
					{
						string text = "DhranImage";
						string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
						DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
						{
							PicBill.Image.Dispose();
							PicBill.Image = null;
							FileSystem.Kill(DC_Main.MsBillImgPath);
						}
					}
					goto end_IL_0001;
				case 295:
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
				try0001_dispatch = 295;
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
	private void btnbillCap_Click(object sender, EventArgs e)
	{
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
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
					string text = "DhranImage";
					string text2 = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + DC_Main.MCo_year + "_" + DC_Main.MCo_Book + tVchNo.Text;
					DC_Main.MsBillImgPath = DC_Main.MSImageSavePath + "\\" + text + "\\" + text2 + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsBillImgPath, (FileAttribute)0), "", false) != 0)
					{
						PicBill.Image.Dispose();
						PicBill.Image = null;
						FileSystem.Kill(DC_Main.MsBillImgPath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				}
				case 294:
					num = -1;
					switch (num2)
					{
					case 2:
						Interaction.MsgBox((object)"Please Check Len Connection...You Cant Save Image...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 294;
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

	private void PicBill_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicBill.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void TR_PURC_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_PR_IDTL", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_PR_IDTL).SelectionStart = 0;
			((TextBoxBase)TEXT_PR_IDTL).SelectionLength = Strings.Len(TEXT_PR_IDTL.Text);
		}
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
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

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void tSlBill_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,B.BOOK_NAME As BookL,A.TOT_AMT As BillAmtR,A.CO_YEAR As YearL,A.CO_BOOK As CoBookL,A.AC_CODE As AcCodeL FROM  SL_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.MAIN_BOOK = 'SALES' AND B.BOOK_TYPE = 'T'  ORDER BY A.VCH_DATE,A.VCH_NO DESC";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 150.0;
		DC_Main.ColWidth[4] = 120.0;
		DC_Main.ColWidth[5] = 0.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 0.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tSlBill.Text = DC_Main.ColValue[0];
				tSlBill_DbCd.Text = DC_Main.ColValue[6];
				tAcCode.Text = DC_Main.ColValue[7];
				tAcName.Text = DC_Main.ColValue[2];
				((Control)tAcCode).Focus();
			}
			else
			{
				tSlBill.Text = "";
				tSlBill_DbCd.Text = "";
			}
		}
	}

	private void btnUpdate_Click(object sender, EventArgs e)
	{
		((Control)PnlUpdate).Visible = false;
		DC_Main.MsAcUpdate = tAcCode.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
	}

	private void tAcCode_DoubleClick(object sender, EventArgs e)
	{
		if (!((Control)PnlUpdate).Visible)
		{
			((Control)PnlUpdate).Visible = true;
		}
		else
		{
			((Control)PnlUpdate).Visible = false;
		}
	}

	private void nCrDays_TextChanged(object sender, EventArgs e)
	{
	}

	private void btnQuot_Click(object sender, EventArgs e)
	{
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(EntryMode, "A", false) != 0 || !((Operators.CompareString(tAcCode.Text, "00050", false) != 0) & (Operators.CompareString(tAcCode.Text, "", false) != 0)))
		{
			return;
		}
		DC_Main.RsQry = "Select A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.CO_BOOK As BookL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,SUM(C.ITM_PCS) As PcsM,SUM(C.ITM_GWT) As GrWtW,SUM(C.ITM_NWT) As NetWtW,A.PARTY_FINE As FineW,A.TOT_AMT As TotAmtR FROM ((" + TblData + " AS A LEFT JOIN " + TblDetl + " AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.MAIN_BOOK = 'PR QUOT' GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.CO_BOOK,A.VCH_DESC,A.MAIN_USER,A.PARTY_FINE,A.TOT_AMT ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[12];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 200.0;
		DC_Main.ColWidth[3] = 90.0;
		DC_Main.ColWidth[4] = 150.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 70.0;
		DC_Main.ColWidth[7] = 90.0;
		DC_Main.ColWidth[8] = 90.0;
		DC_Main.ColWidth[9] = 90.0;
		DC_Main.ColWidth[10] = 100.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (DC_Main.HelpClose || DC_Main.HelpClose || Operators.CompareString(DC_Main.ColValue[0], "", false) == 0)
		{
			return;
		}
		QtNo = DC_Main.ColValue[0];
		QtDbCd = DC_Main.ColValue[3];
		DC_Main.RsQry = "SELECT * FROM " + TblData + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + QtDbCd + "' AND VCH_NO = '" + QtNo + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				CurPrnVch = tVchNo.Text;
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BILL_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				OldAcCode = tAcCode.Text;
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				nPartyFine.Text = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsData.Rows[0]["PARTY_FINE"], (object)"")), "0.000");
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["IT_TYPE"], (object)""), (object)"G", false))
				{
					cboItemTyp.SelectedIndex = 0;
				}
				else
				{
					cboItemTyp.SelectedIndex = 1;
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00"));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TCS_CODE"], (object)""));
				MSG2_TOTAL[3, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_PRC"]), "0.000");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TCS_AMT"]), "0.00");
				if (Operators.CompareString(DC_Main.MsPrTdsTax, "Y", false) == 0)
				{
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
					MSG2_TOTAL[5, 3] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TDS_AMT"]))), "0.00");
				}
				else
				{
					MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
					MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				}
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[9, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[10, 3] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[6, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[6, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[7, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[7, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[7, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
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
				tSlBill.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_NO"], (object)""));
				tSlBill_DbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["SL_BILL_DBCD"], (object)""));
				nCrDays.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CR_DAYS"], (object)""));
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
				MSG_PR_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM " + TblDetl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + QtDbCd + "' AND A.VCH_NO = '" + QtNo + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG_PR = MSG_PR;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG_PR[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG_PR[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
					mSG_PR[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""), (object)"", false))
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					}
					mSG_PR[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG_PR[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_LOT"], (object)""));
					mSG_PR[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["WITH_STOCK"], (object)""));
					mSG_PR[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 9] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG_PR[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_TOT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_TOT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LOSS_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK311NBVK", false) == 0)
					{
						mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.000");
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.000");
						mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.000");
						mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG_PR[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG_PR[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					}
					mSG_PR[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_LESS_TCH"])), "0.00");
					mSG_PR[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					if ((Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) != 0.0) & (Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) != 0.0))
					{
						mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)((Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 20])) * (Conversion.Val(mSG_PR[DC_Main.i + 1, 21]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 22]) - Conversion.Val(mSG_PR[DC_Main.i + 1, 23])) / 100.0), "0.000");
					}
					else
					{
						mSG_PR[DC_Main.i + 1, 25] = Strings.Format((object)(Conversion.Val(mSG_PR[DC_Main.i + 1, 18]) + Conversion.Val(mSG_PR[DC_Main.i + 1, 20])), "0.000");
					}
					mSG_PR[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["SILVER_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_FINE"])), "0.000");
					mSG_PR[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["CONV_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_PR[DC_Main.i + 1, 30] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["URD_RATE_TYPE"]);
					mSG_PR[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG_PR[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["COMM_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["COMM_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG_PR[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_PR[DC_Main.i + 1, 46] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_PR[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG_PR[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_PCS"])), "0");
					mSG_PR[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_GWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_NWT"])), "0.000");
					mSG_PR[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["FINE_CUT_FINE"])), "0.000");
					mSG_PR.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_PR.Rows > 2)
				{
					mSG_PR.Rows -= 1;
				}
				mSG_PR = null;
				MSG_PR_TOT_FILL();
				MSG_PR_IDTL_CLEAR();
				DtIdtlPr.Clear();
				DtIdtlPr.Reset();
				FilRowPr = 0;
				int num3 = MSG_PR_IDTL.Cols - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num3)
				{
					DtIdtlPr.Columns.Add(MSG_PR_IDTL[0, DC_Main.M]);
					DC_Main.M++;
				}
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM " + TblIdtl + " AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + QtDbCd + "' AND A.VCH_NO = '" + QtNo + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					drPr = DtIdtlPr.NewRow();
					drPr[24] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					drPr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					drPr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					drPr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					drPr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					drPr[4] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					drPr[5] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					drPr[6] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					drPr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					drPr[8] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					drPr[9] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					drPr[10] = 0;
					drPr[11] = 0;
					drPr[12] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					drPr[13] = 0;
					drPr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					drPr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
					drPr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					drPr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					drPr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					drPr[19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					drPr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					drPr[21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					drPr[22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					drPr[23] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtlPr.Rows.Add(drPr);
					DC_Main.i++;
				}
				MsgOldRowPr = 0;
				MSG_PR_RowColChange(MSG_PR, new EventArgs());
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				EntryMode = "A";
			}
			else
			{
				((Control)mVchDate).Focus();
				EntryMode = "A";
			}
		}
	}
}
