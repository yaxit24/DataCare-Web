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
public class TR_SALE_ORD : Form
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
	[AccessedThroughProperty("BtnAll")]
	private SimpleButton _BtnAll;

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
	[AccessedThroughProperty("mDelDate")]
	private MaskedTextBox _mDelDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBankName")]
	private TextBox _tBankName;

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
	[AccessedThroughProperty("mFunDate")]
	private MaskedTextBox _mFunDate;

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

	private string DataTrfr;

	private DataTable VchOldData;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string CurPrnMobile;

	private double OldGoldPurcAmt;

	private double OldSilverPurcAmt;

	private string CardCommAdj;

	private double OldCardAmt;

	private bool UpiEntry;

	private double OldUpiAmt;

	private bool UpiTypeAdd;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OrdGold;

	private double OrdSilver;

	private double OldSchmAmt;

	private bool MobileSearch;

	private double ToDayGlRate;

	private double ToDaySlRate;

	private string OldAcCode;

	private double CustOpAmt;

	private double CustClAmt;

	private double RecAdjAmt;

	private double AdjGold;

	private double AdjSilver;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private DataTable RsData;

	private DataTable RsDetl;

	private DataTable RsIdtl;

	private DataTable RsOldDetl;

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

	private const int cColor = 5;

	private const int cSize = 6;

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

	private const int cRateFix = 17;

	private const int cItRate = 18;

	private const int cItAmt = 19;

	private const int cLbrPrc = 20;

	private const int cLbrType = 21;

	private const int cLbrRate = 22;

	private const int cLbrAmt = 23;

	private const int cOthAmt = 24;

	private const int cMrp = 25;

	private const int cDlvDate = 26;

	private const int cTotAmt = 27;

	private const int cTaxPrc = 28;

	private const int cNetAmt = 29;

	private const int cKrName = 30;

	private const int cKrOthWt = 31;

	private const int cKrNetWt = 32;

	private const int cKrGhatPrc = 33;

	private const int cKrGhatWt = 34;

	private const int cKrTouch = 35;

	private const int cKrWestPrc = 36;

	private const int cKrFine = 37;

	private const int cKrLRate = 38;

	private const int cKrLAmt = 39;

	private const int cKrOthAmt = 40;

	private const int cPrCost = 41;

	private const int cVchSrno = 42;

	private const int cTagCost = 43;

	private const int cMargin = 44;

	private const int cImageTake = 45;

	private const int cTagSrNo = 46;

	private const int cOldSrNo = 47;

	private const int cRateType = 48;

	private const int cItType = 49;

	private const int cTagType = 50;

	private const int cPrCode = 51;

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

	private const int cItRemark = 65;

	private const int cOrdDesignIsu = 66;

	private const int cOrdTagGen = 67;

	private const int cOrdTagSale = 68;

	private const int cOldCounter = 69;

	private const int cOrdTagStkLess = 70;

	private const int cDesignImgId = 71;

	private const int cHmId = 72;

	private const int cHmId2 = 73;

	private const int cHmId3 = 74;

	private const int cHmId4 = 75;

	private const int cHmIdWt = 76;

	private const int cHmId2Wt = 77;

	private const int cHmId3Wt = 78;

	private const int cHmId4wt = 79;

	private const int cOldValChange = 80;

	private const int cOldTotAmt = 81;

	private const int cOldItAmt = 82;

	private const int cOldItRate = 83;

	private const int cOldLbrRate = 84;

	private const int cOldLbrAmt = 85;

	private const int cOldLbrPrc = 86;

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

	private const int cTax2 = 1;

	private const int cTot2 = 2;

	private const int cCash2 = 3;

	private const int cChq2 = 4;

	private const int cCard2 = 5;

	private const int cOldGold2 = 6;

	private const int cOldSl2 = 7;

	private const int cSchem2 = 8;

	private const int cAdvAmt2 = 9;

	private const int cOs2 = 10;

	private const int cUrSrNo = 0;

	private const int cUrItCode = 1;

	private const int cUrItName = 2;

	private const int cUrPcs = 3;

	private const int cUrGrWt = 4;

	private const int cUrOthWt = 5;

	private const int cUrNetWt = 6;

	private const int cUrTouch = 7;

	private const int cUrFine = 8;

	private const int cUrRateType = 9;

	private const int cUrRate = 10;

	private const int cUrNetAmt = 11;

	private const int cUrItType = 12;

	private const int cUrOldRate = 13;

	private const int cUrOldNetAmt = 14;

	private const int cUrOldFine = 15;

	private const int cUrOldNetWt = 16;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			EventHandler eventHandler = TEXT_ENTRY_TextChanged;
			KeyEventHandler val = new KeyEventHandler(TEXT_ENTRY_KeyDown);
			KeyEventHandler val2 = new KeyEventHandler(TEXT_ENTRY_KeyUp);
			TextBox val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged -= eventHandler;
				((Control)val3).KeyDown -= val;
				((Control)val3).KeyUp -= val2;
			}
			_TEXT_ENTRY = value;
			val3 = _TEXT_ENTRY;
			if (val3 != null)
			{
				((Control)val3).TextChanged += eventHandler;
				((Control)val3).KeyDown += val;
				((Control)val3).KeyUp += val2;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAcName_KeyDown);
			EventHandler eventHandler = TAcName_TextChanged;
			TextBox val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcName = value;
			val2 = _tAcName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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
			TextBox val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tVchDesc = value;
			val2 = _tVchDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton BtnAll
	{
		[CompilerGenerated]
		get
		{
			return _BtnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			SimpleButton val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAll = value;
			val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual MaskedTextBox mDelDate
	{
		[CompilerGenerated]
		get
		{
			return _mDelDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mDelDate_KeyDown);
			EventHandler eventHandler = mDelDate_GotFocus;
			MaskedTextBox val2 = _mDelDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mDelDate = value;
			val2 = _mDelDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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

	internal virtual MaskedTextBox mFunDate
	{
		[CompilerGenerated]
		get
		{
			return _mFunDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFunDate_KeyDown);
			EventHandler eventHandler = mFunDate_GotFocus;
			MaskedTextBox val2 = _mFunDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFunDate = value;
			val2 = _mFunDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
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
			EventHandler eventHandler = TEXT_UPI_TextChanged;
			TextBox val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_TEXT_UPI = value;
			val2 = _TEXT_UPI;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	public TR_SALE_ORD()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_SALE_ORD_Load;
		((Form)this).Deactivate += TR_SALE_ORD_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_SALE_ORD_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_SALE_ORD_KeyDown);
		((Form)this).Activated += TR_SALE_ORD_Activated;
		((Form)this).Closed += TR_SALE_ORD_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_SALE_ORD_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
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
		//IL_0452: Unknown result type (might be due to invalid IL or missing references)
		//IL_045c: Expected O, but got Unknown
		//IL_050e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0518: Expected O, but got Unknown
		//IL_059b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a5: Expected O, but got Unknown
		//IL_0642: Unknown result type (might be due to invalid IL or missing references)
		//IL_064c: Expected O, but got Unknown
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0704: Expected O, but got Unknown
		//IL_078b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0795: Expected O, but got Unknown
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_083a: Expected O, but got Unknown
		//IL_08c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d3: Expected O, but got Unknown
		//IL_0936: Unknown result type (might be due to invalid IL or missing references)
		//IL_0940: Expected O, but got Unknown
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09f3: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected O, but got Unknown
		//IL_0b09: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b13: Expected O, but got Unknown
		//IL_0c30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3a: Expected O, but got Unknown
		//IL_0d45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4f: Expected O, but got Unknown
		//IL_0db2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dbc: Expected O, but got Unknown
		//IL_0f4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1026: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Expected O, but got Unknown
		//IL_10dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e6: Expected O, but got Unknown
		//IL_11de: Unknown result type (might be due to invalid IL or missing references)
		//IL_11e8: Expected O, but got Unknown
		//IL_12f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1303: Expected O, but got Unknown
		//IL_1380: Unknown result type (might be due to invalid IL or missing references)
		//IL_138a: Expected O, but got Unknown
		//IL_144e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1458: Expected O, but got Unknown
		//IL_14ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1509: Expected O, but got Unknown
		//IL_1601: Unknown result type (might be due to invalid IL or missing references)
		//IL_160b: Expected O, but got Unknown
		//IL_166c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1676: Expected O, but got Unknown
		//IL_177f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1789: Expected O, but got Unknown
		//IL_1861: Unknown result type (might be due to invalid IL or missing references)
		//IL_186b: Expected O, but got Unknown
		//IL_1907: Unknown result type (might be due to invalid IL or missing references)
		//IL_1911: Expected O, but got Unknown
		//IL_1a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a56: Expected O, but got Unknown
		//IL_1aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aab: Expected O, but got Unknown
		//IL_1b28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b32: Expected O, but got Unknown
		//IL_1bb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc1: Expected O, but got Unknown
		//IL_1c8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c95: Expected O, but got Unknown
		//IL_1d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d46: Expected O, but got Unknown
		//IL_1dc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dd1: Expected O, but got Unknown
		//IL_1e59: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e63: Expected O, but got Unknown
		//IL_1f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f21: Expected O, but got Unknown
		//IL_1fd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fdf: Expected O, but got Unknown
		//IL_20a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_20ab: Expected O, but got Unknown
		//IL_2183: Unknown result type (might be due to invalid IL or missing references)
		//IL_218d: Expected O, but got Unknown
		//IL_2229: Unknown result type (might be due to invalid IL or missing references)
		//IL_2233: Expected O, but got Unknown
		//IL_2348: Unknown result type (might be due to invalid IL or missing references)
		//IL_2352: Expected O, but got Unknown
		//IL_23d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_23dd: Expected O, but got Unknown
		//IL_24a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_24b1: Expected O, but got Unknown
		//IL_2518: Unknown result type (might be due to invalid IL or missing references)
		//IL_2522: Expected O, but got Unknown
		//IL_257d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2587: Expected O, but got Unknown
		//IL_2625: Unknown result type (might be due to invalid IL or missing references)
		//IL_262f: Expected O, but got Unknown
		//IL_26c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_26cb: Expected O, but got Unknown
		//IL_2752: Unknown result type (might be due to invalid IL or missing references)
		//IL_275c: Expected O, but got Unknown
		//IL_2810: Unknown result type (might be due to invalid IL or missing references)
		//IL_281a: Expected O, but got Unknown
		//IL_289f: Unknown result type (might be due to invalid IL or missing references)
		//IL_28a9: Expected O, but got Unknown
		//IL_2961: Unknown result type (might be due to invalid IL or missing references)
		//IL_296b: Expected O, but got Unknown
		//IL_2a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a29: Expected O, but got Unknown
		//IL_2add: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae7: Expected O, but got Unknown
		//IL_2b83: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b8d: Expected O, but got Unknown
		//IL_2c3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c45: Expected O, but got Unknown
		//IL_2cc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ccd: Expected O, but got Unknown
		//IL_2d81: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d8b: Expected O, but got Unknown
		//IL_2fb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fbd: Expected O, but got Unknown
		//IL_306a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3074: Expected O, but got Unknown
		//IL_3103: Unknown result type (might be due to invalid IL or missing references)
		//IL_310d: Expected O, but got Unknown
		//IL_31bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_31c5: Expected O, but got Unknown
		//IL_3254: Unknown result type (might be due to invalid IL or missing references)
		//IL_325e: Expected O, but got Unknown
		//IL_330c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3316: Expected O, but got Unknown
		//IL_33c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_33ce: Expected O, but got Unknown
		//IL_345d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3467: Expected O, but got Unknown
		//IL_34f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3500: Expected O, but got Unknown
		//IL_358e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3598: Expected O, but got Unknown
		//IL_3645: Unknown result type (might be due to invalid IL or missing references)
		//IL_364f: Expected O, but got Unknown
		//IL_36d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_36e0: Expected O, but got Unknown
		//IL_3831: Unknown result type (might be due to invalid IL or missing references)
		//IL_383b: Expected O, but got Unknown
		//IL_38de: Unknown result type (might be due to invalid IL or missing references)
		//IL_38e8: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_SALE_ORD));
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
		BtnAll = new SimpleButton();
		tItRemark = new TextBox();
		Label5 = new Label();
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG_OLD = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_OLD = new TextBox();
		mDelDate = new MaskedTextBox();
		Label6 = new Label();
		tBankName = new TextBox();
		Label7 = new Label();
		BtnImgC = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgD = new SimpleButton();
		Label8 = new Label();
		tBillNo = new TextBox();
		LOpAmt = new Label();
		LClAmt = new Label();
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
		Label12 = new Label();
		mFunDate = new MaskedTextBox();
		Label14 = new Label();
		PnlUpi = new Panel();
		TEXT_UPI = new TextBox();
		MSG_UPI = new AxMSFlexGrid();
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
		lblBook.Text = "Sales Order";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(349, 42);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(270, 43);
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
		((Control)tVchNo).Location = new Point(105, 42);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(520, 42);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(431, 42);
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
		((Control)chkWapp).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(453, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(119, 27);
		((Control)chkWapp).TabIndex = 8;
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
		((Control)TEXT_ENTRY).Location = new Point(789, 144);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 5;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(728, 246);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(444, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(444, 318);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 7;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 275);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(708, 103);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(12, 467);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(122, 94);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 223);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1264, 17);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 103);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 119);
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
		((Control)BtnF1).Location = new Point(187, 42);
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
		((Control)tAcCode).Location = new Point(349, 71);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(431, 71);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(323, 23);
		((Control)tAcName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(271, 71);
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
		((Control)tEmpCode).Location = new Point(265, 469);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 10;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(328, 469);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(185, 469);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(655, 500);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(728, 502);
		((TextBoxBase)tVchDesc).MaxLength = 250;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(441, 59);
		((Control)tVchDesc).TabIndex = 14;
		((BaseStyleControl)BtnAll).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAll).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAll).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnAll).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAll).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnAll).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAll).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAll).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAll).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAll).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAll).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAll).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnAll).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnAll).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAll).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAll).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAll).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAll).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAll).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnAll).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAll).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAll).AppearancePressed.Options.UseFont = true;
		((Control)BtnAll).Location = new Point(228, 42);
		((BaseControl)BtnAll).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAll).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAll).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAll).Name = "BtnAll";
		((Control)BtnAll).Size = new Size(35, 23);
		((Control)BtnAll).TabIndex = 1164;
		BtnAll.Text = "All";
		((BaseControl)BtnAll).ToolTip = "Voucher Help";
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(77, 246);
		((TextBoxBase)tItRemark).MaxLength = 100;
		((Control)tItRemark).Name = "tItRemark";
		((Control)tItRemark).Size = new Size(643, 23);
		((Control)tItRemark).TabIndex = 6;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 246);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(60, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Remark ";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(728, 274);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 222);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_OLD).Location = new Point(12, 386);
		((Control)MSG_OLD).Name = "MSG_OLD";
		((AxHost)MSG_OLD).OcxState = (State)componentResourceManager.GetObject("MSG_OLD.OcxState");
		((Control)MSG_OLD).Size = new Size(708, 71);
		((Control)MSG_OLD).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(915, 403);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 8;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_OLD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_OLD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_OLD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_OLD).ForeColor = Color.White;
		((Control)TEXT_OLD).Location = new Point(378, 414);
		((Control)TEXT_OLD).Name = "TEXT_OLD";
		((Control)TEXT_OLD).Size = new Size(100, 18);
		((Control)TEXT_OLD).TabIndex = 9;
		((Control)TEXT_OLD).Visible = false;
		((TextBoxBase)mDelDate).BackColor = Color.White;
		((Control)mDelDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDelDate).Location = new Point(265, 536);
		mDelDate.Mask = "00/00/0000";
		((Control)mDelDate).Name = "mDelDate";
		((Control)mDelDate).Size = new Size(76, 23);
		((Control)mDelDate).TabIndex = 12;
		mDelDate.ValidatingType = typeof(DateTime);
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(181, 536);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(71, 20);
		((Control)Label6).TabIndex = 1171;
		Label6.Text = "Del Date";
		Label6.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(265, 504);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(216, 23);
		((Control)tBankName).TabIndex = 11;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(182, 504);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)16;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(140, 467);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 1174;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(140, 500);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 1175;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(140, 533);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 1176;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 71);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(105, 71);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(158, 23);
		((Control)tBillNo).TabIndex = 2;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1021, 71);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(571, 469);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1210;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
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
		((Control)PanelAdd).Controls.Add((Control)(object)Label12);
		((Control)PanelAdd).Location = new Point(349, 103);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(405, 152);
		((Control)PanelAdd).TabIndex = 4;
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
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Maroon;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(17, 6);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(59, 20);
		((Control)Label12).TabIndex = 1158;
		Label12.Text = "Add 1  :";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mFunDate).BackColor = Color.White;
		((Control)mFunDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFunDate).Location = new Point(468, 536);
		mFunDate.Mask = "00/00/0000";
		((Control)mFunDate).Name = "mFunDate";
		((Control)mFunDate).Size = new Size(76, 23);
		((Control)mFunDate).TabIndex = 13;
		mFunDate.ValidatingType = typeof(DateTime);
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(357, 537);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(105, 20);
		((Control)Label14).TabIndex = 1212;
		Label14.Text = "Function Date";
		Label14.TextAlign = (ContentAlignment)16;
		((Control)PnlUpi).Controls.Add((Control)(object)TEXT_UPI);
		((Control)PnlUpi).Controls.Add((Control)(object)MSG_UPI);
		((Control)PnlUpi).Location = new Point(12, 274);
		((Control)PnlUpi).Name = "PnlUpi";
		((Control)PnlUpi).Size = new Size(710, 287);
		((Control)PnlUpi).TabIndex = 1213;
		((Control)PnlUpi).Visible = false;
		((TextBoxBase)TEXT_UPI).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_UPI).BorderStyle = (BorderStyle)0;
		((Control)TEXT_UPI).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_UPI).ForeColor = Color.White;
		((Control)TEXT_UPI).Location = new Point(305, 134);
		((Control)TEXT_UPI).Name = "TEXT_UPI";
		((Control)TEXT_UPI).Size = new Size(100, 18);
		((Control)TEXT_UPI).TabIndex = 11;
		((Control)TEXT_UPI).Visible = false;
		((Control)MSG_UPI).Location = new Point(5, 5);
		((Control)MSG_UPI).Name = "MSG_UPI";
		((AxHost)MSG_UPI).OcxState = (State)componentResourceManager.GetObject("MSG_UPI.OcxState");
		((Control)MSG_UPI).Size = new Size(700, 277);
		((Control)MSG_UPI).TabIndex = 0;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PnlUpi);
		((Control)this).Controls.Add((Control)(object)mFunDate);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)mDelDate);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)TEXT_OLD);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG_OLD);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItRemark);
		((Control)this).Controls.Add((Control)(object)BtnAll);
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
		((Control)this).Name = "TR_SALE_ORD";
		((Form)this).Text = "Sales Order";
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
			MSG2_TOTAL[3, 1] = Strings.Format((object)num2, "0.00");
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
		//IL_07e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_043d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
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
							BILL_TOTAL();
							((Control)PnlUpi).Visible = false;
							((Control)TEXT_UPI).Visible = false;
							MSG2_TOTAL.Col = 3;
							MSG2_TOTAL.Row = 3;
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
						if ((Operators.CompareString(TEXT_UPI.Text, "", false) != 0) & (Operators.CompareString(EntryMode, "E", false) != 0))
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

	private void MSG_OLD_CLEAR()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD.Clear();
		mSG_OLD.Cols = 17;
		mSG_OLD.FixedRows = 1;
		mSG_OLD.Rows = 2;
		mSG_OLD.Row = 1;
		mSG_OLD[0] = 0;
		mSG_OLD[1] = 0;
		mSG_OLD.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG_OLD[0] = (int)Math.Round(450.0 * ColCon);
			mSG_OLD[0] = 3;
			mSG_OLD[0, 0] = "Sr";
			mSG_OLD[1] = (int)Math.Round(850.0 * ColCon);
			mSG_OLD[1] = 0;
			mSG_OLD[0, 1] = "ItCode";
			mSG_OLD[2] = (int)Math.Round(1650.0 * ColCon);
			mSG_OLD[2] = 0;
			mSG_OLD[0, 2] = "ItName";
			mSG_OLD[3] = (int)Math.Round(500.0 * ColCon);
			mSG_OLD[3] = 7;
			mSG_OLD[0, 3] = "Pcs";
			mSG_OLD[4] = (int)Math.Round(925.0 * ColCon);
			mSG_OLD[4] = 7;
			mSG_OLD[0, 4] = "GrWt";
			mSG_OLD[5] = (int)Math.Round(800.0 * ColCon);
			mSG_OLD[5] = 7;
			mSG_OLD[0, 5] = "OthWt";
			mSG_OLD[6] = (int)Math.Round(925.0 * ColCon);
			mSG_OLD[6] = 7;
			mSG_OLD[0, 6] = "NetWt";
			mSG_OLD[7] = (int)Math.Round(675.0 * ColCon);
			mSG_OLD[7] = 3;
			mSG_OLD[0, 7] = "Touch";
			mSG_OLD[8] = (int)Math.Round(925.0 * ColCon);
			mSG_OLD[8] = 7;
			mSG_OLD[0, 8] = "Fine";
			mSG_OLD[9] = (int)Math.Round(650.0 * ColCon);
			mSG_OLD[9] = 3;
			mSG_OLD[0, 9] = "RTyp";
			mSG_OLD[10] = (int)Math.Round(900.0 * ColCon);
			mSG_OLD[10] = 7;
			mSG_OLD[0, 10] = "Rate";
			mSG_OLD[11] = (int)Math.Round(1000.0 * ColCon);
			mSG_OLD[11] = 7;
			mSG_OLD[0, 11] = "NetAmt";
			mSG_OLD[12] = 0;
			mSG_OLD[0, 12] = "ConWt";
			mSG_OLD[13] = 0;
			mSG_OLD[0, 13] = "OldRate";
			mSG_OLD[14] = 0;
			mSG_OLD[0, 14] = "OldNetAmt";
			mSG_OLD[15] = 0;
			mSG_OLD[0, 15] = "OldFine";
			mSG_OLD[16] = 0;
			mSG_OLD[0, 16] = "OldNwt";
			mSG_OLD.Row = 1;
			mSG_OLD.Col = 1;
			((Control)TEXT_IDTL).Visible = false;
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
		mSG_OLD[mSG_OLD.Row, 9] = "F";
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
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_017b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Invalid comparison between Unknown and I4
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Invalid comparison between Unknown and I4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Invalid comparison between Unknown and I4
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_0268: Invalid comparison between Unknown and I4
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Invalid comparison between Unknown and I4
		//IL_01fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Invalid comparison between Unknown and I4
		//IL_0480: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		MsgIdtlLeft = false;
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG_OLD.Col == 10)
			{
				if (Conversion.Val(TEXT_OLD.Text) == 0.0)
				{
					DC_Main.RsQry = "SELECT GR_RATE FROM  RATE_MAST AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND B.IT_CODE = '" + mSG_OLD[mSG_OLD.Row, 1] + "'";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num = default(double);
					if (dataTable.Rows.Count > 0)
					{
						num = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
					}
					if (num > 0.0)
					{
						TEXT_OLD.Text = Strings.Format((object)Math.Round(num / 10.0, 0), "0.00");
					}
					else
					{
						mSG_OLD[mSG_OLD.Row, 10] = "";
					}
				}
				return;
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num2 = mSG_OLD.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num2)
					{
						mSG_OLD[mSG_OLD.Row, DC_Main.M] = "";
						DC_Main.M++;
					}
					TEXT_OLD.Text = "";
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
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
				if (mSG_OLD.Col < 15)
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
							MSG2_TOTAL.Row = 8;
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
									mSG_OLD[mSG_OLD.Row, 12] = DC_Main.ColValue[4];
								}
								((Control)TEXT_OLD).Focus();
							}
							return;
						}
						mSG_OLD[mSG_OLD.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_OLD[mSG_OLD.Row, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						break;
					case 9:
						if ((Operators.CompareString(TEXT_OLD.Text, "N", false) != 0) & (Operators.CompareString(TEXT_OLD.Text, "F", false) != 0))
						{
							Interaction.MsgBox((object)"Please Slelect Rate type = N - Net Wise Or F - Fine Wise", (MsgBoxStyle)0, (object)null);
							return;
						}
						break;
					case 11:
						if (mSG_OLD.Row == mSG_OLD.Rows - 1)
						{
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
							{
								if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) != 0.0) & (Conversion.Val(TEXT_OLD.Text) != Conversion.Val(mSG_OLD[mSG_OLD.Row, 11])))
								{
									mSG_OLD[mSG_OLD.Row, 7] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * 100.0), "0.00");
									mSG_OLD[mSG_OLD.Row, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 7]) / 100.0), "0.000");
									mSG_OLD[mSG_OLD.Row, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), "0.000");
									if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
									{
										mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]), 0), "0.00");
									}
									else
									{
										mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), 0), "0.00");
									}
									mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), "0.00");
								}
								mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
								mSG_OLD[mSG_OLD.Row, 14] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
								CommPassTotal_Old(mSG_OLD.Row);
							}
							else
							{
								mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
								if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0))
								{
									if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
									{
										mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]), 0), "0.00");
									}
									else
									{
										mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), 0), "0.00");
									}
									mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), "0.00");
									mSG_OLD[mSG_OLD.Row, 14] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
									mSG_OLD[mSG_OLD.Row, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), "0.000");
								}
								CommPassTotal_Old(mSG_OLD.Row);
							}
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
				case 9:
					((TextBoxBase)TEXT_OLD).MaxLength = 1;
					TEXT_OLD.Text = mSG_OLD[mSG_OLD.Row, mSG_OLD.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_OLD).MaxLength = 6;
					TEXT_OLD.Text = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, mSG_OLD.Col]), "0");
					break;
				case 7:
				case 10:
				case 11:
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
		if (MsgClearIdtl || MSG_OLD.Row == 0 || MSG_OLD[MSG_OLD.Col] == 0 || !((Control)TEXT_OLD).Visible)
		{
			return;
		}
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		switch (MSG_OLD.Col)
		{
		case 0:
		case 1:
		case 2:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = TEXT_OLD.Text;
			break;
		case 9:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = TEXT_OLD.Text;
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 3:
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0");
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		case 7:
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
		case 11:
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM285NEKU", false) == 0)
			{
				if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) != 0.0) & (Conversion.Val(TEXT_OLD.Text) != Conversion.Val(mSG_OLD[mSG_OLD.Row, 11])))
				{
					mSG_OLD[mSG_OLD.Row, 7] = Strings.Format((object)(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * 100.0), "0.00");
					mSG_OLD[mSG_OLD.Row, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 7]) / 100.0), "0.000");
					mSG_OLD[mSG_OLD.Row, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), "0.000");
					double num = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), "0.000"));
					if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
					{
						mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]), 0), "0.00");
					}
					else
					{
						mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(TEXT_OLD.Text) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), 0), "0.00");
					}
					double num2 = Conversions.ToDouble(Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), "0.000"));
					mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), "0.00");
				}
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				mSG_OLD[mSG_OLD.Row, 14] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				CommPassTotal_Old(mSG_OLD.Row);
				break;
			}
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0))
			{
				if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]), 0), "0.00");
				}
				else
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), 0), "0.00");
				}
				mSG_OLD[mSG_OLD.Row, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]), "0.000");
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
				mSG_OLD[mSG_OLD.Row, 14] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			}
			CommPassTotal_Old(mSG_OLD.Row);
			break;
		}
		mSG_OLD = null;
	}

	private void CommPassTotal_Old(int CRow)
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		if (Conversion.Val(mSG_OLD[CRow, 5]) != 0.0)
		{
			mSG_OLD[CRow, 6] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 4]) - Conversion.Val(mSG_OLD[CRow, 5])), "0.000");
			if (Conversion.Val(mSG_OLD[CRow, 8]) == 0.0)
			{
				mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
			}
		}
		else
		{
			mSG_OLD[CRow, 6] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 4]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 6]) != Conversion.Val(mSG_OLD[CRow, 16]))
		{
			mSG_OLD[CRow, 16] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
			if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
			{
				mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
			}
			mSG_OLD[mSG_OLD.Row, 13] = Conversions.ToString(0);
			mSG_OLD[CRow, 15] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 8]), "0.000");
		}
		if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 8]) == 0.0)
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 8]) != Conversion.Val(mSG_OLD[CRow, 15]))
		{
			mSG_OLD[mSG_OLD.Row, 13] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_OLD[CRow, 11]) != Conversion.Val(mSG_OLD[CRow, 14])) & (Conversion.Val(mSG_OLD[CRow, 8]) != 0.0))
		{
			if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
			{
				mSG_OLD[CRow, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[CRow, 11]) / Conversion.Val(mSG_OLD[CRow, 6]), 0), "0.00");
			}
			else
			{
				mSG_OLD[CRow, 10] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[CRow, 11]) / Conversion.Val(mSG_OLD[CRow, 8]), 0), "0.00");
			}
			mSG_OLD[mSG_OLD.Row, 14] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]), "0.00");
		}
		if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) != Conversion.Val(mSG_OLD[mSG_OLD.Row, 13]))
		{
			if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
			{
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), 0), "0.00");
			}
			else
			{
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), 0), "0.00");
			}
			mSG_OLD[mSG_OLD.Row, 13] = Strings.Format((object)Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), "0.00");
		}
		if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
		{
			if ((Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OG", false) == 0) & (ToDayGlRate != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 11]) != 0.0))
			{
				mSG_OLD[CRow, 7] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 11]) / ToDayGlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0), "0.00");
			}
			if ((Operators.CompareString(mSG_OLD[mSG_OLD.Row, 1], "OS", false) == 0) & (ToDaySlRate != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 11]) != 0.0))
			{
				mSG_OLD[CRow, 7] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 11]) / ToDaySlRate / Conversion.Val(mSG_OLD[CRow, 6]) * 100.0), "0.00");
			}
			if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
			{
				mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
			}
		}
		BILL_TOTAL();
		mSG_OLD = null;
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
		mSG_IDTL[mSG_IDTL.Row, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 47]));
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
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
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
				MSG[MSG.Row, 10] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 11] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - Conversion.Val(MSG[MSG.Row, 10])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 31] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 32] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - Conversion.Val(MSG[MSG.Row, 31])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 24] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 40] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 11] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 9]) - num2), "0.000");
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

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 87;
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
			mSG[2] = (int)Math.Round(1000.0 * ColCon);
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
			mSG[5] = (int)Math.Round(1200.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Color";
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
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "BagWt";
			mSG[8] = (int)Math.Round(700.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Pcs";
			mSG[9] = (int)Math.Round(1000.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "GrWt";
			mSG[10] = (int)Math.Round(900.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "LsWt";
			mSG[11] = (int)Math.Round(1000.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "NetWt";
			mSG[31] = (int)Math.Round(0.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "KrOthWt";
			mSG[32] = (int)Math.Round(0.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "KrNwt";
			mSG[33] = (int)Math.Round(0.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrGht%";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrGht";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrTouch";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrWst%";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrFine";
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
			mSG[21] = (int)Math.Round(800.0 * ColCon);
			mSG[21] = 3;
			mSG[0, 21] = "LType";
			mSG[22] = (int)Math.Round(900.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "LbrRate";
			mSG[23] = (int)Math.Round(950.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "LbrAmt";
			mSG[24] = (int)Math.Round(1000.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "OthAmt";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "KrLRate";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "KrLAmt";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrOthAmt";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "PrCost";
			mSG[17] = (int)Math.Round(800.0 * ColCon);
			mSG[17] = 3;
			mSG[0, 17] = "RtFix";
			mSG[18] = (int)Math.Round(1000.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "ItRate";
			mSG[19] = (int)Math.Round(1100.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "ItAmt";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "TagCost";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "Margin";
			mSG[25] = (int)Math.Round(900.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Mrp";
			mSG[26] = (int)Math.Round(1200.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "DelDate";
			mSG[27] = (int)Math.Round(1100.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "TotAmt";
			mSG[28] = (int)Math.Round(800.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "Tax%";
			mSG[29] = (int)Math.Round(1100.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "NetAmt";
			mSG[45] = (int)Math.Round(0.0 * ColCon);
			mSG[45] = 3;
			mSG[0, 45] = "Image";
			mSG[30] = (int)Math.Round(0.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "KrCode";
			mSG[46] = 0;
			mSG[47] = 0;
			mSG[48] = 0;
			mSG[49] = 0;
			mSG[50] = 0;
			mSG[51] = 0;
			mSG[42] = 0;
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
			mSG[83] = 0;
			mSG[82] = 0;
			mSG[84] = 0;
			mSG[85] = 0;
			mSG[86] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'SALE_ORDER' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
					mSG_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 43]) + Conversion.Val(MSG[DC_Main.M, 43]))), "0.00");
					mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.000");
					mSG_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 27]) + Conversion.Val(MSG[DC_Main.M, 27]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 31]) + Conversion.Val(MSG[DC_Main.M, 31]))), "0.000");
					mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.000");
					mSG_TOT[0, 34] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 34]) + Conversion.Val(MSG[DC_Main.M, 34]))), "0.000");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.000");
					mSG_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 39]) + Conversion.Val(MSG[DC_Main.M, 39]))), "0.00");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.00");
					mSG_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 41]) + Conversion.Val(MSG[DC_Main.M, 41]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 23]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 8] = Conversions.ToString(1);
		mSG[mSG.Row, 21] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 47] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 47] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 47]) + 1.0);
		}
		mSG[mSG.Row, 53] = "A";
		mSG[mSG.Row, 45] = "N";
		mSG[mSG.Row, 66] = "N";
		mSG[mSG.Row, 67] = "N";
		mSG[mSG.Row, 68] = "N";
		mSG[mSG.Row, 17] = "N";
		mSG[mSG.Row, 70] = DC_Main.MsOrdTagLessInStk;
		mSG[mSG.Row, 71] = "N";
		mSG[mSG.Row, 80] = "N";
		if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
		{
			mSG[mSG.Row, 3] = "002";
		}
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
				if ((mSG.Col != 3) & (mSG.Col != 4) & (mSG.Col != 6))
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
			case 30:
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
				break;
			case 26:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 17:
			case 21:
			case 45:
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
			case 35:
			case 36:
			case 44:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
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
			case 38:
			case 39:
			case 40:
			case 41:
			case 43:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 7:
			case 9:
			case 10:
			case 11:
			case 13:
			case 31:
			case 32:
			case 33:
			case 34:
			case 37:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 16:
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
		case 21:
		case 26:
		case 30:
		case 45:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 8:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 28:
			CommPassTotal();
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			break;
		case 12:
		case 14:
		case 15:
		case 20:
		case 35:
		case 36:
		case 44:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 18:
		case 19:
		case 22:
		case 23:
		case 24:
		case 25:
		case 27:
		case 29:
		case 38:
		case 39:
		case 40:
		case 41:
		case 43:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 10:
		case 31:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 7:
		case 9:
		case 11:
		case 13:
		case 16:
		case 32:
		case 33:
		case 34:
		case 37:
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
		double num5 = default(double);
		string text = default(string);
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
				case 11814:
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
							goto IL_004b;
						case 5:
							goto IL_007e;
						case 6:
							goto IL_00c5;
						case 7:
							goto IL_010c;
						case 8:
							goto IL_0122;
						case 9:
						case 10:
							goto IL_013b;
						case 11:
							goto IL_0187;
						case 12:
						case 13:
							goto IL_01d1;
						case 14:
							goto IL_021d;
						case 15:
						case 16:
							goto IL_0271;
						case 17:
							goto IL_02bc;
						case 18:
							goto IL_0304;
						case 19:
							goto IL_0364;
						case 21:
							goto IL_03e2;
						case 20:
						case 22:
						case 23:
							goto IL_0417;
						case 24:
							goto IL_042e;
						case 25:
						case 26:
							goto IL_0448;
						case 27:
							goto IL_047f;
						case 28:
							goto IL_04b3;
						case 29:
							goto IL_0513;
						case 30:
						case 31:
							goto IL_058f;
						case 32:
							goto IL_05a6;
						case 33:
						case 34:
							goto IL_05c0;
						case 35:
							goto IL_05f7;
						case 36:
							goto IL_062b;
						case 37:
							goto IL_068b;
						case 38:
						case 39:
							goto IL_0707;
						case 40:
							goto IL_071e;
						case 41:
						case 42:
							goto IL_0738;
						case 43:
							goto IL_0773;
						case 44:
						case 45:
							goto IL_07bd;
						case 46:
							goto IL_0809;
						case 47:
						case 48:
							goto IL_0853;
						case 49:
							goto IL_088a;
						case 50:
							goto IL_08be;
						case 51:
							goto IL_091e;
						case 53:
							goto IL_099c;
						case 52:
						case 54:
						case 55:
						case 56:
							goto IL_09d3;
						case 57:
							goto IL_0a0a;
						case 58:
							goto IL_0a3e;
						case 59:
							goto IL_0a9e;
						case 60:
						case 61:
						case 62:
							goto IL_0b1c;
						case 63:
							goto IL_0b53;
						case 64:
							goto IL_0b87;
						case 65:
							goto IL_0be7;
						case 66:
						case 67:
						case 68:
							goto IL_0c65;
						case 69:
							goto IL_0ca0;
						case 70:
						case 71:
							goto IL_0cea;
						case 72:
							goto IL_0cf8;
						case 73:
							goto IL_0d02;
						case 74:
							goto IL_0d0c;
						case 75:
							goto IL_0d28;
						case 76:
							goto IL_0d3f;
						case 77:
							goto IL_0da2;
						case 78:
							goto IL_0e14;
						case 79:
							goto IL_0e37;
						case 81:
							goto IL_0e78;
						case 84:
							goto IL_0e95;
						case 87:
							goto IL_0eb1;
						case 88:
							goto IL_0eca;
						case 90:
							goto IL_0ee6;
						case 80:
						case 82:
						case 83:
						case 85:
						case 86:
						case 89:
						case 91:
						case 92:
							goto IL_0f13;
						case 93:
							goto IL_0f4a;
						case 94:
							goto IL_0f7e;
						case 95:
							goto IL_0f96;
						case 97:
							goto IL_0fdf;
						case 99:
							goto IL_1032;
						case 101:
							goto IL_107f;
						case 103:
							goto IL_10c9;
						case 96:
						case 98:
						case 100:
						case 102:
						case 104:
						case 105:
							goto IL_1109;
						case 106:
						case 107:
							goto IL_1167;
						case 108:
							goto IL_119e;
						case 109:
							goto IL_11d2;
						case 110:
							goto IL_11e9;
						case 111:
							goto IL_126b;
						case 113:
							goto IL_12b4;
						case 115:
							goto IL_1307;
						case 117:
							goto IL_1354;
						case 119:
							goto IL_139e;
						case 112:
						case 114:
						case 116:
						case 118:
						case 120:
						case 121:
						case 122:
						case 123:
							goto IL_13e2;
						case 124:
							goto IL_1419;
						case 125:
							goto IL_144d;
						case 126:
							goto IL_1464;
						case 127:
							goto IL_14b4;
						case 129:
							goto IL_14fd;
						case 131:
							goto IL_1557;
						case 133:
							goto IL_15b2;
						case 135:
							goto IL_162b;
						case 136:
							goto IL_164a;
						case 138:
							goto IL_16a3;
						case 128:
						case 130:
						case 132:
						case 134:
						case 137:
						case 139:
						case 140:
						case 141:
							goto IL_1710;
						case 142:
						case 143:
							goto IL_1749;
						case 144:
						case 145:
							goto IL_17aa;
						case 146:
							goto IL_1806;
						case 147:
							goto IL_183d;
						case 148:
							goto IL_189c;
						case 149:
						case 150:
							goto IL_18b8;
						case 151:
							goto IL_18f9;
						case 152:
							goto IL_1930;
						case 153:
							goto IL_194b;
						case 155:
							goto IL_1997;
						case 157:
							goto IL_19ed;
						case 159:
							goto IL_1a44;
						case 161:
							goto IL_1ab9;
						case 162:
							goto IL_1ad8;
						case 164:
							goto IL_1b2d;
						case 154:
						case 156:
						case 158:
						case 160:
						case 163:
						case 165:
						case 166:
						case 167:
							goto IL_1b96;
						case 168:
						case 169:
							goto IL_1bf7;
						case 170:
							goto IL_1c42;
						case 171:
							goto IL_1c7c;
						case 172:
							goto IL_1cb3;
						case 173:
							goto IL_1ccd;
						case 174:
							goto IL_1d2c;
						case 175:
							goto IL_1d56;
						case 176:
						case 177:
							goto IL_1d72;
						case 178:
							goto IL_1da2;
						case 179:
							goto IL_1df5;
						case 181:
							goto IL_1e41;
						case 183:
							goto IL_1e9b;
						case 185:
							goto IL_1ef6;
						case 187:
							goto IL_1f6f;
						case 188:
							goto IL_1f8e;
						case 190:
							goto IL_1fe7;
						case 180:
						case 182:
						case 184:
						case 186:
						case 189:
						case 191:
						case 192:
						case 193:
						case 194:
						case 195:
						case 196:
							goto IL_205a;
						case 197:
							goto IL_2087;
						case 198:
							goto IL_20be;
						case 199:
							goto IL_20d8;
						case 200:
						case 201:
							goto IL_20f4;
						case 202:
							goto IL_210d;
						case 203:
							goto IL_2141;
						case 204:
							goto IL_2175;
						case 205:
						case 206:
						case 207:
							goto IL_2193;
						case 208:
							goto IL_21be;
						case 209:
							goto IL_21d8;
						case 210:
							goto IL_2208;
						case 211:
							goto IL_226d;
						case 212:
							goto IL_22d2;
						case 213:
							goto IL_2302;
						case 214:
							goto IL_234b;
						case 216:
							goto IL_239b;
						case 217:
							goto IL_23e5;
						case 219:
							goto IL_2436;
						case 220:
							goto IL_2480;
						case 222:
							goto IL_24db;
						case 223:
							goto IL_2528;
						case 224:
							goto IL_2547;
						case 226:
							goto IL_2596;
						case 215:
						case 218:
						case 221:
						case 225:
						case 227:
						case 228:
						case 229:
						case 230:
							goto IL_25f9;
						case 231:
							goto IL_2630;
						case 232:
							goto IL_2667;
						case 233:
							goto IL_269e;
						case 234:
							goto IL_26d5;
						case 235:
							goto IL_270c;
						case 236:
							goto IL_275b;
						case 237:
						case 238:
							goto IL_27b2;
						case 239:
						case 240:
						case 241:
							goto IL_27ed;
						case 242:
							goto IL_281a;
						case 243:
							goto IL_2847;
						case 244:
							goto IL_2892;
						case 245:
						case 246:
							goto IL_28e9;
						case 247:
							goto IL_2948;
						case 249:
							goto IL_2983;
						case 250:
							goto IL_29ba;
						case 248:
						case 251:
						case 252:
						case 253:
							goto IL_29f5;
						case 254:
							goto IL_29f7;
						case 255:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 256:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_29ba:
					num2 = 250;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_29f5;
					IL_29f5:
					val = null;
					goto IL_29f7;
					IL_2983:
					num2 = 249;
					val[val.Row, 27] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_29ba;
					IL_29f7:
					num2 = 254;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 56]))
					{
						goto IL_004b;
					}
					goto IL_013b;
					IL_004b:
					num2 = 4;
					val[val.Row, 56] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 31])), "0.000");
					goto IL_010c;
					IL_010c:
					num2 = 7;
					val[val.Row, 80] = "N";
					goto IL_0122;
					IL_0122:
					num2 = 8;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_013b;
					IL_013b:
					num2 = 10;
					if ((Conversion.Val(val[val.Row, 10]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0187;
					}
					goto IL_01d1;
					IL_0187:
					num2 = 11;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_01d1;
					IL_01d1:
					num2 = 13;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_021d;
					}
					goto IL_0271;
					IL_021d:
					num2 = 14;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 12]) / 100.0), "0.000");
					goto IL_0271;
					IL_0271:
					num2 = 16;
					if (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 57]))
					{
						goto IL_02bc;
					}
					goto IL_0448;
					IL_02bc:
					num2 = 17;
					val[val.Row, 57] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_0304;
					IL_0304:
					num2 = 18;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0364;
					}
					goto IL_03e2;
					IL_0364:
					num2 = 19;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0417;
					IL_03e2:
					num2 = 21;
					val[val.Row, 16] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_0417;
					IL_0417:
					num2 = 23;
					val[val.Row, 80] = "N";
					goto IL_042e;
					IL_042e:
					num2 = 24;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_0448;
					IL_0448:
					num2 = 26;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_047f;
					}
					goto IL_05c0;
					IL_047f:
					num2 = 27;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.00");
					goto IL_04b3;
					IL_04b3:
					num2 = 28;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0513;
					}
					goto IL_058f;
					IL_0513:
					num2 = 29;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_058f;
					IL_058f:
					num2 = 31;
					val[val.Row, 80] = "N";
					goto IL_05a6;
					IL_05a6:
					num2 = 32;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_05c0;
					IL_05c0:
					num2 = 34;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 61]))
					{
						goto IL_05f7;
					}
					goto IL_0738;
					IL_05f7:
					num2 = 35;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_062b;
					IL_062b:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_068b;
					}
					goto IL_0707;
					IL_068b:
					num2 = 37;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0707;
					IL_0707:
					num2 = 39;
					val[val.Row, 80] = "N";
					goto IL_071e;
					IL_071e:
					num2 = 40;
					val[val.Row, 83] = Conversions.ToString(0);
					goto IL_0738;
					IL_0738:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) == 0.0)
					{
						goto IL_0773;
					}
					goto IL_07bd;
					IL_0773:
					num2 = 43;
					val[val.Row, 16] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_07bd;
					IL_07bd:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0809;
					}
					goto IL_0853;
					IL_0809:
					num2 = 46;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 31])), "0.000");
					goto IL_0853;
					IL_0853:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 32]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_088a;
					}
					goto IL_09d3;
					IL_088a:
					num2 = 49;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 32]), "0.000");
					goto IL_08be;
					IL_08be:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_091e;
					}
					goto IL_099c;
					IL_091e:
					num2 = 51;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_09d3;
					IL_099c:
					num2 = 53;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 32]), "0.000");
					goto IL_09d3;
					IL_09d3:
					num2 = 56;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_0a0a;
					}
					goto IL_0b1c;
					IL_0a0a:
					num2 = 57;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_0a3e;
					IL_0a3e:
					num2 = 58;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_0a9e;
					}
					goto IL_0b1c;
					IL_0a9e:
					num2 = 59;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_0b1c;
					IL_0b1c:
					num2 = 62;
					if (Conversion.Val(val[val.Row, 36]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_0b53;
					}
					goto IL_0c65;
					IL_0b53:
					num2 = 63;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.00");
					goto IL_0b87;
					IL_0b87:
					num2 = 64;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_0be7;
					}
					goto IL_0c65;
					IL_0be7:
					num2 = 65;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_0c65;
					IL_0c65:
					num2 = 68;
					if (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_0ca0;
					}
					goto IL_0cea;
					IL_0ca0:
					num2 = 69;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])), "0.000");
					goto IL_0cea;
					IL_0cea:
					num2 = 71;
					num5 = 0.0;
					goto IL_0cf8;
					IL_0cf8:
					num2 = 72;
					text = "N";
					goto IL_0d02;
					IL_0d02:
					num2 = 73;
					text = DC_Main.MsSlAmtType;
					goto IL_0d0c;
					IL_0d0c:
					num2 = 74;
					if (Operators.CompareString(text, "F", false) == 0)
					{
						goto IL_0d28;
					}
					goto IL_0eb1;
					IL_0d28:
					num2 = 75;
					if (val[16] != 0)
					{
						goto IL_0d3f;
					}
					goto IL_0e95;
					IL_0d3f:
					num2 = 76;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_0da2;
					}
					goto IL_0e78;
					IL_0da2:
					num2 = 77;
					num5 = Conversions.ToDouble(Strings.Format((object)((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000"));
					goto IL_0e14;
					IL_0e14:
					num2 = 78;
					val[val.Row, 16] = Strings.Format((object)num5, "0.000");
					goto IL_0e37;
					IL_0e37:
					num2 = 79;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_0f13;
					IL_0e78:
					num2 = 81;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_0f13;
					IL_0e95:
					num2 = 84;
					num5 = Conversion.Val(val[val.Row, 11]);
					goto IL_0f13;
					IL_0eb1:
					num2 = 87;
					if (Operators.CompareString(text, "G", false) == 0)
					{
						goto IL_0eca;
					}
					goto IL_0ee6;
					IL_0eca:
					num2 = 88;
					num5 = Conversion.Val(val[val.Row, 9]);
					goto IL_0f13;
					IL_0ee6:
					num2 = 90;
					num5 = Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13]);
					goto IL_0f13;
					IL_0f13:
					num2 = 92;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 83]))
					{
						goto IL_0f4a;
					}
					goto IL_1167;
					IL_0f4a:
					num2 = 93;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_0f7e;
					IL_0f7e:
					num2 = 94;
					val[val.Row, 80] = "N";
					goto IL_0f96;
					IL_0f96:
					num2 = 95;
					switch (val[val.Row, 48])
					{
					case "P":
						break;
					case "1":
						goto IL_1032;
					case "K":
						goto IL_107f;
					default:
						goto IL_10c9;
					}
					goto IL_0fdf;
					IL_10c9:
					num2 = 103;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1109;
					IL_107f:
					num2 = 101;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * (Conversion.Val(val[val.Row, 18]) / 1000.0), 0), "0.00");
					goto IL_1109;
					IL_1032:
					num2 = 99;
					val[val.Row, 19] = Strings.Format((object)Math.Round(num5 * (Conversion.Val(val[val.Row, 18]) / 10.0), 0), "0.00");
					goto IL_1109;
					IL_0fdf:
					num2 = 97;
					val[val.Row, 19] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 18]), 0), "0.00");
					goto IL_1109;
					IL_1109:
					num2 = 105;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_1167;
					IL_1167:
					num2 = 107;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 82]))
					{
						goto IL_119e;
					}
					goto IL_13e2;
					IL_119e:
					num2 = 108;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_11d2;
					IL_11d2:
					num2 = 109;
					val[val.Row, 80] = "N";
					goto IL_11e9;
					IL_11e9:
					num2 = 110;
					if ((Conversion.Val(val[val.Row, 18]) == 0.0) & (Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_126b;
					}
					goto IL_13e2;
					IL_126b:
					num2 = 111;
					switch (val[val.Row, 48])
					{
					case "P":
						break;
					case "1":
						goto IL_1307;
					case "K":
						goto IL_1354;
					default:
						goto IL_139e;
					}
					goto IL_12b4;
					IL_139e:
					num2 = 119;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / num5, 2), "0.00");
					goto IL_13e2;
					IL_1354:
					num2 = 117;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / num5 * 1000.0, 2), "0.00");
					goto IL_13e2;
					IL_1307:
					num2 = 115;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / num5 * 10.0, 2), "0.00");
					goto IL_13e2;
					IL_12b4:
					num2 = 113;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) / Conversion.Val(val[val.Row, 8]), 2), "0.00");
					goto IL_13e2;
					IL_13e2:
					num2 = 123;
					if (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 85]))
					{
						goto IL_1419;
					}
					goto IL_17aa;
					IL_1419:
					num2 = 124;
					val[val.Row, 85] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_144d;
					IL_144d:
					num2 = 125;
					val[val.Row, 80] = "N";
					goto IL_1464;
					IL_1464:
					num2 = 126;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_14b4;
					}
					goto IL_1749;
					IL_14b4:
					num2 = 127;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "G":
						goto IL_1557;
					case "K":
						goto IL_15b2;
					default:
						goto IL_162b;
					}
					goto IL_14fd;
					IL_162b:
					num2 = 135;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_164a;
					}
					goto IL_16a3;
					IL_164a:
					num2 = 136;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_1710;
					IL_16a3:
					num2 = 138;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), DC_Main.MsLbrRof), "0.00");
					goto IL_1710;
					IL_15b2:
					num2 = 133;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1710;
					IL_1557:
					num2 = 131;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_1710;
					IL_14fd:
					num2 = 129;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_1710;
					IL_1710:
					num2 = 141;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1749;
					IL_1749:
					num2 = 143;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_17aa;
					IL_17aa:
					num2 = 145;
					if ((Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 86])) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_1806;
					}
					goto IL_18b8;
					IL_1806:
					num2 = 146;
					val[val.Row, 86] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_183d;
					IL_183d:
					num2 = 147;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * Conversion.Val(val[val.Row, 20]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_189c;
					IL_189c:
					num2 = 148;
					val[val.Row, 80] = "N";
					goto IL_18b8;
					IL_18b8:
					num2 = 150;
					if (0u - ((Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 84])) ? 1u : 0u) != 0)
					{
						goto IL_18f9;
					}
					goto IL_1bf7;
					IL_18f9:
					num2 = 151;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_1930;
					IL_1930:
					num2 = 152;
					val[val.Row, 80] = "N";
					goto IL_194b;
					IL_194b:
					num2 = 153;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "G":
						goto IL_19ed;
					case "K":
						goto IL_1a44;
					default:
						goto IL_1ab9;
					}
					goto IL_1997;
					IL_1ab9:
					num2 = 161;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1ad8;
					}
					goto IL_1b2d;
					IL_1ad8:
					num2 = 162;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_1b96;
					IL_1b2d:
					num2 = 164;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_1b96;
					IL_1a44:
					num2 = 159;
					val[val.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) * (Conversion.Val(val[val.Row, 22]) / 1000.0), 0), "0.00");
					goto IL_1b96;
					IL_19ed:
					num2 = 157;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_1b96;
					IL_1997:
					num2 = 155;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 22]), 0), "0.00");
					goto IL_1b96;
					IL_1b96:
					num2 = 167;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_1bf7;
					IL_1bf7:
					num2 = 169;
					val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])), "0.0");
					goto IL_1c42;
					IL_1c42:
					num2 = 170;
					if (Conversion.Val(val[val.Row, 27]) != Conversion.Val(val[val.Row, 81]))
					{
						goto IL_1c7c;
					}
					goto IL_205a;
					IL_1c7c:
					num2 = 171;
					val[val.Row, 81] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_1cb3;
					IL_1cb3:
					num2 = 172;
					val[val.Row, 80] = "N";
					goto IL_1ccd;
					IL_1ccd:
					num2 = 173;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 27]) - Conversion.Val(val[val.Row, 24]) - Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_1d2c;
					IL_1d2c:
					num2 = 174;
					if (Conversion.Val(val[val.Row, 23]) < 0.0)
					{
						goto IL_1d56;
					}
					goto IL_1d72;
					IL_1d56:
					num2 = 175;
					val[val.Row, 23] = "";
					goto IL_1d72;
					IL_1d72:
					num2 = 177;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_1da2;
					}
					goto IL_205a;
					IL_1da2:
					num2 = 178;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_1df5;
					}
					goto IL_205a;
					IL_1df5:
					num2 = 179;
					switch (val[val.Row, 21])
					{
					case "P":
						break;
					case "G":
						goto IL_1e9b;
					case "K":
						goto IL_1ef6;
					default:
						goto IL_1f6f;
					}
					goto IL_1e41;
					IL_1f6f:
					num2 = 187;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_1f8e;
					}
					goto IL_1fe7;
					IL_1f8e:
					num2 = 188;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_205a;
					IL_1fe7:
					num2 = 190;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])), DC_Main.MsLbrRof), "0.00");
					goto IL_205a;
					IL_1ef6:
					num2 = 185;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_205a;
					IL_1e9b:
					num2 = 183;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_205a;
					IL_1e41:
					num2 = 181;
					val[val.Row, 22] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_205a;
					IL_205a:
					num2 = 196;
					if (Conversion.Val(val[val.Row, 25]) != 0.0)
					{
						goto IL_2087;
					}
					goto IL_20f4;
					IL_2087:
					num2 = 197;
					val[val.Row, 27] = Strings.Format((object)Conversion.Val(val[val.Row, 25]), "0.00");
					goto IL_20be;
					IL_20be:
					num2 = 198;
					val[val.Row, 24] = "";
					goto IL_20d8;
					IL_20d8:
					num2 = 199;
					val[val.Row, 19] = "";
					goto IL_20f4;
					IL_20f4:
					num2 = 201;
					if (val.Col == 28)
					{
						goto IL_210d;
					}
					goto IL_2193;
					IL_210d:
					num2 = 202;
					if (Conversion.Val(TEXT_ENTRY.Text) != Conversion.Val(val[val.Row, 28]))
					{
						goto IL_2141;
					}
					goto IL_2193;
					IL_2141:
					num2 = 203;
					val[val.Row, 28] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
					goto IL_2175;
					IL_2175:
					num2 = 204;
					val[val.Row, 80] = "N";
					goto IL_2193;
					IL_2193:
					num2 = 207;
					if (Operators.CompareString(val[val.Row, 80], "N", false) == 0)
					{
						goto IL_21be;
					}
					goto IL_27ed;
					IL_21be:
					num2 = 208;
					val[val.Row, 80] = "Y";
					goto IL_21d8;
					IL_21d8:
					num2 = 209;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_2208;
					}
					goto IL_27ed;
					IL_2208:
					num2 = 210;
					val[val.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 28]) + 100.0) * 100.0, 0), "0.00");
					goto IL_226d;
					IL_226d:
					num2 = 211;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 19]) - Conversion.Val(val[val.Row, 24]), 0), "0.00");
					goto IL_22d2;
					IL_22d2:
					num2 = 212;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_2302;
					}
					goto IL_25f9;
					IL_2302:
					num2 = 213;
					if ((Operators.CompareString(val[val.Row, 21], "P", false) == 0) & (Conversion.Val(val[val.Row, 8]) != 0.0))
					{
						goto IL_234b;
					}
					goto IL_239b;
					IL_234b:
					num2 = 214;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 8])), "0.00");
					goto IL_25f9;
					IL_239b:
					num2 = 216;
					if ((Operators.CompareString(val[val.Row, 21], "G", false) == 0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_23e5;
					}
					goto IL_2436;
					IL_23e5:
					num2 = 217;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9])), "0.00");
					goto IL_25f9;
					IL_2436:
					num2 = 219;
					if ((Operators.CompareString(val[val.Row, 21], "K", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_2480;
					}
					goto IL_24db;
					IL_2480:
					num2 = 220;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 9]) * 1000.0), "0.00");
					goto IL_25f9;
					IL_24db:
					num2 = 222;
					if ((Operators.CompareString(val[val.Row, 21], "N", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_2528;
					}
					goto IL_25f9;
					IL_2528:
					num2 = 223;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_2547;
					}
					goto IL_2596;
					IL_2547:
					num2 = 224;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / Conversion.Val(val[val.Row, 11])), "0.00");
					goto IL_25f9;
					IL_2596:
					num2 = 226;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) / (Conversion.Val(val[val.Row, 11]) + Conversion.Val(val[val.Row, 13]))), "0.00");
					goto IL_25f9;
					IL_25f9:
					num2 = 230;
					val[val.Row, 83] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_2630;
					IL_2630:
					num2 = 231;
					val[val.Row, 82] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_2667;
					IL_2667:
					num2 = 232;
					val[val.Row, 84] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_269e;
					IL_269e:
					num2 = 233;
					val[val.Row, 85] = Strings.Format((object)Conversion.Val(val[val.Row, 23]), "0.00");
					goto IL_26d5;
					IL_26d5:
					num2 = 234;
					val[val.Row, 81] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_270c;
					IL_270c:
					num2 = 235;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_275b;
					}
					goto IL_27b2;
					IL_275b:
					num2 = 236;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_27b2;
					IL_27b2:
					num2 = 238;
					val[val.Row, 86] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_27ed;
					IL_27ed:
					num2 = 241;
					if (Conversion.Val(val[val.Row, 28]) == 0.0)
					{
						goto IL_281a;
					}
					goto IL_29f5;
					IL_281a:
					num2 = 242;
					if (Conversion.Val(val[val.Row, 25]) == 0.0)
					{
						goto IL_2847;
					}
					goto IL_2983;
					IL_2847:
					num2 = 243;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val((object)val[20]) > 0.0))
					{
						goto IL_2892;
					}
					goto IL_28e9;
					IL_2892:
					num2 = 244;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 22]) * 100.0 / Conversion.Val(val[val.Row, 18])), "0.00");
					goto IL_28e9;
					IL_28e9:
					num2 = 246;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 23]) + Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_2948;
					IL_2948:
					num2 = 247;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_29f5;
					end_IL_0001_2:
					break;
				}
				num2 = 255;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 11814;
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
		//IL_045b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045e: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa4: Invalid comparison between Unknown and I4
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Invalid comparison between Unknown and I4
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_048b: Invalid comparison between Unknown and I4
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acd: Invalid comparison between Unknown and I4
		//IL_053e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b21: Invalid comparison between Unknown and I4
		//IL_0b9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9d: Invalid comparison between Unknown and I4
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf1: Invalid comparison between Unknown and I4
		//IL_0c49: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4c: Invalid comparison between Unknown and I4
		//IL_0a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_30c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1052: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f1: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,SR_NO FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + mSG[mSG.Row, 42] + " ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("You Cant Delete This Order Because  This Tag " + mSG[mSG.Row, 1] + " Sales With  Book =  "), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" And Vch No = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" And Sr No = "), DC_Main.Tbl.Rows[0]["SR_NO"]), (object)" ... "), (MsgBoxStyle)0, (object)null);
					return;
				}
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.ORD_NO = '',BAR_DETL.ORD_YRCD = '', BAR_DETL.ORD_DBCD = '',ORD_SRNO = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + mSG[mSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42])) + " ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 47]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][20])) == Conversion.Val(mSG[mSG.Row, 47]))
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
							mSG[mSG.Row, 47] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 47] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 47]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 66] = "N";
					mSG[mSG.Row, 67] = "N";
					mSG[mSG.Row, 68] = "N";
					mSG[mSG.Row, 17] = "N";
					mSG[mSG.Row, 70] = DC_Main.MsOrdTagLessInStk;
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 26)
			{
				if ((int)Interaction.MsgBox((object)"This Design Re Isu For Ghat...?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
				{
					DC_Main.RsQry = "UPDATE B SET B.DESIGN_ISU = 'N' FROM SL_ORD_DETL AS B WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 47])) + " ";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Interaction.MsgBox((object)"Design Re Isu Is UPdate...", (MsgBoxStyle)0, (object)null);
				}
				return;
			}
			if (mSG.Col == 4)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,A.DIE_NO As RemarkL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 2] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 2] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[12];
				DC_Main.ColWidth[0] = 120.0;
				DC_Main.ColWidth[1] = 120.0;
				DC_Main.ColWidth[2] = 150.0;
				DC_Main.ColWidth[3] = 90.0;
				DC_Main.ColWidth[4] = 100.0;
				DC_Main.ColWidth[5] = 100.0;
				DC_Main.ColWidth[6] = 80.0;
				DC_Main.ColWidth[7] = 80.0;
				DC_Main.ColWidth[8] = 80.0;
				DC_Main.ColWidth[9] = 90.0;
				DC_Main.ColWidth[10] = 0.0;
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
					mSG[mSG.Row, 6] = DC_Main.ColValue[3];
					mSG[mSG.Row, 30] = DC_Main.ColValue[4];
					if (Operators.CompareString(mSG[mSG.Row, 53], "E", false) != 0)
					{
						if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
						{
							mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
						{
							mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
						{
							mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) == 0.0 && Conversion.Val(DC_Main.ColValue[9]) != 0.0)
						{
							mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[9]), "0.00");
						}
					}
					mSG[mSG.Row, 71] = DC_Main.ColValue[10];
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				else
				{
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 4] = "";
					mSG[mSG.Row, 71] = "N";
				}
				((Control)TEXT_ENTRY).Focus();
				return;
			}
			if (mSG.Col == 18)
			{
				if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
				{
					DC_Main.RsQry = "SELECT GR_RATE FROM  RATE_MAST AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.GR_CODE = B.GR_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND B.IT_CODE = '" + mSG[mSG.Row, 2] + "'";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					double num4 = default(double);
					if (dataTable.Rows.Count > 0)
					{
						num4 = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
					}
					if (num4 > 0.0)
					{
						TEXT_ENTRY.Text = Strings.Format((object)Math.Round(num4 / 10.0, 0), "0.00");
					}
					else
					{
						Interaction.MsgBox((object)"Please Insert Rate In Rate Master...and Try....", (MsgBoxStyle)0, (object)null);
					}
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
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 42]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
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
									mSG[mSG.Row, 52] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 42] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 42] = "";
									mSG[mSG.Row, 1] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
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
						mSG[mSG.Row, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								mSG[mSG.Row, 52] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 42] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 42]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
							{
								mSG[mSG.Row, 3] = "002";
							}
							else
							{
								mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							}
							mSG[DC_Main.i, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
							mSG[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							if (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0)
							{
								if (Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) == 0.0)
								{
									if ((Conversion.Val(mSG[mSG.Row, 25]) == 0.0) & (DC_Main.RtView != null))
									{
										DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
										DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										double num6 = default(double);
										if (dataTable2.Rows.Count > 0)
										{
											num6 = Conversions.ToDouble(dataTable2.Rows[0]["GR_RATE"]);
										}
										else
										{
											DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
											if (DC_Main.RtView.Count > 0)
											{
												num6 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
											}
										}
										if (num6 > 0.0)
										{
											if (Operators.CompareString(mSG[DC_Main.i, 48], "G", false) == 0)
											{
												mSG[mSG.Row, 18] = Strings.Format((object)Math.Round(num6 / 10.0, 2), "0.00");
											}
											else if (Operators.CompareString(mSG[DC_Main.i, 48], "K", false) == 0)
											{
												mSG[mSG.Row, 18] = Strings.Format((object)Math.Round(num6 * 10.0, 0), "0.00");
											}
											else if (Operators.CompareString(mSG[DC_Main.i, 48], "1", false) == 0)
											{
												mSG[mSG.Row, 18] = Strings.Format((object)Math.Round(num6, 0), "0.00");
											}
										}
										else
										{
											mSG[mSG.Row, 18] = "";
										}
									}
								}
								else
								{
									mSG[DC_Main.i, 28] = "3.00";
								}
							}
							mSG[DC_Main.i, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
							mSG[DC_Main.i, 49] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[DC_Main.i, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							mSG[mSG.Row, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[mSG.Row, 73] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[mSG.Row, 74] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[mSG.Row, 75] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[mSG.Row, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[mSG.Row, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[mSG.Row, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[mSG.Row, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						int num7 = 0;
						int num8 = DtIdtl.Rows.Count - 1;
						int num9 = num8;
						for (int i = 0; i <= num9; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num7][20], (object)Conversion.Val(mSG[DC_Main.i, 47]), false))
							{
								DtIdtl.Rows[num7].Delete();
								DtIdtl.AcceptChanges();
								num7--;
							}
							num7++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 42] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[20] = Conversion.Val(MSG[mSG.Row, 47]);
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
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (((Operators.CompareString(DC_Main.SSRegSrNo, "AK029NEAK", false) == 0) & (Operators.CompareString(MSG[mSG.Row, 1], "", false) != 0)) && mSG.Row == mSG.Rows - 1)
						{
							CommPassTotal();
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							mSG.Col = 1;
							MsgClear = false;
							CommPassAdd();
							((Control)TEXT_ENTRY).Visible = true;
							return;
						}
						break;
					}
					case 2:
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
									mSG[mSG.Row, 52] = DC_Main.ColValue[0];
									mSG[mSG.Row, 51] = DC_Main.ColValue[3];
									mSG[mSG.Row, 49] = DC_Main.ColValue[4];
									mSG[mSG.Row, 50] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 49] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						break;
					case 6:
						mSG[mSG.Row, 6] = TEXT_ENTRY.Text;
						((Control)TEXT_ENTRY).Visible = false;
						((Control)tItRemark).Focus();
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
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && ((Operators.CompareString(mSG[mSG.Row, 53], "A", false) == 0) & (mSG.Row == mSG.Rows - 1)) && mSG.Row == mSG.Rows - 1 && Operators.CompareString(mSG[mSG.Row, 1], "", false) == 0)
						{
							if (Operators.CompareString(DC_Main.MsStkLimitWithDesign, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' "), Interaction.IIf(Operators.CompareString(mSG[mSG.Row, 4], "", false) == 0, (object)" AND IT_DESIGN = 'N' ", (object)("AND IT_DESIGN = '" + mSG[mSG.Row, 4] + "'"))), (object)" AND FROM_WT <= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)" AND TO_WT >= "), (object)Conversion.Val(TEXT_ENTRY.Text)), (object)""));
							}
							else
							{
								DC_Main.RsQry = ("SELECT * FROM ITM_WT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + mSG[mSG.Row, 2] + "' AND FROM_WT <= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text)) + " AND TO_WT >= " + Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text))) ?? "";
							}
							DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable3.Rows.Count > 0)
							{
								if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_CODE"], (object)""), (object)"", false))
								{
									mSG[mSG.Row, 22] = "";
									mSG[mSG.Row, 23] = "";
									mSG[mSG.Row, 20] = "";
									mSG[mSG.Row, 12] = "";
									mSG[mSG.Row, 15] = "";
									mSG[mSG.Row, 25] = "";
								}
								else
								{
									if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"F", false))
									{
										mSG[mSG.Row, 22] = "";
										mSG[mSG.Row, 23] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"G", false))
									{
										mSG[mSG.Row, 48] = "G";
										mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"K", false))
									{
										mSG[mSG.Row, 48] = "G";
										mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else if (Operators.ConditionalCompareObjectEqual(dataTable3.Rows[0]["LBR_TYPE"], (object)"P", false))
									{
										mSG[mSG.Row, 48] = "P";
										mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									else
									{
										mSG[mSG.Row, 48] = "N";
										mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_RATE"], (object)"")), "0.00");
									}
									mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable3.Rows[0]["LBR_PRC"], (object)"")), "0.00");
								}
							}
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
					case 26:
						if (mSG[26] != 0 && Strings.Len(TEXT_ENTRY.Text) != 10)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 29:
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

	private void TR_SALE_ORD_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_14b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c1: Expected O, but got Unknown
		//IL_14e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_14f5: Expected O, but got Unknown
		//IL_151a: Unknown result type (might be due to invalid IL or missing references)
		//IL_151f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1529: Expected O, but got Unknown
		//IL_154e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1553: Unknown result type (might be due to invalid IL or missing references)
		//IL_155d: Expected O, but got Unknown
		//IL_1582: Unknown result type (might be due to invalid IL or missing references)
		//IL_1587: Unknown result type (might be due to invalid IL or missing references)
		//IL_1591: Expected O, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15df: Expected O, but got Unknown
		//IL_15f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_15fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1608: Expected O, but got Unknown
		//IL_1622: Unknown result type (might be due to invalid IL or missing references)
		//IL_1627: Unknown result type (might be due to invalid IL or missing references)
		//IL_1631: Expected O, but got Unknown
		//IL_164b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1650: Unknown result type (might be due to invalid IL or missing references)
		//IL_165a: Expected O, but got Unknown
		//IL_1674: Unknown result type (might be due to invalid IL or missing references)
		//IL_1679: Unknown result type (might be due to invalid IL or missing references)
		//IL_1683: Expected O, but got Unknown
		//IL_169d: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ac: Expected O, but got Unknown
		//IL_16d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16db: Expected O, but got Unknown
		//IL_17bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17cb: Expected O, but got Unknown
		//IL_1853: Unknown result type (might be due to invalid IL or missing references)
		//IL_1858: Unknown result type (might be due to invalid IL or missing references)
		//IL_1862: Expected O, but got Unknown
		//IL_18fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1900: Unknown result type (might be due to invalid IL or missing references)
		//IL_1906: Expected O, but got Unknown
		//IL_1990: Unknown result type (might be due to invalid IL or missing references)
		//IL_1995: Unknown result type (might be due to invalid IL or missing references)
		//IL_199f: Expected O, but got Unknown
		//IL_19c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19d3: Expected O, but got Unknown
		//IL_1a00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a0a: Expected O, but got Unknown
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
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				object? obj18 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_OLD2 = MSG_OLD;
				object? obj19 = colorConverter.ConvertFromString("DarkGray");
				mSG_OLD2.BackColorBkg = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_OLD3 = MSG_OLD;
				object? obj20 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_OLD3.BackColorFixed = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj21 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj22 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj23 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_UPI = MSG_UPI;
				object? obj24 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_UPI2 = MSG_UPI;
				object? obj25 = colorConverter.ConvertFromString("DarkGray");
				mSG_UPI2.BackColorBkg = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_UPI3 = MSG_UPI;
				object? obj26 = colorConverter.ConvertFromString("255, 224, 192");
				mSG_UPI3.BackColorFixed = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj27 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj29 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj30 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj33 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj34 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj35 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj36 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj37 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_OLD4 = MSG_OLD;
				object? obj38 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD4.BackColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_OLD5 = MSG_OLD;
				object? obj39 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_OLD5.BackColorBkg = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_OLD6 = MSG_OLD;
				object? obj40 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_OLD6.BackColorFixed = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj41 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj42 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj42 != null) ? ((Color)obj42) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj43 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG_UPI4 = MSG_UPI;
				object? obj44 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI4.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG_UPI5 = MSG_UPI;
				object? obj45 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_UPI5.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG_UPI6 = MSG_UPI;
				object? obj46 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_UPI6.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj47 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj48 = lblBook;
				object? obj49 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj48).ForeColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj50 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj51 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj52 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj53 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj54 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj55 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj56 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj57 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj58 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj59 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj59 != null) ? ((Color)obj59) : default(Color));
				AxMSFlexGrid mSG_OLD7 = MSG_OLD;
				object? obj60 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD7.BackColor = ((obj60 != null) ? ((Color)obj60) : default(Color));
				AxMSFlexGrid mSG_OLD8 = MSG_OLD;
				object? obj61 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_OLD8.BackColorBkg = ((obj61 != null) ? ((Color)obj61) : default(Color));
				AxMSFlexGrid mSG_OLD9 = MSG_OLD;
				object? obj62 = colorConverter.ConvertFromString("Cornsilk");
				mSG_OLD9.BackColorFixed = ((obj62 != null) ? ((Color)obj62) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj63 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj63 != null) ? ((Color)obj63) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj64 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj64 != null) ? ((Color)obj64) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj65 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj65 != null) ? ((Color)obj65) : default(Color));
				AxMSFlexGrid mSG_UPI7 = MSG_UPI;
				object? obj66 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_UPI7.BackColor = ((obj66 != null) ? ((Color)obj66) : default(Color));
				AxMSFlexGrid mSG_UPI8 = MSG_UPI;
				object? obj67 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_UPI8.BackColorBkg = ((obj67 != null) ? ((Color)obj67) : default(Color));
				AxMSFlexGrid mSG_UPI9 = MSG_UPI;
				object? obj68 = colorConverter.ConvertFromString("Cornsilk");
				mSG_UPI9.BackColorFixed = ((obj68 != null) ? ((Color)obj68) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj69 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj69 != null) ? ((Color)obj69) : default(Color));
				AppearanceObject appearance3 = ((BaseStyleControl)BtnAll).Appearance;
				object? obj70 = colorConverter.ConvertFromString("238, 244, 236");
				appearance3.BackColor = ((obj70 != null) ? ((Color)obj70) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_OLD).AutoSize = false;
				((TextBoxBase)TEXT_UPI).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_OLD).Font = new Font(((Control)TEXT_OLD).Font.FontFamily, (float)num3, ((Control)TEXT_OLD).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_UPI).Font = new Font(((Control)TEXT_UPI).Font.FontFamily, (float)num3, ((Control)TEXT_UPI).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_OLD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_OLD.Font.Style);
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
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnFirst).Font.Size * (1.0 + num2));
				((BaseStyleControl)BtnFirst).Font = new Font(((BaseStyleControl)BtnFirst).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnFirst).Font.Style);
				((BaseStyleControl)BtnLast).Font = new Font(((BaseStyleControl)BtnLast).Font.FontFamily, (float)num3, ((BaseStyleControl)BtnLast).Font.Style);
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
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
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
			CLEAR_DATA();
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
		UpiEntry = false;
		UpiTypeAdd = false;
		OldValTot = 0.0;
		NewValTot = 0.0;
		RecAdjAmt = 0.0;
		AdjGold = 0.0;
		AdjSilver = 0.0;
		OldSchmAmt = 0.0;
		DC_Main.MsCardSlAdj = false;
		DC_Main.MsOldPurc = false;
		DC_Main.MsOldPurcSl = false;
		OldGoldPurcAmt = 0.0;
		OldSilverPurcAmt = 0.0;
		OldUpiAmt = 0.0;
		OldCardAmt = 0.0;
		chkWapp.Checked = false;
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
		OrdGold = 0.0;
		OrdSilver = 0.0;
		((Control)PanelAdd).Visible = false;
		tAdd1.Text = "";
		tAdd2.Text = "";
		tAdd3.Text = "";
		tCity.Text = "";
		tMobile.Text = "";
		DC_Main.MsSlAdj = false;
		((Control)PnlUpi).Visible = false;
		OldAcCode = "";
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
		{
			tAcCode.Text = "";
		}
		else
		{
			tAcCode.Text = "00020";
		}
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_OLD).Visible = false;
		((Control)TEXT_UPI).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_OLD_CLEAR();
		MSG2_CLEAR();
		MSG_UPI_CLEAR();
		CommPassAddUpi();
		if ((Operators.CompareString(FormBookType, "T", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK133NEVK", false) == 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAX_CODE = '" + DC_Main.MsTaxCode + "'";
			DC_Main.RsTax = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.RsTax.Rows.Count > 0)
			{
				TEXT_ENTRY_2.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				MSG2_TOTAL[1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_NAME"], (object)""));
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.RsTax.Rows[0])["TAX_PRC"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[1, 2] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
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
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				MSG2_TOTAL[1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				MSG2_TOTAL[3, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UPI_AMT"]), "0.00");
				OldUpiAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UPI_AMT"]), "0.00"));
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				OldCardAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00"));
				CardCommAdj = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_ADJ"], (object)""));
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00");
				OldGoldPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL_AMT"]), "0.00"));
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00");
				OldSilverPurcAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL_AMT"]), "0.00"));
				MSG2_TOTAL[6, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_GL"]), "0.000");
				MSG2_TOTAL[7, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["OLD_SL"]), "0.000");
				MSG2_TOTAL[8, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00");
				OldSchmAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["SCHM_AMT"]), "0.00"));
				MSG2_TOTAL[9, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADV_AMT"]), "0.00");
				MSG2_TOTAL[9, 1] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_RATE"]), "0.00");
				if (Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0)
				{
					MSG2_TOTAL[9, 1] = "";
				}
				MSG2_TOTAL[9, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_FINE"]), "0.000");
				if (Conversion.Val(MSG2_TOTAL[9, 2]) == 0.0)
				{
					MSG2_TOTAL[9, 2] = "";
				}
				RecAdjAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ORD_ADJ_AMT"]), "0.00"));
				AdjGold = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_GOLD"]), "0.000"));
				AdjSilver = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_SILVER"]), "0.000"));
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[4, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[5, 4] + "'";
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
				tBankName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_NAME"], (object)""));
				mDelDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DEL_DATE"], (object)""));
				mFunDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FUN_DATE"], (object)""));
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
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
				CurPrnMobile = tMobile.Text;
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
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
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 86] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 84] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 85] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_FIX"], (object)""));
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DEL_DATE"], (object)""));
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 81] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAX_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 49] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_ISU"], (object)""));
					mSG[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_GEN"], (object)""));
					mSG[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_SALE"], (object)""));
					mSG[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_STK_LESS"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 74] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
					mSG[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
					mSG[DC_Main.i + 1, 80] = "Y";
					mSG[DC_Main.i + 1, 53] = "E";
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
					mSG_OLD[DC_Main.i + 1, 5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_OTH"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["ITM_RATE_TYPE"], (object)""));
					mSG_OLD[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_OLD.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_OLD.Rows > 2)
				{
					mSG_OLD.Rows -= 1;
				}
				mSG_OLD = null;
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
				if (MSG.Rows >= 1)
				{
					MSG.Row = 1;
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 23]);
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 23]);
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (UpiEntry)
		{
			Interaction.MsgBox((object)"Please First Save Upi Entry... Because This Voucher Upi Entery is open...", (MsgBoxStyle)0, (object)null);
		}
		else if (OldUpiAmt != Conversion.Val(MSG2_TOTAL[3, 1]))
		{
			Interaction.MsgBox((object)"Please First Save Voucher... Because Upi Entery is Change In Upi Form...", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void TR_SALE_ORD_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_SALE_ORD_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_025d: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_0321: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Invalid comparison between Unknown and I4
		//IL_0524: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_058d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0619: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c2: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (UpiEntry)
		{
			Interaction.MsgBox((object)"Please First Save Upi Entry... Because This Voucher Upi Entery is open...", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)tEmpCode).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0 && ((Operators.CompareString(mDelDate.Text, "  /  /", false) == 0) | (Operators.CompareString(mFunDate.Text, "  /  /", false) == 0)))
		{
			Interaction.MsgBox((object)"Please Insert Delevery Date and Function Date and Try", (MsgBoxStyle)0, (object)null);
			((Control)mDelDate).Focus();
			return;
		}
		if (DC_Main.MsCashLimit > 0.0 && Operators.CompareString(tAcCode.Text, "00020", false) != 0)
		{
			DC_Main.LedrCash(tAcCode.Text, DC_Main.MCo_Book, tVchNo.Text);
			if (Conversion.Val(MSG2_TOTAL[3, 3]) + DC_Main.AcCash > DC_Main.MsCashLimit)
			{
				Interaction.MsgBox((object)("Cash Recieved Limit Amount = " + Conversions.ToString(DC_Main.MsCashLimit) + " \r\nOld Ledr Value Is " + Conversions.ToString(DC_Main.AcCash) + " \r\nAnd Total Cash Amount Is " + Conversions.ToString(Conversion.Val(MSG2_TOTAL[3, 3]) + DC_Main.AcCash) + " You Can Not Receive More Then Cash Limit ..."), (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "VK115NEVK", false) == 0 && Operators.CompareString(mDelDate.Text, DC_Main.MMask, false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Delevery Date and Try......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (((Conversion.Val(MSG2_TOTAL[4, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[4, 4], "", false) == 0)) && Operators.CompareString(CardCommAdj, "N", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[5, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[5, 4], "", false) == 0))
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
		bool flag = false;
		if (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0)
		{
			Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0)
		{
			if ((int)Interaction.MsgBox((object)"This Voucher Save In Last Year...So Amt or Fine Ledger effect Is Not Disply In Curent Year Ledger Report You Want Save This... ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				((Control)BtnSave).Enabled = true;
				return;
			}
			flag = true;
		}
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0 && !flag)
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
			DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
					DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,AC_CODE FROM UPI_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND AC_CODE = '" + tAcCode.Text + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						DC_Main.ExeQuteDc("UPDATE UPI_DATA SET VCH_NO = '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND AC_CODE = '" + tAcCode.Text + "'");
						DC_Main.ExeQuteDc("UPDATE AC_DATA SET VCH_NO = '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND AC_CODE = '" + tAcCode.Text + "'");
						DC_Main.ExeQuteDc("UPDATE ROJ_MEL_DATA SET VCH_NO = '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND AC_CODE = '" + tAcCode.Text + "'");
					}
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
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_TOT[0, 25]) != 0.0) | (Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG2_TOTAL[9, 3]) != 0.0))
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
			DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
			dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
			dataRow2["TAX_CODE"] = MSG2_TOTAL[1, 4];
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			if (Conversion.Val(MSG2_TOTAL[9, 1]) != 0.0)
			{
				dataRow2["RCUT_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow2["ADV_AMT"] = 0;
			}
			else
			{
				dataRow2["ADV_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow2["RCUT_AMT"] = 0;
			}
			dataRow2["RCUT_RATE"] = Conversion.Val(MSG2_TOTAL[9, 1]);
			dataRow2["RCUT_FINE"] = Conversion.Val(MSG2_TOTAL[9, 2]);
			dataRow2["OLD_GL_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			dataRow2["OLD_SL_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
			dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["UPI_AMT"] = Conversion.Val(MSG2_TOTAL[3, 1]);
			dataRow2["SCHM_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
			dataRow2["OLD_GL"] = Conversion.Val(MSG2_TOTAL[6, 2]) + Conversion.Val(MSG2_TOTAL[9, 2]);
			dataRow2["OLD_SL"] = Conversion.Val(MSG2_TOTAL[7, 2]);
			dataRow2["ORD_ADJ_AMT"] = RecAdjAmt;
			dataRow2["ADJ_GOLD"] = AdjGold;
			dataRow2["ADJ_SILVER"] = AdjSilver;
			dataRow2["CARD_AC"] = MSG2_TOTAL[5, 4];
			dataRow2["BANK_AC"] = MSG2_TOTAL[4, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[4, 2];
			dataRow2["BANK_NAME"] = tBankName.Text;
			dataRow2["DEL_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mDelDate.Text), (object)DBNull.Value, (object)mDelDate.Text));
			dataRow2["FUN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mFunDate.Text), (object)DBNull.Value, (object)mFunDate.Text));
			dataRow2["CARD_ADJ"] = CardCommAdj;
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["ADD1"] = tAdd1.Text;
			dataRow2["ADD2"] = tAdd2.Text;
			dataRow2["ADD3"] = tAdd3.Text;
			dataRow2["CITY"] = tCity.Text;
			dataRow2["MOBILE"] = tMobile.Text;
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
		DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				if ((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) | (Conversion.Val(mSG[DC_Main.i, 25]) + (Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 23]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 29])) != 0.0))
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
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 47]);
					dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
					dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 65];
					if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) == 0)
					{
						dataRow3["TAG_NO"] = "N";
					}
					else
					{
						dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
					}
					dataRow3["TBL_CODE"] = mSG[DC_Main.i, 3];
					dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
					dataRow3["ITM_COLOR"] = mSG[DC_Main.i, 5];
					dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
					dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
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
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
					if (mSG[17] != 0)
					{
						dataRow3["RATE_FIX"] = mSG[DC_Main.i, 17];
					}
					else if (Conversion.Val(mSG[DC_Main.i, 18]) != 0.0)
					{
						dataRow3["RATE_FIX"] = "Y";
					}
					else
					{
						dataRow3["RATE_FIX"] = "N";
					}
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 18]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 43]);
					dataRow3["TOT_AMT"] = Conversion.Val(mSG[DC_Main.i, 27]);
					dataRow3["TAX_PRC"] = Conversion.Val(mSG[DC_Main.i, 28]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
					dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 32]);
					dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 35]);
					dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 36]);
					dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 37]);
					dataRow3["KR_NAME"] = mSG[DC_Main.i, 30];
					dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 48];
					dataRow3["IT_TYPE"] = mSG[DC_Main.i, 49];
					dataRow3["PR_CODE"] = mSG[DC_Main.i, 51];
					dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 42]);
					dataRow3["DESIGN_ISU"] = mSG[DC_Main.i, 66];
					dataRow3["TAG_GEN"] = mSG[DC_Main.i, 67];
					dataRow3["TAG_SALE"] = mSG[DC_Main.i, 68];
					dataRow3["OLD_TBL_CODE"] = mSG[DC_Main.i, 69];
					dataRow3["TAG_STK_LESS"] = mSG[DC_Main.i, 70];
					if (Operators.CompareString(mSG[DC_Main.i, 70], "", false) == 0)
					{
						dataRow3["TAG_STK_LESS"] = "N";
					}
					if (Operators.CompareString(mSG[DC_Main.i, 70], "Y", false) == 0)
					{
						if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0)
						{
							dataRow3["DESIGN_ISU"] = "Y";
							dataRow3["TAG_GEN"] = "Y";
						}
						else
						{
							dataRow3["TAG_STK_LESS"] = "N";
						}
					}
					else
					{
						dataRow3["TAG_STK_LESS"] = "N";
					}
					if (Strings.Len(mSG[DC_Main.i, 26]) == 10)
					{
						dataRow3["ORD_DEL_DATE"] = mSG[DC_Main.i, 26];
					}
					else
					{
						dataRow3["ORD_DEL_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mDelDate.Text), (object)DBNull.Value, (object)mDelDate.Text));
					}
					dataRow3["EMP_CODE"] = tEmpCode.Text;
					dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 71];
					dataRow3["HM_ID"] = mSG[DC_Main.i, 72];
					dataRow3["HM_ID2"] = mSG[DC_Main.i, 73];
					dataRow3["HM_ID3"] = mSG[DC_Main.i, 74];
					dataRow3["HM_ID4"] = mSG[DC_Main.i, 75];
					dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 76]);
					dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 77]);
					dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 78]);
					dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 79]);
					dataRow3["ORD_REC_AMT"] = 0;
					dataRow3["MAIN_USER"] = MainUser;
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MsOrdImgPrint, "Y", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					AxMSFlexGrid mSG2 = MSG;
					if (Operators.CompareString(MSG[DC_Main.i, 71], "N", false) != 0)
					{
						DC_Main.MsImageNo = MSG[DC_Main.i, 71];
						DC_Main.MsImageType = "TagImage";
					}
					else if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0)
					{
						DC_Main.MsImageNo = mSG2[DC_Main.i, 1] + "_" + mSG2[DC_Main.i, 42];
						DC_Main.MsImageType = "TagImage";
					}
					else if (Operators.CompareString(mSG2[DC_Main.i, 4], "", false) != 0)
					{
						DC_Main.MsImageNo = mSG2[DC_Main.i, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
						DC_Main.MsImageType = "TagImage";
					}
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
						MemoryStream memoryStream = new MemoryStream();
						PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
						byte[] buffer = memoryStream.GetBuffer();
						DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + DC_Main.MCo_Book + "' AND MEMB_CODE = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 0]))) ?? "";
						DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow4 = dataTable2.NewRow();
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["SCHM_CODE"] = DC_Main.MCo_Book;
						dataRow4["MEMB_CODE"] = tVchNo.Text;
						dataRow4["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
						if (Operators.CompareString(mSG2[DC_Main.i, 71], "N", false) != 0)
						{
							dataRow4["TAG_NO"] = mSG2[DC_Main.i, 71];
						}
						dataRow4["VCH_SRNO"] = 0;
						dataRow4["DESIGN"] = mSG2[DC_Main.i, 4];
						dataRow4["TAG_IMAGE"] = buffer;
						dataTable2.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
						dataTable2.Clear();
					}
					mSG2 = null;
					DC_Main.i++;
				}
			}
			DC_Main.RsQry = "SELECT * FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow5 = RsIdtl.NewRow();
			int num3 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15])) != 0.0)
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
					dataRow5["ENTRY_TYPE"] = "O";
					dataRow5["BOOK_NAME"] = FormMainBook;
					dataRow5["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow5["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))), 1];
					dataRow5["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))), 42]);
					dataRow5["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow5["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow5["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
					dataRow5["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
					dataRow5["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
					dataRow5["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
					dataRow5["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
					dataRow5["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
					dataRow5["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow5["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
					dataRow5["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]);
					dataRow5["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
					dataRow5["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow5["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
					dataRow5["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow5["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow5["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow5["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
					dataRow5["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow5);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			RsOldDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow6 = RsOldDetl.NewRow();
			int num4 = MSG_OLD.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num4)
			{
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 11]) != 0.0) & (Operators.CompareString(MSG_OLD[DC_Main.i, 1], "", false) != 0))
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
					dataRow6["IT_TYPE"] = mSG_OLD[DC_Main.i, 12];
					dataRow6["IT_DESC"] = mSG_OLD[DC_Main.i, 2];
					dataRow6["ITM_PCS"] = Conversion.Val(mSG_OLD[DC_Main.i, 3]);
					dataRow6["ITM_GWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 4]);
					dataRow6["ITM_OTH"] = Conversion.Val(mSG_OLD[DC_Main.i, 5]);
					dataRow6["ITM_NWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 6]);
					dataRow6["ITM_TOUCH"] = Conversion.Val(mSG_OLD[DC_Main.i, 7]);
					dataRow6["ITM_FINE"] = Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					dataRow6["ITM_RATE_TYPE"] = mSG_OLD[DC_Main.i, 9];
					dataRow6["ITM_RATE"] = Conversion.Val(mSG_OLD[DC_Main.i, 10]);
					dataRow6["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 11]);
					if ((Operators.CompareString(mSG_OLD[DC_Main.i, 12], "G", false) == 0) & (Conversion.Val(mSG_OLD[DC_Main.i, 11]) == 0.0))
					{
						OrdGold += Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					}
					if ((Operators.CompareString(mSG_OLD[DC_Main.i, 12], "S", false) == 0) & (Conversion.Val(mSG_OLD[DC_Main.i, 11]) == 0.0))
					{
						OrdSilver += Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					}
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
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
			DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow7 = dataTable3.NewRow();
			if (Conversion.Val(MSG2_TOTAL[9, 3]) + OrdGold + OrdSilver != 0.0)
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
				dataRow7["AC_NAME"] = tAcName.Text;
				dataRow7["VCH_TYPE"] = FormBookSname;
				dataRow7["INOUT_TYPE"] = FormBookInOut;
				dataRow7["ENTRY_TYPE"] = "O";
				dataRow7["BOOK_NAME"] = FormMainBook;
				dataRow7["ORD_HD_VCH_NO"] = tHdVchNo.Text;
				dataRow7["ORD_NO"] = tVchNo.Text;
				dataRow7["ORD_LC"] = DC_Main.MLc_code;
				dataRow7["ORD_YRCD"] = DC_Main.MCo_year;
				dataRow7["ORD_DBCD"] = DC_Main.MCo_Book;
				dataRow7["ORD_AC_CODE"] = tAcCode.Text;
				dataRow7["ORD_SIGN"] = "+";
				dataRow7["ORD_AMT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0, (object)Conversion.Val(MSG2_TOTAL[9, 3]), (object)0));
				dataRow7["PAID_AC"] = "";
				dataRow7["PAID_AMT"] = 0;
				dataRow7["KASAR_AMT"] = 0;
				dataRow7["ORD_BAL_AMT"] = 0;
				dataRow7["ORD_GOLD"] = OrdGold + Conversion.Val(MSG2_TOTAL[9, 2]);
				dataRow7["ORD_SILVER"] = OrdSilver;
				dataRow7["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow7["DATA_TRFR"] = "N";
				dataRow7["EMP_CODE"] = tEmpCode.Text;
				dataRow7["IT_DESC"] = tVchDesc.Text;
				dataRow7["MAIN_USER"] = MainUser;
				dataTable3.Rows.Add(dataRow7);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable3);
				dataTable3.Clear();
			}
			DC_Main.RsQry = "DELETE FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM UPI_DATA WHERE CO_CODE  = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow8 = RsDetl.NewRow();
			int num5 = MSG_UPI.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num5)
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
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.ORD_NO = B.VCH_NO,BAR_DETL.ORD_DBCD = B.CO_BOOK,BAR_DETL.ORD_YRCD = B.CO_YEAR,BAR_DETL.ORD_SRNO = B.OLD_SRNO,BAR_DETL.ORD_AC = B.AC_CODE  FROM BAR_DETL,SL_ORD_DETL AS B WHERE B.CO_CODE = BAR_DETL.CO_CODE AND B.LC_CODE = BAR_DETL.LC_CODE AND B.TAG_NO = BAR_DETL.TAG_NO AND B.VCH_SRNO = BAR_DETL.VCH_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.TAG_STK_LESS = 'Y' AND B.TAG_NO <> 'N'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.TBL_CODE = B.TBL_CODE FROM BAR_DETL,SL_ORD_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE MAIN_STOCK SET MAIN_STOCK.TBL_CODE = B.TBL_CODE FROM MAIN_STOCK,SL_ORD_DETL AS B WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.TAG_NO = B.TAG_NO AND MAIN_STOCK.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND MAIN_STOCK.ITM_SIGN = '+'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Ledr.Order_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Rojmel.Order_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Order_Stk(DC_Main.MCo_Book, tVchNo.Text);
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
			DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,ADV_AMT FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND ADV_AMT <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["ADV_AMT"], (object)0, false))))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					DataTable dataTable4 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					int num6 = 0;
					int num7 = dataTable4.Rows.Count - 1;
					for (num6 = 0; num6 <= num7; num6++)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dataTable4.Rows[num6]["NET_AMT"], (object)0, false))
						{
							double num8 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(dataTable4.Rows[num6]["NET_AMT"], DC_Main.Rshlp.Rows[0]["ADV_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
								2
							}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DETL SET ORD_REC_AMT = " + Conversions.ToString(num8) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable4.Rows[num6]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable4.Rows[num6]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable4.Rows[num6]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable4.Rows[num6]["SR_NO"]), (object)"")));
						}
					}
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DETL SET ORD_REC_AMT = 0 WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"'")));
				}
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0 && Operators.CompareString(EntryMode, "E", false) == 0)
			{
				DC_Main.RsQry = "SELECT * FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.TableCol();
				string text = "";
				int num9 = RsData.Columns.Count - 2;
				DC_Main.M = 0;
				while (DC_Main.M <= num9)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
					{
						int num10 = DC_Main.RsTblCol.Rows.Count - 1;
						for (int j = 0; j <= num10; j++)
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
						DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','N')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						text = "";
					}
					DC_Main.M++;
				}
				DC_Main.RsTblCol.Clear();
			}
			if (Operators.CompareString(FormVchNo, "", false) != 0)
			{
				CLEAR_DATA();
				((Form)this).Close();
				return;
			}
			CurPrnVch = tVchNo.Text;
			CurPrnMobile = tMobile.Text;
			DC_Main.MsAcBal(tAcCode.Text, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
			CustOpAmt = DC_Main.MsAcAmtOpBal;
			CustClAmt = DC_Main.MsAcAmtClBal;
			CLEAR_DATA();
			BtnPrint_Click(BtnPrint, new EventArgs());
			CurPrnVch = "";
			CurPrnMobile = "";
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
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Invalid comparison between Unknown and I4
		//IL_024a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa6: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			return;
		}
		if (UpiEntry)
		{
			Interaction.MsgBox((object)"Please First Save Upi Entry... Because This Voucher Upi Entery is open...", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if ((Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0) & (Operators.CompareString(MSG[DC_Main.i, 70], "Y", false) == 0))
				{
					DC_Main.RsQry = "SELECT CO_BOOK,VCH_NO,SR_NO FROM SL_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.i, 1] + "' AND VCH_SRNO = " + MSG[DC_Main.i, 42] + " ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("You Cant Delete This Order Because  This Tag " + MSG[DC_Main.i, 1] + " Sales With  Book =  "), DC_Main.Tbl.Rows[0]["CO_BOOK"]), (object)" And Vch No = "), DC_Main.Tbl.Rows[0]["VCH_NO"]), (object)" And Sr No = "), DC_Main.Tbl.Rows[0]["SR_NO"]), (object)" ... "), (MsgBoxStyle)0, (object)null);
						return;
					}
				}
				DC_Main.i++;
			}
			if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
			{
				return;
			}
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,ADV_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING('Cash/Bank/Card/Ogl/Osl' + '-' + STR(CASH_AMT)+'/'+STR(CHQ_AMT)+'/'+STR(CARD_AMT)+'/'+STR(OLD_GL_AMT)+'/'+STR(OLD_SL_AMT)+' OG :'+STR(OLD_GL)+' OS :'+STR(OLD_SL),1,150)  FROM  (SL_ORD_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.ORD_NO = '',BAR_DETL.ORD_DBCD ='',BAR_DETL.ORD_YRCD = '',BAR_DETL.ORD_SRNO = 0,BAR_DETL.ORD_AC = ''  FROM BAR_DETL,SL_ORD_DETL AS B WHERE B.CO_CODE = BAR_DETL.CO_CODE AND B.LC_CODE = BAR_DETL.LC_CODE AND B.TAG_NO = BAR_DETL.TAG_NO AND B.VCH_SRNO = BAR_DETL.VCH_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.TAG_STK_LESS = 'Y' AND B.TAG_NO <> 'N'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.TBL_CODE = B.OLD_TBL_CODE FROM BAR_DETL,SL_ORD_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "UPDATE MAIN_STOCK SET MAIN_STOCK.TBL_CODE = B.OLD_TBL_CODE FROM MAIN_STOCK,SL_ORD_DETL AS B WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.TAG_NO = B.TAG_NO AND MAIN_STOCK.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND MAIN_STOCK.ITM_SIGN = '+'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SL_BILL_YRCD = '" + DC_Main.MCo_year + "' AND SL_BILL_DBCD = '" + DC_Main.MCo_Book + "' AND SL_BILL_NO = '" + tVchNo.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				int num2 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM PR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_YEAR"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"'")));
					DC_Main.M++;
				}
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("Delete FROM UPI_DATA WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_SALE_ORD_KeyDown(object sender, KeyEventArgs e)
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

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (UpiEntry)
		{
			Interaction.MsgBox((object)"Please First Save Upi Entry... Because This Voucher Upi Entery is open...", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (OldUpiAmt != Conversion.Val(MSG2_TOTAL[3, 1]))
		{
			Interaction.MsgBox((object)"Please First Save Voucher... Because Upi Entery is Change In Upi Form...", (MsgBoxStyle)0, (object)null);
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
		string rptName;
		if ((Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0) | chkWapp.Checked)
		{
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM SL_ORD_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
			}
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + CurPrnMobile;
			DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			rptName = ((DC_Main.Rshlp.Rows.Count == 0) ? "OrderVch" : ((Operators.CompareString(DC_Main.MsOrdImgPrint, "Y", false) != 0) ? "OrderBill" : "OrdVchImg"));
			DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				DC_Main.MsCrForName1 = "OldItem";
				DC_Main.MsCrForStr1 = "'N'";
			}
			else
			{
				DC_Main.MsCrForName1 = "OldItem";
				DC_Main.MsCrForStr1 = "'Y'";
			}
			DC_Main.MsWappPrintType = "AmtBal";
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.RptFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderVch.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderVch.RPT";
			}
			rptName = "OrderVch";
		}
		else
		{
			if (Operators.CompareString(DC_Main.MsOrdImgPrint, "Y", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrdVchImg.RPT";
			}
			else if (Operators.CompareString(FormBookType, "T", false) == 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderBill.RPT";
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderBill.RPT";
			}
			rptName = "OrderBill";
		}
		DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			Cr[(short)2] = "OldItem = 'N'";
			DC_Main.MsWappOrdOldItm = "'N'";
		}
		else
		{
			Cr[(short)2] = "OldItem = 'Y'";
			DC_Main.MsWappOrdOldItm = "'Y'";
		}
		Cr.SelectionFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)3] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)4] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.RptName = rptName;
			DC_Main.MsWappPrintType = "SlOrder";
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.RptFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT3 = new UT_REPORT();
			((Control)uT_REPORT3).Show();
			((Control)uT_REPORT3).Focus();
			return;
		}
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
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		if (UpiEntry)
		{
			Interaction.MsgBox((object)"Please First Save Upi Entry... Because This Voucher Upi Entery is open...", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (OldUpiAmt != Conversion.Val(MSG2_TOTAL[3, 1]))
		{
			Interaction.MsgBox((object)"Please First Save Voucher... Because Upi Entery is Change In Upi Form...", (MsgBoxStyle)0, (object)null);
			return;
		}
		CurPrnMobile = "";
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_SALE_ORD_Activated(object sender, EventArgs e)
	{
		DC_Main.MCo_Book = FormBook;
		DC_Main.MCo_BookType = FormBookType;
		lblBook.Text = FormName;
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
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
			PicImage.Image = null;
		}
		if (DC_Main.MsSlAdj)
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			MSG2_TOTAL[8, 3] = Strings.Format((object)DC_Main.MsSlSchmAdj, "0.00");
			DC_Main.MsSlSchmAdj = 0.0;
		}
		if ((DC_Main.MsOldPurcSl & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0)) && Conversion.Val(MSG2_TOTAL[7, 3]) == 0.0)
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[7, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[7, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
			return;
		}
		if (DC_Main.MsOldPurc & !DC_Main.MsSlAdj & (DC_Main.MsOldPurcAmt != 0.0))
		{
			TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[6, 3] = Strings.Format((object)DC_Main.MsOldPurcAmt, "0.00");
			MSG2_TOTAL[6, 2] = Strings.Format((object)DC_Main.MsOldPurcWt, "0.000");
			DC_Main.MsOldPurcAmt = 0.0;
			DC_Main.MsOldPurcWt = 0.0;
			((Control)TEXT_ENTRY_2).Focus();
			return;
		}
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
			MSG2_TOTAL[5, 3] = Strings.Format((object)DC_Main.MsCardAdj, "0.00");
			MSG2_TOTAL[5, 2] = Strings.Format((object)DC_Main.MsCardAdjComm, "0.00");
			MSG2_TOTAL[5, 1] = DC_Main.MsCardBankName;
			MSG2_TOTAL[5, 4] = DC_Main.MsCardBank;
			DC_Main.MsCardAdj = 0.0;
			DC_Main.MsCardAdjComm = 0.0;
			DC_Main.MsCardBankName = "";
			DC_Main.MsCardBank = "";
			((Control)TEXT_ENTRY_2).Focus();
		}
		else if (UpiEntry)
		{
			if ((DC_Main.MsUpiAmt > 0.0) & (Operators.CompareString(DC_Main.MsUpiCurAcCode, tAcCode.Text, false) == 0))
			{
				TEXT_ENTRY_2.Text = Strings.Format((object)DC_Main.MsUpiAmt, "0.00");
				MSG2_TOTAL[3, 1] = Strings.Format((object)DC_Main.MsUpiAmt, "0.00");
				((Control)TEXT_ENTRY_2).Focus();
				DC_Main.MsUpiAmt = 0.0;
				DC_Main.MsUpiCurAcCode = "";
				UpiEntry = false;
				return;
			}
			if (Operators.CompareString(DC_Main.MsUpiFormOpen, "N", false) == 0)
			{
				UpiEntry = false;
			}
			DC_Main.MsUpiAmt = 0.0;
			DC_Main.MsUpiCurAcCode = "";
			TEXT_ENTRY_2.Text = "";
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
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.ADV_AMT As OrdAmtR,SUM(CASE WHEN ORD_SIGN = '-' THEN ORD_AMT ELSE 0 END) As AdjAmtR FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON   A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.VCH_DESC,A.MAIN_USER,A.ADV_AMT HAVING SUM(CASE WHEN ORD_SIGN = '+' THEN ORD_AMT ELSE - ORD_AMT END) > 0 ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_0af2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0afc: Expected O, but got Unknown
		//IL_06f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ff: Expected O, but got Unknown
		//IL_0937: Unknown result type (might be due to invalid IL or missing references)
		//IL_0941: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 52] + " : It Name";
		tItRemark.Text = MSG[MSG.Row, 65];
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 47]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])))
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
			if ((Operators.CompareString(MSG[MSG.Row, 71], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 71];
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
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 71] + "' AND IMAGE_TYPE = 'D'";
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
				if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 42];
					DC_Main.MsImageType = "TagImage";
				}
				else
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
					DC_Main.MsImageType = "TagImage";
				}
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
						PicImage.Image = null;
						string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
						{
							DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 42]))) ?? "";
						}
						else
						{
							DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 4] + "'";
						}
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
				if (PicImage.Image != null)
				{
					string text = Application.StartupPath + "\\AllImage\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if ((Operators.CompareString(FileSystem.Dir(text, (FileAttribute)0), "", false) == 0) & (Operators.CompareString(Strings.Mid(DC_Main.MsImageNo, 1, 1), "_", false) != 0))
					{
						PicImage.Image.Save(Application.StartupPath + "\\AllImage\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
					}
				}
			}
			MSG_IDTL[num, 0] = Conversions.ToString(num);
			MSG_IDTL[num, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 47]));
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
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_SALE_ORD_Closed(object sender, EventArgs e)
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
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
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
		if (Operators.CompareString(tAcCode.Text, "00020", false) == 0)
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
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
		if (((Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0)) && (int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM SL_ORD_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
				switch (DC_Main.i)
				{
				case 0:
				case 2:
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
				case 1:
				case 3:
				case 4:
				case 5:
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
				case 6:
				case 7:
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
			mSG2_TOTAL[1, 0] = "Tax Amt : ";
			mSG2_TOTAL[2, 0] = "Total Amt : ";
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM594NEKU", false) == 0)
			{
				mSG2_TOTAL[3, 0] = "Zelle / Cash Amt : ";
			}
			else
			{
				mSG2_TOTAL[3, 0] = "Upi / Cash Amt : ";
			}
			mSG2_TOTAL[4, 0] = "Cheque Amt : ";
			mSG2_TOTAL[5, 0] = "Card Amt : ";
			mSG2_TOTAL[6, 0] = "Old Gold Amt : ";
			mSG2_TOTAL[7, 0] = "Old Silver Amt : ";
			mSG2_TOTAL[8, 0] = "Scheme Amt : ";
			mSG2_TOTAL[9, 0] = "Tot Adv Amt : ";
			mSG2_TOTAL[10, 0] = "Panding Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 3))
				{
					((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
				}
				else if (mSG2_TOTAL.Row == 9)
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
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
				else if (mSG2_TOTAL.Row == 9)
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.000");
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 6))
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
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 9))
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
			if (mSG2_TOTAL.Row == 9)
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.00");
				break;
			}
			mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
			BILL_TOTAL();
			break;
		case 2:
			if ((mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 5))
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = TEXT_ENTRY_2.Text;
				break;
			}
			if (mSG2_TOTAL.Row == 9)
			{
				mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY_2.Text), "0.000");
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
		//IL_05e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
		Keys keyCode = e.KeyCode;
		checked
		{
			if (unchecked((int)keyCode) != 13)
			{
				switch (unchecked(keyCode - 37))
				{
				default:
					if (unchecked((int)keyCode) != 112 || mSG2_TOTAL.Row != 3 || MSG2_TOTAL.Col != 1)
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
					if (mSG2_TOTAL.Row == 9)
					{
						if (Versioned.IsNumeric((object)TEXT_ENTRY_2.Text))
						{
							if ((Conversion.Val(TEXT_ENTRY_2.Text) != 0.0) & (Conversion.Val(mSG2_TOTAL[9, 3]) != 0.0))
							{
								mSG2_TOTAL[9, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[9, 3]) / Conversion.Val(TEXT_ENTRY_2.Text)), "0.000");
							}
							else
							{
								mSG2_TOTAL[9, 2] = "";
							}
						}
						else
						{
							TEXT_ENTRY_2.Text = "";
							mSG2_TOTAL[9, 2] = "";
						}
					}
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
					if (mSG2_TOTAL.Row != 1)
					{
						break;
					}
					if (Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From TAX_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND TAX_NAME = '" + TEXT_ENTRY_2.Text + "'  ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TAX_NAME As TaxNameL,A.TAX_PRC as TaxPrcR, TAX_CODE AS TaxCodeL FROM TAX_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.TAX_CODE";
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
									mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[1]), "0.00");
									mSG2_TOTAL[mSG2_TOTAL.Row, 4] = DC_Main.ColValue[2];
								}
								else
								{
									TEXT_ENTRY_2.Text = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
									mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 3;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_PRC"], (object)"")), "0.00");
							mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 3;
							mSG2_TOTAL.Col = 3;
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
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 3:
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						mSG2_TOTAL.Row += 1;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Visible = true;
						((Control)TEXT_ENTRY_2).Focus();
						return;
					case 4:
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
					case 5:
						if (Operators.CompareString(DC_Main.MsCardComAdj, "Y", false) == 0)
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
								DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[2, 3]);
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
								mSG2_TOTAL.Col = 3;
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
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 6:
					case 7:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if (Operators.CompareString(FormBookType, "T", false) == 0)
							{
								if (!DC_Main.MsOldPurc & (OldGoldPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 6))
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
								if (!DC_Main.MsOldPurcSl & (OldSilverPurcAmt != Conversion.Val(TEXT_ENTRY_2.Text)) & (mSG2_TOTAL.Row == 7))
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
					case 9:
						CommPassTotal();
						MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
						BILL_TOTAL();
						((Control)TEXT_ENTRY_2).Visible = false;
						((Control)tEmpCode).Focus();
						return;
					case 8:
						if (Conversion.Val(TEXT_ENTRY_2.Text) != 0.0)
						{
							if ((Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0) | (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0))
							{
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								BILL_TOTAL();
								mSG2_TOTAL.Row += 1;
								mSG2_TOTAL.Col = 1;
								((Control)TEXT_ENTRY_2).Visible = true;
								((Control)TEXT_ENTRY_2).Focus();
							}
							else if (!DC_Main.MsSlAdj & (OldSchmAmt != Conversion.Val(TEXT_ENTRY_2.Text)))
							{
								DC_Main.MsSlBill = tVchNo.Text;
								DC_Main.MsSlBillHdNo = tHdVchNo.Text;
								DC_Main.MsSlAcCode = tAcCode.Text;
								DC_Main.MsSlYrCd = DC_Main.MCo_year;
								DC_Main.MsSlDbCd = DC_Main.MCo_Book;
								DC_Main.MsSlAmt = Conversion.Val(mSG2_TOTAL[2, 3]);
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
								mSG2_TOTAL.Col = 1;
								((Control)TEXT_ENTRY_2).Visible = true;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							BILL_TOTAL();
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 1;
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
		mSG2_TOTAL[0, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 29]), "0.00");
		mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0, 0), "0.00");
		mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]), 0), "0.00");
		checked
		{
			if (Operators.CompareString(DC_Main.MCo_BookType, "F", false) == 0)
			{
				mSG2_TOTAL[6, 2] = "";
				mSG2_TOTAL[6, 3] = "";
				mSG2_TOTAL[7, 2] = "";
				mSG2_TOTAL[7, 3] = "";
				int num = MSG_OLD.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 12], "G", false) == 0)
					{
						mSG2_TOTAL[6, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 8])), "0.000");
						mSG2_TOTAL[6, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 11])), "0.00");
					}
					if (Operators.CompareString(MSG_OLD[DC_Main.M, 12], "G", false) != 0)
					{
						mSG2_TOTAL[7, 2] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[7, 2]) + Conversion.Val(MSG_OLD[DC_Main.M, 8])), "0.000");
						mSG2_TOTAL[7, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[7, 3]) + Conversion.Val(MSG_OLD[DC_Main.M, 11])), "0.00");
					}
					DC_Main.M++;
				}
			}
			mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[3, 1]) + Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(mSG2_TOTAL[7, 3])), "0.00");
			if (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)
			{
				mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[3, 1]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3])), "0.00");
			}
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[9, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[9, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[9, 3]);
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

	private void mDelDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(mDelDate.Text, "  /  /", false) != 0)
		{
			MaskedTextBox MsDate = mDelDate;
			DC_Main.SetDate(ref MsDate);
			mDelDate = MsDate;
			if (DC_Main.RongDate)
			{
				return;
			}
		}
		SendKeys.Send("{TAB}");
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(DC_Main.MsImageNo, "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Design No and Try..", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image.Dispose();
						PicImage.Image = null;
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					((Form)MyProject.Forms.UT_WEB_CAM).MdiParent = ((Form)this).MdiParent;
					((Control)MyProject.Forms.UT_WEB_CAM).Show();
					((Control)MyProject.Forms.UT_WEB_CAM).Focus();
					goto end_IL_0001;
				case 196:
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
				try0001_dispatch = 196;
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

	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_02ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Unknown result type (might be due to invalid IL or missing references)
		//IL_029c: Expected O, but got Unknown
		try
		{
			if (Operators.CompareString(DC_Main.MsImageNo, "", false) == 0)
			{
				Interaction.MsgBox((object)"Please Insert Design No and Try..", (MsgBoxStyle)0, (object)null);
				return;
			}
			((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
			if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
			{
				return;
			}
			if (Operators.CompareString(MSG[MSG.Row, 71], "N", false) != 0)
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 71];
				DC_Main.MsImageType = "TagImage";
			}
			else if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
			{
				DC_Main.MsImageNo = MSG[DC_Main.i, 1] + "_" + MSG[MSG.Row, 42];
				DC_Main.MsImageType = "TagImage";
			}
			else if (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0)
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
				DC_Main.MsImageType = "TagImage";
			}
			DC_Main.MsImageType = "TagImage";
			string text = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\";
			DC_Main.MsImagePath = text + DC_Main.MsImageNo + ".jpg";
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			if (File.Exists(DC_Main.MsImagePath))
			{
				try
				{
					File.Delete(DC_Main.MsImagePath);
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					GC.Collect();
					GC.WaitForPendingFinalizers();
					File.Delete(DC_Main.MsImagePath);
					ProjectData.ClearProjectError();
				}
			}
			byte[] buffer = DC_Main.CompressImage(((FileDialog)DlgOpen).FileName, 60);
			using (MemoryStream memoryStream = new MemoryStream(buffer))
			{
				Image val = Image.FromStream((Stream)memoryStream);
				try
				{
					val.Save(DC_Main.MsImagePath, ImageFormat.Jpeg);
					PicImage.Image = (Image)val.Clone();
				}
				finally
				{
					((IDisposable)val)?.Dispose();
				}
			}
			Mobile_image_Save(MSG.Row);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)("Error: " + ex2.Message), (MsgBoxStyle)0, (object)null);
			ProjectData.ClearProjectError();
		}
	}

	private void Mobile_image_Save(int ImgRow)
	{
		//IL_036c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Expected O, but got Unknown
		try
		{
			AxMSFlexGrid mSG = MSG;
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (File.Exists(DC_Main.MsImagePath))
			{
				Image val = DC_Main.LoadImageWithoutLock(DC_Main.MsImagePath);
				PicImage.Image = (Image)val.Clone();
				val.Dispose();
				GC.Collect();
				GC.WaitForPendingFinalizers();
				byte[] inArray = File.ReadAllBytes(DC_Main.MsImagePath);
				string value = Convert.ToBase64String(inArray);
				if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
				{
					Ac_Image.FtpUploadFile(ftpuri: (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsUrlPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"), filetoupload: DC_Main.MsImagePath, ftpusername: DC_Main.MsUrlId, ftppassword: DC_Main.MsUrlPwd);
				}
				string text = "";
				int num = 0;
				if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
				{
					text = mSG[ImgRow, 1];
					num = checked((int)Math.Round(Conversion.Val(mSG[ImgRow, 42])));
				}
				else if (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0)
				{
					text = mSG[ImgRow, 4];
					num = 0;
				}
				DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + text + "' AND VCH_SRNO = " + Conversions.ToString(num)) ?? "";
				DC_Main.ExeQuteImg(DC_Main.RsQry);
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + text + "' AND VCH_SRNO = " + Conversions.ToString(num)) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow = dataTable.NewRow();
				dataRow["CO_CODE"] = DC_Main.MCo_code;
				dataRow["LC_CODE"] = DC_Main.MLc_code;
				dataRow["TAG_NO"] = text;
				dataRow["VCH_SRNO"] = num;
				dataRow["IMAGE_TYPE"] = "T";
				dataRow["MOB_IMAGE"] = value;
				dataTable.Rows.Add(dataRow);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
				dataTable.Dispose();
				mSG = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)("Mobile_image_Save Error: " + ex2.Message), (MsgBoxStyle)0, (object)null);
			ProjectData.ClearProjectError();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
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
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							PicImage.Image.Dispose();
							PicImage.Image = null;
							FileSystem.Kill(DC_Main.MsImagePath);
						}
					}
					goto end_IL_0001;
				case 227:
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
				try0001_dispatch = 227;
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

	private void BtnAll_Click(object sender, EventArgs e)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.ADV_AMT As OrdAmtR,SUM(CASE WHEN ORD_SIGN = '-' THEN ORD_AMT ELSE 0 END) As AdjAmtR FROM SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON   A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC AND A.CO_YEAR = B.ORD_YRCD AND A.CO_BOOK = B.ORD_DBCD AND A.VCH_NO = B.ORD_NO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  GROUP BY A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.VCH_DESC,A.MAIN_USER,A.ADV_AMT  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 100.0;
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

	private void tAcName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Invalid comparison between Unknown and I4
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "00020", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
			{
				((Control)PanelAdd).Visible = true;
				if ((int)e.KeyCode == 13)
				{
					((Control)tAdd1).Focus();
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
		else
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void tItRemark_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 8;
			MSG[MSG.Row, 65] = tItRemark.Text;
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
		if ((int)e.KeyCode == 13)
		{
			((Control)PanelAdd).Visible = false;
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TR_SALE_ORD_KeyUp(object sender, KeyEventArgs e)
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

	private void TAcName_TextChanged(object sender, EventArgs e)
	{
	}

	private void TAcCode_TextChanged(object sender, EventArgs e)
	{
		//IL_0195: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsMobileHelp, "N", false) == 0 || ((Operators.CompareString(DC_Main.MsSoftType, "A", false) != 0) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) != 0)))
		{
			return;
		}
		if (Strings.Len(tAcCode.Text) > 3)
		{
			MobileSearch = true;
		}
		else
		{
			MobileSearch = false;
		}
		if (!((Strings.Len(tAcCode.Text) >= 2) & !MobileSearch & Versioned.IsNumeric((object)tAcCode.Text)))
		{
			return;
		}
		DC_Main.MsMobileLen = tAcCode.Text;
		MobileSearch = true;
		DC_Main.RsQry = "SELECT A.AC_MOBILE As MobileL,A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL FROM AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND SUBSTRING(A.AC_MOBILE,1,2)  = '" + Strings.Mid(tAcCode.Text, 1, 2) + "'  ORDER BY A.AC_MOBILE";
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
			MS_ACCT mS_ACCT = new MS_ACCT();
			((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)mS_ACCT).Show();
			((Control)mS_ACCT).Focus();
			return;
		}
		if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
		{
			tAcCode.Text = DC_Main.ColValue[2];
			tAcName.Text = DC_Main.ColValue[1];
			tAdd1.Text = DC_Main.ColValue[3];
			tCity.Text = DC_Main.ColValue[4];
			tMobile.Text = DC_Main.ColValue[0];
		}
		MobileSearch = false;
		((Control)tAcCode).Focus();
		((TextBoxBase)tAcCode).SelectAll();
	}

	private void mFunDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(mFunDate.Text, "  /  /", false) != 0)
		{
			MaskedTextBox MsDate = mFunDate;
			DC_Main.SetDate(ref MsDate);
			mFunDate = MsDate;
			if (DC_Main.RongDate)
			{
				return;
			}
		}
		SendKeys.Send("{TAB}");
	}

	private void mFunDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFunDate).SelectionStart = 0;
		((TextBoxBase)mFunDate).SelectionLength = Strings.Len(mFunDate.Text);
	}

	private void mDelDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mDelDate).SelectionStart = 0;
		((TextBoxBase)mDelDate).SelectionLength = Strings.Len(mDelDate.Text);
	}

	private void TEXT_ENTRY_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Invalid comparison between Unknown and I4
		if (MSG.Col == 26 && (int)e.KeyCode != 8)
		{
			if (Strings.Len(TEXT_ENTRY.Text) == 2)
			{
				TEXT_ENTRY.Text += "/";
			}
			else if (Strings.Len(TEXT_ENTRY.Text) == 5)
			{
				TEXT_ENTRY.Text += "/";
			}
			((TextBoxBase)TEXT_ENTRY).SelectionStart = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void TEXT_UPI_TextChanged(object sender, EventArgs e)
	{
	}
}
