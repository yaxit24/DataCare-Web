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
public class TR_MFG_ITEM : Form
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
	[AccessedThroughProperty("btnTagPrint")]
	private SimpleButton _btnTagPrint;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private double TotDrFine;

	private string WaxProcess;

	private double AcFineGl;

	private double AcFineSl;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string MsPorcessType;

	private string LastPorcess;

	private string CurProcess;

	private string NextProcess;

	private string StkLess;

	private string StkAdd;

	private string TranCode;

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

	private double VpAdjAmt;

	private string MaxVchNo;

	private string LastVchNo;

	private bool RowChang;

	private const int cSrNo = 0;

	private const int cItCode = 1;

	private const int cItName = 2;

	private const int cNewItmTag = 3;

	private const int cDesign = 4;

	private const int cSize = 5;

	private const int cCastingWt = 6;

	private const int cWaxWt = 7;

	private const int cAddWt = 8;

	private const int cRtnWt = 9;

	private const int cPcs = 10;

	private const int cGrWt = 11;

	private const int cOthWt = 12;

	private const int cNetWt = 13;

	private const int cTouch = 14;

	private const int cWestPrc = 15;

	private const int cFine = 16;

	private const int cMtrlIt = 17;

	private const int cMtrlWt = 18;

	private const int cGhtPrc = 19;

	private const int cGhtWt = 20;

	private const int cRtnChol = 21;

	private const int cGhis = 22;

	private const int cLbrType = 23;

	private const int cLbrRate = 24;

	private const int cLbrAmt = 25;

	private const int cOthAmt = 26;

	private const int cNetAmt = 27;

	private const int cCustOrdNo = 28;

	private const int cTagLotNo = 29;

	private const int cItmLot = 30;

	private const int cIsuGwt = 31;

	private const int cDiffWt = 32;

	private const int cOrdItCode = 33;

	private const int cOrdPcs = 34;

	private const int cOrdGwt = 35;

	private const int cOrdOthWt = 36;

	private const int cOrdNwt = 37;

	private const int cDifP = 38;

	private const int cImageTake = 39;

	private const int cLotGen = 40;

	private const int cKrName = 41;

	private const int cOldSrNo = 42;

	private const int cItRate = 43;

	private const int cItAmt = 44;

	private const int cLbrPrc = 45;

	private const int cEntryMod = 46;

	private const int cOldGrWt = 47;

	private const int cOldNtWt = 48;

	private const int cOldTouch = 49;

	private const int cOldWestPrc = 50;

	private const int cItRemark = 51;

	private const int cDesignSrNo = 52;

	private const int cProType = 53;

	private const int cProInout = 54;

	private const int cIsuRecNo = 55;

	private const int cIsuRecYrcd = 56;

	private const int cIsuRecDbCd = 57;

	private const int cIsuRecSrNo = 58;

	private const int cIsuRecOldSrNo = 59;

	private const int cDmPcs = 60;

	private const int cDmWt = 61;

	private const int cPrCode = 62;

	private const int cItType = 63;

	private const int cOldPrCode = 64;

	private const int cOrdNo = 65;

	private const int cOrdYrCd = 66;

	private const int cOrdDbCd = 67;

	private const int cOrdSrNo = 68;

	private const int cOrdOldSrNo = 69;

	private const int cOrdAcCode = 70;

	private const int cOrdAcName = 71;

	private const int cRecNo = 72;

	private const int cRecYrCd = 73;

	private const int cRecDbCd = 74;

	private const int cRecSrNo = 75;

	private const int c1SrNo = 0;

	private const int c1ItmLot = 1;

	private const int c1ItCode = 2;

	private const int c1ItName = 3;

	private const int c1IsuPcs = 4;

	private const int c1IsuGrWt = 5;

	private const int c1Pcs = 6;

	private const int c1GrWt = 7;

	private const int c1ConPrc = 8;

	private const int c1RtnPcs = 9;

	private const int c1RtnGrWt = 10;

	private const int c1BrokPcs = 11;

	private const int c1BrokGrWt = 12;

	private const int c1RateType = 13;

	private const int c1ItRate = 14;

	private const int c1ItmAmt = 15;

	private const int c1LbrRate = 16;

	private const int c1LbrAmt = 17;

	private const int c1NetAmt = 18;

	private const int c1OldisuItm = 19;

	private const int c1ConWt = 20;

	private const int c1ItType = 21;

	private const int c1RowSr = 22;

	private const int cNetAmt2 = 0;

	private const int cTax2 = 1;

	private const int cTot2 = 2;

	private const int cCash2 = 3;

	private const int cChq2 = 4;

	private const int cKasarAmt2 = 5;

	private const int cOs2 = 6;

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

	internal virtual SimpleButton btnTagPrint
	{
		[CompilerGenerated]
		get
		{
			return _btnTagPrint;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTagPrint_Click;
			SimpleButton val = _btnTagPrint;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTagPrint = value;
			val = _btnTagPrint;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
	[AccessedThroughProperty("nLableSkip")]
	private virtual TextBox _nLableSkip;

	internal virtual TextBox nLableSkip
	{
		get
		{
			return _nLableSkip;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nLableSkip = value;
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

	public TR_MFG_ITEM()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_MFG_ITEM_Load;
		((Form)this).Deactivate += TR_MFG_ITEM_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_MFG_ITEM_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_MFG_ITEM_KeyDown);
		((Form)this).Activated += TR_MFG_ITEM_Activated;
		((Form)this).Closed += TR_MFG_ITEM_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_MFG_ITEM_KeyUp);
		MsPorcessType = "";
		LastPorcess = "";
		CurProcess = "";
		NextProcess = "";
		StkLess = "";
		StkAdd = "";
		TranCode = "";
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
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		//IL_0436: Unknown result type (might be due to invalid IL or missing references)
		//IL_0440: Expected O, but got Unknown
		//IL_04c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected O, but got Unknown
		//IL_056a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0574: Expected O, but got Unknown
		//IL_0622: Unknown result type (might be due to invalid IL or missing references)
		//IL_062c: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		//IL_0758: Unknown result type (might be due to invalid IL or missing references)
		//IL_0762: Expected O, but got Unknown
		//IL_07f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_085e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0868: Expected O, but got Unknown
		//IL_0911: Unknown result type (might be due to invalid IL or missing references)
		//IL_091b: Expected O, but got Unknown
		//IL_097e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Expected O, but got Unknown
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3b: Expected O, but got Unknown
		//IL_0b58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b62: Expected O, but got Unknown
		//IL_0c6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c77: Expected O, but got Unknown
		//IL_0cda: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce4: Expected O, but got Unknown
		//IL_0e8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef1: Expected O, but got Unknown
		//IL_0f54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f5e: Expected O, but got Unknown
		//IL_1063: Unknown result type (might be due to invalid IL or missing references)
		//IL_106d: Expected O, but got Unknown
		//IL_1165: Unknown result type (might be due to invalid IL or missing references)
		//IL_116f: Expected O, but got Unknown
		//IL_1280: Unknown result type (might be due to invalid IL or missing references)
		//IL_128a: Expected O, but got Unknown
		//IL_1307: Unknown result type (might be due to invalid IL or missing references)
		//IL_1311: Expected O, but got Unknown
		//IL_13d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_13df: Expected O, but got Unknown
		//IL_1486: Unknown result type (might be due to invalid IL or missing references)
		//IL_1490: Expected O, but got Unknown
		//IL_158e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1598: Expected O, but got Unknown
		//IL_15f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1603: Expected O, but got Unknown
		//IL_170f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1719: Expected O, but got Unknown
		//IL_17f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fb: Expected O, but got Unknown
		//IL_1897: Unknown result type (might be due to invalid IL or missing references)
		//IL_18a1: Expected O, but got Unknown
		//IL_19dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e6: Expected O, but got Unknown
		//IL_1a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a3b: Expected O, but got Unknown
		//IL_1ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1abf: Expected O, but got Unknown
		//IL_1b44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4e: Expected O, but got Unknown
		//IL_1c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1f: Expected O, but got Unknown
		//IL_1cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd0: Expected O, but got Unknown
		//IL_1d4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d57: Expected O, but got Unknown
		//IL_1ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de9: Expected O, but got Unknown
		//IL_1e9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea4: Expected O, but got Unknown
		//IL_1f55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5f: Expected O, but got Unknown
		//IL_1ffb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2005: Expected O, but got Unknown
		//IL_2086: Unknown result type (might be due to invalid IL or missing references)
		//IL_2090: Expected O, but got Unknown
		//IL_215a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2164: Expected O, but got Unknown
		//IL_21bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c9: Expected O, but got Unknown
		//IL_2246: Unknown result type (might be due to invalid IL or missing references)
		//IL_2250: Expected O, but got Unknown
		//IL_2301: Unknown result type (might be due to invalid IL or missing references)
		//IL_230b: Expected O, but got Unknown
		//IL_238c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2396: Expected O, but got Unknown
		//IL_244a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2454: Expected O, but got Unknown
		//IL_250b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2515: Expected O, but got Unknown
		//IL_25d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_25e0: Expected O, but got Unknown
		//IL_2694: Unknown result type (might be due to invalid IL or missing references)
		//IL_269e: Expected O, but got Unknown
		//IL_275f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2769: Expected O, but got Unknown
		//IL_2824: Unknown result type (might be due to invalid IL or missing references)
		//IL_282e: Expected O, but got Unknown
		//IL_28e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ec: Expected O, but got Unknown
		//IL_29a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_29aa: Expected O, but got Unknown
		//IL_2a5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a64: Expected O, but got Unknown
		//IL_2b18: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b22: Expected O, but got Unknown
		//IL_2ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bb1: Expected O, but got Unknown
		//IL_2c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c63: Expected O, but got Unknown
		//IL_2d0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d16: Expected O, but got Unknown
		//IL_2dab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2db5: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_MFG_ITEM));
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
		btnTagPrint = new SimpleButton();
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
		MSG2_TOTAL = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		Label8 = new Label();
		tBillNo = new TextBox();
		LOpAmt = new Label();
		LClAmt = new Label();
		LOpSilver = new Label();
		LOpGold = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		Label6 = new Label();
		nLableSkip = new TextBox();
		nPcs = new TextBox();
		nItNwt = new TextBox();
		nitGwt = new TextBox();
		Label15 = new Label();
		((Control)PnlBotam).SuspendLayout();
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
		lblBook.Text = "Mfg Item Wise Isu Rec";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(306, 39);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(232, 40);
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
		((Control)mDay).Location = new Point(475, 39);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(386, 39);
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnTagPrint);
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
		((BaseStyleControl)btnTagPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnTagPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnTagPrint.ImageOptions.SvgImage");
		((Control)btnTagPrint).Location = new Point(730, 3);
		((BaseControl)btnTagPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagPrint).Name = "btnTagPrint";
		((Control)btnTagPrint).Size = new Size(91, 37);
		((Control)btnTagPrint).TabIndex = 28;
		btnTagPrint.Text = "&Tg Prn";
		((BaseButton)btnTagPrint).ToolTipAnchor = (ToolTipAnchor)1;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(251, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(473, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(204, 3);
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
		((Control)BtnFirst).Location = new Point(157, 3);
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
		((Control)TEXT_ENTRY).Location = new Point(583, 175);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 4;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)lblItem).Font = new Font("Franklin Gothic Book", 9.75f);
		((Control)lblItem).ForeColor = Color.Black;
		lblItem.ImeMode = (ImeMode)0;
		((Control)lblItem).Location = new Point(912, 285);
		((Control)lblItem).Name = "lblItem";
		((Control)lblItem).Size = new Size(254, 20);
		((Control)lblItem).TabIndex = 1139;
		lblItem.Text = "Item Name";
		lblItem.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TEXT_IDTL).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_IDTL).BorderStyle = (BorderStyle)0;
		((Control)TEXT_IDTL).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_IDTL).ForeColor = Color.White;
		((Control)TEXT_IDTL).Location = new Point(369, 362);
		((Control)TEXT_IDTL).Name = "TEXT_IDTL";
		((Control)TEXT_IDTL).Size = new Size(100, 18);
		((Control)TEXT_IDTL).TabIndex = 6;
		((Control)TEXT_IDTL).Visible = false;
		((Control)MSG_IDTL).Location = new Point(12, 316);
		((Control)MSG_IDTL).Name = "MSG_IDTL";
		((AxHost)MSG_IDTL).OcxState = (State)componentResourceManager.GetObject("MSG_IDTL.OcxState");
		((Control)MSG_IDTL).Size = new Size(1157, 110);
		((Control)MSG_IDTL).TabIndex = 1140;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(374, 437);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(142, 119);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((Control)MSG_TOT).Location = new Point(14, 266);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1155, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(12, 104);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1158, 159);
		((Control)MSG).TabIndex = 1135;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1227, 448);
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
		((Control)Cr).Location = new Point(1183, 477);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(105, 70);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 70);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(371, 23);
		((Control)tAcName).TabIndex = 1158;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(21, 70);
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
		((Control)tEmpCode).Location = new Point(90, 436);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 8;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(152, 435);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(16, 435);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(17, 492);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(89, 494);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(279, 62);
		((Control)tVchDesc).TabIndex = 9;
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(80, 284);
		((TextBoxBase)tItRemark).MaxLength = 100;
		((Control)tItRemark).Name = "tItRemark";
		((Control)tItRemark).Size = new Size(726, 23);
		((Control)tItRemark).TabIndex = 5;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 285);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(60, 20);
		((Control)Label5).TabIndex = 1166;
		Label5.Text = "Remark ";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)MSG2_TOTAL).Location = new Point(728, 455);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 103);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(967, 485);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 7;
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(16, 463);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(58, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(89, 464);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(131, 23);
		((Control)tBillNo).TabIndex = 8;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1035, 39);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(134, 20);
		((Control)LOpAmt).TabIndex = 1207;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(578, 452);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(144, 20);
		((Control)LClAmt).TabIndex = 1210;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(1220, 130);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(77, 20);
		((Control)LOpSilver).TabIndex = 1223;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpSilver).Visible = false;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(1035, 71);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(134, 20);
		((Control)LOpGold).TabIndex = 1222;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(1215, 527);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(60, 20);
		((Control)LClSilver).TabIndex = 1225;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).Visible = false;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(580, 485);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(142, 20);
		((Control)lClGold).TabIndex = 1224;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(522, 527);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 1228;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(522, 482);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 1227;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(522, 438);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 1226;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(594, 534);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(80, 20);
		((Control)Label6).TabIndex = 1230;
		Label6.Text = "Lable Skip";
		Label6.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nLableSkip).BackColor = Color.White;
		((Control)nLableSkip).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLableSkip).Location = new Point(683, 534);
		((TextBoxBase)nLableSkip).MaxLength = 15;
		((Control)nLableSkip).Name = "nLableSkip";
		((Control)nLableSkip).Size = new Size(39, 22);
		((Control)nLableSkip).TabIndex = 1229;
		((TextBoxBase)nPcs).BackColor = Color.White;
		((Control)nPcs).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nPcs).Location = new Point(648, 70);
		((TextBoxBase)nPcs).MaxLength = 8;
		((Control)nPcs).Name = "nPcs";
		((TextBoxBase)nPcs).ReadOnly = true;
		((Control)nPcs).Size = new Size(47, 23);
		((Control)nPcs).TabIndex = 1234;
		nPcs.TextAlign = (HorizontalAlignment)1;
		((Control)nPcs).Visible = false;
		((TextBoxBase)nItNwt).BackColor = Color.White;
		((Control)nItNwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nItNwt).Location = new Point(781, 70);
		((TextBoxBase)nItNwt).MaxLength = 10;
		((Control)nItNwt).Name = "nItNwt";
		((TextBoxBase)nItNwt).ReadOnly = true;
		((Control)nItNwt).Size = new Size(74, 23);
		((Control)nItNwt).TabIndex = 1233;
		nItNwt.TextAlign = (HorizontalAlignment)1;
		((Control)nItNwt).Visible = false;
		((TextBoxBase)nitGwt).BackColor = Color.White;
		((Control)nitGwt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nitGwt).Location = new Point(700, 70);
		((TextBoxBase)nitGwt).MaxLength = 10;
		((Control)nitGwt).Name = "nitGwt";
		((TextBoxBase)nitGwt).ReadOnly = true;
		((Control)nitGwt).Size = new Size(76, 23);
		((Control)nitGwt).TabIndex = 1232;
		nitGwt.TextAlign = (HorizontalAlignment)1;
		((Control)nitGwt).Visible = false;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(576, 72);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(66, 20);
		((Control)Label15).TabIndex = 1231;
		Label15.Text = "Item Wt";
		Label15.TextAlign = (ContentAlignment)64;
		((Control)Label15).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nPcs);
		((Control)this).Controls.Add((Control)(object)nItNwt);
		((Control)this).Controls.Add((Control)(object)nitGwt);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nLableSkip);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
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
		((Control)this).Name = "TR_MFG_ITEM";
		((Form)this).Text = "Mfg Itm Isu Rec";
		((Control)PnlBotam).ResumeLayout(false);
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

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 76;
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
			mSG[1] = (int)Math.Round(1000.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "ItCode";
			mSG[2] = (int)Math.Round(2500.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItName";
			mSG[3] = 0;
			mSG[4] = (int)Math.Round(1300.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			mSG[5] = 0;
			mSG[6] = 0;
			mSG[7] = 0;
			mSG[8] = 0;
			mSG[9] = 0;
			mSG[19] = 0;
			mSG[20] = 0;
			mSG[21] = 0;
			mSG[22] = 0;
			mSG[17] = 0;
			mSG[18] = 0;
			mSG[38] = 0;
			mSG[23] = 0;
			mSG[24] = 0;
			mSG[25] = 0;
			mSG[26] = 0;
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[33] = 0;
			mSG[34] = 0;
			mSG[35] = 0;
			mSG[36] = 0;
			mSG[37] = 0;
			mSG[55] = 0;
			mSG[56] = 0;
			mSG[57] = 0;
			mSG[58] = 0;
			mSG[59] = 0;
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
			mSG[10] = (int)Math.Round(800.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "Pcs";
			mSG[11] = (int)Math.Round(1100.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "GrWt";
			mSG[12] = (int)Math.Round(1050.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "OthWt";
			mSG[13] = (int)Math.Round(1100.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "NetWt";
			mSG[14] = (int)Math.Round(1100.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "Touch";
			mSG[15] = (int)Math.Round(1100.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "West%";
			mSG[16] = (int)Math.Round(1100.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "Fine";
			if (Operators.CompareString(FormBookInOut, "O", false) != 0)
			{
				mSG[3] = (int)Math.Round(1200.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "TagLot";
				mSG[19] = (int)Math.Round(900.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "Ght%";
				mSG[20] = (int)Math.Round(1000.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "GhtWt";
				mSG[24] = (int)Math.Round(1100.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "LbrRate";
				mSG[25] = (int)Math.Round(1200.0 * ColCon);
				mSG[25] = 7;
				mSG[0, 25] = "LbrAmt";
			}
			mSG[27] = (int)Math.Round(1200.0 * ColCon);
			mSG[27] = 7;
			mSG[0, 27] = "NetAmt";
			mSG[39] = 0;
			mSG[28] = 0;
			mSG[29] = 0;
			mSG[30] = 0;
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
			mSG[60] = 0;
			mSG[61] = 0;
			mSG[62] = 0;
			mSG[64] = 0;
			mSG[63] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'MFG ITM ISUREC' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
			MsgLastCol = 27;
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
		mSG_IDTL.Cols = 23;
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
			mSG_IDTL[1] = 0;
			mSG_IDTL[1] = 0;
			mSG_IDTL[0, 1] = "ItmLot";
			mSG_IDTL[2] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[2] = 0;
			mSG_IDTL[0, 2] = "ItCode";
			mSG_IDTL[3] = (int)Math.Round(2200.0 * ColCon);
			mSG_IDTL[3] = 0;
			mSG_IDTL[0, 3] = "ItName";
			if ((Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0))
			{
				mSG_IDTL[4] = 750;
				mSG_IDTL[4] = 7;
				mSG_IDTL[0, 4] = "IsuPcs";
				mSG_IDTL[5] = 1000;
				mSG_IDTL[5] = 7;
				mSG_IDTL[0, 5] = "IsuWt";
			}
			else if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
			{
				mSG_IDTL[4] = 750;
				mSG_IDTL[4] = 7;
				mSG_IDTL[0, 4] = "OrdPcs";
				mSG_IDTL[5] = 1000;
				mSG_IDTL[5] = 7;
				mSG_IDTL[0, 5] = "OrdWt";
			}
			else
			{
				mSG_IDTL[4] = 0;
				mSG_IDTL[5] = 0;
			}
			mSG_IDTL[6] = (int)Math.Round(750.0 * ColCon);
			mSG_IDTL[6] = 7;
			mSG_IDTL[0, 6] = "Pcs";
			mSG_IDTL[7] = (int)Math.Round(1000.0 * ColCon);
			mSG_IDTL[7] = 7;
			mSG_IDTL[0, 7] = "Weight";
			mSG_IDTL[8] = (int)Math.Round(850.0 * ColCon);
			mSG_IDTL[8] = 7;
			mSG_IDTL[0, 8] = "Con%";
			if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
			{
				mSG_IDTL[9] = (int)Math.Round(750.0 * ColCon);
				mSG_IDTL[9] = 7;
				mSG_IDTL[0, 9] = "RtnPcs";
				mSG_IDTL[10] = (int)Math.Round(1000.0 * ColCon);
				mSG_IDTL[10] = 7;
				mSG_IDTL[0, 10] = "RtnWt";
				mSG_IDTL[11] = 0;
				mSG_IDTL[11] = 7;
				mSG_IDTL[0, 11] = "BrkPcs";
				mSG_IDTL[12] = 0;
				mSG_IDTL[12] = 7;
				mSG_IDTL[0, 12] = "BrkWt";
			}
			else
			{
				mSG_IDTL[9] = 0;
				mSG_IDTL[10] = 0;
				mSG_IDTL[11] = 0;
				mSG_IDTL[12] = 0;
				if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) != 0)
				{
					((Control)MSG_IDTL).Width = (int)Math.Round(900.0 * ColCon);
				}
			}
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
			mSG_IDTL[20] = 0;
			mSG_IDTL[0, 20] = "ConWt";
			mSG_IDTL[19] = (int)Math.Round(900.0 * ColCon);
			mSG_IDTL[19] = 3;
			mSG_IDTL[0, 19] = "OldItm";
			mSG_IDTL[21] = 0;
			mSG_IDTL[0, 21] = "ItType";
			mSG_IDTL[22] = 0;
			mSG_IDTL[0, 22] = "RowSrNo";
			mSG_IDTL.Row = 1;
			mSG_IDTL.Col = 0;
			((Control)TEXT_IDTL).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClIdtl);
			int num = 0;
			if (dataView.Count > 0)
			{
				int num2 = mSG_IDTL.Cols - 1;
				for (num = 1; num <= num2; num++)
				{
					dataView.RowFilter = "BOOK_NAME = 'TAG_IDTL' AND COL_NAME = '" + mSG_IDTL[0, num] + "'";
					if (dataView.Count > 0)
					{
						if (Operators.ConditionalCompareObjectEqual(dataView[0]["YES_NO"], (object)"N", false))
						{
							mSG_IDTL[num] = 0;
						}
						mSG_IDTL[0, num] = Conversions.ToString(dataView[0]["COL_NEW_NAME"]);
					}
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
		mSG_IDTL[mSG_IDTL.Row, 22] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 42]));
		if (Operators.CompareString(mSG_IDTL[mSG_IDTL.Row, 2], "", false) == 0)
		{
			mSG_IDTL[mSG_IDTL.Row, 19] = "N";
		}
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
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_084d: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 22])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[mSG_IDTL.Row, 0])))
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
					{
						if (!((Operators.CompareString(TEXT_IDTL.Text, "", false) != 0) & (Operators.CompareString(TEXT_IDTL.Text, mSG_IDTL[mSG_IDTL.Row, 1], false) != 0)))
						{
							break;
						}
						string text = "";
						int num3 = MSG.Rows - 1;
						DC_Main.M = 1;
						while (DC_Main.M <= num3)
						{
							text = text + "'" + MSG[DC_Main.M, 30] + "',";
							DC_Main.M++;
						}
						text = Strings.Mid(text, 1, Strings.Len(text) - 1);
						DC_Main.RsQry = "SELECT A.ITM_LOT,A.IT_CODE,B.IT_NAME,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As ItmPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '" + TEXT_IDTL.Text + "' AND ITM_LOT <> '' AND ITM_LOT NOT IN (" + text + ") AND TAG_NO = 'N'  GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) > 0";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.ITM_LOT As ItmLotL,A.IT_CODE as ItCodeL,B.IT_NAME As ItemNameL,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As ItmPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWtW  FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT <> '' AND ITM_LOT NOT IN (" + text + ") AND TAG_NO = 'N' GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME ORDER BY A.ITM_LOT,B.IT_NAME";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[6];
							DC_Main.ColWidth[0] = 120.0;
							DC_Main.ColWidth[1] = 120.0;
							DC_Main.ColWidth[2] = 300.0;
							DC_Main.ColWidth[3] = 100.0;
							DC_Main.ColWidth[4] = 125.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (DC_Main.HelpClose)
							{
								return;
							}
							if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
							{
								TEXT_IDTL.Text = DC_Main.ColValue[0];
								mSG_IDTL[mSG_IDTL.Row, 1] = DC_Main.ColValue[0];
								mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[2];
								mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[1];
								if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
								{
									mSG_IDTL[mSG_IDTL.Row, 6] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0");
								}
								mSG_IDTL[mSG_IDTL.Row, 7] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[4]), "0.000");
								mSG_IDTL[mSG_IDTL.Row, 19] = "N";
							}
						}
						else
						{
							mSG_IDTL[mSG_IDTL.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_LOT"], (object)""));
							mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG_IDTL[mSG_IDTL.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG_IDTL[mSG_IDTL.Row, 6] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ItmPcs"], (object)"")), "0");
							mSG_IDTL[mSG_IDTL.Row, 7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GrWt"], (object)"")), "0.000");
							mSG_IDTL[mSG_IDTL.Row, 19] = "Y";
						}
						break;
					}
					case 2:
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
									mSG_IDTL[mSG_IDTL.Row, 2] = DC_Main.ColValue[1];
									mSG_IDTL[mSG_IDTL.Row, 3] = DC_Main.ColValue[0];
									mSG_IDTL[mSG_IDTL.Row, 21] = DC_Main.ColValue[4];
								}
								((Control)TEXT_IDTL).Focus();
							}
						}
						else
						{
							mSG_IDTL[mSG_IDTL.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
							mSG_IDTL[mSG_IDTL.Row, 21] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
							if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
							{
								mSG_IDTL.Col = 6;
							}
							else
							{
								mSG_IDTL.Col = 6;
							}
							((Control)TEXT_IDTL).Visible = true;
							((Control)TEXT_IDTL).Focus();
						}
						return;
					case 18:
						if (mSG_IDTL.Row == mSG_IDTL.Rows - 1)
						{
							mSG_IDTL[mSG_IDTL.Row, 18] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
							CommPassTotal_Idtl(mSG_IDTL.Row);
							MsgClearIdtl = true;
							mSG_IDTL.Rows += 1;
							mSG_IDTL.Row += 1;
							MsgClearIdtl = false;
							mSG_IDTL.Col = 2;
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
					((TextBoxBase)TEXT_IDTL).MaxLength = 5;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 2:
					((TextBoxBase)TEXT_IDTL).MaxLength = 5;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_IDTL).MaxLength = 50;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 13:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					break;
				case 19:
					((TextBoxBase)TEXT_IDTL).MaxLength = 1;
					TEXT_IDTL.Text = mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col];
					((TextBoxBase)TEXT_IDTL).ReadOnly = true;
					break;
				case 4:
				case 6:
				case 9:
				case 11:
					((TextBoxBase)TEXT_IDTL).MaxLength = 6;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0");
					break;
				case 14:
				case 15:
				case 16:
				case 17:
				case 18:
					((TextBoxBase)TEXT_IDTL).MaxLength = 10;
					TEXT_IDTL.Text = Strings.Format((object)Conversion.Val(mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col]), "0.00");
					break;
				case 5:
				case 7:
				case 8:
				case 10:
				case 12:
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
			case 3:
			case 13:
			case 19:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				break;
			case 2:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = TEXT_IDTL.Text;
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 4:
			case 6:
			case 9:
			case 11:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 14:
			case 15:
			case 16:
			case 17:
			case 18:
				mSG_IDTL[mSG_IDTL.Row, mSG_IDTL.Col] = Strings.Format((object)Conversion.Val(TEXT_IDTL.Text), "0.00");
				CommPassTotal_Idtl(mSG_IDTL.Row);
				break;
			case 5:
			case 7:
			case 8:
			case 10:
			case 12:
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
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		AxMSFlexGrid mSG_IDTL = MSG_IDTL;
		if ((Conversion.Val(mSG_IDTL[CRow, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 8]) != 0.0))
		{
			mSG_IDTL[CRow, 20] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 7]) * Conversion.Val(mSG_IDTL[CRow, 8])), "0.000");
		}
		else
		{
			mSG_IDTL[CRow, 20] = Conversions.ToString(0);
		}
		if (Operators.CompareString(mSG_IDTL[CRow, 13], "", false) == 0)
		{
			if ((Conversion.Val(mSG_IDTL[CRow, 7]) == 0.0) & (Conversion.Val(mSG_IDTL[CRow, 6]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 6])), "0.00");
			}
			else if ((Conversion.Val(mSG_IDTL[CRow, 7]) != 0.0) & (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0))
			{
				mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
			}
		}
		else if (((0 - ((Operators.CompareString(mSG_IDTL[CRow, 13], "P", false) == 0) ? 1 : 0)) & checked((long)Math.Round(Conversion.Val(mSG_IDTL[CRow, 14])))) != 0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 6])), "0.00");
		}
		else if (Conversion.Val(mSG_IDTL[CRow, 14]) != 0.0)
		{
			mSG_IDTL[CRow, 15] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 14]) * Conversion.Val(mSG_IDTL[CRow, 7])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 16]) != 0.0)
		{
			mSG_IDTL[CRow, 17] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 16]) * Conversion.Val(mSG_IDTL[CRow, 6])), "0.00");
		}
		if (Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17]) != 0.0)
		{
			mSG_IDTL[CRow, 18] = Strings.Format((object)(Conversion.Val(mSG_IDTL[CRow, 15]) + Conversion.Val(mSG_IDTL[CRow, 17])), "0.00");
		}
		if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0 && Conversion.Val(mSG_IDTL[CRow, 6]) + Conversion.Val(mSG_IDTL[CRow, 7]) > 0.0)
		{
			mSG_IDTL[CRow, 19] = "N";
		}
		checked
		{
			int num5 = mSG_IDTL.Rows - 1;
			DC_Main.M = 1;
			double num6 = default(double);
			double num7 = default(double);
			while (DC_Main.M <= num5)
			{
				num6 += Conversion.Val(mSG_IDTL[DC_Main.M, 20]);
				if (Operators.CompareString(mSG_IDTL[DC_Main.M, 19], "Y", false) != 0)
				{
					num += Conversion.Val(mSG_IDTL[DC_Main.M, 7]);
					num2 += Conversion.Val(mSG_IDTL[DC_Main.M, 20]);
					num7 += Conversion.Val(mSG_IDTL[DC_Main.M, 18]);
					if (Operators.CompareString(mSG_IDTL[DC_Main.M, 21], "G", false) != 0)
					{
						num3 += Conversion.Val(mSG_IDTL[DC_Main.M, 6]);
						num4 += Conversion.Val(mSG_IDTL[DC_Main.M, 7]);
					}
				}
				DC_Main.M++;
			}
			if (num3 != 0.0)
			{
				MSG[MSG.Row, 60] = Strings.Format((object)num3, "0");
			}
			if (num4 != 0.0)
			{
				MSG[MSG.Row, 61] = Strings.Format((object)num4, "0.000");
			}
			if (Operators.CompareString(FormMainBook, "MFG REC ITEM", false) == 0)
			{
				if (num6 != 0.0)
				{
					MSG[MSG.Row, 12] = Strings.Format((object)num6, "0.000");
					MSG[MSG.Row, 13] = Strings.Format((object)(Conversion.Val(MSG[MSG.Row, 11]) - Conversion.Val(MSG[MSG.Row, 12])), "0.000");
				}
				if (num7 != 0.0)
				{
					MSG[MSG.Row, 26] = Strings.Format((object)num7, "0.00");
				}
			}
			if (Operators.CompareString(mSG_IDTL[CRow, 2], "", false) != 0)
			{
				bool flag = false;
				int num8 = DtIdtl.Rows.Count - 1;
				for (int i = 0; i <= num8; i++)
				{
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22])) == Conversion.Val(mSG_IDTL[CRow, 22])) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0])) == Conversion.Val(mSG_IDTL[CRow, 0])))
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
		AcFineGl = 0.0;
		AcFineSl = 0.0;
		AxMSFlexGrid mSG_TOT = MSG_TOT;
		int num = 0;
		checked
		{
			int num2 = MSG.Cols - 1;
			for (num = 1; num <= num2; num++)
			{
				mSG_TOT[0, num] = "";
			}
			TotDrFine = 0.0;
			mSG_TOT[0, 4] = "Total :";
			int num3 = MSG.Rows - 1;
			for (num = 1; num <= num3; num++)
			{
				mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[num, 10]))), "0");
				mSG_TOT[0, 22] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 22]) + Conversion.Val(MSG[num, 22]))), "0.000");
				mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[num, 11]))), "0.000");
				mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[num, 12]))), "0.000");
				mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[num, 13]))), "0.000");
				mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[num, 20]))), "0.000");
				mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[num, 16]))), "0.000");
				mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[num, 7]))), "0.000");
				mSG_TOT[0, 35] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 35]) + Conversion.Val(MSG[num, 35]))), "0.000");
				mSG_TOT[0, 36] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 36]) + Conversion.Val(MSG[num, 36]))), "0.000");
				mSG_TOT[0, 37] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 37]) + Conversion.Val(MSG[num, 37]))), "0.000");
				mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[num, 44]))), "0.00");
				mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[num, 25]))), "0.00");
				mSG_TOT[0, 26] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 26]) + Conversion.Val(MSG[num, 26]))), "0.00");
				mSG_TOT[0, 27] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 27]) + Conversion.Val(MSG[num, 27]))), "0.00");
				if (Conversion.Val(MSG[num, 44]) == 0.0)
				{
					TotDrFine += Conversion.Val(MSG[num, 16]);
				}
				if (Conversion.Val(MSG[num, 44]) == 0.0)
				{
					if (Operators.CompareString(MSG[num, 63], "G", false) == 0)
					{
						AcFineGl += Conversion.Val(MSG[num, 16]);
					}
					else if (Operators.CompareString(MSG[num, 63], "S", false) == 0)
					{
						AcFineSl += Conversion.Val(MSG[num, 16]);
					}
				}
			}
			mSG_TOT = null;
			NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 26]) + Conversion.Val(MSG_TOT[0, 25]);
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 10] = Conversions.ToString(1);
		mSG[mSG.Row, 23] = "G";
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 42] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 42] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 42]) + 1.0);
		}
		mSG[mSG.Row, 46] = "A";
		mSG[mSG.Row, 39] = "N";
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
			case 1:
			case 17:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 29:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 28:
			case 30:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 2:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 33:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 3:
			case 40:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 4:
			case 5:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 23:
			case 39:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 34:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 10:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 14:
			case 15:
			case 19:
			case 45:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 24:
			case 25:
			case 26:
			case 27:
			case 43:
			case 44:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 7:
			case 31:
			case 35:
			case 36:
			case 37:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				if (Operators.CompareString(FormMainBook, "MFG WEX REC", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 6:
			case 8:
			case 9:
			case 11:
			case 12:
			case 13:
			case 18:
			case 20:
			case 21:
			case 22:
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
		if (!UpDown && !MsgClear && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 1:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 4:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 2:
			case 3:
			case 5:
			case 17:
			case 23:
			case 28:
			case 29:
			case 30:
			case 33:
			case 39:
			case 41:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 10:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 14:
			case 15:
			case 19:
			case 45:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 24:
			case 25:
			case 26:
			case 27:
			case 43:
			case 44:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 12:
			case 21:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal_Idtl(1);
				CommPassTotal();
				break;
			case 7:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 6:
			case 8:
			case 9:
			case 11:
			case 13:
			case 16:
			case 18:
			case 20:
			case 22:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 31:
			case 35:
			case 36:
			case 37:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				break;
			}
			mSG = null;
		}
	}

	private void ItmTagGen(int Y)
	{
		AxMSFlexGrid mSG = MSG;
		DC_Main.RsQry = "SELECT RIGHT(A.TAG_NO,4) AS TAG_SRNO FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND SUBSTRING(TAG_NO,2,2) = '" + Strings.Mid(mVchDate.Text, 4, 2) + "' GROUP BY RIGHT(A.TAG_NO,4) ORDER BY RIGHT(A.TAG_NO,4) DESC";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		string text = ((dataTable.Rows.Count != 0) ? Strings.Format((object)(Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[0]["TAG_SRNO"], (object)"")) + 1.0), "0000") : "0001");
		checked
		{
			int num = mSG.Rows - 1;
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				if (Operators.CompareString(mSG[Y, 3], "", false) == 0 && ((DC_Main.i != Y) & (Conversion.Val(Strings.Right(mSG[DC_Main.i, 3], 4)) >= Conversion.Val(text))) && Conversion.Val(Strings.Right(mSG[DC_Main.i, 3], 4)) + 1.0 > Conversion.Val(text))
				{
					text = Strings.Format((object)(Conversion.Val(Strings.Right(mSG[DC_Main.i, 3], 4)) + 1.0), "0000");
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				mSG[Y, 3] = Strings.Mid(DC_Main.MCo_year, 4, 1) + Strings.Mid(mVchDate.Text, 4, 2) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + text;
			}
			else
			{
				mSG[Y, 3] = Strings.Mid(DC_Main.MCo_year, 4, 1) + Strings.Mid(mVchDate.Text, 4, 2) + text;
			}
			TEXT_ENTRY.Text = mSG[Y, 3];
			mSG = null;
			dataTable.Clear();
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
				case 4130:
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
							goto IL_0034;
						case 5:
							goto IL_0053;
						case 6:
							goto IL_00ad;
						case 7:
							goto IL_00f4;
						case 10:
							goto IL_0141;
						case 11:
							goto IL_016a;
						case 8:
						case 9:
						case 12:
						case 13:
						case 14:
							goto IL_01b3;
						case 15:
							goto IL_01e7;
						case 16:
							goto IL_021b;
						case 17:
						case 18:
							goto IL_0265;
						case 19:
							goto IL_02b1;
						case 20:
						case 21:
							goto IL_02fb;
						case 22:
							goto IL_0332;
						case 23:
							goto IL_0366;
						case 24:
							goto IL_03c6;
						case 26:
							goto IL_0444;
						case 25:
						case 27:
						case 28:
						case 29:
							goto IL_047b;
						case 30:
							goto IL_04c7;
						case 31:
						case 32:
							goto IL_051b;
						case 33:
							goto IL_0552;
						case 34:
							goto IL_0586;
						case 35:
							goto IL_05e6;
						case 36:
						case 37:
						case 38:
							goto IL_0664;
						case 39:
							goto IL_069b;
						case 40:
							goto IL_06cf;
						case 41:
							goto IL_072f;
						case 42:
						case 43:
						case 44:
							goto IL_07ad;
						case 45:
							goto IL_07e8;
						case 46:
						case 47:
							goto IL_0832;
						case 48:
							goto IL_087e;
						case 49:
						case 50:
							goto IL_08dc;
						case 51:
							goto IL_090a;
						case 53:
							goto IL_0953;
						case 55:
							goto IL_09a7;
						case 57:
							goto IL_0a0f;
						case 59:
							goto IL_0a7e;
						case 52:
						case 54:
						case 56:
						case 58:
						case 60:
						case 61:
						case 62:
							goto IL_0ad1;
						case 63:
							goto IL_0ae7;
						case 64:
							goto IL_0b14;
						case 65:
							goto IL_0b64;
						case 67:
							goto IL_0bad;
						case 69:
							goto IL_0c05;
						case 71:
							goto IL_0c71;
						case 73:
							goto IL_0ce4;
						case 66:
						case 68:
						case 70:
						case 72:
						case 74:
						case 75:
						case 76:
						case 77:
						case 78:
							goto IL_0d3f;
						case 79:
							goto IL_0d87;
						case 80:
							goto IL_0dbc;
						case 81:
							goto IL_0e04;
						case 82:
						case 83:
							goto IL_0e9f;
						case 84:
							goto IL_0ea1;
						case 85:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 86:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0e04:
					num2 = 81;
					val[val.Row, 32] = Strings.Format((object)(Conversion.Val(val[val.Row, 31]) - (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20]) + Conversion.Val(val[val.Row, 21]) + Conversion.Val(val[val.Row, 22]) + Conversion.Val(val[val.Row, 18]))), "0.000");
					goto IL_0e9f;
					IL_0e9f:
					val = null;
					goto IL_0ea1;
					IL_0dbc:
					num2 = 80;
					val[val.Row, 38] = Strings.Format((object)(Conversion.Val(val[val.Row, 34]) - Conversion.Val(val[val.Row, 10])), "0");
					goto IL_0e04;
					IL_0ea1:
					num2 = 84;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
					{
						goto IL_0034;
					}
					goto IL_0141;
					IL_0034:
					num2 = 4;
					if (Operators.CompareString(EntryMode, "A", false) == 0)
					{
						goto IL_0053;
					}
					goto IL_01b3;
					IL_0053:
					num2 = 5;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 31]) - Conversion.Val(val[val.Row, 9]) + Conversion.Val(val[val.Row, 8])), "0.000");
					goto IL_00ad;
					IL_00ad:
					num2 = 6;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 31]) - Conversion.Val(val[val.Row, 9])), "0.000");
					goto IL_00f4;
					IL_00f4:
					num2 = 7;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 13])), "0.000");
					goto IL_01b3;
					IL_0141:
					num2 = 10;
					if (Conversion.Val(val[val.Row, 6]) != 0.0)
					{
						goto IL_016a;
					}
					goto IL_01b3;
					IL_016a:
					num2 = 11;
					val[val.Row, 11] = Strings.Format((object)(Conversion.Val(val[val.Row, 6]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_01b3;
					IL_01b3:
					num2 = 14;
					if (Conversion.Val(val[val.Row, 11]) != Conversion.Val(val[val.Row, 47]))
					{
						goto IL_01e7;
					}
					goto IL_0265;
					IL_01e7:
					num2 = 15;
					val[val.Row, 47] = Strings.Format((object)Conversion.Val(val[val.Row, 11]), "0.000");
					goto IL_021b;
					IL_021b:
					num2 = 16;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_0265;
					IL_0265:
					num2 = 18;
					if ((Conversion.Val(val[val.Row, 12]) != 0.0) & (Conversion.Val(val[val.Row, 11]) != 0.0))
					{
						goto IL_02b1;
					}
					goto IL_02fb;
					IL_02b1:
					num2 = 19;
					val[val.Row, 13] = Strings.Format((object)(Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 12])), "0.000");
					goto IL_02fb;
					IL_02fb:
					num2 = 21;
					if (Conversion.Val(val[val.Row, 13]) != Conversion.Val(val[val.Row, 48]))
					{
						goto IL_0332;
					}
					goto IL_047b;
					IL_0332:
					num2 = 22;
					val[val.Row, 48] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_0366;
					IL_0366:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_03c6;
					}
					goto IL_0444;
					IL_03c6:
					num2 = 24;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_047b;
					IL_0444:
					num2 = 26;
					val[val.Row, 16] = Strings.Format((object)Conversion.Val(val[val.Row, 13]), "0.000");
					goto IL_047b;
					IL_047b:
					num2 = 29;
					if ((Conversion.Val(val[val.Row, 19]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_04c7;
					}
					goto IL_051b;
					IL_04c7:
					num2 = 30;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) * Conversion.Val(val[val.Row, 19]) / 100.0), "0.000");
					goto IL_051b;
					IL_051b:
					num2 = 32;
					if (Conversion.Val(val[val.Row, 14]) != Conversion.Val(val[val.Row, 49]))
					{
						goto IL_0552;
					}
					goto IL_0664;
					IL_0552:
					num2 = 33;
					val[val.Row, 49] = Strings.Format((object)Conversion.Val(val[val.Row, 14]), "0.00");
					goto IL_0586;
					IL_0586:
					num2 = 34;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_05e6;
					}
					goto IL_0664;
					IL_05e6:
					num2 = 35;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_0664;
					IL_0664:
					num2 = 38;
					if (Conversion.Val(val[val.Row, 15]) != Conversion.Val(val[val.Row, 50]))
					{
						goto IL_069b;
					}
					goto IL_07ad;
					IL_069b:
					num2 = 39;
					val[val.Row, 50] = Strings.Format((object)Conversion.Val(val[val.Row, 15]), "0.00");
					goto IL_06cf;
					IL_06cf:
					num2 = 40;
					if ((Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) != 0.0) & (Conversion.Val(val[val.Row, 13]) != 0.0))
					{
						goto IL_072f;
					}
					goto IL_07ad;
					IL_072f:
					num2 = 41;
					val[val.Row, 16] = Strings.Format((object)((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15])) / 100.0), "0.000");
					goto IL_07ad;
					IL_07ad:
					num2 = 44;
					if (Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) == 0.0)
					{
						goto IL_07e8;
					}
					goto IL_0832;
					IL_07e8:
					num2 = 45;
					val[val.Row, 16] = Strings.Format((object)(Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])), "0.000");
					goto IL_0832;
					IL_0832:
					num2 = 47;
					if ((Conversion.Val(val[val.Row, 45]) != 0.0) & (Conversion.Val(val[val.Row, 43]) != 0.0))
					{
						goto IL_087e;
					}
					goto IL_08dc;
					IL_087e:
					num2 = 48;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 43]) * Conversion.Val(val[val.Row, 45]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_08dc;
					IL_08dc:
					num2 = 50;
					if (Conversion.Val(val[val.Row, 24]) != 0.0)
					{
						goto IL_090a;
					}
					goto IL_0ad1;
					IL_090a:
					num2 = 51;
					switch (val[val.Row, 23])
					{
					case "P":
						break;
					case "N":
						goto IL_09a7;
					case "K":
						goto IL_0a0f;
					default:
						goto IL_0a7e;
					}
					goto IL_0953;
					IL_0a7e:
					num2 = 59;
					val[val.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 11]) * Conversion.Val(val[val.Row, 24]), 0), "0.00");
					goto IL_0ad1;
					IL_0a0f:
					num2 = 57;
					val[val.Row, 25] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) * (Conversion.Val(val[val.Row, 24]) / 1000.0), 0), "0.00");
					goto IL_0ad1;
					IL_09a7:
					num2 = 55;
					val[val.Row, 25] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) * Conversion.Val(val[val.Row, 24]), 0), "0.00");
					goto IL_0ad1;
					IL_0953:
					num2 = 53;
					val[val.Row, 25] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 10]) * Conversion.Val(val[val.Row, 24]), 0), "0.00");
					goto IL_0ad1;
					IL_0ad1:
					num2 = 62;
					if (val.Col == 25)
					{
						goto IL_0ae7;
					}
					goto IL_0d3f;
					IL_0ae7:
					num2 = 63;
					if (Conversion.Val(val[val.Row, 25]) != 0.0)
					{
						goto IL_0b14;
					}
					goto IL_0d3f;
					IL_0b14:
					num2 = 64;
					if ((Conversion.Val(val[val.Row, 25]) != 0.0) & (Conversion.Val(val[val.Row, 24]) != 0.0))
					{
						goto IL_0b64;
					}
					goto IL_0d3f;
					IL_0b64:
					num2 = 65;
					switch (val[val.Row, 23])
					{
					case "P":
						break;
					case "N":
						goto IL_0c05;
					case "K":
						goto IL_0c71;
					default:
						goto IL_0ce4;
					}
					goto IL_0bad;
					IL_0ce4:
					num2 = 73;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 25]) / Conversion.Val(val[val.Row, 11]), DC_Main.MsLbrRof), "0.00");
					goto IL_0d3f;
					IL_0c71:
					num2 = 71;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 25]) / (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_0d3f;
					IL_0c05:
					num2 = 69;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 25]) / (Conversion.Val(val[val.Row, 13]) + Conversion.Val(val[val.Row, 20])), DC_Main.MsLbrRof), "0.00");
					goto IL_0d3f;
					IL_0bad:
					num2 = 67;
					val[val.Row, 24] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 25]) / Conversion.Val(val[val.Row, 10]), DC_Main.MsLbrRof), "0.00");
					goto IL_0d3f;
					IL_0d3f:
					num2 = 78;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 25]) + Conversion.Val(val[val.Row, 26])), "0.00");
					goto IL_0d87;
					IL_0d87:
					num2 = 79;
					if ((Operators.CompareString(FormBookInOut, "I", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
					{
						goto IL_0dbc;
					}
					goto IL_0e9f;
					end_IL_0001_2:
					break;
				}
				num2 = 85;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 4130;
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
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Invalid comparison between Unknown and I4
		//IL_02aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Invalid comparison between Unknown and I4
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Invalid comparison between Unknown and I4
		//IL_0327: Unknown result type (might be due to invalid IL or missing references)
		//IL_032a: Invalid comparison between Unknown and I4
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a6: Invalid comparison between Unknown and I4
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0432: Invalid comparison between Unknown and I4
		//IL_04c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c5: Invalid comparison between Unknown and I4
		//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ebe: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			if (mSG.Col == 3 && ((Operators.CompareString(mSG[mSG.Row, 3], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)))
			{
				ItmTagGen(mSG.Row);
			}
		}
		else if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = (int)Math.Round(Conversion.Val(mSG[mSG.Row, 42]));
					List<DataRow> list = new List<DataRow>();
					int num2 = DtIdtl.Rows.Count - 1;
					DC_Main.M = 0;
					while (DC_Main.M <= num2)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[DC_Main.M][22])) == Conversion.Val(mSG[mSG.Row, 42]))
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
							mSG[mSG.Row, 42] = Conversions.ToString(MSG.Row);
						}
						else
						{
							mSG[mSG.Row, 42] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 42]) + 1.0);
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
					MsgOldRow = 0;
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
					case 29:
						if ((Operators.CompareString(FormMainBook, "MFG CAST ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG CAST REC", false) == 0))
						{
							if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 68]) != Conversion.Val(mSG[mSG.Row, 69])))
							{
								Casting_Isu_Rec(mSG.Row);
								if (mSG.Row == mSG.Rows - 1)
								{
									mSG.Col = 1;
								}
								else
								{
									mSG.Col = 1;
								}
								((Control)TEXT_ENTRY).Visible = true;
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						if ((Operators.CompareString(FormMainBook, "MFG FILE ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG PREP ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG ASMBL ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG NAKSHI ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH ISU", false) == 0))
						{
							if (!(((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 68]) != Conversion.Val(mSG[mSG.Row, 69]))))
							{
								return;
							}
							Filing_isu(mSG.Row);
							if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
							{
								if (mSG.Row == mSG.Rows - 1)
								{
									mSG.Col = 1;
								}
								else
								{
									mSG.Col = 1;
								}
							}
							else if (mSG.Row == mSG.Rows - 1)
							{
								mSG.Col = 11;
							}
							else
							{
								mSG.Col = 1;
							}
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if ((Operators.CompareString(FormMainBook, "MFG FILE REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG PREP REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG ASMBL REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG NAKSHI REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH REC", false) == 0))
						{
							if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 68]) != Conversion.Val(mSG[mSG.Row, 69])))
							{
								Filing_Rec(mSG.Row);
								if (mSG.Row == mSG.Rows - 1)
								{
									mSG.Col = 1;
								}
								else
								{
									mSG.Col = 1;
								}
								((Control)TEXT_ENTRY).Visible = true;
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						if (Operators.CompareString(FormMainBook, "MFG ASMBL REC", false) != 0)
						{
							break;
						}
						if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 68]) != Conversion.Val(mSG[mSG.Row, 69])))
						{
							Asmbl_Rec(mSG.Row);
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG.Col = 1;
							}
							else
							{
								mSG.Col = 1;
							}
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					case 1:
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
									mSG[mSG.Row, 1] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[0];
									mSG[mSG.Row, 62] = DC_Main.ColValue[3];
									mSG[mSG.Row, 63] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 62] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						mSG[mSG.Row, 63] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
						{
							if (Operators.CompareString(mSG[mSG.Row, 62], mSG[mSG.Row, 64], false) != 0)
							{
								mSG[mSG.Row, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
								mSG[mSG.Row, 3] = "";
							}
						}
						else
						{
							mSG[mSG.Row, 64] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["PR_CODE"], (object)""));
						}
						lblItem.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)" : It Name"));
						break;
					case 17:
						if (Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							break;
						}
						DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count != 0)
						{
							break;
						}
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
								mSG[mSG.Row, 17] = DC_Main.ColValue[1];
							}
							((Control)TEXT_ENTRY).Focus();
						}
						return;
					case 5:
						mSG[mSG.Row, 5] = TEXT_ENTRY.Text;
						((Control)TEXT_ENTRY).Visible = false;
						((Control)tItRemark).Focus();
						return;
					case 11:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						if (Operators.CompareString(FormMainBook, "MFG REC ITEM", false) == 0)
						{
							mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
							CommPassTotal();
							((Control)TEXT_ENTRY).Visible = false;
							MSG_IDTL.Row = 1;
							MSG_IDTL.Col = 2;
							MSG_IDTL_EnterCell(MSG_IDTL, new EventArgs());
							((Control)TEXT_IDTL).Focus();
							((TextBoxBase)TEXT_IDTL).SelectAll();
							return;
						}
						break;
					case 27:
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

	private void CustOrd_isu(int CurRow)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 28], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 68]) != Conversion.Val(mSG[mSG.Row, 69])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 28], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 68]) == Conversion.Val(MSG[DC_Main.i, 68])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode,B.IT_NAME From SL_ORD_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 66] + "' AND CO_BOOK = '" + mSG[mSG.Row, 67] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 68])) + " AND VCH_NO = '" + TEXT_ENTRY.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE As SizeL,A.ORD_DEL_DATE As DeleveryL,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.SR_NO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL,A.AC_CODE As AcCodeL,A.ITM_PCS As OrdPcsM FROM (SL_ORD_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.DESIGN_ISU = 'N' AND A.TAG_STK_LESS <> 'Y'  ORDER BY A.VCH_DATE,A.VCH_NO,A.SR_NO";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[16];
					DC_Main.ColWidth[0] = 70.0;
					DC_Main.ColWidth[1] = 150.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 200.0;
					DC_Main.ColWidth[4] = 200.0;
					DC_Main.ColWidth[5] = 80.0;
					DC_Main.ColWidth[6] = 100.0;
					DC_Main.ColWidth[7] = 90.0;
					DC_Main.ColWidth[8] = 90.0;
					DC_Main.ColWidth[9] = 60.0;
					DC_Main.ColWidth[10] = 80.0;
					DC_Main.ColWidth[11] = 70.0;
					DC_Main.ColWidth[12] = 0.0;
					DC_Main.ColWidth[13] = 0.0;
					DC_Main.ColWidth[14] = 0.0;
					DC_Main.HelpSelect = 0;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						mSG[CurRow, 2] = DC_Main.ColValue[1];
						mSG[CurRow, 1] = DC_Main.ColValue[12];
						mSG[CurRow, 4] = DC_Main.ColValue[2];
						mSG[CurRow, 51] = DC_Main.ColValue[4];
						mSG[CurRow, 10] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[14]), "0");
						mSG[CurRow, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[CurRow, 12] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[7]) - Conversion.Val(DC_Main.ColValue[8])), "0.000");
						mSG[CurRow, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
						mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[14]), "0");
						mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[CurRow, 36] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[7]) - Conversion.Val(DC_Main.ColValue[8])), "0.000");
						mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
						mSG[CurRow, 28] = DC_Main.ColValue[0];
						mSG[CurRow, 65] = DC_Main.ColValue[0];
						mSG[CurRow, 66] = DC_Main.ColValue[10];
						mSG[CurRow, 67] = DC_Main.ColValue[11];
						mSG[CurRow, 68] = DC_Main.ColValue[9];
						mSG[CurRow, 69] = DC_Main.ColValue[9];
						mSG[CurRow, 71] = DC_Main.ColValue[3];
						mSG[CurRow, 70] = DC_Main.ColValue[13];
						if ((Operators.CompareString(mSG[mSG.Row, 3], "", false) == 0) & (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0))
						{
							ItmTagGen(mSG.Row);
						}
						int num2 = 0;
						int num3 = DtIdtl.Rows.Count - 1;
						int num4 = num3;
						for (int i = 0; i <= num4; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num2][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
							{
								DtIdtl.Rows[num2].Delete();
								DtIdtl.AcceptChanges();
								num2--;
							}
							num2++;
						}
						MSG_IDTL_CLEAR();
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM SL_ORD_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 66] + "' AND CO_BOOK = '" + mSG[CurRow, 67] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 68])) + " AND VCH_NO = '" + mSG[CurRow, 28] + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = 0;
						while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
						{
							dr = DtIdtl.NewRow();
							dr[22] = Conversion.Val(MSG[CurRow, 42]);
							dr[0] = DC_Main.i + 1;
							dr[1] = "";
							dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
							dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
							if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
							{
								dr[4] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
								dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
								dr[6] = 0;
								dr[7] = 0;
							}
							else
							{
								dr[4] = 0;
								dr[5] = 0;
								dr[6] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
								dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							}
							dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
							dr[9] = 0;
							dr[10] = 0;
							dr[11] = 0;
							dr[12] = 0;
							dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
							dr[14] = 0;
							dr[15] = 0;
							dr[16] = 0;
							dr[17] = 0;
							dr[18] = 0;
							dr[19] = "Y";
							dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
							dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
							DtIdtl.Rows.Add(dr);
							DC_Main.i++;
						}
						MsgOldRow = 0;
						CommPassTotal();
						MSG_RowColChange(MSG, new EventArgs());
						MSG_TOT_FILL();
					}
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	private void Wex_Rec(int CurRow)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0429: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 28], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 58]) != Conversion.Val(mSG[mSG.Row, 59])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 28], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 58]) == Conversion.Val(MSG[DC_Main.i, 59])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = "Select A.*, B.IT_TYPE As ItType,B.RATE_TYPE, B.PR_CODE as PrCode,B.IT_NAME From MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' And CO_YEAR = '" + mSG[mSG.Row, 56] + "' AND CO_BOOK = '" + mSG[mSG.Row, 57] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 58])) + " AND VCH_NO = '" + TEXT_ENTRY.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE As SizeL,A.ITM_GWT As ItmGwtW,A.ITM_NWT As ItmNwtW,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL FROM (MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = 'D' AND A.REP_ADJ = 'N'  ORDER BY A.VCH_NO,A.OLD_SRNO,A.VCH_DATE DESC";
					DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.ColWidth = new double[13];
					DC_Main.ColWidth[0] = 70.0;
					DC_Main.ColWidth[1] = 150.0;
					DC_Main.ColWidth[2] = 100.0;
					DC_Main.ColWidth[3] = 200.0;
					DC_Main.ColWidth[4] = 200.0;
					DC_Main.ColWidth[5] = 80.0;
					DC_Main.ColWidth[6] = 90.0;
					DC_Main.ColWidth[7] = 90.0;
					DC_Main.ColWidth[8] = 60.0;
					DC_Main.ColWidth[9] = 80.0;
					DC_Main.ColWidth[10] = 70.0;
					DC_Main.ColWidth[11] = 0.0;
					DC_Main.HelpSelect = 0;
					((Form)MyProject.Forms.MS_HELP).ShowDialog();
					if (DC_Main.HelpClose)
					{
						return;
					}
					if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
					{
						TEXT_ENTRY.Text = DC_Main.ColValue[0];
						mSG[CurRow, 2] = DC_Main.ColValue[1];
						mSG[CurRow, 1] = DC_Main.ColValue[11];
						mSG[CurRow, 33] = DC_Main.ColValue[11];
						mSG[CurRow, 4] = DC_Main.ColValue[2];
						mSG[CurRow, 51] = DC_Main.ColValue[4];
						mSG[CurRow, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
						mSG[CurRow, 12] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[6]) - Conversion.Val(DC_Main.ColValue[7])), "0.000");
						mSG[CurRow, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
						mSG[CurRow, 28] = DC_Main.ColValue[0];
						mSG[CurRow, 55] = DC_Main.ColValue[0];
						mSG[CurRow, 56] = DC_Main.ColValue[9];
						mSG[CurRow, 57] = DC_Main.ColValue[10];
						mSG[CurRow, 58] = DC_Main.ColValue[8];
						mSG[CurRow, 59] = DC_Main.ColValue[8];
						DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ORD_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_PCS"], (object)"")), "0");
							mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_GWT"], (object)"")), "0.000");
							mSG[CurRow, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_OTH_WT"], (object)"")), "0.000");
							mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NWT"], (object)"")), "0.000");
							mSG[CurRow, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
							mSG[CurRow, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
							mSG[CurRow, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
							mSG[CurRow, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
							mSG[CurRow, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
							mSG[CurRow, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
						}
						int num2 = 0;
						int num3 = DtIdtl.Rows.Count - 1;
						int num4 = num3;
						for (int i = 0; i <= num4; i++)
						{
							if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num2][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
							{
								DtIdtl.Rows[num2].Delete();
								DtIdtl.AcceptChanges();
								num2--;
							}
							num2++;
						}
						MSG_IDTL_CLEAR();
						CommPassTotal();
						MSG_TOT_FILL();
					}
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	private void Casting_Isu_Rec(int CurRow)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 58]) != Conversion.Val(mSG[mSG.Row, 59])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 29], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 58]) == Conversion.Val(MSG[DC_Main.i, 59])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				if (Operators.CompareString(FormMainBook, "MFG CAST REC", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE As SizeL,A.ITM_GWT As ItmGwtW,A.KR_WAX_WT As WaxWtW,A.VCH_NO As VchNoL,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.ISU_IT_CODE As ItCodeL FROM (MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = 'C' AND A.REP_ADJ = 'N' AND A.INOUT_TYPE = 'O' AND A.AC_CODE = '" + tAcCode.Text + "'  ORDER BY A.VCH_NO,A.OLD_SRNO,A.VCH_DATE DESC";
				}
				else if (Operators.CompareString(WaxProcess, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE As SizeL,A.ITM_GWT As ItmGwtW,A.KR_WAX_WT As WaxWtW,A.VCH_NO As VchNoL,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL FROM (MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = 'W' AND A.REP_ADJ = 'N'  ORDER BY A.VCH_NO,A.OLD_SRNO,A.VCH_DATE DESC";
				}
				else
				{
					DC_Main.RsQry = "SELECT A.TAG_NO As TagNoL,C.IT_NAME As ItNameL,A.DESIGN_NO As DesignL,B.AC_NAME as CustNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE As SizeL,A.ITM_GWT As ItmGwtW,0 As WaxWtW,A.VCH_NO As VchNoL,A.OLD_SRNO AS SrNoM,A.CO_YEAR As YearM,A.CO_BOOK As BookL,A.IT_CODE As ItCodeL FROM (MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ENTRY_TYPE = 'D' AND A.REP_ADJ = 'N'  ORDER BY A.VCH_NO,A.OLD_SRNO,A.VCH_DATE DESC";
				}
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[13];
				DC_Main.ColWidth[0] = 90.0;
				DC_Main.ColWidth[1] = 170.0;
				DC_Main.ColWidth[2] = 100.0;
				DC_Main.ColWidth[3] = 200.0;
				DC_Main.ColWidth[4] = 200.0;
				DC_Main.ColWidth[5] = 65.0;
				DC_Main.ColWidth[6] = 90.0;
				DC_Main.ColWidth[7] = 90.0;
				DC_Main.ColWidth[8] = 70.0;
				DC_Main.ColWidth[9] = 60.0;
				DC_Main.ColWidth[10] = 80.0;
				DC_Main.ColWidth[11] = 60.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[0];
					mSG[CurRow, 29] = DC_Main.ColValue[0];
					if (Operators.CompareString(FormMainBook, "MFG CAST REC", false) == 0)
					{
						mSG[CurRow, 1] = DC_Main.ColValue[12];
						mSG[CurRow, 2] = DC_Main.ColValue[1];
					}
					else
					{
						mSG[CurRow, 33] = DC_Main.ColValue[12];
					}
					mSG[CurRow, 4] = DC_Main.ColValue[2];
					mSG[CurRow, 51] = DC_Main.ColValue[4];
					if (Operators.CompareString(WaxProcess, "Y", false) == 0)
					{
						mSG[CurRow, 11] = "";
						mSG[CurRow, 7] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
					}
					else
					{
						mSG[CurRow, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
						mSG[CurRow, 7] = "";
					}
					mSG[CurRow, 55] = DC_Main.ColValue[8];
					mSG[CurRow, 56] = DC_Main.ColValue[10];
					mSG[CurRow, 57] = DC_Main.ColValue[11];
					mSG[CurRow, 58] = DC_Main.ColValue[9];
					mSG[CurRow, 59] = DC_Main.ColValue[9];
					mSG[CurRow, 72] = tVchNo.Text;
					mSG[CurRow, 73] = DC_Main.MCo_year;
					mSG[CurRow, 74] = DC_Main.MCo_Book;
					mSG[CurRow, 75] = Conversions.ToString(Conversion.Val(mSG[CurRow, 42]));
					DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ORD_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_PCS"], (object)"")), "0");
						mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_GWT"], (object)"")), "0.000");
						mSG[CurRow, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_OTH_WT"], (object)"")), "0.000");
						mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NWT"], (object)"")), "0.000");
						mSG[CurRow, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
						mSG[CurRow, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
						mSG[CurRow, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
						mSG[CurRow, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
						mSG[CurRow, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG[CurRow, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
					}
					int num2 = 0;
					int num3 = DtIdtl.Rows.Count - 1;
					int num4 = num3;
					for (int i = 0; i <= num4; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num2][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
						{
							DtIdtl.Rows[num2].Delete();
							DtIdtl.AcceptChanges();
							num2--;
						}
						num2++;
					}
					MSG_IDTL_CLEAR();
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						dr = DtIdtl.NewRow();
						dr[22] = Conversion.Val(MSG[CurRow, 42]);
						dr[0] = DC_Main.i + 1;
						dr[1] = "";
						dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
						dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[4] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[6] = 0;
							dr[7] = 0;
						}
						else
						{
							dr[4] = 0;
							dr[5] = 0;
							dr[6] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
						}
						dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
						dr[9] = 0;
						dr[10] = 0;
						dr[11] = 0;
						dr[12] = 0;
						dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
						dr[19] = "Y";
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
						dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						DtIdtl.Rows.Add(dr);
						DC_Main.i++;
					}
					MsgOldRow = 0;
					CommPassTotal();
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	private void Filing_isu(int CurRow)
	{
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 58]) != Conversion.Val(mSG[mSG.Row, 59])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 29], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 58]) == Conversion.Val(MSG[DC_Main.i, 59])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				DC_Main.RsQry = "SELECT ROW_NUMBER() OVER (ORDER BY A.LOT_NO,B.IT_NAME) AS SrNoM,A.LOT_NO As LotNoL,A.IT_CODE As ItCodeL,B.IT_NAME As ItNameL,SUM(CASE WHEN ITM_SIGN = '+' AND IR_TYPE = '" + LastPorcess + "' THEN IR_PCS ELSE 0 END)As IsPcsM,SUM(CASE WHEN ITM_SIGN = '-' AND IR_TYPE = '" + CurProcess + "' THEN IR_PCS ELSE 0 END)As RcPcsM,SUM(CASE WHEN ITM_SIGN = '+' AND IR_TYPE = '" + LastPorcess + "' THEN IR_WT+DM_WT ELSE 0 END)As IsuWtW,SUM(CASE WHEN ITM_SIGN = '-' AND IR_TYPE = '" + CurProcess + "' THEN IR_WT ELSE 0 END) As RecWtW,SUM(CASE WHEN ITM_SIGN = '+' AND IR_TYPE = '" + LastPorcess + "' THEN IR_WT+DM_WT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '-' AND IR_TYPE = '" + CurProcess + "' THEN IR_WT ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.REC_YRCD As MfgYearL,A.REC_DBCD As MfgDbCdL,A.REC_NO As MfgNoL,A.REC_SRNO As MfgSrNo   FROM MFG_ISU_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.LOT_NO <> '' AND A.IR_TYPE IN ('" + LastPorcess + "','" + CurProcess + "')  GROUP BY A.LOT_NO,A.IT_CODE,B.IT_NAME,A.IT_CODE,A.REC_YRCD,A.REC_DBCD,A.REC_NO,A.REC_SRNO HAVING SUM(CASE WHEN ITM_SIGN = '+' AND IR_TYPE = '" + LastPorcess + "' THEN IR_WT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '-' AND IR_TYPE = '" + CurProcess + "' THEN IR_WT ELSE 0 END) > 0 ORDER BY A.LOT_NO DESC,B.IT_NAME ";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[15];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 90.0;
				DC_Main.ColWidth[2] = 80.0;
				DC_Main.ColWidth[3] = 150.0;
				DC_Main.ColWidth[4] = 90.0;
				DC_Main.ColWidth[5] = 90.0;
				DC_Main.ColWidth[6] = 100.0;
				DC_Main.ColWidth[7] = 100.0;
				DC_Main.ColWidth[8] = 100.0;
				DC_Main.ColWidth[9] = 80.0;
				DC_Main.ColWidth[10] = 0.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.ColWidth[13] = 0.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[1];
					mSG[CurRow, 29] = DC_Main.ColValue[1];
					mSG[CurRow, 1] = DC_Main.ColValue[2];
					mSG[CurRow, 2] = DC_Main.ColValue[3];
					mSG[CurRow, 4] = DC_Main.ColValue[2];
					if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
					{
						mSG[mSG.Row, 10] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0");
					}
					mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[CurRow, 73] = DC_Main.ColValue[10];
					mSG[CurRow, 74] = DC_Main.ColValue[11];
					mSG[CurRow, 72] = DC_Main.ColValue[12];
					mSG[CurRow, 75] = DC_Main.ColValue[13];
					mSG[CurRow, 56] = DC_Main.MCo_year;
					mSG[CurRow, 57] = DC_Main.MCo_Book;
					mSG[CurRow, 55] = tVchNo.Text;
					mSG[CurRow, 58] = Conversions.ToString(Conversion.Val(mSG[CurRow, 42]));
					mSG[CurRow, 59] = Conversions.ToString(Conversion.Val(mSG[CurRow, 42]));
					DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ORD_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[CurRow, 73] + "' AND A.CO_BOOK = '" + mSG[CurRow, 74] + "' AND A.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 75])) + " AND VCH_NO = '" + mSG[CurRow, 72] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[CurRow, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
						mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_PCS"], (object)"")), "0");
						mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_GWT"], (object)"")), "0.000");
						mSG[CurRow, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_OTH_WT"], (object)"")), "0.000");
						mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NWT"], (object)"")), "0.000");
						mSG[CurRow, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
						mSG[CurRow, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
						mSG[CurRow, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
						mSG[CurRow, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
						mSG[CurRow, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG[CurRow, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
					}
					int num2 = 0;
					int num3 = DtIdtl.Rows.Count - 1;
					int num4 = num3;
					for (int i = 0; i <= num4; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num2][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
						{
							DtIdtl.Rows[num2].Delete();
							DtIdtl.AcceptChanges();
							num2--;
						}
						num2++;
					}
					MSG_IDTL_CLEAR();
					if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
					{
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM (MFG_DETL AS C INNER JOIN MFG_IDTL AS A ON C.CO_CODE = A.CO_CODE AND C.LC_CODE = A.LC_CODE AND C.CO_YEAR = A.CO_YEAR AND C.CO_BOOK = A.CO_BOOK AND C.VCH_NO = A.VCH_NO AND C.OLD_SRNO = A.SR_NO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.ORD_YRCD = '" + mSG[CurRow, 66] + "' AND C.ORD_DBCD = '" + mSG[CurRow, 67] + "' AND C.ORD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 68])) + " AND C.ORD_NO = '" + mSG[CurRow, 65] + "' AND C.CO_BOOK = '301' ";
					}
					else
					{
						DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					}
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						dr = DtIdtl.NewRow();
						dr[22] = Conversion.Val(MSG[CurRow, 42]);
						dr[0] = DC_Main.i + 1;
						dr[1] = "";
						dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
						dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[4] = Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"], (object)""));
							dr[5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
							dr[6] = 0;
							dr[7] = 0;
						}
						else if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
						{
							dr[4] = Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"], (object)""));
							dr[5] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
							dr[6] = 0;
							dr[7] = 0;
						}
						else
						{
							dr[4] = 0;
							dr[5] = 0;
							dr[6] = Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"], (object)""));
							dr[7] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"], (object)"")), "0.000");
						}
						dr[8] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"], (object)"")), "0.00");
						dr[9] = 0;
						dr[10] = 0;
						dr[11] = 0;
						dr[12] = 0;
						dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						dr[14] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"], (object)"")), "0.00");
						dr[15] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"], (object)"")), "0.00");
						dr[16] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"], (object)"")), "0.00");
						dr[17] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"], (object)"")), "0.00");
						dr[18] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"], (object)"")), "0.00");
						dr[19] = "Y";
						dr[20] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"], (object)"")), "0.000");
						dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						DtIdtl.Rows.Add(dr);
						DC_Main.i++;
					}
					MsgOldRow = 0;
					CommPassTotal();
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	private void Filing_Rec(int CurRow)
	{
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 58]) != Conversion.Val(mSG[mSG.Row, 59])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 29], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 58]) == Conversion.Val(MSG[DC_Main.i, 59])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				string text = "";
				string text2 = "";
				string text3 = "";
				int num2 = 0;
				DC_Main.RsQry = "SELECT ROW_NUMBER() OVER (ORDER BY A.LOT_NO,B.IT_NAME) AS SrNoM,A.LOT_NO As LotNoL,A.IT_CODE As ItCodeL,B.IT_NAME As ItNameL,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)As IsPcsM,SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END)As RcPcsM,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT+(ITM_GWT-ITM_NWT) ELSE 0 END)As IsuWtW,SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) As RecWtW,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT+(ITM_GWT-ITM_NWT) ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.IR_YRCD As MfgYearL,A.IR_DBCD As MfgDbCdL,A.IR_NO As MfgNoL,A.IR_SRNO As MfgSrNo  FROM MFG_ISU_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "'  AND A.LOT_NO <> '' AND A.IR_TYPE IN ('" + LastPorcess + "')  GROUP BY A.LOT_NO,A.IT_CODE,B.IT_NAME,A.IT_CODE,A.IR_YRCD,A.IR_DBCD,A.IR_NO,A.IR_SRNO HAVING SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) > 0 ORDER BY A.LOT_NO DESC,B.IT_NAME ";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[15];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 90.0;
				DC_Main.ColWidth[2] = 80.0;
				DC_Main.ColWidth[3] = 150.0;
				DC_Main.ColWidth[4] = 70.0;
				DC_Main.ColWidth[5] = 70.0;
				DC_Main.ColWidth[6] = 90.0;
				DC_Main.ColWidth[7] = 90.0;
				DC_Main.ColWidth[8] = 90.0;
				DC_Main.ColWidth[9] = 80.0;
				DC_Main.ColWidth[10] = 0.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.ColWidth[13] = 0.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[1];
					mSG[CurRow, 29] = DC_Main.ColValue[1];
					mSG[CurRow, 1] = DC_Main.ColValue[2];
					mSG[CurRow, 2] = DC_Main.ColValue[3];
					if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
					{
						mSG[mSG.Row, 10] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0");
					}
					if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
					{
						mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					}
					mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[CurRow, 56] = DC_Main.ColValue[10];
					mSG[CurRow, 57] = DC_Main.ColValue[11];
					mSG[CurRow, 55] = DC_Main.ColValue[12];
					mSG[CurRow, 58] = DC_Main.ColValue[13];
					mSG[CurRow, 59] = DC_Main.ColValue[13];
					mSG[CurRow, 73] = DC_Main.MCo_year;
					mSG[CurRow, 74] = DC_Main.MCo_Book;
					mSG[CurRow, 72] = tVchNo.Text;
					mSG[CurRow, 75] = Conversions.ToString(Conversion.Val(mSG[CurRow, 42]));
					DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ORD_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[CurRow, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
						if (Operators.CompareString(FormMainBook, "MFG POLISH REC", false) == 0)
						{
							mSG[CurRow, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_GWT"], (object)"")), "0.000");
							mSG[CurRow, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"], (object)"")), "0.000");
							mSG[CurRow, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_NWT"], (object)"")), "0.000");
						}
						if (Operators.CompareString(FormMainBook, "MFG ASMBL REC", false) == 0)
						{
							mSG[CurRow, 12] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"], (object)"")), "0.000");
							mSG[CurRow, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_NWT"], (object)"")), "0.000");
						}
						mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_PCS"], (object)"")), "0");
						mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_GWT"], (object)"")), "0.000");
						mSG[CurRow, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_OTH_WT"], (object)"")), "0.000");
						mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NWT"], (object)"")), "0.000");
						mSG[CurRow, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
						mSG[CurRow, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
						mSG[CurRow, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
						mSG[CurRow, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
						mSG[CurRow, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG[CurRow, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
					}
					int num3 = 0;
					int num4 = DtIdtl.Rows.Count - 1;
					int num5 = num4;
					for (int i = 0; i <= num5; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num3][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
						{
							DtIdtl.Rows[num3].Delete();
							DtIdtl.AcceptChanges();
							num3--;
						}
						num3++;
					}
					MSG_IDTL_CLEAR();
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						dr = DtIdtl.NewRow();
						dr[22] = Conversion.Val(MSG[CurRow, 42]);
						dr[0] = DC_Main.i + 1;
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_LOT"], (object)"");
						}
						else
						{
							dr[1] = "";
						}
						dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
						dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[4] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[6] = 0;
							dr[7] = 0;
						}
						else
						{
							dr[4] = 0;
							dr[5] = 0;
							dr[6] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
						}
						dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
						dr[9] = 0;
						dr[10] = 0;
						dr[11] = 0;
						dr[12] = 0;
						dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
						if ((Operators.CompareString(FormMainBook, "MFG FILE ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG FILE2 ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH ISU", false) == 0))
						{
							dr[19] = "Y";
						}
						else if ((Operators.CompareString(FormMainBook, "MFG FILE REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG FILE2 REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG PREP REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH REC", false) == 0))
						{
							dr[19] = "Y";
						}
						else if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
						{
							dr[19] = "N";
						}
						else if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[19] = "Y";
						}
						else
						{
							dr[19] = "N";
						}
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
						dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						DtIdtl.Rows.Add(dr);
						DC_Main.i++;
					}
					MsgOldRow = 0;
					CommPassTotal();
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	private void Asmbl_Rec(int CurRow)
	{
		//IL_03bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		checked
		{
			if (((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 29], false) != 0)) | (Conversion.Val(mSG[mSG.Row, 58]) != Conversion.Val(mSG[mSG.Row, 59])))
			{
				DC_Main.i = CurRow;
				int num = mSG.Rows - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num)
				{
					if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 29], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 58]) == Conversion.Val(MSG[DC_Main.i, 59])) & (CurRow != DC_Main.X))
					{
						Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
						mSG[CurRow, 2] = "";
						mSG[CurRow, 1] = "";
						mSG[CurRow, 4] = "";
						mSG[CurRow, 51] = "";
						mSG[CurRow, 11] = "";
						mSG[CurRow, 13] = "";
						mSG[CurRow, 28] = "";
						mSG[CurRow, 66] = "";
						mSG[CurRow, 67] = "";
						mSG[CurRow, 68] = "";
						mSG[CurRow, 65] = "";
						mSG[CurRow, 70] = "";
						mSG[CurRow, 71] = "";
						mSG[CurRow, 55] = "";
						mSG[CurRow, 56] = "";
						mSG[CurRow, 57] = "";
						mSG[CurRow, 58] = "";
						mSG[CurRow, 59] = "";
						return;
					}
					DC_Main.X++;
				}
				string text = "";
				string text2 = "";
				string text3 = "";
				int num2 = 0;
				DC_Main.RsQry = "SELECT ROW_NUMBER() OVER (ORDER BY A.LOT_NO,B.IT_NAME) AS SrNoM,A.LOT_NO As LotNoL,A.IT_CODE As ItCodeL,B.IT_NAME As ItNameL,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)As IsPcsM,SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END)As RcPcsM,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT+(ITM_GWT-ITM_NWT) ELSE 0 END)As IsuWtW,SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) As RecWtW,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT+(ITM_GWT-ITM_NWT) ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.REC_YRCD As MfgYearL,A.IR_DBCD As MfgDbCdL,A.IR_NO As MfgNoL,A.IR_SRNO As MfgSrNo  FROM MFG_ISU_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE And A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "'  AND A.LOT_NO <> '' AND A.IR_TYPE IN ('" + LastPorcess + "')  GROUP BY A.LOT_NO,A.IT_CODE,B.IT_NAME,A.IT_CODE,A.IR_YRCD,A.IR_DBCD,A.IR_NO,A.IR_SRNO HAVING SUM(CASE WHEN ITM_SIGN = '-' THEN IR_WT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN (IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS) ELSE 0 END) > 0 ORDER BY A.LOT_NO DESC,B.IT_NAME ";
				DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.ColWidth = new double[15];
				DC_Main.ColWidth[0] = 70.0;
				DC_Main.ColWidth[1] = 90.0;
				DC_Main.ColWidth[2] = 80.0;
				DC_Main.ColWidth[3] = 150.0;
				DC_Main.ColWidth[4] = 70.0;
				DC_Main.ColWidth[5] = 70.0;
				DC_Main.ColWidth[6] = 90.0;
				DC_Main.ColWidth[7] = 90.0;
				DC_Main.ColWidth[8] = 90.0;
				DC_Main.ColWidth[9] = 80.0;
				DC_Main.ColWidth[10] = 0.0;
				DC_Main.ColWidth[11] = 0.0;
				DC_Main.ColWidth[12] = 0.0;
				DC_Main.ColWidth[13] = 0.0;
				DC_Main.HelpSelect = 0;
				((Form)MyProject.Forms.MS_HELP).ShowDialog();
				if (DC_Main.HelpClose)
				{
					return;
				}
				if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[1];
					mSG[CurRow, 29] = DC_Main.ColValue[1];
					mSG[CurRow, 1] = DC_Main.ColValue[2];
					mSG[CurRow, 2] = DC_Main.ColValue[3];
					if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
					{
						mSG[mSG.Row, 10] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[4]) - Conversion.Val(DC_Main.ColValue[5])), "0");
					}
					mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[mSG.Row, 31] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
					mSG[CurRow, 56] = DC_Main.ColValue[10];
					mSG[CurRow, 57] = DC_Main.ColValue[11];
					mSG[CurRow, 55] = DC_Main.ColValue[12];
					mSG[CurRow, 58] = DC_Main.ColValue[13];
					mSG[CurRow, 59] = DC_Main.ColValue[13];
					mSG[CurRow, 73] = DC_Main.MCo_year;
					mSG[CurRow, 74] = DC_Main.MCo_Book;
					mSG[CurRow, 72] = tVchNo.Text;
					mSG[CurRow, 75] = Conversions.ToString(Conversion.Val(mSG[CurRow, 42]));
					DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM MFG_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ORD_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count > 0)
					{
						mSG[CurRow, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
						mSG[CurRow, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_PCS"], (object)"")), "0");
						mSG[CurRow, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_GWT"], (object)"")), "0.000");
						mSG[CurRow, 36] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_OTH_WT"], (object)"")), "0.000");
						mSG[CurRow, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NWT"], (object)"")), "0.000");
						mSG[CurRow, 65] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_NO"], (object)""));
						mSG[CurRow, 66] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_YRCD"], (object)""));
						mSG[CurRow, 67] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_DBCD"], (object)""));
						mSG[CurRow, 68] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_SRNO"], (object)""));
						mSG[CurRow, 71] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["AC_NAME"], (object)""));
						mSG[CurRow, 70] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ORD_AC_CODE"], (object)""));
					}
					int num3 = 0;
					int num4 = DtIdtl.Rows.Count - 1;
					int num5 = num4;
					for (int i = 0; i <= num5; i++)
					{
						if (Operators.ConditionalCompareObjectEqual(DtIdtl.Rows[num3][22], (object)Conversion.Val(mSG[DC_Main.i, 42]), false))
						{
							DtIdtl.Rows[num3].Delete();
							DtIdtl.AcceptChanges();
							num3--;
						}
						num3++;
					}
					MSG_IDTL_CLEAR();
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[CurRow, 56] + "' AND CO_BOOK = '" + mSG[CurRow, 57] + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[CurRow, 58])) + " AND VCH_NO = '" + mSG[CurRow, 55] + "' ";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					while (DC_Main.i < DC_Main.Rshlp.Rows.Count)
					{
						dr = DtIdtl.NewRow();
						dr[22] = Conversion.Val(MSG[CurRow, 42]);
						dr[0] = DC_Main.i + 1;
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[1] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["ITM_LOT"], (object)"");
						}
						else
						{
							dr[1] = "";
						}
						dr[2] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CODE"], (object)"");
						dr[3] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NAME"], (object)"");
						if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[4] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
							dr[6] = 0;
							dr[7] = 0;
						}
						else
						{
							dr[4] = 0;
							dr[5] = 0;
							dr[6] = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_PCS"]);
							dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_GWT"])), "0.000");
						}
						dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
						dr[9] = 0;
						dr[10] = 0;
						dr[11] = 0;
						dr[12] = 0;
						dr[13] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
						dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_RATE"])), "0.00");
						dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_AMT"])), "0.00");
						dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
						dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
						dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
						if ((Operators.CompareString(FormMainBook, "MFG FILE ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG FILE2 ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH ISU", false) == 0))
						{
							dr[19] = "Y";
						}
						else if ((Operators.CompareString(FormMainBook, "MFG FILE REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG FILE2 REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG PREP REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG POLISH REC", false) == 0))
						{
							dr[19] = "Y";
						}
						else if (Operators.CompareString(FormMainBook, "MFG STNG ISU", false) == 0)
						{
							dr[19] = "N";
						}
						else if (Operators.CompareString(FormMainBook, "MFG STNG REC", false) == 0)
						{
							dr[19] = "Y";
						}
						else
						{
							dr[19] = "N";
						}
						dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
						dr[21] = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["IT_TYPE"], (object)"");
						DtIdtl.Rows.Add(dr);
						DC_Main.i++;
					}
					MsgOldRow = 0;
					CommPassTotal();
					MSG_RowColChange(MSG, new EventArgs());
					MSG_TOT_FILL();
					((Control)TEXT_ENTRY).Focus();
					return;
				}
				mSG[CurRow, 2] = "";
				mSG[CurRow, 1] = "";
				mSG[CurRow, 4] = "";
				mSG[CurRow, 51] = "";
				mSG[CurRow, 11] = "";
				mSG[CurRow, 13] = "";
				mSG[CurRow, 28] = "";
				mSG[CurRow, 66] = "";
				mSG[CurRow, 67] = "";
				mSG[CurRow, 68] = "";
				mSG[CurRow, 65] = "";
				mSG[CurRow, 70] = "";
				mSG[CurRow, 71] = "";
				mSG[CurRow, 55] = "";
				mSG[CurRow, 56] = "";
				mSG[CurRow, 57] = "";
				mSG[CurRow, 58] = "";
				mSG[CurRow, 59] = "";
			}
			mSG = null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void Setting_Rec_ItmLot(int CurRow)
	{
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		DC_Main.RsQry = "Select A.ITM_LOT,A.IT_CODE,B.IT_NAME,SUM(Case When ITM_SIGN = '+' THEN IR_PCS ELSE -IR_PCS END) As ItmPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) As NetWt FROM MFG_ISU_REC AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '" + TEXT_ENTRY.Text + "' AND ITM_LOT <> '' AND BOOK_NAME = 'MFG STNG ISU' GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE -IR_PCS END) > 0";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.ITM_LOT As TagLotL,C.RecIt As RecItL,B.IT_NAME As ItNameL,SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)As IsPcsM,SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END)As RcPcsM,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_GWT ELSE 0 END)As IsuWtW,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE 0 END) As RecWtW,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_GWT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE 0 END) As DifWtW,A.IT_CODE As IsuItL,A.IR_YRCD As MfgYearL,A.IR_DBCD As MfgDbCdL,A.IR_NO As MfgNoL,A.IR_SRNO As MfgSrNo,SUM(CASE WHEN ITM_SIGN = '-' THEN ITM_NWT ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE 0 END) As DifNwtW  FROM (MFG_ISU_REC AS A INNER JOIN(SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISU_IT_CODE As RecIt FROM MFG_DETL) AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO AND A.SR_NO = C.SR_NO)LEFT JOIN ITEM_MAST AS B ON C.CO_CODE = B.CO_CODE And C.RecIt = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_AC_CODE = '" + tAcCode.Text + "' AND A.AC_CODE = '" + tAcCode.Text + "'  AND A.ITM_LOT <> '' AND A.IR_TYPE IN ('" + LastPorcess + "')  GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME,C.RecIt,A.IR_YRCD,A.IR_DBCD,A.IR_NO,A.IR_SRNO HAVING SUM(CASE WHEN ITM_SIGN = '-' THEN IR_PCS ELSE 0 END)-SUM(CASE WHEN ITM_SIGN = '+' THEN IR_PCS ELSE 0 END) > 0 ORDER BY A.ITM_LOT DESC,B.IT_NAME ";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[15];
			DC_Main.ColWidth[0] = 120.0;
			DC_Main.ColWidth[1] = 80.0;
			DC_Main.ColWidth[2] = 150.0;
			DC_Main.ColWidth[3] = 90.0;
			DC_Main.ColWidth[4] = 90.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.ColWidth[6] = 100.0;
			DC_Main.ColWidth[7] = 100.0;
			DC_Main.ColWidth[8] = 80.0;
			DC_Main.ColWidth[9] = 0.0;
			DC_Main.ColWidth[10] = 0.0;
			DC_Main.ColWidth[11] = 0.0;
			DC_Main.ColWidth[12] = 0.0;
			DC_Main.ColWidth[13] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				TEXT_ENTRY.Text = DC_Main.ColValue[0];
				mSG[mSG.Row, 30] = DC_Main.ColValue[0];
				mSG[mSG.Row, 2] = DC_Main.ColValue[2];
				mSG[mSG.Row, 1] = DC_Main.ColValue[1];
				if (Operators.CompareString(FormBookInOut, "O", false) == 0)
				{
					mSG[mSG.Row, 33] = DC_Main.ColValue[1];
				}
				else
				{
					mSG[mSG.Row, 33] = DC_Main.ColValue[8];
				}
				mSG[mSG.Row, 56] = DC_Main.ColValue[9];
				mSG[mSG.Row, 57] = DC_Main.ColValue[10];
				mSG[mSG.Row, 55] = DC_Main.ColValue[11];
				mSG[mSG.Row, 58] = DC_Main.ColValue[12];
				if (Conversion.Val(DC_Main.ColValue[3]) != 0.0)
				{
					mSG[mSG.Row, 34] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[3]) - Conversion.Val(DC_Main.ColValue[4])), "0");
				}
				mSG[mSG.Row, 35] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
				mSG[mSG.Row, 37] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[13]), "0.000");
				if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
				{
					mSG[mSG.Row, 10] = Strings.Format((object)(Conversion.Val(DC_Main.ColValue[3]) - Conversion.Val(DC_Main.ColValue[4])), "0");
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				MSG_TOT_FILL();
				ImageName();
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				}
				else
				{
					PicImage.Image = null;
				}
				((Control)TEXT_ENTRY).Focus();
			}
			else
			{
				mSG[mSG.Row, 30] = "";
				TEXT_ENTRY.Text = "";
				((Control)TEXT_ENTRY).Focus();
			}
		}
		else
		{
			mSG[mSG.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_LOT"], (object)""));
			mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
			mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
			mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ItmPcs"], (object)"")), "0");
			mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GrWt"], (object)"")), "0.000");
			mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NetWt"], (object)"")), "0.000");
			mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 11]) - Conversion.Val(mSG[mSG.Row, 13])), "0.000");
			mSG[mSG.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
			mSG[mSG.Row, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ItmPcs"], (object)"")), "0");
			mSG[mSG.Row, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GrWt"], (object)"")), "0.000");
			mSG[mSG.Row, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NetWt"], (object)"")), "0.000");
			mSG = null;
		}
	}

	private void ItemLotIsu(int CurRow)
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		AxMSFlexGrid mSG = MSG;
		DC_Main.RsQry = "SELECT A.ITM_LOT,A.IT_CODE,B.IT_NAME,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As ItmPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWt,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) As NetWt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_LOT = '" + TEXT_ENTRY.Text + "' AND ITM_LOT <> '' AND TAG_NO = 'N'  GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) > 0";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT A.ITM_LOT As ItmLotL,A.IT_CODE as ItCodeL,B.IT_NAME As ItemNameL,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_PCS ELSE -ITM_PCS END) As ItmPcs,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) As GrWtW,SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) As NetWtW  FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ITM_LOT <> '' AND TAG_NO = 'N'  GROUP BY A.ITM_LOT,A.IT_CODE,B.IT_NAME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_GWT ELSE -ITM_GWT END) > 0 ORDER BY A.ITM_LOT,B.IT_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 120.0;
			DC_Main.ColWidth[1] = 120.0;
			DC_Main.ColWidth[2] = 300.0;
			DC_Main.ColWidth[3] = 100.0;
			DC_Main.ColWidth[4] = 125.0;
			DC_Main.ColWidth[5] = 125.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (DC_Main.HelpClose)
			{
				return;
			}
			if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				TEXT_ENTRY.Text = DC_Main.ColValue[0];
				mSG[mSG.Row, 30] = DC_Main.ColValue[0];
				mSG[mSG.Row, 2] = DC_Main.ColValue[2];
				mSG[mSG.Row, 1] = DC_Main.ColValue[1];
				if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
				{
					mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0");
				}
				mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[4]), "0.000");
				mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
				mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 11]) - Conversion.Val(mSG[mSG.Row, 13])), "0.000");
				mSG[mSG.Row, 33] = DC_Main.ColValue[1];
				if (Conversion.Val(DC_Main.ColValue[4]) != 0.0)
				{
					mSG[mSG.Row, 34] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[3]), "0");
				}
				mSG[mSG.Row, 35] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[4]), "0.000");
				mSG[mSG.Row, 37] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[5]), "0.000");
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				MSG_TOT_FILL();
				return;
			}
		}
		else
		{
			mSG[mSG.Row, 30] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_LOT"], (object)""));
			mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
			mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
			mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ItmPcs"], (object)"")), "0");
			mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GrWt"], (object)"")), "0.000");
			mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NetWt"], (object)"")), "0.000");
			mSG[mSG.Row, 12] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 11]) - Conversion.Val(mSG[mSG.Row, 13])), "0.000");
			mSG[mSG.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
			mSG[mSG.Row, 34] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ItmPcs"], (object)"")), "0");
			mSG[mSG.Row, 35] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["GrWt"], (object)"")), "0.000");
			mSG[mSG.Row, 37] = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["NetWt"], (object)"")), "0.000");
		}
		mSG = null;
	}

	private void TR_MFG_ITEM_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d99: Expected O, but got Unknown
		//IL_0dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcd: Expected O, but got Unknown
		//IL_0e0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e1b: Expected O, but got Unknown
		//IL_0e35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e44: Expected O, but got Unknown
		//IL_0e5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e6d: Expected O, but got Unknown
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9c: Expected O, but got Unknown
		//IL_0f7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8c: Expected O, but got Unknown
		//IL_1014: Unknown result type (might be due to invalid IL or missing references)
		//IL_1019: Unknown result type (might be due to invalid IL or missing references)
		//IL_1023: Expected O, but got Unknown
		//IL_10bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c7: Expected O, but got Unknown
		//IL_1151: Unknown result type (might be due to invalid IL or missing references)
		//IL_1156: Unknown result type (might be due to invalid IL or missing references)
		//IL_1160: Expected O, but got Unknown
		//IL_1185: Unknown result type (might be due to invalid IL or missing references)
		//IL_118a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1194: Expected O, but got Unknown
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
				((TextBoxBase)TEXT_ENTRY_2).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				((Control)TEXT_ENTRY_2).Font = new Font(((Control)TEXT_ENTRY_2).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY_2).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG2_TOTAL.Font = new Font("Segoe UI Semibold", (float)num3, MSG2_TOTAL.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
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
				num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
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
			if ((Operators.CompareString(FormMainBook, "MFG CAST ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG CAST REC", false) == 0))
			{
				DC_Main.RsQry = "SELECT * FROM MENU_DATA WHERE BTN_NAME = 'Mfg' AND SM_MAIN_NAME = 'Wex Rec' AND SM_VIEW = 'Y'";
				DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 0)
				{
					WaxProcess = "Y";
				}
				else
				{
					WaxProcess = "N";
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
		((TextBoxBase)tVchNo).ReadOnly = true;
		OldValTot = 0.0;
		NewValTot = 0.0;
		RecAdjAmt = 0.0;
		VpAdjAmt = 0.0;
		UsUPdate = "N";
		UsDelete = "N";
		OrdGold = 0.0;
		OrdSilver = 0.0;
		TotDrFine = 0.0;
		OldAcCode = "";
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
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		((Control)TEXT_IDTL).Visible = false;
		((Control)TEXT_ENTRY_2).Visible = false;
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
			if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
			{
				tEmpCode.Text = DC_Main.MsUserEmpCode;
				tEmpName.Text = DC_Main.MsUserEmpName;
			}
			DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
			DC_Main.RsQry = "SELECT SM_CODE,ENTRY_TYPE,NEXT_TRAN,LAST_TRAN,STK_ISU,STK_REC FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				LastPorcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["LAST_TRAN"]);
				CurProcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["ENTRY_TYPE"]);
				MsPorcessType = Conversions.ToString(DC_Main.Tbl.Rows[0]["ENTRY_TYPE"]);
				NextProcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["NEXT_TRAN"]);
				StkLess = Conversions.ToString(DC_Main.Tbl.Rows[0]["STK_ISU"]);
				StkAdd = Conversions.ToString(DC_Main.Tbl.Rows[0]["STK_REC"]);
				TranCode = Conversions.ToString(DC_Main.Tbl.Rows[0]["SM_CODE"]);
			}
			EntryMode = "A";
			((Control)BtnSave).Enabled = true;
			((Control)tVchNo).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "Select * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[6, 3] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[4, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[4, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[4, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[4, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,C.AC_NAME As OrdAcName FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.ORD_AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LOT_NO"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DESIGN_SRNO"])), "0");
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_JDT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_WAX_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["RTN_GHIS"])), "0.000");
					if (mSG[9] > 0)
					{
						mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["RTN_CHOL"])), "0.000");
					}
					else
					{
						mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["RTN_CHOL"])), "0.000");
					}
					mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["MTRL_IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MTRL_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ADD_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 23] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 56] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 55] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_NO"], (object)""));
					mSG[DC_Main.i + 1, 58] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["REP_SRNO"])), "0");
					mSG[DC_Main.i + 1, 73] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REC_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 74] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REC_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 72] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REC_NO"], (object)""));
					mSG[DC_Main.i + 1, 75] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["REC_SRNO"])), "0");
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ORD_PCS"]);
					mSG[DC_Main.i + 1, 35] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ORD_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 36] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ORD_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ORD_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 66] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 67] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 68] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ORD_SRNO"])), "0");
					mSG[DC_Main.i + 1, 69] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ORD_SRNO"])), "0");
					mSG[DC_Main.i + 1, 70] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 71] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OrdAcName"], (object)""));
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DM_PCS"])), "0");
					mSG[DC_Main.i + 1, 61] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DM_WT"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 46] = "E";
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM MFG_IDTL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO,A.ISR_NO";
				RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				while (DC_Main.i < RsIdtl.Rows.Count)
				{
					dr = DtIdtl.NewRow();
					dr[22] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["SR_NO"]);
					dr[0] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ISR_NO"]);
					dr[1] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["ITM_LOT"], (object)"");
					dr[2] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_CODE"], (object)"");
					dr[3] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_NAME"], (object)"");
					dr[4] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ORD_PCS"]);
					dr[5] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["ORD_WT"])), "0.000");
					dr[6] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_PCS"]);
					dr[7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_GWT"])), "0.000");
					dr[8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_PRC"])), "0.00");
					dr[9] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["RTN_PCS"]);
					dr[10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["RTN_GWT"])), "0.000");
					dr[11] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["BROK_PCS"]);
					dr[12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["BROK_WT"])), "0.000");
					dr[13] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_RATE_TYPE"], (object)"");
					dr[14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_RATE"])), "0.00");
					dr[15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_AMT"])), "0.00");
					dr[16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_RATE"])), "0.00");
					dr[17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_LBR_AMT"])), "0.00");
					dr[18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_NET_AMT"])), "0.00");
					dr[19] = RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["OLD_ITM_ISU"]);
					dr[20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIdtl.Rows[DC_Main.i]["IT_CON_WT"])), "0.000");
					dr[21] = Operators.ConcatenateObject(RsIdtl.Rows[DC_Main.i]["IT_TYPE"], (object)"");
					DtIdtl.Rows.Add(dr);
					DC_Main.i++;
				}
				Module_Save.ExeQuteDcSave("DELETE FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
				DC_Main.RsQry = "SELECT * FROM ITM_LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
				DataTable dataTable = Module_Save.OpenRecordSetDcSave(DC_Main.RsQry, Module_Save.PurcTran);
				Module_Save.MsInsertDataSave(Module_Save.PurcTran);
				DataRow dataRow2 = dataTable.NewRow();
				int num3 = MSG.Rows - 1;
				DC_Main.i = 1;
				while (DC_Main.i <= num3)
				{
					AxMSFlexGrid mSG2 = MSG;
					if ((Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0) & (Operators.CompareString(mSG2[DC_Main.i, 3], "", false) != 0) & (Conversion.Val(mSG2[DC_Main.i, 11]) != 0.0))
					{
						dataRow2["CO_CODE"] = DC_Main.MCo_code;
						dataRow2["LC_CODE"] = DC_Main.MLc_code;
						dataRow2["CO_YEAR"] = DC_Main.MCo_year;
						dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
						dataRow2["VCH_NO"] = tVchNo.Text;
						dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
						dataRow2["VCH_DATE"] = mVchDate.Text;
						if (Operators.CompareString(mSG2[DC_Main.i, 46], "E", false) != 0)
						{
							dataRow2["STK_DATE"] = mVchDate.Text;
						}
						else
						{
							dataRow2["STK_DATE"] = mVchDate.Text;
						}
						dataRow2["LBR_PRC"] = 0;
						dataRow2["VCH_TYPE"] = FormBookSname;
						dataRow2["INOUT_TYPE"] = FormBookInOut;
						dataRow2["ENTRY_TYPE"] = "P";
						dataRow2["BOOK_NAME"] = FormMainBook;
						dataRow2["SR_NO"] = Conversion.Val(mSG2[DC_Main.i, 0]);
						dataRow2["IT_CODE"] = mSG2[DC_Main.i, 1];
						dataRow2["LOT_NO"] = mSG2[DC_Main.i, 3];
						dataRow2["TBL_CODE"] = "001";
						dataRow2["DESIGN_NO"] = mSG2[DC_Main.i, 4];
						dataRow2["ITM_SIZE"] = "";
						dataRow2["ITM_PCS"] = Conversion.Val(mSG2[DC_Main.i, 10]);
						dataRow2["ITM_GWT"] = Conversion.Val(mSG2[DC_Main.i, 11]);
						dataRow2["ITM_OTH_WT"] = Conversion.Val(mSG2[DC_Main.i, 12]);
						dataRow2["ITM_NWT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
						dataRow2["ITM_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 14]);
						dataRow2["ITM_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 15]);
						dataRow2["ITM_FINE"] = Conversion.Val(mSG2[DC_Main.i, 16]);
						dataRow2["KR_NET_WT"] = Conversion.Val(mSG2[DC_Main.i, 13]);
						dataRow2["KR_TOUCH"] = Conversion.Val(mSG2[DC_Main.i, 14]);
						dataRow2["KR_WEST_PRC"] = Conversion.Val(mSG2[DC_Main.i, 15]);
						dataRow2["KR_FINE"] = Conversion.Val(mSG2[DC_Main.i, 16]);
						dataRow2["LBR_PRC"] = 0;
						dataRow2["LBR_TYPE"] = "G";
						dataRow2["LBR_RATE"] = 0;
						dataRow2["LBR_AMT"] = 0;
						dataRow2["OTH_AMT"] = 0;
						dataRow2["ITM_RATE"] = 0;
						dataRow2["ITM_AMT"] = 0;
						dataRow2["ITM_REMARK"] = mSG2[DC_Main.i, 2];
						dataRow2["KR_CODE"] = "";
						dataRow2["IT_TYPE"] = mSG2[DC_Main.i, 63];
						dataRow2["PR_CODE"] = mSG2[DC_Main.i, 62];
						dataRow2["DATA_TRFR"] = "N";
						dataRow2["DATA_TYPE"] = "A";
						dataRow2["DESIGN_IMG_ID"] = "N";
						dataRow2["MAIN_USER"] = MainUser;
						dataTable.Rows.Add(dataRow2);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
						dataTable.Clear();
					}
					mSG2 = null;
					DC_Main.i++;
				}
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				ImageName();
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				}
				else
				{
					PicImage.Image = null;
				}
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 26]) + Conversion.Val(MSG_TOT[0, 25]);
				NewValTot = Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 26]) + Conversion.Val(MSG_TOT[0, 25]);
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

	private void TR_MFG_ITEM_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_MFG_ITEM_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0290: Unknown result type (might be due to invalid IL or missing references)
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_0484: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[4, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[4, 4], "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
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
			DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(MSG_TOT[0, 10]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 27]) + Conversion.Val(MSG2_TOTAL[5, 3]) + Conversion.Val(MSG_TOT[0, 7]) + Conversion.Val(MSG_TOT[0, 35]) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsData.NewRow();
			dataRow2["CO_CODE"] = DC_Main.MCo_code;
			dataRow2["LC_CODE"] = DC_Main.MLc_code;
			dataRow2["CO_YEAR"] = DC_Main.MCo_year;
			dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow2["VCH_NO"] = tVchNo.Text;
			dataRow2["VCH_DATE"] = mVchDate.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["KR_CODE"] = tAcCode.Text;
			dataRow2["BILL_NO"] = tVchNo.Text;
			dataRow2["BILL_DATE"] = mVchDate.Text;
			dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow2["VCH_TYPE"] = FormBookSname;
			dataRow2["INOUT_TYPE"] = FormBookInOut;
			dataRow2["ENTRY_TYPE"] = MsPorcessType;
			dataRow2["BOOK_NAME"] = FormMainBook;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
			dataRow2["TAX_CODE"] = "";
			dataRow2["TAX_PRC"] = 0;
			dataRow2["TAX_AMT"] = 0;
			dataRow2["AC_GST_TYPE"] = "L";
			dataRow2["IGST_TAX"] = 0;
			dataRow2["SGST_TAX"] = 0;
			dataRow2["CGST_TAX"] = 0;
			dataRow2["GR_WT"] = Conversion.Val(MSG_TOT[0, 11]);
			dataRow2["NET_WT"] = Conversion.Val(MSG_TOT[0, 13]);
			dataRow2["FINE_WT"] = Conversion.Val(MSG_TOT[0, 16]);
			dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 25]);
			dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 26]);
			dataRow2["ROF_AMT"] = 0;
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["CARD_AMT"] = 0;
			dataRow2["CARD_AC"] = "";
			dataRow2["BANK_AC"] = MSG2_TOTAL[4, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[4, 2];
			dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["DATA_TRFR"] = "N";
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		DC_Main.RsQry = "SELECT * FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				if ((Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 11]) + Conversion.Val(mSG[DC_Main.i, 25]) + Conversion.Val(mSG[DC_Main.i, 26]) + Conversion.Val(mSG[DC_Main.i, 7]) + Conversion.Val(mSG[DC_Main.i, 35]) != 0.0))
				{
					dataRow3["CO_CODE"] = DC_Main.MCo_code;
					dataRow3["LC_CODE"] = DC_Main.MLc_code;
					dataRow3["CO_YEAR"] = DC_Main.MCo_year;
					dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow3["VCH_NO"] = tVchNo.Text;
					dataRow3["VCH_DATE"] = mVchDate.Text;
					dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow3["AC_CODE"] = tAcCode.Text;
					dataRow3["KR_CODE"] = tAcCode.Text;
					dataRow3["VCH_TYPE"] = FormBookSname;
					dataRow3["INOUT_TYPE"] = FormBookInOut;
					dataRow3["ENTRY_TYPE"] = MsPorcessType;
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 42]);
					dataRow3["IT_CODE"] = mSG[DC_Main.i, 1];
					dataRow3["ISU_IT_CODE"] = mSG[DC_Main.i, 33];
					dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 51];
					dataRow3["TAG_NO"] = mSG[DC_Main.i, 3];
					dataRow3["LOT_NO"] = mSG[DC_Main.i, 30];
					dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
					dataRow3["DESIGN_SRNO"] = Conversion.Val(mSG[DC_Main.i, 52]);
					dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 5];
					dataRow3["KR_JDT_WT"] = Conversion.Val(mSG[DC_Main.i, 6]);
					dataRow3["KR_WAX_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 10]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 11]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 12]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 20]);
					dataRow3["RTN_GHIS"] = Conversion.Val(mSG[DC_Main.i, 22]);
					if (Conversion.Val(mSG[DC_Main.i, 9]) != 0.0)
					{
						dataRow3["RTN_CHOL"] = Conversion.Val(mSG[DC_Main.i, 9]);
					}
					else
					{
						dataRow3["RTN_CHOL"] = Conversion.Val(mSG[DC_Main.i, 21]);
					}
					dataRow3["MTRL_IT_CODE"] = mSG[DC_Main.i, 17];
					dataRow3["MTRL_WT"] = Conversion.Val(mSG[DC_Main.i, 18]);
					dataRow3["ADD_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 8]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 15]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 16]);
					dataRow3["KR_GHAT_WT"] = 0;
					dataRow3["KR_KUNDAN_WT"] = 0;
					dataRow3["FTNG_NWT"] = 0;
					dataRow3["FTNG_TOUCH"] = 0;
					dataRow3["FTNG_FINE"] = 0;
					dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 23];
					dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 24]);
					dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 26]);
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 43]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 44]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 27]);
					dataRow3["DM_PCS"] = Conversion.Val(mSG[DC_Main.i, 60]);
					dataRow3["DM_WT"] = Conversion.Val(mSG[DC_Main.i, 61]);
					dataRow3["OLD_GWT"] = 0;
					dataRow3["OLD_NWT"] = 0;
					dataRow3["OLD_FINE"] = 0;
					dataRow3["OLD_OTH"] = 0;
					dataRow3["OLD_LBR_AMT"] = 0;
					dataRow3["KR_NAME"] = mSG[DC_Main.i, 41];
					dataRow3["RATE_TYPE"] = "";
					dataRow3["IT_TYPE"] = "G";
					dataRow3["PR_CODE"] = "";
					dataRow3["VCH_SRNO"] = 0;
					dataRow3["REP_ADJ"] = "N";
					dataRow3["REP_YRCD"] = mSG[DC_Main.i, 56];
					dataRow3["REP_DBCD"] = mSG[DC_Main.i, 57];
					dataRow3["REP_NO"] = mSG[DC_Main.i, 55];
					dataRow3["REP_SRNO"] = Conversion.Val(mSG[DC_Main.i, 58]);
					dataRow3["REP_AC_CODE"] = "";
					dataRow3["ORD_PCS"] = Conversion.Val(mSG[DC_Main.i, 34]);
					dataRow3["ORD_GWT"] = Conversion.Val(mSG[DC_Main.i, 35]);
					dataRow3["ORD_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 36]);
					dataRow3["ORD_NWT"] = Conversion.Val(mSG[DC_Main.i, 37]);
					dataRow3["ORD_YRCD"] = mSG[DC_Main.i, 66];
					dataRow3["ORD_DBCD"] = mSG[DC_Main.i, 67];
					dataRow3["ORD_NO"] = mSG[DC_Main.i, 65];
					dataRow3["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 68]);
					dataRow3["ORD_AC_CODE"] = mSG[DC_Main.i, 70];
					dataRow3["REC_YRCD"] = mSG[DC_Main.i, 73];
					dataRow3["REC_DBCD"] = mSG[DC_Main.i, 74];
					dataRow3["REC_NO"] = mSG[DC_Main.i, 72];
					dataRow3["REC_SRNO"] = Conversion.Val(mSG[DC_Main.i, 75]);
					dataRow3["MAIN_USER"] = MainUser;
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			DC_Main.RsQry = "SELECT * FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsIdtl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow4 = RsIdtl.NewRow();
			int num2 = DtIdtl.Rows.Count - 1;
			for (int i = 0; i <= num2; i++)
			{
				DataTable dtIdtl = DtIdtl;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7])) + Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18])) != 0.0)
				{
					dataRow4["CO_CODE"] = DC_Main.MCo_code;
					dataRow4["LC_CODE"] = DC_Main.MLc_code;
					dataRow4["CO_YEAR"] = DC_Main.MCo_year;
					dataRow4["CO_BOOK"] = DC_Main.MCo_Book;
					dataRow4["VCH_NO"] = tVchNo.Text;
					dataRow4["HD_VCH_NO"] = tHdVchNo.Text;
					dataRow4["VCH_DATE"] = mVchDate.Text;
					dataRow4["AC_CODE"] = tAcCode.Text;
					dataRow4["KR_CODE"] = tAcCode.Text;
					dataRow4["VCH_TYPE"] = FormBookSname;
					dataRow4["INOUT_TYPE"] = FormBookInOut;
					dataRow4["ENTRY_TYPE"] = MsPorcessType;
					dataRow4["BOOK_NAME"] = FormMainBook;
					dataRow4["SR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]));
					dataRow4["TAG_NO"] = MSG[(int)Math.Round(Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][22]))), 3];
					dataRow4["VCH_SRNO"] = 0;
					dataRow4["ISR_NO"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][0]));
					dataRow4["ITM_LOT"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][1]);
					dataRow4["IT_CODE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][2]);
					dataRow4["ORD_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][4]));
					dataRow4["ORD_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][5]));
					dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]));
					dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
					dataRow4["IT_CON_PRC"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][8]));
					dataRow4["RTN_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][9]));
					dataRow4["RTN_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][10]));
					dataRow4["BROK_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][11]));
					dataRow4["BROK_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][12]));
					dataRow4["IT_PCS"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][6]));
					dataRow4["IT_GWT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][7]));
					dataRow4["IT_RATE_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][13]);
					dataRow4["IT_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][14]));
					dataRow4["IT_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][15]));
					dataRow4["IT_LBR_RATE"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][16]));
					dataRow4["IT_LBR_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][17]));
					dataRow4["IT_NET_AMT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][18]));
					dataRow4["OLD_ITM_ISU"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][19]);
					dataRow4["IT_CON_WT"] = Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][20]));
					dataRow4["IT_TYPE"] = RuntimeHelpers.GetObjectValue(DtIdtl.Rows[i][21]);
					dataRow4["MAIN_USER"] = MainUser;
					RsIdtl.Rows.Add(dataRow4);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsIdtl);
					RsIdtl.Clear();
				}
				dtIdtl = null;
			}
			DC_Main.RsQry = "DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			Module_Save.ExeQuteDcSave(DC_Main.RsQry, Module_Save.PurcTran);
			Ac_Stock.Itm_Mfg_Lot(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			Ac_Stock.Mfg_Itm_Isu_Rec_Stk(DC_Main.MCo_Book, tVchNo.Text);
			DC_Main.RsQry = "DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormBookInOut, "O", false) == 0)
			{
				Ac_Tax.Kr_Mfg_Itm_Isu(DC_Main.MCo_Book, tVchNo.Text);
			}
			if (Operators.CompareString(FormBookInOut, "I", false) == 0)
			{
				Ac_Tax.Kr_Mfg_Itm_Rec(DC_Main.MCo_Book, tVchNo.Text);
			}
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			if (Operators.CompareString(FormBookInOut, "O", false) == 0)
			{
				Ac_Ledr.Mfg_Kr_Item_Isu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			}
			if (Operators.CompareString(FormBookInOut, "I", false) == 0)
			{
				Ac_Ledr.Mfg_Kr_Item_Rec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
			}
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
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_05e5: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,0,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,0,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',0  FROM  (MFG_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Module_Save.ExeQuteDcSave("DELETE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'", Module_Save.PurcTran);
			DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_MFG_ITEM_KeyDown(object sender, KeyEventArgs e)
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
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JdtVch.RPT";
		Cr.SelectionFormula = "{MFG_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MFG_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {MFG_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MFG_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {MFG_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
		Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
		Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, "0.00")) ?? "";
		Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, "0.00")) ?? "";
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
	private void TR_MFG_ITEM_Activated(object sender, EventArgs e)
	{
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Expected O, but got Unknown
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
		if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
		{
			Image val = Image.FromFile(DC_Main.MsImagePath);
			PicImage.Image = (Image)new Bitmap(val);
			val.Dispose();
			CurActCtrl = (Control)(object)TEXT_ENTRY;
		}
		else
		{
			PicImage.Image = null;
		}
		if (Operators.CompareString(DC_Main.SSRegSrNo, "HM378NAPK", false) == 0)
		{
			DC_Main.ExeQuteDc("UPDATE MFG_DETL SET TAG_NO = DESIGN_NO WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO <> DESIGN_NO ");
		}
		((ContainerControl)this).ActiveControl = CurActCtrl;
		CurActCtrl.Focus();
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_NO AS RefNoL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,format(GR_WT,'0.000') AS GrWtW,format(NET_WT,'0.000') AS NetWtW FROM MFG_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[9];
		DC_Main.ColWidth[0] = 80.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 80.0;
		DC_Main.ColWidth[4] = 200.0;
		DC_Main.ColWidth[5] = 100.0;
		DC_Main.ColWidth[6] = 100.0;
		DC_Main.ColWidth[7] = 100.0;
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
		//IL_0848: Unknown result type (might be due to invalid IL or missing references)
		//IL_0852: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		int num6 = default(int);
		int num7 = default(int);
		Image image = default(Image);
		string address = default(string);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (MSG.Row == 0)
						{
							goto end_IL_0001;
						}
						goto IL_001b;
					case 2481:
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
							case 3:
								goto IL_001b;
							case 4:
								goto IL_0046;
							case 5:
								goto IL_0059;
							case 6:
								goto IL_0088;
							case 7:
								goto IL_00ae;
							case 8:
								goto IL_00e8;
							case 9:
								goto IL_0122;
							case 10:
								goto IL_015d;
							case 11:
								goto IL_0167;
							case 12:
								goto IL_016d;
							case 13:
								goto IL_018c;
							case 14:
								goto IL_01da;
							case 15:
								goto IL_01f3;
							case 16:
								goto IL_0222;
							case 17:
								goto IL_0251;
							case 18:
								goto IL_0280;
							case 19:
								goto IL_02af;
							case 20:
								goto IL_02de;
							case 21:
								goto IL_031c;
							case 22:
								goto IL_035a;
							case 23:
								goto IL_0393;
							case 24:
								goto IL_03c4;
							case 25:
								goto IL_03f5;
							case 26:
								goto IL_0426;
							case 27:
								goto IL_0457;
							case 28:
								goto IL_0488;
							case 29:
								goto IL_04b9;
							case 30:
								goto IL_04ea;
							case 31:
								goto IL_051b;
							case 32:
								goto IL_054c;
							case 33:
								goto IL_057d;
							case 34:
								goto IL_05ae;
							case 35:
								goto IL_05df;
							case 36:
								goto IL_0610;
							case 37:
								goto IL_0641;
							case 38:
								goto IL_065d;
							case 39:
							case 40:
								goto IL_0668;
							case 41:
								goto IL_067a;
							case 42:
								goto IL_06ba;
							case 43:
								goto IL_06c7;
							case 44:
								goto IL_070a;
							case 45:
								goto IL_071a;
							case 46:
								goto IL_073d;
							case 47:
								goto IL_0765;
							case 49:
								goto IL_077c;
							case 50:
								goto IL_079b;
							case 51:
								goto IL_07a4;
							case 52:
								goto IL_07b4;
							case 53:
								goto IL_07d0;
							case 55:
								goto IL_0814;
							case 54:
							case 56:
							case 57:
								goto IL_082e;
							case 48:
							case 58:
							case 59:
								goto IL_0854;
							case 60:
								goto end_IL_0001_3;
							default:
								goto end_IL_0001_2;
							case 2:
							case 61:
							case 62:
								goto end_IL_0001;
							}
							goto default;
						}
						IL_0641:
						num2 = 37;
						MSG_IDTL.Rows += 1;
						goto IL_065d;
						IL_065d:
						num2 = 38;
						num5++;
						goto IL_0668;
						IL_0610:
						num2 = 36;
						MSG_IDTL[num5, 22] = Conversions.ToString(DtIdtl.Rows[num6][22]);
						goto IL_0641;
						IL_0668:
						num2 = 40;
						num6++;
						goto IL_0671;
						IL_001b:
						num2 = 3;
						if (!((MsgOldRow != MSG.Row) & !MsgClear))
						{
							goto end_IL_0001;
						}
						goto IL_0046;
						IL_0046:
						num2 = 4;
						MsgOldRow = MSG.Row;
						goto IL_0059;
						IL_0059:
						num2 = 5;
						lblItem.Text = MSG[MSG.Row, 2] + " : It Name";
						goto IL_0088;
						IL_0088:
						num2 = 6;
						tItRemark.Text = MSG[MSG.Row, 51];
						goto IL_00ae;
						IL_00ae:
						num2 = 7;
						nPcs.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 34]), "0");
						goto IL_00e8;
						IL_00e8:
						num2 = 8;
						nitGwt.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 35]), "0.000");
						goto IL_0122;
						IL_0122:
						num2 = 9;
						nItNwt.Text = Strings.Format((object)Conversion.Val(MSG[MSG.Row, 37]), "0.000");
						goto IL_015d;
						IL_015d:
						num2 = 10;
						MSG_IDTL_CLEAR();
						goto IL_0167;
						IL_0167:
						num2 = 11;
						num5 = 1;
						goto IL_016d;
						IL_016d:
						num2 = 12;
						num7 = DtIdtl.Rows.Count - 1;
						num6 = 0;
						goto IL_0671;
						IL_0671:
						if (num6 <= num7)
						{
							goto IL_018c;
						}
						goto IL_067a;
						IL_067a:
						num2 = 41;
						DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 4];
						goto IL_06ba;
						IL_06ba:
						num2 = 42;
						DC_Main.MsImageType = "DhranImage";
						goto IL_06c7;
						IL_06c7:
						num2 = 43;
						DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
						goto IL_070a;
						IL_070a:
						num2 = 44;
						PicImage.Image = null;
						goto IL_071a;
						IL_071a:
						num2 = 45;
						if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
						{
							goto IL_073d;
						}
						goto IL_077c;
						IL_073d:
						num2 = 46;
						using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
						{
							image = Image.FromStream(stream);
						}
						goto IL_0765;
						IL_0765:
						num2 = 47;
						PicImage.Image = image;
						goto IL_0854;
						IL_077c:
						num2 = 49;
						if (Operators.CompareString(DC_Main.MsHttpPath, "", false) != 0)
						{
							goto IL_079b;
						}
						goto IL_0854;
						IL_079b:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_07a4;
						IL_07a4:
						num2 = 51;
						PicImage.Image = null;
						goto IL_07b4;
						IL_07b4:
						num2 = 52;
						if (Operators.CompareString(DC_Main.MsAppSchem, "Y", false) == 0)
						{
							goto IL_07d0;
						}
						goto IL_0814;
						IL_07d0:
						num2 = 53;
						address = DC_Main.MsHttpPath + "/" + DC_Main.MsImageType + "/" + DC_Main.MsImageNo + ".jpg";
						goto IL_082e;
						IL_0814:
						num2 = 55;
						address = DC_Main.MsHttpPath + DC_Main.MsImageNo + ".jpg";
						goto IL_082e;
						IL_082e:
						num2 = 57;
						PicImage.Image = (Image)new Bitmap((Stream)new MemoryStream(new WebClient().DownloadData(address)));
						goto IL_0854;
						IL_0854:
						num2 = 59;
						MSG_IDTL[num5, 0] = Conversions.ToString(num5);
						break;
						IL_018c:
						num2 = 13;
						if (Conversion.Val(MSG[MSG.Row, 42]) == Conversion.Val(RuntimeHelpers.GetObjectValue(DtIdtl.Rows[num6][22])))
						{
							goto IL_01da;
						}
						goto IL_0668;
						IL_01da:
						num2 = 14;
						MSG_IDTL[num5, 0] = Conversions.ToString(num5);
						goto IL_01f3;
						IL_01f3:
						num2 = 15;
						MSG_IDTL[num5, 1] = Conversions.ToString(DtIdtl.Rows[num6][1]);
						goto IL_0222;
						IL_0222:
						num2 = 16;
						MSG_IDTL[num5, 2] = Conversions.ToString(DtIdtl.Rows[num6][2]);
						goto IL_0251;
						IL_0251:
						num2 = 17;
						MSG_IDTL[num5, 3] = Conversions.ToString(DtIdtl.Rows[num6][3]);
						goto IL_0280;
						IL_0280:
						num2 = 18;
						MSG_IDTL[num5, 4] = Conversions.ToString(DtIdtl.Rows[num6][4]);
						goto IL_02af;
						IL_02af:
						num2 = 19;
						MSG_IDTL[num5, 5] = Conversions.ToString(DtIdtl.Rows[num6][5]);
						goto IL_02de;
						IL_02de:
						num2 = 20;
						MSG_IDTL[num5, 6] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[num6][6], (object)"")));
						goto IL_031c;
						IL_031c:
						num2 = 21;
						MSG_IDTL[num5, 7] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DtIdtl.Rows[num6][7], (object)"")));
						goto IL_035a;
						IL_035a:
						num2 = 22;
						MSG_IDTL[num5, 8] = Conversions.ToString(Operators.ConcatenateObject(DtIdtl.Rows[num6][8], (object)""));
						goto IL_0393;
						IL_0393:
						num2 = 23;
						MSG_IDTL[num5, 9] = Conversions.ToString(DtIdtl.Rows[num6][9]);
						goto IL_03c4;
						IL_03c4:
						num2 = 24;
						MSG_IDTL[num5, 10] = Conversions.ToString(DtIdtl.Rows[num6][10]);
						goto IL_03f5;
						IL_03f5:
						num2 = 25;
						MSG_IDTL[num5, 11] = Conversions.ToString(DtIdtl.Rows[num6][11]);
						goto IL_0426;
						IL_0426:
						num2 = 26;
						MSG_IDTL[num5, 12] = Conversions.ToString(DtIdtl.Rows[num6][12]);
						goto IL_0457;
						IL_0457:
						num2 = 27;
						MSG_IDTL[num5, 13] = Conversions.ToString(DtIdtl.Rows[num6][13]);
						goto IL_0488;
						IL_0488:
						num2 = 28;
						MSG_IDTL[num5, 14] = Conversions.ToString(DtIdtl.Rows[num6][14]);
						goto IL_04b9;
						IL_04b9:
						num2 = 29;
						MSG_IDTL[num5, 15] = Conversions.ToString(DtIdtl.Rows[num6][15]);
						goto IL_04ea;
						IL_04ea:
						num2 = 30;
						MSG_IDTL[num5, 16] = Conversions.ToString(DtIdtl.Rows[num6][16]);
						goto IL_051b;
						IL_051b:
						num2 = 31;
						MSG_IDTL[num5, 17] = Conversions.ToString(DtIdtl.Rows[num6][17]);
						goto IL_054c;
						IL_054c:
						num2 = 32;
						MSG_IDTL[num5, 18] = Conversions.ToString(DtIdtl.Rows[num6][18]);
						goto IL_057d;
						IL_057d:
						num2 = 33;
						MSG_IDTL[num5, 19] = Conversions.ToString(DtIdtl.Rows[num6][19]);
						goto IL_05ae;
						IL_05ae:
						num2 = 34;
						MSG_IDTL[num5, 20] = Conversions.ToString(DtIdtl.Rows[num6][20]);
						goto IL_05df;
						IL_05df:
						num2 = 35;
						MSG_IDTL[num5, 21] = Conversions.ToString(DtIdtl.Rows[num6][21]);
						goto IL_0610;
						end_IL_0001_3:
						break;
					}
					num2 = 60;
					MSG_IDTL[num5, 22] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 42]));
					break;
				}
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 2481;
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
				DC_Main.RsQry = "SELECT VCH_NO FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_MFG_ITEM_Closed(object sender, EventArgs e)
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

	private void tEmpCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "UPDATE MENU_DATA SET SM_VIEW = 'Y' WHERE BTN_NAME = 'Mfg' AND SM_MAIN_NAME = 'Mfg Mast'";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
			Application.Exit();
		}
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM MFG_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 8;
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
			mSG2_TOTAL[1] = 0;
			mSG2_TOTAL[2] = 0;
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
				case 6:
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
				case 3:
				case 4:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj7 = mSG2_TOTAL;
					object? obj8 = colorConverter.ConvertFromString("DarkBlue");
					obj7.CellForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					break;
				}
				case 5:
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
			while (DC_Main.i <= 6);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Tax Amt : ";
			mSG2_TOTAL[2, 0] = "Total Amt : ";
			mSG2_TOTAL[3, 0] = "Cash Amt : ";
			mSG2_TOTAL[4, 0] = "Cheque Amt : ";
			mSG2_TOTAL[5, 0] = "Ksr Amt : ";
			mSG2_TOTAL[6, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 6))
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
				if (mSG2_TOTAL.Row == 4)
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 6) | (mSG2_TOTAL.Row == 1))
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
					if (mSG2_TOTAL.Row == 4)
					{
						((TextBoxBase)TEXT_ENTRY_2).ReadOnly = true;
					}
				}
				else if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 2) | (mSG2_TOTAL.Row == 6))
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
			if (mSG2_TOTAL.Row == 4)
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
		//IL_0437: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
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
					if (mSG2_TOTAL.Row == 4 && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 4)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
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
		mSG2_TOTAL[0, 3] = Strings.Format((object)Conversion.Val(MSG_TOT[0, 27]), "0.00");
		mSG2_TOTAL[1, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0, 0), "0.00");
		mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) + Conversion.Val(mSG2_TOTAL[1, 3]), 0), "0.00");
		if (Conversion.Val(mSG2_TOTAL[0, 3]) != 0.0)
		{
			mSG2_TOTAL[6, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3])), "0.00");
		}
		if (CustOpAmt > 0.0)
		{
			CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[6, 3]);
		}
		else if (CustOpAmt < 0.0)
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[6, 3]) - Math.Abs(CustOpAmt);
		}
		else
		{
			CustClAmt = Conversion.Val(mSG2_TOTAL[6, 3]);
		}
		if (AcFineGl != 0.0)
		{
			if (CustOpGold > 0.0)
			{
				CustClGold = CustOpGold - AcFineGl;
			}
			else if (CustOpGold < 0.0)
			{
				CustClGold = 0.0 - (AcFineGl + Math.Abs(CustOpGold));
			}
			else
			{
				CustClGold = 0.0 - AcFineGl;
			}
		}
		else
		{
			CustClGold = CustOpGold;
		}
		if (AcFineSl != 0.0)
		{
			if (CustOpSilver > 0.0)
			{
				CustClSilver = CustOpSilver - AcFineSl;
			}
			else if (CustOpGold < 0.0)
			{
				CustClSilver = 0.0 - (AcFineSl + Math.Abs(CustOpSilver));
			}
			else
			{
				CustClSilver = 0.0 - AcFineSl;
			}
		}
		else
		{
			CustClSilver = CustOpSilver;
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

	private void tItRemark_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 10;
			MSG[MSG.Row, 51] = tItRemark.Text;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void TR_MFG_ITEM_KeyUp(object sender, KeyEventArgs e)
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

	private void ImageName()
	{
		DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 4];
		DC_Main.MsImageType = "DhranImage";
		DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0104: Unknown result type (might be due to invalid IL or missing references)
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
					ImageName();
					if (Operators.CompareString(DC_Main.MsImageNo, "", false) == 0)
					{
						Interaction.MsgBox((object)"Please Insert Design No and Try..", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
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
				case 268:
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
				try0001_dispatch = 268;
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
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		ImageName();
		if (Operators.CompareString(DC_Main.MsImageNo, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Design No and Try..", (MsgBoxStyle)0, (object)null);
			return;
		}
		((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
		((FileDialog)DlgOpen).Title = "Open Image File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() == 1)
		{
			if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
			{
				PicImage.Image.Dispose();
				PicImage.Image = null;
				FileSystem.Kill(DC_Main.MsImagePath);
			}
			PicImage.Image = Image.FromFile(((FileDialog)DlgOpen).FileName);
			PicImage.Image.Save(DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg");
			if (Operators.CompareString(DC_Main.MsUrlPath, "", false) != 0)
			{
				string ftpuri = DC_Main.MsUrlPath + DC_Main.MsImageNo + ".jpg";
				Ac_Image.FtpUploadFile(DC_Main.MsImagePath, ftpuri, DC_Main.MsUrlId, DC_Main.MsUrlPwd);
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Invalid comparison between Unknown and I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		Image image = default(Image);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					ImageName();
					goto IL_000b;
				case 297:
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
							goto IL_0014;
						case 4:
							goto IL_0030;
						case 5:
							goto IL_0052;
						case 6:
							goto IL_0079;
						case 7:
							goto IL_0089;
						case 8:
							goto IL_0097;
						case 9:
							goto end_IL_0001_2;
						case 13:
							num2 = 13;
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001_3;
						default:
							goto end_IL_0001;
						case 10:
						case 11:
						case 12:
						case 14:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0079:
					num2 = 6;
					PicImage.Image = image;
					goto IL_0089;
					IL_0089:
					num2 = 7;
					((Control)PicImage).Refresh();
					goto IL_0097;
					IL_0052:
					num2 = 5;
					using (Stream stream = File.OpenRead(DC_Main.MsImagePath))
					{
						image = Image.FromStream(stream);
					}
					goto IL_0079;
					IL_0097:
					num2 = 8;
					GC.Collect();
					break;
					IL_000b:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0014;
					IL_0014:
					num2 = 3;
					if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Image now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
					{
						goto end_IL_0001_3;
					}
					goto IL_0030;
					IL_0030:
					num2 = 4;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) == 0)
					{
						goto end_IL_0001_3;
					}
					goto IL_0052;
					end_IL_0001_2:
					break;
				}
				num2 = 9;
				FileSystem.Kill(DC_Main.MsImagePath);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 297;
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

	private void BtnTagPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.ExeQuteDc("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,VCH_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,'',ITM_SIZE,ITM_PCS,0,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  0,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,0,0,0,ITM_REMARK,'',KR_NAME,0,RATE_TYPE,'','','',  '','','','',0,0,0,0,''  FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + CurPrnVch + "'");
			DC_Main.RsQry = "SELECT * FROM TAG_PRINT_DATA";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			((Form)MyProject.Forms.MS_PRINT).ShowDialog();
			if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) != 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\GhatTagPrnt.RPT";
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = "SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('06') AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_GR IN ('06') ORDER BY A.AC_NAME";
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
				DC_Main.MsGrCode = "06";
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
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
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
		MSG.Row = 1;
		MSG.Col = 1;
		MSG_EnterCell(MSG, new EventArgs());
		((Control)TEXT_ENTRY).Focus();
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void btnItCancel_Click(object sender, EventArgs e)
	{
	}
}
