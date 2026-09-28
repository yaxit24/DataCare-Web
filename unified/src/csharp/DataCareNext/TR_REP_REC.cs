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
public class TR_REP_REC : Form
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
	[AccessedThroughProperty("MSG2_TOTAL")]
	private AxMSFlexGrid _MSG2_TOTAL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("MSG")]
	private AxMSFlexGrid _MSG;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY_2")]
	private TextBox _TEXT_ENTRY_2;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("TEXT_ENTRY")]
	private TextBox _TEXT_ENTRY;

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
	[AccessedThroughProperty("tVchDesc")]
	private TextBox _tVchDesc;

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

	private string OldAcCode;

	private string AcGstType;

	private double PurcAcFine;

	private string TblData;

	private string TblDetl;

	private string TblIdtl;

	private double CustOpAmt;

	private double CustOpGold;

	private double CustOpSilver;

	private double CustClAmt;

	private double CustClGold;

	private double CustClSilver;

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

	private const int cIsuNo = 1;

	private const int cCustRepNo = 2;

	private const int cTagNo = 3;

	private const int cItCode = 4;

	private const int cItName = 5;

	private const int cItmSize = 6;

	private const int cRemark = 7;

	private const int cPcs = 8;

	private const int cGrWt = 9;

	private const int cOthWt = 10;

	private const int cNetWt = 11;

	private const int cLessWt = 12;

	private const int cLessTch = 13;

	private const int cLessFine = 14;

	private const int cAddWt = 15;

	private const int cTouch = 16;

	private const int cWestPrc = 17;

	private const int cFine = 18;

	private const int cRate = 19;

	private const int cItAmt = 20;

	private const int cLbrType = 21;

	private const int cLbrRate = 22;

	private const int cLbrAmt = 23;

	private const int cOthAmt = 24;

	private const int cNetAmt = 25;

	private const int cRepNo = 26;

	private const int cRepLc = 27;

	private const int cRepYrCd = 28;

	private const int cRepDbCd = 29;

	private const int cRepSrNo = 30;

	private const int cRepAcCode = 31;

	private const int cRepAcName = 32;

	private const int cRepHdVchNo = 33;

	private const int cRepAdj = 34;

	private const int cIsuLc = 35;

	private const int cIsuYrCd = 36;

	private const int cIsuDbCd = 37;

	private const int cIsuSrNo = 38;

	private const int cIsuAcCode = 39;

	private const int cIsuAcName = 40;

	private const int cIsuHdVchNo = 41;

	private const int cIsuAdj = 42;

	private const int cItType = 43;

	private const int cRateType = 44;

	private const int cOldGwt = 45;

	private const int cOldAddWt = 46;

	private const int cOldTouch = 47;

	private const int cOldWest = 48;

	private const int cOldRate = 49;

	private const int cVchSrno = 50;

	private const int cOldLessTch = 51;

	private const int cOldLessWt = 52;

	private const int cNetAmt2 = 0;

	private const int cLbrDisc2 = 1;

	private const int cTax2 = 2;

	private const int cRof2 = 3;

	private const int cTot2 = 4;

	private const int cChq2 = 5;

	private const int cCard2 = 6;

	private const int cCash2 = 7;

	private const int cKasar2 = 8;

	private const int cOs2 = 9;

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

	public TR_REP_REC()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_REP_REC_Load;
		((Form)this).Deactivate += TR_REP_REC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_REP_REC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_REP_REC_KeyDown);
		((Form)this).Activated += TR_REP_REC_Activated;
		((Form)this).Closed += TR_REP_REC_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_REP_REC_KeyUp);
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
		//IL_0386: Unknown result type (might be due to invalid IL or missing references)
		//IL_0390: Expected O, but got Unknown
		//IL_0442: Unknown result type (might be due to invalid IL or missing references)
		//IL_044c: Expected O, but got Unknown
		//IL_04cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d9: Expected O, but got Unknown
		//IL_0576: Unknown result type (might be due to invalid IL or missing references)
		//IL_0580: Expected O, but got Unknown
		//IL_062e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0638: Expected O, but got Unknown
		//IL_06bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c9: Expected O, but got Unknown
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected O, but got Unknown
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		//IL_086a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0874: Expected O, but got Unknown
		//IL_091d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0927: Expected O, but got Unknown
		//IL_098a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0994: Expected O, but got Unknown
		//IL_0a3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a47: Expected O, but got Unknown
		//IL_0b64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6e: Expected O, but got Unknown
		//IL_0c79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c83: Expected O, but got Unknown
		//IL_0ce6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf0: Expected O, but got Unknown
		//IL_0e82: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f37: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f41: Expected O, but got Unknown
		//IL_1039: Unknown result type (might be due to invalid IL or missing references)
		//IL_1043: Expected O, but got Unknown
		//IL_129c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a6: Expected O, but got Unknown
		//IL_137e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1388: Expected O, but got Unknown
		//IL_1424: Unknown result type (might be due to invalid IL or missing references)
		//IL_142e: Expected O, but got Unknown
		//IL_1569: Unknown result type (might be due to invalid IL or missing references)
		//IL_1573: Expected O, but got Unknown
		//IL_15be: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c8: Expected O, but got Unknown
		//IL_1645: Unknown result type (might be due to invalid IL or missing references)
		//IL_164f: Expected O, but got Unknown
		//IL_16d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_16da: Expected O, but got Unknown
		//IL_17a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ae: Expected O, but got Unknown
		//IL_1855: Unknown result type (might be due to invalid IL or missing references)
		//IL_185f: Expected O, but got Unknown
		//IL_18dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e7: Expected O, but got Unknown
		//IL_196f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1979: Expected O, but got Unknown
		//IL_1a2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a34: Expected O, but got Unknown
		//IL_1ae5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aef: Expected O, but got Unknown
		//IL_1ba7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bb1: Expected O, but got Unknown
		//IL_1c15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c1f: Expected O, but got Unknown
		//IL_1c7d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c87: Expected O, but got Unknown
		//IL_1d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d30: Expected O, but got Unknown
		//IL_1dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dcc: Expected O, but got Unknown
		//IL_1e4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e58: Expected O, but got Unknown
		//IL_1ef5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eff: Expected O, but got Unknown
		//IL_1fad: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fb7: Expected O, but got Unknown
		//IL_21a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ad: Expected O, but got Unknown
		//IL_225a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2264: Expected O, but got Unknown
		//IL_22f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_22fd: Expected O, but got Unknown
		//IL_23ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_23b5: Expected O, but got Unknown
		//IL_2444: Unknown result type (might be due to invalid IL or missing references)
		//IL_244e: Expected O, but got Unknown
		//IL_24fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2506: Expected O, but got Unknown
		//IL_25b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_25be: Expected O, but got Unknown
		//IL_264d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2657: Expected O, but got Unknown
		//IL_26e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_26f0: Expected O, but got Unknown
		//IL_277e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2788: Expected O, but got Unknown
		//IL_284b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2855: Expected O, but got Unknown
		//IL_28a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28ad: Expected O, but got Unknown
		//IL_2961: Unknown result type (might be due to invalid IL or missing references)
		//IL_296b: Expected O, but got Unknown
		//IL_2a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a29: Expected O, but got Unknown
		//IL_2add: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ae7: Expected O, but got Unknown
		//IL_2b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ba5: Expected O, but got Unknown
		//IL_2c59: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c63: Expected O, but got Unknown
		//IL_2d1b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d25: Expected O, but got Unknown
		//IL_2dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_2de3: Expected O, but got Unknown
		//IL_2e97: Unknown result type (might be due to invalid IL or missing references)
		//IL_2ea1: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_REP_REC));
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
		MSG2_TOTAL = new AxMSFlexGrid();
		MSG = new AxMSFlexGrid();
		TEXT_ENTRY_2 = new TextBox();
		TEXT_ENTRY = new TextBox();
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
		MSG_TOT = new AxMSFlexGrid();
		LOpSilver = new Label();
		LOpGold = new Label();
		LOpAmt = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		BtnImgD = new SimpleButton();
		BtnImgS = new SimpleButton();
		BtnImgC = new SimpleButton();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
		((Control)PanelAdd).SuspendLayout();
		((ISupportInitialize)MSG_TOT).BeginInit();
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
		lblBook.Text = "Reparing Received";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)mVchDate).BackColor = Color.White;
		((Control)mVchDate).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mVchDate).Location = new Point(312, 42);
		mVchDate.Mask = "00/00/0000";
		((Control)mVchDate).Name = "mVchDate";
		((Control)mVchDate).Size = new Size(76, 23);
		((Control)mVchDate).TabIndex = 1;
		mVchDate.ValidatingType = typeof(DateTime);
		((Control)lblBDate).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblBDate).ForeColor = Color.Black;
		lblBDate.ImeMode = (ImeMode)0;
		((Control)lblBDate).Location = new Point(229, 43);
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
		((Control)tVchNo).Location = new Point(96, 42);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
		((Control)tVchNo).TabIndex = 0;
		((TextBoxBase)mDay).BackColor = Color.White;
		((Control)mDay).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mDay).Location = new Point(483, 42);
		((TextBoxBase)mDay).MaxLength = 8;
		((Control)mDay).Name = "mDay";
		((TextBoxBase)mDay).ReadOnly = true;
		((Control)mDay).Size = new Size(83, 23);
		((Control)mDay).TabIndex = 1133;
		mDay.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)mTime).BackColor = Color.White;
		((Control)mTime).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mTime).Location = new Point(394, 42);
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
		((Control)PnlBotam).TabIndex = 14;
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
		((Control)PicImage).Location = new Point(483, 354);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(162, 121);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
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
		((Control)BtnF1).Location = new Point(178, 42);
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
		((Control)tAcCode).Location = new Point(312, 74);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(394, 74);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(326, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(230, 73);
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
		((Control)tEmpCode).Location = new Point(105, 354);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 11;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(168, 354);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(216, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(28, 354);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(21, 412);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(105, 412);
		((TextBoxBase)tVchDesc).MaxLength = 250;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(356, 76);
		((Control)tVchDesc).TabIndex = 13;
		((Control)MSG2_TOTAL).Location = new Point(728, 354);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 203);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG).Location = new Point(13, 106);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1156, 215);
		((Control)MSG).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(956, 454);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(806, 189);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 10;
		((Control)TEXT_ENTRY).Visible = false;
		((TextBoxBase)tBankName).BackColor = Color.White;
		((Control)tBankName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBankName).Location = new Point(105, 383);
		((TextBoxBase)tBankName).MaxLength = 50;
		((Control)tBankName).Name = "tBankName";
		((Control)tBankName).Size = new Size(216, 23);
		((Control)tBankName).TabIndex = 12;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(25, 382);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(76, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Bank Name";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 74);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(96, 74);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
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
		((Control)PanelAdd).Location = new Point(312, 107);
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
		((Control)MSG_TOT).Location = new Point(15, 324);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1153, 15);
		((Control)MSG_TOT).TabIndex = 1179;
		((Control)LOpSilver).BackColor = Color.Transparent;
		((Control)LOpSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpSilver).ForeColor = Color.Black;
		LOpSilver.ImeMode = (ImeMode)0;
		((Control)LOpSilver).Location = new Point(806, 79);
		((Control)LOpSilver).Name = "LOpSilver";
		((Control)LOpSilver).Size = new Size(148, 20);
		((Control)LOpSilver).TabIndex = 1210;
		LOpSilver.Text = "OpSilver";
		LOpSilver.TextAlign = (ContentAlignment)64;
		((Control)LOpGold).BackColor = Color.Transparent;
		((Control)LOpGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpGold).ForeColor = Color.Black;
		LOpGold.ImeMode = (ImeMode)0;
		((Control)LOpGold).Location = new Point(806, 57);
		((Control)LOpGold).Name = "LOpGold";
		((Control)LOpGold).Size = new Size(148, 20);
		((Control)LOpGold).TabIndex = 1209;
		LOpGold.Text = "OpGold";
		LOpGold.TextAlign = (ContentAlignment)64;
		((Control)LOpAmt).BackColor = Color.Transparent;
		((Control)LOpAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LOpAmt).ForeColor = Color.Black;
		LOpAmt.ImeMode = (ImeMode)0;
		((Control)LOpAmt).Location = new Point(806, 37);
		((Control)LOpAmt).Name = "LOpAmt";
		((Control)LOpAmt).Size = new Size(148, 20);
		((Control)LOpAmt).TabIndex = 1208;
		LOpAmt.Text = "OpAmt";
		LOpAmt.TextAlign = (ContentAlignment)64;
		((Control)LClSilver).BackColor = Color.Transparent;
		((Control)LClSilver).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClSilver).ForeColor = Color.Black;
		LClSilver.ImeMode = (ImeMode)0;
		((Control)LClSilver).Location = new Point(1021, 79);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(148, 20);
		((Control)LClSilver).TabIndex = 1213;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(1021, 57);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(148, 20);
		((Control)lClGold).TabIndex = 1212;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(1021, 37);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		BtnImgD.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgD.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgD.ImageOptions.SvgImage");
		((Control)BtnImgD).Location = new Point(657, 441);
		((BaseControl)BtnImgD).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgD).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgD).Name = "BtnImgD";
		((Control)BtnImgD).Size = new Size(40, 34);
		((Control)BtnImgD).TabIndex = 1216;
		((BaseControl)BtnImgD).ToolTip = "Image Delete";
		BtnImgS.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgS.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgS.ImageOptions.SvgImage");
		((Control)BtnImgS).Location = new Point(657, 354);
		((BaseControl)BtnImgS).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgS).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgS).Name = "BtnImgS";
		((Control)BtnImgS).Size = new Size(40, 34);
		((Control)BtnImgS).TabIndex = 1215;
		((BaseControl)BtnImgS).ToolTip = "Image Select";
		BtnImgC.ImageOptions.ImageToTextAlignment = (ImageAlignToText)8;
		((ImageCollectionImageOptions)BtnImgC.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnImgC.ImageOptions.SvgImage");
		((Control)BtnImgC).Location = new Point(657, 398);
		((BaseControl)BtnImgC).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnImgC).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnImgC).Name = "BtnImgC";
		((Control)BtnImgC).Size = new Size(40, 34);
		((Control)BtnImgC).TabIndex = 1214;
		((BaseControl)BtnImgC).ToolTip = "Image Capture";
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)BtnImgD);
		((Control)this).Controls.Add((Control)(object)BtnImgS);
		((Control)this).Controls.Add((Control)(object)BtnImgC);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)PanelAdd);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tBankName);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY);
		((Control)this).Controls.Add((Control)(object)TEXT_ENTRY_2);
		((Control)this).Controls.Add((Control)(object)MSG);
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
		((Control)this).Name = "TR_REP_REC";
		((Form)this).Text = "Reparing Received";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((Control)PanelAdd).ResumeLayout(false);
		((Control)PanelAdd).PerformLayout();
		((ISupportInitialize)MSG_TOT).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		mSG.Clear();
		mSG.Cols = 53;
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
			mSG[3] = (int)Math.Round(1300.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "TagNo";
			mSG[4] = (int)Math.Round(1000.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "ItCode";
			mSG[5] = (int)Math.Round(2000.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "ItName";
			mSG[6] = (int)Math.Round(900.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "Size";
			mSG[7] = (int)Math.Round(2700.0 * ColCon);
			mSG[7] = 0;
			mSG[0, 7] = "Reparing Desc";
			mSG[8] = (int)Math.Round(700.0 * ColCon);
			mSG[8] = 7;
			mSG[0, 8] = "Pcs";
			mSG[9] = (int)Math.Round(1100.0 * ColCon);
			mSG[9] = 7;
			mSG[0, 9] = "GrWt";
			mSG[10] = (int)Math.Round(1000.0 * ColCon);
			mSG[10] = 7;
			mSG[0, 10] = "OthWt";
			mSG[11] = (int)Math.Round(1100.0 * ColCon);
			mSG[11] = 7;
			mSG[0, 11] = "NetWt";
			mSG[2] = 0;
			mSG[1] = 0;
			mSG[12] = 0;
			mSG[15] = 0;
			mSG[16] = 0;
			mSG[17] = 0;
			mSG[18] = 0;
			mSG[14] = 0;
			mSG[19] = 0;
			mSG[20] = 0;
			if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
			{
				mSG[16] = (int)Math.Round(750.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "Touch";
				mSG[21] = (int)Math.Round(800.0 * ColCon);
				mSG[21] = 3;
				mSG[0, 21] = "Ltype";
				mSG[22] = (int)Math.Round(1000.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "LRate";
				mSG[23] = (int)Math.Round(1100.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "LAmt";
				mSG[24] = (int)Math.Round(1000.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "OthAmt";
				mSG[3] = 0;
				mSG[13] = 0;
			}
			else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
			{
				mSG[2] = (int)Math.Round(1100.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "RepNo";
				mSG[10] = 0;
				mSG[16] = (int)Math.Round(750.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "Touch";
				mSG[21] = (int)Math.Round(800.0 * ColCon);
				mSG[21] = 3;
				mSG[0, 21] = "Ltype";
				mSG[22] = (int)Math.Round(1000.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "LRate";
				mSG[23] = (int)Math.Round(1100.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "LAmt";
				mSG[24] = (int)Math.Round(1000.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "OthAmt";
				mSG[13] = 0;
			}
			else if (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0)
			{
				mSG[5] = (int)Math.Round(2500.0 * ColCon);
				mSG[5] = 0;
				mSG[0, 5] = "ItName";
				mSG[6] = (int)Math.Round(800.0 * ColCon);
				mSG[6] = 0;
				mSG[0, 6] = "Size";
				mSG[1] = (int)Math.Round(1000.0 * ColCon);
				mSG[1] = 0;
				mSG[0, 1] = "IsuNo";
				mSG[12] = (int)Math.Round(800.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "LsWt";
				mSG[15] = (int)Math.Round(800.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "AddWt";
				mSG[10] = 0;
				mSG[16] = (int)Math.Round(750.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "Touch";
				mSG[17] = (int)Math.Round(0.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "West%";
				mSG[18] = (int)Math.Round(1000.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "Fine";
				mSG[13] = (int)Math.Round(750.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "LsTch";
				mSG[14] = (int)Math.Round(900.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "LsFine";
				mSG[19] = (int)Math.Round(900.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "Rate";
				mSG[20] = (int)Math.Round(1000.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "ItAmt";
				mSG[21] = (int)Math.Round(0.0 * ColCon);
				mSG[21] = 3;
				mSG[0, 21] = "Ltype";
				mSG[22] = (int)Math.Round(0.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "LRate";
				mSG[23] = (int)Math.Round(900.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "LAmt";
				mSG[24] = (int)Math.Round(900.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "OthAmt";
			}
			else if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
			{
				mSG[2] = (int)Math.Round(1100.0 * ColCon);
				mSG[2] = 0;
				mSG[0, 2] = "RepNo";
				mSG[12] = (int)Math.Round(1000.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "LessWt";
				mSG[15] = (int)Math.Round(1000.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "AddWt";
				mSG[16] = (int)Math.Round(750.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "Touch";
				mSG[18] = (int)Math.Round(1000.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "Fine";
				mSG[13] = (int)Math.Round(750.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "LesTch";
				mSG[14] = (int)Math.Round(900.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "LsFine";
				mSG[19] = (int)Math.Round(1000.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "Rate";
				mSG[20] = (int)Math.Round(1000.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "ItAmt";
				mSG[21] = (int)Math.Round(0.0 * ColCon);
				mSG[21] = 3;
				mSG[0, 21] = "Ltype";
				mSG[22] = (int)Math.Round(0.0 * ColCon);
				mSG[22] = 7;
				mSG[0, 22] = "LRate";
				mSG[23] = (int)Math.Round(1000.0 * ColCon);
				mSG[23] = 7;
				mSG[0, 23] = "LAmt";
				mSG[24] = (int)Math.Round(1100.0 * ColCon);
				mSG[24] = 7;
				mSG[0, 24] = "OthAmt";
				mSG[3] = 0;
			}
			mSG[25] = (int)Math.Round(1200.0 * ColCon);
			mSG[25] = 7;
			mSG[0, 25] = "NetAmt";
			mSG[26] = 0;
			mSG[27] = 0;
			mSG[28] = 0;
			mSG[29] = 0;
			mSG[30] = 0;
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[34] = 0;
			mSG[33] = 0;
			mSG[35] = 0;
			mSG[36] = 0;
			mSG[37] = 0;
			mSG[38] = 0;
			mSG[41] = 0;
			mSG[39] = 0;
			mSG[40] = 0;
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
					dataView.RowFilter = " BOOK_NAME = 'REP_REC' AND COL_NAME = '" + mSG[0, DC_Main.M] + "'";
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
		mSG[mSG.Row, 34] = "N";
		mSG[mSG.Row, 42] = "N";
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
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Invalid comparison between Unknown and I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Invalid comparison between Unknown and I4
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Invalid comparison between Unknown and I4
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0111: Invalid comparison between Unknown and I4
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Invalid comparison between Unknown and I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Invalid comparison between Unknown and I4
		//IL_03c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fde: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_20be: Unknown result type (might be due to invalid IL or missing references)
		//IL_225d: Unknown result type (might be due to invalid IL or missing references)
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
				if (mSG.Col < 25)
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
					case 1:
						DC_Main.RsQry = "SELECT * FROM REP_DETL AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 36] + "' AND CO_BOOK = '" + mSG[mSG.Row, 37] + "' AND VCH_NO = '" + TEXT_ENTRY.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 38])) + "  ";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (RsDetl.Rows.Count == 0)
						{
							DC_Main.RsQry = "SELECT B.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS RepDtL,A.IT_NAME AS ItNameL,A.ITM_GWT As ItmGwtW,A.SR_NO As SrNoM,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL,A.REP_AC_NAME AS CustNameL FROM REP_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_ADJ = 'N' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.BOOK_NAME = 'KRREP ISSUE' ORDER BY A.VCH_DATE,A.VCH_NO ";
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[12];
							DC_Main.ColWidth[0] = 250.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 95.0;
							DC_Main.ColWidth[3] = 120.0;
							DC_Main.ColWidth[4] = 200.0;
							DC_Main.ColWidth[5] = 100.0;
							DC_Main.ColWidth[6] = 70.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[10] = 200.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[2], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[2];
									mSG[mSG.Row, 40] = DC_Main.ColValue[0];
									mSG[mSG.Row, 38] = DC_Main.ColValue[6];
									mSG[mSG.Row, 36] = DC_Main.ColValue[7];
									mSG[mSG.Row, 37] = DC_Main.ColValue[8];
									mSG[mSG.Row, 39] = DC_Main.ColValue[1];
									mSG[mSG.Row, 41] = DC_Main.ColValue[9];
									mSG[mSG.Row, 35] = DC_Main.MLc_code;
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 1] = TEXT_ENTRY.Text;
						mSG[mSG.Row, 35] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["LC_CODE"], (object)""));
						mSG[mSG.Row, 36] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["CO_YEAR"], (object)""));
						mSG[mSG.Row, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["CO_BOOK"], (object)""));
						mSG[mSG.Row, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["SR_NO"])), "0");
						mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HD_VCH_NO"], (object)""));
						mSG[mSG.Row, 39] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["AC_CODE"], (object)""));
						mSG[mSG.Row, 2] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_NO"], (object)""));
						mSG[mSG.Row, 26] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_NO"], (object)""));
						mSG[mSG.Row, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_LC"], (object)""));
						mSG[mSG.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_YRCD"], (object)""));
						mSG[mSG.Row, 29] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_DBCD"], (object)""));
						mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["REP_SRNO"])), "0");
						mSG[mSG.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_HD_VCH_NO"], (object)""));
						mSG[mSG.Row, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_AC_CODE"], (object)""));
						mSG[mSG.Row, 32] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["REP_AC_NAME"], (object)""));
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["TAG_NO"], (object)""));
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_CODE"], (object)""));
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["ITM_SIZE"], (object)""));
						mSG[mSG.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_DESC"], (object)""));
						mSG[mSG.Row, 8] = Conversions.ToString(RsDetl.Rows[0]["ITM_PCS"]);
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_OTH_WT"])), "0.000");
						mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_NWT"])), "0.000");
						mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ADD_WT"])), "0.000");
						mSG[mSG.Row, 46] = Conversions.ToString(0);
						mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["LESS_WT"])), "0.000");
						mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST"])), "0.00");
						mSG[mSG.Row, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST"])), "0.00");
						mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["LESS_FINE"])), "0.000");
						mSG[mSG.Row, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["VCH_SRNO"])), "0");
						mSG[mSG.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["RATE_TYPE"], (object)""));
						mSG[mSG.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_TYPE"], (object)""));
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						break;
					case 2:
						DC_Main.RsQry = "SELECT * FROM REP_DETL AS A WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + mSG[mSG.Row, 28] + "' AND CO_BOOK = '" + mSG[mSG.Row, 29] + "' AND VCH_NO = '" + TEXT_ENTRY.Text + "' AND SR_NO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 30])) + "  ";
						RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (RsDetl.Rows.Count == 0)
						{
							if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
							{
								DC_Main.RsQry = "SELECT B.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS RepDtL,A.IT_NAME AS ItNameL,A.ITM_GWT As ItmGwtW,A.SR_NO As SrNoM,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL,'' As KarigarNameL FROM (REP_DETL AS A LEFT JOIN REP_DATA AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO) LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_ADJ = 'N' AND A.ISU_ADJ = 'N' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.BOOK_NAME = 'CUSTREP RECEIPT'   UNION ALL Select D.REP_AC_NAME As PartyNameL,D.REP_AC_CODE As AcCodeL,D.REP_NO As VchNoT,replace(convert(NVARCHAR,D.VCH_DATE, 103), ' ', '/') AS RepDtL,D.IT_NAME AS ItNameL,D.ITM_GWT As ItmGwtW,D.REP_SRNO As SrNoM,D.REP_YRCD AS YearL,D.REP_DBCD as BookL,D.REP_HD_VCH_NO As HdVchNoL,D.ISU_AC_NAME As KarigarNameL FROM REP_DETL AS D  WHERE D.CO_CODE = '" + DC_Main.MCo_code + "' AND D.LC_CODE = '" + DC_Main.MLc_code + "' AND D.ISU_ADJ = 'N' AND D.REP_AC_CODE = '" + tAcCode.Text + "' AND D.BOOK_NAME = 'KRREP RECEIPT' ";
							}
							else
							{
								DC_Main.RsQry = "SELECT B.AC_NAME AS PartyNameL,A.AC_CODE AS AcCodeL,A.VCH_NO AS VchNoT,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS RepDtL,A.IT_NAME AS ItNameL,A.ITM_GWT As ItmGwtW,A.SR_NO As SrNoM,A.CO_YEAR AS YearL,A.CO_BOOK as BookL,A.HD_VCH_NO As HdVchNoL FROM REP_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE   WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_ADJ = 'N'  AND A.BOOK_NAME = 'CUSTREP RECEIPT' ORDER BY A.VCH_DATE,A.VCH_NO ";
							}
							DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							DC_Main.ColWidth = new double[12];
							DC_Main.ColWidth[0] = 250.0;
							DC_Main.ColWidth[1] = 100.0;
							DC_Main.ColWidth[2] = 95.0;
							DC_Main.ColWidth[3] = 130.0;
							DC_Main.ColWidth[4] = 250.0;
							DC_Main.ColWidth[5] = 110.0;
							DC_Main.ColWidth[6] = 80.0;
							DC_Main.ColWidth[7] = 0.0;
							DC_Main.ColWidth[8] = 0.0;
							DC_Main.ColWidth[9] = 0.0;
							DC_Main.ColWidth[0] = 250.0;
							DC_Main.HelpSelect = 1;
							((Form)MyProject.Forms.MS_HELP).ShowDialog();
							if (!DC_Main.HelpClose)
							{
								if (Operators.CompareString(DC_Main.ColValue[2], "", false) != 0)
								{
									TEXT_ENTRY.Text = DC_Main.ColValue[2];
									mSG[mSG.Row, 26] = DC_Main.ColValue[0];
									mSG[mSG.Row, 32] = DC_Main.ColValue[0];
									mSG[mSG.Row, 30] = DC_Main.ColValue[6];
									mSG[mSG.Row, 28] = DC_Main.ColValue[7];
									mSG[mSG.Row, 29] = DC_Main.ColValue[8];
									mSG[mSG.Row, 31] = DC_Main.ColValue[1];
									mSG[mSG.Row, 33] = DC_Main.ColValue[9];
									mSG[mSG.Row, 27] = DC_Main.MLc_code;
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 2] = TEXT_ENTRY.Text;
						mSG[mSG.Row, 26] = TEXT_ENTRY.Text;
						mSG[mSG.Row, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["LC_CODE"], (object)""));
						mSG[mSG.Row, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["CO_YEAR"], (object)""));
						mSG[mSG.Row, 29] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["CO_BOOK"], (object)""));
						mSG[mSG.Row, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["SR_NO"])), "0");
						mSG[mSG.Row, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["HD_VCH_NO"], (object)""));
						mSG[mSG.Row, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["AC_CODE"], (object)""));
						mSG[mSG.Row, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["TAG_NO"], (object)""));
						mSG[mSG.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_CODE"], (object)""));
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["ITM_SIZE"], (object)""));
						mSG[mSG.Row, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_DESC"], (object)""));
						mSG[mSG.Row, 8] = Conversions.ToString(RsDetl.Rows[0]["ITM_PCS"]);
						mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_GWT"])), "0.000");
						mSG[mSG.Row, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_OTH_WT"])), "0.000");
						mSG[mSG.Row, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_NWT"])), "0.000");
						if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
						{
							mSG[mSG.Row, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_RATE"])), "0.00");
							mSG[mSG.Row, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["LBR_AMT"])), "0.00");
							mSG[mSG.Row, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["OTH_AMT"])), "0.00");
						}
						DC_Main.RsQry = "SELECT A.*,B.AC_NAME FROM REP_DETL AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.ISU_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND BOOK_NAME = 'KRREP RECEIPT' AND REP_YRCD = '" + mSG[mSG.Row, 28] + "' AND REP_DBCD = '" + mSG[mSG.Row, 29] + "' AND REP_NO = '" + TEXT_ENTRY.Text + "' AND REP_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 30])) + "  ";
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Tbl.Rows.Count > 0)
						{
							mSG[mSG.Row, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["VCH_NO"], (object)""));
							mSG[mSG.Row, 35] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LC_CODE"], (object)""));
							mSG[mSG.Row, 36] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_YEAR"], (object)""));
							mSG[mSG.Row, 37] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["CO_BOOK"], (object)""));
							mSG[mSG.Row, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["SR_NO"])), "0");
							mSG[mSG.Row, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["HD_VCH_NO"], (object)""));
							mSG[mSG.Row, 39] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_CODE"], (object)""));
							mSG[mSG.Row, 40] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
							mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["ADD_WT"])), "0.000");
							mSG[mSG.Row, 46] = Conversions.ToString(0);
							mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LESS_WT"])), "0.000");
							if (Conversion.Val(mSG[mSG.Row, 23]) == 0.0)
							{
								mSG[mSG.Row, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LBR_AMT"])), "0.00");
							}
							if (Conversion.Val(mSG[mSG.Row, 24]) == 0.0)
							{
								mSG[mSG.Row, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["OTH_AMT"])), "0.00");
							}
							mSG[mSG.Row, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LESS_TOUCH"])), "0.00");
							mSG[mSG.Row, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LESS_TOUCH"])), "0.00");
							mSG[mSG.Row, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[0]["LESS_FINE"])), "0.000");
						}
						else
						{
							mSG[mSG.Row, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ADD_WT"])), "0.000");
							mSG[mSG.Row, 46] = Conversions.ToString(0);
							mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["LESS_WT"])), "0.000");
						}
						mSG[mSG.Row, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_TOUCH"])), "0.00");
						mSG[mSG.Row, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST"])), "0.00");
						mSG[mSG.Row, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_WEST"])), "0.00");
						mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["ITM_FINE"])), "0.000");
						mSG[mSG.Row, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[0]["VCH_SRNO"])), "0");
						mSG[mSG.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["RATE_TYPE"], (object)""));
						mSG[mSG.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[0]["IT_TYPE"], (object)""));
						MsgOldRow = 0;
						MSG_RowColChange(MSG, new EventArgs());
						break;
					case 3:
					{
						if (!((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) | (Operators.CompareString(TEXT_ENTRY.Text, mSG[mSG.Row, 3], false) != 0)))
						{
							break;
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.TAG_NO,A.VCH_SRNO,B.VCH_DATE FROM MAIN_STOCK AS A LEFT JOIN BAR_DETL AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.TAG_NO = B.TAG_NO AND A.VCH_SRNO = B.VCH_SRNO WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '" + TEXT_ENTRY.Text + "'"), Interaction.IIf(Conversion.Val(mSG[mSG.Row, 50]) == 0.0, (object)"", (object)(("AND A.VCH_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 50]))) ?? ""))), (object)" AND B.EMP_ISU <> 'Y' GROUP BY A.TAG_NO,A.VCH_SRNO,B.VCH_DATE HAVING SUM(CASE WHEN A.ITM_SIGN ='+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY B.VCH_DATE DESC"));
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
									mSG[mSG.Row, 5] = DC_Main.ColValue[1];
									mSG[mSG.Row, 4] = DC_Main.ColValue[2];
									mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
									mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
									mSG[mSG.Row, 50] = DC_Main.ColValue[7];
									((Control)TEXT_ENTRY).Focus();
								}
								else
								{
									mSG[mSG.Row, 50] = "";
									mSG[mSG.Row, 3] = "";
									((Control)TEXT_ENTRY).Focus();
								}
							}
							return;
						}
						int num2 = mSG.Rows - 1;
						DC_Main.X = 1;
						while (DC_Main.X <= num2)
						{
							if ((Operators.CompareString(mSG[DC_Main.X, 3], TEXT_ENTRY.Text, false) == 0) & (mSG.Row != DC_Main.X))
							{
								Interaction.MsgBox((object)"Duplicate Tag No", (MsgBoxStyle)0, (object)null);
								return;
							}
							DC_Main.X++;
						}
						mSG[mSG.Row, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
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
								mSG[mSG.Row, 5] = DC_Main.ColValue[1];
								mSG[mSG.Row, 4] = DC_Main.ColValue[0];
								mSG[mSG.Row, 9] = Strings.Format((object)DC_Main.ColValue[4], "0.000");
								mSG[mSG.Row, 11] = Strings.Format((object)DC_Main.ColValue[5], "0.000");
								mSG[mSG.Row, 50] = DC_Main.ColValue[7];
								((Control)TEXT_ENTRY).Focus();
							}
						}
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.*,B.IT_NAME FROM BAR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND  A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.TAG_NO = '"), DC_Main.Rshlp.Rows[0]["TAG_NO"]), (object)""), (object)"' AND A.VCH_SRNO = '"), (object)mSG[mSG.Row, 50]), (object)"' "));
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						DC_Main.i = mSG.Row;
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							mSG[DC_Main.i, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAG_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BAG_WT"])), "0.000");
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 46] = Conversions.ToString(0);
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GHT_WT"])), "0.000");
							mSG[DC_Main.i, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["RATE_TYPE"], (object)""));
							mSG[DC_Main.i, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_TYPE"], (object)""));
							mSG[DC_Main.i, 50] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_SRNO"], (object)""));
						}
						break;
					}
					case 4:
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
									mSG[mSG.Row, 5] = DC_Main.ColValue[0];
									mSG[mSG.Row, 43] = DC_Main.ColValue[4];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						mSG[mSG.Row, 43] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_TYPE"], (object)""));
						mSG[mSG.Row, 44] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["RATE_TYPE"], (object)""));
						break;
					case 9:
						if ((Conversion.Val(TEXT_ENTRY.Text) == 0.0) & (Operators.CompareString(mSG[mSG.Row, 44], "P", false) != 0))
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 25:
						if (mSG.Row == mSG.Rows - 1)
						{
							mSG[mSG.Row, 25] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
							CommPassTotal(mSG.Row);
							MsgClearIdtl = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClearIdtl = false;
							mSG.Col = 1;
							CommPassAdd();
							((Control)TEXT_ENTRY).Visible = true;
							((Control)TEXT_ENTRY).Focus();
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
				case 4:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 3:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 5:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 6:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 7:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 150;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 1:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 2:
				case 26:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 21:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
					TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
					break;
				case 8:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
					break;
				case 13:
				case 16:
				case 17:
				case 19:
				case 20:
				case 22:
				case 23:
				case 24:
				case 25:
					((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
					TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
					break;
				case 9:
				case 10:
				case 11:
				case 12:
				case 14:
				case 15:
				case 18:
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
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 21:
			case 26:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 8:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				CommPassTotal(mSG.Row);
				break;
			case 13:
			case 16:
			case 17:
			case 19:
			case 20:
			case 22:
			case 23:
			case 24:
			case 25:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal(mSG.Row);
				break;
			case 9:
			case 10:
			case 11:
			case 12:
			case 14:
			case 15:
			case 18:
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
		if (Conversion.Val(mSG[mSG.Row, 9]) != Conversion.Val(mSG[mSG.Row, 45]))
		{
			mSG[mSG.Row, 45] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 9]), "0.000");
			mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 9]) - Conversion.Val(mSG[mSG.Row, 10])), "0.000");
		}
		if ((Conversion.Val(mSG[mSG.Row, 10]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 9]) != 0.0))
		{
			mSG[mSG.Row, 11] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 9]) - Conversion.Val(mSG[mSG.Row, 10])), "0.000");
		}
		if (Conversion.Val(mSG[mSG.Row, 15]) != Conversion.Val(mSG[mSG.Row, 46]))
		{
			mSG[mSG.Row, 46] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 15]), "0.000");
			if ((Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 15]) != 0.0))
			{
				mSG[mSG.Row, 18] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17])) / 100.0), "0.000");
			}
			else
			{
				mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 15]), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 16]) != Conversion.Val(mSG[mSG.Row, 47]))
		{
			mSG[mSG.Row, 47] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 16]), "0.00");
			if ((Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 15]) != 0.0))
			{
				mSG[mSG.Row, 18] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 17]) != Conversion.Val(mSG[mSG.Row, 48]))
		{
			mSG[mSG.Row, 48] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 17]), "0.00");
			if ((Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 15]) != 0.0))
			{
				mSG[mSG.Row, 18] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17])) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 16]) + Conversion.Val(mSG[mSG.Row, 17]) == 0.0)
		{
			mSG[mSG.Row, 18] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 15]), "0.000");
		}
		if (Conversion.Val(mSG[mSG.Row, 12]) != Conversion.Val(mSG[mSG.Row, 52]))
		{
			mSG[mSG.Row, 52] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 12]), "0.00");
			mSG[mSG.Row, 51] = "";
		}
		if (Conversion.Val(mSG[mSG.Row, 13]) != Conversion.Val(mSG[mSG.Row, 51]))
		{
			mSG[mSG.Row, 51] = Strings.Format((object)Conversion.Val(mSG[mSG.Row, 13]), "0.00");
			if ((Conversion.Val(mSG[mSG.Row, 13]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 12]) != 0.0))
			{
				mSG[mSG.Row, 14] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 12]) * Conversion.Val(mSG[mSG.Row, 13]) / 100.0), "0.000");
			}
		}
		if (Conversion.Val(mSG[mSG.Row, 13]) == 0.0)
		{
			mSG[mSG.Row, 14] = "";
		}
		if ((Conversion.Val(mSG[mSG.Row, 19]) != 0.0) & (Conversion.Val(mSG[mSG.Row, 18]) + Conversion.Val(mSG[mSG.Row, 8]) != 0.0))
		{
			if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
			{
				switch (mSG[mSG.Row, 44])
				{
				case "P":
					mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 8]) * Conversion.Val(mSG[mSG.Row, 19]), 0), "0.00");
					break;
				case "1":
					mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 19]) / 10.0), 0), "0.00");
					break;
				case "K":
					mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * (Conversion.Val(mSG[mSG.Row, 19]) / 1000.0), 0), "0.00");
					break;
				default:
					mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 15]) * Conversion.Val(mSG[mSG.Row, 19]), 0), "0.00");
					break;
				}
			}
			else
			{
				switch (mSG[mSG.Row, 44])
				{
				case "P":
					mSG[mSG.Row, 20] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 8]) * Conversion.Val(mSG[mSG.Row, 19]), 0), "0.00");
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
		}
		if (Conversion.Val(mSG[mSG.Row, 22]) != 0.0)
		{
			switch (mSG[mSG.Row, 21])
			{
			case "P":
				mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 8]) * Conversion.Val(mSG[mSG.Row, 22]), 0), "0.00");
				break;
			case "N":
				mSG[mSG.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 12])) * Conversion.Val(mSG[mSG.Row, 22]), 0), "0.00");
				break;
			case "K":
				mSG[mSG.Row, 23] = Strings.Format((object)Math.Round((Conversion.Val(mSG[mSG.Row, 11]) + Conversion.Val(mSG[mSG.Row, 12])) * (Conversion.Val(mSG[mSG.Row, 22]) / 1000.0), 0), "0.00");
				break;
			default:
				mSG[mSG.Row, 23] = Strings.Format((object)Math.Round(Conversion.Val(mSG[mSG.Row, 9]) * Conversion.Val(mSG[mSG.Row, 22]), 0), "0.00");
				break;
			}
		}
		mSG[mSG.Row, 25] = Strings.Format((object)(Conversion.Val(mSG[mSG.Row, 23]) + Conversion.Val(mSG[mSG.Row, 24]) + Conversion.Val(mSG[mSG.Row, 20])), "0.00");
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
			mSG_TOT[0, 28] = "Total :";
			int num2 = MSG.Rows - 1;
			DC_Main.M = 1;
			while (DC_Main.M <= num2)
			{
				mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0");
				mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
				mSG_TOT[0, 10] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 10]) + Conversion.Val(MSG[DC_Main.M, 10]))), "0.000");
				mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
				mSG_TOT[0, 15] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 15]) + Conversion.Val(MSG[DC_Main.M, 15]))), "0.000");
				mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
				mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.000");
				mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
				mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
				mSG_TOT[0, 23] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 23]) + Conversion.Val(MSG[DC_Main.M, 23]))), "0.00");
				mSG_TOT[0, 24] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 24]) + Conversion.Val(MSG[DC_Main.M, 24]))), "0.00");
				mSG_TOT[0, 25] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 25]) + Conversion.Val(MSG[DC_Main.M, 25]))), "0.00");
				if (Conversion.Val(MSG[DC_Main.M, 20]) == 0.0)
				{
					PurcAcFine += Conversion.Val(MSG[DC_Main.M, 18]);
				}
				DC_Main.M++;
			}
			mSG_TOT = null;
		}
	}

	private void TR_REP_REC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0be5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected O, but got Unknown
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c28: Expected O, but got Unknown
		//IL_0c67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c76: Expected O, but got Unknown
		//IL_0c90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9f: Expected O, but got Unknown
		//IL_0cb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc8: Expected O, but got Unknown
		//IL_0cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cf7: Expected O, but got Unknown
		//IL_0dd8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ddd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de7: Expected O, but got Unknown
		//IL_0e6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e74: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7e: Expected O, but got Unknown
		//IL_0f17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f22: Expected O, but got Unknown
		//IL_0fac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fbb: Expected O, but got Unknown
		//IL_0fe0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fef: Expected O, but got Unknown
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
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				object? obj15 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				object? obj16 = colorConverter.ConvertFromString("DarkGray");
				mSG2_TOTAL2.BackColorBkg = ((obj16 != null) ? ((Color)obj16) : default(Color));
				AxMSFlexGrid mSG2_TOTAL3 = MSG2_TOTAL;
				object? obj17 = colorConverter.ConvertFromString("255, 224, 192");
				mSG2_TOTAL3.BackColorFixed = ((obj17 != null) ? ((Color)obj17) : default(Color));
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
				AxMSFlexGrid mSG_TOT4 = MSG_TOT;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT4.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				AxMSFlexGrid mSG_TOT5 = MSG_TOT;
				object? obj21 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT5.BackColorBkg = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AxMSFlexGrid mSG_TOT6 = MSG_TOT;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				mSG_TOT6.BackColorFixed = ((obj22 != null) ? ((Color)obj22) : default(Color));
				AxMSFlexGrid mSG4 = MSG;
				object? obj23 = colorConverter.ConvertFromString("ControlLightLight");
				mSG4.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				AxMSFlexGrid mSG5 = MSG;
				object? obj24 = colorConverter.ConvertFromString("174, 184, 194");
				mSG5.BackColorBkg = ((obj24 != null) ? ((Color)obj24) : default(Color));
				AxMSFlexGrid mSG6 = MSG;
				object? obj25 = colorConverter.ConvertFromString("233, 235, 240");
				mSG6.BackColorFixed = ((obj25 != null) ? ((Color)obj25) : default(Color));
				AxMSFlexGrid mSG2_TOTAL4 = MSG2_TOTAL;
				object? obj26 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL4.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				AxMSFlexGrid mSG2_TOTAL5 = MSG2_TOTAL;
				object? obj27 = colorConverter.ConvertFromString("174, 184, 194");
				mSG2_TOTAL5.BackColorBkg = ((obj27 != null) ? ((Color)obj27) : default(Color));
				AxMSFlexGrid mSG2_TOTAL6 = MSG2_TOTAL;
				object? obj28 = colorConverter.ConvertFromString("233, 235, 240");
				mSG2_TOTAL6.BackColorFixed = ((obj28 != null) ? ((Color)obj28) : default(Color));
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
				AxMSFlexGrid mSG_TOT7 = MSG_TOT;
				object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT7.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				AxMSFlexGrid mSG_TOT8 = MSG_TOT;
				object? obj34 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT8.BackColorBkg = ((obj34 != null) ? ((Color)obj34) : default(Color));
				AxMSFlexGrid mSG_TOT9 = MSG_TOT;
				object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
				mSG_TOT9.BackColorFixed = ((obj35 != null) ? ((Color)obj35) : default(Color));
				AxMSFlexGrid mSG7 = MSG;
				object? obj36 = colorConverter.ConvertFromString("ControlLightLight");
				mSG7.BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				AxMSFlexGrid mSG8 = MSG;
				object? obj37 = colorConverter.ConvertFromString("238, 244, 236");
				mSG8.BackColorBkg = ((obj37 != null) ? ((Color)obj37) : default(Color));
				AxMSFlexGrid mSG9 = MSG;
				object? obj38 = colorConverter.ConvertFromString("Cornsilk");
				mSG9.BackColorFixed = ((obj38 != null) ? ((Color)obj38) : default(Color));
				AxMSFlexGrid mSG2_TOTAL7 = MSG2_TOTAL;
				object? obj39 = colorConverter.ConvertFromString("ControlLightLight");
				mSG2_TOTAL7.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				AxMSFlexGrid mSG2_TOTAL8 = MSG2_TOTAL;
				object? obj40 = colorConverter.ConvertFromString("238, 244, 236");
				mSG2_TOTAL8.BackColorBkg = ((obj40 != null) ? ((Color)obj40) : default(Color));
				AxMSFlexGrid mSG2_TOTAL9 = MSG2_TOTAL;
				object? obj41 = colorConverter.ConvertFromString("Cornsilk");
				mSG2_TOTAL9.BackColorFixed = ((obj41 != null) ? ((Color)obj41) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)BtnF1).Appearance;
				object? obj42 = colorConverter.ConvertFromString("238, 244, 236");
				appearance2.BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
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
			if ((Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0) | (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0))
			{
				((Control)BtnImgS).Visible = false;
				((Control)BtnImgC).Visible = false;
				((Control)BtnImgD).Visible = false;
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
		mVchDate.Text = Conversions.ToString(DC_Main.MsSysDate);
		mTime.Text = DateTime.Now.ToString("HH:mm:ss");
		mDay.Text = Strings.Format((object)Conversions.ToDate(mVchDate.Text), "dddd");
		MsVchSrno = "";
		OldAcCode = "";
		((TextBoxBase)tVchNo).ReadOnly = true;
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
		AcGstType = "L";
		UsUPdate = "N";
		UsDelete = "N";
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_ENTRY).Visible = false;
		MSG_CLEAR();
		MSG2_CLEAR();
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
				double num = DC_Main.Fnv(ref Value);
				dataRow["TAX_PRC"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[2, 2] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsTax.Rows[0]["TAX_CODE"], (object)""));
			}
		}
		DC_Main.RsQry = "Select MAX(VCH_NO) As VchNo  From REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		if (Operators.CompareString(DC_Main.MsEmpAsUser, "Y", false) == 0)
		{
			tEmpCode.Text = DC_Main.MsUserEmpCode;
			tEmpName.Text = DC_Main.MsUserEmpName;
		}
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
		DC_Main.RsQry = "SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				AcGstType = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["AC_GST_TYPE"], (object)""));
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				MSG2_TOTAL[1, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_PRC"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["DISC_AMT"]), "0.00");
				MSG2_TOTAL[2, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["TAX_CODE"], (object)""));
				MSG2_TOTAL[2, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_PRC"]), "0.00");
				MSG2_TOTAL[2, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TAX_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["ROF_AMT"]), "0.00");
				MSG2_TOTAL[4, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["TOT_AMT"]), "0.00");
				MSG2_TOTAL[5, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[6, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CARD_AMT"]), "0.00");
				MSG2_TOTAL[7, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["KASAR_AMT"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["KASAR_AMT"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[8, 3] = Strings.Format((object)num, "0.00");
				AxMSFlexGrid mSG2_TOTAL2 = MSG2_TOTAL;
				Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num2 = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL2[9, 3] = Strings.Format((object)num2, "0.00");
				MSG2_TOTAL[5, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[5, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[5, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[5, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[6, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CARD_AC"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[6, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[6, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				DC_Main.RsQry = "SELECT TAX_NAME FROM TAX_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND SR_NO = 0 AND TAX_CODE = '" + MSG2_TOTAL[2, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[2, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["TAX_NAME"], (object)""));
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME,B.RATE_TYPE,B.IT_TYPE FROM REP_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["REP_NO"]);
					mSG[DC_Main.i + 1, 26] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["REP_NO"]);
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ISU_NO"]);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_NAME"], (object)""));
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					mSG[DC_Main.i + 1, 7] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_DESC"], (object)""));
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 45] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ADD_WT"])), "0.000");
					mSG[DC_Main.i + 1, 46] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ADD_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_WT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST"])), "0.00");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 51] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LESS_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 22] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 23] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 24] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 25] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 27] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_LC"], (object)""));
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 29] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 30] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["REP_SRNO"])), "0");
					mSG[DC_Main.i + 1, 31] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 32] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 33] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_HD_VCH_NO"], (object)""));
					mSG[DC_Main.i + 1, 34] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_ADJ"], (object)""));
					mSG[DC_Main.i + 1, 35] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_LC"], (object)""));
					mSG[DC_Main.i + 1, 36] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 37] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ISU_SRNO"])), "0");
					mSG[DC_Main.i + 1, 39] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_AC_CODE"], (object)""));
					mSG[DC_Main.i + 1, 40] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_AC_NAME"], (object)""));
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_HD_VCH_NO"], (object)""));
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_ADJ"], (object)""));
					mSG[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["VCH_SRNO"])), "0");
					mSG[DC_Main.i + 1, 44] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["RATE_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 43] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_TYPE"], (object)""));
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
				OldValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 23]);
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 11]) + Conversion.Val(MSG_TOT[0, 24]) + Conversion.Val(MSG_TOT[0, 23]);
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

	private void TR_REP_REC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_REP_REC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0135: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a9: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
		{
			Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[5, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[5, 4], "", false) == 0))
		{
			Interaction.MsgBox((object)"Please Select Bank Account And Try Because Chq Rec Amt <> 0......", (MsgBoxStyle)0, (object)null);
			((Control)BtnSave).Enabled = true;
			return;
		}
		if ((Conversion.Val(MSG2_TOTAL[6, 3]) != 0.0) & (Operators.CompareString(MSG2_TOTAL[6, 4], "", false) == 0))
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
		MSG_TOT_FILL();
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				DC_Main.RsQry = "SELECT MAX(VCH_NO) AS VchNo  From REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' and CO_BOOK = '" + DC_Main.MCo_Book + "' HAVING MAX(VCH_NO) > 0";
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
		DC_Main.ExeQuteDc("DELETE FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
		if ((Conversion.Val(MSG_TOT[0, 26]) != 0.0) | (Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 25]) != 0.0))
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
			DC_Main.RsQry = "SELECT * FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
			dataRow2["DISC_PRC"] = Conversion.Val(MSG2_TOTAL[1, 2]);
			dataRow2["DISC_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
			dataRow2["TAX_CODE"] = MSG2_TOTAL[2, 4];
			dataRow2["TAX_PRC"] = Conversion.Val(MSG2_TOTAL[2, 2]);
			dataRow2["TAX_AMT"] = Conversion.Val(MSG2_TOTAL[2, 3]);
			dataRow2["ROF_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
			dataRow2["TOT_AMT"] = Conversion.Val(MSG2_TOTAL[4, 3]);
			dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[5, 3]);
			dataRow2["CARD_AMT"] = Conversion.Val(MSG2_TOTAL[6, 3]);
			dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[7, 3]);
			dataRow2["KASAR_AMT"] = Conversion.Val(MSG2_TOTAL[8, 3]);
			dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[9, 3]);
			dataRow2["CARD_AC"] = MSG2_TOTAL[6, 4];
			dataRow2["BANK_AC"] = MSG2_TOTAL[5, 4];
			dataRow2["CHQ_NO"] = MSG2_TOTAL[5, 2];
			dataRow2["BANK_NAME"] = tBankName.Text;
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
		DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
		DC_Main.RsQry = "SELECT * FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ";
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
				if ((Conversion.Val(MSG[DC_Main.i, 11]) + Conversion.Val(MSG[DC_Main.i, 25]) != 0.0) & (Operators.CompareString(MSG[DC_Main.i, 4], "", false) != 0))
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
					dataRow3["ENTRY_TYPE"] = "C";
					dataRow3["BOOK_NAME"] = FormMainBook;
					dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 0]);
					dataRow3["REP_NO"] = mSG[DC_Main.i, 26];
					dataRow3["ISU_NO"] = mSG[DC_Main.i, 1];
					dataRow3["TAG_NO"] = mSG[DC_Main.i, 3];
					dataRow3["IT_CODE"] = mSG[DC_Main.i, 4];
					dataRow3["IT_NAME"] = mSG[DC_Main.i, 5];
					dataRow3["DESIGN_NO"] = "";
					dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
					dataRow3["IT_DESC"] = mSG[DC_Main.i, 7];
					dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 8]);
					dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 9]);
					dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 10]);
					dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 11]);
					dataRow3["ADD_WT"] = Conversion.Val(mSG[DC_Main.i, 15]);
					dataRow3["LESS_WT"] = Conversion.Val(mSG[DC_Main.i, 12]);
					dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 16]);
					dataRow3["ITM_WEST"] = Conversion.Val(mSG[DC_Main.i, 17]);
					dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 18]);
					dataRow3["LESS_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 13]);
					dataRow3["LESS_FINE"] = Conversion.Val(mSG[DC_Main.i, 14]);
					dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 19]);
					dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
					dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 21];
					dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 22]);
					dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 23]);
					dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 24]);
					dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 25]);
					dataRow3["VCH_SRNO"] = Conversion.Val(mSG[DC_Main.i, 50]);
					if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
					{
						dataRow3["REP_NO"] = tVchNo.Text;
						dataRow3["REP_SRNO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["REP_LC"] = DC_Main.MLc_code;
						dataRow3["REP_YRCD"] = DC_Main.MCo_year;
						dataRow3["REP_DBCD"] = DC_Main.MCo_Book;
						dataRow3["REP_AC_CODE"] = tAcCode.Text;
						dataRow3["REP_AC_NAME"] = tAcName.Text;
						dataRow3["REP_HD_VCH_NO"] = tHdVchNo.Text;
						dataRow3["REP_ADJ"] = mSG[DC_Main.i, 34];
					}
					else
					{
						dataRow3["REP_SRNO"] = Conversion.Val(mSG[DC_Main.i, 30]);
						dataRow3["REP_LC"] = mSG[DC_Main.i, 27];
						dataRow3["REP_YRCD"] = mSG[DC_Main.i, 28];
						dataRow3["REP_DBCD"] = mSG[DC_Main.i, 29];
						dataRow3["REP_AC_CODE"] = mSG[DC_Main.i, 31];
						dataRow3["REP_AC_NAME"] = mSG[DC_Main.i, 32];
						dataRow3["REP_HD_VCH_NO"] = mSG[DC_Main.i, 33];
						dataRow3["REP_ADJ"] = mSG[DC_Main.i, 34];
					}
					if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
					{
						dataRow3["ISU_NO"] = tVchNo.Text;
						dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 0]);
						dataRow3["ISU_LC"] = DC_Main.MLc_code;
						dataRow3["ISU_YRCD"] = DC_Main.MCo_year;
						dataRow3["ISU_DBCD"] = DC_Main.MCo_Book;
						dataRow3["ISU_AC_CODE"] = tAcCode.Text;
						dataRow3["ISU_AC_NAME"] = tAcName.Text;
						dataRow3["ISU_HD_VCH_NO"] = tHdVchNo.Text;
						dataRow3["ISU_ADJ"] = mSG[DC_Main.i, 42];
					}
					else
					{
						dataRow3["ISU_SRNO"] = Conversion.Val(mSG[DC_Main.i, 38]);
						dataRow3["ISU_LC"] = mSG[DC_Main.i, 35];
						dataRow3["ISU_YRCD"] = mSG[DC_Main.i, 36];
						dataRow3["ISU_DBCD"] = mSG[DC_Main.i, 37];
						dataRow3["ISU_AC_CODE"] = mSG[DC_Main.i, 39];
						dataRow3["ISU_AC_NAME"] = mSG[DC_Main.i, 40];
						dataRow3["ISU_HD_VCH_NO"] = mSG[DC_Main.i, 41];
						dataRow3["ISU_ADJ"] = mSG[DC_Main.i, 42];
					}
					dataRow3["RATE_TYPE"] = mSG[DC_Main.i, 44];
					dataRow3["IT_TYPE"] = mSG[DC_Main.i, 43];
					dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
					dataRow3["MAIN_USER"] = MainUser;
					RsDetl.Rows.Add(dataRow3);
					((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
					RsDetl.Clear();
				}
				mSG = null;
				DC_Main.i++;
			}
			if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
			{
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.Rep_CustRec_KrIsu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.Rep_CustRec_KrIsu_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'Y' FROM REP_DETL,REP_DETL AS B WHERE B.REP_LC = REP_DETL.LC_CODE AND B.REP_YRCD = REP_DETL.CO_YEAR AND B.REP_DBCD = REP_DETL.CO_BOOK AND B.REP_NO = REP_DETL.VCH_NO AND B.REP_SRNO = REP_DETL.SR_NO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.Rep_CustRec_KrIsu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.Rep_CustRec_KrIsu_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'Y' FROM REP_DETL,REP_DETL AS B WHERE B.ISU_LC = REP_DETL.LC_CODE AND B.ISU_YRCD = REP_DETL.CO_YEAR AND B.ISU_DBCD = REP_DETL.CO_BOOK AND B.ISU_NO = REP_DETL.VCH_NO AND B.ISU_SRNO = REP_DETL.SR_NO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.Rep_KrRec_CustIsu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.Rep_KrRec_CustIsu_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
			}
			else if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'Y' FROM REP_DETL,REP_DETL AS B WHERE  REP_DETL.LC_CODE = B.ISU_LC  AND REP_DETL.CO_YEAR = B.ISU_YRCD AND  REP_DETL.CO_BOOK = B.ISU_DBCD AND  REP_DETL.VCH_NO = B.ISU_NO AND  REP_DETL.SR_NO = B.ISU_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE REP_DETL SET REP_ADJ = 'Y',ISU_ADJ = 'Y' FROM REP_DETL,REP_DETL AS B WHERE REP_DETL.LC_CODE = B.REP_LC  AND REP_DETL.CO_YEAR = B.REP_YRCD AND  REP_DETL.CO_BOOK = B.REP_DBCD AND  REP_DETL.VCH_NO = B.REP_NO AND  REP_DETL.SR_NO = B.REP_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Ledr.Rep_KrRec_CustIsu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
				DC_Main.RsQry = "DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				Ac_Rojmel.Rep_KrRec_CustIsu_Rojmel(DC_Main.MCo_Book, tVchNo.Text);
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
		//IL_0604: Unknown result type (might be due to invalid IL or missing references)
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
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM ROJ_MEL_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM TAX_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "'");
			if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'N' FROM REP_DETL,REP_DETL AS B WHERE B.REP_LC = REP_DETL.LC_CODE AND B.REP_YRCD = REP_DETL.CO_YEAR AND B.REP_DBCD = REP_DETL.CO_BOOK AND B.REP_NO = REP_DETL.VCH_NO AND B.REP_SRNO = REP_DETL.SR_NO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'N' FROM REP_DETL,REP_DETL AS B WHERE B.ISU_LC = REP_DETL.LC_CODE AND B.ISU_YRCD = REP_DETL.CO_YEAR AND B.ISU_DBCD = REP_DETL.CO_BOOK AND B.ISU_NO = REP_DETL.VCH_NO AND B.ISU_SRNO = REP_DETL.SR_NO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			else if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
			{
				DC_Main.RsQry = "UPDATE REP_DETL SET ISU_ADJ = 'N' FROM REP_DETL,REP_DETL AS B WHERE  REP_DETL.LC_CODE = B.ISU_LC  AND REP_DETL.CO_YEAR = B.ISU_YRCD AND  REP_DETL.CO_BOOK = B.ISU_DBCD AND  REP_DETL.VCH_NO = B.ISU_NO AND  REP_DETL.SR_NO = B.ISU_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.RsQry = "UPDATE REP_DETL SET REP_ADJ = 'N' FROM REP_DETL,REP_DETL AS B WHERE REP_DETL.LC_CODE = B.REP_LC  AND REP_DETL.CO_YEAR = B.REP_YRCD AND  REP_DETL.CO_BOOK = B.REP_DBCD AND  REP_DETL.VCH_NO = B.REP_NO AND  REP_DETL.SR_NO = B.REP_SRNO  AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "'";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.ExeQuteDc("DELETE FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM REP_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
		}
	}

	private void TR_REP_REC_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode != 27)
		{
			return;
		}
		if (((Control)TEXT_ENTRY).Visible)
		{
			MSG_LeaveCell(MSG, new EventArgs());
			MSG.Row = checked(MSG.Rows - 1);
			MSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MSG_TOT_FILL();
			if ((Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0))
			{
				MSG2_TOTAL.Row = 5;
			}
			else
			{
				MSG2_TOTAL.Row = 1;
			}
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
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.MsCustMail = "";
			if (Operators.CompareString(tMobile.Text, "", false) != 0)
			{
				DC_Main.MsCustWappNo = "";
			}
			DC_Main.RsQry = "SELECT B.AC_EMAIL,B.AC_MOBILE FROM REP_DATA AS A INNER JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND  A.VCH_NO = '" + CurPrnVch + "' AND (B.AC_EMAIL <> '' OR B.AC_MOBILE <> '')";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				DC_Main.MsCustMail = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_EMAIL"], (object)""));
				if (Operators.CompareString(tMobile.Text, "", false) != 0)
				{
					DC_Main.MsCustWappNo = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)DC_Main.MsCountryId, DC_Main.Tbl.Rows[0]["AC_MOBILE"]), (object)""));
				}
			}
			string rptName = ((Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0) ? "ReparingKrRec" : ((Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) != 0) ? "ReparingRec" : "ReparingCustIsu"));
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.00"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.00"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, "0.00"));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, "0.00"));
			DC_Main.RptFormula = "{REP_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REP_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {REP_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {REP_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {REP_DATA.VCH_NO} = '" + CurPrnVch + "'";
			DC_Main.MsWappPrintType = "KrIsu";
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
		if (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ReparingKrRec.RPT";
		}
		else if (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0)
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ReparingCustIsu.RPT";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\ReparingRec.RPT";
		}
		Cr.SelectionFormula = "{REP_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {REP_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {REP_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {REP_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {REP_DATA.VCH_NO} = '" + CurPrnVch + "'";
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
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_REP_REC_Activated(object sender, EventArgs e)
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
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL FROM REP_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  ORDER BY A.VCH_NO";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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
				DC_Main.RsQry = "SELECT VCH_NO FROM REP_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + text + "'";
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

	private void TR_REP_REC_Closed(object sender, EventArgs e)
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
				if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
				{
					DC_Main.MsGrCode = "20";
				}
				else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
				{
					DC_Main.MsGrCode = "10";
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
			return;
		}
		if (Operators.CompareString(tAcCode.Text, OldAcCode, false) != 0)
		{
			OldAcCode = tAcCode.Text;
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			AcGstType = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_GST_TYPE"], (object)""));
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM REP_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 10;
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
				case 4:
				case 14:
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
				case 5:
				case 6:
				case 8:
				case 9:
				case 11:
				case 12:
				case 13:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj7 = mSG2_TOTAL;
					object? obj8 = colorConverter.ConvertFromString("DarkBlue");
					obj7.CellForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					break;
				}
				case 7:
				case 10:
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
			while (DC_Main.i <= 9);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Disc Amt : ";
			mSG2_TOTAL[2, 0] = "Tax Amt : ";
			mSG2_TOTAL[3, 0] = "Rof Amt : ";
			mSG2_TOTAL[4, 0] = "Total Amt : ";
			mSG2_TOTAL[5, 0] = "Cheque Amt : ";
			mSG2_TOTAL[6, 0] = "Card Amt : ";
			mSG2_TOTAL[7, 0] = "Cash Amt : ";
			mSG2_TOTAL[8, 0] = "Kasar Amt : ";
			mSG2_TOTAL[9, 0] = "Os Amt : ";
			if ((Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0))
			{
				mSG2_TOTAL[1] = 0;
				mSG2_TOTAL[2] = 0;
				mSG2_TOTAL[3] = 0;
				mSG2_TOTAL[4] = 0;
				mSG2_TOTAL[8] = 0;
				mSG2_TOTAL[9] = 0;
				((Control)MSG2_TOTAL).Height = 82;
			}
			else if (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0)
			{
				mSG2_TOTAL[1] = 0;
				mSG2_TOTAL[3] = 0;
				((Control)MSG2_TOTAL).Height = 162;
			}
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9))
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
				if ((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9) | (mSG2_TOTAL.Row == 2))
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 4) | (mSG2_TOTAL.Row == 9))
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
			if ((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6))
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
		//IL_0251: Unknown result type (might be due to invalid IL or missing references)
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
					if (((mSG2_TOTAL.Row == 5) | (mSG2_TOTAL.Row == 6)) && Operators.CompareString(TEXT_ENTRY_2.Text, "", false) != 0)
					{
						DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							if (mSG2_TOTAL.Row == 5)
							{
								DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
							}
							else if (mSG2_TOTAL.Row == 6)
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
					if (mSG2_TOTAL.Row != 2)
					{
						break;
					}
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
									BILL_TOTAL();
								}
								else
								{
									TEXT_ENTRY_2.Text = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 1] = "TAX FREE";
									mSG2_TOTAL[mSG2_TOTAL.Row, 2] = "0.00";
									mSG2_TOTAL[mSG2_TOTAL.Row, 4] = "00";
								}
								MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
								mSG2_TOTAL.Row = 5;
								mSG2_TOTAL.Col = 3;
								((Control)TEXT_ENTRY_2).Focus();
							}
						}
						else
						{
							mSG2_TOTAL[mSG2_TOTAL.Row, 2] = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00");
							double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["TAX_PRC"]), "0.00"));
							mSG2_TOTAL[mSG2_TOTAL.Row, 4] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["TAX_CODE"], (object)""));
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row = 5;
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
						mSG2_TOTAL.Row = 5;
						mSG2_TOTAL.Col = 3;
						((Control)TEXT_ENTRY_2).Focus();
					}
					return;
				case 3:
					switch (mSG2_TOTAL.Row)
					{
					case 7:
						if ((Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0))
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							((Control)TEXT_ENTRY_2).Visible = false;
							BILL_TOTAL();
							((Control)tEmpCode).Focus();
						}
						else
						{
							MSG2_TOTAL_LeaveCell(MSG2_TOTAL, new EventArgs());
							mSG2_TOTAL.Row += 1;
							mSG2_TOTAL.Col = 3;
							((Control)TEXT_ENTRY_2).Visible = true;
							((Control)TEXT_ENTRY_2).Focus();
						}
						return;
					case 5:
					case 6:
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
					case 8:
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
		if (Conversion.Val(MSG_TOT[0, 25]) != 0.0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 25]), 0), "0.00");
			if (Conversion.Val(mSG2_TOTAL[1, 2]) != 0.0)
			{
				mSG2_TOTAL[1, 3] = Strings.Format((object)(Conversion.Val(MSG_TOT[0, 23]) * Conversion.Val(mSG2_TOTAL[1, 2]) / 100.0), "0.00");
			}
			mSG2_TOTAL[2, 3] = Strings.Format((object)Math.Round((Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3])) * Conversion.Val(mSG2_TOTAL[2, 2]) / 100.0, DC_Main.MsTaxRof), "0.00");
			mSG2_TOTAL[4, 3] = Strings.Format((object)Math.Round(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) + Conversion.Val(mSG2_TOTAL[2, 3]), 0), "0.00");
			mSG2_TOTAL[9, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[4, 3]) - Conversion.Val(mSG2_TOTAL[5, 3]) - Conversion.Val(mSG2_TOTAL[6, 3]) - Conversion.Val(mSG2_TOTAL[7, 3]) - Conversion.Val(mSG2_TOTAL[8, 3])), "0.00");
		}
		else
		{
			mSG2_TOTAL[0, 3] = "";
			mSG2_TOTAL[1, 3] = "";
			mSG2_TOTAL[2, 3] = "";
			mSG2_TOTAL[4, 3] = "";
			mSG2_TOTAL[9, 3] = "";
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
			((Control)PanelAdd).Visible = false;
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row == 0 || !((MsgOldRow != MSG.Row) & !MsgClear))
		{
			return;
		}
		MsgOldRow = MSG.Row;
		if ((Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(FormMainBook, "CUSTREP ISSUE", false) == 0))
		{
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
		}
		else if ((Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0) | (Operators.CompareString(FormMainBook, "KRREP RECEIPT", false) == 0))
		{
			if (Operators.CompareString(MSG[MSG.Row, 26], "", false) != 0)
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(MSG[MSG.Row, 28], 1, 4) + MSG[MSG.Row, 29] + MSG[MSG.Row, 26] + MSG[MSG.Row, 30];
			}
			else
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
			}
		}
		DC_Main.MsImageType = "ReparingImage";
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

	private void MSG_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgC_Click(object sender, EventArgs e)
	{
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
					}
					else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
					{
						if (Operators.CompareString(MSG[MSG.Row, 26], "", false) != 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(MSG[MSG.Row, 28], 1, 4) + MSG[MSG.Row, 29] + MSG[MSG.Row, 26] + MSG[MSG.Row, 30];
						}
						else
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
						}
					}
					DC_Main.MsImageType = "ReparingImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
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
				case 677:
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
				try0001_dispatch = 677;
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
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Invalid comparison between Unknown and I4
		((FileDialog)DlgOpen).Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg";
		((FileDialog)DlgOpen).Title = "Open Image File";
		if ((int)((CommonDialog)DlgOpen).ShowDialog() != 1)
		{
			return;
		}
		if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
		{
			DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
		}
		else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
		{
			if (Operators.CompareString(MSG[MSG.Row, 26], "", false) != 0)
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(MSG[MSG.Row, 28], 1, 4) + MSG[MSG.Row, 29] + MSG[MSG.Row, 26] + MSG[MSG.Row, 30];
			}
			else
			{
				DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
			}
		}
		DC_Main.MsImageType = "ReparingImage";
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

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void BtnImgD_Click(object sender, EventArgs e)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
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
					if (Operators.CompareString(FormMainBook, "CUSTREP RECEIPT", false) == 0)
					{
						DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
					}
					else if (Operators.CompareString(FormMainBook, "KRREP ISSUE", false) == 0)
					{
						if (Operators.CompareString(MSG[MSG.Row, 26], "", false) != 0)
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(MSG[MSG.Row, 28], 1, 4) + MSG[MSG.Row, 29] + MSG[MSG.Row, 26] + MSG[MSG.Row, 30];
						}
						else
						{
							DC_Main.MsImageNo = DC_Main.MCo_code + DC_Main.MLc_code + Strings.Mid(DC_Main.MCo_year, 1, 4) + DC_Main.MCo_Book + tVchNo.Text + MSG[MSG.Row, 0];
						}
					}
					DC_Main.MsImageType = "ReparingImage";
					DC_Main.MsImagePath = DC_Main.MSImageSavePath + "\\" + DC_Main.MsImageType + "\\" + DC_Main.MsImageNo + ".jpg";
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MsImagePath, (FileAttribute)0), "", false) != 0)
					{
						PicImage.Image.Dispose();
						PicImage.Image = null;
						FileSystem.Kill(DC_Main.MsImagePath);
					}
					goto end_IL_0001;
				case 678:
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
				try0001_dispatch = 678;
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

	private void TR_REP_REC_KeyUp(object sender, KeyEventArgs e)
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
		if ((Operators.CompareString(((ContainerControl)this).ActiveControl.Name, "TEXT_ENTRY_2", false) == 0) & (((int)e.KeyCode == 39) | ((int)e.KeyCode == 37) | ((int)e.KeyCode == 38) | ((int)e.KeyCode == 40) | ((int)e.KeyCode == 13)))
		{
			((TextBoxBase)TEXT_ENTRY_2).SelectionStart = 0;
			((TextBoxBase)TEXT_ENTRY_2).SelectionLength = Strings.Len(TEXT_ENTRY_2.Text);
		}
	}

	private void tVchDesc_DoubleClick(object sender, EventArgs e)
	{
		((Control)BtnSave).Enabled = true;
	}
}
