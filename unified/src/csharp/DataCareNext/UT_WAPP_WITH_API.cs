using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using Newtonsoft.Json.Linq;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class UT_WAPP_WITH_API : Form
{
	public enum GridViewColumnType
	{
		TextBox,
		InvisibleTextBoxCell
	}

	private IContainer components;

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
	[AccessedThroughProperty("btnAcOs")]
	private QButton _btnAcOs;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnGoldRate")]
	private QButton _btnGoldRate;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboTemplate")]
	private ComboBox _cboTemplate;

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

	private bool Formload;

	private bool DgvData;

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

	private readonly string ACCESS_TOKEN;

	private readonly string PHONE_NUMBER_ID;

	private readonly string WABA_ID;

	private readonly string BASE_TRACK_URL;

	private readonly int MAX_CONCURRENT;

	private readonly int SEND_DELAY_MS;

	private List<string> numbersList;

	private DataTable dtStatus;

	private string tmpLANGUAGE;

	private string CurrentMediaId;

	private string CurrentMediaType;

	private string CurrentFileName;

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
	[AccessedThroughProperty("Timer1")]
	private virtual System.Windows.Forms.Timer _Timer1;

	internal virtual System.Windows.Forms.Timer Timer1
	{
		get
		{
			return _Timer1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Timer1 = value;
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
	[AccessedThroughProperty("txtFinalPreview")]
	private virtual RichTextBox _txtFinalPreview;

	internal virtual RichTextBox txtFinalPreview
	{
		get
		{
			return _txtFinalPreview;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_txtFinalPreview = value;
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

	internal virtual ComboBox cboTemplate
	{
		[CompilerGenerated]
		get
		{
			return _cboTemplate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = cboTemplate_SelectedIndexChanged;
			ComboBox val = _cboTemplate;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboTemplate = value;
			val = _cboTemplate;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlVariables")]
	private virtual Panel _pnlVariables;

	internal virtual Panel pnlVariables
	{
		get
		{
			return _pnlVariables;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlVariables = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("txtPreview")]
	private virtual TextBox _txtPreview;

	internal virtual TextBox txtPreview
	{
		get
		{
			return _txtPreview;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_txtPreview = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("pnlMedia")]
	private virtual Panel _pnlMedia;

	internal virtual Panel pnlMedia
	{
		get
		{
			return _pnlMedia;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_pnlMedia = value;
		}
	}

	public UT_WAPP_WITH_API()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += UT_WAPP_WITH_API_Load;
		((Form)this).Activated += UT_WAPP_WITH_API_Activated;
		((Form)this).Deactivate += UT_WAPP_WITH_API_Deactivate;
		((Control)this).KeyDown += new KeyEventHandler(UT_WAPP_WITH_API_KeyDown);
		((Form)this).Closed += UT_WAPP_WITH_API_Closed;
		sec = 0;
		ACCESS_TOKEN = DC_Main.MsWappApiKey;
		PHONE_NUMBER_ID = DC_Main.MsWappApiMobile;
		WABA_ID = DC_Main.MsWappApiId;
		BASE_TRACK_URL = "https://graph.facebook.com/v17.0";
		MAX_CONCURRENT = 6;
		SEND_DELAY_MS = 150;
		numbersList = new List<string>();
		dtStatus = new DataTable();
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
		//IL_01f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		//IL_020b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0215: Expected O, but got Unknown
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
		//IL_0265: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_027b: Expected O, but got Unknown
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0287: Expected O, but got Unknown
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Expected O, but got Unknown
		//IL_0295: Unknown result type (might be due to invalid IL or missing references)
		//IL_029f: Expected O, but got Unknown
		//IL_02a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_02ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b7: Expected O, but got Unknown
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
		//IL_0467: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ca: Expected O, but got Unknown
		//IL_05d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e0: Expected O, but got Unknown
		//IL_0643: Unknown result type (might be due to invalid IL or missing references)
		//IL_064d: Expected O, but got Unknown
		//IL_06f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0701: Expected O, but got Unknown
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0816: Expected O, but got Unknown
		//IL_0933: Unknown result type (might be due to invalid IL or missing references)
		//IL_093d: Expected O, but got Unknown
		//IL_09a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_09aa: Expected O, but got Unknown
		//IL_0a53: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a5d: Expected O, but got Unknown
		//IL_0ac0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aca: Expected O, but got Unknown
		//IL_0b73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7d: Expected O, but got Unknown
		//IL_0be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bea: Expected O, but got Unknown
		//IL_0c94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9e: Expected O, but got Unknown
		//IL_0df6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e00: Expected O, but got Unknown
		//IL_0e6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e78: Expected O, but got Unknown
		//IL_0f44: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f4e: Expected O, but got Unknown
		//IL_0fd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe3: Expected O, but got Unknown
		//IL_1061: Unknown result type (might be due to invalid IL or missing references)
		//IL_106b: Expected O, but got Unknown
		//IL_10e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_10f3: Expected O, but got Unknown
		//IL_119e: Unknown result type (might be due to invalid IL or missing references)
		//IL_11a8: Expected O, but got Unknown
		//IL_1256: Unknown result type (might be due to invalid IL or missing references)
		//IL_1260: Expected O, but got Unknown
		//IL_132b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1335: Expected O, but got Unknown
		//IL_13ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_13d4: Expected O, but got Unknown
		//IL_1452: Unknown result type (might be due to invalid IL or missing references)
		//IL_145c: Expected O, but got Unknown
		//IL_1534: Unknown result type (might be due to invalid IL or missing references)
		//IL_153e: Expected O, but got Unknown
		//IL_15a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15b1: Expected O, but got Unknown
		//IL_1851: Unknown result type (might be due to invalid IL or missing references)
		//IL_1875: Unknown result type (might be due to invalid IL or missing references)
		//IL_1899: Unknown result type (might be due to invalid IL or missing references)
		//IL_18bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_18e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f0: Expected O, but got Unknown
		//IL_1913: Unknown result type (might be due to invalid IL or missing references)
		//IL_198a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1994: Expected O, but got Unknown
		//IL_1a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a4f: Expected O, but got Unknown
		//IL_1ad7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ae1: Expected O, but got Unknown
		//IL_1d7f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1da3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e1e: Expected O, but got Unknown
		//IL_1e44: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ed8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ee2: Expected O, but got Unknown
		//IL_1fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fc1: Expected O, but got Unknown
		//IL_205a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2064: Expected O, but got Unknown
		//IL_2199: Unknown result type (might be due to invalid IL or missing references)
		//IL_21a3: Expected O, but got Unknown
		//IL_2278: Unknown result type (might be due to invalid IL or missing references)
		//IL_2282: Expected O, but got Unknown
		//IL_231b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2325: Expected O, but got Unknown
		//IL_243d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2447: Expected O, but got Unknown
		//IL_24fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_2508: Expected O, but got Unknown
		//IL_27b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_281c: Unknown result type (might be due to invalid IL or missing references)
		//IL_2845: Unknown result type (might be due to invalid IL or missing references)
		//IL_284f: Expected O, but got Unknown
		//IL_2872: Unknown result type (might be due to invalid IL or missing references)
		//IL_28fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_2904: Expected O, but got Unknown
		//IL_29ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d8: Expected O, but got Unknown
		//IL_2a81: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8b: Expected O, but got Unknown
		//IL_2b45: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b4f: Expected O, but got Unknown
		//IL_2c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_2c21: Expected O, but got Unknown
		//IL_2cad: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb7: Expected O, but got Unknown
		//IL_2d72: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d7c: Expected O, but got Unknown
		//IL_2e61: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e6b: Expected O, but got Unknown
		//IL_2e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f40: Expected O, but got Unknown
		//IL_2f77: Unknown result type (might be due to invalid IL or missing references)
		//IL_322c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3250: Unknown result type (might be due to invalid IL or missing references)
		//IL_3274: Unknown result type (might be due to invalid IL or missing references)
		//IL_3298: Unknown result type (might be due to invalid IL or missing references)
		//IL_32c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_32cb: Expected O, but got Unknown
		//IL_32ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_3552: Unknown result type (might be due to invalid IL or missing references)
		//IL_3576: Unknown result type (might be due to invalid IL or missing references)
		//IL_359a: Unknown result type (might be due to invalid IL or missing references)
		//IL_35be: Unknown result type (might be due to invalid IL or missing references)
		//IL_35e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_35f1: Expected O, but got Unknown
		//IL_3614: Unknown result type (might be due to invalid IL or missing references)
		//IL_36ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_36f7: Expected O, but got Unknown
		//IL_37af: Unknown result type (might be due to invalid IL or missing references)
		//IL_37b9: Expected O, but got Unknown
		//IL_3871: Unknown result type (might be due to invalid IL or missing references)
		//IL_387b: Expected O, but got Unknown
		//IL_3909: Unknown result type (might be due to invalid IL or missing references)
		//IL_3913: Expected O, but got Unknown
		//IL_39cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_39d5: Expected O, but got Unknown
		//IL_3a8d: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a97: Expected O, but got Unknown
		//IL_3b21: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b2b: Expected O, but got Unknown
		//IL_3bd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3bde: Expected O, but got Unknown
		//IL_3c6c: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c76: Expected O, but got Unknown
		//IL_3d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d48: Expected O, but got Unknown
		//IL_3dd4: Unknown result type (might be due to invalid IL or missing references)
		//IL_3dde: Expected O, but got Unknown
		//IL_3ea9: Unknown result type (might be due to invalid IL or missing references)
		//IL_3eb3: Expected O, but got Unknown
		//IL_3f42: Unknown result type (might be due to invalid IL or missing references)
		//IL_3f4c: Expected O, but got Unknown
		//IL_400c: Unknown result type (might be due to invalid IL or missing references)
		//IL_4016: Expected O, but got Unknown
		//IL_4046: Unknown result type (might be due to invalid IL or missing references)
		//IL_40ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_4124: Unknown result type (might be due to invalid IL or missing references)
		//IL_419b: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_WAPP_WITH_API));
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
		Label13 = new Label();
		cboBarth = new ComboBox();
		ChkOnlyMoNo = new CheckBox();
		lblAcGroup = new Label();
		cboAcGroup = new ComboBox();
		lblSmsCount = new Label();
		lblMsgLenth = new Label();
		Timer1 = new System.Windows.Forms.Timer(components);
		lblWhatsAppState = new Label();
		LblSenderId = new Label();
		statusRetriever = new System.Windows.Forms.Timer(components);
		openAttach = new OpenFileDialog();
		btnAcOs = new QButton();
		btnGoldRate = new QButton();
		ProgressBar1 = new ProgressBar();
		LblDays = new Label();
		Label7 = new Label();
		nFromRow = new TextBox();
		Label8 = new Label();
		Label9 = new Label();
		nToRow = new TextBox();
		txtFinalPreview = new RichTextBox();
		tCountryCode = new TextBox();
		Label10 = new Label();
		cboArea = new ComboBox();
		Label11 = new Label();
		cboCity = new ComboBox();
		Label12 = new Label();
		cboTemplate = new ComboBox();
		pnlVariables = new Panel();
		txtPreview = new TextBox();
		pnlMedia = new Panel();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
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
		lblBook.Text = "Whatsapp With Api";
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
		((Control)Label3).Location = new Point(17, 333);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(82, 20);
		((Control)Label3).TabIndex = 1158;
		Label3.Text = "Mobile No";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobileNo).BackColor = Color.White;
		((Control)tMobileNo).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobileNo).Location = new Point(153, 333);
		((TextBoxBase)tMobileNo).MaxLength = 10;
		((Control)tMobileNo).Name = "tMobileNo";
		((Control)tMobileNo).Size = new Size(150, 26);
		((Control)tMobileNo).TabIndex = 1157;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(24, 371);
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
		((Control)BtnSmsSend).Location = new Point(404, 329);
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
		((Control)BtnAc).Location = new Point(309, 333);
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
		((Control)BtnMemb).Location = new Point(349, 334);
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
		((Control)lblSmsRow).Location = new Point(255, 514);
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
		((Control)ChkOnlyMoNo).Location = new Point(1220, 214);
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
		((Control)lblSmsCount).Location = new Point(395, 514);
		((Control)lblSmsCount).Name = "lblSmsCount";
		((Control)lblSmsCount).Size = new Size(96, 20);
		((Control)lblSmsCount).TabIndex = 1186;
		lblSmsCount.Text = "Send Row";
		lblSmsCount.TextAlign = (ContentAlignment)64;
		((Control)lblMsgLenth).BackColor = Color.Transparent;
		((Control)lblMsgLenth).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMsgLenth).ForeColor = Color.FromArgb(192, 0, 0);
		lblMsgLenth.ImeMode = (ImeMode)0;
		((Control)lblMsgLenth).Location = new Point(110, 514);
		((Control)lblMsgLenth).Name = "lblMsgLenth";
		((Control)lblMsgLenth).Size = new Size(90, 20);
		((Control)lblMsgLenth).TabIndex = 1194;
		lblMsgLenth.Text = "Msg Lenth";
		lblMsgLenth.TextAlign = (ContentAlignment)16;
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
		((Control)ProgressBar1).Location = new Point(0, 542);
		((Control)ProgressBar1).Name = "ProgressBar1";
		((Control)ProgressBar1).Size = new Size(1309, 20);
		((Control)ProgressBar1).TabIndex = 1209;
		((Control)LblDays).BackColor = Color.Transparent;
		((Control)LblDays).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)LblDays).ForeColor = Color.FromArgb(192, 0, 0);
		LblDays.ImeMode = (ImeMode)0;
		((Control)LblDays).Location = new Point(120, 300);
		((Control)LblDays).Name = "LblDays";
		((Control)LblDays).Size = new Size(54, 20);
		((Control)LblDays).TabIndex = 1219;
		LblDays.Text = "0";
		LblDays.TextAlign = (ContentAlignment)32;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.FromArgb(192, 0, 0);
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(119, 267);
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
		((TextBoxBase)txtFinalPreview).BorderStyle = (BorderStyle)1;
		txtFinalPreview.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)txtFinalPreview).Location = new Point(110, 371);
		txtFinalPreview.MaxLength = 2500;
		((Control)txtFinalPreview).Name = "txtFinalPreview";
		((Control)txtFinalPreview).Size = new Size(382, 139);
		((Control)txtFinalPreview).TabIndex = 1225;
		txtFinalPreview.Text = "";
		((TextBoxBase)tCountryCode).BackColor = Color.White;
		((Control)tCountryCode).Enabled = false;
		((Control)tCountryCode).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tCountryCode).Location = new Point(111, 333);
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
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.Black;
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(498, 336);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(108, 20);
		((Control)Label12).TabIndex = 1251;
		Label12.Text = "Message Type";
		Label12.TextAlign = (ContentAlignment)64;
		cboTemplate.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboTemplate).Font = new Font("Arial", 9.75f);
		((ListControl)cboTemplate).FormattingEnabled = true;
		((Control)cboTemplate).Location = new Point(611, 335);
		((Control)cboTemplate).Margin = new Padding(2);
		((Control)cboTemplate).Name = "cboTemplate";
		((Control)cboTemplate).Size = new Size(171, 24);
		((Control)cboTemplate).TabIndex = 1250;
		((ScrollableControl)pnlVariables).AutoScroll = true;
		((Control)pnlVariables).Location = new Point(792, 335);
		((Control)pnlVariables).Margin = new Padding(2);
		((Control)pnlVariables).Name = "pnlVariables";
		((Control)pnlVariables).Size = new Size(383, 144);
		((Control)pnlVariables).TabIndex = 1252;
		((Control)txtPreview).Location = new Point(502, 371);
		((Control)txtPreview).Margin = new Padding(2);
		txtPreview.Multiline = true;
		((Control)txtPreview).Name = "txtPreview";
		((Control)txtPreview).Size = new Size(280, 163);
		((Control)txtPreview).TabIndex = 1253;
		((Control)pnlMedia).Location = new Point(792, 486);
		((Control)pnlMedia).Margin = new Padding(2);
		((Control)pnlMedia).Name = "pnlMedia";
		((Control)pnlMedia).Size = new Size(383, 48);
		((Control)pnlMedia).TabIndex = 1254;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)pnlMedia);
		((Control)this).Controls.Add((Control)(object)txtPreview);
		((Control)this).Controls.Add((Control)(object)pnlVariables);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)cboTemplate);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)cboCity);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)cboArea);
		((Control)this).Controls.Add((Control)(object)tCountryCode);
		((Control)this).Controls.Add((Control)(object)txtFinalPreview);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)nToRow);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)nFromRow);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)LblDays);
		((Control)this).Controls.Add((Control)(object)ProgressBar1);
		((Control)this).Controls.Add((Control)(object)btnGoldRate);
		((Control)this).Controls.Add((Control)(object)btnAcOs);
		((Control)this).Controls.Add((Control)(object)LblSenderId);
		((Control)this).Controls.Add((Control)(object)lblWhatsAppState);
		((Control)this).Controls.Add((Control)(object)lblMsgLenth);
		((Control)this).Controls.Add((Control)(object)lblSmsCount);
		((Control)this).Controls.Add((Control)(object)lblAcGroup);
		((Control)this).Controls.Add((Control)(object)cboAcGroup);
		((Control)this).Controls.Add((Control)(object)ChkOnlyMoNo);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)cboBarth);
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
		((Control)this).Name = "UT_WAPP_WITH_API";
		((Form)this).Text = "Whatsapp Sender";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void UT_WAPP_WITH_API_Load(object sender, EventArgs e)
	{
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_015b: Expected O, but got Unknown
		//IL_0d07: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cc6: Unknown result type (might be due to invalid IL or missing references)
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
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj21 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				((Control)lblWhatsAppState).BackColor = Color.Cornsilk;
				((Control)LblSenderId).BackColor = Color.Cornsilk;
				CheckBox obj22 = chkAllRow;
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj22).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				Label obj24 = lblBook;
				object? obj25 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj24).ForeColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				Label obj26 = lblWhatsAppState;
				object? obj27 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj26).ForeColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				Label lblSenderId3 = LblSenderId;
				object? obj28 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)lblSenderId3).ForeColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj29 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj30 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				ComboBox cboSmsType2 = CboSmsType;
				object? obj32 = colorConverter.ConvertFromString("Cornsilk");
				cboSmsType2.BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				CheckBox chkOnlyMoNo2 = ChkOnlyMoNo;
				object? obj33 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)chkOnlyMoNo2).BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				CheckBox obj34 = chkAllRow;
				object? obj35 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj34).BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
			}
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			CboSmsType.Items.Add((object)"Accounts");
			CboSmsType.Items.Add((object)"Address");
			CboSmsType.Items.Add((object)"Scheme");
			CboSmsType.SelectedIndex = 0;
			cboBarth.Items.Add((object)"");
			cboBarth.Items.Add((object)"Birthday");
			cboBarth.Items.Add((object)"Anniversary");
			cboBarth.SelectedIndex = 0;
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
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(executingAssembly.Location);
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			EntryMode = "A";
			LoadTemplates();
			if (!DC_Main.MsWappMember)
			{
				if (DC_Main.MsWappEndDay <= 0)
				{
					Interaction.MsgBox((object)"You Have No Subscription... Plsease Subscribe...", (MsgBoxStyle)0, (object)null);
					DC_Main.MsWhatsAppOpen = "N";
					LblDays.Text = Conversions.ToString(0);
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

	private void UT_WAPP_WITH_API_Activated(object sender, EventArgs e)
	{
	}

	private async void BtnSmsSend_Click(object sender, EventArgs e)
	{
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
			if (Operators.CompareString(txtFinalPreview.Text, "", false) != 0)
			{
				SendDetl = txtFinalPreview.Text;
			}
			if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
			{
				await SendWhatsAppMessageAsync(DC_Main.MsCountryId + tMobileNo.Text);
			}
			else if (cboBarth.SelectedIndex != 0)
			{
				if (((DataGridView)DGV).Rows.Count <= 1)
				{
					return;
				}
				int num2 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num2)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
					{
						string mobileNo = DC_Main.MsCountryId.ToString() + ((DataGridView)DGV).Rows[DC_Main.M].Cells[5].Value.ToString().Trim();
						await SendWhatsAppMessageAsync(mobileNo);
						TotSms++;
						lblSmsCount.Text = TotSms.ToString();
						ProgressBar progressBar;
						ProgressBar val = (progressBar = ProgressBar1);
						progressBar.Value = val.Value + 1;
					}
					DC_Main.M++;
				}
				if (TotSms > 0)
				{
					Interaction.MsgBox((object)"All Message Send..", (MsgBoxStyle)0, (object)null);
				}
			}
			else if (OsMsg)
			{
				int num3 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num3)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
					{
						string mobileNo = DC_Main.MsCountryId.ToString() + ((DataGridView)DGV).Rows[DC_Main.M].Cells[8].Value.ToString().Trim();
						await SendWhatsAppMessageAsync(mobileNo);
						TotSms++;
						lblSmsCount.Text = TotSms.ToString();
						ProgressBar progressBar;
						ProgressBar val2 = (progressBar = ProgressBar1);
						progressBar.Value = val2.Value + 1;
					}
					DC_Main.M++;
				}
				if (TotSms > 0)
				{
					Interaction.MsgBox((object)"All Message Send..", (MsgBoxStyle)0, (object)null);
				}
			}
			else if (DgvData)
			{
				int num4 = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num4)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
					{
						string mobileNo = DC_Main.MsCountryId.ToString() + ((DataGridView)DGV).Rows[DC_Main.M].Cells[6].Value.ToString().Trim();
						await SendWhatsAppMessageAsync(mobileNo);
						TotSms++;
						lblSmsCount.Text = TotSms.ToString();
						ProgressBar progressBar;
						ProgressBar val3 = (progressBar = ProgressBar1);
						progressBar.Value = val3.Value + 1;
					}
					DC_Main.M++;
				}
			}
			else if (SchmOsMsg)
			{
				SchmOsSms();
			}
		}
	}

	private async Task SendWhatsAppMessageAsync(string mobileNo)
	{
		string text = cboTemplate.Text;
		List<string> list = new List<string>();
		int num = 0;
		foreach (Control control in ((Control)pnlVariables).Controls)
		{
			Control val = control;
			if (!(val is TextBox))
			{
				continue;
			}
			if (Operators.CompareString(cboTemplate.Text, "payment_due", false) == 0)
			{
				switch (num)
				{
				case 0:
					list.Add(Conversions.ToString(RuntimeHelpers.GetObjectValue(((DataGridView)DGV).Rows[DC_Main.M].Cells[5].Value)));
					break;
				case 1:
				{
					string text2 = "";
					string text3 = "";
					string text4 = "";
					if (((DataGridView)DGV).Rows[DC_Main.M].Cells[2].Value != null && Operators.CompareString(((DataGridView)DGV).Rows[DC_Main.M].Cells[2].Value.ToString().Trim(), "", false) != 0)
					{
						text2 = "Amount :" + ((DataGridView)DGV).Rows[DC_Main.M].Cells[2].Value.ToString() + " Dr";
					}
					if (((DataGridView)DGV).Rows[DC_Main.M].Cells[3].Value != null && Operators.CompareString(((DataGridView)DGV).Rows[DC_Main.M].Cells[3].Value.ToString().Trim(), "", false) != 0)
					{
						text3 = ", Gold :" + ((DataGridView)DGV).Rows[DC_Main.M].Cells[3].Value.ToString() + " Dr";
					}
					if (((DataGridView)DGV).Rows[DC_Main.M].Cells[4].Value != null && Operators.CompareString(((DataGridView)DGV).Rows[DC_Main.M].Cells[4].Value.ToString().Trim(), "", false) != 0)
					{
						text4 = ", Silver :" + ((DataGridView)DGV).Rows[DC_Main.M].Cells[4].Value.ToString() + " Dr";
					}
					list.Add(text2 + text3 + text4);
					break;
				}
				default:
					list.Add(Conversions.ToString(DC_Main.MsSysDate));
					break;
				}
				num = checked(num + 1);
			}
			else
			{
				list.Add(val.Text);
			}
		}
		foreach (string item in list)
		{
			if (string.IsNullOrWhiteSpace(item))
			{
				MessageBox.Show("All variables fill First...");
				return;
			}
		}
		string text5 = "";
		foreach (string item2 in list)
		{
			text5 += $"{{ \"type\": \"text\", \"text\": \"{item2}\" }},";
		}
		text5 = text5.TrimEnd(new char[1] { ',' });
		List<string> list2 = new List<string>();
		if (!string.IsNullOrEmpty(CurrentMediaId))
		{
			if (Operators.CompareString(CurrentMediaType, "IMAGE", false) == 0)
			{
				list2.Add($"{{ \"type\": \"header\", \"parameters\": [\r\n                    {{ \"type\": \"image\", \"image\": {{ \"id\": \"{CurrentMediaId}\" }} }}\r\n                ] }}");
			}
			else if (Operators.CompareString(CurrentMediaType, "VIDEO", false) == 0)
			{
				list2.Add($"{{ \"type\": \"header\", \"parameters\": [\r\n                    {{ \"type\": \"video\", \"video\": {{ \"id\": \"{CurrentMediaId}\" }} }}\r\n                ] }}");
			}
			else if (Operators.CompareString(CurrentMediaType, "application/pdf", false) == 0)
			{
				list2.Add($"{{ \"type\": \"header\", \"parameters\": [\r\n                    {{ \"type\": \"document\", \"document\": {{ \"id\": \"{CurrentMediaId}\", \"filename\": \"{CurrentFileName}\" }} }}\r\n                ] }}");
			}
		}
		list2.Add($"{{ \"type\": \"body\", \"parameters\": [\r\n                {text5}\r\n            ] }}");
		string text6 = string.Join(",", list2);
		string text7 = string.Format("{{\r\n                          \"messaging_product\": \"whatsapp\",\r\n                          \"to\": \"{0}\",\r\n                          \"type\": \"template\",\r\n                          \"template\": {{\r\n                            \"name\": \"{1}\",\r\n                            \"language\": {{ \"code\": \"{2}\" }},\r\n                            \"components\": [\r\n                              {3}\r\n                            ]\r\n                          }}\r\n                        }}", new object[4] { mobileNo, text, tmpLANGUAGE, text6 });
		HttpClient val2 = new HttpClient();
		try
		{
			((HttpHeaders)val2.DefaultRequestHeaders).Clear();
			((HttpHeaders)val2.DefaultRequestHeaders).Add("Authorization", $"Bearer {ACCESS_TOKEN}");
			StringContent val3 = new StringContent(text7, Encoding.UTF8, "application/json");
			string jsonData = await (await val2.PostAsync($"https://graph.facebook.com/v22.0/{PHONE_NUMBER_ID}/messages", (HttpContent)(object)val3)).Content.ReadAsStringAsync();
			string connectionString = "Data Source=103.13.115.232,8899;Initial Catalog=DcWpMain;User ID=sa;Password=datacare@123;MultipleActiveResultSets=True;";
			SaveWebhookToDatabase(jsonData, text7, connectionString);
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
		Application.DoEvents();
	}

	private void SaveWebhookToDatabase(string jsonData, string sendJson, string connectionString)
	{
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Expected O, but got Unknown
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Expected O, but got Unknown
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c0: Expected O, but got Unknown
		//IL_050f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0516: Expected O, but got Unknown
		try
		{
			SqlConnection val = new SqlConnection(connectionString);
			try
			{
				SqlCommand val2 = new SqlCommand("INSERT INTO WebhookInbox (JsonData) VALUES (@Json)", val);
				try
				{
					val2.Parameters.Add("@Json", SqlDbType.NVarChar).Value = jsonData;
					val.Open();
					val2.ExecuteNonQuery();
				}
				finally
				{
					((IDisposable)val2)?.Dispose();
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			MessageBox.Show("DB Save Error : " + ex2.Message);
			ProjectData.ClearProjectError();
		}
		JObject val3 = JObject.Parse(jsonData);
		JObject val4 = JObject.Parse(sendJson);
		SqlConnection val5 = new SqlConnection(connectionString);
		checked
		{
			try
			{
				val5.Open();
				string text = "";
				if (val3["messages"][(object)0][(object)"id"].ToString() != null)
				{
					text = val3["messages"][(object)0][(object)"id"].ToString() ?? "";
				}
				string text2 = val4["type"].ToString();
				DateTime dateTime = Conversions.ToDate(DateAndTime.Now.ToString());
				string text3 = val3["contacts"][(object)0][(object)"wa_id"].ToString();
				string sSRegSrNo = DC_Main.SSRegSrNo;
				string text4 = "";
				string text5 = "";
				switch (text2)
				{
				case "Text":
					text4 = val4["text"][(object)"body"].ToString();
					break;
				case "image":
					text5 = ((JToken)val4).SelectToken("image.id").ToString();
					break;
				case "document":
				{
					JToken obj8 = ((JToken)val4).SelectToken("document.id");
					text5 = ((obj8 != null) ? obj8.ToString() : null);
					JToken obj9 = ((JToken)val4).SelectToken("document.filename");
					text4 = ((obj9 != null) ? obj9.ToString() : null);
					break;
				}
				case "template":
				{
					JToken obj = ((JToken)val4).SelectToken("template.name");
					string text6 = ((obj != null) ? obj.ToString() : null);
					JToken val6 = ((JToken)val4).SelectToken("template.components[?(@.type=='header')]");
					if (val6 != null)
					{
						JToken val7 = val6[(object)"parameters"][(object)0];
						JToken obj2 = val7[(object)"type"];
						if (Operators.CompareString((obj2 != null) ? obj2.ToString() : null, "image", false) == 0)
						{
							JToken obj3 = val7.SelectToken("image.id");
							text5 = ((obj3 != null) ? obj3.ToString() : null);
						}
						else
						{
							JToken obj4 = val7[(object)"type"];
							if (Operators.CompareString((obj4 != null) ? obj4.ToString() : null, "document", false) == 0)
							{
								JToken obj5 = val7.SelectToken("document.id");
								text5 = ((obj5 != null) ? obj5.ToString() : null);
							}
							else
							{
								JToken obj6 = val7[(object)"type"];
								if (Operators.CompareString((obj6 != null) ? obj6.ToString() : null, "video", false) == 0)
								{
									JToken obj7 = val7.SelectToken("video.id");
									text5 = ((obj7 != null) ? obj7.ToString() : null);
								}
							}
						}
					}
					List<string> list = new List<string>();
					JToken val8 = ((JToken)val4).SelectToken("template.components");
					if (val8 != null)
					{
						foreach (JToken item in (IEnumerable<JToken>)val8)
						{
							if (item[(object)"parameters"] == null)
							{
								continue;
							}
							foreach (JToken item2 in (IEnumerable<JToken>)item[(object)"parameters"])
							{
								if (item2[(object)"text"] != null)
								{
									list.Add(item2[(object)"text"].ToString());
								}
							}
						}
					}
					string text7 = txtFinalPreview.Text;
					int num = list.Count - 1;
					for (int i = 0; i <= num; i++)
					{
						text7 = text7.Replace("{{" + (i + 1) + "}}", list[i]);
					}
					text4 = txtFinalPreview.Text;
					break;
				}
				}
				string text8 = "outbound";
				bool flag = false;
				SqlCommand val9 = new SqlCommand("SELECT Count(1) FROM app_ChatMessages WHERE MessageID = @mid", val5);
				try
				{
					val9.Parameters.AddWithValue("@mid", (object)text);
					if (Convert.ToInt32(RuntimeHelpers.GetObjectValue(val9.ExecuteScalar())) == 0)
					{
						flag = true;
					}
				}
				finally
				{
					((IDisposable)val9)?.Dispose();
				}
				try
				{
					string text9 = "INSERT INTO app_ChatMessages (MessageID, ThreadID, AccountID, Direction, Type, Content, Status, Timestamp, MediaID, CustomerName , CampaignID, ErrorMessage) VALUES (@mid, @tid, @accId, @dir, @type, @content, @status, @ts, @mediaId,@custname ,@campaId , @errMsg)";
					SqlCommand val10 = new SqlCommand(text9, val5);
					try
					{
						val10.Parameters.AddWithValue("@mid", (object)text);
						val10.Parameters.AddWithValue("@tid", (object)text3);
						val10.Parameters.AddWithValue("@accId", (object)sSRegSrNo);
						val10.Parameters.AddWithValue("@dir", (object)text8);
						val10.Parameters.AddWithValue("@type", (object)text2);
						val10.Parameters.AddWithValue("@content", (object)text4);
						val10.Parameters.AddWithValue("@status", (object)"sent");
						val10.Parameters.AddWithValue("@ts", (object)DateTime.Parse(Conversions.ToString(dateTime)));
						val10.Parameters.AddWithValue("@mediaId", (object)text5);
						val10.Parameters.AddWithValue("@custname", (object)"");
						val10.Parameters.AddWithValue("@campaId", (object)"");
						val10.Parameters.AddWithValue("@errMsg", (object)"");
						val10.ExecuteNonQuery();
					}
					finally
					{
						((IDisposable)val10)?.Dispose();
					}
				}
				catch (Exception ex3)
				{
					ProjectData.SetProjectError(ex3);
					Exception ex4 = ex3;
					string message = ex4.Message;
					ProjectData.ClearProjectError();
				}
			}
			finally
			{
				((IDisposable)val5)?.Dispose();
			}
		}
	}

	private async void LoadTemplates()
	{
		try
		{
			string text = $"https://graph.facebook.com/v22.0/{WABA_ID}/message_templates?status=APPROVED";
			HttpClient val = new HttpClient();
			try
			{
				val.Timeout = TimeSpan.FromSeconds(35.0);
				((HttpHeaders)val.DefaultRequestHeaders).Clear();
				((HttpHeaders)val.DefaultRequestHeaders).Add("Authorization", $"Bearer {ACCESS_TOKEN}");
				HttpResponseMessage val2 = await val.GetAsync(text);
				string text2 = await val2.Content.ReadAsStringAsync();
				if (!val2.IsSuccessStatusCode)
				{
					MessageBox.Show("API Error : " + text2);
					return;
				}
				DataTable dataTable = new DataTable
				{
					Columns = { "name" }
				};
				JObject val3 = JObject.Parse(text2);
				if (val3["data"] != null)
				{
					foreach (JToken item in (IEnumerable<JToken>)val3["data"])
					{
						dataTable.Rows.Add(item[(object)"name"].ToString());
					}
				}
				cboTemplate.DataSource = dataTable;
				((ListControl)cboTemplate).DisplayMember = "name";
				((ListControl)cboTemplate).ValueMember = "name";
			}
			finally
			{
				((IDisposable)val)?.Dispose();
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

	private async void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
	{
		txtFinalPreview.Text = "";
		if (!Formload)
		{
			Formload = true;
			return;
		}
		ClearMediaPanel();
		string text = cboTemplate.Text;
		string text2 = await GetTemplateBodyLive(text);
		txtPreview.Text = text2;
		List<string> templateVariables = GetTemplateVariables(text2);
		CurrentMediaId = "";
		CreateVariableInputs(templateVariables);
	}

	private async Task<string> GetTemplateBodyLive(string templateName)
	{
		string text = $"https://graph.facebook.com/v22.0/{WABA_ID}/message_templates?name={templateName}";
		HttpClient val = new HttpClient();
		try
		{
			((HttpHeaders)val.DefaultRequestHeaders).Clear();
			((HttpHeaders)val.DefaultRequestHeaders).Add("Authorization", $"Bearer {ACCESS_TOKEN}");
			JObject val2 = JObject.Parse(await (await val.GetAsync(text)).Content.ReadAsStringAsync());
			tmpLANGUAGE = val2["data"][(object)0][(object)"language"].ToString();
			if (val2["data"] == null || ((IEnumerable<JToken>)val2["data"]).Count() == 0)
			{
				return "";
			}
			string result = "";
			foreach (JToken item in (IEnumerable<JToken>)val2["data"][(object)0][(object)"components"])
			{
				string text2 = item[(object)"type"].ToString().ToUpper();
				if (Operators.CompareString(text2, "BODY", false) == 0)
				{
					result = item[(object)"text"].ToString();
				}
				else if (Operators.CompareString(text2, "HEADER", false) == 0)
				{
					string mediaType = item[(object)"format"].ToString().ToUpper();
					CreateMediaUploadControl(mediaType);
				}
			}
			return result;
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void ClearMediaPanel()
	{
		((Control)pnlMedia).Controls.Clear();
		((Control)pnlMedia).Visible = false;
		CurrentMediaId = "";
		CurrentMediaType = "";
		CurrentFileName = "";
	}

	private List<string> GetTemplateVariables(string body)
	{
		List<string> list = new List<string>();
		Regex regex = new Regex("\\{\\{(\\d+)\\}\\}");
		foreach (Match item in regex.Matches(body))
		{
			list.Add(item.Value);
		}
		return list;
	}

	private void CreateVariableInputs(List<string> vars)
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Expected O, but got Unknown
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Expected O, but got Unknown
		((Control)pnlVariables).Controls.Clear();
		int num = 10;
		foreach (string var in vars)
		{
			Label val = new Label();
			val.Text = "{{" + var + "}}";
			((Control)val).Left = 10;
			((Control)val).Top = num;
			((Control)val).Width = 50;
			TextBox val2 = new TextBox();
			((Control)val2).Name = "txtVar" + var;
			((Control)val2).Left = 70;
			((Control)val2).Top = num;
			((Control)val2).Width = 200;
			((Control)val2).TextChanged += VariableTextChanged;
			((Control)pnlVariables).Controls.Add((Control)(object)val);
			((Control)pnlVariables).Controls.Add((Control)(object)val2);
			num = checked(num + 35);
		}
	}

	private void CreateMediaUploadControl(string mediaType)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Expected O, but got Unknown
		((Control)pnlMedia).Controls.Clear();
		((Control)pnlMedia).Visible = true;
		((Control)pnlMedia).Enabled = true;
		((Control)pnlMedia).BringToFront();
		((Control)pnlMedia).Width = 450;
		((Control)pnlMedia).Height = 50;
		Label val = new Label();
		((Control)val).Left = 2;
		((Control)val).Top = 15;
		((Control)val).Width = 70;
		val.Text = mediaType + " File";
		TextBox val2 = new TextBox();
		((Control)val2).Left = 85;
		((Control)val2).Top = 12;
		((Control)val2).Width = 190;
		((TextBoxBase)val2).ReadOnly = true;
		((Control)val2).Name = "txtMediaFile";
		Button val3 = new Button();
		((Control)val3).Left = 300;
		((Control)val3).Top = 10;
		((Control)val3).Width = 75;
		((Control)val3).Height = 26;
		((ButtonBase)val3).Text = "Browse";
		((Control)val3).Tag = mediaType;
		((Control)val3).Visible = true;
		((Control)val3).Enabled = true;
		((Control)val3).Click += BrowseMediaFile;
		((Control)pnlMedia).Controls.Add((Control)(object)val);
		((Control)pnlMedia).Controls.Add((Control)(object)val2);
		((Control)pnlMedia).Controls.Add((Control)(object)val3);
	}

	private async void BrowseMediaFile(object sender, EventArgs e)
	{
		Button val = (Button)sender;
		string text = ((Control)val).Tag.ToString();
		OpenFileDialog val2 = new OpenFileDialog();
		try
		{
			switch (text)
			{
			case "IMAGE":
				((FileDialog)val2).Filter = "Images|*.jpg;*.jpeg;*.png";
				break;
			case "VIDEO":
				((FileDialog)val2).Filter = "Videos|*.mp4";
				break;
			case "DOCUMENT":
				((FileDialog)val2).Filter = "Documents|*.pdf;*.docx";
				break;
			}
			if ((int)((CommonDialog)val2).ShowDialog() == 1)
			{
				string fileName = ((FileDialog)val2).FileName;
				TextBox val3 = (TextBox)((Control)pnlMedia).Controls["txtMediaFile"];
				val3.Text = fileName;
				string text2 = "";
				switch (Path.GetExtension(fileName).ToLower())
				{
				case ".jpg":
				case ".jpeg":
					text2 = "image/jpeg";
					break;
				case ".png":
					text2 = "image/png";
					break;
				case ".mp4":
					text2 = "video/mp4";
					break;
				case ".pdf":
					text2 = "application/pdf";
					break;
				case ".docx":
					text2 = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
					break;
				}
				string text3 = await UploadMediaAndGetId(fileName, text2);
				if (string.IsNullOrEmpty(text3))
				{
					MessageBox.Show("Media upload failed.");
					return;
				}
				CurrentMediaId = text3;
				CurrentMediaType = text2;
				CurrentFileName = "JEWELLERS BILL";
				MessageBox.Show("Media Uploaded Successfully.\r\nMedia ID: " + text3);
			}
		}
		finally
		{
			((IDisposable)val2)?.Dispose();
		}
	}

	private async Task<string> UploadMediaAndGetId(string filePath, string mimeType)
	{
		string text = $"https://graph.facebook.com/v22.0/{PHONE_NUMBER_ID}/media";
		HttpClient val = new HttpClient();
		try
		{
			((HttpHeaders)val.DefaultRequestHeaders).Clear();
			((HttpHeaders)val.DefaultRequestHeaders).Add("Authorization", $"Bearer {ACCESS_TOKEN}");
			MultipartFormDataContent val2 = new MultipartFormDataContent();
			val2.Add((HttpContent)new StringContent("whatsapp"), "messaging_product");
			byte[] array = File.ReadAllBytes(filePath);
			ByteArrayContent val3 = new ByteArrayContent(array);
			((HttpContent)val3).Headers.ContentType = new MediaTypeHeaderValue(mimeType);
			val2.Add((HttpContent)(object)val3, "file", Path.GetFileName(filePath));
			HttpResponseMessage val4 = await val.PostAsync(text, (HttpContent)(object)val2);
			string text2 = await val4.Content.ReadAsStringAsync();
			if (!val4.IsSuccessStatusCode)
			{
				MessageBox.Show("Upload Error: " + text2);
				return "";
			}
			JObject val5 = JObject.Parse(text2);
			return val5["id"].ToString();
		}
		finally
		{
			((IDisposable)val)?.Dispose();
		}
	}

	private void VariableTextChanged(object sender, EventArgs e)
	{
		UpdateFinalPreview();
	}

	private void UpdateFinalPreview()
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Expected O, but got Unknown
		string text = txtPreview.Text;
		int num = 1;
		foreach (Control control in ((Control)pnlVariables).Controls)
		{
			Control val = control;
			if (val is TextBox)
			{
				text = text.Replace("{{" + Conversions.ToString(num) + "}}", val.Text);
				num = checked(num + 1);
			}
		}
		txtFinalPreview.Text = text;
	}

	private async void SchmOsSms()
	{
		SendRow = 0;
		ScelectMo = "";
		int num = 7;
		checked
		{
			foreach (DataGridViewRow item in (IEnumerable)((DataGridView)DGV).Rows)
			{
				DataGridViewRow val = item;
				try
				{
					if (!Operators.ConditionalCompareObjectEqual(val.Cells[0].Value, (object)true, false))
					{
						continue;
					}
					ScelectMo = Conversions.ToString(RuntimeHelpers.GetObjectValue(Operators.ConcatenateObject(val.Cells[num].Value, (object)"")));
					TotSms++;
					if (Operators.CompareString(ScelectMo, "", false) != 0)
					{
						string value = txtFinalPreview.Text + " Rs = " + Strings.Format(RuntimeHelpers.GetObjectValue(val.Cells[8].Value), "0.00") + Environment.NewLine + "Have a Nice Day...";
						_ = DC_Main.MsCountryId + ScelectMo;
						if (string.IsNullOrEmpty(value))
						{
						}
					}
					lblSmsCount.Text = Conversions.ToString(TotSms);
					ProgressBar progressBar;
					ProgressBar val2 = (progressBar = ProgressBar1);
					progressBar.Value = val2.Value + 1;
					Application.DoEvents();
				}
				catch (Exception projectError)
				{
					ProjectData.SetProjectError(projectError);
					ProjectData.ClearProjectError();
				}
			}
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

	private void UT_WAPP_WITH_API_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_WAPP_WITH_API_KeyDown(object sender, KeyEventArgs e)
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
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
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
			DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_DETL = '" + txtFinalPreview.Text + "'");
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
		txtFinalPreview.Text = "";
		tCountryCode.Text = DC_Main.MsCountryId;
		((DataGridView)DGV).DataSource = null;
		DgvData = false;
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

	private void UT_WAPP_WITH_API_Closed(object sender, EventArgs e)
	{
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
			((Control)txtFinalPreview).Focus();
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
			((Control)txtFinalPreview).Focus();
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
		cboBarth.SelectedIndex = 0;
		cboBarth.Text = "";
		DgvData = true;
		OsMsg = false;
		RateMsg = false;
		ExelMsg = false;
		SchmOsMsg = false;
		chkAllRow.Checked = false;
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
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		//IL_027f: Invalid comparison between Unknown and I4
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d0: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Expected O, but got Unknown
		//IL_02b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Invalid comparison between Unknown and I4
		chkAllRow.Checked = false;
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
			txtFinalPreview.Text = "";
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

	private void BtnAcOs_Click(object sender, EventArgs e)
	{
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Expected O, but got Unknown
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0248: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fcd: Unknown result type (might be due to invalid IL or missing references)
		//IL_1031: Unknown result type (might be due to invalid IL or missing references)
		//IL_103b: Expected O, but got Unknown
		//IL_10e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_10ef: Expected O, but got Unknown
		//IL_106d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1072: Unknown result type (might be due to invalid IL or missing references)
		//IL_107c: Expected O, but got Unknown
		//IL_1092: Unknown result type (might be due to invalid IL or missing references)
		//IL_1097: Unknown result type (might be due to invalid IL or missing references)
		//IL_10a1: Expected O, but got Unknown
		//IL_10b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_10bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_10c6: Expected O, but got Unknown
		cboBarth.SelectedIndex = 0;
		cboBarth.Text = "";
		txtFinalPreview.Text = "";
		chkAllRow.Checked = false;
		DgvData = false;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
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
					txtFinalPreview.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
				}
				if (Operators.CompareString(txtFinalPreview.Text, "", false) == 0)
				{
					txtFinalPreview.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer Your Scheme Amount is Due of This Month Please Pay...";
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
			if (Operators.CompareString(txtFinalPreview.Text, "", false) == 0)
			{
				txtFinalPreview.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer, your due amount Is";
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
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c7: Expected O, but got Unknown
		//IL_0345: Unknown result type (might be due to invalid IL or missing references)
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0354: Expected O, but got Unknown
		//IL_036a: Unknown result type (might be due to invalid IL or missing references)
		//IL_036f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0379: Expected O, but got Unknown
		//IL_038f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		//IL_039e: Expected O, but got Unknown
		cboBarth.SelectedIndex = 0;
		cboBarth.Text = "";
		txtFinalPreview.Text = "";
		chkAllRow.Checked = false;
		DgvData = false;
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
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
					txtFinalPreview.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[0]["MSG_DETL"], (object)" 999 Gold Rate = "), (object)num), (object)" And 999 Silver Rate = "), (object)num2), (object)" Have a Nice Day..."));
				}
				else
				{
					txtFinalPreview.Text = DC_Main.MCo_Name + Environment.NewLine + "Dear customer Todays  999 Gold Rate = " + Conversions.ToString(num) + " And 999 Silver Rate = " + Conversions.ToString(num2) + " Have a Nice Day...";
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
