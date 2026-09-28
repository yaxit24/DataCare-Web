using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_WHATSAPP : Form
{
	public enum GridViewColumnType
	{
		TextBox,
		InvisibleTextBoxCell
	}

	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlBotam")]
	private FlowLayoutPanel _PnlBotam;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private SimpleButton _BtnDelete;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("CboSmsType")]
	private ComboBox _CboSmsType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFromOs")]
	private TextBox _nFromOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nToOs")]
	private TextBox _nToOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnOk")]
	private QButton _btnOk;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobileNo")]
	private TextBox _tMobileNo;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSmsSend")]
	private QButton _BtnSmsSend;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAc")]
	private SimpleButton _BtnAc;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnMemb")]
	private SimpleButton _BtnMemb;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkAllRow")]
	private CheckBox _chkAllRow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExlImport")]
	private QButton _btnExlImport;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboBarth")]
	private ComboBox _cboBarth;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExcel")]
	private SimpleButton _BtnExcel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTanslat")]
	private SimpleButton _BtnTanslat;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private System.Windows.Forms.Timer _Timer1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnWappInstall")]
	private QButton _btnWappInstall;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkBoxHeadLess")]
	private CheckBox _chkBoxHeadLess;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnAcOs")]
	private QButton _btnAcOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboMsgType")]
	private ComboBox _cboMsgType;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGoldRate")]
	private QButton _btnGoldRate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnLogout")]
	private QButton _BtnLogout;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnQuit")]
	private QButton _btnQuit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnBrowse")]
	private QButton _btnBrowse;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnClear")]
	private QButton _btnClear;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnDelyTime")]
	private SimpleButton _btnDelyTime;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnHide")]
	private SimpleButton _btnHide;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nFromRow")]
	private TextBox _nFromRow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("nToRow")]
	private TextBox _nToRow;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnTextMsg")]
	private SimpleButton _btnTextMsg;

	public static Module_WhatsApp whatsApp;

	private System.Windows.Forms.Timer authTimer;

	private Image _AUTH_QR;

	private int sec;

	private string _translationSpeakUrl;

	private Control CurActCtrl;

	private double ColCon;

	private DataTable RsMast;

	private string EntryMode;

	private bool MsgLess;

	private bool OsMsg;

	private bool SchmOsMsg;

	private bool RateMsg;

	private bool ExelMsg;

	private DateTime WappEndDate;

	private string RateSend;

	private string theWebSite;

	private string ScelectMo;

	private string SendDetl;

	private int SendRow;

	private int TotSms;

	private string[] AryGroup;

	private int MaxPages;

	private int LastRow;

	private int Pages;

	private bool WhatsappLoad;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	internal virtual FlowLayoutPanel PnlBotam
	{
		[CompilerGenerated]
		get
		{
			return _PnlBotam;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = PnlBotam_DoubleClick;
			FlowLayoutPanel val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_PnlBotam = value;
			val = _PnlBotam;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblBook")]
	private virtual Label _lblBook;

	internal virtual Label lblBook
	{
		get
		{
			return _lblBook;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblBook = value;
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
	[AccessedThroughProperty("dlgOpen")]
	private virtual FolderBrowserDialog _dlgOpen;

	internal virtual FolderBrowserDialog dlgOpen
	{
		get
		{
			return _dlgOpen;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_dlgOpen = value;
		}
	}

	internal virtual ComboBox CboSmsType
	{
		[CompilerGenerated]
		get
		{
			return _CboSmsType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = CboSmsType_SelectedIndexChanged;
			KeyEventHandler val = new KeyEventHandler(CboSmsType_KeyDown);
			ComboBox val2 = _CboSmsType;
			if (val2 != null)
			{
				val2.SelectedIndexChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_CboSmsType = value;
			val2 = _CboSmsType;
			if (val2 != null)
			{
				val2.SelectedIndexChanged += eventHandler;
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nFromOs
	{
		[CompilerGenerated]
		get
		{
			return _nFromOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFromOs_KeyDown);
			TextBox val2 = _nFromOs;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFromOs = value;
			val2 = _nFromOs;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox nToOs
	{
		[CompilerGenerated]
		get
		{
			return _nToOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nToOs_KeyDown);
			TextBox val2 = _nToOs;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nToOs = value;
			val2 = _nToOs;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private virtual DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
	{
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DGV = value;
		}
	}

	internal virtual QButton btnOk
	{
		[CompilerGenerated]
		get
		{
			return _btnOk;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnOk_Click;
			QButton val = _btnOk;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnOk = value;
			val = _btnOk;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tMobileNo
	{
		[CompilerGenerated]
		get
		{
			return _tMobileNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = TMobileNo_TextChanged;
			TextBox val = _tMobileNo;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tMobileNo = value;
			val = _tMobileNo;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
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

	internal virtual QButton BtnSmsSend
	{
		[CompilerGenerated]
		get
		{
			return _BtnSmsSend;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnSmsSend_Click;
			QButton val = _BtnSmsSend;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnSmsSend = value;
			val = _BtnSmsSend;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnAc
	{
		[CompilerGenerated]
		get
		{
			return _BtnAc;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAc_Click;
			SimpleButton val = _BtnAc;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAc = value;
			val = _BtnAc;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton BtnMemb
	{
		[CompilerGenerated]
		get
		{
			return _BtnMemb;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnMemb_Click;
			SimpleButton val = _BtnMemb;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnMemb = value;
			val = _BtnMemb;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual CheckBox chkAllRow
	{
		[CompilerGenerated]
		get
		{
			return _chkAllRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkAllRow_CheckedChanged;
			CheckBox val = _chkAllRow;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkAllRow = value;
			val = _chkAllRow;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblSmsRow")]
	private virtual Label _lblSmsRow;

	internal virtual Label lblSmsRow
	{
		get
		{
			return _lblSmsRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblSmsRow = value;
		}
	}

	internal virtual QButton btnExlImport
	{
		[CompilerGenerated]
		get
		{
			return _btnExlImport;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExlImport_Click;
			QButton val = _btnExlImport;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExlImport = value;
			val = _btnExlImport;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DlgOpn")]
	private virtual OpenFileDialog _DlgOpn;

	internal virtual OpenFileDialog DlgOpn
	{
		get
		{
			return _DlgOpn;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DlgOpn = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tsmstype")]
	private virtual TextBox _tsmstype;

	internal virtual TextBox tsmstype
	{
		get
		{
			return _tsmstype;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tsmstype = value;
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

	internal virtual ComboBox cboBarth
	{
		[CompilerGenerated]
		get
		{
			return _cboBarth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboBarth_SelectedIndexChanged;
			ComboBox val = _cboBarth;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboBarth = value;
			val = _cboBarth;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ChkOnlyMoNo")]
	private virtual CheckBox _ChkOnlyMoNo;

	internal virtual CheckBox ChkOnlyMoNo
	{
		get
		{
			return _ChkOnlyMoNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ChkOnlyMoNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAcGroup")]
	private virtual Label _lblAcGroup;

	internal virtual Label lblAcGroup
	{
		get
		{
			return _lblAcGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAcGroup = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboAcGroup")]
	private virtual ComboBox _cboAcGroup;

	internal virtual ComboBox cboAcGroup
	{
		get
		{
			return _cboAcGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboAcGroup = value;
		}
	}

	internal virtual SimpleButton BtnExcel
	{
		[CompilerGenerated]
		get
		{
			return _BtnExcel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnExcel_Click;
			SimpleButton val = _BtnExcel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnExcel = value;
			val = _BtnExcel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblSmsCount")]
	private virtual Label _lblSmsCount;

	internal virtual Label lblSmsCount
	{
		get
		{
			return _lblSmsCount;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblSmsCount = value;
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
	[AccessedThroughProperty("TxtUniCode")]
	private virtual TextBox _TxtUniCode;

	internal virtual TextBox TxtUniCode
	{
		get
		{
			return _TxtUniCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_TxtUniCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_comboFrom")]
	private virtual ComboBox __comboFrom;

	internal virtual ComboBox _comboFrom
	{
		get
		{
			return __comboFrom;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			__comboFrom = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_comboTo")]
	private virtual ComboBox __comboTo;

	internal virtual ComboBox _comboTo
	{
		get
		{
			return __comboTo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			__comboTo = value;
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

	internal virtual SimpleButton BtnTanslat
	{
		[CompilerGenerated]
		get
		{
			return _BtnTanslat;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTanslat_Click;
			SimpleButton val = _BtnTanslat;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTanslat = value;
			val = _BtnTanslat;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblMsgLenth")]
	private virtual Label _lblMsgLenth;

	internal virtual Label lblMsgLenth
	{
		get
		{
			return _lblMsgLenth;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMsgLenth = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_lnkSourceEnglish")]
	private virtual LinkLabel __lnkSourceEnglish;

	internal virtual LinkLabel _lnkSourceEnglish
	{
		get
		{
			return __lnkSourceEnglish;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			__lnkSourceEnglish = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("_lnkTargetEnglish")]
	private virtual LinkLabel __lnkTargetEnglish;

	internal virtual LinkLabel _lnkTargetEnglish
	{
		get
		{
			return __lnkTargetEnglish;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			__lnkTargetEnglish = value;
		}
	}

	internal virtual System.Windows.Forms.Timer Timer1
	{
		[CompilerGenerated]
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = timer1_Tick;
			System.Windows.Forms.Timer val = _Timer1;
			if (val != null)
			{
				val.Tick -= eventHandler;
			}
			_Timer1 = value;
			val = _Timer1;
			if (val != null)
			{
				val.Tick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblWhatsAppState")]
	private virtual Label _lblWhatsAppState;

	internal virtual Label lblWhatsAppState
	{
		get
		{
			return _lblWhatsAppState;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblWhatsAppState = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblSenderId")]
	private virtual Label _LblSenderId;

	internal virtual Label LblSenderId
	{
		get
		{
			return _LblSenderId;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblSenderId = value;
		}
	}

	internal virtual QButton btnWappInstall
	{
		[CompilerGenerated]
		get
		{
			return _btnWappInstall;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWappInstall_Click;
			QButton val = _btnWappInstall;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWappInstall = value;
			val = _btnWappInstall;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pBoxAuthQR")]
	private virtual PictureBox _pBoxAuthQR;

	internal virtual PictureBox pBoxAuthQR
	{
		get
		{
			return _pBoxAuthQR;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pBoxAuthQR = value;
		}
	}

	internal virtual CheckBox chkBoxHeadLess
	{
		[CompilerGenerated]
		get
		{
			return _chkBoxHeadLess;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkBoxHeadLess_Click;
			CheckBox val = _chkBoxHeadLess;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_chkBoxHeadLess = value;
			val = _chkBoxHeadLess;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("statusRetriever")]
	private virtual System.Windows.Forms.Timer _statusRetriever;

	internal virtual System.Windows.Forms.Timer statusRetriever
	{
		get
		{
			return _statusRetriever;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_statusRetriever = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("openAttach")]
	private virtual OpenFileDialog _openAttach;

	internal virtual OpenFileDialog openAttach
	{
		get
		{
			return _openAttach;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_openAttach = value;
		}
	}

	internal virtual QButton btnAcOs
	{
		[CompilerGenerated]
		get
		{
			return _btnAcOs;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAcOs_Click;
			QButton val = _btnAcOs;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnAcOs = value;
			val = _btnAcOs;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual ComboBox cboMsgType
	{
		[CompilerGenerated]
		get
		{
			return _cboMsgType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboMsgType_SelectedIndexChanged;
			ComboBox val = _cboMsgType;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboMsgType = value;
			val = _cboMsgType;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	internal virtual QButton btnGoldRate
	{
		[CompilerGenerated]
		get
		{
			return _btnGoldRate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGoldRate_Click;
			QButton val = _btnGoldRate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnGoldRate = value;
			val = _btnGoldRate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnLogout
	{
		[CompilerGenerated]
		get
		{
			return _BtnLogout;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnLogout_Click;
			QButton val = _BtnLogout;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnLogout = value;
			val = _BtnLogout;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton btnQuit
	{
		[CompilerGenerated]
		get
		{
			return _btnQuit;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnQuit_Click;
			QButton val = _btnQuit;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnQuit = value;
			val = _btnQuit;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("ProgressBar1")]
	private virtual ProgressBar _ProgressBar1;

	internal virtual ProgressBar ProgressBar1
	{
		get
		{
			return _ProgressBar1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_ProgressBar1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblDelay")]
	private virtual Label _lblDelay;

	internal virtual Label lblDelay
	{
		get
		{
			return _lblDelay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblDelay = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("numDelay")]
	private virtual NumericUpDown _numDelay;

	internal virtual NumericUpDown numDelay
	{
		get
		{
			return _numDelay;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_numDelay = value;
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

	internal virtual QButton btnBrowse
	{
		[CompilerGenerated]
		get
		{
			return _btnBrowse;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBrowse_Click;
			QButton val = _btnBrowse;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnBrowse = value;
			val = _btnBrowse;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBoxAttach")]
	private virtual TextBox _tBoxAttach;

	internal virtual TextBox tBoxAttach
	{
		get
		{
			return _tBoxAttach;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBoxAttach = value;
		}
	}

	internal virtual QButton btnClear
	{
		[CompilerGenerated]
		get
		{
			return _btnClear;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnClear_Click;
			QButton val = _btnClear;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnClear = value;
			val = _btnClear;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnDelyTime
	{
		[CompilerGenerated]
		get
		{
			return _btnDelyTime;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDelyTime_Click;
			SimpleButton val = _btnDelyTime;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnDelyTime = value;
			val = _btnDelyTime;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual SimpleButton btnHide
	{
		[CompilerGenerated]
		get
		{
			return _btnHide;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnHide_Click;
			SimpleButton val = _btnHide;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnHide = value;
			val = _btnHide;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("LblDays")]
	private virtual Label _LblDays;

	internal virtual Label LblDays
	{
		get
		{
			return _LblDays;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_LblDays = value;
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

	internal virtual TextBox nFromRow
	{
		[CompilerGenerated]
		get
		{
			return _nFromRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nFromRow_KeyDown);
			TextBox val2 = _nFromRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_nFromRow = value;
			val2 = _nFromRow;
			if (val2 != null)
			{
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

	internal virtual TextBox nToRow
	{
		[CompilerGenerated]
		get
		{
			return _nToRow;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(nToRow_KeyDown);
			EventHandler eventHandler = nToRow_TextChanged;
			TextBox val2 = _nToRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_nToRow = value;
			val2 = _nToRow;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMsg")]
	private virtual RichTextBox _tMsg;

	internal virtual RichTextBox tMsg
	{
		get
		{
			return _tMsg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMsg = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCountryCode")]
	private virtual TextBox _tCountryCode;

	internal virtual TextBox tCountryCode
	{
		get
		{
			return _tCountryCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tCountryCode = value;
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
	[AccessedThroughProperty("cboArea")]
	private virtual ComboBox _cboArea;

	internal virtual ComboBox cboArea
	{
		get
		{
			return _cboArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboArea = value;
		}
	}

	internal virtual SimpleButton btnTextMsg
	{
		[CompilerGenerated]
		get
		{
			return _btnTextMsg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTextMsg_Click;
			SimpleButton val = _btnTextMsg;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnTextMsg = value;
			val = _btnTextMsg;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
	[AccessedThroughProperty("cboCity")]
	private virtual ComboBox _cboCity;

	internal virtual ComboBox cboCity
	{
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboCity = value;
		}
	}

	public UT_WHATSAPP()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		((Form)this).Load += UT_WHATSAPP_Load;
		((Form)this).FormClosing += new FormClosingEventHandler(UT_WHATSAPP_FormClosing);
		((Form)this).Activated += UT_WHATSAPP_Activated;
		((Form)this).Deactivate += UT_WHATSAPP_Deactivate;
		((Control)this).KeyDown += new KeyEventHandler(UT_WHATSAPP_KeyDown);
		((Form)this).Closed += UT_WHATSAPP_Closed;
		authTimer = new System.Windows.Forms.Timer();
		sec = 0;
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
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Expected O, but got Unknown
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Expected O, but got Unknown
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected O, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Expected O, but got Unknown
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d7: Expected O, but got Unknown
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e3: Expected O, but got Unknown
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Expected O, but got Unknown
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Expected O, but got Unknown
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_0143: Expected O, but got Unknown
		//IL_0145: Unknown result type (might be due to invalid IL or missing references)
		//IL_014f: Expected O, but got Unknown
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0167: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_0175: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Expected O, but got Unknown
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0197: Expected O, but got Unknown
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_01bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c7: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d3: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		//IL_01e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Expected O, but got Unknown
		//IL_01ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f7: Expected O, but got Unknown
		//IL_01f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Expected O, but got Unknown
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		//IL_020f: Expected O, but got Unknown
		//IL_0211: Unknown result type (might be due to invalid IL or missing references)
		//IL_021b: Expected O, but got Unknown
		//IL_021d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0227: Expected O, but got Unknown
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023f: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Expected O, but got Unknown
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected O, but got Unknown
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0275: Expected O, but got Unknown
		//IL_0277: Unknown result type (might be due to invalid IL or missing references)
		//IL_0281: Expected O, but got Unknown
		//IL_0283: Unknown result type (might be due to invalid IL or missing references)
		//IL_028d: Expected O, but got Unknown
		//IL_028f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0299: Expected O, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected O, but got Unknown
		//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Expected O, but got Unknown
		//IL_02b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Expected O, but got Unknown
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cf: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Expected O, but got Unknown
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e7: Expected O, but got Unknown
		//IL_02e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected O, but got Unknown
		//IL_02f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected O, but got Unknown
		//IL_0301: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_030d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0317: Expected O, but got Unknown
		//IL_0319: Unknown result type (might be due to invalid IL or missing references)
		//IL_0323: Expected O, but got Unknown
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_032f: Expected O, but got Unknown
		//IL_0331: Unknown result type (might be due to invalid IL or missing references)
		//IL_033b: Expected O, but got Unknown
		//IL_033d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0347: Expected O, but got Unknown
		//IL_0349: Unknown result type (might be due to invalid IL or missing references)
		//IL_0353: Expected O, but got Unknown
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected O, but got Unknown
		//IL_036d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0377: Expected O, but got Unknown
		//IL_0379: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Expected O, but got Unknown
		//IL_0385: Unknown result type (might be due to invalid IL or missing references)
		//IL_038f: Expected O, but got Unknown
		//IL_0391: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Expected O, but got Unknown
		//IL_039d: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a7: Expected O, but got Unknown
		//IL_03a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b3: Expected O, but got Unknown
		//IL_03b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03bf: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cb: Expected O, but got Unknown
		//IL_03cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d7: Expected O, but got Unknown
		//IL_03d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ef: Expected O, but got Unknown
		//IL_03f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fb: Expected O, but got Unknown
		//IL_03fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0407: Expected O, but got Unknown
		//IL_0563: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c6: Expected O, but got Unknown
		//IL_06d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_06dc: Expected O, but got Unknown
		//IL_073f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0749: Expected O, but got Unknown
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		//IL_0908: Unknown result type (might be due to invalid IL or missing references)
		//IL_0912: Expected O, but got Unknown
		//IL_0a2f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a39: Expected O, but got Unknown
		//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa6: Expected O, but got Unknown
		//IL_0b4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b59: Expected O, but got Unknown
		//IL_0bbc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc6: Expected O, but got Unknown
		//IL_0c6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c79: Expected O, but got Unknown
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Expected O, but got Unknown
		//IL_0d90: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d9a: Expected O, but got Unknown
		//IL_0ef2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0efc: Expected O, but got Unknown
		//IL_0f6a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f74: Expected O, but got Unknown
		//IL_1040: Unknown result type (might be due to invalid IL or missing references)
		//IL_104a: Expected O, but got Unknown
		//IL_10d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_10df: Expected O, but got Unknown
		//IL_115d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1167: Expected O, but got Unknown
		//IL_11e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_11ef: Expected O, but got Unknown
		//IL_129a: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a4: Expected O, but got Unknown
		//IL_1352: Unknown result type (might be due to invalid IL or missing references)
		//IL_135c: Expected O, but got Unknown
		//IL_1427: Unknown result type (might be due to invalid IL or missing references)
		//IL_1431: Expected O, but got Unknown
		//IL_14c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14d0: Expected O, but got Unknown
		//IL_154e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1558: Expected O, but got Unknown
		//IL_1630: Unknown result type (might be due to invalid IL or missing references)
		//IL_163a: Expected O, but got Unknown
		//IL_16a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ad: Expected O, but got Unknown
		//IL_194d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1971: Unknown result type (might be due to invalid IL or missing references)
		//IL_1995: Unknown result type (might be due to invalid IL or missing references)
		//IL_19b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ec: Expected O, but got Unknown
		//IL_1a0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a90: Expected O, but got Unknown
		//IL_1b44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4e: Expected O, but got Unknown
		//IL_1bd6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1be0: Expected O, but got Unknown
		//IL_1e81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ea5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ec9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1eed: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f16: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f20: Expected O, but got Unknown
		//IL_1f46: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fda: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fe4: Expected O, but got Unknown
		//IL_20b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_20c3: Expected O, but got Unknown
		//IL_215c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2166: Expected O, but got Unknown
		//IL_229b: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a5: Expected O, but got Unknown
		//IL_237a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2384: Expected O, but got Unknown
		//IL_241d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2427: Expected O, but got Unknown
		//IL_253f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2549: Expected O, but got Unknown
		//IL_2600: Unknown result type (might be due to invalid IL or missing references)
		//IL_260a: Expected O, but got Unknown
		//IL_28b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_28d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_28fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_291e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2947: Unknown result type (might be due to invalid IL or missing references)
		//IL_2951: Expected O, but got Unknown
		//IL_2974: Unknown result type (might be due to invalid IL or missing references)
		//IL_29fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a06: Expected O, but got Unknown
		//IL_2a97: Unknown result type (might be due to invalid IL or missing references)
		//IL_2aa1: Expected O, but got Unknown
		//IL_2b6b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b75: Expected O, but got Unknown
		//IL_2c1e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c28: Expected O, but got Unknown
		//IL_2ce2: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cec: Expected O, but got Unknown
		//IL_2db4: Unknown result type (might be due to invalid IL or missing references)
		//IL_2dbe: Expected O, but got Unknown
		//IL_2e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e54: Expected O, but got Unknown
		//IL_2f0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f19: Expected O, but got Unknown
		//IL_2fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fd7: Expected O, but got Unknown
		//IL_3088: Unknown result type (might be due to invalid IL or missing references)
		//IL_3092: Expected O, but got Unknown
		//IL_3102: Unknown result type (might be due to invalid IL or missing references)
		//IL_310c: Expected O, but got Unknown
		//IL_31cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_31d6: Expected O, but got Unknown
		//IL_3246: Unknown result type (might be due to invalid IL or missing references)
		//IL_3250: Expected O, but got Unknown
		//IL_3321: Unknown result type (might be due to invalid IL or missing references)
		//IL_332b: Expected O, but got Unknown
		//IL_3400: Unknown result type (might be due to invalid IL or missing references)
		//IL_340a: Expected O, but got Unknown
		//IL_34a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_34ad: Expected O, but got Unknown
		//IL_35c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_35cf: Expected O, but got Unknown
		//IL_37cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_37d5: Expected O, but got Unknown
		//IL_3809: Unknown result type (might be due to invalid IL or missing references)
		//IL_38a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_38aa: Expected O, but got Unknown
		//IL_38e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b56: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_3beb: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bf5: Expected O, but got Unknown
		//IL_3c18: Unknown result type (might be due to invalid IL or missing references)
		//IL_4002: Unknown result type (might be due to invalid IL or missing references)
		//IL_4026: Unknown result type (might be due to invalid IL or missing references)
		//IL_404a: Unknown result type (might be due to invalid IL or missing references)
		//IL_406e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4097: Unknown result type (might be due to invalid IL or missing references)
		//IL_40a1: Expected O, but got Unknown
		//IL_40c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_413b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4145: Expected O, but got Unknown
		//IL_4213: Unknown result type (might be due to invalid IL or missing references)
		//IL_421d: Expected O, but got Unknown
		//IL_449f: Unknown result type (might be due to invalid IL or missing references)
		//IL_44c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_44e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_450b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4534: Unknown result type (might be due to invalid IL or missing references)
		//IL_453e: Expected O, but got Unknown
		//IL_4561: Unknown result type (might be due to invalid IL or missing references)
		//IL_47d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_47fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_481e: Unknown result type (might be due to invalid IL or missing references)
		//IL_4842: Unknown result type (might be due to invalid IL or missing references)
		//IL_486b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4875: Expected O, but got Unknown
		//IL_4898: Unknown result type (might be due to invalid IL or missing references)
		//IL_4afc: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b20: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b44: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b68: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_4b9b: Expected O, but got Unknown
		//IL_4bbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c82: Unknown result type (might be due to invalid IL or missing references)
		//IL_4c8c: Expected O, but got Unknown
		//IL_4d03: Unknown result type (might be due to invalid IL or missing references)
		//IL_4d0d: Expected O, but got Unknown
		//IL_4d9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_4da5: Expected O, but got Unknown
		//IL_501a: Unknown result type (might be due to invalid IL or missing references)
		//IL_503e: Unknown result type (might be due to invalid IL or missing references)
		//IL_5062: Unknown result type (might be due to invalid IL or missing references)
		//IL_5086: Unknown result type (might be due to invalid IL or missing references)
		//IL_50af: Unknown result type (might be due to invalid IL or missing references)
		//IL_50b9: Expected O, but got Unknown
		//IL_50df: Unknown result type (might be due to invalid IL or missing references)
		//IL_5156: Unknown result type (might be due to invalid IL or missing references)
		//IL_5160: Expected O, but got Unknown
		//IL_53d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_53fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_5420: Unknown result type (might be due to invalid IL or missing references)
		//IL_5444: Unknown result type (might be due to invalid IL or missing references)
		//IL_546d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5477: Expected O, but got Unknown
		//IL_549d: Unknown result type (might be due to invalid IL or missing references)
		//IL_5531: Unknown result type (might be due to invalid IL or missing references)
		//IL_553b: Expected O, but got Unknown
		//IL_5610: Unknown result type (might be due to invalid IL or missing references)
		//IL_561a: Expected O, but got Unknown
		//IL_56b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_56bd: Expected O, but got Unknown
		//IL_57d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_57df: Expected O, but got Unknown
		//IL_5897: Unknown result type (might be due to invalid IL or missing references)
		//IL_58a1: Expected O, but got Unknown
		//IL_5959: Unknown result type (might be due to invalid IL or missing references)
		//IL_5963: Expected O, but got Unknown
		//IL_59f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_59fb: Expected O, but got Unknown
		//IL_5ab3: Unknown result type (might be due to invalid IL or missing references)
		//IL_5abd: Expected O, but got Unknown
		//IL_5b75: Unknown result type (might be due to invalid IL or missing references)
		//IL_5b7f: Expected O, but got Unknown
		//IL_5c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_5c13: Expected O, but got Unknown
		//IL_5cbf: Unknown result type (might be due to invalid IL or missing references)
		//IL_5cc9: Expected O, but got Unknown
		//IL_5d5a: Unknown result type (might be due to invalid IL or missing references)
		//IL_5d64: Expected O, but got Unknown
		//IL_5e2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_5e36: Expected O, but got Unknown
		//IL_5ec2: Unknown result type (might be due to invalid IL or missing references)
		//IL_5ecc: Expected O, but got Unknown
		//IL_5f97: Unknown result type (might be due to invalid IL or missing references)
		//IL_5fa1: Expected O, but got Unknown
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_WHATSAPP));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		btnHide = new SimpleButton();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnExcel = new SimpleButton();
		btnTextMsg = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		CboSmsType = new ComboBox();
		nFromOs = new TextBox();
		nToOs = new TextBox();
		Label5 = new Label();
		Label1 = new Label();
		Label2 = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		btnOk = new QButton();
		Label3 = new Label();
		tMobileNo = new TextBox();
		Label4 = new Label();
		BtnSmsSend = new QButton();
		BtnAc = new SimpleButton();
		BtnMemb = new SimpleButton();
		chkAllRow = new CheckBox();
		lblSmsRow = new Label();
		btnExlImport = new QButton();
		DlgOpn = new OpenFileDialog();
		tsmstype = new TextBox();
		Label13 = new Label();
		cboBarth = new ComboBox();
		ChkOnlyMoNo = new CheckBox();
		lblAcGroup = new Label();
		cboAcGroup = new ComboBox();
		lblSmsCount = new Label();
		Label14 = new Label();
		TxtUniCode = new TextBox();
		_comboFrom = new ComboBox();
		Label15 = new Label();
		_comboTo = new ComboBox();
		Label16 = new Label();
		BtnTanslat = new SimpleButton();
		lblMsgLenth = new Label();
		_lnkSourceEnglish = new LinkLabel();
		_lnkTargetEnglish = new LinkLabel();
		Timer1 = new System.Windows.Forms.Timer(components);
		lblWhatsAppState = new Label();
		LblSenderId = new Label();
		btnWappInstall = new QButton();
		pBoxAuthQR = new PictureBox();
		chkBoxHeadLess = new CheckBox();
		statusRetriever = new System.Windows.Forms.Timer(components);
		openAttach = new OpenFileDialog();
		btnAcOs = new QButton();
		Label17 = new Label();
		cboMsgType = new ComboBox();
		btnGoldRate = new QButton();
		BtnLogout = new QButton();
		btnQuit = new QButton();
		ProgressBar1 = new ProgressBar();
		lblDelay = new Label();
		numDelay = new NumericUpDown();
		Label6 = new Label();
		btnBrowse = new QButton();
		tBoxAttach = new TextBox();
		btnClear = new QButton();
		btnDelyTime = new SimpleButton();
		LblDays = new Label();
		Label7 = new Label();
		nFromRow = new TextBox();
		Label8 = new Label();
		Label9 = new Label();
		nToRow = new TextBox();
		tMsg = new RichTextBox();
		tCountryCode = new TextBox();
		Label10 = new Label();
		cboArea = new ComboBox();
		Label11 = new Label();
		cboCity = new ComboBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((ISupportInitialize)pBoxAuthQR).BeginInit();
		((ISupportInitialize)numDelay).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)btnHide);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExcel);
		((Control)PnlBotam).Controls.Add((Control)(object)btnTextMsg);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 5;
		((BaseStyleControl)btnHide).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnHide).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnHide).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnHide).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnHide.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnHide).Location = new Point(1215, 3);
		((BaseControl)btnHide).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnHide).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnHide).Name = "btnHide";
		((Control)btnHide).Size = new Size(91, 37);
		((Control)btnHide).TabIndex = 12;
		btnHide.Text = "H&Ide";
		((BaseButton)btnHide).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnExit).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExit).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExit).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExit).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExit.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExit.ImageOptions.SvgImage");
		((Control)BtnExit).Location = new Point(1118, 3);
		((BaseControl)BtnExit).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExit).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExit).Name = "BtnExit";
		((Control)BtnExit).Size = new Size(91, 37);
		((Control)BtnExit).TabIndex = 9;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnDelete).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnDelete).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnDelete).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnDelete).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnDelete.ImageOptions).SvgImage = Resources.actions_trash;
		((Control)BtnDelete).Location = new Point(1021, 3);
		((BaseControl)BtnDelete).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnDelete).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnDelete).Name = "BtnDelete";
		((Control)BtnDelete).Size = new Size(91, 37);
		((Control)BtnDelete).TabIndex = 8;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(924, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 7;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnSave).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnSave).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnSave).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnSave).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnSave.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnSave.ImageOptions.SvgImage");
		((Control)BtnSave).Location = new Point(827, 3);
		((BaseControl)BtnSave).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnSave).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnSave).Name = "BtnSave";
		((Control)BtnSave).Size = new Size(91, 37);
		((Control)BtnSave).TabIndex = 5;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(730, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 6;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnExcel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExcel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExcel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExcel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExcel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExcel.ImageOptions.SvgImage");
		((Control)BtnExcel).Location = new Point(633, 3);
		((BaseControl)BtnExcel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExcel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExcel).Name = "BtnExcel";
		((Control)BtnExcel).Size = new Size(91, 37);
		((Control)BtnExcel).TabIndex = 11;
		BtnExcel.Text = "&Excel";
		((BaseButton)BtnExcel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnTextMsg).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnTextMsg).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnTextMsg).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnTextMsg).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnTextMsg.ImageOptions).Image = (Image)(object)Resources.ArrowRight;
		((Control)btnTextMsg).Location = new Point(536, 3);
		((BaseControl)btnTextMsg).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnTextMsg).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnTextMsg).Name = "btnTextMsg";
		((Control)btnTextMsg).Size = new Size(91, 37);
		((Control)btnTextMsg).TabIndex = 13;
		btnTextMsg.Text = "&TxtMsg";
		((BaseControl)btnTextMsg).ToolTip = "Whatsapp Text Message";
		((BaseButton)btnTextMsg).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)btnTextMsg).Visible = false;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(502, 3);
		((Control)Cr).Name = "Cr";
		((AxHost)Cr).OcxState = (State)componentResourceManager.GetObject("Cr.OcxState");
		((Control)Cr).Size = new Size(28, 28);
		((Control)Cr).TabIndex = 10;
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
		lblBook.Text = "Whatsapp Sender";
		lblBook.TextAlign = (ContentAlignment)32;
		CboSmsType.AutoCompleteMode = (AutoCompleteMode)2;
		CboSmsType.AutoCompleteSource = (AutoCompleteSource)256;
		CboSmsType.DropDownStyle = (ComboBoxStyle)2;
		((Control)CboSmsType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)CboSmsType).FormattingEnabled = true;
		((Control)CboSmsType).Location = new Point(111, 45);
		CboSmsType.MaxLength = 20;
		((Control)CboSmsType).Name = "CboSmsType";
		((Control)CboSmsType).Size = new Size(145, 24);
		((Control)CboSmsType).TabIndex = 4;
		((TextBoxBase)nFromOs).BackColor = Color.White;
		((Control)nFromOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFromOs).Location = new Point(111, 197);
		((TextBoxBase)nFromOs).MaxLength = 15;
		((Control)nFromOs).Name = "nFromOs";
		((Control)nFromOs).Size = new Size(81, 22);
		((Control)nFromOs).TabIndex = 0;
		((TextBoxBase)nToOs).BackColor = Color.White;
		((Control)nToOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nToOs).Location = new Point(111, 226);
		((TextBoxBase)nToOs).MaxLength = 15;
		((Control)nToOs).Name = "nToOs";
		((Control)nToOs).Size = new Size(81, 22);
		((Control)nToOs).TabIndex = 1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(11, 45);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(93, 20);
		((Control)Label5).TabIndex = 19;
		Label5.Text = "Wapp Type";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(40, 230);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(64, 20);
		((Control)Label1).TabIndex = 16;
		Label1.Text = "To Os <";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(21, 198);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(84, 20);
		((Control)Label2).TabIndex = 15;
		Label2.Text = "From Os >";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(206, 89);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		((DataGridView)DGV).ScrollBars = (ScrollBars)2;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(969, 231);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1155;
		((QControl)btnOk).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnOk).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnOk).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnOk).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnOk).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnOk).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnOk).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnOk).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnOk.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnOk.Image = null;
		((QControl)btnOk).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnOk).Location = new Point(274, 43);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(117, 37);
		((Control)btnOk).TabIndex = 1156;
		btnOk.Text = "Get List";
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(197, 336);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(82, 20);
		((Control)Label3).TabIndex = 1158;
		Label3.Text = "Mobile No";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobileNo).BackColor = Color.White;
		((Control)tMobileNo).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobileNo).Location = new Point(329, 336);
		((TextBoxBase)tMobileNo).MaxLength = 10;
		((Control)tMobileNo).Name = "tMobileNo";
		((Control)tMobileNo).Size = new Size(150, 26);
		((Control)tMobileNo).TabIndex = 1157;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(201, 371);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(78, 20);
		((Control)Label4).TabIndex = 1162;
		Label4.Text = "Message";
		Label4.TextAlign = (ContentAlignment)64;
		((QControl)BtnSmsSend).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSmsSend).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnSmsSend).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnSmsSend).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSmsSend).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnSmsSend).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnSmsSend).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnSmsSend).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnSmsSend).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnSmsSend.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSmsSend.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSmsSend.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSmsSend.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnSmsSend.Image = null;
		((QControl)BtnSmsSend).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnSmsSend).Location = new Point(581, 333);
		((Control)BtnSmsSend).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSmsSend).Name = "BtnSmsSend";
		((Control)BtnSmsSend).Size = new Size(87, 33);
		((Control)BtnSmsSend).TabIndex = 1164;
		BtnSmsSend.Text = "Send";
		((BaseStyleControl)BtnAc).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnAc).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnAc).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnAc).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnAc).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnAc).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnAc).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnAc).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnAc).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnAc).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnAc).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnAc).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnAc).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnAc).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnAc).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnAc).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnAc).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnAc).AppearancePressed.Options.UseFont = true;
		((Control)BtnAc).Location = new Point(486, 335);
		((BaseControl)BtnAc).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAc).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAc).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAc).Name = "BtnAc";
		((Control)BtnAc).Size = new Size(34, 26);
		((Control)BtnAc).TabIndex = 1166;
		BtnAc.Text = "A";
		((BaseControl)BtnAc).ToolTip = "Party Help";
		((BaseStyleControl)BtnMemb).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnMemb).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnMemb).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnMemb).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnMemb).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnMemb).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnMemb).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnMemb).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnMemb).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnMemb).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnMemb).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnMemb).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnMemb).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnMemb).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnMemb).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnMemb).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnMemb).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnMemb).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnMemb).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnMemb).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnMemb).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnMemb).AppearancePressed.Options.UseFont = true;
		((Control)BtnMemb).Location = new Point(527, 336);
		((BaseControl)BtnMemb).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnMemb).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnMemb).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnMemb).Name = "BtnMemb";
		((Control)BtnMemb).Size = new Size(34, 25);
		((Control)BtnMemb).TabIndex = 1167;
		BtnMemb.Text = "M";
		((BaseControl)BtnMemb).ToolTip = "Member Help";
		((ButtonBase)chkAllRow).BackColor = SystemColors.ButtonHighlight;
		((Control)chkAllRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkAllRow).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkAllRow).Location = new Point(1064, 54);
		((Control)chkAllRow).Name = "chkAllRow";
		((Control)chkAllRow).RightToLeft = (RightToLeft)0;
		((Control)chkAllRow).Size = new Size(118, 19);
		((Control)chkAllRow).TabIndex = 1168;
		((ButtonBase)chkAllRow).Text = "Select All Row";
		((ButtonBase)chkAllRow).UseVisualStyleBackColor = false;
		((Control)lblSmsRow).BackColor = Color.Transparent;
		((Control)lblSmsRow).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblSmsRow).ForeColor = Color.FromArgb(192, 0, 0);
		lblSmsRow.ImeMode = (ImeMode)0;
		((Control)lblSmsRow).Location = new Point(432, 514);
		((Control)lblSmsRow).Name = "lblSmsRow";
		((Control)lblSmsRow).Size = new Size(87, 20);
		((Control)lblSmsRow).TabIndex = 1169;
		lblSmsRow.Text = "Select Row";
		lblSmsRow.TextAlign = (ContentAlignment)32;
		((QControl)btnExlImport).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnExlImport).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnExlImport).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnExlImport).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnExlImport).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnExlImport).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnExlImport).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnExlImport).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnExlImport).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnExlImport).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnExlImport).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnExlImport).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnExlImport).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnExlImport).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnExlImport.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnExlImport.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnExlImport.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnExlImport.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnExlImport.Image = null;
		((QControl)btnExlImport).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnExlImport).Location = new Point(682, 43);
		((Control)btnExlImport).Margin = new Padding(3, 6, 3, 6);
		((Control)btnExlImport).Name = "btnExlImport";
		((Control)btnExlImport).Size = new Size(115, 37);
		((Control)btnExlImport).TabIndex = 1170;
		btnExlImport.Text = "Exel Import";
		((FileDialog)DlgOpn).FileName = "OpenFileDialog1";
		((TextBoxBase)tsmstype).BackColor = Color.White;
		((Control)tsmstype).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tsmstype).Location = new Point(945, 442);
		((TextBoxBase)tsmstype).MaxLength = 1;
		((Control)tsmstype).Name = "tsmstype";
		((Control)tsmstype).Size = new Size(24, 22);
		((Control)tsmstype).TabIndex = 1172;
		tsmstype.TextAlign = (HorizontalAlignment)2;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(-1, 165);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(103, 20);
		((Control)Label13).TabIndex = 1180;
		Label13.Text = "Birthday";
		Label13.TextAlign = (ContentAlignment)64;
		cboBarth.AutoCompleteMode = (AutoCompleteMode)2;
		cboBarth.AutoCompleteSource = (AutoCompleteSource)256;
		cboBarth.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboBarth).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboBarth).FormattingEnabled = true;
		((Control)cboBarth).Location = new Point(111, 166);
		cboBarth.MaxLength = 20;
		((Control)cboBarth).Name = "cboBarth";
		((Control)cboBarth).Size = new Size(80, 24);
		((Control)cboBarth).TabIndex = 1179;
		((ButtonBase)ChkOnlyMoNo).BackColor = SystemColors.ButtonHighlight;
		ChkOnlyMoNo.Checked = true;
		ChkOnlyMoNo.CheckState = (CheckState)1;
		((Control)ChkOnlyMoNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ChkOnlyMoNo).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)ChkOnlyMoNo).Location = new Point(797, 511);
		((Control)ChkOnlyMoNo).Name = "ChkOnlyMoNo";
		((Control)ChkOnlyMoNo).RightToLeft = (RightToLeft)0;
		((Control)ChkOnlyMoNo).Size = new Size(121, 19);
		((Control)ChkOnlyMoNo).TabIndex = 1181;
		((ButtonBase)ChkOnlyMoNo).Text = "Ac With Mobile";
		((ButtonBase)ChkOnlyMoNo).UseVisualStyleBackColor = false;
		((Control)lblAcGroup).BackColor = Color.Transparent;
		((Control)lblAcGroup).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAcGroup).ForeColor = Color.Black;
		lblAcGroup.ImeMode = (ImeMode)0;
		((Control)lblAcGroup).Location = new Point(16, 76);
		((Control)lblAcGroup).Name = "lblAcGroup";
		((Control)lblAcGroup).Size = new Size(88, 20);
		((Control)lblAcGroup).TabIndex = 1184;
		lblAcGroup.Text = "Ac Group";
		lblAcGroup.TextAlign = (ContentAlignment)64;
		cboAcGroup.AutoCompleteMode = (AutoCompleteMode)2;
		cboAcGroup.AutoCompleteSource = (AutoCompleteSource)256;
		cboAcGroup.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboAcGroup).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboAcGroup).FormattingEnabled = true;
		((Control)cboAcGroup).Location = new Point(111, 76);
		cboAcGroup.MaxLength = 20;
		((Control)cboAcGroup).Name = "cboAcGroup";
		((Control)cboAcGroup).Size = new Size(81, 24);
		((Control)cboAcGroup).TabIndex = 1183;
		((Control)lblSmsCount).BackColor = Color.Transparent;
		((Control)lblSmsCount).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblSmsCount).ForeColor = Color.FromArgb(192, 0, 0);
		lblSmsCount.ImeMode = (ImeMode)0;
		((Control)lblSmsCount).Location = new Point(572, 514);
		((Control)lblSmsCount).Name = "lblSmsCount";
		((Control)lblSmsCount).Size = new Size(96, 20);
		((Control)lblSmsCount).TabIndex = 1186;
		lblSmsCount.Text = "Send Row";
		lblSmsCount.TextAlign = (ContentAlignment)64;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(674, 364);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(114, 25);
		((Control)Label14).TabIndex = 1188;
		Label14.Text = "Multi Language";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TxtUniCode).BackColor = Color.White;
		((Control)TxtUniCode).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TxtUniCode).Location = new Point(794, 365);
		((TextBoxBase)TxtUniCode).MaxLength = 2500;
		TxtUniCode.Multiline = true;
		((Control)TxtUniCode).Name = "TxtUniCode";
		TxtUniCode.ScrollBars = (ScrollBars)2;
		((Control)TxtUniCode).Size = new Size(381, 67);
		((Control)TxtUniCode).TabIndex = 1187;
		_comboFrom.BackColor = Color.FromArgb(255, 224, 192);
		((Control)_comboFrom).Font = new Font("Tahoma", 9f);
		((ListControl)_comboFrom).FormattingEnabled = true;
		((Control)_comboFrom).Location = new Point(794, 334);
		((Control)_comboFrom).Name = "_comboFrom";
		((Control)_comboFrom).Size = new Size(108, 22);
		((Control)_comboFrom).TabIndex = 1189;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(698, 335);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(90, 20);
		((Control)Label15).TabIndex = 1190;
		Label15.Text = "Translate To";
		Label15.TextAlign = (ContentAlignment)64;
		_comboTo.BackColor = Color.FromArgb(255, 224, 192);
		((Control)_comboTo).Font = new Font("Tahoma", 9f);
		((ListControl)_comboTo).FormattingEnabled = true;
		((Control)_comboTo).Location = new Point(968, 334);
		((Control)_comboTo).Name = "_comboTo";
		((Control)_comboTo).Size = new Size(118, 22);
		((Control)_comboTo).TabIndex = 1191;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(908, 336);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(50, 20);
		((Control)Label16).TabIndex = 1192;
		Label16.Text = "From";
		Label16.TextAlign = (ContentAlignment)64;
		((BaseStyleControl)BtnTanslat).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)BtnTanslat).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)BtnTanslat).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)BtnTanslat).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)BtnTanslat).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)BtnTanslat).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)BtnTanslat).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)BtnTanslat).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnTanslat).Appearance.Options.UseForeColor = true;
		((BaseButton)BtnTanslat).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)BtnTanslat).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)BtnTanslat).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)BtnTanslat).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)BtnTanslat).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)BtnTanslat).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)BtnTanslat).AppearanceHovered.Options.UseFont = true;
		((BaseButton)BtnTanslat).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)BtnTanslat).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)BtnTanslat).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)BtnTanslat).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)BtnTanslat).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)BtnTanslat).AppearancePressed.Options.UseFont = true;
		((Control)BtnTanslat).Location = new Point(1092, 333);
		((BaseControl)BtnTanslat).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnTanslat).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnTanslat).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnTanslat).Name = "BtnTanslat";
		((Control)BtnTanslat).Size = new Size(83, 23);
		((Control)BtnTanslat).TabIndex = 1193;
		BtnTanslat.Text = "Translate";
		((BaseControl)BtnTanslat).ToolTip = "Translate";
		((Control)lblMsgLenth).BackColor = Color.Transparent;
		((Control)lblMsgLenth).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMsgLenth).ForeColor = Color.FromArgb(192, 0, 0);
		lblMsgLenth.ImeMode = (ImeMode)0;
		((Control)lblMsgLenth).Location = new Point(287, 514);
		((Control)lblMsgLenth).Name = "lblMsgLenth";
		((Control)lblMsgLenth).Size = new Size(90, 20);
		((Control)lblMsgLenth).TabIndex = 1194;
		lblMsgLenth.Text = "Msg Lenth";
		lblMsgLenth.TextAlign = (ContentAlignment)16;
		((Label)_lnkSourceEnglish).AutoSize = true;
		((Control)_lnkSourceEnglish).Location = new Point(1240, 274);
		((Control)_lnkSourceEnglish).Name = "_lnkSourceEnglish";
		((Control)_lnkSourceEnglish).Size = new Size(41, 13);
		((Control)_lnkSourceEnglish).TabIndex = 1195;
		_lnkSourceEnglish.TabStop = true;
		_lnkSourceEnglish.Text = "English";
		((Control)_lnkSourceEnglish).Visible = false;
		((Label)_lnkTargetEnglish).AutoSize = true;
		((Control)_lnkTargetEnglish).Location = new Point(1240, 307);
		((Control)_lnkTargetEnglish).Name = "_lnkTargetEnglish";
		((Control)_lnkTargetEnglish).Size = new Size(41, 13);
		((Control)_lnkTargetEnglish).TabIndex = 1196;
		_lnkTargetEnglish.TabStop = true;
		_lnkTargetEnglish.Text = "English";
		((Control)_lnkTargetEnglish).Visible = false;
		Timer1.Enabled = true;
		Timer1.Interval = 1000;
		((Control)lblWhatsAppState).BackColor = Color.FromArgb(255, 224, 192);
		((Control)lblWhatsAppState).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblWhatsAppState).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)lblWhatsAppState).Location = new Point(17, 5);
		((Control)lblWhatsAppState).Margin = new Padding(3);
		((Control)lblWhatsAppState).Name = "lblWhatsAppState";
		((Control)lblWhatsAppState).Size = new Size(235, 27);
		((Control)lblWhatsAppState).TabIndex = 1197;
		lblWhatsAppState.Text = "ENGINE : STOPPED";
		lblWhatsAppState.TextAlign = (ContentAlignment)16;
		((Control)LblSenderId).BackColor = Color.FromArgb(255, 224, 192);
		((Control)LblSenderId).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblSenderId).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)LblSenderId).Location = new Point(964, 1);
		((Control)LblSenderId).Margin = new Padding(3);
		((Control)LblSenderId).Name = "LblSenderId";
		((Control)LblSenderId).Size = new Size(211, 28);
		((Control)LblSenderId).TabIndex = 1198;
		LblSenderId.Text = "Sender Id: Unavailable";
		LblSenderId.TextAlign = (ContentAlignment)64;
		((QControl)btnWappInstall).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWappInstall).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWappInstall).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWappInstall).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWappInstall).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWappInstall).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWappInstall).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWappInstall).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWappInstall).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWappInstall).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWappInstall).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWappInstall).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWappInstall).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWappInstall).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWappInstall.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappInstall.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappInstall.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappInstall.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWappInstall.Image = null;
		((QControl)btnWappInstall).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWappInstall).Location = new Point(77, 409);
		((Control)btnWappInstall).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWappInstall).Name = "btnWappInstall";
		((Control)btnWappInstall).Size = new Size(115, 37);
		((Control)btnWappInstall).TabIndex = 1199;
		btnWappInstall.Text = "Connect";
		((Control)pBoxAuthQR).BackColor = Color.Transparent;
		pBoxAuthQR.BorderStyle = (BorderStyle)1;
		((Control)pBoxAuthQR).Location = new Point(31, 257);
		((Control)pBoxAuthQR).Name = "pBoxAuthQR";
		((Control)pBoxAuthQR).Size = new Size(160, 143);
		pBoxAuthQR.SizeMode = (PictureBoxSizeMode)4;
		pBoxAuthQR.TabIndex = 1200;
		pBoxAuthQR.TabStop = false;
		((ButtonBase)chkBoxHeadLess).BackColor = SystemColors.ButtonHighlight;
		chkBoxHeadLess.CheckAlign = (ContentAlignment)2;
		((Control)chkBoxHeadLess).Cursor = Cursors.Hand;
		((Control)chkBoxHeadLess).Enabled = false;
		((Control)chkBoxHeadLess).Location = new Point(5, 478);
		((Control)chkBoxHeadLess).Name = "chkBoxHeadLess";
		((Control)chkBoxHeadLess).Size = new Size(68, 51);
		((Control)chkBoxHeadLess).TabIndex = 1201;
		((ButtonBase)chkBoxHeadLess).Text = "Whout Chrome";
		chkBoxHeadLess.TextAlign = (ContentAlignment)512;
		((ButtonBase)chkBoxHeadLess).UseVisualStyleBackColor = false;
		statusRetriever.Enabled = true;
		statusRetriever.Interval = 1000;
		((FileDialog)openAttach).DefaultExt = "*";
		((FileDialog)openAttach).FileName = "*.*";
		((QControl)btnAcOs).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnAcOs).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAcOs).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnAcOs).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnAcOs).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnAcOs).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnAcOs).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAcOs).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnAcOs).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnAcOs).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnAcOs).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnAcOs).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnAcOs).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnAcOs).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnAcOs.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcOs.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcOs.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcOs.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnAcOs.Image = null;
		((QControl)btnAcOs).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnAcOs).Location = new Point(408, 43);
		((Control)btnAcOs).Margin = new Padding(3, 6, 3, 6);
		((Control)btnAcOs).Name = "btnAcOs";
		((Control)btnAcOs).Size = new Size(117, 37);
		((Control)btnAcOs).TabIndex = 1203;
		btnAcOs.Text = "Party Os";
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(681, 442);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(107, 20);
		((Control)Label17).TabIndex = 1205;
		Label17.Text = "Message Type";
		Label17.TextAlign = (ContentAlignment)64;
		cboMsgType.AutoCompleteMode = (AutoCompleteMode)2;
		cboMsgType.AutoCompleteSource = (AutoCompleteSource)256;
		cboMsgType.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboMsgType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboMsgType).FormattingEnabled = true;
		((Control)cboMsgType).Location = new Point(794, 441);
		cboMsgType.MaxLength = 20;
		((Control)cboMsgType).Name = "cboMsgType";
		((Control)cboMsgType).Size = new Size(145, 24);
		((Control)cboMsgType).TabIndex = 1204;
		((QControl)btnGoldRate).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnGoldRate).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGoldRate).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnGoldRate).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnGoldRate).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnGoldRate).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnGoldRate).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGoldRate).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnGoldRate).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnGoldRate).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnGoldRate).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnGoldRate).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnGoldRate).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnGoldRate).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnGoldRate.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGoldRate.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGoldRate.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGoldRate.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnGoldRate.Image = null;
		((QControl)btnGoldRate).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnGoldRate).Location = new Point(545, 43);
		((Control)btnGoldRate).Margin = new Padding(3, 6, 3, 6);
		((Control)btnGoldRate).Name = "btnGoldRate";
		((Control)btnGoldRate).Size = new Size(117, 37);
		((Control)btnGoldRate).TabIndex = 1206;
		btnGoldRate.Text = "Rate Send";
		((QControl)btnGoldRate).ToolTipText = "Today Gold And Silver Rate Send";
		((QControl)BtnLogout).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnLogout).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnLogout).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnLogout).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnLogout).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnLogout).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnLogout).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnLogout).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnLogout).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnLogout).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnLogout).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnLogout).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnLogout).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnLogout).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnLogout.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLogout.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLogout.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLogout.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnLogout.Image = null;
		((QControl)BtnLogout).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnLogout).Location = new Point(77, 498);
		((Control)BtnLogout).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnLogout).Name = "BtnLogout";
		((Control)BtnLogout).Size = new Size(115, 37);
		((Control)BtnLogout).TabIndex = 1207;
		BtnLogout.Text = "LogOut";
		((QControl)btnQuit).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnQuit).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnQuit).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnQuit).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnQuit).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnQuit).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnQuit).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnQuit).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnQuit).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnQuit).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnQuit).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnQuit).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnQuit).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnQuit).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnQuit.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQuit.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQuit.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQuit.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnQuit.Image = null;
		((QControl)btnQuit).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnQuit).Location = new Point(77, 453);
		((Control)btnQuit).Margin = new Padding(3, 6, 3, 6);
		((Control)btnQuit).Name = "btnQuit";
		((Control)btnQuit).Size = new Size(115, 37);
		((Control)btnQuit).TabIndex = 1208;
		btnQuit.Text = "Quit";
		((Control)ProgressBar1).Location = new Point(0, 542);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1309, 20);
		((Control)ProgressBar1).TabIndex = 1209;
		lblDelay.AutoSize = true;
		((Control)lblDelay).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblDelay).Location = new Point(984, 443);
		((Control)lblDelay).Name = "lblDelay";
		((Control)lblDelay).Size = new Size(108, 20);
		((Control)lblDelay).TabIndex = 1211;
		lblDelay.Text = "Msg Delay Time";
		((Control)numDelay).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)numDelay).Location = new Point(1096, 443);
		((Control)numDelay).Name = "numDelay";
		((Control)numDelay).Size = new Size(39, 22);
		((Control)numDelay).TabIndex = 1210;
		numDelay.Value = new decimal(new int[4] { 3, 0, 0, 0 });
		Label6.AutoSize = true;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).Location = new Point(712, 476);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(76, 20);
		((Control)Label6).TabIndex = 1212;
		Label6.Text = "File Attach";
		((QControl)btnBrowse).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnBrowse).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBrowse).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnBrowse).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnBrowse).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnBrowse).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnBrowse).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBrowse).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnBrowse).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnBrowse).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnBrowse).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnBrowse).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnBrowse).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnBrowse).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnBrowse.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrowse.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrowse.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrowse.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnBrowse.Image = null;
		((QControl)btnBrowse).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnBrowse).Location = new Point(1092, 503);
		((Control)btnBrowse).Margin = new Padding(3, 6, 3, 6);
		((Control)btnBrowse).Name = "btnBrowse";
		((Control)btnBrowse).Size = new Size(83, 33);
		((Control)btnBrowse).TabIndex = 1215;
		btnBrowse.Text = "Browse";
		((TextBoxBase)tBoxAttach).BackColor = Color.White;
		((Control)tBoxAttach).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBoxAttach).Location = new Point(794, 474);
		((TextBoxBase)tBoxAttach).MaxLength = 32700;
		((Control)tBoxAttach).Name = "tBoxAttach";
		((Control)tBoxAttach).Size = new Size(381, 22);
		((Control)tBoxAttach).TabIndex = 1216;
		((QControl)btnClear).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnClear).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnClear).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnClear).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnClear).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnClear).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnClear).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnClear).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnClear).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnClear).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnClear).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnClear).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnClear).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnClear).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnClear.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnClear.Image = null;
		((QControl)btnClear).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnClear).Location = new Point(1003, 503);
		((Control)btnClear).Margin = new Padding(3, 6, 3, 6);
		((Control)btnClear).Name = "btnClear";
		((Control)btnClear).Size = new Size(83, 33);
		((Control)btnClear).TabIndex = 1217;
		btnClear.Text = "Clear";
		((BaseStyleControl)btnDelyTime).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnDelyTime).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnDelyTime).Appearance.Font = new Font("Arial", 9f);
		((BaseStyleControl)btnDelyTime).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnDelyTime).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnDelyTime).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnDelyTime).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnDelyTime).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnDelyTime).Appearance.Options.UseForeColor = true;
		((BaseButton)btnDelyTime).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnDelyTime).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnDelyTime).AppearanceHovered.Font = new Font("Arial", 9f);
		((BaseButton)btnDelyTime).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnDelyTime).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnDelyTime).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnDelyTime).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnDelyTime).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnDelyTime).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnDelyTime).AppearancePressed.Font = new Font("Arial", 9f);
		((BaseButton)btnDelyTime).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnDelyTime).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnDelyTime).AppearancePressed.Options.UseFont = true;
		((Control)btnDelyTime).Location = new Point(1141, 441);
		((BaseControl)btnDelyTime).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnDelyTime).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnDelyTime).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnDelyTime).Name = "btnDelyTime";
		((Control)btnDelyTime).Size = new Size(34, 24);
		((Control)btnDelyTime).TabIndex = 1218;
		btnDelyTime.Text = "S";
		((BaseControl)btnDelyTime).ToolTip = "Msg Dely Time Save";
		((Control)LblDays).BackColor = Color.Transparent;
		((Control)LblDays).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblDays).ForeColor = Color.FromArgb(192, 0, 0);
		LblDays.ImeMode = (ImeMode)0;
		((Control)LblDays).Location = new Point(12, 448);
		((Control)LblDays).Name = "LblDays";
		((Control)LblDays).Size = new Size(54, 20);
		((Control)LblDays).TabIndex = 1219;
		LblDays.Text = "0";
		LblDays.TextAlign = (ContentAlignment)32;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.FromArgb(192, 0, 0);
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(12, 412);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(55, 20);
		((Control)Label7).TabIndex = 1220;
		Label7.Text = "Days";
		Label7.TextAlign = (ContentAlignment)32;
		((TextBoxBase)nFromRow).BackColor = Color.White;
		((Control)nFromRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFromRow).Location = new Point(872, 52);
		((TextBoxBase)nFromRow).MaxLength = 5;
		((Control)nFromRow).Name = "nFromRow";
		((Control)nFromRow).Size = new Size(46, 22);
		((Control)nFromRow).TabIndex = 1221;
		nFromRow.TextAlign = (HorizontalAlignment)2;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.FromArgb(192, 0, 0);
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(807, 52);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(58, 20);
		((Control)Label8).TabIndex = 1222;
		Label8.Text = "F/ Row";
		Label8.TextAlign = (ContentAlignment)16;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.FromArgb(192, 0, 0);
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(924, 53);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(64, 20);
		((Control)Label9).TabIndex = 1224;
		Label9.Text = "To/ Row";
		Label9.TextAlign = (ContentAlignment)16;
		((TextBoxBase)nToRow).BackColor = Color.White;
		((Control)nToRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nToRow).Location = new Point(997, 52);
		((TextBoxBase)nToRow).MaxLength = 5;
		((Control)nToRow).Name = "nToRow";
		((Control)nToRow).Size = new Size(46, 22);
		((Control)nToRow).TabIndex = 1223;
		nToRow.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tMsg).BorderStyle = (BorderStyle)1;
		tMsg.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMsg).Location = new Point(287, 371);
		tMsg.MaxLength = 2500;
		((Control)tMsg).Name = "tMsg";
		((Control)tMsg).Size = new Size(382, 139);
		((Control)tMsg).TabIndex = 1225;
		tMsg.Text = "";
		((TextBoxBase)tCountryCode).BackColor = Color.White;
		((Control)tCountryCode).Enabled = false;
		((Control)tCountryCode).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCountryCode).Location = new Point(287, 336);
		((TextBoxBase)tCountryCode).MaxLength = 3;
		((Control)tCountryCode).Name = "tCountryCode";
		((Control)tCountryCode).Size = new Size(36, 26);
		((Control)tCountryCode).TabIndex = 1226;
		tCountryCode.TextAlign = (HorizontalAlignment)2;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(16, 106);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(87, 20);
		((Control)Label10).TabIndex = 1228;
		Label10.Text = "Area";
		Label10.TextAlign = (ContentAlignment)64;
		cboArea.AutoCompleteMode = (AutoCompleteMode)2;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboArea).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(111, 107);
		cboArea.MaxLength = 20;
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(81, 24);
		((Control)cboArea).TabIndex = 1227;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.Black;
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(16, 135);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(87, 20);
		((Control)Label11).TabIndex = 1230;
		Label11.Text = "City";
		Label11.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)2;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboCity).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(111, 136);
		cboCity.MaxLength = 20;
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(81, 24);
		((Control)cboCity).TabIndex = 1229;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)tCountryCode);
		((Control)this).Controls.Add((Control)(object)tMsg);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nToRow);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nFromRow);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)LblDays);
		((Control)this).Controls.Add((Control)(object)btnDelyTime);
		((Control)this).Controls.Add((Control)(object)btnClear);
		((Control)this).Controls.Add((Control)(object)tBoxAttach);
		((Control)this).Controls.Add((Control)(object)btnBrowse);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)lblDelay);
		((Control)this).Controls.Add((Control)(object)numDelay);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)btnQuit);
		((Control)this).Controls.Add((Control)(object)BtnLogout);
		((Control)this).Controls.Add((Control)(object)btnGoldRate);
		((Control)this).Controls.Add((Control)(object)Label17);
		((Control)this).Controls.Add((Control)(object)cboMsgType);
		((Control)this).Controls.Add((Control)(object)btnAcOs);
		((Control)this).Controls.Add((Control)(object)chkBoxHeadLess);
		((Control)this).Controls.Add((Control)(object)pBoxAuthQR);
		((Control)this).Controls.Add((Control)(object)btnWappInstall);
		((Control)this).Controls.Add((Control)(object)LblSenderId);
		((Control)this).Controls.Add((Control)(object)lblWhatsAppState);
		((Control)this).Controls.Add((Control)(object)_lnkTargetEnglish);
		((Control)this).Controls.Add((Control)(object)_lnkSourceEnglish);
		((Control)this).Controls.Add((Control)(object)lblMsgLenth);
		((Control)this).Controls.Add((Control)(object)BtnTanslat);
		((Control)this).Controls.Add((Control)(object)_comboTo);
		((Control)this).Controls.Add((Control)(object)Label16);
		((Control)this).Controls.Add((Control)(object)_comboFrom);
		((Control)this).Controls.Add((Control)(object)Label15);
		((Control)this).Controls.Add((Control)(object)Label14);
		((Control)this).Controls.Add((Control)(object)TxtUniCode);
		((Control)this).Controls.Add((Control)(object)lblSmsCount);
		((Control)this).Controls.Add((Control)(object)lblAcGroup);
		((Control)this).Controls.Add((Control)(object)cboAcGroup);
		((Control)this).Controls.Add((Control)(object)ChkOnlyMoNo);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)cboBarth);
		((Control)this).Controls.Add((Control)(object)tsmstype);
		((Control)this).Controls.Add((Control)(object)btnExlImport);
		((Control)this).Controls.Add((Control)(object)lblSmsRow);
		((Control)this).Controls.Add((Control)(object)chkAllRow);
		((Control)this).Controls.Add((Control)(object)BtnMemb);
		((Control)this).Controls.Add((Control)(object)BtnAc);
		((Control)this).Controls.Add((Control)(object)BtnSmsSend);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)tMobileNo);
		((Control)this).Controls.Add((Control)(object)btnOk);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)CboSmsType);
		((Control)this).Controls.Add((Control)(object)nFromOs);
		((Control)this).Controls.Add((Control)(object)nToOs);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "UT_WHATSAPP";
		((Form)this).Text = "Whatsapp Sender";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((ISupportInitialize)pBoxAuthQR).EndInit();
		((ISupportInitialize)numDelay).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void UT_WHATSAPP_Load(object sender, EventArgs e)
	{
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fd2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
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
				Label obj4 = lblWhatsAppState;
				object? obj5 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj4).BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				Label lblSenderId = LblSenderId;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)lblSenderId).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				Label obj7 = lblBook;
				object? obj8 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj7).ForeColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				Label obj9 = lblWhatsAppState;
				object? obj10 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj9).ForeColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				Label lblSenderId2 = LblSenderId;
				object? obj11 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)lblSenderId2).ForeColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj12 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				((ButtonBase)ChkOnlyMoNo).BackColor = Color.Silver;
				((ButtonBase)chkAllRow).BackColor = Color.Silver;
				((ButtonBase)chkBoxHeadLess).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblWhatsAppState).BackColor = Color.LightSlateGray;
				((Control)LblSenderId).BackColor = Color.LightSlateGray;
				((Control)lblWhatsAppState).ForeColor = Color.White;
				((Control)LblSenderId).ForeColor = Color.White;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj15 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				ComboBox cboSmsType = CboSmsType;
				object? obj17 = colorConverter.ConvertFromString("233, 235, 240");
				cboSmsType.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				CheckBox chkOnlyMoNo = ChkOnlyMoNo;
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)chkOnlyMoNo).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				CheckBox obj19 = chkAllRow;
				object? obj20 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj19).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				CheckBox obj21 = chkBoxHeadLess;
				object? obj22 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj21).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblWhatsAppState).BackColor = Color.Cornsilk;
				((Control)LblSenderId).BackColor = Color.Cornsilk;
				CheckBox obj24 = chkAllRow;
				object? obj25 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj24).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				Label obj26 = lblBook;
				object? obj27 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj26).ForeColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				Label obj28 = lblWhatsAppState;
				object? obj29 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj28).ForeColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				Label lblSenderId3 = LblSenderId;
				object? obj30 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)lblSenderId3).ForeColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj31 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj32 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj33 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				ComboBox cboSmsType2 = CboSmsType;
				object? obj34 = colorConverter.ConvertFromString("Cornsilk");
				cboSmsType2.BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				CheckBox chkOnlyMoNo2 = ChkOnlyMoNo;
				object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)chkOnlyMoNo2).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
				CheckBox obj36 = chkAllRow;
				object? obj37 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj36).BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				CheckBox obj38 = chkBoxHeadLess;
				object? obj39 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj38).BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
			}
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			CboSmsType.Items.Add((object)"Accounts");
			CboSmsType.Items.Add((object)"Address");
			CboSmsType.Items.Add((object)"Scheme");
			CboSmsType.SelectedIndex = 0;
			cboBarth.Items.Add((object)"");
			cboBarth.Items.Add((object)"Both");
			cboBarth.Items.Add((object)"Birthday");
			cboBarth.Items.Add((object)"Anniversary");
			cboBarth.SelectedIndex = 0;
			cboMsgType.Items.Add((object)"");
			cboMsgType.Items.Add((object)"A Anniversary");
			cboMsgType.Items.Add((object)"B Birthday");
			cboMsgType.Items.Add((object)"L Bill Msg");
			cboMsgType.Items.Add((object)"G Gold Rate");
			cboMsgType.Items.Add((object)"O Party Os");
			cboMsgType.Items.Add((object)"1 Message");
			cboMsgType.Items.Add((object)"2 Message");
			cboMsgType.Items.Add((object)"3 Message");
			cboMsgType.Items.Add((object)"4 Message");
			cboMsgType.Items.Add((object)"5 Message");
			cboMsgType.Items.Add((object)"6 Message");
			cboMsgType.Items.Add((object)"7 Message");
			cboMsgType.Items.Add((object)"8 Message");
			cboMsgType.Items.Add((object)"9 Message");
			cboMsgType.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT WAPP_DELAY From CO_SET_NEW WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				numDelay.Value = Conversions.ToDecimal(DC_Main.Tbl.Rows[0]["WAPP_DELAY"]);
			}
			AcGroupDetl();
			DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboArea.Items.Clear();
				cboArea.Items.Add((object)"");
				int num3 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 1;
				while (DC_Main.X <= num3)
				{
					cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboArea.Items.Add((object)"");
			}
			cboArea.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND AC_CITY <> '' GROUP BY AC_CITY ORDER BY AC_CITY ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboCity.Items.Clear();
				cboCity.Items.Add((object)"");
				int count = DC_Main.Rshlp.Rows.Count;
				DC_Main.X = 1;
				while (DC_Main.X <= count)
				{
					cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X - 1]["AC_CITY"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboCity.Items.Clear();
				cboCity.Items.Add((object)"");
				cboCity.Text = "";
			}
			try
			{
				_comboFrom.Items.AddRange((object[])Translator.Languages.ToArray());
				_comboTo.Items.AddRange((object[])Translator.Languages.ToArray());
				_comboFrom.SelectedItem = "English";
				_comboTo.SelectedItem = "Gujarati";
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				MessageBox.Show(ex2.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
				ProjectData.ClearProjectError();
			}
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			EntryMode = "A";
			if (!DC_Main.MsWappMember)
			{
				if (DC_Main.MsWappEndDay <= 0)
				{
					Interaction.MsgBox((object)"You Have No Subscription... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
					DC_Main.MsWhatsAppOpen = "N";
					LblDays.Text = Conversions.ToString(0);
					((Control)btnWappInstall).Enabled = false;
				}
				else
				{
					Interaction.MsgBox((object)("This is a Demo Version Close After " + Conversions.ToString(DC_Main.MsWappEndDay) + " Days...."), (MsgBoxStyle)0, (object)null);
					DC_Main.MsWappMember = true;
				}
			}
			tCountryCode.Text = DC_Main.MsCountryId;
			nFromRow.Text = Conversions.ToString(1);
			nToRow.Text = Conversions.ToString(250);
			whatsApp = new Module_WhatsApp();
			whatsApp.StateChanged += OnWhatsAppStateChanged;
			whatsApp.QRCodeAvailable += OnQRCodeAvailable;
			whatsApp.MessageSent += OnMessageSent;
			whatsApp.ConnectionEstablished += OnConnectionEstablished;
			authTimer.Interval = 2000;
			authTimer.Tick += AuthTimer_Tick;
			UpdateUIBasedOnState();
		}
	}

	private void UT_WHATSAPP_FormClosing(object sender, FormClosingEventArgs e)
	{
		try
		{
			authTimer.Stop();
			if (whatsApp != null)
			{
				whatsApp.Destroy();
				whatsApp = null;
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine($"[FormClosing] Cleanup error: {ex2.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private void OnConnectionEstablished(string phoneNumber)
	{
		//IL_01a7: Unknown result type (might be due to invalid IL or missing references)
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				OnConnectionEstablished(phoneNumber);
			}));
			return;
		}
		pBoxAuthQR.Image = null;
		Console.WriteLine($"OnConnectionEstablished called with: [{phoneNumber}]");
		Console.WriteLine($"phoneNumber length: {phoneNumber.Length}");
		Console.WriteLine($"IsNullOrEmpty: {string.IsNullOrEmpty(phoneNumber)}");
		if (!string.IsNullOrEmpty(phoneNumber))
		{
			string text = $"Sender Id: {phoneNumber}";
			Console.WriteLine($"Setting LblSenderId.Text to: [{text}]");
			LblSenderId.Text = text;
			((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text = "W Id : " + phoneNumber;
			Application.DoEvents();
			if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) == 0)
			{
				DC_Main.IdWappIdNo = phoneNumber;
			}
			((Control)LblSenderId).Refresh();
			Application.DoEvents();
			Console.WriteLine($"LblSenderId.Text after setting: [{LblSenderId.Text}]");
		}
		else
		{
			Console.WriteLine("phoneNumber is empty, setting to (Retrieving...)");
			LblSenderId.Text = "Sender Id: (Retrieving...)";
			((Control)LblSenderId).Refresh();
			Application.DoEvents();
			MessageBox.Show(string.Format("WhatsApp Connected!{0}Note: Phone number not detected yet.", "\r\n"), "Connected", (MessageBoxButtons)0, (MessageBoxIcon)64);
		}
	}

	private void OnWhatsAppStateChanged(Module_WhatsApp.WhatsAppState state)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				OnWhatsAppStateChanged(state);
			}));
			return;
		}
		switch (state)
		{
		case Module_WhatsApp.WhatsAppState.Stopped:
			lblWhatsAppState.Text = "Engine: Stopped";
			((Control)lblWhatsAppState).ForeColor = Color.Gray;
			break;
		case Module_WhatsApp.WhatsAppState.Initializing:
			lblWhatsAppState.Text = "Engine: Starting...";
			((Control)lblWhatsAppState).ForeColor = Color.Blue;
			break;
		case Module_WhatsApp.WhatsAppState.WaitingForQR:
			lblWhatsAppState.Text = "Engine: QR Code Scan Required";
			((Control)lblWhatsAppState).ForeColor = Color.Orange;
			break;
		case Module_WhatsApp.WhatsAppState.Ready:
			lblWhatsAppState.Text = "Engine: Ready";
			((Control)lblWhatsAppState).ForeColor = Color.Green;
			authTimer.Stop();
			break;
		case Module_WhatsApp.WhatsAppState.Error:
			lblWhatsAppState.Text = "Engine: Error";
			((Control)lblWhatsAppState).ForeColor = Color.Red;
			break;
		}
		UpdateUIBasedOnState();
	}

	private void OnQRCodeAvailable(string qrDataUrl)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				OnQRCodeAvailable(qrDataUrl);
			}));
			return;
		}
		try
		{
			string s = qrDataUrl.Split(new char[1] { ',' })[1];
			byte[] buffer = Convert.FromBase64String(s);
			using MemoryStream memoryStream = new MemoryStream(buffer);
			pBoxAuthQR.Image = Image.FromStream((Stream)memoryStream);
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Console.WriteLine($"QR Code display error: {ex2.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private void OnMessageSent(string phone, bool success, string message)
	{
		if (((Control)this).InvokeRequired)
		{
			((Control)this).Invoke((Delegate)(VB_0024AnonymousDelegate_0)([SpecialName] () =>
			{
				OnMessageSent(phone, success, message);
			}));
		}
		else
		{
			Console.WriteLine(string.Format("Message to {0}: {1} - {2}", phone, success ? "Success" : "Failed", message));
		}
	}

	private void UpdateUIBasedOnState()
	{
		try
		{
			if (whatsApp != null)
			{
				Module_WhatsApp.WhatsAppState currentState = whatsApp.CurrentState;
				((Control)btnWappInstall).Enabled = currentState == Module_WhatsApp.WhatsAppState.Stopped;
				((Control)btnQuit).Enabled = currentState != Module_WhatsApp.WhatsAppState.Stopped;
				((Control)chkBoxHeadLess).Enabled = currentState == Module_WhatsApp.WhatsAppState.Stopped;
				((Control)BtnSmsSend).Enabled = currentState == Module_WhatsApp.WhatsAppState.Ready;
				((Control)btnHide).Enabled = currentState == Module_WhatsApp.WhatsAppState.Ready;
				((Control)BtnLogout).Enabled = currentState == Module_WhatsApp.WhatsAppState.Ready;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			ProjectData.ClearProjectError();
		}
	}

	private async void AuthTimer_Tick(object sender, EventArgs e)
	{
		try
		{
			if (whatsApp != null)
			{
				await whatsApp.PollAuthenticationAsync();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Exception ex3 = ex2;
			Console.WriteLine($"AuthTimer_Tick error: {ex3.Message}");
			ProjectData.ClearProjectError();
		}
	}

	private async void timer1_Tick(object sender, EventArgs e)
	{
		if (whatsApp == null)
		{
			await Task.Delay(500);
		}
		else
		{
			UpdateUIBasedOnState();
		}
	}

	public bool CheckForInternetConnection()
	{
		Thread.Sleep(1000);
		bool result;
		try
		{
			using WebClient webClient = new WebClient();
			using (webClient.OpenRead("http://www.google.com"))
			{
				result = true;
			}
		}
		catch (Exception projectError)
		{
			ProjectData.SetProjectError(projectError);
			result = false;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private async void Initialization()
	{
		if (CheckForInternetConnection())
		{
			try
			{
				((Control)btnWappInstall).Enabled = false;
				lblWhatsAppState.Text = "Engine: Initializing...";
				((Control)lblWhatsAppState).ForeColor = Color.Blue;
				await whatsApp.InitializeAsync(chkBoxHeadLess.Checked);
				authTimer.Start();
				return;
			}
			catch (Exception ex)
			{
				ProjectData.SetProjectError(ex);
				Exception ex2 = ex;
				Exception ex3 = ex2;
				MessageBox.Show(ex3.Message, "Error", (MessageBoxButtons)0, (MessageBoxIcon)16);
				lblWhatsAppState.Text = "Engine: Error";
				((Control)lblWhatsAppState).ForeColor = Color.Red;
				((Control)btnWappInstall).Enabled = true;
				ProjectData.ClearProjectError();
				return;
			}
		}
		MessageBox.Show("Internet Connection Failed", "Stop", (MessageBoxButtons)0, (MessageBoxIcon)16);
	}

	[MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
	private void UT_WHATSAPP_Activated(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num3 = default(int);
		int num = default(int);
		int num2 = default(int);
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
				case 453:
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
							goto IL_0019;
						case 4:
							goto IL_0028;
						case 5:
							goto IL_0034;
						case 6:
							goto IL_0048;
						case 8:
							goto IL_005e;
						case 9:
							goto IL_0071;
						case 10:
							goto IL_0081;
						case 11:
							goto IL_009a;
						case 12:
							goto IL_00a7;
						case 15:
							goto IL_00c3;
						case 16:
							goto IL_00ef;
						case 17:
						case 18:
							goto IL_0101;
						case 19:
							goto IL_0123;
						case 20:
						case 21:
							goto end_IL_0001_2;
						default:
							goto end_IL_0001;
						case 7:
						case 13:
						case 14:
						case 22:
						case 23:
						case 24:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_00ef:
					num2 = 16;
					((Control)btnTextMsg).Visible = true;
					goto IL_0101;
					IL_0101:
					num2 = 18;
					if (Operators.CompareString(FileSystem.Dir("D:\\DataCareNext\\WappNextMsg\\NextEmp\\bin\\Debug\\NextEmp.exe", (FileAttribute)0), "", false) == 0)
					{
						break;
					}
					goto IL_0123;
					IL_00c3:
					num2 = 15;
					if (Operators.CompareString(FileSystem.Dir(DC_Main.MSImageSavePath + "\\NextWapp\\NextEmp.exe", (FileAttribute)0), "", false) != 0)
					{
						goto IL_00ef;
					}
					goto IL_0101;
					IL_0123:
					num2 = 19;
					((Control)btnTextMsg).Visible = true;
					break;
					IL_000b:
					num2 = 2;
					if (!DC_Main.MsWappMember)
					{
						goto IL_0019;
					}
					goto IL_005e;
					IL_0019:
					num2 = 3;
					Interaction.MsgBox((object)"You Have No Subscription... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
					goto IL_0028;
					IL_0028:
					num2 = 4;
					DC_Main.MsWhatsAppOpen = "N";
					goto IL_0034;
					IL_0034:
					num2 = 5;
					LblDays.Text = Conversions.ToString(0);
					goto IL_0048;
					IL_0048:
					num2 = 6;
					((Control)btnWappInstall).Enabled = false;
					goto end_IL_0001_3;
					IL_005e:
					num2 = 8;
					if (DC_Main.MsWappEndDay <= 0)
					{
						goto IL_0071;
					}
					goto IL_00c3;
					IL_0071:
					num2 = 9;
					Interaction.MsgBox((object)"Your Subscription is Over... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
					goto IL_0081;
					IL_0081:
					num2 = 10;
					LblDays.Text = Conversions.ToString(DC_Main.MsWappEndDay);
					goto IL_009a;
					IL_009a:
					num2 = 11;
					DC_Main.MsWhatsAppOpen = "N";
					goto IL_00a7;
					IL_00a7:
					num2 = 12;
					((Control)btnWappInstall).Enabled = false;
					goto end_IL_0001_3;
					end_IL_0001_2:
					break;
				}
				num2 = 21;
				LblDays.Text = Conversions.ToString(DC_Main.MsWappEndDay);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 453;
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

	private void BtnSmsSend_Click(object sender, EventArgs e)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (DC_Main.MsWappEndDay <= 0)
		{
			Interaction.MsgBox((object)"Your Subscription is Over... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
			return;
		}
		MaxPages = 0;
		LastRow = 0;
		TotSms = 0;
		Pages = 0;
		lblSmsRow.Text = "Select Row";
		checked
		{
			if (((DataGridView)DGV).Rows.Count > 1)
			{
				int num = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
					{
						MaxPages++;
						lblSmsRow.Text = Conversions.ToString(MaxPages);
					}
					DC_Main.M++;
				}
			}
			ProgressBar1.Value = 0;
			ProgressBar1.Maximum = MaxPages;
			if (Operators.CompareString(tMsg.Text, "", false) != 0)
			{
				SendDetl = tMsg.Text;
			}
			else
			{
				SendDetl = TxtUniCode.Text;
			}
			if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
			{
				SingelMsg();
			}
			else if (cboBarth.SelectedIndex != 0)
			{
				BirthdaySms();
			}
			else if (OsMsg)
			{
				PartyOsSms();
			}
			else if (SchmOsMsg)
			{
				SchmOsSms();
			}
			else
			{
				DgvSms();
			}
		}
	}

	private async void SingelMsg()
	{
		if (Strings.Len(tMobileNo.Text) >= 9)
		{
			ScelectMo = tMobileNo.Text;
			string text = ((Operators.CompareString(TxtUniCode.Text, "", false) == 0) ? tMsg.Text : TxtUniCode.Text);
			string text2 = text;
			if (Operators.CompareString(text2, "", false) == 0)
			{
				text2 = null;
			}
			string phone = DC_Main.MsCountryId + ScelectMo;
			string attachmentPath = (string.IsNullOrEmpty(tBoxAttach.Text) ? null : tBoxAttach.Text);
			(bool, string) tuple = await whatsApp.SendMessageAsync(phone, text2, attachmentPath);
			if (tuple.Item1)
			{
				MessageBox.Show("Message sent successfully!");
			}
			else
			{
				MessageBox.Show("Failed to send message: " + tuple.Item2);
			}
		}
	}

	public string StrToHex(ref string Data)
	{
		string text = "";
		while (Data.Length > 0)
		{
			byte[] bytes = Encoding.Default.GetBytes(TxtUniCode.Text);
			int num = Information.UBound((Array)bytes, 1);
			for (int i = 0; i <= num; i = checked(i + 1))
			{
				string text2 = Conversion.Hex((object)Strings.Chr((int)bytes[i]));
				text += text2;
			}
		}
		return text;
	}

	private async void SchmOsSms()
	{
		SendRow = 0;
		ScelectMo = "";
		int num = 7;
		int num2 = 0;
		checked
		{
			if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
			{
				foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
				{
					DataGridViewRow val = item;
					try
					{
						if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
						{
							ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
							TotSms++;
							if (Operators.CompareString(ScelectMo, "", false) != 0)
							{
								string text = tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[8].Value), "0.00") + Environment.NewLine + "Have a Nice Day...";
								string text2 = DC_Main.MsCountryId + ScelectMo;
								string text3 = (string.IsNullOrEmpty(text) ? null : text);
								string text4 = (string.IsNullOrEmpty(tBoxAttach.Text) ? null : tBoxAttach.Text);
								if (text2 != null && (text3 != null || text4 != null))
								{
									int i = 0;
									int num3 = 2;
									bool flag = false;
									string text5 = "";
									for (; i < num3; i++)
									{
										if (flag)
										{
											break;
										}
										if (i > 0)
										{
											Console.WriteLine($"Retry {i} for number: {text2}");
											await Task.Delay(3000);
										}
										(bool, string) tuple = await whatsApp.SendMessageAsync(text2, text3, text4);
										flag = tuple.Item1;
										text5 = tuple.Item2;
									}
									if (num2 == 27)
									{
										num2 = 0;
										val.Cells[6].Value = (flag ? "Successfully Sent" : ("Not Sent: " + text5));
										if (Convert.ToInt32(numDelay.Value) > 0)
										{
											await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
										}
										if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) != 0)
										{
											await whatsApp.SendMessageAsync(DC_Main.IdWappIdNo, "hi");
										}
									}
									if (flag)
									{
										val.Cells[6].Value = "Successfully Sent";
									}
									else
									{
										val.Cells[6].Value = "Not Sent: " + text5;
									}
								}
							}
							lblSmsCount.Text = Conversions.ToString(TotSms);
							ProgressBar progressBar;
							ProgressBar val2 = (progressBar = ProgressBar1);
							progressBar.Value = val2.Value + 1;
							if (Convert.ToInt32(numDelay.Value) > 0)
							{
								await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
							}
							Application.DoEvents();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				return;
			}
			MessageBox.Show("WhatsApp not ready. Current state: " + whatsApp.CurrentState);
		}
	}

	private async void PartyOsSms()
	{
		SendRow = 0;
		ScelectMo = "";
		int num = 8;
		int num2 = 0;
		checked
		{
			if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
			{
				foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
				{
					DataGridViewRow val = item;
					try
					{
						if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
						{
							ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
							TotSms++;
							if (Operators.CompareString(ScelectMo, "", false) != 0)
							{
								string text = (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0)) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0)) ? (tMsg.Text + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0)) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : (((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)) != 0.0)) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : ((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[4].Value)) != 0.0) ? (tMsg.Text + " Silver Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[4].Value), "0.000") + Environment.NewLine + "Have a Nice Day...") : ((Conversion.Val(RuntimeHelpers.GetObjectValue(val.Cells[3].Value)) == 0.0) ? (tMsg.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[2].Value), "0.00") + Environment.NewLine + "Have a Nice Day...") : (tMsg.Text + " Gold Fine = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[3].Value), "0.000") + Environment.NewLine + "Have a Nice Day...")))))));
								string text2 = DC_Main.MsCountryId + ScelectMo;
								string text3 = (string.IsNullOrEmpty(text) ? null : text);
								string text4 = (string.IsNullOrEmpty(tBoxAttach.Text) ? null : tBoxAttach.Text);
								if (text2 != null && (text3 != null || text4 != null))
								{
									int i = 0;
									int num3 = 2;
									bool flag = false;
									string text5 = "";
									for (; i < num3; i++)
									{
										if (flag)
										{
											break;
										}
										if (i > 0)
										{
											Console.WriteLine($"Retry {i} for number: {text2}");
											await Task.Delay(3000);
										}
										(bool, string) tuple = await whatsApp.SendMessageAsync(text2, text3, text4);
										flag = tuple.Item1;
										text5 = tuple.Item2;
									}
									if (num2 == 27)
									{
										num2 = 0;
										val.Cells[6].Value = (flag ? "Successfully Sent" : ("Not Sent: " + text5));
										if (Convert.ToInt32(numDelay.Value) > 0)
										{
											await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
										}
										if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) != 0)
										{
											await whatsApp.SendMessageAsync(DC_Main.IdWappIdNo, "hi");
										}
									}
									if (flag)
									{
										val.Cells[6].Value = "Successfully Sent";
									}
									else
									{
										val.Cells[6].Value = "Not Sent: " + text5;
									}
								}
							}
							lblSmsCount.Text = Conversions.ToString(TotSms);
							ProgressBar progressBar;
							ProgressBar val2 = (progressBar = ProgressBar1);
							progressBar.Value = val2.Value + 1;
							if (Convert.ToInt32(numDelay.Value) > 0)
							{
								await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
							}
							Application.DoEvents();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				return;
			}
			MessageBox.Show("WhatsApp not ready. Current state: " + whatsApp.CurrentState);
		}
	}

	private async void BirthdaySms()
	{
		string text = "";
		string text2 = "";
		DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE IN ('B','A') ORDER BY MSG_TYPE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			int num = DC_Main.Rshlp.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_TYPE"], (object)"A", false))
				{
					text2 = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)"")));
				}
				else if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_TYPE"], (object)"B", false))
				{
					text = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)"")));
				}
				DC_Main.i++;
			}
			if (Operators.CompareString(text2, "", false) == 0)
			{
				text2 = "Happy Marriage Anniversary To Both Of You Regards, " + DC_Main.MCo_Name + " Have a Nice Day...";
			}
			if (Operators.CompareString(text, "", false) == 0)
			{
				text = "Happy Birthday To You Regard" + DC_Main.MCo_Name + " Have a Nice Day...";
			}
			SendRow = 0;
			TotSms = 0;
			ScelectMo = "";
			int num2 = 5;
			int num3 = 0;
			if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
			{
				foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
				{
					DataGridViewRow val = item;
					try
					{
						if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
						{
							ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num2].Value, (object)"")));
							TotSms++;
							if (Operators.CompareString(ScelectMo, "", false) != 0)
							{
								if (Operators.CompareString(Strings.Mid(Conversions.ToString(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)), 1, 1), "A", false) == 0)
								{
									tMsg.Text = text2;
								}
								else if (Operators.CompareString(Strings.Mid(Conversions.ToString(RuntimeHelpers.GetObjectValue(val.Cells[2].Value)), 1, 1), "B", false) == 0)
								{
									tMsg.Text = text;
								}
								string text3 = DC_Main.MsCountryId + ScelectMo;
								string text4 = (string.IsNullOrEmpty(tMsg.Text) ? null : tMsg.Text);
								string text5 = (string.IsNullOrEmpty(tBoxAttach.Text) ? null : tBoxAttach.Text);
								if (text3 != null && (text4 != null || text5 != null))
								{
									int i = 0;
									int num4 = 2;
									bool flag = false;
									string text6 = "";
									for (; i < num4; i++)
									{
										if (flag)
										{
											break;
										}
										if (i > 0)
										{
											Console.WriteLine($"Retry {i} for number: {text3}");
											await Task.Delay(3000);
										}
										(bool, string) tuple = await whatsApp.SendMessageAsync(text3, text4, text5);
										flag = tuple.Item1;
										text6 = tuple.Item2;
									}
									if (num3 == 27)
									{
										num3 = 0;
										val.Cells[4].Value = (flag ? "Successfully Sent" : ("Not Sent: " + text6));
										if (Convert.ToInt32(numDelay.Value) > 0)
										{
											await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
										}
										if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) != 0)
										{
											await whatsApp.SendMessageAsync(DC_Main.IdWappIdNo, "hi");
										}
									}
									if (flag)
									{
										val.Cells[4].Value = "Successfully Sent";
									}
									else
									{
										val.Cells[4].Value = "Not Sent: " + text6;
									}
								}
							}
							lblSmsCount.Text = Conversions.ToString(TotSms);
							ProgressBar progressBar;
							ProgressBar val2 = (progressBar = ProgressBar1);
							progressBar.Value = val2.Value + 1;
							if (Convert.ToInt32(numDelay.Value) > 0)
							{
								await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
							}
							Application.DoEvents();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				return;
			}
			MessageBox.Show("WhatsApp not ready. Current state: " + whatsApp.CurrentState);
		}
	}

	private async void DgvSms()
	{
		SendRow = 0;
		TotSms = 0;
		ScelectMo = "";
		int num = 6;
		int num2 = 3;
		if (ExelMsg)
		{
			num = 2;
			num2 = 0;
		}
		if (RateMsg)
		{
			num = 5;
			num2 = 2;
		}
		if (CboSmsType.SelectedIndex == 2)
		{
			num = 7;
			num2 = 3;
		}
		lblSmsCount.Text = Conversions.ToString(0);
		_ = tMsg.Text;
		int num3 = 0;
		checked
		{
			if (whatsApp.CurrentState == Module_WhatsApp.WhatsAppState.Ready)
			{
				foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
				{
					DataGridViewRow val = item;
					try
					{
						if (Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
						{
							ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
							TotSms++;
							if (Operators.CompareString(ScelectMo, "", false) != 0)
							{
								string text = ((Operators.CompareString(TxtUniCode.Text, "", false) == 0) ? Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(val.Cells[num].Value, (object)Environment.NewLine), (object)"Dear "), val.Cells[num2].Value), (object)Environment.NewLine), (object)""), (object)tMsg.Text))) : Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(val.Cells[num].Value, (object)Environment.NewLine), (object)"Dear "), val.Cells[num2].Value), (object)Environment.NewLine), (object)""), (object)TxtUniCode.Text))));
								num3++;
								string text2 = DC_Main.MsCountryId + ScelectMo;
								string text3 = (string.IsNullOrEmpty(text) ? null : text);
								string text4 = (string.IsNullOrEmpty(tBoxAttach.Text) ? null : tBoxAttach.Text);
								if (text2 != null && (text3 != null || text4 != null))
								{
									int i = 0;
									int num4 = 2;
									bool flag = false;
									string text5 = "";
									for (; i < num4; i++)
									{
										if (flag)
										{
											break;
										}
										if (i > 0)
										{
											Console.WriteLine($"Retry {i} for number: {text2}");
											await Task.Delay(3000);
										}
										(bool, string) tuple = await whatsApp.SendMessageAsync(text2, text3, text4);
										flag = tuple.Item1;
										text5 = tuple.Item2;
									}
									Application.DoEvents();
									if (flag)
									{
										val.Cells[4].Value = "Sent";
									}
									else
									{
										val.Cells[4].Value = "Not Sent: " + text5;
									}
									if (Convert.ToInt32(numDelay.Value) > 0)
									{
										await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
									}
									num3++;
									if (num3 == 27)
									{
										num3 = 0;
										if (Convert.ToInt32(numDelay.Value) > 0)
										{
											await Task.Delay(Convert.ToInt32(numDelay.Value) * 1000);
										}
										if (Operators.CompareString(DC_Main.IdWappIdNo, "", false) != 0)
										{
											await whatsApp.SendMessageAsync(DC_Main.IdWappIdNo, "hi");
										}
									}
									((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Selected = true;
								}
							}
							lblSmsCount.Text = Conversions.ToString(TotSms);
							ProgressBar progressBar;
							ProgressBar val2 = (progressBar = ProgressBar1);
							progressBar.Value = val2.Value + 1;
							Application.DoEvents();
						}
					}
					catch (Exception projectError)
					{
						ProjectData.SetProjectError(projectError);
						ProjectData.ClearProjectError();
					}
				}
				return;
			}
			MessageBox.Show("WhatsApp not ready. Current state: " + whatsApp.CurrentState);
		}
	}

	private void CboSmsType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("0"))
		{
			lblAcGroup.Text = "Ac Group";
			btnAcOs.Text = "Party Os";
		}
		else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("1"))
		{
			lblAcGroup.Text = "Cust Group";
		}
		else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("2"))
		{
			lblAcGroup.Text = "Schm Code";
			btnAcOs.Text = "Scheme Os";
		}
		AcGroupDetl();
	}

	private void AcGroupDetl()
	{
		cboAcGroup.Items.Clear();
		checked
		{
			if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("0"))
			{
				DC_Main.RsQry = "SELECT A.AC_GR As GrCode,B.AC_GR_NAME as GrName FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_GR,B.AC_GR_NAME  ORDER BY A.AC_GR";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AryGroup = new string[DC_Main.Rshlp.Rows.Count + 1];
					AryGroup[DC_Main.X] = "";
					cboAcGroup.Items.Add((object)"");
					int num = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num)
					{
						cboAcGroup.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["GrName"]), (object)""));
						AryGroup[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboAcGroup.Items.Add((object)"");
					AryGroup[DC_Main.X] = "";
				}
				cboAcGroup.SelectedIndex = 0;
			}
			else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("1"))
			{
				DC_Main.RsQry = "SELECT A.AC_GR As GrCode FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY A.AC_GR  ORDER BY A.AC_GR";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboAcGroup.Items.Add((object)"");
					int num2 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num2)
					{
						cboAcGroup.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboAcGroup.Items.Add((object)"");
					AryGroup[DC_Main.X] = "";
				}
				cboAcGroup.SelectedIndex = 0;
			}
			else
			{
				if ((double)CboSmsType.SelectedIndex != Conversions.ToDouble("2"))
				{
					return;
				}
				DC_Main.RsQry = "SELECT A.SCHM_CODE As GrCode,A.SCHM_NAME as GrName FROM AD_MAST AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.SCHM_CODE";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.X = 0;
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					AryGroup = new string[DC_Main.Rshlp.Rows.Count + 1];
					AryGroup[DC_Main.X] = "";
					cboAcGroup.Items.Add((object)"");
					int num3 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 0;
					while (DC_Main.X <= num3)
					{
						cboAcGroup.Items.Add(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)"-"), DC_Main.Rshlp.Rows[DC_Main.X]["GrName"]), (object)""));
						AryGroup[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrCode"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboAcGroup.Items.Add((object)"");
					AryGroup[DC_Main.X] = "";
				}
				cboAcGroup.SelectedIndex = 0;
			}
		}
	}

	private void DISPLAY_DATA()
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
		}
		MainUser = DC_Main.MCo_User;
		tCountryCode.Text = DC_Main.MsCountryId;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		if (CboSmsType.SelectedIndex == 0)
		{
			PatyMast();
		}
		else if (CboSmsType.SelectedIndex == 1)
		{
			AddressMast();
		}
		else if (CboSmsType.SelectedIndex == 2)
		{
			MembMast();
		}
		nFromRow.Text = Conversions.ToString(1);
		nToRow.Text = Conversions.ToString(250);
	}

	private void AddressMast()
	{
		//IL_01cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028b: Expected O, but got Unknown
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0218: Expected O, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_023d: Expected O, but got Unknown
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0262: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" "));
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + cboAcGroup.Text + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CITY =  '" + cboCity.Text + "'";
		}
		DC_Main.RsQry += "ORDER BY A.AC_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = 50;
				((DataGridView)dGV).Columns.Add("", "AcCode");
				((DataGridView)dGV).Columns[2].Width = 100;
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[3].Width = 270;
				((DataGridView)dGV).Columns.Add("", "Address");
				((DataGridView)dGV).Columns[4].Width = 225;
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[5].Width = 150;
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[6].Width = 110;
				((DataGridView)dGV).Columns.Add("", "Mobile2");
				((DataGridView)dGV).Columns[7].Width = 110;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void MembMast()
	{
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_028b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0292: Expected O, but got Unknown
		//IL_0210: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Unknown result type (might be due to invalid IL or missing references)
		//IL_021f: Expected O, but got Unknown
		//IL_0235: Unknown result type (might be due to invalid IL or missing references)
		//IL_023a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0244: Expected O, but got Unknown
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0269: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.* FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND A.AC_MOBILE <> ''")), (object)" "));
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.SCHM_CODE =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CITY =  '" + cboCity.Text + "'";
		}
		DC_Main.RsQry += "ORDER BY A.SCHM_CODE,A.MEMB_CODE";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = 50;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = 50;
				((DataGridView)dGV).Columns.Add("", "SchmCode");
				((DataGridView)dGV).Columns[2].Width = 100;
				((DataGridView)dGV).Columns.Add("", "MembCode");
				((DataGridView)dGV).Columns[3].Width = 100;
				((DataGridView)dGV).Columns.Add("", "MembName");
				((DataGridView)dGV).Columns[4].Width = 270;
				((DataGridView)dGV).Columns.Add("", "Address");
				((DataGridView)dGV).Columns[5].Width = 225;
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[6].Width = 150;
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[7].Width = 110;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["SCHM_CODE"]);
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["MEMB_CODE"]);
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["MEMB_NAME"]);
					((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void PatyMast()
	{
		//IL_023c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_02f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fa: Expected O, but got Unknown
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ac: Expected O, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" AND A.AC_CODE > '00100'  "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND AC_MOBILE <> ''")), (object)" AND CAST(AC_CODE AS INT) > 99  "));
		}
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboArea.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
		}
		if (Operators.CompareString(cboCity.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_CITY =  '" + cboCity.Text + "'";
		}
		DC_Main.RsQry += "ORDER BY A.AC_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = 40;
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = 40;
				((DataGridView)dGV).Columns.Add("", "AcCode");
				((DataGridView)dGV).Columns[2].Width = 80;
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[3].Width = 250;
				((DataGridView)dGV).Columns.Add("", "Address");
				((DataGridView)dGV).Columns[4].Width = 200;
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[5].Width = 130;
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[6].Width = 100;
				((DataGridView)dGV).Columns.Add("", "Mobile2");
				((DataGridView)dGV).Columns[7].Width = 100;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CODE"]);
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void CLEAR_DATA()
	{
		BtnCancel_Click(BtnCancel, new EventArgs());
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void UT_WHATSAPP_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_WHATSAPP_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
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
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(tMsg.Text, "", false) == 0)
					{
						Interaction.MsgBox((object)"Please First Type Massage and Try...", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001;
					}
					DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_TYPE = '" + tsmstype.Text + "'");
					if (Operators.CompareString(tsmstype.Text, "", false) != 0)
					{
						DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','" + tsmstype.Text + "','E','" + Strings.Mid(tMsg.Text, 1, 500) + "')";
					}
					else
					{
						DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','N','E','" + Strings.Mid(tMsg.Text, 1, 500) + "')";
					}
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Interaction.MsgBox((object)"Data Is Save Ok...", (MsgBoxStyle)0, (object)null);
					BtnCancel_Click(BtnCancel, new EventArgs());
					goto end_IL_0001;
				case 443:
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
				try0001_dispatch = 443;
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
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Invalid comparison between Unknown and I4
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if ((int)Interaction.MsgBox((object)"Record will delete permantley ?", (MsgBoxStyle)20, (object)null) == 6)
		{
			DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_DETL = '" + tMsg.Text + "'");
			Interaction.MsgBox((object)"Sms Recotd Delete Sussesfuli...", (MsgBoxStyle)0, (object)null);
			BtnCancel_Click(BtnCancel, new EventArgs());
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
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
		}
		MainUser = DC_Main.MCo_User;
		tMsg.Text = "";
		tCountryCode.Text = DC_Main.MsCountryId;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		CboSmsType.SelectedIndex = 0;
		cboCity.SelectedIndex = 0;
		cboArea.SelectedIndex = 0;
		AcGroupDetl();
		EntryMode = "A";
		((Control)nFromOs).Focus();
	}

	private void UT_WHATSAPP_Closed(object sender, EventArgs e)
	{
		//IL_00c3: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			if (Operators.CompareString(((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text, "Whatsapp Open", false) == 0)
			{
				if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
				{
					((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
				}
				else
				{
					((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
				}
				return;
			}
			whatsApp.Destroy();
			((ButtonBase)MyProject.Forms.MDI_FORM.chkWappId).Text = "Whatsapp Open";
			MyProject.Forms.MDI_FORM.chkWappId.Checked = false;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void nToOs_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void nFromOs_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(nFromOs.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void CboSmsType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnAc_Click(object sender, EventArgs e)
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY AC_NAME";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
		}
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[6];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 220.0;
		DC_Main.ColWidth[3] = 120.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[3], "", false) != 0)
		{
			tMobileNo.Text = DC_Main.ColValue[3];
			((Control)tMsg).Focus();
		}
	}

	private void BtnMemb_Click(object sender, EventArgs e)
	{
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT MEMB_NAME As AcNameL,MEMB_CODE as AcCodeL, SCHM_CODE AS SchmCode,AC_ADD1 AS AddressL,AC_CITY AS CityL,AC_MOBILE FROM AD_MEMB   WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY MEMB_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[7];
		DC_Main.ColWidth[0] = 350.0;
		DC_Main.ColWidth[1] = 110.0;
		DC_Main.ColWidth[2] = 110.0;
		DC_Main.ColWidth[3] = 230.0;
		DC_Main.ColWidth[4] = 180.0;
		DC_Main.ColWidth[5] = 150.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
		{
			tMobileNo.Text = DC_Main.ColValue[5];
			((Control)tMsg).Focus();
		}
	}

	private void ChkAllRow_CheckedChanged(object sender, EventArgs e)
	{
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		if (!chkAllRow.Checked)
		{
			return;
		}
		double num = 1.0;
		checked
		{
			if ((Conversion.Val(nFromRow.Text) != 0.0) & (Conversion.Val(nToRow.Text) != 0.0))
			{
				int num2 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					((DataGridView)DGV)[0, DC_Main.M].Value = false;
					DC_Main.M++;
				}
				if (Conversion.Val((object)((DataGridView)DGV).Rows.Count) < Conversion.Val(nToRow.Text))
				{
					nToRow.Text = Conversions.ToString(Conversion.Val((object)((DataGridView)DGV).Rows.Count));
				}
				if (Conversion.Val(nToRow.Text) < Conversion.Val(nFromRow.Text))
				{
					Interaction.MsgBox((object)"You Cant Set From Row > To row Please change it...", (MsgBoxStyle)0, (object)null);
					((Control)nFromRow).Focus();
					return;
				}
				double a = Conversion.Val(nFromRow.Text) - 1.0;
				double a2 = Conversion.Val(nToRow.Text) - 1.0;
				int m = (int)Math.Round(a);
				int num3 = (int)Math.Round(a2);
				DC_Main.M = m;
				while (DC_Main.M <= num3)
				{
					num += 1.0;
					((DataGridView)DGV)[0, DC_Main.M].Value = true;
					DC_Main.M++;
				}
				lblSmsRow.Text = Conversions.ToString(num);
			}
			else
			{
				int num4 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num4)
				{
					((DataGridView)DGV)[0, DC_Main.M].Value = true;
					DC_Main.M++;
				}
				lblSmsRow.Text = Conversions.ToString(DC_Main.M);
			}
		}
	}

	private void BtnOk_Click(object sender, EventArgs e)
	{
		OsMsg = false;
		RateMsg = false;
		ExelMsg = false;
		SchmOsMsg = false;
		chkAllRow.Checked = false;
		RateSend = "N";
		DISPLAY_DATA();
	}

	private static DataTable ImportExceltoDatatable(string filepath)
	{
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Expected O, but got Unknown
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		DataTable dataTable = new DataTable();
		DataTable result;
		try
		{
			DataSet dataSet = new DataSet();
			string text = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
			OleDbConnection val = new OleDbConnection(text ?? "");
			val.Open();
			object objectValue = RuntimeHelpers.GetObjectValue(val.GetSchema("Tables").Rows[0]["TABLE_NAME"]);
			string text2 = $"SELECT * FROM [{RuntimeHelpers.GetObjectValue(objectValue)}]";
			OleDbDataAdapter val2 = new OleDbDataAdapter(text2, val);
			((DbDataAdapter)(object)val2).Fill(dataSet);
			dataTable = dataSet.Tables[0];
			result = dataTable;
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Interaction.MsgBox((object)Information.Err().Description, (MsgBoxStyle)16, (object)null);
			result = dataTable;
			ProjectData.ClearProjectError();
		}
		return result;
	}

	private void BtnExlImport_Click(object sender, EventArgs e)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_0127: Expected O, but got Unknown
		//IL_0284: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Invalid comparison between Unknown and I4
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Expected O, but got Unknown
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0100: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Invalid comparison between Unknown and I4
		chkAllRow.Checked = false;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		RateSend = "N";
		DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(250.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Address");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(190.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "City");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridViewColumn)val).Name = "Select";
			dGV = null;
		}
		if ((int)Interaction.MsgBox((object)"Import Excel Data....?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		((FileDialog)DlgOpn).Filter = "Excel files |*.xls;*.xlsx";
		((FileDialog)DlgOpn).Title = "Open File";
		if ((int)((CommonDialog)DlgOpn).ShowDialog() == 1)
		{
			DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpn).FileName);
			DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
			checked
			{
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV2).Rows.Add();
					((DataGridView)dGV2)[1, DC_Main.i].Value = DC_Main.i;
					((DataGridView)dGV2)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i][0]);
					((DataGridView)dGV2)[3, DC_Main.i].Value = "";
					((DataGridView)dGV2)[4, DC_Main.i].Value = "";
					((DataGridView)dGV2)[5, DC_Main.i].Value = "";
					DC_Main.i++;
				}
				dGV2 = null;
				nFromRow.Text = Conversions.ToString(1);
				nToRow.Text = Conversions.ToString(250);
				OsMsg = false;
				SchmOsMsg = false;
				RateMsg = false;
				ExelMsg = true;
			}
		}
	}

	private void tMsg_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode == 112)
		{
			DC_Main.RsQry = "SELECT MSG_DETL As SmsDescL,MSG_TYPE As TypeM FROM MSG_MAST WHERE MSG_DETL <> ''  ORDER BY MSG_DETL";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 700.0;
			DC_Main.ColWidth[1] = 50.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose && Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
			{
				tMsg.Text = DC_Main.ColValue[0];
				tsmstype.Text = DC_Main.ColValue[1];
			}
		}
	}

	private void CboBarth_SelectedIndexChanged(object sender, EventArgs e)
	{
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_086f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0879: Expected O, but got Unknown
		//IL_0926: Unknown result type (might be due to invalid IL or missing references)
		//IL_092d: Expected O, but got Unknown
		//IL_08ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ba: Expected O, but got Unknown
		//IL_08d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected O, but got Unknown
		//IL_08f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0904: Expected O, but got Unknown
		if (cboBarth.SelectedIndex == 0)
		{
			tMsg.Text = "";
		}
		if (cboBarth.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "   AND   MONTH(BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " or  DAY(L_BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(L_BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or DAY(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
		}
		else if (cboBarth.SelectedIndex == 3)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND DAY(AN_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + " AND   MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + "  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(AN_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND DAY(ANV_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)"  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
		}
		else
		{
			if (cboBarth.SelectedIndex != 1)
			{
				return;
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,L_BR_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND (DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " or  DAY(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " or  DAY(L_BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(L_BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + ")  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,L_BR_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BR_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,L_BR_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BIRTH_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(L_BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "));
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		DC_Main.i = 1;
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
			return;
		}
		bool flag = false;
		if (DC_Main.Tbl.Rows.Count <= 0 || ((DataGridView)DGV).Rows.Count > 0)
		{
			return;
		}
		DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
		((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)dGV).AutoGenerateColumns = false;
		DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
		((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
		((DataGridView)dGV).Columns[0].Width = 50;
		((DataGridViewColumn)val).Name = "Ok";
		((DataGridView)dGV).Columns.Add("", "SrNo");
		checked
		{
			((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(270.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Address");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(225.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "City");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile2");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
				if (cboBarth.SelectedIndex == 2)
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"B - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				}
				else if (cboBarth.SelectedIndex == 3)
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"A - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				}
				else if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["BR_DATE"])) & (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["BR_DATE"], (object)"")), 1, 2), Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2), false) == 0))
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"B - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				}
				else if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AN_DATE"])) & (Operators.CompareString(Strings.Mid(Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[DC_Main.i]["AN_DATE"], (object)"")), 1, 2), Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2), false) == 0))
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"A - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				}
				else if (!Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["L_BR_DATE"])))
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"BL - ", DC_Main.Tbl.Rows[DC_Main.i]["AcType"]), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				}
				((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
				((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
				((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
				((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
				DC_Main.i++;
			}
			dGV = null;
		}
	}

	private void BtnExcel_Click(object sender, EventArgs e)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		object obj = default(object);
		int num6 = default(int);
		object obj2 = default(object);
		object obj3 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num9 = default(int);
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
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1455:
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
								goto IL_001e;
							case 4:
							case 5:
								goto IL_0034;
							case 6:
								goto IL_004b;
							case 7:
								goto IL_007d;
							case 8:
								goto IL_00a5;
							case 9:
								goto IL_00ae;
							case 10:
								goto IL_00d6;
							case 11:
								goto IL_0109;
							case 12:
								goto IL_0120;
							case 13:
								goto IL_0168;
							case 14:
								goto IL_0177;
							case 15:
								goto IL_0194;
							case 16:
								goto IL_01ae;
							case 17:
								goto IL_01d1;
							case 18:
							case 19:
								goto IL_0226;
							case 20:
								goto IL_0238;
							case 21:
								goto IL_0253;
							case 22:
								goto IL_025d;
							case 23:
								goto IL_02b0;
							case 24:
								goto IL_0305;
							case 25:
								goto IL_035d;
							case 26:
								goto IL_03cb;
							case 27:
								goto IL_040e;
							case 28:
								goto IL_043d;
							case 29:
								goto IL_0480;
							case 30:
								goto IL_04c1;
							case 31:
								goto IL_04e2;
							case 32:
								goto IL_04f0;
							case 33:
								goto IL_04f6;
							case 34:
								goto IL_04fc;
							case 35:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 36:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_0226:
						num2 = 19;
						num5++;
						goto IL_022f;
						IL_0120:
						num2 = 12;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0168;
						IL_01d1:
						num2 = 17;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0226;
						IL_0168:
						num2 = 13;
						num6++;
						goto IL_0171;
						IL_001e:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0034:
						num2 = 5;
						obj2 = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
						goto IL_004b;
						IL_004b:
						num2 = 6;
						obj3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
						goto IL_007d;
						IL_007d:
						num2 = 7;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00a5;
						IL_00a5:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_00ae;
						IL_00ae:
						num2 = 9;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj3, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00d6;
						IL_00d6:
						num2 = 10;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0109;
						IL_0109:
						num2 = 11;
						num7 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_0171;
						IL_0171:
						if (num6 <= num7)
						{
							goto IL_0120;
						}
						goto IL_0177;
						IL_0177:
						num2 = 14;
						num8 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0247;
						IL_0247:
						if (DC_Main.i <= num8)
						{
							goto IL_0194;
						}
						goto IL_0253;
						IL_0253:
						num2 = 21;
						colorConverter = new ColorConverter();
						goto IL_025d;
						IL_025d:
						num2 = 22;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_02b0;
						IL_02b0:
						num2 = 23;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0305;
						IL_0305:
						num2 = 24;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_035d;
						IL_035d:
						num2 = 25;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_03cb;
						IL_03cb:
						num2 = 26;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_040e;
						IL_040e:
						num2 = 27;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_043d;
						IL_043d:
						num2 = 28;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0480;
						IL_0480:
						num2 = 29;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_04c1;
						IL_04c1:
						num2 = 30;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_04e2;
						IL_04e2:
						num2 = 31;
						Cursor.Current = Cursors.Default;
						goto IL_04f0;
						IL_04f0:
						num2 = 32;
						obj = null;
						goto IL_04f6;
						IL_04f6:
						num2 = 33;
						obj3 = null;
						goto IL_04fc;
						IL_04fc:
						num2 = 34;
						obj2 = null;
						break;
						IL_0194:
						num2 = 15;
						num9 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_022f;
						IL_022f:
						if (num5 <= num9)
						{
							goto IL_01ae;
						}
						goto IL_0238;
						IL_0238:
						num2 = 20;
						DC_Main.i++;
						goto IL_0247;
						IL_01ae:
						num2 = 16;
						if (((DataGridView)DGV)[num5, DC_Main.i].Value != null)
						{
							goto IL_01d1;
						}
						goto IL_0226;
						end_IL_0001_2:
						break;
					}
					num2 = 35;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1455;
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

	private void TxtUniCode_Change()
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		lblMsgLenth.Text = Conversions.ToString(Strings.Len(TxtUniCode.Text));
		if ((Strings.Len(TxtUniCode.Text) > 1000) & !MsgLess)
		{
			MsgLess = true;
			Interaction.MsgBox((object)"If Message Character Grater Tehn 1000 then 2 Message Balance Deduct", (MsgBoxStyle)0, (object)null);
		}
	}

	private void BtnTanslat_Click(object sender, EventArgs e)
	{
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		Translator translator = new Translator();
		TxtUniCode.Text = string.Empty;
		((Control)TxtUniCode).Update();
		_translationSpeakUrl = null;
		try
		{
			((Control)this).Cursor = Cursors.WaitCursor;
			TxtUniCode.Text = translator.Translate(tMsg.Text.Trim(), Conversions.ToString(_comboFrom.SelectedItem), Conversions.ToString(_comboTo.SelectedItem));
			if (translator.Error == null)
			{
				((Control)TxtUniCode).Update();
				_translationSpeakUrl = translator.TranslationSpeechUrl;
			}
			else
			{
				MessageBox.Show(translator.Error.Message, ((Form)this).Text, (MessageBoxButtons)0, (MessageBoxIcon)48);
			}
			tMsg.Text = "";
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message, ((Form)this).Text, (MessageBoxButtons)0, (MessageBoxIcon)48);
			ProjectData.ClearProjectError();
		}
		finally
		{
			((Control)this).Cursor = Cursors.Default;
		}
	}

	private void BtnWappInstall_Click(object sender, EventArgs e)
	{
		Initialization();
	}

	private void BtnAcOs_Click(object sender, EventArgs e)
	{
		//IL_0199: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a3: Expected O, but got Unknown
		//IL_024f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_01d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01da: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Expected O, but got Unknown
		//IL_01fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		//IL_022e: Expected O, but got Unknown
		//IL_04da: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fb3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1017: Unknown result type (might be due to invalid IL or missing references)
		//IL_1021: Expected O, but got Unknown
		//IL_10ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_10d5: Expected O, but got Unknown
		//IL_1053: Unknown result type (might be due to invalid IL or missing references)
		//IL_1058: Unknown result type (might be due to invalid IL or missing references)
		//IL_1062: Expected O, but got Unknown
		//IL_1078: Unknown result type (might be due to invalid IL or missing references)
		//IL_107d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1087: Expected O, but got Unknown
		//IL_109d: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ac: Expected O, but got Unknown
		tMsg.Text = "";
		chkAllRow.Checked = false;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		RateSend = "N";
		checked
		{
			if (CboSmsType.SelectedIndex == 2)
			{
				DC_Main.RsQry = "SELECT A.CO_CODE,A.LC_CODE,A.SCHM_CODE,A.MEMB_CODE,A.MEMB_AMT AS MembAmt,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE,  (SELECT TOP 1 C.SCHM_DATE FROM AD_DATA AS C WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND C.SCHM_CODE = A.SCHM_CODE AND C.MEMB_CODE = A.MEMB_CODE  ORDER BY C.SCHM_DATE DESC) As LastRecDt   FROM AD_MEMB AS A  WHERE a.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND DAY(A.JOIN_DATE) >= '" + Strings.Format((object)DC_Main.MsSysDate, "dd") + "' AND DAY(A.JOIN_DATE) <= '" + Strings.Format((object)DC_Main.MsSysDate, "dd") + "' AND A.EXP_DATE >= '" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "' GROUP BY  A.CO_CODE,A.LC_CODE,A.SCHM_CODE,A.MEMB_CODE,A.MEMB_AMT,A.MEMB_NAME,A.JOIN_DATE,A.AC_MOBILE ORDER BY A.SCHM_CODE,A.MEMB_CODE ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				((DataGridView)DGV).DataSource = null;
				((DataGridView)DGV).Columns.Clear();
				((DataGridView)DGV).Rows.Clear();
				((Control)DGV).Refresh();
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
				((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridViewColumn)val).Name = "Ok";
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Schm");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Memb");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "MembName");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(250.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "JoinDate");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "LastRecDt");
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "MobileNo");
				((DataGridView)dGV).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "MembAmt");
				((DataGridView)dGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV).Columns[8].DefaultCellStyle.Format = "N2";
				if (DC_Main.Tbl.Rows.Count == 0)
				{
					Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
					return;
				}
				DateTime now = DateAndTime.Now;
				DateTime now2 = DateAndTime.Now;
				DC_Main.X = 0;
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.MEMB_AMT,B.JOIN_DATE,A.SCHM_DATE,B.EXP_DATE FROM AD_DATA AS A LEFT JOIN AD_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.SCHM_CODE = B.SCHM_CODE AND A.MEMB_CODE = B.MEMB_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.SCHM_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]), (object)"' AND A.MEMB_CODE = '"), DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]), (object)"' AND MONTH(SCHM_DATE) = '"), (object)Strings.Format((object)Conversions.ToDate(DC_Main.Tbl.Rows[DC_Main.X]["JOIN_DATE"]), "MM")), (object)"' AND B.EXP_DATE >= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"'  ORDER BY A.SCHM_DATE DESC "));
					DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable.Rows.Count >= 0)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.X].Value = DC_Main.X + 1;
						((DataGridView)dGV)[2, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["SCHM_CODE"]);
						((DataGridView)dGV)[3, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_CODE"]);
						((DataGridView)dGV)[4, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MEMB_NAME"]);
						((DataGridView)dGV)[5, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["JOIN_DATE"]), "dd/MM/yyyy") ?? "";
						((DataGridView)dGV)[6, DC_Main.X].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["LastRecDt"]), "dd/MM/yyyy") ?? "";
						((DataGridView)dGV)[7, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["AC_MOBILE"]);
						((DataGridView)dGV)[8, DC_Main.X].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["MembAmt"]);
					}
					DC_Main.X++;
				}
				dGV = null;
				DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE IN ('O') ORDER BY MSG_TYPE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
				}
				if (Operators.CompareString(tMsg.Text, "", false) == 0)
				{
					tMsg.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer Your Scheme Amount is Due of This Month Please Pay...";
				}
				nFromRow.Text = Conversions.ToString(1);
				nToRow.Text = Conversions.ToString(250);
				SchmOsMsg = true;
				OsMsg = false;
				RateMsg = false;
				ExelMsg = false;
				return;
			}
			DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' and A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM425NEKU", false) == 0, (object)"AND  B.AC_GR IN ('20','19')", RuntimeHelpers.GetObjectValue(Interaction.IIf((Operators.CompareString(DC_Main.SSRegSrNo, "HM269NEHP", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK029NEVK", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM404NSHM", false) == 0), (object)"", (object)"AND  B.AC_GR = '20'")))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO "), (object)" HAVING (round(Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) + "), (object)" (round(Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) + "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00'))+ "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END)) else 0 end,'0.00')) <> 0 "), (object)" ORDER BY B.AC_NAME "));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrAmt"], (object)0, false))
				{
					num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrAmt"]), "0.00"));
				}
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrGold"], (object)0, false))
				{
					num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrGold"]), "0.000"));
				}
				if (Operators.ConditionalCompareObjectNotEqual(DC_Main.Rshlp.Rows[DC_Main.X]["DrSilver"], (object)0, false))
				{
					num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["DrSilver"]), "0.000"));
				}
				if (num2 + num3 + num4 != 0.0)
				{
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,"), (object)Math.Abs(num2)), (object)",0,"), (object)Math.Abs(num3)), (object)",0,"), (object)Math.Abs(num4)), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
					DC_Main.ExeQuteDc(DC_Main.RsQry);
				}
				DC_Main.X++;
			}
			DC_Main.RsQry = "SELECT A.DR_AMT,A.DR_FINE_WT,A.DR_SL_FINE,B.AC_NAME,B.AC_ADD1,B.AC_CITY,B.AC_MOBILE,B.AC_MOBILE2 FROM LEDR_AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ";
			if (Conversion.Val(nFromOs.Text) != 0.0)
			{
				DC_Main.RsQry = (DC_Main.RsQry + " AND A.DR_AMT >= " + nFromOs.Text) ?? "";
			}
			if (Conversion.Val(nToOs.Text) != 0.0)
			{
				DC_Main.RsQry = (DC_Main.RsQry + " AND A.DR_AMT <= " + nToOs.Text) ?? "";
			}
			if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
			}
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.AC_AREA =  '" + cboArea.Text + "'";
			}
			DC_Main.RsQry += " ORDER BY B.AC_NAME";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.i = 1;
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				Interaction.MsgBox((object)"No Record Found....", (MsgBoxStyle)0, (object)null);
				return;
			}
			bool flag = false;
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				((DataGridView)dGV2).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)dGV2).AutoGenerateColumns = false;
				DataGridViewCheckBoxColumn val2 = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV2).Columns.Add((DataGridViewColumn)(object)val2);
				((DataGridView)dGV2).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridViewColumn)val2).Name = "Ok";
				((DataGridView)dGV2).Columns.Add("", "SrNo");
				((DataGridView)dGV2).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV2).Columns.Add("", "AmountOs");
				((DataGridView)dGV2).Columns[2].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)dGV2).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV2).Columns[2].DefaultCellStyle.Format = "N2";
				((DataGridView)dGV2).Columns.Add("", "GoldOs");
				((DataGridView)dGV2).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)dGV2).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV2).Columns[3].DefaultCellStyle.Format = "N3";
				((DataGridView)dGV2).Columns.Add("", "SilverOs");
				((DataGridView)dGV2).Columns[4].Width = (int)Math.Round(85.0 * ColCon);
				((DataGridView)dGV2).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)dGV2).Columns[4].DefaultCellStyle.Format = "N2";
				((DataGridView)dGV2).Columns.Add("", "AcName");
				((DataGridView)dGV2).Columns[5].Width = (int)Math.Round(240.0 * ColCon);
				((DataGridView)dGV2).Columns.Add("", "Address");
				((DataGridView)dGV2).Columns[6].Width = (int)Math.Round(150.0 * ColCon);
				((DataGridView)dGV2).Columns.Add("", "City");
				((DataGridView)dGV2).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
				((DataGridView)dGV2).Columns.Add("", "Mobile");
				((DataGridView)dGV2).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV2).Columns.Add("", "Mobile2");
				((DataGridView)dGV2).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
				int num5 = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num5)
				{
					((DataGridView)dGV2).Rows.Add();
					((DataGridView)dGV2)[1, DC_Main.i].Value = DC_Main.i + 1;
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"])) != 0.0)
					{
						((DataGridView)dGV2)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"]);
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"])) != 0.0)
					{
						((DataGridView)dGV2)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"]);
					}
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"])) != 0.0)
					{
						((DataGridView)dGV2)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"]);
					}
					((DataGridView)dGV2)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
					((DataGridView)dGV2)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
					((DataGridView)dGV2)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
					((DataGridView)dGV2)[8, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
					((DataGridView)dGV2)[9, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
					DC_Main.i++;
				}
				dGV2 = null;
			}
			if (Operators.CompareString(tMsg.Text, "", false) == 0)
			{
				tMsg.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer, your due amount Is";
			}
			nFromRow.Text = Conversions.ToString(1);
			nToRow.Text = Conversions.ToString(250);
			OsMsg = true;
			RateMsg = false;
			ExelMsg = false;
			SchmOsMsg = false;
		}
	}

	private void BtnGoldRate_Click(object sender, EventArgs e)
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_03a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ad: Expected O, but got Unknown
		//IL_032b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_033a: Expected O, but got Unknown
		//IL_0350: Unknown result type (might be due to invalid IL or missing references)
		//IL_0355: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Expected O, but got Unknown
		//IL_0375: Unknown result type (might be due to invalid IL or missing references)
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0384: Expected O, but got Unknown
		tMsg.Text = "";
		chkAllRow.Checked = false;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		RateSend = "Y";
		DC_Main.RsQry = "select * from RATE_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (dataTable.Rows.Count > 0)
			{
				double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_GL_RATE"]), "0.00"));
				double num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_SL_RATE"]), "0.00"));
				DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = 'G'  ";
				DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable2.Rows.Count > 0)
				{
					tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[0]["MSG_DETL"], (object)" 999 Gold Rate = "), (object)num), (object)" And 999 Silver Rate = "), (object)num2), (object)" Have a Nice Day..."));
				}
				else
				{
					tMsg.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer Todays  999 Gold Rate = " + Conversions.ToString(num) + " And 999 Silver Rate = " + Conversions.ToString(num2) + " Have a Nice Day...";
				}
				DC_Main.RsQry = "SELECT A.* FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_MOBILE <> '' AND A.AC_GR = '20'";
				if (Operators.CompareString(cboArea.Text, "", false) != 0)
				{
					DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_AREA =  '" + cboArea.Text + "'";
				}
				DC_Main.RsQry += " ORDER BY  A.AC_NAME ";
				dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable2.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
					((DataGridView)dGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
					if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
					{
						((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
						((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
					}
					((DataGridView)dGV).AutoGenerateColumns = false;
					DataGridViewCheckBoxColumn val = new DataGridViewCheckBoxColumn();
					((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val);
					((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridViewColumn)val).Name = "Ok";
					((DataGridView)dGV).Columns.Add("", "SrNo");
					((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "AcName");
					((DataGridView)dGV).Columns[2].Width = (int)Math.Round(240.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Address");
					((DataGridView)dGV).Columns[3].Width = (int)Math.Round(210.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "City");
					((DataGridView)dGV).Columns[4].Width = (int)Math.Round(120.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Mobile");
					((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)dGV).Columns.Add("", "Mobile2");
					((DataGridView)dGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
					int num3 = dataTable2.Rows.Count - 1;
					DC_Main.i = 0;
					while (DC_Main.i <= num3)
					{
						((DataGridView)dGV).Rows.Add();
						((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
						((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_NAME"]);
						((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_ADD1"]);
						((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_CITY"]);
						((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_MOBILE"]);
						((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.i]["AC_MOBILE2"]);
						DC_Main.i++;
					}
					dGV = null;
				}
				nFromRow.Text = Conversions.ToString(1);
				nToRow.Text = Conversions.ToString(250);
				OsMsg = false;
				RateMsg = true;
				ExelMsg = false;
				SchmOsMsg = false;
			}
			else
			{
				Interaction.MsgBox((object)"Please Insert Daily Rate in Rate Master......", (MsgBoxStyle)0, (object)null);
			}
		}
	}

	private void BtnQuit_Click(object sender, EventArgs e)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			whatsApp.Destroy();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show(ex2.Message);
			ProjectData.ClearProjectError();
		}
	}

	private async void BtnLogout_Click(object sender, EventArgs e)
	{
		try
		{
			await whatsApp.Logout();
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

	private void BtnBrowse_Click(object sender, EventArgs e)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		DialogResult val = ((CommonDialog)openAttach).ShowDialog();
		if ((int)val == 1)
		{
			if (File.Exists(((FileDialog)openAttach).FileName))
			{
				tBoxAttach.Text = ((FileDialog)openAttach).FileName;
			}
			else
			{
				MessageBox.Show("File does not exists");
			}
		}
	}

	private void BtnClear_Click(object sender, EventArgs e)
	{
		((TextBoxBase)tBoxAttach).Clear();
	}

	private void CboMsgType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cboMsgType.SelectedIndex != 0)
		{
			tsmstype.Text = Strings.Mid(cboMsgType.Text, 1, 1);
			DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = '" + tsmstype.Text + "'";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
			}
		}
	}

	private void BtnDelyTime_Click(object sender, EventArgs e)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "UPDATE CO_SET_NEW SET WAPP_DELAY = " + Conversions.ToString(numDelay.Value) + " WHERE CO_CODE = '" + DC_Main.MCo_code + "'";
		DC_Main.ExeQuteDc(DC_Main.RsQry);
		Interaction.MsgBox((object)"Whatsapp Delay Time is Set....", (MsgBoxStyle)0, (object)null);
	}

	private void chkBoxHeadLess_Click(object sender, EventArgs e)
	{
		if (!chkBoxHeadLess.Checked)
		{
			((Control)chkBoxHeadLess).Enabled = false;
		}
	}

	private void PnlBotam_DoubleClick(object sender, EventArgs e)
	{
		((Control)chkBoxHeadLess).Enabled = true;
	}

	private void BtnHide_Click(object sender, EventArgs e)
	{
		((Control)this).Hide();
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 2)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void nFromRow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)nToRow).Focus();
		}
	}

	private void nToRow_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)chkAllRow).Focus();
		}
	}

	private void TMobileNo_TextChanged(object sender, EventArgs e)
	{
		if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
		{
			((Control)tCountryCode).Enabled = true;
		}
		else
		{
			((Control)tCountryCode).Enabled = false;
		}
	}

	private void BtnTextMsg_Click(object sender, EventArgs e)
	{
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		if (Conversion.Val(LblDays.Text) > 0.0)
		{
			DC_Main.RsQry = "SELECT CO_CODE FROM POINT_MAST WHERE CO_CODE = 'XX' ";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (dataTable.Rows.Count > 0)
			{
				DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE POINT_MAST SET POINT_CODE = '" + DC_Main.MCo_code + "',POINT_NAME = '" + DC_Main.MLc_code + "',SR_NO = " + Conversions.ToString(Conversion.Val(LblDays.Text)) + ",POINT_TYPE = "), Interaction.IIf(DC_Main.MsWappMember, (object)"'Y'", (object)"'N'")), (object)",MAIN_USER = '"), (object)DC_Main.MCo_year), (object)"'  WHERE CO_CODE = 'XX'")));
			}
			else
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO POINT_MAST(CO_CODE,SR_NO,POINT_CODE,POINT_NAME,POINT_TYPE,MAIN_USER) VALUES('XX'," + Conversions.ToString(Conversion.Val(LblDays.Text)) + ",'" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "',"), Interaction.IIf(DC_Main.MsWappMember, (object)"'Y'", (object)"'N'")), (object)",'"), (object)DC_Main.MCo_year), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
			}
			if (Operators.CompareString(DC_Main.SSCompSrNo1, "A/3QSKYY2/CNCMK009AK0067/Z", false) == 0)
			{
				File.WriteAllText("D:\\DataCareNext\\WappNextMsg\\NextEmp\\bin\\Debug\\SqlName.txt", DC_Main.SqlServer + Environment.NewLine + DC_Main.SqlData + Environment.NewLine + DC_Main.SqlMain);
				Process.Start("D:\\DataCareNext\\WappNextMsg\\NextEmp\\bin\\Debug\\NextEmp.exe");
			}
			else
			{
				File.WriteAllText(DC_Main.MSImageSavePath + "\\NextWapp\\SqlName.txt", DC_Main.SqlServer + Environment.NewLine + DC_Main.SqlData + Environment.NewLine + DC_Main.SqlMain);
				Process.Start(DC_Main.MSImageSavePath + "\\NextWapp\\NextEmp.exe");
			}
		}
		else
		{
			DC_Main.ExeQuteDc("DELETE FROM POINT_MAST WHERE CO_CODE = 'XX'");
			Interaction.MsgBox((object)"Your Subscription is Over... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
		}
	}

	private void nToRow_TextChanged(object sender, EventArgs e)
	{
	}
}
