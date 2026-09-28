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
public class TR_FN_INOUT : Form
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
	[AccessedThroughProperty("tToLcCode")]
	private TextBox _tToLcCode;

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
	[AccessedThroughProperty("tFrmLc")]
	private TextBox _tFrmLc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagVch")]
	private TextBox _tTagVch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagVchHelp")]
	private SimpleButton _btnTagVchHelp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnRateRemove")]
	private SimpleButton _btnRateRemove;

	private string UsUPdate;

	private string UsDelete;

	private string TagBook;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private bool RowChang;

	private double OldNetAmt;

	private double OldTdsPrc;

	private string AcGstType;

	private string TmpEntryMode;

	private bool BillSavePanding;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private double OldValTot;

	private double NewValTot;

	private string CurTagNo;

	private string MsVchSrno;

	private string FanAcCode;

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

	private const int cItCode = 2;

	private const int cCounter = 3;

	private const int cDesign = 4;

	private const int cColor = 5;

	private const int cSize = 6;

	private const int cHmId = 7;

	private const int cSign = 8;

	private const int cBagWt = 9;

	private const int cPcs = 10;

	private const int cGrWt = 11;

	private const int cOthWt = 12;

	private const int cNetWt = 13;

	private const int cGhtPrc = 14;

	private const int cGhtWt = 15;

	private const int cTouch = 16;

	private const int cWestPrc = 17;

	private const int cFine = 18;

	private const int cItRate = 19;

	private const int cItAmt = 20;

	private const int cLbrPrc = 21;

	private const int cLbrType = 22;

	private const int cLbrRate = 23;

	private const int cLbrAmt = 24;

	private const int cOthAmt = 25;

	private const int cTagCost = 26;

	private const int cMainMargin = 27;

	private const int cMainMrp = 28;

	private const int cMargin = 29;

	private const int cMrp = 30;

	private const int cNetAmt = 31;

	private const int cTrFrItCode = 32;

	private const int cTrFrItName = 33;

	private const int cKrName = 34;

	private const int cWithRfid = 35;

	private const int cKrOthWt = 36;

	private const int cKrNetWt = 37;

	private const int cKrTouch = 38;

	private const int cKrWestPrc = 39;

	private const int cKrFine = 40;

	private const int cImageTake = 41;

	private const int cTagSrNo = 42;

	private const int cOldSrNo = 43;

	private const int cRateType = 44;

	private const int cItType = 45;

	private const int cTagType = 46;

	private const int cPrCode = 47;

	private const int cItName = 48;

	private const int cEntryMod = 49;

	private const int cOldTagType = 50;

	private const int cOldPrCode = 51;

	private const int cOldGrWt = 52;

	private const int cOldNtWt = 53;

	private const int cOldGhatPrc = 54;

	private const int cOldGhatWt = 55;

	private const int cOldTouch = 56;

	private const int cOldWestPrc = 57;

	private const int cOldKrNetWt = 58;

	private const int cOldKrTouch = 59;

	private const int cOldKrWest = 60;

	private const int cOldKrGhatWt = 61;

	private const int cOldMargin = 62;

	private const int cItRemark = 63;

	private const int cHmId2 = 64;

	private const int cHmId3 = 65;

	private const int cHmId4 = 66;

	private const int cHmIdWt = 67;

	private const int cHmId2Wt = 68;

	private const int cHmId3Wt = 69;

	private const int cHmId4Wt = 70;

	private const int cLotType = 71;

	private const int cVchSrno = 72;

	private const int cEmpIsu = 73;

	private const int cRowValue = 74;

	private const int cRowText = 75;

	private const int cOldMainMargin = 76;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = TToLcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tToLcCode_KeyDown);
			TextBox val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tToLcCode = value;
			val2 = _tToLcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual TextBox tFrmLc
	{
		[CompilerGenerated]
		get
		{
			return _tFrmLc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tFrmLc_TextChanged;
			TextBox val = _tFrmLc;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tFrmLc = value;
			val = _tFrmLc;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tTagVch_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tTagVch_KeyDown);
			TextBox val2 = _tTagVch;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tTagVch = value;
			val2 = _tTagVch;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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
	[AccessedThroughProperty("nPartyFine")]
	private virtual TextBox _nPartyFine;

	internal virtual TextBox nPartyFine
	{
		get
		{
			return _nPartyFine;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPartyFine = value;
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

	internal virtual SimpleButton btnRateRemove
	{
		[CompilerGenerated]
		get
		{
			return _btnRateRemove;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnRateRemove_Click;
			SimpleButton val = _btnRateRemove;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnRateRemove = value;
			val = _btnRateRemove;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public TR_FN_INOUT()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_FN_INOUT_Load;
		((Form)this).Deactivate += TR_FN_INOUT_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_FN_INOUT_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_FN_INOUT_KeyDown);
		((Form)this).Activated += TR_FN_INOUT_Activated;
		((Form)this).Closed += TR_FN_INOUT_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_FN_INOUT_KeyUp);
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
		//IL_0356: Unknown result type (might be due to invalid IL or missing references)
		//IL_0360: Expected O, but got Unknown
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_041c: Expected O, but got Unknown
		//IL_049c: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a6: Expected O, but got Unknown
		//IL_0540: Unknown result type (might be due to invalid IL or missing references)
		//IL_054a: Expected O, but got Unknown
		//IL_05f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0602: Expected O, but got Unknown
		//IL_0689: Unknown result type (might be due to invalid IL or missing references)
		//IL_0693: Expected O, but got Unknown
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0738: Expected O, but got Unknown
		//IL_07c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d1: Expected O, but got Unknown
		//IL_0834: Unknown result type (might be due to invalid IL or missing references)
		//IL_083e: Expected O, but got Unknown
		//IL_08e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f1: Expected O, but got Unknown
		//IL_0954: Unknown result type (might be due to invalid IL or missing references)
		//IL_095e: Expected O, but got Unknown
		//IL_0a07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a11: Expected O, but got Unknown
		//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b38: Expected O, but got Unknown
		//IL_0c43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c4d: Expected O, but got Unknown
		//IL_0cb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Expected O, but got Unknown
		//IL_0e4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f21: Expected O, but got Unknown
		//IL_1026: Unknown result type (might be due to invalid IL or missing references)
		//IL_1030: Expected O, but got Unknown
		//IL_1128: Unknown result type (might be due to invalid IL or missing references)
		//IL_1132: Expected O, but got Unknown
		//IL_1243: Unknown result type (might be due to invalid IL or missing references)
		//IL_124d: Expected O, but got Unknown
		//IL_12ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d4: Expected O, but got Unknown
		//IL_1395: Unknown result type (might be due to invalid IL or missing references)
		//IL_139f: Expected O, but got Unknown
		//IL_1446: Unknown result type (might be due to invalid IL or missing references)
		//IL_1450: Expected O, but got Unknown
		//IL_1548: Unknown result type (might be due to invalid IL or missing references)
		//IL_1552: Expected O, but got Unknown
		//IL_15b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15bd: Expected O, but got Unknown
		//IL_16c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_16d3: Expected O, but got Unknown
		//IL_17ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b5: Expected O, but got Unknown
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Expected O, but got Unknown
		//IL_1996: Unknown result type (might be due to invalid IL or missing references)
		//IL_19a0: Expected O, but got Unknown
		//IL_19eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_19f5: Expected O, but got Unknown
		//IL_1a7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a89: Expected O, but got Unknown
		//IL_1b1a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b24: Expected O, but got Unknown
		//IL_1bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Expected O, but got Unknown
		//IL_1ca9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cb3: Expected O, but got Unknown
		//IL_1d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3d: Expected O, but got Unknown
		//IL_1dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcf: Expected O, but got Unknown
		//IL_1e83: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8d: Expected O, but got Unknown
		//IL_1f41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4b: Expected O, but got Unknown
		//IL_1fe9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff3: Expected O, but got Unknown
		//IL_207d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2087: Expected O, but got Unknown
		//IL_2145: Unknown result type (might be due to invalid IL or missing references)
		//IL_214f: Expected O, but got Unknown
		//IL_21cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d6: Expected O, but got Unknown
		//IL_2294: Unknown result type (might be due to invalid IL or missing references)
		//IL_229e: Expected O, but got Unknown
		//IL_2325: Unknown result type (might be due to invalid IL or missing references)
		//IL_232f: Expected O, but got Unknown
		//IL_23ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f7: Expected O, but got Unknown
		//IL_2492: Unknown result type (might be due to invalid IL or missing references)
		//IL_249c: Expected O, but got Unknown
		//IL_2537: Unknown result type (might be due to invalid IL or missing references)
		//IL_2541: Expected O, but got Unknown
		//IL_25dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e6: Expected O, but got Unknown
		//IL_266d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2677: Expected O, but got Unknown
		//IL_2755: Unknown result type (might be due to invalid IL or missing references)
		//IL_275f: Expected O, but got Unknown
		//IL_2837: Unknown result type (might be due to invalid IL or missing references)
		//IL_2841: Expected O, but got Unknown
		//IL_28dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_28e7: Expected O, but got Unknown
		//IL_2a16: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a20: Expected O, but got Unknown
		//IL_2ace: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ad8: Expected O, but got Unknown
		//IL_2b29: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b33: Expected O, but got Unknown
		//IL_2be7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bf1: Expected O, but got Unknown
		//IL_2c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c8a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_FN_INOUT));
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
		btnRateRemove = new SimpleButton();
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
		TEXT_ENTRY_2 = new TextBox();
		MSG2_TOTAL = new AxMSFlexGrid();
		Label14 = new Label();
		nPartyFine = new TextBox();
		lblItStock = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)MSG_IDTL).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
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
		lblBook.Text = "Franchise In Out";
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
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)btnRateRemove);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)btnRateRemove).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnRateRemove).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnRateRemove).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnRateRemove).Appearance.Options.UseForeColor = true;
		((Control)btnRateRemove).Location = new Point(410, 3);
		((BaseControl)btnRateRemove).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnRateRemove).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnRateRemove).Name = "btnRateRemove";
		((Control)btnRateRemove).Size = new Size(162, 37);
		((Control)btnRateRemove).TabIndex = 2;
		btnRateRemove.Text = "&Rate Remove";
		((BaseButton)btnRateRemove).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnRateRemove).Visible = false;
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
		((Control)lblItem).Location = new Point(960, 43);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(210, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(476, 364);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 5;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 331);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(707, 112);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(15, 451);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(121, 106);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(15, 307);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 103);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 202);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1215, 353);
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
		((Control)Cr).Location = new Point(1222, 403);
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
		((Control)Label1).Location = new Point(326, 75);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(58, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Trfr Co";
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
		((Control)tEmpCode).Location = new Point(228, 476);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 6;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(291, 476);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(153, 478);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(155, 506);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(228, 506);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(491, 51);
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
		lFromLc.Text = "From Co";
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
		((Control)Label5).Location = new Point(942, 75);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(80, 20);
		((Control)Label5).TabIndex = 1168;
		Label5.Text = "TrFrVchNo";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label5).Visible = false;
		((TextBoxBase)tToVchNo).BackColor = Color.White;
		((Control)tToVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tToVchNo).Location = new Point(1028, 74);
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
		((Control)tToBook).Location = new Point(1110, 74);
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
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(843, 425);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 1177;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)MSG2_TOTAL).Location = new Point(725, 331);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(442, 225);
		((Control)MSG2_TOTAL).TabIndex = 1178;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(539, 451);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(69, 20);
		((Control)Label14).TabIndex = 1222;
		Label14.Text = "Party Fine";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPartyFine).BackColor = Color.White;
		((Control)nPartyFine).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPartyFine).Location = new Point(614, 449);
		((TextBoxBase)nPartyFine).MaxLength = 50;
		((Control)nPartyFine).Name = "nPartyFine";
		((Control)nPartyFine).Size = new Size(105, 23);
		((Control)nPartyFine).TabIndex = 1221;
		nPartyFine.TextAlign = (HorizontalAlignment)1;
		((Control)lblItStock).BackColor = Color.Transparent;
		((Control)lblItStock).Font = new Font("Tahoma", 9f);
		((Control)lblItStock).ForeColor = Color.Blue;
		lblItStock.ImeMode = (ImeMode)0;
		((Control)lblItStock).Location = new Point(225, 451);
		((Control)lblItStock).Name = "lblItStock";
		((Control)lblItStock).Size = new Size(282, 20);
		((Control)lblItStock).TabIndex = 1225;
		lblItStock.Text = "Itm Stock :";
		lblItStock.TextAlign = (ContentAlignment)16;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)lblItStock);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)nPartyFine);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG2_TOTAL);
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
		((Control)this).Name = "TR_FN_INOUT";
		((Form)this).Text = "Franchise In Out";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)MSG_IDTL).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
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
		mSG_IDTL[mSG_IDTL.Row, 16] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 43]));
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
				MSG[MSG.Row, 12] = Strings.Format((object)num2, "0.000");
				MSG[MSG.Row, 13] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - Conversion.Val(MSG[MSG.Row, 12])), "0.000");
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 36] = Strings.Format((object)num3, "0.000");
				MSG[MSG.Row, 37] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - Conversion.Val(MSG[MSG.Row, 36])), "0.000");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 25] = Strings.Format((object)num4, "0.00");
			}
			if (num2 != 0.0)
			{
				MSG[MSG.Row, 13] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - num2), "0.000");
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 1], "", false) != 0)
			{
				bool flag = false;
				int num5 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
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
		mSG.Cols = 77;
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
			mSG[2] = (int)Math.Round(950.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[1] = (int)Math.Round(1400.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[3] = (int)Math.Round(900.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "Counter";
			mSG[4] = (int)Math.Round(900.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			mSG[7] = (int)Math.Round(750.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "HmId";
			mSG[5] = (int)Math.Round(1000.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Color";
			mSG[6] = (int)Math.Round(750.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Size";
			mSG[9] = (int)Math.Round(800.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "BagWt";
			mSG[10] = (int)Math.Round(700.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Pcs";
			mSG[11] = (int)Math.Round(1050.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "GrWt";
			mSG[12] = (int)Math.Round(900.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "LsWt";
			mSG[13] = (int)Math.Round(1050.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "NetWt";
			mSG[36] = (int)Math.Round(0.0 * ColCon);
			mSG[36] = 7;
			mSG[0, 36] = "KrOthWt";
			mSG[37] = (int)Math.Round(0.0 * ColCon);
			mSG[37] = 7;
			mSG[0, 37] = "KrNwt";
			mSG[38] = (int)Math.Round(0.0 * ColCon);
			mSG[38] = 7;
			mSG[0, 38] = "KrTouch";
			mSG[39] = (int)Math.Round(0.0 * ColCon);
			mSG[39] = 7;
			mSG[0, 39] = "KrWst%";
			mSG[40] = (int)Math.Round(0.0 * ColCon);
			mSG[40] = 7;
			mSG[0, 40] = "KrFine";
			mSG[14] = (int)Math.Round(750.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Ght%";
			mSG[15] = (int)Math.Round(850.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "GhtWt";
			mSG[16] = (int)Math.Round(750.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "Touch";
			mSG[17] = (int)Math.Round(750.0 * ColCon);
			mSG[17] = 7;
			mSG[0, 17] = "West%";
			mSG[18] = (int)Math.Round(1050.0 * ColCon);
			mSG[18] = 7;
			mSG[0, 18] = "Fine";
			mSG[8] = 0;
			mSG[8] = 3;
			mSG[0, 8] = "Sign";
			mSG[23] = (int)Math.Round(850.0 * ColCon);
			mSG[23] = 7;
			mSG[0, 23] = "LbrRate";
			mSG[24] = (int)Math.Round(900.0 * ColCon);
			mSG[24] = 7;
			mSG[0, 24] = "LbrAmt";
			mSG[25] = (int)Math.Round(950.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "OthAmt";
			mSG[32] = 0;
			mSG[32] = 3;
			mSG[0, 32] = "TrfrItm";
			mSG[33] = 0;
			mSG[33] = 3;
			mSG[0, 33] = "TrfrItmName";
			mSG[27] = (int)Math.Round(925.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "MMargin";
			mSG[28] = (int)Math.Round(1000.0 * ColCon);
			mSG[28] = 7;
			mSG[0, 28] = "MainMrp";
			mSG[26] = (int)Math.Round(1000.0 * ColCon);
			mSG[26] = 7;
			mSG[0, 26] = "TagCost";
			mSG[29] = (int)Math.Round(800.0 * ColCon);
			mSG[29] = 7;
			mSG[0, 29] = "Margin";
			mSG[30] = (int)Math.Round(1000.0 * ColCon);
			mSG[30] = 7;
			mSG[0, 30] = "Mrp";
			mSG[31] = (int)Math.Round(1150.0 * ColCon);
			mSG[31] = 7;
			mSG[0, 31] = "NetAmt";
			mSG[34] = (int)Math.Round(0.0 * ColCon);
			mSG[34] = 7;
			mSG[0, 34] = "KrCode";
			mSG[21] = (int)Math.Round(0.0 * ColCon);
			mSG[21] = 7;
			mSG[0, 21] = "Lbr%";
			mSG[22] = (int)Math.Round(0.0 * ColCon);
			mSG[22] = 3;
			mSG[0, 22] = "LType";
			mSG[19] = (int)Math.Round(1000.0 * ColCon);
			mSG[19] = 7;
			mSG[0, 19] = "ItRate";
			mSG[20] = (int)Math.Round(1150.0 * ColCon);
			mSG[20] = 7;
			mSG[0, 20] = "ItAmt";
			mSG[41] = 0;
			mSG[41] = 3;
			mSG[0, 41] = "Image";
			mSG[35] = 0;
			mSG[35] = 3;
			mSG[0, 35] = "Rfid";
			mSG[42] = 0;
			mSG[43] = 0;
			mSG[44] = 0;
			mSG[45] = 0;
			mSG[46] = 0;
			mSG[47] = 0;
			mSG[72] = 0;
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
			mSG[73] = 0;
			mSG[74] = 0;
			mSG[75] = 0;
			mSG[76] = 0;
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
					if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'FAN PURC' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
						if (dataView.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
							{
								mSG[DC_Main.M] = 0;
							}
							mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
						}
					}
					else if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
					{
						dataView.RowFilter = " BOOK_NAME = 'FAN SALE' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
						if (dataView.Count > 0)
						{
							if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
							{
								mSG[DC_Main.M] = 0;
							}
							mSG[0, DC_Main.M] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
						}
					}
					DC_Main.M++;
				}
			}
			MsgLastCol = 34;
			DC_Main.M = 32;
			do
			{
				if (mSG[DC_Main.M] > 0)
				{
					mSG[34] = (int)Math.Round(1100.0 * ColCon);
					MsgLastCol = 34;
					break;
				}
				DC_Main.M++;
			}
			while (DC_Main.M <= 34);
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
					mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.000");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
					mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
					mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.00");
					mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[DC_Main.M, 26]))), "0.00");
					mSG_TOT[0, 30] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 30]) + Conversion.Val(MSG[DC_Main.M, 30]))), "0.000");
					mSG_TOT[0, 31] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 31]) + Conversion.Val(MSG[DC_Main.M, 31]))), "0.00");
					mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[DC_Main.M, 36]))), "0.000");
					mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[DC_Main.M, 37]))), "0.000");
					mSG_TOT[0, 40] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 40]) + Conversion.Val(MSG[DC_Main.M, 40]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				nPartyFine.Text = Strings.Format((object)Conversion.Val(MSG_TOT[0, 18]), "0.000");
				NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 22] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 43] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 43] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Row - 1), 43]) + 1.0);
		}
		mSG[mSG.Row, 49] = "A";
		mSG[mSG.Row, 41] = "N";
		mSG[mSG.Row, 71] = "S";
		mSG[mSG.Row, 73] = "N";
		mSG[mSG.Row, 35] = "N";
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
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 0:
			case 32:
			case 34:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 33:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0 && Operators.CompareString(FormMainBook, "FAN PURC", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
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
			case 8:
			case 22:
			case 35:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 14:
			case 16:
			case 17:
			case 21:
			case 27:
			case 28:
			case 29:
			case 30:
			case 38:
			case 39:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 19:
			case 20:
			case 23:
			case 24:
			case 25:
			case 26:
			case 31:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 11:
			case 12:
			case 13:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if (((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Operators.CompareString(DC_Main.MsSlNwtLock, "Y", false) == 0)) && Operators.CompareString(mSG[mSG.Row, 71], "S", false) == 0 && Operators.CompareString(DC_Main.MCo_UserType, "A", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 9:
			case 15:
			case 18:
			case 36:
			case 37:
			case 40:
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
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 1:
			case 3:
			case 4:
			case 6:
			case 8:
			case 22:
			case 32:
			case 33:
			case 34:
			case 35:
			case 41:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 10:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 14:
			case 16:
			case 17:
			case 21:
			case 38:
			case 39:
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
			case 30:
			case 31:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 12:
			case 36:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 9:
			case 11:
			case 13:
			case 15:
			case 18:
			case 37:
			case 40:
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
				case 5046:
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
							goto IL_0a2a;
						case 52:
						case 54:
						case 55:
						case 56:
							goto IL_0a61;
						case 57:
							goto IL_0a98;
						case 58:
							goto IL_0acc;
						case 59:
							goto IL_0b2c;
						case 60:
						case 61:
						case 62:
							goto IL_0b96;
						case 63:
							goto IL_0bcd;
						case 64:
							goto IL_0c01;
						case 65:
							goto IL_0c61;
						case 66:
						case 67:
						case 68:
							goto IL_0ccb;
						case 69:
							goto IL_0d06;
						case 44:
						case 70:
						case 71:
						case 72:
							goto IL_0d3d;
						case 73:
							goto IL_0d8d;
						case 75:
							goto IL_0dd6;
						case 77:
							goto IL_0e2a;
						case 79:
							goto IL_0e88;
						case 81:
							goto IL_0ee3;
						case 74:
						case 76:
						case 78:
						case 80:
						case 82:
						case 83:
						case 84:
							goto IL_0f36;
						case 85:
							goto IL_0f64;
						case 87:
							goto IL_0fad;
						case 89:
							goto IL_1001;
						case 91:
							goto IL_1069;
						case 93:
							goto IL_10d8;
						case 86:
						case 88:
						case 90:
						case 92:
						case 94:
						case 95:
						case 96:
							goto IL_112b;
						case 97:
							goto IL_1155;
						case 99:
							goto IL_118d;
						case 98:
						case 100:
						case 101:
							goto IL_11eb;
						case 102:
							goto IL_11ed;
						case 103:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 104:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_118d:
					num2 = 99;
					val[val.Row, 31] = Strings.Format((object)(Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 24]) + Conversion.Val(val[val.Row, 25])), "0.00");
					goto IL_11eb;
					IL_11eb:
					val = null;
					goto IL_11ed;
					IL_1155:
					num2 = 97;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 28]), "0.00");
					goto IL_11eb;
					IL_11ed:
					num2 = 102;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 52]))
					{
						goto IL_004b;
					}
					goto IL_015b;
					IL_004b:
					num2 = 4;
					val[val.Row, 52] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_00c5;
					IL_00c5:
					num2 = 6;
					if ((Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_0110;
					}
					goto IL_015b;
					IL_0110:
					num2 = 7;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 36])), "0.000");
					goto IL_015b;
					IL_015b:
					num2 = 10;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_01a7;
					}
					goto IL_01f1;
					IL_01a7:
					num2 = 11;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_01f1;
					IL_01f1:
					num2 = 13;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 53]))
					{
						goto IL_0228;
					}
					goto IL_0371;
					IL_0228:
					num2 = 14;
					val[val.Row, 53] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_025c;
					IL_025c:
					num2 = 15;
					if ((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_02bc;
					}
					goto IL_033a;
					IL_02bc:
					num2 = 16;
					val[val.Row, 18] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17])) / 100.0), "0.000");
					goto IL_0371;
					IL_033a:
					num2 = 18;
					val[val.Row, 18] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0371;
					IL_0371:
					num2 = 21;
					if (Conversion.Val(val[val.Row, 16]) != Conversion.Val(val[val.Row, 56]))
					{
						goto IL_03a8;
					}
					goto IL_04ba;
					IL_03a8:
					num2 = 22;
					val[val.Row, 56] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_03dc;
					IL_03dc:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_043c;
					}
					goto IL_04ba;
					IL_043c:
					num2 = 24;
					val[val.Row, 18] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17])) / 100.0), "0.000");
					goto IL_04ba;
					IL_04ba:
					num2 = 27;
					if (Conversion.Val(val[val.Row, 17]) != Conversion.Val(val[val.Row, 57]))
					{
						goto IL_04f1;
					}
					goto IL_0603;
					IL_04f1:
					num2 = 28;
					val[val.Row, 57] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.00");
					goto IL_0525;
					IL_0525:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_0585;
					}
					goto IL_0603;
					IL_0585:
					num2 = 30;
					val[val.Row, 18] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17])) / 100.0), "0.000");
					goto IL_0603;
					IL_0603:
					num2 = 33;
					if (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17]) == 0.0)
					{
						goto IL_063e;
					}
					goto IL_0688;
					IL_063e:
					num2 = 34;
					val[val.Row, 18] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])), "0.000");
					goto IL_0688;
					IL_0688:
					num2 = 36;
					if ((Conversion.Val(val[val.Row, 18]) == 0.0) & (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_06e5;
					}
					goto IL_0761;
					IL_06e5:
					num2 = 37;
					val[val.Row, 18] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * (Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 17])) / 100.0), "0.000");
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
					val[val.Row, 37] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_07bc;
					IL_07bc:
					num2 = 41;
					val[val.Row, 38] = Strings.Format((object)Conversion.Val(val[val.Row, 16]), "0.00");
					goto IL_07f0;
					IL_07f0:
					num2 = 42;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 17]), "0.00");
					goto IL_0824;
					IL_0824:
					num2 = 43;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 18]), "0.000");
					goto IL_0d3d;
					IL_085f:
					num2 = 45;
					if ((Conversion.Val(val[val.Row, 36]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_08ab;
					}
					goto IL_08f5;
					IL_08ab:
					num2 = 46;
					val[val.Row, 37] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 36])), "0.000");
					goto IL_08f5;
					IL_08f5:
					num2 = 48;
					if (Conversion.Val(val[val.Row, 37]) != Conversion.Val(val[val.Row, 58]))
					{
						goto IL_092c;
					}
					goto IL_0a61;
					IL_092c:
					num2 = 49;
					val[val.Row, 58] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.000");
					goto IL_0960;
					IL_0960:
					num2 = 50;
					if ((Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_09c0;
					}
					goto IL_0a2a;
					IL_09c0:
					num2 = 51;
					val[val.Row, 40] = Strings.Format((object)(Conversion.Val(val[val.Row, 37]) * (Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39])) / 100.0), "0.000");
					goto IL_0a61;
					IL_0a2a:
					num2 = 53;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.000");
					goto IL_0a61;
					IL_0a61:
					num2 = 56;
					if (Conversion.Val(val[val.Row, 38]) != Conversion.Val(val[val.Row, 59]))
					{
						goto IL_0a98;
					}
					goto IL_0b96;
					IL_0a98:
					num2 = 57;
					val[val.Row, 59] = Strings.Format((object)Conversion.Val(val[val.Row, 38]), "0.00");
					goto IL_0acc;
					IL_0acc:
					num2 = 58;
					if ((Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_0b2c;
					}
					goto IL_0b96;
					IL_0b2c:
					num2 = 59;
					val[val.Row, 40] = Strings.Format((object)(Conversion.Val(val[val.Row, 37]) * (Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39])) / 100.0), "0.000");
					goto IL_0b96;
					IL_0b96:
					num2 = 62;
					if (Conversion.Val(val[val.Row, 39]) != Conversion.Val(val[val.Row, 60]))
					{
						goto IL_0bcd;
					}
					goto IL_0ccb;
					IL_0bcd:
					num2 = 63;
					val[val.Row, 60] = Strings.Format((object)Conversion.Val(val[val.Row, 39]), "0.00");
					goto IL_0c01;
					IL_0c01:
					num2 = 64;
					if ((Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39]) != 0.0) & (Conversion.Val(val[val.Row, 37]) != 0.0))
					{
						goto IL_0c61;
					}
					goto IL_0ccb;
					IL_0c61:
					num2 = 65;
					val[val.Row, 40] = Strings.Format((object)(Conversion.Val(val[val.Row, 37]) * (Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39])) / 100.0), "0.000");
					goto IL_0ccb;
					IL_0ccb:
					num2 = 68;
					if (Conversion.Val(val[val.Row, 38]) + Conversion.Val(val[val.Row, 39]) == 0.0)
					{
						goto IL_0d06;
					}
					goto IL_0d3d;
					IL_0d06:
					num2 = 69;
					val[val.Row, 40] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.000");
					goto IL_0d3d;
					IL_0d3d:
					num2 = 72;
					if ((Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 18]) != 0.0))
					{
						goto IL_0d8d;
					}
					goto IL_0f36;
					IL_0d8d:
					num2 = 73;
					switch (val[val.Row, 44])
					{
					case "P":
						break;
					case "1":
						goto IL_0e2a;
					case "K":
						goto IL_0e88;
					default:
						goto IL_0ee3;
					}
					goto IL_0dd6;
					IL_0ee3:
					num2 = 81;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_0f36;
					IL_0e88:
					num2 = 79;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * (Conversion.Val(val[val.Row, 19]) / 1000.0), 0), "0.00");
					goto IL_0f36;
					IL_0e2a:
					num2 = 77;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) * (Conversion.Val(val[val.Row, 19]) / 10.0), 0), "0.00");
					goto IL_0f36;
					IL_0dd6:
					num2 = 75;
					val[val.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 19]), 0), "0.00");
					goto IL_0f36;
					IL_0f36:
					num2 = 84;
					if (Conversion.Val(val[val.Row, 23]) != 0.0)
					{
						goto IL_0f64;
					}
					goto IL_112b;
					IL_0f64:
					num2 = 85;
					switch (val[val.Row, 22])
					{
					case "P":
						break;
					case "N":
						goto IL_1001;
					case "K":
						goto IL_1069;
					default:
						goto IL_10d8;
					}
					goto IL_0fad;
					IL_10d8:
					num2 = 93;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_112b;
					IL_1069:
					num2 = 91;
					val[val.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * (Conversion.Val(val[val.Row, 23]) / 1000.0), 0), "0.00");
					goto IL_112b;
					IL_1001:
					num2 = 89;
					val[val.Row, 24] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 15])) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_112b;
					IL_0fad:
					num2 = 87;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 23]), 0), "0.00");
					goto IL_112b;
					IL_112b:
					num2 = 96;
					if (Conversion.Val(val[val.Row, 28]) != 0.0)
					{
						goto IL_1155;
					}
					goto IL_118d;
					end_IL_0001_2:
					break;
				}
				num2 = 103;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 5046;
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
		//IL_01d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Invalid comparison between Unknown and I4
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f4: Invalid comparison between Unknown and I4
		//IL_0506: Unknown result type (might be due to invalid IL or missing references)
		//IL_0508: Invalid comparison between Unknown and I4
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Invalid comparison between Unknown and I4
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_056e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Invalid comparison between Unknown and I4
		//IL_05ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_05ed: Invalid comparison between Unknown and I4
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_0648: Invalid comparison between Unknown and I4
		//IL_06a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_06aa: Invalid comparison between Unknown and I4
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_2958: Unknown result type (might be due to invalid IL or missing references)
		//IL_098f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cba: Unknown result type (might be due to invalid IL or missing references)
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
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 43]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][16])) == Conversion.Val(mSG[mSG.Row, 43]))
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
					MSG[mSG.Row, 43] = Conversions.ToString(num);
					TEXT_ENTRY.Text = "";
					Interaction.MsgBox((object)"Please Save This Voucher Then Effect....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else if ((int)keyCode == 112)
		{
			checked
			{
				if (mSG.Col == 3)
				{
					if (mSG.Rows > 1)
					{
						TEXT_ENTRY.Text = mSG[mSG.Row - 1, 3];
						mSG[mSG.Row, 3] = mSG[mSG.Row - 1, 3];
					}
					return;
				}
				if (mSG.Col == 1)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,A.TBL_CODE As CntrL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.PRINT_NAME As PrintNameL,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_PCS ELSE - A.ITM_PCS END) AS PcsM,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_GWT ELSE - A.ITM_GWT END) AS GrWtW,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_NWT ELSE - A.ITM_NWT END) AS NetWtW From (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE)LEFT JOIN TAG_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.IT_CODE = C.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' and A.TAG_NO <> 'N' AND A.LOT_TYPE = 'L' "), Interaction.IIf(Operators.CompareString(FormItmType, "A", false) == 0, (object)"", (object)("AND B.IT_TYPE = '" + FormItmType + "'"))), (object)" GROUP BY A.TAG_NO,A.TBL_CODE,B.IT_NAME,A.IT_CODE,C.PRINT_NAME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.ITM_GWT ELSE -A.ITM_GWT END) > 0  ORDER BY A.TAG_NO"));
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[9];
					DC_Main.ColWidth[0] = 120.0;
					DC_Main.ColWidth[1] = 70.0;
					DC_Main.ColWidth[2] = 250.0;
					DC_Main.ColWidth[3] = 100.0;
					DC_Main.ColWidth[4] = 250.0;
					DC_Main.ColWidth[5] = 100.0;
					DC_Main.ColWidth[6] = 120.0;
					DC_Main.ColWidth[7] = 120.0;
					DC_Main.HelpSelect = 1;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (!DC_Main.HelpClose)
					{
						if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
						{
							TEXT_ENTRY.Text = DC_Main.ColValue[0];
							mSG[mSG.Row, 3] = DC_Main.ColValue[1];
							mSG[mSG.Row, 48] = DC_Main.ColValue[2];
							mSG[mSG.Row, 2] = DC_Main.ColValue[3];
							mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[6], "0.000");
							mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[7], "0.000");
							mSG[mSG.Row, 72] = Conversions.ToString(0);
							mSG[mSG.Row, 71] = "L";
							((Control)TEXT_ENTRY).Focus();
						}
						else
						{
							mSG[mSG.Row, 71] = "";
							mSG[mSG.Row, 72] = "";
							mSG[mSG.Row, 1] = "";
							((Control)TEXT_ENTRY).Focus();
						}
					}
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
						if (Operators.CompareString(FormMainBook, "FAN SALE", false) != 0 || Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						if ((Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0) & (Conversion.Val(mSG[mSG.Row, 72]) == 0.0))
						{
							mSG[mSG.Row, 1] = "";
						}
						if (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) == 0)
						{
							break;
						}
						mSG[mSG.Row, 71] = "S";
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 72]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 72]))) ?? ""))), (object)"  GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_DATE From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_DATE HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_DATE DESC";
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
									mSG[mSG.Row, 48] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 72] = DC_Main.ColValue[7];
									mSG[mSG.Row, 71] = "L";
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 72] = "";
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
						mSG[mSG.Row, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								mSG[mSG.Row, 48] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 13] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 72] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 72]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["BAG_WT"], (object)"")), "0.000");
							mSG[DC_Main.i, 10] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_PRC"])), "0.00");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_WEST_PRC"])), "0.00");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_PRC"])), "0.00");
							mSG[DC_Main.i, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["LBR_TYPE"], (object)""));
							mSG[DC_Main.i, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_RATE"])), "0.00");
							mSG[DC_Main.i, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NET_WT"], (object)"")), "0.00");
							mSG[DC_Main.i, 38] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_TOUCH"], (object)"")), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_WEST_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 40] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_FINE"], (object)"")), "0.000");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_RATE"])), "0.00");
							mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_AMT"])), "0.00");
							mSG[DC_Main.i, 26] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_COST"], (object)"")), "0.00");
							mSG[DC_Main.i, 27] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_MARGIN_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 76] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_MARGIN_PRC"], (object)"")), "0.00");
							mSG[DC_Main.i, 28] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MAIN_MRP"], (object)"")), "0.00");
							mSG[DC_Main.i, 29] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 62] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MARGIN"], (object)"")), "0.00");
							mSG[DC_Main.i, 30] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_MRP"], (object)"")), "0.00");
							if ((Conversion.Val(mSG[DC_Main.i, 16]) + Conversion.Val(mSG[DC_Main.i, 17]) != 0.0) & (Conversion.Val(mSG[DC_Main.i, 13]) != 0.0))
							{
								mSG[DC_Main.i, 18] = Strings.Format((object)((Conversion.Val(mSG[DC_Main.i, 13]) + Conversion.Val(mSG[DC_Main.i, 15])) * (Conversion.Val(mSG[DC_Main.i, 16]) + Conversion.Val(mSG[DC_Main.i, 17])) / 100.0), "0.000");
							}
							if ((Conversion.Val(mSG[mSG.Row, 19]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 18]) != 0.0))
							{
								switch (mSG[mSG.Row, 44])
								{
								case "P":
									mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 10]) * Conversion.Val(mSG[mSG.Row, 19]), 0), "0.00");
									break;
								case "1":
									mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 18]) * (Conversion.Val(mSG[mSG.Row, 19]) / 10.0), 0), "0.00");
									break;
								case "K":
									mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 18]) * (Conversion.Val(mSG[mSG.Row, 19]) / 1000.0), 0), "0.00");
									break;
								default:
									mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 18]) * Conversion.Val(mSG[mSG.Row, 19]), 0), "0.00");
									break;
								}
							}
							if ((Conversion.Val(mSG[DC_Main.i, 23]) != 0.0) & (Conversion.Val(mSG[DC_Main.i, 11]) != 0.0))
							{
								mSG[DC_Main.i, 24] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 11]) * Conversion.Val(mSG[DC_Main.i, 23])), "0.00");
							}
							mSG[DC_Main.i, 31] = Strings.Format((object)(Conversion.Val(mSG[DC_Main.i, 20]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 25])), "0.00");
							mSG[DC_Main.i, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 42] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_SRNO"], (object)"")), "0");
							mSG[DC_Main.i, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 46] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_TYPE"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PR_CODE"], (object)""));
							mSG[DC_Main.i, 72] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)" : It Name"));
							ItmStk(DC_Main.i);
							int num5 = 0;
							int num6 = DtIdtl.Rows.Count - 1;
							int num7 = num6;
							for (int i = 0; i <= num7; i++)
							{
								if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num5][16], (object)Conversion.Val(mSG[DC_Main.i, 43]), false))
								{
									DtIdtl.Rows[num5].Delete();
									DtIdtl.AcceptChanges();
									num5--;
								}
								num5++;
							}
							MSG_IDTL_CLEAR();
						}
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + mSG[mSG.Row, 1] + "' AND A.VCH_SRNO = " + mSG[mSG.Row, 72] + " ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.R = 0;
						while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[16] = Conversion.Val(MSG[mSG.Row, 43]);
							dr[0] = DC_Main.R + 1;
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IT_CODE"], (object)"");
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IT_NAME"], (object)"");
							dr[3] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_PCS"]);
							dr[4] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_GWT"])), "0.000");
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_WT"])), "0.000");
							dr[6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_CON_PRC"])), "0.000");
							dr[7] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IT_RATE_TYPE"], (object)"");
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_RATE"])), "0.00");
							dr[9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_AMT"])), "0.00");
							dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_LBR_RATE"])), "0.00");
							dr[11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_LBR_AMT"])), "0.00");
							dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_NET_AMT"])), "0.00");
							dr[13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_CON_WT"])), "0.000");
							dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["KR_CON_WT"], (object)"")), "0.000");
							dr[15] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["IT_TYPE"], (object)"");
							dr[17] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_CODE"], (object)"");
							dr[18] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_NAME"], (object)"");
							dr[19] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_COLOR"], (object)"");
							dr[20] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_SIZE"], (object)"");
							dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_ORIGIN"], (object)"");
							dr[22] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_REMARK"], (object)"");
							dr[23] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["DM_SFNO"], (object)"");
							dr[24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_ACT_WT"])), "0.000");
							dr[25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_ACT_PRC"])), "0.00");
							dr[26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_LESS_PRC"])), "0.00");
							dr[27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_RATE"])), "0.00");
							dr[28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_AMT"])), "0.00");
							dr[29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_PCS_WT"])), "0.000");
							dr[30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["KR_WT"])), "0.000");
							dr[31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["IT_GWT"])), "0.000");
							DtIdtl.Rows.Add(dr);
							DC_Main.R++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
						if (Operators.CompareString(mSG[DC_Main.i, 71], "L", false) == 0)
						{
							mSG.Col = 10;
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
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
						break;
					}
					case 2:
						if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
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
										mSG[mSG.Row, 48] = DC_Main.ColValue[0];
										mSG[mSG.Row, 47] = DC_Main.ColValue[3];
										mSG[mSG.Row, 45] = DC_Main.ColValue[4];
										mSG[mSG.Row, 46] = DC_Main.ColValue[4];
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							mSG[mSG.Row, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
							mSG[mSG.Row, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
							mSG[mSG.Row, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
							mSG[mSG.Row, 46] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TAG_TYPE"], (object)""));
							mSG[mSG.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
							lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						}
						else
						{
							Interaction.MsgBox((object)"You Cant Insert New Entry In Inword Voucher", (MsgBoxStyle)0, (object)null);
						}
						break;
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
					case 11:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
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
					case 31:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 31] = Conversions.ToString(Conversion.Val(TEXT_ENTRY.Text));
							TempSave((int)Math.Round(Conversion.Val(mSG[mSG.Row, 0])));
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

	private void TempSave(int L)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_2272: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tToLcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Transfer Franchise And Try.... ", (MsgBoxStyle)0, (object)null);
			return;
		}
		if (Operators.CompareString(TmpEntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			DC_Main.RsQry = "DELETE FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if ((Conversion.Val(MSG_TOT[0, 30]) != 0.0) | (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 25]) != 0.0))
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
				DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow2 = RsData.NewRow();
				dataRow2["CO_CODE"] = DC_Main.MCo_code;
				dataRow2["LC_CODE"] = DC_Main.MLc_code;
				dataRow2["CO_YEAR"] = DC_Main.MCo_year;
				dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
				dataRow2["VCH_NO"] = tVchNo.Text;
				dataRow2["VCH_DATE"] = mVchDate.Text;
				dataRow2["AC_CODE"] = FanAcCode;
				dataRow2["VCH_TYPE"] = FormBookSname;
				dataRow2["INOUT_TYPE"] = FormBookInOut;
				dataRow2["ENTRY_TYPE"] = "O";
				dataRow2["BOOK_NAME"] = FormMainBook;
				dataRow2["TO_FAN_CODE"] = tToLcCode.Text;
				dataRow2["TO_CO_BOOK"] = tToBook.Text;
				dataRow2["TO_VCH_NO"] = tToVchNo.Text;
				dataRow2["FROM_FAN_CODE"] = DC_Main.MCo_code;
				dataRow2["FROM_CO_BOOK"] = DC_Main.MCo_Book;
				dataRow2["FROM_VCH_NO"] = tVchNo.Text;
				dataRow2["STK_TRFR"] = "N";
				dataRow2["TOT_GWT"] = Conversion.Val(MSG_TOT[0, 11]);
				dataRow2["TOT_NWT"] = Conversion.Val(MSG_TOT[0, 13]);
				dataRow2["TOT_FINE"] = Conversion.Val(MSG_TOT[0, 18]);
				dataRow2["PARTY_FINE"] = Conversion.Val(nPartyFine.Text);
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
				dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
				dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 24]);
				dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 25]);
				dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
				dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
				dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
				dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[10, 3]);
				dataRow2["CARD_AC"] = MSG2_TOTAL[7, 4];
				dataRow2["BANK_AC"] = MSG2_TOTAL[6, 4];
				dataRow2["CHQ_NO"] = MSG2_TOTAL[6, 2];
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
				dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
				dataRow2["EMP_CODE"] = tEmpCode.Text;
				dataRow2["VCH_DESC"] = tVchDesc.Text;
				dataRow2["TAG_VCH_NO"] = tTagVch.Text;
				dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow2["DATA_TRFR"] = "N";
				dataRow2["MAIN_USER"] = MainUser;
				dataRow2["USER_UPDATE"] = "N";
				dataRow2["USER_DELETE"] = "N";
				RsData.Rows.Add(dataRow2);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
				RsData.Clear();
			}
			EntryMode = "E";
			TmpEntryMode = "E";
		}
		BillSavePanding = true;
		DC_Main.RsQry = ("DELETE FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = ("SELECT * FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow3 = RsDetl.NewRow();
		AxMSFlexGrid mSG = MSG;
		if (((Operators.CompareString(mSG[L, 2], "", false) != 0) & (Operators.CompareString(mSG[L, 1], "", false) != 0) & (Conversion.Val(mSG[L, 30]) != 0.0)) | (Conversion.Val(mSG[L, 10]) + Conversion.Val(mSG[L, 11]) + Conversion.Val(mSG[L, 24]) + Conversion.Val(mSG[L, 25]) != 0.0))
		{
			dataRow3["CO_CODE"] = DC_Main.MCo_code;
			dataRow3["LC_CODE"] = DC_Main.MLc_code;
			dataRow3["CO_YEAR"] = DC_Main.MCo_year;
			dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow3["VCH_NO"] = tVchNo.Text;
			dataRow3["VCH_DATE"] = mVchDate.Text;
			dataRow3["TO_FAN_CODE"] = tToLcCode.Text;
			dataRow3["TO_CO_BOOK"] = tToBook.Text;
			dataRow3["TO_VCH_NO"] = tToVchNo.Text;
			dataRow3["FROM_FAN_CODE"] = DC_Main.MCo_code;
			dataRow3["FROM_CO_BOOK"] = DC_Main.MCo_Book;
			dataRow3["FROM_VCH_NO"] = tVchNo.Text;
			dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow3["AC_CODE"] = FanAcCode;
			dataRow3["VCH_TYPE"] = FormBookSname;
			dataRow3["INOUT_TYPE"] = FormBookInOut;
			dataRow3["ENTRY_TYPE"] = "O";
			dataRow3["BOOK_NAME"] = FormMainBook;
			dataRow3["SR_NO"] = Conversion.Val(mSG[L, 0]);
			dataRow3["OLD_SRNO"] = Conversion.Val(mSG[L, 43]);
			dataRow3["IT_CODE"] = mSG[L, 2];
			if (Operators.CompareString(mSG[L, 1], "", false) == 0)
			{
				dataRow3["TAG_NO"] = "N";
			}
			else
			{
				dataRow3["TAG_NO"] = mSG[L, 1];
			}
			dataRow3["TBL_CODE"] = mSG[L, 3];
			dataRow3["DESIGN_NO"] = mSG[L, 4];
			dataRow3["ITM_COLOR"] = mSG[L, 5];
			dataRow3["HM_ID"] = mSG[L, 7];
			dataRow3["WITH_RFID"] = mSG[L, 35];
			dataRow3["ITM_SIZE"] = mSG[L, 6];
			dataRow3["BAG_WT"] = Conversion.Val(mSG[L, 9]);
			dataRow3["ITM_PCS"] = Conversion.Val(mSG[L, 10]);
			dataRow3["ITM_GWT"] = Conversion.Val(mSG[L, 11]);
			dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[L, 12]);
			dataRow3["ITM_NWT"] = Conversion.Val(mSG[L, 13]);
			dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[L, 15]);
			dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[L, 16]);
			dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[L, 17]);
			dataRow3["ITM_FINE"] = Conversion.Val(mSG[L, 18]);
			dataRow3["LBR_PRC"] = Conversion.Val(mSG[L, 21]);
			dataRow3["LBR_TYPE"] = mSG[L, 22];
			dataRow3["LBR_RATE"] = Conversion.Val(mSG[L, 23]);
			dataRow3["LBR_AMT"] = Conversion.Val(mSG[L, 24]);
			dataRow3["OTH_AMT"] = Conversion.Val(mSG[L, 25]);
			dataRow3["ITM_RATE"] = Conversion.Val(mSG[L, 19]);
			dataRow3["ITM_AMT"] = Conversion.Val(mSG[L, 20]);
			dataRow3["ITM_MRP"] = Conversion.Val(mSG[L, 30]);
			dataRow3["MAIN_MRP"] = Conversion.Val(mSG[L, 28]);
			dataRow3["NET_AMT"] = Conversion.Val(mSG[L, 31]);
			dataRow3["KR_NET_WT"] = Conversion.Val(mSG[L, 37]);
			dataRow3["KR_TOUCH"] = Conversion.Val(mSG[L, 38]);
			dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[L, 39]);
			dataRow3["KR_FINE"] = Conversion.Val(mSG[L, 40]);
			dataRow3["KR_NAME"] = mSG[L, 34];
			dataRow3["RATE_TYPE"] = mSG[L, 44];
			dataRow3["IT_TYPE"] = mSG[L, 45];
			dataRow3["PR_CODE"] = mSG[L, 47];
			dataRow3["VCH_SRNO"] = Conversion.Val(mSG[L, 72]);
			dataRow3["HM_ID2"] = mSG[L, 64];
			dataRow3["HM_ID3"] = mSG[L, 65];
			dataRow3["HM_ID4"] = mSG[L, 66];
			dataRow3["HM_ID_WT"] = Conversion.Val(mSG[L, 67]);
			dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[L, 68]);
			dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[L, 69]);
			dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[L, 70]);
			dataRow3["EMP_ISU"] = mSG[L, 73];
			if (Operators.CompareString(mSG[L, 73], "", false) == 0)
			{
				dataRow3["EMP_ISU"] = "N";
			}
			dataRow3["LOT_TYPE"] = mSG[L, 71];
			dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow3["DATA_TRFR"] = "N";
			dataRow3["MAIN_USER"] = MainUser;
			double num = 0.0;
			num = Conversion.Val(mSG[L, 9]) + Conversion.Val(mSG[L, 10]) + Conversion.Val(mSG[L, 11]) + Conversion.Val(mSG[L, 18]) + Conversion.Val(mSG[L, 37]) + Conversion.Val(mSG[L, 40]);
			num += Conversion.Val(mSG[L, 21]) + Conversion.Val(mSG[L, 24]) + Conversion.Val(mSG[L, 25]) + Conversion.Val(mSG[L, 26]) + Conversion.Val(mSG[L, 30]);
			num += Conversion.Val(mSG[L, 67]);
			string text = "";
			text = mSG[L, 2] + mSG[L, 1] + mSG[L, 3] + mSG[L, 4] + mSG[L, 6] + mSG[L, 7] + mSG[L, 63] + mSG[L, 34] + mSG[L, 35];
			mSG[L, 74] = Strings.Format((object)num, "0.000");
			mSG[L, 75] = text;
			RsDetl.Rows.Add(dataRow3);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
			RsDetl.Clear();
		}
		mSG = null;
		DC_Main.RsQry = ("DELETE FROM FAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		DC_Main.RsQry = ("SELECT * FROM FAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND SR_NO = " + Conversions.ToString(L)) ?? "";
		RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.MsInsertData();
		DataRow dataRow4 = RsIdtl.NewRow();
		int num2 = L;
		checked
		{
			int num3 = MSG_IDTL.Rows - 1;
			for (int i = 1; i <= num3; i++)
			{
				AxMSFlexGrid mSG_IDTL = MSG_IDTL;
				if (Conversion.Val(mSG_IDTL[i, 3]) + Conversion.Val(mSG_IDTL[i, 4]) + Conversion.Val(mSG_IDTL[i, 12]) != 0.0)
				{
					int num4 = MSG.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num4)
					{
						if (Conversion.Val(MSG[DC_Main.M, 43]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])))
						{
							num2 = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["TO_FAN_CODE"] = tToLcCode.Text;
					dataRow4["TO_CO_BOOK"] = tToBook.Text;
					dataRow4["TO_VCH_NO"] = tToVchNo.Text;
					dataRow4["FROM_FAN_CODE"] = DC_Main.MCo_code;
					dataRow4["FROM_CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["FROM_VCH_NO"] = tVchNo.Text;
					dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["AC_CODE"] = FanAcCode;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = "T";
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow4["TAG_NO"] = MSG[num2, 1];
					dataRow4["VCH_SRNO"] = MSG[num2, 72];
					dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]));
					dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]));
					dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]));
					dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]));
					dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
					dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
					dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
					dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
					dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
					dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]);
					dataRow4["MAIN_USER"] = MainUser;
					dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]);
					dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]);
					dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
					dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]);
					dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]);
					dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
					dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]);
					dataRow4["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][24]));
					dataRow4["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25]));
					dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26]));
					dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][27]));
					dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][28]));
					dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29]));
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				mSG_IDTL = null;
			}
			Interaction.MsgBox((object)"Row Data Save....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void TR_FN_INOUT_Load(object sender, EventArgs e)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		Cr.Connect = DC_Main.CrConnect;
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
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj48 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj49 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj50 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj50 != null) ? ((Color)obj50) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj51 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj51 != null) ? ((Color)obj51) : default(Color));
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
			if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
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
			if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
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
		OldNetAmt = 0.0;
		OldTdsPrc = 0.0;
		AcGstType = "L";
		FanAcCode = "";
		lblItStock.Text = "Itm Stock :";
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
		((Control)TEXT_ENTRY_2).Visible = false;
		BillSavePanding = false;
		MSG_CLEAR();
		MSG_IDTL_CLEAR();
		MSG2_CLEAR();
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
					double num2 = DC_Main.Fnv(ref Value);
					dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
					mSG2_TOTAL[2, 2] = Strings.Format((object)num2, "0.00");
					MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
				}
			}
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tToLcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_FAN_CODE"], (object)""));
				tToBook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_CO_BOOK"], (object)""));
				tToVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_VCH_NO"], (object)""));
				tFrmLc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_FAN_CODE"], (object)""));
				tFrombook.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_CO_BOOK"], (object)""));
				tFromVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_VCH_NO"], (object)""));
				if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.* FROM FAN_AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.FAN_CO_CODE =  '" + tFrmLc.Text + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						FanAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FAN_AC_CODE"], (object)""));
					}
				}
				else
				{
					FanAcCode = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				}
				DC_Main.RsQry = "SELECT CO_NAME FROM CO_MAST WHERE CO_CODE ='" + tToLcCode.Text + "' AND LC_CODE = '00'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT CO_NAME FROM CO_MAST WHERE CO_CODE ='" + tFrmLc.Text + "' AND LC_CODE = '00'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tFromLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_NAME"], (object)""));
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				OldNetAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00"));
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
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
				tTagVch.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAG_VCH_NO"], (object)""));
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
				EntryMode = "E";
				TmpEntryMode = "E";
				MSG_CLEAR();
				MSG_IDTL_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM FAN_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 43] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID"], (object)""));
					mSG[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["WITH_RFID"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["BAG_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 28] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MAIN_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
					mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
					mSG[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3"], (object)""));
					mSG[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4"], (object)""));
					mSG[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID_WT"], (object)""));
					mSG[DC_Main.i + 1, 68] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID2_WT"], (object)""));
					mSG[DC_Main.i + 1, 69] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID3_WT"], (object)""));
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["HM_ID4_WT"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["EMP_ISU"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PR_CODE"], (object)""));
					mSG[DC_Main.i + 1, 49] = "E";
					double num3 = 0.0;
					num3 = Conversion.Val(mSG[DC_Main.i + 1, 9]) + Conversion.Val(mSG[DC_Main.i + 1, 10]) + Conversion.Val(mSG[DC_Main.i + 1, 11]) + Conversion.Val(mSG[DC_Main.i + 1, 13]) + Conversion.Val(mSG[DC_Main.i + 1, 18]) + Conversion.Val(mSG[DC_Main.i + 1, 37]) + Conversion.Val(mSG[DC_Main.i + 1, 40]);
					num3 += Conversion.Val(mSG[DC_Main.i + 1, 21]) + Conversion.Val(mSG[DC_Main.i + 1, 24]) + Conversion.Val(mSG[DC_Main.i + 1, 25]) + Conversion.Val(mSG[DC_Main.i + 1, 26]) + Conversion.Val(mSG[DC_Main.i + 1, 30]);
					num3 += Conversion.Val(mSG[DC_Main.i + 1, 67]) + Conversion.Val(mSG[DC_Main.i + 1, 19]) + Conversion.Val(mSG[DC_Main.i + 1, 20]);
					string text = "";
					text = mSG[DC_Main.i + 1, 2] + mSG[DC_Main.i + 1, 1] + mSG[DC_Main.i + 1, 3] + mSG[DC_Main.i + 1, 4] + mSG[DC_Main.i + 1, 6] + mSG[DC_Main.i + 1, 7] + mSG[DC_Main.i + 1, 63] + mSG[DC_Main.i + 1, 34] + mSG[DC_Main.i + 1, 35] + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy");
					mSG[DC_Main.i + 1, 74] = Strings.Format((object)num3, "0.000");
					mSG[DC_Main.i + 1, 75] = text;
					mSG.Rows += 1;
					DC_Main.i++;
				}
				mSG.Rows -= 1;
				mSG = null;
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM FAN_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
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
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
				NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 37]) + Conversion.Val(MSG_TOT[0, 25]) + Conversion.Val(MSG_TOT[0, 24]);
				EntryMode = "E";
				TmpEntryMode = "E";
				MsVchSrno = "";
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
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (BillSavePanding)
		{
			Interaction.MsgBox((object)"Please Save Voucher First Then Cancel... Because Row Wise Entry Is Save But Voucher Is Not Save ....", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void TR_FN_INOUT_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_FN_INOUT_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0786: Unknown result type (might be due to invalid IL or missing references)
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
		if (Operators.CompareString(tToLcCode.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Transfer Franchise Code An Try  ....", (MsgBoxStyle)0, (object)null);
			((Control)tToLcCode).Focus();
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if (Operators.CompareString(tVchNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		MSG_TOT_FILL();
		if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM FAN_AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.FAN_CO_CODE =  '" + tFrmLc.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				FanAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FAN_AC_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_GST_TYPE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + FanAcCode + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_GST_TYPE"], (object)""));
				}
			}
		}
		else
		{
			DC_Main.RsQry = "SELECT A.* FROM FAN_AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.FAN_CO_CODE =  '" + tToLcCode.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				FanAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FAN_AC_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_GST_TYPE FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + FanAcCode + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_GST_TYPE"], (object)""));
				}
			}
		}
		tToBook.Text = "062";
		if ((Operators.CompareString(EntryMode, "A", false) == 0) | (Operators.CompareString(tToVchNo.Text, "", false) == 0))
		{
			DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From FAN_DATA WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + tToBook.Text + "' HAVING MAX(VCH_NO) > 0";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tToVchNo.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VchNo"])) + 1.0), "00000");
			}
			else
			{
				tToVchNo.Text = "00001";
			}
		}
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		int num = 0;
		checked
		{
			if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM FAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				if ((Conversion.Val(MSG_TOT[0, 30]) != 0.0) | (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 25]) != 0.0))
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
					DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
					RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.MsInsertData();
					DataRow dataRow2 = RsData.NewRow();
					dataRow2["CO_CODE"] = DC_Main.MCo_code;
					dataRow2["LC_CODE"] = DC_Main.MLc_code;
					dataRow2["CO_YEAR"] = DC_Main.MCo_year;
					dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["VCH_NO"] = tVchNo.Text;
					dataRow2["VCH_DATE"] = mVchDate.Text;
					dataRow2["AC_CODE"] = FanAcCode;
					dataRow2["VCH_TYPE"] = FormBookSname;
					dataRow2["INOUT_TYPE"] = FormBookInOut;
					dataRow2["ENTRY_TYPE"] = "O";
					dataRow2["BOOK_NAME"] = FormMainBook;
					dataRow2["TO_FAN_CODE"] = tToLcCode.Text;
					dataRow2["TO_CO_BOOK"] = tToBook.Text;
					dataRow2["TO_VCH_NO"] = tToVchNo.Text;
					dataRow2["FROM_FAN_CODE"] = DC_Main.MCo_code;
					dataRow2["FROM_CO_BOOK"] = DC_Main.MCo_Book;
					dataRow2["FROM_VCH_NO"] = tVchNo.Text;
					dataRow2["STK_TRFR"] = "N";
					dataRow2["TOT_GWT"] = Conversion.Val(MSG_TOT[0, 11]);
					dataRow2["TOT_NWT"] = Conversion.Val(MSG_TOT[0, 13]);
					dataRow2["TOT_FINE"] = Conversion.Val(MSG_TOT[0, 18]);
					dataRow2["PARTY_FINE"] = Conversion.Val(nPartyFine.Text);
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
					dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
					dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 24]);
					dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 25]);
					dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
					dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
					dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
					dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
					dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[10, 3]);
					dataRow2["CARD_AC"] = MSG2_TOTAL[7, 4];
					dataRow2["BANK_AC"] = MSG2_TOTAL[6, 4];
					dataRow2["CHQ_NO"] = MSG2_TOTAL[6, 2];
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
					dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow2["EMP_CODE"] = tEmpCode.Text;
					dataRow2["VCH_DESC"] = tVchDesc.Text;
					dataRow2["TAG_VCH_NO"] = tTagVch.Text;
					dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow2["DATA_TRFR"] = "N";
					dataRow2["MAIN_USER"] = MainUser;
					dataRow2["USER_UPDATE"] = "N";
					dataRow2["USER_DELETE"] = "N";
					RsData.Rows.Add(dataRow2);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
					RsData.Clear();
				}
				BillSavePanding = false;
				int num2 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num2)
				{
					AxMSFlexGrid mSG = MSG;
					double num3 = 0.0;
					num3 = Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 10]) + Conversion.Val(mSG[DC_Main.i, 11]) + Conversion.Val(mSG[DC_Main.i, 13]) + Conversion.Val(mSG[DC_Main.i, 18]) + Conversion.Val(mSG[DC_Main.i, 37]) + Conversion.Val(mSG[DC_Main.i, 40]);
					num3 += Conversion.Val(mSG[DC_Main.i, 21]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 25]) + Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 30]);
					num3 += Conversion.Val(mSG[DC_Main.i, 67]) + Conversion.Val(mSG[DC_Main.i, 19]) + Conversion.Val(mSG[DC_Main.i, 20]);
					string text = "";
					text = mSG[DC_Main.i, 2] + mSG[DC_Main.i, 1] + mSG[DC_Main.i, 3] + mSG[DC_Main.i, 4] + mSG[DC_Main.i, 6] + mSG[DC_Main.i, 7] + mSG[DC_Main.i, 63] + mSG[DC_Main.i, 34] + mSG[DC_Main.i, 35] + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy");
					if ((Operators.CompareString(Strings.Format((object)Conversion.Val(mSG[DC_Main.i, 74]), "0.000"), Strings.Format((object)num3, "0.000"), false) != 0) | (Operators.CompareString(mSG[DC_Main.i, 75], text, false) != 0))
					{
						DC_Main.ExeQuteDc("DELETE FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 43])) + " ");
						DC_Main.RsQry = "SELECT * FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 43])) + " ";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow3 = RsDetl.NewRow();
						if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 10]) + Conversion.Val(mSG[DC_Main.i, 11]) + Conversion.Val(mSG[DC_Main.i, 24]) + Conversion.Val(mSG[DC_Main.i, 25]) != 0.0))
						{
							dataRow3["CO_CODE"] = DC_Main.MCo_code;
							dataRow3["LC_CODE"] = DC_Main.MLc_code;
							dataRow3["CO_YEAR"] = DC_Main.MCo_year;
							dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow3["VCH_NO"] = tVchNo.Text;
							dataRow3["VCH_DATE"] = mVchDate.Text;
							dataRow3["TO_FAN_CODE"] = tToLcCode.Text;
							dataRow3["TO_CO_BOOK"] = tToBook.Text;
							dataRow3["TO_VCH_NO"] = tToVchNo.Text;
							dataRow3["FROM_FAN_CODE"] = DC_Main.MCo_code;
							dataRow3["FROM_CO_BOOK"] = DC_Main.MCo_Book;
							dataRow3["FROM_VCH_NO"] = tVchNo.Text;
							dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow3["AC_CODE"] = FanAcCode;
							dataRow3["VCH_TYPE"] = FormBookSname;
							dataRow3["INOUT_TYPE"] = FormBookInOut;
							dataRow3["ENTRY_TYPE"] = "O";
							dataRow3["BOOK_NAME"] = FormMainBook;
							dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
							dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 43]);
							dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
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
							dataRow3["HM_ID"] = mSG[DC_Main.i, 7];
							dataRow3["WITH_RFID"] = mSG[DC_Main.i, 35];
							dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
							dataRow3["BAG_WT"] = Conversion.Val(mSG[DC_Main.i, 9]);
							dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 10]);
							dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 11]);
							dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 12]);
							dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 13]);
							dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 15]);
							dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 16]);
							dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 17]);
							dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 18]);
							dataRow3["LBR_PRC"] = Conversion.Val(mSG[DC_Main.i, 21]);
							dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 22];
							dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 23]);
							dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
							dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
							dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 19]);
							dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
							dataRow3["MAIN_MRP"] = Conversion.Val(mSG[DC_Main.i, 28]);
							dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 30]);
							dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 31]);
							dataRow3["KR_NET_WT"] = Conversion.Val(mSG[DC_Main.i, 37]);
							dataRow3["KR_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 38]);
							dataRow3["KR_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 39]);
							dataRow3["KR_FINE"] = Conversion.Val(mSG[DC_Main.i, 40]);
							dataRow3["KR_NAME"] = mSG[DC_Main.i, 34];
							dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 44];
							dataRow3["IT_TYPE"] = mSG[DC_Main.i, 45];
							dataRow3["PR_CODE"] = mSG[DC_Main.i, 47];
							dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 72]);
							dataRow3["HM_ID2"] = mSG[DC_Main.i, 64];
							dataRow3["HM_ID3"] = mSG[DC_Main.i, 65];
							dataRow3["HM_ID4"] = mSG[DC_Main.i, 66];
							dataRow3["HM_ID_WT"] = Conversion.Val(mSG[DC_Main.i, 67]);
							dataRow3["HM_ID2_WT"] = Conversion.Val(mSG[DC_Main.i, 68]);
							dataRow3["HM_ID3_WT"] = Conversion.Val(mSG[DC_Main.i, 69]);
							dataRow3["HM_ID4_WT"] = Conversion.Val(mSG[DC_Main.i, 70]);
							dataRow3["EMP_ISU"] = mSG[DC_Main.i, 73];
							if (Operators.CompareString(mSG[DC_Main.i, 73], "", false) == 0)
							{
								dataRow3["EMP_ISU"] = "N";
							}
							dataRow3["LOT_TYPE"] = mSG[DC_Main.i, 71];
							dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow3["DATA_TRFR"] = "N";
							dataRow3["MAIN_USER"] = MainUser;
							RsDetl.Rows.Add(dataRow3);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
							RsDetl.Clear();
						}
					}
					mSG = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM FAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow4 = RsIdtl.NewRow();
				num = 0;
				int num4 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					DataTable dtIdtl = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12])) != 0.0)
					{
						int num5 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num5)
						{
							if (Conversion.Val(MSG[DC_Main.M, 43]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])))
							{
								num = DC_Main.M;
								break;
							}
							DC_Main.M++;
						}
						dataRow4["CO_CODE"] = DC_Main.MCo_code;
						dataRow4["LC_CODE"] = DC_Main.MLc_code;
						dataRow4["CO_YEAR"] = DC_Main.MCo_year;
						dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["VCH_NO"] = tVchNo.Text;
						dataRow4["TO_FAN_CODE"] = tToLcCode.Text;
						dataRow4["TO_CO_BOOK"] = tToBook.Text;
						dataRow4["TO_VCH_NO"] = tToVchNo.Text;
						dataRow4["FROM_FAN_CODE"] = DC_Main.MCo_code;
						dataRow4["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						dataRow4["FROM_VCH_NO"] = tVchNo.Text;
						dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow4["VCH_DATE"] = mVchDate.Text;
						dataRow4["AC_CODE"] = FanAcCode;
						dataRow4["VCH_TYPE"] = FormBookSname;
						dataRow4["INOUT_TYPE"] = FormBookInOut;
						dataRow4["ENTRY_TYPE"] = "T";
						dataRow4["BOOK_NAME"] = FormMainBook;
						dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
						dataRow4["TAG_NO"] = MSG[num, 1];
						dataRow4["VCH_SRNO"] = MSG[num, 72];
						dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
						dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
						dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][3]));
						dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]));
						dataRow4["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]));
						dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]));
						dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]);
						dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
						dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
						dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
						dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
						dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
						dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]));
						dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]);
						dataRow4["MAIN_USER"] = MainUser;
						dataRow4["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]);
						dataRow4["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]);
						dataRow4["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
						dataRow4["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]);
						dataRow4["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]);
						dataRow4["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]);
						dataRow4["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][23]);
						dataRow4["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][24]));
						dataRow4["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][25]));
						dataRow4["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][26]));
						dataRow4["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][27]));
						dataRow4["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][28]));
						dataRow4["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][29]));
						RsIdtl.Rows.Add(dataRow4);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
						RsIdtl.Clear();
					}
					dtIdtl = null;
				}
			}
			DC_Main.ExeQuteDc("DELETE FROM FAN_DATA WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FAN_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FAN_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			if ((Conversion.Val(MSG_TOT[0, 30]) != 0.0) | (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 25]) != 0.0))
			{
				DC_Main.RsQry = "SELECT * FROM FAN_DATA WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
				RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow5 = RsData.NewRow();
				dataRow5["CO_CODE"] = tToLcCode.Text;
				dataRow5["LC_CODE"] = "00";
				dataRow5["CO_YEAR"] = DC_Main.MCo_year;
				dataRow5["CO_BOOK"] = tToBook.Text;
				dataRow5["VCH_NO"] = tToVchNo.Text;
				dataRow5["HD_VCH_NO"] = tToVchNo.Text;
				dataRow5["VCH_DATE"] = mVchDate.Text;
				dataRow5["AC_CODE"] = FanAcCode;
				dataRow5["AC_GST_TYPE"] = AcGstType;
				dataRow5["TO_FAN_CODE"] = tToLcCode.Text;
				dataRow5["TO_CO_BOOK"] = tToBook.Text;
				dataRow5["TO_VCH_NO"] = tToVchNo.Text;
				if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
				{
					dataRow5["FROM_FAN_CODE"] = tFrmLc.Text;
					dataRow5["FROM_CO_BOOK"] = tFrombook.Text;
					dataRow5["FROM_VCH_NO"] = tFromVchNo.Text;
				}
				else
				{
					dataRow5["FROM_FAN_CODE"] = DC_Main.MCo_code;
					dataRow5["FROM_CO_BOOK"] = DC_Main.MCo_Book;
					dataRow5["FROM_VCH_NO"] = tVchNo.Text;
				}
				dataRow5["VCH_TYPE"] = "FNPUR";
				dataRow5["INOUT_TYPE"] = "I";
				dataRow5["ENTRY_TYPE"] = "I";
				dataRow5["BOOK_NAME"] = "FAN PURC";
				if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
				{
					dataRow5["STK_TRFR"] = "Y";
				}
				else
				{
					dataRow5["STK_TRFR"] = "N";
				}
				dataRow5["TOT_GWT"] = Conversion.Val(MSG_TOT[0, 11]);
				dataRow5["TOT_NWT"] = Conversion.Val(MSG_TOT[0, 13]);
				dataRow5["TOT_FINE"] = Conversion.Val(MSG_TOT[0, 18]);
				dataRow5["PARTY_FINE"] = Conversion.Val(nPartyFine.Text);
				dataRow5["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
				dataRow5["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
				dataRow5["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
				dataRow5["TAX_CODE"] = MSG2_TOTAL[2, 4];
				dataRow5["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
				dataRow5["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
				dataRow5["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 24]);
				dataRow5["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 25]);
				dataRow5["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
				dataRow5["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
				dataRow5["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
				dataRow5["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
				dataRow5["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[9, 3]);
				dataRow5["BILL_OS"] = Conversion.Val(MSG2_TOTAL[10, 3]);
				dataRow5["EMP_CODE"] = tEmpCode.Text;
				dataRow5["VCH_DESC"] = tVchDesc.Text;
				dataRow5["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
				dataRow5["DATA_TRFR"] = "N";
				dataRow5["MAIN_USER"] = MainUser;
				RsData.Rows.Add(dataRow5);
				((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
				RsData.Clear();
			}
			DC_Main.RsQry = "SELECT * FROM FAN_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
			RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow6 = RsDetl.NewRow();
			int num6 = MSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num6)
			{
				AxMSFlexGrid mSG2 = MSG;
				if (((Operators.CompareString(mSG2[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG2[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(mSG2[DC_Main.i, 10]) + Conversion.Val(mSG2[DC_Main.i, 11]) + Conversion.Val(mSG2[DC_Main.i, 24]) + Conversion.Val(mSG2[DC_Main.i, 25]) != 0.0))
				{
					dataRow6["CO_CODE"] = tToLcCode.Text;
					dataRow6["LC_CODE"] = "00";
					dataRow6["CO_YEAR"] = DC_Main.MCo_year;
					dataRow6["CO_BOOK"] = tToBook.Text;
					dataRow6["VCH_NO"] = tToVchNo.Text;
					dataRow6["VCH_DATE"] = mVchDate.Text;
					dataRow6["TO_FAN_CODE"] = tToLcCode.Text;
					dataRow6["TO_CO_BOOK"] = tToBook.Text;
					dataRow6["TO_VCH_NO"] = tToVchNo.Text;
					if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
					{
						dataRow6["FROM_FAN_CODE"] = tFrmLc.Text;
						dataRow6["FROM_CO_BOOK"] = tFrombook.Text;
						dataRow6["FROM_VCH_NO"] = tFromVchNo.Text;
					}
					else
					{
						dataRow6["FROM_FAN_CODE"] = DC_Main.MCo_code;
						dataRow6["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						dataRow6["FROM_VCH_NO"] = tVchNo.Text;
					}
					dataRow6["HD_VCH_NO"] = tToVchNo.Text;
					dataRow6["AC_CODE"] = FanAcCode;
					dataRow6["VCH_TYPE"] = "FNPUR";
					dataRow6["INOUT_TYPE"] = "I";
					dataRow6["ENTRY_TYPE"] = "I";
					dataRow6["BOOK_NAME"] = "FAN PURC";
					dataRow6["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
					dataRow6["OLD_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 43]);
					dataRow6["IT_CODE"] = mSG2[DC_Main.i, 2];
					if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) == 0)
					{
						dataRow6["TAG_NO"] = "N";
					}
					else
					{
						dataRow6["TAG_NO"] = mSG2[DC_Main.i, 1];
					}
					dataRow6["TBL_CODE"] = mSG2[DC_Main.i, 3];
					dataRow6["DESIGN_NO"] = mSG2[DC_Main.i, 4];
					dataRow6["WITH_RFID"] = mSG2[DC_Main.i, 35];
					dataRow6["ITM_COLOR"] = mSG2[DC_Main.i, 5];
					dataRow6["HM_ID"] = mSG2[DC_Main.i, 7];
					dataRow6["ITM_SIZE"] = mSG2[DC_Main.i, 6];
					dataRow6["BAG_WT"] = Conversion.Val(mSG2[DC_Main.i, 9]);
					dataRow6["ITM_PCS"] = Conversion.Val(mSG2[DC_Main.i, 10]);
					dataRow6["ITM_GWT"] = Conversion.Val(mSG2[DC_Main.i, 11]);
					dataRow6["ITM_OTH_WT"] = Conversion.Val(mSG2[DC_Main.i, 12]);
					dataRow6["ITM_NWT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
					dataRow6["ITM_GHT_WT"] = Conversion.Val(mSG2[DC_Main.i, 15]);
					dataRow6["ITM_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 16]);
					dataRow6["ITM_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 17]);
					dataRow6["ITM_FINE"] = Conversion.Val(mSG2[DC_Main.i, 18]);
					dataRow6["LBR_PRC"] = Conversion.Val(mSG2[DC_Main.i, 21]);
					dataRow6["LBR_TYPE"] = mSG2[DC_Main.i, 22];
					dataRow6["LBR_RATE"] = Conversion.Val(mSG2[DC_Main.i, 23]);
					dataRow6["LBR_AMT"] = Conversion.Val(mSG2[DC_Main.i, 24]);
					dataRow6["OTH_AMT"] = Conversion.Val(mSG2[DC_Main.i, 25]);
					dataRow6["ITM_RATE"] = Conversion.Val(mSG2[DC_Main.i, 19]);
					dataRow6["ITM_AMT"] = Conversion.Val(mSG2[DC_Main.i, 20]);
					dataRow6["MAIN_MRP"] = Conversion.Val(mSG2[DC_Main.i, 28]);
					dataRow6["ITM_MRP"] = Conversion.Val(mSG2[DC_Main.i, 30]);
					dataRow6["NET_AMT"] = Conversion.Val(mSG2[DC_Main.i, 31]);
					dataRow6["KR_NET_WT"] = Conversion.Val(mSG2[DC_Main.i, 37]);
					dataRow6["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 38]);
					dataRow6["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 39]);
					dataRow6["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 40]);
					dataRow6["KR_NAME"] = mSG2[DC_Main.i, 34];
					dataRow6["RATE_TYPE"] = mSG2[DC_Main.i, 44];
					dataRow6["IT_TYPE"] = mSG2[DC_Main.i, 45];
					dataRow6["PR_CODE"] = mSG2[DC_Main.i, 47];
					dataRow6["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 43]));
					dataRow6["HM_ID2"] = mSG2[DC_Main.i, 64];
					dataRow6["HM_ID3"] = mSG2[DC_Main.i, 65];
					dataRow6["HM_ID4"] = mSG2[DC_Main.i, 66];
					dataRow6["HM_ID_WT"] = Conversion.Val(mSG2[DC_Main.i, 67]);
					dataRow6["HM_ID2_WT"] = Conversion.Val(mSG2[DC_Main.i, 68]);
					dataRow6["HM_ID3_WT"] = Conversion.Val(mSG2[DC_Main.i, 69]);
					dataRow6["HM_ID4_WT"] = Conversion.Val(mSG2[DC_Main.i, 70]);
					dataRow6["LOT_TYPE"] = mSG2[DC_Main.i, 71];
					dataRow6["EMP_ISU"] = mSG2[DC_Main.i, 73];
					if (Operators.CompareString(mSG2[DC_Main.i, 73], "", false) == 0)
					{
						dataRow6["EMP_ISU"] = "N";
					}
					dataRow6["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow6["DATA_TRFR"] = "N";
					dataRow6["MAIN_USER"] = MainUser;
					RsDetl.Rows.Add(dataRow6);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG2 = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM FAN_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow7 = RsIdtl.NewRow();
			num = 0;
			int num7 = DtIdtl.Rows.Count - 1;
			for (int j = 0; j <= num7; j++)
			{
				DataTable dtIdtl2 = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12])) != 0.0)
				{
					int num8 = MSG.Rows - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num8)
					{
						if (Conversion.Val(MSG[DC_Main.M, 43]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16])))
						{
							num = DC_Main.M;
							break;
						}
						DC_Main.M++;
					}
					dataRow7["CO_CODE"] = tToLcCode.Text;
					dataRow7["LC_CODE"] = "00";
					dataRow7["CO_YEAR"] = DC_Main.MCo_year;
					dataRow7["CO_BOOK"] = tToBook.Text;
					dataRow7["VCH_NO"] = tToVchNo.Text;
					dataRow7["TO_FAN_CODE"] = tToLcCode.Text;
					dataRow7["TO_CO_BOOK"] = tToBook.Text;
					dataRow7["TO_VCH_NO"] = tToVchNo.Text;
					if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
					{
						dataRow6["FROM_FAN_CODE"] = tFrmLc.Text;
						dataRow6["FROM_CO_BOOK"] = tFrombook.Text;
						dataRow6["FROM_VCH_NO"] = tFromVchNo.Text;
					}
					else
					{
						dataRow6["FROM_FAN_CODE"] = DC_Main.MCo_code;
						dataRow6["FROM_CO_BOOK"] = DC_Main.MCo_Book;
						dataRow6["FROM_VCH_NO"] = tVchNo.Text;
					}
					dataRow7["HD_VCH_NO"] = tToVchNo.Text;
					dataRow7["VCH_DATE"] = mVchDate.Text;
					dataRow7["AC_CODE"] = FanAcCode;
					dataRow7["VCH_TYPE"] = "FNPUR";
					dataRow7["INOUT_TYPE"] = "I";
					dataRow7["ENTRY_TYPE"] = "I";
					dataRow7["BOOK_NAME"] = "FAN PURC";
					dataRow7["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][16]));
					dataRow7["TAG_NO"] = MSG[num, 1];
					dataRow7["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(num);
					dataRow7["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][0]));
					dataRow7["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][1]);
					dataRow7["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][3]));
					dataRow7["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][4]));
					dataRow7["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][5]));
					dataRow7["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][6]));
					dataRow7["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][7]);
					dataRow7["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][8]));
					dataRow7["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][9]));
					dataRow7["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][10]));
					dataRow7["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][11]));
					dataRow7["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][12]));
					dataRow7["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][13]));
					dataRow7["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][15]);
					dataRow7["MAIN_USER"] = MainUser;
					dataRow7["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][17]);
					dataRow7["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][18]);
					dataRow7["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][19]);
					dataRow7["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][20]);
					dataRow7["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][21]);
					dataRow7["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][22]);
					dataRow7["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][23]);
					dataRow7["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][24]));
					dataRow7["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][25]));
					dataRow7["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][26]));
					dataRow7["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][27]));
					dataRow7["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][28]));
					dataRow7["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[j][29]));
					RsIdtl.Rows.Add(dataRow7);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl2 = null;
			}
			if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.RsQry = "SELECT * FROM BAR_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow8 = RsDetl.NewRow();
				int num9 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num9)
				{
					AxMSFlexGrid mSG3 = MSG;
					if (((Operators.CompareString(mSG3[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG3[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG3[DC_Main.i, 30]) != 0.0)) | (Conversion.Val(mSG3[DC_Main.i, 10]) + Conversion.Val(mSG3[DC_Main.i, 11]) + Conversion.Val(mSG3[DC_Main.i, 24]) + Conversion.Val(mSG3[DC_Main.i, 25]) != 0.0))
					{
						dataRow8["CO_CODE"] = tToLcCode.Text;
						dataRow8["LC_CODE"] = "00";
						dataRow8["CO_YEAR"] = DC_Main.MCo_year;
						dataRow8["CO_BOOK"] = tToBook.Text;
						dataRow8["VCH_NO"] = tToVchNo.Text;
						dataRow8["VCH_DATE"] = mVchDate.Text;
						dataRow8["STK_DATE"] = mVchDate.Text;
						dataRow8["HD_VCH_NO"] = tToVchNo.Text;
						dataRow8["AC_CODE"] = FanAcCode;
						dataRow8["VCH_TYPE"] = "FNPUR";
						dataRow8["INOUT_TYPE"] = "I";
						dataRow8["ENTRY_TYPE"] = "I";
						dataRow8["BOOK_NAME"] = "FAN PURC";
						dataRow8["SR_NO"] = Conversion.Val(mSG3[DC_Main.i, 0]);
						dataRow8["OLD_SRNO"] = Conversion.Val(mSG3[DC_Main.i, 43]);
						dataRow8["IT_CODE"] = mSG3[DC_Main.i, 2];
						if (Operators.CompareString(mSG3[DC_Main.i, 1], "", false) == 0)
						{
							dataRow8["TAG_NO"] = "N";
						}
						else
						{
							dataRow8["TAG_NO"] = mSG3[DC_Main.i, 1];
						}
						dataRow8["TBL_CODE"] = mSG3[DC_Main.i, 3];
						dataRow8["DESIGN_NO"] = mSG3[DC_Main.i, 4];
						dataRow8["ITM_COLOR"] = mSG3[DC_Main.i, 5];
						dataRow8["HM_ID"] = mSG3[DC_Main.i, 7];
						dataRow8["ITM_SIZE"] = mSG3[DC_Main.i, 6];
						dataRow8["BAG_WT"] = Conversion.Val(mSG3[DC_Main.i, 9]);
						dataRow8["ITM_PCS"] = Conversion.Val(mSG3[DC_Main.i, 10]);
						dataRow8["ITM_GWT"] = Conversion.Val(mSG3[DC_Main.i, 11]);
						dataRow8["ITM_OTH_WT"] = Conversion.Val(mSG3[DC_Main.i, 12]);
						dataRow8["ITM_NWT"] = Conversion.Val(mSG3[DC_Main.i, 13]);
						dataRow8["ITM_GHT_WT"] = Conversion.Val(mSG3[DC_Main.i, 15]);
						dataRow8["ITM_TOUCH"] = Conversion.Val(mSG3[DC_Main.i, 16]);
						dataRow8["ITM_WEST_PRC"] = Conversion.Val(mSG3[DC_Main.i, 17]);
						dataRow8["ITM_FINE"] = Conversion.Val(mSG3[DC_Main.i, 18]);
						dataRow8["LBR_PRC"] = Conversion.Val(mSG3[DC_Main.i, 21]);
						dataRow8["LBR_TYPE"] = mSG3[DC_Main.i, 22];
						dataRow8["LBR_RATE"] = Conversion.Val(mSG3[DC_Main.i, 23]);
						dataRow8["LBR_AMT"] = Conversion.Val(mSG3[DC_Main.i, 24]);
						dataRow8["OTH_AMT"] = Conversion.Val(mSG3[DC_Main.i, 25]);
						dataRow8["ITM_RATE"] = Conversion.Val(mSG3[DC_Main.i, 19]);
						dataRow8["ITM_AMT"] = Conversion.Val(mSG3[DC_Main.i, 20]);
						dataRow8["MAIN_MRP"] = Conversion.Val(mSG3[DC_Main.i, 28]);
						dataRow8["ITM_MARGIN"] = Conversion.Val(mSG3[DC_Main.i, 29]);
						dataRow8["ITM_MRP"] = Conversion.Val(mSG3[DC_Main.i, 30]);
						dataRow8["KR_NET_WT"] = Conversion.Val(mSG3[DC_Main.i, 37]);
						dataRow8["KR_TOUCH"] = Conversion.Val(mSG3[DC_Main.i, 38]);
						dataRow8["KR_WEST_PRC"] = Conversion.Val(mSG3[DC_Main.i, 39]);
						dataRow8["KR_FINE"] = Conversion.Val(mSG3[DC_Main.i, 40]);
						dataRow8["KR_OTH_WT"] = Conversion.Val(mSG3[DC_Main.i, 36]);
						dataRow8["TAG_COST"] = Conversion.Val(mSG3[DC_Main.i, 26]);
						dataRow8["ITM_REMARK"] = mSG3[DC_Main.i, 63];
						dataRow8["KR_NAME"] = mSG3[DC_Main.i, 34];
						dataRow8["RATE_TYPE"] = mSG3[DC_Main.i, 44];
						dataRow8["IT_TYPE"] = mSG3[DC_Main.i, 45];
						dataRow8["TAG_TYPE"] = mSG3[DC_Main.i, 45];
						dataRow8["PR_CODE"] = mSG3[DC_Main.i, 47];
						dataRow8["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG3[DC_Main.i, 43]));
						dataRow8["HM_ID2"] = mSG3[DC_Main.i, 64];
						dataRow8["HM_ID3"] = mSG3[DC_Main.i, 65];
						dataRow8["HM_ID4"] = mSG3[DC_Main.i, 66];
						dataRow8["HM_ID_WT"] = Conversion.Val(mSG3[DC_Main.i, 67]);
						dataRow8["HM_ID2_WT"] = Conversion.Val(mSG3[DC_Main.i, 68]);
						dataRow8["HM_ID3_WT"] = Conversion.Val(mSG3[DC_Main.i, 69]);
						dataRow8["HM_ID4_WT"] = Conversion.Val(mSG3[DC_Main.i, 70]);
						dataRow8["EMP_ISU"] = mSG3[DC_Main.i, 73];
						if (Operators.CompareString(mSG3[DC_Main.i, 73], "", false) == 0)
						{
							dataRow8["EMP_ISU"] = "N";
						}
						dataRow8["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
						dataRow8["DATA_TYPE"] = "A";
						dataRow8["DATA_TRFR"] = "N";
						dataRow8["APP_TRFR"] = "N";
						dataRow8["APR_ISU"] = "N";
						dataRow8["MAIN_USER"] = MainUser;
						RsDetl.Rows.Add(dataRow8);
						((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
						RsDetl.Clear();
					}
					mSG3 = null;
					DC_Main.i++;
				}
				DC_Main.RsQry = "SELECT * FROM BAR_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.MsInsertData();
				DataRow dataRow9 = RsIdtl.NewRow();
				num = 0;
				int num10 = DtIdtl.Rows.Count - 1;
				for (int k = 0; k <= num10; k++)
				{
					DataTable dtIdtl3 = DtIdtl;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][3])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][4])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][12])) != 0.0)
					{
						int num11 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num11)
						{
							if (Conversion.Val(MSG[DC_Main.M, 43]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][16])))
							{
								num = DC_Main.M;
								break;
							}
							DC_Main.M++;
						}
						if (Operators.CompareString(MSG[num, 1], "", false) != 0)
						{
							dataRow9["CO_CODE"] = tToLcCode.Text;
							dataRow9["LC_CODE"] = "00";
							dataRow9["CO_YEAR"] = DC_Main.MCo_year;
							dataRow9["CO_BOOK"] = tToBook.Text;
							dataRow9["VCH_NO"] = tToVchNo.Text;
							dataRow9["VCH_DATE"] = mVchDate.Text;
							dataRow9["AC_CODE"] = FanAcCode;
							dataRow9["VCH_TYPE"] = "FNPUR";
							dataRow9["INOUT_TYPE"] = "I";
							dataRow9["ENTRY_TYPE"] = "I";
							dataRow9["BOOK_NAME"] = "FAN PURC";
							dataRow9["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][16]));
							dataRow9["TAG_NO"] = MSG[num, 1];
							dataRow9["VCH_SRNO"] = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(tToLcCode.Text)) + Strings.Mid(mVchDate.Text, 10, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(MSG[num, 43]));
							dataRow9["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][0]));
							dataRow9["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][1]);
							dataRow9["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][3]));
							dataRow9["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][4]));
							dataRow9["KR_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][5]));
							dataRow9["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][6]));
							dataRow9["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][7]);
							dataRow9["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][8]));
							dataRow9["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][9]));
							dataRow9["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][10]));
							dataRow9["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][11]));
							dataRow9["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][12]));
							dataRow9["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][13]));
							dataRow9["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][15]);
							dataRow9["MAIN_USER"] = MainUser;
							dataRow9["DM_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][17]);
							dataRow9["DM_NAME"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][18]);
							dataRow9["DM_COLOR"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][19]);
							dataRow9["DM_SIZE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][20]);
							dataRow9["DM_ORIGIN"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][21]);
							dataRow9["DM_REMARK"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][22]);
							dataRow9["DM_SFNO"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][23]);
							dataRow9["KR_ACT_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][24]));
							dataRow9["KR_ACT_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][25]));
							dataRow9["KR_LESS_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][26]));
							dataRow9["KR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][27]));
							dataRow9["KR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][28]));
							dataRow9["IT_PCS_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[k][29]));
							RsIdtl.Rows.Add(dataRow9);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
							RsIdtl.Clear();
						}
					}
					dtIdtl3 = null;
				}
			}
			if ((Operators.CompareString(FormMainBook, "FAN PURC", false) == 0) & (Operators.CompareString(DC_Main.MCo_code, "01", false) != 0))
			{
				Master_Import();
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
			{
				Ac_Ledr.Fan_Purc_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.Fan_Purc_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Fan_InWord_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Fan_Purc_GST(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
			{
				Ac_Ledr.Fan_Sale_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Rojmel.Fan_Sale_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Stock.Fan_OutWord_Stk(DC_Main.MCo_Book, tVchNo.Text);
				Ac_Tax.Fan_Sale_GST(DC_Main.MCo_Book, tVchNo.Text);
			}
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

	private void Master_Import()
	{
		checked
		{
			int num = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num)
			{
				DC_Main.RsQry = "SELECT IT_CODE FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + MSG[DC_Main.M, 2] + "'";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					DC_Main.RsQry = "INSERT INTO ITEM_MAST(CO_CODE,IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,  ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,MAIN_USER,SAFE_NAME)  SELECT '" + DC_Main.MCo_code + "',IT_CODE,IT_NAME,IT_TYPE,TAG_TYPE,PR_CODE,GR_CODE,TRAD_TYPE,UNIT_NAME,RATE_TYPE,HSN_CODE,  ITEM_RATE,LBR_PRC,CON_PRC,DISC_PRC,IT_TOUCH,IT_WEST,OTHER_RATE,MIN_STK,AVG_TOUCH,AVG_FINE,AVG_NWT,AC_ITEM,MAIN_USER,'MAIN'  FROM ITEM_MAST WHERE CO_CODE = '01' AND IT_CODE = '" + MSG[DC_Main.M, 2] + "'";
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					string text = "";
					string text2 = "";
					DC_Main.RsQry = "SELECT GR_CODE,PR_CODE FROM ITEM_MAST WHERE CO_CODE = '01' AND IT_CODE  = '" + MSG[DC_Main.M, 2] + "'";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["GR_CODE"], (object)""));
						DC_Main.RsQry = "SELECT PR_CODE FROM PRODUCT_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND PR_CODE = '" + text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "INSERT INTO PRODUCT_MAST(CO_CODE,PR_CODE,PR_NAME,MAIN_USER)  SELECT '" + DC_Main.MCo_code + "',PR_CODE,PR_NAME,MAIN_USER FROM PRODUCT_MAST WHERE CO_CODE = '01' AND PR_CODE = '" + text + "'";
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
						DC_Main.RsQry = "SELECT GR_CODE FROM GROUP_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '" + text2 + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "INSERT INTO GROUP_MAST(CO_CODE,GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT)  SELECT '" + DC_Main.MCo_code + "',GR_CODE,GR_NAME,GR_TYPE,TRAD_TYPE,GR_TOUCH,GR_PURC_TOUCH,MELTING_PRC,  GR_RATE,WEST_PRC,SALE_AC,PURC_AC,HSN_CODE,MAIN_USER,TAX_PRC,AVG_TOUCH,AVG_FINE,AVG_NWT FROM GROUP_MAST WHERE CO_CODE = '01' AND GR_CODE = '" + text2 + "'";
							DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						}
					}
				}
				DC_Main.M++;
			}
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Invalid comparison between Unknown and I4
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_06fa: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
		{
			Interaction.MsgBox((object)"You Cant Delete InWord Voucher......", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UsDelete, "Y", false) != 0 && Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,'',0,0,IT_TYPE,0,ITM_NWT,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE + ' TagNo' + '/' + TAG_NO FROM FAN_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
			{
				DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM FAN_DATA WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM FAN_DETL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
				DC_Main.ExeQuteDc("DELETE FROM FAN_IDTL WHERE CO_CODE = '" + tToLcCode.Text + "' AND LC_CODE = '00' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + tToBook.Text + "' AND VCH_NO = '" + tToVchNo.Text + "'");
			}
			DC_Main.ExeQuteDc("DELETE FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM FAN_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_FN_INOUT_KeyDown(object sender, KeyEventArgs e)
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
		Cr[(short)0] = "OpAmt = 0 ";
		Cr[(short)1] = "ClAmt = 0 ";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\FranchiseBill.RPT";
		Cr.SelectionFormula = "{FAN_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {FAN_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {FAN_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {FAN_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {FAN_DATA.VCH_NO} = '" + CurPrnVch + "'";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "PRINT", false) == 0)
		{
			if (DC_Main.MsPrintOg)
			{
				Cr[(short)6] = "InVoiceType = 'ORIGINAL FOR RECIPIENT'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintDup)
			{
				Cr[(short)6] = "InVoiceType = 'DUPLICATE FOR SUPPLIER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
			if (DC_Main.MsPrintTrip)
			{
				Cr[(short)6] = "InVoiceType = 'TRIPLICATE FOR TRANSPORTER'";
				Cr.Destination = (DestinationConstants)1;
				Cr.Action = -1;
			}
		}
		else
		{
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom((short)110);
		}
		DC_Main.MsPrintStatus = false;
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		if (BillSavePanding)
		{
			Interaction.MsgBox((object)"Please Save Voucher First Then Cancel... Because Row Wise Entry Is Save But Voucher Is Not Save ....", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			CLEAR_DATA();
		}
	}

	private void TR_FN_INOUT_Activated(object sender, EventArgs e)
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
		if (Operators.CompareString(FormMainBook, "FAN SALE", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.TO_FAN_CODE As CodeL,B.CO_NAME As LocationL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.TOT_GWT As GwtW,A.STK_TRFR As StkRecM FROM FAN_DATA AS A LEFT JOIN CO_MAST AS B ON A.TO_FAN_CODE = B.CO_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		}
		if (Operators.CompareString(FormMainBook, "FAN PURC", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,A.FROM_FAN_CODE As CodeL,B.CO_NAME As LocationL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,A.TOT_GWT As GwtW,A.STK_TRFR As StkRecM FROM FAN_DATA AS A LEFT JOIN CO_MAST AS B ON A.FROM_FAN_CODE = B.CO_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		//IL_08e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ee: Expected O, but got Unknown
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		lblItem.Text = MSG[MSG.Row, 48] + " : It Name";
		MSG_IDTL_CLEAR();
		int num = 1;
		checked
		{
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				if (Conversion.Val(MSG[MSG.Row, 43]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16])))
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
			ItmStk(MSG.Row);
			PicImage.Image = null;
			DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 72];
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
					string address = DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg";
					PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 72]))) ?? "";
					DataTable dataTable = DC_Main.OpenRecordSetImg(DC_Main.RsQry);
					if (dataTable.Rows.Count > 0)
					{
						object obj = Operators.ConcatenateObject(dataTable.Rows[0]["MOB_IMAGE"], (object)"");
						byte[] bA = Ac_Image.ConvertBase64ToByteArray(Conversions.ToString(obj));
						object objectValue = RuntimeHelpers.GetObjectValue(Ac_Image.convertbytetoimage(bA));
						PicImage.Image = (Image)objectValue;
					}
					ProjectData.ClearProjectError();
				}
			}
			MSG_IDTL[num, 0] = Conversions.ToString(num);
			MSG_IDTL[num, 16] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 43]));
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
				DC_Main.RsQry = "SELECT VCH_NO FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM FAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_FN_INOUT_Closed(object sender, EventArgs e)
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

	private void TToLcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tToLcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From CO_MAST WHERE  CO_CODE = '" + tToLcCode.Text + "' AND CO_CODE <> '" + DC_Main.MCo_code + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count <= 0)
		{
			DC_Main.RsQry = "Select CO_CODE As CodeL,CO_NAME As NameL,CO_ADD1 As AddressL,CO_CITY As CityL FROM CO_MAST WHERE CO_CODE <> '" + DC_Main.MCo_code + "' ORDER BY CO_CODE";
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
			tToLcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_NAME"], (object)""));
			DC_Main.RsQry = "SELECT A.* FROM FAN_AC_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.FAN_CO_CODE =  '" + tToLcCode.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				FanAcCode = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["FAN_AC_CODE"], (object)""));
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM FAN_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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

	private void TR_FN_INOUT_KeyUp(object sender, KeyEventArgs e)
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
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(EntryMode, "A", false) != 0)
		{
			return;
		}
		((Control)TEXT_ENTRY).Visible = false;
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.BOOK_NAME As BookL,A.STK_IT_CODE As StkItCodeL,A.VCH_DESC As RemarkL,A.MAIN_USER As UserL,A.CO_BOOK As CoBookL,SUM(C.ITM_GWT) As GrwtW FROM (BAR_DATA AS A LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.MAIN_BOOK IN ('OPSTK','TAG GEN','PURCHASE','KARIGAR RECEIPT')  GROUP BY A.VCH_NO,A.VCH_DATE,B.BOOK_NAME,A.STK_IT_CODE,A.VCH_DESC,A.MAIN_USER,A.CO_BOOK ORDER BY A.VCH_DATE,A.CO_BOOK,A.VCH_NO ";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 175.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 250.0;
		DC_Main.ColWidth[5] = 125.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 110.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && !DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
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

	private void tTagVch_TextChanged(object sender, EventArgs e)
	{
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
				mSG2[DC_Main.i + 1, 43] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["OLD_SRNO"]);
				mSG2[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 48] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)""));
				mSG2[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_NO"], (object)""));
				mSG2[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TBL_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
				mSG2[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_COLOR"], (object)""));
				mSG2[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
				mSG2[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID"], (object)""));
				mSG2[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["BAG_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 10] = Conversions.ToString(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_PCS"]);
				mSG2[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
				mSG2[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
				mSG2[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
				mSG2[DC_Main.i + 1, 53] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
				mSG2[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_OTH_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NET_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 59] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 40] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["KR_FINE"])), "0.000");
				mSG2[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 54] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 55] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 56] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
				mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 57] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
				mSG2[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_PRC"])), "0.00");
				mSG2[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
				mSG2[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
				mSG2[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
				mSG2[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_COST"])), "0.00");
				mSG2[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
				mSG2[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MARGIN"])), "0.00");
				mSG2[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
				mSG2[DC_Main.i + 1, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
				mSG2[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["KR_NAME"], (object)""));
				mSG2[DC_Main.i + 1, 42] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_SRNO"])), "0");
				mSG2[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 45] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 46] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 47] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 72] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["VCH_SRNO"])), "0");
				mSG2[DC_Main.i + 1, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["TAG_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["PR_CODE"], (object)""));
				mSG2[DC_Main.i + 1, 49] = "E";
				mSG2[DC_Main.i + 1, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2"], (object)""));
				mSG2[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3"], (object)""));
				mSG2[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4"], (object)""));
				mSG2[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["LOT_TYPE"], (object)""));
				mSG2[DC_Main.i + 1, 67] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID2_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID3_WT"])), "0.000");
				mSG2[DC_Main.i + 1, 70] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["HM_ID4_WT"])), "0.000");
				DC_Main.RsQry = "SELECT * FROM TAG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '" + mSG2[DC_Main.i + 1, 1] + "' AND TAG_NO <> ''";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					mSG2[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ITM_TOUCH"])), "0.00");
					mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["F_WEST"])), "0.00");
					mSG2[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["F_LRATE"])), "0.00");
				}
				else
				{
					DC_Main.RsQry = "SELECT * FROM TAG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TAG_NO = '' AND IT_CODE = '" + mSG2[DC_Main.i + 1, 2] + "' ";
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						mSG2[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ITM_TOUCH"])), "0.00");
						mSG2[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["F_WEST"])), "0.00");
						mSG2[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["F_LRATE"])), "0.00");
					}
				}
				if ((Conversion.Val(mSG2[DC_Main.i + 1, 16]) + Conversion.Val(mSG2[DC_Main.i + 1, 17]) != 0.0) & (Conversion.Val(mSG2[DC_Main.i + 1, 13]) != 0.0))
				{
					mSG2[DC_Main.i + 1, 18] = Strings.Format((object)((Conversion.Val(mSG2[DC_Main.i + 1, 13]) + Conversion.Val(mSG2[DC_Main.i + 1, 15])) * (Conversion.Val(mSG2[DC_Main.i + 1, 16]) + Conversion.Val(mSG2[DC_Main.i + 1, 17])) / 100.0), "0.000");
				}
				if ((Conversion.Val(mSG2[DC_Main.i + 1, 23]) != 0.0) & (Conversion.Val(mSG2[DC_Main.i + 1, 11]) != 0.0))
				{
					mSG2[DC_Main.i + 1, 24] = Strings.Format((object)(Conversion.Val(mSG2[DC_Main.i + 1, 11]) * Conversion.Val(mSG2[DC_Main.i + 1, 23])), "0.00");
				}
				mSG2[DC_Main.i + 1, 31] = Strings.Format((object)(Conversion.Val(mSG2[DC_Main.i + 1, 20]) + Conversion.Val(mSG2[DC_Main.i + 1, 24]) + Conversion.Val(mSG2[DC_Main.i + 1, 25])), "0.00");
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
			MSG_TOT_FILL();
			BILL_TOTAL();
			if (Operators.CompareString(tToLcCode.Text, "", false) == 0)
			{
				((Control)tToLcCode).Focus();
			}
			else if (MSG.Row >= 0)
			{
				MSG.Col = 1;
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
			}
			MsgOldRow = 0;
			MSG_RowColChange(MSG, new EventArgs());
		}
	}

	private void tFrmLc_TextChanged(object sender, EventArgs e)
	{
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
						((Control)TEXT_ENTRY_2).Visible = false;
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
		mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 31]), DC_Main.MsTotAmtRof), "0.00");
		if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
		{
			mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 24]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
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
		mSG2_TOTAL[10, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3]) - Conversion.Val(mSG2_TOTAL[9, 3])), "0.00");
		mSG2_TOTAL = null;
	}

	private void ItmStk(int Row)
	{
		if (Operators.CompareString(MSG[Row, 1], "", false) == 0)
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "' AND TAG_NO = 'N'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
		else if (Operators.CompareString(MSG[Row, 71], "L", false) == 0)
		{
			if (Operators.CompareString(MSG[Row, 3], "", false) != 0)
			{
				DC_Main.RsQry = "Select A.TAG_NO,A.TBL_CODE,A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TAG_NO = '" + MSG[Row, 1] + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND A.TAG_NO <> 'N' AND A.LOT_TYPE = 'L' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.TAG_NO,A.TBL_CODE,A.IT_CODE ";
			}
			else
			{
				DC_Main.RsQry = "Select A.TAG_NO,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'  AND A.TAG_NO = '" + MSG[Row, 1] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.TAG_NO ";
			}
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
		else
		{
			DC_Main.RsQry = "Select A.IT_CODE,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) AS StkPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) AS StkGwt, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS StkNwt FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '" + MSG[Row, 2] + "' AND VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "'  GROUP BY A.IT_CODE ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				lblItStock.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"P= ", dataTable.Rows[0]["StkPcs"]), (object)"  G= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkGwt"])), "0.00")), (object)"  N= "), (object)Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["StkNwt"])), "0.00")));
			}
			else
			{
				lblItStock.Text = "Itm Stk :";
			}
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void FlowLayoutPanel1_DoubleClick(object sender, EventArgs e)
	{
		((Control)btnRateRemove).Visible = true;
	}

	private void BtnRateRemove_Click(object sender, EventArgs e)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		if ((int)Interaction.MsgBox((object)"Are You Sure To Delete Item Rate For This book ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "UPDATE FAN_DETL SET ITM_RATE = 0,ITM_AMT = 0,NET_AMT = LBR_AMT+OTH_AMT WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "SELECT VCH_NO,SUM(LBR_AMT) As LbrAmt,SUM(OTH_AMT) As OthAmt FROM FAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY VCH_NO ORDER BY VCH_NO ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			checked
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					double num2 = Conversions.ToDouble(Strings.Format((object)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["LbrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["OthAmt"])), 0), "00"));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE FAN_DATA SET FAN_DATA.NET_AMT = " + Conversions.ToString(num2) + ",FAN_DATA.TOT_AMT = " + Conversions.ToString(num2) + ",FAN_DATA.BILL_OS = " + Conversions.ToString(num2) + "  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["VCH_NO"]), (object)"' "));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					DC_Main.M++;
				}
			}
		}
		Interaction.MsgBox((object)"Process Is Ok...Please Data Refresh..then check...", (MsgBoxStyle)0, (object)null);
	}
}
