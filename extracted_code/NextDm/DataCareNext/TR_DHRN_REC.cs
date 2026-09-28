using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
public class TR_DHRN_REC : Form
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
	[AccessedThroughProperty("PicImage")]
	private PictureBox _PicImage;

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
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItDesc")]
	private TextBox _tItDesc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnAmt")]
	private TextBox _nDhrnAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nMonthlyInt")]
	private TextBox _nMonthlyInt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPacketNo")]
	private TextBox _tPacketNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnMonth")]
	private TextBox _nDhrnMonth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntPrc")]
	private TextBox _nIntPrc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntDays")]
	private TextBox _nIntDays;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDate")]
	private MaskedTextBox _mToDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntAmt")]
	private TextBox _nIntAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tIsuNo")]
	private TextBox _tIsuNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnIssue")]
	private SimpleButton _BtnIssue;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRecAc")]
	private TextBox _tRecAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntRecAmt")]
	private TextBox _nIntRecAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mIsuDate")]
	private MaskedTextBox _mIsuDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDate")]
	private MaskedTextBox _mFromDate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnReceived")]
	private TextBox _nDhrnReceived;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntKasr")]
	private TextBox _nIntKasr;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkInt")]
	private CheckBox _chkInt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboLoanType")]
	private ComboBox _cboLoanType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PicAcImage")]
	private PictureBox _PicAcImage;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMultyTimeIsu")]
	private SimpleButton _btnMultyTimeIsu;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFineRate")]
	private TextBox _nFineRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPayAmt")]
	private TextBox _nPayAmt;

	private string UsUPdate;

	private string UsDelete;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private int MsgLastCol;

	private bool MsgClear;

	private bool MsgClearIdtl;

	private string CurPrnVch;

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private int CurRow;

	private string CurIntTypeCalc;

	private double DhrnAdjAmt;

	private string GoldDesc;

	private string IsuRec;

	private double ItGoldWt;

	private double ItSilverWt;

	private double OldIntPrc;

	private double OldMontIntPrc;

	private int OldIntDay;

	private string CurTagImage;

	private string IsuYrCd;

	private string IsuDbCd;

	private string OldIsuNo;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

	private double AdvanceRecAmt;

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

	private DataTable RsBarDetl;

	private DataTable RsBarIdtl;

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

	private const int cPacketNo = 1;

	private const int cCustName = 2;

	private const int cItCode = 3;

	private const int cItName = 4;

	private const int cPcs = 5;

	private const int cGrWt = 6;

	private const int cOthWt = 7;

	private const int cNetWt = 8;

	private const int cTouch = 9;

	private const int cWestPrc = 10;

	private const int cFine = 11;

	private const int cRate = 12;

	private const int cItAmt = 13;

	private const int cNetAmt = 14;

	private const int cPacketReIsu = 15;

	private const int cItType = 16;

	private const int cRateType = 17;

	private const int cItDesc = 18;

	private const int cOldGwt = 19;

	private const int cOldNwt = 20;

	private const int cOldTouch = 21;

	private const int cOldWest = 22;

	private const int cOldRate = 23;

	private const int cDhrnNo = 24;

	private const int cDhrnYrCd = 25;

	private const int cDhrnDbCd = 26;

	private const int cDhrnSrNo = 27;

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

	internal virtual TextBox tItDesc
	{
		[CompilerGenerated]
		get
		{
			return _tItDesc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tAdd1_KeyDown);
			TextBox val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItDesc = value;
			val2 = _tItDesc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox nDhrnAmt
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnAmt_KeyDown);
			TextBox val2 = _nDhrnAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnAmt = value;
			val2 = _nDhrnAmt;
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

	internal virtual TextBox nMonthlyInt
	{
		[CompilerGenerated]
		get
		{
			return _nMonthlyInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nMonthlyInt_KeyDown);
			TextBox val2 = _nMonthlyInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nMonthlyInt = value;
			val2 = _nMonthlyInt;
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

	internal virtual TextBox tPacketNo
	{
		[CompilerGenerated]
		get
		{
			return _tPacketNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPacketNo_KeyDown);
			TextBox val2 = _tPacketNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPacketNo = value;
			val2 = _tPacketNo;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nDhrnMonth
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnMonth_KeyDown);
			TextBox val2 = _nDhrnMonth;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnMonth = value;
			val2 = _nDhrnMonth;
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

	internal virtual TextBox nIntPrc
	{
		[CompilerGenerated]
		get
		{
			return _nIntPrc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntPrc_KeyDown);
			TextBox val2 = _nIntPrc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntPrc = value;
			val2 = _nIntPrc;
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

	internal virtual TextBox nIntDays
	{
		[CompilerGenerated]
		get
		{
			return _nIntDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntDays_KeyDown);
			TextBox val2 = _nIntDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntDays = value;
			val2 = _nIntDays;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mToDate
	{
		[CompilerGenerated]
		get
		{
			return _mToDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mToDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mToDate_KeyDown);
			MaskedTextBox val2 = _mToDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mToDate = value;
			val2 = _mToDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
				((Control)val2).KeyDown += val;
			}
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

	internal virtual TextBox nIntAmt
	{
		[CompilerGenerated]
		get
		{
			return _nIntAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntAmt_KeyDown);
			TextBox val2 = _nIntAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntAmt = value;
			val2 = _nIntAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
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

	internal virtual SimpleButton BtnIssue
	{
		[CompilerGenerated]
		get
		{
			return _BtnIssue;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnIssue_Click;
			SimpleButton val = _BtnIssue;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnIssue = value;
			val = _BtnIssue;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label24")]
	private virtual Label _Label24;

	internal virtual Label Label24
	{
		get
		{
			return _Label24;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label24 = value;
		}
	}

	internal virtual TextBox tRecAc
	{
		[CompilerGenerated]
		get
		{
			return _tRecAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tRecAc_KeyDown);
			TextBox val2 = _tRecAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tRecAc = value;
			val2 = _tRecAc;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tRecAcName")]
	private virtual TextBox _tRecAcName;

	internal virtual TextBox tRecAcName
	{
		get
		{
			return _tRecAcName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tRecAcName = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label25")]
	private virtual Label _Label25;

	internal virtual Label Label25
	{
		get
		{
			return _Label25;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label25 = value;
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

	internal virtual TextBox nIntRecAmt
	{
		[CompilerGenerated]
		get
		{
			return _nIntRecAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntRecAmt_KeyDown);
			TextBox val2 = _nIntRecAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntRecAmt = value;
			val2 = _nIntRecAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual MaskedTextBox mIsuDate
	{
		[CompilerGenerated]
		get
		{
			return _mIsuDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mIsuDate_KeyDown);
			MaskedTextBox val2 = _mIsuDate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_mIsuDate = value;
			val2 = _mIsuDate;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nDhrnAdjAmt")]
	private virtual TextBox _nDhrnAdjAmt;

	internal virtual TextBox nDhrnAdjAmt
	{
		get
		{
			return _nDhrnAdjAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nDhrnAdjAmt = value;
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
	[AccessedThroughProperty("nPandingDhrn")]
	private virtual TextBox _nPandingDhrn;

	internal virtual TextBox nPandingDhrn
	{
		get
		{
			return _nPandingDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPandingDhrn = value;
		}
	}

	internal virtual MaskedTextBox mFromDate
	{
		[CompilerGenerated]
		get
		{
			return _mFromDate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = mFromDate_GotFocus;
			KeyEventHandler val = new KeyEventHandler(mFromDate_KeyDown);
			MaskedTextBox val2 = _mFromDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_mFromDate = value;
			val2 = _mFromDate;
			if (val2 != null)
			{
				((Control)val2).GotFocus += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nPanIntAmt")]
	private virtual TextBox _nPanIntAmt;

	internal virtual TextBox nPanIntAmt
	{
		get
		{
			return _nPanIntAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nPanIntAmt = value;
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
	[AccessedThroughProperty("nIntMonth")]
	private virtual TextBox _nIntMonth;

	internal virtual TextBox nIntMonth
	{
		get
		{
			return _nIntMonth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nIntMonth = value;
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

	internal virtual TextBox nDhrnReceived
	{
		[CompilerGenerated]
		get
		{
			return _nDhrnReceived;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nDhrnReceived_KeyDown);
			TextBox val2 = _nDhrnReceived;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nDhrnReceived = value;
			val2 = _nDhrnReceived;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label20")]
	private virtual Label _Label20;

	internal virtual Label Label20
	{
		get
		{
			return _Label20;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label20 = value;
		}
	}

	internal virtual TextBox nIntKasr
	{
		[CompilerGenerated]
		get
		{
			return _nIntKasr;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nIntKasr_KeyDown);
			TextBox val2 = _nIntKasr;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nIntKasr = value;
			val2 = _nIntKasr;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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
	[AccessedThroughProperty("nTotRec")]
	private virtual TextBox _nTotRec;

	internal virtual TextBox nTotRec
	{
		get
		{
			return _nTotRec;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nTotRec = value;
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
	[AccessedThroughProperty("nAdjInt")]
	private virtual TextBox _nAdjInt;

	internal virtual TextBox nAdjInt
	{
		get
		{
			return _nAdjInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAdjInt = value;
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
	[AccessedThroughProperty("nAdjDhiran")]
	private virtual TextBox _nAdjDhiran;

	internal virtual TextBox nAdjDhiran
	{
		get
		{
			return _nAdjDhiran;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAdjDhiran = value;
		}
	}

	internal virtual CheckBox chkInt
	{
		[CompilerGenerated]
		get
		{
			return _chkInt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(chkInt_KeyDown);
			EventHandler eventHandler = chkInt_Click;
			CheckBox val2 = _chkInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Click -= eventHandler;
			}
			_chkInt = value;
			val2 = _chkInt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nIntYear")]
	private virtual TextBox _nIntYear;

	internal virtual TextBox nIntYear
	{
		get
		{
			return _nIntYear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nIntYear = value;
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

	internal virtual ComboBox cboLoanType
	{
		[CompilerGenerated]
		get
		{
			return _cboLoanType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboLoanType_KeyDown);
			EventHandler eventHandler = cboLoanType_SelectedIndexChanged;
			ComboBox val2 = _cboLoanType;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboLoanType = value;
			val2 = _cboLoanType;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblLoanType")]
	private virtual Label _lblLoanType;

	internal virtual Label lblLoanType
	{
		get
		{
			return _lblLoanType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblLoanType = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label30")]
	private virtual Label _Label30;

	internal virtual Label Label30
	{
		get
		{
			return _Label30;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label30 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nAdvanceDhiran")]
	private virtual TextBox _nAdvanceDhiran;

	internal virtual TextBox nAdvanceDhiran
	{
		get
		{
			return _nAdvanceDhiran;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nAdvanceDhiran = value;
		}
	}

	internal virtual PictureBox PicAcImage
	{
		[CompilerGenerated]
		get
		{
			return _PicAcImage;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PicAcImage_DoubleClick;
			PictureBox val = _PicAcImage;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PicAcImage = value;
			val = _PicAcImage;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnMultyTimeIsu
	{
		[CompilerGenerated]
		get
		{
			return _btnMultyTimeIsu;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMultyTimeIsu_Click;
			SimpleButton val = _btnMultyTimeIsu;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMultyTimeIsu = value;
			val = _btnMultyTimeIsu;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblRCutAmt")]
	private virtual Label _lblRCutAmt;

	internal virtual Label lblRCutAmt
	{
		get
		{
			return _lblRCutAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblRCutAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblFineRate")]
	private virtual Label _lblFineRate;

	internal virtual Label lblFineRate
	{
		get
		{
			return _lblFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblFineRate = value;
		}
	}

	internal virtual TextBox nFineRate
	{
		[CompilerGenerated]
		get
		{
			return _nFineRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFineRate_KeyDown);
			TextBox val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFineRate = value;
			val2 = _nFineRate;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nRcutAmt")]
	private virtual TextBox _nRcutAmt;

	internal virtual TextBox nRcutAmt
	{
		get
		{
			return _nRcutAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nRcutAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblPayAmt")]
	private virtual Label _lblPayAmt;

	internal virtual Label lblPayAmt
	{
		get
		{
			return _lblPayAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblPayAmt = value;
		}
	}

	internal virtual TextBox nPayAmt
	{
		[CompilerGenerated]
		get
		{
			return _nPayAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nPayAmt_KeyDown);
			TextBox val2 = _nPayAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nPayAmt = value;
			val2 = _nPayAmt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOsAmt")]
	private virtual TextBox _nOsAmt;

	internal virtual TextBox nOsAmt
	{
		get
		{
			return _nOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nOsAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblOsAmt")]
	private virtual Label _lblOsAmt;

	internal virtual Label lblOsAmt
	{
		get
		{
			return _lblOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOsAmt = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblOrnaAgainstDhrn")]
	private virtual Label _lblOrnaAgainstDhrn;

	internal virtual Label lblOrnaAgainstDhrn
	{
		get
		{
			return _lblOrnaAgainstDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblOrnaAgainstDhrn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nOrnaAginestDhrn")]
	private virtual TextBox _nOrnaAginestDhrn;

	internal virtual TextBox nOrnaAginestDhrn
	{
		get
		{
			return _nOrnaAginestDhrn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_nOrnaAginestDhrn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMobile")]
	private virtual Label _lblMobile;

	internal virtual Label lblMobile
	{
		get
		{
			return _lblMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCity")]
	private virtual Label _lblCity;

	internal virtual Label lblCity
	{
		get
		{
			return _lblCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCity = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd1")]
	private virtual Label _lblAdd1;

	internal virtual Label lblAdd1
	{
		get
		{
			return _lblAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Label31")]
	private virtual Label _Label31;

	internal virtual Label Label31
	{
		get
		{
			return _Label31;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Label31 = value;
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

	public TR_DHRN_REC()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_DHRN_REC_Load;
		((Form)this).Deactivate += TR_DHRN_REC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_DHRN_REC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_DHRN_REC_KeyDown);
		((Form)this).Activated += TR_DHRN_REC_Activated;
		((Form)this).Closed += TR_DHRN_REC_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_DHRN_REC_KeyUp);
		CurIntTypeCalc = "";
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
		//IL_05f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0600: Expected O, but got Unknown
		//IL_06b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06bd: Expected O, but got Unknown
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		//IL_074a: Expected O, but got Unknown
		//IL_07e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f1: Expected O, but got Unknown
		//IL_089f: Unknown result type (might be due to invalid IL or missing references)
		//IL_08a9: Expected O, but got Unknown
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Expected O, but got Unknown
		//IL_09d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_09df: Expected O, but got Unknown
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a78: Expected O, but got Unknown
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae5: Expected O, but got Unknown
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		//IL_0bfb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c05: Expected O, but got Unknown
		//IL_0cae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb8: Expected O, but got Unknown
		//IL_0dd5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddf: Expected O, but got Unknown
		//IL_0eea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ef4: Expected O, but got Unknown
		//IL_0f57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f61: Expected O, but got Unknown
		//IL_10f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11b2: Expected O, but got Unknown
		//IL_12aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b4: Expected O, but got Unknown
		//IL_150d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1517: Expected O, but got Unknown
		//IL_15ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f9: Expected O, but got Unknown
		//IL_1695: Unknown result type (might be due to invalid IL or missing references)
		//IL_169f: Expected O, but got Unknown
		//IL_17da: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e4: Expected O, but got Unknown
		//IL_182f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1839: Expected O, but got Unknown
		//IL_18b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_18bd: Expected O, but got Unknown
		//IL_193f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1949: Expected O, but got Unknown
		//IL_1a10: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1a: Expected O, but got Unknown
		//IL_1ac1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1acb: Expected O, but got Unknown
		//IL_1b4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b56: Expected O, but got Unknown
		//IL_1bde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be8: Expected O, but got Unknown
		//IL_1c99: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca3: Expected O, but got Unknown
		//IL_1d54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d5e: Expected O, but got Unknown
		//IL_1e13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1d: Expected O, but got Unknown
		//IL_1e78: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e82: Expected O, but got Unknown
		//IL_1f00: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f0a: Expected O, but got Unknown
		//IL_1fb8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc2: Expected O, but got Unknown
		//IL_204a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2054: Expected O, but got Unknown
		//IL_2100: Unknown result type (might be due to invalid IL or missing references)
		//IL_210a: Expected O, but got Unknown
		//IL_2158: Unknown result type (might be due to invalid IL or missing references)
		//IL_2162: Expected O, but got Unknown
		//IL_2216: Unknown result type (might be due to invalid IL or missing references)
		//IL_2220: Expected O, but got Unknown
		//IL_22d7: Unknown result type (might be due to invalid IL or missing references)
		//IL_22e1: Expected O, but got Unknown
		//IL_238f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2399: Expected O, but got Unknown
		//IL_2431: Unknown result type (might be due to invalid IL or missing references)
		//IL_243b: Expected O, but got Unknown
		//IL_24ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_24f6: Expected O, but got Unknown
		//IL_2585: Unknown result type (might be due to invalid IL or missing references)
		//IL_258f: Expected O, but got Unknown
		//IL_263d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2647: Expected O, but got Unknown
		//IL_26df: Unknown result type (might be due to invalid IL or missing references)
		//IL_26e9: Expected O, but got Unknown
		//IL_279a: Unknown result type (might be due to invalid IL or missing references)
		//IL_27a4: Expected O, but got Unknown
		//IL_283f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2849: Expected O, but got Unknown
		//IL_28fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2904: Expected O, but got Unknown
		//IL_2993: Unknown result type (might be due to invalid IL or missing references)
		//IL_299d: Expected O, but got Unknown
		//IL_2a51: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a5b: Expected O, but got Unknown
		//IL_2b0c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b16: Expected O, but got Unknown
		//IL_2ba5: Unknown result type (might be due to invalid IL or missing references)
		//IL_2baf: Expected O, but got Unknown
		//IL_2c4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c54: Expected O, but got Unknown
		//IL_2d02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d0c: Expected O, but got Unknown
		//IL_2d95: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d9f: Expected O, but got Unknown
		//IL_2e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e2e: Expected O, but got Unknown
		//IL_2ec7: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ed1: Expected O, but got Unknown
		//IL_2f6d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f77: Expected O, but got Unknown
		//IL_3045: Unknown result type (might be due to invalid IL or missing references)
		//IL_304f: Expected O, but got Unknown
		//IL_3127: Unknown result type (might be due to invalid IL or missing references)
		//IL_3131: Expected O, but got Unknown
		//IL_31cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d7: Expected O, but got Unknown
		//IL_32ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_32f6: Expected O, but got Unknown
		//IL_33a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_33b1: Expected O, but got Unknown
		//IL_3432: Unknown result type (might be due to invalid IL or missing references)
		//IL_343c: Expected O, but got Unknown
		//IL_34c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ce: Expected O, but got Unknown
		//IL_357f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3589: Expected O, but got Unknown
		//IL_3649: Unknown result type (might be due to invalid IL or missing references)
		//IL_3653: Expected O, but got Unknown
		//IL_36e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ec: Expected O, but got Unknown
		//IL_3780: Unknown result type (might be due to invalid IL or missing references)
		//IL_378a: Expected O, but got Unknown
		//IL_383b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3845: Expected O, but got Unknown
		//IL_38f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3900: Expected O, but got Unknown
		//IL_399b: Unknown result type (might be due to invalid IL or missing references)
		//IL_39a5: Expected O, but got Unknown
		//IL_3a61: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a6b: Expected O, but got Unknown
		//IL_3b04: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b0e: Expected O, but got Unknown
		//IL_3ba6: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bb0: Expected O, but got Unknown
		//IL_3c61: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c6b: Expected O, but got Unknown
		//IL_3d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d35: Expected O, but got Unknown
		//IL_3dc4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dce: Expected O, but got Unknown
		//IL_3e7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3e89: Expected O, but got Unknown
		//IL_3f18: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f22: Expected O, but got Unknown
		//IL_3fe2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3fec: Expected O, but got Unknown
		//IL_407b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4085: Expected O, but got Unknown
		//IL_4145: Unknown result type (might be due to invalid IL or missing references)
		//IL_414f: Expected O, but got Unknown
		//IL_41de: Unknown result type (might be due to invalid IL or missing references)
		//IL_41e8: Expected O, but got Unknown
		//IL_42a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_42b2: Expected O, but got Unknown
		//IL_4344: Unknown result type (might be due to invalid IL or missing references)
		//IL_434e: Expected O, but got Unknown
		//IL_43ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_4409: Expected O, but got Unknown
		//IL_449b: Unknown result type (might be due to invalid IL or missing references)
		//IL_44a5: Expected O, but got Unknown
		//IL_4556: Unknown result type (might be due to invalid IL or missing references)
		//IL_4560: Expected O, but got Unknown
		//IL_460c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4616: Expected O, but got Unknown
		//IL_46db: Unknown result type (might be due to invalid IL or missing references)
		//IL_46e5: Expected O, but got Unknown
		//IL_4777: Unknown result type (might be due to invalid IL or missing references)
		//IL_4781: Expected O, but got Unknown
		//IL_4841: Unknown result type (might be due to invalid IL or missing references)
		//IL_484b: Expected O, but got Unknown
		//IL_48b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_48c1: Expected O, but got Unknown
		//IL_4972: Unknown result type (might be due to invalid IL or missing references)
		//IL_497c: Expected O, but got Unknown
		//IL_4a3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_4a44: Expected O, but got Unknown
		//IL_4b8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b97: Expected O, but got Unknown
		//IL_4c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c79: Expected O, but got Unknown
		//IL_4d15: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d1f: Expected O, but got Unknown
		//IL_4e34: Unknown result type (might be due to invalid IL or missing references)
		//IL_4e3e: Expected O, but got Unknown
		//IL_4eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_4f09: Expected O, but got Unknown
		//IL_4fc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_4fd1: Expected O, but got Unknown
		//IL_507e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5088: Expected O, but got Unknown
		//IL_5138: Unknown result type (might be due to invalid IL or missing references)
		//IL_5142: Expected O, but got Unknown
		//IL_5200: Unknown result type (might be due to invalid IL or missing references)
		//IL_520a: Expected O, but got Unknown
		//IL_52b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_52c1: Expected O, but got Unknown
		//IL_5371: Unknown result type (might be due to invalid IL or missing references)
		//IL_537b: Expected O, but got Unknown
		//IL_543c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5446: Expected O, but got Unknown
		//IL_5507: Unknown result type (might be due to invalid IL or missing references)
		//IL_5511: Expected O, but got Unknown
		//IL_55b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_55ba: Expected O, but got Unknown
		//IL_566e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5678: Expected O, but got Unknown
		//IL_572c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5736: Expected O, but got Unknown
		//IL_57ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_57f4: Expected O, but got Unknown
		//IL_58a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_58af: Expected O, but got Unknown
		//IL_5960: Unknown result type (might be due to invalid IL or missing references)
		//IL_596a: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_DHRN_REC));
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
		PicImage = new PictureBox();
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
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY = new TextBox();
		Label8 = new Label();
		tBillNo = new TextBox();
		tItDesc = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		LOpAmt = new Label();
		LClAmt = new Label();
		Label16 = new Label();
		nDhrnAmt = new TextBox();
		Label5 = new Label();
		nMonthlyInt = new TextBox();
		Label14 = new Label();
		tPacketNo = new TextBox();
		Label15 = new Label();
		nDhrnMonth = new TextBox();
		Label17 = new Label();
		nIntPrc = new TextBox();
		Label18 = new Label();
		Label19 = new Label();
		nIntDays = new TextBox();
		mToDate = new MaskedTextBox();
		Label21 = new Label();
		nIntAmt = new TextBox();
		tIsuNo = new TextBox();
		tIsuYrCd = new TextBox();
		tIsuDbCd = new TextBox();
		Label23 = new Label();
		BtnIssue = new SimpleButton();
		Label24 = new Label();
		tRecAc = new TextBox();
		tRecAcName = new TextBox();
		Label25 = new Label();
		Label6 = new Label();
		nIntRecAmt = new TextBox();
		mIsuDate = new MaskedTextBox();
		Label7 = new Label();
		Label9 = new Label();
		nDhrnAdjAmt = new TextBox();
		Label10 = new Label();
		nPandingDhrn = new TextBox();
		mFromDate = new MaskedTextBox();
		Label11 = new Label();
		Label13 = new Label();
		nPanIntAmt = new TextBox();
		Label26 = new Label();
		nIntMonth = new TextBox();
		Label12 = new Label();
		nDhrnReceived = new TextBox();
		Label20 = new Label();
		nIntKasr = new TextBox();
		Label22 = new Label();
		nTotRec = new TextBox();
		Label27 = new Label();
		nAdjInt = new TextBox();
		Label28 = new Label();
		nAdjDhiran = new TextBox();
		chkInt = new CheckBox();
		nIntYear = new TextBox();
		Label29 = new Label();
		cboLoanType = new ComboBox();
		lblLoanType = new Label();
		Label30 = new Label();
		nAdvanceDhiran = new TextBox();
		PicAcImage = new PictureBox();
		btnMultyTimeIsu = new SimpleButton();
		lblRCutAmt = new Label();
		lblFineRate = new Label();
		nFineRate = new TextBox();
		nRcutAmt = new TextBox();
		lblPayAmt = new Label();
		nPayAmt = new TextBox();
		nOsAmt = new TextBox();
		lblOsAmt = new Label();
		lblOrnaAgainstDhrn = new Label();
		nOrnaAginestDhrn = new TextBox();
		lblMobile = new Label();
		lblCity = new Label();
		lblAdd1 = new Label();
		Label31 = new Label();
		Label32 = new Label();
		Label33 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((ISupportInitialize)MSG_TOT).BeginInit();
		((ISupportInitialize)PicAcImage).BeginInit();
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
		((Control)lblBook).TabIndex = 27;
		lblBook.Text = "Dhrn Receive";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(320, 38);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(243, 39);
		((Control)lblBDate).Name = "lblBDate";
		((Control)lblBDate).Size = new Size(71, 20);
		((Control)lblBDate).TabIndex = 1126;
		lblBDate.Text = "Vch Date";
		lblBDate.TextAlign = (ContentAlignment)64;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(37, 40);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(62, 20);
		((Control)Label2).TabIndex = 1125;
		Label2.Text = "Vch No";
		Label2.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchNo).BackColor = Color.White;
		((Control)tVchNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchNo).Location = new Point(105, 38);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(491, 38);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(89, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(402, 38);
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
		((Control)PnlBotam).TabIndex = 25;
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
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(677, 67);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(200, 164);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(636, 155);
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
		((Control)BtnF1).Size = new Size(31, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1235, 432);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(104, 67);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(77, 23);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 67);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(393, 23);
		((Control)tAcName).TabIndex = 26;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 66);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(75, 20);
		((Control)Label1).TabIndex = 1157;
		Label1.Text = "Party Code";
		Label1.TextAlign = (ContentAlignment)64;
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
		((Control)tEmpCode).Location = new Point(133, 471);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(76, 23);
		((Control)tEmpCode).TabIndex = 23;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(215, 471);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(60, 471);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(53, 500);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(133, 500);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(402, 53);
		((Control)tVchDesc).TabIndex = 24;
		((Control)MSG).Location = new Point(14, 269);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1156, 118);
		((Control)MSG).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(514, 311);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 18;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(36, 124);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(104, 124);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((TextBoxBase)tBillNo).ReadOnly = true;
		((Control)tBillNo).Size = new Size(114, 23);
		((Control)tBillNo).TabIndex = 4;
		((TextBoxBase)tItDesc).BackColor = Color.White;
		((Control)tItDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tItDesc).ForeColor = Color.Maroon;
		((Control)tItDesc).Location = new Point(133, 413);
		((TextBoxBase)tItDesc).MaxLength = 50;
		((Control)tItDesc).Name = "tItDesc";
		((Control)tItDesc).Size = new Size(402, 23);
		((Control)tItDesc).TabIndex = 28;
		((Control)MSG_TOT).Location = new Point(14, 388);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1153, 15);
		((Control)MSG_TOT).TabIndex = 1179;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(1022, 41);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1208;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(1022, 529);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((Control)Label16).BackColor = Color.Transparent;
		((Control)Label16).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(20, 153);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(79, 20);
		((Control)Label16).TabIndex = 1213;
		Label16.Text = "Dhiran Amt";
		Label16.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnAmt).BackColor = Color.OldLace;
		((Control)nDhrnAmt).Font = new Font("Tahoma", 9f);
		((Control)nDhrnAmt).Location = new Point(104, 153);
		((TextBoxBase)nDhrnAmt).MaxLength = 10;
		((Control)nDhrnAmt).Name = "nDhrnAmt";
		((TextBoxBase)nDhrnAmt).ReadOnly = true;
		((Control)nDhrnAmt).Size = new Size(114, 22);
		((Control)nDhrnAmt).TabIndex = 6;
		nDhrnAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(404, 180);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(96, 20);
		((Control)Label5).TabIndex = 1215;
		Label5.Text = "Monthli Int %";
		Label5.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nMonthlyInt).BackColor = Color.White;
		((Control)nMonthlyInt).Font = new Font("Tahoma", 9f);
		((Control)nMonthlyInt).Location = new Point(506, 181);
		((TextBoxBase)nMonthlyInt).MaxLength = 10;
		((Control)nMonthlyInt).Name = "nMonthlyInt";
		((Control)nMonthlyInt).Size = new Size(74, 22);
		((Control)nMonthlyInt).TabIndex = 11;
		nMonthlyInt.TextAlign = (HorizontalAlignment)1;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(231, 126);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(83, 20);
		((Control)Label14).TabIndex = 1223;
		Label14.Text = "Packet No";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tPacketNo).BackColor = Color.White;
		((Control)tPacketNo).Font = new Font("Tahoma", 9f);
		((Control)tPacketNo).Location = new Point(320, 125);
		((TextBoxBase)tPacketNo).MaxLength = 10;
		((Control)tPacketNo).Name = "tPacketNo";
		((TextBoxBase)tPacketNo).ReadOnly = true;
		((Control)tPacketNo).Size = new Size(76, 22);
		((Control)tPacketNo).TabIndex = 5;
		tPacketNo.TextAlign = (HorizontalAlignment)1;
		((Control)Label15).BackColor = Color.Transparent;
		((Control)Label15).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(402, 152);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(98, 20);
		((Control)Label15).TabIndex = 1221;
		Label15.Text = "Dhiran Month";
		Label15.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnMonth).BackColor = Color.White;
		((Control)nDhrnMonth).Font = new Font("Tahoma", 9f);
		((Control)nDhrnMonth).Location = new Point(506, 153);
		((TextBoxBase)nDhrnMonth).MaxLength = 10;
		((Control)nDhrnMonth).Name = "nDhrnMonth";
		((TextBoxBase)nDhrnMonth).ReadOnly = true;
		((Control)nDhrnMonth).Size = new Size(74, 22);
		((Control)nDhrnMonth).TabIndex = 8;
		nDhrnMonth.TextAlign = (HorizontalAlignment)1;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(227, 181);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(87, 20);
		((Control)Label17).TabIndex = 1219;
		Label17.Text = "Interest %";
		Label17.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntPrc).BackColor = Color.White;
		((Control)nIntPrc).Font = new Font("Tahoma", 9f);
		((Control)nIntPrc).Location = new Point(320, 181);
		((TextBoxBase)nIntPrc).MaxLength = 10;
		((Control)nIntPrc).Name = "nIntPrc";
		((Control)nIntPrc).Size = new Size(76, 22);
		((Control)nIntPrc).TabIndex = 10;
		nIntPrc.TextAlign = (HorizontalAlignment)1;
		((Control)Label18).BackColor = Color.Transparent;
		((Control)Label18).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label18).ForeColor = Color.Black;
		Label18.ImeMode = (ImeMode)0;
		((Control)Label18).Location = new Point(238, 210);
		((Control)Label18).Name = "Label18";
		((Control)Label18).Size = new Size(73, 20);
		((Control)Label18).TabIndex = 1227;
		Label18.Text = "To Date";
		Label18.TextAlign = (ContentAlignment)64;
		((Control)Label19).BackColor = Color.Transparent;
		((Control)Label19).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label19).ForeColor = Color.Black;
		Label19.ImeMode = (ImeMode)0;
		((Control)Label19).Location = new Point(404, 208);
		((Control)Label19).Name = "Label19";
		((Control)Label19).Size = new Size(96, 20);
		((Control)Label19).TabIndex = 1225;
		Label19.Text = "Interest Days";
		Label19.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntDays).BackColor = Color.White;
		((Control)nIntDays).Font = new Font("Tahoma", 9f);
		((Control)nIntDays).Location = new Point(506, 209);
		((TextBoxBase)nIntDays).MaxLength = 10;
		((Control)nIntDays).Name = "nIntDays";
		((Control)nIntDays).Size = new Size(74, 22);
		((Control)nIntDays).TabIndex = 14;
		nIntDays.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)mToDate).BackColor = Color.White;
		((Control)mToDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDate).Location = new Point(320, 209);
		mToDate.Mask = "00/00/0000";
		((Control)mToDate).Name = "mToDate";
		((Control)mToDate).Size = new Size(76, 23);
		((Control)mToDate).TabIndex = 13;
		mToDate.ValidatingType = typeof(DateTime);
		((Control)Label21).BackColor = Color.Transparent;
		((Control)Label21).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label21).ForeColor = Color.Black;
		Label21.ImeMode = (ImeMode)0;
		((Control)Label21).Location = new Point(14, 238);
		((Control)Label21).Name = "Label21";
		((Control)Label21).Size = new Size(85, 20);
		((Control)Label21).TabIndex = 1232;
		Label21.Text = "Int Amount";
		Label21.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntAmt).BackColor = Color.White;
		((Control)nIntAmt).Font = new Font("Tahoma", 9f);
		((Control)nIntAmt).Location = new Point(105, 238);
		((TextBoxBase)nIntAmt).MaxLength = 10;
		((Control)nIntAmt).Name = "nIntAmt";
		((Control)nIntAmt).Size = new Size(76, 22);
		((Control)nIntAmt).TabIndex = 15;
		nIntAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuNo).BackColor = Color.White;
		((Control)tIsuNo).Font = new Font("Tahoma", 9f);
		((Control)tIsuNo).Location = new Point(104, 96);
		((TextBoxBase)tIsuNo).MaxLength = 10;
		((Control)tIsuNo).Name = "tIsuNo";
		((Control)tIsuNo).Size = new Size(77, 22);
		((Control)tIsuNo).TabIndex = 3;
		tIsuNo.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuYrCd).BackColor = Color.White;
		((Control)tIsuYrCd).Font = new Font("Tahoma", 9f);
		((Control)tIsuYrCd).Location = new Point(402, 96);
		((TextBoxBase)tIsuYrCd).MaxLength = 10;
		((Control)tIsuYrCd).Name = "tIsuYrCd";
		((TextBoxBase)tIsuYrCd).ReadOnly = true;
		((Control)tIsuYrCd).Size = new Size(83, 22);
		((Control)tIsuYrCd).TabIndex = 1236;
		tIsuYrCd.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)tIsuDbCd).BackColor = Color.White;
		((Control)tIsuDbCd).Font = new Font("Tahoma", 9f);
		((Control)tIsuDbCd).Location = new Point(492, 96);
		((TextBoxBase)tIsuDbCd).MaxLength = 10;
		((Control)tIsuDbCd).Name = "tIsuDbCd";
		((TextBoxBase)tIsuDbCd).ReadOnly = true;
		((Control)tIsuDbCd).Size = new Size(88, 22);
		((Control)tIsuDbCd).TabIndex = 1237;
		tIsuDbCd.TextAlign = (HorizontalAlignment)1;
		((Control)Label23).BackColor = Color.Transparent;
		((Control)Label23).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label23).ForeColor = Color.Black;
		Label23.ImeMode = (ImeMode)0;
		((Control)Label23).Location = new Point(31, 96);
		((Control)Label23).Name = "Label23";
		((Control)Label23).Size = new Size(67, 20);
		((Control)Label23).TabIndex = 1238;
		Label23.Text = "Issue No";
		Label23.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnIssue).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnIssue).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnIssue).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnIssue).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnIssue).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnIssue).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnIssue).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnIssue).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnIssue).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnIssue).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnIssue).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnIssue).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnIssue).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)BtnIssue).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnIssue).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnIssue).AppearancePressed.Options.UseFont = true;
		((Control)BtnIssue).Location = new Point(187, 96);
		((BaseControl)BtnIssue).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnIssue).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnIssue).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnIssue).Name = "BtnIssue";
		((Control)BtnIssue).Size = new Size(31, 23);
		((Control)BtnIssue).TabIndex = 1239;
		BtnIssue.Text = "F1";
		((BaseControl)BtnIssue).ToolTip = "Voucher Help";
		((Control)Label24).BackColor = Color.Transparent;
		((Control)Label24).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label24).ForeColor = Color.Black;
		Label24.ImeMode = (ImeMode)0;
		((Control)Label24).Location = new Point(17, 413);
		((Control)Label24).Name = "Label24";
		((Control)Label24).Size = new Size(112, 20);
		((Control)Label24).TabIndex = 1240;
		Label24.Text = "Print Name";
		Label24.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tRecAc).BackColor = Color.White;
		((Control)tRecAc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRecAc).Location = new Point(133, 442);
		((TextBoxBase)tRecAc).MaxLength = 8;
		((Control)tRecAc).Name = "tRecAc";
		((Control)tRecAc).Size = new Size(76, 23);
		((Control)tRecAc).TabIndex = 22;
		((TextBoxBase)tRecAcName).BackColor = Color.White;
		((Control)tRecAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tRecAcName).Location = new Point(215, 442);
		((TextBoxBase)tRecAcName).MaxLength = 50;
		((Control)tRecAcName).Name = "tRecAcName";
		((Control)tRecAcName).Size = new Size(320, 23);
		((Control)tRecAcName).TabIndex = 1242;
		((Control)Label25).BackColor = Color.Transparent;
		((Control)Label25).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label25).ForeColor = Color.Black;
		Label25.ImeMode = (ImeMode)0;
		((Control)Label25).Location = new Point(54, 441);
		((Control)Label25).Name = "Label25";
		((Control)Label25).Size = new Size(75, 20);
		((Control)Label25).TabIndex = 1243;
		Label25.Text = "Issue Ac";
		Label25.TextAlign = (ContentAlignment)64;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(958, 410);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(107, 20);
		((Control)Label6).TabIndex = 1248;
		Label6.Text = "Interest Rec";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntRecAmt).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nIntRecAmt).Font = new Font("Tahoma", 9f);
		((Control)nIntRecAmt).Location = new Point(1071, 410);
		((TextBoxBase)nIntRecAmt).MaxLength = 10;
		((Control)nIntRecAmt).Name = "nIntRecAmt";
		((Control)nIntRecAmt).Size = new Size(99, 22);
		((Control)nIntRecAmt).TabIndex = 19;
		nIntRecAmt.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)mIsuDate).BackColor = Color.White;
		((Control)mIsuDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mIsuDate).Location = new Point(320, 96);
		mIsuDate.Mask = "00/00/0000";
		((Control)mIsuDate).Name = "mIsuDate";
		mIsuDate.ReadOnly = true;
		((Control)mIsuDate).Size = new Size(76, 23);
		((Control)mIsuDate).TabIndex = 1249;
		mIsuDate.ValidatingType = typeof(DateTime);
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(261, 96);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(53, 20);
		((Control)Label7).TabIndex = 1250;
		Label7.Text = "Isu Dt";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(224, 151);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(90, 20);
		((Control)Label9).TabIndex = 1252;
		Label9.Text = "Dharan Rec";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnAdjAmt).BackColor = Color.OldLace;
		((Control)nDhrnAdjAmt).Font = new Font("Tahoma", 9f);
		((Control)nDhrnAdjAmt).Location = new Point(320, 153);
		((TextBoxBase)nDhrnAdjAmt).MaxLength = 10;
		((Control)nDhrnAdjAmt).Name = "nDhrnAdjAmt";
		((TextBoxBase)nDhrnAdjAmt).ReadOnly = true;
		((Control)nDhrnAdjAmt).Size = new Size(76, 22);
		((Control)nDhrnAdjAmt).TabIndex = 7;
		nDhrnAdjAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(0, 182);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(98, 20);
		((Control)Label10).TabIndex = 1254;
		Label10.Text = "Panding Amt";
		Label10.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPandingDhrn).BackColor = Color.FromArgb(255, 192, 192);
		((Control)nPandingDhrn).Font = new Font("Tahoma", 9f);
		((Control)nPandingDhrn).Location = new Point(104, 182);
		((TextBoxBase)nPandingDhrn).MaxLength = 10;
		((Control)nPandingDhrn).Name = "nPandingDhrn";
		((TextBoxBase)nPandingDhrn).ReadOnly = true;
		((Control)nPandingDhrn).Size = new Size(114, 22);
		((Control)nPandingDhrn).TabIndex = 9;
		nPandingDhrn.TextAlign = (HorizontalAlignment)1;
		((TextBoxBase)mFromDate).BackColor = Color.White;
		((Control)mFromDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDate).Location = new Point(104, 210);
		mFromDate.Mask = "00/00/0000";
		((Control)mFromDate).Name = "mFromDate";
		((Control)mFromDate).Size = new Size(76, 23);
		((Control)mFromDate).TabIndex = 12;
		mFromDate.ValidatingType = typeof(DateTime);
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(22, 211);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(73, 20);
		((Control)Label11).TabIndex = 1256;
		Label11.Text = "From Date";
		Label11.TextAlign = (ContentAlignment)64;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(207, 238);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(107, 20);
		((Control)Label13).TabIndex = 1258;
		Label13.Text = "Panding Adjust";
		Label13.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nPanIntAmt).BackColor = Color.FromArgb(255, 192, 192);
		((Control)nPanIntAmt).Font = new Font("Tahoma", 9f);
		((Control)nPanIntAmt).Location = new Point(320, 238);
		((TextBoxBase)nPanIntAmt).MaxLength = 10;
		((Control)nPanIntAmt).Name = "nPanIntAmt";
		((Control)nPanIntAmt).Size = new Size(76, 22);
		((Control)nPanIntAmt).TabIndex = 16;
		nPanIntAmt.TextAlign = (HorizontalAlignment)1;
		((Control)Label26).BackColor = Color.Transparent;
		((Control)Label26).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label26).ForeColor = Color.Black;
		Label26.ImeMode = (ImeMode)0;
		((Control)Label26).Location = new Point(404, 236);
		((Control)Label26).Name = "Label26";
		((Control)Label26).Size = new Size(96, 20);
		((Control)Label26).TabIndex = 1260;
		Label26.Text = "Interest Month";
		Label26.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntMonth).BackColor = Color.White;
		((Control)nIntMonth).Font = new Font("Tahoma", 9f);
		((Control)nIntMonth).Location = new Point(506, 236);
		((TextBoxBase)nIntMonth).MaxLength = 10;
		((Control)nIntMonth).Name = "nIntMonth";
		((Control)nIntMonth).Size = new Size(74, 22);
		((Control)nIntMonth).TabIndex = 17;
		nIntMonth.TextAlign = (HorizontalAlignment)1;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(958, 440);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(107, 20);
		((Control)Label12).TabIndex = 1262;
		Label12.Text = "Dhiran Rec";
		Label12.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nDhrnReceived).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nDhrnReceived).Font = new Font("Tahoma", 9f);
		((Control)nDhrnReceived).Location = new Point(1071, 440);
		((TextBoxBase)nDhrnReceived).MaxLength = 10;
		((Control)nDhrnReceived).Name = "nDhrnReceived";
		((Control)nDhrnReceived).Size = new Size(99, 22);
		((Control)nDhrnReceived).TabIndex = 20;
		nDhrnReceived.TextAlign = (HorizontalAlignment)1;
		((Control)Label20).BackColor = Color.Transparent;
		((Control)Label20).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label20).ForeColor = Color.Black;
		Label20.ImeMode = (ImeMode)0;
		((Control)Label20).Location = new Point(958, 470);
		((Control)Label20).Name = "Label20";
		((Control)Label20).Size = new Size(107, 20);
		((Control)Label20).TabIndex = 1264;
		Label20.Text = "Interest Kasar";
		Label20.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nIntKasr).BackColor = Color.FromArgb(255, 224, 192);
		((Control)nIntKasr).Font = new Font("Tahoma", 9f);
		((Control)nIntKasr).Location = new Point(1071, 470);
		((TextBoxBase)nIntKasr).MaxLength = 10;
		((Control)nIntKasr).Name = "nIntKasr";
		((Control)nIntKasr).Size = new Size(99, 22);
		((Control)nIntKasr).TabIndex = 21;
		nIntKasr.TextAlign = (HorizontalAlignment)1;
		((Control)Label22).BackColor = Color.Transparent;
		((Control)Label22).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label22).ForeColor = Color.Black;
		Label22.ImeMode = (ImeMode)0;
		((Control)Label22).Location = new Point(958, 498);
		((Control)Label22).Name = "Label22";
		((Control)Label22).Size = new Size(107, 20);
		((Control)Label22).TabIndex = 1266;
		Label22.Text = "Total Received";
		Label22.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nTotRec).BackColor = Color.FromArgb(255, 192, 192);
		((Control)nTotRec).Font = new Font("Tahoma", 9f);
		((Control)nTotRec).Location = new Point(1071, 498);
		((TextBoxBase)nTotRec).MaxLength = 10;
		((Control)nTotRec).Name = "nTotRec";
		((Control)nTotRec).Size = new Size(99, 22);
		((Control)nTotRec).TabIndex = 1265;
		nTotRec.TextAlign = (HorizontalAlignment)1;
		((Control)Label27).BackColor = Color.Transparent;
		((Control)Label27).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label27).ForeColor = Color.Black;
		Label27.ImeMode = (ImeMode)0;
		((Control)Label27).Location = new Point(770, 410);
		((Control)Label27).Name = "Label27";
		((Control)Label27).Size = new Size(107, 20);
		((Control)Label27).TabIndex = 1268;
		Label27.Text = "Adjust Int";
		Label27.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nAdjInt).BackColor = Color.White;
		((Control)nAdjInt).Font = new Font("Tahoma", 9f);
		((Control)nAdjInt).Location = new Point(880, 410);
		((TextBoxBase)nAdjInt).MaxLength = 10;
		((Control)nAdjInt).Name = "nAdjInt";
		((Control)nAdjInt).Size = new Size(89, 22);
		((Control)nAdjInt).TabIndex = 1267;
		nAdjInt.TextAlign = (HorizontalAlignment)1;
		((Control)Label28).BackColor = Color.Transparent;
		((Control)Label28).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label28).ForeColor = Color.Black;
		Label28.ImeMode = (ImeMode)0;
		((Control)Label28).Location = new Point(782, 441);
		((Control)Label28).Name = "Label28";
		((Control)Label28).Size = new Size(95, 20);
		((Control)Label28).TabIndex = 1270;
		Label28.Text = "Adjust Dhiran";
		Label28.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nAdjDhiran).BackColor = Color.White;
		((Control)nAdjDhiran).Font = new Font("Tahoma", 9f);
		((Control)nAdjDhiran).Location = new Point(880, 441);
		((TextBoxBase)nAdjDhiran).MaxLength = 10;
		((Control)nAdjDhiran).Name = "nAdjDhiran";
		((Control)nAdjDhiran).Size = new Size(89, 22);
		((Control)nAdjDhiran).TabIndex = 1269;
		nAdjDhiran.TextAlign = (HorizontalAlignment)1;
		((ButtonBase)chkInt).BackColor = SystemColors.ButtonHighlight;
		chkInt.Checked = true;
		chkInt.CheckState = (CheckState)1;
		((Control)chkInt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkInt).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkInt).Location = new Point(418, 127);
		((Control)chkInt).Name = "chkInt";
		((Control)chkInt).RightToLeft = (RightToLeft)0;
		((Control)chkInt).Size = new Size(164, 19);
		((Control)chkInt).TabIndex = 1271;
		((ButtonBase)chkInt).Text = "With Compound Intrest";
		chkInt.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkInt).UseVisualStyleBackColor = false;
		((TextBoxBase)nIntYear).BackColor = Color.White;
		((Control)nIntYear).Font = new Font("Tahoma", 9f);
		((Control)nIntYear).Location = new Point(677, 238);
		((TextBoxBase)nIntYear).MaxLength = 10;
		((Control)nIntYear).Name = "nIntYear";
		((Control)nIntYear).Size = new Size(63, 22);
		((Control)nIntYear).TabIndex = 1272;
		nIntYear.TextAlign = (HorizontalAlignment)1;
		((Control)Label29).BackColor = Color.Transparent;
		((Control)Label29).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label29).ForeColor = Color.Black;
		Label29.ImeMode = (ImeMode)0;
		((Control)Label29).Location = new Point(586, 238);
		((Control)Label29).Name = "Label29";
		((Control)Label29).Size = new Size(85, 20);
		((Control)Label29).TabIndex = 1273;
		Label29.Text = "Interest Year";
		Label29.TextAlign = (ContentAlignment)64;
		cboLoanType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboLoanType).Font = new Font("Tahoma", 9f);
		((ListControl)cboLoanType).FormattingEnabled = true;
		((Control)cboLoanType).Location = new Point(677, 38);
		((Control)cboLoanType).Name = "cboLoanType";
		((Control)cboLoanType).Size = new Size(118, 22);
		((Control)cboLoanType).TabIndex = 2;
		((Control)lblLoanType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblLoanType).ForeColor = Color.Black;
		lblLoanType.ImeMode = (ImeMode)0;
		((Control)lblLoanType).Location = new Point(587, 38);
		((Control)lblLoanType).Name = "lblLoanType";
		((Control)lblLoanType).Size = new Size(82, 20);
		((Control)lblLoanType).TabIndex = 1281;
		lblLoanType.Text = "Loan Type";
		lblLoanType.TextAlign = (ContentAlignment)64;
		((Control)Label30).BackColor = Color.Transparent;
		((Control)Label30).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label30).ForeColor = Color.Black;
		Label30.ImeMode = (ImeMode)0;
		((Control)Label30).Location = new Point(569, 440);
		((Control)Label30).Name = "Label30";
		((Control)Label30).Size = new Size(118, 20);
		((Control)Label30).TabIndex = 1283;
		Label30.Text = "Advance Dhiran";
		Label30.TextAlign = (ContentAlignment)64;
		((TextBoxBase)nAdvanceDhiran).BackColor = Color.White;
		((Control)nAdvanceDhiran).Enabled = false;
		((Control)nAdvanceDhiran).Font = new Font("Tahoma", 9f);
		((Control)nAdvanceDhiran).Location = new Point(693, 441);
		((TextBoxBase)nAdvanceDhiran).MaxLength = 10;
		((Control)nAdvanceDhiran).Name = "nAdvanceDhiran";
		((Control)nAdvanceDhiran).Size = new Size(90, 22);
		((Control)nAdvanceDhiran).TabIndex = 1282;
		nAdvanceDhiran.TextAlign = (HorizontalAlignment)1;
		((Control)PicAcImage).BackColor = Color.Transparent;
		PicAcImage.BorderStyle = (BorderStyle)1;
		PicAcImage.ImeMode = (ImeMode)0;
		((Control)PicAcImage).Location = new Point(883, 149);
		((Control)PicAcImage).Name = "PicAcImage";
		((Control)PicAcImage).Size = new Size(104, 83);
		PicAcImage.SizeMode = (PictureBoxSizeMode)4;
		PicAcImage.TabIndex = 1284;
		PicAcImage.TabStop = false;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnMultyTimeIsu).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMultyTimeIsu).Appearance.Options.UseForeColor = true;
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnMultyTimeIsu).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnMultyTimeIsu).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnMultyTimeIsu).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnMultyTimeIsu).AppearancePressed.Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnMultyTimeIsu).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnMultyTimeIsu).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnMultyTimeIsu).AppearancePressed.Options.UseFont = true;
		((Control)btnMultyTimeIsu).Location = new Point(224, 96);
		((BaseControl)btnMultyTimeIsu).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnMultyTimeIsu).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnMultyTimeIsu).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMultyTimeIsu).Name = "btnMultyTimeIsu";
		((Control)btnMultyTimeIsu).Size = new Size(31, 23);
		((Control)btnMultyTimeIsu).TabIndex = 1285;
		btnMultyTimeIsu.Text = "M";
		((BaseControl)btnMultyTimeIsu).ToolTip = "Multy Time Isu Agains Ornament";
		((Control)lblRCutAmt).BackColor = Color.Transparent;
		((Control)lblRCutAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblRCutAmt).ForeColor = Color.Black;
		lblRCutAmt.ImeMode = (ImeMode)0;
		((Control)lblRCutAmt).Location = new Point(789, 500);
		((Control)lblRCutAmt).Name = "lblRCutAmt";
		((Control)lblRCutAmt).Size = new Size(88, 20);
		((Control)lblRCutAmt).TabIndex = 1287;
		lblRCutAmt.Text = "Ratecut Amt";
		lblRCutAmt.TextAlign = (ContentAlignment)64;
		((Control)lblRCutAmt).Visible = false;
		((Control)lblFineRate).BackColor = Color.Transparent;
		((Control)lblFineRate).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblFineRate).ForeColor = Color.Black;
		lblFineRate.ImeMode = (ImeMode)0;
		((Control)lblFineRate).Location = new Point(589, 498);
		((Control)lblFineRate).Name = "lblFineRate";
		((Control)lblFineRate).Size = new Size(99, 20);
		((Control)lblFineRate).TabIndex = 1289;
		lblFineRate.Text = "Fine Rate 1 gm";
		lblFineRate.TextAlign = (ContentAlignment)64;
		((Control)lblFineRate).Visible = false;
		((TextBoxBase)nFineRate).BackColor = Color.Lavender;
		((Control)nFineRate).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nFineRate).ForeColor = Color.Black;
		((Control)nFineRate).Location = new Point(693, 498);
		((TextBoxBase)nFineRate).MaxLength = 10;
		((Control)nFineRate).Name = "nFineRate";
		((Control)nFineRate).Size = new Size(90, 22);
		((Control)nFineRate).TabIndex = 1288;
		nFineRate.TextAlign = (HorizontalAlignment)1;
		((Control)nFineRate).Visible = false;
		((TextBoxBase)nRcutAmt).BackColor = Color.Lavender;
		((Control)nRcutAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nRcutAmt).ForeColor = Color.Black;
		((Control)nRcutAmt).Location = new Point(879, 498);
		((TextBoxBase)nRcutAmt).MaxLength = 10;
		((Control)nRcutAmt).Name = "nRcutAmt";
		((Control)nRcutAmt).Size = new Size(90, 22);
		((Control)nRcutAmt).TabIndex = 1290;
		nRcutAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nRcutAmt).Visible = false;
		((Control)lblPayAmt).BackColor = Color.Transparent;
		((Control)lblPayAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblPayAmt).ForeColor = Color.Black;
		lblPayAmt.ImeMode = (ImeMode)0;
		((Control)lblPayAmt).Location = new Point(599, 529);
		((Control)lblPayAmt).Name = "lblPayAmt";
		((Control)lblPayAmt).Size = new Size(88, 20);
		((Control)lblPayAmt).TabIndex = 1292;
		lblPayAmt.Text = "Pay Amt";
		lblPayAmt.TextAlign = (ContentAlignment)64;
		((Control)lblPayAmt).Visible = false;
		((TextBoxBase)nPayAmt).BackColor = Color.Lavender;
		((Control)nPayAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nPayAmt).ForeColor = Color.Blue;
		((Control)nPayAmt).Location = new Point(693, 527);
		((TextBoxBase)nPayAmt).MaxLength = 10;
		((Control)nPayAmt).Name = "nPayAmt";
		((Control)nPayAmt).Size = new Size(90, 22);
		((Control)nPayAmt).TabIndex = 1293;
		nPayAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nPayAmt).Visible = false;
		((TextBoxBase)nOsAmt).BackColor = Color.Lavender;
		((Control)nOsAmt).Font = new Font("Tahoma", 9f);
		((TextBoxBase)nOsAmt).ForeColor = Color.Red;
		((Control)nOsAmt).Location = new Point(879, 527);
		((TextBoxBase)nOsAmt).MaxLength = 10;
		((Control)nOsAmt).Name = "nOsAmt";
		((Control)nOsAmt).Size = new Size(90, 22);
		((Control)nOsAmt).TabIndex = 1294;
		nOsAmt.TextAlign = (HorizontalAlignment)1;
		((Control)nOsAmt).Visible = false;
		((Control)lblOsAmt).BackColor = Color.Transparent;
		((Control)lblOsAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblOsAmt).ForeColor = Color.Black;
		lblOsAmt.ImeMode = (ImeMode)0;
		((Control)lblOsAmt).Location = new Point(792, 529);
		((Control)lblOsAmt).Name = "lblOsAmt";
		((Control)lblOsAmt).Size = new Size(81, 20);
		((Control)lblOsAmt).TabIndex = 1295;
		lblOsAmt.Text = "Os Amount";
		lblOsAmt.TextAlign = (ContentAlignment)64;
		((Control)lblOsAmt).Visible = false;
		((Control)lblOrnaAgainstDhrn).BackColor = Color.Transparent;
		((Control)lblOrnaAgainstDhrn).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblOrnaAgainstDhrn).ForeColor = Color.Black;
		lblOrnaAgainstDhrn.ImeMode = (ImeMode)0;
		((Control)lblOrnaAgainstDhrn).Location = new Point(730, 239);
		((Control)lblOrnaAgainstDhrn).Name = "lblOrnaAgainstDhrn";
		((Control)lblOrnaAgainstDhrn).Size = new Size(166, 20);
		((Control)lblOrnaAgainstDhrn).TabIndex = 1297;
		lblOrnaAgainstDhrn.Text = "Orna Aginest Tot Dhiran";
		lblOrnaAgainstDhrn.TextAlign = (ContentAlignment)64;
		((Control)lblOrnaAgainstDhrn).Visible = false;
		((TextBoxBase)nOrnaAginestDhrn).BackColor = Color.White;
		((Control)nOrnaAginestDhrn).Font = new Font("Tahoma", 9f);
		((Control)nOrnaAginestDhrn).Location = new Point(917, 238);
		((TextBoxBase)nOrnaAginestDhrn).MaxLength = 10;
		((Control)nOrnaAginestDhrn).Name = "nOrnaAginestDhrn";
		((Control)nOrnaAginestDhrn).Size = new Size(74, 22);
		((Control)nOrnaAginestDhrn).TabIndex = 1296;
		nOrnaAginestDhrn.TextAlign = (HorizontalAlignment)1;
		((Control)nOrnaAginestDhrn).Visible = false;
		((Control)lblMobile).BackColor = Color.Transparent;
		((Control)lblMobile).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.Maroon;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(963, 124);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).Size = new Size(207, 20);
		((Control)lblMobile).TabIndex = 1303;
		lblMobile.Text = ":";
		lblMobile.TextAlign = (ContentAlignment)16;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblCity).ForeColor = Color.Maroon;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(963, 100);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(207, 20);
		((Control)lblCity).TabIndex = 1302;
		lblCity.Text = ":";
		lblCity.TextAlign = (ContentAlignment)16;
		((Control)lblAdd1).BackColor = Color.Transparent;
		((Control)lblAdd1).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.Maroon;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(963, 75);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).Size = new Size(207, 20);
		((Control)lblAdd1).TabIndex = 1301;
		lblAdd1.Text = ":";
		lblAdd1.TextAlign = (ContentAlignment)16;
		((Control)Label31).BackColor = Color.Transparent;
		((Control)Label31).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label31).ForeColor = Color.Maroon;
		Label31.ImeMode = (ImeMode)0;
		((Control)Label31).Location = new Point(884, 125);
		((Control)Label31).Name = "Label31";
		((Control)Label31).Size = new Size(73, 20);
		((Control)Label31).TabIndex = 1300;
		Label31.Text = "Mobile No  :";
		Label31.TextAlign = (ContentAlignment)64;
		((Control)Label32).BackColor = Color.Transparent;
		((Control)Label32).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label32).ForeColor = Color.Maroon;
		Label32.ImeMode = (ImeMode)0;
		((Control)Label32).Location = new Point(898, 101);
		((Control)Label32).Name = "Label32";
		((Control)Label32).Size = new Size(59, 20);
		((Control)Label32).TabIndex = 1299;
		Label32.Text = "City  :";
		Label32.TextAlign = (ContentAlignment)64;
		((Control)Label33).BackColor = Color.Transparent;
		((Control)Label33).Font = new Font("Arial", 9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)Label33).ForeColor = Color.Maroon;
		Label33.ImeMode = (ImeMode)0;
		((Control)Label33).Location = new Point(898, 75);
		((Control)Label33).Name = "Label33";
		((Control)Label33).Size = new Size(59, 20);
		((Control)Label33).TabIndex = 1298;
		Label33.Text = "Add 1  :";
		Label33.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)nIntYear);
		((Control)this).Controls.Add((Control)(object)PicZoom);
		((Control)this).Controls.Add((Control)(object)lblMobile);
		((Control)this).Controls.Add((Control)(object)lblCity);
		((Control)this).Controls.Add((Control)(object)lblAdd1);
		((Control)this).Controls.Add((Control)(object)Label31);
		((Control)this).Controls.Add((Control)(object)Label32);
		((Control)this).Controls.Add((Control)(object)Label33);
		((Control)this).Controls.Add((Control)(object)lblOrnaAgainstDhrn);
		((Control)this).Controls.Add((Control)(object)nOrnaAginestDhrn);
		((Control)this).Controls.Add((Control)(object)lblOsAmt);
		((Control)this).Controls.Add((Control)(object)nOsAmt);
		((Control)this).Controls.Add((Control)(object)nPayAmt);
		((Control)this).Controls.Add((Control)(object)lblPayAmt);
		((Control)this).Controls.Add((Control)(object)nRcutAmt);
		((Control)this).Controls.Add((Control)(object)lblFineRate);
		((Control)this).Controls.Add((Control)(object)nFineRate);
		((Control)this).Controls.Add((Control)(object)lblRCutAmt);
		((Control)this).Controls.Add((Control)(object)btnMultyTimeIsu);
		((Control)this).Controls.Add((Control)(object)PicAcImage);
		((Control)this).Controls.Add((Control)(object)Label30);
		((Control)this).Controls.Add((Control)(object)nAdvanceDhiran);
		((Control)this).Controls.Add((Control)(object)cboLoanType);
		((Control)this).Controls.Add((Control)(object)lblLoanType);
		((Control)this).Controls.Add((Control)(object)Label29);
		((Control)this).Controls.Add((Control)(object)chkInt);
		((Control)this).Controls.Add((Control)(object)Label28);
		((Control)this).Controls.Add((Control)(object)nAdjDhiran);
		((Control)this).Controls.Add((Control)(object)Label27);
		((Control)this).Controls.Add((Control)(object)nAdjInt);
		((Control)this).Controls.Add((Control)(object)Label22);
		((Control)this).Controls.Add((Control)(object)nTotRec);
		((Control)this).Controls.Add((Control)(object)Label20);
		((Control)this).Controls.Add((Control)(object)nIntKasr);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)nDhrnReceived);
		((Control)this).Controls.Add((Control)(object)Label26);
		((Control)this).Controls.Add((Control)(object)nIntMonth);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)nPanIntAmt);
		((Control)this).Controls.Add((Control)(object)mFromDate);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)nPandingDhrn);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nDhrnAdjAmt);
		((Control)this).Controls.Add((Control)(object)mIsuDate);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)nIntRecAmt);
		((Control)this).Controls.Add((Control)(object)tRecAc);
		((Control)this).Controls.Add((Control)(object)tRecAcName);
		((Control)this).Controls.Add((Control)(object)Label25);
		((Control)this).Controls.Add((Control)(object)Label24);
		((Control)this).Controls.Add((Control)(object)BtnIssue);
		((Control)this).Controls.Add((Control)(object)Label23);
		((Control)this).Controls.Add((Control)(object)tIsuDbCd);
		((Control)this).Controls.Add((Control)(object)tIsuYrCd);
		((Control)this).Controls.Add((Control)(object)tIsuNo);
		((Control)this).Controls.Add((Control)(object)Label21);
		((Control)this).Controls.Add((Control)(object)tItDesc);
		((Control)this).Controls.Add((Control)(object)nIntAmt);
		((Control)this).Controls.Add((Control)(object)mToDate);
		((Control)this).Controls.Add((Control)(object)Label18);
		((Control)this).Controls.Add((Control)(object)Label19);
		((Control)this).Controls.Add((Control)(object)nIntDays);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)tPacketNo);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)nDhrnMonth);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)nIntPrc);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)nMonthlyInt);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)nDhrnAmt);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)MSG);
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
		((Control)this).Controls.Add((Control)(object)PicImage);
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
		((Control)this).Name = "TR_DHRN_REC";
		((Form)this).Text = "Dhrn Receive";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((ISupportInitialize)PicAcImage).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		mSG.Clear();
		mSG.Cols = 28;
		mSG.FixedRows = 1;
		mSG.Rows = 2;
		mSG.Row = 1;
		mSG[0] = 0;
		mSG[1] = 0;
		mSG.ScrollBars = (ScrollBarsSettings)0;
		checked
		{
			mSG[0] = (int)Math.Round(500.0 * ColCon);
			mSG[0] = 3;
			mSG[0, 0] = "Sr";
			if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
			{
				mSG[1] = (int)Math.Round(1100.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "PacketNo";
				mSG[2] = (int)Math.Round(3000.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "CustName";
				mSG[3] = (int)Math.Round(1000.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "ItCode";
				mSG[4] = (int)Math.Round(2200.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "ItName";
				mSG[7] = 0;
				mSG[10] = 0;
				mSG[15] = (int)Math.Round(900.0 * ColCon);
				mSG[15] = 3;
				mSG[0, 15] = "PktReIsu";
				mSG[5] = (int)Math.Round(600.0 * ColCon);
				mSG[5] = 7;
				mSG[0, 5] = "Pcs";
				mSG[6] = (int)Math.Round(1050.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "GrWt";
				mSG[8] = (int)Math.Round(1050.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "NetWt";
				mSG[9] = (int)Math.Round(900.0 * ColCon);
				mSG[9] = 3;
				mSG[0, 9] = "Touch";
				mSG[11] = (int)Math.Round(1050.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "Fine";
			}
			else
			{
				mSG[1] = 0;
				mSG[2] = 0;
				mSG[7] = (int)Math.Round(1200.0 * ColCon);
				mSG[7] = 7;
				mSG[0, 7] = "OthWt";
				mSG[10] = (int)Math.Round(900.0 * ColCon);
				mSG[10] = 3;
				mSG[0, 10] = "West%";
				mSG[3] = (int)Math.Round(1100.0 * ColCon);
				mSG[3] = 0;
				mSG[0, 3] = "ItCode";
				mSG[4] = (int)Math.Round(3000.0 * ColCon);
				mSG[4] = 0;
				mSG[0, 4] = "ItName";
				mSG[15] = 0;
				mSG[5] = (int)Math.Round(800.0 * ColCon);
				mSG[5] = 7;
				mSG[0, 5] = "Pcs";
				mSG[6] = (int)Math.Round(1200.0 * ColCon);
				mSG[6] = 7;
				mSG[0, 6] = "GrWt";
				mSG[8] = (int)Math.Round(1200.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "NetWt";
				mSG[9] = (int)Math.Round(900.0 * ColCon);
				mSG[9] = 3;
				mSG[0, 9] = "Touch";
				mSG[11] = (int)Math.Round(1200.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "Fine";
			}
			mSG[12] = (int)Math.Round(1100.0 * ColCon);
			mSG[12] = 7;
			mSG[0, 12] = "Rate";
			mSG[13] = (int)Math.Round(1200.0 * ColCon);
			mSG[13] = 7;
			mSG[0, 13] = "ItAmt";
			mSG[14] = (int)Math.Round(1200.0 * ColCon);
			mSG[14] = 7;
			mSG[0, 14] = "NetAmt";
			mSG[18] = 0;
			mSG[16] = 0;
			mSG[17] = 0;
			mSG[19] = 0;
			mSG[20] = 0;
			mSG[21] = 0;
			mSG[22] = 0;
			mSG[23] = 0;
			mSG[24] = 0;
			mSG[25] = 0;
			mSG[26] = 0;
			mSG[27] = 0;
			mSG.Row = 1;
			mSG.Col = 1;
			((Control)TEXT_ENTRY).Visible = false;
			DataView dataView = new DataView(DC_Main.RsClDetl);
			if (dataView.Count > 0)
			{
				int num = mSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					dataView.RowFilter = " BOOK_NAME = 'DHRN_ISU' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(mSG.Row);
		mSG[mSG.Row, 15] = "N";
		mSG = null;
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
		//IL_0366: Unknown result type (might be due to invalid IL or missing references)
		//IL_0374: Invalid comparison between Unknown and I4
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Invalid comparison between Unknown and I4
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_0388: Invalid comparison between Unknown and I4
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Invalid comparison between Unknown and I4
		//IL_0457: Unknown result type (might be due to invalid IL or missing references)
		//IL_045a: Invalid comparison between Unknown and I4
		//IL_0485: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Invalid comparison between Unknown and I4
		//IL_03e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Invalid comparison between Unknown and I4
		//IL_05fc: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == 112)
		{
			DC_Main.RsQry = "Select A.CUST_NAME AS AcNameL,A.PACKET_NO As PacketNoL,A.IT_DESC as ItemDescL,A.VCH_NO AS VchNoL,A.CO_BOOK as BookL,A.CO_YEAR As YearL,A.ITM_GWT AS WeightW,A.SR_NO As SrNoM  FROM DHRN_ISU_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = 'LOAN REC' AND A.PACKET_REC = 'N' AND AC_CODE = '" + tAcCode.Text + "'  ORDER BY A.CO_YEAR,A.CO_BOOK,A.VCH_NO";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[9];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 250.0;
			DC_Main.ColWidth[3] = 90.0;
			DC_Main.ColWidth[4] = 70.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.ColWidth[6] = 110.0;
			DC_Main.ColWidth[7] = 0.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					TEXT_ENTRY.Text = DC_Main.ColValue[1];
					mSG[mSG.Row, 2] = DC_Main.ColValue[0];
					mSG[mSG.Row, 3] = "OG";
					mSG[mSG.Row, 4] = "OLD GOLD";
					mSG[mSG.Row, 18] = DC_Main.ColValue[2];
					tItDesc.Text = DC_Main.ColValue[2];
					mSG[mSG.Row, 1] = DC_Main.ColValue[1];
					mSG[mSG.Row, 6] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
					mSG[mSG.Row, 8] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[6]), "0.000");
					mSG[mSG.Row, 24] = DC_Main.ColValue[3];
					mSG[mSG.Row, 25] = DC_Main.ColValue[5];
					mSG[mSG.Row, 26] = DC_Main.ColValue[4];
					mSG[mSG.Row, 27] = DC_Main.ColValue[7];
				}
				else
				{
					TEXT_ENTRY.Text = "";
					mSG[mSG.Row, 1] = "";
					mSG[mSG.Row, 4] = "";
					mSG[mSG.Row, 18] = "";
					mSG[mSG.Row, 6] = "";
					mSG[mSG.Row, 8] = "";
					mSG[mSG.Row, 24] = "";
					mSG[mSG.Row, 25] = "";
					mSG[mSG.Row, 26] = "";
					mSG[mSG.Row, 27] = "";
				}
				((Control)TEXT_ENTRY).Focus();
			}
			return;
		}
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6)
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
					Interaction.MsgBox((object)"Record is Deleted....", (MsgBoxStyle)0, (object)null);
				}
			}
		}
		else
		{
			if ((int)keyCode == 37)
			{
				if (mSG.Col > 1)
				{
					Msgleft = true;
					mSG.Col = checked(mSG.Col - 1);
				}
				return;
			}
			if ((int)keyCode == 39)
			{
				if (mSG.Col < 14)
				{
					mSG.Col = checked(mSG.Col + 1);
				}
				return;
			}
			if ((int)keyCode == 38)
			{
				if (mSG.Row > 1)
				{
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
					case 3:
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
									mSG[mSG.Row, 4] = DC_Main.ColValue[0];
									mSG[mSG.Row, 16] = DC_Main.ColValue[4];
									mSG[mSG.Row, 18] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 16] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 17] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						if (Operators.CompareString(mSG[mSG.Row, 18], "", false) == 0)
						{
							mSG[mSG.Row, 18] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						}
						tItDesc.Text = mSG[mSG.Row, 18];
						break;
					case 6:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 17], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 14:
					case 15:
						if (mSG.Row == mSG.Rows - 1)
						{
							if (mSG.Col == 15)
							{
								mSG[mSG.Row, 15] = TEXT_ENTRY.Text;
							}
							else
							{
								mSG[mSG.Row, 14] = Strings.Format((object)TEXT_ENTRY.Text, "0.00");
							}
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
						mSG.Col += 1;
					}
					((Control)TEXT_ENTRY).Visible = true;
					((Control)TEXT_ENTRY).Focus();
				}
			}
		}
		mSG = null;
	}

	private void MSG_ClickEvent(object sender, EventArgs e)
	{
		AxMSFlexGrid mSG = MSG;
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
			if (!((mSG.Row == 0) | (mSG.CellWidth <= 0)) && mSG[mSG.Col] != 0)
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
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 15:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 18:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 9:
				case 10:
				case 12:
				case 13:
				case 14:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 6:
				case 7:
				case 8:
				case 11:
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
		if (!MsgClearIdtl && MSG.Row != 0 && MSG[MSG.Col] != 0 && ((Control)TEXT_ENTRY).Visible)
		{
			AxMSFlexGrid mSG = MSG;
			switch (MSG.Col)
			{
			case 0:
			case 2:
			case 3:
			case 4:
			case 15:
			case 18:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 5:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				CommPassTotal(mSG.Row);
				break;
			case 9:
			case 10:
			case 12:
			case 13:
			case 14:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal(mSG.Row);
				break;
			case 6:
			case 7:
			case 8:
			case 11:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal(mSG.Row);
				break;
			}
			mSG = null;
		}
	}

	private void CommPassTotal(int CRow)
	{
		AxMSFlexGrid mSG = MSG;
		if (Conversion.Val(mSG[mSG.Row, 6]) != Conversion.Val(mSG[mSG.Row, 19]))
		{
			mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 6]), "0.000");
			mSG[mSG.Row, 8] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 6]) - Conversion.Val(mSG[mSG.Row, 7])), "0.000");
		}
		if ((Conversion.Val(mSG[mSG.Row, 7]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 6]) != 0.0))
		{
			mSG[mSG.Row, 8] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 6]) - Conversion.Val(mSG[mSG.Row, 7])), "0.000");
		}
		if (Conversion.Val(mSG[mSG.Row, 8]) != Conversion.Val(mSG[mSG.Row, 20]))
		{
			mSG[mSG.Row, 20] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 8]), "0.000");
			if ((Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 8]) != 0.0))
			{
				mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) / 100.0), "0.000");
			}
			else
			{
				mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 8]), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 9]) != Conversion.Val(mSG[mSG.Row, 21]))
		{
			mSG[mSG.Row, 21] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 9]), "0.00");
			if ((Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 8]) != 0.0))
			{
				mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 10]) != Conversion.Val(mSG[mSG.Row, 22]))
		{
			mSG[mSG.Row, 22] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 10]), "0.00");
			if ((Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 8]) != 0.0))
			{
				mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 8]) * (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 9]) + Conversion.Val(mSG[mSG.Row, 10]) == 0.0)
		{
			mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 8]), "0.000");
		}
		if ((Conversion.Val(mSG[mSG.Row, 12]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 5]) != 0.0))
		{
			switch (mSG[mSG.Row, 17])
			{
			case "P":
				mSG[mSG.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 5]) * Conversion.Val(mSG[mSG.Row, 12]), 0), "0.00");
				break;
			case "1":
				mSG[mSG.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 11]) * (Conversion.Val(mSG[mSG.Row, 12]) / 10.0), 0), "0.00");
				break;
			case "K":
				mSG[mSG.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 11]) * (Conversion.Val(mSG[mSG.Row, 12]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG[mSG.Row, 13] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 11]) * Conversion.Val(mSG[mSG.Row, 12]), 0), "0.00");
				break;
			}
		}
		mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 13]), "0.00");
		MSG_TOT_FILL();
		BILL_TOTAL();
		mSG = null;
	}

	private void MSG_TOT_FILL()
	{
		if (UpDown)
		{
			return;
		}
		PurcAcFine = 0.0;
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
			mSG_TOT[0, 18] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[0, 5] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 5]) + Conversion.Val(MSG[DC_Main.M, 5]))), "0");
				mSG_TOT[0, 6] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 6]) + Conversion.Val(MSG[DC_Main.M, 6]))), "0.000");
				mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
				mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0.000");
				mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
				mSG_TOT[0, 13] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 13]) + Conversion.Val(MSG[DC_Main.M, 13]))), "0.00");
				mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 13]) == 0.0)
				{
					PurcAcFine += Conversion.Val(MSG[DC_Main.M, 11]);
				}
				DC_Main.M++;
			}
			mSG_TOT = null;
		}
	}

	private void TR_DHRN_REC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0ab5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac4: Expected O, but got Unknown
		//IL_0b03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Expected O, but got Unknown
		//IL_0b2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3b: Expected O, but got Unknown
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Expected O, but got Unknown
		//IL_0c4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c50: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5a: Expected O, but got Unknown
		//IL_0ce2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf1: Expected O, but got Unknown
		//IL_0d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d95: Expected O, but got Unknown
		//IL_0e1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e2e: Expected O, but got Unknown
		//IL_0e53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e62: Expected O, but got Unknown
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
				((ButtonBase)chkInt).BackColor = Color.Silver;
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				object? obj9 = colorConverter.ConvertFromString("Silver");
				mSG_TOT.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				AxMSFlexGrid mSG_TOT2 = MSG_TOT;
				object? obj10 = colorConverter.ConvertFromString("Silver");
				mSG_TOT2.BackColorBkg = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AxMSFlexGrid mSG_TOT3 = MSG_TOT;
				object? obj11 = colorConverter.ConvertFromString("Silver");
				mSG_TOT3.BackColorFixed = ((obj11 != null) ? ((Color)obj11) : default(Color));
				AxMSFlexGrid mSG = MSG;
				object? obj12 = colorConverter.ConvertFromString("ControlLightLight");
				mSG.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				AxMSFlexGrid mSG2 = MSG;
				object? obj13 = colorConverter.ConvertFromString("DarkGray");
				mSG2.BackColorBkg = ((obj13 != null) ? ((Color)obj13) : default(Color));
				AxMSFlexGrid mSG3 = MSG;
				object? obj14 = colorConverter.ConvertFromString("255, 224, 192");
				mSG3.BackColorFixed = ((obj14 != null) ? ((Color)obj14) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj15 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((TextBoxBase)tHdVchNo).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				CheckBox obj16 = chkInt;
				object? obj17 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj16).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)BtnF1).Appearance;
				object? obj18 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj19 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj22 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj23 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj24 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj24 != null) ? ((Color)obj24) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj25 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((TextBoxBase)tHdVchNo).BackColor = Color.Cornsilk;
				Label obj26 = lblBook;
				object? obj27 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj26).ForeColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj28 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				CheckBox obj29 = chkInt;
				object? obj30 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj29).BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj31 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj32 != null) ? ((Color)obj32) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj34 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj35 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj36 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj37 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
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
			if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
			{
				Label23.Text = "Rec No";
				Label7.Text = "Rec Date";
				Label16.Text = "Lon Amt";
				Label9.Text = "Old Rec Lon";
				Label28.Text = "Adj Lon";
				Label12.Text = "Lon Rec";
				CurIntTypeCalc = DC_Main.MsLoanIntType;
				((Control)btnMultyTimeIsu).Visible = false;
				if (Operators.CompareString(DC_Main.SSRegSrNo, "AK004NEAK", false) == 0)
				{
					((TextBoxBase)nIntAmt).ReadOnly = true;
				}
			}
			else
			{
				CurIntTypeCalc = DC_Main.MsDhrnIntType;
				lblLoanType.Text = "Dhrn Type";
			}
			cboLoanType.Items.Add((object)"Amount");
			cboLoanType.Items.Add((object)"Gold");
			cboLoanType.Items.Add((object)"Silver");
			cboLoanType.SelectedIndex = 0;
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
		mToDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		OldIsuNo = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
		AdvanceRecAmt = 0.0;
		UsUPdate = "N";
		UsDelete = "N";
		lblAdd1.Text = ":";
		lblCity.Text = ":";
		lblMobile.Text = ":";
		((Control)lblOrnaAgainstDhrn).Visible = false;
		((Control)nOrnaAginestDhrn).Visible = false;
		LOpAmt.Text = ": Amt";
		((Control)LOpAmt).ForeColor = Color.Black;
		LClAmt.Text = ": Amt";
		((Control)LClAmt).ForeColor = Color.Black;
		ColorConverter colorConverter = new ColorConverter();
		SimpleButton btnSave = BtnSave;
		object? obj = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnSave).ForeColor = ((obj != null) ? ((Color)obj) : default(Color));
		SimpleButton btnDelete = BtnDelete;
		object? obj2 = colorConverter.ConvertFromString("192, 64, 0");
		((BaseStyleControl)btnDelete).ForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
		OldValTot = 0.0;
		NewValTot = 0.0;
		OldIntDay = 0;
		AcGstType = "L";
		tRecAc.Text = "00001";
		if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
		{
			chkInt.Checked = false;
		}
		else if (Operators.CompareString(DC_Main.MsDhrnCompound, "N", false) == 0)
		{
			chkInt.Checked = false;
		}
		else
		{
			chkInt.Checked = true;
		}
		((Control)lblFineRate).Visible = false;
		((Control)lblRCutAmt).Visible = false;
		((Control)lblPayAmt).Visible = false;
		((Control)lblOsAmt).Visible = false;
		((Control)nFineRate).Visible = false;
		((Control)nRcutAmt).Visible = false;
		((Control)nPayAmt).Visible = false;
		((Control)nOsAmt).Visible = false;
		PicImage.Image = null;
		PicAcImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY).Visible = false;
		cboLoanType.SelectedIndex = 0;
		MSG_CLEAR();
		if (Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0)
		{
			tEmpCode.Text = "";
		}
		else
		{
			tEmpCode.Text = "001";
		}
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
		RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (RsData.Rows.Count > 0)
			{
				tVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_NO"], (object)""));
				CurPrnVch = tVchNo.Text;
				tHdVchNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["HD_VCH_NO"], (object)""));
				mVchDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DATE"], (object)""));
				mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
				mTime.Text = Strings.Format((object)Conversions.ToDate(RsData.Rows[0]["VCH_TIME"]), "HH:mm:ss");
				mToDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_DATE"], (object)""));
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DHRN_BILL"], (object)""));
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_CODE"], (object)""));
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_NAME"], (object)""));
				OldAcCode = tAcCode.Text;
				tRecAc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["LEDR_ACCD"], (object)""));
				DC_Main.RsQry = "SELECT * FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CODE = '" + tRecAc.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tRecAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
					lblAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_ADD1"], (object)""));
					lblCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_CITY"], (object)""));
					lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_MOBILE"], (object)""));
				}
				DC_Main.RsAc.Clear();
				DC_Main.RsAc.Columns.Clear();
				tPacketNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["PACKET_NO"], (object)""));
				mIsuDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["DHRN_DATE"], (object)""));
				if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["LOAN_TYPE"], (object)""), (object)"G", false))
				{
					cboLoanType.SelectedIndex = 1;
				}
				else if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(RsData.Rows[0]["LOAN_TYPE"], (object)""), (object)"S", false))
				{
					cboLoanType.SelectedIndex = 2;
				}
				else
				{
					cboLoanType.SelectedIndex = 0;
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					nPanIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PAN_ADJ_AMT"]), "0.000");
					nAdjInt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_INT"]), "0.000");
					nAdjDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_DHRN"]), "0.000");
					nAdvanceDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UNCHAK_DHRN_REC"]), "0.000");
					nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_AMT"]), "0.000");
					nDhrnAdjAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_ADJ_AMT"]), "0.000");
					nPandingDhrn.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_OS_AMT"]), "0.000");
					nDhrnReceived.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_REC_AMT"]), "0.000");
				}
				else
				{
					nPanIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["PAN_ADJ_AMT"]), "0.00");
					nAdjInt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_INT"]), "0.00");
					nAdjDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ADJ_DHRN"]), "0.00");
					nAdvanceDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["UNCHAK_DHRN_REC"]), "0.00");
					nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_AMT"]), "0.00");
					nDhrnAdjAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_ADJ_AMT"]), "0.00");
					nPandingDhrn.Text = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_OS_AMT"])) + Conversion.Val(nAdvanceDhiran.Text) + Conversion.Val(nDhrnAdjAmt.Text)), "0.00");
					nDhrnReceived.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_REC_AMT"]), "0.00");
					AdvanceRecAmt = Conversion.Val(nAdjDhiran.Text) + Conversion.Val(nAdjInt.Text);
				}
				nDhrnMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DHRN_MONTH"]), "00");
				mFromDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["FROM_DATE"], (object)""));
				mToDate.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TO_DATE"], (object)""));
				nIntMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_MONTH"]), "0");
				nIntDays.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_DAY"]), "0");
				nIntPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_PRC"]), "0.00");
				OldIntDay = (int)Math.Round(Conversion.Val(nIntDays.Text) + Conversion.Val(nIntPrc.Text));
				if (Conversion.Val(nIntPrc.Text) != 0.0)
				{
					nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
				}
				if (cboLoanType.SelectedIndex != 0)
				{
					nIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"]), "0.000");
					nIntRecAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_REC_AMT"]), "0.000");
					nIntKasr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KASAR_AMT"]), "0.000");
					nFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_RATE"]), "0.00");
					nRcutAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_AMT"]), "0.000");
					nPayAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_PAY_AMT"]), "0.000");
					nOsAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_OS_AMT"]), "0.000");
				}
				else
				{
					nIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_AMT"]), "0.00");
					nIntRecAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["INT_REC_AMT"]), "0.00");
					nIntKasr.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["KASAR_AMT"]), "0.00");
					nFineRate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_RATE"]), "0.00");
					nRcutAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_AMT"]), "0.00");
					nPayAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_PAY_AMT"]), "0.00");
					nOsAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["RCUT_OS_AMT"]), "0.00");
				}
				if (Conversion.Val(nRcutAmt.Text) > 0.0)
				{
					((Control)lblFineRate).Visible = true;
					((Control)lblRCutAmt).Visible = true;
					((Control)lblPayAmt).Visible = true;
					((Control)lblOsAmt).Visible = true;
					((Control)nFineRate).Visible = true;
					((Control)nRcutAmt).Visible = true;
					((Control)nPayAmt).Visible = true;
					((Control)nOsAmt).Visible = true;
				}
				tEmpCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["EMP_CODE"], (object)""));
				DC_Main.RsQry = "SELECT EMP_NAME FROM EMP_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND EMP_CODE = '" + tEmpCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tEmpName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["EMP_NAME"], (object)""));
				}
				tVchDesc.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["VCH_DESC"], (object)""));
				tIsuNo.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
				OldIsuNo = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["ISU_NO"], (object)""));
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
				DC_Main.MsAcAmtClBal = 0.0;
				if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0 && cboLoanType.SelectedIndex != 0)
				{
					((Control)lblFineRate).Visible = true;
					((Control)lblRCutAmt).Visible = true;
					((Control)lblPayAmt).Visible = true;
					((Control)lblOsAmt).Visible = true;
					((Control)nFineRate).Visible = true;
					((Control)nRcutAmt).Visible = true;
					((Control)nPayAmt).Visible = true;
					((Control)nOsAmt).Visible = true;
				}
				MSG_CLEAR();
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM DHRN_REC_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PACKET_NO"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["CUST_NAME"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 16] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_NO"], (object)""));
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ISU_SRNO"])), "0");
					mSG[DC_Main.i + 1, 15] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["PACKET_RE_ISU"], (object)""));
					mSG.Rows += 1;
					DC_Main.i++;
				}
				if (mSG.Rows > 2)
				{
					mSG.Rows -= 1;
				}
				mSG = null;
				tItDesc.Text = MSG[1, 18];
				MSG_TOT_FILL();
				BILL_TOTAL();
				OldValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]);
				NewValTot = Conversion.Val(MSG_TOT[0, 6]) + Conversion.Val(MSG_TOT[0, 8]);
				DC_Main.MsImageType = "DhranImage";
				DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + tIsuYrCd.Text + tIsuNo.Text + tAcCode.Text + Conversions.ToString(1);
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				}
				else
				{
					PicImage.Image = null;
				}
				AcImage();
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

	private void TR_DHRN_REC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_DHRN_REC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0376: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if (Conversion.Val(nIntAmt.Text) + Conversion.Val(nIntRecAmt.Text) + Conversion.Val(nDhrnReceived.Text) + Conversion.Val(nIntKasr.Text) != 0.0)
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
			DC_Main.RsQry = "SELECT * FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
			RsData = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.MsInsertData();
			DataRow dataRow2 = RsData.NewRow();
			dataRow2["CO_CODE"] = DC_Main.MCo_code;
			dataRow2["LC_CODE"] = DC_Main.MLc_code;
			dataRow2["CO_YEAR"] = DC_Main.MCo_year;
			dataRow2["CO_BOOK"] = DC_Main.MCo_Book;
			dataRow2["VCH_NO"] = tVchNo.Text;
			dataRow2["VCH_DATE"] = mVchDate.Text;
			dataRow2["DHRN_BILL"] = tBillNo.Text;
			dataRow2["HD_VCH_NO"] = tHdVchNo.Text;
			dataRow2["AC_CODE"] = tAcCode.Text;
			dataRow2["AC_NAME"] = tAcName.Text;
			dataRow2["FROM_DATE"] = mFromDate.Text;
			dataRow2["TO_DATE"] = mToDate.Text;
			dataRow2["VCH_TYPE"] = FormBookSname;
			dataRow2["INOUT_TYPE"] = FormBookInOut;
			if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
			{
				dataRow2["ENTRY_TYPE"] = "L";
			}
			else
			{
				dataRow2["ENTRY_TYPE"] = "D";
			}
			dataRow2["BOOK_NAME"] = FormMainBook;
			dataRow2["DHRN_LIC_NO"] = "";
			dataRow2["PACKET_NO"] = tPacketNo.Text;
			dataRow2["DHRN_DATE"] = mIsuDate.Text;
			dataRow2["LOAN_TYPE"] = Strings.Mid(cboLoanType.Text, 1, 1);
			dataRow2["DHRN_AMT"] = Conversion.Val(nDhrnAmt.Text);
			dataRow2["DHRN_ADJ_AMT"] = Conversion.Val(nDhrnAdjAmt.Text);
			dataRow2["UNCHAK_DHRN_REC"] = Conversion.Val(nAdvanceDhiran.Text);
			dataRow2["DHRN_OS_AMT"] = Conversion.Val(nPandingDhrn.Text) - (Conversion.Val(nAdvanceDhiran.Text) + Conversion.Val(nDhrnAdjAmt.Text));
			dataRow2["DHRN_REC_AMT"] = Conversion.Val(nDhrnReceived.Text);
			dataRow2["DHRN_MONTH"] = Conversion.Val(nDhrnMonth.Text);
			dataRow2["KASAR_AMT"] = Conversion.Val(nIntKasr.Text);
			dataRow2["INT_DAY"] = Conversion.Val(nIntDays.Text);
			dataRow2["INT_PRC"] = Conversion.Val(nIntPrc.Text);
			dataRow2["INT_AMT"] = Conversion.Val(nIntAmt.Text);
			dataRow2["INT_REC_AMT"] = Conversion.Val(nIntRecAmt.Text);
			dataRow2["INT_MONTH"] = Conversion.Val(nIntMonth.Text);
			dataRow2["LEDR_ACCD"] = tRecAc.Text;
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["GOLD_AMT"] = Conversion.Val(MSG_TOT[0, 14]);
			dataRow2["GOLD_WT"] = Conversion.Val(MSG_TOT[0, 6]);
			dataRow2["ISU_NO"] = tIsuNo.Text;
			dataRow2["ISU_LC"] = DC_Main.MLc_code;
			dataRow2["ISU_YRCD"] = tIsuYrCd.Text;
			dataRow2["ISU_DBCD"] = tIsuDbCd.Text;
			dataRow2["VCH_DESC"] = RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(tVchDesc.Text, "Text Hear", false) == 0, (object)"", (object)tVchDesc.Text));
			dataRow2["PAN_ADJ_AMT"] = Conversion.Val(nPanIntAmt.Text);
			dataRow2["ADJ_INT"] = Conversion.Val(nAdjInt.Text);
			dataRow2["ADJ_DHRN"] = Conversion.Val(nAdjDhiran.Text);
			dataRow2["EMP_CODE"] = tEmpCode.Text;
			dataRow2["MAIN_USER"] = MainUser;
			dataRow2["VCH_DESC"] = tVchDesc.Text;
			dataRow2["RCUT_RATE"] = Conversion.Val(nFineRate.Text);
			dataRow2["RCUT_AMT"] = Conversion.Val(nRcutAmt.Text);
			dataRow2["RCUT_PAY_AMT"] = Conversion.Val(nPayAmt.Text);
			dataRow2["RCUT_OS_AMT"] = Conversion.Val(nOsAmt.Text);
			dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
			dataRow2["DATA_TRFR"] = "N";
			dataRow2["USER_UPDATE"] = "N";
			dataRow2["USER_DELETE"] = "N";
			RsData.Rows.Add(dataRow2);
			((DbDataAdapter)(object)DC_Main.Da).Update(RsData);
			RsData.Clear();
		}
		DC_Main.RsQry = "SELECT * FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ";
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
				if ((Conversion.Val(MSG[DC_Main.i, 8]) + Conversion.Val(MSG[DC_Main.i, 14]) != 0.0) & (Operators.CompareString(MSG[DC_Main.i, 3], "", false) != 0))
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
					if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
					{
						dataRow3["ENTRY_TYPE"] = "L";
					}
					else
					{
						dataRow3["ENTRY_TYPE"] = "D";
					}
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["PACKET_NO"] = mSG[DC_Main.i, 1];
					dataRow3["CUST_NAME"] = mSG[DC_Main.i, 2];
					dataRow3["IT_CODE"] = mSG[DC_Main.i, 3];
					dataRow3["IT_NAME"] = mSG[DC_Main.i, 4];
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 5]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 6]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 7]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 8]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 9]);
					dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 10]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 11]);
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 12]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow3["IT_DESC"] = Strings.Mid(mSG[DC_Main.i, 18], 1, 249);
					dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 17];
					dataRow3["IT_TYPE"] = mSG[DC_Main.i, 16];
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["MAIN_USER"] = MainUser;
					dataRow3["ISU_LC"] = DC_Main.MLc_code;
					dataRow3["ISU_NO"] = mSG[DC_Main.i, 24];
					dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 25];
					dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 26];
					dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 27]);
					if (Operators.CompareString(mSG[DC_Main.i, 15], "", false) == 0)
					{
						mSG[DC_Main.i, 15] = "N";
					}
					dataRow3["PACKET_RE_ISU"] = mSG[DC_Main.i, 15];
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE DHRN_ISU_DETL SET DHRN_ISU_DETL.PACKET_REC = 'Y' FROM DHRN_ISU_DETL,DHRN_REC_DETL AS B WHERE DHRN_ISU_DETL.CO_CODE = B.CO_CODE AND DHRN_ISU_DETL.LC_CODE = B.LC_CODE AND DHRN_ISU_DETL.CO_YEAR = B.ISU_YRCD  AND DHRN_ISU_DETL.CO_BOOK = B.ISU_DBCD AND DHRN_ISU_DETL.VCH_NO = B.ISU_NO AND DHRN_ISU_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE DHRN_ISU_DATA SET DHRN_ISU_DATA.ISU_REC = CASE WHEN B.PACKET_RE_ISU ='Y' THEN 'N' ELSE 'Y' END FROM DHRN_ISU_DATA,DHRN_REC_DETL AS B,DHRN_ISU_DETL AS C WHERE B.CO_CODE = C.CO_CODE AND B.LC_CODE = C.LC_CODE AND B.ISU_YRCD = C.CO_YEAR AND B.ISU_DBCD = C.CO_BOOK AND B.ISU_NO = C.VCH_NO AND B.ISU_SRNO = C.SR_NO   AND C.CO_CODE = DHRN_ISU_DATA.CO_CODE And C.LC_CODE = DHRN_ISU_DATA.LC_CODE And C.DHRN_YRCD = DHRN_ISU_DATA.CO_YEAR  And C.DHRN_DBCD = DHRN_ISU_DATA.CO_BOOK And C.DHRN_NO = DHRN_ISU_DATA.VCH_NO And  C.PACKET_NO = DHRN_ISU_DATA.PACKET_NO  And B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.Loan_Isu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.Loan_Isu_RojMel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Tax.Loan_Isu_Data(DC_Main.MCo_Book, tVchNo.Text, DC_Main.MCo_year);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Loan_Isu_Stk(DC_Main.MCo_Book, tVchNo.Text);
			}
			else
			{
				DC_Main.RsQry = "UPDATE DHRN_ISU_DATA SET DHRN_ISU_DATA.ISU_REC = 'Y' FROM DHRN_ISU_DATA,DHRN_REC_DATA AS B WHERE DHRN_ISU_DATA.CO_CODE = B.CO_CODE AND DHRN_ISU_DATA.LC_CODE = B.LC_CODE AND DHRN_ISU_DATA.CO_YEAR = B.ISU_YRCD  AND DHRN_ISU_DATA.CO_BOOK = B.ISU_DBCD AND DHRN_ISU_DATA.VCH_NO = B.ISU_NO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.DhrnRec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.DhrnRec_RojMel(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Tax.DhrnRec_Data(DC_Main.MCo_Book, tVchNo.Text, DC_Main.MCo_year);
				DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Stock.Dhrn_Rec_Stk(DC_Main.MCo_Book, tVchNo.Text);
			}
			Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
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
			CustOpGold = DC_Main.MsAcGoldOpBal;
			CustClGold = DC_Main.MsAcGoldClBal;
			CustOpSilver = DC_Main.MsAcSilverOpBal;
			CustClSilver = DC_Main.MsAcSilverClBal;
			CLEAR_DATA();
			BtnPrint_Click(BtnPrint, new EventArgs());
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
		}
	}

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Invalid comparison between Unknown and I4
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,1,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,AC_CODE,AC_NAME,0,DHRN_AMT,'A',0,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "',SUBSTRING(VCH_DESC,1,149) FROM DHRN_REC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE DHRN_ISU_DETL SET DHRN_ISU_DETL.PACKET_REC = 'N' FROM DHRN_ISU_DETL,DHRN_REC_DETL AS B WHERE DHRN_ISU_DETL.CO_CODE = B.CO_CODE AND DHRN_ISU_DETL.LC_CODE = B.LC_CODE AND DHRN_ISU_DETL.CO_YEAR = B.ISU_YRCD  AND DHRN_ISU_DETL.CO_BOOK = B.ISU_DBCD AND DHRN_ISU_DETL.VCH_NO = B.ISU_NO AND DHRN_ISU_DETL.SR_NO = B.ISU_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE DHRN_ISU_DATA SET DHRN_ISU_DATA.ISU_REC ='Y' FROM DHRN_ISU_DATA,DHRN_REC_DETL AS B,DHRN_ISU_DETL AS C WHERE B.CO_CODE = C.CO_CODE AND B.LC_CODE = C.LC_CODE AND B.ISU_YRCD = C.CO_YEAR AND B.ISU_DBCD = C.CO_BOOK AND B.ISU_NO = C.VCH_NO AND B.ISU_SRNO = C.SR_NO   AND C.CO_CODE = DHRN_ISU_DATA.CO_CODE And C.LC_CODE = DHRN_ISU_DATA.LC_CODE And C.DHRN_YRCD = DHRN_ISU_DATA.CO_YEAR  And C.DHRN_DBCD = DHRN_ISU_DATA.CO_BOOK And C.DHRN_NO = DHRN_ISU_DATA.VCH_NO And  C.PACKET_NO = DHRN_ISU_DATA.PACKET_NO  And B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.PACKET_RE_ISU ='Y' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else
			{
				DC_Main.RsQry = "UPDATE DHRN_ISU_DATA SET DHRN_ISU_DATA.ISU_REC = 'N' FROM DHRN_ISU_DATA,DHRN_REC_DATA AS B WHERE DHRN_ISU_DATA.CO_CODE = B.CO_CODE AND DHRN_ISU_DATA.LC_CODE = B.LC_CODE AND DHRN_ISU_DATA.CO_YEAR = B.ISU_YRCD  AND DHRN_ISU_DATA.CO_BOOK = B.ISU_DBCD AND DHRN_ISU_DATA.VCH_NO = B.ISU_NO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM DHRN_REC_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_DHRN_REC_KeyDown(object sender, KeyEventArgs e)
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
				((Control)nIntRecAmt).Focus();
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
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\DhrnIntRec.RPT";
		Cr.SelectionFormula = "{DHRN_REC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {DHRN_REC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {DHRN_REC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {DHRN_REC_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {DHRN_REC_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_DHRN_REC_Activated(object sender, EventArgs e)
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.AC_NAME As VchNameL,A.MAIN_USER As UserL FROM DHRN_REC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 250.0;
		DC_Main.ColWidth[4] = 125.0;
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
			if (Operators.CompareString(EntryMode, "E", false) != 0)
			{
				mToDate.Text = mVchDate.Text;
			}
			SendKeys.Send("{TAB}");
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
				DC_Main.RsQry = "SELECT VCH_NO FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM DHRN_REC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_DHRN_REC_Closed(object sender, EventArgs e)
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
		//IL_028e: Unknown result type (might be due to invalid IL or missing references)
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
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" ORDER BY A.AC_NAME"));
			}
			else if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT C.AC_NAME As AcNameL,C.AC_CODE As AcCodeL,D.AC_GR_NAME AS GroupL,C.AC_AREA As AreaL,C.AC_ADD1 As AddressL,C.AC_CITY As CityL,C.AC_MOBILE As MobileL FROM AC_MAST AS C LEFT JOIN AC_GROUP AS D ON C.CO_CODE = D.CO_CODE AND C.AC_GR = D.AC_GR WHERE C.CO_CODE = '" + DC_Main.MCo_code + "' AND CAST(C.AC_CODE AS INT) < 100   UNION ALL SELECT A.AC_NAME,A.AC_CODE,B.AC_GR_NAME,A.AC_AREA,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" AND CAST(A.AC_CODE AS INT) >=200 ORDER BY C.AC_NAME "));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0, (object)"AND A.AC_GR IN('01','03','04')", (object)"AND A.AC_GR = '15'")), (object)" ORDER BY A.AC_NAME"));
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
				DC_Main.MsGrCode = "15";
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
			if (Operators.CompareString(EntryMode, "A", false) == 0)
			{
				tIsuNo.Text = "";
				tIsuYrCd.Text = "";
				tIsuDbCd.Text = "";
				nDhrnAmt.Text = "";
				nDhrnReceived.Text = "";
				nIntRecAmt.Text = "";
				MSG_CLEAR();
			}
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
			lblAdd1.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_ADD1"], (object)""));
			lblCity.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CITY"], (object)""));
			lblMobile.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_MOBILE"], (object)""));
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
			DC_Main.MsAcAmtClBal = 0.0;
			AcImage();
		}
		SendKeys.Send("{tab}");
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM DHRN_REC_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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

	private void BILL_TOTAL()
	{
		checked
		{
			if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
			{
				nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1);
			}
			else
			{
				nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
			}
			if ((double)OldIntDay != Conversion.Val(nIntDays.Text) + Conversion.Val(nIntPrc.Text))
			{
				OldIntDay = (int)Math.Round(Conversion.Val(nIntDays.Text) + Conversion.Val(nIntPrc.Text));
				double num4 = default(double);
				double num5 = default(double);
				if (Operators.CompareString(CurIntTypeCalc, "M", false) != 0)
				{
					if (chkInt.Checked)
					{
						if (Conversion.Val(nIntDays.Text) != 0.0)
						{
							nIntYear.Text = Strings.Format((object)(Conversion.Val(nIntDays.Text) / 365.0), "0.00");
						}
						if (Conversion.Val(nIntYear.Text) > 1.0)
						{
							if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
							{
								nIntYear.Text = Strings.Mid(nIntYear.Text, 1, 1);
								double num = Conversion.Val(nPandingDhrn.Text);
								int num2 = (int)Math.Round(Conversion.Val(nIntYear.Text));
								DC_Main.M = 1;
								while (DC_Main.M <= num2)
								{
									double num3 = Conversions.ToDouble(Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * 360.0), "0.00"));
									num4 += num3;
									num += num3;
									num5 += 360.0;
									DC_Main.M++;
								}
								if (cboLoanType.SelectedIndex != 0)
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num5) + num4, 3), "0.000");
								}
								else
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num5) + num4), "0.00");
								}
							}
						}
						else if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text), 3), "0.000");
							}
							else
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text)), "0.00");
							}
						}
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.000");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.000");
							}
							else
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.00");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.00");
							}
						}
					}
					else
					{
						if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text), 3), "0.000");
							}
							else
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text)), "0.00");
							}
						}
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.000");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.000");
							}
							else
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.00");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.00");
							}
						}
					}
				}
				else
				{
					int num6 = 0;
					if ((Operators.CompareString(mFromDate.Text, DC_Main.MMask, false) != 0) & (Operators.CompareString(mFromDate.Text, "", false) != 0))
					{
						num6 = (int)Math.Round((double)Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) / 365.0 * 360.0 / 30.0);
						nIntMonth.Text = Conversions.ToString(num6);
					}
					if ((Conversion.Val(nIntDays.Text) != 0.0) & (Operators.CompareString(Strings.Mid(mFromDate.Text, 1, 2), Strings.Mid(mToDate.Text, 1, 2), false) == 0))
					{
						nIntDays.Text = Conversions.ToString(num6 * 30);
						double value = Conversion.Val(nIntDays.Text) - Math.Round(Conversions.ToDouble(Strings.Format((object)Conversion.Val(nIntDays.Text), "0")) / 30.0) * 30.0;
						nIntDays.Text = Conversions.ToString(Conversion.Val(nIntDays.Text) - Math.Abs(value));
					}
					else
					{
						nIntDays.Text = Conversions.ToString(num6 * 30);
						double value = Conversion.Val(nIntDays.Text) - Math.Round(Conversions.ToDouble(Strings.Format((object)Conversion.Val(nIntDays.Text), "0")) / 30.0) * 30.0;
						nIntDays.Text = Conversions.ToString(Conversion.Val(nIntDays.Text) - Math.Abs(value));
					}
					if (Conversion.Val(nIntDays.Text) != 0.0)
					{
						nIntYear.Text = Strings.Format((object)(Conversion.Val(nIntDays.Text) / 365.0), "0.00");
					}
					if (chkInt.Checked)
					{
						if (Conversion.Val(nIntYear.Text) > 1.0)
						{
							if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
							{
								nIntYear.Text = Strings.Mid(nIntYear.Text, 1, 1);
								double num = Conversion.Val(nPandingDhrn.Text);
								int num7 = (int)Math.Round(Conversion.Val(nIntYear.Text));
								DC_Main.M = 1;
								while (DC_Main.M <= num7)
								{
									double num3 = Conversions.ToDouble(Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * 360.0), "0.00"));
									num4 += num3;
									num += num3;
									num5 += 360.0;
									DC_Main.M++;
								}
								if (cboLoanType.SelectedIndex != 0)
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num5) + num4, 3), "0.000");
								}
								else
								{
									nIntAmt.Text = Strings.Format((object)Math.Round(num * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * (Conversion.Val(nIntDays.Text) - num5) + num4), "0.00");
								}
							}
						}
						else if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text), 3), "0.000");
							}
							else
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text)), "0.00");
							}
						}
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.000");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.000");
							}
							else
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.00");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.00");
							}
						}
					}
					else
					{
						if (((Conversion.Val(nPandingDhrn.Text) != 0.0) & (Conversion.Val(nIntDays.Text) != 0.0)) && Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text), 3), "0.000");
							}
							else
							{
								nIntAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nPandingDhrn.Text) * Conversion.Val(nIntPrc.Text) / 100.0 / DC_Main.MsIntYearDays * Conversion.Val(nIntDays.Text)), "0.00");
							}
						}
						if (Operators.CompareString(EntryMode, "E", false) != 0)
						{
							if (cboLoanType.SelectedIndex != 0)
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.000");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.000");
							}
							else
							{
								nIntRecAmt.Text = Strings.Format((object)nIntAmt.Text, "0.00");
								nDhrnReceived.Text = Strings.Format((object)nPandingDhrn.Text, "0.00");
							}
						}
					}
				}
			}
			if (cboLoanType.SelectedIndex != 0)
			{
				nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text) - Conversion.Val(nAdjInt.Text)), "0.000");
				nDhrnReceived.Text = Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) - Conversion.Val(nAdjDhiran.Text)), "0.000");
				nTotRec.Text = Strings.Format((object)(Conversion.Val(nIntRecAmt.Text) + Conversion.Val(nDhrnReceived.Text) - Conversion.Val(nIntKasr.Text)), "0.000");
			}
			else
			{
				if (Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text) >= AdvanceRecAmt)
				{
					if (Operators.CompareString(EntryMode, "E", false) == 0)
					{
						nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text) - Conversion.Val(nAdjInt.Text)), "0.00");
					}
					else
					{
						nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text) - AdvanceRecAmt), "0.00");
						nAdjInt.Text = Strings.Format((object)AdvanceRecAmt, "0.00");
					}
				}
				else
				{
					nIntRecAmt.Text = "";
					nAdjInt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
					nAdjDhiran.Text = Strings.Format((object)(AdvanceRecAmt - Conversion.Val(nIntAmt.Text)), "0.00");
				}
				if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) != 0)
				{
					nDhrnReceived.Text = Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) - (Conversion.Val(nAdjDhiran.Text) + Conversion.Val(nAdvanceDhiran.Text))), "0.00");
				}
				else if (Conversion.Val(nDhrnReceived.Text) == 0.0)
				{
					nDhrnReceived.Text = Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) - (Conversion.Val(nAdjDhiran.Text) + Conversion.Val(nAdvanceDhiran.Text))), "0.00");
				}
				nTotRec.Text = Strings.Format((object)(Conversion.Val(nIntRecAmt.Text) + Conversion.Val(nDhrnReceived.Text) - Conversion.Val(nIntKasr.Text)), "0.00");
			}
			if (((Control)nFineRate).Visible)
			{
				if (cboLoanType.SelectedIndex != 0)
				{
					nOsAmt.Text = Strings.Format((object)(Conversion.Val(nRcutAmt.Text) - Conversion.Val(nPayAmt.Text)), "0.000");
				}
				else
				{
					nRcutAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nTotRec.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
					nOsAmt.Text = Strings.Format((object)(Conversion.Val(nRcutAmt.Text) - Conversion.Val(nPayAmt.Text)), "0.00");
				}
			}
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + (Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text)) - Conversion.Val(nTotRec.Text) - Conversion.Val(nIntKasr.Text);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(nIntRecAmt.Text) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(nIntRecAmt.Text);
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
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if ((int)Interaction.MsgBox((object)"Creat New Addres ?", (MsgBoxStyle)292, (object)null) == 6)
		{
			if ((int)e.KeyCode == 13)
			{
				SendKeys.Send("{TAB}");
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
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (CurRow != MSG.Row)
		{
			CurRow = MSG.Row;
			DC_Main.MsImageType = "DhranImage";
			DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + tIsuYrCd.Text + tIsuNo.Text + tAcCode.Text + Conversions.ToString(Conversion.Val(MSG[MSG.Row, 0]));
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

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void nDhrnAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				nDhrnAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnAmt.Text)), "0.000");
			}
			else
			{
				nDhrnAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnAmt.Text)), "0.00");
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nMonthlyInt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nMonthlyInt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nMonthlyInt.Text)), "0.00");
			if (OldMontIntPrc != Conversion.Val(nMonthlyInt.Text))
			{
				OldMontIntPrc = Conversion.Val(nMonthlyInt.Text);
				nIntPrc.Text = Strings.Format((object)(Conversion.Val(nMonthlyInt.Text) * 12.0), "0.00");
			}
			OldIntDay = 0;
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nIntPrc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntPrc.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntPrc.Text)), "0.00");
			if ((Conversion.Val(nMonthlyInt.Text) == 0.0) | (OldIntPrc != Conversion.Val(nIntPrc.Text)))
			{
				OldIntPrc = Conversion.Val(nIntPrc.Text);
				nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
				OldMontIntPrc = Conversion.Val(nMonthlyInt.Text);
			}
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nDhrnMonth_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDhrnMonth.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnMonth.Text)), "0");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void nIntAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		nIntAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntAmt.Text)), "0.00");
		DC_Main.RsQry = "SELECT B.ISU_NO AS IsuNoL,A.DHRN_BILL AS RefNoL,A.VCH_DATE AS IsuDateM,C.AC_NAME,A.DHRN_AMT AS DhiranAmtR,A.INT_PRC AS InterestR,B.ISU_YRCD AS YearM, B.ISU_DBCD As BookM,sum(B.INT_REC_AMT - B.INT_AMT)As IntBalance FROM (DHRN_REC_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE ='" + tAcCode.Text + "' and B.ISU_NO = '" + tIsuNo.Text + "' AND B.ISU_DBCD = '" + tIsuDbCd.Text + "' AND B.ISU_YRCD  = '" + tIsuYrCd.Text + "' GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL HAVING SUM(B.INT_REC_AMT - B.INT_AMT) >0 ORDER BY A.VCH_DATE,B.ISU_NO";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count > 0)
		{
			if (Conversion.Val(nIntAmt.Text) >= Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntBalance"]), "0.00")))
			{
				nAdjInt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["IntBalance"]), "0.00");
				nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) - Conversion.Val(nAdjInt.Text)), "0.00");
			}
			else
			{
				nAdjInt.Text = Strings.Format((object)Conversion.Val(nIntAmt.Text), "0.00");
				nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) - Conversion.Val(nAdjInt.Text)), "0.00");
				nAdjDhiran.Text = Strings.Format(Operators.SubtractObject(dataTable.Rows[0]["IntBalance"], (object)Conversion.Val(nIntAmt.Text)), "0.00");
				nDhrnReceived.Text = Strings.Format((object)(Conversion.Val(nPandingDhrn.Text) - Conversion.Val(nAdjDhiran.Text)), "0.00");
			}
		}
		else
		{
			nIntRecAmt.Text = Strings.Format((object)(Conversion.Val(nIntAmt.Text) + Conversion.Val(nPanIntAmt.Text)), "0.00");
		}
		BILL_TOTAL();
		if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) == 0)
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
		else
		{
			((Control)nIntRecAmt).Focus();
		}
	}

	private void tPacketNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{TAB}");
		}
	}

	private void tRecAc_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tRecAc.Text + "'";
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
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tRecAc.Text = DC_Main.ColValue[1];
					tRecAcName.Text = DC_Main.ColValue[0];
				}
				((Control)tRecAc).Focus();
			}
		}
		else
		{
			tRecAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			SendKeys.Send("{TAB}");
		}
	}

	private void BtnIssue_Click(object sender, EventArgs e)
	{
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT B.ISU_NO AS IsuNoL,A.DHRN_BILL AS RefNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS IsuDateM,C.AC_NAME,A.DHRN_AMT AS DhiranAmtR,A.INT_PRC AS InterestR,B.ISU_YRCD AS YearM, B.ISU_DBCD As BookM,sum(B.DHRN_REC_AMT)As DhrnRecR,sum(B.UNCHAK_DHRN_REC) As UnchakRecR ,A.GOLD_DESC AS ItemName FROM (DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE ='" + tAcCode.Text + "' AND A.LOAN_TYPE = '" + Strings.Mid(cboLoanType.Text, 1, 1) + "'  GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL,A.GOLD_DESC HAVING SUM(B.DHRN_REC_AMT)+sum(B.UNCHAK_DHRN_REC) < A.DHRN_AMT  ORDER BY A.VCH_DATE,B.ISU_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[12];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 90.0;
		DC_Main.ColWidth[2] = 120.0;
		DC_Main.ColWidth[3] = 300.0;
		DC_Main.ColWidth[4] = 100.0;
		DC_Main.ColWidth[5] = 80.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 0.0;
		DC_Main.ColWidth[8] = 110.0;
		DC_Main.ColWidth[9] = 110.0;
		DC_Main.ColWidth[10] = 250.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (DC_Main.HelpClose || DC_Main.HelpClose)
		{
			return;
		}
		if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
		{
			tIsuNo.Text = DC_Main.ColValue[0];
			tIsuYrCd.Text = DC_Main.ColValue[6];
			tIsuDbCd.Text = DC_Main.ColValue[7];
			if (cboLoanType.SelectedIndex != 0)
			{
				nDhrnAdjAmt.Text = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.000");
			}
			else
			{
				nDhrnAdjAmt.Text = Strings.Format((object)Conversion.Val(DC_Main.ColValue[8]), "0.00");
			}
			DC_Main.RsQry = "SELECT OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ISU_NO FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + tIsuYrCd.Text + "' AND CO_BOOK = '" + tIsuDbCd.Text + "' AND VCH_NO = '" + tIsuNo.Text + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ISU_NO FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND OLD_ISU_YRCD = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_YRCD"]), (object)"' AND OLD_ISU_DBCD = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_DBCD"]), (object)"' AND OLD_ISU_NO = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_NO"]), (object)"' "));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Tbl.Rows.Count > 1)
				{
					((Control)lblOrnaAgainstDhrn).Visible = true;
					((Control)nOrnaAginestDhrn).Visible = true;
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ISU_NO,SUM(DHRN_AMT) As TotDhrn FROM DHRN_ISU_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND OLD_ISU_YRCD = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_YRCD"]), (object)"' AND OLD_ISU_DBCD = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_DBCD"]), (object)"' AND OLD_ISU_NO = '"), DC_Main.Tbl.Rows[0]["OLD_ISU_NO"]), (object)"' GROUP BY OLD_ISU_YRCD,OLD_ISU_DBCD,OLD_ISU_NO "));
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Tbl.Rows.Count > 0)
					{
						nOrnaAginestDhrn.Text = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["TotDhrn"])), "0.00");
					}
				}
			}
			((Control)tIsuNo).Focus();
		}
		else
		{
			((Control)tIsuNo).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void tIsuNo_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		checked
		{
			if ((Operators.CompareString(tIsuNo.Text, "", false) == 0) | (Operators.CompareString(OldIsuNo, tIsuNo.Text, false) != 0))
			{
				DC_Main.RsQry = "Select A.* from DHRN_ISU_DATA AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND A.CO_BOOK ='" + tIsuDbCd.Text + "'  AND A.VCH_NO = '" + tIsuNo.Text + "' AND A.AC_CODE ='" + tAcCode.Text + "'  ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count == 0)
				{
					BtnIssue_Click(BtnIssue, new EventArgs());
					((Control)tIsuNo).Focus();
					return;
				}
				mIsuDate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
				OldIsuNo = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
				tBillNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DHRN_BILL"], (object)""));
				tPacketNo.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["PACKET_NO"], (object)""));
				nDhrnMonth.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_MONTH"]), "00");
				if (cboLoanType.SelectedIndex != 0)
				{
					nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_AMT"]), "0.000");
					nPandingDhrn.Text = Strings.Format((object)(Conversion.Val(nDhrnAmt.Text) - Conversion.Val(nDhrnAdjAmt.Text)), "0.000");
					nIntPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["INT_PRC"]), "0.00");
				}
				else
				{
					nDhrnAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["DHRN_AMT"]), "0.00");
					nPandingDhrn.Text = Strings.Format((object)(Conversion.Val(nDhrnAmt.Text) - Conversion.Val(nDhrnAdjAmt.Text)), "0.00");
					nIntPrc.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["INT_PRC"]), "0.00");
				}
				if (Conversion.Val(nIntPrc.Text) != 0.0)
				{
					nMonthlyInt.Text = Strings.Format((object)(Conversion.Val(nIntPrc.Text) / 12.0), "0.00");
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT * FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND ISU_YRCD = '"), DC_Main.Rshlp.Rows[0]["CO_YEAR"]), (object)"' AND ISU_DBCD = '"), DC_Main.Rshlp.Rows[0]["CO_BOOK"]), (object)"' AND ISU_NO = '"), (object)tIsuNo.Text), (object)"'  AND AC_CODE = '"), DC_Main.Rshlp.Rows[0]["AC_CODE"]), (object)"'  ORDER BY TO_DATE DESC"));
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					mFromDate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["TO_DATE"]), "dd/MM/yyyy");
				}
				else
				{
					mFromDate.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
				}
				if (DateTime.Compare(Conversions.ToDate(mVchDate.Text), Conversions.ToDate(mFromDate.Text)) < 0)
				{
					mToDate.Text = mFromDate.Text;
				}
				else
				{
					if (Operators.CompareString(DC_Main.MsIntDayCalc, "2", false) == 0)
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)) + 1);
					}
					else
					{
						nIntDays.Text = Conversions.ToString(Math.Abs(DateAndTime.DateDiff((DateInterval)4, Conversions.ToDate(mToDate.Text), Conversions.ToDate(mFromDate.Text), (FirstDayOfWeek)1, (FirstWeekOfYear)1)));
					}
					if (Operators.CompareString(CurIntTypeCalc, "M", false) == 0)
					{
						switch (Strings.Mid(mVchDate.Text, 4, 2))
						{
						case "02":
							if (Conversions.ToDouble(Strings.Mid(mFromDate.Text, 1, 2)) > 28.0)
							{
								mToDate.Text = "01/" + Strings.Mid(mVchDate.Text, 4, 2) + "/" + Strings.Mid(mToDate.Text, 7, 4);
							}
							else
							{
								mToDate.Text = string.Concat(Strings.Mid(mFromDate.Text, 1, 3) + Strings.Mid(mVchDate.Text, 4, 3), Strings.Mid(mToDate.Text, 7, 4));
							}
							break;
						case "04":
						case "06":
						case "09":
						case "11":
							if (Conversions.ToDouble(Strings.Mid(mFromDate.Text, 1, 2)) > 30.0)
							{
								mToDate.Text = "01/" + Strings.Mid(mVchDate.Text, 4, 2) + "/" + Strings.Mid(mToDate.Text, 7, 4);
							}
							else
							{
								mToDate.Text = string.Concat(Strings.Mid(mFromDate.Text, 1, 3) + Strings.Mid(mVchDate.Text, 4, 3), Strings.Mid(mToDate.Text, 7, 4));
							}
							break;
						default:
							mToDate.Text = string.Concat(Strings.Mid(mFromDate.Text, 1, 3) + Strings.Mid(mVchDate.Text, 4, 3), Strings.Mid(mToDate.Text, 7, 4));
							break;
						}
						if (DateTime.Compare(Conversions.ToDate(mToDate.Text), Conversions.ToDate(mVchDate.Text)) < 0)
						{
							double num = Conversion.Val((object)DateAndTime.Month(Conversions.ToDate(mVchDate.Text)));
							if (num == 1.0 || num == 3.0 || num == 5.0 || num == 7.0 || num == 8.0 || num == 10.0 || num == 12.0)
							{
								mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(31.0));
							}
							else if (num == 2.0)
							{
								mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(28.0));
							}
							else if (num == 4.0 || num == 6.0 || num == 9.0 || num == 11.0)
							{
								mToDate.Text = Conversions.ToString(Conversions.ToDate(mToDate.Text).AddDays(30.0));
							}
						}
					}
				}
				DC_Main.RsQry = "SELECT SUM(INT_AMT - INT_REC_AMT) As PanInt,SUM(UNCHAK_DHRN_REC) As AdvanceDhrnRec FROM DHRN_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ISU_YRCD = '" + tIsuYrCd.Text + "' AND ISU_DBCD = '" + tIsuDbCd.Text + "' AND ISU_NO = '" + tIsuNo.Text + "'  AND AC_CODE = '" + tAcCode.Text + "'  ";
				dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PanInt"])) > 0.0)
					{
						if (cboLoanType.SelectedIndex != 0)
						{
							nPanIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PanInt"]), "0.000");
						}
						else
						{
							nPanIntAmt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PanInt"]), "0.00");
						}
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["PanInt"])) < 0.0)
					{
						if (cboLoanType.SelectedIndex != 0)
						{
							Type? typeFromHandle = typeof(Math);
							DataRow dataRow;
							object[] obj = new object[1] { (dataRow = dataTable.Rows[0])["PanInt"] };
							object[] array = obj;
							bool[] obj2 = new bool[1] { true };
							bool[] array2 = obj2;
							object obj3 = NewLateBinding.LateGet((object)null, typeFromHandle, "Abs", obj, (string[])null, (Type[])null, obj2);
							if (array2[0])
							{
								dataRow["PanInt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
							}
							AdvanceRecAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(obj3), "0.000"));
						}
						else
						{
							Type? typeFromHandle2 = typeof(Math);
							DataRow dataRow;
							object[] obj4 = new object[1] { (dataRow = dataTable.Rows[0])["PanInt"] };
							object[] array = obj4;
							bool[] obj5 = new bool[1] { true };
							bool[] array2 = obj5;
							object obj6 = NewLateBinding.LateGet((object)null, typeFromHandle2, "Abs", obj4, (string[])null, (Type[])null, obj5);
							if (array2[0])
							{
								dataRow["PanInt"] = RuntimeHelpers.GetObjectValue(RuntimeHelpers.GetObjectValue(array[0]));
							}
							AdvanceRecAmt = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(obj6), "0.00"));
						}
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdvanceDhrnRec"])) != 0.0)
					{
						if (cboLoanType.SelectedIndex != 0)
						{
							nAdvanceDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdvanceDhrnRec"]), "0.000");
						}
						else
						{
							nAdvanceDhiran.Text = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["AdvanceDhrnRec"]), "0.00");
						}
					}
				}
				MSG_CLEAR();
				if (Operators.CompareString(FormMainBook, "LOAN ISSUE", false) != 0)
				{
					DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM DHRN_ISU_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + tIsuYrCd.Text + "' AND  A.CO_BOOK = '" + tIsuDbCd.Text + "' AND A.VCH_NO = '" + tIsuNo.Text + "' ORDER BY A.SR_NO";
					RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.i = 0;
					AxMSFlexGrid mSG = MSG;
					while (DC_Main.i < RsDetl.Rows.Count)
					{
						mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
						mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
						mSG[DC_Main.i + 1, 5] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
						mSG[DC_Main.i + 1, 6] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
						mSG[DC_Main.i + 1, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
						mSG[DC_Main.i + 1, 8] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
						mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[DC_Main.i + 1, 21] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
						mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST_PRC"])), "0.00");
						mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST_PRC"])), "0.00");
						mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
						mSG[DC_Main.i + 1, 18] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
						mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
						mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
						mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
						mSG[DC_Main.i + 1, 17] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
						mSG[DC_Main.i + 1, 16] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
						mSG.Rows += 1;
						DC_Main.i++;
					}
					if (mSG.Rows > 2)
					{
						mSG.Rows -= 1;
					}
					mSG = null;
				}
				tItDesc.Text = MSG[MSG.Rows - 1, 18];
				MSG_TOT_FILL();
				DC_Main.MsImageType = "DhranImage";
				DC_Main.MsImageNo = Conversions.ToString(Conversion.Val(DC_Main.MCo_code)) + DC_Main.MLc_code + tIsuYrCd.Text + tIsuNo.Text + tAcCode.Text + Conversions.ToString(1);
				DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
				if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
				{
					PicImage.Image = Image.FromFile(DC_Main.MsImagePath);
				}
				else
				{
					PicImage.Image = null;
				}
				((Control)mToDate).Focus();
			}
			else
			{
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void nIntRecAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntRecAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntRecAmt.Text)), "0.00");
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void nIntDays_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntDays.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntDays.Text)), "0");
			BILL_TOTAL();
			SendKeys.Send("{TAB}");
		}
	}

	private void mIsuDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mIsuDate;
			DC_Main.SetDate(ref MsDate);
			mIsuDate = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void mFromDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDate).SelectionStart = 0;
		((TextBoxBase)mFromDate).SelectionLength = Strings.Len(mFromDate.Text);
	}

	private void mFromDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDate;
			DC_Main.SetDate(ref MsDate);
			mToDate = MsDate;
			if (!DC_Main.RongDate)
			{
				BILL_TOTAL();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void mToDate_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDate).SelectionStart = 0;
		((TextBoxBase)mToDate).SelectionLength = Strings.Len(mToDate.Text);
	}

	private void mToDate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDate;
			DC_Main.SetDate(ref MsDate);
			mToDate = MsDate;
			if (!DC_Main.RongDate)
			{
				BILL_TOTAL();
				SendKeys.Send("{TAB}");
			}
		}
	}

	private void nDhrnReceived_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nDhrnReceived.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nDhrnReceived.Text)), "0.000");
			BILL_TOTAL();
			SendKeys.Send("{tab}");
		}
	}

	private void nIntKasr_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nIntKasr.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nIntKasr.Text)), "0.000");
			BILL_TOTAL();
			if (((Control)nFineRate).Visible)
			{
				((Control)nFineRate).Focus();
			}
			else
			{
				((Control)tRecAc).Focus();
			}
		}
	}

	private void chkInt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			BILL_TOTAL();
			((Control)mToDate).Focus();
		}
	}

	private void cboLoanType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (cboLoanType.SelectedIndex != 0)
			{
				((Control)lblFineRate).Visible = true;
				((Control)lblRCutAmt).Visible = true;
				((Control)lblPayAmt).Visible = true;
				((Control)lblOsAmt).Visible = true;
				((Control)nFineRate).Visible = true;
				((Control)nRcutAmt).Visible = true;
				((Control)nPayAmt).Visible = true;
				((Control)nOsAmt).Visible = true;
			}
			SendKeys.Send("{tab}");
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void AcImage()
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
			PicAcImage.Image = Image.FromFile(DC_Main.MsImagePath);
		}
		else
		{
			PicAcImage.Image = null;
		}
	}

	private void PicAcImage_DoubleClick(object sender, EventArgs e)
	{
		PicZoom.Image = PicAcImage.Image;
		((Control)PicZoom).Left = ((Control)this).Left;
		((Control)PicZoom).Top = ((Control)this).Top;
		((Control)PicZoom).Width = ((Control)this).Width;
		((Control)PicZoom).Height = ((Control)this).Height;
		((Control)PicZoom).BringToFront();
		((Control)PicZoom).Visible = true;
	}

	private void chkInt_Click(object sender, EventArgs e)
	{
		OldIntDay = 0;
		BILL_TOTAL();
	}

	private void TR_DHRN_REC_KeyUp(object sender, KeyEventArgs e)
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

	private void BtnMultyTimeIsu_Click(object sender, EventArgs e)
	{
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(tIsuNo.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select Dhiran Isu No and Try....", (MsgBoxStyle)0, (object)null);
			((Control)tIsuNo).Focus();
			return;
		}
		DC_Main.RsQry = "SELECT B.ISU_NO AS IsuNoL,A.DHRN_BILL AS RefNoL,FORMAT(A.VCH_DATE,'dd/MM/yyyy') AS IsuDateM,C.AC_NAME As AcNameL,A.DHRN_AMT AS DhiranAmtR,A.INT_PRC AS InterestR,B.ISU_YRCD AS YearM, B.ISU_DBCD As BookM,sum(B.DHRN_REC_AMT)As DhrnRecR,A.GOLD_DESC AS ItemName FROM (DHRN_ISU_DATA AS A LEFT JOIN DHRN_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.CO_YEAR = B.ISU_YRCD AND A.CO_BOOK = B.ISU_DBCD AND A.VCH_NO = B.ISU_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE ='" + tAcCode.Text + "'  AND OLD_ISU_NO = '" + tIsuNo.Text + "' AND OLD_ISU_DBCD = '" + tIsuDbCd.Text + "' AND OLD_ISU_YRCD = '" + tIsuYrCd.Text + "' GROUP BY A.VCH_DATE,B.ISU_NO,A.DHRN_AMT,A.INT_PRC,C.AC_NAME,B.ISU_DBCD,B.ISU_YRCD,A.DHRN_BILL,A.GOLD_DESC HAVING SUM(B.DHRN_REC_AMT) < A.DHRN_AMT  ORDER BY A.VCH_DATE,B.ISU_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[11];
		DC_Main.ColWidth[0] = 90.0;
		DC_Main.ColWidth[1] = 90.0;
		DC_Main.ColWidth[2] = 120.0;
		DC_Main.ColWidth[3] = 330.0;
		DC_Main.ColWidth[4] = 110.0;
		DC_Main.ColWidth[5] = 110.0;
		DC_Main.ColWidth[6] = 0.0;
		DC_Main.ColWidth[7] = 0.0;
		DC_Main.ColWidth[8] = 110.0;
		DC_Main.ColWidth[9] = 250.0;
		DC_Main.HelpSelect = 0;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
		}
	}

	private void nFineRate_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nFineRate.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nFineRate.Text)), "0.00");
			nRcutAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nTotRec.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			if (Conversion.Val(nPayAmt.Text) == 0.0)
			{
				nPayAmt.Text = Strings.Format((object)Math.Round(Conversion.Val(nTotRec.Text) * Conversion.Val(nFineRate.Text), 0), "0.00");
			}
			((Control)nPayAmt).Focus();
		}
	}

	private void nPayAmt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			nPayAmt.Text = Strings.Format((object)Convert.ToDouble(Conversion.Val(nPayAmt.Text)), "0.00");
			nOsAmt.Text = Strings.Format((object)(Conversion.Val(nRcutAmt.Text) - Conversion.Val(nPayAmt.Text)), "0.00");
			((Control)tRecAc).Focus();
		}
	}

	private void cboLoanType_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
