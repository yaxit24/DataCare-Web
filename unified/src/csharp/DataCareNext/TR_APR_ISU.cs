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
using DevNet.Models;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_APR_ISU : Form
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
	[AccessedThroughProperty("btnIsuNo")]
	private SimpleButton _btnIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

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
	[AccessedThroughProperty("tLcCode")]
	private TextBox _tLcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	private Module_WhatsApp whatsApp;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private DataTable RsAcOthRate;

	private DataView DvAcRate;

	private string WappAcName;

	private string WappMobile;

	private string WappMsg;

	private string AdminWappMsg;

	private string AcMobile;

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

	private const int cIsuOrdNo = 1;

	private const int cKrOrnaRecDt = 2;

	private const int cIsuAcName = 3;

	private const int cConsiItCode = 4;

	private const int cTagNo = 5;

	private const int cItCode = 6;

	private const int cCounter = 7;

	private const int cDesign = 8;

	private const int cSize = 9;

	private const int cHmId = 10;

	private const int cItRemark = 11;

	private const int cMtlColor = 12;

	private const int cBagWt = 13;

	private const int cPcs = 14;

	private const int cGrWt = 15;

	private const int cOthWt = 16;

	private const int cNetWt = 17;

	private const int cGhtPrc = 18;

	private const int cGhtWt = 19;

	private const int cTouch = 20;

	private const int cWestPrc = 21;

	private const int cFine = 22;

	private const int cItRate = 23;

	private const int cItAmt = 24;

	private const int cLbrPrc = 25;

	private const int cLbrType = 26;

	private const int cLbrRate = 27;

	private const int cLbrAmt = 28;

	private const int cOthAmt = 29;

	private const int cMrp = 30;

	private const int cLbrDiscPrc = 31;

	private const int cLbrDiscAmt = 32;

	private const int cNetAmt = 33;

	private const int cKrName = 34;

	private const int cIsuRec = 35;

	private const int cIsuNo = 36;

	private const int cIsuYrCd = 37;

	private const int cIsuDbCd = 38;

	private const int cIsuSrNo = 39;

	private const int cIsuAcCode = 40;

	private const int cVchSrno = 41;

	private const int cIsuLcCode = 42;

	private const int cKrOthWt = 43;

	private const int cKrNetWt = 44;

	private const int cKrGhatPrc = 45;

	private const int cKrGhatWt = 46;

	private const int cKrTouch = 47;

	private const int cKrWestPrc = 48;

	private const int cKrFine = 49;

	private const int cKrLRate = 50;

	private const int cKrLAmt = 51;

	private const int cKrOthAmt = 52;

	private const int cTagCost = 53;

	private const int cMargin = 54;

	private const int cImageTake = 55;

	private const int cTagSrNo = 56;

	private const int cOldSrNo = 57;

	private const int cRateType = 58;

	private const int cItType = 59;

	private const int cTagType = 60;

	private const int cPrCode = 61;

	private const int cItName = 62;

	private const int cEntryMod = 63;

	private const int cOldTagType = 64;

	private const int cOldPrCode = 65;

	private const int cOldGrWt = 66;

	private const int cOldNtWt = 67;

	private const int cOldGhatPrc = 68;

	private const int cOldGhatWt = 69;

	private const int cOldTouch = 70;

	private const int cOldWestPrc = 71;

	private const int cOldKrNetWt = 72;

	private const int cOldKrTouch = 73;

	private const int cOldKrWest = 74;

	private const int cEmpSale = 75;

	private const int cDesignImgId = 76;

	private const int cConsiIsuRec = 77;

	private const int c1SrNo = 0;

	private const int c1ItCode = 1;

	private const int c1ItName = 2;

	private const int c1DmCode = 3;

	private const int c1DmName = 4;

	private const int c1DmSize = 5;

	private const int c1DmSfNo = 6;

	private const int c1Pcs = 7;

	private const int c1GrWt = 8;

	private const int c1KrWt = 9;

	private const int c1ConPrc = 10;

	private const int c1RateType = 11;

	private const int c1ItRate = 12;

	private const int c1ItmAmt = 13;

	private const int c1LbrRate = 14;

	private const int c1LbrAmt = 15;

	private const int c1NetAmt = 16;

	private const int c1ConWt = 17;

	private const int c1KrConWt = 18;

	private const int c1ItType = 19;

	private const int c1RowSr = 20;

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
			EventHandler eventHandler5 = MSG_Enter;
			EventHandler eventHandler6 = MSG_Scroll;
			AxMSFlexGrid val = _MSG;
			if (val != null)
			{
				val.ClickEvent -= eventHandler;
				val.EnterCell -= eventHandler2;
				val.LeaveCell -= eventHandler3;
				val.RowColChange -= eventHandler4;
				((Control)val).Enter -= eventHandler5;
				val.Scroll -= eventHandler6;
			}
			_MSG = value;
			val = _MSG;
			if (val != null)
			{
				val.ClickEvent += eventHandler;
				val.EnterCell += eventHandler2;
				val.LeaveCell += eventHandler3;
				val.RowColChange += eventHandler4;
				((Control)val).Enter += eventHandler5;
				val.Scroll += eventHandler6;
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
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tIsuNo_KeyDown);
			TextBox val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tIsuNo = value;
			val2 = _tIsuNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox tLcCode
	{
		[CompilerGenerated]
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tLcCode_KeyDown);
			TextBox val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tLcCode = value;
			val2 = _tLcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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
			EventHandler eventHandler = btnExel_Click;
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

	public TR_APR_ISU()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_APR_ISU_Load;
		((Form)this).Deactivate += TR_APR_ISU_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_APR_ISU_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_APR_ISU_KeyDown);
		((Form)this).Activated += TR_APR_ISU_Activated;
		((Form)this).Closed += TR_APR_ISU_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_APR_ISU_KeyUp);
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
		//IL_02f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Expected O, but got Unknown
		//IL_03af: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b9: Expected O, but got Unknown
		//IL_043c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0446: Expected O, but got Unknown
		//IL_04e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ed: Expected O, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected O, but got Unknown
		//IL_0626: Unknown result type (might be due to invalid IL or missing references)
		//IL_0630: Expected O, but got Unknown
		//IL_06c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d2: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_076b: Expected O, but got Unknown
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_0881: Unknown result type (might be due to invalid IL or missing references)
		//IL_088b: Expected O, but got Unknown
		//IL_08ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f8: Expected O, but got Unknown
		//IL_09a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ab: Expected O, but got Unknown
		//IL_0ac8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad2: Expected O, but got Unknown
		//IL_0bdd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0be7: Expected O, but got Unknown
		//IL_0c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c54: Expected O, but got Unknown
		//IL_0dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e60: Expected O, but got Unknown
		//IL_0fea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff4: Expected O, but got Unknown
		//IL_10a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10aa: Expected O, but got Unknown
		//IL_11a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ac: Expected O, but got Unknown
		//IL_12bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c7: Expected O, but got Unknown
		//IL_1344: Unknown result type (might be due to invalid IL or missing references)
		//IL_134e: Expected O, but got Unknown
		//IL_140f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Expected O, but got Unknown
		//IL_14c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_14ca: Expected O, but got Unknown
		//IL_15ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d8: Expected O, but got Unknown
		//IL_1639: Unknown result type (might be due to invalid IL or missing references)
		//IL_1643: Expected O, but got Unknown
		//IL_174f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1759: Expected O, but got Unknown
		//IL_1831: Unknown result type (might be due to invalid IL or missing references)
		//IL_183b: Expected O, but got Unknown
		//IL_18d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e1: Expected O, but got Unknown
		//IL_1a1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a26: Expected O, but got Unknown
		//IL_1a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a78: Expected O, but got Unknown
		//IL_1aef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1af9: Expected O, but got Unknown
		//IL_1b7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b87: Expected O, but got Unknown
		//IL_1c4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c58: Expected O, but got Unknown
		//IL_1cfc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d06: Expected O, but got Unknown
		//IL_1d80: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d8a: Expected O, but got Unknown
		//IL_1e12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1c: Expected O, but got Unknown
		//IL_1ecd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed7: Expected O, but got Unknown
		//IL_1f8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f95: Expected O, but got Unknown
		//IL_2056: Unknown result type (might be due to invalid IL or missing references)
		//IL_2060: Expected O, but got Unknown
		//IL_2138: Unknown result type (might be due to invalid IL or missing references)
		//IL_2142: Expected O, but got Unknown
		//IL_21de: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e8: Expected O, but got Unknown
		//IL_22f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_2300: Expected O, but got Unknown
		//IL_23bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_23c5: Expected O, but got Unknown
		//IL_2459: Unknown result type (might be due to invalid IL or missing references)
		//IL_2463: Expected O, but got Unknown
		//IL_24fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2505: Expected O, but got Unknown
		//IL_25a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_25ae: Expected O, but got Unknown
		//IL_266f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2679: Expected O, but got Unknown
		//IL_273a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2744: Expected O, but got Unknown
		//IL_2801: Unknown result type (might be due to invalid IL or missing references)
		//IL_280b: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_APR_ISU));
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
		btnIsuNo = new SimpleButton();
		Label5 = new Label();
		tIsuNo = new TextBox();
		tIsuDbCd = new TextBox();
		tIsuYrCd = new TextBox();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		tLcCode = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
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
		lblBook.Text = "Approval Issu";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(297, 43);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(227, 44);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(19, 44);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(68, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(104, 43);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(458, 43);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(378, 43);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(75, 22);
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
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = Resources.bo_contract;
		((Control)btnExel).Location = new Point(730, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 28;
		btnExel.Text = "&Exel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(247, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(477, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(367, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(107, 34);
		((Control)chkWapp).TabIndex = 8;
		((ButtonBase)chkWapp).Text = "Whatsapp";
		((ButtonBase)chkWapp).UseVisualStyleBackColor = false;
		((Control)chkWapp).Visible = false;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(200, 3);
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
		((Control)BtnFirst).Location = new Point(153, 3);
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
		((Control)lblItem).Location = new Point(952, 75);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(221, 20);
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
		((Control)PicImage).Location = new Point(992, 361);
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
		((Control)BtnF1).Location = new Point(186, 42);
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
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(104, 72);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tAcName).Location = new Point(186, 72);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(355, 22);
		((Control)tAcName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(18, 69);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(87, 20);
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
		((Control)tEmpCode).Font = new Font("Tahoma", 9f);
		((Control)tEmpCode).Location = new Point(90, 520);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 6;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(153, 520);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(15, 522);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(375, 520);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(448, 519);
		((TextBoxBase)tVchDesc).MaxLength = 200;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(537, 38);
		((Control)tVchDesc).TabIndex = 7;
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
		((Control)btnIsuNo).Location = new Point(860, 43);
		((BaseControl)btnIsuNo).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnIsuNo).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnIsuNo).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnIsuNo).Name = "btnIsuNo";
		((Control)btnIsuNo).Size = new Size(35, 23);
		((Control)btnIsuNo).TabIndex = 1166;
		btnIsuNo.Text = "F1";
		((BaseControl)btnIsuNo).ToolTip = "Voucher Help";
		((Control)btnIsuNo).Visible = false;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(555, 43);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(53, 20);
		((Control)Label5).TabIndex = 1165;
		Label5.Text = "Isu No";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)Label5).Visible = false;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuNo).Location = new Point(614, 44);
		((TextBoxBase)tIsuNo).MaxLength = 8;
		((Control)tIsuNo).Name = "tIsuNo";
		((TextBoxBase)tIsuNo).ReadOnly = true;
		((Control)tIsuNo).Size = new Size(76, 22);
		((Control)tIsuNo).TabIndex = 2;
		((Control)tIsuNo).Visible = false;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuDbCd).Location = new Point(778, 44);
		((TextBoxBase)tIsuDbCd).MaxLength = 8;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(76, 22);
		((Control)tIsuDbCd).TabIndex = 1167;
		((Control)tIsuDbCd).Visible = false;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tIsuYrCd).Location = new Point(696, 44);
		((TextBoxBase)tIsuYrCd).MaxLength = 8;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(76, 22);
		((Control)tIsuYrCd).TabIndex = 1168;
		((Control)tIsuYrCd).Visible = false;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(1123, 519);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 1179;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((Control)BtnImgD).Visible = false;
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(1068, 519);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 1178;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		((Control)BtnImgS).Visible = false;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(1015, 520);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 1177;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((Control)BtnImgC).Visible = false;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(924, 43);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1180;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)btnIsuNo);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
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
		((Control)this).Name = "TR_APR_ISU";
		((Form)this).Text = "Approval Issu";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
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
			mSG_IDTL[2] = (int)Math.Round(2000.0 * ColCon);
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
			mSG_IDTL[9] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[9] = 7;
			mSG_IDTL[0, 9] = "KrWt";
			mSG_IDTL[8] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[8] = 7;
			mSG_IDTL[0, 8] = "Weight";
			mSG_IDTL[10] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[10] = 7;
			mSG_IDTL[0, 10] = "Con%";
			mSG_IDTL[11] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[11] = 3;
			mSG_IDTL[0, 11] = "P/W";
			mSG_IDTL[12] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[12] = 7;
			mSG_IDTL[0, 12] = "Rate";
			mSG_IDTL[13] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[13] = 7;
			mSG_IDTL[0, 13] = "ItAmt";
			mSG_IDTL[14] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[14] = 7;
			mSG_IDTL[0, 14] = "LbrRate";
			mSG_IDTL[15] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[15] = 7;
			mSG_IDTL[0, 15] = "LbrAmt";
			mSG_IDTL[16] = (int)Math.Round(1050.0 * ColCon);
			mSG_IDTL[16] = 7;
			mSG_IDTL[0, 16] = "NetAmt";
			mSG_IDTL[17] = 0;
			mSG_IDTL[0, 17] = "ConWt";
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
		mSG_IDTL[mSG_IDTL.Row, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
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
				if (mSG_IDTL.Col < 16)
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
						if (Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 12]) == 0.0)
						{
							mSG_IDTL[mSG_IDTL.Row, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["SL_RATE"], (object)"")), "0.00");
						}
						break;
					case 16:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 16] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
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
				case 11:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 10:
				case 12:
				case 13:
				case 14:
				case 15:
				case 16:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 8:
				case 9:
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
			case 11:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 7:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 10:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 8:
			case 9:
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
		if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 9]) == 0.0))
		{
			mSG_IDTL[CRow, 9] = Strings.Format((object)Conversion.Val(mSG_IDTL[CRow, 8]), "0.000");
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0))
		{
			mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 8]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 17] = Conversions.ToString(0);
		}
		if ((Conversion.Val(mSG_IDTL[CRow, 9]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 10]) != 0.0))
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 9]) * Conversion.Val(mSG_IDTL[CRow, 10])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 18] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 11], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 8]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
			{
				mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0))
			{
				mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 8])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 11], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 12])))) != 0)
		{
			mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 12]) != 0.0)
		{
			mSG_IDTL[CRow, 13] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 12]) * Conversion.Val(mSG_IDTL[CRow, 8])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 13]) + Conversion.Val(mSG_IDTL[CRow, 15]) != 0.0)
		{
			mSG_IDTL[CRow, 16] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 13]) + Conversion.Val(mSG_IDTL[CRow, 15])), "0.00");
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
				num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 17]);
				num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
				num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 16]);
				DC_Main.M++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 16] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 17] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 15]) - Conversion.Val(MSG[MSG.Row, 16])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 43] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 44] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 15]) - Conversion.Val(MSG[MSG.Row, 43])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 29] = Strings.Format((object)num4, "0.00");
			}
			double num5 = default(double);
			if (num5 != 0.0)
			{
				MSG[MSG.Row, 52] = Strings.Format((object)num5, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 17] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 15]) - num2), "0.000");
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
		mSG.Cols = 78;
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
			if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
			{
				mSG[4] = (int)Math.Round(1000.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "ItCode";
				mSG[6] = 0;
			}
			else
			{
				mSG[6] = (int)Math.Round(1000.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "ItCode";
				mSG[4] = 0;
			}
			mSG[5] = (int)Math.Round(1200.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "TagNo";
			mSG[7] = (int)Math.Round(900.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "Counter";
			mSG[8] = (int)Math.Round(1300.0 * ColCon);
			mSG[8] = 0;
			mSG[0, 8] = "Design";
			mSG[9] = (int)Math.Round(800.0 * ColCon);
			mSG[9] = 0;
			mSG[0, 9] = "Size";
			mSG[10] = (int)Math.Round(900.0 * ColCon);
			mSG[10] = 0;
			mSG[0, 10] = "HmId";
			mSG[13] = (int)Math.Round(800.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "BagWt";
			mSG[14] = (int)Math.Round(700.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Pcs";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "GrWt";
			mSG[16] = (int)Math.Round(900.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "LsWt";
			mSG[17] = (int)Math.Round(1000.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "NetWt";
			mSG[18] = (int)Math.Round(750.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "Ght%";
			mSG[19] = (int)Math.Round(850.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "GhtWt";
			mSG[20] = (int)Math.Round(850.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "Touch";
			mSG[21] = (int)Math.Round(850.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "West%";
			mSG[22] = (int)Math.Round(1000.0 * ColCon);
			mSG[22] = 7;
			mSG[0, 22] = "Fine";
			mSG[25] = (int)Math.Round(800.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "Lbr%";
			mSG[26] = (int)Math.Round(800.0 * ColCon);
			mSG[26] = 3;
			mSG[0, 26] = "LType";
			mSG[27] = (int)Math.Round(900.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "LbrRate";
			mSG[28] = (int)Math.Round(950.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "LbrAmt";
			mSG[29] = (int)Math.Round(1000.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "OthAmt";
			mSG[33] = (int)Math.Round(1000.0 * ColCon);
			mSG[33] = 7;
			mSG[0, 33] = "NetAmt";
			mSG[23] = (int)Math.Round(900.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "ItRate";
			mSG[24] = (int)Math.Round(1000.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "ItAmt";
			mSG[30] = (int)Math.Round(900.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Mrp";
			mSG[31] = (int)Math.Round(850.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "LDisc%";
			mSG[32] = (int)Math.Round(950.0 * ColCon);
			mSG[32] = 7;
			mSG[0, 32] = "LDiscAmt";
			mSG[55] = (int)Math.Round(0.0 * ColCon);
			mSG[55] = 3;
			mSG[0, 55] = "Image";
			mSG[34] = (int)Math.Round(900.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrCode";
			if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
			{
				mSG[1] = (int)Math.Round(900.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "OrdNo";
				mSG[2] = (int)Math.Round(1100.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "KrRecDt";
				mSG[3] = (int)Math.Round(2200.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "Party Order";
				mSG[11] = (int)Math.Round(1800.0 * ColCon);
				mSG[11] = 0;
				mSG[0, 11] = "Remark ";
				mSG[12] = (int)Math.Round(1000.0 * ColCon);
				mSG[12] = 0;
				mSG[0, 12] = "MtlColor";
				mSG[5] = 0;
				mSG[7] = 0;
				mSG[13] = 0;
				mSG[18] = 0;
				mSG[19] = 0;
				mSG[23] = 0;
				mSG[24] = 0;
				mSG[30] = 0;
				mSG[55] = 0;
				mSG[34] = 0;
				mSG[10] = 0;
				mSG[35] = 0;
				mSG[36] = 0;
				mSG[37] = 0;
				mSG[38] = 0;
				mSG[39] = 0;
			}
			else
			{
				mSG[1] = 0;
				mSG[2] = 0;
				mSG[3] = 0;
				mSG[11] = 0;
				mSG[12] = 0;
				if ((Operators.CompareString(FormMainBook, "APR RTN", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0))
				{
					mSG[35] = 0;
					mSG[36] = (int)Math.Round(900.0 * ColCon);
					mSG[36] = 0;
					mSG[0, 36] = "IsuNo";
					mSG[37] = (int)Math.Round(1000.0 * ColCon);
					mSG[37] = 0;
					mSG[0, 37] = "Year";
					mSG[38] = (int)Math.Round(800.0 * ColCon);
					mSG[38] = 0;
					mSG[0, 38] = "Book";
					mSG[39] = (int)Math.Round(700.0 * ColCon);
					mSG[39] = 3;
					mSG[0, 39] = "SrNo";
				}
				else
				{
					mSG[35] = (int)Math.Round(700.0 * ColCon);
					mSG[35] = 3;
					mSG[0, 35] = "ItRec";
					mSG[36] = 0;
					mSG[37] = 0;
					mSG[38] = 0;
					mSG[39] = 0;
				}
			}
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
			mSG[58] = 0;
			mSG[59] = 0;
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[41] = 0;
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
			mSG[40] = 0;
			mSG[75] = 0;
			mSG[76] = 0;
			mSG[77] = 0;
			if (DC_Main.MsTagVchSrnoUpdate)
			{
				mSG[41] = (int)Math.Round(1500.0 * ColCon);
				mSG[41] = 3;
				mSG[0, 41] = "TagId";
			}
			else
			{
				mSG[41] = 0;
			}
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
					if (Operators.CompareString(FormMainBook, "CONSI PURC", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'CONSI PURC' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					}
					else if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'KR DESIGN ISU' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					}
					else
					{
						dataView.RowFilter = " BOOK_NAME = 'APR_DETL' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
					}
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
			if (Operators.CompareString(FormBookInOut, "O", false) == 0)
			{
				MsgLastCol = 35;
			}
			else
			{
				MsgLastCol = 0;
			}
			DC_Main.M = 35;
			while (DC_Main.M <= 0)
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[33] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 0;
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
				mSG_TOT[0, 8] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.000");
					mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[DC_Main.M, 22]))), "0.000");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					mSG_TOT[0, 28] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 28]) + Conversion.Val(MSG[DC_Main.M, 28]))), "0.00");
					mSG_TOT[0, 29] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 29]) + Conversion.Val(MSG[DC_Main.M, 29]))), "0.00");
					mSG_TOT[0, 53] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 53]) + Conversion.Val(MSG[DC_Main.M, 53]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
					mSG_TOT[0, 43] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 43]) + Conversion.Val(MSG[DC_Main.M, 43]))), "0.000");
					mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.000");
					mSG_TOT[0, 46] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 46]) + Conversion.Val(MSG[DC_Main.M, 46]))), "0.000");
					mSG_TOT[0, 49] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 49]) + Conversion.Val(MSG[DC_Main.M, 49]))), "0.000");
					mSG_TOT[0, 51] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 51]) + Conversion.Val(MSG[DC_Main.M, 51]))), "0.00");
					mSG_TOT[0, 52] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 52]) + Conversion.Val(MSG[DC_Main.M, 52]))), "0.00");
					mSG_TOT[0, 33] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 33]) + Conversion.Val(MSG[DC_Main.M, 33]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 17]) + Conversion.Val(MSG_TOT[0, 44]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 28]);
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
			mSG[mSG.Row, 14] = Conversions.ToString(1);
			mSG[mSG.Row, 26] = DC_Main.MsLbrType;
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 57] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 57] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 57]) + 1.0);
			}
			mSG[mSG.Row, 63] = "A";
			mSG[mSG.Row, 35] = "N";
			mSG[mSG.Row, 75] = "N";
			mSG[mSG.Row, 76] = "N";
			mSG[mSG.Row, 77] = "N";
			MSG_IDTL_CLEAR();
			if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
			{
				if (mSG.Row > 1)
				{
					TEXT_ENTRY.Text = mSG[mSG.Row - 1, 4];
				}
				mSG[mSG.Row, 41] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 4, 1) + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mVchDate.Text))) + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dd") + Strings.Format((object)DateAndTime.Now, "HH") + Strings.Format((object)DateAndTime.Now, "mm") + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 57]));
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
			case 4:
			case 34:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 5], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 1:
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 11:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 5], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 5:
			case 12:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 8:
			case 9:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 26:
			case 55:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 35:
			case 36:
			case 37:
			case 38:
			case 39:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 14:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 5], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 31:
			case 32:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 18:
			case 20:
			case 21:
			case 25:
			case 47:
			case 48:
			case 54:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 23:
			case 24:
			case 27:
			case 28:
			case 29:
			case 30:
			case 33:
			case 50:
			case 51:
			case 52:
			case 53:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 13:
			case 15:
			case 16:
			case 17:
			case 19:
			case 22:
			case 43:
			case 44:
			case 45:
			case 46:
			case 49:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 25;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
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
		case 4:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			if ((Operators.CompareString(mSG[mSG.Row, 5], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 4], "", false) != 0))
			{
				NewTagNo(mSG.Row);
			}
			break;
		case 6:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 0:
		case 5:
		case 7:
		case 8:
		case 9:
		case 10:
		case 26:
		case 34:
		case 35:
		case 36:
		case 37:
		case 38:
		case 39:
		case 55:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 2:
		case 3:
		case 11:
		case 12:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 14:
		case 41:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			break;
		case 18:
		case 20:
		case 21:
		case 25:
		case 47:
		case 48:
		case 54:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 23:
		case 24:
		case 27:
		case 28:
		case 29:
		case 30:
		case 31:
		case 32:
		case 33:
		case 50:
		case 51:
		case 52:
		case 53:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 16:
		case 43:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
			CommPassTotal_Idtl(1);
			CommPassTotal();
			break;
		case 13:
		case 15:
		case 17:
		case 19:
		case 22:
		case 44:
		case 45:
		case 46:
		case 49:
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
				case 5283:
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
							goto IL_01da;
						case 13:
							goto IL_020e;
						case 14:
							goto IL_026e;
						case 16:
							goto IL_02ec;
						case 15:
						case 17:
						case 18:
						case 19:
							goto IL_0323;
						case 20:
							goto IL_035a;
						case 21:
							goto IL_038e;
						case 22:
							goto IL_03ee;
						case 23:
						case 24:
						case 25:
							goto IL_046c;
						case 26:
							goto IL_04a3;
						case 27:
							goto IL_04d7;
						case 28:
							goto IL_0537;
						case 29:
						case 30:
						case 31:
							goto IL_05b5;
						case 32:
							goto IL_05f0;
						case 33:
						case 34:
							goto IL_063a;
						case 35:
							goto IL_0686;
						case 36:
						case 37:
							goto IL_06d0;
						case 38:
							goto IL_0707;
						case 39:
							goto IL_073b;
						case 40:
							goto IL_079b;
						case 42:
							goto IL_0819;
						case 41:
						case 43:
						case 44:
						case 45:
							goto IL_0850;
						case 46:
							goto IL_0887;
						case 47:
							goto IL_08bb;
						case 48:
							goto IL_091b;
						case 49:
						case 50:
						case 51:
							goto IL_0999;
						case 52:
							goto IL_09d0;
						case 53:
							goto IL_0a04;
						case 54:
							goto IL_0a64;
						case 55:
						case 56:
						case 57:
							goto IL_0ae2;
						case 58:
							goto IL_0b1d;
						case 59:
						case 60:
							goto IL_0b67;
						case 61:
							goto IL_0bb7;
						case 63:
							goto IL_0c00;
						case 65:
							goto IL_0c54;
						case 67:
							goto IL_0cb2;
						case 69:
							goto IL_0d0d;
						case 62:
						case 64:
						case 66:
						case 68:
						case 70:
						case 71:
						case 72:
							goto IL_0d60;
						case 73:
							goto IL_0daf;
						case 74:
							goto IL_0e0b;
						case 75:
							goto IL_0e32;
						case 76:
							goto IL_0e49;
						case 77:
						case 78:
						case 79:
							goto IL_0e64;
						case 80:
							goto IL_0e92;
						case 82:
							goto IL_0edb;
						case 84:
							goto IL_0f2f;
						case 85:
							goto IL_0f4b;
						case 87:
							goto IL_0f9d;
						case 90:
							goto IL_1006;
						case 92:
							goto IL_1075;
						case 81:
						case 83:
						case 86:
						case 88:
						case 89:
						case 91:
						case 93:
						case 94:
						case 95:
							goto IL_10c8;
						case 96:
							goto IL_10f5;
						case 97:
							goto IL_1141;
						case 100:
							goto IL_11a6;
						case 101:
							goto IL_11f2;
						case 98:
						case 99:
						case 102:
						case 103:
						case 104:
							goto IL_1251;
						case 105:
							goto IL_12d6;
						case 106:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 107:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_11f2:
					num2 = 101;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 28]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1251;
					IL_1251:
					num2 = 104;
					val[val.Row, 33] = Strings.Format((object)(Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 28]) + Conversion.Val(val[val.Row, 29]) + Conversion.Val(val[val.Row, 30]) - Conversion.Val(val[val.Row, 32])), "0.0");
					goto IL_12d6;
					IL_11a6:
					num2 = 100;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 28]) != 0.0))
					{
						goto IL_11f2;
					}
					goto IL_1251;
					IL_12d6:
					val = null;
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 66]))
					{
						goto IL_004b;
					}
					goto IL_010e;
					IL_004b:
					num2 = 4;
					val[val.Row, 66] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) - Conversion.Val(val[val.Row, 16])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					val[val.Row, 44] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) - Conversion.Val(val[val.Row, 43])), "0.000");
					goto IL_010e;
					IL_010e:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 16]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_0159;
					}
					goto IL_01a3;
					IL_0159:
					num2 = 9;
					val[val.Row, 17] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) - Conversion.Val(val[val.Row, 16])), "0.000");
					goto IL_01a3;
					IL_01a3:
					num2 = 11;
					if (Conversion.Val(val[val.Row, 17]) != Conversion.Val(val[val.Row, 67]))
					{
						goto IL_01da;
					}
					goto IL_0323;
					IL_01da:
					num2 = 12;
					val[val.Row, 67] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_020e;
					IL_020e:
					num2 = 13;
					if ((Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_026e;
					}
					goto IL_02ec;
					IL_026e:
					num2 = 14;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])) * (Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])) / 100.0), "0.000");
					goto IL_0323;
					IL_02ec:
					num2 = 16;
					val[val.Row, 22] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.000");
					goto IL_0323;
					IL_0323:
					num2 = 19;
					if (Conversion.Val(val[val.Row, 20]) != Conversion.Val(val[val.Row, 70]))
					{
						goto IL_035a;
					}
					goto IL_046c;
					IL_035a:
					num2 = 20;
					val[val.Row, 70] = Strings.Format((object)Conversion.Val(val[val.Row, 20]), "0.00");
					goto IL_038e;
					IL_038e:
					num2 = 21;
					if ((Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_03ee;
					}
					goto IL_046c;
					IL_03ee:
					num2 = 22;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])) * (Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])) / 100.0), "0.000");
					goto IL_046c;
					IL_046c:
					num2 = 25;
					if (Conversion.Val(val[val.Row, 21]) != Conversion.Val(val[val.Row, 71]))
					{
						goto IL_04a3;
					}
					goto IL_05b5;
					IL_04a3:
					num2 = 26;
					val[val.Row, 71] = Strings.Format((object)Conversion.Val(val[val.Row, 21]), "0.00");
					goto IL_04d7;
					IL_04d7:
					num2 = 27;
					if ((Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_0537;
					}
					goto IL_05b5;
					IL_0537:
					num2 = 28;
					val[val.Row, 22] = Strings.Format((object)((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])) * (Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21])) / 100.0), "0.000");
					goto IL_05b5;
					IL_05b5:
					num2 = 31;
					if (Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) == 0.0)
					{
						goto IL_05f0;
					}
					goto IL_063a;
					IL_05f0:
					num2 = 32;
					val[val.Row, 22] = Strings.Format((object)(Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])), "0.000");
					goto IL_063a;
					IL_063a:
					num2 = 34;
					if ((Conversion.Val(val[val.Row, 43]) != 0.0) & (Conversion.Val(val[val.Row, 15]) != 0.0))
					{
						goto IL_0686;
					}
					goto IL_06d0;
					IL_0686:
					num2 = 35;
					val[val.Row, 44] = Strings.Format((object)(Conversion.Val(val[val.Row, 15]) - Conversion.Val(val[val.Row, 43])), "0.000");
					goto IL_06d0;
					IL_06d0:
					num2 = 37;
					if (Conversion.Val(val[val.Row, 44]) != Conversion.Val(val[val.Row, 72]))
					{
						goto IL_0707;
					}
					goto IL_0850;
					IL_0707:
					num2 = 38;
					val[val.Row, 72] = Strings.Format((object)Conversion.Val(val[val.Row, 44]), "0.000");
					goto IL_073b;
					IL_073b:
					num2 = 39;
					if ((Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48]) != 0.0) & (Conversion.Val(val[val.Row, 44]) != 0.0))
					{
						goto IL_079b;
					}
					goto IL_0819;
					IL_079b:
					num2 = 40;
					val[val.Row, 49] = Strings.Format((object)((Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 46])) * (Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48])) / 100.0), "0.000");
					goto IL_0850;
					IL_0819:
					num2 = 42;
					val[val.Row, 49] = Strings.Format((object)Conversion.Val(val[val.Row, 44]), "0.000");
					goto IL_0850;
					IL_0850:
					num2 = 45;
					if (Conversion.Val(val[val.Row, 47]) != Conversion.Val(val[val.Row, 73]))
					{
						goto IL_0887;
					}
					goto IL_0999;
					IL_0887:
					num2 = 46;
					val[val.Row, 73] = Strings.Format((object)Conversion.Val(val[val.Row, 47]), "0.00");
					goto IL_08bb;
					IL_08bb:
					num2 = 47;
					if ((Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48]) != 0.0) & (Conversion.Val(val[val.Row, 44]) != 0.0))
					{
						goto IL_091b;
					}
					goto IL_0999;
					IL_091b:
					num2 = 48;
					val[val.Row, 49] = Strings.Format((object)((Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 46])) * (Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48])) / 100.0), "0.000");
					goto IL_0999;
					IL_0999:
					num2 = 51;
					if (Conversion.Val(val[val.Row, 48]) != Conversion.Val(val[val.Row, 74]))
					{
						goto IL_09d0;
					}
					goto IL_0ae2;
					IL_09d0:
					num2 = 52;
					val[val.Row, 74] = Strings.Format((object)Conversion.Val(val[val.Row, 48]), "0.00");
					goto IL_0a04;
					IL_0a04:
					num2 = 53;
					if ((Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48]) != 0.0) & (Conversion.Val(val[val.Row, 44]) != 0.0))
					{
						goto IL_0a64;
					}
					goto IL_0ae2;
					IL_0a64:
					num2 = 54;
					val[val.Row, 49] = Strings.Format((object)((Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 46])) * (Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48])) / 100.0), "0.000");
					goto IL_0ae2;
					IL_0ae2:
					num2 = 57;
					if (Conversion.Val(val[val.Row, 47]) + Conversion.Val(val[val.Row, 48]) == 0.0)
					{
						goto IL_0b1d;
					}
					goto IL_0b67;
					IL_0b1d:
					num2 = 58;
					val[val.Row, 49] = Strings.Format((object)(Conversion.Val(val[val.Row, 44]) + Conversion.Val(val[val.Row, 46])), "0.000");
					goto IL_0b67;
					IL_0b67:
					num2 = 60;
					if ((Conversion.Val(val[val.Row, 23]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_0bb7;
					}
					goto IL_0d60;
					IL_0bb7:
					num2 = 61;
					switch (val[val.Row, 58])
					{
					case "P":
						break;
					case "1":
						goto IL_0c54;
					case "K":
						goto IL_0cb2;
					default:
						goto IL_0d0d;
					}
					goto IL_0c00;
					IL_0d0d:
					num2 = 69;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_0d60;
					IL_0cb2:
					num2 = 67;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * (Conversion.Val(val[val.Row, 23]) / 1000.0), 0), "0.00");
					goto IL_0d60;
					IL_0c54:
					num2 = 65;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * (Conversion.Val(val[val.Row, 23]) / 10.0), 0), "0.00");
					goto IL_0d60;
					IL_0c00:
					num2 = 63;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_0d60;
					IL_0d60:
					num2 = 72;
					if ((Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_0daf;
					}
					goto IL_0e64;
					IL_0daf:
					num2 = 73;
					val[val.Row, 27] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 23]) * Conversion.Val(val[val.Row, 25]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_0e0b;
					IL_0e0b:
					num2 = 74;
					if (Conversion.Val(val[val.Row, 25]) == 0.0)
					{
						goto IL_0e32;
					}
					goto IL_0e64;
					IL_0e32:
					num2 = 75;
					val[val.Row, 27] = "";
					goto IL_0e49;
					IL_0e49:
					num2 = 76;
					val[val.Row, 28] = "";
					goto IL_0e64;
					IL_0e64:
					num2 = 79;
					if (Conversion.Val(val[val.Row, 27]) != 0.0)
					{
						goto IL_0e92;
					}
					goto IL_10c8;
					IL_0e92:
					num2 = 80;
					switch (val[val.Row, 26])
					{
					case "P":
						break;
					case "N":
						goto IL_0f2f;
					case "K":
						goto IL_1006;
					default:
						goto IL_1075;
					}
					goto IL_0edb;
					IL_1075:
					num2 = 92;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 15]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_10c8;
					IL_1006:
					num2 = 90;
					val[val.Row, 28] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])) * (Conversion.Val(val[val.Row, 27]) / 1000.0), 0), "0.00");
					goto IL_10c8;
					IL_0f2f:
					num2 = 84;
					if (Operators.CompareString(DC_Main.MsLbrWithGht, "N", false) == 0)
					{
						goto IL_0f4b;
					}
					goto IL_0f9d;
					IL_0f4b:
					num2 = 85;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 17]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_10c8;
					IL_0f9d:
					num2 = 87;
					val[val.Row, 28] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 17]) + Conversion.Val(val[val.Row, 19])) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_10c8;
					IL_0edb:
					num2 = 82;
					val[val.Row, 28] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 14]) * Conversion.Val(val[val.Row, 27]), 0), "0.00");
					goto IL_10c8;
					IL_10c8:
					num2 = 95;
					if (Conversion.Val(val[val.Row, 30]) != 0.0)
					{
						goto IL_10f5;
					}
					goto IL_11a6;
					IL_10f5:
					num2 = 96;
					if ((Conversion.Val(val[val.Row, 31]) != 0.0) & (Conversion.Val(val[val.Row, 30]) != 0.0))
					{
						goto IL_1141;
					}
					goto IL_1251;
					IL_1141:
					num2 = 97;
					val[val.Row, 32] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 30]) * Conversion.Val(val[val.Row, 31]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_1251;
					end_IL_0001_2:
					break;
				}
				num2 = 106;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 5283;
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
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a1: Invalid comparison between Unknown and I4
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06b5: Invalid comparison between Unknown and I4
		//IL_06c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Invalid comparison between Unknown and I4
		//IL_0760: Unknown result type (might be due to invalid IL or missing references)
		//IL_0763: Invalid comparison between Unknown and I4
		//IL_03d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_07df: Invalid comparison between Unknown and I4
		//IL_0830: Unknown result type (might be due to invalid IL or missing references)
		//IL_0833: Invalid comparison between Unknown and I4
		//IL_088b: Unknown result type (might be due to invalid IL or missing references)
		//IL_088e: Invalid comparison between Unknown and I4
		//IL_560b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5a64: Unknown result type (might be due to invalid IL or missing references)
		//IL_38bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bf7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2431: Unknown result type (might be due to invalid IL or missing references)
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
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 57]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][20])) == Conversion.Val(mSG[mSG.Row, 57]))
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
							mSG[mSG.Row, 57] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 57] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 57]) + 1.0);
						}
					}
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			if (mSG.Col == 8)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "DM043NEDM", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,A.DIE_NO As RemarkL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 6] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.DESIGN_NO as DesignL,BOOK_NAME As BookNameL,B.PR_NAME As ProductL,A.ITM_SIZE as SizeL,A.KR_NAME As KrNameL,A.ITM_GWT As GrwtW,A.ITM_TOUCH As TouchR,A.ITM_WEST_PRC AS WestPrcR,A.LBR_PRC AS LbrPrcR,A.LBR_RATE As LbrRateR,A.DESIGN_IMG_ID As DesignIdL FROM (DESIGN_DETL AS A LEFT JOIN PRODUCT_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.PR_CODE = B.PR_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.PR_CODE = C.PR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND C.IT_CODE = '" + mSG[mSG.Row, 6] + "' ORDER BY A.BOOK_NAME,A.DESIGN_NO,A.SR_NO";
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
					mSG[mSG.Row, 8] = DC_Main.ColValue[0];
					mSG[mSG.Row, 9] = DC_Main.ColValue[3];
					mSG[mSG.Row, 34] = DC_Main.ColValue[4];
					if (Operators.CompareString(mSG[mSG.Row, 63], "E", false) != 0)
					{
						if (Conversion.Val(DC_Main.ColValue[5]) != 0.0)
						{
							mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
						}
						if (Conversion.Val(DC_Main.ColValue[6]) != 0.0)
						{
							mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[7]) != 0.0)
						{
							mSG[mSG.Row, 21] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) != 0.0)
						{
							mSG[mSG.Row, 25] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
						}
						if (Conversion.Val(DC_Main.ColValue[8]) == 0.0 && Conversion.Val(DC_Main.ColValue[9]) != 0.0)
						{
							mSG[mSG.Row, 27] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[9]), "0.00");
						}
					}
					mSG[mSG.Row, 76] = DC_Main.ColValue[10];
					MsgOldRow = 0;
					MSG_RowColChange(MSG, new EventArgs());
				}
				else
				{
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 8] = "";
					mSG[mSG.Row, 76] = "N";
				}
				((Control)TEXT_ENTRY).Focus();
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
				if (Operators.ConditionalCompareObjectGreater((object)mSG.Col, Interaction.IIf((Operators.CompareString(FormMainBook, "CON REC", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0), (object)4, (object)1), false))
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
						DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode From SL_ORD_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + mSG[mSG.Row, 42] + "' AND CO_YEAR = '" + mSG[mSG.Row, 37] + "' AND CO_BOOK = '" + mSG[mSG.Row, 38] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 39])) + " AND VCH_NO = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_NO As VchNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.SR_NO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL,A.AC_CODE As AcCodeL,A.LC_CODE As OrdLcM FROM (SL_ORD_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)(" AND A.LC_CODE = '" + DC_Main.MLc_code + "'"), (object)(" AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND A.DESIGN_ISU = 'N' AND A.TAG_STK_LESS <> 'Y'  ORDER BY A.LC_CODE,A.VCH_DATE,A.VCH_NO,A.SR_NO"));
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[14];
							DC_Main.ColWidth[0] = 90.0;
							DC_Main.ColWidth[1] = 150.0;
							DC_Main.ColWidth[2] = 100.0;
							DC_Main.ColWidth[3] = 200.0;
							DC_Main.ColWidth[4] = 225.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 100.0;
							DC_Main.ColWidth[7] = 60.0;
							DC_Main.ColWidth[8] = 80.0;
							DC_Main.ColWidth[9] = 70.0;
							DC_Main.ColWidth[10] = 0.0;
							DC_Main.ColWidth[11] = 0.0;
							DC_Main.ColWidth[12] = 90.0;
							DC_Main.HelpSelect = 0;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 62] = DC_Main.ColValue[1];
									mSG[mSG.Row, 6] = DC_Main.ColValue[10];
									mSG[mSG.Row, 8] = DC_Main.ColValue[2];
									mSG[mSG.Row, 11] = DC_Main.ColValue[4];
									mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
									mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
									mSG[mSG.Row, 37] = DC_Main.ColValue[8];
									mSG[mSG.Row, 38] = DC_Main.ColValue[9];
									mSG[mSG.Row, 39] = DC_Main.ColValue[7];
									mSG[mSG.Row, 3] = DC_Main.ColValue[3];
									mSG[mSG.Row, 40] = DC_Main.ColValue[11];
									mSG[mSG.Row, 42] = DC_Main.ColValue[12];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 40] = "";
									mSG[mSG.Row, 42] = "";
									mSG[mSG.Row, 1] = "";
									mSG[mSG.Row, 37] = "";
									mSG[mSG.Row, 38] = "";
									mSG[mSG.Row, 39] = "";
									mSG[mSG.Row, 41] = "";
									mSG[mSG.Row, 5] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 42] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LC_CODE"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[DC_Main.i, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[DC_Main.i, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							mSG[DC_Main.i, 38] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							mSG[DC_Main.i, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)""));
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DEL_DATE"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""), (object)"", false))
							{
								mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							}
							else
							{
								mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							}
							mSG[DC_Main.i, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 14] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
						}
						int num13 = 0;
						int num14 = DtIdtl.Rows.Count - 1;
						int num15 = num14;
						for (int k = 0; k <= num15; k++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num13][20], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
							{
								DtIdtl.Rows[num13].Delete();
								DtIdtl.AcceptChanges();
								num13--;
							}
							num13++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + mSG[mSG.Row, 42] + "' AND CO_YEAR = '" + mSG[mSG.Row, 37] + "' AND CO_BOOK = '" + mSG[mSG.Row, 38] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 39])) + " AND VCH_NO = '" + mSG[mSG.Row, 1] + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[20] = Conversion.Val(MSG[mSG.Row, 57]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[7] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[11] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (mSG.Row == mSG.Rows - 1)
						{
							CommPassTotal();
							MSG_RowColChange(MSG, new EventArgs());
							MsgOldRow = 0;
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							mSG.Col = 1;
							MsgClear = false;
							CommPassAdd();
							return;
						}
						break;
					}
					case 5:
					{
						if (((Operators.CompareString(FormMainBook, "APR RTN", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)) && ((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | ((Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 5], false) != 0) & (mSG.Col == 5))))
						{
							if (Operators.CompareString(tIsuNo.Text, "", false) != 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'  AND A.AC_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "CON ISU", false) == 0, (object)"AND A.BOOK_NAME = 'CON REC' AND A.CON_ISU_REC = 'N'", (object)"AND A.BOOK_NAME = 'APR ISU' AND A.ISU_REC = 'N'")), (object)""));
							}
							else
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'  AND A.AC_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "CON ISU", false) == 0, (object)"AND A.BOOK_NAME = 'CON REC' AND A.CON_ISU_REC = 'N'", (object)"AND A.BOOK_NAME = 'APR ISU' AND A.ISU_REC = 'N'")), (object)" AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"' "));
							}
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_NO As IsuNoL,A.CO_YEAR As IsuYearL,A.CO_BOOK As IsuBookL,A.OLD_SRNO As IsuSrNoL  From APR_DETL AS A LEFT JOIN  ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "CON ISU", false) == 0, (object)"AND A.BOOK_NAME = 'CON REC' AND A.CON_ISU_REC = 'N'", (object)"AND A.BOOK_NAME = 'APR ISU' AND A.ISU_REC = 'N'")), (object)"  ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO "));
								}
								else
								{
									DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO AS TagNoL,A.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,A.ITM_GWT AS GrWtW,A.ITM_NWT AS NetWtW,A.ITM_MRP as MrpR,A.VCH_SRNO,A.VCH_NO As IsuNoL,A.CO_YEAR As IsuYearL,A.CO_BOOK As IsuBookL,A.OLD_SRNO As IsuSrNoL  From APR_DETL AS A LEFT JOIN  ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "CON ISU", false) == 0, (object)"AND A.BOOK_NAME = 'CON REC' AND A.CON_ISU_REC = 'N'", (object)"AND A.BOOK_NAME = 'APR ISU' AND A.ISU_REC = 'N'")), (object)"  ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO,A.SR_NO "));
								}
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[13];
								DC_Main.ColWidth[0] = 100.0;
								DC_Main.ColWidth[1] = 90.0;
								DC_Main.ColWidth[2] = 250.0;
								DC_Main.ColWidth[3] = 80.0;
								DC_Main.ColWidth[4] = 90.0;
								DC_Main.ColWidth[5] = 90.0;
								DC_Main.ColWidth[6] = 100.0;
								DC_Main.ColWidth[7] = 0.0;
								DC_Main.ColWidth[8] = 90.0;
								DC_Main.ColWidth[9] = 100.0;
								DC_Main.ColWidth[10] = 80.0;
								DC_Main.ColWidth[11] = 70.0;
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
										mSG[mSG.Row, 8] = DC_Main.ColValue[0];
									}
									else
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[0];
										mSG[mSG.Row, 8] = DC_Main.ColValue[1];
									}
									mSG[mSG.Row, 62] = DC_Main.ColValue[2];
									mSG[mSG.Row, 6] = DC_Main.ColValue[3];
									mSG[mSG.Row, 15] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 17] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 41] = DC_Main.ColValue[7];
									mSG[mSG.Row, 36] = DC_Main.ColValue[8];
									mSG[mSG.Row, 37] = DC_Main.ColValue[9];
									mSG[mSG.Row, 38] = DC_Main.ColValue[10];
									mSG[mSG.Row, 39] = DC_Main.ColValue[11];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 36] = "";
									mSG[mSG.Row, 37] = "";
									mSG[mSG.Row, 38] = "";
									mSG[mSG.Row, 39] = "";
									mSG[mSG.Row, 41] = "";
									mSG[mSG.Row, 5] = "";
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
							mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							DC_Main.i = mSG.Row;
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								mSG[DC_Main.i, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
								mSG[DC_Main.i, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
								mSG[DC_Main.i, 38] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
								mSG[DC_Main.i, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)""));
								mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
								mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
								mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
								mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
								mSG[DC_Main.i, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
								mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
								mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
								mSG[DC_Main.i, 14] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
								mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
								mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
								mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
								mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
								mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
								mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
								mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
								mSG[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
								mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
								mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
								mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
								mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_NET_WT"])), "0.00");
								mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_TOUCH"])), "0.00");
								mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"])), "0.00");
								mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_FINE"])), "0.000");
								mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
								mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
								mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
								mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
								if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])) != 0.0)
								{
									mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
								}
								mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
								mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
								mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
								mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
								mSG[DC_Main.i, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
							}
							int num5 = 0;
							int num6 = DtIdtl.Rows.Count - 1;
							int num7 = num6;
							for (int i = 0; i <= num7; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num5][20], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
								{
									DtIdtl.Rows[num5].Delete();
									DtIdtl.AcceptChanges();
									num5--;
								}
								num5++;
							}
							MSG_IDTL_CLEAR();
							DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 5] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 41] + " ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.i = 0;
							while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
							{
								dr = DtIdtl.NewRow();
								dr[20] = Conversion.Val(MSG[mSG.Row, 57]);
								dr[0] = DC_Main.i + 1;
								dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
								dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
								dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
								dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
								dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
								dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
								dr[7] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
								dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
								dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
								dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
								dr[11] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
								dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
								dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
								dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
								dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
								dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
								dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
								dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
								dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
								DtIdtl.Rows.Add(dr);
								DC_Main.i++;
							}
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							MSG_TOT_FILL();
							if (mSG.Row == mSG.Rows - 1)
							{
								CommPassTotal();
								MsgOldRow = 0;
								MSG_RowColChange(MSG, new EventArgs());
								MsgClear = true;
								mSG.Rows += 1;
								mSG.Row += 1;
								mSG.Col = 1;
								MsgClear = false;
								CommPassAdd();
								return;
							}
						}
						if (Operators.CompareString(FormBookInOut, "O", false) != 0 || !((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 5], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 41]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 41]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsDesignHelp, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select C.DESIGN_NO AS DesignNoL,A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY SUBSTRING(C.DESIGN_NO,1,2), LEN(C.DESIGN_NO),C.DESIGN_NO,A.TAG_NO,C.VCH_TIME DESC"));
							}
							else
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,C.DESIGN_NO AS DesignNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
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
									mSG[mSG.Row, 8] = DC_Main.ColValue[0];
								}
								else
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[0];
									mSG[mSG.Row, 8] = DC_Main.ColValue[1];
								}
								mSG[mSG.Row, 62] = DC_Main.ColValue[2];
								mSG[mSG.Row, 6] = DC_Main.ColValue[3];
								mSG[mSG.Row, 15] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 17] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 41] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
							else
							{
								mSG[mSG.Row, 41] = "";
								mSG[mSG.Row, 5] = "";
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						int num8 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num8)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 5], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
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
								mSG[mSG.Row, 62] = DC_Main.ColValue[1];
								mSG[mSG.Row, 6] = DC_Main.ColValue[0];
								mSG[mSG.Row, 8] = DC_Main.ColValue[3];
								mSG[mSG.Row, 15] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 17] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 41] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
								return;
							}
						}
						mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME,B.GR_CODE FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 41]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["HM_ID"], (object)""));
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 14] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							if (Operators.CompareString(FormMainBook, "APR ISU", false) == 0 && ((Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")) == 0.0) & (Operators.CompareString(DC_Main.MsWorkType, "R", false) == 0)) && ((Conversion.Val(mSG[mSG.Row, 30]) == 0.0) & (DC_Main.RtView != null)))
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT GR_RATE FROM RATE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND GR_CODE = '"), DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
								DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								double num9 = default(double);
								if (dataTable.Rows.Count > 0)
								{
									num9 = Conversions.ToDouble(dataTable.Rows[0]["GR_RATE"]);
								}
								else
								{
									DC_Main.RtView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"GR_CODE = '", DC_Main.Rshlp.Rows[0]["GR_CODE"]), (object)"'"));
									if (DC_Main.RtView.Count > 0)
									{
										num9 = Conversions.ToDouble(DC_Main.RtView[0]["GR_RATE"]);
									}
								}
								if (num9 > 0.0)
								{
									if (Operators.CompareString(mSG[DC_Main.i, 58], "G", false) == 0)
									{
										mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(num9 / 10.0, 2), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 58], "K", false) == 0)
									{
										mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(num9 * 10.0, 0), "0.00");
									}
									else if (Operators.CompareString(mSG[DC_Main.i, 58], "1", false) == 0)
									{
										mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(num9, 0), "0.00");
									}
									else
									{
										mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(num9 / 10.0, 2), "0.00");
									}
								}
								else
								{
									mSG[mSG.Row, 23] = "";
								}
							}
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 44] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.00");
							mSG[DC_Main.i, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_OTH_WT"])), "0.00");
							mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
							mSG[DC_Main.i, 48] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
							mSG[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])) != 0.0)
							{
								mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							}
							mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[DC_Main.i, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
						}
						int num10 = 0;
						int num11 = DtIdtl.Rows.Count - 1;
						int num12 = num11;
						for (int j = 0; j <= num12; j++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num10][20], (object)Conversion.Val(mSG[DC_Main.i, 57]), false))
							{
								DtIdtl.Rows[num10].Delete();
								DtIdtl.AcceptChanges();
								num10--;
							}
							num10++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)mSG[mSG.Row, 5]), (object)"' AND A.VCH_SRNO = "), (object)mSG[mSG.Row, 41]), (object)" "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[20] = Conversion.Val(MSG[mSG.Row, 57]);
							dr[0] = DC_Main.i + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_CODE"], (object)"");
							dr[4] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_NAME"], (object)"");
							dr[5] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SIZE"], (object)"");
							dr[6] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DM_SFNO"], (object)"");
							dr[7] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WT"])), "0.000");
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[11] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							if (Operators.CompareString(FormMainBook, "APR ISU", false) == 0)
							{
								if (DvAcRate != null)
								{
									DvAcRate.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"AC_IT_CODE =  '", DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"]), (object)""), (object)"'"));
									if (DvAcRate.Count > 0)
									{
										dr[12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DvAcRate[0]["AC_RATE"], (object)"")), "0.00");
									}
									else
									{
										dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
									}
								}
								else
								{
									dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
								}
							}
							else
							{
								dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
							}
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
							dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
							dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
							dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
							dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
							dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (mSG.Row == mSG.Rows - 1)
						{
							CommPassTotal();
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							mSG.Col = 1;
							MsgClear = false;
							CommPassAdd();
							return;
						}
						break;
					}
					case 4:
					case 6:
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
									mSG[mSG.Row, 4] = DC_Main.ColValue[1];
									mSG[mSG.Row, 6] = DC_Main.ColValue[1];
									mSG[mSG.Row, 62] = DC_Main.ColValue[0];
									mSG[mSG.Row, 61] = DC_Main.ColValue[3];
									mSG[mSG.Row, 59] = DC_Main.ColValue[4];
									mSG[mSG.Row, 60] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 60] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
						mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						if (Operators.CompareString(FormMainBook, "CON REC", false) == 0 && ((Operators.CompareString(mSG[mSG.Row, 60], mSG[mSG.Row, 64], false) != 0) | (Operators.CompareString(mSG[mSG.Row, 61], mSG[mSG.Row, 65], false) != 0)))
						{
							mSG[mSG.Row, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 5] = "";
							mSG[mSG.Row, 56] = "";
						}
						break;
					case 7:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
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
									mSG[mSG.Row, 7] = DC_Main.ColValue[1];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
						break;
					case 15:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
						CommPassTotal();
						((Control)TEXT_ENTRY).Visible = false;
						MSG_IDTL.Row = MSG_IDTL.Rows - 1;
						MSG_IDTL.Col = 1;
						MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
						((Control)TEXT_IDTL).Focus();
						((TextBoxBase)TEXT_IDTL).SelectAll();
						return;
					case 33:
					case 34:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
							{
								mSG.Col = 4;
							}
							else
							{
								mSG.Col = 1;
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

	private void TR_APR_ISU_Load(object sender, EventArgs e)
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
		//IL_0fab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb5: Expected O, but got Unknown
		//IL_0fff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1004: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e: Expected O, but got Unknown
		//IL_1033: Unknown result type (might be due to invalid IL or missing references)
		//IL_1038: Unknown result type (might be due to invalid IL or missing references)
		//IL_1042: Expected O, but got Unknown
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
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
				((Control)chkWapp).Font = new Font("Segoe UI Semibold", (float)num3, (FontStyle)0);
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
			if ((Operators.CompareString(DC_Main.MsWhatsAppOpen, "Y", false) == 0) | DC_Main.MsEmailOpen)
			{
				((Control)chkWapp).Visible = true;
			}
			if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
			{
				((Control)BtnImgC).Visible = true;
				((Control)BtnImgS).Visible = true;
				((Control)BtnImgD).Visible = true;
				((Control)chkWapp).Visible = true;
				tLcCode.Text = DC_Main.MLc_code;
				if (DC_Main.MsLcBoxShow)
				{
					((Control)tLcCode).Visible = true;
				}
			}
			else if (Operators.CompareString(FormMainBook, "CON REC", false) != 0)
			{
				if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
				{
					((Control)Label5).Visible = true;
					((Control)tIsuNo).Visible = true;
					((Control)tIsuDbCd).Visible = true;
					((Control)tIsuYrCd).Visible = true;
					((Control)btnIsuNo).Visible = true;
				}
				else if (Operators.CompareString(FormBookInOut, "I", false) == 0)
				{
					((Control)Label5).Visible = true;
					((Control)tIsuNo).Visible = true;
					((Control)tIsuDbCd).Visible = true;
					((Control)tIsuYrCd).Visible = true;
					((Control)btnIsuNo).Visible = true;
					if (Operators.CompareString(DC_Main.SSRegSrNo, "VK046NEVK", false) == 0)
					{
						DC_Main.ExeQuteDc("UPDATE APR_DETL SET ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
						DC_Main.RsQry = "SELECT A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,A.ISU_SRNO FROM APR_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'APR RTN' AND A.ISU_NO <> ''  UNION ALL SELECT B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,B.ISU_SRNO FROM SL_DETL AS B  WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.BOOK_NAME = 'SALES' AND B.ISU_NO <> ''  UNION ALL SELECT C.ISU_YRCD,C.ISU_DBCD,C.ISU_NO,C.ISU_SRNO FROM RATE_CUT_ISU AS C  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.BOOK_NAME = 'WH SALES' AND C.ISU_NO <> ''";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.M = 0;
						while (DC_Main.M < DC_Main.Tbl.Rows.Count)
						{
							DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE APR_DETL SET ISU_REC = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_YRCD"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_DBCD"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_NO"]), (object)"' AND OLD_SRNO = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_SRNO"]), (object)"'")));
							DC_Main.M++;
						}
					}
				}
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
		OldValTot = 0.0;
		NewValTot = 0.0;
		AcMobile = "";
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		UsUPdate = "N";
		UsDelete = "N";
		if (RsAcOthRate != null)
		{
			RsAcOthRate.Clear();
		}
		DvAcRate = null;
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
			tLcCode.Text = DC_Main.MLc_code;
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.RsQry = "SELECT * FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME,AC_MOBILE FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
					AcMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_MOBILE"], (object)""));
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
				tIsuYrCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_YRCD"], (object)""));
				tIsuDbCd.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_DBCD"], (object)""));
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
				CurPrnVch = tVchNo.Text;
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
					{
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					}
					else
					{
						mSG[DC_Main.i + 1, 36] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["MTL_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 40] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 62] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
					{
						mSG[DC_Main.i + 1, 5] = "";
					}
					else
					{
						mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					}
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DISC_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 33] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["NET_AMT"], (object)"")), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_REC"], (object)""));
					mSG[DC_Main.i + 1, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 38] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_SRNO"], (object)"")), "0");
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_LC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORNA_REC_DATE"], (object)""));
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 75] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_SALE"], (object)""));
					mSG[DC_Main.i + 1, 63] = "E";
					mSG[DC_Main.i + 1, 76] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
					mSG[DC_Main.i + 1, 77] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["CON_ISU_REC"], (object)""));
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
					dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[11] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[19] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 17]) + Conversion.Val(MSG_TOT[0, 44]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 28]);
				NewValTot = Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 17]) + Conversion.Val(MSG_TOT[0, 44]) + Conversion.Val(MSG_TOT[0, 29]) + Conversion.Val(MSG_TOT[0, 28]);
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

	private void TR_APR_ISU_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_APR_ISU_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Unknown result type (might be due to invalid IL or missing references)
		//IL_044e: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
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
		if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			((Control)tEmpCode).Focus();
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
		DC_Main.MsTagVchSrnoUpdate = false;
		MSG_TOT_FILL();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		if ((Operators.CompareString(FormMainBook, "CON ISU", false) == 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT - B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT - B.ITM_NWT FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_TOT[0, 30]) + Conversion.Val(MSG_TOT[0, 33]) != 0.0) | (Conversion.Val(MSG_TOT[0, 15]) + Conversion.Val(MSG_TOT[0, 28]) + Conversion.Val(MSG_TOT[0, 29]) != 0.0))
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
			DC_Main.RsQry = "SELECT * FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
			dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["ISU_NO"] = tIsuNo.Text;
			dataRow2["ISU_LC_CODE"] = DC_Main.MLc_code;
			dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
			dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		DC_Main.RsQry = "SELECT * FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				if (((Operators.CompareString(mSG[DC_Main.i, 6], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 15]) + Conversion.Val(mSG[DC_Main.i, 28]) + Conversion.Val(mSG[DC_Main.i, 29]) != 0.0))
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
					dataRow3["ENTRY_TYPE"] = "A";
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 57]);
					if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
					{
						dataRow3["ISU_NO"] = mSG[DC_Main.i, 1];
					}
					else
					{
						dataRow3["ISU_NO"] = mSG[DC_Main.i, 36];
					}
					dataRow3["ISU_AC_NAME"] = mSG[DC_Main.i, 3];
					dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 11];
					dataRow3["MTL_COLOR"] = mSG[DC_Main.i, 12];
					dataRow3["ISU_AC_CODE"] = mSG[DC_Main.i, 40];
					if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
					{
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 4];
					}
					else
					{
						dataRow3["IT_CODE"] = mSG[DC_Main.i, 6];
					}
					if (Operators.CompareString(mSG[DC_Main.i, 5], "", false) == 0)
					{
						dataRow3["TAG_NO"] = "N";
						dataRow3["VCH_SRNO"] = 0;
					}
					else
					{
						dataRow3["TAG_NO"] = mSG[DC_Main.i, 5];
						dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 41]);
					}
					dataRow3["TBL_CODE"] = mSG[DC_Main.i, 7];
					dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 8];
					dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 9];
					dataRow3["HM_ID"] = mSG[DC_Main.i, 10];
					dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 15]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 16]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 17]);
					dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 20]);
					dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 21]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 22]);
					dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 26];
					dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 27]);
					dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 23]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
					dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 30]);
					dataRow3["DISC_PRC"] = Conversion.Val(mSG[DC_Main.i, 31]);
					dataRow3["DISC_AMT"] = Conversion.Val(mSG[DC_Main.i, 32]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 33]);
					dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 44]);
					dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 47]);
					dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 48]);
					dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 49]);
					dataRow3["KR_NAME"] = mSG[DC_Main.i, 34];
					dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 58];
					dataRow3["IT_TYPE"] = mSG[DC_Main.i, 59];
					dataRow3["PR_CODE"] = mSG[DC_Main.i, 61];
					dataRow3["ISU_REC"] = mSG[DC_Main.i, 35];
					dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 37];
					dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 38];
					dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 39]);
					dataRow3["ISU_LC_CODE"] = mSG[DC_Main.i, 42];
					dataRow3["EMP_SALE"] = mSG[DC_Main.i, 75];
					dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 76];
					if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
					{
						dataRow3["ISU_LC_CODE"] = mSG[DC_Main.i, 42];
						dataRow3["ORNA_REC_DATE"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(mSG[DC_Main.i, 2], "", false) == 0, (object)DBNull.Value, (object)mSG[DC_Main.i, 2]));
					}
					else
					{
						dataRow3["ISU_LC_CODE"] = DC_Main.MLc_code;
						dataRow3["ORNA_REC_DATE"] = mVchDate.Text;
					}
					dataRow3["CON_ISU_REC"] = mSG[DC_Main.i, 77];
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["MAIN_USER"] = MainUser;
					dataRow3["EMP_CODE"] = tEmpCode.Text;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			if (((Operators.CompareString(FormMainBook, "APR ISU", false) == 0) & (Operators.CompareString(DC_Main.MsAprImgPrint, "Y", false) == 0)) | ((Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0) | (Operators.CompareString(DC_Main.MsKrDesignImgPrint, "Y", false) == 0)))
			{
				DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					AxMSFlexGrid mSG2 = MSG;
					if (Operators.CompareString(MSG[DC_Main.i, 76], "N", false) != 0)
					{
						DC_Main.MsImageNo = MSG[DC_Main.i, 76];
						DC_Main.MsImageType = "TagImage";
					}
					else if (Operators.CompareString(mSG2[DC_Main.i, 5], "", false) != 0)
					{
						DC_Main.MsImageNo = mSG2[DC_Main.i, 5] + "_" + mSG2[DC_Main.i, 41];
						DC_Main.MsImageType = "TagImage";
					}
					else if (Operators.CompareString(mSG2[DC_Main.i, 8], "", false) != 0)
					{
						DC_Main.MsImageNo = mSG2[DC_Main.i, 8] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
						if (Operators.CompareString(mSG2[DC_Main.i, 76], "N", false) != 0)
						{
							dataRow4["TAG_NO"] = mSG2[DC_Main.i, 76];
						}
						else
						{
							dataRow4["TAG_NO"] = mSG2[DC_Main.i, 5];
						}
						dataRow4["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 41]);
						dataRow4["DESIGN"] = mSG2[DC_Main.i, 8];
						dataRow4["TAG_IMAGE"] = buffer;
						dataTable2.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
						dataTable2.Clear();
					}
					mSG2 = null;
					DC_Main.i++;
				}
			}
			DC_Main.RsQry = "SELECT * FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow5 = RsIdtl.NewRow();
			int num3 = 0;
			int num4 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])) != 0.0)
				{
					int num5 = MSG.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num5)
					{
						if (Conversion.Val(MSG[DC_Main.M, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])))
						{
							num3 = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
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
					dataRow5["ENTRY_TYPE"] = "A";
					dataRow5["BOOK_NAME"] = FormMainBook;
					dataRow5["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow5["TAG_NO"] = MSG[num3, 5];
					dataRow5["VCH_SRNO"] = Conversion.Val(MSG[num3, 41]);
					dataRow5["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow5["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow5["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
					dataRow5["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
					dataRow5["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
					dataRow5["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
					dataRow5["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
					dataRow5["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
					dataRow5["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
					dataRow5["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow5["IT_RATE_TYPE"] = Operators.ConcatenateObject(DtIdtl.Rows[i][11], (object)"");
					dataRow5["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow5["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
					dataRow5["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow5["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow5["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow5["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow5["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
					dataRow5["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow5);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			WappMsg = ("Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " TotGwt :" + Conversions.ToString(Conversion.Val(MSG_TOT[0, 15])) + " TotNwt :" + Conversions.ToString(Conversion.Val(MSG_TOT[0, 17])) + "  Thanks Regard  " + DC_Main.MCo_Name) ?? "";
			AdminWappMsg = tAcName.Text + " Book = " + DC_Main.MCo_Book + " Bill No = " + tVchNo.Text + " TotGwt :" + Conversions.ToString(Conversion.Val(MSG_TOT[0, 15])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG_TOT[0, 17]));
			if (Operators.CompareString(EntryMode, "E", false) == 0)
			{
				WappMsg = "";
				AdminWappMsg = "";
			}
			WappAcName = tAcName.Text;
			WappMobile = AcMobile;
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
			{
				DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.DESIGN_ISU = 'Y' FROM SL_ORD_DETL,APR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.ISU_LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ISU_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ISU_DBCD AND SL_ORD_DETL.VCH_NO = B.ISU_NO AND SL_ORD_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
			{
				InsertTagDataEntry();
				Ac_Stock.Consi_Rec_Stk(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT + B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT + B.ITM_NWT FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.CON_ISU_REC = 'Y' FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Consi_Isu_Stk(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "APR RTN", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y' FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'N',BAR_DETL.APP_TRFR = 'N' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.TAG_NO = B.TAG_NO  AND APR_DETL.VCH_SRNO = B.VCH_SRNO AND APR_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND APR_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND APR_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND APR_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Apr_Rtn_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Dm_Apr_Trfr_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "APR ISU", false) == 0)
			{
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.TAG_NO = B.TAG_NO  AND APR_DETL.VCH_SRNO = B.VCH_SRNO AND APR_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND APR_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND APR_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND APR_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.VCH_NO = '" + tVchNo.Text + "' AND APR_DETL.ISU_REC = 'N' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Apr_Isu_Stk(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Dm_Apr_Trfr_Detl(DC_Main.MCo_Book, tVchNo.Text);
			}
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
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
	}

	private void InsertTagDataEntry()
	{
		DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
		DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
		DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow = dataTable.NewRow();
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				AxMSFlexGrid mSG = MSG;
				if (((Operators.CompareString(mSG[DC_Main.i, 6], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 5], "", false) == 0) & (Conversion.Val(mSG[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 15]) + Conversion.Val(mSG[DC_Main.i, 28]) + Conversion.Val(mSG[DC_Main.i, 29]) != 0.0))
				{
					dataRow["CO_CODE"] = DC_Main.MCo_code;
					dataRow["LC_CODE"] = DC_Main.MLc_code;
					dataRow["CO_YEAR"] = DC_Main.MCo_year;
					dataRow["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow["VCH_NO"] = tVchNo.Text;
					dataRow["VCH_DATE"] = mVchDate.Text;
					dataRow["STK_DATE"] = mVchDate.Text;
					dataRow["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow["AC_CODE"] = tAcCode.Text;
					dataRow["VCH_TYPE"] = FormBookSname;
					dataRow["INOUT_TYPE"] = FormBookInOut;
					dataRow["ENTRY_TYPE"] = "I";
					dataRow["BOOK_NAME"] = FormMainBook;
					dataRow["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 57]);
					dataRow["ITM_REMARK"] = mSG[DC_Main.i, 11];
					dataRow["IT_CODE"] = mSG[DC_Main.i, 4];
					dataRow["TAG_NO"] = mSG[DC_Main.i, 5];
					dataRow["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 41]);
					dataRow["TBL_CODE"] = mSG[DC_Main.i, 7];
					dataRow["ITM_STYLE"] = "";
					dataRow["ITM_COLOR"] = "";
					dataRow["DESIGN_NO"] = mSG[DC_Main.i, 8];
					dataRow["ITM_SIZE"] = mSG[DC_Main.i, 9];
					dataRow["HM_ID"] = mSG[DC_Main.i, 10];
					dataRow["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 15]);
					dataRow["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 16]);
					dataRow["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 17]);
					dataRow["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 20]);
					dataRow["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 21]);
					dataRow["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 22]);
					dataRow["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow["LBR_TYPE"] = mSG[DC_Main.i, 26];
					dataRow["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 27]);
					dataRow["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 28]);
					dataRow["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 29]);
					dataRow["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 23]);
					dataRow["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
					dataRow["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 30]);
					dataRow["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 44]);
					dataRow["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 47]);
					dataRow["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 48]);
					dataRow["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 49]);
					dataRow["KR_NAME"] = mSG[DC_Main.i, 34];
					dataRow["RATE_TYPE"] = mSG[DC_Main.i, 58];
					dataRow["IT_TYPE"] = mSG[DC_Main.i, 59];
					dataRow["PR_CODE"] = mSG[DC_Main.i, 61];
					dataRow["TAG_TYPE"] = mSG[DC_Main.i, 60];
					dataRow["ORD_NO"] = "";
					dataRow["ORD_SRNO"] = 0;
					dataRow["ORD_YRCD"] = "";
					dataRow["ORD_DBCD"] = "";
					dataRow["ORD_AC"] = "";
					dataRow["ORD_LC_CODE"] = "";
					dataRow["SF_NO"] = "";
					dataRow["JDT_JDT_WT"] = 0;
					dataRow["JDT_GHT_WT"] = 0;
					dataRow["JDT_KUN_WT"] = 0;
					dataRow["JDT_KUN_TOUCH"] = 0;
					dataRow["JDT_KUN_NET"] = 0;
					dataRow["JDT_WAX_WT"] = 0;
					dataRow["KR_WAX_WT"] = 0;
					dataRow["EMP_ISU"] = "N";
					dataRow["MFG_NO"] = "";
					dataRow["MFG_YRCD"] = "";
					dataRow["MFG_DBCD"] = "";
					dataRow["MFG_SRNO"] = 0;
					dataRow["EMP_ISU"] = "N";
					dataRow["DESIGN_IMG_ID"] = mSG[DC_Main.i, 76];
					dataRow["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow["MAIN_USER"] = MainUser;
					dataTable.Rows.Add(dataRow);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
					dataTable.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = dataTable2.NewRow();
			int num2 = 0;
			int num3 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num3; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])) != 0.0)
				{
					int num4 = MSG.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num4)
					{
						if (Conversion.Val(MSG[DC_Main.M, 57]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])))
						{
							num2 = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_YEAR"] = DC_Main.MCo_year;
					dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["VCH_NO"] = tVchNo.Text;
					dataRow2["VCH_DATE"] = mVchDate.Text;
					dataRow2["AC_CODE"] = tAcCode.Text;
					dataRow2["VCH_TYPE"] = FormBookSname;
					dataRow2["INOUT_TYPE"] = FormBookInOut;
					dataRow2["ENTRY_TYPE"] = "A";
					dataRow2["BOOK_NAME"] = FormMainBook;
					dataRow2["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow2["TAG_NO"] = MSG[num2, 5];
					dataRow2["VCH_SRNO"] = Conversion.Val(MSG[num2, 41]);
					dataRow2["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow2["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow2["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]);
					dataRow2["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]);
					dataRow2["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]);
					dataRow2["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]);
					dataRow2["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
					dataRow2["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
					dataRow2["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
					dataRow2["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow2["IT_RATE_TYPE"] = Operators.ConcatenateObject(DtIdtl.Rows[i][11], (object)"");
					dataRow2["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow2["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
					dataRow2["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow2["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow2["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow2["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow2["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
					dataRow2["MAIN_USER"] = MainUser;
					dataTable2.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
					dataTable2.Clear();
				}
				dtIdtl = null;
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0231: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Invalid comparison between Unknown and I4
		//IL_016c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0217: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a87: Unknown result type (might be due to invalid IL or missing references)
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
		if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) != 0 && Operators.CompareString(FormBookInOut, "O", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO,A.CO_YEAR,A.CO_BOOK FROM APR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + DC_Main.MCo_year + "' AND A.ISU_DBCD = '" + DC_Main.MCo_Book + "' AND A.ISU_NO = '" + tVchNo.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete this Voucher Because This Voucher Is Approval Returne....", (MsgBoxStyle)0, (object)null);
				return;
			}
			DC_Main.RsQry = "SELECT A.VCH_NO,A.CO_YEAR,A.CO_BOOK FROM RATE_CUT_ISU AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + DC_Main.MCo_year + "' AND A.ISU_DBCD = '" + DC_Main.MCo_Book + "' AND A.ISU_NO = '" + tVchNo.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				Interaction.MsgBox((object)"You Cant Delete this Voucher Because This Voucher Use In Wh Sales....", (MsgBoxStyle)0, (object)null);
				return;
			}
		}
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + ' / ' + IT_CODE + '   TagNo' + ' / ' + TAG_NO FROM (APR_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)  LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
		DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
		{
			DC_Main.RsQry = "UPDATE SL_ORD_DETL SET SL_ORD_DETL.DESIGN_ISU = 'N' FROM SL_ORD_DETL,APR_DETL AS B WHERE SL_ORD_DETL.CO_CODE = B.CO_CODE AND SL_ORD_DETL.LC_CODE = B.ISU_LC_CODE AND SL_ORD_DETL.CO_YEAR = B.ISU_YRCD  AND SL_ORD_DETL.CO_BOOK = B.ISU_DBCD AND SL_ORD_DETL.VCH_NO = B.ISU_NO AND SL_ORD_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
		}
		else if (Operators.CompareString(FormMainBook, "CON REC", false) != 0)
		{
			if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT - B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT - B.ITM_NWT FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.CON_ISU_REC = 'N' FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(FormMainBook, "APR RTN", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,APR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.ISU_YRCD  AND APR_DETL.CO_BOOK = B.ISU_DBCD AND APR_DETL.VCH_NO = B.ISU_NO AND APR_DETL.OLD_SRNO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.TAG_NO = B.TAG_NO  AND APR_DETL.VCH_SRNO = B.VCH_SRNO AND APR_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND APR_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND APR_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND APR_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(FormMainBook, "APR ISU", false) == 0)
			{
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'N' FROM APR_DETL,BAR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.TAG_NO = B.TAG_NO  AND APR_DETL.VCH_SRNO = B.VCH_SRNO AND APR_DETL.CO_CODE = '" + DC_Main.MCo_code + "' AND APR_DETL.LC_CODE = '" + DC_Main.MLc_code + "' AND APR_DETL.CO_YEAR = '" + DC_Main.MCo_year + "' AND APR_DETL.CO_BOOK = '" + DC_Main.MCo_Book + "' AND APR_DETL.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
		}
		DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
		DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
		DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
		DC_Main.ExeQuteDc("DELETE FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM APR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		CLEAR_DATA();
	}

	private void TR_APR_ISU_KeyDown(object sender, KeyEventArgs e)
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
		string rptName = "";
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsCustMail = "";
			DC_Main.MsCustWappNo = "";
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM APR_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
			}
			rptName = (((Operators.CompareString(FormMainBook, "CON REC", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)) ? "ConsiBill" : ((Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0) ? "KrDesignIsuImg" : ((Operators.CompareString(DC_Main.MsAprImgPrint, "Y", false) != 0) ? "AprBill" : "AprBillImg")));
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{APR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {APR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {APR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {APR_DATA.VCH_NO} = '" + CurPrnVch + "'";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
			return;
		}
		if ((Operators.CompareString(FormMainBook, "CON REC", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0))
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ConsiBill.RPT";
			rptName = "ConsiBill";
		}
		else if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\KrDesignIsuVch.RPT";
			if (chkWapp.Checked)
			{
				rptName = "KrDesignIsuImg";
			}
		}
		else if (Operators.CompareString(DC_Main.MsAprImgPrint, "Y", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprBillImg.RPT";
			rptName = "AprBillImg";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\AprBill.RPT";
			rptName = "AprBill";
		}
		Cr.SelectionFormula = "{APR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {APR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {APR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {APR_DATA.VCH_NO} = '" + CurPrnVch + "'";
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = "91" + AcMobile;
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{APR_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {APR_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {APR_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {APR_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {APR_DATA.VCH_NO} = '" + CurPrnVch + "'";
			DC_Main.MsWappPrintType = "AprIsu";
			UT_REPORT uT_REPORT2 = new UT_REPORT();
			((Control)uT_REPORT2).Show();
			((Control)uT_REPORT2).Focus();
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
		CLEAR_DATA();
	}

	private void TR_APR_ISU_Activated(object sender, EventArgs e)
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
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL FROM APR_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
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
		//IL_114d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1157: Expected O, but got Unknown
		//IL_0d25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2f: Expected O, but got Unknown
		//IL_0f71: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f7b: Expected O, but got Unknown
		//IL_1452: Unknown result type (might be due to invalid IL or missing references)
		//IL_145c: Expected O, but got Unknown
		//IL_1318: Unknown result type (might be due to invalid IL or missing references)
		//IL_1322: Expected O, but got Unknown
		if (MsgClear || MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 62] + " : It Name";
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
				if (Conversion.Val(MSG[MSG.Row, 57]) != Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20])))
				{
					continue;
				}
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
				MSG_IDTL[num4, 10] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][10], (object)""));
				MSG_IDTL[num4, 11] = Conversions.ToString(DtIdtl.Rows[i][11]);
				MSG_IDTL[num4, 12] = Conversions.ToString(DtIdtl.Rows[i][12]);
				MSG_IDTL[num4, 13] = Conversions.ToString(DtIdtl.Rows[i][13]);
				MSG_IDTL[num4, 14] = Conversions.ToString(DtIdtl.Rows[i][14]);
				MSG_IDTL[num4, 15] = Conversions.ToString(DtIdtl.Rows[i][15]);
				MSG_IDTL[num4, 16] = Conversions.ToString(DtIdtl.Rows[i][16]);
				MSG_IDTL[num4, 17] = Conversions.ToString(DtIdtl.Rows[i][17]);
				MSG_IDTL[num4, 18] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[i][18], (object)""));
				MSG_IDTL[num4, 19] = Conversions.ToString(DtIdtl.Rows[i][19]);
				MSG_IDTL[num4, 20] = Conversions.ToString(DtIdtl.Rows[i][20]);
				if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[i][11], (object)"", false))
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) == 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) != 0.0))
					{
						MSG_IDTL[num4, 13] = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])), 0), "0.00");
					}
					else if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) != 0.0))
					{
						MSG_IDTL[num4, 13] = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])), 0), "0.00");
					}
				}
				else if (Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(DtIdtl.Rows[i][11], (object)"P", false), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])))))
				{
					MSG_IDTL[num4, 13] = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])), 0), "0.00");
				}
				else if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) != 0.0)
				{
					MSG_IDTL[num4, 13] = Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) * Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8])), 0), "0.00");
				}
				if (Conversion.Val(MSG_IDTL[num4, 13]) + Conversion.Val(MSG_IDTL[num4, 15]) != 0.0)
				{
					MSG_IDTL[num4, 16] = Strings.Format((object)(Conversion.Val(MSG_IDTL[num4, 13]) + Conversion.Val(MSG_IDTL[num4, 15])), "0.00");
				}
				num += Conversion.Val(MSG_IDTL[num4, 16]);
				num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
				num3 += Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[i][18], (object)""));
				MSG_IDTL.Rows += 1;
				num4++;
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 16] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 17] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 15]) - Conversion.Val(MSG[MSG.Row, 16])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 43] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 44] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 15]) - Conversion.Val(MSG[MSG.Row, 43])), "0.000");
			}
			if (num != 0.0)
			{
				MSG[MSG.Row, 29] = Strings.Format((object)num, "0.00");
			}
			CommPassTotal();
			PicImage.Image = null;
			if ((Operators.CompareString(MSG[MSG.Row, 76], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 8], "", false) != 0))
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 76];
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
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 76] + "' AND IMAGE_TYPE = 'D'";
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
				if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) == 0)
				{
					if (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0)
					{
						DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + MSG[MSG.Row, 41];
					}
					else
					{
						DC_Main.MsImageNo = MSG[MSG.Row, 8] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tVchNo.Text;
					}
				}
				else
				{
					DC_Main.MsImageNo = MSG[MSG.Row, 5] + "_" + MSG[MSG.Row, 41];
				}
				DC_Main.MsImageType = "TagImage";
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				PicImage.Image = null;
				if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
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
						if (Operators.CompareString(FormMainBook, "KARIGAR ORDER", false) != 0)
						{
							if (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0)
							{
								DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 41]))) ?? "";
							}
							else
							{
								DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 8] + "'";
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
						ProjectData.ClearProjectError();
					}
				}
				else if (Operators.CompareString(MSG[MSG.Row, 5], "", false) != 0)
				{
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 5] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 41]))) ?? "";
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
				}
				else if (Operators.CompareString(MSG[MSG.Row, 8], "", false) != 0)
				{
					DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 8] + "'";
					DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)""), (object)"System.Byte[]", false))
						{
							PicImage.Image = null;
							return;
						}
						object obj4 = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
						byte[] bA4 = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj4));
						object objectValue4 = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA4));
						PicImage.Image = (Image)objectValue4;
					}
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
			MSG_IDTL[num4, 0] = Conversions.ToString(num4);
			MSG_IDTL[num4, 20] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 57]));
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
				SendKeys.Send("{tab}");
			}
		}
	}

	private void MSG_Enter(object sender, EventArgs e)
	{
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
				DC_Main.RsQry = "SELECT VCH_NO FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM APR_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_APR_ISU_Closed(object sender, EventArgs e)
	{
		DC_Main.MsTagVchSrnoUpdate = false;
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
		//IL_02be: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if ((Operators.CompareString(FormMainBook, "CON REC", false) == 0) | (Operators.CompareString(FormMainBook, "CON ISU", false) == 0))
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_ADD1 As AddressL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 200   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_ADD1,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR IN ('05','10') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
				else
				{
					DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_ADD1 As AddressL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 200   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_ADD1,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('05','10') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
				}
			}
			else if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR <> '15' ORDER BY A.LC_CODE,A.AC_NAME";
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR <> '15' AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR <> '15' ORDER BY A.AC_NAME";
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
				if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
				{
					DC_Main.MsGrCode = "05";
				}
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
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcMobile = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			if (Operators.CompareString(FormMainBook, "APR ISU", false) == 0)
			{
				AcOthRate();
			}
			if (Operators.CompareString(FormMainBook, "CON REC", false) == 0)
			{
				MSG.Col = 4;
			}
			else if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
			{
				MSG.Col = 5;
			}
			else
			{
				MSG.Col = 1;
			}
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void AcOthRate()
	{
		DC_Main.RsQry = "Select AC_IT_CODE,AC_RATE From TOUCH_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE  = '" + tAcCode.Text + "'";
		RsAcOthRate = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (RsAcOthRate.Rows.Count > 0)
		{
			DvAcRate = new DataView(RsAcOthRate);
		}
		else
		{
			DvAcRate = null;
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM APR_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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

	private void btnIsuNo_Click(object sender, EventArgs e)
	{
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.AC_NAME As PartyNameL,SUM(A.ITM_NWT) As ItmNwtW,SUM(A.ADJ_NWT) As AdjWtW,SUM(A.ITM_NWT-A.ADJ_NWT) As BalWtW,A.CO_YEAR As YearL,A.CO_BOOK As BookL FROM (APR_DETL AS A   LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE)  LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND D.MAIN_BOOK = 'CON REC'  GROUP BY A.VCH_NO,A.VCH_DATE,C.AC_NAME,A.CO_YEAR,A.CO_BOOK HAVING SUM(A.ITM_NWT-A.ADJ_NWT) > 0 ORDER BY A.VCH_NO";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 250.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 90.0;
			DC_Main.HelpSelect = 0;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && !DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					tIsuNo.Text = DC_Main.ColValue[0];
					tIsuYrCd.Text = DC_Main.ColValue[6];
					tIsuDbCd.Text = DC_Main.ColValue[7];
					((Control)tIsuNo).Focus();
				}
				else
				{
					((Control)tIsuNo).Focus();
				}
			}
			return;
		}
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

	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0242: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND CON_ISU_REC = 'N' ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' AND ISU_REC = 'N'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			btnIsuNo_Click(btnIsuNo, new EventArgs());
			return;
		}
		tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_CODE"], (object)""));
		DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.RsAc.Rows.Count > 0)
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
		}
		if ((int)Interaction.MsgBox((object)"All Item In This Voucher Import?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.i = 0;
			DC_Main.R = 1;
			AxMSFlexGrid mSG = MSG;
			checked
			{
				if (Operators.CompareString(FormMainBook, "CON ISU", false) == 0)
				{
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ADJ_NWT"])) > 0.0)
						{
							mSG[DC_Main.R, 0] = Conversions.ToString(DC_Main.R);
							mSG[DC_Main.R, 57] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
							mSG[DC_Main.R, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
							mSG[DC_Main.R, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
							if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
							{
								mSG[DC_Main.R, 5] = "";
							}
							else
							{
								mSG[DC_Main.R, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
							}
							mSG[DC_Main.R, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
							mSG[DC_Main.R, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
							mSG[DC_Main.R, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
							mSG[DC_Main.R, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
							mSG[DC_Main.R, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
							mSG[DC_Main.R, 14] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
							mSG[DC_Main.R, 15] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ADJ_GWT"]))), "0.000");
							mSG[DC_Main.R, 66] = "0.000";
							mSG[DC_Main.R, 17] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ADJ_NWT"]))), "0.000");
							mSG[DC_Main.R, 67] = "0.000";
							mSG[DC_Main.R, 16] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.R, 15]) - Conversion.Val(mSG[DC_Main.R, 17])), "0.000");
							mSG[DC_Main.R, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.R, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.R, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.R, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.R, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.R, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.R, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
							mSG[DC_Main.R, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
							mSG[DC_Main.R, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
							mSG[DC_Main.R, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
							mSG[DC_Main.R, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
							mSG[DC_Main.R, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
							mSG[DC_Main.R, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
							mSG[DC_Main.R, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
							mSG[DC_Main.R, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
							mSG[DC_Main.R, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
							mSG[DC_Main.R, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
							mSG[DC_Main.R, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
							mSG[DC_Main.R, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
							mSG[DC_Main.R, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
							mSG[DC_Main.R, 35] = "N";
							mSG[DC_Main.R, 77] = "N";
							mSG[DC_Main.R, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
							mSG[DC_Main.R, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"], (object)""));
							mSG[DC_Main.R, 38] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"], (object)""));
							mSG[DC_Main.R, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"], (object)"")), "0");
							mSG[DC_Main.R, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
							mSG[DC_Main.R, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
							mSG[DC_Main.R, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
							mSG[DC_Main.R, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
							mSG[DC_Main.R, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
							mSG[DC_Main.R, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
							mSG[DC_Main.R, 63] = "A";
							CommPassTotal();
							mSG.Rows += 1;
							DC_Main.R++;
						}
						DC_Main.i++;
					}
					mSG.Rows -= 1;
				}
				else
				{
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						mSG[DC_Main.R, 0] = Conversions.ToString(DC_Main.R);
						mSG[DC_Main.R, 57] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
						mSG[DC_Main.R, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.R, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
						if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""), (object)"N", false))
						{
							mSG[DC_Main.R, 5] = "";
						}
						else
						{
							mSG[DC_Main.R, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
						}
						mSG[DC_Main.R, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						mSG[DC_Main.R, 8] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG[DC_Main.R, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						mSG[DC_Main.R, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
						mSG[DC_Main.R, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
						mSG[DC_Main.R, 14] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[DC_Main.R, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.R, 66] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.R, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[DC_Main.R, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.R, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.R, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[DC_Main.R, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
						mSG[DC_Main.R, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[DC_Main.R, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[DC_Main.R, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[DC_Main.R, 71] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
						mSG[DC_Main.R, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[DC_Main.R, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
						mSG[DC_Main.R, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
						mSG[DC_Main.R, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
						mSG[DC_Main.R, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[DC_Main.R, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG[DC_Main.R, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[DC_Main.R, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
						mSG[DC_Main.R, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						mSG[DC_Main.R, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
						mSG[DC_Main.R, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
						mSG[DC_Main.R, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
						mSG[DC_Main.R, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
						mSG[DC_Main.R, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])) != 0.0)
						{
							mSG[DC_Main.R, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						}
						mSG[DC_Main.R, 35] = "N";
						mSG[DC_Main.R, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_NO"], (object)""));
						mSG[DC_Main.R, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_YEAR"], (object)""));
						mSG[DC_Main.R, 38] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["CO_BOOK"], (object)""));
						mSG[DC_Main.R, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"], (object)"")), "0");
						mSG[DC_Main.R, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG[DC_Main.R, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG[DC_Main.R, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[DC_Main.R, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						mSG[DC_Main.R, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
						mSG[DC_Main.R, 63] = "A";
						mSG[DC_Main.R, 76] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
						mSG.Rows += 1;
						DC_Main.R++;
						DC_Main.i++;
					}
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM APR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
					dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["KR_WT"])), "0.000");
					dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[11] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["KR_CON_WT"], (object)"")), "0.000");
					dr[19] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			((Control)tAcCode).Focus();
		}
	}

	private void TR_APR_ISU_KeyUp(object sender, KeyEventArgs e)
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

	private void TEXT_ENTRY_KeyUp(object sender, KeyEventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		if (MSG.Col == 2 && (int)e.KeyCode != 8)
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

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
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
			DC_Main.MsImageNo = MSG[MSG.Row, 8] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tVchNo.Text;
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
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0148: Unknown result type (might be due to invalid IL or missing references)
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
					}
					else if (Operators.CompareString(MSG[MSG.Row, 76], "N", false) == 0)
					{
						if (Operators.CompareString(MSG[MSG.Row, 8], "", false) != 0)
						{
							DC_Main.MsImageNo = MSG[MSG.Row, 8] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tVchNo.Text;
						}
						else
						{
							DC_Main.MsImageNo = "";
						}
						DC_Main.MsImageType = "TagImage";
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
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
					}
					else
					{
						Interaction.MsgBox((object)"This Is a Design Book Desing No Need To Capture Image..", (MsgBoxStyle)0, (object)null);
					}
					goto end_IL_0001;
				case 493:
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
				try0001_dispatch = 493;
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
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
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
						DC_Main.MsImageNo = MSG[MSG.Row, 8] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text;
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
				case 323:
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
				try0001_dispatch = 323;
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

	private void tLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_011e: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tLcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From LOCT_MAST WHERE  CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + tLcCode.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count <= 0)
			{
				DC_Main.RsQry = "Select LC_CODE As CodeL,LC_NAME As NameL,LC_ADD1 As AddressL,LC_CITY As CityL FROM LOCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LC_CODE";
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
					tLcCode.Text = DC_Main.ColValue[0];
					((TextBoxBase)tLcCode).SelectAll();
				}
			}
			else
			{
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tLcCode.Text = DC_Main.MLc_code;
		}
	}

	private void NewTagNo(int Y)
	{
		if (Operators.CompareString(MSG[Y, 61], "", false) == 0)
		{
			return;
		}
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "KJ005NEKJ", false) == 0) & (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0))
		{
			DC_Main.NewYearTagGen(MSG[Y, 61], MSG[Y, 60]);
			MSG[Y, 5] = DC_Main.MsNewTagNo;
			return;
		}
		AxMSFlexGrid mSG = MSG;
		if ((Operators.CompareString(DC_Main.SSRegSrNo, "HM244NEKU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK142NEVK", false) == 0) | (Operators.CompareString(DC_Main.MsLcMenuOpen, "Y", false) == 0))
		{
			DC_Main.RsQry = "SELECT TOP 1 TAG_SRNO FROM (SELECT CAST(TAG_SRNO AS INT) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + mSG[Y, 61] + "'  AND TAG_TYPE = '" + mSG[Y, 60] + "'  GROUP BY TAG_SRNO   UNION ALL SELECT MAX(CAST(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS INT)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND B.PR_CODE = '" + mSG[Y, 61] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG[Y, 60] + "' ) AS X ORDER BY TAG_SRNO DESC";
		}
		else if ((Operators.CompareString(DC_Main.MCo_Type, "", false) != 0) & (Operators.CompareString(DC_Main.MCo_Type, "P", false) != 0))
		{
			DC_Main.RsQry = "SELECT SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG[Y, 61] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG[Y, 60] + "' GROUP BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) ORDER BY SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO)) DESC";
		}
		else if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS054NEVS", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "KJ012NEKJ", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM553NBHM", false) == 0))
		{
			DC_Main.RsQry = "SELECT MAX(TAG_SRNO) AS TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG[Y, 61] + "'  AND TAG_TYPE = '" + mSG[Y, 60] + "'   UNION ALL SELECT  MAX(SUBSTRING(A.TAG_NO,4,LEN(A.TAG_NO))) AS TAG_SRNO FROM SRNO_MAST AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND B.PR_CODE = '" + mSG[Y, 61] + "' AND LEN(A.TAG_NO) > 6  AND B.TAG_TYPE = '" + mSG[Y, 60] + "' ";
		}
		else
		{
			DC_Main.RsQry = "SELECT TOP 2 TAG_SRNO FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND PR_CODE = '" + mSG[Y, 61] + "'  AND TAG_TYPE = '" + mSG[Y, 60] + "' GROUP BY TAG_SRNO ORDER BY TAG_SRNO DESC";
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
		else if (Operators.CompareString(DC_Main.SSRegSrNo, "VS054NEVS", false) == 0)
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
				if (Operators.CompareString(mSG[Y, 5], "", false) == 0 && ((DC_Main.i != Y) & (Operators.CompareString(mSG[DC_Main.i, 61], mSG[Y, 61], false) == 0) & (Operators.CompareString(mSG[DC_Main.i, 60], mSG[Y, 60], false) == 0) & (Conversion.Val(mSG[DC_Main.i, 56]) >= Conversion.Val(CurTagNo))) && Conversion.Val((object)(Conversions.ToDouble(mSG[DC_Main.i, 56]) + 1.0)) > Conversion.Val(CurTagNo))
				{
					if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 56]) + 1.0), "0000");
					}
					else
					{
						CurTagNo = Strings.Format((object)(Conversions.ToDouble(mSG[DC_Main.i, 56]) + 1.0), "00000");
					}
				}
				DC_Main.i++;
			}
			mSG[mSG.Row, 56] = CurTagNo;
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG[mSG.Row, 5] = mSG[Y, 61] + mSG[Y, 60] + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + CurTagNo;
			}
			else
			{
				mSG[mSG.Row, 5] = mSG[Y, 61] + mSG[Y, 60] + CurTagNo;
			}
			mSG = null;
			dataTable.Clear();
		}
	}

	private void btnExel_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		((Control)this).Cursor = Cursors.WaitCursor;
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
		object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
		objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
		NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
		int num = 0;
		checked
		{
			do
			{
				if (MSG[num] > 0)
				{
					NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
					{
						1,
						num + 1,
						MSG[0, num]
					}, (string[])null, (Type[])null);
				}
				num++;
			}
			while (num <= 34);
			int num2 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num2)
			{
				int num3 = 0;
				do
				{
					if (MSG[num3] > 0)
					{
						NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 1,
							num3 + 1,
							MSG[DC_Main.i, num3]
						}, (string[])null, (Type[])null);
					}
					num3++;
				}
				while (num3 <= 34);
				DC_Main.i++;
			}
			ColorConverter colorConverter = new ColorConverter();
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			int num4 = 1;
			do
			{
				object obj = objectValue3;
				object[] obj2 = new object[2] { 1, num4 };
				object[] array = obj2;
				bool[] obj3 = new bool[2] { false, true };
				bool[] array2 = obj3;
				object obj4 = NewLateBinding.LateGet(obj, (Type)null, "Cells", obj2, (string[])null, (Type[])null, obj3);
				if (array2[1])
				{
					num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[1]), typeof(int));
				}
				object objectValue4 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj4, (Type)null, "Value", new object[0], (string[])null, (Type[])null, (bool[])null));
				if (objectValue4 == null || string.IsNullOrWhiteSpace(objectValue4.ToString()))
				{
					object obj5 = objectValue3;
					object[] obj6 = new object[1] { num4 };
					array = obj6;
					bool[] obj7 = new bool[1] { true };
					array2 = obj7;
					obj4 = NewLateBinding.LateGet(obj5, (Type)null, "Columns", obj6, (string[])null, (Type[])null, obj7);
					if (array2[0])
					{
						num4 = (int)Conversions.ChangeType(RuntimeHelpers.GetObjectValue(array[0]), typeof(int));
					}
					NewLateBinding.LateSetComplex(NewLateBinding.LateGet(obj4, (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Hidden", new object[1] { true }, (string[])null, (Type[])null, false, true);
				}
				num4++;
			}
			while (num4 <= 35);
			NewLateBinding.LateSet(objectValue, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
			objectValue3 = null;
			objectValue2 = null;
			objectValue = null;
			GC.Collect();
			((Control)this).Cursor = Cursors.Default;
		}
	}
}
