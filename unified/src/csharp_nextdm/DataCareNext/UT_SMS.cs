using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
public class UT_SMS : Form
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
	[AccessedThroughProperty("tMsg")]
	private TextBox _tMsg;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("WebBrowser1")]
	private WebBrowser _WebBrowser1;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSmsSend")]
	private QButton _BtnSmsSend;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnBalance")]
	private QButton _BtnBalance;

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
	[AccessedThroughProperty("chkOsAmt")]
	private CheckBox _chkOsAmt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkRetSend")]
	private CheckBox _chkRetSend;

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
	[AccessedThroughProperty("btnWhatsapp")]
	private QButton _btnWhatsapp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("Timer1")]
	private Timer _Timer1;

	private int sec;

	private string _translationSpeakUrl;

	private Control CurActCtrl;

	private double ColCon;

	private DataTable RsMast;

	private string EntryMode;

	private bool MsgLess;

	private string theWebSite;

	private string ScelectMo;

	private string SendDetl;

	private int SendRow;

	private int TotSms;

	private string[] AryGroup;

	private int MaxPages;

	private int LastRow;

	private int Pages;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

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
	private virtual DataGridViewX _DGV;

	internal virtual DataGridViewX DGV
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tMobileNo")]
	private virtual TextBox _tMobileNo;

	internal virtual TextBox tMobileNo
	{
		get
		{
			return _tMobileNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tMobileNo = value;
		}
	}

	internal virtual TextBox tMsg
	{
		[CompilerGenerated]
		get
		{
			return _tMsg;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tMsg_KeyDown);
			TextBox val2 = _tMsg;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tMsg = value;
			val2 = _tMsg;
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

	internal virtual WebBrowser WebBrowser1
	{
		[CompilerGenerated]
		get
		{
			return _WebBrowser1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			WebBrowserDocumentCompletedEventHandler val = new WebBrowserDocumentCompletedEventHandler(WebBrowser1_DocumentCompleted);
			WebBrowser val2 = _WebBrowser1;
			if (val2 != null)
			{
				val2.DocumentCompleted -= val;
			}
			_WebBrowser1 = value;
			val2 = _WebBrowser1;
			if (val2 != null)
			{
				val2.DocumentCompleted += val;
			}
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

	internal virtual QButton BtnBalance
	{
		[CompilerGenerated]
		get
		{
			return _BtnBalance;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnBalance_Click;
			QButton val = _BtnBalance;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnBalance = value;
			val = _BtnBalance;
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

	internal virtual CheckBox chkOsAmt
	{
		[CompilerGenerated]
		get
		{
			return _chkOsAmt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = ChkOsAmt_CheckedChanged;
			CheckBox val = _chkOsAmt;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkOsAmt = value;
			val = _chkOsAmt;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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

	internal virtual CheckBox chkRetSend
	{
		[CompilerGenerated]
		get
		{
			return _chkRetSend;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkRetSend_CheckedChanged;
			CheckBox val = _chkRetSend;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkRetSend = value;
			val = _chkRetSend;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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

	private virtual LinkLabel _lnkSourceEnglish
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

	private virtual LinkLabel _lnkTargetEnglish
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

	internal virtual QButton btnWhatsapp
	{
		[CompilerGenerated]
		get
		{
			return _btnWhatsapp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnWhatsapp_Click;
			QButton val = _btnWhatsapp;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnWhatsapp = value;
			val = _btnWhatsapp;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual Timer Timer1
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
			EventHandler eventHandler = Timer1_Tick;
			Timer val = _Timer1;
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

	public UT_SMS()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += UT_SMS_Load;
		((Form)this).Deactivate += UT_SMS_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(UT_SMS_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(UT_SMS_KeyDown);
		((Form)this).Closed += UT_SMS_Closed;
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
		//IL_02ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f9: Expected O, but got Unknown
		//IL_040f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0468: Unknown result type (might be due to invalid IL or missing references)
		//IL_0472: Expected O, but got Unknown
		//IL_04d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected O, but got Unknown
		//IL_0589: Unknown result type (might be due to invalid IL or missing references)
		//IL_0593: Expected O, but got Unknown
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a8: Expected O, but got Unknown
		//IL_07c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07cf: Expected O, but got Unknown
		//IL_0832: Unknown result type (might be due to invalid IL or missing references)
		//IL_083c: Expected O, but got Unknown
		//IL_08e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08ef: Expected O, but got Unknown
		//IL_0952: Unknown result type (might be due to invalid IL or missing references)
		//IL_095c: Expected O, but got Unknown
		//IL_0a05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a0f: Expected O, but got Unknown
		//IL_0a72: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7c: Expected O, but got Unknown
		//IL_0b54: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b5e: Expected O, but got Unknown
		//IL_0bcc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd6: Expected O, but got Unknown
		//IL_0ca2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cac: Expected O, but got Unknown
		//IL_0d3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d44: Expected O, but got Unknown
		//IL_0dc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dcc: Expected O, but got Unknown
		//IL_0e4a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e54: Expected O, but got Unknown
		//IL_0eff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f09: Expected O, but got Unknown
		//IL_0fb7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc1: Expected O, but got Unknown
		//IL_108c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1096: Expected O, but got Unknown
		//IL_112b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1135: Expected O, but got Unknown
		//IL_11b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11bd: Expected O, but got Unknown
		//IL_1292: Unknown result type (might be due to invalid IL or missing references)
		//IL_129c: Expected O, but got Unknown
		//IL_1305: Unknown result type (might be due to invalid IL or missing references)
		//IL_130f: Expected O, but got Unknown
		//IL_15af: Unknown result type (might be due to invalid IL or missing references)
		//IL_15d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_161b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1644: Unknown result type (might be due to invalid IL or missing references)
		//IL_164e: Expected O, but got Unknown
		//IL_1671: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_16f2: Expected O, but got Unknown
		//IL_17a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ad: Expected O, but got Unknown
		//IL_182f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1839: Expected O, but got Unknown
		//IL_18ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d8: Expected O, but got Unknown
		//IL_1be0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c04: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c28: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7f: Expected O, but got Unknown
		//IL_1ca5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f51: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f75: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f9e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fa8: Expected O, but got Unknown
		//IL_1fce: Unknown result type (might be due to invalid IL or missing references)
		//IL_2062: Unknown result type (might be due to invalid IL or missing references)
		//IL_206c: Expected O, but got Unknown
		//IL_2141: Unknown result type (might be due to invalid IL or missing references)
		//IL_214b: Expected O, but got Unknown
		//IL_21e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_21ee: Expected O, but got Unknown
		//IL_2323: Unknown result type (might be due to invalid IL or missing references)
		//IL_232d: Expected O, but got Unknown
		//IL_2402: Unknown result type (might be due to invalid IL or missing references)
		//IL_240c: Expected O, but got Unknown
		//IL_24a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_24af: Expected O, but got Unknown
		//IL_25c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_25d1: Expected O, but got Unknown
		//IL_268e: Unknown result type (might be due to invalid IL or missing references)
		//IL_2698: Expected O, but got Unknown
		//IL_2940: Unknown result type (might be due to invalid IL or missing references)
		//IL_2964: Unknown result type (might be due to invalid IL or missing references)
		//IL_2988: Unknown result type (might be due to invalid IL or missing references)
		//IL_29ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_29d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_29df: Expected O, but got Unknown
		//IL_2a02: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_2a94: Expected O, but got Unknown
		//IL_2b48: Unknown result type (might be due to invalid IL or missing references)
		//IL_2b52: Expected O, but got Unknown
		//IL_2be3: Unknown result type (might be due to invalid IL or missing references)
		//IL_2bed: Expected O, but got Unknown
		//IL_2cab: Unknown result type (might be due to invalid IL or missing references)
		//IL_2cb5: Expected O, but got Unknown
		//IL_2d73: Unknown result type (might be due to invalid IL or missing references)
		//IL_2d7d: Expected O, but got Unknown
		//IL_2e3b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2e45: Expected O, but got Unknown
		//IL_2f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_2f0d: Expected O, but got Unknown
		//IL_2fcb: Unknown result type (might be due to invalid IL or missing references)
		//IL_2fd5: Expected O, but got Unknown
		//IL_3093: Unknown result type (might be due to invalid IL or missing references)
		//IL_309d: Expected O, but got Unknown
		//IL_3165: Unknown result type (might be due to invalid IL or missing references)
		//IL_316f: Expected O, but got Unknown
		//IL_321b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3225: Expected O, but got Unknown
		//IL_32dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_32e6: Expected O, but got Unknown
		//IL_339d: Unknown result type (might be due to invalid IL or missing references)
		//IL_33a7: Expected O, but got Unknown
		//IL_3472: Unknown result type (might be due to invalid IL or missing references)
		//IL_347c: Expected O, but got Unknown
		//IL_350e: Unknown result type (might be due to invalid IL or missing references)
		//IL_3518: Expected O, but got Unknown
		//IL_35d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_35dc: Expected O, but got Unknown
		//IL_3697: Unknown result type (might be due to invalid IL or missing references)
		//IL_36a1: Expected O, but got Unknown
		//IL_3752: Unknown result type (might be due to invalid IL or missing references)
		//IL_375c: Expected O, but got Unknown
		//IL_37fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_3807: Expected O, but got Unknown
		//IL_3874: Unknown result type (might be due to invalid IL or missing references)
		//IL_387e: Expected O, but got Unknown
		//IL_393b: Unknown result type (might be due to invalid IL or missing references)
		//IL_3945: Expected O, but got Unknown
		//IL_39b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_39bf: Expected O, but got Unknown
		//IL_3a90: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a9a: Expected O, but got Unknown
		//IL_3b6f: Unknown result type (might be due to invalid IL or missing references)
		//IL_3b79: Expected O, but got Unknown
		//IL_3c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_3c1c: Expected O, but got Unknown
		//IL_3d34: Unknown result type (might be due to invalid IL or missing references)
		//IL_3d3e: Expected O, but got Unknown
		//IL_40dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_4101: Unknown result type (might be due to invalid IL or missing references)
		//IL_4125: Unknown result type (might be due to invalid IL or missing references)
		//IL_4149: Unknown result type (might be due to invalid IL or missing references)
		//IL_4172: Unknown result type (might be due to invalid IL or missing references)
		//IL_417c: Expected O, but got Unknown
		//IL_41a2: Unknown result type (might be due to invalid IL or missing references)
		components = new Container();
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(UT_SMS));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnExcel = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		CboSmsType = new ComboBox();
		nFromOs = new TextBox();
		nToOs = new TextBox();
		Label5 = new Label();
		Label1 = new Label();
		Label2 = new Label();
		DGV = new DataGridViewX();
		btnOk = new QButton();
		Label3 = new Label();
		tMobileNo = new TextBox();
		tMsg = new TextBox();
		Label4 = new Label();
		WebBrowser1 = new WebBrowser();
		BtnSmsSend = new QButton();
		BtnBalance = new QButton();
		BtnAc = new SimpleButton();
		BtnMemb = new SimpleButton();
		chkAllRow = new CheckBox();
		lblSmsRow = new Label();
		btnExlImport = new QButton();
		DlgOpn = new OpenFileDialog();
		Label6 = new Label();
		tsmstype = new TextBox();
		Label7 = new Label();
		Label8 = new Label();
		Label9 = new Label();
		Label10 = new Label();
		Label11 = new Label();
		Label12 = new Label();
		Label13 = new Label();
		cboBarth = new ComboBox();
		ChkOnlyMoNo = new CheckBox();
		chkOsAmt = new CheckBox();
		lblAcGroup = new Label();
		cboAcGroup = new ComboBox();
		chkRetSend = new CheckBox();
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
		btnWhatsapp = new QButton();
		Timer1 = new Timer(components);
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExcel);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 5;
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
		((Control)BtnExit).TabIndex = 9;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnDelete).TabIndex = 8;
		BtnDelete.Text = "&Delete";
		((BaseButton)BtnDelete).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnCancel).TabIndex = 7;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnSave).TabIndex = 5;
		BtnSave.Text = "&Save";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
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
		((Control)BtnPrint).TabIndex = 6;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnExcel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnExcel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnExcel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnExcel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnExcel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnExcel.ImageOptions.SvgImage");
		((Control)BtnExcel).Location = new Point(730, 3);
		((BaseControl)BtnExcel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnExcel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnExcel).Name = "BtnExcel";
		((Control)BtnExcel).Size = new Size(91, 37);
		((Control)BtnExcel).TabIndex = 11;
		BtnExcel.Text = "&Excel";
		((BaseButton)BtnExcel).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(696, 3);
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
		lblBook.Text = "Sms Master";
		lblBook.TextAlign = (ContentAlignment)32;
		CboSmsType.AutoCompleteMode = (AutoCompleteMode)2;
		CboSmsType.AutoCompleteSource = (AutoCompleteSource)256;
		CboSmsType.DropDownStyle = (ComboBoxStyle)2;
		((Control)CboSmsType).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)CboSmsType).FormattingEnabled = true;
		((Control)CboSmsType).Location = new Point(128, 42);
		CboSmsType.MaxLength = 20;
		((Control)CboSmsType).Name = "CboSmsType";
		((Control)CboSmsType).Size = new Size(145, 24);
		((Control)CboSmsType).TabIndex = 4;
		((TextBoxBase)nFromOs).BackColor = Color.White;
		((Control)nFromOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nFromOs).Location = new Point(666, 45);
		((TextBoxBase)nFromOs).MaxLength = 15;
		((Control)nFromOs).Name = "nFromOs";
		((Control)nFromOs).Size = new Size(81, 22);
		((Control)nFromOs).TabIndex = 0;
		((TextBoxBase)nToOs).BackColor = Color.White;
		((Control)nToOs).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)nToOs).Location = new Point(666, 78);
		((TextBoxBase)nToOs).MaxLength = 15;
		((Control)nToOs).Name = "nToOs";
		((Control)nToOs).Size = new Size(81, 22);
		((Control)nToOs).TabIndex = 1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(27, 42);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(94, 20);
		((Control)Label5).TabIndex = 19;
		Label5.Text = "Sms Type";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(596, 78);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(64, 20);
		((Control)Label1).TabIndex = 16;
		Label1.Text = "To Os <";
		Label1.TextAlign = (ContentAlignment)64;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(576, 44);
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
		((Control)DGV).Location = new Point(20, 116);
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
		((Control)DGV).Size = new Size(1152, 231);
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
		((Control)btnOk).Location = new Point(924, 42);
		((Control)btnOk).Margin = new Padding(3, 6, 3, 6);
		((Control)btnOk).Name = "btnOk";
		((Control)btnOk).Size = new Size(117, 37);
		((Control)btnOk).TabIndex = 1156;
		btnOk.Text = "Get List";
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(20, 360);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(84, 20);
		((Control)Label3).TabIndex = 1158;
		Label3.Text = "Mobile No";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tMobileNo).BackColor = Color.White;
		((Control)tMobileNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMobileNo).Location = new Point(110, 359);
		((TextBoxBase)tMobileNo).MaxLength = 10;
		((Control)tMobileNo).Name = "tMobileNo";
		((Control)tMobileNo).Size = new Size(117, 22);
		((Control)tMobileNo).TabIndex = 1157;
		((TextBoxBase)tMsg).BackColor = Color.White;
		((Control)tMsg).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tMsg).Location = new Point(110, 389);
		((TextBoxBase)tMsg).MaxLength = 255;
		tMsg.Multiline = true;
		((Control)tMsg).Name = "tMsg";
		((Control)tMsg).Size = new Size(586, 63);
		((Control)tMsg).TabIndex = 1161;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(16, 389);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(84, 20);
		((Control)Label4).TabIndex = 1162;
		Label4.Text = "English Msg";
		Label4.TextAlign = (ContentAlignment)64;
		((Control)WebBrowser1).Location = new Point(827, 361);
		((Control)WebBrowser1).MinimumSize = new Size(20, 20);
		((Control)WebBrowser1).Name = "WebBrowser1";
		((Control)WebBrowser1).Size = new Size(345, 63);
		((Control)WebBrowser1).TabIndex = 1163;
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
		((Control)BtnSmsSend).Location = new Point(709, 391);
		((Control)BtnSmsSend).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnSmsSend).Name = "BtnSmsSend";
		((Control)BtnSmsSend).Size = new Size(98, 33);
		((Control)BtnSmsSend).TabIndex = 1164;
		BtnSmsSend.Text = "Sms Send";
		((QControl)BtnBalance).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnBalance).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBalance).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnBalance).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnBalance).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnBalance).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnBalance).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnBalance).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnBalance).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnBalance).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnBalance).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnBalance).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnBalance).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnBalance).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnBalance.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalance.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalance.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalance.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnBalance.Image = null;
		((QControl)BtnBalance).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnBalance).Location = new Point(709, 436);
		((Control)BtnBalance).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnBalance).Name = "BtnBalance";
		((Control)BtnBalance).Size = new Size(98, 33);
		((Control)BtnBalance).TabIndex = 1165;
		BtnBalance.Text = "Balance";
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
		((Control)BtnAc).Location = new Point(233, 358);
		((BaseControl)BtnAc).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnAc).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnAc).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnAc).Name = "BtnAc";
		((Control)BtnAc).Size = new Size(35, 23);
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
		((Control)BtnMemb).Location = new Point(274, 358);
		((BaseControl)BtnMemb).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnMemb).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnMemb).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnMemb).Name = "BtnMemb";
		((Control)BtnMemb).Size = new Size(35, 23);
		((Control)BtnMemb).TabIndex = 1167;
		BtnMemb.Text = "M";
		((BaseControl)BtnMemb).ToolTip = "Member Help";
		((ButtonBase)chkAllRow).BackColor = SystemColors.ButtonHighlight;
		((Control)chkAllRow).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkAllRow).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkAllRow).Location = new Point(335, 361);
		((Control)chkAllRow).Name = "chkAllRow";
		((Control)chkAllRow).RightToLeft = (RightToLeft)0;
		((Control)chkAllRow).Size = new Size(134, 19);
		((Control)chkAllRow).TabIndex = 1168;
		((ButtonBase)chkAllRow).Text = "Select All Row";
		((ButtonBase)chkAllRow).UseVisualStyleBackColor = false;
		((Control)lblSmsRow).BackColor = Color.Transparent;
		((Control)lblSmsRow).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblSmsRow).ForeColor = Color.FromArgb(192, 0, 0);
		lblSmsRow.ImeMode = (ImeMode)0;
		((Control)lblSmsRow).Location = new Point(475, 361);
		((Control)lblSmsRow).Name = "lblSmsRow";
		((Control)lblSmsRow).Size = new Size(94, 20);
		((Control)lblSmsRow).TabIndex = 1169;
		lblSmsRow.Text = "Sms Row";
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
		((Control)btnExlImport).Location = new Point(1057, 42);
		((Control)btnExlImport).Margin = new Padding(3, 6, 3, 6);
		((Control)btnExlImport).Name = "btnExlImport";
		((Control)btnExlImport).Size = new Size(115, 37);
		((Control)btnExlImport).TabIndex = 1170;
		btnExlImport.Text = "Exel Import";
		((FileDialog)DlgOpn).FileName = "OpenFileDialog1";
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(704, 479);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(74, 20);
		((Control)Label6).TabIndex = 1171;
		Label6.Text = "Sms Type";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tsmstype).BackColor = Color.White;
		((Control)tsmstype).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tsmstype).Location = new Point(783, 478);
		((TextBoxBase)tsmstype).MaxLength = 1;
		((Control)tsmstype).Name = "tsmstype";
		((Control)tsmstype).Size = new Size(24, 22);
		((Control)tsmstype).TabIndex = 1172;
		tsmstype.TextAlign = (HorizontalAlignment)2;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.FromArgb(192, 0, 0);
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(829, 463);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(150, 20);
		((Control)Label7).TabIndex = 1173;
		Label7.Text = "Type  = O  Party Os";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label8).BackColor = Color.Transparent;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label8).ForeColor = Color.FromArgb(192, 0, 0);
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(829, 488);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(150, 20);
		((Control)Label8).TabIndex = 1174;
		Label8.Text = "Type  = L  Bill Msg";
		Label8.TextAlign = (ContentAlignment)16;
		((Control)Label9).BackColor = Color.Transparent;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label9).ForeColor = Color.FromArgb(192, 0, 0);
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(829, 514);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(150, 20);
		((Control)Label9).TabIndex = 1175;
		Label9.Text = "Type  = G  Gold Rate";
		Label9.TextAlign = (ContentAlignment)16;
		((Control)Label10).BackColor = Color.Transparent;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label10).ForeColor = Color.FromArgb(192, 0, 0);
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(985, 514);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(187, 20);
		((Control)Label10).TabIndex = 1178;
		Label10.Text = "Type  = M Then Mobile Os";
		Label10.TextAlign = (ContentAlignment)16;
		((Control)Label11).BackColor = Color.Transparent;
		((Control)Label11).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label11).ForeColor = Color.FromArgb(192, 0, 0);
		Label11.ImeMode = (ImeMode)0;
		((Control)Label11).Location = new Point(985, 488);
		((Control)Label11).Name = "Label11";
		((Control)Label11).Size = new Size(187, 20);
		((Control)Label11).TabIndex = 1177;
		Label11.Text = "Type  = B Then Birthday";
		Label11.TextAlign = (ContentAlignment)16;
		((Control)Label12).BackColor = Color.Transparent;
		((Control)Label12).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label12).ForeColor = Color.FromArgb(192, 0, 0);
		Label12.ImeMode = (ImeMode)0;
		((Control)Label12).Location = new Point(985, 463);
		((Control)Label12).Name = "Label12";
		((Control)Label12).Size = new Size(187, 20);
		((Control)Label12).TabIndex = 1176;
		Label12.Text = "Type  = A Then Anniversary";
		Label12.TextAlign = (ContentAlignment)16;
		((Control)Label13).BackColor = Color.Transparent;
		((Control)Label13).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label13).ForeColor = Color.Black;
		Label13.ImeMode = (ImeMode)0;
		((Control)Label13).Location = new Point(10, 77);
		((Control)Label13).Name = "Label13";
		((Control)Label13).Size = new Size(110, 20);
		((Control)Label13).TabIndex = 1180;
		Label13.Text = "Barthday Sms";
		Label13.TextAlign = (ContentAlignment)64;
		cboBarth.AutoCompleteMode = (AutoCompleteMode)2;
		cboBarth.AutoCompleteSource = (AutoCompleteSource)256;
		cboBarth.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboBarth).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboBarth).FormattingEnabled = true;
		((Control)cboBarth).Location = new Point(128, 78);
		cboBarth.MaxLength = 20;
		((Control)cboBarth).Name = "cboBarth";
		((Control)cboBarth).Size = new Size(145, 24);
		((Control)cboBarth).TabIndex = 1179;
		((ButtonBase)ChkOnlyMoNo).BackColor = SystemColors.ButtonHighlight;
		ChkOnlyMoNo.Checked = true;
		ChkOnlyMoNo.CheckState = (CheckState)1;
		((Control)ChkOnlyMoNo).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)ChkOnlyMoNo).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)ChkOnlyMoNo).Location = new Point(768, 43);
		((Control)ChkOnlyMoNo).Name = "ChkOnlyMoNo";
		((Control)ChkOnlyMoNo).RightToLeft = (RightToLeft)0;
		((Control)ChkOnlyMoNo).Size = new Size(121, 19);
		((Control)ChkOnlyMoNo).TabIndex = 1181;
		((ButtonBase)ChkOnlyMoNo).Text = "Ac With Mobile";
		((ButtonBase)ChkOnlyMoNo).UseVisualStyleBackColor = false;
		((ButtonBase)chkOsAmt).BackColor = SystemColors.ButtonHighlight;
		((Control)chkOsAmt).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOsAmt).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkOsAmt).Location = new Point(768, 66);
		((Control)chkOsAmt).Name = "chkOsAmt";
		((Control)chkOsAmt).RightToLeft = (RightToLeft)0;
		((Control)chkOsAmt).Size = new Size(121, 19);
		((Control)chkOsAmt).TabIndex = 1182;
		((ButtonBase)chkOsAmt).Text = "Party Os";
		((ButtonBase)chkOsAmt).UseVisualStyleBackColor = false;
		((Control)lblAcGroup).BackColor = Color.Transparent;
		((Control)lblAcGroup).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAcGroup).ForeColor = Color.Black;
		lblAcGroup.ImeMode = (ImeMode)0;
		((Control)lblAcGroup).Location = new Point(280, 44);
		((Control)lblAcGroup).Name = "lblAcGroup";
		((Control)lblAcGroup).Size = new Size(92, 20);
		((Control)lblAcGroup).TabIndex = 1184;
		lblAcGroup.Text = "Ac Group";
		lblAcGroup.TextAlign = (ContentAlignment)64;
		cboAcGroup.AutoCompleteMode = (AutoCompleteMode)2;
		cboAcGroup.AutoCompleteSource = (AutoCompleteSource)256;
		cboAcGroup.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboAcGroup).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboAcGroup).FormattingEnabled = true;
		((Control)cboAcGroup).Location = new Point(382, 44);
		cboAcGroup.MaxLength = 20;
		((Control)cboAcGroup).Name = "cboAcGroup";
		((Control)cboAcGroup).Size = new Size(191, 24);
		((Control)cboAcGroup).TabIndex = 1183;
		((ButtonBase)chkRetSend).BackColor = SystemColors.ButtonHighlight;
		((Control)chkRetSend).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkRetSend).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkRetSend).Location = new Point(768, 90);
		((Control)chkRetSend).Name = "chkRetSend";
		((Control)chkRetSend).RightToLeft = (RightToLeft)0;
		((Control)chkRetSend).Size = new Size(135, 19);
		((Control)chkRetSend).TabIndex = 1185;
		((ButtonBase)chkRetSend).Text = "Today Rate Send";
		((ButtonBase)chkRetSend).UseVisualStyleBackColor = false;
		((Control)lblSmsCount).BackColor = Color.Transparent;
		((Control)lblSmsCount).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblSmsCount).ForeColor = Color.FromArgb(192, 0, 0);
		lblSmsCount.ImeMode = (ImeMode)0;
		((Control)lblSmsCount).Location = new Point(596, 361);
		((Control)lblSmsCount).Name = "lblSmsCount";
		((Control)lblSmsCount).Size = new Size(94, 20);
		((Control)lblSmsCount).TabIndex = 1186;
		lblSmsCount.Text = "Sms Count";
		lblSmsCount.TextAlign = (ContentAlignment)32;
		((Control)Label14).BackColor = Color.Transparent;
		((Control)Label14).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label14).ForeColor = Color.Black;
		Label14.ImeMode = (ImeMode)0;
		((Control)Label14).Location = new Point(16, 479);
		((Control)Label14).Name = "Label14";
		((Control)Label14).Size = new Size(84, 46);
		((Control)Label14).TabIndex = 1188;
		Label14.Text = "Multi Language";
		Label14.TextAlign = (ContentAlignment)64;
		((TextBoxBase)TxtUniCode).BackColor = Color.White;
		((Control)TxtUniCode).Font = new Font("Arial", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)TxtUniCode).Location = new Point(110, 487);
		((TextBoxBase)TxtUniCode).MaxLength = 255;
		TxtUniCode.Multiline = true;
		((Control)TxtUniCode).Name = "TxtUniCode";
		((Control)TxtUniCode).Size = new Size(586, 67);
		((Control)TxtUniCode).TabIndex = 1187;
		_comboFrom.BackColor = Color.FromArgb(255, 224, 192);
		((Control)_comboFrom).Font = new Font("Tahoma", 9f);
		((ListControl)_comboFrom).FormattingEnabled = true;
		((Control)_comboFrom).Location = new Point(110, 458);
		((Control)_comboFrom).Name = "_comboFrom";
		((Control)_comboFrom).Size = new Size(124, 22);
		((Control)_comboFrom).TabIndex = 1189;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(14, 458);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(90, 20);
		((Control)Label15).TabIndex = 1190;
		Label15.Text = "Translate To";
		Label15.TextAlign = (ContentAlignment)64;
		_comboTo.BackColor = Color.FromArgb(255, 224, 192);
		((Control)_comboTo).Font = new Font("Tahoma", 9f);
		((ListControl)_comboTo).FormattingEnabled = true;
		((Control)_comboTo).Location = new Point(457, 458);
		((Control)_comboTo).Name = "_comboTo";
		((Control)_comboTo).Size = new Size(124, 22);
		((Control)_comboTo).TabIndex = 1191;
		((Control)Label16).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label16).ForeColor = Color.Black;
		Label16.ImeMode = (ImeMode)0;
		((Control)Label16).Location = new Point(343, 459);
		((Control)Label16).Name = "Label16";
		((Control)Label16).Size = new Size(109, 20);
		((Control)Label16).TabIndex = 1192;
		Label16.Text = "Translate From";
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
		((Control)BtnTanslat).Location = new Point(240, 458);
		((BaseControl)BtnTanslat).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)BtnTanslat).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)BtnTanslat).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnTanslat).Name = "BtnTanslat";
		((Control)BtnTanslat).Size = new Size(96, 23);
		((Control)BtnTanslat).TabIndex = 1193;
		BtnTanslat.Text = "Translate";
		((BaseControl)BtnTanslat).ToolTip = "Translate";
		((Control)lblMsgLenth).BackColor = Color.Transparent;
		((Control)lblMsgLenth).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMsgLenth).ForeColor = Color.FromArgb(192, 0, 0);
		lblMsgLenth.ImeMode = (ImeMode)0;
		((Control)lblMsgLenth).Location = new Point(709, 360);
		((Control)lblMsgLenth).Name = "lblMsgLenth";
		((Control)lblMsgLenth).Size = new Size(94, 20);
		((Control)lblMsgLenth).TabIndex = 1194;
		lblMsgLenth.Text = "Msg Lenth";
		lblMsgLenth.TextAlign = (ContentAlignment)32;
		((Label)_lnkSourceEnglish).AutoSize = true;
		((Control)_lnkSourceEnglish).Location = new Point(59, 436);
		((Control)_lnkSourceEnglish).Name = "_lnkSourceEnglish";
		((Control)_lnkSourceEnglish).Size = new Size(41, 13);
		((Control)_lnkSourceEnglish).TabIndex = 1195;
		_lnkSourceEnglish.TabStop = true;
		_lnkSourceEnglish.Text = "English";
		((Label)_lnkTargetEnglish).AutoSize = true;
		((Control)_lnkTargetEnglish).Location = new Point(587, 463);
		((Control)_lnkTargetEnglish).Name = "_lnkTargetEnglish";
		((Control)_lnkTargetEnglish).Size = new Size(41, 13);
		((Control)_lnkTargetEnglish).TabIndex = 1196;
		_lnkTargetEnglish.TabStop = true;
		_lnkTargetEnglish.Text = "English";
		((QControl)btnWhatsapp).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhatsapp).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)btnWhatsapp).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)btnWhatsapp).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhatsapp).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)btnWhatsapp).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)btnWhatsapp).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)btnWhatsapp).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)btnWhatsapp).ColorScheme).InheritCurrentThemeFromGlobal = false;
		btnWhatsapp.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhatsapp.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhatsapp.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhatsapp.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		btnWhatsapp.Image = null;
		((QControl)btnWhatsapp).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)btnWhatsapp).Location = new Point(709, 514);
		((Control)btnWhatsapp).Margin = new Padding(3, 6, 3, 6);
		((Control)btnWhatsapp).Name = "btnWhatsapp";
		((Control)btnWhatsapp).Size = new Size(98, 33);
		((Control)btnWhatsapp).TabIndex = 1197;
		btnWhatsapp.Text = "Whatsapp";
		((Control)btnWhatsapp).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)btnWhatsapp);
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
		((Control)this).Controls.Add((Control)(object)chkRetSend);
		((Control)this).Controls.Add((Control)(object)lblAcGroup);
		((Control)this).Controls.Add((Control)(object)cboAcGroup);
		((Control)this).Controls.Add((Control)(object)chkOsAmt);
		((Control)this).Controls.Add((Control)(object)ChkOnlyMoNo);
		((Control)this).Controls.Add((Control)(object)Label13);
		((Control)this).Controls.Add((Control)(object)cboBarth);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)Label11);
		((Control)this).Controls.Add((Control)(object)Label12);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tsmstype);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)btnExlImport);
		((Control)this).Controls.Add((Control)(object)lblSmsRow);
		((Control)this).Controls.Add((Control)(object)chkAllRow);
		((Control)this).Controls.Add((Control)(object)BtnMemb);
		((Control)this).Controls.Add((Control)(object)BtnAc);
		((Control)this).Controls.Add((Control)(object)BtnBalance);
		((Control)this).Controls.Add((Control)(object)BtnSmsSend);
		((Control)this).Controls.Add((Control)(object)WebBrowser1);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)tMsg);
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
		((Control)this).Name = "UT_SMS";
		((Form)this).Text = "Sms Master";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void BtnSmsSend_Click(object sender, EventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SmsId, "", false) == 0)
		{
			Interaction.MsgBox((object)"You Have No SMS Pack...Please By SMS Pack....", (MsgBoxStyle)0, (object)null);
		}
		MaxPages = 0;
		LastRow = 0;
		TotSms = 0;
		Pages = 0;
		lblSmsRow.Text = "Sms Row";
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
			if (Operators.CompareString(tMsg.Text, "", false) != 0)
			{
				SendDetl = tMsg.Text;
			}
			else
			{
				TextBox txtUniCode;
				string Data = (txtUniCode = TxtUniCode).Text;
				string sendDetl = StrToHex(ref Data);
				txtUniCode.Text = Data;
				SendDetl = sendDetl;
			}
			if (Operators.CompareString(tMobileNo.Text, "", false) != 0)
			{
				SingelMsg();
			}
			else if (cboBarth.SelectedIndex != 0)
			{
				BirthdaySms();
			}
			else if (chkOsAmt.Checked)
			{
				PartyOsSms();
			}
			else
			{
				DgvSms();
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

	private void PartyOsSms()
	{
		DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE IN ('O') ORDER BY MSG_TYPE ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[0]["MSG_DETL"], (object)""));
		}
		SendRow = 0;
		ScelectMo = "";
		int num = 8;
		DataGridViewX dGV = DGV;
		int lastRow = LastRow;
		checked
		{
			int num2 = ((DataGridView)dGV).Rows.Count - 1;
			DC_Main.M = lastRow;
			while (DC_Main.M <= num2)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
				{
					LastRow = DC_Main.M + 1;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value)) != 0.0))
					{
						SendDetl = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(tMsg.Text + " Rs ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value), (object)" Gold Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value), (object)" Silver Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value));
					}
					else if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value)) != 0.0))
					{
						SendDetl = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(tMsg.Text + " Gold Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value), (object)" Silver Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value));
					}
					else if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value)) != 0.0))
					{
						SendDetl = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(tMsg.Text + " Rs ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value), (object)" Silver Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[4].Value));
					}
					else if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value)) != 0.0))
					{
						SendDetl = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)(tMsg.Text + " Rs ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value), (object)" Gold Fine ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[3].Value));
					}
					else
					{
						SendDetl = Conversions.ToString(Operators.ConcatenateObject((object)(tMsg.Text + " Rs ="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value));
					}
					if (Strings.Len(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value)) == 10)
					{
						TotSms++;
						switch (DC_Main.SmsLink)
						{
						case "001":
							theWebSite = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value), (object)"&message="), (object)SendDetl), (object)"&sender=JEWELL&route=1"));
							break;
						case "002":
						case "012":
						case "022":
						case "032":
						case "042":
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
							{
								theWebSite = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value), (object)"&sms="), (object)SendDetl), (object)"&templateid=1607100000000291855"));
							}
							else if (Operators.CompareString(tMsg.Text, "", false) != 0)
							{
								theWebSite = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value), (object)"&text="), (object)SendDetl));
							}
							else
							{
								theWebSite = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno="), ((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value), (object)"&text="), (object)SendDetl), (object)"&unicode=1"));
							}
							break;
						}
						WebBrowser1.Navigate(theWebSite);
						lblSmsCount.Text = Conversions.ToString(TotSms);
						break;
					}
				}
				DC_Main.M++;
			}
			dGV = null;
		}
	}

	private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		checked
		{
			if (Pages <= MaxPages)
			{
				Thread.Sleep(2000);
				Application.DoEvents();
				if (cboBarth.SelectedIndex != 0)
				{
					BirthdaySms();
				}
				else if (chkOsAmt.Checked)
				{
					PartyOsSms();
				}
				else
				{
					DgvSms();
				}
				Pages++;
				if (MaxPages == Pages)
				{
					Interaction.MsgBox((object)(Conversions.ToString(TotSms) + " Message sent successfully"), (MsgBoxStyle)0, (object)null);
				}
			}
		}
	}

	private void BirthdaySms()
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
					text2 = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)""));
				}
				else if (Operators.ConditionalCompareObjectEqual(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_TYPE"], (object)"B", false))
				{
					text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.i]["MSG_DETL"], (object)""));
				}
				DC_Main.i++;
			}
			SendRow = 0;
			TotSms = 0;
			ScelectMo = "";
			int num2 = 5;
			DataGridViewX dGV = DGV;
			int lastRow = LastRow;
			int num3 = ((DataGridView)dGV).Rows.Count - 1;
			DC_Main.M = lastRow;
			while (DC_Main.M <= num3)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false))
				{
					if (Operators.CompareString(Strings.Mid(Conversions.ToString(((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value), 1, 1), "A", false) == 0)
					{
						tMsg.Text = text2;
					}
					else if (Operators.CompareString(Strings.Mid(Conversions.ToString(((DataGridView)dGV).Rows[DC_Main.M].Cells[2].Value), 1, 1), "B", false) == 0)
					{
						tMsg.Text = text;
					}
					LastRow = DC_Main.M + 1;
					SendDetl = tMsg.Text;
					lblSmsCount.Text = Conversions.ToString(0);
					if (Strings.Len(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[num2].Value)) == 10)
					{
						ScelectMo = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)dGV).Rows[DC_Main.M].Cells[num2].Value, (object)""));
						TotSms++;
						switch (DC_Main.SmsLink)
						{
						case "001":
							theWebSite = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + ScelectMo + "&message=" + SendDetl + "&sender=JEWELL&route=1";
							break;
						case "002":
						case "012":
						case "022":
						case "032":
						case "042":
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
							{
								theWebSite = "http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number=" + ScelectMo + "&sms=" + SendDetl + "&templateid=1607100000000291855";
							}
							else if (Operators.CompareString(tMsg.Text, "", false) != 0)
							{
								theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl;
							}
							else
							{
								theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl + "&unicode=1";
							}
							break;
						}
						WebBrowser1.Navigate(theWebSite);
						lblSmsCount.Text = Conversions.ToString(TotSms);
						break;
					}
				}
				DC_Main.M++;
			}
			dGV = null;
		}
	}

	private void DgvSms()
	{
		SendRow = 0;
		TotSms = 0;
		ScelectMo = "";
		int num = 6;
		if (chkRetSend.Checked)
		{
			num = 5;
		}
		if (CboSmsType.SelectedIndex == 2)
		{
			num = 7;
		}
		lblSmsCount.Text = Conversions.ToString(0);
		DataGridViewX dGV = DGV;
		int lastRow = LastRow;
		checked
		{
			int num2 = ((DataGridView)dGV).Rows.Count - 1;
			DC_Main.M = lastRow;
			while (DC_Main.M <= num2)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV).Rows[DC_Main.M].Cells[0].Value, (object)true, false) && Strings.Len(RuntimeHelpers.GetObjectValue(((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value)) == 10)
				{
					ScelectMo = Conversions.ToString(Operators.ConcatenateObject(Operators.AddObject((object)(ScelectMo ?? ""), ((DataGridView)dGV).Rows[DC_Main.M].Cells[num].Value), (object)","));
					SendRow++;
					TotSms++;
					if (SendRow > 20)
					{
						SendRow = 0;
						LastRow = DC_Main.M + 1;
						ScelectMo = Strings.Mid(ScelectMo, 1, Strings.Len(ScelectMo) - 1);
						switch (DC_Main.SmsLink)
						{
						case "001":
							theWebSite = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + ScelectMo + "&message=" + SendDetl + "&sender=JEWELL&route=1";
							break;
						case "002":
						case "012":
						case "022":
						case "032":
						case "042":
							if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
							{
								theWebSite = "http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number=" + ScelectMo + "&sms=" + SendDetl + "&templateid=1607100000000291855";
							}
							else if (Operators.CompareString(tMsg.Text, "", false) != 0)
							{
								if (Operators.CompareString(DC_Main.SSRegSrNo, "AK007NEAK", false) == 0)
								{
									theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl;
								}
								else
								{
									theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl;
								}
							}
							else
							{
								theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl + "&unicode=1";
							}
							break;
						}
						WebBrowser1.Navigate(theWebSite);
						lblSmsCount.Text = Conversions.ToString(TotSms);
						Application.DoEvents();
						break;
					}
				}
				DC_Main.M++;
			}
			if (SendRow > 0)
			{
				SendRow = 0;
				LastRow = DC_Main.M + 1;
				ScelectMo = Strings.Mid(ScelectMo, 1, Strings.Len(ScelectMo) - 1);
				switch (DC_Main.SmsLink)
				{
				case "001":
					theWebSite = "http://beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + ScelectMo + "&message=" + SendDetl + "&sender=JEWELL&route=1";
					break;
				case "002":
				case "012":
				case "022":
				case "032":
				case "042":
					if (Operators.CompareString(tMsg.Text, "", false) != 0)
					{
						theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl;
					}
					else
					{
						theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl + "&unicode=1";
					}
					break;
				}
				WebBrowser1.Navigate(theWebSite);
				lblSmsCount.Text = Conversions.ToString(TotSms);
				Application.DoEvents();
			}
			dGV = null;
		}
	}

	private void SingelMsg()
	{
		//IL_0274: Unknown result type (might be due to invalid IL or missing references)
		if (!((Strings.Len(tMobileNo.Text) == 10) & (Operators.CompareString(SendDetl, "", false) != 0)))
		{
			return;
		}
		ScelectMo = tMobileNo.Text;
		switch (DC_Main.SmsLink)
		{
		case "001":
			theWebSite = "http: //beta.tripadasmsbox.com/api/sendapi.php?auth_key=" + DC_Main.SmsId + "&mobiles=" + ScelectMo + "&message=" + SendDetl + "&sender=JEWELL&route=1";
			break;
		case "002":
		case "012":
		case "022":
		case "032":
		case "042":
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
			{
				theWebSite = "http://site.ping4sms.com/api/smsapi?key=" + DC_Main.SmsUser + "&route=2&sender=" + DC_Main.SmsId + "&number=" + ScelectMo + "&sms=" + SendDetl + "&templateid=1607100000000291855";
			}
			else if (Operators.CompareString(tMsg.Text, "", false) != 0)
			{
				theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&sender=" + DC_Main.SmsId + "&mobileno=" + ScelectMo + "&text=" + SendDetl;
			}
			else
			{
				theWebSite = "https://sms.mobileadz.in/api/push?apikey=" + DC_Main.SmsUser + "&password=" + DC_Main.SmsPwd + "&sender=" + DC_Main.SmsId + "&to=" + ScelectMo + "&message=" + SendDetl + "&route=route3&unicode=1";
			}
			break;
		}
		WebBrowser1.Navigate(theWebSite);
		Interaction.MsgBox((object)"Message sent successfully", (MsgBoxStyle)0, (object)null);
	}

	private void UT_SMS_Load(object sender, EventArgs e)
	{
		//IL_0a7e: Unknown result type (might be due to invalid IL or missing references)
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
				Label obj4 = lblBook;
				object? obj5 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj4).ForeColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj6 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				((DataGridView)DGV).BackgroundColor = Color.DarkGray;
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				((ButtonBase)ChkOnlyMoNo).BackColor = Color.Silver;
				((ButtonBase)chkOsAmt).BackColor = Color.Silver;
				((ButtonBase)chkAllRow).BackColor = Color.Silver;
				((ButtonBase)chkRetSend).BackColor = Color.Silver;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				CheckBox obj9 = chkRetSend;
				object? obj10 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj9).BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj11 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj12 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				ComboBox cboSmsType = CboSmsType;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				cboSmsType.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				CheckBox chkOnlyMoNo = ChkOnlyMoNo;
				object? obj14 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)chkOnlyMoNo).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				CheckBox obj15 = chkOsAmt;
				object? obj16 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj15).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				CheckBox obj17 = chkAllRow;
				object? obj18 = colorConverter.ConvertFromString("200, 205, 210");
				((ButtonBase)obj17).BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj19 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				CheckBox obj20 = chkOsAmt;
				object? obj21 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj20).BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				CheckBox obj22 = chkAllRow;
				object? obj23 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj22).BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				CheckBox obj24 = chkRetSend;
				object? obj25 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj24).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				Label obj26 = lblBook;
				object? obj27 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj26).ForeColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj28 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewX dGV2 = DGV;
				object? obj29 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj30 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				ComboBox cboSmsType2 = CboSmsType;
				object? obj31 = colorConverter.ConvertFromString("Cornsilk");
				cboSmsType2.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				CheckBox chkOnlyMoNo2 = ChkOnlyMoNo;
				object? obj32 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)chkOnlyMoNo2).BackColor = ((obj32 != null) ? ((Color)obj32) : default(Color));
				CheckBox obj33 = chkOsAmt;
				object? obj34 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj33).BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				CheckBox obj35 = chkAllRow;
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((ButtonBase)obj35).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
			}
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			CboSmsType.Items.Add((object)"Accounts");
			CboSmsType.Items.Add((object)"Address");
			CboSmsType.Items.Add((object)"Scheme");
			CboSmsType.SelectedIndex = 0;
			cboBarth.Items.Add((object)"");
			cboBarth.Items.Add((object)"Both");
			cboBarth.Items.Add((object)"Barthday");
			cboBarth.Items.Add((object)"Anniversary");
			cboBarth.SelectedIndex = 0;
			AcGroupDetl();
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
			EntryMode = "A";
			CurActCtrl = (Control)(object)nFromOs;
		}
	}

	private void CboSmsType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("0"))
		{
			lblAcGroup.Text = "Ac Group";
		}
		else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("1"))
		{
			lblAcGroup.Text = "Cust Group";
		}
		else if ((double)CboSmsType.SelectedIndex == Conversions.ToDouble("2"))
		{
			lblAcGroup.Text = "Schm Code";
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
	}

	private void AddressMast()
	{
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_011c: Expected O, but got Unknown
		//IL_01c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Expected O, but got Unknown
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_0182: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a7: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM ADD_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ";
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + cboAcGroup.Text + "'";
		}
		DC_Main.RsQry += "ORDER BY A.AC_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DataGridViewX dGV = DGV;
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
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected O, but got Unknown
		//IL_01d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d7: Expected O, but got Unknown
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_017a: Unknown result type (might be due to invalid IL or missing references)
		//IL_017f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0189: Expected O, but got Unknown
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		DC_Main.RsQry = "SELECT A.* FROM AD_MEMB AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_MOBILE <> '' ";
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.SCHM_CODE =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
		}
		DC_Main.RsQry += "ORDER BY A.SCHM_CODE,A.MEMB_CODE";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DataGridViewX dGV = DGV;
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
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0207: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Unknown result type (might be due to invalid IL or missing references)
		//IL_019b: Expected O, but got Unknown
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c0: Expected O, but got Unknown
		//IL_01d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01db: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e5: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		ColorConverter colorConverter = new ColorConverter();
		if (Operators.CompareString(DC_Main.MsVbImport, "Y", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_CODE > '00100'  ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.AC_CODE,A.AC_NAME,A.AC_ADD1,A.AC_CITY,A.AC_MOBILE,A.AC_MOBILE2 FROM AC_MAST  AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND LEN(A.AC_CODE) <> 5  ";
		}
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND A.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
		}
		DC_Main.RsQry += "ORDER BY A.AC_NAME";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		checked
		{
			if (DC_Main.Tbl.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
			{
				DataGridViewX dGV = DGV;
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

	private void CLEAR_DATA()
	{
		BtnCancel_Click(BtnCancel, new EventArgs());
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void UT_SMS_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void UT_SMS_KeyPress(object sender, KeyPressEventArgs e)
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

	private void UT_SMS_KeyDown(object sender, KeyEventArgs e)
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
		//IL_019d: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
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
					DC_Main.ExeQuteDc("DELETE FROM MSG_MAST WHERE MSG_TYPE = '" + tsmstype.Text + "' AND MSG_DETL <> ''");
					if (Operators.CompareString(tsmstype.Text, "", false) != 0)
					{
						DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','" + tsmstype.Text + "','E','" + tMsg.Text + "')";
					}
					else
					{
						DC_Main.RsQry = "INSERT INTO MSG_MAST(CO_CODE,MSG_TYPE,MSG_TYPING,MSG_DETL) VALUES('" + DC_Main.MCo_code + "','N','E','" + tMsg.Text + "')";
					}
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					Interaction.MsgBox((object)"Data Is Save Ok...", (MsgBoxStyle)0, (object)null);
					BtnCancel_Click(BtnCancel, new EventArgs());
					goto end_IL_0001;
				case 421:
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
				try0001_dispatch = 421;
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
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		CboSmsType.SelectedIndex = 0;
		AcGroupDetl();
		EntryMode = "A";
		((Control)nFromOs).Focus();
	}

	private void UT_SMS_Closed(object sender, EventArgs e)
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
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,A.AC_ADD1 As AddressL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
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
		checked
		{
			if (chkAllRow.Checked)
			{
				int num = ((DataGridView)DGV).Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
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
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Invalid comparison between Unknown and I4
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Expected O, but got Unknown
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_011c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0121: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		if ((int)Interaction.MsgBox((object)"Are You Sure To Import Old Software Data In Next Software ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) != 6)
		{
			return;
		}
		((FileDialog)DlgOpn).Filter = "Excel files |*.xls;*.xlsx";
		((FileDialog)DlgOpn).Title = "Open File";
		if ((int)((CommonDialog)DlgOpn).ShowDialog() == 1)
		{
			DC_Main.Tbl = ImportExceltoDatatable(((FileDialog)DlgOpn).FileName);
			DataGridViewX dGV = DGV;
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
				((DataGridView)dGV).Columns[1].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcCode");
				((DataGridView)dGV).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "AcName");
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Address");
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "City");
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile");
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns.Add("", "Mobile2");
				((DataGridView)dGV).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridViewColumn)val).Name = "Select";
				int num = DC_Main.Tbl.Rows.Count - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i;
					((DataGridView)dGV)[2, DC_Main.i].Value = "";
					((DataGridView)dGV)[3, DC_Main.i].Value = "";
					((DataGridView)dGV)[4, DC_Main.i].Value = "";
					((DataGridView)dGV)[5, DC_Main.i].Value = "";
					((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i][0]);
					((DataGridView)dGV)[7, DC_Main.i].Value = "";
					DC_Main.i++;
				}
				dGV = null;
			}
		}
	}

	private void BtnBalance_Click(object sender, EventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(DC_Main.SmsId, "", false) == 0)
		{
			Interaction.MsgBox((object)"You Have No SMS Pack...Please By SMS Pack....", (MsgBoxStyle)0, (object)null);
		}
		switch (DC_Main.SmsLink)
		{
		case "001":
			theWebSite = "http://beta.tripadasmsbox.com/api/balance.php?auth_key=" + DC_Main.SmsId + "&type=1";
			break;
		case "002":
		case "012":
		case "022":
		case "032":
		case "042":
			if (Operators.CompareString(DC_Main.SSRegSrNo, "HM307NEKU", false) == 0)
			{
				theWebSite = "http://site.ping4sms.com/api/creditapi?key=8b37b75ef95002a3a22738c2bb869e2f&route=2";
			}
			break;
		}
		WebBrowser1.Navigate(theWebSite);
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
		//IL_066e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_06db: Expected O, but got Unknown
		//IL_0788: Unknown result type (might be due to invalid IL or missing references)
		//IL_078f: Expected O, but got Unknown
		//IL_070d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_071c: Expected O, but got Unknown
		//IL_0732: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Expected O, but got Unknown
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_075c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0766: Expected O, but got Unknown
		if (cboBarth.SelectedIndex == 2)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND (DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "   AND   MONTH(BR_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + ") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" AND A.AC_CODE > '00100'  "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
		}
		else if (cboBarth.SelectedIndex == 3)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  AND (DAY(AN_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + " AND   MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + ")  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" AND A.AC_CODE > '00100'   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(AN_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(ANV_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND   MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)")  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)"  "));
		}
		else
		{
			if (cboBarth.SelectedIndex != 1)
			{
				return;
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'P' As AcType FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND (DAY(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(BR_DATE) =  " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + " or  DAY(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2) + "  AND MONTH(AN_DATE) = " + Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2) + ")  "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" AND A.AC_CODE > '00100'   "), (object)" UNION ALL SELECT AC_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BR_DATE,AN_DATE,'A' As AcType  FROM ADD_MAST  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BR_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BR_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(AN_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "), (object)" UNION ALL SELECT MEMB_NAME,AC_ADD1,AC_CITY,AC_PHONE,AC_MOBILE,AC_MOBILE2,BIRTH_DATE,ANV_DATE,'S' As AcType  FROM AD_MEMB  AS A WHERE A.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND (DAY(BIRTH_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)" AND MONTH(BIRTH_DATE) =  "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)" or  DAY(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 1, 2)), (object)"  AND MONTH(ANV_DATE) = "), (object)Strings.Mid(Conversions.ToString(DC_Main.MsSysDate), 4, 2)), (object)") "), Interaction.IIf(!ChkOnlyMoNo.Checked, (object)"", (object)"AND (A.AC_MOBILE <> '' OR A.AC_PHONE <> '' OR A.AC_MOBILE2 <> '')")), (object)" "));
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
		DataGridViewX dGV = DGV;
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
				else
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = Operators.ConcatenateObject(Operators.ConcatenateObject(Interaction.IIf(Information.IsDBNull(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["BR_DATE"])), (object)"A", (object)"B"), (object)" - "), DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
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

	private void ChkOsAmt_CheckedChanged(object sender, EventArgs e)
	{
		//IL_051e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0582: Unknown result type (might be due to invalid IL or missing references)
		//IL_058c: Expected O, but got Unknown
		//IL_0639: Unknown result type (might be due to invalid IL or missing references)
		//IL_0640: Expected O, but got Unknown
		//IL_05be: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_05e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Expected O, but got Unknown
		//IL_0608: Unknown result type (might be due to invalid IL or missing references)
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		if (!chkOsAmt.Checked)
		{
			return;
		}
		DC_Main.ExeQuteDc("DELETE FROM LEDR_AC_DATA ");
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.AC_CODE,B.AC_GR As AcGr,A.DATA_TYPE, SUM(CR_AMT - DR_AMT) AS AcAmt,SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) as GoldWt,sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) as SilverWt FROM AC_DATA AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,B.AC_GR,A.DATA_TYPE  HAVING SUM(CR_AMT - DR_AMT) < 0 OR SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END )ELSE 0 END) < 0  OR sum(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.SIGN = '+' THEN A.FINE_WT ELSE -A.FINE_WT END) ELSE 0 END) < 0"));
		if (Operators.CompareString(cboAcGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.AC_GR =  '" + AryGroup[cboAcGroup.SelectedIndex] + "'";
		}
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.X = 0;
		checked
		{
			while (DC_Main.X < DC_Main.Rshlp.Rows.Count)
			{
				double value = 0.0;
				double value2 = 0.0;
				double value3 = 0.0;
				if (Operators.ConditionalCompareObjectLess(DC_Main.Rshlp.Rows[DC_Main.X]["ACAMT"], (object)0, false))
				{
					value = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["ACAMT"]), "0.00"));
				}
				if (Operators.ConditionalCompareObjectLess(DC_Main.Rshlp.Rows[DC_Main.X]["GoldWt"], (object)0, false))
				{
					value2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["GoldWt"]), "0.000"));
				}
				if (Operators.ConditionalCompareObjectLess(DC_Main.Rshlp.Rows[DC_Main.X]["SilverWt"], (object)0, false))
				{
					value3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.X]["SilverWt"]), "0.000"));
				}
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO LEDR_AC_DATA (CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_DT,AC_CODE,CR_AMT,DR_AMT,CR_FINE_WT,DR_FINE_WT,CR_SL_FINE,DR_SL_FINE,DATA_TYPE)  VALUES('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','" + DC_Main.MCo_year + "','000','" + Strings.Format((object)DateAndTime.Now, "MM/dd/yyyy") + "','"), DC_Main.Rshlp.Rows[DC_Main.X]["AC_CODE"]), (object)"',0,"), (object)Math.Abs(value)), (object)",0,"), (object)Math.Abs(value2)), (object)",0,"), (object)Math.Abs(value3)), (object)",'"), (object)DC_Main.MsDataType), (object)"')"));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
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
			DC_Main.RsQry += " ORDER BY B.AC_NAME";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
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
			DataGridViewX dGV = DGV;
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
			((DataGridView)dGV).Columns.Add("", "AmountOs");
			((DataGridView)dGV).Columns[2].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns[2].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[2].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "GoldOs");
			((DataGridView)dGV).Columns[3].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[3].DefaultCellStyle.Format = "N3";
			((DataGridView)dGV).Columns.Add("", "SilverOs");
			((DataGridView)dGV).Columns[4].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)dGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)dGV).Columns[4].DefaultCellStyle.Format = "N2";
			((DataGridView)dGV).Columns.Add("", "AcName");
			((DataGridView)dGV).Columns[5].Width = (int)Math.Round(240.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Address");
			((DataGridView)dGV).Columns[6].Width = (int)Math.Round(210.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "City");
			((DataGridView)dGV).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile");
			((DataGridView)dGV).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)dGV).Columns.Add("", "Mobile2");
			((DataGridView)dGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			int num = DC_Main.Tbl.Rows.Count - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num)
			{
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[1, DC_Main.i].Value = DC_Main.i + 1;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"])) != 0.0)
				{
					((DataGridView)dGV)[2, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_AMT"]);
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"])) != 0.0)
				{
					((DataGridView)dGV)[3, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_FINE_WT"]);
				}
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"])) != 0.0)
				{
					((DataGridView)dGV)[4, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["DR_SL_FINE"]);
				}
				((DataGridView)dGV)[5, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_NAME"]);
				((DataGridView)dGV)[6, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_ADD1"]);
				((DataGridView)dGV)[7, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_CITY"]);
				((DataGridView)dGV)[8, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE"]);
				((DataGridView)dGV)[9, DC_Main.i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.i]["AC_MOBILE2"]);
				DC_Main.i++;
			}
			dGV = null;
		}
	}

	private void chkRetSend_CheckedChanged(object sender, EventArgs e)
	{
		//IL_0127: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_024b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0255: Expected O, but got Unknown
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Expected O, but got Unknown
		//IL_0287: Unknown result type (might be due to invalid IL or missing references)
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0296: Expected O, but got Unknown
		//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e0: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		checked
		{
			if (chkRetSend.Checked)
			{
				DC_Main.RsQry = "select * from RATE_MAST where CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "' AND VCH_DATE = '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "' ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (dataTable.Rows.Count > 0)
				{
					double num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_GL_RATE"]), "0.00"));
					double num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["FINE_SL_RATE"]), "0.00"));
					DC_Main.RsQry = "SELECT * FROM MSG_MAST WHERE MSG_TYPE = 'G'  ";
					DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						tMsg.Text = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(dataTable2.Rows[0]["MSG_DETL"], (object)" 999 Gold Rate = "), (object)num), (object)" And 999 Silver Rate = "), (object)num2));
						DC_Main.RsQry = "SELECT A.* FROM AC_MAST  AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.AC_MOBILE <> '' AND A.AC_GR = '20' ";
						DC_Main.RsQry += " ORDER BY  A.AC_NAME ";
						dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						if (dataTable2.Rows.Count > 0 && ((DataGridView)DGV).Rows.Count <= 0)
						{
							DataGridViewX dGV = DGV;
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
					}
					else
					{
						Interaction.MsgBox((object)"Please Creat Daily Rate Send Detail......", (MsgBoxStyle)0, (object)null);
					}
				}
				else
				{
					Interaction.MsgBox((object)"Please Insert Daily Rate in Rate Master......", (MsgBoxStyle)0, (object)null);
				}
			}
			else
			{
				((DataGridView)DGV).DataSource = null;
				((DataGridView)DGV).Columns.Clear();
				((DataGridView)DGV).Rows.Clear();
				((Control)DGV).Refresh();
			}
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
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		lblMsgLenth.Text = Conversions.ToString(Strings.Len(TxtUniCode.Text));
		if ((Strings.Len(TxtUniCode.Text) > 70) & !MsgLess)
		{
			MsgLess = true;
			Interaction.MsgBox((object)"If Message Character Grater Tehn 70 then 2 Message Balance Deduct", (MsgBoxStyle)0, (object)null);
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

	private void BtnWhatsapp_Click(object sender, EventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Expected O, but got Unknown
		try
		{
			WebBrowser val = new WebBrowser();
			if (Operators.CompareString(TxtUniCode.Text, "", false) != 0)
			{
				val.Navigate(("whatsapp://send?phone=" + DC_Main.MsCountryId + tMobileNo.Text + "&text=" + TxtUniCode.Text.Replace(" ", "+")) ?? "");
			}
			else
			{
				val.Navigate(("whatsapp://send?phone=" + DC_Main.MsCountryId + tMobileNo.Text + "&text=" + tMsg.Text.Replace(" ", "+")) ?? "");
			}
			Timer1.Start();
		}
		catch (Exception ex)
		{
			ProjectData.SetProjectError(ex);
			Exception ex2 = ex;
			Timer1.Stop();
			ProjectData.ClearProjectError();
		}
	}

	private void Timer1_Tick(object sender, EventArgs e)
	{
		checked
		{
			sec++;
			if (sec == 10)
			{
				SendKeys.Send("{ENTER}");
				Timer1.Stop();
				sec = 0;
			}
		}
	}
}
