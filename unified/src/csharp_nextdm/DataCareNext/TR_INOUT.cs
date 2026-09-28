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
public class TR_INOUT : Form
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
	[AccessedThroughProperty("tToLcCode")]
	private TextBox _tToLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tEmpName")]
	private TextBox _tEmpName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagVch")]
	private TextBox _tTagVch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagVchHelp")]
	private SimpleButton _btnTagVchHelp;

	private string UsUPdate;

	private string UsDelete;

	private string TagBook;

	private string LcStkTrfr;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string BookDataType;

	private string BranchDataType;

	private bool VchDelete;

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

	private const int cTagNo = 1;

	private const int cItmLot = 2;

	private const int cItCode = 3;

	private const int cCounter = 4;

	private const int cDesign = 5;

	private const int cStyle = 6;

	private const int cColor = 7;

	private const int cSize = 8;

	private const int cHmId = 9;

	private const int cSign = 10;

	private const int cBagWt = 11;

	private const int cPcs = 12;

	private const int cGrWt = 13;

	private const int cOthWt = 14;

	private const int cNetWt = 15;

	private const int cGhtPrc = 16;

	private const int cGhtWt = 17;

	private const int cTouch = 18;

	private const int cWestPrc = 19;

	private const int cFine = 20;

	private const int cTrFrItCode = 21;

	private const int cTrFrItName = 22;

	private const int cLbrCode = 23;

	private const int cLbrPrc = 24;

	private const int cLbrType = 25;

	private const int cLbrRate = 26;

	private const int cLbrAmt = 27;

	private const int cOthAmt = 28;

	private const int cTagCost = 29;

	private const int cMrp = 30;

	private const int cKrName = 31;

	private const int cKrOthWt = 32;

	private const int cKrNetWt = 33;

	private const int cKrGhatPrc = 34;

	private const int cKrGhatWt = 35;

	private const int cKrTouch = 36;

	private const int cKrWestPrc = 37;

	private const int cKrFine = 38;

	private const int cKrLRate = 39;

	private const int cKrLAmt = 40;

	private const int cKrOthAmt = 41;

	private const int cPrCost = 42;

	private const int cVchSrno = 43;

	private const int cItRate = 44;

	private const int cItAmt = 45;

	private const int cMargin = 46;

	private const int cImageTake = 47;

	private const int cTagSrNo = 48;

	private const int cOldSrNo = 49;

	private const int cRateType = 50;

	private const int cItType = 51;

	private const int cTagType = 52;

	private const int cPrCode = 53;

	private const int cItName = 54;

	private const int cEntryMod = 55;

	private const int cOldTagType = 56;

	private const int cOldPrCode = 57;

	private const int cOldGrWt = 58;

	private const int cOldNtWt = 59;

	private const int cOldGhatPrc = 60;

	private const int cOldGhatWt = 61;

	private const int cOldTouch = 62;

	private const int cOldWestPrc = 63;

	private const int cOldKrNetWt = 64;

	private const int cOldKrTouch = 65;

	private const int cOldKrWest = 66;

	private const int cOldKrGhatWt = 67;

	private const int cOldMargin = 68;

	private const int cItRemark = 69;

	private const int cHmId2 = 70;

	private const int cHmId3 = 71;

	private const int cHmId4 = 72;

	private const int cHmIdWt = 73;

	private const int cHmId2Wt = 74;

	private const int cHmId3Wt = 75;

	private const int cHmId4Wt = 76;

	private const int cJdtNet = 77;

	private const int cGhatWt = 78;

	private const int cKundan = 79;

	private const int cKndTch = 80;

	private const int cKndNwt = 81;

	private const int cWax = 82;

	private const int cKrWax = 83;

	private const int cEmpIsu = 84;

	private const int cDesignImgId = 85;

	private const int cOrdLcCode = 86;

	private const int cOrdYrCd = 87;

	private const int cOrdDbCd = 88;

	private const int cOrdNo = 89;

	private const int cOrdSrNo = 90;

	private const int cOrdAcCode = 91;

	private const int cNewVchSrNo = 92;

	private const int cDataType = 93;

	private const int cTagCostOld = 94;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1Pcs = 3;

	private const int c1GrWt = 4;

	private const int c1KrWt = 5;

	private const int c1ConPrc = 6;

	private const int c1RateType = 7;

	private const int c1ItRate = 8;

	private const int c1ItmAmt = 9;

	private const int c1LbrRate = 10;

	private const int c1LbrAmt = 11;

	private const int c1NetAmt = 12;

	private const int c1ConWt = 13;

	private const int c1KrConWt = 14;

	private const int c1ItType = 15;

	private const int c1RowSr = 16;

	private const int c1DmCode = 17;

	private const int c1DmName = 18;

	private const int c1DmColor = 19;

	private const int c1DmSize = 20;

	private const int c1DmOrigin = 21;

	private const int c1DmRemark = 22;

	private const int c1DmSfNo = 23;

	private const int c1KrActWt = 24;

	private const int c1KrActPrc = 25;

	private const int c1KrPrc = 26;

	private const int c1KrRate = 27;

	private const int c1KrAmt = 28;

	private const int c1PcsWt = 29;

	private const int c1oldKrWt = 30;

	private const int c1oldGrWt = 31;

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

	internal virtual TextBox tToLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tToLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tToLcCode_KeyDown);
			TextBox val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tToLcCode = value;
			val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tToLcName")]
	private virtual TextBox _tToLcName;

	internal virtual TextBox tToLcName
	{
		get
		{
			return _tToLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToLcName = value;
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

	internal virtual TextBox tEmpName
	{
		[CompilerGenerated]
		get
		{
			return _tEmpName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tEmpName_KeyDown);
			TextBox val2 = _tEmpName;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tEmpName = value;
			val2 = _tEmpName;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFrmLc")]
	private virtual TextBox _tFrmLc;

	internal virtual TextBox tFrmLc
	{
		get
		{
			return _tFrmLc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFrmLc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lFromLc")]
	private virtual Label _lFromLc;

	internal virtual Label lFromLc
	{
		get
		{
			return _lFromLc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lFromLc = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFromLcName")]
	private virtual TextBox _tFromLcName;

	internal virtual TextBox tFromLcName
	{
		get
		{
			return _tFromLcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFromLcName = value;
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
	[AccessedThroughProperty("tToVchNo")]
	private virtual TextBox _tToVchNo;

	internal virtual TextBox tToVchNo
	{
		get
		{
			return _tToVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToVchNo = value;
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
	[AccessedThroughProperty("tFromVchNo")]
	private virtual TextBox _tFromVchNo;

	internal virtual TextBox tFromVchNo
	{
		get
		{
			return _tFromVchNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFromVchNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tToBook")]
	private virtual TextBox _tToBook;

	internal virtual TextBox tToBook
	{
		get
		{
			return _tToBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tToBook = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tFrombook")]
	private virtual TextBox _tFrombook;

	internal virtual TextBox tFrombook
	{
		get
		{
			return _tFrombook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tFrombook = value;
		}
	}

	internal virtual TextBox tTagVch
	{
		[CompilerGenerated]
		get
		{
			return _tTagVch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tTagVch_KeyDown);
			TextBox val2 = _tTagVch;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tTagVch = value;
			val2 = _tTagVch;
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

	internal virtual SimpleButton btnTagVchHelp
	{
		[CompilerGenerated]
		get
		{
			return _btnTagVchHelp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagVchHelp_Click;
			SimpleButton val = _btnTagVchHelp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagVchHelp = value;
			val = _btnTagVchHelp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public TR_INOUT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_INOUT_Load;
		((Form)this).Deactivate += TR_INOUT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_INOUT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_INOUT_KeyDown);
		((Form)this).Activated += TR_INOUT_Activated;
		((Form)this).Closed += TR_INOUT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_INOUT_KeyUp);
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
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_04e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ea: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_0629: Unknown result type (might be due to invalid IL or missing references)
		//IL_0633: Expected O, but got Unknown
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Expected O, but got Unknown
		//IL_0767: Unknown result type (might be due to invalid IL or missing references)
		//IL_0771: Expected O, but got Unknown
		//IL_07d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07de: Expected O, but got Unknown
		//IL_0887: Unknown result type (might be due to invalid IL or missing references)
		//IL_0891: Expected O, but got Unknown
		//IL_08f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fe: Expected O, but got Unknown
		//IL_09a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b1: Expected O, but got Unknown
		//IL_0ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad8: Expected O, but got Unknown
		//IL_0be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bed: Expected O, but got Unknown
		//IL_0c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Expected O, but got Unknown
		//IL_0dec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eaa: Expected O, but got Unknown
		//IL_0fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fac: Expected O, but got Unknown
		//IL_10bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c7: Expected O, but got Unknown
		//IL_1144: Unknown result type (might be due to invalid IL or missing references)
		//IL_114e: Expected O, but got Unknown
		//IL_120f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1219: Expected O, but got Unknown
		//IL_12c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ca: Expected O, but got Unknown
		//IL_13ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d8: Expected O, but got Unknown
		//IL_1439: Unknown result type (might be due to invalid IL or missing references)
		//IL_1443: Expected O, but got Unknown
		//IL_154f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1559: Expected O, but got Unknown
		//IL_1631: Unknown result type (might be due to invalid IL or missing references)
		//IL_163b: Expected O, but got Unknown
		//IL_16d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e1: Expected O, but got Unknown
		//IL_181c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1826: Expected O, but got Unknown
		//IL_1871: Unknown result type (might be due to invalid IL or missing references)
		//IL_187b: Expected O, but got Unknown
		//IL_1905: Unknown result type (might be due to invalid IL or missing references)
		//IL_190f: Expected O, but got Unknown
		//IL_19a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19aa: Expected O, but got Unknown
		//IL_1a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8b: Expected O, but got Unknown
		//IL_1b2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b39: Expected O, but got Unknown
		//IL_1bb6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc0: Expected O, but got Unknown
		//IL_1c48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c52: Expected O, but got Unknown
		//IL_1d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d0d: Expected O, but got Unknown
		//IL_1dc1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcb: Expected O, but got Unknown
		//IL_1e69: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e73: Expected O, but got Unknown
		//IL_1efd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f07: Expected O, but got Unknown
		//IL_1fc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fcf: Expected O, but got Unknown
		//IL_204c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2056: Expected O, but got Unknown
		//IL_2114: Unknown result type (might be due to invalid IL or missing references)
		//IL_211e: Expected O, but got Unknown
		//IL_21a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_21af: Expected O, but got Unknown
		//IL_226d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2277: Expected O, but got Unknown
		//IL_2312: Unknown result type (might be due to invalid IL or missing references)
		//IL_231c: Expected O, but got Unknown
		//IL_23b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c1: Expected O, but got Unknown
		//IL_245c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2466: Expected O, but got Unknown
		//IL_24ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f7: Expected O, but got Unknown
		//IL_25d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_25df: Expected O, but got Unknown
		//IL_26b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_26c1: Expected O, but got Unknown
		//IL_275d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2767: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_INOUT));
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
		tToLcCode = new TextBox();
		tToLcName = new TextBox();
		Label1 = new Label();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		Label4 = new Label();
		tVchDesc = new TextBox();
		tFrmLc = new TextBox();
		lFromLc = new Label();
		tFromLcName = new TextBox();
		Label5 = new Label();
		tToVchNo = new TextBox();
		Label6 = new Label();
		tFromVchNo = new TextBox();
		tToBook = new TextBox();
		tFrombook = new TextBox();
		tTagVch = new TextBox();
		Label7 = new Label();
		btnTagVchHelp = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
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
		lblBook.Text = "Branch Inout";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(104, 74);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(21, 74);
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
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(104, 43);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(186, 43);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(186, 74);
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
		((Control)PnlBotam).TabIndex = 8;
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
		((Control)TEXT_ENTRY).Location = new Point(526, 192);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(963, 75);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(210, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(499, 427);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 5;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 363);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(973, 146);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(992, 362);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(178, 146);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(15, 339);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 103);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 235);
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
		((Control)BtnF1).Location = new Point(275, 43);
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
		((TextBoxBase)tToLcCode).BackColor = Color.White;
		((Control)tToLcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToLcCode).Location = new Point(394, 74);
		((TextBoxBase)tToLcCode).MaxLength = 2;
		((Control)tToLcCode).Name = "tToLcCode";
		((Control)tToLcCode).Size = new Size(50, 23);
		((Control)tToLcCode).TabIndex = 3;
		((Control)tToLcCode).Visible = false;
		((TextBoxBase)tToLcName).BackColor = Color.White;
		((Control)tToLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToLcName).Location = new Point(450, 74);
		((TextBoxBase)tToLcName).MaxLength = 8;
		((Control)tToLcName).Name = "tToLcName";
		((Control)tToLcName).Size = new Size(210, 23);
		((Control)tToLcName).TabIndex = 1158;
		((Control)tToLcName).Visible = false;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(326, 72);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(58, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Trfr Lc";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label1).Visible = false;
		((TextBoxBase)tHdVchNo).BackColor = Color.FromArgb(255, 224, 192);
		((TextBoxBase)tHdVchNo).BorderStyle = (BorderStyle)0;
		((Control)tHdVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((TextBoxBase)tHdVchNo).ForeColor = Color.Maroon;
		((Control)tHdVchNo).Location = new Point(8, 8);
		((TextBoxBase)tHdVchNo).MaxLength = 8;
		((Control)tHdVchNo).Name = "tHdVchNo";
		((TextBoxBase)tHdVchNo).ReadOnly = true;
		((Control)tHdVchNo).Size = new Size(56, 15);
		((Control)tHdVchNo).TabIndex = 9;
		((Control)tHdVchNo).Visible = false;
		((TextBoxBase)tEmpCode).BackColor = Color.White;
		((Control)tEmpCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpCode).Location = new Point(89, 534);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 6;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(152, 534);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(14, 536);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(376, 536);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(448, 519);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(373, 38);
		((Control)tVchDesc).TabIndex = 7;
		((TextBoxBase)tFrmLc).BackColor = Color.White;
		((Control)tFrmLc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFrmLc).Location = new Point(394, 43);
		((TextBoxBase)tFrmLc).MaxLength = 2;
		((Control)tFrmLc).Name = "tFrmLc";
		((Control)tFrmLc).Size = new Size(50, 23);
		((Control)tFrmLc).TabIndex = 2;
		((Control)tFrmLc).Visible = false;
		((Control)lFromLc).BackColor = Color.Transparent;
		((Control)lFromLc).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lFromLc).ForeColor = Color.Black;
		lFromLc.ImeMode = (ImeMode)0;
		((Control)lFromLc).Location = new Point(327, 44);
		((Control)lFromLc).Name = "lFromLc";
		((Control)lFromLc).Size = new Size(61, 20);
		((Control)lFromLc).TabIndex = 1165;
		lFromLc.Text = "From Lc";
		lFromLc.TextAlign = (ContentAlignment)16;
		((Control)lFromLc).Visible = false;
		((TextBoxBase)tFromLcName).BackColor = Color.White;
		((Control)tFromLcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFromLcName).Location = new Point(450, 43);
		((TextBoxBase)tFromLcName).MaxLength = 8;
		((Control)tFromLcName).Name = "tFromLcName";
		((Control)tFromLcName).Size = new Size(210, 23);
		((Control)tFromLcName).TabIndex = 1166;
		((Control)tFromLcName).Visible = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(942, 45);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(80, 20);
		((Control)Label5).TabIndex = 1168;
		Label5.Text = "TrFrVchNo";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label5).Visible = false;
		((TextBoxBase)tToVchNo).BackColor = Color.White;
		((Control)tToVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToVchNo).Location = new Point(1028, 44);
		((TextBoxBase)tToVchNo).MaxLength = 8;
		((Control)tToVchNo).Name = "tToVchNo";
		((TextBoxBase)tToVchNo).ReadOnly = true;
		((Control)tToVchNo).Size = new Size(76, 23);
		((Control)tToVchNo).TabIndex = 1167;
		((Control)tToVchNo).Visible = false;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(689, 44);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(92, 20);
		((Control)Label6).TabIndex = 1169;
		Label6.Text = "From VchNo";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label6).Visible = false;
		((TextBoxBase)tFromVchNo).BackColor = Color.White;
		((Control)tFromVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFromVchNo).Location = new Point(787, 43);
		((TextBoxBase)tFromVchNo).MaxLength = 8;
		((Control)tFromVchNo).Name = "tFromVchNo";
		((TextBoxBase)tFromVchNo).ReadOnly = true;
		((Control)tFromVchNo).Size = new Size(76, 23);
		((Control)tFromVchNo).TabIndex = 1170;
		((Control)tFromVchNo).Visible = false;
		((TextBoxBase)tToBook).BackColor = Color.White;
		((Control)tToBook).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToBook).Location = new Point(1110, 44);
		((TextBoxBase)tToBook).MaxLength = 3;
		((Control)tToBook).Name = "tToBook";
		((TextBoxBase)tToBook).ReadOnly = true;
		((Control)tToBook).Size = new Size(60, 23);
		((Control)tToBook).TabIndex = 1171;
		((Control)tToBook).Visible = false;
		((TextBoxBase)tFrombook).BackColor = Color.White;
		((Control)tFrombook).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tFrombook).Location = new Point(869, 43);
		((TextBoxBase)tFrombook).MaxLength = 3;
		((Control)tFrombook).Name = "tFrombook";
		((TextBoxBase)tFrombook).ReadOnly = true;
		((Control)tFrombook).Size = new Size(60, 23);
		((Control)tFrombook).TabIndex = 1172;
		((Control)tFrombook).Visible = false;
		((TextBoxBase)tTagVch).BackColor = Color.White;
		((Control)tTagVch).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tTagVch).Location = new Point(787, 74);
		((TextBoxBase)tTagVch).MaxLength = 8;
		((Control)tTagVch).Name = "tTagVch";
		((TextBoxBase)tTagVch).ReadOnly = true;
		((Control)tTagVch).Size = new Size(76, 23);
		((Control)tTagVch).TabIndex = 1174;
		((Control)tTagVch).Visible = false;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(672, 75);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(110, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Import Tag Vch";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label7).Visible = false;
		((BaseStyleControl)btnTagVchHelp).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnTagVchHelp).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnTagVchHelp).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagVchHelp).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnTagVchHelp).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnTagVchHelp).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnTagVchHelp).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnTagVchHelp).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagVchHelp).Appearance.Options.UseForeColor = true;
		((BaseButton)btnTagVchHelp).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnTagVchHelp).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnTagVchHelp).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTagVchHelp).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnTagVchHelp).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnTagVchHelp).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnTagVchHelp).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnTagVchHelp).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnTagVchHelp).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnTagVchHelp).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnTagVchHelp).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnTagVchHelp).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnTagVchHelp).AppearancePressed.Options.UseFont = true;
		((Control)btnTagVchHelp).Location = new Point(869, 74);
		((BaseControl)btnTagVchHelp).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagVchHelp).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagVchHelp).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagVchHelp).Name = "btnTagVchHelp";
		((Control)btnTagVchHelp).Size = new Size(35, 23);
		((Control)btnTagVchHelp).TabIndex = 1175;
		btnTagVchHelp.Text = "T";
		((BaseControl)btnTagVchHelp).ToolTip = "Tag Voucher Help";
		((Control)btnTagVchHelp).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnTagVchHelp);
		((Control)this).Controls.Add((Control)(object)tTagVch);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tFrombook);
		((Control)this).Controls.Add((Control)(object)tToBook);
		((Control)this).Controls.Add((Control)(object)tFromVchNo);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tToVchNo);
		((Control)this).Controls.Add((Control)(object)tFromLcName);
		((Control)this).Controls.Add((Control)(object)lFromLc);
		((Control)this).Controls.Add((Control)(object)tFrmLc);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)tToLcCode);
		((Control)this).Controls.Add((Control)(object)tToLcName);
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
		((Control)this).Name = "TR_INOUT";
		((Form)this).Text = "Branch Inout";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_IDTL_CLEAR()
	{
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		mSG_IDTL.Clear();
		mSG_IDTL.Cols = 32;
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
			mSG_IDTL[3] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[3] = 7;
			mSG_IDTL[0, 3] = "Pcs";
			mSG_IDTL[5] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[5] = 7;
			mSG_IDTL[0, 5] = "KrWt";
			mSG_IDTL[4] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[4] = 7;
			mSG_IDTL[0, 4] = "Weight";
			mSG_IDTL[6] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[6] = 7;
			mSG_IDTL[0, 6] = "Con%";
			mSG_IDTL[7] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[7] = 3;
			mSG_IDTL[0, 7] = "P/W";
			mSG_IDTL[8] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[8] = 7;
			mSG_IDTL[0, 8] = "Rate";
			mSG_IDTL[9] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[9] = 7;
			mSG_IDTL[0, 9] = "ItAmt";
			mSG_IDTL[10] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "LbrRate";
			mSG_IDTL[11] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[11] = 7;
			mSG_IDTL[0, 11] = "LbrAmt";
			mSG_IDTL[12] = (int)Math.Round(1050.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "NetAmt";
			mSG_IDTL[13] = 0;
			mSG_IDTL[0, 13] = "ConWt";
			mSG_IDTL[14] = 0;
			mSG_IDTL[0, 14] = "KrConWt";
			mSG_IDTL[15] = 0;
			mSG_IDTL[0, 15] = "ItType";
			mSG_IDTL[16] = 0;
			mSG_IDTL[0, 16] = "RowSrNo";
			mSG_IDTL[17] = 0;
			mSG_IDTL[18] = 0;
			mSG_IDTL[19] = 0;
			mSG_IDTL[20] = 0;
			mSG_IDTL[21] = 0;
			mSG_IDTL[22] = 0;
			mSG_IDTL[23] = 0;
			mSG_IDTL[24] = 0;
			mSG_IDTL[25] = 0;
			mSG_IDTL[26] = 0;
			mSG_IDTL[27] = 0;
			mSG_IDTL[28] = 0;
			mSG_IDTL[29] = 0;
			mSG_IDTL[30] = 0;
			mSG_IDTL[31] = 0;
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
		mSG_IDTL[mSG_IDTL.Row, 16] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 49]));
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
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 16])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
				if (mSG_IDTL.Col < 12)
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
									mSG_IDTL[mSG_IDTL.Row, 15] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
							return;
						}
						mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG_IDTL[mSG_IDTL.Row, 15] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						break;
					case 12:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
				case 2:
					((TextBoxBase)TEXT_IDTL).MaxLength = 50;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 6:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.000");
					break;
				case 8:
				case 9:
				case 10:
				case 11:
				case 12:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 4:
				case 5:
				case 13:
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
			case 7:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 3:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 6:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.000");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 4:
			case 5:
			case 13:
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
		if ((Conversion.Val(mSG_IDTL[CRow, 5]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 4]) == 0.0))
		{
			mSG_IDTL[CRow, 4] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 5]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 4]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 5]) == 0.0))
		{
			mSG_IDTL[CRow, 5] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 4]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 4]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 6]) != 0.0))
		{
			mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 4]) * Conversion.Val(mSG_IDTL[CRow, 6])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 13] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 5]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 6]) != 0.0))
		{
			mSG_IDTL[CRow, 14] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 5]) * Conversion.Val(mSG_IDTL[CRow, 6])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 14] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 7], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 4]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 3]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0))
			{
				mSG_IDTL[CRow, 9] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 3])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 4]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0))
			{
				mSG_IDTL[CRow, 9] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 4])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 7], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 8])))) != 0)
		{
			mSG_IDTL[CRow, 9] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 3])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0)
		{
			mSG_IDTL[CRow, 9] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 4])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0)
		{
			mSG_IDTL[CRow, 11] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 10]) * Conversion.Val(mSG_IDTL[CRow, 3])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 9]) + Conversion.Val(mSG_IDTL[CRow, 11]) != 0.0)
		{
			mSG_IDTL[CRow, 12] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 9]) + Conversion.Val(mSG_IDTL[CRow, 11])), "0.00");
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
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 13]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 14]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 12]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 14] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 15] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 13]) - Conversion.Val(MSG[MSG.Row, 14])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 32] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 33] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 13]) - Conversion.Val(MSG[MSG.Row, 32])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 28] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 41] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 15] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 13]) - num2), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num6 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num6; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])) == Conversion.Val(mSG_IDTL[CRow, 16])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
		mSG.Cols = 95;
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
			mSG[3] = (int)Math.Round(1000.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItCode";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			if (Operators.CompareString(DC_Main.MsItmWitLotStk, "Y", false) == 0)
			{
				mSG[2] = (int)Math.Round(1000.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "ItmLot";
			}
			else
			{
				mSG[2] = 0;
				mSG[2] = 0;
				mSG[0, 2] = "ItmLot";
			}
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
			mSG[9] = (int)Math.Round(900.0 * ColCon);
			mSG[9] = 0;
			mSG[0, 9] = "HmId";
			mSG[7] = (int)Math.Round(1000.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "Color";
			mSG[8] = (int)Math.Round(800.0 * ColCon);
			mSG[8] = 0;
			mSG[0, 8] = "Size";
			mSG[11] = (int)Math.Round(800.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "BagWt";
			mSG[12] = (int)Math.Round(700.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Pcs";
			mSG[13] = (int)Math.Round(1000.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "GrWt";
			mSG[14] = (int)Math.Round(900.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "LsWt";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "NetWt";
			mSG[32] = (int)Math.Round(0.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "KrOthWt";
			mSG[33] = (int)Math.Round(0.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "KrNwt";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrGht%";
			mSG[35] = (int)Math.Round(0.0 * ColCon);
			mSG[35] = 7;
			mSG[0, 35] = "KrGht";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrTouch";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrWst%";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "KrFine";
			mSG[16] = (int)Math.Round(750.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "Ght%";
			mSG[17] = (int)Math.Round(850.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "GhtWt";
			mSG[18] = (int)Math.Round(850.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "Touch";
			mSG[19] = (int)Math.Round(850.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "West%";
			mSG[20] = (int)Math.Round(1000.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Fine";
			mSG[10] = 0;
			mSG[10] = 3;
			mSG[0, 10] = "Sign";
			mSG[26] = (int)Math.Round(900.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "LbrRate";
			mSG[27] = (int)Math.Round(950.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "LbrAmt";
			mSG[28] = (int)Math.Round(1000.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "OthAmt";
			mSG[21] = 0;
			mSG[21] = 3;
			mSG[0, 21] = "TrfrItm";
			mSG[22] = 0;
			mSG[22] = 3;
			mSG[0, 22] = "TrfrItmName";
			mSG[30] = (int)Math.Round(900.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Mrp";
			mSG[31] = (int)Math.Round(900.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "KrCode";
			mSG[23] = (int)Math.Round(800.0 * ColCon);
			mSG[23] = 3;
			mSG[0, 23] = "LCode";
			mSG[24] = (int)Math.Round(800.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "Lbr%";
			mSG[25] = (int)Math.Round(0.0 * ColCon);
			mSG[25] = 3;
			mSG[0, 25] = "LType";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "KrLRate";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrLAmt";
			mSG[41] = (int)Math.Round(0.0 * ColCon);
			mSG[41] = 7;
			mSG[0, 41] = "KrOthAmt";
			mSG[42] = (int)Math.Round(0.0 * ColCon);
			mSG[42] = 7;
			mSG[0, 42] = "PrCost";
			mSG[44] = (int)Math.Round(0.0 * ColCon);
			mSG[44] = 7;
			mSG[0, 44] = "ItRate";
			mSG[45] = (int)Math.Round(0.0 * ColCon);
			mSG[45] = 7;
			mSG[0, 45] = "ItAmt";
			mSG[29] = (int)Math.Round(900.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "TagCost";
			mSG[46] = (int)Math.Round(0.0 * ColCon);
			mSG[46] = 7;
			mSG[0, 46] = "Margin";
			mSG[47] = (int)Math.Round(0.0 * ColCon);
			mSG[47] = 3;
			mSG[0, 47] = "Image";
			mSG[48] = 0;
			mSG[49] = 0;
			mSG[50] = 0;
			mSG[51] = 0;
			mSG[52] = 0;
			mSG[53] = 0;
			mSG[43] = 0;
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
			mSG[85] = 0;
			mSG[86] = 0;
			mSG[87] = 0;
			mSG[88] = 0;
			mSG[89] = 0;
			mSG[90] = 0;
			mSG[91] = 0;
			mSG[92] = 0;
			mSG[93] = 0;
			mSG[94] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'TAG_CAN_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 31;
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
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.000");
					mSG_TOT[0, 45] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 45]) + Conversion.Val(MSG[DC_Main.M, 45]))), "0.00");
					mSG_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 27]) + Conversion.Val(MSG[DC_Main.M, 27]))), "0.00");
					mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
					mSG_TOT[0, 32] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 32]) + Conversion.Val(MSG[DC_Main.M, 32]))), "0.000");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.000");
					mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[DC_Main.M, 35]))), "0.000");
					mSG_TOT[0, 38] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 38]) + Conversion.Val(MSG[DC_Main.M, 38]))), "0.000");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.00");
					mSG_TOT[0, 41] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 41]) + Conversion.Val(MSG[DC_Main.M, 41]))), "0.00");
					mSG_TOT[0, 42] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 42]) + Conversion.Val(MSG[DC_Main.M, 42]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 28]) + Conversion.Val(MSG_TOT[0, 27]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 25] = DC_Main.MsLbrType;
		checked
		{
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 49] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 49] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 49]) + 1.0);
			}
			mSG[mSG.Row, 55] = "A";
			mSG[mSG.Row, 47] = "N";
			mSG[mSG.Row, 84] = "N";
			mSG[mSG.Row, 85] = "N";
			mSG[mSG.Row, 93] = BookDataType;
			if (Operators.CompareString(FormMainBook, "TAG TRFR", false) == 0 && mSG.Row > 1)
			{
				mSG[mSG.Row, 21] = mSG[mSG.Row - 1, 21];
				mSG[mSG.Row, 22] = mSG[mSG.Row - 1, 22];
			}
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
				if (MsgOldRow != MSG.Row)
				{
					MsgOldRow = 0;
				}
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
				if ((mSG.Col != 4) & (mSG.Col != 5) & (mSG.Col != 8))
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
			case 3:
			case 21:
			case 31:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 22:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 4;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 5:
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
			case 25:
			case 47:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 19:
			case 24:
			case 26:
			case 27:
			case 30:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				if (Operators.CompareString(mSG[mSG.Row, 23], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 12:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 16:
			case 18:
			case 36:
			case 37:
			case 46:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 28:
			case 29:
			case 39:
			case 40:
			case 41:
			case 42:
			case 44:
			case 45:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 11:
			case 13:
			case 14:
			case 15:
			case 17:
			case 20:
			case 32:
			case 33:
			case 34:
			case 35:
			case 38:
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
			case 3:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 2:
			case 4:
			case 5:
			case 6:
			case 8:
			case 10:
			case 21:
			case 22:
			case 23:
			case 25:
			case 31:
			case 47:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 12:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 16:
			case 18:
			case 19:
			case 24:
			case 36:
			case 37:
			case 46:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 26:
			case 27:
			case 28:
			case 29:
			case 30:
			case 39:
			case 40:
			case 41:
			case 42:
			case 44:
			case 45:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 14:
			case 32:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 11:
			case 13:
			case 15:
			case 17:
			case 20:
			case 33:
			case 34:
			case 35:
			case 38:
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
				case 4977:
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
							goto IL_0110;
						case 8:
						case 9:
						case 10:
							goto IL_015b;
						case 11:
							goto IL_01a7;
						case 12:
						case 13:
							goto IL_01f1;
						case 14:
							goto IL_0228;
						case 15:
							goto IL_025c;
						case 16:
							goto IL_02bc;
						case 18:
							goto IL_033a;
						case 17:
						case 19:
						case 20:
						case 21:
							goto IL_0371;
						case 22:
							goto IL_03a8;
						case 23:
							goto IL_03dc;
						case 24:
							goto IL_043c;
						case 25:
						case 26:
						case 27:
							goto IL_04ba;
						case 28:
							goto IL_04f1;
						case 29:
							goto IL_0525;
						case 30:
							goto IL_0585;
						case 31:
						case 32:
						case 33:
							goto IL_0603;
						case 34:
							goto IL_063e;
						case 35:
						case 36:
							goto IL_0688;
						case 37:
							goto IL_06e5;
						case 38:
						case 39:
							goto IL_0761;
						case 40:
							goto IL_0788;
						case 41:
							goto IL_07bc;
						case 42:
							goto IL_07f0;
						case 43:
							goto IL_0824;
						case 45:
							goto IL_085f;
						case 46:
							goto IL_08ab;
						case 47:
						case 48:
							goto IL_08f5;
						case 49:
							goto IL_092c;
						case 50:
							goto IL_0960;
						case 51:
							goto IL_09c0;
						case 53:
							goto IL_0a3e;
						case 52:
						case 54:
						case 55:
						case 56:
							goto IL_0a75;
						case 57:
							goto IL_0aac;
						case 58:
							goto IL_0ae0;
						case 59:
							goto IL_0b40;
						case 60:
						case 61:
						case 62:
							goto IL_0bbe;
						case 63:
							goto IL_0bf5;
						case 64:
							goto IL_0c29;
						case 65:
							goto IL_0c89;
						case 66:
						case 67:
						case 68:
							goto IL_0d07;
						case 69:
							goto IL_0d42;
						case 44:
						case 70:
						case 71:
						case 72:
							goto IL_0d8d;
						case 73:
							goto IL_0ddd;
						case 75:
							goto IL_0e26;
						case 77:
							goto IL_0e7a;
						case 79:
							goto IL_0ed8;
						case 81:
							goto IL_0f33;
						case 74:
						case 76:
						case 78:
						case 80:
						case 82:
						case 83:
						case 84:
							goto IL_0f86;
						case 85:
							goto IL_0fb4;
						case 87:
							goto IL_0ffd;
						case 89:
							goto IL_1051;
						case 91:
							goto IL_10b9;
						case 93:
							goto IL_1128;
						case 86:
						case 88:
						case 90:
						case 92:
						case 94:
						case 95:
						case 96:
							goto IL_117b;
						case 97:
							goto IL_11c4;
						case 98:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 99:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0ffd:
					num2 = 87;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 26]), 0), "0.00");
					goto IL_117b;
					IL_117b:
					num2 = 96;
					val[val.Row, 42] = Strings.Format((object)(Conversion.Val(val[val.Row, 40]) + Conversion.Val(val[val.Row, 41])), "0.0");
					goto IL_11c4;
					IL_1051:
					num2 = 89;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * Conversion.Val(val[val.Row, 26]), 0), "0.00");
					goto IL_117b;
					IL_11c4:
					val = null;
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 58]))
					{
						goto IL_004b;
					}
					goto IL_015b;
					IL_004b:
					num2 = 4;
					val[val.Row, 58] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					if ((Conversion.Val(val[val.Row, 32]) != 0.0) & (Conversion.Val(val[val.Row, 33]) != 0.0))
					{
						goto IL_0110;
					}
					goto IL_015b;
					IL_0110:
					num2 = 7;
					val[val.Row, 33] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) - Conversion.Val(val[val.Row, 32])), "0.000");
					goto IL_015b;
					IL_015b:
					num2 = 10;
					if ((Conversion.Val(val[val.Row, 14]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_01a7;
					}
					goto IL_01f1;
					IL_01a7:
					num2 = 11;
					val[val.Row, 15] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) - Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_01f1;
					IL_01f1:
					num2 = 13;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 59]))
					{
						goto IL_0228;
					}
					goto IL_0371;
					IL_0228:
					num2 = 14;
					val[val.Row, 59] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_025c;
					IL_025c:
					num2 = 15;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_02bc;
					}
					goto IL_033a;
					IL_02bc:
					num2 = 16;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0371;
					IL_033a:
					num2 = 18;
					val[val.Row, 20] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_0371;
					IL_0371:
					num2 = 21;
					if (Conversion.Val(val[val.Row, 18]) != Conversion.Val(val[val.Row, 62]))
					{
						goto IL_03a8;
					}
					goto IL_04ba;
					IL_03a8:
					num2 = 22;
					val[val.Row, 62] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_03dc;
					IL_03dc:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_043c;
					}
					goto IL_04ba;
					IL_043c:
					num2 = 24;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_04ba;
					IL_04ba:
					num2 = 27;
					if (Conversion.Val(val[val.Row, 19]) != Conversion.Val(val[val.Row, 63]))
					{
						goto IL_04f1;
					}
					goto IL_0603;
					IL_04f1:
					num2 = 28;
					val[val.Row, 63] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_0525;
					IL_0525:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_0585;
					}
					goto IL_0603;
					IL_0585:
					num2 = 30;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0603;
					IL_0603:
					num2 = 33;
					if (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) == 0.0)
					{
						goto IL_063e;
					}
					goto IL_0688;
					IL_063e:
					num2 = 34;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])), "0.000");
					goto IL_0688;
					IL_0688:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 20]) == 0.0) & (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19]) != 0.0))
					{
						goto IL_06e5;
					}
					goto IL_0761;
					IL_06e5:
					num2 = 37;
					val[val.Row, 20] = Strings.Format((object)((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])) / 100.0), "0.000");
					goto IL_0761;
					IL_0761:
					num2 = 39;
					if (Operators.CompareString(val[val.Row, 1], "", false) == 0)
					{
						goto IL_0788;
					}
					goto IL_085f;
					IL_0788:
					num2 = 40;
					val[val.Row, 33] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_07bc;
					IL_07bc:
					num2 = 41;
					val[val.Row, 36] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.00");
					goto IL_07f0;
					IL_07f0:
					num2 = 42;
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 19]), "0.00");
					goto IL_0824;
					IL_0824:
					num2 = 43;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.000");
					goto IL_0d8d;
					IL_085f:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 32]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_08ab;
					}
					goto IL_08f5;
					IL_08ab:
					num2 = 46;
					val[val.Row, 33] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) - Conversion.Val(val[val.Row, 32])), "0.000");
					goto IL_08f5;
					IL_08f5:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 33]) != Conversion.Val(val[val.Row, 64]))
					{
						goto IL_092c;
					}
					goto IL_0a75;
					IL_092c:
					num2 = 49;
					val[val.Row, 64] = Strings.Format((object)Conversion.Val(val[val.Row, 33]), "0.000");
					goto IL_0960;
					IL_0960:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) != 0.0) & (Conversion.Val(val[val.Row, 33]) != 0.0))
					{
						goto IL_09c0;
					}
					goto IL_0a3e;
					IL_09c0:
					num2 = 51;
					val[val.Row, 38] = Strings.Format((object)((Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 35])) * (Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37])) / 100.0), "0.000");
					goto IL_0a75;
					IL_0a3e:
					num2 = 53;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 33]), "0.000");
					goto IL_0a75;
					IL_0a75:
					num2 = 56;
					if (Conversion.Val(val[val.Row, 36]) != Conversion.Val(val[val.Row, 65]))
					{
						goto IL_0aac;
					}
					goto IL_0bbe;
					IL_0aac:
					num2 = 57;
					val[val.Row, 65] = Strings.Format((object)Conversion.Val(val[val.Row, 36]), "0.00");
					goto IL_0ae0;
					IL_0ae0:
					num2 = 58;
					if ((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) != 0.0) & (Conversion.Val(val[val.Row, 33]) != 0.0))
					{
						goto IL_0b40;
					}
					goto IL_0bbe;
					IL_0b40:
					num2 = 59;
					val[val.Row, 38] = Strings.Format((object)((Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 35])) * (Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37])) / 100.0), "0.000");
					goto IL_0bbe;
					IL_0bbe:
					num2 = 62;
					if (Conversion.Val(val[val.Row, 37]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_0bf5;
					}
					goto IL_0d07;
					IL_0bf5:
					num2 = 63;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.00");
					goto IL_0c29;
					IL_0c29:
					num2 = 64;
					if ((Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) != 0.0) & (Conversion.Val(val[val.Row, 33]) != 0.0))
					{
						goto IL_0c89;
					}
					goto IL_0d07;
					IL_0c89:
					num2 = 65;
					val[val.Row, 38] = Strings.Format((object)((Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 35])) * (Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37])) / 100.0), "0.000");
					goto IL_0d07;
					IL_0d07:
					num2 = 68;
					if (Conversion.Val(val[val.Row, 36]) + Conversion.Val(val[val.Row, 37]) == 0.0)
					{
						goto IL_0d42;
					}
					goto IL_0d8d;
					IL_0d42:
					num2 = 69;
					val[val.Row, 38] = Strings.Format((object)(Conversion.Val(val[val.Row, 33]) + Conversion.Val(val[val.Row, 35])), "0.000");
					goto IL_0d8d;
					IL_0d8d:
					num2 = 72;
					if ((Conversion.Val(val[val.Row, 44]) != 0.0) & (Conversion.Val(val[val.Row, 20]) != 0.0))
					{
						goto IL_0ddd;
					}
					goto IL_0f86;
					IL_0ddd:
					num2 = 73;
					switch (val[val.Row, 50])
					{
					case "P":
						break;
					case "1":
						goto IL_0e7a;
					case "K":
						goto IL_0ed8;
					default:
						goto IL_0f33;
					}
					goto IL_0e26;
					IL_0f33:
					num2 = 81;
					val[val.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 20]) * Conversion.Val(val[val.Row, 44]), 0), "0.00");
					goto IL_0f86;
					IL_0ed8:
					num2 = 79;
					val[val.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 20]) * (Conversion.Val(val[val.Row, 44]) / 1000.0), 0), "0.00");
					goto IL_0f86;
					IL_0e7a:
					num2 = 77;
					val[val.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 20]) * (Conversion.Val(val[val.Row, 44]) / 10.0), 0), "0.00");
					goto IL_0f86;
					IL_0e26:
					num2 = 75;
					val[val.Row, 45] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 44]), 0), "0.00");
					goto IL_0f86;
					IL_0f86:
					num2 = 84;
					if (Conversion.Val(val[val.Row, 26]) != 0.0)
					{
						goto IL_0fb4;
					}
					goto IL_117b;
					IL_0fb4:
					num2 = 85;
					switch (val[val.Row, 25])
					{
					case "P":
						break;
					case "N":
						goto IL_1051;
					case "K":
						goto IL_10b9;
					default:
						goto IL_1128;
					}
					goto IL_0ffd;
					IL_1128:
					num2 = 93;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 26]), 0), "0.00");
					goto IL_117b;
					IL_10b9:
					num2 = 91;
					val[val.Row, 27] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 17])) * (Conversion.Val(val[val.Row, 26]) / 1000.0), 0), "0.00");
					goto IL_117b;
					end_IL_0001_2:
					break;
				}
				num2 = 98;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 4977;
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
		//IL_023f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0242: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_065c: Unknown result type (might be due to invalid IL or missing references)
		//IL_065f: Invalid comparison between Unknown and I4
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_0673: Invalid comparison between Unknown and I4
		//IL_0685: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Invalid comparison between Unknown and I4
		//IL_06d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Invalid comparison between Unknown and I4
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0755: Unknown result type (might be due to invalid IL or missing references)
		//IL_0758: Invalid comparison between Unknown and I4
		//IL_07b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Invalid comparison between Unknown and I4
		//IL_0812: Unknown result type (might be due to invalid IL or missing references)
		//IL_0815: Invalid comparison between Unknown and I4
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_307c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3660: Unknown result type (might be due to invalid IL or missing references)
		//IL_38cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_3196: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_37df: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ad1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b22: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e39: Unknown result type (might be due to invalid IL or missing references)
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
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 49]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][16])) == Conversion.Val(mSG[mSG.Row, 49]))
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
							mSG[mSG.Row, 49] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 49] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 49]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if ((mSG.Col == 15) & (Operators.CompareString(DC_Main.MsSoftType, "E", false) == 0))
			{
				DC_Main.RsQry = ("SELECT A.IT_CODE,A.LBR_CODE,B.LBR_CATG,B.LBR_VAL FROM ITM_WT_MAST AS A LEFT JOIN LBR_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.LBR_CODE = B.LBR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_CODE = '" + mSG[mSG.Row, 3] + "' AND A.LBR_CODE <> '' AND A.FROM_WT <= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 13])) + " AND A.TO_WT >= " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 13]))) ?? "";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					mSG[mSG.Row, 26] = "";
					mSG[mSG.Row, 27] = "";
					mSG[mSG.Row, 24] = "";
					mSG[mSG.Row, 16] = "";
					mSG[mSG.Row, 19] = "";
					mSG[mSG.Row, 30] = "";
					mSG[mSG.Row, 23] = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CODE"], (object)""));
					switch (Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["LBR_CATG"], (object)"")), 1, 2))
					{
					case "01":
						mSG[mSG.Row, 26] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "02":
						mSG[mSG.Row, 24] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "03":
						mSG[mSG.Row, 27] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "04":
						mSG[mSG.Row, 19] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "05":
						mSG[mSG.Row, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "06":
						mSG[mSG.Row, 25] = "K";
						mSG[mSG.Row, 26] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					case "07":
						mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["LBR_VAL"]), "0.00");
						break;
					}
					CommPassTotal();
				}
				else
				{
					Interaction.MsgBox((object)"No LabCode Found Please Update Itm Stock Limit Mast and Try..", (MsgBoxStyle)0, (object)null);
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
						CommPassTotal();
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
							CommPassTotal();
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
						if (Operators.CompareString(FormMainBook, "OUTWORD", false) != 0 || Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Conversion.Val(mSG[mSG.Row, 43]) == 0.0))
						{
							mSG[mSG.Row, 1] = "";
						}
						if (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) == 0)
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 43]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 43]))) ?? ""))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
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
									mSG[mSG.Row, 54] = DC_Main.ColValue[1];
									mSG[mSG.Row, 3] = DC_Main.ColValue[2];
									mSG[mSG.Row, 5] = DC_Main.ColValue[3];
									mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 15] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 43] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 43] = "";
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
						mSG[mSG.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								mSG[mSG.Row, 54] = DC_Main.ColValue[1];
								mSG[mSG.Row, 3] = DC_Main.ColValue[0];
								mSG[mSG.Row, 5] = DC_Main.ColValue[3];
								mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 15] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 43] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 43]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_STYLE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[mSG.Row, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 10] = "-";
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 12] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 23] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_CODE"], (object)""));
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.00");
							mSG[DC_Main.i, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_RATE"], (object)"")), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_LBR_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 41] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_OTH_AMT"], (object)"")), "0.00");
							mSG[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 94] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 46] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							mSG[DC_Main.i, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"")), "0");
							mSG[DC_Main.i, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[mSG.Row, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID2"], (object)""));
							mSG[mSG.Row, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID3"], (object)""));
							mSG[mSG.Row, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID4"], (object)""));
							mSG[mSG.Row, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID_WT"])), "0.000");
							mSG[mSG.Row, 74] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID2_WT"])), "0.000");
							mSG[mSG.Row, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID3_WT"])), "0.000");
							mSG[mSG.Row, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["HM_ID4_WT"])), "0.000");
							mSG[DC_Main.i, 85] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							mSG[DC_Main.i, 87] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
							mSG[DC_Main.i, 88] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
							mSG[DC_Main.i, 89] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
							mSG[DC_Main.i, 91] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC"], (object)""));
							mSG[DC_Main.i, 86] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_LC_CODE"], (object)""));
							mSG[DC_Main.i, 90] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
							mSG[DC_Main.i, 84] = "N";
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 43] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[16] = Conversion.Val(MSG[mSG.Row, 49]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[15] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							dr[17] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[18] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_COLOR"], (object)"");
							dr[20] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_REMARK"], (object)"");
							dr[23] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
							dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
							dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
							dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_RATE"])), "0.00");
							dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_AMT"])), "0.00");
							dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
							dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (Operators.CompareString(FormMainBook, "TAG TRFR", false) == 0)
						{
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 1] = TEXT_ENTRY.Text;
								mSG.Col = 21;
								MSG_EnterCell(MSG, new EventArgs());
								((Control)TEXT_ENTRY).Focus();
								return;
							}
						}
						else if (mSG.Row == mSG.Rows - 1)
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
						if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(mSG[mSG.Row, 2], TEXT_ENTRY.Text, false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = "SELECT ITM_LOT,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '" + mSG[mSG.Row, 2] + "' AND ITM_LOT <> '' AND TAG_NO = 'N' GROUP BY ITM_LOT HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) > 0";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.ITM_LOT As ItmLotL,A.IT_CODE as ItCodeL,B.IT_NAME As ItemNameL,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWtW  FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT <> '' AND TAG_NO = 'N' GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME ORDER BY A.ITM_LOT,B.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[5];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 125.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_ENTRY.Text = DC_Main.ColValue[0];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								if (Operators.CompareString(mSG[mSG.Row, 55], "A", false) == 0)
								{
									mSG[mSG.Row, 54] = DC_Main.ColValue[0];
								}
								mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0.000");
								mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0.000");
							}
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						AxMSFlexGrid obj = mSG;
						int row = mSG.Row;
						DataRow dataRow;
						object Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["GrWt"]);
						double num5 = DC_Main.Fnv(ref Value);
						dataRow["GrWt"] = RuntimeHelpers.GetObjectValue(Value);
						obj[row, 13] = Strings.Format((object)num5, "0.000");
						AxMSFlexGrid obj2 = mSG;
						int row2 = mSG.Row;
						Value = RuntimeHelpers.GetObjectValue((dataRow = DC_Main.Tbl.Rows[0])["GrWt"]);
						double num6 = DC_Main.Fnv(ref Value);
						dataRow["GrWt"] = RuntimeHelpers.GetObjectValue(Value);
						obj2[row2, 15] = Strings.Format((object)num6, "0.000");
						break;
					}
					case 3:
						if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
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
										mSG[mSG.Row, 3] = DC_Main.ColValue[1];
										mSG[mSG.Row, 54] = DC_Main.ColValue[0];
										mSG[mSG.Row, 53] = DC_Main.ColValue[3];
										mSG[mSG.Row, 51] = DC_Main.ColValue[4];
										mSG[mSG.Row, 52] = DC_Main.ColValue[4];
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							mSG[mSG.Row, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
							mSG[mSG.Row, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
							mSG[mSG.Row, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						else
						{
							Interaction.MsgBox((object)"You Cant Insert New Entry In Inword Voucher", (MsgBoxStyle)0, (object)null);
						}
						break;
					case 23:
					{
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						string text = mSG[mSG.Row, 23];
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
							mSG[mSG.Row, 26] = "";
							mSG[mSG.Row, 27] = "";
							mSG[mSG.Row, 24] = "";
							mSG[mSG.Row, 16] = "";
							mSG[mSG.Row, 19] = "";
							mSG[mSG.Row, 30] = "";
						}
						text2 = Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CATG"], (object)"")), 1, 2);
						mSG[mSG.Row, 23] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LBR_CODE"], (object)""));
						switch (text2)
						{
						case "01":
							mSG[mSG.Row, 26] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "02":
							mSG[mSG.Row, 24] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "03":
							mSG[mSG.Row, 27] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "04":
							mSG[mSG.Row, 19] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "05":
							mSG[mSG.Row, 16] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "06":
							mSG[mSG.Row, 25] = "K";
							mSG[mSG.Row, 26] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						case "07":
							mSG[mSG.Row, 30] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_VAL"]), "0.00");
							break;
						}
						CommPassTotal();
						break;
					}
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
					case 10:
						if ((Operators.CompareString(FormMainBook, "STOCK ADJUST", false) == 0) & (Operators.CompareString(TEXT_ENTRY.Text, "+", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, "-", false) != 0))
						{
							Interaction.MsgBox((object)"Please Insert Item Sign + or - then Try", (MsgBoxStyle)0, (object)null);
							return;
						}
						break;
					case 13:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 21:
						if (Operators.CompareString(FormMainBook, "TAG TRFR", false) != 0)
						{
							break;
						}
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
									mSG[mSG.Row, 21] = DC_Main.ColValue[1];
									mSG[mSG.Row, 22] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
						}
						else
						{
							mSG[mSG.Row, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 21] = TEXT_ENTRY.Text;
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
						}
						return;
					case 31:
						if (Operators.CompareString(LcStkTrfr, "Y", false) == 0)
						{
							Interaction.MsgBox((object)"This Voucher Stock Recieved In Transfer Branch... You Cant Add New Tag..Please Creat New Voucher ", (MsgBoxStyle)0, (object)null);
						}
						else if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 31] = TEXT_ENTRY.Text;
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

	private void TR_INOUT_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0c46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c55: Expected O, but got Unknown
		//IL_0c7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c89: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd7: Expected O, but got Unknown
		//IL_0cf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d00: Expected O, but got Unknown
		//IL_0d1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d29: Expected O, but got Unknown
		//IL_0d51: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d58: Expected O, but got Unknown
		//IL_0df4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e03: Expected O, but got Unknown
		//IL_0e8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9a: Expected O, but got Unknown
		//IL_0f33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f38: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f3e: Expected O, but got Unknown
		//IL_0fc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd7: Expected O, but got Unknown
		//IL_0ffc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1001: Unknown result type (might be due to invalid IL or missing references)
		//IL_100b: Expected O, but got Unknown
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
			((Control)MSG_IDTL).Top = ((Control)MSG_TOT).Bottom + 10;
			((Control)PicImage).Height = ((Control)MSG_IDTL).Height;
			((Control)PicImage).Top = ((Control)MSG_IDTL).Top;
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj20 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj21 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj23 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj24 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj25 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG_IDTL4 = MSG_IDTL;
				object? obj26 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG_IDTL5 = MSG_IDTL;
				object? obj27 = colorConverter.ConvertFromString("174, 184, 194");
				mSG_IDTL5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG_IDTL6 = MSG_IDTL;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				mSG_IDTL6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj29 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj30 = lblBook;
				object? obj31 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj30).ForeColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj32 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj33 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj34 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj35 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj38 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG_IDTL7 = MSG_IDTL;
				object? obj39 = colorConverter.ConvertFromString("ControlLightLight");
				mSG_IDTL7.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG_IDTL8 = MSG_IDTL;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				mSG_IDTL8.BackColorBkg = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG_IDTL9 = MSG_IDTL;
				object? obj41 = colorConverter.ConvertFromString("Cornsilk");
				mSG_IDTL9.BackColorFixed = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj42 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
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
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "lblBook", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "TEXT_IDTL", false) != 0)))
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
						if (Operators.ConditionalCompareObjectNotEqual(NewLateBinding.LateGet(objectValue2, (Type)null, "Name", new object[0], (string[])null, (Type[])null, (bool[])null), (object)"chkWapp", false))
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
			if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
			{
				((Control)Label1).Visible = true;
				((Control)tToLcCode).Visible = true;
				((Control)tToLcName).Visible = true;
				((Control)Label5).Visible = true;
				((Control)tToVchNo).Visible = true;
				((TextBoxBase)tToVchNo).ReadOnly = true;
				((Control)tToBook).Visible = true;
				((TextBoxBase)tToBook).ReadOnly = true;
				((Control)Label7).Visible = true;
				((Control)tTagVch).Visible = true;
				((Control)btnTagVchHelp).Visible = true;
			}
			if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
			{
				((Control)lFromLc).Visible = true;
				((Control)tFrmLc).Visible = true;
				((TextBoxBase)tFrmLc).ReadOnly = true;
				((Control)tFromLcName).Visible = true;
				((TextBoxBase)tFromLcName).ReadOnly = true;
				((Control)Label6).Visible = true;
				((Control)tFromVchNo).Visible = true;
				((TextBoxBase)tFromVchNo).ReadOnly = true;
				((Control)tFrombook).Visible = true;
				((TextBoxBase)tFrombook).ReadOnly = true;
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
		lblItem.Text = "";
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		TagBook = "";
		OldValTot = 0.0;
		NewValTot = 0.0;
		UsUPdate = "N";
		UsDelete = "N";
		VchDelete = false;
		LcStkTrfr = "N";
		tFrmLc.Text = DC_Main.MLc_code;
		tFromLcName.Text = DC_Main.MLc_Name;
		((TextBoxBase)tToLcCode).ReadOnly = false;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
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
			DC_Main.RsQry = "SELECT DATA_TYPE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '058'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				BookDataType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DATA_TYPE"], (object)""));
			}
			else
			{
				BookDataType = "A";
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tToLcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_LC_CODE"], (object)""));
				tToBook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_CO_BOOK"], (object)""));
				tToVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_VCH_NO"], (object)""));
				tFrmLc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_LC_CODE"], (object)""));
				tFrombook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_CO_BOOK"], (object)""));
				tFromVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_VCH_NO"], (object)""));
				DC_Main.RsQry = "SELECT LC_NAME FROM LOCT_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT LC_NAME FROM LOCT_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + tFrmLc.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tFromLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				if (Information.IsDBNull(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["VCH_TIME"])))
				{
					mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_DATE"]), "HH:mm:ss");
				}
				else
				{
					mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				}
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
				((TextBoxBase)tToLcCode).ReadOnly = true;
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM INOUT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 49] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					if (Operators.CompareString(mSG[DC_Main.i + 1, 1], "N", false) == 0)
					{
						mSG[DC_Main.i + 1, 1] = "";
					}
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_LOT"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_COST"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 94] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
					mSG[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 23] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					string text = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID_WT"], (object)""));
					mSG[DC_Main.i + 1, 74] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"], (object)""));
					mSG[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"], (object)""));
					mSG[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_JDT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_WT"])), "0.000");
					mSG[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 81] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_KUN_NET"])), "0.000");
					mSG[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["JDT_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 84] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
					mSG[DC_Main.i + 1, 85] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 87] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 88] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 89] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 91] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_AC"], (object)""));
					mSG[DC_Main.i + 1, 86] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_LC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 90] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 92] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG[DC_Main.i + 1, 49]));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 93] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DATA_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 55] = "E";
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM INOUT_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[16] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["SR_NO"], (object)"");
					dr[0] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["ISR_NO"], (object)"");
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[3] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					dr[4] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
					dr[5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_WT"], (object)"")), "0.000");
					dr[6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"], (object)"")), "0.000");
					dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE"], (object)"")), "0.00");
					dr[9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_AMT"], (object)"")), "0.00");
					dr[10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"], (object)"")), "0.00");
					dr[11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"], (object)"")), "0.00");
					dr[12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"], (object)"")), "0.00");
					dr[13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"], (object)"")), "0.000");
					dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[15] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					dr[17] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
					dr[18] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
					dr[19] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
					dr[20] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
					dr[21] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
					dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
					dr[23] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
					dr[24] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_ACT_WT"], (object)"")), "0.000");
					dr[25] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_ACT_PRC"], (object)"")), "0.00");
					dr[26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"], (object)"")), "0.00");
					dr[27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_RATE"], (object)"")), "0.00");
					dr[28] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_AMT"], (object)"")), "0.00");
					dr[29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"], (object)"")), "0.000");
					dr[30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_WT"], (object)"")), "0.000");
					dr[31] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 28]) + Conversion.Val(MSG_TOT[0, 27]);
				NewValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 33]) + Conversion.Val(MSG_TOT[0, 28]) + Conversion.Val(MSG_TOT[0, 27]);
				if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
				{
					DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "' AND STK_TRFR = 'Y'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						LcStkTrfr = "Y";
					}
				}
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

	private void TR_INOUT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_INOUT_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0212: Unknown result type (might be due to invalid IL or missing references)
		//IL_0297: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		AxMSFlexGrid val = default(AxMSFlexGrid);
		int num5 = default(int);
		DataTable dataTable = default(DataTable);
		DataRow dataRow = default(DataRow);
		DataRow dataRow2 = default(DataRow);
		DataRow dataRow3 = default(DataRow);
		int num6 = default(int);
		DataRow dataRow4 = default(DataRow);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		AxMSFlexGrid val2 = default(AxMSFlexGrid);
		DataRow dataRow5 = default(DataRow);
		DataRow dataRow6 = default(DataRow);
		int num10 = default(int);
		DataRow dataRow7 = default(DataRow);
		int num11 = default(int);
		int num12 = default(int);
		DataRow dataRow8 = default(DataRow);
		int num13 = default(int);
		DataRow dataRow9 = default(DataRow);
		int num14 = default(int);
		DataRow dataRow10 = default(DataRow);
		int num15 = default(int);
		int num16 = default(int);
		int num17 = default(int);
		AxMSFlexGrid val3 = default(AxMSFlexGrid);
		AxMSFlexGrid val4 = default(AxMSFlexGrid);
		int num18 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					DataTable dtIdtl;
					DataTable dtIdtl2;
					DataTable dtIdtl3;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							goto IL_0032;
						}
						goto IL_0048;
					case 34712:
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
								goto IL_0078;
							case 7:
								goto IL_0087;
							case 9:
							case 10:
								goto IL_009d;
							case 11:
								goto IL_00d3;
							case 12:
								goto IL_00e3;
							case 14:
							case 15:
								goto IL_00f9;
							case 16:
								goto IL_0109;
							case 17:
								goto IL_0157;
							case 18:
								goto IL_016b;
							case 20:
							case 21:
								goto IL_0182;
							case 22:
								goto IL_01ab;
							case 23:
								goto IL_01cf;
							case 25:
							case 26:
								goto IL_01e6;
							case 27:
								goto IL_0208;
							case 28:
								goto IL_0218;
							case 29:
								goto IL_0227;
							case 31:
							case 32:
								goto IL_023e;
							case 33:
								goto IL_025b;
							case 34:
								goto IL_028d;
							case 35:
								goto IL_029d;
							case 37:
							case 38:
							case 39:
								goto IL_02b6;
							case 40:
								goto IL_02d8;
							case 41:
								goto IL_02e8;
							case 43:
							case 44:
								goto IL_02ff;
							case 45:
								goto IL_0309;
							case 46:
								goto IL_034a;
							case 47:
								goto IL_035c;
							case 48:
								goto IL_0377;
							case 50:
								goto IL_03ad;
							case 49:
							case 51:
							case 52:
								goto IL_03bc;
							case 53:
								goto IL_03c5;
							case 54:
								goto IL_03d9;
							case 55:
								goto IL_03f9;
							case 56:
								goto IL_0461;
							case 57:
								goto IL_0473;
							case 58:
								goto IL_048e;
							case 60:
								goto IL_04de;
							case 59:
							case 61:
							case 62:
							case 63:
								goto IL_04f5;
							case 64:
								goto IL_0515;
							case 65:
								goto IL_0589;
							case 66:
								goto IL_059b;
							case 67:
								goto IL_05b9;
							case 68:
								goto IL_0615;
							case 69:
								goto IL_0627;
							case 70:
								goto IL_0645;
							case 71:
								goto IL_069c;
							case 72:
							case 73:
							case 74:
								goto IL_06ec;
							case 75:
								goto IL_074e;
							case 76:
								goto IL_0760;
							case 77:
								goto IL_077e;
							case 78:
								goto IL_07c9;
							case 79:
								goto IL_07db;
							case 80:
								goto IL_07f6;
							case 81:
							case 82:
							case 83:
							case 84:
								goto IL_0848;
							case 85:
								goto IL_084d;
							case 86:
								goto IL_086d;
							case 87:
								goto IL_08e2;
							case 88:
								goto IL_0957;
							case 89:
								goto IL_09cc;
							case 90:
								goto IL_0a57;
							case 91:
								goto IL_0aba;
							case 92:
								goto IL_0b1c;
							case 93:
								goto IL_0b2b;
							case 94:
								goto IL_0b34;
							case 95:
								goto IL_0b40;
							case 96:
								goto IL_0b55;
							case 97:
								goto IL_0b6a;
							case 98:
								goto IL_0b7f;
							case 99:
								goto IL_0b9a;
							case 100:
								goto IL_0bb0;
							case 101:
								goto IL_0bc2;
							case 102:
								goto IL_0bd2;
							case 103:
								goto IL_0bdd;
							case 104:
								goto IL_0c51;
							case 105:
								goto IL_0c64;
							case 106:
								goto IL_0c6d;
							case 107:
								goto IL_0c7d;
							case 108:
								goto IL_0c92;
							case 109:
								goto IL_0ca7;
							case 110:
								goto IL_0cbc;
							case 111:
								goto IL_0cd1;
							case 112:
								goto IL_0cec;
							case 113:
								goto IL_0d07;
							case 114:
								goto IL_0d1c;
							case 115:
								goto IL_0d32;
							case 116:
								goto IL_0d48;
							case 117:
								goto IL_0d5d;
							case 118:
								goto IL_0d73;
							case 119:
								goto IL_0d8e;
							case 120:
								goto IL_0da9;
							case 121:
								goto IL_0dc4;
							case 122:
								goto IL_0dd9;
							case 123:
								goto IL_0dee;
							case 124:
								goto IL_0e09;
							case 125:
								goto IL_0e1e;
							case 126:
								goto IL_0e46;
							case 127:
								goto IL_0e6e;
							case 128:
								goto IL_0e96;
							case 129:
								goto IL_0ec1;
							case 130:
								goto IL_0eec;
							case 131:
								goto IL_0f17;
							case 132:
								goto IL_0f35;
							case 133:
								goto IL_0f53;
							case 134:
								goto IL_0f71;
							case 135:
								goto IL_0fa4;
							case 136:
								goto IL_0fbc;
							case 137:
								goto IL_0fd5;
							case 138:
								goto IL_0fed;
							case 139:
								goto IL_1005;
							case 140:
								goto IL_101e;
							case 141:
								goto IL_1035;
							case 142:
							case 143:
								goto IL_1049;
							case 144:
								goto IL_10c0;
							case 145:
								goto IL_10d6;
							case 146:
								goto IL_10e2;
							case 147:
								goto IL_10f5;
							case 148:
								goto IL_1116;
							case 149:
								goto IL_1124;
							case 150:
								goto IL_11ea;
							case 151:
								goto IL_1202;
							case 152:
								goto IL_121a;
							case 153:
								goto IL_1232;
							case 154:
								goto IL_124a;
							case 155:
								goto IL_1268;
							case 156:
								goto IL_1286;
							case 157:
								goto IL_12a4;
							case 158:
								goto IL_12c2;
							case 159:
								goto IL_12e0;
							case 160:
								goto IL_12f8;
							case 161:
								goto IL_1310;
							case 162:
								goto IL_132e;
							case 163:
								goto IL_134c;
							case 164:
								goto IL_136a;
							case 165:
								goto IL_1383;
							case 166:
								goto IL_139c;
							case 167:
								goto IL_13b4;
							case 168:
								goto IL_13cd;
							case 169:
								goto IL_13f7;
							case 170:
								goto IL_1422;
							case 171:
								goto IL_1442;
							case 172:
								goto IL_1469;
							case 174:
								goto IL_1485;
							case 173:
							case 175:
							case 176:
								goto IL_14a6;
							case 177:
								goto IL_14c6;
							case 178:
								goto IL_14e6;
							case 179:
								goto IL_1506;
							case 180:
								goto IL_1526;
							case 181:
								goto IL_1546;
							case 182:
								goto IL_1567;
							case 183:
								goto IL_1587;
							case 184:
								goto IL_15b2;
							case 185:
								goto IL_15dd;
							case 186:
								goto IL_1608;
							case 187:
								goto IL_1633;
							case 188:
								goto IL_165e;
							case 189:
								goto IL_1689;
							case 190:
								goto IL_16b4;
							case 191:
								goto IL_16df;
							case 192:
								goto IL_170a;
							case 193:
								goto IL_172b;
							case 194:
								goto IL_1756;
							case 195:
								goto IL_1777;
							case 196:
								goto IL_17a2;
							case 197:
								goto IL_17cd;
							case 198:
								goto IL_17f8;
							case 199:
								goto IL_1823;
							case 200:
								goto IL_184e;
							case 201:
								goto IL_1879;
							case 202:
								goto IL_18a4;
							case 203:
								goto IL_18cf;
							case 204:
								goto IL_18fa;
							case 205:
								goto IL_1925;
							case 206:
								goto IL_1950;
							case 207:
								goto IL_197b;
							case 208:
								goto IL_19a6;
							case 209:
								goto IL_19d1;
							case 210:
								goto IL_19fc;
							case 211:
								goto IL_1a27;
							case 212:
								goto IL_1a52;
							case 213:
								goto IL_1a7d;
							case 214:
								goto IL_1a95;
							case 216:
								goto IL_1ac4;
							case 215:
							case 217:
							case 218:
								goto IL_1af0;
							case 219:
								goto IL_1b11;
							case 220:
								goto IL_1b32;
							case 221:
								goto IL_1b53;
							case 222:
								goto IL_1b74;
							case 223:
								goto IL_1b95;
							case 224:
								goto IL_1bc0;
							case 225:
								goto IL_1be1;
							case 226:
								goto IL_1c02;
							case 227:
								goto IL_1c23;
							case 228:
								goto IL_1c4e;
							case 229:
								goto IL_1c79;
							case 230:
								goto IL_1ca4;
							case 231:
								goto IL_1ccf;
							case 232:
								goto IL_1cfa;
							case 233:
								goto IL_1d25;
							case 234:
								goto IL_1d50;
							case 235:
								goto IL_1d7b;
							case 236:
								goto IL_1da6;
							case 237:
								goto IL_1dd1;
							case 238:
								goto IL_1dfc;
							case 239:
								goto IL_1e1d;
							case 240:
								goto IL_1e3e;
							case 241:
								goto IL_1e5f;
							case 242:
								goto IL_1e80;
							case 243:
								goto IL_1ea1;
							case 244:
								goto IL_1ec2;
							case 245:
								goto IL_1eed;
							case 246:
								goto IL_1f06;
							case 247:
								goto IL_1f27;
							case 248:
								goto IL_1f5a;
							case 249:
								goto IL_1f72;
							case 250:
								goto IL_1f93;
							case 251:
								goto IL_1fac;
							case 252:
								goto IL_1fc5;
							case 253:
								goto IL_1fdc;
							case 254:
							case 255:
								goto IL_1ff1;
							case 256:
								goto IL_1ff4;
							case 257:
								goto IL_2012;
							case 258:
								goto IL_2089;
							case 259:
								goto IL_209f;
							case 260:
								goto IL_20ab;
							case 261:
								goto IL_20be;
							case 262:
								goto IL_20c6;
							case 263:
								goto IL_20e9;
							case 264:
								goto IL_20f7;
							case 265:
								goto IL_217d;
							case 266:
								goto IL_219a;
							case 267:
								goto IL_21e2;
							case 269:
							case 270:
								goto IL_21f2;
							case 268:
							case 271:
								goto IL_220d;
							case 272:
								goto IL_2225;
							case 273:
								goto IL_223d;
							case 274:
								goto IL_2255;
							case 275:
								goto IL_226d;
							case 276:
								goto IL_228b;
							case 277:
								goto IL_22a9;
							case 278:
								goto IL_22c7;
							case 279:
								goto IL_22e5;
							case 280:
								goto IL_22fd;
							case 281:
								goto IL_2315;
							case 282:
								goto IL_2333;
							case 283:
								goto IL_2351;
							case 284:
								goto IL_236f;
							case 285:
								goto IL_238d;
							case 286:
								goto IL_23a6;
							case 287:
								goto IL_23bf;
							case 288:
								goto IL_23d7;
							case 289:
								goto IL_23f0;
							case 290:
								goto IL_242b;
							case 291:
								goto IL_244b;
							case 292:
								goto IL_246c;
							case 293:
								goto IL_24a6;
							case 294:
								goto IL_24d6;
							case 295:
								goto IL_2510;
							case 296:
								goto IL_254a;
							case 297:
								goto IL_2584;
							case 298:
								goto IL_25be;
							case 299:
								goto IL_25ee;
							case 300:
								goto IL_2628;
							case 301:
								goto IL_2663;
							case 302:
								goto IL_269e;
							case 303:
								goto IL_26d9;
							case 304:
								goto IL_2714;
							case 305:
								goto IL_274f;
							case 306:
								goto IL_2780;
							case 307:
								goto IL_2799;
							case 308:
								goto IL_27ca;
							case 309:
								goto IL_27fb;
							case 310:
								goto IL_282c;
							case 311:
								goto IL_285d;
							case 312:
								goto IL_288e;
							case 313:
								goto IL_28bf;
							case 314:
								goto IL_28f0;
							case 315:
								goto IL_292b;
							case 316:
								goto IL_2966;
							case 317:
								goto IL_29a1;
							case 318:
								goto IL_29dc;
							case 319:
								goto IL_2a17;
							case 320:
								goto IL_2a52;
							case 321:
								goto IL_2a6b;
							case 322:
								goto IL_2a82;
							case 323:
							case 324:
								goto IL_2a97;
							case 325:
								goto IL_2a9a;
							case 326:
								goto IL_2aaf;
							case 327:
								goto IL_2b26;
							case 328:
								goto IL_2b37;
							case 329:
								goto IL_2b53;
							case 330:
								goto IL_2bca;
							case 331:
								goto IL_2bdb;
							case 332:
							case 333:
								goto IL_2bf9;
							case 334:
								goto IL_2c7d;
							case 335:
								goto IL_2d01;
							case 336:
								goto IL_2d85;
							case 337:
								goto IL_2e13;
							case 338:
								goto IL_2e96;
							case 339:
								goto IL_2eac;
							case 340:
								goto IL_2eb8;
							case 341:
								goto IL_2ecb;
							case 342:
								goto IL_2ee3;
							case 343:
								goto IL_2f01;
							case 344:
								goto IL_2f19;
							case 345:
								goto IL_2f37;
							case 346:
								goto IL_2f55;
							case 347:
								goto IL_2f73;
							case 348:
								goto IL_2f91;
							case 349:
								goto IL_2fa9;
							case 350:
								goto IL_2fc7;
							case 351:
								goto IL_2fe5;
							case 352:
								goto IL_3003;
							case 353:
								goto IL_3023;
							case 354:
								goto IL_3041;
							case 355:
								goto IL_305f;
							case 357:
								goto IL_3081;
							case 358:
								goto IL_3099;
							case 359:
								goto IL_30b1;
							case 356:
							case 360:
							case 361:
								goto IL_30d0;
							case 362:
								goto IL_30e8;
							case 363:
								goto IL_3100;
							case 364:
								goto IL_3118;
							case 365:
								goto IL_3130;
							case 366:
								goto IL_3150;
							case 368:
								goto IL_316c;
							case 369:
								goto IL_318c;
							case 371:
								goto IL_31a8;
							case 367:
							case 370:
							case 372:
							case 373:
							case 374:
								goto IL_31c2;
							case 375:
								goto IL_31ed;
							case 376:
								goto IL_3218;
							case 377:
								goto IL_3243;
							case 378:
								goto IL_326e;
							case 379:
								goto IL_3299;
							case 380:
								goto IL_32c4;
							case 381:
								goto IL_32e2;
							case 382:
								goto IL_3300;
							case 383:
								goto IL_3333;
							case 384:
								goto IL_334b;
							case 385:
								goto IL_3364;
							case 386:
								goto IL_337d;
							case 387:
								goto IL_3394;
							case 388:
							case 389:
								goto IL_33a8;
							case 390:
								goto IL_342b;
							case 391:
								goto IL_3441;
							case 392:
								goto IL_344d;
							case 393:
								goto IL_3460;
							case 394:
								goto IL_3481;
							case 395:
								goto IL_348f;
							case 396:
								goto IL_3555;
							case 397:
								goto IL_356d;
							case 398:
								goto IL_358b;
							case 399:
								goto IL_35a3;
							case 400:
								goto IL_35c1;
							case 401:
								goto IL_35df;
							case 402:
								goto IL_35fd;
							case 403:
								goto IL_361b;
							case 404:
								goto IL_3639;
							case 405:
								goto IL_3657;
							case 406:
								goto IL_3677;
							case 407:
								goto IL_3695;
							case 408:
								goto IL_36b3;
							case 410:
								goto IL_36d5;
							case 411:
								goto IL_36ed;
							case 412:
								goto IL_3705;
							case 409:
							case 413:
							case 414:
								goto IL_3724;
							case 415:
								goto IL_3742;
							case 416:
								goto IL_375a;
							case 417:
								goto IL_3772;
							case 418:
								goto IL_378a;
							case 419:
								goto IL_37a2;
							case 420:
								goto IL_37ba;
							case 421:
								goto IL_37e4;
							case 422:
								goto IL_380f;
							case 423:
								goto IL_382f;
							case 424:
								goto IL_3856;
							case 426:
								goto IL_3872;
							case 425:
							case 427:
							case 428:
								goto IL_3893;
							case 429:
								goto IL_38b3;
							case 430:
								goto IL_38d3;
							case 431:
								goto IL_38f3;
							case 432:
								goto IL_3913;
							case 433:
								goto IL_3933;
							case 434:
								goto IL_3954;
							case 435:
								goto IL_3974;
							case 436:
								goto IL_399f;
							case 437:
								goto IL_39ca;
							case 438:
								goto IL_39f5;
							case 439:
								goto IL_3a20;
							case 440:
								goto IL_3a4b;
							case 441:
								goto IL_3a76;
							case 442:
								goto IL_3aa1;
							case 443:
								goto IL_3acc;
							case 444:
								goto IL_3af7;
							case 445:
								goto IL_3b18;
							case 446:
								goto IL_3b43;
							case 447:
								goto IL_3b64;
							case 448:
								goto IL_3b8f;
							case 449:
								goto IL_3bba;
							case 450:
								goto IL_3be5;
							case 451:
								goto IL_3c10;
							case 452:
								goto IL_3c3b;
							case 453:
								goto IL_3c66;
							case 454:
								goto IL_3c91;
							case 455:
								goto IL_3cbc;
							case 456:
								goto IL_3ce7;
							case 457:
								goto IL_3d12;
							case 458:
								goto IL_3d3d;
							case 459:
								goto IL_3d68;
							case 460:
								goto IL_3d93;
							case 461:
								goto IL_3dbe;
							case 462:
								goto IL_3de9;
							case 463:
								goto IL_3e14;
							case 464:
								goto IL_3e3f;
							case 465:
								goto IL_3e6a;
							case 466:
								goto IL_3e82;
							case 468:
								goto IL_3eb1;
							case 467:
							case 469:
							case 470:
								goto IL_3edd;
							case 471:
								goto IL_3efe;
							case 472:
								goto IL_3f1f;
							case 473:
								goto IL_3f40;
							case 474:
								goto IL_3f61;
							case 475:
								goto IL_3f82;
							case 476:
								goto IL_3fad;
							case 477:
								goto IL_3fce;
							case 478:
								goto IL_3fef;
							case 479:
								goto IL_4010;
							case 480:
								goto IL_403b;
							case 481:
								goto IL_4066;
							case 482:
								goto IL_4091;
							case 483:
								goto IL_40bc;
							case 484:
								goto IL_40e7;
							case 485:
								goto IL_4112;
							case 486:
								goto IL_413d;
							case 487:
								goto IL_4168;
							case 488:
								goto IL_4193;
							case 489:
								goto IL_41be;
							case 490:
								goto IL_41e9;
							case 491:
								goto IL_420a;
							case 492:
								goto IL_422b;
							case 493:
								goto IL_424c;
							case 494:
								goto IL_426d;
							case 495:
								goto IL_428e;
							case 496:
								goto IL_42af;
							case 497:
								goto IL_42da;
							case 498:
								goto IL_4380;
							case 499:
								goto IL_43a1;
							case 500:
								goto IL_43d4;
							case 501:
								goto IL_43ec;
							case 502:
								goto IL_4405;
							case 503:
								goto IL_441e;
							case 504:
								goto IL_4437;
							case 505:
								goto IL_444e;
							case 506:
							case 507:
								goto IL_4463;
							case 508:
								goto IL_4466;
							case 509:
								goto IL_4484;
							case 510:
								goto IL_4507;
							case 511:
								goto IL_451d;
							case 512:
								goto IL_4529;
							case 513:
								goto IL_453c;
							case 514:
								goto IL_4544;
							case 515:
								goto IL_4567;
							case 516:
								goto IL_4575;
							case 517:
								goto IL_45fb;
							case 518:
								goto IL_4618;
							case 519:
								goto IL_4660;
							case 521:
							case 522:
								goto IL_4670;
							case 520:
							case 523:
								goto IL_468b;
							case 524:
								goto IL_46a3;
							case 525:
								goto IL_46c1;
							case 526:
								goto IL_46d9;
							case 527:
								goto IL_46f7;
							case 528:
								goto IL_4715;
							case 529:
								goto IL_4733;
							case 530:
								goto IL_4751;
							case 531:
								goto IL_476f;
							case 532:
								goto IL_478f;
							case 533:
								goto IL_47ad;
							case 534:
								goto IL_47cb;
							case 536:
								goto IL_47ed;
							case 537:
								goto IL_4805;
							case 538:
								goto IL_481d;
							case 535:
							case 539:
							case 540:
								goto IL_483c;
							case 541:
								goto IL_485a;
							case 542:
								goto IL_4878;
							case 543:
								goto IL_4890;
							case 544:
								goto IL_48a8;
							case 545:
								goto IL_48c0;
							case 546:
								goto IL_48d8;
							case 547:
								goto IL_48f0;
							case 548:
								goto IL_492b;
							case 549:
								goto IL_494b;
							case 550:
								goto IL_496c;
							case 551:
								goto IL_49a6;
							case 552:
								goto IL_49d6;
							case 553:
								goto IL_4a10;
							case 554:
								goto IL_4a4a;
							case 555:
								goto IL_4a84;
							case 556:
								goto IL_4abe;
							case 557:
								goto IL_4aee;
							case 558:
								goto IL_4b28;
							case 559:
								goto IL_4b63;
							case 560:
								goto IL_4b9e;
							case 561:
								goto IL_4bd9;
							case 562:
								goto IL_4c14;
							case 563:
								goto IL_4c4f;
							case 564:
								goto IL_4c80;
							case 565:
								goto IL_4c99;
							case 566:
								goto IL_4cca;
							case 567:
								goto IL_4cfb;
							case 568:
								goto IL_4d2c;
							case 569:
								goto IL_4d5d;
							case 570:
								goto IL_4d8e;
							case 571:
								goto IL_4dbf;
							case 572:
								goto IL_4df0;
							case 573:
								goto IL_4e2b;
							case 574:
								goto IL_4e66;
							case 575:
								goto IL_4ea1;
							case 576:
								goto IL_4edc;
							case 577:
								goto IL_4f17;
							case 578:
								goto IL_4f52;
							case 579:
								goto IL_4f6b;
							case 580:
								goto IL_4f82;
							case 581:
							case 582:
								goto IL_4f97;
							case 583:
								goto IL_4f9a;
							case 584:
								goto IL_4faf;
							case 585:
								goto IL_4fd2;
							case 586:
								goto IL_5056;
							case 587:
								goto IL_50da;
							case 588:
								goto IL_515d;
							case 589:
								goto IL_5173;
							case 590:
								goto IL_517f;
							case 591:
								goto IL_5192;
							case 592:
								goto IL_51b3;
							case 593:
								goto IL_51c1;
							case 594:
								goto IL_5279;
							case 595:
								goto IL_5291;
							case 596:
								goto IL_52af;
							case 597:
								goto IL_52c7;
							case 598:
								goto IL_52e5;
							case 599:
								goto IL_5303;
							case 600:
								goto IL_5321;
							case 601:
								goto IL_533f;
							case 602:
								goto IL_535d;
							case 603:
								goto IL_5375;
							case 604:
								goto IL_538d;
							case 605:
								goto IL_53a5;
							case 606:
								goto IL_53bd;
							case 607:
								goto IL_53d5;
							case 608:
								goto IL_53ff;
							case 609:
								goto IL_542a;
							case 610:
								goto IL_544a;
							case 611:
								goto IL_5471;
							case 613:
								goto IL_548d;
							case 612:
							case 614:
							case 615:
								goto IL_54ae;
							case 616:
								goto IL_54ce;
							case 617:
								goto IL_54ee;
							case 618:
								goto IL_550e;
							case 619:
								goto IL_552e;
							case 620:
								goto IL_554f;
							case 621:
								goto IL_556f;
							case 622:
								goto IL_559a;
							case 623:
								goto IL_55c5;
							case 624:
								goto IL_55f0;
							case 625:
								goto IL_561b;
							case 626:
								goto IL_5646;
							case 627:
								goto IL_5671;
							case 628:
								goto IL_569c;
							case 629:
								goto IL_56c7;
							case 630:
								goto IL_56f2;
							case 631:
								goto IL_5713;
							case 632:
								goto IL_573e;
							case 633:
								goto IL_575f;
							case 634:
								goto IL_578a;
							case 635:
								goto IL_57b5;
							case 636:
								goto IL_57e0;
							case 637:
								goto IL_580b;
							case 638:
								goto IL_5836;
							case 639:
								goto IL_5861;
							case 640:
								goto IL_588c;
							case 641:
								goto IL_58b7;
							case 642:
								goto IL_58e2;
							case 643:
								goto IL_590d;
							case 644:
								goto IL_5938;
							case 645:
								goto IL_5963;
							case 646:
								goto IL_598e;
							case 647:
								goto IL_59b9;
							case 648:
								goto IL_59e4;
							case 649:
								goto IL_5a0f;
							case 650:
								goto IL_5a3a;
							case 651:
								goto IL_5a65;
							case 652:
								goto IL_5a7d;
							case 654:
								goto IL_5aac;
							case 653:
							case 655:
							case 656:
								goto IL_5ad8;
							case 657:
								goto IL_5af9;
							case 658:
								goto IL_5b1a;
							case 659:
								goto IL_5b3b;
							case 660:
								goto IL_5b5c;
							case 661:
								goto IL_5b7d;
							case 662:
								goto IL_5b9e;
							case 663:
								goto IL_5c44;
							case 664:
								goto IL_5cec;
							case 665:
								goto IL_5d0d;
							case 666:
								goto IL_5d2e;
							case 667:
								goto IL_5d4f;
							case 668:
								goto IL_5d7a;
							case 669:
								goto IL_5da5;
							case 670:
								goto IL_5dd0;
							case 671:
								goto IL_5dfb;
							case 672:
								goto IL_5e26;
							case 673:
								goto IL_5e51;
							case 674:
								goto IL_5e7c;
							case 675:
								goto IL_5ea7;
							case 676:
								goto IL_5ed2;
							case 677:
								goto IL_5efd;
							case 678:
								goto IL_5f28;
							case 679:
								goto IL_5f49;
							case 680:
								goto IL_5f6a;
							case 681:
								goto IL_5f8b;
							case 682:
								goto IL_5fac;
							case 683:
								goto IL_5fcd;
							case 684:
								goto IL_5fee;
							case 685:
								goto IL_6019;
							case 686:
								goto IL_604c;
							case 687:
								goto IL_6064;
							case 688:
								goto IL_607c;
							case 689:
								goto IL_6094;
							case 690:
								goto IL_60ac;
							case 691:
								goto IL_60cd;
							case 692:
								goto IL_60ee;
							case 693:
								goto IL_6107;
							case 694:
								goto IL_6120;
							case 695:
								goto IL_6137;
							case 696:
							case 697:
								goto IL_614c;
							case 698:
								goto IL_614f;
							case 699:
								goto IL_616d;
							case 700:
								goto IL_61e5;
							case 701:
								goto IL_625c;
							case 702:
								goto IL_6272;
							case 703:
								goto IL_627e;
							case 704:
								goto IL_6291;
							case 705:
								goto IL_62b2;
							case 706:
								goto IL_62c0;
							case 707:
								goto IL_6378;
							case 708:
							case 709:
								goto IL_641f;
							case 710:
								goto IL_64af;
							case 711:
								goto IL_64c7;
							case 712:
								goto IL_64df;
							case 713:
								goto IL_64f7;
							case 714:
								goto IL_650f;
							case 715:
								goto IL_652d;
							case 716:
								goto IL_654b;
							case 717:
								goto IL_6569;
							case 718:
								goto IL_6582;
							case 719:
								goto IL_659b;
							case 720:
								goto IL_65b3;
							case 721:
								goto IL_65cc;
							case 722:
								goto IL_65f6;
							case 723:
								goto IL_6616;
							case 724:
								goto IL_6636;
							case 725:
								goto IL_6656;
							case 726:
								goto IL_6676;
							case 727:
								goto IL_6696;
							case 728:
								goto IL_66c1;
							case 729:
								goto IL_66ec;
							case 730:
								goto IL_6717;
							case 731:
								goto IL_6742;
							case 732:
								goto IL_676d;
							case 733:
								goto IL_6798;
							case 734:
								goto IL_67c3;
							case 735:
								goto IL_67ee;
							case 736:
								goto IL_6818;
							case 738:
								goto IL_6847;
							case 737:
							case 739:
							case 740:
								goto IL_6873;
							case 741:
								goto IL_68a0;
							case 742:
								goto IL_68cb;
							case 743:
								goto IL_68f6;
							case 745:
								goto IL_6928;
							case 746:
								goto IL_6953;
							case 747:
								goto IL_697e;
							case 744:
							case 748:
							case 749:
								goto IL_69aa;
							case 750:
								goto IL_69d5;
							case 751:
								goto IL_69f6;
							case 752:
								goto IL_6a21;
							case 753:
								goto IL_6a4c;
							case 754:
								goto IL_6a77;
							case 755:
								goto IL_6aa2;
							case 756:
								goto IL_6acd;
							case 757:
								goto IL_6aee;
							case 758:
								goto IL_6b0f;
							case 759:
								goto IL_6b30;
							case 760:
								goto IL_6b51;
							case 761:
								goto IL_6b69;
							case 762:
								goto IL_6b81;
							case 763:
								goto IL_6ba2;
							case 764:
								goto IL_6bbb;
							case 765:
								goto IL_6bd4;
							case 766:
								goto IL_6beb;
							case 767:
							case 768:
								goto IL_6c00;
							case 769:
								goto IL_6c03;
							case 770:
								goto IL_6c21;
							case 771:
								goto IL_6ca4;
							case 772:
								goto IL_6cba;
							case 773:
								goto IL_6cc6;
							case 774:
								goto IL_6cd9;
							case 775:
								goto IL_6ce1;
							case 776:
								goto IL_6d04;
							case 777:
								goto IL_6d12;
							case 778:
								goto IL_6d98;
							case 779:
								goto IL_6db5;
							case 780:
								goto IL_6dfd;
							case 782:
							case 783:
								goto IL_6e0d;
							case 781:
							case 784:
								goto IL_6e28;
							case 785:
								goto IL_6e52;
							case 786:
								goto IL_6e6a;
							case 787:
								goto IL_6e88;
							case 788:
								goto IL_6ea0;
							case 789:
								goto IL_6ebe;
							case 790:
								goto IL_6edc;
							case 791:
								goto IL_6efa;
							case 792:
								goto IL_6f12;
							case 793:
								goto IL_6f2a;
							case 794:
								goto IL_6f42;
							case 795:
								goto IL_6f5a;
							case 796:
								goto IL_6f72;
							case 797:
								goto IL_6fad;
							case 798:
								goto IL_6fcd;
							case 799:
								goto IL_7061;
							case 800:
								goto IL_709b;
							case 801:
								goto IL_70cb;
							case 802:
								goto IL_7105;
							case 803:
								goto IL_713f;
							case 804:
								goto IL_7179;
							case 805:
								goto IL_71b3;
							case 806:
								goto IL_71e3;
							case 807:
								goto IL_721d;
							case 808:
								goto IL_7258;
							case 809:
								goto IL_7293;
							case 810:
								goto IL_72ce;
							case 811:
								goto IL_7309;
							case 812:
								goto IL_7344;
							case 813:
								goto IL_7375;
							case 814:
								goto IL_738e;
							case 815:
								goto IL_73bf;
							case 816:
								goto IL_73f0;
							case 817:
								goto IL_7421;
							case 818:
								goto IL_7452;
							case 819:
								goto IL_7483;
							case 820:
								goto IL_74b4;
							case 821:
								goto IL_74e5;
							case 822:
								goto IL_7520;
							case 823:
								goto IL_755b;
							case 824:
								goto IL_7596;
							case 825:
								goto IL_75d1;
							case 826:
								goto IL_760c;
							case 827:
								goto IL_7647;
							case 828:
								goto IL_7660;
							case 829:
								goto IL_7677;
							case 830:
							case 831:
							case 832:
								goto IL_768e;
							case 833:
								goto IL_7691;
							case 834:
							case 835:
								goto IL_76a8;
							case 836:
								goto IL_76cb;
							case 837:
								goto IL_7742;
							case 838:
								goto IL_7753;
							case 839:
								goto IL_77ca;
							case 840:
								goto IL_77db;
							case 841:
							case 842:
								goto IL_77f9;
							case 843:
								goto IL_781b;
							case 844:
								goto IL_7892;
							case 845:
								goto IL_78a3;
							case 846:
								goto IL_78bf;
							case 847:
								goto IL_7936;
							case 848:
								goto IL_7947;
							case 849:
							case 850:
								goto IL_7965;
							case 851:
								goto IL_7982;
							case 852:
								goto IL_79a2;
							case 853:
								goto IL_79af;
							case 855:
							case 856:
								goto IL_79c0;
							case 857:
								goto IL_79d7;
							case 858:
								goto IL_79e4;
							case 859:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 8:
							case 13:
							case 19:
							case 24:
							case 30:
							case 36:
							case 42:
							case 854:
							case 860:
							case 861:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_444e:
						num2 = 505;
						RsDetl.Clear();
						goto IL_4463;
						IL_4463:
						val = null;
						goto IL_4466;
						IL_4437:
						num2 = 504;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						goto IL_444e;
						IL_4466:
						num2 = 508;
						DC_Main.i++;
						goto IL_4478;
						IL_0032:
						num2 = 2;
						Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0048:
						num2 = 5;
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							goto IL_0078;
						}
						goto IL_009d;
						IL_0078:
						num2 = 6;
						Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
						goto IL_0087;
						IL_0087:
						num2 = 7;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_009d:
						num2 = 10;
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							goto IL_00d3;
						}
						goto IL_00f9;
						IL_00d3:
						num2 = 11;
						Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
						goto IL_00e3;
						IL_00e3:
						num2 = 12;
						((Control)tEmpCode).Focus();
						goto end_IL_0001_3;
						IL_00f9:
						num2 = 15;
						((Control)BtnSave).Enabled = false;
						goto IL_0109;
						IL_0109:
						num2 = 16;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							goto IL_0157;
						}
						goto IL_0182;
						IL_0157:
						num2 = 17;
						Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
						goto IL_016b;
						IL_016b:
						num2 = 18;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_0182:
						num2 = 21;
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							goto IL_01ab;
						}
						goto IL_01e6;
						IL_01ab:
						num2 = 22;
						Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
						goto IL_01cf;
						IL_01cf:
						num2 = 23;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_01e6:
						num2 = 26;
						if (Operators.CompareString(tToLcCode.Text, "", false) == 0)
						{
							goto IL_0208;
						}
						goto IL_023e;
						IL_0208:
						num2 = 27;
						Interaction.MsgBox((object)"Please Select Transfer Loction An Try  ....", (MsgBoxStyle)0, (object)null);
						goto IL_0218;
						IL_0218:
						num2 = 28;
						((Control)tToLcCode).Focus();
						goto IL_0227;
						IL_0227:
						num2 = 29;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_023e:
						num2 = 32;
						if (Operators.CompareString(UsUPdate, "Y", false) != 0)
						{
							goto IL_025b;
						}
						goto IL_02b6;
						IL_025b:
						num2 = 33;
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							goto IL_028d;
						}
						goto IL_02b6;
						IL_028d:
						num2 = 34;
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto IL_029d;
						IL_029d:
						num2 = 35;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_02b6:
						num2 = 39;
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							goto IL_02d8;
						}
						goto IL_02ff;
						IL_02d8:
						num2 = 40;
						Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
						goto IL_02e8;
						IL_02e8:
						num2 = 41;
						((Control)BtnSave).Enabled = true;
						goto end_IL_0001_3;
						IL_02ff:
						num2 = 44;
						MSG_TOT_FILL();
						goto IL_0309;
						IL_0309:
						num2 = 45;
						DC_Main.RsQry = "SELECT DATA_TYPE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_BOOK = '059' ";
						goto IL_034a;
						IL_034a:
						num2 = 46;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_035c;
						IL_035c:
						num2 = 47;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0377;
						}
						goto IL_03ad;
						IL_0377:
						num2 = 48;
						BranchDataType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DATA_TYPE"], (object)""));
						goto IL_03bc;
						IL_03ad:
						num2 = 50;
						BranchDataType = "A";
						goto IL_03bc;
						IL_03bc:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_03c5;
						IL_03c5:
						num2 = 53;
						tToBook.Text = "059";
						goto IL_03d9;
						IL_03d9:
						num2 = 54;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_03f9;
						}
						goto IL_04f5;
						IL_03f9:
						num2 = 55;
						DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + tToBook.Text + "' HAVING MAX(VCH_NO) > 0";
						goto IL_0461;
						IL_0461:
						num2 = 56;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0473;
						IL_0473:
						num2 = 57;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_048e;
						}
						goto IL_04de;
						IL_048e:
						num2 = 58;
						tToVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
						goto IL_04f5;
						IL_04de:
						num2 = 60;
						tToVchNo.Text = "00001";
						goto IL_04f5;
						IL_04f5:
						num2 = 63;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							goto IL_0515;
						}
						goto IL_0848;
						IL_0515:
						num2 = 64;
						DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_0589;
						IL_0589:
						num2 = 65;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_059b;
						IL_059b:
						num2 = 66;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_05b9;
						}
						goto IL_06ec;
						IL_05b9:
						num2 = 67;
						DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
						goto IL_0615;
						IL_0615:
						num2 = 68;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0627;
						IL_0627:
						num2 = 69;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_0645;
						}
						goto IL_06ec;
						IL_0645:
						num2 = 70;
						Interaction.MsgBox((object)("Current Voucher No has been changd New Voucher No is  '" + Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000") + "'"), (MsgBoxStyle)0, (object)null);
						goto IL_069c;
						IL_069c:
						num2 = 71;
						tVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
						goto IL_06ec;
						IL_06ec:
						num2 = 74;
						DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_074e;
						IL_074e:
						num2 = 75;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0760;
						IL_0760:
						num2 = 76;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_077e;
						}
						goto IL_0848;
						IL_077e:
						num2 = 77;
						DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
						goto IL_07c9;
						IL_07c9:
						num2 = 78;
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_07db;
						IL_07db:
						num2 = 79;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							goto IL_07f6;
						}
						goto IL_0848;
						IL_07f6:
						num2 = 80;
						tHdVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
						goto IL_0848;
						IL_0848:
						num2 = 84;
						num5 = 0;
						goto IL_084d;
						IL_084d:
						num2 = 85;
						if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
						{
							goto IL_086d;
						}
						goto IL_2bf9;
						IL_086d:
						num2 = 86;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_08e2;
						IL_08e2:
						num2 = 87;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_0957;
						IL_0957:
						num2 = 88;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_09cc;
						IL_09cc:
						num2 = 89;
						if ((Conversion.Val(MSG_TOT[0, 30]) != 0.0) | (Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 27]) + Conversion.Val(MSG_TOT[0, 28]) != 0.0))
						{
							goto IL_0a57;
						}
						goto IL_1049;
						IL_0a57:
						num2 = 90;
						DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
						goto IL_0aba;
						IL_0aba:
						num2 = 91;
						DC_Main.RsQry = "SELECT * FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
						goto IL_0b1c;
						IL_0b1c:
						num2 = 92;
						dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0b2b;
						IL_0b2b:
						num2 = 93;
						DC_Main.MsInsertData();
						goto IL_0b34;
						IL_0b34:
						num2 = 94;
						dataRow = dataTable.NewRow();
						goto IL_0b40;
						IL_0b40:
						num2 = 95;
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						goto IL_0b55;
						IL_0b55:
						num2 = 96;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						goto IL_0b6a;
						IL_0b6a:
						num2 = 97;
						dataRow["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_0b7f;
						IL_0b7f:
						num2 = 98;
						dataRow["VCH_NO"] = tHdVchNo.Text;
						goto IL_0b9a;
						IL_0b9a:
						num2 = 99;
						dataRow["BOOK_NAME"] = FormName;
						goto IL_0bb0;
						IL_0bb0:
						num2 = 100;
						dataTable.Rows.Add(dataRow);
						goto IL_0bc2;
						IL_0bc2:
						num2 = 101;
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
						goto IL_0bd2;
						IL_0bd2:
						num2 = 102;
						dataTable.Clear();
						goto IL_0bdd;
						IL_0bdd:
						num2 = 103;
						DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_0c51;
						IL_0c51:
						num2 = 104;
						RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_0c64;
						IL_0c64:
						num2 = 105;
						DC_Main.MsInsertData();
						goto IL_0c6d;
						IL_0c6d:
						num2 = 106;
						dataRow2 = RsData.NewRow();
						goto IL_0c7d;
						IL_0c7d:
						num2 = 107;
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						goto IL_0c92;
						IL_0c92:
						num2 = 108;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						goto IL_0ca7;
						IL_0ca7:
						num2 = 109;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_0cbc;
						IL_0cbc:
						num2 = 110;
						dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_0cd1;
						IL_0cd1:
						num2 = 111;
						dataRow2["VCH_NO"] = tVchNo.Text;
						goto IL_0cec;
						IL_0cec:
						num2 = 112;
						dataRow2["VCH_DATE"] = mVchDate.Text;
						goto IL_0d07;
						IL_0d07:
						num2 = 113;
						dataRow2["AC_CODE"] = "";
						goto IL_0d1c;
						IL_0d1c:
						num2 = 114;
						dataRow2["VCH_TYPE"] = FormBookSname;
						goto IL_0d32;
						IL_0d32:
						num2 = 115;
						dataRow2["INOUT_TYPE"] = FormBookInOut;
						goto IL_0d48;
						IL_0d48:
						num2 = 116;
						dataRow2["ENTRY_TYPE"] = "O";
						goto IL_0d5d;
						IL_0d5d:
						num2 = 117;
						dataRow2["BOOK_NAME"] = FormMainBook;
						goto IL_0d73;
						IL_0d73:
						num2 = 118;
						dataRow2["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_0d8e;
						IL_0d8e:
						num2 = 119;
						dataRow2["TO_CO_BOOK"] = tToBook.Text;
						goto IL_0da9;
						IL_0da9:
						num2 = 120;
						dataRow2["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_0dc4;
						IL_0dc4:
						num2 = 121;
						dataRow2["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_0dd9;
						IL_0dd9:
						num2 = 122;
						dataRow2["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_0dee;
						IL_0dee:
						num2 = 123;
						dataRow2["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_0e09;
						IL_0e09:
						num2 = 124;
						dataRow2["STK_TRFR"] = "N";
						goto IL_0e1e;
						IL_0e1e:
						num2 = 125;
						dataRow2["TOT_GWT"] = Conversion.Val(MSG_TOT[0, 13]);
						goto IL_0e46;
						IL_0e46:
						num2 = 126;
						dataRow2["TOT_NWT"] = Conversion.Val(MSG_TOT[0, 15]);
						goto IL_0e6e;
						IL_0e6e:
						num2 = 127;
						dataRow2["TOT_FINE"] = Conversion.Val(MSG_TOT[0, 20]);
						goto IL_0e96;
						IL_0e96:
						num2 = 128;
						dataRow2["TOT_LBR"] = Conversion.Val(MSG_TOT[0, 27]);
						goto IL_0ec1;
						IL_0ec1:
						num2 = 129;
						dataRow2["TOT_OTH"] = Conversion.Val(MSG_TOT[0, 28]);
						goto IL_0eec;
						IL_0eec:
						num2 = 130;
						dataRow2["TOT_NET_AMT"] = Conversion.Val(MSG_TOT[0, 29]);
						goto IL_0f17;
						IL_0f17:
						num2 = 131;
						dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_0f35;
						IL_0f35:
						num2 = 132;
						dataRow2["EMP_CODE"] = tEmpCode.Text;
						goto IL_0f53;
						IL_0f53:
						num2 = 133;
						dataRow2["VCH_DESC"] = tVchDesc.Text;
						goto IL_0f71;
						IL_0f71:
						num2 = 134;
						dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_0fa4;
						IL_0fa4:
						num2 = 135;
						dataRow2["DATA_TRFR"] = "N";
						goto IL_0fbc;
						IL_0fbc:
						num2 = 136;
						dataRow2["MAIN_USER"] = MainUser;
						goto IL_0fd5;
						IL_0fd5:
						num2 = 137;
						dataRow2["USER_UPDATE"] = "N";
						goto IL_0fed;
						IL_0fed:
						num2 = 138;
						dataRow2["USER_DELETE"] = "N";
						goto IL_1005;
						IL_1005:
						num2 = 139;
						RsData.Rows.Add(dataRow2);
						goto IL_101e;
						IL_101e:
						num2 = 140;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
						goto IL_1035;
						IL_1035:
						num2 = 141;
						RsData.Clear();
						goto IL_1049;
						IL_1049:
						num2 = 143;
						DC_Main.RsQry = "SELECT * FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_10c0;
						IL_10c0:
						num2 = 144;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_10d6;
						IL_10d6:
						num2 = 145;
						DC_Main.MsInsertData();
						goto IL_10e2;
						IL_10e2:
						num2 = 146;
						dataRow3 = RsDetl.NewRow();
						goto IL_10f5;
						IL_10f5:
						num2 = 147;
						num6 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_2006;
						IL_2006:
						if (DC_Main.i <= num6)
						{
							goto IL_1116;
						}
						goto IL_2012;
						IL_2012:
						num2 = 257;
						DC_Main.RsQry = "SELECT * FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_2089;
						IL_2089:
						num2 = 258;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_209f;
						IL_209f:
						num2 = 259;
						DC_Main.MsInsertData();
						goto IL_20ab;
						IL_20ab:
						num2 = 260;
						dataRow4 = RsIdtl.NewRow();
						goto IL_20be;
						IL_20be:
						num2 = 261;
						num5 = 0;
						goto IL_20c6;
						IL_20c6:
						num2 = 262;
						num7 = DtIdtl.Rows.Count - 1;
						num8 = 0;
						goto IL_2aa6;
						IL_2aa6:
						if (num8 <= num7)
						{
							goto IL_20e9;
						}
						goto IL_2aaf;
						IL_2aaf:
						num2 = 326;
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_2b26;
						IL_2b26:
						num2 = 327;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_2b37;
						IL_2b37:
						num2 = 328;
						Ac_Stock.OutWord_Stk(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_2b53;
						IL_2b53:
						num2 = 329;
						DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_2bca;
						IL_2bca:
						num2 = 330;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_2bdb;
						IL_2bdb:
						num2 = 331;
						Ac_Stock.Dm_Out_Detl(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_2bf9;
						IL_20e9:
						num2 = 263;
						dtIdtl = DtIdtl;
						goto IL_20f7;
						IL_20f7:
						num2 = 264;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][12])) != 0.0)
						{
							goto IL_217d;
						}
						goto IL_2a97;
						IL_217d:
						num2 = 265;
						num9 = MSG.Rows - 1;
						DC_Main.M = 1;
						goto IL_2204;
						IL_2204:
						if (DC_Main.M <= num9)
						{
							goto IL_219a;
						}
						goto IL_220d;
						IL_219a:
						num2 = 266;
						if (Conversion.Val(MSG[DC_Main.M, 49]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][16])))
						{
							goto IL_21e2;
						}
						goto IL_21f2;
						IL_21e2:
						num2 = 267;
						num5 = DC_Main.M;
						goto IL_220d;
						IL_220d:
						num2 = 271;
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						goto IL_2225;
						IL_2225:
						num2 = 272;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						goto IL_223d;
						IL_223d:
						num2 = 273;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_2255;
						IL_2255:
						num2 = 274;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_226d;
						IL_226d:
						num2 = 275;
						dataRow4["VCH_NO"] = tVchNo.Text;
						goto IL_228b;
						IL_228b:
						num2 = 276;
						dataRow4["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_22a9;
						IL_22a9:
						num2 = 277;
						dataRow4["TO_CO_BOOK"] = tToBook.Text;
						goto IL_22c7;
						IL_22c7:
						num2 = 278;
						dataRow4["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_22e5;
						IL_22e5:
						num2 = 279;
						dataRow4["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_22fd;
						IL_22fd:
						num2 = 280;
						dataRow4["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_2315;
						IL_2315:
						num2 = 281;
						dataRow4["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_2333;
						IL_2333:
						num2 = 282;
						dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_2351;
						IL_2351:
						num2 = 283;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						goto IL_236f;
						IL_236f:
						num2 = 284;
						dataRow4["AC_CODE"] = tToLcCode.Text;
						goto IL_238d;
						IL_238d:
						num2 = 285;
						dataRow4["VCH_TYPE"] = FormBookSname;
						goto IL_23a6;
						IL_23a6:
						num2 = 286;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						goto IL_23bf;
						IL_23bf:
						num2 = 287;
						dataRow4["ENTRY_TYPE"] = "T";
						goto IL_23d7;
						IL_23d7:
						num2 = 288;
						dataRow4["BOOK_NAME"] = FormMainBook;
						goto IL_23f0;
						IL_23f0:
						num2 = 289;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][16]));
						goto IL_242b;
						IL_242b:
						num2 = 290;
						dataRow4["TAG_NO"] = MSG[num5, 1];
						goto IL_244b;
						IL_244b:
						num2 = 291;
						dataRow4["VCH_SRNO"] = MSG[num5, 43];
						goto IL_246c;
						IL_246c:
						num2 = 292;
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][0]));
						goto IL_24a6;
						IL_24a6:
						num2 = 293;
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][1]);
						goto IL_24d6;
						IL_24d6:
						num2 = 294;
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][3]));
						goto IL_2510;
						IL_2510:
						num2 = 295;
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][4]));
						goto IL_254a;
						IL_254a:
						num2 = 296;
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][5]));
						goto IL_2584;
						IL_2584:
						num2 = 297;
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][6]));
						goto IL_25be;
						IL_25be:
						num2 = 298;
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][7]);
						goto IL_25ee;
						IL_25ee:
						num2 = 299;
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][8]));
						goto IL_2628;
						IL_2628:
						num2 = 300;
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][9]));
						goto IL_2663;
						IL_2663:
						num2 = 301;
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][10]));
						goto IL_269e;
						IL_269e:
						num2 = 302;
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][11]));
						goto IL_26d9;
						IL_26d9:
						num2 = 303;
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][12]));
						goto IL_2714;
						IL_2714:
						num2 = 304;
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][13]));
						goto IL_274f;
						IL_274f:
						num2 = 305;
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][15]);
						goto IL_2780;
						IL_2780:
						num2 = 306;
						dataRow4["MAIN_USER"] = MainUser;
						goto IL_2799;
						IL_2799:
						num2 = 307;
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][17]);
						goto IL_27ca;
						IL_27ca:
						num2 = 308;
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][18]);
						goto IL_27fb;
						IL_27fb:
						num2 = 309;
						dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][19]);
						goto IL_282c;
						IL_282c:
						num2 = 310;
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][20]);
						goto IL_285d;
						IL_285d:
						num2 = 311;
						dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][21]);
						goto IL_288e;
						IL_288e:
						num2 = 312;
						dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][22]);
						goto IL_28bf;
						IL_28bf:
						num2 = 313;
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][23]);
						goto IL_28f0;
						IL_28f0:
						num2 = 314;
						dataRow4["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][24]));
						goto IL_292b;
						IL_292b:
						num2 = 315;
						dataRow4["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][25]));
						goto IL_2966;
						IL_2966:
						num2 = 316;
						dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][26]));
						goto IL_29a1;
						IL_29a1:
						num2 = 317;
						dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][27]));
						goto IL_29dc;
						IL_29dc:
						num2 = 318;
						dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][28]));
						goto IL_2a17;
						IL_2a17:
						num2 = 319;
						dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num8][29]));
						goto IL_2a52;
						IL_2a52:
						num2 = 320;
						RsIdtl.Rows.Add(dataRow4);
						goto IL_2a6b;
						IL_2a6b:
						num2 = 321;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						goto IL_2a82;
						IL_2a82:
						num2 = 322;
						RsIdtl.Clear();
						goto IL_2a97;
						IL_21f2:
						num2 = 270;
						DC_Main.M++;
						goto IL_2204;
						IL_2a97:
						dtIdtl = null;
						goto IL_2a9a;
						IL_2a9a:
						num2 = 325;
						num8++;
						goto IL_2aa6;
						IL_1116:
						num2 = 148;
						val2 = MSG;
						goto IL_1124;
						IL_1124:
						num2 = 149;
						if (((Operators.CompareString(val2[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(val2[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(val2[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(val2[DC_Main.i, 12]) + Conversion.Val(val2[DC_Main.i, 13]) + Conversion.Val(val2[DC_Main.i, 27]) + Conversion.Val(val2[DC_Main.i, 28]) != 0.0))
						{
							goto IL_11ea;
						}
						goto IL_1ff1;
						IL_11ea:
						num2 = 150;
						dataRow3["CO_CODE"] = DC_Main.MCo_code;
						goto IL_1202;
						IL_1202:
						num2 = 151;
						dataRow3["LC_CODE"] = DC_Main.MLc_code;
						goto IL_121a;
						IL_121a:
						num2 = 152;
						dataRow3["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_1232;
						IL_1232:
						num2 = 153;
						dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_124a;
						IL_124a:
						num2 = 154;
						dataRow3["VCH_NO"] = tVchNo.Text;
						goto IL_1268;
						IL_1268:
						num2 = 155;
						dataRow3["VCH_DATE"] = mVchDate.Text;
						goto IL_1286;
						IL_1286:
						num2 = 156;
						dataRow3["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_12a4;
						IL_12a4:
						num2 = 157;
						dataRow3["TO_CO_BOOK"] = tToBook.Text;
						goto IL_12c2;
						IL_12c2:
						num2 = 158;
						dataRow3["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_12e0;
						IL_12e0:
						num2 = 159;
						dataRow3["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_12f8;
						IL_12f8:
						num2 = 160;
						dataRow3["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_1310;
						IL_1310:
						num2 = 161;
						dataRow3["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_132e;
						IL_132e:
						num2 = 162;
						dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_134c;
						IL_134c:
						num2 = 163;
						dataRow3["AC_CODE"] = tToLcCode.Text;
						goto IL_136a;
						IL_136a:
						num2 = 164;
						dataRow3["VCH_TYPE"] = FormBookSname;
						goto IL_1383;
						IL_1383:
						num2 = 165;
						dataRow3["INOUT_TYPE"] = FormBookInOut;
						goto IL_139c;
						IL_139c:
						num2 = 166;
						dataRow3["ENTRY_TYPE"] = "O";
						goto IL_13b4;
						IL_13b4:
						num2 = 167;
						dataRow3["BOOK_NAME"] = FormMainBook;
						goto IL_13cd;
						IL_13cd:
						num2 = 168;
						dataRow3["SR_NO"] = Conversion.Val(val2[DC_Main.i, 0]);
						goto IL_13f7;
						IL_13f7:
						num2 = 169;
						dataRow3["OLD_SRNO"] = Conversion.Val(val2[DC_Main.i, 49]);
						goto IL_1422;
						IL_1422:
						num2 = 170;
						dataRow3["IT_CODE"] = val2[DC_Main.i, 3];
						goto IL_1442;
						IL_1442:
						num2 = 171;
						if (Operators.CompareString(val2[DC_Main.i, 1], "", false) == 0)
						{
							goto IL_1469;
						}
						goto IL_1485;
						IL_1469:
						num2 = 172;
						dataRow3["TAG_NO"] = "N";
						goto IL_14a6;
						IL_1485:
						num2 = 174;
						dataRow3["TAG_NO"] = val2[DC_Main.i, 1];
						goto IL_14a6;
						IL_14a6:
						num2 = 176;
						dataRow3["ITM_LOT"] = val2[DC_Main.i, 2];
						goto IL_14c6;
						IL_14c6:
						num2 = 177;
						dataRow3["TBL_CODE"] = val2[DC_Main.i, 4];
						goto IL_14e6;
						IL_14e6:
						num2 = 178;
						dataRow3["DESIGN_NO"] = val2[DC_Main.i, 5];
						goto IL_1506;
						IL_1506:
						num2 = 179;
						dataRow3["ITM_STYLE"] = val2[DC_Main.i, 6];
						goto IL_1526;
						IL_1526:
						num2 = 180;
						dataRow3["ITM_COLOR"] = val2[DC_Main.i, 7];
						goto IL_1546;
						IL_1546:
						num2 = 181;
						dataRow3["HM_ID"] = val2[DC_Main.i, 9];
						goto IL_1567;
						IL_1567:
						num2 = 182;
						dataRow3["ITM_SIZE"] = val2[DC_Main.i, 8];
						goto IL_1587;
						IL_1587:
						num2 = 183;
						dataRow3["BAG_WT"] = Conversion.Val(val2[DC_Main.i, 11]);
						goto IL_15b2;
						IL_15b2:
						num2 = 184;
						dataRow3["ITM_PCS"] = Conversion.Val(val2[DC_Main.i, 12]);
						goto IL_15dd;
						IL_15dd:
						num2 = 185;
						dataRow3["ITM_GWT"] = Conversion.Val(val2[DC_Main.i, 13]);
						goto IL_1608;
						IL_1608:
						num2 = 186;
						dataRow3["ITM_OTH_WT"] = Conversion.Val(val2[DC_Main.i, 14]);
						goto IL_1633;
						IL_1633:
						num2 = 187;
						dataRow3["ITM_NWT"] = Conversion.Val(val2[DC_Main.i, 15]);
						goto IL_165e;
						IL_165e:
						num2 = 188;
						dataRow3["ITM_GHT_WT"] = Conversion.Val(val2[DC_Main.i, 17]);
						goto IL_1689;
						IL_1689:
						num2 = 189;
						dataRow3["ITM_TOUCH"] = Conversion.Val(val2[DC_Main.i, 18]);
						goto IL_16b4;
						IL_16b4:
						num2 = 190;
						dataRow3["ITM_WEST_PRC"] = Conversion.Val(val2[DC_Main.i, 19]);
						goto IL_16df;
						IL_16df:
						num2 = 191;
						dataRow3["ITM_FINE"] = Conversion.Val(val2[DC_Main.i, 20]);
						goto IL_170a;
						IL_170a:
						num2 = 192;
						dataRow3["LBR_CODE"] = val2[DC_Main.i, 23];
						goto IL_172b;
						IL_172b:
						num2 = 193;
						dataRow3["LBR_PRC"] = Conversion.Val(val2[DC_Main.i, 24]);
						goto IL_1756;
						IL_1756:
						num2 = 194;
						dataRow3["LBR_TYPE"] = val2[DC_Main.i, 25];
						goto IL_1777;
						IL_1777:
						num2 = 195;
						dataRow3["LBR_RATE"] = Conversion.Val(val2[DC_Main.i, 26]);
						goto IL_17a2;
						IL_17a2:
						num2 = 196;
						dataRow3["LBR_AMT"] = Conversion.Val(val2[DC_Main.i, 27]);
						goto IL_17cd;
						IL_17cd:
						num2 = 197;
						dataRow3["OTH_AMT"] = Conversion.Val(val2[DC_Main.i, 28]);
						goto IL_17f8;
						IL_17f8:
						num2 = 198;
						dataRow3["ITM_RATE"] = Conversion.Val(val2[DC_Main.i, 44]);
						goto IL_1823;
						IL_1823:
						num2 = 199;
						dataRow3["ITM_AMT"] = Conversion.Val(val2[DC_Main.i, 45]);
						goto IL_184e;
						IL_184e:
						num2 = 200;
						dataRow3["ITM_MARGIN"] = Conversion.Val(val2[DC_Main.i, 46]);
						goto IL_1879;
						IL_1879:
						num2 = 201;
						dataRow3["ITM_MRP"] = Conversion.Val(val2[DC_Main.i, 30]);
						goto IL_18a4;
						IL_18a4:
						num2 = 202;
						dataRow3["KR_NET_WT"] = Conversion.Val(val2[DC_Main.i, 33]);
						goto IL_18cf;
						IL_18cf:
						num2 = 203;
						dataRow3["KR_TOUCH"] = Conversion.Val(val2[DC_Main.i, 36]);
						goto IL_18fa;
						IL_18fa:
						num2 = 204;
						dataRow3["KR_WEST_PRC"] = Conversion.Val(val2[DC_Main.i, 37]);
						goto IL_1925;
						IL_1925:
						num2 = 205;
						dataRow3["KR_FINE"] = Conversion.Val(val2[DC_Main.i, 38]);
						goto IL_1950;
						IL_1950:
						num2 = 206;
						dataRow3["KR_OTH_WT"] = Conversion.Val(val2[DC_Main.i, 32]);
						goto IL_197b;
						IL_197b:
						num2 = 207;
						dataRow3["KR_GHT_PRC"] = Conversion.Val(val2[DC_Main.i, 34]);
						goto IL_19a6;
						IL_19a6:
						num2 = 208;
						dataRow3["KR_GHT_WT"] = Conversion.Val(val2[DC_Main.i, 35]);
						goto IL_19d1;
						IL_19d1:
						num2 = 209;
						dataRow3["KR_LBR_RATE"] = Conversion.Val(val2[DC_Main.i, 39]);
						goto IL_19fc;
						IL_19fc:
						num2 = 210;
						dataRow3["KR_LBR_AMT"] = Conversion.Val(val2[DC_Main.i, 40]);
						goto IL_1a27;
						IL_1a27:
						num2 = 211;
						dataRow3["KR_OTH_AMT"] = Conversion.Val(val2[DC_Main.i, 41]);
						goto IL_1a52;
						IL_1a52:
						num2 = 212;
						dataRow3["KR_COST"] = Conversion.Val(val2[DC_Main.i, 42]);
						goto IL_1a7d;
						IL_1a7d:
						num2 = 213;
						if (val2[29] == 0)
						{
							goto IL_1a95;
						}
						goto IL_1ac4;
						IL_1a95:
						num2 = 214;
						dataRow3["TAG_COST"] = Conversion.Val(val2[DC_Main.i, 94]);
						goto IL_1af0;
						IL_1ac4:
						num2 = 216;
						dataRow3["TAG_COST"] = Conversion.Val(val2[DC_Main.i, 29]);
						goto IL_1af0;
						IL_1af0:
						num2 = 218;
						dataRow3["ITM_REMARK"] = val2[DC_Main.i, 69];
						goto IL_1b11;
						IL_1b11:
						num2 = 219;
						dataRow3["KR_NAME"] = val2[DC_Main.i, 31];
						goto IL_1b32;
						IL_1b32:
						num2 = 220;
						dataRow3["RATE_TYPE"] = val2[DC_Main.i, 50];
						goto IL_1b53;
						IL_1b53:
						num2 = 221;
						dataRow3["IT_TYPE"] = val2[DC_Main.i, 51];
						goto IL_1b74;
						IL_1b74:
						num2 = 222;
						dataRow3["PR_CODE"] = val2[DC_Main.i, 53];
						goto IL_1b95;
						IL_1b95:
						num2 = 223;
						dataRow3["VCH_SRNO"] = Conversion.Val(val2[DC_Main.i, 43]);
						goto IL_1bc0;
						IL_1bc0:
						num2 = 224;
						dataRow3["HM_ID2"] = val2[DC_Main.i, 70];
						goto IL_1be1;
						IL_1be1:
						num2 = 225;
						dataRow3["HM_ID3"] = val2[DC_Main.i, 71];
						goto IL_1c02;
						IL_1c02:
						num2 = 226;
						dataRow3["HM_ID4"] = val2[DC_Main.i, 72];
						goto IL_1c23;
						IL_1c23:
						num2 = 227;
						dataRow3["HM_ID_WT"] = Conversion.Val(val2[DC_Main.i, 73]);
						goto IL_1c4e;
						IL_1c4e:
						num2 = 228;
						dataRow3["HM_ID2_WT"] = Conversion.Val(val2[DC_Main.i, 74]);
						goto IL_1c79;
						IL_1c79:
						num2 = 229;
						dataRow3["HM_ID3_WT"] = Conversion.Val(val2[DC_Main.i, 75]);
						goto IL_1ca4;
						IL_1ca4:
						num2 = 230;
						dataRow3["HM_ID4_WT"] = Conversion.Val(val2[DC_Main.i, 76]);
						goto IL_1ccf;
						IL_1ccf:
						num2 = 231;
						dataRow3["JDT_JDT_WT"] = Conversion.Val(val2[DC_Main.i, 77]);
						goto IL_1cfa;
						IL_1cfa:
						num2 = 232;
						dataRow3["JDT_GHT_WT"] = Conversion.Val(val2[DC_Main.i, 78]);
						goto IL_1d25;
						IL_1d25:
						num2 = 233;
						dataRow3["JDT_KUN_WT"] = Conversion.Val(val2[DC_Main.i, 79]);
						goto IL_1d50;
						IL_1d50:
						num2 = 234;
						dataRow3["JDT_KUN_TOUCH"] = Conversion.Val(val2[DC_Main.i, 80]);
						goto IL_1d7b;
						IL_1d7b:
						num2 = 235;
						dataRow3["JDT_KUN_NET"] = Conversion.Val(val2[DC_Main.i, 81]);
						goto IL_1da6;
						IL_1da6:
						num2 = 236;
						dataRow3["JDT_WAX_WT"] = Conversion.Val(val2[DC_Main.i, 82]);
						goto IL_1dd1;
						IL_1dd1:
						num2 = 237;
						dataRow3["KR_WAX_WT"] = Conversion.Val(val2[DC_Main.i, 83]);
						goto IL_1dfc;
						IL_1dfc:
						num2 = 238;
						dataRow3["DESIGN_IMG_ID"] = val2[DC_Main.i, 85];
						goto IL_1e1d;
						IL_1e1d:
						num2 = 239;
						dataRow3["ORD_YRCD"] = val2[DC_Main.i, 87];
						goto IL_1e3e;
						IL_1e3e:
						num2 = 240;
						dataRow3["ORD_DBCD"] = val2[DC_Main.i, 88];
						goto IL_1e5f;
						IL_1e5f:
						num2 = 241;
						dataRow3["ORD_NO"] = val2[DC_Main.i, 89];
						goto IL_1e80;
						IL_1e80:
						num2 = 242;
						dataRow3["ORD_AC"] = val2[DC_Main.i, 91];
						goto IL_1ea1;
						IL_1ea1:
						num2 = 243;
						dataRow3["ORD_LC_CODE"] = val2[DC_Main.i, 86];
						goto IL_1ec2;
						IL_1ec2:
						num2 = 244;
						dataRow3["ORD_SRNO"] = Conversion.Val(val2[DC_Main.i, 90]);
						goto IL_1eed;
						IL_1eed:
						num2 = 245;
						dataRow3["NEW_VCH_SRNO"] = 0;
						goto IL_1f06;
						IL_1f06:
						num2 = 246;
						dataRow3["EMP_ISU"] = val2[DC_Main.i, 84];
						goto IL_1f27;
						IL_1f27:
						num2 = 247;
						dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_1f5a;
						IL_1f5a:
						num2 = 248;
						dataRow3["DATA_TRFR"] = "N";
						goto IL_1f72;
						IL_1f72:
						num2 = 249;
						dataRow3["DATA_TYPE"] = val2[DC_Main.i, 93];
						goto IL_1f93;
						IL_1f93:
						num2 = 250;
						dataRow3["MAIN_USER"] = MainUser;
						goto IL_1fac;
						IL_1fac:
						num2 = 251;
						RsDetl.Rows.Add(dataRow3);
						goto IL_1fc5;
						IL_1fc5:
						num2 = 252;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						goto IL_1fdc;
						IL_1fdc:
						num2 = 253;
						RsDetl.Clear();
						goto IL_1ff1;
						IL_1ff1:
						val2 = null;
						goto IL_1ff4;
						IL_1ff4:
						num2 = 256;
						DC_Main.i++;
						goto IL_2006;
						IL_2bf9:
						num2 = 333;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
						goto IL_2c7d;
						IL_2c7d:
						num2 = 334;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
						goto IL_2d01;
						IL_2d01:
						num2 = 335;
						DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
						goto IL_2d85;
						IL_2d85:
						num2 = 336;
						if ((Conversion.Val(MSG_TOT[0, 30]) != 0.0) | (Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 27]) + Conversion.Val(MSG_TOT[0, 28]) != 0.0))
						{
							goto IL_2e13;
						}
						goto IL_33a8;
						IL_2e13:
						num2 = 337;
						DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
						goto IL_2e96;
						IL_2e96:
						num2 = 338;
						RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_2eac;
						IL_2eac:
						num2 = 339;
						DC_Main.MsInsertData();
						goto IL_2eb8;
						IL_2eb8:
						num2 = 340;
						dataRow5 = RsData.NewRow();
						goto IL_2ecb;
						IL_2ecb:
						num2 = 341;
						dataRow5["CO_CODE"] = DC_Main.MCo_code;
						goto IL_2ee3;
						IL_2ee3:
						num2 = 342;
						dataRow5["LC_CODE"] = tToLcCode.Text;
						goto IL_2f01;
						IL_2f01:
						num2 = 343;
						dataRow5["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_2f19;
						IL_2f19:
						num2 = 344;
						dataRow5["CO_BOOK"] = tToBook.Text;
						goto IL_2f37;
						IL_2f37:
						num2 = 345;
						dataRow5["VCH_NO"] = tToVchNo.Text;
						goto IL_2f55;
						IL_2f55:
						num2 = 346;
						dataRow5["HD_VCH_NO"] = tToVchNo.Text;
						goto IL_2f73;
						IL_2f73:
						num2 = 347;
						dataRow5["VCH_DATE"] = mVchDate.Text;
						goto IL_2f91;
						IL_2f91:
						num2 = 348;
						dataRow5["AC_CODE"] = "";
						goto IL_2fa9;
						IL_2fa9:
						num2 = 349;
						dataRow5["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_2fc7;
						IL_2fc7:
						num2 = 350;
						dataRow5["TO_CO_BOOK"] = tToBook.Text;
						goto IL_2fe5;
						IL_2fe5:
						num2 = 351;
						dataRow5["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_3003;
						IL_3003:
						num2 = 352;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_3023;
						}
						goto IL_3081;
						IL_3023:
						num2 = 353;
						dataRow5["FROM_LC_CODE"] = tFrmLc.Text;
						goto IL_3041;
						IL_3041:
						num2 = 354;
						dataRow5["FROM_CO_BOOK"] = tFrombook.Text;
						goto IL_305f;
						IL_305f:
						num2 = 355;
						dataRow5["FROM_VCH_NO"] = tFromVchNo.Text;
						goto IL_30d0;
						IL_3081:
						num2 = 357;
						dataRow5["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_3099;
						IL_3099:
						num2 = 358;
						dataRow5["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_30b1;
						IL_30b1:
						num2 = 359;
						dataRow5["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_30d0;
						IL_30d0:
						num2 = 361;
						dataRow5["VCH_TYPE"] = "IN";
						goto IL_30e8;
						IL_30e8:
						num2 = 362;
						dataRow5["INOUT_TYPE"] = "I";
						goto IL_3100;
						IL_3100:
						num2 = 363;
						dataRow5["ENTRY_TYPE"] = "I";
						goto IL_3118;
						IL_3118:
						num2 = 364;
						dataRow5["BOOK_NAME"] = "INWORD";
						goto IL_3130;
						IL_3130:
						num2 = 365;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_3150;
						}
						goto IL_316c;
						IL_3150:
						num2 = 366;
						dataRow5["STK_TRFR"] = "Y";
						goto IL_31c2;
						IL_316c:
						num2 = 368;
						if (Operators.CompareString(LcStkTrfr, "Y", false) == 0)
						{
							goto IL_318c;
						}
						goto IL_31a8;
						IL_318c:
						num2 = 369;
						dataRow5["STK_TRFR"] = "Y";
						goto IL_31c2;
						IL_31a8:
						num2 = 371;
						dataRow5["STK_TRFR"] = "N";
						goto IL_31c2;
						IL_31c2:
						num2 = 374;
						dataRow5["TOT_GWT"] = Conversion.Val(MSG_TOT[0, 13]);
						goto IL_31ed;
						IL_31ed:
						num2 = 375;
						dataRow5["TOT_NWT"] = Conversion.Val(MSG_TOT[0, 15]);
						goto IL_3218;
						IL_3218:
						num2 = 376;
						dataRow5["TOT_FINE"] = Conversion.Val(MSG_TOT[0, 20]);
						goto IL_3243;
						IL_3243:
						num2 = 377;
						dataRow5["TOT_LBR"] = Conversion.Val(MSG_TOT[0, 27]);
						goto IL_326e;
						IL_326e:
						num2 = 378;
						dataRow5["TOT_OTH"] = Conversion.Val(MSG_TOT[0, 28]);
						goto IL_3299;
						IL_3299:
						num2 = 379;
						dataRow5["TOT_NET_AMT"] = Conversion.Val(MSG_TOT[0, 29]);
						goto IL_32c4;
						IL_32c4:
						num2 = 380;
						dataRow5["EMP_CODE"] = tEmpCode.Text;
						goto IL_32e2;
						IL_32e2:
						num2 = 381;
						dataRow5["VCH_DESC"] = tVchDesc.Text;
						goto IL_3300;
						IL_3300:
						num2 = 382;
						dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_3333;
						IL_3333:
						num2 = 383;
						dataRow5["DATA_TRFR"] = "N";
						goto IL_334b;
						IL_334b:
						num2 = 384;
						dataRow5["MAIN_USER"] = MainUser;
						goto IL_3364;
						IL_3364:
						num2 = 385;
						RsData.Rows.Add(dataRow5);
						goto IL_337d;
						IL_337d:
						num2 = 386;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
						goto IL_3394;
						IL_3394:
						num2 = 387;
						RsData.Clear();
						goto IL_33a8;
						IL_33a8:
						num2 = 389;
						DC_Main.RsQry = "SELECT * FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
						goto IL_342b;
						IL_342b:
						num2 = 390;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_3441;
						IL_3441:
						num2 = 391;
						DC_Main.MsInsertData();
						goto IL_344d;
						IL_344d:
						num2 = 392;
						dataRow6 = RsDetl.NewRow();
						goto IL_3460;
						IL_3460:
						num2 = 393;
						num10 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_4478;
						IL_4478:
						if (DC_Main.i <= num10)
						{
							goto IL_3481;
						}
						goto IL_4484;
						IL_4484:
						num2 = 509;
						DC_Main.RsQry = "SELECT * FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
						goto IL_4507;
						IL_4507:
						num2 = 510;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_451d;
						IL_451d:
						num2 = 511;
						DC_Main.MsInsertData();
						goto IL_4529;
						IL_4529:
						num2 = 512;
						dataRow7 = RsIdtl.NewRow();
						goto IL_453c;
						IL_453c:
						num2 = 513;
						num5 = 0;
						goto IL_4544;
						IL_4544:
						num2 = 514;
						num11 = DtIdtl.Rows.Count - 1;
						num12 = 0;
						goto IL_4fa6;
						IL_4fa6:
						if (num12 <= num11)
						{
							goto IL_4567;
						}
						goto IL_4faf;
						IL_4faf:
						num2 = 584;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_4fd2;
						}
						goto IL_76a8;
						IL_4fd2:
						num2 = 585;
						DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
						goto IL_5056;
						IL_5056:
						num2 = 586;
						DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
						goto IL_50da;
						IL_50da:
						num2 = 587;
						DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
						goto IL_515d;
						IL_515d:
						num2 = 588;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_5173;
						IL_5173:
						num2 = 589;
						DC_Main.MsInsertData();
						goto IL_517f;
						IL_517f:
						num2 = 590;
						dataRow8 = RsDetl.NewRow();
						goto IL_5192;
						IL_5192:
						num2 = 591;
						num13 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_6161;
						IL_6161:
						if (DC_Main.i <= num13)
						{
							goto IL_51b3;
						}
						goto IL_616d;
						IL_616d:
						num2 = 699;
						DC_Main.ExeQuteDc("DELETE FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						goto IL_61e5;
						IL_61e5:
						num2 = 700;
						DC_Main.RsQry = "SELECT * FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						goto IL_625c;
						IL_625c:
						num2 = 701;
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_6272;
						IL_6272:
						num2 = 702;
						DC_Main.MsInsertData();
						goto IL_627e;
						IL_627e:
						num2 = 703;
						dataRow9 = RsDetl.NewRow();
						goto IL_6291;
						IL_6291:
						num2 = 704;
						num14 = MSG.Rows - 1;
						DC_Main.i = 1;
						goto IL_6c15;
						IL_6c15:
						if (DC_Main.i <= num14)
						{
							goto IL_62b2;
						}
						goto IL_6c21;
						IL_6c21:
						num2 = 770;
						DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
						goto IL_6ca4;
						IL_6ca4:
						num2 = 771;
						RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_6cba;
						IL_6cba:
						num2 = 772;
						DC_Main.MsInsertData();
						goto IL_6cc6;
						IL_6cc6:
						num2 = 773;
						dataRow10 = RsIdtl.NewRow();
						goto IL_6cd9;
						IL_6cd9:
						num2 = 774;
						num5 = 0;
						goto IL_6ce1;
						IL_6ce1:
						num2 = 775;
						num15 = DtIdtl.Rows.Count - 1;
						num16 = 0;
						goto IL_769d;
						IL_769d:
						if (num16 <= num15)
						{
							goto IL_6d04;
						}
						goto IL_76a8;
						IL_6d04:
						num2 = 776;
						dtIdtl2 = DtIdtl;
						goto IL_6d12;
						IL_6d12:
						num2 = 777;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][12])) != 0.0)
						{
							goto IL_6d98;
						}
						goto IL_768e;
						IL_6d98:
						num2 = 778;
						num17 = MSG.Rows - 1;
						DC_Main.M = 1;
						goto IL_6e1f;
						IL_6e1f:
						if (DC_Main.M <= num17)
						{
							goto IL_6db5;
						}
						goto IL_6e28;
						IL_6db5:
						num2 = 779;
						if (Conversion.Val(MSG[DC_Main.M, 49]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][16])))
						{
							goto IL_6dfd;
						}
						goto IL_6e0d;
						IL_6dfd:
						num2 = 780;
						num5 = DC_Main.M;
						goto IL_6e28;
						IL_6e28:
						num2 = 784;
						if (Operators.CompareString(MSG[num5, 1], "", false) != 0)
						{
							goto IL_6e52;
						}
						goto IL_768e;
						IL_6e52:
						num2 = 785;
						dataRow10["CO_CODE"] = DC_Main.MCo_code;
						goto IL_6e6a;
						IL_6e6a:
						num2 = 786;
						dataRow10["LC_CODE"] = tToLcCode.Text;
						goto IL_6e88;
						IL_6e88:
						num2 = 787;
						dataRow10["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_6ea0;
						IL_6ea0:
						num2 = 788;
						dataRow10["CO_BOOK"] = tToBook.Text;
						goto IL_6ebe;
						IL_6ebe:
						num2 = 789;
						dataRow10["VCH_NO"] = tToVchNo.Text;
						goto IL_6edc;
						IL_6edc:
						num2 = 790;
						dataRow10["VCH_DATE"] = mVchDate.Text;
						goto IL_6efa;
						IL_6efa:
						num2 = 791;
						dataRow10["AC_CODE"] = "";
						goto IL_6f12;
						IL_6f12:
						num2 = 792;
						dataRow10["VCH_TYPE"] = "IN";
						goto IL_6f2a;
						IL_6f2a:
						num2 = 793;
						dataRow10["INOUT_TYPE"] = "I";
						goto IL_6f42;
						IL_6f42:
						num2 = 794;
						dataRow10["ENTRY_TYPE"] = "I";
						goto IL_6f5a;
						IL_6f5a:
						num2 = 795;
						dataRow10["BOOK_NAME"] = "INWORD";
						goto IL_6f72;
						IL_6f72:
						num2 = 796;
						dataRow10["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][16]));
						goto IL_6fad;
						IL_6fad:
						num2 = 797;
						dataRow10["TAG_NO"] = MSG[num5, 1];
						goto IL_6fcd;
						IL_6fcd:
						num2 = 798;
						dataRow10["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(num5);
						goto IL_7061;
						IL_7061:
						num2 = 799;
						dataRow10["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][0]));
						goto IL_709b;
						IL_709b:
						num2 = 800;
						dataRow10["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][1]);
						goto IL_70cb;
						IL_70cb:
						num2 = 801;
						dataRow10["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][3]));
						goto IL_7105;
						IL_7105:
						num2 = 802;
						dataRow10["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][4]));
						goto IL_713f;
						IL_713f:
						num2 = 803;
						dataRow10["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][5]));
						goto IL_7179;
						IL_7179:
						num2 = 804;
						dataRow10["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][6]));
						goto IL_71b3;
						IL_71b3:
						num2 = 805;
						dataRow10["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][7]);
						goto IL_71e3;
						IL_71e3:
						num2 = 806;
						dataRow10["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][8]));
						goto IL_721d;
						IL_721d:
						num2 = 807;
						dataRow10["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][9]));
						goto IL_7258;
						IL_7258:
						num2 = 808;
						dataRow10["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][10]));
						goto IL_7293;
						IL_7293:
						num2 = 809;
						dataRow10["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][11]));
						goto IL_72ce;
						IL_72ce:
						num2 = 810;
						dataRow10["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][12]));
						goto IL_7309;
						IL_7309:
						num2 = 811;
						dataRow10["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][13]));
						goto IL_7344;
						IL_7344:
						num2 = 812;
						dataRow10["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][15]);
						goto IL_7375;
						IL_7375:
						num2 = 813;
						dataRow10["MAIN_USER"] = MainUser;
						goto IL_738e;
						IL_738e:
						num2 = 814;
						dataRow10["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][17]);
						goto IL_73bf;
						IL_73bf:
						num2 = 815;
						dataRow10["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][18]);
						goto IL_73f0;
						IL_73f0:
						num2 = 816;
						dataRow10["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][19]);
						goto IL_7421;
						IL_7421:
						num2 = 817;
						dataRow10["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][20]);
						goto IL_7452;
						IL_7452:
						num2 = 818;
						dataRow10["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][21]);
						goto IL_7483;
						IL_7483:
						num2 = 819;
						dataRow10["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][22]);
						goto IL_74b4;
						IL_74b4:
						num2 = 820;
						dataRow10["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][23]);
						goto IL_74e5;
						IL_74e5:
						num2 = 821;
						dataRow10["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][24]));
						goto IL_7520;
						IL_7520:
						num2 = 822;
						dataRow10["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][25]));
						goto IL_755b;
						IL_755b:
						num2 = 823;
						dataRow10["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][26]));
						goto IL_7596;
						IL_7596:
						num2 = 824;
						dataRow10["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][27]));
						goto IL_75d1;
						IL_75d1:
						num2 = 825;
						dataRow10["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][28]));
						goto IL_760c;
						IL_760c:
						num2 = 826;
						dataRow10["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num16][29]));
						goto IL_7647;
						IL_7647:
						num2 = 827;
						RsIdtl.Rows.Add(dataRow10);
						goto IL_7660;
						IL_7660:
						num2 = 828;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						goto IL_7677;
						IL_7677:
						num2 = 829;
						RsIdtl.Clear();
						goto IL_768e;
						IL_6e0d:
						num2 = 783;
						DC_Main.M++;
						goto IL_6e1f;
						IL_768e:
						dtIdtl2 = null;
						goto IL_7691;
						IL_7691:
						num2 = 833;
						num16++;
						goto IL_769d;
						IL_62b2:
						num2 = 705;
						val3 = MSG;
						goto IL_62c0;
						IL_62c0:
						num2 = 706;
						if ((Operators.CompareString(val3[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(val3[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(val3[DC_Main.i, 30]) + (Conversion.Val(val3[DC_Main.i, 12]) + Conversion.Val(val3[DC_Main.i, 13]) + Conversion.Val(val3[DC_Main.i, 27]) + Conversion.Val(val3[DC_Main.i, 28])) != 0.0))
						{
							goto IL_6378;
						}
						goto IL_641f;
						IL_6378:
						num2 = 707;
						Mobile_image_Save(DC_Main.i, Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(val3[DC_Main.i, 49])));
						goto IL_641f;
						IL_641f:
						num2 = 709;
						if ((Operators.CompareString(val3[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(val3[DC_Main.i, 2], "", false) != 0) & (Conversion.Val(val3[DC_Main.i, 13]) + Conversion.Val(val3[DC_Main.i, 27]) + Conversion.Val(val3[DC_Main.i, 28]) != 0.0))
						{
							goto IL_64af;
						}
						goto IL_6c00;
						IL_64af:
						num2 = 710;
						dataRow9["CO_CODE"] = DC_Main.MCo_code;
						goto IL_64c7;
						IL_64c7:
						num2 = 711;
						dataRow9["LC_CODE"] = DC_Main.MLc_code;
						goto IL_64df;
						IL_64df:
						num2 = 712;
						dataRow9["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_64f7;
						IL_64f7:
						num2 = 713;
						dataRow9["CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_650f;
						IL_650f:
						num2 = 714;
						dataRow9["VCH_NO"] = tVchNo.Text;
						goto IL_652d;
						IL_652d:
						num2 = 715;
						dataRow9["HD_VCH_NO"] = tHdVchNo.Text;
						goto IL_654b;
						IL_654b:
						num2 = 716;
						dataRow9["VCH_DATE"] = mVchDate.Text;
						goto IL_6569;
						IL_6569:
						num2 = 717;
						dataRow9["VCH_TYPE"] = FormBookSname;
						goto IL_6582;
						IL_6582:
						num2 = 718;
						dataRow9["INOUT_TYPE"] = FormBookInOut;
						goto IL_659b;
						IL_659b:
						num2 = 719;
						dataRow9["ENTRY_TYPE"] = "I";
						goto IL_65b3;
						IL_65b3:
						num2 = 720;
						dataRow9["BOOK_NAME"] = FormMainBook;
						goto IL_65cc;
						IL_65cc:
						num2 = 721;
						dataRow9["SR_NO"] = Conversion.Val(val3[DC_Main.i, 0]);
						goto IL_65f6;
						IL_65f6:
						num2 = 722;
						dataRow9["IT_CODE"] = val3[DC_Main.i, 3];
						goto IL_6616;
						IL_6616:
						num2 = 723;
						dataRow9["LOT_NO"] = val3[DC_Main.i, 2];
						goto IL_6636;
						IL_6636:
						num2 = 724;
						dataRow9["TBL_CODE"] = val3[DC_Main.i, 4];
						goto IL_6656;
						IL_6656:
						num2 = 725;
						dataRow9["DESIGN_NO"] = val3[DC_Main.i, 5];
						goto IL_6676;
						IL_6676:
						num2 = 726;
						dataRow9["ITM_SIZE"] = val3[DC_Main.i, 8];
						goto IL_6696;
						IL_6696:
						num2 = 727;
						dataRow9["ITM_PCS"] = Conversion.Val(val3[DC_Main.i, 12]);
						goto IL_66c1;
						IL_66c1:
						num2 = 728;
						dataRow9["ITM_GWT"] = Conversion.Val(val3[DC_Main.i, 13]);
						goto IL_66ec;
						IL_66ec:
						num2 = 729;
						dataRow9["ITM_OTH_WT"] = Conversion.Val(val3[DC_Main.i, 14]);
						goto IL_6717;
						IL_6717:
						num2 = 730;
						dataRow9["ITM_NWT"] = Conversion.Val(val3[DC_Main.i, 15]);
						goto IL_6742;
						IL_6742:
						num2 = 731;
						dataRow9["ITM_TOUCH"] = Conversion.Val(val3[DC_Main.i, 18]);
						goto IL_676d;
						IL_676d:
						num2 = 732;
						dataRow9["ITM_WEST_PRC"] = Conversion.Val(val3[DC_Main.i, 19]);
						goto IL_6798;
						IL_6798:
						num2 = 733;
						dataRow9["ITM_FINE"] = Conversion.Val(val3[DC_Main.i, 20]);
						goto IL_67c3;
						IL_67c3:
						num2 = 734;
						dataRow9["KR_OTH_WT"] = Conversion.Val(val3[DC_Main.i, 32]);
						goto IL_67ee;
						IL_67ee:
						num2 = 735;
						if (Conversion.Val((object)val3[33]) == 0.0)
						{
							goto IL_6818;
						}
						goto IL_6847;
						IL_6818:
						num2 = 736;
						dataRow9["KR_NET_WT"] = Conversion.Val(val3[DC_Main.i, 15]);
						goto IL_6873;
						IL_6847:
						num2 = 738;
						dataRow9["KR_NET_WT"] = Conversion.Val(val3[DC_Main.i, 33]);
						goto IL_6873;
						IL_6873:
						num2 = 740;
						if (Conversion.Val(val3[DC_Main.i, 36]) == 0.0)
						{
							goto IL_68a0;
						}
						goto IL_6928;
						IL_68a0:
						num2 = 741;
						dataRow9["KR_TOUCH"] = Conversion.Val(val3[DC_Main.i, 18]);
						goto IL_68cb;
						IL_68cb:
						num2 = 742;
						dataRow9["KR_WEST_PRC"] = Conversion.Val(val3[DC_Main.i, 19]);
						goto IL_68f6;
						IL_68f6:
						num2 = 743;
						dataRow9["KR_FINE"] = Conversion.Val(val3[DC_Main.i, 20]);
						goto IL_69aa;
						IL_6928:
						num2 = 745;
						dataRow9["KR_TOUCH"] = Conversion.Val(val3[DC_Main.i, 36]);
						goto IL_6953;
						IL_6953:
						num2 = 746;
						dataRow9["KR_WEST_PRC"] = Conversion.Val(val3[DC_Main.i, 37]);
						goto IL_697e;
						IL_697e:
						num2 = 747;
						dataRow9["KR_FINE"] = Conversion.Val(val3[DC_Main.i, 38]);
						goto IL_69aa;
						IL_69aa:
						num2 = 749;
						dataRow9["LBR_PRC"] = Conversion.Val(val3[DC_Main.i, 24]);
						goto IL_69d5;
						IL_69d5:
						num2 = 750;
						dataRow9["LBR_TYPE"] = val3[DC_Main.i, 25];
						goto IL_69f6;
						IL_69f6:
						num2 = 751;
						dataRow9["LBR_RATE"] = Conversion.Val(val3[DC_Main.i, 26]);
						goto IL_6a21;
						IL_6a21:
						num2 = 752;
						dataRow9["LBR_AMT"] = Conversion.Val(val3[DC_Main.i, 27]);
						goto IL_6a4c;
						IL_6a4c:
						num2 = 753;
						dataRow9["OTH_AMT"] = Conversion.Val(val3[DC_Main.i, 28]);
						goto IL_6a77;
						IL_6a77:
						num2 = 754;
						dataRow9["ITM_RATE"] = Conversion.Val(val3[DC_Main.i, 44]);
						goto IL_6aa2;
						IL_6aa2:
						num2 = 755;
						dataRow9["ITM_AMT"] = Conversion.Val(val3[DC_Main.i, 45]);
						goto IL_6acd;
						IL_6acd:
						num2 = 756;
						dataRow9["ITM_REMARK"] = val3[DC_Main.i, 69];
						goto IL_6aee;
						IL_6aee:
						num2 = 757;
						dataRow9["KR_CODE"] = val3[DC_Main.i, 31];
						goto IL_6b0f;
						IL_6b0f:
						num2 = 758;
						dataRow9["IT_TYPE"] = val3[DC_Main.i, 51];
						goto IL_6b30;
						IL_6b30:
						num2 = 759;
						dataRow9["PR_CODE"] = val3[DC_Main.i, 53];
						goto IL_6b51;
						IL_6b51:
						num2 = 760;
						dataRow9["DATA_TRFR"] = "N";
						goto IL_6b69;
						IL_6b69:
						num2 = 761;
						dataRow9["DATA_TYPE"] = "A";
						goto IL_6b81;
						IL_6b81:
						num2 = 762;
						dataRow9["DESIGN_IMG_ID"] = val3[DC_Main.i, 85];
						goto IL_6ba2;
						IL_6ba2:
						num2 = 763;
						dataRow9["MAIN_USER"] = MainUser;
						goto IL_6bbb;
						IL_6bbb:
						num2 = 764;
						RsDetl.Rows.Add(dataRow9);
						goto IL_6bd4;
						IL_6bd4:
						num2 = 765;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						goto IL_6beb;
						IL_6beb:
						num2 = 766;
						RsDetl.Clear();
						goto IL_6c00;
						IL_6c00:
						val3 = null;
						goto IL_6c03;
						IL_6c03:
						num2 = 769;
						DC_Main.i++;
						goto IL_6c15;
						IL_51b3:
						num2 = 592;
						val4 = MSG;
						goto IL_51c1;
						IL_51c1:
						num2 = 593;
						if ((Operators.CompareString(val4[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(val4[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(val4[DC_Main.i, 30]) + (Conversion.Val(val4[DC_Main.i, 12]) + Conversion.Val(val4[DC_Main.i, 13]) + Conversion.Val(val4[DC_Main.i, 27]) + Conversion.Val(val4[DC_Main.i, 28])) != 0.0))
						{
							goto IL_5279;
						}
						goto IL_614c;
						IL_5279:
						num2 = 594;
						dataRow8["CO_CODE"] = DC_Main.MCo_code;
						goto IL_5291;
						IL_5291:
						num2 = 595;
						dataRow8["LC_CODE"] = tToLcCode.Text;
						goto IL_52af;
						IL_52af:
						num2 = 596;
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_52c7;
						IL_52c7:
						num2 = 597;
						dataRow8["CO_BOOK"] = tToBook.Text;
						goto IL_52e5;
						IL_52e5:
						num2 = 598;
						dataRow8["VCH_NO"] = tToVchNo.Text;
						goto IL_5303;
						IL_5303:
						num2 = 599;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						goto IL_5321;
						IL_5321:
						num2 = 600;
						dataRow8["STK_DATE"] = mVchDate.Text;
						goto IL_533f;
						IL_533f:
						num2 = 601;
						dataRow8["HD_VCH_NO"] = tToVchNo.Text;
						goto IL_535d;
						IL_535d:
						num2 = 602;
						dataRow8["AC_CODE"] = "";
						goto IL_5375;
						IL_5375:
						num2 = 603;
						dataRow8["VCH_TYPE"] = "IN";
						goto IL_538d;
						IL_538d:
						num2 = 604;
						dataRow8["INOUT_TYPE"] = "I";
						goto IL_53a5;
						IL_53a5:
						num2 = 605;
						dataRow8["ENTRY_TYPE"] = "I";
						goto IL_53bd;
						IL_53bd:
						num2 = 606;
						dataRow8["BOOK_NAME"] = "INWORD";
						goto IL_53d5;
						IL_53d5:
						num2 = 607;
						dataRow8["SR_NO"] = Conversion.Val(val4[DC_Main.i, 0]);
						goto IL_53ff;
						IL_53ff:
						num2 = 608;
						dataRow8["OLD_SRNO"] = Conversion.Val(val4[DC_Main.i, 49]);
						goto IL_542a;
						IL_542a:
						num2 = 609;
						dataRow8["IT_CODE"] = val4[DC_Main.i, 3];
						goto IL_544a;
						IL_544a:
						num2 = 610;
						if (Operators.CompareString(val4[DC_Main.i, 1], "", false) == 0)
						{
							goto IL_5471;
						}
						goto IL_548d;
						IL_5471:
						num2 = 611;
						dataRow8["TAG_NO"] = "N";
						goto IL_54ae;
						IL_548d:
						num2 = 613;
						dataRow8["TAG_NO"] = val4[DC_Main.i, 1];
						goto IL_54ae;
						IL_54ae:
						num2 = 615;
						dataRow8["TBL_CODE"] = val4[DC_Main.i, 4];
						goto IL_54ce;
						IL_54ce:
						num2 = 616;
						dataRow8["DESIGN_NO"] = val4[DC_Main.i, 5];
						goto IL_54ee;
						IL_54ee:
						num2 = 617;
						dataRow8["ITM_STYLE"] = val4[DC_Main.i, 6];
						goto IL_550e;
						IL_550e:
						num2 = 618;
						dataRow8["ITM_COLOR"] = val4[DC_Main.i, 7];
						goto IL_552e;
						IL_552e:
						num2 = 619;
						dataRow8["HM_ID"] = val4[DC_Main.i, 9];
						goto IL_554f;
						IL_554f:
						num2 = 620;
						dataRow8["ITM_SIZE"] = val4[DC_Main.i, 8];
						goto IL_556f;
						IL_556f:
						num2 = 621;
						dataRow8["BAG_WT"] = Conversion.Val(val4[DC_Main.i, 11]);
						goto IL_559a;
						IL_559a:
						num2 = 622;
						dataRow8["ITM_PCS"] = Conversion.Val(val4[DC_Main.i, 12]);
						goto IL_55c5;
						IL_55c5:
						num2 = 623;
						dataRow8["ITM_GWT"] = Conversion.Val(val4[DC_Main.i, 13]);
						goto IL_55f0;
						IL_55f0:
						num2 = 624;
						dataRow8["ITM_OTH_WT"] = Conversion.Val(val4[DC_Main.i, 14]);
						goto IL_561b;
						IL_561b:
						num2 = 625;
						dataRow8["ITM_NWT"] = Conversion.Val(val4[DC_Main.i, 15]);
						goto IL_5646;
						IL_5646:
						num2 = 626;
						dataRow8["ITM_GHT_WT"] = Conversion.Val(val4[DC_Main.i, 17]);
						goto IL_5671;
						IL_5671:
						num2 = 627;
						dataRow8["ITM_TOUCH"] = Conversion.Val(val4[DC_Main.i, 18]);
						goto IL_569c;
						IL_569c:
						num2 = 628;
						dataRow8["ITM_WEST_PRC"] = Conversion.Val(val4[DC_Main.i, 19]);
						goto IL_56c7;
						IL_56c7:
						num2 = 629;
						dataRow8["ITM_FINE"] = Conversion.Val(val4[DC_Main.i, 20]);
						goto IL_56f2;
						IL_56f2:
						num2 = 630;
						dataRow8["LBR_CODE"] = val4[DC_Main.i, 23];
						goto IL_5713;
						IL_5713:
						num2 = 631;
						dataRow8["LBR_PRC"] = Conversion.Val(val4[DC_Main.i, 24]);
						goto IL_573e;
						IL_573e:
						num2 = 632;
						dataRow8["LBR_TYPE"] = val4[DC_Main.i, 25];
						goto IL_575f;
						IL_575f:
						num2 = 633;
						dataRow8["LBR_RATE"] = Conversion.Val(val4[DC_Main.i, 26]);
						goto IL_578a;
						IL_578a:
						num2 = 634;
						dataRow8["LBR_AMT"] = Conversion.Val(val4[DC_Main.i, 27]);
						goto IL_57b5;
						IL_57b5:
						num2 = 635;
						dataRow8["OTH_AMT"] = Conversion.Val(val4[DC_Main.i, 28]);
						goto IL_57e0;
						IL_57e0:
						num2 = 636;
						dataRow8["ITM_RATE"] = Conversion.Val(val4[DC_Main.i, 44]);
						goto IL_580b;
						IL_580b:
						num2 = 637;
						dataRow8["ITM_AMT"] = Conversion.Val(val4[DC_Main.i, 45]);
						goto IL_5836;
						IL_5836:
						num2 = 638;
						dataRow8["ITM_MARGIN"] = Conversion.Val(val4[DC_Main.i, 46]);
						goto IL_5861;
						IL_5861:
						num2 = 639;
						dataRow8["ITM_MRP"] = Conversion.Val(val4[DC_Main.i, 30]);
						goto IL_588c;
						IL_588c:
						num2 = 640;
						dataRow8["KR_NET_WT"] = Conversion.Val(val4[DC_Main.i, 33]);
						goto IL_58b7;
						IL_58b7:
						num2 = 641;
						dataRow8["KR_TOUCH"] = Conversion.Val(val4[DC_Main.i, 36]);
						goto IL_58e2;
						IL_58e2:
						num2 = 642;
						dataRow8["KR_WEST_PRC"] = Conversion.Val(val4[DC_Main.i, 37]);
						goto IL_590d;
						IL_590d:
						num2 = 643;
						dataRow8["KR_FINE"] = Conversion.Val(val4[DC_Main.i, 38]);
						goto IL_5938;
						IL_5938:
						num2 = 644;
						dataRow8["KR_OTH_WT"] = Conversion.Val(val4[DC_Main.i, 32]);
						goto IL_5963;
						IL_5963:
						num2 = 645;
						dataRow8["KR_GHT_PRC"] = Conversion.Val(val4[DC_Main.i, 34]);
						goto IL_598e;
						IL_598e:
						num2 = 646;
						dataRow8["KR_GHT_WT"] = Conversion.Val(val4[DC_Main.i, 35]);
						goto IL_59b9;
						IL_59b9:
						num2 = 647;
						dataRow8["KR_LBR_RATE"] = Conversion.Val(val4[DC_Main.i, 39]);
						goto IL_59e4;
						IL_59e4:
						num2 = 648;
						dataRow8["KR_LBR_AMT"] = Conversion.Val(val4[DC_Main.i, 40]);
						goto IL_5a0f;
						IL_5a0f:
						num2 = 649;
						dataRow8["KR_OTH_AMT"] = Conversion.Val(val4[DC_Main.i, 41]);
						goto IL_5a3a;
						IL_5a3a:
						num2 = 650;
						dataRow8["KR_COST"] = Conversion.Val(val4[DC_Main.i, 42]);
						goto IL_5a65;
						IL_5a65:
						num2 = 651;
						if (val4[29] == 0)
						{
							goto IL_5a7d;
						}
						goto IL_5aac;
						IL_5a7d:
						num2 = 652;
						dataRow8["TAG_COST"] = Conversion.Val(val4[DC_Main.i, 94]);
						goto IL_5ad8;
						IL_5aac:
						num2 = 654;
						dataRow8["TAG_COST"] = Conversion.Val(val4[DC_Main.i, 29]);
						goto IL_5ad8;
						IL_5ad8:
						num2 = 656;
						dataRow8["ITM_REMARK"] = val4[DC_Main.i, 69];
						goto IL_5af9;
						IL_5af9:
						num2 = 657;
						dataRow8["KR_NAME"] = val4[DC_Main.i, 31];
						goto IL_5b1a;
						IL_5b1a:
						num2 = 658;
						dataRow8["RATE_TYPE"] = val4[DC_Main.i, 50];
						goto IL_5b3b;
						IL_5b3b:
						num2 = 659;
						dataRow8["IT_TYPE"] = val4[DC_Main.i, 51];
						goto IL_5b5c;
						IL_5b5c:
						num2 = 660;
						dataRow8["TAG_TYPE"] = val4[DC_Main.i, 51];
						goto IL_5b7d;
						IL_5b7d:
						num2 = 661;
						dataRow8["PR_CODE"] = val4[DC_Main.i, 53];
						goto IL_5b9e;
						IL_5b9e:
						num2 = 662;
						dataRow8["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(val4[DC_Main.i, 49]));
						goto IL_5c44;
						IL_5c44:
						num2 = 663;
						val4[DC_Main.i, 92] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(val4[DC_Main.i, 49]));
						goto IL_5cec;
						IL_5cec:
						num2 = 664;
						dataRow8["HM_ID2"] = val4[DC_Main.i, 70];
						goto IL_5d0d;
						IL_5d0d:
						num2 = 665;
						dataRow8["HM_ID3"] = val4[DC_Main.i, 71];
						goto IL_5d2e;
						IL_5d2e:
						num2 = 666;
						dataRow8["HM_ID4"] = val4[DC_Main.i, 72];
						goto IL_5d4f;
						IL_5d4f:
						num2 = 667;
						dataRow8["HM_ID_WT"] = Conversion.Val(val4[DC_Main.i, 73]);
						goto IL_5d7a;
						IL_5d7a:
						num2 = 668;
						dataRow8["HM_ID2_WT"] = Conversion.Val(val4[DC_Main.i, 74]);
						goto IL_5da5;
						IL_5da5:
						num2 = 669;
						dataRow8["HM_ID3_WT"] = Conversion.Val(val4[DC_Main.i, 75]);
						goto IL_5dd0;
						IL_5dd0:
						num2 = 670;
						dataRow8["HM_ID4_WT"] = Conversion.Val(val4[DC_Main.i, 76]);
						goto IL_5dfb;
						IL_5dfb:
						num2 = 671;
						dataRow8["JDT_JDT_WT"] = Conversion.Val(val4[DC_Main.i, 77]);
						goto IL_5e26;
						IL_5e26:
						num2 = 672;
						dataRow8["JDT_GHT_WT"] = Conversion.Val(val4[DC_Main.i, 78]);
						goto IL_5e51;
						IL_5e51:
						num2 = 673;
						dataRow8["JDT_KUN_WT"] = Conversion.Val(val4[DC_Main.i, 79]);
						goto IL_5e7c;
						IL_5e7c:
						num2 = 674;
						dataRow8["JDT_KUN_TOUCH"] = Conversion.Val(val4[DC_Main.i, 80]);
						goto IL_5ea7;
						IL_5ea7:
						num2 = 675;
						dataRow8["JDT_KUN_NET"] = Conversion.Val(val4[DC_Main.i, 81]);
						goto IL_5ed2;
						IL_5ed2:
						num2 = 676;
						dataRow8["JDT_WAX_WT"] = Conversion.Val(val4[DC_Main.i, 82]);
						goto IL_5efd;
						IL_5efd:
						num2 = 677;
						dataRow8["KR_WAX_WT"] = Conversion.Val(val4[DC_Main.i, 83]);
						goto IL_5f28;
						IL_5f28:
						num2 = 678;
						dataRow8["DESIGN_IMG_ID"] = val4[DC_Main.i, 85];
						goto IL_5f49;
						IL_5f49:
						num2 = 679;
						dataRow8["ORD_YRCD"] = val4[DC_Main.i, 87];
						goto IL_5f6a;
						IL_5f6a:
						num2 = 680;
						dataRow8["ORD_DBCD"] = val4[DC_Main.i, 88];
						goto IL_5f8b;
						IL_5f8b:
						num2 = 681;
						dataRow8["ORD_NO"] = val4[DC_Main.i, 89];
						goto IL_5fac;
						IL_5fac:
						num2 = 682;
						dataRow8["ORD_AC"] = val4[DC_Main.i, 91];
						goto IL_5fcd;
						IL_5fcd:
						num2 = 683;
						dataRow8["ORD_LC_CODE"] = val4[DC_Main.i, 86];
						goto IL_5fee;
						IL_5fee:
						num2 = 684;
						dataRow8["ORD_SRNO"] = Conversion.Val(val4[DC_Main.i, 90]);
						goto IL_6019;
						IL_6019:
						num2 = 685;
						dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_604c;
						IL_604c:
						num2 = 686;
						dataRow8["DATA_TYPE"] = "A";
						goto IL_6064;
						IL_6064:
						num2 = 687;
						dataRow8["DATA_TRFR"] = "N";
						goto IL_607c;
						IL_607c:
						num2 = 688;
						dataRow8["APP_TRFR"] = "N";
						goto IL_6094;
						IL_6094:
						num2 = 689;
						dataRow8["APR_ISU"] = "N";
						goto IL_60ac;
						IL_60ac:
						num2 = 690;
						dataRow8["EMP_ISU"] = val4[DC_Main.i, 84];
						goto IL_60cd;
						IL_60cd:
						num2 = 691;
						dataRow8["DATA_TYPE"] = val4[DC_Main.i, 93];
						goto IL_60ee;
						IL_60ee:
						num2 = 692;
						dataRow8["MAIN_USER"] = MainUser;
						goto IL_6107;
						IL_6107:
						num2 = 693;
						RsDetl.Rows.Add(dataRow8);
						goto IL_6120;
						IL_6120:
						num2 = 694;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						goto IL_6137;
						IL_6137:
						num2 = 695;
						RsDetl.Clear();
						goto IL_614c;
						IL_614c:
						val4 = null;
						goto IL_614f;
						IL_614f:
						num2 = 698;
						DC_Main.i++;
						goto IL_6161;
						IL_76a8:
						num2 = 835;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_76cb;
						}
						goto IL_77f9;
						IL_76cb:
						num2 = 836;
						DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.TAG_GEN = 'Y' FROM SL_ORD_DETL,BAR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.ORD_LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ORD_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ORD_DBCD AND SL_ORD_DETL.VCH_NO = B.ORD_NO AND SL_ORD_DETL.OLD_SRNO = B.ORD_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_7742;
						IL_7742:
						num2 = 837;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_7753;
						IL_7753:
						num2 = 838;
						DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_77ca;
						IL_77ca:
						num2 = 839;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_77db;
						IL_77db:
						num2 = 840;
						Ac_Stock.InWord_Stk(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_77f9;
						IL_77f9:
						num2 = 842;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM396NEHM", false) == 0)
						{
							goto IL_781b;
						}
						goto IL_7965;
						IL_781b:
						num2 = 843;
						DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_7892;
						IL_7892:
						num2 = 844;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_78a3;
						IL_78a3:
						num2 = 845;
						Ac_Ledr.Stk_InOut_Ledr(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_78bf;
						IL_78bf:
						num2 = 846;
						DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
						goto IL_7936;
						IL_7936:
						num2 = 847;
						DC_Main.ExeQuteDc(DC_Main.RsQry);
						goto IL_7947;
						IL_7947:
						num2 = 848;
						Ac_Rojmel.Stk_InOut_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
						goto IL_7965;
						IL_7965:
						num2 = 850;
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						goto IL_7982;
						IL_7982:
						num2 = 851;
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							goto IL_79a2;
						}
						goto IL_79c0;
						IL_79a2:
						num2 = 852;
						CLEAR_DATA();
						goto IL_79af;
						IL_79af:
						num2 = 853;
						((Form)this).Close();
						goto end_IL_0001_3;
						IL_79c0:
						num2 = 856;
						CurPrnVch = tVchNo.Text;
						goto IL_79d7;
						IL_79d7:
						num2 = 857;
						CLEAR_DATA();
						goto IL_79e4;
						IL_79e4:
						num2 = 858;
						BtnPrint_Click(BtnPrint, new EventArgs());
						break;
						IL_4567:
						num2 = 515;
						dtIdtl3 = DtIdtl;
						goto IL_4575;
						IL_4575:
						num2 = 516;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][12])) != 0.0)
						{
							goto IL_45fb;
						}
						goto IL_4f97;
						IL_45fb:
						num2 = 517;
						num18 = MSG.Rows - 1;
						DC_Main.M = 1;
						goto IL_4682;
						IL_4682:
						if (DC_Main.M <= num18)
						{
							goto IL_4618;
						}
						goto IL_468b;
						IL_4618:
						num2 = 518;
						if (Conversion.Val(MSG[DC_Main.M, 49]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][16])))
						{
							goto IL_4660;
						}
						goto IL_4670;
						IL_4660:
						num2 = 519;
						num5 = DC_Main.M;
						goto IL_468b;
						IL_468b:
						num2 = 523;
						dataRow7["CO_CODE"] = DC_Main.MCo_code;
						goto IL_46a3;
						IL_46a3:
						num2 = 524;
						dataRow7["LC_CODE"] = tToLcCode.Text;
						goto IL_46c1;
						IL_46c1:
						num2 = 525;
						dataRow7["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_46d9;
						IL_46d9:
						num2 = 526;
						dataRow7["CO_BOOK"] = tToBook.Text;
						goto IL_46f7;
						IL_46f7:
						num2 = 527;
						dataRow7["VCH_NO"] = tToVchNo.Text;
						goto IL_4715;
						IL_4715:
						num2 = 528;
						dataRow7["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_4733;
						IL_4733:
						num2 = 529;
						dataRow7["TO_CO_BOOK"] = tToBook.Text;
						goto IL_4751;
						IL_4751:
						num2 = 530;
						dataRow7["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_476f;
						IL_476f:
						num2 = 531;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_478f;
						}
						goto IL_47ed;
						IL_478f:
						num2 = 532;
						dataRow6["FROM_LC_CODE"] = tFrmLc.Text;
						goto IL_47ad;
						IL_47ad:
						num2 = 533;
						dataRow6["FROM_CO_BOOK"] = tFrombook.Text;
						goto IL_47cb;
						IL_47cb:
						num2 = 534;
						dataRow6["FROM_VCH_NO"] = tFromVchNo.Text;
						goto IL_483c;
						IL_47ed:
						num2 = 536;
						dataRow6["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_4805;
						IL_4805:
						num2 = 537;
						dataRow6["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_481d;
						IL_481d:
						num2 = 538;
						dataRow6["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_483c;
						IL_483c:
						num2 = 540;
						dataRow7["HD_VCH_NO"] = tToVchNo.Text;
						goto IL_485a;
						IL_485a:
						num2 = 541;
						dataRow7["VCH_DATE"] = mVchDate.Text;
						goto IL_4878;
						IL_4878:
						num2 = 542;
						dataRow7["AC_CODE"] = "";
						goto IL_4890;
						IL_4890:
						num2 = 543;
						dataRow7["VCH_TYPE"] = "IN";
						goto IL_48a8;
						IL_48a8:
						num2 = 544;
						dataRow7["INOUT_TYPE"] = "I";
						goto IL_48c0;
						IL_48c0:
						num2 = 545;
						dataRow7["ENTRY_TYPE"] = "I";
						goto IL_48d8;
						IL_48d8:
						num2 = 546;
						dataRow7["BOOK_NAME"] = "INWORD";
						goto IL_48f0;
						IL_48f0:
						num2 = 547;
						dataRow7["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][16]));
						goto IL_492b;
						IL_492b:
						num2 = 548;
						dataRow7["TAG_NO"] = MSG[num5, 1];
						goto IL_494b;
						IL_494b:
						num2 = 549;
						dataRow7["VCH_SRNO"] = MSG[num5, 43];
						goto IL_496c;
						IL_496c:
						num2 = 550;
						dataRow7["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][0]));
						goto IL_49a6;
						IL_49a6:
						num2 = 551;
						dataRow7["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][1]);
						goto IL_49d6;
						IL_49d6:
						num2 = 552;
						dataRow7["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][3]));
						goto IL_4a10;
						IL_4a10:
						num2 = 553;
						dataRow7["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][4]));
						goto IL_4a4a;
						IL_4a4a:
						num2 = 554;
						dataRow7["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][5]));
						goto IL_4a84;
						IL_4a84:
						num2 = 555;
						dataRow7["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][6]));
						goto IL_4abe;
						IL_4abe:
						num2 = 556;
						dataRow7["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][7]);
						goto IL_4aee;
						IL_4aee:
						num2 = 557;
						dataRow7["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][8]));
						goto IL_4b28;
						IL_4b28:
						num2 = 558;
						dataRow7["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][9]));
						goto IL_4b63;
						IL_4b63:
						num2 = 559;
						dataRow7["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][10]));
						goto IL_4b9e;
						IL_4b9e:
						num2 = 560;
						dataRow7["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][11]));
						goto IL_4bd9;
						IL_4bd9:
						num2 = 561;
						dataRow7["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][12]));
						goto IL_4c14;
						IL_4c14:
						num2 = 562;
						dataRow7["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][13]));
						goto IL_4c4f;
						IL_4c4f:
						num2 = 563;
						dataRow7["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][15]);
						goto IL_4c80;
						IL_4c80:
						num2 = 564;
						dataRow7["MAIN_USER"] = MainUser;
						goto IL_4c99;
						IL_4c99:
						num2 = 565;
						dataRow7["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][17]);
						goto IL_4cca;
						IL_4cca:
						num2 = 566;
						dataRow7["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][18]);
						goto IL_4cfb;
						IL_4cfb:
						num2 = 567;
						dataRow7["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][19]);
						goto IL_4d2c;
						IL_4d2c:
						num2 = 568;
						dataRow7["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][20]);
						goto IL_4d5d;
						IL_4d5d:
						num2 = 569;
						dataRow7["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][21]);
						goto IL_4d8e;
						IL_4d8e:
						num2 = 570;
						dataRow7["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][22]);
						goto IL_4dbf;
						IL_4dbf:
						num2 = 571;
						dataRow7["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][23]);
						goto IL_4df0;
						IL_4df0:
						num2 = 572;
						dataRow7["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][24]));
						goto IL_4e2b;
						IL_4e2b:
						num2 = 573;
						dataRow7["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][25]));
						goto IL_4e66;
						IL_4e66:
						num2 = 574;
						dataRow7["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][26]));
						goto IL_4ea1;
						IL_4ea1:
						num2 = 575;
						dataRow7["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][27]));
						goto IL_4edc;
						IL_4edc:
						num2 = 576;
						dataRow7["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][28]));
						goto IL_4f17;
						IL_4f17:
						num2 = 577;
						dataRow7["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num12][29]));
						goto IL_4f52;
						IL_4f52:
						num2 = 578;
						RsIdtl.Rows.Add(dataRow7);
						goto IL_4f6b;
						IL_4f6b:
						num2 = 579;
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						goto IL_4f82;
						IL_4f82:
						num2 = 580;
						RsIdtl.Clear();
						goto IL_4f97;
						IL_4670:
						num2 = 522;
						DC_Main.M++;
						goto IL_4682;
						IL_4f97:
						dtIdtl3 = null;
						goto IL_4f9a;
						IL_4f9a:
						num2 = 583;
						num12++;
						goto IL_4fa6;
						IL_3481:
						num2 = 394;
						val = MSG;
						goto IL_348f;
						IL_348f:
						num2 = 395;
						if (((Operators.CompareString(val[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(val[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(val[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(val[DC_Main.i, 12]) + Conversion.Val(val[DC_Main.i, 13]) + Conversion.Val(val[DC_Main.i, 27]) + Conversion.Val(val[DC_Main.i, 28]) != 0.0))
						{
							goto IL_3555;
						}
						goto IL_4463;
						IL_3555:
						num2 = 396;
						dataRow6["CO_CODE"] = DC_Main.MCo_code;
						goto IL_356d;
						IL_356d:
						num2 = 397;
						dataRow6["LC_CODE"] = tToLcCode.Text;
						goto IL_358b;
						IL_358b:
						num2 = 398;
						dataRow6["CO_YEAR"] = DC_Main.MCo_year;
						goto IL_35a3;
						IL_35a3:
						num2 = 399;
						dataRow6["CO_BOOK"] = tToBook.Text;
						goto IL_35c1;
						IL_35c1:
						num2 = 400;
						dataRow6["VCH_NO"] = tToVchNo.Text;
						goto IL_35df;
						IL_35df:
						num2 = 401;
						dataRow6["VCH_DATE"] = mVchDate.Text;
						goto IL_35fd;
						IL_35fd:
						num2 = 402;
						dataRow6["TO_LC_CODE"] = tToLcCode.Text;
						goto IL_361b;
						IL_361b:
						num2 = 403;
						dataRow6["TO_CO_BOOK"] = tToBook.Text;
						goto IL_3639;
						IL_3639:
						num2 = 404;
						dataRow6["TO_VCH_NO"] = tToVchNo.Text;
						goto IL_3657;
						IL_3657:
						num2 = 405;
						if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
						{
							goto IL_3677;
						}
						goto IL_36d5;
						IL_3677:
						num2 = 406;
						dataRow6["FROM_LC_CODE"] = tFrmLc.Text;
						goto IL_3695;
						IL_3695:
						num2 = 407;
						dataRow6["FROM_CO_BOOK"] = tFrombook.Text;
						goto IL_36b3;
						IL_36b3:
						num2 = 408;
						dataRow6["FROM_VCH_NO"] = tFromVchNo.Text;
						goto IL_3724;
						IL_36d5:
						num2 = 410;
						dataRow6["FROM_LC_CODE"] = DC_Main.MLc_code;
						goto IL_36ed;
						IL_36ed:
						num2 = 411;
						dataRow6["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						goto IL_3705;
						IL_3705:
						num2 = 412;
						dataRow6["FROM_VCH_NO"] = tVchNo.Text;
						goto IL_3724;
						IL_3724:
						num2 = 414;
						dataRow6["HD_VCH_NO"] = tToVchNo.Text;
						goto IL_3742;
						IL_3742:
						num2 = 415;
						dataRow6["AC_CODE"] = "";
						goto IL_375a;
						IL_375a:
						num2 = 416;
						dataRow6["VCH_TYPE"] = "IN";
						goto IL_3772;
						IL_3772:
						num2 = 417;
						dataRow6["INOUT_TYPE"] = "I";
						goto IL_378a;
						IL_378a:
						num2 = 418;
						dataRow6["ENTRY_TYPE"] = "I";
						goto IL_37a2;
						IL_37a2:
						num2 = 419;
						dataRow6["BOOK_NAME"] = "INWORD";
						goto IL_37ba;
						IL_37ba:
						num2 = 420;
						dataRow6["SR_NO"] = Conversion.Val(val[DC_Main.i, 0]);
						goto IL_37e4;
						IL_37e4:
						num2 = 421;
						dataRow6["OLD_SRNO"] = Conversion.Val(val[DC_Main.i, 49]);
						goto IL_380f;
						IL_380f:
						num2 = 422;
						dataRow6["IT_CODE"] = val[DC_Main.i, 3];
						goto IL_382f;
						IL_382f:
						num2 = 423;
						if (Operators.CompareString(val[DC_Main.i, 1], "", false) == 0)
						{
							goto IL_3856;
						}
						goto IL_3872;
						IL_3856:
						num2 = 424;
						dataRow6["TAG_NO"] = "N";
						goto IL_3893;
						IL_3872:
						num2 = 426;
						dataRow6["TAG_NO"] = val[DC_Main.i, 1];
						goto IL_3893;
						IL_3893:
						num2 = 428;
						dataRow6["ITM_LOT"] = val[DC_Main.i, 2];
						goto IL_38b3;
						IL_38b3:
						num2 = 429;
						dataRow6["TBL_CODE"] = val[DC_Main.i, 4];
						goto IL_38d3;
						IL_38d3:
						num2 = 430;
						dataRow6["DESIGN_NO"] = val[DC_Main.i, 5];
						goto IL_38f3;
						IL_38f3:
						num2 = 431;
						dataRow6["ITM_STYLE"] = val[DC_Main.i, 6];
						goto IL_3913;
						IL_3913:
						num2 = 432;
						dataRow6["ITM_COLOR"] = val[DC_Main.i, 7];
						goto IL_3933;
						IL_3933:
						num2 = 433;
						dataRow6["HM_ID"] = val[DC_Main.i, 9];
						goto IL_3954;
						IL_3954:
						num2 = 434;
						dataRow6["ITM_SIZE"] = val[DC_Main.i, 8];
						goto IL_3974;
						IL_3974:
						num2 = 435;
						dataRow6["BAG_WT"] = Conversion.Val(val[DC_Main.i, 11]);
						goto IL_399f;
						IL_399f:
						num2 = 436;
						dataRow6["ITM_PCS"] = Conversion.Val(val[DC_Main.i, 12]);
						goto IL_39ca;
						IL_39ca:
						num2 = 437;
						dataRow6["ITM_GWT"] = Conversion.Val(val[DC_Main.i, 13]);
						goto IL_39f5;
						IL_39f5:
						num2 = 438;
						dataRow6["ITM_OTH_WT"] = Conversion.Val(val[DC_Main.i, 14]);
						goto IL_3a20;
						IL_3a20:
						num2 = 439;
						dataRow6["ITM_NWT"] = Conversion.Val(val[DC_Main.i, 15]);
						goto IL_3a4b;
						IL_3a4b:
						num2 = 440;
						dataRow6["ITM_GHT_WT"] = Conversion.Val(val[DC_Main.i, 17]);
						goto IL_3a76;
						IL_3a76:
						num2 = 441;
						dataRow6["ITM_TOUCH"] = Conversion.Val(val[DC_Main.i, 18]);
						goto IL_3aa1;
						IL_3aa1:
						num2 = 442;
						dataRow6["ITM_WEST_PRC"] = Conversion.Val(val[DC_Main.i, 19]);
						goto IL_3acc;
						IL_3acc:
						num2 = 443;
						dataRow6["ITM_FINE"] = Conversion.Val(val[DC_Main.i, 20]);
						goto IL_3af7;
						IL_3af7:
						num2 = 444;
						dataRow6["LBR_CODE"] = val[DC_Main.i, 23];
						goto IL_3b18;
						IL_3b18:
						num2 = 445;
						dataRow6["LBR_PRC"] = Conversion.Val(val[DC_Main.i, 24]);
						goto IL_3b43;
						IL_3b43:
						num2 = 446;
						dataRow6["LBR_TYPE"] = val[DC_Main.i, 25];
						goto IL_3b64;
						IL_3b64:
						num2 = 447;
						dataRow6["LBR_RATE"] = Conversion.Val(val[DC_Main.i, 26]);
						goto IL_3b8f;
						IL_3b8f:
						num2 = 448;
						dataRow6["LBR_AMT"] = Conversion.Val(val[DC_Main.i, 27]);
						goto IL_3bba;
						IL_3bba:
						num2 = 449;
						dataRow6["OTH_AMT"] = Conversion.Val(val[DC_Main.i, 28]);
						goto IL_3be5;
						IL_3be5:
						num2 = 450;
						dataRow6["ITM_RATE"] = Conversion.Val(val[DC_Main.i, 44]);
						goto IL_3c10;
						IL_3c10:
						num2 = 451;
						dataRow6["ITM_AMT"] = Conversion.Val(val[DC_Main.i, 45]);
						goto IL_3c3b;
						IL_3c3b:
						num2 = 452;
						dataRow6["ITM_MARGIN"] = Conversion.Val(val[DC_Main.i, 46]);
						goto IL_3c66;
						IL_3c66:
						num2 = 453;
						dataRow6["ITM_MRP"] = Conversion.Val(val[DC_Main.i, 30]);
						goto IL_3c91;
						IL_3c91:
						num2 = 454;
						dataRow6["KR_NET_WT"] = Conversion.Val(val[DC_Main.i, 33]);
						goto IL_3cbc;
						IL_3cbc:
						num2 = 455;
						dataRow6["KR_TOUCH"] = Conversion.Val(val[DC_Main.i, 36]);
						goto IL_3ce7;
						IL_3ce7:
						num2 = 456;
						dataRow6["KR_WEST_PRC"] = Conversion.Val(val[DC_Main.i, 37]);
						goto IL_3d12;
						IL_3d12:
						num2 = 457;
						dataRow6["KR_FINE"] = Conversion.Val(val[DC_Main.i, 38]);
						goto IL_3d3d;
						IL_3d3d:
						num2 = 458;
						dataRow6["KR_OTH_WT"] = Conversion.Val(val[DC_Main.i, 32]);
						goto IL_3d68;
						IL_3d68:
						num2 = 459;
						dataRow6["KR_GHT_PRC"] = Conversion.Val(val[DC_Main.i, 34]);
						goto IL_3d93;
						IL_3d93:
						num2 = 460;
						dataRow6["KR_GHT_WT"] = Conversion.Val(val[DC_Main.i, 35]);
						goto IL_3dbe;
						IL_3dbe:
						num2 = 461;
						dataRow6["KR_LBR_RATE"] = Conversion.Val(val[DC_Main.i, 39]);
						goto IL_3de9;
						IL_3de9:
						num2 = 462;
						dataRow6["KR_LBR_AMT"] = Conversion.Val(val[DC_Main.i, 40]);
						goto IL_3e14;
						IL_3e14:
						num2 = 463;
						dataRow6["KR_OTH_AMT"] = Conversion.Val(val[DC_Main.i, 41]);
						goto IL_3e3f;
						IL_3e3f:
						num2 = 464;
						dataRow6["KR_COST"] = Conversion.Val(val[DC_Main.i, 42]);
						goto IL_3e6a;
						IL_3e6a:
						num2 = 465;
						if (val[29] == 0)
						{
							goto IL_3e82;
						}
						goto IL_3eb1;
						IL_3e82:
						num2 = 466;
						dataRow6["TAG_COST"] = Conversion.Val(val[DC_Main.i, 94]);
						goto IL_3edd;
						IL_3eb1:
						num2 = 468;
						dataRow6["TAG_COST"] = Conversion.Val(val[DC_Main.i, 29]);
						goto IL_3edd;
						IL_3edd:
						num2 = 470;
						dataRow6["ITM_REMARK"] = val[DC_Main.i, 69];
						goto IL_3efe;
						IL_3efe:
						num2 = 471;
						dataRow6["KR_NAME"] = val[DC_Main.i, 31];
						goto IL_3f1f;
						IL_3f1f:
						num2 = 472;
						dataRow6["RATE_TYPE"] = val[DC_Main.i, 50];
						goto IL_3f40;
						IL_3f40:
						num2 = 473;
						dataRow6["IT_TYPE"] = val[DC_Main.i, 51];
						goto IL_3f61;
						IL_3f61:
						num2 = 474;
						dataRow6["PR_CODE"] = val[DC_Main.i, 53];
						goto IL_3f82;
						IL_3f82:
						num2 = 475;
						dataRow6["VCH_SRNO"] = Conversion.Val(val[DC_Main.i, 43]);
						goto IL_3fad;
						IL_3fad:
						num2 = 476;
						dataRow6["HM_ID2"] = val[DC_Main.i, 70];
						goto IL_3fce;
						IL_3fce:
						num2 = 477;
						dataRow6["HM_ID3"] = val[DC_Main.i, 71];
						goto IL_3fef;
						IL_3fef:
						num2 = 478;
						dataRow6["HM_ID4"] = val[DC_Main.i, 72];
						goto IL_4010;
						IL_4010:
						num2 = 479;
						dataRow6["HM_ID_WT"] = Conversion.Val(val[DC_Main.i, 73]);
						goto IL_403b;
						IL_403b:
						num2 = 480;
						dataRow6["HM_ID2_WT"] = Conversion.Val(val[DC_Main.i, 74]);
						goto IL_4066;
						IL_4066:
						num2 = 481;
						dataRow6["HM_ID3_WT"] = Conversion.Val(val[DC_Main.i, 75]);
						goto IL_4091;
						IL_4091:
						num2 = 482;
						dataRow6["HM_ID4_WT"] = Conversion.Val(val[DC_Main.i, 76]);
						goto IL_40bc;
						IL_40bc:
						num2 = 483;
						dataRow6["JDT_JDT_WT"] = Conversion.Val(val[DC_Main.i, 77]);
						goto IL_40e7;
						IL_40e7:
						num2 = 484;
						dataRow6["JDT_GHT_WT"] = Conversion.Val(val[DC_Main.i, 78]);
						goto IL_4112;
						IL_4112:
						num2 = 485;
						dataRow6["JDT_KUN_WT"] = Conversion.Val(val[DC_Main.i, 79]);
						goto IL_413d;
						IL_413d:
						num2 = 486;
						dataRow6["JDT_KUN_TOUCH"] = Conversion.Val(val[DC_Main.i, 80]);
						goto IL_4168;
						IL_4168:
						num2 = 487;
						dataRow6["JDT_KUN_NET"] = Conversion.Val(val[DC_Main.i, 81]);
						goto IL_4193;
						IL_4193:
						num2 = 488;
						dataRow6["JDT_WAX_WT"] = Conversion.Val(val[DC_Main.i, 82]);
						goto IL_41be;
						IL_41be:
						num2 = 489;
						dataRow6["KR_WAX_WT"] = Conversion.Val(val[DC_Main.i, 83]);
						goto IL_41e9;
						IL_41e9:
						num2 = 490;
						dataRow6["DESIGN_IMG_ID"] = val[DC_Main.i, 85];
						goto IL_420a;
						IL_420a:
						num2 = 491;
						dataRow6["ORD_YRCD"] = val[DC_Main.i, 87];
						goto IL_422b;
						IL_422b:
						num2 = 492;
						dataRow6["ORD_DBCD"] = val[DC_Main.i, 88];
						goto IL_424c;
						IL_424c:
						num2 = 493;
						dataRow6["ORD_NO"] = val[DC_Main.i, 89];
						goto IL_426d;
						IL_426d:
						num2 = 494;
						dataRow6["ORD_AC"] = val[DC_Main.i, 91];
						goto IL_428e;
						IL_428e:
						num2 = 495;
						dataRow6["ORD_LC_CODE"] = val[DC_Main.i, 86];
						goto IL_42af;
						IL_42af:
						num2 = 496;
						dataRow6["ORD_SRNO"] = Conversion.Val(val[DC_Main.i, 90]);
						goto IL_42da;
						IL_42da:
						num2 = 497;
						dataRow6["NEW_VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(val[DC_Main.i, 49]));
						goto IL_4380;
						IL_4380:
						num2 = 498;
						dataRow6["EMP_ISU"] = val[DC_Main.i, 84];
						goto IL_43a1;
						IL_43a1:
						num2 = 499;
						dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						goto IL_43d4;
						IL_43d4:
						num2 = 500;
						dataRow6["DATA_TRFR"] = "N";
						goto IL_43ec;
						IL_43ec:
						num2 = 501;
						dataRow6["MAIN_USER"] = MainUser;
						goto IL_4405;
						IL_4405:
						num2 = 502;
						dataRow6["DATA_TYPE"] = BranchDataType;
						goto IL_441e;
						IL_441e:
						num2 = 503;
						RsDetl.Rows.Add(dataRow6);
						goto IL_4437;
						end_IL_0001_2:
						break;
					}
					num2 = 859;
					CurPrnVch = "";
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 34712;
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Mobile_image_Save(int ImgRow, string NewVchSrNo)
	{
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Expected O, but got Unknown
		//IL_025b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0265: Expected O, but got Unknown
		AxMSFlexGrid mSG = MSG;
		string text = mSG[ImgRow, 1] + "_" + NewVchSrNo;
		DC_Main.MsImageNo = mSG[ImgRow, 1] + "_" + mSG[ImgRow, 43];
		DC_Main.MsImageType = "TagImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
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
				ProjectData.ClearProjectError();
			}
		}
		else
		{
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[ImgRow, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[ImgRow, 43]))) ?? "";
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
			else if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				Image image;
				using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
				{
					image = Image.FromStream(stream);
				}
				PicImage.Image = image;
			}
		}
		if (PicImage.Image != null)
		{
			MemoryStream memoryStream = new MemoryStream();
			PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
			byte[] buffer = memoryStream.GetBuffer();
			string value = Convert.ToBase64String(buffer);
			DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[ImgRow, 1] + "' AND VCH_SRNO = " + NewVchSrNo) ?? "";
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = ("DELETE FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[ImgRow, 1] + "' AND VCH_SRNO = " + NewVchSrNo) ?? "";
			DC_Main.ExeQuteImg(DC_Main.RsQry);
			DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG[ImgRow, 1] + "' AND VCH_SRNO = " + NewVchSrNo) ?? "";
			DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow = dataTable.NewRow();
			dataRow["CO_CODE"] = DC_Main.MCo_code;
			dataRow["LC_CODE"] = DC_Main.MLc_code;
			dataRow["TAG_NO"] = mSG[ImgRow, 1];
			dataRow["VCH_SRNO"] = NewVchSrNo;
			dataRow["IMAGE_TYPE"] = "T";
			dataRow["IMG_IMPORT"] = "N";
			dataRow["MOB_IMAGE"] = value;
			dataTable.Rows.Add(dataRow);
			((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
			dataTable.Clear();
		}
		mSG = null;
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Invalid comparison between Unknown and I4
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
			return;
		}
		if (!VchDelete && Operators.CompareString(FormMainBook, "INWORD", false) == 0)
		{
			Interaction.MsgBox((object)"You Cant Delete InWord Voucher......", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (!VchDelete && Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "' AND STK_TRFR = 'Y'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete This Voucher Because Outword Branch Received This Voucher Please Detlet First Out Word Branch Vch First...", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,'',0,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM INOUT_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND FROM_LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND FROM_CO_BOOK = '" + DC_Main.MCo_Book + "' AND FROM_VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM INOUT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND FROM_LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND FROM_CO_BOOK = '" + DC_Main.MCo_Book + "' AND FROM_VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM INOUT_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND FROM_LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND FROM_CO_BOOK = '" + DC_Main.MCo_Book + "' AND FROM_VCH_NO = '" + tVchNo.Text + "'");
			}
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_INOUT_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (OldValTot == NewValTot)
			{
				((Form)this).Close();
			}
			else if (((Control)TEXT_ENTRY).Visible)
			{
				MSG_LeaveCell(MSG, new EventArgs());
				MSG.Row = checked(MSG.Rows - 1);
				MSG.Col = 0;
				((Control)TEXT_ENTRY).Visible = false;
				MSG_TOT_FILL();
				((Control)tEmpCode).Focus();
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
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\StkInOutVch.RPT";
		Cr.SelectionFormula = "{INOUT_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {INOUT_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {INOUT_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {INOUT_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {INOUT_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		CLEAR_DATA();
	}

	private void TR_INOUT_Activated(object sender, EventArgs e)
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
			tToLcCode.Text = DC_Main.MsCode;
			tToLcName.Text = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0192: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(FormMainBook, "OUTWORD", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.TO_LC_CODE As CodeL,B.LC_NAME As LocationL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.TOT_GWT As GwtW,A.STK_TRFR As StkRecM FROM INOUT_DATA AS A LEFT JOIN LOCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.TO_LC_CODE = B.LC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.FROM_LC_CODE As CodeL,B.LC_NAME As LocationL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.TOT_GWT As GwtW,A.STK_TRFR As StkRecM FROM INOUT_DATA AS A LEFT JOIN LOCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.FROM_LC_CODE = B.LC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 80.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 250.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 110.0;
		DC_Main.ColWidth[7] = 80.0;
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
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 54] + " : It Name";
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 49]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])))
				{
					MSG_IDTL[num, 0] = Conversions.ToString(num);
					MSG_IDTL[num, 1] = Conversions.ToString(DtIdtl.Rows[i][1]);
					MSG_IDTL[num, 2] = Conversions.ToString(DtIdtl.Rows[i][2]);
					MSG_IDTL[num, 3] = Conversions.ToString(DtIdtl.Rows[i][3]);
					MSG_IDTL[num, 4] = Conversions.ToString(DtIdtl.Rows[i][4]);
					MSG_IDTL[num, 5] = Conversions.ToString(DtIdtl.Rows[i][5]);
					MSG_IDTL[num, 6] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][6], (object)""));
					MSG_IDTL[num, 7] = Conversions.ToString(DtIdtl.Rows[i][7]);
					MSG_IDTL[num, 8] = Conversions.ToString(DtIdtl.Rows[i][8]);
					MSG_IDTL[num, 9] = Conversions.ToString(DtIdtl.Rows[i][9]);
					MSG_IDTL[num, 10] = Conversions.ToString(DtIdtl.Rows[i][10]);
					MSG_IDTL[num, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
					MSG_IDTL[num, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
					MSG_IDTL[num, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
					MSG_IDTL[num, 14] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][14], (object)""));
					MSG_IDTL[num, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
					MSG_IDTL[num, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
					MSG_IDTL[num, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
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
					MSG_IDTL[num, 29] = Conversions.ToString(DtIdtl.Rows[i][29]);
					MSG_IDTL[num, 30] = Conversions.ToString(DtIdtl.Rows[i][30]);
					MSG_IDTL[num, 31] = Conversions.ToString(DtIdtl.Rows[i][31]);
					MSG_IDTL.Rows += 1;
					num++;
				}
			}
			ImgDisplay((int)Math.Round(Conversion.Val(MSG[MSG.Row, 49])));
			MSG_IDTL[num, 0] = Conversions.ToString(num);
			MSG_IDTL[num, 16] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 49]));
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void ImgDisplay(int Row)
	{
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e6: Expected O, but got Unknown
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		//IL_0332: Unknown result type (might be due to invalid IL or missing references)
		//IL_033c: Expected O, but got Unknown
		PicImage.Image = null;
		if (Row >= MSG.Rows)
		{
			return;
		}
		if ((Operators.CompareString(MSG[Row, 85] ?? "", "N", false) != 0) & (Operators.CompareString(MSG[Row, 5] ?? "", "", false) != 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 85] + "' AND IMAGE_TYPE = 'D'";
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
			return;
		}
		if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
		{
			DC_Main.MsImageNo = MSG[Row, 1] + "_" + MSG[Row, 92];
		}
		else
		{
			DC_Main.MsImageNo = MSG[Row, 1] + "_" + MSG[Row, 43];
		}
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
			if (Operators.CompareString(DC_Main.MsHttpPath, "", false) == 0)
			{
				return;
			}
			try
			{
				string address = ((Operators.CompareString(DC_Main.MsAppSchem, "Y", false) != 0) ? (DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg") : (DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg"));
				PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
			}
			catch (Exception projectError)
			{
				ProjectData.SetProjectError(projectError);
				if (Operators.CompareString(FormMainBook, "INWORD", false) == 0)
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[Row, 92]))) ?? "";
				}
				else
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[Row, 43]))) ?? "";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM INOUT_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_INOUT_Closed(object sender, EventArgs e)
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

	private void tToLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tToLcCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE <> '" + DC_Main.MLc_code + "' ORDER BY LC_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[5];
			DC_Main.ColWidth[0] = 70.0;
			DC_Main.ColWidth[1] = 280.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 250.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tToLcCode.Text = DC_Main.ColValue[0];
				tToLcName.Text = DC_Main.ColValue[1];
				((TextBoxBase)tToLcCode).SelectAll();
				((Control)tToLcCode).Focus();
			}
		}
		else
		{
			tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_NAME"], (object)""));
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM INOUT_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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

	private void TR_INOUT_KeyUp(object sender, KeyEventArgs e)
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

	private void BtnTagVchHelp_Click(object sender, EventArgs e)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.BOOK_NAME As BookL,A.STK_IT_CODE As StkItCodeL,A.VCH_DESC As RemarkL,A.MAIN_USER As UserL,A.CO_BOOK As CoBookL FROM ((BAR_DATA AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)LEFT JOIN MAIN_STOCK AS D ON C.CO_CODE = D.CO_CODE AND C.LC_CODE = D.LC_CODE AND C.TAG_NO = D.TAG_NO AND C.VCH_SRNO = D.VCH_SRNO  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.MAIN_BOOK IN ('OPSTK','TAG GEN','PURCHASE','KARIGAR RECEIPT')   GROUP BY A.VCH_NO,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/'),B.BOOK_NAME,A.STK_IT_CODE,A.VCH_DESC,A.MAIN_USER,A.CO_BOOK HAVING SUM(CASE WHEN D.ITM_SIGN ='+' THEN D.VCH_SRNO ELSE - C.VCH_SRNO END) > 0  ORDER BY A.CO_BOOK,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/'),A.VCH_NO ";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 175.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 250.0;
		DC_Main.ColWidth[5] = 150.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				CLEAR_DATA();
				tTagVch.Text = DC_Main.ColValue[0];
				TagBook = DC_Main.ColValue[6];
				((Control)tTagVch).Focus();
			}
			else
			{
				TagBook = "";
				((Control)tTagVch).Focus();
			}
		}
	}

	private void tTagVch_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 84)
		{
			BtnTagVchHelp_Click(BtnF1, new EventArgs());
		}
		if ((int)e.KeyCode == 13)
		{
			TagImport();
		}
	}

	private void TagImport()
	{
		//IL_01a2: Unknown result type (might be due to invalid IL or missing references)
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		DC_Main.RsQry = "SELECT A.TAG_NO,A.VCH_SRNO FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + TagBook + "' AND A.VCH_NO = '" + tTagVch.Text + "' ORDER BY A.SR_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.i = 0;
		AxMSFlexGrid mSG = MSG;
		checked
		{
			while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)"' AND A.VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"]))), (object)" GROUP BY A.TAG_NO,A.VCH_SRNO HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 "));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"You Cant Transfer This Voucher Because ", DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"]), (object)" This Tag No Is Out Of Stock Pleas check First... "), (MsgBoxStyle)0, (object)null);
					return;
				}
				DC_Main.i++;
			}
			mSG = null;
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + TagBook + "' AND A.VCH_NO = '" + tTagVch.Text + "' ORDER BY A.SR_NO";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.i = 0;
			AxMSFlexGrid mSG2 = MSG;
			while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
			{
				mSG2[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
				mSG2[DC_Main.i + 1, 49] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
				mSG2[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 54] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
				mSG2[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
				mSG2[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
				mSG2[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
				mSG2[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
				mSG2[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_STYLE"], (object)""));
				mSG2[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
				mSG2[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 12] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
				mSG2[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
				mSG2[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
				mSG2[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
				mSG2[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
				mSG2[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 64] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 34] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 65] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
				mSG2[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
				mSG2[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
				mSG2[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_RATE"])), "0.00");
				mSG2[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_LBR_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 41] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_COST"])), "0.00");
				mSG2[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
				mSG2[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_COST"])), "0.00");
				mSG2[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
				mSG2[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
				mSG2[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
				mSG2[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
				mSG2[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
				mSG2[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_SRNO"])), "0");
				mSG2[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 52] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 53] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"])), "0");
				mSG2[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 55] = "E";
				mSG2[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2"], (object)""));
				mSG2[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3"], (object)""));
				mSG2[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4"], (object)""));
				mSG2[DC_Main.i + 1, 73] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 74] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 76] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 77] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_JDT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 78] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 79] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 80] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 81] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_KUN_NET"])), "0.000");
				mSG2[DC_Main.i + 1, 82] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["JDT_WAX_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 83] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
				mSG2.Rows += 1;
				DC_Main.i++;
			}
			mSG2.Rows -= 1;
			mSG2 = null;
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
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + TagBook + "' AND A.VCH_NO = '" + tTagVch.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.i = 0;
			while (DC_Main.i < RsIdtl.Rows.Count)
			{
				dr = DtIdtl.NewRow();
				dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
				dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
				dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
				dr[3] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
				dr[4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
				dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
				dr[6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.000");
				dr[7] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
				dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
				dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
				dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
				dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
				dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
				dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
				dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
				dr[15] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
				dr[16] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
				dr[17] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_CODE"], (object)"");
				dr[18] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_NAME"], (object)"");
				dr[19] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_COLOR"], (object)"");
				dr[20] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SIZE"], (object)"");
				dr[21] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_ORIGIN"], (object)"");
				dr[22] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_REMARK"], (object)"");
				dr[23] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["DM_SFNO"], (object)"");
				dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_WT"])), "0.000");
				dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_ACT_PRC"])), "0.00");
				dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_LESS_PRC"])), "0.00");
				dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_RATE"])), "0.00");
				dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_AMT"])), "0.00");
				dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS_WT"])), "0.000");
				dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
				dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
				DtIdtl.Rows.Add(dr);
				DC_Main.i++;
			}
			MsgOldRow = 0;
			MSG_RowColChange(MSG, new EventArgs());
		}
	}

	private void tEmpName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			VchDelete = true;
		}
	}
}
