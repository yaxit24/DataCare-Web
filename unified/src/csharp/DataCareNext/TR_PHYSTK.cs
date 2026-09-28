using System;
using System.Collections;
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
using QRCoder;

namespace DataCareNext;

[DesignerGenerated]
public class TR_PHYSTK : Form
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
	[AccessedThroughProperty("btnReset")]
	private SimpleButton _btnReset;

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
	[AccessedThroughProperty("BtnFirst")]
	private SimpleButton _BtnFirst;

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
	[AccessedThroughProperty("tEmpCode")]
	private TextBox _tEmpCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnReport")]
	private SimpleButton _btnReport;

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
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicZoom")]
	private PictureBox _PicZoom;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTagPrint")]
	private SimpleButton _btnTagPrint;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private double LessAdvAmt;

	private double CustOpAmt;

	private double CustClAmt;

	private string PartyAcCode;

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

	private const int cItCode = 2;

	private const int citName = 3;

	private const int cDesign = 4;

	private const int cColour = 5;

	private const int cPolish = 6;

	private const int cSize = 7;

	private const int cCfNo = 8;

	private const int cCounter = 9;

	private const int cFromCntr = 10;

	private const int cToCntrCode = 11;

	private const int cToCntrName = 12;

	private const int cPcs = 13;

	private const int cGrWt = 14;

	private const int cOthWt = 15;

	private const int cNetWt = 16;

	private const int cFine = 17;

	private const int cLbrAmt = 18;

	private const int cOthAmt = 19;

	private const int cTagCost = 20;

	private const int cMrp = 21;

	private const int cMargin = 22;

	private const int cNewMrp = 23;

	private const int cRemark = 24;

	private const int cKrName = 25;

	private const int cVchSrno = 26;

	private const int cEntryMod = 27;

	private const int cDesignImgId = 28;

	private const int cOldSrNo = 29;

	private const int cTblPosting = 30;

	private const int cOldMargin = 31;

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

	internal virtual SimpleButton btnReset
	{
		[CompilerGenerated]
		get
		{
			return _btnReset;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnReset_Click;
			SimpleButton val = _btnReset;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReset = value;
			val = _btnReset;
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
			EventHandler eventHandler = tEmpCode_DoubleClick;
			TextBox val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tEmpCode = value;
			val2 = _tEmpCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).DoubleClick += eventHandler;
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

	internal virtual SimpleButton btnReport
	{
		[CompilerGenerated]
		get
		{
			return _btnReport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnReport_Click;
			SimpleButton val = _btnReport;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnReport = value;
			val = _btnReport;
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
			EventHandler eventHandler = btnTagPrint_Click;
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
	[AccessedThroughProperty("btnTagSet")]
	private virtual SimpleButton _btnTagSet;

	internal virtual SimpleButton btnTagSet
	{
		get
		{
			return _btnTagSet;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_btnTagSet = value;
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

	public TR_PHYSTK()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_PHYSTK_Load;
		((Form)this).Deactivate += TR_PHYSTK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_PHYSTK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_PHYSTK_KeyDown);
		((Form)this).Activated += TR_PHYSTK_Activated;
		((Form)this).Closed += TR_PHYSTK_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_PHYSTK_KeyUp);
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
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_03e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f2: Expected O, but got Unknown
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0499: Expected O, but got Unknown
		//IL_0544: Unknown result type (might be due to invalid IL or missing references)
		//IL_054e: Expected O, but got Unknown
		//IL_05d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05dc: Expected O, but got Unknown
		//IL_0674: Unknown result type (might be due to invalid IL or missing references)
		//IL_067e: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0717: Expected O, but got Unknown
		//IL_077a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0784: Expected O, but got Unknown
		//IL_082d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0837: Expected O, but got Unknown
		//IL_089a: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a4: Expected O, but got Unknown
		//IL_094d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0957: Expected O, but got Unknown
		//IL_0a74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7e: Expected O, but got Unknown
		//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b93: Expected O, but got Unknown
		//IL_0bf6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c00: Expected O, but got Unknown
		//IL_0da9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0c: Expected O, but got Unknown
		//IL_0e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e79: Expected O, but got Unknown
		//IL_0f7e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f88: Expected O, but got Unknown
		//IL_1080: Unknown result type (might be due to invalid IL or missing references)
		//IL_108a: Expected O, but got Unknown
		//IL_119b: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a5: Expected O, but got Unknown
		//IL_124c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1256: Expected O, but got Unknown
		//IL_12b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c1: Expected O, but got Unknown
		//IL_1332: Unknown result type (might be due to invalid IL or missing references)
		//IL_133c: Expected O, but got Unknown
		//IL_1414: Unknown result type (might be due to invalid IL or missing references)
		//IL_141e: Expected O, but got Unknown
		//IL_14ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c4: Expected O, but got Unknown
		//IL_15ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_1609: Expected O, but got Unknown
		//IL_166d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1677: Expected O, but got Unknown
		//IL_171b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1725: Expected O, but got Unknown
		//IL_17a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ac: Expected O, but got Unknown
		//IL_1834: Unknown result type (might be due to invalid IL or missing references)
		//IL_183e: Expected O, but got Unknown
		//IL_18f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1900: Expected O, but got Unknown
		//IL_19c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_19cb: Expected O, but got Unknown
		//IL_1a8c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a96: Expected O, but got Unknown
		//IL_1c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c8c: Expected O, but got Unknown
		//IL_1d2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d34: Expected O, but got Unknown
		//IL_1ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de6: Expected O, but got Unknown
		//IL_1f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f4e: Expected O, but got Unknown
		//IL_2023: Unknown result type (might be due to invalid IL or missing references)
		//IL_202d: Expected O, but got Unknown
		//IL_20c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20d3: Expected O, but got Unknown
		//IL_2218: Unknown result type (might be due to invalid IL or missing references)
		//IL_2222: Expected O, but got Unknown
		//IL_22ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_22b6: Expected O, but got Unknown
		//IL_2377: Unknown result type (might be due to invalid IL or missing references)
		//IL_2381: Expected O, but got Unknown
		//IL_2442: Unknown result type (might be due to invalid IL or missing references)
		//IL_244c: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_PHYSTK));
		lblBook = new Label();
		mVchDate = new MaskedTextBox();
		lblBDate = new Label();
		Label2 = new Label();
		tVchNo = new TextBox();
		mDay = new TextBox();
		mTime = new TextBox();
		btnReset = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnExit = new SimpleButton();
		PnlBotam = new FlowLayoutPanel();
		btnReport = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		BtnLast = new SimpleButton();
		BtnFirst = new SimpleButton();
		TEXT_ENTRY = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		BtnF1 = new SimpleButton();
		Cr = new AxCrystalReport();
		tHdVchNo = new TextBox();
		tEmpCode = new TextBox();
		tEmpName = new TextBox();
		Label3 = new Label();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		PicImage = new PictureBox();
		DlgOpen = new OpenFileDialog();
		PicZoom = new PictureBox();
		tVchDesc = new TextBox();
		Label4 = new Label();
		btnTagPrint = new SimpleButton();
		btnTagSet = new SimpleButton();
		cboPrintfile = new ComboBox();
		Label6 = new Label();
		Label1 = new Label();
		nLableSkip = new TextBox();
		PictureBox1 = new PictureBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
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
		((Control)lblBook).TabIndex = 6;
		lblBook.Text = "Physical Stock";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mVchDate).Location = new Point(287, 47);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 22);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(214, 48);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)16;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(19, 48);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(61, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tVchNo).Location = new Point(86, 47);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 22);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mDay).Location = new Point(448, 47);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 22);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)mTime).Location = new Point(368, 47);
		((TextBoxBase)mTime).MaxLength = 8;
		((Control)mTime).Name = "mTime";
		((TextBoxBase)mTime).ReadOnly = true;
		((Control)mTime).Size = new Size(75, 22);
		((Control)mTime).TabIndex = 1132;
		mTime.TextAlign = (HorizontalAlignment)2;
		((BaseStyleControl)btnReset).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnReset).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnReset).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnReset).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnReset.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnReset.ImageOptions.SvgImage");
		((Control)btnReset).Location = new Point(696, 3);
		((BaseControl)btnReset).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnReset).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnReset).Name = "btnReset";
		((Control)btnReset).Size = new Size(125, 37);
		((Control)btnReset).TabIndex = 1;
		btnReset.Text = "&Reset Stock";
		((BaseButton)btnReset).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnReport);
		((Control)PnlBotam).Controls.Add((Control)(object)btnReset);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnLast);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnFirst);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 5;
		((BaseStyleControl)btnReport).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnReport).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnReport).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnReport).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnReport.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnReport.ImageOptions.SvgImage");
		((Control)btnReport).Location = new Point(827, 3);
		((BaseControl)btnReport).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnReport).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnReport).Name = "btnReport";
		((Control)btnReport).Size = new Size(91, 37);
		((Control)btnReport).TabIndex = 28;
		btnReport.Text = "&Report";
		((BaseButton)btnReport).ToolTipAnchor = (ToolTipAnchor)1;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(271, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(419, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((BaseStyleControl)BtnLast).Appearance.Font = new Font("Tahoma", 18f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnLast).Appearance.ForeColor = Color.FromArgb(255, 128, 0);
		((BaseStyleControl)BtnLast).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnLast).Appearance.Options.UseForeColor = true;
		((Control)BtnLast).Location = new Point(224, 3);
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
		((Control)BtnFirst).Location = new Point(177, 3);
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
		((Control)TEXT_ENTRY).TabIndex = 2;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)MSG_TOT).Location = new Point(15, 443);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1154, 15);
		((Control)MSG_TOT).TabIndex = 1136;
		((Control)MSG).Location = new Point(11, 82);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1160, 359);
		((Control)MSG).TabIndex = 1135;
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
		((Control)BtnF1).Location = new Point(170, 46);
		((BaseControl)BtnF1).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnF1).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnF1).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnF1).Name = "BtnF1";
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1200, 379);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
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
		((Control)tEmpCode).Location = new Point(279, 472);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 22);
		((Control)tEmpCode).TabIndex = 3;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tEmpName).Location = new Point(342, 472);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(249, 22);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(197, 472);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)16;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(140, 530);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(35, 28);
		((Control)BtnImgD).TabIndex = 1180;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		((Control)BtnImgD).Visible = false;
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(140, 497);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(35, 28);
		((Control)BtnImgS).TabIndex = 1179;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		((Control)BtnImgS).Visible = false;
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(140, 464);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(35, 28);
		((Control)BtnImgC).TabIndex = 1178;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((Control)BtnImgC).Visible = false;
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(12, 464);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(122, 94);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1177;
		PicImage.TabStop = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1193, 443);
		((Control)PicZoom).Name = "PicZoom";
		((Control)PicZoom).Size = new Size(35, 20);
		PicZoom.SizeMode = (PictureBoxSizeMode)4;
		PicZoom.TabIndex = 1181;
		PicZoom.TabStop = false;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(279, 504);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(362, 50);
		((Control)tVchDesc).TabIndex = 4;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(197, 499);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(67, 20);
		((Control)Label4).TabIndex = 1183;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)16;
		((BaseStyleControl)btnTagPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTagPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTagPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTagPrint).Appearance.Options.UseForeColor = true;
		btnTagPrint.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)btnTagPrint.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)btnTagPrint).Location = new Point(782, 512);
		((BaseControl)btnTagPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTagPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagPrint).Name = "btnTagPrint";
		((Control)btnTagPrint).Size = new Size(105, 37);
		((Control)btnTagPrint).TabIndex = 1184;
		btnTagPrint.Text = "&Tag Print";
		((BaseButton)btnTagPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnTagPrint).Visible = false;
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
		((Control)btnTagSet).Location = new Point(1127, 517);
		((BaseControl)btnTagSet).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnTagSet).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnTagSet).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTagSet).Name = "btnTagSet";
		((Control)btnTagSet).Size = new Size(44, 24);
		((Control)btnTagSet).TabIndex = 1187;
		btnTagSet.Text = "Set";
		((BaseControl)btnTagSet).ToolTip = "Party Help";
		cboPrintfile.AutoCompleteMode = (AutoCompleteMode)2;
		cboPrintfile.AutoCompleteSource = (AutoCompleteSource)256;
		cboPrintfile.BackColor = Color.FromArgb(250, 220, 230);
		((Control)cboPrintfile).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboPrintfile).FormattingEnabled = true;
		((Control)cboPrintfile).Location = new Point(1008, 518);
		cboPrintfile.MaxLength = 5;
		((Control)cboPrintfile).Name = "cboPrintfile";
		((Control)cboPrintfile).Size = new Size(113, 24);
		((Control)cboPrintfile).TabIndex = 1185;
		((Control)cboPrintfile).Visible = false;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(896, 519);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(106, 20);
		((Control)Label6).TabIndex = 1186;
		Label6.Text = "Print file Name";
		Label6.TextAlign = (ContentAlignment)16;
		((Control)Label6).Visible = false;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(649, 520);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(80, 20);
		((Control)Label1).TabIndex = 1189;
		Label1.Text = "Lable Skip";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label1).Visible = false;
		((TextBoxBase)nLableSkip).BackColor = Color.White;
		((Control)nLableSkip).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nLableSkip).Location = new Point(736, 520);
		((TextBoxBase)nLableSkip).MaxLength = 15;
		((Control)nLableSkip).Name = "nLableSkip";
		((Control)nLableSkip).Size = new Size(39, 22);
		((Control)nLableSkip).TabIndex = 1188;
		((Control)nLableSkip).Visible = false;
		((Control)PictureBox1).Location = new Point(1193, 296);
		((Control)PictureBox1).Name = "PictureBox1";
		((Control)PictureBox1).Size = new Size(56, 48);
		PictureBox1.SizeMode = (PictureBoxSizeMode)3;
		PictureBox1.TabIndex = 1229;
		PictureBox1.TabStop = false;
		((Control)PictureBox1).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)PictureBox1);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)nLableSkip);
		((Control)this).Controls.Add((Control)(object)btnTagSet);
		((Control)this).Controls.Add((Control)(object)cboPrintfile);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)btnTagPrint);
		((Control)this).Controls.Add((Control)(object)tVchDesc);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)PicImage);
		((Control)this).Controls.Add((Control)(object)tEmpCode);
		((Control)this).Controls.Add((Control)(object)tEmpName);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tHdVchNo);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)BtnF1);
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
		((Control)this).Name = "TR_PHYSTK";
		((Form)this).Text = "Physical Stock";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)PictureBox1).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 32;
		mSG.Rows = 2;
		mSG.Row = 0;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(700.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			mSG[1] = (int)Math.Round(1200.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "TagNo";
			mSG[2] = (int)Math.Round(900.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "ItCode";
			mSG[3] = (int)Math.Round(3000.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItName";
			mSG[4] = (int)Math.Round(1300.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "Design";
			if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
			{
				mSG[5] = (int)Math.Round(1200.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "Color";
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "Purity";
				mSG[7] = (int)Math.Round(1200.0 * ColCon);
				mSG[7] = 0;
				mSG[0, 7] = "Size";
				mSG[8] = (int)Math.Round(1200.0 * ColCon);
				mSG[8] = 0;
				mSG[0, 8] = "Cf.No";
				mSG[24] = (int)Math.Round(1200.0 * ColCon);
				mSG[24] = 0;
				mSG[0, 24] = "Remark";
				mSG[18] = (int)Math.Round(1100.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "LbrAmt";
				mSG[19] = (int)Math.Round(1100.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "OthAmt";
				mSG[21] = (int)Math.Round(1200.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "Mrp";
				mSG[25] = (int)Math.Round(1000.0 * ColCon);
				mSG[25] = 0;
				mSG[0, 25] = "KrName";
				mSG[9] = 0;
				mSG[10] = 0;
				mSG[11] = 0;
				mSG[12] = 0;
				mSG[17] = 0;
				mSG[20] = 0;
				mSG[22] = 0;
				mSG[23] = 0;
			}
			else if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
			{
				mSG[4] = (int)Math.Round(800.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "Design";
				mSG[3] = (int)Math.Round(2500.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "ItName";
				mSG[20] = (int)Math.Round(1100.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "TagCost";
				mSG[21] = (int)Math.Round(1200.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "Mrp";
				mSG[22] = (int)Math.Round(900.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "Mar%";
				mSG[23] = (int)Math.Round(1200.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "NwMrp";
				mSG[25] = (int)Math.Round(1000.0 * ColCon);
				mSG[25] = 0;
				mSG[0, 25] = "KrName";
				mSG[5] = 0;
				mSG[6] = 0;
				mSG[7] = 0;
				mSG[8] = 0;
				mSG[24] = 0;
				mSG[9] = 0;
				mSG[10] = 0;
				mSG[11] = 0;
				mSG[12] = 0;
				mSG[17] = 0;
				mSG[18] = 0;
				mSG[19] = 0;
			}
			else if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
			{
				mSG[7] = (int)Math.Round(0.0 * ColCon);
				mSG[7] = 0;
				mSG[0, 7] = "Size";
				mSG[9] = (int)Math.Round(800.0 * ColCon);
				mSG[9] = 3;
				mSG[0, 9] = "Cntr";
				mSG[10] = (int)Math.Round(1600.0 * ColCon);
				mSG[10] = 0;
				mSG[0, 10] = "FCounter";
				mSG[11] = (int)Math.Round(800.0 * ColCon);
				mSG[11] = 3;
				mSG[0, 11] = "ToCntr";
				mSG[12] = (int)Math.Round(1600.0 * ColCon);
				mSG[12] = 0;
				mSG[0, 12] = "ToCounter";
				mSG[17] = (int)Math.Round(0.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "Fine";
				mSG[18] = (int)Math.Round(0.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "LbrAmt";
				mSG[19] = (int)Math.Round(0.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "OthAmt";
				mSG[21] = (int)Math.Round(1100.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "Mrp";
				mSG[25] = (int)Math.Round(0.0 * ColCon);
				mSG[25] = 0;
				mSG[0, 25] = "KrName";
				mSG[5] = 0;
				mSG[6] = 0;
				mSG[8] = 0;
				mSG[24] = 0;
				mSG[20] = 0;
				mSG[22] = 0;
				mSG[23] = 0;
			}
			else
			{
				mSG[7] = (int)Math.Round(800.0 * ColCon);
				mSG[7] = 0;
				mSG[0, 7] = "Size";
				mSG[9] = (int)Math.Round(800.0 * ColCon);
				mSG[9] = 3;
				mSG[0, 9] = "Cntr";
				mSG[10] = (int)Math.Round(0.0 * ColCon);
				mSG[10] = 3;
				mSG[0, 10] = "FCounter";
				mSG[11] = (int)Math.Round(0.0 * ColCon);
				mSG[11] = 3;
				mSG[0, 11] = "ToCode";
				mSG[12] = (int)Math.Round(0.0 * ColCon);
				mSG[12] = 3;
				mSG[0, 12] = "ToCounter";
				mSG[17] = (int)Math.Round(0.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "Fine";
				mSG[18] = (int)Math.Round(1100.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "LbrAmt";
				mSG[19] = (int)Math.Round(1100.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "OthAmt";
				mSG[21] = (int)Math.Round(1200.0 * ColCon);
				mSG[21] = 7;
				mSG[0, 21] = "Mrp";
				mSG[25] = (int)Math.Round(1000.0 * ColCon);
				mSG[25] = 0;
				mSG[0, 25] = "KrName";
				mSG[5] = 0;
				mSG[6] = 0;
				mSG[8] = 0;
				mSG[24] = 0;
				mSG[20] = 0;
				mSG[22] = 0;
				mSG[23] = 0;
			}
			mSG[13] = (int)Math.Round(800.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "Pcs";
			mSG[14] = (int)Math.Round(1000.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "GrWt";
			mSG[15] = (int)Math.Round(1000.0 * ColCon);
			mSG[15] = 7;
			mSG[0, 15] = "OthWt";
			mSG[16] = (int)Math.Round(1000.0 * ColCon);
			mSG[16] = 7;
			mSG[0, 16] = "NetWt";
			mSG[27] = 0;
			mSG[26] = 0;
			mSG[28] = 0;
			mSG[29] = 0;
			mSG[30] = 0;
			mSG[31] = 0;
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 17;
			mSG[0] = (int)Math.Round(325.0 * ColCon);
			mSG[1] = (int)Math.Round(300.0 * ColCon);
			mSG.ScrollBars = (ScrollBarsSettings)3;
			CommPassAdd();
			mSG = null;
			AxMSFlexGrid mSG_TOT = MSG_TOT;
			mSG_TOT.Cols = MSG.Cols;
			int num = MSG.Cols - 1;
			DC_Main.M = 0;
			while (DC_Main.M <= num)
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
				mSG_TOT[0, 3] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0");
					mSG_TOT[0, 17] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 17]) + Conversion.Val(MSG[DC_Main.M, 17]))), "0.000");
					mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 16] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 16]) + Conversion.Val(MSG[DC_Main.M, 16]))), "0.000");
					DC_Main.M++;
				}
				mSG_TOT = null;
				NewValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 14]);
			}
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 28] = "N";
		checked
		{
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				mSG[mSG.Row, 29] = Conversions.ToString(MSG.Row);
			}
			else
			{
				mSG[mSG.Row, 29] = Conversions.ToString(Conversion.Val(mSG[mSG.Rows - 2, 29]) + 1.0);
			}
			if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
			{
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0))
				{
					mSG[mSG.Row, 30] = "Y";
				}
				else
				{
					mSG[mSG.Row, 30] = "N";
				}
			}
			else
			{
				mSG[mSG.Row, 30] = "N";
			}
			if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
			{
				if (mSG.Row > 1 && ((Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS023NPBU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS332NUBU", false) == 0)))
				{
					mSG[mSG.Row, 11] = mSG[mSG.Row - 1, 11];
				}
			}
			else if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0 && mSG.Row > 1 && Operators.CompareString(DC_Main.SSRegSrNo, "VK052NEVK", false) != 0)
			{
				mSG[mSG.Row, 22] = mSG[mSG.Row - 1, 22];
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
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 9:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 11:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 3;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 10:
			case 12:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 30;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 1:
			case 4:
			case 7:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 3:
			case 5:
			case 6:
			case 8:
			case 24:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 25:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 13:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 18:
			case 19:
			case 20:
			case 21:
			case 22:
			case 23:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 14:
			case 15:
			case 16:
			case 17:
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
		case 7:
		case 9:
		case 10:
		case 11:
		case 12:
		case 25:
			mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
			break;
		case 0:
		case 1:
		case 3:
		case 5:
		case 6:
		case 8:
		case 24:
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
			}
			else
			{
				DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 26];
			}
			DC_Main.MsImageType = "TagImage";
			DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
			break;
		case 13:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
			CommPassTotal();
			break;
		case 18:
		case 19:
		case 20:
		case 21:
		case 22:
		case 23:
			mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
			CommPassTotal();
			break;
		case 14:
		case 15:
		case 16:
		case 17:
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
				case 1299:
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
							goto IL_005d;
						case 6:
							goto IL_00a8;
						case 7:
						case 8:
							goto IL_010a;
						case 9:
							goto IL_017e;
						case 12:
							goto IL_01f3;
						case 13:
							goto IL_024c;
						case 14:
							goto IL_0280;
						case 15:
						case 16:
							goto IL_02e3;
						case 17:
							goto IL_030d;
						case 18:
							goto IL_0337;
						case 20:
							goto IL_0375;
						case 19:
						case 21:
						case 22:
						case 23:
							goto IL_03b2;
						case 24:
							goto IL_0408;
						case 10:
						case 11:
						case 25:
						case 26:
						case 27:
						case 28:
							goto IL_047a;
						case 29:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 30:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_03b2:
					num2 = 23;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 21])))
					{
						goto IL_0408;
					}
					goto IL_047a;
					IL_0408:
					num2 = 24;
					val[val.Row, 22] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 20])) / Conversion.Val(val[val.Row, 20]) * 100.0, 2), "0.00");
					goto IL_047a;
					IL_0375:
					num2 = 20;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 20]), 0), "0.00");
					goto IL_03b2;
					IL_047a:
					val = null;
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
					{
						goto IL_0034;
					}
					goto IL_047a;
					IL_0034:
					num2 = 4;
					if (Conversion.Val(val[val.Row, 20]) == 0.0)
					{
						goto IL_005d;
					}
					goto IL_01f3;
					IL_005d:
					num2 = 5;
					if ((Conversion.Val(val[val.Row, 21]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != 0.0))
					{
						goto IL_00a8;
					}
					goto IL_010a;
					IL_00a8:
					num2 = 6;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]) * (1.0 + Conversion.Val(val[val.Row, 22]) / 100.0)), "0.00");
					goto IL_010a;
					IL_010a:
					num2 = 8;
					if ((Conversion.Val(val[val.Row, 20]) == 0.0) & (Conversion.Val(val[val.Row, 23]) != Conversion.Val(val[val.Row, 21])) & (Conversion.Val(val[val.Row, 23]) != 0.0))
					{
						goto IL_017e;
					}
					goto IL_047a;
					IL_017e:
					num2 = 9;
					val[val.Row, 22] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 23]) - Conversion.Val(val[val.Row, 21])) / Conversion.Val(val[val.Row, 21]) * 100.0, 2), "0.00");
					goto IL_047a;
					IL_01f3:
					num2 = 12;
					if ((Conversion.Val(val[val.Row, 20]) != 0.0) & (Conversion.Val(val[val.Row, 22]) != Conversion.Val(val[val.Row, 31])))
					{
						goto IL_024c;
					}
					goto IL_02e3;
					IL_024c:
					num2 = 13;
					val[val.Row, 31] = Strings.Format((object)Conversion.Val(val[val.Row, 22]), "0.00");
					goto IL_0280;
					IL_0280:
					num2 = 14;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 20]) * (1.0 + Conversion.Val(val[val.Row, 22]) / 100.0)), "0.00");
					goto IL_02e3;
					IL_02e3:
					num2 = 16;
					if (Conversion.Val(val[val.Row, 23]) == 0.0)
					{
						goto IL_030d;
					}
					goto IL_03b2;
					IL_030d:
					num2 = 17;
					if (Conversion.Val(val[val.Row, 21]) != 0.0)
					{
						goto IL_0337;
					}
					goto IL_0375;
					IL_0337:
					num2 = 18;
					val[val.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 21]), 0), "0.00");
					goto IL_03b2;
					end_IL_0001_2:
					break;
				}
				num2 = 29;
				MSG_TOT_FILL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1299;
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
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Invalid comparison between Unknown and I4
		//IL_00de: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Invalid comparison between Unknown and I4
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Invalid comparison between Unknown and I4
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Invalid comparison between Unknown and I4
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Invalid comparison between Unknown and I4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c5: Invalid comparison between Unknown and I4
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Invalid comparison between Unknown and I4
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Invalid comparison between Unknown and I4
		//IL_1637: Unknown result type (might be due to invalid IL or missing references)
		//IL_147d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0702: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a18: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bce: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0 && (int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
			{
				checked
				{
					int num = mSG.Cols - 1;
					DC_Main.M = 1;
					while (DC_Main.M <= num)
					{
						mSG[mSG.Row, DC_Main.M] = "";
						DC_Main.M++;
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
						if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0 && Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0)
						{
							MSG.Col += 1;
							return;
						}
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) == 0) | (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 1], false) != 0)))
						{
							break;
						}
						if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 26]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 26]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						else
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO,A.VCH_SRNO,B.VCH_TIME FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.TAG_NO = '"), (object)TEXT_ENTRY.Text), (object)"'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 26]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 26]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_TIME HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_TIME DESC"));
						}
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
							}
							else
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"Select A.TAG_NO AS TagNoL,B.IT_NAME As ItNameL,A.IT_CODE as ItCodeL,C.DESIGN_NO AS DesignNoL,C.ITM_GWT AS GrWtW,C.ITM_NWT AS NetWtW,C.ITM_MRP as MrpR,C.VCH_SRNO,C.VCH_TIME From (MAIN_STOCK AS A LEFT JOIN BAR_DETL AS C ON A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE =  B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,B.IT_NAME,A.IT_CODE,C.DESIGN_NO,C.ITM_GWT,C.ITM_NWT,C.ITM_MRP,C.VCH_SRNO,C.VCH_TIME HAVING SUM(CASE WHEN ITM_SIGN = '+' THEN A.VCH_SRNO ELSE -A.VCH_SRNO END) > 0  ORDER BY A.TAG_NO,C.VCH_TIME DESC"));
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
									mSG[mSG.Row, 3] = DC_Main.ColValue[1];
									mSG[mSG.Row, 2] = DC_Main.ColValue[2];
									mSG[mSG.Row, 4] = DC_Main.ColValue[3];
									mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 16] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 26] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 26] = "";
									mSG[mSG.Row, 1] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
						int num2 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num2)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 1], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								mSG[mSG.Row, 3] = DC_Main.ColValue[1];
								mSG[mSG.Row, 2] = DC_Main.ColValue[0];
								mSG[mSG.Row, 4] = DC_Main.ColValue[3];
								mSG[mSG.Row, 14] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 16] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 26] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) != 0)
						{
							DC_Main.RsQry = ("SELECT TAG_NO FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = '" + FormMainBook + "' AND TAG_NO = '" + TEXT_ENTRY.Text + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 26]))) ?? "";
							DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (dataTable.Rows.Count > 0)
							{
								Interaction.MsgBox((object)"This Tag is Allrady Scane to Other Voucher Not Alloud Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								mSG[mSG.Row, 3] = "";
								mSG[mSG.Row, 2] = "";
								mSG[mSG.Row, 14] = "";
								mSG[mSG.Row, 26] = "";
								return;
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 26]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 2] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 9] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TBL_CODE"], (object)""));
							if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
							{
								DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TABLE_NAME FROM TABLE_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TABLE_CODE = '"), DC_Main.Rshlp.Rows[0]["TBL_CODE"]), (object)""), (object)"'"));
								DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								if (DC_Main.Tbl.Rows.Count > 0)
								{
									mSG[DC_Main.i, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_NAME"], (object)""));
								}
							}
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 7] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 13] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[DC_Main.i, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["LBR_AMT"])), "0.00");
							mSG[DC_Main.i, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["OTH_AMT"])), "0.00");
							if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])) != 0.0)
							{
								mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["KR_COST"])), "0.00");
							}
							else
							{
								mSG[DC_Main.i, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAG_COST"])), "0.00");
							}
							mSG[DC_Main.i, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_MRP"])), "0.00");
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 26] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
							mSG[DC_Main.i, 28] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_IMG_ID"], (object)""));
						}
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						CommPassTotal();
						if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
						{
							mSG.Col = 4;
							break;
						}
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
						{
							mSG.Col = 11;
							return;
						}
						if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
						{
							mSG.Col = 22;
							return;
						}
						if (mSG.Row != mSG.Rows - 1)
						{
							break;
						}
						MsgClear = true;
						mSG.Rows += 1;
						mSG.Row += 1;
						MsgClear = false;
						mSG.Col = 1;
						CommPassAdd();
						return;
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
									mSG[mSG.Row, 3] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						break;
					case 11:
						DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TABLE_CODE = '" + TEXT_ENTRY.Text + "'";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT A.TABLE_NAME As CouneterNameL,A.TABLE_CODE as CtrCodeL FROM TABLE_MAST AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.TABLE_CODE";
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
									mSG[mSG.Row, 11] = DC_Main.ColValue[1];
									mSG[mSG.Row, 12] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
						}
						else
						{
							mSG[mSG.Row, 11] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_CODE"], (object)""));
							mSG[mSG.Row, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_NAME"], (object)""));
							if (mSG.Row == mSG.Rows - 1)
							{
								mSG[mSG.Row, 25] = TEXT_ENTRY.Text;
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
					case 25:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 25] = TEXT_ENTRY.Text;
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

	private void TR_PHYSTK_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a74: Expected O, but got Unknown
		//IL_0ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac2: Expected O, but got Unknown
		//IL_0adc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aeb: Expected O, but got Unknown
		//IL_0b13: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b1a: Expected O, but got Unknown
		//IL_0ba0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0baf: Expected O, but got Unknown
		//IL_0c37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c46: Expected O, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cea: Expected O, but got Unknown
		//IL_0d74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d83: Expected O, but got Unknown
		//IL_0da8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dad: Unknown result type (might be due to invalid IL or missing references)
		//IL_0db7: Expected O, but got Unknown
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj17 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj18 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj26 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj27 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj28 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj28 != null) ? ((Color)obj28) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj29 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj29 != null) ? ((Color)obj29) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				((TextBoxBase)TEXT_ENTRY).AutoSize = false;
				int num3 = (int)Math.Ceiling((double)((Control)TEXT_ENTRY).Font.Size * (1.0 + num2));
				((Control)TEXT_ENTRY).Font = new Font(((Control)TEXT_ENTRY).Font.FontFamily, (float)num3, ((Control)TEXT_ENTRY).Font.Style);
				num3 = (int)Math.Ceiling((double)MSG.Font.Size * (1.0 + num2));
				MSG.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				MSG_TOT.Font = new Font("Segoe UI Semibold", (float)num3, MSG.Font.Style);
				Font font = ((Control)tVchNo).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && ((Operators.CompareString(val3.Name, "TEXT_ENTRY", false) != 0) & (Operators.CompareString(val3.Name, "lblBook", false) != 0)))
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
			if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
			{
				((Control)btnReport).Visible = true;
				btnReport.Text = "Print";
				((Control)btnReset).Visible = false;
				((Control)BtnImgC).Visible = true;
				((Control)BtnImgS).Visible = true;
				((Control)BtnImgD).Visible = true;
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(570.0 * ColCon);
			}
			else if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
			{
				((Control)btnReport).Visible = false;
				((Control)btnReset).Visible = false;
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(670.0 * ColCon);
			}
			else if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
			{
				((Control)btnReport).Visible = false;
				((Control)btnReset).Visible = false;
				((Control)FlowLayoutPanel1).Width = (int)Math.Round(670.0 * ColCon);
			}
			DC_Main.CurBook = "";
			DC_Main.CurBookName = "";
			DC_Main.CurBookType = "";
			DC_Main.CurBookItm = "";
			DC_Main.CurBookMain = "";
			DC_Main.CurBookSname = "";
			DC_Main.CurBookInOut = "";
			if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
			{
				((Control)btnTagPrint).Visible = true;
				((Control)Label6).Visible = true;
				((Control)cboPrintfile).Visible = true;
				((Control)btnTagSet).Visible = true;
				((Control)Label1).Visible = true;
				((Control)nLableSkip).Visible = true;
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
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		OldValTot = 0.0;
		NewValTot = 0.0;
		LessAdvAmt = 0.0;
		((Control)TEXT_ENTRY).Visible = false;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		MSG_CLEAR();
		FilRow = 0;
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["EMP_NAME"], (object)""));
				}
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				MainUser = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["MAIN_USER"], (object)""));
				MSG_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME FROM BAR_CAN_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				if (RsDetl.Rows.Count > 0)
				{
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < RsDetl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 29] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OLD_SRNO"], (object)""));
						mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
						mSG[DC_Main.i + 1, 9] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_CODE"], (object)""));
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
						{
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TABLE_NAME FROM TABLE_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TABLE_CODE = '"), RsDetl.Rows[0]["TBL_CODE"]), (object)""), (object)"'"));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								mSG[DC_Main.i + 1, 10] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_NAME"], (object)""));
							}
							mSG[DC_Main.i + 1, 11] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TO_TBL_CODE"], (object)""));
							DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT TABLE_NAME FROM TABLE_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TABLE_CODE = '"), RsDetl.Rows[0]["TO_TBL_CODE"]), (object)""), (object)"'"));
							DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Tbl.Rows.Count > 0)
							{
								mSG[DC_Main.i + 1, 12] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["TABLE_NAME"], (object)""));
							}
						}
						mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
						mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
						mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_COLOUR"], (object)""));
						mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_POLISH"], (object)""));
						mSG[DC_Main.i + 1, 8] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_CF_NO"], (object)""));
						mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
						mSG[DC_Main.i + 1, 13] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
						mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
						mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TAG_COST"])), "0.00");
						if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
						{
							mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OLD_MRP"])), "0.00");
							mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MRP_MARGIN"])), "0.00");
							mSG[DC_Main.i + 1, 31] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MRP_MARGIN"])), "0.00");
							mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						}
						else
						{
							mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_MRP"])), "0.00");
						}
						mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
						mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["VCH_SRNO"], (object)""));
						mSG[DC_Main.i + 1, 27] = "E";
						mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_IMG_ID"], (object)""));
						mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TBL_POSTING"], (object)""));
						mSG.Rows += 1;
						DC_Main.i++;
					}
					mSG.Rows -= 1;
					mSG = null;
					MSG_TOT_FILL();
					DtIdtl.Clear();
					DtIdtl.Reset();
					FilRow = 0;
					MSG_TOT_FILL();
					EntryMode = "E";
					if (MSG.Rows >= 1)
					{
						MSG.Row = 1;
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
					}
				}
				OldValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 14]);
				NewValTot = Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 14]);
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

	private void TR_PHYSTK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_PHYSTK_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_2034: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f6e: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
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
					{
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0 && ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0)))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							((Control)tEmpCode).Focus();
							goto end_IL_0001;
						}
						((Control)BtnSave).Enabled = false;
						if ((DateTime.Compare(Conversions.ToDate(DC_Main.MCo_OpDate), Conversions.ToDate(mVchDate.Text)) > 0) | (DateTime.Compare(Conversions.ToDate(DC_Main.MCo_ClDate), Conversions.ToDate(mVchDate.Text)) < 0))
						{
							Interaction.MsgBox((object)"You Cant Save Entry Because Voucher Date Not In Current Year... Please Change Date...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
						{
							Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(tVchNo.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert VchNo and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						MSG_TOT_FILL();
						ProjectData.ClearProjectError();
						num2 = 2;
						if (Operators.CompareString(EntryMode, "A", false) == 0)
						{
							DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count > 0)
							{
								DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0 && ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0)))
						{
							DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
							DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						}
						DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						if (Conversion.Val(MSG_TOT[0, 13]) + Conversion.Val(MSG_TOT[0, 14]) != 0.0)
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
							DC_Main.RsQry = "SELECT * FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
							RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.MsInsertData();
							DataRow dataRow2 = RsData.NewRow();
							dataRow2["CO_CODE"] = DC_Main.MCo_code;
							dataRow2["LC_CODE"] = DC_Main.MLc_code;
							dataRow2["CO_YEAR"] = DC_Main.MCo_year;
							dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
							dataRow2["VCH_NO"] = tVchNo.Text;
							dataRow2["AC_CODE"] = "";
							dataRow2["VCH_DATE"] = mVchDate.Text;
							dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
							dataRow2["EMP_CODE"] = tEmpCode.Text;
							dataRow2["VCH_DESC"] = tVchDesc.Text;
							dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow2["DATA_TRFR"] = "Y";
							dataRow2["MAIN_USER"] = MainUser;
							RsData.Rows.Add(dataRow2);
							((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
							RsData.Clear();
						}
						DC_Main.RsQry = "SELECT * FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow3 = RsDetl.NewRow();
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							AxMSFlexGrid mSG = MSG;
							if (((Operators.CompareString(mSG[DC_Main.i, 2], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 1], "", false) != 0) & (Conversion.Val(mSG[DC_Main.i, 21]) != 0.0)) | (Conversion.Val(mSG[DC_Main.i, 14]) + Conversion.Val(mSG[DC_Main.i, 18]) + Conversion.Val(mSG[DC_Main.i, 19]) != 0.0))
							{
								dataRow3["CO_CODE"] = DC_Main.MCo_code;
								dataRow3["LC_CODE"] = DC_Main.MLc_code;
								dataRow3["CO_YEAR"] = DC_Main.MCo_year;
								dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
								dataRow3["VCH_NO"] = tVchNo.Text;
								dataRow3["VCH_DATE"] = mVchDate.Text;
								dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow3["AC_CODE"] = "";
								dataRow3["VCH_TYPE"] = FormBookSname;
								dataRow3["INOUT_TYPE"] = FormBookInOut;
								dataRow3["ENTRY_TYPE"] = "T";
								dataRow3["BOOK_NAME"] = FormMainBook;
								dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
								dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 29]);
								dataRow3["IT_CODE"] = mSG[DC_Main.i, 2];
								dataRow3["TAG_NO"] = mSG[DC_Main.i, 1];
								dataRow3["TBL_CODE"] = mSG[DC_Main.i, 9];
								dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 4];
								dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 7];
								dataRow3["ITM_SIGN"] = "-";
								dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 13]);
								dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 14]);
								dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 15]);
								dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 16]);
								dataRow3["ITM_GHT_WT"] = 0;
								dataRow3["ITM_TOUCH"] = 0;
								dataRow3["ITM_WEST_PRC"] = 0;
								dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 17]);
								dataRow3["LBR_PRC"] = 0;
								dataRow3["LBR_TYPE"] = "";
								dataRow3["LBR_RATE"] = 0;
								dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 18]);
								dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
								dataRow3["ITM_RATE"] = 0;
								dataRow3["ITM_AMT"] = 0;
								dataRow3["TAG_COST"] = Conversion.Val(mSG[DC_Main.i, 20]);
								if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
								{
									dataRow3["OLD_MRP"] = Conversion.Val(mSG[DC_Main.i, 21]);
									dataRow3["MRP_MARGIN"] = Conversion.Val(mSG[DC_Main.i, 22]);
									dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 23]);
								}
								else
								{
									dataRow3["ITM_MRP"] = Conversion.Val(mSG[DC_Main.i, 21]);
									dataRow3["OLD_MRP"] = 0;
									dataRow3["MRP_MARGIN"] = 0;
								}
								dataRow3["KR_NET_WT"] = 0;
								dataRow3["KR_TOUCH"] = 0;
								dataRow3["KR_WEST_PRC"] = 0;
								dataRow3["KR_FINE"] = 0;
								dataRow3["KR_NAME"] = mSG[DC_Main.i, 25];
								dataRow3["RATE_TYPE"] = "";
								dataRow3["IT_TYPE"] = "";
								dataRow3["PR_CODE"] = "";
								dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 26]);
								dataRow3["TO_TBL_CODE"] = mSG[DC_Main.i, 11];
								dataRow3["ITM_COLOUR"] = mSG[DC_Main.i, 5];
								dataRow3["ITM_POLISH"] = mSG[DC_Main.i, 6];
								dataRow3["ITM_CF_NO"] = mSG[DC_Main.i, 8];
								dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 24];
								dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								dataRow3["DATA_TRFR"] = "N";
								dataRow3["MAIN_USER"] = MainUser;
								dataRow3["DESIGN_IMG_ID"] = mSG[DC_Main.i, 28];
								if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
								{
									if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0))
									{
										if (Operators.CompareString(MSG[DC_Main.i, 30], "", false) == 0)
										{
											dataRow3["TBL_POSTING"] = "Y";
										}
										else
										{
											dataRow3["TBL_POSTING"] = MSG[DC_Main.i, 30];
										}
									}
									else
									{
										dataRow3["TBL_POSTING"] = "N";
									}
								}
								else
								{
									dataRow3["TBL_POSTING"] = "N";
								}
								RsDetl.Rows.Add(dataRow3);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
								if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0 && ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0)))
								{
									DC_Main.RsQry = "INSERT INTO BAR_DETL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,  VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,  TAG_SRNO,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,  MAIN_USER,ADD_USER,DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,  HM_ID4_WT,HM_ID,DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,  KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID)   SELECT TOP 1 CO_CODE,LC_CODE,'" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 0])) + "," + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 29])) + ",'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "',STK_DATE,'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text + " " + mTime.Text), "MM/dd/yyyy HH:mm:ss") + "',  '" + FormBookSname + "','" + FormBookInOut + "','T','" + FormMainBook + "',AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,'" + mSG[DC_Main.i, 11] + "',ITM_SIZE,ITM_PCS,  BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,LBR_PRC,LBR_RATE,  LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,KR_OTH_WT,  KR_NET_WT,KR_GHT_PRC,KR_GHT_WT,KR_TOUCH,KR_WEST_PRC,KR_FINE,KR_LBR_RATE,KR_LBR_AMT,KR_OTH_AMT,KR_COST,  TAG_SRNO," + Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 1) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 29])) + ",RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,APR_ISU,ORD_NO,ORD_SRNO,ORD_YRCD,ORD_DBCD,ORD_AC,  MAIN_USER,ADD_USER,DATA_TRFR,HD_VCH_NO,OLD_VCH_NO,NEW_VCH_NO,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,  HM_ID4_WT,HM_ID,DATA_TYPE,APP_TRFR,ITM_COLOR,MAIN_MARGIN_PRC,MAIN_MRP,JDT_JDT_WT,JDT_GHT_WT,JDT_KUN_WT,JDT_WAX_WT,  KR_WAX_WT,JDT_KUN_TOUCH,JDT_KUN_NET,EMP_ISU,LBR_CODE,DESIGN_IMG_ID FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO =  '" + mSG[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 26])) + " ORDER BY VCH_TIME DESC ";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
									DC_Main.RsQry = "INSERT INTO BAR_IDTL(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,ISR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,  BOOK_NAME,AC_CODE,TAG_NO,VCH_SRNO,IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,  KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,  DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC)   SELECT CO_CODE,LC_CODE,'" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 29])) + ",ISR_NO,'" + Strings.Format((object)Conversions.ToDate(mVchDate.Text), "MM/dd/yyyy") + "','" + FormBookSname + "','" + FormBookInOut + "','T',  '" + FormMainBook + "',AC_CODE,TAG_NO," + Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + Conversions.ToString(Conversion.Val(DC_Main.MLc_code)) + Strings.Mid(DC_Main.MCo_year, 1, 1) + Conversions.ToString(Conversion.Val(DC_Main.MCo_Book)) + Conversions.ToString(Conversion.Val(tVchNo.Text)) + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 29])) + ",IT_CODE,IT_TYPE,DM_CODE,DM_SIZE,DM_SFNO,DM_LEB,IT_PCS,IT_PCS_WT,KR_WT,  KR_LESS_PRC,IT_GWT,IT_CON_PRC,IT_CON_WT,IT_RATE_TYPE,IT_RATE,IT_AMT,IT_LBR_RATE,IT_LBR_AMT,IT_NET_AMT,KR_CON_PRC,  KR_CON_WT,KR_RATE,KR_AMT,KR_LBR_RATE,KR_LBR_AMT,KR_NET_AMT,MAIN_USER,DM_NAME,OLD_VCH_NO,NEW_VCH_NO,DM_ORIGIN,  DM_REMARK,DM_COLOR,KR_ACT_WT,KR_ACT_PRC FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO =  '" + mSG[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[DC_Main.i, 26])) + "  ";
									DC_Main.ExeQuteDc(DC_Main.RsQry);
								}
							}
							mSG = null;
							DC_Main.i++;
						}
						if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
						{
							DC_Main.RsQry = "DELETE FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							string text = "";
							int num4 = MSG.Rows - 1;
							DC_Main.i = 1;
							while (DC_Main.i <= num4)
							{
								AxMSFlexGrid mSG2 = MSG;
								text = ((Operators.CompareString(mSG2[DC_Main.i, 1], "", false) == 0) ? (MSG[DC_Main.i, 4] + "_" + DC_Main.MCo_code + DC_Main.MLc_code + DC_Main.MCo_year + DC_Main.MCo_Book + tHdVchNo.Text) : (mSG2[DC_Main.i, 1] + "_" + mSG2[DC_Main.i, 26]));
								if (Operators.CompareString(text, "", false) != 0)
								{
									DC_Main.MsImageNo = text;
									DC_Main.MsImageType = "TagImage";
									DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
									if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
									{
										PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
										MemoryStream memoryStream = new MemoryStream();
										PicImage.Image.Save((Stream)memoryStream, PicImage.Image.RawFormat);
										byte[] buffer = memoryStream.GetBuffer();
										DC_Main.RsQry = ("SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  TAG_NO = '" + mSG2[DC_Main.i, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG2[DC_Main.i, 26]))) ?? "";
										DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
										DC_Main.MsInsertData();
										DataRow dataRow4 = dataTable2.NewRow();
										dataRow4["CO_CODE"] = DC_Main.MCo_code;
										dataRow4["LC_CODE"] = DC_Main.MLc_code;
										if (Operators.CompareString(mSG2[DC_Main.i, 1], "", false) != 0)
										{
											dataRow4["TAG_NO"] = mSG2[DC_Main.i, 1];
										}
										else
										{
											dataRow4["TAG_NO"] = mSG2[DC_Main.i, 4];
										}
										dataRow4["VCH_SRNO"] = Conversion.Val(mSG2[DC_Main.i, 26]);
										dataRow4["TAG_IMAGE"] = buffer;
										dataTable2.Rows.Add(dataRow4);
										((DbDataAdapter)(object)DC_Main.Da).Update(dataTable2);
										dataTable2.Clear();
									}
								}
								mSG2 = null;
								DC_Main.i++;
							}
						}
						if (Operators.CompareString(FormMainBook, "MRP UPDATE", false) == 0)
						{
							DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.ITM_MARGIN = B.MRP_MARGIN,BAR_DETL.ITM_MRP = B.ITM_MRP FROM BAR_DETL,BAR_CAN_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
						{
							if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0))
							{
								DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								Ac_Stock.Tag_Counter_trfr_Stk(DC_Main.MCo_Book, tVchNo.Text);
								DC_Main.RsQry = "DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								Ac_Stock.Dm_Counter_Trfr_Detl(DC_Main.MCo_Book, tVchNo.Text);
							}
							else
							{
								DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.TBL_CODE = B.TO_TBL_CODE FROM BAR_DETL,BAR_CAN_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.TBL_CODE = B.TO_TBL_CODE FROM APR_DETL,BAR_CAN_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.TAG_NO = B.TAG_NO AND APR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
								DC_Main.RsQry = "UPDATE MAIN_STOCK SET MAIN_STOCK.TBL_CODE = B.TO_TBL_CODE FROM MAIN_STOCK,BAR_CAN_DETL AS B WHERE MAIN_STOCK.CO_CODE = B.CO_CODE AND MAIN_STOCK.TAG_NO = B.TAG_NO AND MAIN_STOCK.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
								DC_Main.ExeQuteDc(DC_Main.RsQry);
							}
						}
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
						}
						CurPrnVch = tVchNo.Text;
						DC_Main.MsAcBal(PartyAcCode, Conversions.ToDate(mVchDate.Text + " " + mTime.Text));
						CustOpAmt = DC_Main.MsAcAmtOpBal;
						CustClAmt = DC_Main.MsAcAmtClBal;
						if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
						{
							CurPrnVch = tVchNo.Text;
							CLEAR_DATA();
							BtnReport_Click(btnReport, new EventArgs());
							CurPrnVch = "";
						}
						else
						{
							Interaction.MsgBox((object)"Voucher Is Saved.....", (MsgBoxStyle)0, (object)null);
							CLEAR_DATA();
						}
						CurPrnVch = "";
						CustOpAmt = 0.0;
						CustClAmt = 0.0;
						DC_Main.MsAcAmtOpBal = 0.0;
						DC_Main.MsAcAmtClBal = 0.0;
						DC_Main.MsAcGoldOpBal = 0.0;
						DC_Main.MsAcGoldClBal = 0.0;
						DC_Main.MsAcSilverOpBal = 0.0;
						DC_Main.MsAcSilverClBal = 0.0;
						goto end_IL_0001;
					}
					case 8252:
						num = -1;
						switch (num2)
						{
						case 2:
							((Control)BtnSave).Enabled = true;
							EntryMode = "E";
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001;
						}
						break;
					}
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 8252;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
		if (DateTime.Compare(DC_Main.MsLockDt, Conversions.ToDate(mVchDate.Text)) >= 0)
		{
			Interaction.MsgBox((object)("You Cant Save and Delete This Voucher Becouse Lock Date is = " + Conversions.ToString(DC_Main.MsLockDt) + " ...."), (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else
		{
			if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
			{
				return;
			}
			if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0)
			{
				if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0))
				{
					DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
					DC_Main.ExeQuteDc("DELETE FROM DM_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
					DC_Main.ExeQuteDc("DELETE FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
					DC_Main.ExeQuteDc("DELETE FROM BAR_IDTL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
				}
				else
				{
					DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.TBL_CODE = B.TBL_CODE FROM BAR_DETL,BAR_CAN_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO   AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND  B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_PHYSTK_KeyDown(object sender, KeyEventArgs e)
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

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_PHYSTK_Activated(object sender, EventArgs e)
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
			TEXT_ENTRY.Text = DC_Main.MsCode;
			MSG[MSG.Row, 7] = DC_Main.MsName;
			DC_Main.MsCode = "";
			DC_Main.MsName = "";
		}
		if (DC_Main.MsSlAdj)
		{
			AxMSFlexGrid mSG = MSG;
			mSG[1, 4] = DC_Main.MsSlBill;
			mSG[1, 25] = DC_Main.MsSlBillHdNo;
			mSG[1, 26] = DC_Main.MLc_code;
			mSG[1, 9] = DC_Main.MsSlAcCode;
			mSG[1, 19] = DC_Main.MsSlYrCd;
			mSG[1, 21] = DC_Main.MsSlDbCd;
			mSG[1, 16] = Strings.Format((object)DC_Main.MsSlAmt, "0.00");
			((Control)mVchDate).Focus();
		}
		else
		{
			if ((Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath ?? "", (FileAttribute)0), "", false) != 0) & (Operators.CompareString(DC_Main.MsImagePath, "", false) != 0))
			{
				PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
			}
			else
			{
				PicImage.Image = null;
			}
			((ContainerControl)this).ActiveControl = CurActCtrl;
			CurActCtrl.Focus();
		}
	}

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,C.IT_NAME As ItemNameL,A.MAIN_USER UserL FROM (BAR_CAN_DATA AS A LEFT JOIN BAR_CAN_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.CO_YEAR AND A.CO_BOOK = B.CO_BOOK AND A.VCH_NO = B.VCH_NO) LEFT JOIN ITEM_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.IT_CODE = C.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' GROUP BY A.VCH_NO,A.VCH_DATE,C.IT_NAME,A.MAIN_USER  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 125.0;
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
		//IL_0425: Unknown result type (might be due to invalid IL or missing references)
		//IL_042f: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_02e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f1: Expected O, but got Unknown
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected O, but got Unknown
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		PicImage.Image = null;
		if ((Operators.CompareString(MSG[MSG.Row, 28], "N", false) != 0) & (Operators.CompareString(MSG[MSG.Row, 4], "", false) != 0))
		{
			DC_Main.RsQry = "SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 28] + "' AND IMAGE_TYPE = 'D'";
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
			DC_Main.MsImageNo = MSG[MSG.Row, 1] + "_" + MSG[MSG.Row, 26];
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
					DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 26]))) ?? "";
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
				DC_Main.RsQry = ("SELECT * FROM TAG_IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND  TAG_NO = '" + MSG[MSG.Row, 1] + "' AND VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 26]))) ?? "";
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
		if (Operators.CompareString(FormMainBook, "COUNTER TRFR", false) == 0 && ((Operators.CompareString(DC_Main.SSRegSrNo, "VK178NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VS048NSHG", false) == 0)))
		{
			MSG[MSG.Row, 30] = "Y";
		}
		checked
		{
			if (MSG.Row == MSG.Rows - 1)
			{
				if (Operators.CompareString(EntryMode, "A", false) == 0)
				{
					MSG[MSG.Row, 29] = Conversions.ToString(MSG.Row);
				}
				else
				{
					MSG[MSG.Row, 29] = Conversions.ToString(Conversion.Val(MSG[MSG.Rows - 2, 29]) + 1.0);
				}
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
				MSG.Col = 1;
				MSG.Row = 1;
				MSG_EnterCell(MSG, new EventArgs());
				((Control)TEXT_ENTRY).Focus();
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
				DC_Main.RsQry = "SELECT VCH_NO FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void TR_PHYSTK_Closed(object sender, EventArgs e)
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

	private void lblBook_DoubleClick(object sender, EventArgs e)
	{
		((Control)tHdVchNo).Visible = true;
	}

	private void BtnReport_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Open Report Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(FormMainBook, "SF PRINT", false) == 0)
		{
			((Form)MyProject.Forms.MS_PRINT).ShowDialog();
			if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) != 0)
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DiamondSf.RPT";
				Cr.SelectionFormula = "{BAR_CAN_DETL.CO_CODE} = '" + DC_Main.MCo_code + "' AND {BAR_CAN_DETL.LC_CODE} = '" + DC_Main.MLc_code + "' AND {BAR_CAN_DETL.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {BAR_CAN_DETL.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {BAR_CAN_DETL.VCH_NO} = '" + CurPrnVch + "'";
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
					Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
				}
				DC_Main.MsPrintStatus = false;
			}
		}
		else
		{
			RP_PHY_STOCK rP_PHY_STOCK = new RP_PHY_STOCK();
			((Form)rP_PHY_STOCK).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)rP_PHY_STOCK).Show();
			((Control)rP_PHY_STOCK).Focus();
		}
	}

	private void BtnReset_Click(object sender, EventArgs e)
	{
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Invalid comparison between Unknown and I4
		//IL_035b: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Physical Stock will Reset permantley ?", (MsgBoxStyle)20, (object)null) == 6 && (int)Interaction.MsgBox((object)"Delete All Physical Stock ?", (MsgBoxStyle)20, (object)null) == 6)
		{
			DC_Main.ExeQuteDc("UPDATE APR_DETL SET ISU_REC = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
			DC_Main.RsQry = "SELECT A.ISU_YRCD,A.ISU_DBCD,A.ISU_NO,A.ISU_SRNO FROM APR_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'APR RTN' AND A.ISU_NO <> ''  UNION ALL SELECT B.ISU_YRCD,B.ISU_DBCD,B.ISU_NO,B.ISU_SRNO FROM SL_DETL AS B  WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.BOOK_NAME = 'SALES' AND B.ISU_NO <> ''  UNION ALL SELECT C.ISU_YRCD,C.ISU_DBCD,C.ISU_NO,C.ISU_SRNO FROM RATE_CUT_ISU AS C  WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND C.LC_CODE = '" + DC_Main.MLc_code + "' AND C.BOOK_NAME = 'WH SALES' AND C.ISU_NO <> ''";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.M = 0;
			checked
			{
				while (DC_Main.M < DC_Main.Tbl.Rows.Count)
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE APR_DETL SET ISU_REC = 'Y' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_YRCD"]), (object)"' AND CO_BOOK = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_DBCD"]), (object)"' AND VCH_NO = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_NO"]), (object)"' AND OLD_SRNO = '"), DC_Main.Tbl.Rows[DC_Main.M]["ISU_SRNO"]), (object)"'")));
					DC_Main.M++;
				}
				DC_Main.ExeQuteDc("UPDATE BAR_DETL SET APR_ISU = 'N' WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'");
				DC_Main.RsQry = "UPDATE BAR_DETL SET BAR_DETL.APR_ISU = 'Y' FROM BAR_DETL,APR_DETL AS B WHERE BAR_DETL.CO_CODE = B.CO_CODE AND BAR_DETL.TAG_NO = B.TAG_NO AND BAR_DETL.VCH_SRNO = B.VCH_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.BOOK_NAME = 'APR ISU' AND B.ISU_REC = 'N'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
				DC_Main.ExeQuteDc("DELETE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "'");
				Interaction.MsgBox((object)"Physical Stock Is ReSet...", (MsgBoxStyle)0, (object)null);
				CLEAR_DATA();
			}
		}
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

	private void TR_PHYSTK_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY).SelectionLength = Strings.Len(TEXT_ENTRY.Text);
		}
	}

	private void tEmpCode_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}

	private void tVchDesc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)BtnSave).Enabled = true;
			((Control)BtnSave).Focus();
		}
	}

	private void btnTagPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Expected O, but got Unknown
		//IL_022c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM TAG_PRINT_DATA");
		DC_Main.ExeQuteDc("DELETE FROM IMAGE_DATA");
		checked
		{
			int num = (int)Math.Round(Conversion.Val(nLableSkip.Text));
			DC_Main.i = 1;
			while (DC_Main.i <= num)
			{
				DC_Main.RsQry = "INSERT INTO TAG_PRINT_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,IT_CODE,VCH_SRNO)   VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','" + DC_Main.MCo_Book + "','" + tVchNo.Text + "'," + Conversions.ToString(DC_Main.i) + ",'00',0)";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.i++;
			}
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				if (Operators.CompareString(MSG[DC_Main.M, 1], "", false) != 0)
				{
					DC_Main.RsQry = ("INSERT INTO TAG_PRINT_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE)  SELECT '" + DC_Main.MCo_code + "',LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,OLD_SRNO,VCH_DATE,STK_DATE,VCH_TIME,VCH_TYPE,INOUT_TYPE,ENTRY_TYPE,BOOK_NAME,  AC_CODE,IT_CODE,TAG_NO,LOT_NO,DESIGN_NO,TBL_CODE,ITM_SIZE,ITM_PCS,BAG_WT,ITM_GWT,ITM_OTH_WT,ITM_NWT,ITM_GHT_PRC,ITM_GHT_WT,ITM_TOUCH,ITM_WEST_PRC,ITM_FINE,  LBR_PRC,LBR_RATE,LBR_TYPE,LBR_AMT,OTH_AMT,ITM_RATE,ITM_AMT,TAG_COST,ITM_MARGIN,ITM_MRP,ITM_REMARK,SF_NO,KR_NAME,VCH_SRNO,RATE_TYPE,IT_TYPE,TAG_TYPE,PR_CODE,  HM_ID,HM_ID2,HM_ID3,HM_ID4,HM_ID_WT,HM_ID2_WT,HM_ID3_WT,HM_ID4_WT,ITM_COLOR,LBR_CODE,ITM_STYLE  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 1] + "' and VCH_SRNO = " + Conversions.ToString(Conversion.Val(MSG[DC_Main.M, 26]))) ?? "";
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					if (Operators.CompareString(DC_Main.MsQrCodeGen, "Y", false) == 0)
					{
						QRCodeGenerator val = new QRCodeGenerator();
						QRCodeData val2 = val.CreateQrCode(MSG[DC_Main.M, 1], (ECCLevel)2, false, false, (EciMode)0, -1);
						QRCode val3 = new QRCode(val2);
						PictureBox1.Image = (Image)(object)val3.GetGraphic(3);
						MemoryStream memoryStream = new MemoryStream();
						PictureBox1.Image.Save((Stream)memoryStream, ImageFormat.Jpeg);
						byte[] value = memoryStream.ToArray();
						DC_Main.RsQry = "SELECT * FROM IMAGE_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND TAG_NO = '" + MSG[DC_Main.M, 1] + "' AND VCH_SRNO = " + MSG[DC_Main.M, 26] + " ";
						DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.MsInsertData();
						DataRow dataRow = dataTable.NewRow();
						dataRow["CO_CODE"] = DC_Main.MCo_code;
						dataRow["LC_CODE"] = DC_Main.MLc_code;
						dataRow["SR_NO"] = DC_Main.M;
						dataRow["TAG_NO"] = MSG[DC_Main.M, 1];
						dataRow["VCH_SRNO"] = Conversion.Val(MSG[DC_Main.M, 26]);
						dataRow["TAG_IMAGE"] = value;
						dataTable.Rows.Add(dataRow);
						((DbDataAdapter)(object)DC_Main.Da).Update(dataTable);
						dataTable.Clear();
					}
				}
				DC_Main.M++;
			}
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
				UT_REPORT uT_REPORT = new UT_REPORT();
				((Control)uT_REPORT).Show();
				((Control)uT_REPORT).Focus();
				return;
			}
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
