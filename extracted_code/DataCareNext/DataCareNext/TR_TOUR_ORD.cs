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
public class TR_TOUR_ORD : Form
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

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private DataTable VchOldData;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private double OldGoldPurcAmt;

	private double OldSilverPurcAmt;

	private string CardCommAdj;

	private double OldCardAmt;

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

	private const int cQty = 8;

	private const int cPcs = 9;

	private const int cGrWt = 10;

	private const int cOthWt = 11;

	private const int cNetWt = 12;

	private const int cGhtPrc = 13;

	private const int cGhtWt = 14;

	private const int cTouch = 15;

	private const int cWestPrc = 16;

	private const int cFine = 17;

	private const int cRateFix = 18;

	private const int cItRate = 19;

	private const int cItAmt = 20;

	private const int cLbrPrc = 21;

	private const int cLbrType = 22;

	private const int cLbrRate = 23;

	private const int cLbrAmt = 24;

	private const int cOthAmt = 25;

	private const int cMrp = 26;

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

	private const int cRowValue = 72;

	private const int cRowText = 73;

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

	public TR_TOUR_ORD()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_TOUR_ORD_Load;
		((Form)this).Deactivate += TR_TOUR_ORD_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_TOUR_ORD_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_TOUR_ORD_KeyDown);
		((Form)this).Activated += TR_TOUR_ORD_Activated;
		((Form)this).Closed += TR_TOUR_ORD_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_TOUR_ORD_KeyUp);
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
		//IL_03f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_053b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0545: Expected O, but got Unknown
		//IL_05e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ec: Expected O, but got Unknown
		//IL_069a: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a4: Expected O, but got Unknown
		//IL_072b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0735: Expected O, but got Unknown
		//IL_07d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07da: Expected O, but got Unknown
		//IL_0869: Unknown result type (might be due to invalid IL or missing references)
		//IL_0873: Expected O, but got Unknown
		//IL_08d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e0: Expected O, but got Unknown
		//IL_0989: Unknown result type (might be due to invalid IL or missing references)
		//IL_0993: Expected O, but got Unknown
		//IL_09f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a00: Expected O, but got Unknown
		//IL_0aa9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab3: Expected O, but got Unknown
		//IL_0bd0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bda: Expected O, but got Unknown
		//IL_0ce5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cef: Expected O, but got Unknown
		//IL_0d52: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5c: Expected O, but got Unknown
		//IL_0eee: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd0: Expected O, but got Unknown
		//IL_107c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1086: Expected O, but got Unknown
		//IL_117e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1188: Expected O, but got Unknown
		//IL_1299: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a3: Expected O, but got Unknown
		//IL_1320: Unknown result type (might be due to invalid IL or missing references)
		//IL_132a: Expected O, but got Unknown
		//IL_13eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f5: Expected O, but got Unknown
		//IL_149c: Unknown result type (might be due to invalid IL or missing references)
		//IL_14a6: Expected O, but got Unknown
		//IL_159e: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Expected O, but got Unknown
		//IL_160c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1616: Expected O, but got Unknown
		//IL_1728: Unknown result type (might be due to invalid IL or missing references)
		//IL_1732: Expected O, but got Unknown
		//IL_177d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1787: Expected O, but got Unknown
		//IL_1801: Unknown result type (might be due to invalid IL or missing references)
		//IL_180b: Expected O, but got Unknown
		//IL_1890: Unknown result type (might be due to invalid IL or missing references)
		//IL_189a: Expected O, but got Unknown
		//IL_1961: Unknown result type (might be due to invalid IL or missing references)
		//IL_196b: Expected O, but got Unknown
		//IL_1a12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1c: Expected O, but got Unknown
		//IL_1a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aa0: Expected O, but got Unknown
		//IL_1b25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b2f: Expected O, but got Unknown
		//IL_1bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be7: Expected O, but got Unknown
		//IL_1c9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca5: Expected O, but got Unknown
		//IL_1d64: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d6e: Expected O, but got Unknown
		//IL_1e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e50: Expected O, but got Unknown
		//IL_1eec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ef6: Expected O, but got Unknown
		//IL_200b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2015: Expected O, but got Unknown
		//IL_2099: Unknown result type (might be due to invalid IL or missing references)
		//IL_20a3: Expected O, but got Unknown
		//IL_2170: Unknown result type (might be due to invalid IL or missing references)
		//IL_217a: Expected O, but got Unknown
		//IL_21e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_21eb: Expected O, but got Unknown
		//IL_2246: Unknown result type (might be due to invalid IL or missing references)
		//IL_2250: Expected O, but got Unknown
		//IL_22ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_22f8: Expected O, but got Unknown
		//IL_2389: Unknown result type (might be due to invalid IL or missing references)
		//IL_2393: Expected O, but got Unknown
		//IL_2417: Unknown result type (might be due to invalid IL or missing references)
		//IL_2421: Expected O, but got Unknown
		//IL_24d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_24dc: Expected O, but got Unknown
		//IL_255e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2568: Expected O, but got Unknown
		//IL_261d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2627: Expected O, but got Unknown
		//IL_26d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e2: Expected O, but got Unknown
		//IL_2793: Unknown result type (might be due to invalid IL or missing references)
		//IL_279d: Expected O, but got Unknown
		//IL_2836: Unknown result type (might be due to invalid IL or missing references)
		//IL_2840: Expected O, but got Unknown
		//IL_28fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2908: Expected O, but got Unknown
		//IL_2994: Unknown result type (might be due to invalid IL or missing references)
		//IL_299e: Expected O, but got Unknown
		//IL_2a52: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a5c: Expected O, but got Unknown
		//IL_2c85: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c8f: Expected O, but got Unknown
		//IL_2d3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d46: Expected O, but got Unknown
		//IL_2dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ddf: Expected O, but got Unknown
		//IL_2e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e97: Expected O, but got Unknown
		//IL_2f26: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f30: Expected O, but got Unknown
		//IL_2fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fe8: Expected O, but got Unknown
		//IL_3096: Unknown result type (might be due to invalid IL or missing references)
		//IL_30a0: Expected O, but got Unknown
		//IL_312f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3139: Expected O, but got Unknown
		//IL_31c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d2: Expected O, but got Unknown
		//IL_3260: Unknown result type (might be due to invalid IL or missing references)
		//IL_326a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_TOUR_ORD));
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
		((Control)mVchDate).Location = new Point(311, 41);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(232, 42);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(23, 43);
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
		((Control)mDay).Location = new Point(482, 41);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(393, 41);
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
		((Control)PnlBotam).TabIndex = 12;
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
		((Control)TEXT_ENTRY).Location = new Point(301, 176);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(485, 102);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(349, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)16;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(393, 336);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 6;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 310);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(708, 103);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(1010, 39);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(118, 90);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 287);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 135);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 149);
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
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1181, 393);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(105, 101);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(185, 101);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(291, 23);
		((Control)tAcName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 101);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(65, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Ac Code";
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
		((Control)tEmpCode).Location = new Point(105, 71);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(76, 23);
		((Control)tEmpCode).TabIndex = 2;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(185, 70);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(291, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(23, 71);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(74, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Emp Code";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(277, 535);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(72, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(358, 500);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(362, 57);
		((Control)tVchDesc).TabIndex = 11;
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
		((Control)BtnAll).Location = new Point(187, 40);
		((BaseControl)BtnAll).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAll).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAll).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAll).Name = "BtnAll";
		((Control)BtnAll).Size = new Size(34, 23);
		((Control)BtnAll).TabIndex = 1164;
		BtnAll.Text = "F1";
		((BaseControl)BtnAll).ToolTip = "Voucher Help";
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(789, 307);
		((TextBoxBase)tItRemark).MaxLength = 100;
		((Control)tItRemark).Name = "tItRemark";
		((Control)tItRemark).Size = new Size(380, 23);
		((Control)tItRemark).TabIndex = 5;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(726, 310);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(60, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Remark ";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(728, 336);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 222);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG_OLD).Location = new Point(12, 421);
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
		((Control)TEXT_ENTRY_2).TabIndex = 7;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_OLD).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_OLD).BorderStyle = (BorderStyle)0;
		((Control)TEXT_OLD).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_OLD).ForeColor = Color.White;
		((Control)TEXT_OLD).Location = new Point(376, 436);
		((Control)TEXT_OLD).Name = "TEXT_OLD";
		((Control)TEXT_OLD).Size = new Size(100, 18);
		((Control)TEXT_OLD).TabIndex = 8;
		((Control)TEXT_OLD).Visible = false;
		((TextBoxBase)mDelDate).BackColor = Color.White;
		((Control)mDelDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDelDate).Location = new Point(94, 532);
		mDelDate.Mask = "00/00/0000";
		((Control)mDelDate).Name = "mDelDate";
		((Control)mDelDate).Size = new Size(76, 23);
		((Control)mDelDate).TabIndex = 10;
		mDelDate.ValidatingType = typeof(DateTime);
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(11, 534);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(71, 20);
		((Control)Label6).TabIndex = 1171;
		Label6.Text = "Del Date";
		Label6.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(94, 500);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(258, 23);
		((Control)tBankName).TabIndex = 9;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(11, 500);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)16;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(1135, 38);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 1174;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(1135, 69);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 1175;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(1135, 101);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 1176;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(1192, 93);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(56, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((Control)Label8).Visible = false;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(1254, 91);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(126, 23);
		((Control)tBillNo).TabIndex = 14;
		((Control)tBillNo).Visible = false;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(856, 43);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(856, 106);
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
		((Control)PanelAdd).Location = new Point(1192, 135);
		((Control)PanelAdd).Name = "PanelAdd";
		((Control)PanelAdd).Size = new Size(405, 152);
		((Control)PanelAdd).TabIndex = 13;
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
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
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
		((Control)this).Name = "TR_TOUR_ORD";
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
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_OLD_CLEAR()
	{
		AxMSFlexGrid mSG_OLD = MSG_OLD;
		mSG_OLD.Clear();
		mSG_OLD.Cols = 13;
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
			mSG_OLD[2] = (int)Math.Round(1750.0 * ColCon);
			mSG_OLD[2] = 0;
			mSG_OLD[0, 2] = "ItName";
			mSG_OLD[3] = (int)Math.Round(500.0 * ColCon);
			mSG_OLD[3] = 7;
			mSG_OLD[0, 3] = "Pcs";
			mSG_OLD[4] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[4] = 7;
			mSG_OLD[0, 4] = "GrWt";
			mSG_OLD[5] = (int)Math.Round(800.0 * ColCon);
			mSG_OLD[5] = 7;
			mSG_OLD[0, 5] = "OthWt";
			mSG_OLD[6] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[6] = 7;
			mSG_OLD[0, 6] = "NetWt";
			mSG_OLD[7] = (int)Math.Round(675.0 * ColCon);
			mSG_OLD[7] = 3;
			mSG_OLD[0, 7] = "Touch";
			mSG_OLD[8] = (int)Math.Round(950.0 * ColCon);
			mSG_OLD[8] = 7;
			mSG_OLD[0, 8] = "Fine";
			mSG_OLD[9] = (int)Math.Round(700.0 * ColCon);
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
		//IL_031b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Unknown result type (might be due to invalid IL or missing references)
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
							mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
							if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0))
							{
								if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
								{
									mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6])), "0.00");
								}
								else
								{
									mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8])), "0.00");
								}
							}
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
			mSG_OLD[mSG_OLD.Row, mSG_OLD.Col] = Strings.Format((object)Conversion.Val(TEXT_OLD.Text), "0.00");
			if ((Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) != 0.0) & (Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) != 0.0))
			{
				if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 6])), "0.00");
				}
				else
				{
					mSG_OLD[mSG_OLD.Row, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[mSG_OLD.Row, 11]) / Conversion.Val(mSG_OLD[mSG_OLD.Row, 8])), "0.00");
				}
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
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		else if (Conversion.Val(mSG_OLD[CRow, 6]) == 0.0)
		{
			mSG_OLD[CRow, 6] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 4]), "0.000");
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if ((Conversion.Val(mSG_OLD[CRow, 7]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 6]) != 0.0))
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 6]) * Conversion.Val(mSG_OLD[CRow, 7]) / 100.0), "0.000");
		}
		if (Conversion.Val(mSG_OLD[CRow, 8]) == 0.0)
		{
			mSG_OLD[CRow, 8] = Strings.Format((object)Conversion.Val(mSG_OLD[CRow, 6]), "0.000");
		}
		if (Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]) != 0.0)
		{
			if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
			{
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 6]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), 0), "0.00");
			}
			else
			{
				mSG_OLD[mSG_OLD.Row, 11] = Strings.Format((object)Math.Round(Conversion.Val(mSG_OLD[mSG_OLD.Row, 8]) * Conversion.Val(mSG_OLD[mSG_OLD.Row, 10]), 0), "0.00");
			}
		}
		if ((Conversion.Val(mSG_OLD[CRow, 11]) != 0.0) & (Conversion.Val(mSG_OLD[CRow, 8]) != 0.0))
		{
			if (Operators.CompareString(mSG_OLD[mSG_OLD.Row, 9], "N", false) == 0)
			{
				mSG_OLD[CRow, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 11]) / Conversion.Val(mSG_OLD[CRow, 6])), "0.00");
			}
			else
			{
				mSG_OLD[CRow, 10] = Strings.Format((object)(Conversion.Val(mSG_OLD[CRow, 11]) / Conversion.Val(mSG_OLD[CRow, 8])), "0.00");
			}
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
				MSG[MSG.Row, 11] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 12] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 11])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 31] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 32] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - Conversion.Val(MSG[MSG.Row, 31])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 25] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 40] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 12] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 10]) - num2), "0.000");
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
		mSG.Cols = 74;
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
			mSG[6] = (int)Math.Round(800.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Size";
			mSG[7] = (int)Math.Round(800.0 * ColCon);
			mSG[7] = 7;
			mSG[0, 7] = "BagWt";
			mSG[8] = (int)Math.Round(700.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Qty";
			mSG[9] = (int)Math.Round(700.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "Pcs";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "GrWt";
			mSG[11] = (int)Math.Round(900.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "LsWt";
			mSG[12] = (int)Math.Round(1000.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "NetWt";
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
			mSG[21] = (int)Math.Round(800.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "Lbr%";
			mSG[22] = (int)Math.Round(800.0 * ColCon);
			mSG[22] = 3;
			mSG[0, 22] = "LType";
			mSG[23] = (int)Math.Round(900.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "LbrRate";
			mSG[24] = (int)Math.Round(950.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "LbrAmt";
			mSG[25] = (int)Math.Round(1000.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "OthAmt";
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
			mSG[18] = (int)Math.Round(800.0 * ColCon);
			mSG[18] = 3;
			mSG[0, 18] = "RtFix";
			mSG[19] = (int)Math.Round(1000.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "ItRate";
			mSG[20] = (int)Math.Round(1100.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "ItAmt";
			mSG[43] = (int)Math.Round(0.0 * ColCon);
			mSG[43] = 7;
			mSG[0, 43] = "TagCost";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "Margin";
			mSG[26] = (int)Math.Round(1000.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "Mrp";
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
					dataView.RowFilter = " BOOK_NAME = 'TOUR ORDER' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0");
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.00");
					mSG_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 43]) + Conversion.Val(MSG[DC_Main.M, 43]))), "0.00");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.000");
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
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 9] = Conversions.ToString(1);
		mSG[mSG.Row, 8] = Conversions.ToString(1);
		mSG[mSG.Row, 22] = DC_Main.MsLbrType;
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
		mSG[mSG.Row, 18] = "N";
		mSG[mSG.Row, 71] = "N";
		mSG[mSG.Row, 70] = DC_Main.MsOrdTagLessInStk;
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
				case 2:
				case 30:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
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
				case 18:
				case 22:
				case 45:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 8:
				case 9:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 13:
				case 15:
				case 16:
				case 21:
				case 35:
				case 36:
				case 44:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 19:
				case 20:
				case 23:
				case 24:
				case 25:
				case 26:
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
				case 10:
				case 11:
				case 12:
				case 14:
				case 31:
				case 32:
				case 33:
				case 34:
				case 37:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				case 17:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
					break;
				}
				mSG = null;
				((TextBoxBase)TEXT_ENTRY).SelectAll();
			}
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
		case 18:
		case 22:
		case 30:
		case 45:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 8:
		case 9:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 13:
		case 15:
		case 16:
		case 21:
		case 35:
		case 36:
		case 44:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 19:
		case 20:
		case 23:
		case 24:
		case 25:
		case 26:
		case 27:
		case 28:
		case 29:
		case 38:
		case 39:
		case 40:
		case 41:
		case 43:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 11:
		case 31:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 7:
		case 10:
		case 12:
		case 14:
		case 17:
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
				case 7621:
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
						case 8:
							goto IL_010e;
						case 9:
							goto IL_0159;
						case 10:
						case 11:
							goto IL_01a3;
						case 12:
							goto IL_01ef;
						case 13:
						case 14:
							goto IL_0243;
						case 15:
							goto IL_027a;
						case 16:
							goto IL_02ae;
						case 17:
							goto IL_030e;
						case 19:
							goto IL_038c;
						case 18:
						case 20:
						case 21:
						case 22:
							goto IL_03c3;
						case 23:
							goto IL_03fa;
						case 24:
							goto IL_042e;
						case 25:
							goto IL_048e;
						case 26:
						case 27:
						case 28:
							goto IL_050c;
						case 29:
							goto IL_0543;
						case 30:
							goto IL_0577;
						case 31:
							goto IL_05d7;
						case 32:
						case 33:
						case 34:
							goto IL_0655;
						case 35:
							goto IL_0690;
						case 36:
						case 37:
							goto IL_06da;
						case 38:
							goto IL_0726;
						case 39:
						case 40:
							goto IL_0770;
						case 41:
							goto IL_07a7;
						case 42:
							goto IL_07db;
						case 43:
							goto IL_083b;
						case 45:
							goto IL_08b9;
						case 44:
						case 46:
						case 47:
						case 48:
							goto IL_08f0;
						case 49:
							goto IL_0927;
						case 50:
							goto IL_095b;
						case 51:
							goto IL_09bb;
						case 52:
						case 53:
						case 54:
							goto IL_0a39;
						case 55:
							goto IL_0a70;
						case 56:
							goto IL_0aa4;
						case 57:
							goto IL_0b04;
						case 58:
						case 59:
						case 60:
							goto IL_0b82;
						case 61:
							goto IL_0bbd;
						case 62:
						case 63:
							goto IL_0c07;
						case 64:
							goto IL_0c57;
						case 66:
							goto IL_0ca0;
						case 68:
							goto IL_0cf4;
						case 70:
							goto IL_0d52;
						case 72:
							goto IL_0dad;
						case 65:
						case 67:
						case 69:
						case 71:
						case 73:
						case 74:
						case 75:
							goto IL_0e00;
						case 76:
							goto IL_0e16;
						case 77:
							goto IL_0e43;
						case 78:
							goto IL_0e93;
						case 80:
							goto IL_0edc;
						case 82:
							goto IL_0f34;
						case 84:
							goto IL_0fa0;
						case 86:
							goto IL_1013;
						case 79:
						case 81:
						case 83:
						case 85:
						case 87:
						case 88:
						case 89:
						case 90:
						case 91:
							goto IL_106e;
						case 92:
							goto IL_10ba;
						case 93:
						case 94:
							goto IL_1118;
						case 95:
							goto IL_1146;
						case 97:
							goto IL_118f;
						case 99:
							goto IL_11e3;
						case 101:
							goto IL_124b;
						case 103:
							goto IL_12ba;
						case 96:
						case 98:
						case 100:
						case 102:
						case 104:
						case 105:
						case 106:
							goto IL_130d;
						case 107:
							goto IL_1355;
						case 108:
							goto IL_136b;
						case 109:
							goto IL_13c4;
						case 110:
							goto IL_13eb;
						case 111:
						case 112:
							goto IL_1404;
						case 113:
							goto IL_1431;
						case 114:
							goto IL_1481;
						case 116:
							goto IL_14ca;
						case 118:
							goto IL_1522;
						case 120:
							goto IL_158e;
						case 122:
							goto IL_1601;
						case 115:
						case 117:
						case 119:
						case 121:
						case 123:
						case 124:
						case 125:
						case 126:
						case 127:
							goto IL_165c;
						case 128:
							goto IL_16b8;
						case 129:
							goto IL_16e2;
						case 130:
						case 131:
							goto IL_171b;
						case 132:
							goto IL_1734;
						case 133:
							goto IL_1764;
						case 134:
							goto IL_17c9;
						case 135:
							goto IL_182e;
						case 136:
							goto IL_185e;
						case 137:
							goto IL_18a8;
						case 139:
							goto IL_18f9;
						case 140:
							goto IL_1943;
						case 142:
							goto IL_19a8;
						case 143:
							goto IL_19f2;
						case 145:
							goto IL_1a4d;
						case 146:
							goto IL_1a97;
						case 150:
							goto IL_1ae9;
						case 138:
						case 141:
						case 144:
						case 147:
						case 148:
						case 149:
						case 151:
						case 152:
						case 153:
							goto IL_1b24;
						case 154:
							goto IL_1b26;
						case 155:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 156:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_1ae9:
					num2 = 150;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_1b24;
					IL_1b24:
					val = null;
					goto IL_1b26;
					IL_1a97:
					num2 = 146;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 10])), "0.00");
					goto IL_1b24;
					IL_1b26:
					num2 = 154;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 10]) != Conversion.Val(val[val.Row, 56]))
					{
						goto IL_004b;
					}
					goto IL_010e;
					IL_004b:
					num2 = 4;
					val[val.Row, 56] = Strings.Format((object)Conversion.Val(val[val.Row, 10]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 31])), "0.000");
					goto IL_010e;
					IL_010e:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 11]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_0159;
					}
					goto IL_01a3;
					IL_0159:
					num2 = 9;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_01a3;
					IL_01a3:
					num2 = 11;
					if ((Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_01ef;
					}
					goto IL_0243;
					IL_01ef:
					num2 = 12;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 13]) / 100.0), "0.000");
					goto IL_0243;
					IL_0243:
					num2 = 14;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 57]))
					{
						goto IL_027a;
					}
					goto IL_03c3;
					IL_027a:
					num2 = 15;
					val[val.Row, 57] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_02ae;
					IL_02ae:
					num2 = 16;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_030e;
					}
					goto IL_038c;
					IL_030e:
					num2 = 17;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_03c3;
					IL_038c:
					num2 = 19;
					val[val.Row, 17] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_03c3;
					IL_03c3:
					num2 = 22;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_03fa;
					}
					goto IL_050c;
					IL_03fa:
					num2 = 23;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_042e;
					IL_042e:
					num2 = 24;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_048e;
					}
					goto IL_050c;
					IL_048e:
					num2 = 25;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_050c;
					IL_050c:
					num2 = 28;
					if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 61]))
					{
						goto IL_0543;
					}
					goto IL_0655;
					IL_0543:
					num2 = 29;
					val[val.Row, 61] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_0577;
					IL_0577:
					num2 = 30;
					if ((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_05d7;
					}
					goto IL_0655;
					IL_05d7:
					num2 = 31;
					val[val.Row, 17] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16])) / 100.0), "0.000");
					goto IL_0655;
					IL_0655:
					num2 = 34;
					if (Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) == 0.0)
					{
						goto IL_0690;
					}
					goto IL_06da;
					IL_0690:
					num2 = 35;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_06da;
					IL_06da:
					num2 = 37;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_0726;
					}
					goto IL_0770;
					IL_0726:
					num2 = 38;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 10]) - Conversion.Val(val[val.Row, 31])), "0.000");
					goto IL_0770;
					IL_0770:
					num2 = 40;
					if (Conversion.Val(val[val.Row, 32]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_07a7;
					}
					goto IL_08f0;
					IL_07a7:
					num2 = 41;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 32]), "0.000");
					goto IL_07db;
					IL_07db:
					num2 = 42;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_083b;
					}
					goto IL_08b9;
					IL_083b:
					num2 = 43;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_08f0;
					IL_08b9:
					num2 = 45;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 32]), "0.000");
					goto IL_08f0;
					IL_08f0:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 35]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_0927;
					}
					goto IL_0a39;
					IL_0927:
					num2 = 49;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 35]), "0.00");
					goto IL_095b;
					IL_095b:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_09bb;
					}
					goto IL_0a39;
					IL_09bb:
					num2 = 51;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_0a39;
					IL_0a39:
					num2 = 54;
					if (Conversion.Val(val[val.Row, 36]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_0a70;
					}
					goto IL_0b82;
					IL_0a70:
					num2 = 55;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.00");
					goto IL_0aa4;
					IL_0aa4:
					num2 = 56;
					if ((Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 32]) != 0.0))
					{
						goto IL_0b04;
					}
					goto IL_0b82;
					IL_0b04:
					num2 = 57;
					val[val.Row, 37] = Strings.Format((object)((Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])) * (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36])) / 100.0), "0.000");
					goto IL_0b82;
					IL_0b82:
					num2 = 60;
					if (Conversion.Val(val[val.Row, 35]) + Conversion.Val(val[val.Row, 36]) == 0.0)
					{
						goto IL_0bbd;
					}
					goto IL_0c07;
					IL_0bbd:
					num2 = 61;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 32]) + Conversion.Val(val[val.Row, 34])), "0.000");
					goto IL_0c07;
					IL_0c07:
					num2 = 63;
					if ((Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_0c57;
					}
					goto IL_0e00;
					IL_0c57:
					num2 = 64;
					switch (val[val.Row, 48])
					{
					case "P":
						break;
					case "1":
						goto IL_0cf4;
					case "K":
						goto IL_0d52;
					default:
						goto IL_0dad;
					}
					goto IL_0ca0;
					IL_0dad:
					num2 = 72;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_0e00;
					IL_0d52:
					num2 = 70;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * (Conversion.Val(val[val.Row, 19]) / 1000.0), 0), "0.00");
					goto IL_0e00;
					IL_0cf4:
					num2 = 68;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * (Conversion.Val(val[val.Row, 19]) / 10.0), 0), "0.00");
					goto IL_0e00;
					IL_0ca0:
					num2 = 66;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_0e00;
					IL_0e00:
					num2 = 75;
					if (val.Col == 24)
					{
						goto IL_0e16;
					}
					goto IL_106e;
					IL_0e16:
					num2 = 76;
					if (Conversion.Val(val[val.Row, 24]) != 0.0)
					{
						goto IL_0e43;
					}
					goto IL_106e;
					IL_0e43:
					num2 = 77;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_0e93;
					}
					goto IL_106e;
					IL_0e93:
					num2 = 78;
					switch (val[val.Row, 22])
					{
					case "P":
						break;
					case "N":
						goto IL_0f34;
					case "K":
						goto IL_0fa0;
					default:
						goto IL_1013;
					}
					goto IL_0edc;
					IL_1013:
					num2 = 86;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_106e;
					IL_0fa0:
					num2 = 84;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_106e;
					IL_0f34:
					num2 = 82;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), DC_Main.MsLbrRof), "0.00");
					goto IL_106e;
					IL_0edc:
					num2 = 80;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_106e;
					IL_106e:
					num2 = 91;
					if ((Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 19]) != 0.0))
					{
						goto IL_10ba;
					}
					goto IL_1118;
					IL_10ba:
					num2 = 92;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 19]) * Conversion.Val(val[val.Row, 21]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1118;
					IL_1118:
					num2 = 94;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_1146;
					}
					goto IL_130d;
					IL_1146:
					num2 = 95;
					switch (val[val.Row, 22])
					{
					case "P":
						break;
					case "N":
						goto IL_11e3;
					case "K":
						goto IL_124b;
					default:
						goto IL_12ba;
					}
					goto IL_118f;
					IL_12ba:
					num2 = 103;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_130d;
					IL_124b:
					num2 = 101;
					val[val.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 23]) / 1000.0), 0), "0.00");
					goto IL_130d;
					IL_11e3:
					num2 = 99;
					val[val.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_130d;
					IL_118f:
					num2 = 97;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_130d;
					IL_130d:
					num2 = 106;
					val[val.Row, 41] = Strings.Format((object)(Conversion.Val(val[val.Row, 39]) + Conversion.Val(val[val.Row, 40])), "0.0");
					goto IL_1355;
					IL_1355:
					num2 = 107;
					if (val.Col == 27)
					{
						goto IL_136b;
					}
					goto IL_165c;
					IL_136b:
					num2 = 108;
					val[val.Row, 24] = Strings.Format((object)(Conversion.Val(TEXT_ENTRY.Text) - Conversion.Val(val[val.Row, 25]) - Conversion.Val(val[val.Row, 20])), "0.00");
					goto IL_13c4;
					IL_13c4:
					num2 = 109;
					if (Conversion.Val(val[val.Row, 24]) < 0.0)
					{
						goto IL_13eb;
					}
					goto IL_1404;
					IL_13eb:
					num2 = 110;
					val[val.Row, 24] = "";
					goto IL_1404;
					IL_1404:
					num2 = 112;
					if (Conversion.Val(val[val.Row, 24]) != 0.0)
					{
						goto IL_1431;
					}
					goto IL_165c;
					IL_1431:
					num2 = 113;
					if ((Conversion.Val(val[val.Row, 24]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_1481;
					}
					goto IL_165c;
					IL_1481:
					num2 = 114;
					switch (val[val.Row, 22])
					{
					case "P":
						break;
					case "N":
						goto IL_1522;
					case "K":
						goto IL_158e;
					default:
						goto IL_1601;
					}
					goto IL_14ca;
					IL_1601:
					num2 = 122;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_165c;
					IL_158e:
					num2 = 120;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_165c;
					IL_1522:
					num2 = 118;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), DC_Main.MsLbrRof), "0.00");
					goto IL_165c;
					IL_14ca:
					num2 = 116;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_165c;
					IL_165c:
					num2 = 127;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 20])), "0.00");
					goto IL_16b8;
					IL_16b8:
					num2 = 128;
					if (Conversion.Val(val[val.Row, 28]) == 0.0)
					{
						goto IL_16e2;
					}
					goto IL_171b;
					IL_16e2:
					num2 = 129;
					val[val.Row, 29] = Strings.Format((object)Conversion.Val(val[val.Row, 27]), "0.00");
					goto IL_171b;
					IL_171b:
					num2 = 131;
					if (val.Col == 28)
					{
						goto IL_1734;
					}
					goto IL_1b24;
					IL_1734:
					num2 = 132;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_1764;
					}
					goto IL_1ae9;
					IL_1764:
					num2 = 133;
					val[val.Row, 29] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 27]) / (Conversion.Val(val[val.Row, 28]) + 100.0) * 100.0, 0), "0.00");
					goto IL_17c9;
					IL_17c9:
					num2 = 134;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 29]) - Conversion.Val(val[val.Row, 20]) - Conversion.Val(val[val.Row, 25]), 0), "0.00");
					goto IL_182e;
					IL_182e:
					num2 = 135;
					if (Conversion.Val(val[val.Row, 24]) != 0.0)
					{
						goto IL_185e;
					}
					goto IL_1b24;
					IL_185e:
					num2 = 136;
					if ((Operators.CompareString(val[val.Row, 22], "P", false) == 0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_18a8;
					}
					goto IL_18f9;
					IL_18a8:
					num2 = 137;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 9])), "0.00");
					goto IL_1b24;
					IL_18f9:
					num2 = 139;
					if ((Operators.CompareString(val[val.Row, 22], "N", false) == 0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_1943;
					}
					goto IL_19a8;
					IL_1943:
					num2 = 140;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14]))), "0.00");
					goto IL_1b24;
					IL_19a8:
					num2 = 142;
					if ((Operators.CompareString(val[val.Row, 22], "K", false) == 0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_19f2;
					}
					goto IL_1a4d;
					IL_19f2:
					num2 = 143;
					val[val.Row, 23] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) / Conversion.Val(val[val.Row, 10]) * 1000.0), "0.00");
					goto IL_1b24;
					IL_1a4d:
					num2 = 145;
					if ((Operators.CompareString(val[val.Row, 22], "G", false) == 0) & (Conversion.Val(val[val.Row, 10]) != 0.0))
					{
						goto IL_1a97;
					}
					goto IL_1b24;
					end_IL_0001_2:
					break;
				}
				num2 = 155;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 7621;
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
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Invalid comparison between Unknown and I4
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ea: Invalid comparison between Unknown and I4
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_033e: Invalid comparison between Unknown and I4
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ba: Invalid comparison between Unknown and I4
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_040e: Invalid comparison between Unknown and I4
		//IL_0466: Unknown result type (might be due to invalid IL or missing references)
		//IL_0469: Invalid comparison between Unknown and I4
		//IL_20e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2433: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_094b: Unknown result type (might be due to invalid IL or missing references)
		//IL_075d: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
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
						if (Operators.CompareString(FormBookInOut, "I", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 42]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
							{
								DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.DESIGN_NO AS DesignNoL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_DATE From APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = 'EMP ISU' AND A.EMP_CODE = '" + tEmpCode.Text + "' AND A.ISU_REC = 'N' ";
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
									mSG[mSG.Row, 52] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
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
						if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
						{
							DC_Main.RsQry = "Select A.TAG_NO FROM APR_DETL AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "' AND BOOK_NAME = 'EMP ISU' AND A.EMP_CODE = '" + tEmpCode.Text + "' AND A.ISU_REC = 'N'";
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count == 0)
							{
								TEXT_ENTRY.Text = "";
								Interaction.MsgBox((object)"This Tag Not In Employee Stock List Please Check...", (MsgBoxStyle)0, (object)null);
								return;
							}
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
								mSG[mSG.Row, 10] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 12] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 42] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 42]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG[DC_Main.i, 9] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 8] = Conversions.ToString(1);
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
							mSG[DC_Main.i, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
							mSG[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"])), "0.00");
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_SRNO"])), "0");
							mSG[DC_Main.i, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 49] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 55] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[DC_Main.i, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
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
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (Operators.CompareString(MSG[mSG.Row, 1], "", false) != 0 && mSG.Row == mSG.Rows - 1)
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
					case 10:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
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

	private void TR_TOUR_ORD_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_10db: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ea: Expected O, but got Unknown
		//IL_110f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1114: Unknown result type (might be due to invalid IL or missing references)
		//IL_111e: Expected O, but got Unknown
		//IL_1143: Unknown result type (might be due to invalid IL or missing references)
		//IL_1148: Unknown result type (might be due to invalid IL or missing references)
		//IL_1152: Expected O, but got Unknown
		//IL_1177: Unknown result type (might be due to invalid IL or missing references)
		//IL_117c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1186: Expected O, but got Unknown
		//IL_11c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d4: Expected O, but got Unknown
		//IL_11ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_11f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11fd: Expected O, but got Unknown
		//IL_1217: Unknown result type (might be due to invalid IL or missing references)
		//IL_121c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1226: Expected O, but got Unknown
		//IL_1240: Unknown result type (might be due to invalid IL or missing references)
		//IL_1245: Unknown result type (might be due to invalid IL or missing references)
		//IL_124f: Expected O, but got Unknown
		//IL_1269: Unknown result type (might be due to invalid IL or missing references)
		//IL_126e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1278: Expected O, but got Unknown
		//IL_12a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a7: Expected O, but got Unknown
		//IL_1388: Unknown result type (might be due to invalid IL or missing references)
		//IL_138d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1397: Expected O, but got Unknown
		//IL_141f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1424: Unknown result type (might be due to invalid IL or missing references)
		//IL_142e: Expected O, but got Unknown
		//IL_14c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_14cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d2: Expected O, but got Unknown
		//IL_155c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1561: Unknown result type (might be due to invalid IL or missing references)
		//IL_156b: Expected O, but got Unknown
		//IL_1590: Unknown result type (might be due to invalid IL or missing references)
		//IL_1595: Unknown result type (might be due to invalid IL or missing references)
		//IL_159f: Expected O, but got Unknown
		//IL_15cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d6: Expected O, but got Unknown
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AxMSFlexGrid mSG4 = MSG;
				object? obj25 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj26 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj28 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj29 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj31 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj32 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_OLD4 = MSG_OLD;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD4.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_OLD5 = MSG_OLD;
				object? obj35 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_OLD5.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_OLD6 = MSG_OLD;
				object? obj36 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_OLD6.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj37 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj38 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj39 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj39 != null) ? ((Color)obj39) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj40 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj41 = lblBook;
				object? obj42 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj41).ForeColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj43 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj44 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj45 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj45 != null) ? ((Color)obj45) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj46 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj46 != null) ? ((Color)obj46) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj47 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj48 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj49 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj50 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj51 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj51 != null) ? ((Color)obj51) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj52 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj52 != null) ? ((Color)obj52) : default(Color));
				AxMSFlexGrid mSG_OLD7 = MSG_OLD;
				object? obj53 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_OLD7.BackColor = ((obj53 != null) ? ((Color)obj53) : default(Color));
				AxMSFlexGrid mSG_OLD8 = MSG_OLD;
				object? obj54 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_OLD8.BackColorBkg = ((obj54 != null) ? ((Color)obj54) : default(Color));
				AxMSFlexGrid mSG_OLD9 = MSG_OLD;
				object? obj55 = colorConverter.ConvertFromString("Cornsilk");
				mSG_OLD9.BackColorFixed = ((obj55 != null) ? ((Color)obj55) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj56 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj56 != null) ? ((Color)obj56) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj57 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj57 != null) ? ((Color)obj57) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj58 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj58 != null) ? ((Color)obj58) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)BtnAll).Appearance;
				object? obj59 = colorConverter.ConvertFromString("238, 244, 236");
				appearance.BackColor = ((obj59 != null) ? ((Color)obj59) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				((TextBoxBase)TEXT_IDTL).AutoSize = false;
				((TextBoxBase)TEXT_OLD).AutoSize = false;
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_OLD).Font = new Font(((Control)TEXT_OLD).Font.FontFamily, (float)num3, ((Control)TEXT_OLD).Font.Style);
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_IDTL).Font = new Font(((Control)TEXT_IDTL).Font.FontFamily, (float)num3, ((Control)TEXT_IDTL).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG_OLD.Font = new Font("Segoe UI Semibold", (float)num3, MSG_OLD.Font.Style);
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
		((TextBoxBase)tVchNo).ReadOnly = true;
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
		((Control)TEXT_OLD).Visible = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG_OLD_CLEAR();
		MSG2_CLEAR();
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
				tAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD1"], (object)""));
				tAdd2.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD2"], (object)""));
				tAdd3.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ADD3"], (object)""));
				tCity.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CITY"], (object)""));
				tMobile.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MOBILE"], (object)""));
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
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_QTY"])));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_PCS"])));
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_FIX"], (object)""));
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_AMT"])), "0.00");
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
					double num = 0.0;
					num = Conversion.Val(mSG[DC_Main.i + 1, 7]) + Conversion.Val(mSG[DC_Main.i + 1, 9]) + Conversion.Val(mSG[DC_Main.i + 1, 10]) + Conversion.Val(mSG[DC_Main.i + 1, 17]) + Conversion.Val(mSG[DC_Main.i + 1, 32]) + Conversion.Val(mSG[DC_Main.i + 1, 37]);
					num += Conversion.Val(mSG[DC_Main.i + 1, 21]) + Conversion.Val(mSG[DC_Main.i + 1, 24]) + Conversion.Val(mSG[DC_Main.i + 1, 25]) + Conversion.Val(mSG[DC_Main.i + 1, 43]) + Conversion.Val(mSG[DC_Main.i + 1, 26]) + Conversion.Val(mSG[DC_Main.i + 1, 8]);
					string text = "";
					text = mSG[DC_Main.i + 1, 3] + mSG[DC_Main.i + 1, 4] + mSG[DC_Main.i + 1, 6] + mSG[DC_Main.i + 1, 1] + mSG[DC_Main.i + 1, 65] + mSG[DC_Main.i + 1, 30];
					mSG[DC_Main.i + 1, 72] = Strings.Format((object)num, "0.000");
					mSG[DC_Main.i + 1, 73] = text;
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
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
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
					mSG_OLD[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG_OLD[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["ITM_RATE_TYPE"], (object)""));
					mSG_OLD[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsOldDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG_OLD[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsOldDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG_OLD.Rows += 1;
					DC_Main.i++;
				}
				if (mSG_OLD.Rows > 2)
				{
					mSG_OLD.Rows -= 1;
				}
				mSG_OLD = null;
				if (MSG.Rows >= 1)
				{
					MSG.Row = 1;
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
				NewValTot = Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 32]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
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

	private void TR_TOUR_ORD_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_TOUR_ORD_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0220: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0341: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0423: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Invalid comparison between Unknown and I4
		//IL_0492: Unknown result type (might be due to invalid IL or missing references)
		//IL_053c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0587: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
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
		DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_TOT[0, 26]) != 0.0) | (Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG2_TOTAL[9, 3]) != 0.0))
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
			dataRow2["FUN_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mDelDate.Text), (object)DBNull.Value, (object)mDelDate.Text));
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
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG = MSG;
				double num2 = 0.0;
				num2 = Conversion.Val(mSG[DC_Main.i, 7]) + Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 10]) + Conversion.Val(mSG[DC_Main.i, 17]) + Conversion.Val(mSG[DC_Main.i, 32]) + Conversion.Val(mSG[DC_Main.i, 37]);
				num2 += Conversion.Val(mSG[DC_Main.i, 21]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 25]) + Conversion.Val(mSG[DC_Main.i, 43]) + Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 8]);
				string text = "";
				text = mSG[DC_Main.i, 3] + mSG[DC_Main.i, 4] + mSG[DC_Main.i, 6] + mSG[DC_Main.i, 1] + mSG[DC_Main.i, 65] + mSG[DC_Main.i, 30];
				if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG[DC_Main.i, 72]), "0.000"), Strings.Format((object)num2, "0.000"), false) != 0) | (Operators.CompareString(mSG[DC_Main.i, 73], text, false) != 0))
				{
					DC_Main.ExeQuteDc(("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 0]))) ?? "");
					DC_Main.RsQry = ("SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 0]))) ?? "";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow3 = RsDetl.NewRow();
					if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 26]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 10]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 25]) != 0.0))
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
						dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
						dataRow3["TBL_CODE"] = mSG[DC_Main.i, 3];
						dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
						dataRow3["ITM_COLOR"] = mSG[DC_Main.i, 5];
						dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
						dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
						dataRow3["ITM_QTY"] = Conversion.Val(mSG[DC_Main.i, 8]);
						dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 9]);
						dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 10]);
						dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 11]);
						dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
						dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 13]);
						dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 14]);
						dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 15]);
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 16]);
						dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 17]);
						dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 21]);
						dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 22];
						dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 23]);
						dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
						dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
						if (mSG[18] != 0)
						{
							dataRow3["RATE_FIX"] = mSG[DC_Main.i, 18];
						}
						else if (Conversion.Val(mSG[DC_Main.i, 19]) != 0.0)
						{
							dataRow3["RATE_FIX"] = "Y";
						}
						else
						{
							dataRow3["RATE_FIX"] = "N";
						}
						dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 19]);
						dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
						dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 26]);
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
						dataRow3["ORD_DEL_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(!Information.IsDate((object)mDelDate.Text), (object)DBNull.Value, (object)mDelDate.Text));
						dataRow3["EMP_CODE"] = tEmpCode.Text;
						dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 71];
						dataRow3["MAIN_USER"] = MainUser;
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						RsDetl.Rows.Add(dataRow3);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
				}
				mSG = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num3 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15])) != 0.0)
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
					dataRow4["ENTRY_TYPE"] = "O";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow4["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))), 1];
					dataRow4["VCH_SRNO"] = Conversion.Val(MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]))), 42]);
					dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
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
			DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			RsOldDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow5 = RsOldDetl.NewRow();
			int num4 = MSG_OLD.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num4)
			{
				AxMSFlexGrid mSG_OLD = MSG_OLD;
				if ((Conversion.Val(MSG_OLD[DC_Main.i, 6]) + Conversion.Val(MSG_OLD[DC_Main.i, 11]) != 0.0) & (Operators.CompareString(MSG_OLD[DC_Main.i, 1], "", false) != 0))
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
					dataRow5["ENTRY_TYPE"] = "A";
					dataRow5["BOOK_NAME"] = FormMainBook;
					dataRow5["SR_NO"] = Conversion.Val(mSG_OLD[DC_Main.i, 0]);
					dataRow5["IT_CODE"] = mSG_OLD[DC_Main.i, 1];
					dataRow5["IT_TYPE"] = mSG_OLD[DC_Main.i, 12];
					dataRow5["IT_DESC"] = mSG_OLD[DC_Main.i, 2];
					dataRow5["ITM_PCS"] = Conversion.Val(mSG_OLD[DC_Main.i, 3]);
					dataRow5["ITM_GWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 4]);
					dataRow5["ITM_OTH"] = Conversion.Val(mSG_OLD[DC_Main.i, 5]);
					dataRow5["ITM_NWT"] = Conversion.Val(mSG_OLD[DC_Main.i, 6]);
					dataRow5["ITM_TOUCH"] = Conversion.Val(mSG_OLD[DC_Main.i, 7]);
					dataRow5["ITM_FINE"] = Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					dataRow5["ITM_RATE_TYPE"] = mSG_OLD[DC_Main.i, 9];
					dataRow5["ITM_RATE"] = Conversion.Val(mSG_OLD[DC_Main.i, 10]);
					dataRow5["NET_AMT"] = Conversion.Val(mSG_OLD[DC_Main.i, 11]);
					if ((Operators.CompareString(mSG_OLD[DC_Main.i, 12], "G", false) == 0) & (Conversion.Val(mSG_OLD[DC_Main.i, 11]) == 0.0))
					{
						OrdGold += Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					}
					if ((Operators.CompareString(mSG_OLD[DC_Main.i, 12], "S", false) == 0) & (Conversion.Val(mSG_OLD[DC_Main.i, 11]) == 0.0))
					{
						OrdSilver += Conversion.Val(mSG_OLD[DC_Main.i, 8]);
					}
					dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow5["MAIN_USER"] = MainUser;
					RsOldDetl.Rows.Add(dataRow5);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsOldDetl);
					RsOldDetl.Clear();
				}
				mSG_OLD = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT * FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ";
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow6 = dataTable2.NewRow();
			if (Conversion.Val(MSG2_TOTAL[9, 3]) + OrdGold + OrdSilver != 0.0)
			{
				dataRow6["CO_CODE"] = DC_Main.MCo_code;
				dataRow6["LC_CODE"] = DC_Main.MLc_code;
				dataRow6["CO_YEAR"] = DC_Main.MCo_year;
				dataRow6["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow6["VCH_NO"] = tVchNo.Text;
				dataRow6["SR_NO"] = 1;
				dataRow6["VCH_DATE"] = mVchDate.Text;
				dataRow6["HD_VCH_NO"] = tHdVchNo.Text;
				dataRow6["AC_CODE"] = tAcCode.Text;
				dataRow6["AC_NAME"] = tAcName.Text;
				dataRow6["VCH_TYPE"] = FormBookSname;
				dataRow6["INOUT_TYPE"] = FormBookInOut;
				dataRow6["ENTRY_TYPE"] = "O";
				dataRow6["BOOK_NAME"] = FormMainBook;
				dataRow6["ORD_HD_VCH_NO"] = tHdVchNo.Text;
				dataRow6["ORD_NO"] = tVchNo.Text;
				dataRow6["ORD_LC"] = DC_Main.MLc_code;
				dataRow6["ORD_YRCD"] = DC_Main.MCo_year;
				dataRow6["ORD_DBCD"] = DC_Main.MCo_Book;
				dataRow6["ORD_AC_CODE"] = tAcCode.Text;
				dataRow6["ORD_SIGN"] = "+";
				dataRow6["ORD_AMT"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Conversion.Val(MSG2_TOTAL[9, 1]) == 0.0, (object)Conversion.Val(MSG2_TOTAL[9, 3]), (object)0));
				dataRow6["PAID_AC"] = "";
				dataRow6["PAID_AMT"] = 0;
				dataRow6["KASAR_AMT"] = 0;
				dataRow6["ORD_BAL_AMT"] = 0;
				dataRow6["ORD_GOLD"] = OrdGold + Conversion.Val(MSG2_TOTAL[9, 2]);
				dataRow6["ORD_SILVER"] = OrdSilver;
				dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow6["DATA_TRFR"] = "N";
				dataRow6["EMP_CODE"] = tEmpCode.Text;
				dataRow6["IT_DESC"] = tVchDesc.Text;
				dataRow6["MAIN_USER"] = MainUser;
				dataTable2.Rows.Add(dataRow6);
				((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
				dataTable2.Clear();
			}
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
			DC_Main.RsQry = "SELECT CO_YEAR,CO_BOOK,VCH_NO,NET_AMT,ADV_AMT FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' AND ADV_AMT <> 0 ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["NET_AMT"], (object)0, false), Operators.CompareObjectNotEqual(DC_Main.Rshlp.Rows[0]["ADV_AMT"], (object)0, false))))
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT CO_YEAR,CO_BOOK,VCH_NO,SR_NO,NET_AMT FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' and CO_BOOK = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND VCH_NO = '"), DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"' ORDER BY SR_NO"));
					DataTable dataTable3 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					int num5 = 0;
					int num6 = dataTable3.Rows.Count - 1;
					for (num5 = 0; num5 <= num6; num5++)
					{
						if (Operators.ConditionalCompareObjectNotEqual(dataTable3.Rows[num5]["NET_AMT"], (object)0, false))
						{
							double num7 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet((object)null, typeof(Math), "Round", new object[2]
							{
								Operators.DivideObject(Operators.MultiplyObject(dataTable3.Rows[num5]["NET_AMT"], DC_Main.Rshlp.Rows[0]["ADV_AMT"]), DC_Main.Rshlp.Rows[0]["NET_AMT"]),
								2
							}, (string[])null, (Type[])null, (bool[])null)), "0.000"));
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE SL_ORD_DETL SET ORD_REC_AMT = " + Conversions.ToString(num7) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), dataTable3.Rows[num5]["CO_YEAR"]), (object)"' and CO_BOOK = '"), dataTable3.Rows[num5]["CO_BOOK"]), (object)"' AND VCH_NO = '"), dataTable3.Rows[num5]["VCH_NO"]), (object)"'  AND SR_NO = "), dataTable3.Rows[num5]["SR_NO"]), (object)"")));
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
				string text2 = "";
				int num8 = RsData.Columns.Count - 2;
				DC_Main.M = 0;
				while (DC_Main.M <= num8)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)""), Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)""), false))
					{
						int num9 = DC_Main.RsTblCol.Rows.Count - 1;
						for (int j = 0; j <= num9; j++)
						{
							if (Operators.ConditionalCompareObjectEqual((object)RsData.Columns[DC_Main.M].ColumnName, DC_Main.RsTblCol.Rows[j]["TBL_COL_NAME"], false))
							{
								text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTblCol.Rows[j]["COL_NAME"], (object)""));
							}
						}
						if (Operators.CompareString(text2, "", false) == 0)
						{
							text2 = RsData.Columns[DC_Main.M].ColumnName;
						}
						DC_Main.RsQry = "INSERT INTO USER_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,AC_CODE,VCH_DATE,EDIT_DATE,ENTRY_TIME,USER_NAME,NEW_USER,BOOK_NAME,COL_TYPE,OLD_VAL,NEW_VAL,ENTRY_CHECK)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "','" + tAcCode.Text + "','" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy hh:mm") + "','" + MainUser + "','" + DC_Main.MCo_User + "','" + FormMainBook + "','" + text2 + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(VchOldData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','" + Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0][DC_Main.M], (object)"")), 1, 50) + "','N')";
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						text2 = "";
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
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf3: Unknown result type (might be due to invalid IL or missing references)
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
			checked
			{
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					int num = DC_Main.Tbl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num)
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
				DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("Delete FROM SL_ORD_ADJ WHERE CO_CODE='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK ='" + DC_Main.MCo_Book + "' AND VCH_NO ='" + tVchNo.Text + "' ");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_ORD_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				CLEAR_DATA();
			}
		}
	}

	private void TR_TOUR_ORD_KeyDown(object sender, KeyEventArgs e)
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
				((Control)tBankName).Focus();
			}
			else if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void ImgPrint()
	{
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_068f: Expected O, but got Unknown
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_0528: Unknown result type (might be due to invalid IL or missing references)
		//IL_0532: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MsOrdImgPrint, "Y", false) != 0)
		{
			return;
		}
		DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				PicImage.Image = null;
				AxMSFlexGrid mSG = MSG;
				if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0)
				{
					DC_Main.MsImageNo = mSG[DC_Main.i, 1] + "_" + mSG[DC_Main.i, 42];
					DC_Main.MsImageType = "TagImage";
				}
				else if (Operators.CompareString(mSG[DC_Main.i, 4], "", false) != 0)
				{
					DC_Main.MsImageNo = mSG[DC_Main.i, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
					DC_Main.MsImageType = "TagImage";
				}
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
				{
					if ((Operators.CompareString(MSG[DC_Main.i, 71], "N", false) != 0) & (Operators.CompareString(MSG[DC_Main.i, 4], "", false) != 0))
					{
						DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[DC_Main.i, 71] + "' AND IMAGE_TYPE = 'D'";
						DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
						if (dataTable.Rows.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
							{
								PicImage.Image = null;
								break;
							}
							object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
							byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
							object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
							PicImage.Image = (Image)objectValue;
						}
					}
					else
					{
						if (Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0)
						{
							DC_Main.MsImageNo = MSG[DC_Main.i, 1] + "_" + MSG[DC_Main.i, 42];
							DC_Main.MsImageType = "TagImage";
						}
						else
						{
							DC_Main.MsImageNo = MSG[DC_Main.i, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
							DC_Main.MsImageType = "TagImage";
						}
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
								PicImage.Image = null;
								string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
								PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
							}
							catch (Exception ex)
							{
								ProjectData.SetProjectError(ex);
								Exception ex2 = ex;
								if (Operators.CompareString(MSG[DC_Main.i, 1], "", false) != 0)
								{
									DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 42]))) ?? "";
									DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
									if (dataTable.Rows.Count > 0)
									{
										if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
										{
											PicImage.Image = null;
											ProjectData.ClearProjectError();
											break;
										}
										object obj2 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
										byte[] bA2 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj2));
										object objectValue2 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA2));
										PicImage.Image = (Image)objectValue2;
									}
								}
								ProjectData.ClearProjectError();
							}
						}
						if (PicImage.Image != null)
						{
							string text = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
							if (Operators.CompareString(FileSystem.Dir(text, (FileAttribute)0), "", false) == 0)
							{
								PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
							}
						}
					}
				}
				if (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0)
				{
					DC_Main.MsImageNo = mSG[DC_Main.i, 1] + "_" + mSG[DC_Main.i, 42];
					DC_Main.MsImageType = "TagImage";
				}
				else if (Operators.CompareString(mSG[DC_Main.i, 4], "", false) != 0)
				{
					DC_Main.MsImageNo = mSG[DC_Main.i, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
					DC_Main.MsImageType = "TagImage";
				}
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
					MemoryStream memoryStream = new MemoryStream();
					PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
					byte[] buffer = memoryStream.GetBuffer();
					DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND SCHM_CODE = '" + DC_Main.MCo_Book + "' AND MEMB_CODE = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.i, 0]))) ?? "";
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow = dataTable.NewRow();
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["SCHM_CODE"] = DC_Main.MCo_Book;
					dataRow["MEMB_CODE"] = tVchNo.Text;
					dataRow["SR_NO"] = Conversion.Val(MSG[DC_Main.i, 0]);
					dataRow["TAG_NO"] = "";
					dataRow["VCH_SRNO"] = 0;
					dataRow["DESIGN"] = MSG[DC_Main.i, 4];
					dataRow["TAG_IMAGE"] = buffer;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
					Thread.Sleep(500);
					Application.DoEvents();
				}
				mSG = null;
				DC_Main.i++;
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
		ImgPrint();
		DC_Main.RsQry = "SELECT * FROM IMAGE_DATA ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = "SELECT * FROM SL_ORD_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string rptName;
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\OrderVch.RPT";
			rptName = "OrderVch";
		}
		else if (Operators.CompareString(DC_Main.MsOrdImgPrint, "Y", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TourOrdImg.RPT";
			rptName = "TourOrdImg";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TourOrdVch.RPT";
			rptName = "TourOrdVch";
		}
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		DC_Main.RsQry = "SELECT * FROM SL_PR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + CurPrnVch + "' ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			Cr[(short)2] = "OldItem = 'N'";
		}
		else
		{
			Cr[(short)2] = "OldItem = 'Y'";
		}
		Cr.SelectionFormula = "{SL_ORD_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {SL_ORD_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {SL_ORD_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {SL_ORD_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {SL_ORD_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)3] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)4] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
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
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_TOUR_ORD_Activated(object sender, EventArgs e)
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
		else
		{
			((ContainerControl)this).ActiveControl = CurActCtrl;
			CurActCtrl.Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_0b6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b78: Expected O, but got Unknown
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_063e: Expected O, but got Unknown
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a09: Expected O, but got Unknown
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
				if (PicImage.Image != null)
				{
					string text = Application.StartupPath + "\\AllImage\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(text, (FileAttribute)0), "", false) == 0)
					{
						PicImage.Image.Save(Application.StartupPath + "\\AllImage\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
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
						PicImage.Image = null;
						string address = DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg";
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
					}
					catch (Exception ex)
					{
						ProjectData.SetProjectError(ex);
						Exception ex2 = ex;
						if (Operators.CompareString(MSG[MSG.Row, 1], "", false) != 0)
						{
							DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 42]))) ?? "";
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
						}
						ProjectData.ClearProjectError();
					}
				}
				if (PicImage.Image != null)
				{
					string text2 = Application.StartupPath + "\\AllImage\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(text2, (FileAttribute)0), "", false) == 0)
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
			BtnAll_Click(BtnAll, new EventArgs());
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

	private void TR_TOUR_ORD_Closed(object sender, EventArgs e)
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
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tEmpCode.Text, "", false) != 0)
		{
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
		else
		{
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
			mSG2_TOTAL[3, 0] = "Cash Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 10) | (mSG2_TOTAL.Row == 7) | (mSG2_TOTAL.Row == 6))
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
		//IL_054b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
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
			mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[3, 3]) + Conversion.Val(mSG2_TOTAL[8, 3]) + Conversion.Val(mSG2_TOTAL[4, 3]) + Conversion.Val(mSG2_TOTAL[5, 3]) + Conversion.Val(mSG2_TOTAL[6, 3]) + Conversion.Val(mSG2_TOTAL[7, 3])), "0.00");
			if (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)
			{
				mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3])), "0.00");
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgS_Click(object sender, EventArgs e)
	{
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsImageNo, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Design No and Try..", (MsgBoxStyle)0, (object)null);
			return;
		}
		((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
		((FileDialog)DlgOpen).Title = "Open Image File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
		{
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				PicImage.Image.Dispose();
				PicImage.Image = null;
				FileSystem.Kill(DC_Main.MsImagePath);
			}
			PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
			PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
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
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "00020", false) == 0)
		{
			if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
			{
				((Control)PanelAdd).Left = ((Control)tAcName).Left;
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

	private void TR_TOUR_ORD_KeyUp(object sender, KeyEventArgs e)
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

	private void mDelDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mDelDate).SelectionStart = 0;
		((TextBoxBase)mDelDate).SelectionLength = Strings.Len(mDelDate.Text);
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}
}
