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
using DevNet.Models;
using MSFlexGridLib;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class TR_MFG_GHAT_REC : Form
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
	[AccessedThroughProperty("tBillNo")]
	private TextBox _tBillNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobile")]
	private TextBox _tMobile;

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

	private string OldAcCode;

	private string AcGstType;

	private double AcFineGl;

	private double AcFineSl;

	private string MsPorcessType;

	private string LastPorcess;

	private string CurProcess;

	private string NextProcess;

	private string WappAcName;

	private string WappMobile;

	private string WappMsg;

	private string AdminWappMsg;

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

	private const int cOrdNo = 1;

	private const int cOrdSrNo = 2;

	private const int cItCode = 3;

	private const int cLotNo = 4;

	private const int cDesign = 5;

	private const int cSize = 6;

	private const int cIsGrWt = 7;

	private const int cPcs = 8;

	private const int cGrWt = 9;

	private const int cMinoWt = 10;

	private const int cOthWt = 11;

	private const int cNetWt = 12;

	private const int cGhtPrc = 13;

	private const int cGhtWt = 14;

	private const int cRtnChol = 15;

	private const int cGhis = 16;

	private const int cLbrRate = 17;

	private const int cLbrAmt = 18;

	private const int cOthAmt = 19;

	private const int cNetAmt = 20;

	private const int cOrdAcName = 21;

	private const int cOrdYrCd = 22;

	private const int cOrdDbCd = 23;

	private const int cOrdAc = 24;

	private const int cItName = 25;

	private const int cDmGht = 26;

	private const int cTotGht = 27;

	private const int cMtrlIt = 28;

	private const int cMtrlWt = 29;

	private const int cLbrType = 30;

	private const int cIsPcs = 31;

	private const int cIsOthWt = 32;

	private const int cIsNetWt = 33;

	private const int cDifP = 34;

	private const int cDiffWt = 35;

	private const int cImageTake = 36;

	private const int cTouch = 37;

	private const int cWestPrc = 38;

	private const int cFine = 39;

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

	private const int cAddOthWt = 53;

	private const int cLessOthWt = 54;

	private const int cProType = 55;

	private const int cProInout = 56;

	private const int cRepNo = 57;

	private const int cRepYrcd = 58;

	private const int cRepDbCd = 59;

	private const int cRepSrNo = 60;

	private const int cIsuItCode = 61;

	private const int cDmPcs = 62;

	private const int cDmWt = 63;

	private const int cOldOrdSrNo = 64;

	private const int cRepAdj = 65;

	private const int cNetAmt2 = 0;

	private const int cChq2 = 1;

	private const int cCard2 = 2;

	private const int cCash2 = 3;

	private const int cKasar2 = 4;

	private const int cOs2 = 5;

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
			EventHandler eventHandler5 = MSG_PR_Scroll;
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
			EventHandler eventHandler = tConsiNo_TextChanged;
			TextBox val = _tMobile;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tMobile = value;
			val = _tMobile;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItRemark")]
	private virtual TextBox _tItRemark;

	internal virtual TextBox tItRemark
	{
		get
		{
			return _tItRemark;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tItRemark = value;
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

	public TR_MFG_GHAT_REC()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		((Form)this).Load += TR_MFG_GHAT_REC_Load;
		((Form)this).Deactivate += TR_MFG_GHAT_REC_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(TR_MFG_GHAT_REC_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(TR_MFG_GHAT_REC_KeyDown);
		((Form)this).Activated += TR_MFG_GHAT_REC_Activated;
		((Form)this).Closed += TR_MFG_GHAT_REC_Closed;
		((Control)this).KeyUp += new KeyEventHandler(TR_MFG_GHAT_REC_KeyUp);
		whatsApp = UT_WHATSAPP.whatsApp;
		MsPorcessType = "";
		LastPorcess = "";
		CurProcess = "";
		NextProcess = "";
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
		//IL_03b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bc: Expected O, but got Unknown
		//IL_043f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0449: Expected O, but got Unknown
		//IL_04e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f0: Expected O, but got Unknown
		//IL_059e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a8: Expected O, but got Unknown
		//IL_062f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected O, but got Unknown
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06de: Expected O, but got Unknown
		//IL_076d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0777: Expected O, but got Unknown
		//IL_07da: Unknown result type (might be due to invalid IL or missing references)
		//IL_07e4: Expected O, but got Unknown
		//IL_088d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0897: Expected O, but got Unknown
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_0ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ade: Expected O, but got Unknown
		//IL_0be9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf3: Expected O, but got Unknown
		//IL_0c56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c60: Expected O, but got Unknown
		//IL_0df2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ed4: Expected O, but got Unknown
		//IL_0f80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f8a: Expected O, but got Unknown
		//IL_1082: Unknown result type (might be due to invalid IL or missing references)
		//IL_108c: Expected O, but got Unknown
		//IL_12e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ec: Expected O, but got Unknown
		//IL_13c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ce: Expected O, but got Unknown
		//IL_146a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1474: Expected O, but got Unknown
		//IL_15af: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b9: Expected O, but got Unknown
		//IL_1604: Unknown result type (might be due to invalid IL or missing references)
		//IL_160e: Expected O, but got Unknown
		//IL_1688: Unknown result type (might be due to invalid IL or missing references)
		//IL_1692: Expected O, but got Unknown
		//IL_1713: Unknown result type (might be due to invalid IL or missing references)
		//IL_171d: Expected O, but got Unknown
		//IL_17e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ee: Expected O, but got Unknown
		//IL_1895: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Expected O, but got Unknown
		//IL_1920: Unknown result type (might be due to invalid IL or missing references)
		//IL_192a: Expected O, but got Unknown
		//IL_19b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19bc: Expected O, but got Unknown
		//IL_1a70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a7a: Expected O, but got Unknown
		//IL_1b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b38: Expected O, but got Unknown
		//IL_1bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bfa: Expected O, but got Unknown
		//IL_1c5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c68: Expected O, but got Unknown
		//IL_1cc6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cd0: Expected O, but got Unknown
		//IL_1d6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d79: Expected O, but got Unknown
		//IL_1df7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e01: Expected O, but got Unknown
		//IL_1eaf: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eb9: Expected O, but got Unknown
		//IL_1f4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f54: Expected O, but got Unknown
		//IL_1fa2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fac: Expected O, but got Unknown
		//IL_2060: Unknown result type (might be due to invalid IL or missing references)
		//IL_206a: Expected O, but got Unknown
		//IL_211e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2128: Expected O, but got Unknown
		//IL_21dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21e6: Expected O, but got Unknown
		//IL_229d: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a7: Expected O, but got Unknown
		//IL_235e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2368: Expected O, but got Unknown
		//IL_241c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2426: Expected O, but got Unknown
		//IL_24c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_24cf: Expected O, but got Unknown
		//IL_2554: Unknown result type (might be due to invalid IL or missing references)
		//IL_255e: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(TR_MFG_GHAT_REC));
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
		Label8 = new Label();
		tBillNo = new TextBox();
		MSG_TOT = new AxMSFlexGrid();
		LOpSilver = new Label();
		LOpGold = new Label();
		LOpAmt = new Label();
		LClSilver = new Label();
		lClGold = new Label();
		LClAmt = new Label();
		tMobile = new TextBox();
		tItRemark = new TextBox();
		Label5 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((Control)FlowLayoutPanel1).SuspendLayout();
		((ISupportInitialize)PicImage).BeginInit();
		((ISupportInitialize)PicZoom).BeginInit();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)MSG2_TOTAL).BeginInit();
		((ISupportInitialize)MSG).BeginInit();
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
		lblBook.Text = "Mfg Gaht Receive";
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
		((Control)tVchNo).Location = new Point(105, 38);
		((TextBoxBase)tVchNo).MaxLength = 8;
		((Control)tVchNo).Name = "tVchNo";
		((TextBoxBase)tVchNo).ReadOnly = true;
		((Control)tVchNo).Size = new Size(76, 23);
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
		((Control)PnlBotam).TabIndex = 14;
		((Control)FlowLayoutPanel1).Controls.Add((Control)(object)chkWapp);
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(246, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(575, 36);
		((Control)FlowLayoutPanel1).TabIndex = 27;
		((ButtonBase)chkWapp).BackColor = Color.Transparent;
		((Control)chkWapp).Font = new Font("Bahnschrift SemiLight SemiConde", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkWapp).ForeColor = Color.Black;
		((Control)chkWapp).Location = new Point(474, 3);
		((Control)chkWapp).Name = "chkWapp";
		((Control)chkWapp).RightToLeft = (RightToLeft)0;
		((Control)chkWapp).Size = new Size(98, 34);
		((Control)chkWapp).TabIndex = 7;
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
		((Control)PicImage).BackColor = Color.Transparent;
		PicImage.BorderStyle = (BorderStyle)1;
		PicImage.ImeMode = (ImeMode)0;
		((Control)PicImage).Location = new Point(15, 426);
		((Control)PicImage).Name = "PicImage";
		((Control)PicImage).Size = new Size(142, 115);
		PicImage.SizeMode = (PictureBoxSizeMode)4;
		PicImage.TabIndex = 1138;
		PicImage.TabStop = false;
		((FileDialog)DlgOpen).FileName = "OpenFileDialog1";
		((Control)PicZoom).BackColor = Color.Transparent;
		PicZoom.ImeMode = (ImeMode)0;
		((Control)PicZoom).Location = new Point(1208, 323);
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
		((Control)BtnF1).Size = new Size(35, 23);
		((Control)BtnF1).TabIndex = 1149;
		BtnF1.Text = "F1";
		((BaseControl)BtnF1).ToolTip = "Voucher Help";
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1215, 358);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 1155;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcCode).Location = new Point(105, 97);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(76, 23);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tAcName).Location = new Point(187, 97);
		((TextBoxBase)tAcName).MaxLength = 50;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(326, 23);
		((Control)tAcName).TabIndex = 4;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(23, 97);
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
		((Control)tEmpCode).Location = new Point(249, 426);
		((TextBoxBase)tEmpCode).MaxLength = 3;
		((Control)tEmpCode).Name = "tEmpCode";
		((Control)tEmpCode).Size = new Size(57, 23);
		((Control)tEmpCode).TabIndex = 11;
		((TextBoxBase)tEmpName).BackColor = Color.White;
		((Control)tEmpName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tEmpName).Location = new Point(312, 426);
		((TextBoxBase)tEmpName).MaxLength = 50;
		((Control)tEmpName).Name = "tEmpName";
		((Control)tEmpName).Size = new Size(246, 23);
		((Control)tEmpName).TabIndex = 1162;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(172, 426);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(69, 20);
		((Control)Label3).TabIndex = 1161;
		Label3.Text = "Employee";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(163, 459);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(76, 20);
		((Control)Label4).TabIndex = 1163;
		Label4.Text = "Vch Desc";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tVchDesc).BackColor = Color.White;
		((Control)tVchDesc).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tVchDesc).Location = new Point(249, 459);
		((TextBoxBase)tVchDesc).MaxLength = 100;
		tVchDesc.Multiline = true;
		((Control)tVchDesc).Name = "tVchDesc";
		tVchDesc.ScrollBars = (ScrollBars)2;
		((Control)tVchDesc).Size = new Size(309, 77);
		((Control)tVchDesc).TabIndex = 13;
		((Control)MSG2_TOTAL).Location = new Point(728, 383);
		((Control)MSG2_TOTAL).Name = "MSG2_TOTAL";
		((AxHost)MSG2_TOTAL).OcxState = (State)componentResourceManager.GetObject("MSG2_TOTAL.OcxState");
		((Control)MSG2_TOTAL).Size = new Size(441, 124);
		((Control)MSG2_TOTAL).TabIndex = 1167;
		((Control)MSG).Location = new Point(13, 131);
		((Control)MSG).Name = "MSG";
		((AxHost)MSG).OcxState = (State)componentResourceManager.GetObject("MSG.OcxState");
		((Control)MSG).Size = new Size(1156, 224);
		((Control)MSG).TabIndex = 1168;
		((TextBoxBase)TEXT_ENTRY_2).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY_2).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY_2).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY_2).ForeColor = Color.White;
		((Control)TEXT_ENTRY_2).Location = new Point(947, 431);
		((Control)TEXT_ENTRY_2).Name = "TEXT_ENTRY_2";
		((Control)TEXT_ENTRY_2).Size = new Size(100, 18);
		((Control)TEXT_ENTRY_2).TabIndex = 9;
		((Control)TEXT_ENTRY_2).Visible = false;
		((TextBoxBase)TEXT_ENTRY).BackColor = Color.DarkGray;
		((TextBoxBase)TEXT_ENTRY).BorderStyle = (BorderStyle)0;
		((Control)TEXT_ENTRY).Font = new Font("Segoe UI", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)TEXT_ENTRY).ForeColor = Color.White;
		((Control)TEXT_ENTRY).Location = new Point(466, 212);
		((Control)TEXT_ENTRY).Name = "TEXT_ENTRY";
		((Control)TEXT_ENTRY).Size = new Size(100, 18);
		((Control)TEXT_ENTRY).TabIndex = 10;
		((Control)TEXT_ENTRY).Visible = false;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(22, 68);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(62, 20);
		((Control)Label8).TabIndex = 1178;
		Label8.Text = "Ref No";
		Label8.TextAlign = (ContentAlignment)16;
		((TextBoxBase)tBillNo).BackColor = Color.White;
		((Control)tBillNo).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBillNo).Location = new Point(104, 68);
		((TextBoxBase)tBillNo).MaxLength = 20;
		((Control)tBillNo).Name = "tBillNo";
		((Control)tBillNo).Size = new Size(117, 23);
		((Control)tBillNo).TabIndex = 2;
		((Control)MSG_TOT).Location = new Point(15, 358);
		((Control)MSG_TOT).Name = "MSG_TOT";
		((AxHost)MSG_TOT).OcxState = (State)componentResourceManager.GetObject("MSG_TOT.OcxState");
		((Control)MSG_TOT).Size = new Size(1153, 16);
		((Control)MSG_TOT).TabIndex = 1179;
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
		((Control)LClSilver).Location = new Point(573, 526);
		((Control)LClSilver).Name = "LClSilver";
		((Control)LClSilver).Size = new Size(148, 20);
		((Control)LClSilver).TabIndex = 1213;
		LClSilver.Text = "ClSilver";
		LClSilver.TextAlign = (ContentAlignment)64;
		((Control)lClGold).BackColor = Color.Transparent;
		((Control)lClGold).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lClGold).ForeColor = Color.Black;
		lClGold.ImeMode = (ImeMode)0;
		((Control)lClGold).Location = new Point(572, 503);
		((Control)lClGold).Name = "lClGold";
		((Control)lClGold).Size = new Size(148, 20);
		((Control)lClGold).TabIndex = 1212;
		lClGold.Text = "ClGold";
		lClGold.TextAlign = (ContentAlignment)64;
		((Control)LClAmt).BackColor = Color.Transparent;
		((Control)LClAmt).Font = new Font("Tahoma", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LClAmt).ForeColor = Color.Black;
		LClAmt.ImeMode = (ImeMode)0;
		((Control)LClAmt).Location = new Point(572, 480);
		((Control)LClAmt).Name = "LClAmt";
		((Control)LClAmt).Size = new Size(148, 20);
		((Control)LClAmt).TabIndex = 1211;
		LClAmt.Text = "ClAmt";
		LClAmt.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobile).BackColor = Color.White;
		((Control)tMobile).Font = new Font("Microsoft Sans Serif", 9.75f);
		((Control)tMobile).Location = new Point(519, 98);
		((TextBoxBase)tMobile).MaxLength = 10;
		((Control)tMobile).Name = "tMobile";
		((TextBoxBase)tMobile).ReadOnly = true;
		((Control)tMobile).Size = new Size(161, 22);
		((Control)tMobile).TabIndex = 1214;
		((Control)tMobile).Visible = false;
		((TextBoxBase)tItRemark).BackColor = Color.White;
		((Control)tItRemark).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tItRemark).Location = new Point(87, 385);
		((TextBoxBase)tItRemark).MaxLength = 50;
		((Control)tItRemark).Name = "tItRemark";
		((Control)tItRemark).Size = new Size(633, 23);
		((Control)tItRemark).TabIndex = 1215;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(12, 386);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(69, 20);
		((Control)Label5).TabIndex = 1216;
		Label5.Text = "ItRemark";
		Label5.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)tItRemark);
		((Control)this).Controls.Add((Control)(object)tMobile);
		((Control)this).Controls.Add((Control)(object)LClSilver);
		((Control)this).Controls.Add((Control)(object)lClGold);
		((Control)this).Controls.Add((Control)(object)LClAmt);
		((Control)this).Controls.Add((Control)(object)LOpSilver);
		((Control)this).Controls.Add((Control)(object)LOpGold);
		((Control)this).Controls.Add((Control)(object)LOpAmt);
		((Control)this).Controls.Add((Control)(object)MSG_TOT);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tBillNo);
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
		((Control)this).Name = "TR_MFG_GHAT_REC";
		((Form)this).Text = "_UMS_U";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)FlowLayoutPanel1).ResumeLayout(false);
		((ISupportInitialize)PicImage).EndInit();
		((ISupportInitialize)PicZoom).EndInit();
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)MSG2_TOTAL).EndInit();
		((ISupportInitialize)MSG).EndInit();
		((ISupportInitialize)MSG_TOT).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MSG_CLEAR()
	{
		AxMSFlexGrid mSG = MSG;
		MsgClear = true;
		mSG.Clear();
		mSG.Cols = 66;
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
			mSG[4] = (int)Math.Round(0.0 * ColCon);
			mSG[4] = 0;
			mSG[0, 4] = "LotNo";
			mSG[3] = (int)Math.Round(1000.0 * ColCon);
			mSG[3] = 0;
			mSG[0, 3] = "ItCode";
			mSG[5] = (int)Math.Round(1100.0 * ColCon);
			mSG[5] = 0;
			mSG[0, 5] = "Design";
			mSG[6] = (int)Math.Round(1000.0 * ColCon);
			mSG[6] = 0;
			mSG[0, 6] = "cSize";
			if ((Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0))
			{
				mSG[8] = (int)Math.Round(700.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "Pcs";
				mSG[9] = (int)Math.Round(1000.0 * ColCon);
				mSG[9] = 7;
				mSG[0, 9] = "GrWt";
				mSG[11] = (int)Math.Round(900.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "OthWt";
				mSG[12] = (int)Math.Round(1000.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "NetWt";
				mSG[13] = (int)Math.Round(800.0 * ColCon);
				mSG[13] = 7;
				mSG[0, 13] = "Ght%";
				mSG[14] = (int)Math.Round(900.0 * ColCon);
				mSG[14] = 7;
				mSG[0, 14] = "GhtWt";
				mSG[15] = (int)Math.Round(900.0 * ColCon);
				mSG[15] = 7;
				mSG[0, 15] = "Chole";
				mSG[16] = (int)Math.Round(900.0 * ColCon);
				mSG[16] = 7;
				mSG[0, 16] = "Ghis";
				mSG[17] = (int)Math.Round(0.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "LbrRat";
				mSG[18] = (int)Math.Round(0.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "LbrAmt";
				mSG[19] = (int)Math.Round(0.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "OthAmt";
				mSG[20] = (int)Math.Round(1100.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "NetAmt";
				mSG[10] = 0;
				mSG[7] = 0;
			}
			else if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
			{
				mSG[7] = (int)Math.Round(1000.0 * ColCon);
				mSG[7] = 7;
				mSG[0, 7] = "IsuGwt";
				mSG[10] = (int)Math.Round(1000.0 * ColCon);
				mSG[10] = 7;
				mSG[0, 10] = "MinoWt";
				mSG[8] = (int)Math.Round(700.0 * ColCon);
				mSG[8] = 7;
				mSG[0, 8] = "Pcs";
				mSG[9] = (int)Math.Round(1000.0 * ColCon);
				mSG[9] = 7;
				mSG[0, 9] = "GrWt";
				mSG[11] = (int)Math.Round(900.0 * ColCon);
				mSG[11] = 7;
				mSG[0, 11] = "OthWt";
				mSG[12] = (int)Math.Round(1000.0 * ColCon);
				mSG[12] = 7;
				mSG[0, 12] = "NetWt";
				mSG[13] = 0;
				mSG[14] = 0;
				mSG[15] = 0;
				mSG[16] = 0;
				mSG[17] = (int)Math.Round(900.0 * ColCon);
				mSG[17] = 7;
				mSG[0, 17] = "LbrRat";
				mSG[18] = (int)Math.Round(1000.0 * ColCon);
				mSG[18] = 7;
				mSG[0, 18] = "LbrAmt";
				mSG[19] = (int)Math.Round(0.0 * ColCon);
				mSG[19] = 7;
				mSG[0, 19] = "OthAmt";
				mSG[20] = (int)Math.Round(1100.0 * ColCon);
				mSG[20] = 7;
				mSG[0, 20] = "NetAmt";
			}
			mSG[1] = (int)Math.Round(1100.0 * ColCon);
			mSG[1] = 0;
			mSG[0, 1] = "OrdNo";
			mSG[2] = (int)Math.Round(800.0 * ColCon);
			mSG[2] = 0;
			mSG[0, 2] = "OrdSr";
			mSG[22] = (int)Math.Round(0.0 * ColCon);
			mSG[22] = 0;
			mSG[0, 22] = "OrdYr";
			mSG[23] = (int)Math.Round(0.0 * ColCon);
			mSG[23] = 0;
			mSG[0, 23] = "OrdBk";
			mSG[24] = (int)Math.Round(0.0 * ColCon);
			mSG[24] = 0;
			mSG[0, 24] = "OrdAc";
			mSG[21] = (int)Math.Round(2200.0 * ColCon);
			mSG[21] = 0;
			mSG[0, 21] = "OrdParty";
			mSG[25] = (int)Math.Round(2200.0 * ColCon);
			mSG[25] = 0;
			mSG[0, 25] = "ItName";
			if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
			{
				mSG[13] = 0;
				mSG[14] = 0;
				mSG[15] = 0;
				mSG[16] = 0;
				mSG[21] = (int)Math.Round(2700.0 * ColCon);
				mSG[21] = 0;
				mSG[0, 21] = "OrdParty";
				mSG[25] = (int)Math.Round(2300.0 * ColCon);
				mSG[25] = 0;
				mSG[0, 25] = "ItName";
			}
			mSG[26] = 0;
			mSG[27] = 0;
			mSG[28] = 0;
			mSG[29] = 0;
			mSG[34] = 0;
			mSG[35] = 0;
			mSG[31] = 0;
			mSG[32] = 0;
			mSG[33] = 0;
			mSG[30] = 0;
			mSG[36] = 0;
			mSG[37] = 0;
			mSG[38] = 0;
			mSG[39] = 0;
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
			mSG.Row = 1;
			mSG.Col = 0;
			((Control)TEXT_ENTRY).Visible = false;
			MsgClear = false;
			MsgLastCol = 20;
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
			((Control)TEXT_ENTRY).Visible = false;
		}
	}

	private void CommPassAdd()
	{
		AxMSFlexGrid mSG = MSG;
		mSG[mSG.Row, 0] = Conversions.ToString(MSG.Row);
		mSG[mSG.Row, 8] = Conversions.ToString(1);
		mSG[mSG.Row, 30] = DC_Main.MsLbrType;
		if (Operators.CompareString(EntryMode, "A", false) == 0)
		{
			mSG[mSG.Row, 42] = Conversions.ToString(MSG.Row);
		}
		else
		{
			mSG[mSG.Row, 42] = Conversions.ToString(Conversion.Val(mSG[checked(mSG.Rows - 2), 42]) + 1.0);
		}
		mSG[mSG.Row, 46] = "A";
		mSG[mSG.Row, 36] = "N";
		mSG[mSG.Row, 65] = "N";
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
			case 3:
			case 28:
			case 41:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 5;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 1:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				if (Operators.CompareString(mSG[mSG.Row, 46], "E", false) == 0)
				{
					((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				}
				break;
			case 2:
			case 22:
			case 23:
			case 24:
			case 25:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 50;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 4:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 40:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 15;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 5:
			case 6:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 20;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 30:
			case 36:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 1;
				TEXT_ENTRY.Text = mSG[mSG.Row, mSG.Col];
				break;
			case 31:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 6;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 8:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 8;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0");
				break;
			case 13:
			case 37:
			case 38:
			case 45:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 17:
			case 18:
			case 19:
			case 20:
			case 43:
			case 44:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.00");
				break;
			case 7:
			case 32:
			case 33:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				((TextBoxBase)TEXT_ENTRY).ReadOnly = true;
				break;
			case 9:
			case 10:
			case 11:
			case 12:
			case 14:
			case 15:
			case 16:
			case 26:
			case 27:
			case 29:
				((TextBoxBase)TEXT_ENTRY).MaxLength = 10;
				TEXT_ENTRY.Text = Strings.Format((object)Conversion.Val(mSG[mSG.Row, mSG.Col]), "0.000");
				break;
			case 39:
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
			case 2:
			case 22:
			case 23:
			case 24:
			case 25:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 0:
			case 4:
			case 6:
			case 28:
			case 30:
			case 36:
			case 41:
				mSG[mSG.Row, mSG.Col] = TEXT_ENTRY.Text;
				break;
			case 8:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0");
				break;
			case 13:
			case 37:
			case 38:
			case 45:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 17:
			case 18:
			case 19:
			case 20:
			case 43:
			case 44:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.00");
				CommPassTotal();
				break;
			case 11:
			case 15:
				mSG[mSG.Row, mSG.Col] = Strings.Format((object)Conversion.Val(TEXT_ENTRY.Text), "0.000");
				CommPassTotal();
				break;
			case 7:
			case 9:
			case 10:
			case 12:
			case 14:
			case 16:
			case 26:
			case 27:
			case 29:
			case 32:
			case 33:
			case 39:
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
				case 3975:
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
						case 7:
							goto IL_00db;
						case 8:
							goto IL_0126;
						case 9:
						case 10:
							goto IL_016f;
						case 11:
							goto IL_01a6;
						case 12:
							goto IL_01da;
						case 13:
							goto IL_023a;
						case 15:
							goto IL_02b8;
						case 14:
						case 16:
						case 17:
						case 18:
							goto IL_02ef;
						case 19:
							goto IL_030f;
						case 20:
							goto IL_0356;
						case 21:
						case 22:
							goto IL_03b4;
						case 23:
							goto IL_0400;
						case 24:
						case 25:
							goto IL_0454;
						case 26:
							goto IL_049c;
						case 27:
							goto IL_04d3;
						case 28:
							goto IL_0507;
						case 29:
							goto IL_0567;
						case 30:
						case 31:
						case 32:
							goto IL_05e5;
						case 33:
							goto IL_061c;
						case 34:
							goto IL_0650;
						case 35:
							goto IL_06b0;
						case 36:
						case 37:
						case 38:
							goto IL_072e;
						case 39:
							goto IL_0769;
						case 40:
						case 41:
							goto IL_07b3;
						case 42:
							goto IL_07c9;
						case 43:
							goto IL_07f6;
						case 44:
							goto IL_0846;
						case 46:
							goto IL_088f;
						case 48:
							goto IL_08e6;
						case 50:
							goto IL_0952;
						case 52:
							goto IL_09c5;
						case 45:
						case 47:
						case 49:
						case 51:
						case 53:
						case 54:
						case 55:
						case 56:
						case 57:
							goto IL_0a20;
						case 58:
							goto IL_0a6c;
						case 59:
						case 60:
							goto IL_0aca;
						case 61:
							goto IL_0af8;
						case 63:
							goto IL_0b41;
						case 65:
							goto IL_0b94;
						case 67:
							goto IL_0bfc;
						case 69:
							goto IL_0c6b;
						case 62:
						case 64:
						case 66:
						case 68:
						case 70:
						case 71:
						case 72:
							goto IL_0cbe;
						case 73:
							goto IL_0d06;
						case 74:
							goto IL_0d3b;
						case 75:
							goto IL_0d82;
						case 76:
						case 77:
							goto IL_0e1c;
						case 78:
							goto IL_0e1e;
						case 79:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 80:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0d82:
					num2 = 75;
					val[val.Row, 35] = Strings.Format((object)(Conversion.Val(val[val.Row, 7]) - (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 15]) + Conversion.Val(val[val.Row, 16]) + Conversion.Val(val[val.Row, 29]))), "0.000");
					goto IL_0e1c;
					IL_0e1c:
					val = null;
					goto IL_0e1e;
					IL_0d3b:
					num2 = 74;
					val[val.Row, 34] = Strings.Format((object)(Conversion.Val(val[val.Row, 31]) - Conversion.Val(val[val.Row, 8])), "0");
					goto IL_0d82;
					IL_0e1e:
					num2 = 78;
					MSG_TOT_FILL();
					break;
					IL_000c:
					num2 = 2;
					val = MSG;
					goto IL_0015;
					IL_0015:
					num2 = 3;
					if (Conversion.Val(val[val.Row, 9]) != Conversion.Val(val[val.Row, 47]))
					{
						goto IL_004b;
					}
					goto IL_00db;
					IL_004b:
					num2 = 4;
					val[val.Row, 47] = Strings.Format((object)Conversion.Val(val[val.Row, 9]), "0.000");
					goto IL_007e;
					IL_007e:
					num2 = 5;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 11]) - Conversion.Val(val[val.Row, 10])), "0.000");
					goto IL_00db;
					IL_00db:
					num2 = 7;
					if ((Conversion.Val(val[val.Row, 11]) != 0.0) & (Conversion.Val(val[val.Row, 9]) != 0.0))
					{
						goto IL_0126;
					}
					goto IL_016f;
					IL_0126:
					num2 = 8;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 11])), "0.000");
					goto IL_016f;
					IL_016f:
					num2 = 10;
					if (Conversion.Val(val[val.Row, 12]) != Conversion.Val(val[val.Row, 48]))
					{
						goto IL_01a6;
					}
					goto IL_02ef;
					IL_01a6:
					num2 = 11;
					val[val.Row, 48] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_01da;
					IL_01da:
					num2 = 12;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_023a;
					}
					goto IL_02b8;
					IL_023a:
					num2 = 13;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_02ef;
					IL_02b8:
					num2 = 15;
					val[val.Row, 39] = Strings.Format((object)Conversion.Val(val[val.Row, 12]), "0.000");
					goto IL_02ef;
					IL_02ef:
					num2 = 18;
					if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
					{
						goto IL_030f;
					}
					goto IL_03b4;
					IL_030f:
					num2 = 19;
					val[val.Row, 10] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - Conversion.Val(val[val.Row, 7])), "0.000");
					goto IL_0356;
					IL_0356:
					num2 = 20;
					val[val.Row, 12] = Strings.Format((object)(Conversion.Val(val[val.Row, 9]) - (Conversion.Val(val[val.Row, 10]) + Conversion.Val(val[val.Row, 11]))), "0.000");
					goto IL_03b4;
					IL_03b4:
					num2 = 22;
					if ((Conversion.Val(val[val.Row, 13]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0400;
					}
					goto IL_0454;
					IL_0400:
					num2 = 23;
					val[val.Row, 14] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) * Conversion.Val(val[val.Row, 13]) / 100.0), "0.000");
					goto IL_0454;
					IL_0454:
					num2 = 25;
					val[val.Row, 27] = Strings.Format((object)(Conversion.Val(val[val.Row, 14]) + Conversion.Val(val[val.Row, 26])), "0.000");
					goto IL_049c;
					IL_049c:
					num2 = 26;
					if (Conversion.Val(val[val.Row, 37]) != Conversion.Val(val[val.Row, 49]))
					{
						goto IL_04d3;
					}
					goto IL_05e5;
					IL_04d3:
					num2 = 27;
					val[val.Row, 49] = Strings.Format((object)Conversion.Val(val[val.Row, 37]), "0.00");
					goto IL_0507;
					IL_0507:
					num2 = 28;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_0567;
					}
					goto IL_05e5;
					IL_0567:
					num2 = 29;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_05e5;
					IL_05e5:
					num2 = 32;
					if (Conversion.Val(val[val.Row, 38]) != Conversion.Val(val[val.Row, 50]))
					{
						goto IL_061c;
					}
					goto IL_072e;
					IL_061c:
					num2 = 33;
					val[val.Row, 50] = Strings.Format((object)Conversion.Val(val[val.Row, 38]), "0.00");
					goto IL_0650;
					IL_0650:
					num2 = 34;
					if ((Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) != 0.0) & (Conversion.Val(val[val.Row, 12]) != 0.0))
					{
						goto IL_06b0;
					}
					goto IL_072e;
					IL_06b0:
					num2 = 35;
					val[val.Row, 39] = Strings.Format((object)((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38])) / 100.0), "0.000");
					goto IL_072e;
					IL_072e:
					num2 = 38;
					if (Conversion.Val(val[val.Row, 37]) + Conversion.Val(val[val.Row, 38]) == 0.0)
					{
						goto IL_0769;
					}
					goto IL_07b3;
					IL_0769:
					num2 = 39;
					val[val.Row, 39] = Strings.Format((object)(Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), "0.000");
					goto IL_07b3;
					IL_07b3:
					num2 = 41;
					if (val.Col == 18)
					{
						goto IL_07c9;
					}
					goto IL_0a20;
					IL_07c9:
					num2 = 42;
					if (Conversion.Val(val[val.Row, 18]) != 0.0)
					{
						goto IL_07f6;
					}
					goto IL_0a20;
					IL_07f6:
					num2 = 43;
					if ((Conversion.Val(val[val.Row, 18]) != 0.0) & (Conversion.Val(val[val.Row, 17]) != 0.0))
					{
						goto IL_0846;
					}
					goto IL_0a20;
					IL_0846:
					num2 = 44;
					switch (val[val.Row, 30])
					{
					case "P":
						break;
					case "N":
						goto IL_08e6;
					case "K":
						goto IL_0952;
					default:
						goto IL_09c5;
					}
					goto IL_088f;
					IL_09c5:
					num2 = 52;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 9]), DC_Main.MsLbrRof), "0.00");
					goto IL_0a20;
					IL_0952:
					num2 = 50;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) / 1000.0, DC_Main.MsLbrRof), "0.00");
					goto IL_0a20;
					IL_08e6:
					num2 = 48;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) / (Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])), DC_Main.MsLbrRof), "0.00");
					goto IL_0a20;
					IL_088f:
					num2 = 46;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 18]) / Conversion.Val(val[val.Row, 8]), DC_Main.MsLbrRof), "0.00");
					goto IL_0a20;
					IL_0a20:
					num2 = 57;
					if ((Conversion.Val(val[val.Row, 45]) != 0.0) & (Conversion.Val(val[val.Row, 43]) != 0.0))
					{
						goto IL_0a6c;
					}
					goto IL_0aca;
					IL_0a6c:
					num2 = 58;
					val[val.Row, 17] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 43]) * Conversion.Val(val[val.Row, 45]) / 100.0, DC_Main.MsLbrRof), "0.00");
					goto IL_0aca;
					IL_0aca:
					num2 = 60;
					if (Conversion.Val(val[val.Row, 17]) != 0.0)
					{
						goto IL_0af8;
					}
					goto IL_0cbe;
					IL_0af8:
					num2 = 61;
					switch (val[val.Row, 30])
					{
					case "P":
						break;
					case "N":
						goto IL_0b94;
					case "K":
						goto IL_0bfc;
					default:
						goto IL_0c6b;
					}
					goto IL_0b41;
					IL_0c6b:
					num2 = 69;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 9]) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0cbe;
					IL_0bfc:
					num2 = 67;
					val[val.Row, 18] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * (Conversion.Val(val[val.Row, 17]) / 1000.0), 0), "0.00");
					goto IL_0cbe;
					IL_0b94:
					num2 = 65;
					val[val.Row, 18] = Strings.Format((object)Math.Round((Conversion.Val(val[val.Row, 12]) + Conversion.Val(val[val.Row, 14])) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0cbe;
					IL_0b41:
					num2 = 63;
					val[val.Row, 18] = Strings.Format((object)Math.Round(Conversion.Val(val[val.Row, 8]) * Conversion.Val(val[val.Row, 17]), 0), "0.00");
					goto IL_0cbe;
					IL_0cbe:
					num2 = 72;
					val[val.Row, 20] = Strings.Format((object)(Conversion.Val(val[val.Row, 18]) + Conversion.Val(val[val.Row, 19])), "0.00");
					goto IL_0d06;
					IL_0d06:
					num2 = 73;
					if ((Operators.CompareString(FormBookInOut, "I", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
					{
						goto IL_0d3b;
					}
					goto IL_0e1c;
					end_IL_0001_2:
					break;
				}
				num2 = 79;
				BILL_TOTAL();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 3975;
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
		//IL_053f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Invalid comparison between Unknown and I4
		//IL_0554: Unknown result type (might be due to invalid IL or missing references)
		//IL_0556: Invalid comparison between Unknown and I4
		//IL_0533: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		//IL_0568: Unknown result type (might be due to invalid IL or missing references)
		//IL_056b: Invalid comparison between Unknown and I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Invalid comparison between Unknown and I4
		//IL_0638: Unknown result type (might be due to invalid IL or missing references)
		//IL_063b: Invalid comparison between Unknown and I4
		//IL_06c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c7: Invalid comparison between Unknown and I4
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075a: Invalid comparison between Unknown and I4
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1512: Unknown result type (might be due to invalid IL or missing references)
		//IL_208b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_17d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_23f8: Unknown result type (might be due to invalid IL or missing references)
		UpDown = false;
		Msgleft = false;
		AxMSFlexGrid mSG = MSG;
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x44 & (0 - (e.Control ? 1 : 0))))
		{
			if (MSG.Rows > 2)
			{
				if ((int)Interaction.MsgBox((object)"This Row Record will Removed permantley ?", (MsgBoxStyle)36, (object)null) == 6 && (int)Interaction.MsgBox((object)"Are You Soure Delete This Record... ?", (MsgBoxStyle)36, (object)null) == 6)
				{
					if (Operators.CompareString(mSG[mSG.Row, 1], "", false) != 0)
					{
						DC_Main.RsQry = ("SELECT A.VCH_NO,A.CO_YEAR,A.CO_BOOK,B.BOOK_NAME,A.OLD_SRNO  FROM MFG_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_YRCD = '" + DC_Main.MCo_year + "' AND A.REP_DBCD = '" + DC_Main.MCo_Book + "' AND A.REP_NO = '" + tVchNo.Text + "' AND A.REP_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42]))) ?? "";
						DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (DC_Main.Rshlp.Rows.Count > 0)
						{
							Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"You Cant Delete this Voucher Because This Voucher Linkd With ", DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"  Voucher No And SrNo = "), DC_Main.Rshlp.Rows[0]["OLD_SRNO"]), (object)"  and Book Is "), DC_Main.Rshlp.Rows[0]["BOOK_NAME"]), (object)" Item .... First Delete It.."), (MsgBoxStyle)0, (object)null);
							return;
						}
						if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
						{
							DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,MFG_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.REP_YRCD  AND APR_DETL.CO_BOOK = B.REP_DBCD AND APR_DETL.VCH_NO = B.REP_NO AND APR_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42])) + " ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
						{
							DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42])) + " ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
						{
							DC_Main.RsQry = ("UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' AND B.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42]))) ?? "";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.ExeQuteDc(("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' AND OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 42]))) ?? "");
					}
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
			else
			{
				Interaction.MsgBox((object)"Please Delate This Voucher Because item row > 1 then Row Delete Enable....", (MsgBoxStyle)0, (object)null);
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
					case 1:
						if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
						{
							if (!(((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, MSG[MSG.Row, 1], false) != 0)) | (Conversion.Val(MSG[MSG.Row, 2]) != Conversion.Val(MSG[MSG.Row, 64]))))
							{
								break;
							}
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM APR_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ISU_YRCD = '" + mSG[mSG.Row, 22] + "' AND A.ISU_DBCD = '" + mSG[mSG.Row, 23] + "' AND A.ISU_NO = '" + TEXT_ENTRY.Text + "' AND A.ISU_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 2])) + " ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT A.ISU_AC_NAME as CustNameL,A.ISU_NO As VchNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE as SizeL,D.ORD_DEL_DATE As DeliveryL,A.ITM_GWT As GrwtW,A.ISU_SRNO AS SrNoM,A.ISU_YRCD As YearL,A.ISU_DBCD As BookL,A.ITM_NWT As NetWtW,A.ISU_AC_CODE,C.AC_NAME As KrgrL,A.IT_CODE as ItCodeL FROM ((APR_DETL AS A LEFT JOIN SL_ORD_DETL AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.ISU_YRCD = D.CO_YEAR AND A.ISU_DBCD = D.CO_BOOK AND A.ISU_NO = D.VCH_NO AND A.ISU_SRNO = D.OLD_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.BOOK_NAME = 'GHAT ISU' AND A.ISU_REC = 'N' AND A.ISU_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[16];
								DC_Main.ColWidth[0] = 200.0;
								DC_Main.ColWidth[1] = 80.0;
								DC_Main.ColWidth[2] = 105.0;
								DC_Main.ColWidth[3] = 160.0;
								DC_Main.ColWidth[4] = 160.0;
								DC_Main.ColWidth[5] = 80.0;
								DC_Main.ColWidth[6] = 100.0;
								DC_Main.ColWidth[7] = 80.0;
								DC_Main.ColWidth[8] = 60.0;
								DC_Main.ColWidth[9] = 100.0;
								DC_Main.ColWidth[10] = 70.0;
								DC_Main.ColWidth[11] = 80.0;
								DC_Main.ColWidth[12] = 0.0;
								DC_Main.ColWidth[13] = 0.0;
								DC_Main.ColWidth[14] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[1];
										mSG[mSG.Row, 3] = DC_Main.ColValue[14];
										mSG[mSG.Row, 21] = DC_Main.ColValue[0];
										mSG[mSG.Row, 1] = DC_Main.ColValue[1];
										mSG[mSG.Row, 2] = DC_Main.ColValue[8];
										mSG[mSG.Row, 22] = DC_Main.ColValue[9];
										mSG[mSG.Row, 23] = DC_Main.ColValue[10];
										mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[11]), "0.000");
										mSG[mSG.Row, 24] = DC_Main.ColValue[12];
										mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[11]), "0.000");
										mSG[mSG.Row, 5] = DC_Main.ColValue[2];
										mSG[mSG.Row, 6] = DC_Main.ColValue[5];
										mSG[mSG.Row, 51] = DC_Main.ColValue[4];
									}
									else
									{
										mSG[mSG.Row, 21] = "";
										mSG[mSG.Row, 1] = "";
										mSG[mSG.Row, 2] = "";
										mSG[mSG.Row, 22] = "";
										mSG[mSG.Row, 23] = "";
										mSG[mSG.Row, 24] = "";
										mSG[mSG.Row, 5] = "";
										mSG[mSG.Row, 6] = "";
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							DC_Main.i = mSG.Row;
							int num2 = mSG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num2)
							{
								if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 1], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 2]) == Conversion.Val(MSG[DC_Main.i, 2])) & (mSG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
									mSG[DC_Main.i, 1] = "";
									mSG[DC_Main.i, 2] = "";
									mSG[DC_Main.i, 22] = "";
									mSG[DC_Main.i, 23] = "";
									mSG[DC_Main.i, 24] = "";
									mSG[DC_Main.i, 5] = "";
									mSG[DC_Main.i, 6] = "";
									mSG[DC_Main.i, 21] = "";
									mSG[DC_Main.i, 3] = "";
									mSG[DC_Main.i, 9] = "";
									mSG[DC_Main.i, 11] = "";
									mSG[DC_Main.i, 12] = "";
									mSG[DC_Main.i, 58] = "";
									mSG[DC_Main.i, 59] = "";
									mSG[DC_Main.i, 57] = "";
									mSG[DC_Main.i, 60] = "";
									return;
								}
								DC_Main.X++;
							}
							mSG[DC_Main.i, 64] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 2]));
							mSG[DC_Main.i, 55] = "G";
							mSG[DC_Main.i, 56] = "O";
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 4] = "";
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							mSG[mSG.Row, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[mSG.Row, 60] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)"")));
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							MSG_TOT_FILL();
						}
						else if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
						{
							if (!(((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, MSG[MSG.Row, 1], false) != 0)) | (Conversion.Val(MSG[MSG.Row, 2]) != Conversion.Val(MSG[MSG.Row, 64]))))
							{
								break;
							}
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.ORD_YRCD = '" + mSG[mSG.Row, 22] + "' AND A.ORD_DBCD = '" + mSG[mSG.Row, 23] + "' AND A.ORD_NO = '" + TEXT_ENTRY.Text + "' AND A.ORD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 2])) + " ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT D.AC_NAME as CustNameL,A.ORD_NO As VchNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE as SizeL,E.ORD_DEL_DATE As DeliveryL,A.ITM_GWT As GrwtW,A.ORD_SRNO AS SrNoM,A.ORD_YRCD As YearL,A.ORD_DBCD As BookL,A.ITM_NWT As NetWtW,A.ORD_AC_CODE,C.AC_NAME As KrgrL,A.IT_CODE as ItCodeL FROM (((MFG_DETL AS A LEFT JOIN SL_ORD_DETL AS E ON A.CO_CODE = E.CO_CODE AND A.LC_CODE = E.LC_CODE AND A.ORD_YRCD = E.CO_YEAR AND A.ORD_DBCD = E.CO_BOOK AND A.ORD_NO = E.VCH_NO AND A.ORD_SRNO = E.OLD_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.KR_CODE = C.AC_CODE)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'MFG GHAT REC' AND A.REP_ADJ = 'N' AND A.ORD_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[16];
								DC_Main.ColWidth[0] = 180.0;
								DC_Main.ColWidth[1] = 80.0;
								DC_Main.ColWidth[2] = 90.0;
								DC_Main.ColWidth[3] = 160.0;
								DC_Main.ColWidth[4] = 160.0;
								DC_Main.ColWidth[5] = 80.0;
								DC_Main.ColWidth[6] = 90.0;
								DC_Main.ColWidth[7] = 0.0;
								DC_Main.ColWidth[8] = 60.0;
								DC_Main.ColWidth[9] = 100.0;
								DC_Main.ColWidth[10] = 70.0;
								DC_Main.ColWidth[11] = 80.0;
								DC_Main.ColWidth[12] = 0.0;
								DC_Main.ColWidth[13] = 140.0;
								DC_Main.ColWidth[14] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[1];
										mSG[mSG.Row, 3] = DC_Main.ColValue[14];
										mSG[mSG.Row, 21] = DC_Main.ColValue[0];
										mSG[mSG.Row, 1] = DC_Main.ColValue[1];
										mSG[mSG.Row, 2] = DC_Main.ColValue[8];
										mSG[mSG.Row, 22] = DC_Main.ColValue[9];
										mSG[mSG.Row, 23] = DC_Main.ColValue[10];
										mSG[mSG.Row, 12] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[11]), "0.000");
										mSG[mSG.Row, 24] = DC_Main.ColValue[12];
										mSG[mSG.Row, 9] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
										mSG[mSG.Row, 5] = DC_Main.ColValue[2];
										mSG[mSG.Row, 6] = DC_Main.ColValue[5];
										mSG[mSG.Row, 51] = DC_Main.ColValue[4];
									}
									else
									{
										mSG[mSG.Row, 21] = "";
										mSG[mSG.Row, 1] = "";
										mSG[mSG.Row, 2] = "";
										mSG[mSG.Row, 22] = "";
										mSG[mSG.Row, 23] = "";
										mSG[mSG.Row, 24] = "";
										mSG[mSG.Row, 5] = "";
										mSG[mSG.Row, 6] = "";
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							DC_Main.i = mSG.Row;
							int num3 = mSG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num3)
							{
								if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 1], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 2]) == Conversion.Val(MSG[DC_Main.i, 2])) & (mSG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
									mSG[DC_Main.i, 1] = "";
									mSG[DC_Main.i, 2] = "";
									mSG[DC_Main.i, 22] = "";
									mSG[DC_Main.i, 23] = "";
									mSG[DC_Main.i, 24] = "";
									mSG[DC_Main.i, 5] = "";
									mSG[DC_Main.i, 6] = "";
									mSG[DC_Main.i, 21] = "";
									mSG[DC_Main.i, 3] = "";
									mSG[DC_Main.i, 9] = "";
									mSG[DC_Main.i, 11] = "";
									mSG[DC_Main.i, 12] = "";
									mSG[DC_Main.i, 58] = "";
									mSG[DC_Main.i, 59] = "";
									mSG[DC_Main.i, 57] = "";
									mSG[DC_Main.i, 60] = "";
									return;
								}
								DC_Main.X++;
							}
							mSG[DC_Main.i, 64] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 2]));
							mSG[DC_Main.i, 55] = "M";
							mSG[DC_Main.i, 56] = "O";
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 4] = "";
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_FINE"])), "0.000");
							mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							mSG[mSG.Row, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[mSG.Row, 60] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)"")));
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
							mSG[DC_Main.i, 65] = "N";
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							MSG_TOT_FILL();
						}
						else
						{
							if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) != 0 || !(((Operators.CompareString(TEXT_ENTRY.Text, "", false) != 0) & (Operators.CompareString(TEXT_ENTRY.Text, MSG[MSG.Row, 1], false) != 0)) | (Conversion.Val(MSG[MSG.Row, 2]) != Conversion.Val(MSG[MSG.Row, 64]))))
							{
								break;
							}
							DC_Main.RsQry = "Select A.*,B.IT_NAME FROM MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + mSG[mSG.Row, 58] + "' AND A.CO_BOOK = '" + mSG[mSG.Row, 59] + "' AND A.VCH_NO = '" + mSG[mSG.Row, 57] + "' AND A.OLD_SRNO = " + Conversions.ToString(Conversion.Val(mSG[mSG.Row, 60])) + " ";
							DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
							if (DC_Main.Rshlp.Rows.Count == 0)
							{
								DC_Main.RsQry = "SELECT D.AC_NAME as CustNameL,A.ORD_NO As VchNoL,A.DESIGN_NO As DesignL,B.IT_NAME As ItNameL,A.ITM_REMARK AS OrderDesc,A.ITM_SIZE as SizeL,E.ORD_DEL_DATE As DeliveryL,A.ITM_GWT As GrwtW,A.ORD_SRNO AS SrNoM,A.ORD_YRCD As YearL,A.ORD_DBCD As BookL,A.ITM_NWT As NetWtW,A.ORD_AC_CODE,C.AC_NAME As KrgrL,A.IT_CODE as ItCodeL,A.CO_YEAR As RepNoL,A.CO_BOOK As RepDbcdL,A.VCH_NO As RepNoL,A.OLD_SRNO As RepSrNoM FROM (((MFG_DETL AS A LEFT JOIN SL_ORD_DETL AS E ON A.CO_CODE = E.CO_CODE AND A.LC_CODE = E.LC_CODE AND A.ORD_YRCD = E.CO_YEAR AND A.ORD_DBCD = E.CO_BOOK AND A.ORD_NO = E.VCH_NO AND A.ORD_SRNO = E.OLD_SRNO) LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.KR_CODE = C.AC_CODE)LEFT JOIN AC_MAST AS D ON A.CO_CODE = D.CO_CODE AND A.ORD_AC_CODE = D.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND KR_CODE = '" + tAcCode.Text + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.BOOK_NAME = 'MFG MINO ISU' AND A.REP_ADJ = 'N' AND A.ORD_NO <> ''  ORDER BY A.VCH_NO,A.SR_NO";
								DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
								DC_Main.ColWidth = new double[20];
								DC_Main.ColWidth[0] = 180.0;
								DC_Main.ColWidth[1] = 80.0;
								DC_Main.ColWidth[2] = 90.0;
								DC_Main.ColWidth[3] = 150.0;
								DC_Main.ColWidth[4] = 150.0;
								DC_Main.ColWidth[5] = 80.0;
								DC_Main.ColWidth[6] = 100.0;
								DC_Main.ColWidth[7] = 0.0;
								DC_Main.ColWidth[8] = 60.0;
								DC_Main.ColWidth[9] = 100.0;
								DC_Main.ColWidth[10] = 70.0;
								DC_Main.ColWidth[11] = 80.0;
								DC_Main.ColWidth[12] = 0.0;
								DC_Main.ColWidth[13] = 150.0;
								DC_Main.ColWidth[14] = 0.0;
								DC_Main.ColWidth[15] = 0.0;
								DC_Main.ColWidth[16] = 0.0;
								DC_Main.ColWidth[17] = 0.0;
								DC_Main.ColWidth[18] = 0.0;
								DC_Main.HelpSelect = 1;
								((Form)MyProject.Forms.MS_HELP).ShowDialog();
								if (!DC_Main.HelpClose)
								{
									if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
									{
										TEXT_ENTRY.Text = DC_Main.ColValue[1];
										mSG[mSG.Row, 3] = DC_Main.ColValue[14];
										mSG[mSG.Row, 21] = DC_Main.ColValue[0];
										mSG[mSG.Row, 1] = DC_Main.ColValue[1];
										mSG[mSG.Row, 2] = DC_Main.ColValue[8];
										mSG[mSG.Row, 22] = DC_Main.ColValue[9];
										mSG[mSG.Row, 23] = DC_Main.ColValue[10];
										mSG[mSG.Row, 33] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[11]), "0.000");
										mSG[mSG.Row, 24] = DC_Main.ColValue[12];
										mSG[mSG.Row, 7] = Strings.Format((object)Conversion.Val(DC_Main.ColValue[7]), "0.000");
										mSG[mSG.Row, 5] = DC_Main.ColValue[2];
										mSG[mSG.Row, 6] = DC_Main.ColValue[5];
										mSG[mSG.Row, 51] = DC_Main.ColValue[4];
										mSG[mSG.Row, 58] = DC_Main.ColValue[15];
										mSG[mSG.Row, 59] = DC_Main.ColValue[16];
										mSG[mSG.Row, 57] = DC_Main.ColValue[17];
										mSG[mSG.Row, 60] = DC_Main.ColValue[18];
									}
									else
									{
										mSG[mSG.Row, 21] = "";
										mSG[mSG.Row, 1] = "";
										mSG[mSG.Row, 2] = "";
										mSG[mSG.Row, 22] = "";
										mSG[mSG.Row, 23] = "";
										mSG[mSG.Row, 24] = "";
										mSG[mSG.Row, 5] = "";
										mSG[mSG.Row, 6] = "";
										mSG[mSG.Row, 58] = "";
										mSG[mSG.Row, 59] = "";
										mSG[mSG.Row, 57] = "";
										mSG[mSG.Row, 60] = "";
									}
									((Control)TEXT_ENTRY).Focus();
								}
								return;
							}
							DC_Main.i = mSG.Row;
							int num4 = mSG.Rows - 1;
							DC_Main.X = 1;
							while (DC_Main.X <= num4)
							{
								if ((Operators.CompareString(TEXT_ENTRY.Text, MSG[DC_Main.X, 1], false) == 0) & (Conversion.Val(MSG[DC_Main.X, 2]) == Conversion.Val(MSG[DC_Main.i, 2])) & (mSG.Row != DC_Main.X))
								{
									Interaction.MsgBox((object)"Duplicate Entry...", (MsgBoxStyle)0, (object)null);
									mSG[DC_Main.i, 1] = "";
									mSG[DC_Main.i, 2] = "";
									mSG[DC_Main.i, 22] = "";
									mSG[DC_Main.i, 23] = "";
									mSG[DC_Main.i, 24] = "";
									mSG[DC_Main.i, 5] = "";
									mSG[DC_Main.i, 6] = "";
									mSG[DC_Main.i, 21] = "";
									mSG[DC_Main.i, 3] = "";
									mSG[DC_Main.i, 9] = "";
									mSG[DC_Main.i, 11] = "";
									mSG[DC_Main.i, 12] = "";
									mSG[DC_Main.i, 58] = "";
									mSG[DC_Main.i, 59] = "";
									mSG[DC_Main.i, 57] = "";
									mSG[DC_Main.i, 60] = "";
									return;
								}
								DC_Main.X++;
							}
							mSG[DC_Main.i, 64] = Conversions.ToString(Conversion.Val(MSG[MSG.Row, 2]));
							mSG[DC_Main.i, 55] = "M";
							mSG[DC_Main.i, 56] = "I";
							mSG[DC_Main.i, 3] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 61] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_CODE"], (object)""));
							mSG[DC_Main.i, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["IT_NAME"], (object)""));
							mSG[DC_Main.i, 4] = "";
							mSG[DC_Main.i, 5] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["DESIGN_NO"], (object)""));
							mSG[DC_Main.i, 6] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_SIZE"], (object)""));
							mSG[DC_Main.i, 8] = Conversions.ToString(DC_Main.Rshlp.Rows[0]["ITM_PCS"]);
							mSG[DC_Main.i, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							mSG[DC_Main.i, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[DC_Main.i, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_TOUCH"])), "0.00");
							mSG[mSG.Row, 58] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_YEAR"], (object)""));
							mSG[mSG.Row, 59] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["CO_BOOK"], (object)""));
							mSG[mSG.Row, 57] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["VCH_NO"], (object)""));
							mSG[mSG.Row, 60] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["OLD_SRNO"], (object)"")));
							mSG[DC_Main.i, 41] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["KR_NAME"], (object)""));
							mSG[DC_Main.i, 51] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["ITM_REMARK"], (object)""));
							mSG[DC_Main.i, 65] = "N";
							mSG[DC_Main.i, 7] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_GWT"])), "0.000");
							mSG[DC_Main.i, 32] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_OTH_WT"])), "0.000");
							mSG[DC_Main.i, 33] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["ITM_NWT"])), "0.000");
							MsgOldRow = 0;
							MSG_RowColChange(MSG, new EventArgs());
							MSG_TOT_FILL();
						}
						break;
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
									mSG[mSG.Row, 25] = DC_Main.ColValue[0];
								}
								((Control)TEXT_ENTRY).Focus();
							}
							return;
						}
						mSG[mSG.Row, 25] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["IT_NAME"], (object)""));
						break;
					case 9:
						if (Conversion.Val(TEXT_ENTRY.Text) == 0.0)
						{
							((Control)TEXT_ENTRY).Focus();
							return;
						}
						break;
					case 20:
						if (mSG.Row == mSG.Rows - 1)
						{
							MsgClear = true;
							mSG.Rows += 1;
							mSG.Row += 1;
							MsgClear = false;
							if ((Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0))
							{
								mSG.Col = 1;
							}
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

	private void MSG_TOT_FILL()
	{
		checked
		{
			if (!UpDown)
			{
				AcFineGl = 0.0;
				AcFineSl = 0.0;
				AxMSFlexGrid mSG_TOT = MSG_TOT;
				int num = MSG.Cols - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num)
				{
					mSG_TOT[0, DC_Main.M] = "";
					DC_Main.M++;
				}
				mSG_TOT[0, 25] = "Total :";
				int num2 = MSG.Rows - 1;
				DC_Main.M = 1;
				while (DC_Main.M <= num2)
				{
					mSG_TOT[0, 8] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 8]) + Conversion.Val(MSG[DC_Main.M, 8]))), "0");
					mSG_TOT[0, 7] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 7]) + Conversion.Val(MSG[DC_Main.M, 7]))), "0.000");
					mSG_TOT[0, 9] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 9]) + Conversion.Val(MSG[DC_Main.M, 9]))), "0.000");
					mSG_TOT[0, 11] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 11]) + Conversion.Val(MSG[DC_Main.M, 11]))), "0.000");
					mSG_TOT[0, 12] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 12]) + Conversion.Val(MSG[DC_Main.M, 12]))), "0.000");
					mSG_TOT[0, 14] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 14]) + Conversion.Val(MSG[DC_Main.M, 14]))), "0.000");
					mSG_TOT[0, 39] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 39]) + Conversion.Val(MSG[DC_Main.M, 39]))), "0.000");
					mSG_TOT[0, 44] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 44]) + Conversion.Val(MSG[DC_Main.M, 44]))), "0.00");
					mSG_TOT[0, 18] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 18]) + Conversion.Val(MSG[DC_Main.M, 18]))), "0.00");
					mSG_TOT[0, 19] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 19]) + Conversion.Val(MSG[DC_Main.M, 19]))), "0.00");
					mSG_TOT[0, 20] = Strings.Format((object)Conversion.Val((object)(Conversion.Val(mSG_TOT[0, 20]) + Conversion.Val(MSG[DC_Main.M, 20]))), "0.00");
					DC_Main.M++;
				}
				mSG_TOT = null;
			}
		}
	}

	private void TR_MFG_GHAT_REC_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
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
		chkWapp.Checked = false;
		PicImage.Image = null;
		DC_Main.MsImagePath = "";
		((Control)TEXT_ENTRY_2).Visible = false;
		((Control)TEXT_ENTRY).Visible = false;
		tMobile.Text = "";
		MSG_CLEAR();
		MSG2_CLEAR();
		DC_Main.RsQry = "SELECT SM_CODE,ENTRY_TYPE,NEXT_TRAN,LAST_TRAN,STK_ISU,STK_REC FROM MFG_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			LastPorcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["LAST_TRAN"]);
			CurProcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["ENTRY_TYPE"]);
			MsPorcessType = Conversions.ToString(DC_Main.Tbl.Rows[0]["ENTRY_TYPE"]);
			NextProcess = Conversions.ToString(DC_Main.Tbl.Rows[0]["NEXT_TRAN"]);
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
		EntryMode = "A";
		((Control)BtnSave).Enabled = true;
		((Control)tVchNo).Focus();
	}

	private void DISPLAY_DATA()
	{
		DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'";
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
				tAcCode.Text = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["KR_CODE"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + tAcCode.Text + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
				}
				MSG2_TOTAL[0, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["NET_AMT"]), "0.00");
				MSG2_TOTAL[1, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CHQ_AMT"]), "0.00");
				MSG2_TOTAL[3, 3] = Strings.Format(RuntimeHelpers.GetObjectValue(RsData.Rows[0]["CASH_AMT"]), "0.00");
				AxMSFlexGrid mSG2_TOTAL = MSG2_TOTAL;
				DataRow dataRow;
				object Value = RuntimeHelpers.GetObjectValue((dataRow = RsData.Rows[0])["BILL_OS"]);
				double num = DC_Main.Fnv(ref Value);
				dataRow["BILL_OS"] = RuntimeHelpers.GetObjectValue(Value);
				mSG2_TOTAL[5, 3] = Strings.Format((object)num, "0.00");
				MSG2_TOTAL[1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["BANK_AC"], (object)""));
				MSG2_TOTAL[1, 2] = Conversions.ToString(Operators.ConcatenateObject(RsData.Rows[0]["CHQ_NO"], (object)""));
				DC_Main.RsQry = "SELECT AC_NAME FROM AC_MAST WHERE CO_CODE ='" + DC_Main.MCo_code + "' AND AC_CODE = '" + MSG2_TOTAL[1, 4] + "'";
				DC_Main.RsAc = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.RsAc.Rows.Count > 0)
				{
					MSG2_TOTAL[1, 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.RsAc.Rows[0]["AC_NAME"], (object)""));
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
				DC_Main.RsQry = "SELECT A.*,B.IT_NAME As ItName,B.RATE_TYPE,B.IT_TYPE,C.AC_NAME As OrdAcName FROM (MFG_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.ORD_AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND  A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND A.VCH_NO = '" + tVchNo.Text + "' ORDER BY A.SR_NO";
				RsDetl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.i = 0;
				AxMSFlexGrid mSG = MSG;
				while (DC_Main.i < RsDetl.Rows.Count)
				{
					mSG[DC_Main.i + 1, 0] = Conversions.ToString(DC_Main.i + 1);
					mSG[DC_Main.i + 1, 42] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["OLD_SRNO"]);
					mSG[DC_Main.i + 1, 3] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 61] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ISU_IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 1] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_NO"], (object)""));
					mSG[DC_Main.i + 1, 2] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_SRNO"], (object)"")));
					mSG[DC_Main.i + 1, 64] = Conversions.ToString(Conversion.Val(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_SRNO"], (object)"")));
					mSG[DC_Main.i + 1, 25] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ItName"], (object)""));
					mSG[DC_Main.i + 1, 51] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_REMARK"], (object)""));
					mSG[DC_Main.i + 1, 4] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["TAG_NO"], (object)""));
					mSG[DC_Main.i + 1, 5] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["DESIGN_NO"], (object)""));
					mSG[DC_Main.i + 1, 52] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DESIGN_SRNO"])), "0");
					mSG[DC_Main.i + 1, 6] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ITM_SIZE"], (object)""));
					if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
					{
						mSG[DC_Main.i + 1, 7] = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])) - Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_MINO_WT"]))), "0.000");
					}
					mSG[DC_Main.i + 1, 8] = Conversions.ToString(RsDetl.Rows[DC_Main.i]["ITM_PCS"]);
					mSG[DC_Main.i + 1, 9] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 47] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GWT"])), "0.000");
					mSG[DC_Main.i + 1, 11] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_OTH_WT"])), "0.000");
					mSG[DC_Main.i + 1, 12] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 48] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_NWT"])), "0.000");
					mSG[DC_Main.i + 1, 13] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 14] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_GHT_WT"])), "0.000");
					mSG[DC_Main.i + 1, 26] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DM_GHT"])), "0.000");
					mSG[DC_Main.i + 1, 27] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["TOT_GHT"])), "0.000");
					mSG[DC_Main.i + 1, 16] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["RTN_GHIS"])), "0.000");
					mSG[DC_Main.i + 1, 15] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["RTN_CHOL"])), "0.000");
					mSG[DC_Main.i + 1, 28] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["MTRL_IT_CODE"], (object)""));
					mSG[DC_Main.i + 1, 29] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["MTRL_WT"])), "0.000");
					mSG[DC_Main.i + 1, 10] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["KR_MINO_WT"])), "0.000");
					mSG[DC_Main.i + 1, 37] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 49] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_TOUCH"])), "0.00");
					mSG[DC_Main.i + 1, 38] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 50] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_WEST_PRC"])), "0.00");
					mSG[DC_Main.i + 1, 39] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_FINE"])), "0.000");
					mSG[DC_Main.i + 1, 30] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["LBR_TYPE"], (object)""));
					mSG[DC_Main.i + 1, 17] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 18] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["LBR_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 19] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["OTH_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 43] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_RATE"])), "0.00");
					mSG[DC_Main.i + 1, 44] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["ITM_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 20] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["NET_AMT"])), "0.00");
					mSG[DC_Main.i + 1, 58] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 59] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 57] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_NO"], (object)""));
					mSG[DC_Main.i + 1, 60] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["REP_SRNO"])), "0");
					mSG[DC_Main.i + 1, 65] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["REP_ADJ"], (object)""));
					mSG[DC_Main.i + 1, 62] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DM_PCS"])), "0");
					mSG[DC_Main.i + 1, 63] = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsDetl.Rows[DC_Main.i]["DM_WT"])), "0.00");
					mSG[DC_Main.i + 1, 41] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["KR_NAME"], (object)""));
					mSG[DC_Main.i + 1, 21] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["OrdAcName"], (object)""));
					mSG[DC_Main.i + 1, 22] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_YRCD"], (object)""));
					mSG[DC_Main.i + 1, 23] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_DBCD"], (object)""));
					mSG[DC_Main.i + 1, 24] = Conversions.ToString(Operators.ConcatenateObject(RsDetl.Rows[DC_Main.i]["ORD_AC_CODE"], (object)""));
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
				MSG_TOT_FILL();
				MsgOldRow = 0;
				MSG_RowColChange(MSG, new EventArgs());
				OldValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 18]);
				NewValTot = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 19]) + Conversion.Val(MSG_TOT[0, 18]);
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

	private void TR_MFG_GHAT_REC_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void TR_MFG_GHAT_REC_KeyPress(object sender, KeyPressEventArgs e)
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
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f96: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_019e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_044a: Unknown result type (might be due to invalid IL or missing references)
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
						if ((Operators.CompareString(DC_Main.MsSoftNoUse, "Y", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save New Entry Because Your lIcence Has been Expired Please Renew lIcence....", (MsgBoxStyle)0, (object)null);
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MsEmpCodeMendetry, "Y", false) == 0) & (Operators.CompareString(tEmpCode.Text, "", false) == 0))
						{
							Interaction.MsgBox((object)"Please Select Employee Code and Try......", (MsgBoxStyle)0, (object)null);
							((Control)tEmpCode).Focus();
							goto end_IL_0001;
						}
						if ((Operators.CompareString(DC_Main.MCo_Type, "B", false) == 0) & (Operators.CompareString(EntryMode, "A", false) == 0))
						{
							Interaction.MsgBox((object)"You Cant Save This Voucher Becouse This Company Type is B......", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
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
						if (Operators.CompareString(UsUPdate, "Y", false) != 0 && ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0)))
						{
							Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							goto end_IL_0001;
						}
						if (Operators.CompareString(tAcCode.Text, "", false) == 0)
						{
							Interaction.MsgBox((object)"Please Insert Party and try", (MsgBoxStyle)0, (object)null);
							((Control)BtnSave).Enabled = true;
							((Control)tAcCode).Focus();
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
						DC_Main.MsTagVchSrnoUpdate = false;
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
						if ((Operators.CompareString(EntryMode, "E", false) == 0) & (Operators.CompareString(FormMainBook, "CON PUR", false) == 0))
						{
							DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ADJ_GWT = APR_DETL.ADJ_GWT - B.ITM_GWT,APR_DETL.ADJ_NWT = APR_DETL.ADJ_NWT - B.ITM_NWT FROM APR_DETL,PR_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.CONSI_YRCD  AND APR_DETL.CO_BOOK = B.CONSI_DBCD AND APR_DETL.VCH_NO = B.CONSI_NO AND APR_DETL.OLD_SRNO = B.CONSI_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND  CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
						if (Conversion.Val(MSG_TOT[0, 8]) + Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 20]) != 0.0)
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
							dataRow2["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
							dataRow2["NET_AMT"] = Conversion.Val(MSG2_TOTAL[0, 3]);
							dataRow2["TAX_CODE"] = "";
							dataRow2["TAX_PRC"] = 0;
							dataRow2["TAX_AMT"] = 0;
							dataRow2["AC_GST_TYPE"] = "L";
							dataRow2["IGST_TAX"] = 0;
							dataRow2["SGST_TAX"] = 0;
							dataRow2["CGST_TAX"] = 0;
							dataRow2["GR_WT"] = Conversion.Val(MSG_TOT[0, 9]);
							dataRow2["NET_WT"] = Conversion.Val(MSG_TOT[0, 12]);
							dataRow2["FINE_WT"] = Conversion.Val(MSG_TOT[0, 39]);
							dataRow2["LBR_AMT"] = Conversion.Val(MSG_TOT[0, 18]);
							dataRow2["OTH_AMT"] = Conversion.Val(MSG_TOT[0, 19]);
							dataRow2["ROF_AMT"] = 0;
							dataRow2["TOT_AMT"] = 0;
							dataRow2["CASH_AMT"] = Conversion.Val(MSG2_TOTAL[3, 3]);
							dataRow2["CHQ_AMT"] = Conversion.Val(MSG2_TOTAL[1, 3]);
							dataRow2["CARD_AMT"] = 0;
							dataRow2["CARD_AC"] = "";
							dataRow2["BANK_AC"] = MSG2_TOTAL[1, 4];
							dataRow2["CHQ_NO"] = MSG2_TOTAL[1, 2];
							dataRow2["KASAR_AMT"] = 0;
							dataRow2["BILL_OS"] = Conversion.Val(MSG2_TOTAL[5, 3]);
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
						int num3 = MSG.Rows - 1;
						DC_Main.i = 1;
						while (DC_Main.i <= num3)
						{
							AxMSFlexGrid mSG = MSG;
							if (((Operators.CompareString(mSG[DC_Main.i, 3], "", false) != 0) & (Operators.CompareString(mSG[DC_Main.i, 4], "", false) != 0)) | (Conversion.Val(mSG[DC_Main.i, 9]) + Conversion.Val(mSG[DC_Main.i, 18]) + Conversion.Val(mSG[DC_Main.i, 19]) != 0.0))
							{
								dataRow3["CO_CODE"] = DC_Main.MCo_code;
								dataRow3["LC_CODE"] = DC_Main.MLc_code;
								dataRow3["CO_YEAR"] = DC_Main.MCo_year;
								dataRow3["CO_BOOK"] = DC_Main.MCo_Book;
								dataRow3["VCH_NO"] = tVchNo.Text;
								dataRow3["VCH_DATE"] = mVchDate.Text;
								dataRow3["HD_VCH_NO"] = tHdVchNo.Text;
								dataRow3["AC_CODE"] = "";
								dataRow3["KR_CODE"] = tAcCode.Text;
								dataRow3["VCH_TYPE"] = FormBookSname;
								dataRow3["INOUT_TYPE"] = FormBookInOut;
								dataRow3["ENTRY_TYPE"] = MsPorcessType;
								dataRow3["BOOK_NAME"] = FormMainBook;
								dataRow3["SR_NO"] = Conversion.Val(mSG[DC_Main.i, 0]);
								dataRow3["OLD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 42]);
								dataRow3["ORD_NO"] = mSG[DC_Main.i, 1];
								dataRow3["ORD_SRNO"] = Conversion.Val(mSG[DC_Main.i, 2]);
								dataRow3["IT_CODE"] = mSG[DC_Main.i, 3];
								dataRow3["ISU_IT_CODE"] = mSG[DC_Main.i, 3];
								dataRow3["ITM_REMARK"] = mSG[DC_Main.i, 51];
								dataRow3["TAG_NO"] = mSG[DC_Main.i, 4];
								dataRow3["DESIGN_NO"] = mSG[DC_Main.i, 5];
								dataRow3["DESIGN_SRNO"] = Conversion.Val(mSG[DC_Main.i, 52]);
								dataRow3["ITM_SIZE"] = mSG[DC_Main.i, 6];
								dataRow3["ITM_PCS"] = Conversion.Val(mSG[DC_Main.i, 8]);
								dataRow3["ITM_GWT"] = Conversion.Val(mSG[DC_Main.i, 9]);
								dataRow3["ITM_OTH_WT"] = Conversion.Val(mSG[DC_Main.i, 11]);
								dataRow3["ITM_NWT"] = Conversion.Val(mSG[DC_Main.i, 12]);
								dataRow3["ITM_GHT_PRC"] = Conversion.Val(mSG[DC_Main.i, 13]);
								dataRow3["ITM_GHT_WT"] = Conversion.Val(mSG[DC_Main.i, 14]);
								dataRow3["DM_GHT"] = Conversion.Val(mSG[DC_Main.i, 26]);
								dataRow3["TOT_GHT"] = Conversion.Val(mSG[DC_Main.i, 27]);
								dataRow3["RTN_GHIS"] = Conversion.Val(mSG[DC_Main.i, 16]);
								dataRow3["RTN_CHOL"] = Conversion.Val(mSG[DC_Main.i, 15]);
								dataRow3["MTRL_IT_CODE"] = mSG[DC_Main.i, 28];
								dataRow3["MTRL_WT"] = Conversion.Val(mSG[DC_Main.i, 29]);
								dataRow3["ITM_TOUCH"] = Conversion.Val(mSG[DC_Main.i, 37]);
								dataRow3["ITM_WEST_PRC"] = Conversion.Val(mSG[DC_Main.i, 38]);
								dataRow3["ITM_FINE"] = Conversion.Val(mSG[DC_Main.i, 39]);
								dataRow3["KR_GHAT_WT"] = 0;
								dataRow3["KR_KUNDAN_WT"] = 0;
								dataRow3["KR_WAX_WT"] = 0;
								dataRow3["FTNG_NWT"] = 0;
								dataRow3["FTNG_TOUCH"] = 0;
								dataRow3["FTNG_FINE"] = 0;
								dataRow3["LBR_TYPE"] = mSG[DC_Main.i, 30];
								dataRow3["LBR_RATE"] = Conversion.Val(mSG[DC_Main.i, 17]);
								dataRow3["LBR_AMT"] = Conversion.Val(mSG[DC_Main.i, 18]);
								dataRow3["OTH_AMT"] = Conversion.Val(mSG[DC_Main.i, 19]);
								dataRow3["ITM_RATE"] = Conversion.Val(mSG[DC_Main.i, 43]);
								dataRow3["ITM_AMT"] = Conversion.Val(mSG[DC_Main.i, 44]);
								dataRow3["NET_AMT"] = Conversion.Val(mSG[DC_Main.i, 20]);
								dataRow3["DM_PCS"] = Conversion.Val(mSG[DC_Main.i, 62]);
								dataRow3["DM_WT"] = Conversion.Val(mSG[DC_Main.i, 63]);
								dataRow3["KR_MINO_WT"] = Conversion.Val(mSG[DC_Main.i, 10]);
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
								dataRow3["REP_ADJ"] = mSG[DC_Main.i, 65];
								dataRow3["REP_YRCD"] = mSG[DC_Main.i, 58];
								dataRow3["REP_DBCD"] = mSG[DC_Main.i, 59];
								dataRow3["REP_NO"] = mSG[DC_Main.i, 57];
								dataRow3["REP_SRNO"] = Conversion.Val(mSG[DC_Main.i, 60]);
								dataRow3["REP_AC_CODE"] = tAcCode.Text;
								dataRow3["ORD_YRCD"] = mSG[DC_Main.i, 22];
								dataRow3["ORD_DBCD"] = mSG[DC_Main.i, 23];
								dataRow3["ORD_AC_CODE"] = mSG[DC_Main.i, 24];
								dataRow3["MAIN_USER"] = MainUser;
								dataRow3["VCH_TIME"] = mVchDate.Text + " " + mTime.Text;
								RsDetl.Rows.Add(dataRow3);
								((DbDataAdapter)(object)DC_Main.Da).Update(RsDetl);
								RsDetl.Clear();
							}
							mSG = null;
							DC_Main.i++;
						}
						WappMsg = ("Dear : " + tAcName.Text + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[0, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3])) + "  Thanks Regard  " + DC_Main.MCo_Name) ?? "";
						AdminWappMsg = tAcName.Text + " Book = " + DC_Main.MCo_Book + " Bill No = " + tVchNo.Text + " Total :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[0, 3])) + " Os Amt :" + Conversions.ToString(Conversion.Val(MSG2_TOTAL[5, 3]));
						if (Operators.CompareString(EntryMode, "E", false) == 0)
						{
							WappMsg = "";
							AdminWappMsg = "";
						}
						WappAcName = tAcName.Text;
						WappMobile = tMobile.Text;
						if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
						{
							DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'Y' FROM APR_DETL,MFG_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.REP_YRCD  AND APR_DETL.CO_BOOK = B.REP_DBCD AND APR_DETL.VCH_NO = B.REP_NO AND APR_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
						{
							DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'Y' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
						{
							DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'Y' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
						}
						if (Operators.CompareString(DC_Main.MsMfgWithLedger, "Y", false) == 0)
						{
							DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							if (Operators.CompareString(FormBookInOut, "I", false) == 0)
							{
								Ac_Ledr.Mfg_Rec_Ledr(DC_Main.MCo_Book, tVchNo.Text);
							}
							if (Operators.CompareString(FormBookInOut, "O", false) == 0)
							{
								Ac_Ledr.Mfg_Isu_Ledr(DC_Main.MCo_Book, tVchNo.Text);
							}
						}
						else
						{
							DC_Main.RsQry = "DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
							{
								Ac_Tax.Ghat_Rec_Mfg(DC_Main.MCo_Book, tVchNo.Text);
							}
							else if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
							{
								Ac_Tax.Mino_Isu_Mfg(DC_Main.MCo_Book, tVchNo.Text);
							}
							else if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
							{
								Ac_Tax.Mino_Rec_Mfg(DC_Main.MCo_Book, tVchNo.Text);
							}
						}
						if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) == 0)
						{
							DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
							DC_Main.ExeQuteDc(DC_Main.RsQry);
							Ac_Stock.Mfg_Stk_Rec_With_Ord(DC_Main.MCo_Book, tVchNo.Text);
						}
						Ac_Tax.Vch_Remark(DC_Main.MCo_Book, tVchNo.Text, 0);
						if (Operators.CompareString(FormVchNo, "", false) != 0)
						{
							CLEAR_DATA();
							((Form)this).Close();
							goto end_IL_0001;
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
						goto end_IL_0001;
					}
					case 8094:
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
				try0001_dispatch = 8094;
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
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Invalid comparison between Unknown and I4
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_0764: Unknown result type (might be due to invalid IL or missing references)
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
		DC_Main.RsQry = "SELECT A.VCH_NO,A.CO_YEAR,A.CO_BOOK,B.BOOK_NAME  FROM MFG_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.REP_YRCD = '" + DC_Main.MCo_year + "' AND A.REP_DBCD = '" + DC_Main.MCo_Book + "' AND A.REP_NO = '" + tVchNo.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"You Cant Delete this Voucher Because This Voucher Linkd With ", DC_Main.Rshlp.Rows[0]["VCH_NO"]), (object)"  Voucher No and Book Is "), DC_Main.Rshlp.Rows[0]["BOOK_NAME"]), (object)" Item .... First Delete It.."), (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This Voucher now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "INSERT INTO DELETE_DATA(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,DELETE_DATE,VCH_TYPE,VCH_TIME,DELETE_TIME,  BOOK_NAME,AC_CODE,AC_NAME,VCH_VAL_DR,VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,HD_VCH_NO,MAIN_USER,DELETE_USER,VCH_DESC)  SELECT A.CO_CODE,A.LC_CODE,A.CO_YEAR,A.CO_BOOK,VCH_NO,SR_NO,VCH_DATE,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "',B.BOOK_SNAME,VCH_TIME,'" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy HH:mm:ss") + "',  B.BOOK_NAME,A.AC_CODE,C.AC_NAME,0,0,IT_TYPE,ITM_FINE,0,HD_VCH_NO,A.MAIN_USER,'" + DC_Main.MCo_User + "','ItCode' + '/' + IT_CODE FROM (MFG_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK)  LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
			{
				DC_Main.RsQry = "UPDATE APR_DETL SET APR_DETL.ISU_REC = 'N' FROM APR_DETL,MFG_DETL AS B WHERE APR_DETL.CO_CODE = B.CO_CODE AND APR_DETL.LC_CODE = B.LC_CODE AND APR_DETL.CO_YEAR = B.REP_YRCD  AND APR_DETL.CO_BOOK = B.REP_DBCD AND APR_DETL.VCH_NO = B.REP_NO AND APR_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			if (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0)
			{
				DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
			{
				DC_Main.RsQry = "UPDATE MFG_DETL SET MFG_DETL.REP_ADJ = 'N' FROM MFG_DETL,MFG_DETL AS B WHERE MFG_DETL.CO_CODE = B.CO_CODE AND MFG_DETL.LC_CODE = B.LC_CODE AND MFG_DETL.CO_YEAR = B.REP_YRCD  AND MFG_DETL.CO_BOOK = B.REP_DBCD AND MFG_DETL.VCH_NO = B.REP_NO AND MFG_DETL.OLD_SRNO = B.REP_SRNO AND B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.CO_BOOK = '" + DC_Main.MCo_Book + "' AND B.VCH_NO = '" + tVchNo.Text + "' ";
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			DC_Main.ExeQuteDc("DELETE FROM REMARK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM TEMP_BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND  VCH_NO = '" + tHdVchNo.Text + "' ");
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.RsQry = "DELETE FROM MAIN_STOCK WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ";
			DC_Main.ExeQuteDc(DC_Main.RsQry);
			DC_Main.ExeQuteDc("DELETE FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "' ");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			DC_Main.ExeQuteDc("DELETE FROM MFG_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND CO_BOOK = '" + DC_Main.MCo_Book + "' AND VCH_NO = '" + tVchNo.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			CustOpAmt = 0.0;
			CustClAmt = 0.0;
			CustOpGold = 0.0;
			CustClGold = 0.0;
			CustOpSilver = 0.0;
			CustClSilver = 0.0;
		}
	}

	private void TR_MFG_GHAT_REC_KeyDown(object sender, KeyEventArgs e)
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
		if (Operators.CompareString(DC_Main.MsPrintOpt, "CANCEL", false) == 0)
		{
			return;
		}
		string rptName;
		if ((Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0) | (Operators.CompareString(FormMainBook, "MFG MINO ISU", false) == 0))
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MfgMinoIsuRec.RPT";
			rptName = "MfgGhatRec";
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MfgGhatRec.RPT";
			rptName = "MfgGhatRec";
		}
		Cr.SelectionFormula = "{MFG_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MFG_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {MFG_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MFG_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {MFG_DATA.VCH_NO} = '" + CurPrnVch + "'";
		Cr[(short)2] = ("OpAmt = " + Strings.Format((object)CustOpAmt, "0.00")) ?? "";
		Cr[(short)3] = ("ClAmt = " + Strings.Format((object)CustClAmt, "0.00")) ?? "";
		Cr[(short)4] = ("OpGold = " + Strings.Format((object)CustOpGold, "0.000")) ?? "";
		Cr[(short)5] = ("ClGold = " + Strings.Format((object)CustClGold, "0.000")) ?? "";
		Cr[(short)6] = ("OpSilver = " + Strings.Format((object)CustOpSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
		Cr[(short)7] = ("ClSilver = " + Strings.Format((object)CustClSilver, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")))) ?? "";
		if (chkWapp.Checked)
		{
			DC_Main.MsCustWappNo = DC_Main.MsCountryId + tMobile.Text;
			DC_Main.RptName = rptName;
			DC_Main.MsWappOpAmt = Conversions.ToDouble(Strings.Format((object)CustOpAmt, "0.00"));
			DC_Main.MsWappClAmt = Conversions.ToDouble(Strings.Format((object)CustClAmt, "0.00"));
			DC_Main.MsWappOpGlFine = Conversions.ToDouble(Strings.Format((object)CustOpGold, "0.00"));
			DC_Main.MsWappClGlFine = Conversions.ToDouble(Strings.Format((object)CustClGold, "0.00"));
			DC_Main.MsWappOpSlFine = Conversions.ToDouble(Strings.Format((object)CustOpSilver, "0.00"));
			DC_Main.MsWappClSlFine = Conversions.ToDouble(Strings.Format((object)CustClSilver, "0.00"));
			DC_Main.RptFormula = "{MFG_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MFG_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {MFG_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MFG_DATA.CO_BOOK} = '" + DC_Main.MCo_Book + "' AND {MFG_DATA.VCH_NO} = '" + CurPrnVch + "'";
			DC_Main.MsWappPrintType = "KrIsu";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
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
		CustOpAmt = 0.0;
		CustClAmt = 0.0;
		CustOpGold = 0.0;
		CustClGold = 0.0;
		CustOpSilver = 0.0;
		CustClSilver = 0.0;
		CLEAR_DATA();
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void TR_MFG_GHAT_REC_Activated(object sender, EventArgs e)
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
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.VCH_NO As VchNoL,replace(convert(NVARCHAR,A.VCH_DATE, 103), ' ', '/') AS VchDateL,B.AC_NAME As PartyNameL,BILL_NO As RefNoL,A.VCH_DESC As VchDescL,A.MAIN_USER As UserL,SUM(C.ITM_GWT) As GrwtW FROM (MFG_DATA AS A LEFT JOIN MFG_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.CO_YEAR = C.CO_YEAR AND A.CO_BOOK = C.CO_BOOK AND A.VCH_NO = C.VCH_NO)LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK = '" + DC_Main.MCo_Book + "'  GROUP BY A.VCH_NO,A.VCH_DATE,B.AC_NAME,BILL_NO,A.VCH_DESC,A.MAIN_USER ORDER BY A.VCH_NO";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[8];
		DC_Main.ColWidth[0] = 100.0;
		DC_Main.ColWidth[1] = 120.0;
		DC_Main.ColWidth[2] = 300.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.ColWidth[4] = 250.0;
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
			if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
			{
				((Control)tMobile).Focus();
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

	private void TR_MFG_GHAT_REC_Closed(object sender, EventArgs e)
	{
		FormVchNo = "";
		DC_Main.MsTagVchSrnoUpdate = false;
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
				DC_Main.MsGrCode = "10";
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
		if (Operators.CompareString(FormMainBook, "CON PUR", false) == 0)
		{
			MSG.Col = 2;
		}
		else
		{
			MSG.Col = 1;
		}
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
			DC_Main.RsQry = "SELECT VCH_DESC As VchDescL FROM KR_DATA WHERE VCH_DESC <> '' AND LEN(VCH_DESC) < " + Conversions.ToString(DC_Main.MsVchDescHelpLenth) + " AND VCH_DESC <> '' GROUP BY VCH_DESC   ORDER BY VCH_DESC";
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
		mSG2_TOTAL.Rows = 6;
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
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					if (DC_Main.MsCoTheme == 3)
					{
						AxMSFlexGrid obj3 = mSG2_TOTAL;
						object? obj4 = colorConverter.ConvertFromString("233, 235, 240");
						obj3.CellBackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
					}
					else if (DC_Main.MsCoTheme == 4)
					{
						AxMSFlexGrid obj5 = mSG2_TOTAL;
						object? obj6 = colorConverter.ConvertFromString("Cornsilk");
						obj5.CellBackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
					}
					else
					{
						AxMSFlexGrid obj7 = mSG2_TOTAL;
						object? obj8 = colorConverter.ConvertFromString("255, 224, 192");
						obj7.CellBackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
					}
					break;
				case 1:
				case 2:
				case 3:
				case 4:
				{
					mSG2_TOTAL.Col = mSG2_TOTAL.FixedCols;
					mSG2_TOTAL.RowSel = DC_Main.i;
					mSG2_TOTAL.ColSel = mSG2_TOTAL.Cols - 1;
					AxMSFlexGrid obj = mSG2_TOTAL;
					object? obj2 = colorConverter.ConvertFromString("DarkBlue");
					obj.CellForeColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
					break;
				}
				}
				DC_Main.i++;
			}
			while (DC_Main.i <= 5);
			mSG2_TOTAL[0, 0] = "Net Amt : ";
			mSG2_TOTAL[1, 0] = "Cheque Amt : ";
			mSG2_TOTAL[2, 0] = "Card Amt : ";
			mSG2_TOTAL[3, 0] = "Cash Amt : ";
			mSG2_TOTAL[4, 0] = "Kasar Amt : ";
			mSG2_TOTAL[5, 0] = "Os Amt : ";
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5))
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
				if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 2))
				{
					TEXT_ENTRY_2.Text = mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col];
				}
				else
				{
					TEXT_ENTRY_2.Text = Strings.Format((object)Conversion.Val(mSG2_TOTAL[mSG2_TOTAL.Row, mSG2_TOTAL.Col]), "0.00");
				}
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5))
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
				if ((mSG2_TOTAL.Row == 0) | (mSG2_TOTAL.Row == 5))
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
			if ((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 2))
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
					if (!((mSG2_TOTAL.Row == 1) | (mSG2_TOTAL.Row == 2)) || Operators.CompareString(TEXT_ENTRY_2.Text, "", false) == 0)
					{
						break;
					}
					DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_NAME = '" + TEXT_ENTRY_2.Text + "'";
					DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (DC_Main.Rshlp.Rows.Count == 0)
					{
						if (mSG2_TOTAL.Row == 1)
						{
							DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE as AcCodeL, B.AC_GR_NAME AS GrNameL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_GR in( '02','22','03','23')  ORDER BY A.AC_NAME";
						}
						else if (mSG2_TOTAL.Row == 2)
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
					break;
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
					case 1:
					case 2:
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
					case 4:
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
		if (Conversion.Val(MSG_TOT[0, 20]) != 0.0)
		{
			mSG2_TOTAL[0, 3] = Strings.Format((object)Math.Round(Conversion.Val(MSG_TOT[0, 20]), 0), "0.00");
			mSG2_TOTAL[5, 3] = Strings.Format((object)(Conversion.Val(mSG2_TOTAL[0, 3]) - Conversion.Val(mSG2_TOTAL[1, 3]) - Conversion.Val(mSG2_TOTAL[2, 3]) - Conversion.Val(mSG2_TOTAL[3, 3]) - Conversion.Val(mSG2_TOTAL[4, 3])), "0.00");
		}
		else
		{
			mSG2_TOTAL[0, 3] = "";
			mSG2_TOTAL[5, 3] = "";
		}
		if (Operators.CompareString(FormMainBook, "MFG GHAT REC", false) == 0)
		{
			AcFineGl = Conversion.Val(MSG_TOT[0, 12]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 15]);
		}
		else if (Operators.CompareString(FormMainBook, "MFG MINO REC", false) == 0)
		{
			AcFineGl = Conversion.Val(MSG_TOT[0, 7]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 15]);
		}
		else
		{
			AcFineGl = Conversion.Val(MSG_TOT[0, 9]) + Conversion.Val(MSG_TOT[0, 16]) + Conversion.Val(MSG_TOT[0, 14]) + Conversion.Val(MSG_TOT[0, 15]);
		}
		if (Operators.CompareString(FormBookInOut, "O", false) == 0)
		{
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[5, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[5, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[5, 3]);
			}
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
		}
		else
		{
			if (CustOpAmt > 0.0)
			{
				CustClAmt = CustOpAmt + Conversion.Val(mSG2_TOTAL[5, 3]);
			}
			else if (CustOpAmt < 0.0)
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[5, 3]) - Math.Abs(CustOpAmt);
			}
			else
			{
				CustClAmt = Conversion.Val(mSG2_TOTAL[5, 3]);
			}
			if (AcFineGl != 0.0)
			{
				if (CustOpGold > 0.0)
				{
					CustClGold = CustOpGold + AcFineGl;
				}
				else if (CustOpGold < 0.0)
				{
					CustClGold = CustOpGold + AcFineGl;
				}
				else
				{
					CustClGold = AcFineGl;
				}
			}
			else
			{
				CustClGold = CustOpGold;
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
		if ((int)e.KeyCode == 13)
		{
			MSG.Col = 1;
			MSG.Row = 1;
			MSG_EnterCell(MSG, new EventArgs());
			((Control)TEXT_ENTRY).Focus();
		}
	}

	private void MSG_RowColChange(object sender, EventArgs e)
	{
		if (MSG.Row != 0 && ((MsgOldRow != MSG.Row) & !MsgClear))
		{
			MsgOldRow = MSG.Row;
			tItRemark.Text = MSG[MSG.Row, 51];
		}
	}

	private void MSG_PR_Scroll(object sender, EventArgs e)
	{
		if (MSG_TOT.LeftCol != MSG.LeftCol)
		{
			MSG_TOT.LeftCol = MSG.LeftCol;
			MSG_TOT.ScrollTrack = MSG.LeftCol != 0;
		}
	}

	private void TR_MFG_GHAT_REC_KeyUp(object sender, KeyEventArgs e)
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

	private void tConsiNo_TextChanged(object sender, EventArgs e)
	{
	}
}
