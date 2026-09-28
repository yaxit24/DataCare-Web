using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
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

namespace DataCareNext;

[DesignerGenerated]
public class MS_USER : Form
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
	[AccessedThroughProperty("cboUserTyp")]
	private ComboBox _cboUserTyp;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tConPasword")]
	private TextBox _tConPasword;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tPasword")]
	private TextBox _tPasword;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tUserName")]
	private TextBox _tUserName;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tOldPasword")]
	private TextBox _tOldPasword;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboUser")]
	private ComboBox _cboUser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnUserRights")]
	private SimpleButton _btnUserRights;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnMenuUpdate")]
	private SimpleButton _btnMenuUpdate;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tResetPwd")]
	private TextBox _tResetPwd;

	private Control CurActCtrl;

	private double ColCon;

	private DataTable RsMast;

	private string EntryMode;

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

	internal virtual ComboBox cboUserTyp
	{
		[CompilerGenerated]
		get
		{
			return _cboUserTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboUserTyp_KeyDown);
			ComboBox val2 = _cboUserTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboUserTyp = value;
			val2 = _cboUserTyp;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tConPasword
	{
		[CompilerGenerated]
		get
		{
			return _tConPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tConPasword_KeyDown);
			CancelEventHandler cancelEventHandler = tConPasword_Validating;
			EventHandler eventHandler = tConPasword_DoubleClick;
			TextBox val2 = _tConPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_tConPasword = value;
			val2 = _tConPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual TextBox tPasword
	{
		[CompilerGenerated]
		get
		{
			return _tPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tPasword_KeyDown);
			TextBox val2 = _tPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tPasword = value;
			val2 = _tPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual TextBox tUserName
	{
		[CompilerGenerated]
		get
		{
			return _tUserName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			CancelEventHandler cancelEventHandler = tUserName_Validating;
			KeyEventHandler val = new KeyEventHandler(tUserName_KeyDown);
			EventHandler eventHandler = tUserName_LostFocus;
			TextBox val2 = _tUserName;
			if (val2 != null)
			{
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).KeyDown -= val;
				((Control)val2).LostFocus -= eventHandler;
			}
			_tUserName = value;
			val2 = _tUserName;
			if (val2 != null)
			{
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).KeyDown += val;
				((Control)val2).LostFocus += eventHandler;
			}
		}
	}

	internal virtual TextBox tOldPasword
	{
		[CompilerGenerated]
		get
		{
			return _tOldPasword;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tOldPasword_KeyDown);
			CancelEventHandler cancelEventHandler = tOldPasword_Validating;
			EventHandler eventHandler = tOldPasword_TextChanged;
			TextBox val2 = _tOldPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Validating -= cancelEventHandler;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tOldPasword = value;
			val2 = _tOldPasword;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Validating += cancelEventHandler;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual ComboBox cboUser
	{
		[CompilerGenerated]
		get
		{
			return _cboUser;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = CboUser_SelectedIndexChanged;
			ComboBox val = _cboUser;
			if (val != null)
			{
				val.SelectedIndexChanged -= eventHandler;
			}
			_cboUser = value;
			val = _cboUser;
			if (val != null)
			{
				val.SelectedIndexChanged += eventHandler;
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

	internal virtual SimpleButton btnUserRights
	{
		[CompilerGenerated]
		get
		{
			return _btnUserRights;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnUserRights_Click;
			SimpleButton val = _btnUserRights;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnUserRights = value;
			val = _btnUserRights;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV
	{
		[CompilerGenerated]
		get
		{
			return _DGV;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(DGV_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	internal virtual SimpleButton btnMenuUpdate
	{
		[CompilerGenerated]
		get
		{
			return _btnMenuUpdate;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnMenuUpdate_Click;
			SimpleButton val = _btnMenuUpdate;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnMenuUpdate = value;
			val = _btnMenuUpdate;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual TextBox tResetPwd
	{
		[CompilerGenerated]
		get
		{
			return _tResetPwd;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tResetPwd_KeyDown);
			TextBox val2 = _tResetPwd;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tResetPwd = value;
			val2 = _tResetPwd;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
			}
		}
	}

	public MS_USER()
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		((Form)this).Load += MS_USER_Load;
		((Form)this).Deactivate += MS_USER_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(MS_USER_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(MS_USER_KeyDown);
		((Form)this).Closed += MS_USER_Closed;
		((Form)this).Activated += MS_USER_Activated;
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
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Expected O, but got Unknown
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected O, but got Unknown
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Expected O, but got Unknown
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Expected O, but got Unknown
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected O, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected O, but got Unknown
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Expected O, but got Unknown
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected O, but got Unknown
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Expected O, but got Unknown
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Expected O, but got Unknown
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected O, but got Unknown
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Expected O, but got Unknown
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected O, but got Unknown
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_0120: Expected O, but got Unknown
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Expected O, but got Unknown
		//IL_012e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0138: Expected O, but got Unknown
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0144: Expected O, but got Unknown
		//IL_0146: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0152: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_0272: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d5: Expected O, but got Unknown
		//IL_0338: Unknown result type (might be due to invalid IL or missing references)
		//IL_0342: Expected O, but got Unknown
		//IL_03ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Expected O, but got Unknown
		//IL_0501: Unknown result type (might be due to invalid IL or missing references)
		//IL_050b: Expected O, but got Unknown
		//IL_0628: Unknown result type (might be due to invalid IL or missing references)
		//IL_0632: Expected O, but got Unknown
		//IL_0695: Unknown result type (might be due to invalid IL or missing references)
		//IL_069f: Expected O, but got Unknown
		//IL_0748: Unknown result type (might be due to invalid IL or missing references)
		//IL_0752: Expected O, but got Unknown
		//IL_07b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07bf: Expected O, but got Unknown
		//IL_0868: Unknown result type (might be due to invalid IL or missing references)
		//IL_0872: Expected O, but got Unknown
		//IL_08d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_08df: Expected O, but got Unknown
		//IL_09ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c4: Expected O, but got Unknown
		//IL_0a32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0b08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b12: Expected O, but got Unknown
		//IL_0ba3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bad: Expected O, but got Unknown
		//IL_0c3f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c49: Expected O, but got Unknown
		//IL_0cdb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce5: Expected O, but got Unknown
		//IL_0d69: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d73: Expected O, but got Unknown
		//IL_0e05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0f: Expected O, but got Unknown
		//IL_0ec0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0eca: Expected O, but got Unknown
		//IL_0f7b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f85: Expected O, but got Unknown
		//IL_1036: Unknown result type (might be due to invalid IL or missing references)
		//IL_1040: Expected O, but got Unknown
		//IL_10f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_10fb: Expected O, but got Unknown
		//IL_11c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d2: Expected O, but got Unknown
		//IL_1253: Unknown result type (might be due to invalid IL or missing references)
		//IL_125d: Expected O, but got Unknown
		//IL_132b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1335: Expected O, but got Unknown
		//IL_140d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1417: Expected O, but got Unknown
		//IL_14b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Expected O, but got Unknown
		//IL_15f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ff: Expected O, but got Unknown
		//IL_1694: Unknown result type (might be due to invalid IL or missing references)
		//IL_169e: Expected O, but got Unknown
		//IL_171c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1726: Expected O, but got Unknown
		//IL_17fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_1805: Expected O, but got Unknown
		//IL_186e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1878: Expected O, but got Unknown
		//IL_192b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1935: Expected O, but got Unknown
		//IL_19f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a00: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MS_USER));
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
		btnMenuUpdate = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		cboUserTyp = new ComboBox();
		tConPasword = new TextBox();
		tPasword = new TextBox();
		tUserName = new TextBox();
		tOldPasword = new TextBox();
		Label5 = new Label();
		Label4 = new Label();
		Label3 = new Label();
		Label1 = new Label();
		Label2 = new Label();
		cboUser = new ComboBox();
		Label6 = new Label();
		btnUserRights = new SimpleButton();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		Label7 = new Label();
		tResetPwd = new TextBox();
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
		((Control)PnlBotam).Controls.Add((Control)(object)btnMenuUpdate);
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
		((BaseStyleControl)btnMenuUpdate).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnMenuUpdate).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnMenuUpdate).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnMenuUpdate).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnMenuUpdate.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnMenuUpdate.ImageOptions.SvgImage");
		((Control)btnMenuUpdate).Location = new Point(670, 3);
		((BaseControl)btnMenuUpdate).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnMenuUpdate).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnMenuUpdate).Name = "btnMenuUpdate";
		((Control)btnMenuUpdate).Size = new Size(151, 37);
		((Control)btnMenuUpdate).TabIndex = 11;
		btnMenuUpdate.Text = "&Menu Update";
		((BaseButton)btnMenuUpdate).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(636, 3);
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
		lblBook.Text = "User Create";
		lblBook.TextAlign = (ContentAlignment)32;
		cboUserTyp.AutoCompleteMode = (AutoCompleteMode)2;
		cboUserTyp.AutoCompleteSource = (AutoCompleteSource)256;
		cboUserTyp.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboUserTyp).Font = new Font("Arial", 9f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((ListControl)cboUserTyp).FormattingEnabled = true;
		((Control)cboUserTyp).Location = new Point(915, 338);
		cboUserTyp.MaxLength = 20;
		((Control)cboUserTyp).Name = "cboUserTyp";
		((Control)cboUserTyp).Size = new Size(184, 23);
		((Control)cboUserTyp).TabIndex = 4;
		((TextBoxBase)tConPasword).BackColor = Color.White;
		((Control)tConPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tConPasword).Location = new Point(915, 301);
		((TextBoxBase)tConPasword).MaxLength = 15;
		((Control)tConPasword).Name = "tConPasword";
		tConPasword.PasswordChar = '*';
		((Control)tConPasword).Size = new Size(184, 22);
		((Control)tConPasword).TabIndex = 3;
		((TextBoxBase)tPasword).BackColor = Color.White;
		((Control)tPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tPasword).Location = new Point(915, 264);
		((TextBoxBase)tPasword).MaxLength = 15;
		((Control)tPasword).Name = "tPasword";
		tPasword.PasswordChar = '*';
		((Control)tPasword).Size = new Size(184, 22);
		((Control)tPasword).TabIndex = 2;
		((TextBoxBase)tUserName).BackColor = Color.White;
		((Control)tUserName).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tUserName).Location = new Point(915, 193);
		((TextBoxBase)tUserName).MaxLength = 15;
		((Control)tUserName).Name = "tUserName";
		((Control)tUserName).Size = new Size(184, 22);
		((Control)tUserName).TabIndex = 0;
		((TextBoxBase)tOldPasword).BackColor = Color.White;
		((Control)tOldPasword).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tOldPasword).Location = new Point(915, 228);
		((TextBoxBase)tOldPasword).MaxLength = 15;
		((Control)tOldPasword).Name = "tOldPasword";
		tOldPasword.PasswordChar = '*';
		((Control)tOldPasword).Size = new Size(184, 22);
		((Control)tOldPasword).TabIndex = 1;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(779, 338);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(124, 20);
		((Control)Label5).TabIndex = 19;
		Label5.Text = "User Type";
		Label5.TextAlign = (ContentAlignment)16;
		((Control)Label4).BackColor = Color.Transparent;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(779, 301);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(124, 20);
		((Control)Label4).TabIndex = 18;
		Label4.Text = "Confirm Password";
		Label4.TextAlign = (ContentAlignment)16;
		((Control)Label3).BackColor = Color.Transparent;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(779, 264);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(124, 20);
		((Control)Label3).TabIndex = 17;
		Label3.Text = "New Password";
		Label3.TextAlign = (ContentAlignment)16;
		((Control)Label1).BackColor = Color.Transparent;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(779, 228);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(124, 20);
		((Control)Label1).TabIndex = 16;
		Label1.Text = "Old Password";
		Label1.TextAlign = (ContentAlignment)16;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(779, 193);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(124, 20);
		((Control)Label2).TabIndex = 15;
		Label2.Text = "Create New User";
		Label2.TextAlign = (ContentAlignment)16;
		cboUser.BackColor = Color.FromArgb(255, 224, 192);
		cboUser.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboUser).Font = new Font("Bahnschrift SemiBold", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((ListControl)cboUser).FormattingEnabled = true;
		((Control)cboUser).Location = new Point(120, 48);
		((Control)cboUser).Name = "cboUser";
		((Control)cboUser).Size = new Size(184, 26);
		((Control)cboUser).TabIndex = 1132;
		((Control)Label6).BackColor = Color.Transparent;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(16, 48);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(98, 20);
		((Control)Label6).TabIndex = 1133;
		Label6.Text = "User Name";
		Label6.TextAlign = (ContentAlignment)16;
		((BaseStyleControl)btnUserRights).Appearance.BackColor = Color.AntiqueWhite;
		((BaseStyleControl)btnUserRights).Appearance.BorderColor = Color.SandyBrown;
		((BaseStyleControl)btnUserRights).Appearance.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnUserRights).Appearance.ForeColor = Color.Maroon;
		((BaseStyleControl)btnUserRights).Appearance.GradientMode = (LinearGradientMode)1;
		((BaseStyleControl)btnUserRights).Appearance.Options.UseBackColor = true;
		((BaseStyleControl)btnUserRights).Appearance.Options.UseBorderColor = true;
		((BaseStyleControl)btnUserRights).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnUserRights).Appearance.Options.UseForeColor = true;
		((BaseButton)btnUserRights).AppearanceHovered.BackColor = Color.FromArgb(255, 192, 128);
		((BaseButton)btnUserRights).AppearanceHovered.BorderColor = Color.SandyBrown;
		((BaseButton)btnUserRights).AppearanceHovered.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUserRights).AppearanceHovered.GradientMode = (LinearGradientMode)1;
		((BaseButton)btnUserRights).AppearanceHovered.Options.UseBackColor = true;
		((BaseButton)btnUserRights).AppearanceHovered.Options.UseBorderColor = true;
		((BaseButton)btnUserRights).AppearanceHovered.Options.UseFont = true;
		((BaseButton)btnUserRights).AppearancePressed.BackColor = Color.LightGoldenrodYellow;
		((BaseButton)btnUserRights).AppearancePressed.BorderColor = Color.Moccasin;
		((BaseButton)btnUserRights).AppearancePressed.Font = new Font("Arial", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((BaseButton)btnUserRights).AppearancePressed.Options.UseBackColor = true;
		((BaseButton)btnUserRights).AppearancePressed.Options.UseBorderColor = true;
		((BaseButton)btnUserRights).AppearancePressed.Options.UseFont = true;
		((Control)btnUserRights).Location = new Point(249, 521);
		((BaseControl)btnUserRights).LookAndFeel.SkinName = "Office 2019 Colorful";
		((BaseControl)btnUserRights).LookAndFeel.Style = (LookAndFeelStyle)0;
		((BaseControl)btnUserRights).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnUserRights).Name = "btnUserRights";
		((Control)btnUserRights).Size = new Size(217, 32);
		((Control)btnUserRights).TabIndex = 1154;
		btnUserRights.Text = "Update User Right";
		((BaseControl)btnUserRights).ToolTip = "Party Help";
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
		((Control)DGV).Location = new Point(23, 83);
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
		((Control)DGV).Size = new Size(687, 428);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1155;
		((Control)Label7).BackColor = Color.Transparent;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 12f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(779, 383);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(124, 20);
		((Control)Label7).TabIndex = 1157;
		Label7.Text = "ReSet Pwd";
		Label7.TextAlign = (ContentAlignment)16;
		((Control)Label7).Visible = false;
		((TextBoxBase)tResetPwd).BackColor = Color.White;
		((Control)tResetPwd).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tResetPwd).Location = new Point(915, 383);
		((TextBoxBase)tResetPwd).MaxLength = 10;
		((Control)tResetPwd).Name = "tResetPwd";
		tResetPwd.PasswordChar = '*';
		((Control)tResetPwd).Size = new Size(184, 22);
		((Control)tResetPwd).TabIndex = 1156;
		((Control)tResetPwd).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)tResetPwd);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)btnUserRights);
		((Control)this).Controls.Add((Control)(object)cboUser);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)cboUserTyp);
		((Control)this).Controls.Add((Control)(object)tConPasword);
		((Control)this).Controls.Add((Control)(object)tPasword);
		((Control)this).Controls.Add((Control)(object)tUserName);
		((Control)this).Controls.Add((Control)(object)tOldPasword);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "MS_USER";
		((Form)this).Text = "User Create";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void MS_USER_Load(object sender, EventArgs e)
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_08b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_08bb: Expected O, but got Unknown
		//IL_092b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0930: Unknown result type (might be due to invalid IL or missing references)
		//IL_093a: Expected O, but got Unknown
		//IL_09c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d1: Expected O, but got Unknown
		//IL_0a43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4e: Expected O, but got Unknown
		//IL_0b00: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b0f: Expected O, but got Unknown
		//IL_0b2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3d: Expected O, but got Unknown
		//IL_0b5c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b61: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6b: Expected O, but got Unknown
		if (Operators.CompareString(DC_Main.MCo_User, "ABC", false) == 0)
		{
			DC_Main.RsQry = "Select * From USER_SET WHERE USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		}
		else
		{
			DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		}
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
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj8 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj9 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				AppearanceObject appearance = ((BaseStyleControl)btnUserRights).Appearance;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				appearance.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				ComboBox obj12 = cboUser;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				ComboBox obj14 = cboUserTyp;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				obj14.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj16 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj17 = lblBook;
				object? obj18 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj17).ForeColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj19 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV2).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				AppearanceObject appearance2 = ((BaseStyleControl)btnUserRights).Appearance;
				object? obj22 = colorConverter.ConvertFromString("Cornsilk");
				appearance2.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				ComboBox obj23 = cboUser;
				object? obj24 = colorConverter.ConvertFromString("Cornsilk");
				obj23.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				ComboBox obj25 = cboUserTyp;
				object? obj26 = colorConverter.ConvertFromString("Cornsilk");
				obj25.BackColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tUserName).Font.Size * (1.0 + num2));
				Font font = ((Control)tUserName).Font;
				try
				{
					foreach (Control control3 in ((Control)this).Controls)
					{
						Control val3 = control3;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
						NewLateBinding.LateSet(objectValue2, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV).Font.Style);
					((DataGridView)DGV).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
			{
				((Control)DGV).Visible = false;
				((Control)btnUserRights).Visible = false;
				((Control)Label6).Left = ((Control)Label2).Left;
				((Control)cboUser).Left = ((Control)tUserName).Left;
			}
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '01' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			cboUserTyp.Items.Add((object)"User");
			cboUserTyp.Items.Add((object)"Admin");
			cboUserTyp.SelectedIndex = 0;
			EntryMode = "A";
			AddCboItem();
			CurActCtrl = (Control)(object)tUserName;
		}
	}

	private void AddCboItem()
	{
		cboUser.Items.Clear();
		DC_Main.RsQry = "SELECT LOGIN_NAME FROM LOGIN_MAST WHERE CO_CODE = '01' GROUP BY LOGIN_NAME ORDER BY LOGIN_NAME ";
		DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		cboUser.Items.Clear();
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboUser.Items.Add((object)"");
				int num = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num)
				{
					cboUser.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["LOGIN_NAME"], (object)""));
					DC_Main.X++;
				}
				cboUser.SelectedIndex = 0;
			}
			else
			{
				cboUser.Items.Add((object)"");
			}
		}
	}

	private void DISPLAY_DATA()
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_053a: Expected O, but got Unknown
		//IL_065a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0661: Expected O, but got Unknown
		//IL_067d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0684: Expected O, but got Unknown
		//IL_06a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a7: Expected O, but got Unknown
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_056c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_057b: Expected O, but got Unknown
		//IL_0591: Unknown result type (might be due to invalid IL or missing references)
		//IL_0596: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a0: Expected O, but got Unknown
		//IL_05b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c5: Expected O, but got Unknown
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_088c: Expected O, but got Unknown
		ColorConverter colorConverter = new ColorConverter();
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
		if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE = 'L' ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else if (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else if (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else if (Operators.CompareString(DC_Main.MsSoftType, "U", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else if (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U','P') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else if (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0)
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U','P','A') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		else
		{
			DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.USER_NAME = '" + cboUser.Text + "' ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
		}
		DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MsSoftType, "L", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE = 'L' ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "B", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "S", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "U", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "P", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U','P') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else if (Operators.CompareString(DC_Main.MsSoftType, "A", false) == 0)
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' AND B.SM_TYPE IN ('L','B','S','U','P','A') ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			else
			{
				DC_Main.RsQry = "SELECT A.* FROM USER_SET AS A LEFT JOIN MENU_DATA AS B ON A.MAIN_SRNO = B.MAIN_SRNO AND A.SUB_SRNO = B.SM_MAIN_CODE WHERE A.LC_CODE = '00' AND A.USER_NAME = '" + cboUser.Text + "' ORDER BY A.MAIN_SRNO,A.SUB_SRNO ";
			}
			DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		}
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
				((DataGridView)dGV).Columns.Add("", "SrNo");
				((DataGridView)dGV).Columns.Add("Main_SrNo", "");
				((DataGridView)dGV).Columns.Add("SrNo", "");
				((DataGridView)dGV).Columns.Add("Main_Menu", "Main Menu");
				((DataGridView)dGV).Columns.Add("Sub_Menu", "Sub Menu");
				DataGridViewCheckBoxColumn val2 = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val2);
				((DataGridViewColumn)val2).Name = "View";
				DataGridViewCheckBoxColumn val3 = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val3);
				((DataGridViewColumn)val3).Name = "Edit";
				DataGridViewCheckBoxColumn val4 = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val4);
				((DataGridViewColumn)val4).Name = "Delete";
				DataGridViewCheckBoxColumn val5 = new DataGridViewCheckBoxColumn();
				((DataGridView)dGV).Columns.Add((DataGridViewColumn)(object)val5);
				((DataGridViewColumn)val5).Name = "Print";
				((DataGridView)dGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)dGV).Columns[1].Width = 0;
				((DataGridView)dGV).Columns[1].Visible = false;
				((DataGridView)dGV).Columns[2].Width = 0;
				((DataGridView)dGV).Columns[2].Visible = false;
				((DataGridView)dGV).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)dGV).Columns[4].Width = (int)Math.Round(180.0 * ColCon);
				((DataGridView)dGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns[6].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)dGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				int num = DC_Main.Tbl.Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, i].Value = i + 1;
					((DataGridView)dGV)[1, i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["MAIN_SRNO"]);
					((DataGridView)dGV)[2, i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["SUB_SRNO"]);
					((DataGridView)dGV)[3, i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["MAIN_MENU"]);
					((DataGridView)dGV)[4, i].Value = RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[i]["SUB_MENU"]);
					if (Operators.CompareString(((DataGridView)dGV)[4, i].Value.ToString(), " ", false) == 0)
					{
						((DataGridView)dGV).Rows[i].Cells[3].Style.ForeColor = Color.DarkBlue;
						((DataGridView)dGV).Rows[i].Cells[0].Style.ForeColor = Color.DarkBlue;
						DataGridViewCellStyle style = ((DataGridView)dGV).Rows[i].Cells[0].Style;
						object? obj = colorConverter.ConvertFromString("ControlLight");
						style.BackColor = ((obj != null) ? ((Color)obj) : default(Color));
						DataGridViewCellStyle style2 = ((DataGridView)dGV).Rows[i].Cells[1].Style;
						object? obj2 = colorConverter.ConvertFromString("ControlLight");
						style2.BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
						DataGridViewCellStyle style3 = ((DataGridView)dGV).Rows[i].Cells[2].Style;
						object? obj3 = colorConverter.ConvertFromString("ControlLight");
						style3.BackColor = ((obj3 != null) ? ((Color)obj3) : default(Color));
						DataGridViewCellStyle style4 = ((DataGridView)dGV).Rows[i].Cells[3].Style;
						object? obj4 = colorConverter.ConvertFromString("ControlLight");
						style4.BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
						DataGridViewCellStyle style5 = ((DataGridView)dGV).Rows[i].Cells[4].Style;
						object? obj5 = colorConverter.ConvertFromString("ControlLight");
						style5.BackColor = ((obj5 != null) ? ((Color)obj5) : default(Color));
						DataGridViewCellStyle style6 = ((DataGridView)dGV).Rows[i].Cells[5].Style;
						object? obj6 = colorConverter.ConvertFromString("ControlLight");
						style6.BackColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
						DataGridViewCellStyle style7 = ((DataGridView)dGV).Rows[i].Cells[6].Style;
						object? obj7 = colorConverter.ConvertFromString("ControlLight");
						style7.BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
						DataGridViewCellStyle style8 = ((DataGridView)dGV).Rows[i].Cells[7].Style;
						object? obj8 = colorConverter.ConvertFromString("ControlLight");
						style8.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
						DataGridViewCellStyle style9 = ((DataGridView)dGV).Rows[i].Cells[8].Style;
						object? obj9 = colorConverter.ConvertFromString("ControlLight");
						style9.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
						((DataGridView)dGV)[5, i].ReadOnly = true;
						((DataGridView)dGV)[6, i].ReadOnly = true;
						((DataGridView)dGV)[7, i].ReadOnly = true;
						((DataGridView)dGV)[8, i].ReadOnly = true;
					}
					else
					{
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[i]["FRM_VIEW"], (object)"Y", false))
						{
							((DataGridView)dGV)[5, i].Value = true;
						}
						else
						{
							((DataGridView)dGV)[5, i].Value = false;
						}
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[i]["FRM_EDIT"], (object)"Y", false))
						{
							((DataGridView)dGV)[6, i].Value = true;
						}
						else
						{
							((DataGridView)dGV)[6, i].Value = false;
						}
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[i]["FRM_DELETE"], (object)"Y", false))
						{
							((DataGridView)dGV)[7, i].Value = true;
						}
						else
						{
							((DataGridView)dGV)[7, i].Value = false;
						}
						if (Operators.ConditionalCompareObjectEqual(DC_Main.Tbl.Rows[i]["FRM_PRINT"], (object)"Y", false))
						{
							((DataGridView)dGV)[8, i].Value = true;
						}
						else
						{
							((DataGridView)dGV)[8, i].Value = false;
						}
					}
				}
				dGV = null;
			}
			EntryMode = "E";
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

	private void MS_USER_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void MS_USER_KeyPress(object sender, KeyPressEventArgs e)
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

	private void MS_USER_KeyDown(object sender, KeyEventArgs e)
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
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0334: Unknown result type (might be due to invalid IL or missing references)
		//IL_0394: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if ((Operators.CompareString(UserEdit, "Y", false) != 0) & (Operators.CompareString(EntryMode, "E", false) == 0))
					{
						goto IL_0031;
					}
					goto IL_0047;
				case 1091:
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
							goto IL_0031;
						case 4:
						case 5:
							goto IL_0047;
						case 6:
							goto IL_0050;
						case 7:
							goto IL_0071;
						case 8:
							goto IL_0084;
						case 11:
							goto IL_009e;
						case 12:
							goto IL_00c0;
						case 13:
							goto IL_00ce;
						case 14:
							goto IL_0144;
						case 15:
							goto IL_0152;
						case 16:
							goto IL_0174;
						case 17:
							goto IL_0182;
						case 18:
							goto IL_01f8;
						case 19:
							goto IL_0206;
						case 20:
							goto IL_0226;
						case 21:
							goto IL_0248;
						case 22:
							goto IL_0256;
						case 23:
							goto IL_0278;
						case 24:
							goto IL_0286;
						case 25:
							goto IL_02c7;
						case 26:
							goto IL_02d5;
						case 27:
							goto IL_0316;
						case 28:
						case 29:
							goto IL_0326;
						case 30:
							goto IL_033a;
						case 31:
							goto IL_0344;
						case 32:
							goto IL_034e;
						case 33:
							goto end_IL_0001_2;
						case 36:
							num2 = 36;
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001_3;
						default:
							goto end_IL_0001;
						case 3:
						case 9:
						case 10:
						case 34:
						case 35:
						case 37:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_033a:
					num2 = 30;
					CLEAR_DATA();
					goto IL_0344;
					IL_0344:
					num2 = 31;
					AddCboItem();
					goto IL_034e;
					IL_0326:
					num2 = 29;
					Interaction.MsgBox((object)"User Are Created.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					goto IL_033a;
					IL_034e:
					num2 = 32;
					DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '01' ORDER BY LOGIN_NAME ";
					break;
					IL_0031:
					num2 = 2;
					Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
					goto end_IL_0001_3;
					IL_0047:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0050;
					IL_0050:
					num2 = 6;
					if (Operators.CompareString(tUserName.Text, "", false) == 0)
					{
						goto IL_0071;
					}
					goto IL_009e;
					IL_0071:
					num2 = 7;
					Interaction.MsgBox((object)"Please Enter User Name.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					goto IL_0084;
					IL_0084:
					num2 = 8;
					((Control)tUserName).Focus();
					goto end_IL_0001_3;
					IL_009e:
					num2 = 11;
					DC_Main.RsQry = "DELETE FROM LOGIN_MAST WHERE CO_CODE = '01' AND  LOGIN_NAME = '" + tUserName.Text + "'";
					goto IL_00c0;
					IL_00c0:
					num2 = 12;
					DC_Main.ExeQuteMc(DC_Main.RsQry);
					goto IL_00ce;
					IL_00ce:
					num2 = 13;
					DC_Main.RsQry = "INSERT INTO LOGIN_MAST (CO_CODE,LOGIN_NAME,LOGIN_PWD,LOGIN_CATG,MAIN_USER) VALUES  ('01','" + tUserName.Text + "','" + tPasword.Text + "','" + Strings.Mid(cboUserTyp.Text, 1, 1) + "','" + MainUser + "')";
					goto IL_0144;
					IL_0144:
					num2 = 14;
					DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					goto IL_0152;
					IL_0152:
					num2 = 15;
					DC_Main.RsQry = "DELETE FROM LOGIN_MAST WHERE CO_CODE = '01' AND  LOGIN_NAME = '" + tUserName.Text + "'";
					goto IL_0174;
					IL_0174:
					num2 = 16;
					DC_Main.ExeQuteDc(DC_Main.RsQry);
					goto IL_0182;
					IL_0182:
					num2 = 17;
					DC_Main.RsQry = "INSERT INTO LOGIN_MAST (CO_CODE,LOGIN_NAME,LOGIN_PWD,LOGIN_CATG,MAIN_USER) VALUES  ('01','" + tUserName.Text + "','" + tPasword.Text + "','" + Strings.Mid(cboUserTyp.Text, 1, 1) + "','" + MainUser + "')";
					goto IL_01f8;
					IL_01f8:
					num2 = 18;
					DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					goto IL_0206;
					IL_0206:
					num2 = 19;
					if (Operators.CompareString(EntryMode, "A", false) == 0)
					{
						goto IL_0226;
					}
					goto IL_0326;
					IL_0226:
					num2 = 20;
					DC_Main.RsQry = "DELETE FROM USER_SET WHERE  CO_CODE = '01' AND LC_CODE = '00' AND  USER_NAME = '" + tUserName.Text + "'";
					goto IL_0248;
					IL_0248:
					num2 = 21;
					DC_Main.ExeQuteMc(DC_Main.RsQry);
					goto IL_0256;
					IL_0256:
					num2 = 22;
					DC_Main.RsQry = "INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','00',MAIN_SRNO,SM_MAIN_CODE,'" + tUserName.Text + "',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA ";
					goto IL_0278;
					IL_0278:
					num2 = 23;
					DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					goto IL_0286;
					IL_0286:
					num2 = 24;
					DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + tUserName.Text + "'";
					goto IL_02c7;
					IL_02c7:
					num2 = 25;
					DC_Main.ExeQuteMc(DC_Main.RsQry);
					goto IL_02d5;
					IL_02d5:
					num2 = 26;
					DC_Main.RsQry = "INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','" + DC_Main.MLc_code + "',MAIN_SRNO,SM_MAIN_CODE,'" + tUserName.Text + "',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA ";
					goto IL_0316;
					IL_0316:
					num2 = 27;
					DC_Main.OpenRecordSetMc(DC_Main.RsQry);
					goto IL_0326;
					end_IL_0001_2:
					break;
				}
				num2 = 33;
				RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1091;
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

	private void BtnDelete_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserDelete, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(tUserName.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Select User For Delete.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
		}
		else if ((int)Interaction.MsgBox((object)"Are You Sure To Delete This User now?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle) == 6)
		{
			DC_Main.RsQry = "SELECT * FROM  LOGIN_MAST WHERE CO_CODE = '01' AND LOGIN_NAME = '" + tUserName.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			DC_Main.ExeQuteMc("DELETE FROM LOGIN_MAST WHERE CO_CODE = '01' AND  LOGIN_NAME = '" + tUserName.Text + "'");
			DC_Main.ExeQuteMc("DELETE FROM USER_SET WHERE CO_CODE = '01' AND  USER_NAME = '" + tUserName.Text + "'");
			Interaction.MsgBox((object)"Delete Success.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			CLEAR_DATA();
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST WHERE CO_CODE = '01' ORDER BY LOGIN_NAME ";
			RsMast = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
		AddCboItem();
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).Columns.Clear();
		((DataGridView)DGV).Rows.Clear();
		((Control)DGV).Refresh();
		cboUser.SelectedIndex = 0;
		cboUserTyp.SelectedIndex = 0;
		EntryMode = "A";
		((Control)tUserName).Focus();
	}

	private void MS_USER_Closed(object sender, EventArgs e)
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

	private void tUserName_Validating(object sender, CancelEventArgs e)
	{
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " LOGIN_NAME = '" + tUserName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.CompareString(EntryMode, "E", false) != 0 && Operators.ConditionalCompareObjectEqual(dataView[0]["LOGIN_NAME"], (object)tUserName.Text, false))
			{
				Interaction.MsgBox((object)"This User Name already Exist.Please Change User Name...", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
				cancel = true;
				((TextBoxBase)tUserName).SelectAll();
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void tOldPasword_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112 && Operators.CompareString(DC_Main.MCo_UserType, "A", false) == 0)
		{
			tOldPasword.PasswordChar = '\0';
			DC_Main.RsQry = "SELECT * FROM LOGIN_MAST where LOGIN_NAME='" + tUserName.Text + "' ";
			DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count > 0)
			{
				tOldPasword.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["LOGIN_PWD"], (object)""));
			}
		}
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tPasword_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tConPasword_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tUserName_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13 && Operators.CompareString(tUserName.Text, "", false) != 0)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tConPasword_Validating(object sender, CancelEventArgs e)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		if (Operators.CompareString(tPasword.Text, tConPasword.Text, false) != 0)
		{
			Interaction.MsgBox((object)"Password Not Match", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
			tConPasword.Text = "";
			((Control)tConPasword).Focus();
		}
		else
		{
			cancel = false;
			e.Cancel = cancel;
		}
	}

	private void tOldPasword_Validating(object sender, CancelEventArgs e)
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		bool cancel = e.Cancel;
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " LOGIN_NAME = '" + tUserName.Text + "'";
		if (dataView.Count > 0)
		{
			if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LOGIN_PWD"], (object)"", false))
			{
				if (Operators.CompareString(tOldPasword.Text, "", false) == 0)
				{
					Interaction.MsgBox((object)"Please Insert Old Password", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					((Control)tOldPasword).Focus();
					return;
				}
				if (Operators.ConditionalCompareObjectNotEqual(dataView[0]["LOGIN_PWD"], (object)tOldPasword.Text, false))
				{
					Interaction.MsgBox((object)"Old Password Doesn't Match", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					((Control)tOldPasword).Focus();
					((TextBoxBase)tOldPasword).SelectAll();
					return;
				}
				cancel = false;
			}
		}
		else
		{
			cancel = false;
		}
		e.Cancel = cancel;
	}

	private void cboUserTyp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnUserRights_Click(object sender, EventArgs e)
	{
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Expected O, but got Unknown
		//IL_03c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Expected O, but got Unknown
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		IEnumerator enumerator = default(IEnumerator);
		DataGridViewRow val2 = default(DataGridViewRow);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				SqlCommand val;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (Operators.CompareString(cboUser.Text, "", false) == 0)
					{
						goto IL_0021;
					}
					goto IL_004e;
				case 1114:
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
							goto IL_0021;
						case 3:
							goto IL_0034;
						case 6:
							goto IL_004e;
						case 7:
							goto IL_0057;
						case 8:
							goto IL_0097;
						case 9:
							goto IL_00a4;
						case 10:
							goto IL_00cd;
						case 11:
							goto IL_0387;
						case 12:
							goto IL_039a;
						case 13:
							goto IL_03b3;
						case 14:
							goto end_IL_0001_2;
						case 16:
							num2 = 16;
							Interaction.MsgBox((object)("Error Found: " + Information.Err().Description + "\rClick Ok to Exit."), (MsgBoxStyle)48, (object)DC_Main.MsgTitle);
							goto end_IL_0001_3;
						default:
							goto end_IL_0001;
						case 4:
						case 5:
						case 15:
						case 17:
						case 18:
							goto end_IL_0001_3;
						}
						goto default;
					}
					IL_0387:
					num2 = 11;
					goto IL_038a;
					IL_03b3:
					num2 = 13;
					Interaction.MsgBox((object)"Data Are Update.", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					break;
					IL_039a:
					num2 = 12;
					if (enumerator is IDisposable)
					{
						(enumerator as IDisposable).Dispose();
					}
					goto IL_03b3;
					IL_00cd:
					num2 = 10;
					val = new SqlCommand("INSERT INTO USER_SET(CO_CODE,LC_CODE,MAIN_SRNO,SUB_SRNO,USER_NAME,MAIN_MENU,SUB_MENU,FRM_VIEW,FRM_EDIT,FRM_DELETE,FRM_PRINT) VALUES(@CO_CODE,@LC_CODE,@MAIN_SRNO,@SUB_SRNO,@USER_NAME,@MAIN_MENU,@SUB_MENU,@FRM_VIEW,@FRM_EDIT,@FRM_DELETE,@FRM_PRINT)", DC_Main.Mc);
					try
					{
						val.Parameters.AddWithValue("@CO_CODE", (object)"01");
						val.Parameters.AddWithValue("@LC_CODE", (object)DC_Main.MLc_code);
						val.Parameters.AddWithValue("@MAIN_SRNO", RuntimeHelpers.GetObjectValue(val2.Cells["Main_Srno"].Value));
						val.Parameters.AddWithValue("@SUB_SRNO", RuntimeHelpers.GetObjectValue(val2.Cells["Srno"].Value));
						val.Parameters.AddWithValue("@USER_NAME", (object)cboUser.Text);
						val.Parameters.AddWithValue("@MAIN_MENU", RuntimeHelpers.GetObjectValue(val2.Cells["Main_Menu"].Value));
						val.Parameters.AddWithValue("@SUB_MENU", RuntimeHelpers.GetObjectValue(val2.Cells["Sub_Menu"].Value));
						if (Operators.ConditionalCompareObjectEqual(val2.Cells["View"].Value, (object)true, false))
						{
							val.Parameters.AddWithValue("@FRM_VIEW", (object)"Y");
						}
						else
						{
							val.Parameters.AddWithValue("@FRM_VIEW", (object)"N");
						}
						if (Operators.ConditionalCompareObjectEqual(val2.Cells["Edit"].Value, (object)true, false))
						{
							val.Parameters.AddWithValue("@FRM_EDIT", (object)"Y");
						}
						else
						{
							val.Parameters.AddWithValue("@FRM_EDIT", (object)"N");
						}
						if (Operators.ConditionalCompareObjectEqual(val2.Cells["Delete"].Value, (object)true, false))
						{
							val.Parameters.AddWithValue("@FRM_DELETE", (object)"Y");
						}
						else
						{
							val.Parameters.AddWithValue("@FRM_DELETE", (object)"N");
						}
						if (Operators.ConditionalCompareObjectEqual(val2.Cells["Print"].Value, (object)true, false))
						{
							val.Parameters.AddWithValue("@FRM_PRINT", (object)"Y");
						}
						else
						{
							val.Parameters.AddWithValue("@FRM_PRINT", (object)"N");
						}
						DC_Main.Mc.Open();
						val.Connection = DC_Main.Mc;
						val.ExecuteNonQuery();
						DC_Main.Mc.Close();
					}
					finally
					{
						((IDisposable)val)?.Dispose();
					}
					goto IL_0387;
					IL_0021:
					num2 = 2;
					Interaction.MsgBox((object)"User Name Is Not Selected,Please Select User Name First And Try Again..", (MsgBoxStyle)0, (object)DC_Main.MsgTitle);
					goto IL_0034;
					IL_0034:
					num2 = 3;
					((Control)cboUser).Focus();
					goto end_IL_0001_3;
					IL_004e:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0057;
					IL_0057:
					num2 = 7;
					DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '" + DC_Main.MLc_code + "' AND USER_NAME = '" + cboUser.Text + "'";
					goto IL_0097;
					IL_0097:
					num2 = 8;
					DC_Main.ExeQuteMc(DC_Main.RsQry);
					goto IL_00a4;
					IL_00a4:
					num2 = 9;
					enumerator = ((IEnumerable)((DataGridView)DGV).Rows).GetEnumerator();
					goto IL_038a;
					IL_038a:
					if (enumerator.MoveNext())
					{
						val2 = (DataGridViewRow)enumerator.Current;
						goto IL_00cd;
					}
					goto IL_039a;
					end_IL_0001_2:
					break;
				}
				num2 = 14;
				CLEAR_DATA();
				break;
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 1114;
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

	private void CboUser_SelectedIndexChanged(object sender, EventArgs e)
	{
		DISPLAY_DATA();
	}

	private void tUserName_LostFocus(object sender, EventArgs e)
	{
		DataView dataView = new DataView(RsMast);
		dataView.RowFilter = " LOGIN_NAME = '" + tUserName.Text + "'";
		if (dataView.Count > 0)
		{
			EntryMode = "E";
			if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(dataView[0]["LOGIN_CATG"], (object)""), (object)"A", false))
			{
				cboUserTyp.SelectedIndex = 1;
			}
			else
			{
				cboUserTyp.SelectedIndex = 0;
			}
		}
		else
		{
			EntryMode = "A";
		}
	}

	private void MS_USER_Activated(object sender, EventArgs e)
	{
	}

	private void btnMenuUpdate_Click(object sender, EventArgs e)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Invalid comparison between Unknown and I4
		//IL_178c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fba: Unknown result type (might be due to invalid IL or missing references)
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		int num5 = default(int);
		DataTable dataTable = default(DataTable);
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
						if (Operators.CompareString(UserDelete, "Y", false) != 0)
						{
							goto IL_001c;
						}
						goto IL_0032;
					case 10047:
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
								goto IL_001c;
							case 4:
							case 5:
								goto IL_0032;
							case 6:
								goto IL_0050;
							case 7:
								goto IL_005c;
							case 8:
								goto IL_006d;
							case 9:
								goto IL_0088;
							case 11:
								goto IL_009a;
							case 10:
							case 12:
							case 13:
								goto IL_00a9;
							case 14:
								goto IL_00b7;
							case 15:
								goto IL_00c5;
							case 16:
								goto IL_00d3;
							case 17:
								goto IL_00e1;
							case 18:
								goto IL_00ef;
							case 19:
								goto IL_00fd;
							case 20:
								goto IL_010b;
							case 21:
								goto IL_0119;
							case 22:
								goto IL_0127;
							case 23:
								goto IL_0135;
							case 24:
								goto IL_0151;
							case 26:
								goto IL_0163;
							case 25:
							case 27:
							case 28:
								goto IL_0172;
							case 29:
								goto IL_0180;
							case 30:
								goto IL_018e;
							case 31:
								goto IL_019c;
							case 32:
								goto IL_01aa;
							case 33:
								goto IL_01b8;
							case 34:
								goto IL_01c6;
							case 35:
								goto IL_01d4;
							case 36:
								goto IL_01e2;
							case 37:
								goto IL_01f0;
							case 38:
								goto IL_01fe;
							case 39:
								goto IL_020c;
							case 40:
								goto IL_021a;
							case 41:
								goto IL_0228;
							case 42:
								goto IL_0236;
							case 43:
								goto IL_0244;
							case 44:
								goto IL_0252;
							case 45:
								goto IL_0260;
							case 46:
								goto IL_026e;
							case 47:
								goto IL_027c;
							case 48:
								goto IL_028a;
							case 49:
								goto IL_0298;
							case 50:
								goto IL_02a6;
							case 51:
								goto IL_02b4;
							case 52:
								goto IL_02c2;
							case 53:
								goto IL_02d0;
							case 54:
								goto IL_02de;
							case 55:
								goto IL_02ec;
							case 56:
								goto IL_02fa;
							case 57:
								goto IL_0308;
							case 58:
								goto IL_0316;
							case 59:
								goto IL_0324;
							case 60:
								goto IL_0343;
							case 61:
								goto IL_0351;
							case 62:
								goto IL_035f;
							case 63:
								goto IL_036d;
							case 64:
								goto IL_037b;
							case 65:
								goto IL_0389;
							case 66:
								goto IL_0397;
							case 67:
								goto IL_03a5;
							case 68:
								goto IL_03b3;
							case 69:
								goto IL_03c1;
							case 70:
								goto IL_03cf;
							case 71:
								goto IL_03dd;
							case 72:
								goto IL_03eb;
							case 73:
								goto IL_03f9;
							case 74:
								goto IL_0407;
							case 75:
								goto IL_0415;
							case 76:
								goto IL_0431;
							case 77:
								goto IL_043f;
							case 79:
								goto IL_0451;
							case 80:
								goto IL_045f;
							case 78:
							case 81:
							case 82:
								goto IL_046e;
							case 83:
								goto IL_047c;
							case 84:
								goto IL_048a;
							case 85:
								goto IL_0498;
							case 86:
								goto IL_04a6;
							case 87:
								goto IL_04b4;
							case 88:
								goto IL_04c2;
							case 89:
								goto IL_04d0;
							case 90:
								goto IL_04de;
							case 91:
								goto IL_04ec;
							case 93:
								goto IL_0501;
							case 94:
								goto IL_050f;
							case 95:
								goto IL_051d;
							case 96:
								goto IL_052b;
							case 97:
								goto IL_0539;
							case 98:
								goto IL_0547;
							case 99:
								goto IL_0555;
							case 100:
								goto IL_0563;
							case 101:
								goto IL_0571;
							case 102:
								goto IL_057f;
							case 103:
								goto IL_058d;
							case 104:
								goto IL_059b;
							case 105:
								goto IL_05a9;
							case 106:
								goto IL_05b7;
							case 107:
								goto IL_05c5;
							case 108:
								goto IL_05d3;
							case 109:
								goto IL_05e1;
							case 110:
								goto IL_05ef;
							case 111:
								goto IL_05fd;
							case 112:
								goto IL_060b;
							case 113:
								goto IL_0619;
							case 114:
								goto IL_0627;
							case 115:
								goto IL_0635;
							case 116:
								goto IL_0643;
							case 92:
							case 117:
							case 118:
								goto IL_0652;
							case 119:
								goto IL_0660;
							case 120:
								goto IL_066e;
							case 121:
								goto IL_067c;
							case 122:
								goto IL_068a;
							case 123:
								goto IL_0698;
							case 124:
								goto IL_06a6;
							case 125:
								goto IL_06b4;
							case 126:
								goto IL_06c2;
							case 127:
								goto IL_06d0;
							case 128:
								goto IL_06de;
							case 129:
								goto IL_06ef;
							case 130:
								goto IL_0700;
							case 131:
								goto IL_0711;
							case 132:
								goto IL_0722;
							case 133:
								goto IL_0733;
							case 134:
								goto IL_0744;
							case 135:
								goto IL_0755;
							case 136:
								goto IL_0766;
							case 137:
								goto IL_0777;
							case 138:
								goto IL_0788;
							case 139:
								goto IL_0799;
							case 140:
								goto IL_07aa;
							case 141:
								goto IL_07bb;
							case 142:
								goto IL_07cc;
							case 143:
								goto IL_07dd;
							case 144:
								goto IL_07ee;
							case 145:
								goto IL_07ff;
							case 146:
								goto IL_0810;
							case 147:
								goto IL_0821;
							case 148:
								goto IL_0832;
							case 149:
								goto IL_0843;
							case 150:
								goto IL_0854;
							case 151:
								goto IL_0865;
							case 152:
								goto IL_0876;
							case 153:
								goto IL_0887;
							case 154:
								goto IL_08a6;
							case 156:
								goto IL_08bb;
							case 155:
							case 157:
							case 158:
								goto IL_08cd;
							case 159:
								goto IL_08de;
							case 160:
								goto IL_08ef;
							case 161:
								goto IL_0900;
							case 162:
								goto IL_0911;
							case 163:
								goto IL_0922;
							case 164:
								goto IL_0933;
							case 165:
								goto IL_0952;
							case 167:
								goto IL_0967;
							case 166:
							case 168:
							case 169:
								goto IL_0979;
							case 170:
								goto IL_098a;
							case 171:
								goto IL_09a9;
							case 173:
								goto IL_09be;
							case 172:
							case 174:
							case 175:
								goto IL_09d0;
							case 176:
								goto IL_09e1;
							case 177:
								goto IL_09f2;
							case 178:
								goto IL_0a03;
							case 179:
								goto IL_0a14;
							case 180:
								goto IL_0a25;
							case 181:
								goto IL_0a36;
							case 182:
								goto IL_0a47;
							case 183:
								goto IL_0a66;
							case 185:
								goto IL_0a7b;
							case 184:
							case 186:
							case 187:
								goto IL_0a8d;
							case 188:
								goto IL_0a9e;
							case 189:
								goto IL_0aaf;
							case 190:
								goto IL_0ac0;
							case 191:
								goto IL_0ad1;
							case 192:
								goto IL_0ae2;
							case 193:
								goto IL_0af3;
							case 194:
								goto IL_0b04;
							case 195:
								goto IL_0b15;
							case 196:
								goto IL_0b26;
							case 197:
								goto IL_0b37;
							case 198:
								goto IL_0b48;
							case 199:
								goto IL_0b59;
							case 200:
								goto IL_0b6a;
							case 201:
								goto IL_0b7b;
							case 202:
								goto IL_0b8c;
							case 203:
								goto IL_0b9d;
							case 204:
								goto IL_0bae;
							case 205:
								goto IL_0bbf;
							case 206:
								goto IL_0bd0;
							case 207:
								goto IL_0be1;
							case 208:
								goto IL_0bf2;
							case 209:
								goto IL_0c03;
							case 210:
								goto IL_0c14;
							case 211:
								goto IL_0c25;
							case 212:
								goto IL_0c36;
							case 213:
								goto IL_0c47;
							case 214:
								goto IL_0c58;
							case 215:
								goto IL_0c69;
							case 216:
								goto IL_0c7a;
							case 217:
								goto IL_0c8b;
							case 218:
								goto IL_0c9c;
							case 219:
								goto IL_0cad;
							case 220:
								goto IL_0cbe;
							case 221:
								goto IL_0ccf;
							case 222:
								goto IL_0ce0;
							case 223:
								goto IL_0cf1;
							case 224:
								goto IL_0d02;
							case 225:
								goto IL_0d13;
							case 226:
								goto IL_0d24;
							case 227:
								goto IL_0d35;
							case 228:
								goto IL_0d46;
							case 229:
								goto IL_0d57;
							case 230:
								goto IL_0d68;
							case 231:
								goto IL_0d79;
							case 232:
								goto IL_0d8a;
							case 233:
								goto IL_0d9b;
							case 234:
								goto IL_0dac;
							case 235:
								goto IL_0dbd;
							case 236:
								goto IL_0dce;
							case 237:
								goto IL_0ddf;
							case 238:
								goto IL_0df0;
							case 239:
								goto IL_0e01;
							case 240:
								goto IL_0e23;
							case 241:
								goto IL_0e34;
							case 242:
								goto IL_0e45;
							case 243:
								goto IL_0e56;
							case 244:
								goto IL_0e67;
							case 245:
								goto IL_0e78;
							case 246:
								goto IL_0e89;
							case 247:
								goto IL_0e9a;
							case 248:
								goto IL_0eab;
							case 249:
								goto IL_0ebc;
							case 250:
								goto IL_0ecd;
							case 251:
								goto IL_0ede;
							case 252:
								goto IL_0f11;
							case 253:
								goto IL_0f22;
							case 254:
								goto IL_0f33;
							case 256:
								goto IL_0f48;
							case 257:
								goto IL_0f59;
							case 258:
								goto IL_0f6a;
							case 255:
							case 259:
							case 260:
								goto IL_0f7c;
							case 261:
								goto IL_0f8d;
							case 262:
								goto IL_0fac;
							case 263:
								goto IL_0fbd;
							case 265:
								goto IL_0fd2;
							case 266:
								goto IL_0fe3;
							case 264:
							case 267:
							case 268:
								goto IL_0ff5;
							case 269:
								goto IL_1006;
							case 270:
								goto IL_1017;
							case 271:
								goto IL_1028;
							case 272:
								goto IL_1039;
							case 273:
								goto IL_104a;
							case 274:
								goto IL_105b;
							case 276:
								goto IL_1073;
							case 277:
								goto IL_1084;
							case 278:
								goto IL_1095;
							case 279:
								goto IL_10a6;
							case 280:
								goto IL_10b7;
							case 281:
								goto IL_10c8;
							case 282:
								goto IL_10d9;
							case 283:
								goto IL_10ea;
							case 284:
								goto IL_10fb;
							case 285:
								goto IL_110c;
							case 286:
								goto IL_111d;
							case 287:
								goto IL_112e;
							case 288:
								goto IL_113f;
							case 289:
								goto IL_1150;
							case 290:
								goto IL_1161;
							case 291:
								goto IL_1172;
							case 292:
								goto IL_1183;
							case 293:
								goto IL_1194;
							case 294:
								goto IL_11a5;
							case 295:
								goto IL_11b6;
							case 296:
								goto IL_11c7;
							case 297:
								goto IL_11d8;
							case 275:
							case 298:
							case 299:
								goto IL_11ea;
							case 300:
								goto IL_120c;
							case 301:
								goto IL_121d;
							case 302:
								goto IL_122e;
							case 303:
								goto IL_123f;
							case 304:
								goto IL_1250;
							case 305:
								goto IL_1261;
							case 306:
								goto IL_1272;
							case 307:
								goto IL_1283;
							case 308:
								goto IL_1294;
							case 309:
								goto IL_12a5;
							case 310:
								goto IL_12b6;
							case 312:
								goto IL_12ce;
							case 313:
								goto IL_12df;
							case 314:
								goto IL_12f0;
							case 315:
								goto IL_1301;
							case 316:
								goto IL_1312;
							case 317:
								goto IL_1323;
							case 318:
								goto IL_1334;
							case 319:
								goto IL_1345;
							case 320:
								goto IL_1356;
							case 321:
								goto IL_1367;
							case 322:
								goto IL_1378;
							case 311:
							case 323:
							case 324:
								goto IL_138a;
							case 325:
								goto IL_139b;
							case 326:
								goto IL_13ac;
							case 327:
								goto IL_13bd;
							case 328:
								goto IL_13ce;
							case 329:
								goto IL_13df;
							case 330:
								goto IL_13f0;
							case 331:
								goto IL_1401;
							case 332:
								goto IL_1412;
							case 333:
								goto IL_1423;
							case 334:
								goto IL_1434;
							case 335:
								goto IL_1445;
							case 336:
								goto IL_1456;
							case 337:
								goto IL_1467;
							case 338:
								goto IL_1478;
							case 339:
								goto IL_1489;
							case 340:
								goto IL_149a;
							case 341:
								goto IL_14ab;
							case 342:
								goto IL_14bc;
							case 343:
								goto IL_14cd;
							case 344:
								goto IL_14de;
							case 345:
								goto IL_1500;
							case 346:
								goto IL_1511;
							case 347:
								goto IL_1522;
							case 348:
								goto IL_1541;
							case 349:
								goto IL_1552;
							case 350:
								goto IL_1563;
							case 352:
								goto IL_1578;
							case 353:
								goto IL_1589;
							case 351:
							case 354:
							case 355:
								goto IL_159b;
							case 356:
								goto IL_15ac;
							case 357:
								goto IL_15bd;
							case 358:
								goto IL_15ce;
							case 359:
								goto IL_15df;
							case 360:
								goto IL_15f0;
							case 361:
								goto IL_1601;
							case 362:
								goto IL_1612;
							case 363:
								goto IL_1623;
							case 364:
								goto IL_1634;
							case 365:
								goto IL_1645;
							case 366:
								goto IL_1656;
							case 367:
								goto IL_1667;
							case 368:
								goto IL_1686;
							case 369:
							case 370:
								goto IL_1699;
							case 371:
							case 372:
								goto IL_16a7;
							case 373:
								goto IL_16b8;
							case 374:
								goto IL_16c9;
							case 375:
								goto IL_16eb;
							case 376:
								goto IL_170d;
							case 377:
								goto IL_174b;
							case 378:
								goto IL_1760;
							case 379:
								goto IL_177f;
							case 381:
								goto IL_1796;
							case 382:
								goto IL_17a2;
							case 383:
								goto IL_17c1;
							case 385:
								goto IL_17d0;
							case 386:
								goto IL_17ef;
							case 388:
								goto IL_17ff;
							case 380:
							case 384:
							case 387:
							case 389:
							case 390:
							case 391:
							case 392:
							case 393:
								goto IL_1811;
							case 394:
								goto IL_1833;
							case 395:
								goto IL_1844;
							case 396:
								goto IL_1883;
							case 397:
								goto IL_18c2;
							case 398:
								goto IL_18d3;
							case 399:
								goto IL_18e4;
							case 400:
								goto IL_18f5;
							case 401:
								goto IL_1933;
							case 402:
								goto IL_1944;
							case 403:
								goto IL_1955;
							case 404:
								goto IL_1966;
							case 405:
								goto IL_1977;
							case 406:
								goto IL_19b5;
							case 408:
								goto IL_19ca;
							case 407:
							case 409:
							case 410:
								goto IL_19dc;
							case 411:
								goto IL_1a0f;
							case 412:
								goto IL_1a20;
							case 413:
								goto IL_1a31;
							case 414:
								goto IL_1a42;
							case 415:
							case 416:
								goto IL_1a55;
							case 417:
								goto IL_1a74;
							case 418:
								goto IL_1a85;
							case 419:
								goto IL_1a96;
							case 420:
								goto IL_1aa7;
							case 421:
							case 422:
								goto IL_1aba;
							case 423:
								goto IL_1ac6;
							case 424:
								goto IL_1ad6;
							case 425:
								goto IL_1ae7;
							case 426:
								goto IL_1af7;
							case 427:
								goto IL_1b0c;
							case 428:
								goto IL_1b2d;
							case 431:
								goto IL_1b3e;
							case 432:
								goto IL_1b80;
							case 433:
								goto IL_1b91;
							case 434:
								goto IL_1c04;
							case 435:
								goto IL_1c15;
							case 429:
							case 430:
							case 436:
								goto IL_1c28;
							case 438:
								goto IL_1c51;
							case 439:
								goto IL_1c61;
							case 440:
								goto IL_1c72;
							case 441:
								goto IL_1cb8;
							case 437:
							case 442:
							case 443:
								goto IL_1cca;
							case 444:
								goto IL_1cda;
							case 445:
								goto IL_1cef;
							case 446:
								goto IL_1d10;
							case 449:
								goto IL_1d21;
							case 450:
								goto IL_1d2a;
							case 451:
								goto IL_1d3a;
							case 452:
								goto IL_1d4c;
							case 455:
								goto IL_1d5a;
							case 456:
								goto IL_1df9;
							case 457:
								goto IL_1e0e;
							case 458:
								goto IL_1e2f;
							case 459:
								goto IL_1f1c;
							case 460:
							case 461:
								goto IL_1f2f;
							case 453:
							case 454:
							case 462:
								goto IL_1f3c;
							case 463:
								goto IL_1f5b;
							case 447:
							case 448:
							case 464:
								goto IL_1f6e;
							case 465:
							case 466:
								goto IL_1f95;
							case 467:
								goto IL_1fa1;
							case 468:
								goto IL_1fad;
							case 469:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 470:
							case 471:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_1f95:
						num2 = 466;
						DC_Main.OpenTable_ColMast();
						goto IL_1fa1;
						IL_1fa1:
						num2 = 467;
						Mfg_Module.Uae_Setting();
						goto IL_1fad;
						IL_1f2f:
						num2 = 461;
						num5++;
						goto IL_1f3c;
						IL_1fad:
						num2 = 468;
						Interaction.MsgBox((object)"All Menu And ABC User Right Is Update....Please Re open Software", (MsgBoxStyle)0, (object)null);
						break;
						IL_001c:
						num2 = 2;
						Interaction.MsgBox((object)"You Have No Rights.....", (MsgBoxStyle)0, (object)null);
						goto end_IL_0001_3;
						IL_0032:
						num2 = 5;
						if (unchecked((int)Interaction.MsgBox((object)"Are You Sure To Reset All Menu ?", (MsgBoxStyle)4, (object)DC_Main.MsgTitle)) != 6)
						{
							goto end_IL_0001_3;
						}
						goto IL_0050;
						IL_0050:
						num2 = 6;
						DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')";
						goto IL_005c;
						IL_005c:
						num2 = 7;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_006d;
						IL_006d:
						num2 = 8;
						if (DC_Main.Tbl.Rows.Count > 10)
						{
							goto IL_0088;
						}
						goto IL_009a;
						IL_0088:
						num2 = 9;
						DC_Main.OpenRecordSetMc("DELETE FROM MENU_DATA WHERE BTN_NAME <> 'Mfg' ");
						goto IL_00a9;
						IL_009a:
						num2 = 11;
						DC_Main.OpenRecordSetMc("DELETE FROM MENU_DATA");
						goto IL_00a9;
						IL_00a9:
						num2 = 13;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','00','00','','','N','L','N')");
						goto IL_00b7;
						IL_00b7:
						num2 = 14;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','01','01','Company','Company','Y','L','N')");
						goto IL_00c5;
						IL_00c5:
						num2 = 15;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','02','02','Year Create','Year Create','Y','L','N')");
						goto IL_00d3;
						IL_00d3:
						num2 = 16;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','03','03','Balance TrFr','Balance TrFr','Y','L','N')");
						goto IL_00e1;
						IL_00e1:
						num2 = 17;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','04','04','Books','Books','Y','L','N')");
						goto IL_00ef;
						IL_00ef:
						num2 = 18;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','05','05','User Create','User Create','Y','L','N')");
						goto IL_00fd;
						IL_00fd:
						num2 = 19;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','06','06','Account Group','Account Group','Y','B','N')");
						goto IL_010b;
						IL_010b:
						num2 = 20;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','07','07','Trade Master','Trade Master','Y','B','N')");
						goto IL_0119;
						IL_0119:
						num2 = 21;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','08','08','Setting','Setting','Y','B','N')");
						goto IL_0127;
						IL_0127:
						num2 = 22;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','09','09','Setting Main','Setting Main','Y','S','N')");
						goto IL_0135;
						IL_0135:
						num2 = 23;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
						{
							goto IL_0151;
						}
						goto IL_0163;
						IL_0151:
						num2 = 24;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','10','10','Location','Location','Y','U','N')");
						goto IL_0172;
						IL_0163:
						num2 = 26;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','10','10','Location','Location','Y','E','N')");
						goto IL_0172;
						IL_0172:
						num2 = 28;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','11','11','Data Refresh','Data Refresh','Y','L','N')");
						goto IL_0180;
						IL_0180:
						num2 = 29;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','12','12','Data Backup','Data Backup','Y','L','N')");
						goto IL_018e;
						IL_018e:
						num2 = 30;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','13','13','Main Menu','Main Menu','N','A','N')");
						goto IL_019c;
						IL_019c:
						num2 = 31;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','14','14','Admin Setting','Admin Setting','Y','E','N')");
						goto IL_01aa;
						IL_01aa:
						num2 = 32;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','15','15','Year Select','Year Select','Y','B','N')");
						goto IL_01b8;
						IL_01b8:
						num2 = 33;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('01','Company','16','16','Menu Set','Menu Set','Y','P','N')");
						goto IL_01c6;
						IL_01c6:
						num2 = 34;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','00','0','','','N','L','N')");
						goto IL_01d4;
						IL_01d4:
						num2 = 35;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','01','01','Party','Party','Y','L','N')");
						goto IL_01e2;
						IL_01e2:
						num2 = 36;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','02','02','Address','Address','Y','L','N')");
						goto IL_01f0;
						IL_01f0:
						num2 = 37;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','03','03','Product','Product','Y','L','N')");
						goto IL_01fe;
						IL_01fe:
						num2 = 38;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','04','04','Group','Group','Y','L','N')");
						goto IL_020c;
						IL_020c:
						num2 = 39;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','05','05','Item','Item','Y','L','N')");
						goto IL_021a;
						IL_021a:
						num2 = 40;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','06','06','AutoItem','AutoItem','Y','L','N')");
						goto IL_0228;
						IL_0228:
						num2 = 41;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','07','07','Employee','Employee','Y','L','N')");
						goto IL_0236;
						IL_0236:
						num2 = 42;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','08','08','Tax','Tax','Y','L','N')");
						goto IL_0244;
						IL_0244:
						num2 = 43;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','09','09','Party Opening','Party Opening','Y','L','N')");
						goto IL_0252;
						IL_0252:
						num2 = 44;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','10','10','Item Opening','Item Opening','Y','L','N')");
						goto IL_0260;
						IL_0260:
						num2 = 45;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','11','11','Tag Opening','Tag Opening','Y','L','N')");
						goto IL_026e;
						IL_026e:
						num2 = 46;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','12','12','Lot Opening','Lot Opening','Y','A','N')");
						goto IL_027c;
						IL_027c:
						num2 = 47;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','13','13','Counter','Counter','Y','B','N')");
						goto IL_028a;
						IL_028a:
						num2 = 48;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','15','15','Style','Style','Y','A','N')");
						goto IL_0298;
						IL_0298:
						num2 = 49;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','16','16','Labour','Labour','Y','S','N')");
						goto IL_02a6;
						IL_02a6:
						num2 = 50;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','17','17','Item Touch','Purity Mast','Y','B','N')");
						goto IL_02b4;
						IL_02b4:
						num2 = 51;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','18','18','ItStk Limit','ItStk Limit','Y','E','N')");
						goto IL_02c2;
						IL_02c2:
						num2 = 52;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','19','19','Point Mast','Point Mast','Y','E','N')");
						goto IL_02d0;
						IL_02d0:
						num2 = 53;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','20','20','Labour Disc','Labour Disc','Y','A','N')");
						goto IL_02de;
						IL_02de:
						num2 = 54;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','21','21','Labour Type','Labour Type','Y','E','N')");
						goto IL_02ec;
						IL_02ec:
						num2 = 55;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','22','22','Design Book','Design Book','Y','E','N')");
						goto IL_02fa;
						IL_02fa:
						num2 = 56;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','23','23','Diamond','Diamond','Y','E','N')");
						goto IL_0308;
						IL_0308:
						num2 = 57;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('02','Master','24','24','Dm Size','Dm Size','N','E','N')");
						goto IL_0316;
						IL_0316:
						num2 = 58;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','00','00','','','N','L','N')");
						goto IL_0324;
						IL_0324:
						num2 = 59;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_0343;
						}
						goto IL_0501;
						IL_0343:
						num2 = 60;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','01','01','B2B Purc','B2B Purc','Y','L','N')");
						goto IL_0351;
						IL_0351:
						num2 = 61;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','02','02','B2B Sales','B2B Sales','Y','L','N')");
						goto IL_035f;
						IL_035f:
						num2 = 62;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','03','03','Hedging Fix','Hedging Fix','Y','L','N')");
						goto IL_036d;
						IL_036d:
						num2 = 63;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','04','04','Purchase','Purchase','Y','L','N')");
						goto IL_037b;
						IL_037b:
						num2 = 64;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','05','05','Purchase Rtn','Purchase Rtn','Y','L','N')");
						goto IL_0389;
						IL_0389:
						num2 = 65;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','06','06','Sales Order','Sales Order','Y','L','N')");
						goto IL_0397;
						IL_0397:
						num2 = 66;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','07','07','Sales','Sales','Y','L','N')");
						goto IL_03a5;
						IL_03a5:
						num2 = 67;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','08','08','Sales Return','Sales Return','Y','L','N')");
						goto IL_03b3;
						IL_03b3:
						num2 = 68;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','09','90','Wh Sales','Wh Sales','Y','L','N')");
						goto IL_03c1;
						IL_03c1:
						num2 = 69;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','10','10','Rate Cut','Rate Cut','N','B','N')");
						goto IL_03cf;
						IL_03cf:
						num2 = 70;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','11','11','Cash Received','Cash Received','Y','L','N')");
						goto IL_03dd;
						IL_03dd:
						num2 = 71;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','12','12','Cash Payment','Cash Payment','Y','L','N')");
						goto IL_03eb;
						IL_03eb:
						num2 = 72;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','13','13','Bank Received','Bank Received','Y','L','N')");
						goto IL_03f9;
						IL_03f9:
						num2 = 73;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','14','14','Bank Payment','Bank Payment','Y','L','N')");
						goto IL_0407;
						IL_0407:
						num2 = 74;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','15','15','Contra Entry','Contra Entry','Y','L','N')");
						goto IL_0415;
						IL_0415:
						num2 = 75;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
						{
							goto IL_0431;
						}
						goto IL_0451;
						IL_0431:
						num2 = 76;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','16','16','Stock Out','Stock Out','Y','U','N')");
						goto IL_043f;
						IL_043f:
						num2 = 77;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','17','17','Stock In','Stock In','Y','U','N')");
						goto IL_046e;
						IL_0451:
						num2 = 79;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','16','16','Stock Out','Stock Out','Y','E','N')");
						goto IL_045f;
						IL_045f:
						num2 = 80;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','17','17','Stock In','Stock In','Y','E','N')");
						goto IL_046e;
						IL_046e:
						num2 = 82;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','18','18','Sale Booking','Sale Booking','Y','S','N')");
						goto IL_047c;
						IL_047c:
						num2 = 83;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','19','19','Purc Booking','Purc Booking','Y','S','N')");
						goto IL_048a;
						IL_048a:
						num2 = 84;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','20','20','Bul Sales','Bul Sales','Y','S','N')");
						goto IL_0498;
						IL_0498:
						num2 = 85;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','21','21','Bul LcBook','Bul LcBook','Y','S','N')");
						goto IL_04a6;
						IL_04a6:
						num2 = 86;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','22','22','E Invoice','E Invoice','N','B','N')");
						goto IL_04b4;
						IL_04b4:
						num2 = 87;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','23','23','E CrntNote','E CrntNote','N','B','N')");
						goto IL_04c2;
						IL_04c2:
						num2 = 88;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','24','24','Sl Quotation','Sl Quotation','N','B','N')");
						goto IL_04d0;
						IL_04d0:
						num2 = 89;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','25','25','Pr Quotation','Pr Quotation','N','S','N')");
						goto IL_04de;
						IL_04de:
						num2 = 90;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','26','26','Wh Quotation','Wh Quotation','N','S','N')");
						goto IL_04ec;
						IL_04ec:
						num2 = 91;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','27','27','Wh Sl Return','Wh Sl Return','N','S','N')");
						goto IL_0652;
						IL_0501:
						num2 = 93;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','01','01','Purchase','Purchase','Y','L','N')");
						goto IL_050f;
						IL_050f:
						num2 = 94;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','02','02','Purchase Rtn','Purchase Rtn','Y','L','N')");
						goto IL_051d;
						IL_051d:
						num2 = 95;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','03','03','Sales Order','Sales Order','Y','L','N')");
						goto IL_052b;
						IL_052b:
						num2 = 96;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','04','04','Sales','Sales','Y','L','N')");
						goto IL_0539;
						IL_0539:
						num2 = 97;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','05','05','Sales Return','Sales Return','Y','L','N')");
						goto IL_0547;
						IL_0547:
						num2 = 98;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','08','08','Wh Sales','Wh Sales','Y','L','N')");
						goto IL_0555;
						IL_0555:
						num2 = 99;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','09','09','Cash Received','Cash Received','Y','L','N')");
						goto IL_0563;
						IL_0563:
						num2 = 100;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','10','10','Cash Payment','Cash Payment','Y','L','N')");
						goto IL_0571;
						IL_0571:
						num2 = 101;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','11','11','Bank Received','Bank Received','Y','L','N')");
						goto IL_057f;
						IL_057f:
						num2 = 102;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','12','12','Bank Payment','Bank Payment','Y','L','N')");
						goto IL_058d;
						IL_058d:
						num2 = 103;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','13','13','Contra Entry','Contra Entry','Y','L','N')");
						goto IL_059b;
						IL_059b:
						num2 = 104;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','14','14','Rate Cut','Rate Cut','Y','B','N')");
						goto IL_05a9;
						IL_05a9:
						num2 = 105;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','15','15','Stock Out','Stock Out','Y','E','N')");
						goto IL_05b7;
						IL_05b7:
						num2 = 106;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','16','16','Stock In','Stock In','Y','E','N')");
						goto IL_05c5;
						IL_05c5:
						num2 = 107;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','17','17','Sale Booking','Sale Booking','Y','S','N')");
						goto IL_05d3;
						IL_05d3:
						num2 = 108;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','18','18','Purc Booking','Purc Booking','Y','S','N')");
						goto IL_05e1;
						IL_05e1:
						num2 = 109;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','19','19','Bul Sales','Bul Sales','Y','S','N')");
						goto IL_05ef;
						IL_05ef:
						num2 = 110;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','20','20','Bul LcBook','Bul LcBook','Y','S','N')");
						goto IL_05fd;
						IL_05fd:
						num2 = 111;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','21','21','E Invoice','E Invoice','Y','B','N')");
						goto IL_060b;
						IL_060b:
						num2 = 112;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','22','22','E CrntNote','E CrntNote','Y','B','N')");
						goto IL_0619;
						IL_0619:
						num2 = 113;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','24','24','Sl Quotation','Sl Quotation','Y','B','N')");
						goto IL_0627;
						IL_0627:
						num2 = 114;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','25','25','Pr Quotation','Pr Quotation','Y','S','N')");
						goto IL_0635;
						IL_0635:
						num2 = 115;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','26','26','Wh Quotation','Wh Quotation','Y','S','N')");
						goto IL_0643;
						IL_0643:
						num2 = 116;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('03','Transaction','27','27','Wh Sl Return','Wh Sl Return','Y','S','N')");
						goto IL_0652;
						IL_0652:
						num2 = 118;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','00','00','','','N','L','N')");
						goto IL_0660;
						IL_0660:
						num2 = 119;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','01','01','Daily Rate','Daily Rate','Y','L','N')");
						goto IL_066e;
						IL_066e:
						num2 = 120;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','02','02','Only Tag Entry','Only Tag Entry','Y','L','Y')");
						goto IL_067c;
						IL_067c:
						num2 = 121;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','03','03','Tag Cancel','Tag Cancel','Y','L','Y')");
						goto IL_068a;
						IL_068a:
						num2 = 122;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','04','04','Tag Print','Tag Print','Y','L','Y')");
						goto IL_0698;
						IL_0698:
						num2 = 123;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','05','05','Stock Adjust','Stock Adjust','Y','L','Y')");
						goto IL_06a6;
						IL_06a6:
						num2 = 124;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','06','06','Order Cancel','Order Cancel','Y','L','Y')");
						goto IL_06b4;
						IL_06b4:
						num2 = 125;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','07','07','Reminder Entry','Reminder Entry','Y','B','Y')");
						goto IL_06c2;
						IL_06c2:
						num2 = 126;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','08','08','Physical Stock','Physical Stock','Y','B','Y')");
						goto IL_06d0;
						IL_06d0:
						num2 = 127;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','09','09','Tag Transfer','Tag Transfer','Y','B','Y')");
						goto IL_06de;
						IL_06de:
						num2 = 128;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','10','10','Tag Adjust','Tag Adjust','Y','A','N')");
						goto IL_06ef;
						IL_06ef:
						num2 = 129;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','11','11','Tag Split','Tag Split','Y','A','N')");
						goto IL_0700;
						IL_0700:
						num2 = 130;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','12','12','Ledger Adjust','Ledger Adjust','Y','E','N')");
						goto IL_0711;
						IL_0711:
						num2 = 131;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','13','13','Mrp Update','Mrp Update','Y','S','N')");
						goto IL_0722;
						IL_0722:
						num2 = 132;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','15','15','Data Import','Data Import','Y','L','N')");
						goto IL_0733;
						IL_0733:
						num2 = 133;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','16','16','Tag Wt Change','Tag Wt Change','Y','B','N')");
						goto IL_0744;
						IL_0744:
						num2 = 134;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','17','17','E-Excel','E-Excel','N','S','N')");
						goto IL_0755;
						IL_0755:
						num2 = 135;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','18','18','Stone/Dm-Cf','Stone/Dm-Cf','Y','A','N')");
						goto IL_0766;
						IL_0766:
						num2 = 136;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','20','20','Whatsapp','Whatsapp','Y','B','N')");
						goto IL_0777;
						IL_0777:
						num2 = 137;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','21','21','Sms','Sms','N','S','N')");
						goto IL_0788;
						IL_0788:
						num2 = 138;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','22','22','Labour Update','Labour Update','Y','S','N')");
						goto IL_0799;
						IL_0799:
						num2 = 139;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','23','23','Counter Trfr','Counter Trfr','Y','B','N')");
						goto IL_07aa;
						IL_07aa:
						num2 = 140;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','24','24','Bank Reconcile','Bank Reconcile','Y','S','N')");
						goto IL_07bb;
						IL_07bb:
						num2 = 141;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','25','25','Vch ReNumber','Vch ReNumber','Y','S','N')");
						goto IL_07cc;
						IL_07cc:
						num2 = 142;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','34','34','Data Export','Data Export','Y','S','N')");
						goto IL_07dd;
						IL_07dd:
						num2 = 143;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('04','Other','35','35','Estimate Reset','Estimate Reset','Y','S','N')");
						goto IL_07ee;
						IL_07ee:
						num2 = 144;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','00','00','','','N','L','N')");
						goto IL_07ff;
						IL_07ff:
						num2 = 145;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','01','01','Ledger Report','Ledger Report','Y','L','N')");
						goto IL_0810;
						IL_0810:
						num2 = 146;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','02','02','Stock Report','Stock Report','Y','L','N')");
						goto IL_0821;
						IL_0821:
						num2 = 147;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','03','03','Tag Stock','Tag Stock','Y','L','N')");
						goto IL_0832;
						IL_0832:
						num2 = 148;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','04','04','Sales Report','Sales Report','Y','L','N')");
						goto IL_0843;
						IL_0843:
						num2 = 149;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','05','05','Purchase Rpt','Purchase Rpt','Y','L','N')");
						goto IL_0854;
						IL_0854:
						num2 = 150;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','06','06','Approval Rpt','Approval Rpt','Y','L','N')");
						goto IL_0865;
						IL_0865:
						num2 = 151;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','07','07','Order Report','Order Report','Y','L','N')");
						goto IL_0876;
						IL_0876:
						num2 = 152;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','08','08','Cash Bank','Cash Bank','Y','L','N')");
						goto IL_0887;
						IL_0887:
						num2 = 153;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_08a6;
						}
						goto IL_08bb;
						IL_08a6:
						num2 = 154;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','09','09','Tax Report','Tax Report','Y','L','N')");
						goto IL_08cd;
						IL_08bb:
						num2 = 156;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','09','09','Gst Report','Gst Report','Y','L','N')");
						goto IL_08cd;
						IL_08cd:
						num2 = 158;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','10','10','Party Os','Party Os','Y','B','N')");
						goto IL_08de;
						IL_08de:
						num2 = 159;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','11','11','Final Reports','Final Reports','Y','S','N')");
						goto IL_08ef;
						IL_08ef:
						num2 = 160;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','12','12','Tag Estmate','Tag Estimate','Y','B','N')");
						goto IL_0900;
						IL_0900:
						num2 = 161;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','13','13','Tag Image','Tag Image','Y','S','N')");
						goto IL_0911;
						IL_0911:
						num2 = 162;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','14','14','Consi Report','Consi Report','Y','P','N')");
						goto IL_0922;
						IL_0922:
						num2 = 163;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','15','15','Trading Report','Trading Report','Y','B','N')");
						goto IL_0933;
						IL_0933:
						num2 = 164;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_0952;
						}
						goto IL_0967;
						IL_0952:
						num2 = 165;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','16','16','HuId Report','HuId Report','N','L','N')");
						goto IL_0979;
						IL_0967:
						num2 = 167;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','16','16','HuId Report','HuId Report','Y','L','N')");
						goto IL_0979;
						IL_0979:
						num2 = 169;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','17','17','Bul Report','Bul Report','Y','S','N')");
						goto IL_098a;
						IL_098a:
						num2 = 170;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_09a9;
						}
						goto IL_09be;
						IL_09a9:
						num2 = 171;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','21','21','Rojmel','Day Book','Y','B','N')");
						goto IL_09d0;
						IL_09be:
						num2 = 173;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','21','21','Rojmel','Rojmel','Y','B','N')");
						goto IL_09d0;
						IL_09d0:
						num2 = 175;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','22','22','Sale Zoom','Sale Zoom','Y','S','N')");
						goto IL_09e1;
						IL_09e1:
						num2 = 176;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','23','23','Purc Zoom','Purc Zoom','Y','S','N')");
						goto IL_09f2;
						IL_09f2:
						num2 = 177;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','24','24','Old Stock','Old Stock','Y','S','N')");
						goto IL_0a03;
						IL_0a03:
						num2 = 178;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','25','25','Stock With Fine','Stock With Fine','Y','S','N')");
						goto IL_0a14;
						IL_0a14:
						num2 = 179;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','26','26','Item InOut','Item InOut','Y','B','N')");
						goto IL_0a25;
						IL_0a25:
						num2 = 180;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','27','27','Reminder Rpt','Reminder Rpt','N','B','N')");
						goto IL_0a36;
						IL_0a36:
						num2 = 181;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','28','28','Address Print','Address Print','Y','B','N')");
						goto IL_0a47;
						IL_0a47:
						num2 = 182;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_0a66;
						}
						goto IL_0a7b;
						IL_0a66:
						num2 = 183;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','29','29','Vp Report','Vp Report','N','S','N')");
						goto IL_0a8d;
						IL_0a7b:
						num2 = 185;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('05','Report','29','29','Vp Report','Vp Report','Y','S','N')");
						goto IL_0a8d;
						IL_0a8d:
						num2 = 187;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','00','00','','','N','L','N')");
						goto IL_0a9e;
						IL_0a9e:
						num2 = 188;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','01','01','Kr Issue','Kr Issue','Y','B','N')");
						goto IL_0aaf;
						IL_0aaf:
						num2 = 189;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','02','02','Kr Received','Kr Received','Y','B','N')");
						goto IL_0ac0;
						IL_0ac0:
						num2 = 190;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','03','03','Kr Design Isu','Kr Design Isu','Y','B','N')");
						goto IL_0ad1;
						IL_0ad1:
						num2 = 191;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','04','04','','','Y','S','N')");
						goto IL_0ae2;
						IL_0ae2:
						num2 = 192;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','05','05','Cust Repar Rec','Cust Repar Rec','Y','S','Y')");
						goto IL_0af3;
						IL_0af3:
						num2 = 193;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','06','06','Kr Repar Isu','Kr Repar Isu','Y','S','Y')");
						goto IL_0b04;
						IL_0b04:
						num2 = 194;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','07','07','Kr Repar Rec','Kr Repar Rec','Y','S','Y')");
						goto IL_0b15;
						IL_0b15:
						num2 = 195;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','08','08','Cust Repar Isu','Cust Repar Isu','Y','S','Y')");
						goto IL_0b26;
						IL_0b26:
						num2 = 196;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','09','09','','','Y','S','N')");
						goto IL_0b37;
						IL_0b37:
						num2 = 197;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','10','10','Kr Report','Kr Report','Y','B','N')");
						goto IL_0b48;
						IL_0b48:
						num2 = 198;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','11','11','Reparing Rpt','Reparing Rpt','Y','S','N')");
						goto IL_0b59;
						IL_0b59:
						num2 = 199;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','14','14','','','N','S','N')");
						goto IL_0b6a;
						IL_0b6a:
						num2 = 200;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','15','15','Mfg Isu','Mfg Isu','N','S','N')");
						goto IL_0b7b;
						IL_0b7b:
						num2 = 201;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','16','16','Mfg Rec','Mfg Rec','N','S','N')");
						goto IL_0b8c;
						IL_0b8c:
						num2 = 202;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','17','17','Mfg Ledger','Mfg Ledger','N','S','N')");
						goto IL_0b9d;
						IL_0b9d:
						num2 = 203;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','18','18','Lot Report','Lot Report','N','S','N')");
						goto IL_0bae;
						IL_0bae:
						num2 = 204;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','23','23','Stock Isu','Stock Isu','Y','E','N')");
						goto IL_0bbf;
						IL_0bbf:
						num2 = 205;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','24','24','Tour Order','Tour Order','Y','E','N')");
						goto IL_0bd0;
						IL_0bd0:
						num2 = 206;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','25','25','Tour Sales','Tour Sales','Y','E','N')");
						goto IL_0be1;
						IL_0be1:
						num2 = 207;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','26','26','Stock Rec','Stock Rec','Y','E','N')");
						goto IL_0bf2;
						IL_0bf2:
						num2 = 208;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','27','27','Tour Report','Tour Report','Y','E','N')");
						goto IL_0c03;
						IL_0c03:
						num2 = 209;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('06','Karigar','28','28','Tour Tag','Tour Tag','Y','E','N')");
						goto IL_0c14;
						IL_0c14:
						num2 = 210;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','00','00','','','N','L','N')");
						goto IL_0c25;
						IL_0c25:
						num2 = 211;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','01','01','Scheme Mast','Scheme Mast','Y','U','N')");
						goto IL_0c36;
						IL_0c36:
						num2 = 212;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','02','02','Member Mast','Member Mast','Y','U','N')");
						goto IL_0c47;
						IL_0c47:
						num2 = 213;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','03','03','Memb Opening','Memb Opening','Y','U','N')");
						goto IL_0c58;
						IL_0c58:
						num2 = 214;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','04','04','Memb Entry','Memb Entry','Y','U','N')");
						goto IL_0c69;
						IL_0c69:
						num2 = 215;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','05','05','Memb Adjust','Memb Adjust','Y','U','N')");
						goto IL_0c7a;
						IL_0c7a:
						num2 = 216;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','06','06','Gold Adjust','Gold Adjust','Y','U','N')");
						goto IL_0c8b;
						IL_0c8b:
						num2 = 217;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','07','07','Scheme Report','Scheme Report','Y','U','N')");
						goto IL_0c9c;
						IL_0c9c:
						num2 = 218;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','08','08','Scheme Ledger','Scheme Ledger','Y','U','N')");
						goto IL_0cad;
						IL_0cad:
						num2 = 219;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','09','09','Monthly Report','Monthly Report','Y','U','N')");
						goto IL_0cbe;
						IL_0cbe:
						num2 = 220;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','13','13','--------------','--------------','Y','U','N')");
						goto IL_0ccf;
						IL_0ccf:
						num2 = 221;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','14','14','Gold Mast','Gold Mast','Y','U','N')");
						goto IL_0ce0;
						IL_0ce0:
						num2 = 222;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','15','15','Digital Gold','Digital Gold','Y','U','N')");
						goto IL_0cf1;
						IL_0cf1:
						num2 = 223;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','16','16','Dg Gold Adj','Dg Gold Adj','Y','U','N')");
						goto IL_0d02;
						IL_0d02:
						num2 = 224;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','25','25','Day Sales','Day Sales','Y','E','N')");
						goto IL_0d13;
						IL_0d13:
						num2 = 225;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('07','Scheme','26','26','Branch InOut','Branch InOut','Y','E','N')");
						goto IL_0d24;
						IL_0d24:
						num2 = 226;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','00','00','','','N','L','N')");
						goto IL_0d35;
						IL_0d35:
						num2 = 227;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','01','01','Dhrn Issue','Dhrn Issue','Y','P','N')");
						goto IL_0d46;
						IL_0d46:
						num2 = 228;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','02','02','Intrest Rec','Intrest Rec','Y','P','N')");
						goto IL_0d57;
						IL_0d57:
						num2 = 229;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','03','03','Dhrn Rec','Dhrn Rec','Y','P','N')");
						goto IL_0d68;
						IL_0d68:
						num2 = 230;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','04','04','Intrest All','Intrest All','Y','P','N')");
						goto IL_0d79;
						IL_0d79:
						num2 = 231;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','05','05','Dhiran Report','Dhiran Report','Y','P','N')");
						goto IL_0d8a;
						IL_0d8a:
						num2 = 232;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','06','06','Dhrn Os Letter','Dhrn Os Letter','Y','P','N')");
						goto IL_0d9b;
						IL_0d9b:
						num2 = 233;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','07','07','Dhrn Due','Dhrn Due','Y','P','N')");
						goto IL_0dac;
						IL_0dac:
						num2 = 234;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','21','21','Loan Received','Loan Received','Y','P','N')");
						goto IL_0dbd;
						IL_0dbd:
						num2 = 235;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','22','22','Loan Intrest','Loan Intrest','Y','P','N')");
						goto IL_0dce;
						IL_0dce:
						num2 = 236;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','23','23','Loan Issue','Loan Issue','Y','P','N')");
						goto IL_0ddf;
						IL_0ddf:
						num2 = 237;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','24','24','Intrest Isu All','Intrest Isu All','Y','P','N')");
						goto IL_0df0;
						IL_0df0:
						num2 = 238;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('08','Dhiran','25','25','Loan Report','Loan Report','Y','P','N')");
						goto IL_0e01;
						IL_0e01:
						num2 = 239;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_0e23;
						}
						goto IL_1073;
						IL_0e23:
						num2 = 240;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','00','00','','','N','L','N')");
						goto IL_0e34;
						IL_0e34:
						num2 = 241;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','01','01','Item Purc','Item Purc','Y','B','N')");
						goto IL_0e45;
						IL_0e45:
						num2 = 242;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','02','02','Item Sales','Item Sales','Y','B','N')");
						goto IL_0e56;
						IL_0e56:
						num2 = 243;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','03','03','Approval Isu','Approval Isu','Y','L','N')");
						goto IL_0e67;
						IL_0e67:
						num2 = 244;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','04','04','Approval Rtn','Approval Rtn','Y','L','N')");
						goto IL_0e78;
						IL_0e78:
						num2 = 245;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','05','05','Labour Work','Labour Work','Y','B','N')");
						goto IL_0e89;
						IL_0e89:
						num2 = 246;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','06','06','Fine Jv Entry','Fine Jv Entry','Y','L','N')");
						goto IL_0e9a;
						IL_0e9a:
						num2 = 247;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','07','07','Old Item Sales','Old Item Sales','Y','S','N')");
						goto IL_0eab;
						IL_0eab:
						num2 = 248;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','08','08','Bill Wise Rec','Bill Wise Rec','Y','S','N')");
						goto IL_0ebc;
						IL_0ebc:
						num2 = 249;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','09','09','Other Expenses','Other Expenses','Y','B','N')");
						goto IL_0ecd;
						IL_0ecd:
						num2 = 250;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','10','10','Other Income','Other Income','Y','B','N')");
						goto IL_0ede;
						IL_0ede:
						num2 = 251;
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "VK265NUST", false) == 0))
						{
							goto IL_0f11;
						}
						goto IL_0f48;
						IL_0f11:
						num2 = 252;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','11','11','Consi Rec','Consi Rec','Y','U','N')");
						goto IL_0f22;
						IL_0f22:
						num2 = 253;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','12','12','Consi Purc','Consi Purc','Y','U','N')");
						goto IL_0f33;
						IL_0f33:
						num2 = 254;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','13','13','Consi Isu','Consi Isu','Y','U','N')");
						goto IL_0f7c;
						IL_0f48:
						num2 = 256;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','11','11','Consi Rec','Consi Rec','N','U','N')");
						goto IL_0f59;
						IL_0f59:
						num2 = 257;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','12','12','Consi Purc','Consi Purc','N','U','N')");
						goto IL_0f6a;
						IL_0f6a:
						num2 = 258;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','13','13','Consi Isu','Consi Isu','N','U','N')");
						goto IL_0f7c;
						IL_0f7c:
						num2 = 260;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','14','14','Card Rec','Card Rec','Y','S','N')");
						goto IL_0f8d;
						IL_0f8d:
						num2 = 261;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "VK252NUST", false) == 0)
						{
							goto IL_0fac;
						}
						goto IL_0fd2;
						IL_0fac:
						num2 = 262;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','15','15','Amt Out','Amt Out','Y','U','N')");
						goto IL_0fbd;
						IL_0fbd:
						num2 = 263;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','16','16','Amt In','Amt In','Y','U','N')");
						goto IL_0ff5;
						IL_0fd2:
						num2 = 265;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','15','15','Amt Out','Amt Out','Y','E','N')");
						goto IL_0fe3;
						IL_0fe3:
						num2 = 266;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','16','16','Amt In','Amt In','Y','E','N')");
						goto IL_0ff5;
						IL_0ff5:
						num2 = 268;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','17','17','Vp Parcel','Vp Parcel','N','S','N')");
						goto IL_1006;
						IL_1006:
						num2 = 269;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','18','18','Vp Adjust','Vp Adjust','N','S','N')");
						goto IL_1017;
						IL_1017:
						num2 = 270;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','19','19','Fine Purc','Fine Purc','N','E','N')");
						goto IL_1028;
						IL_1028:
						num2 = 271;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','20','20','Fine Sales','Fine Sales','N','E','N')");
						goto IL_1039;
						IL_1039:
						num2 = 272;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','21','21','Employee Jv','Employee Jv','Y','A','N')");
						goto IL_104a;
						IL_104a:
						num2 = 273;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','22','22','Service Comm','Service Comm','N','E','N')");
						goto IL_105b;
						IL_105b:
						num2 = 274;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','23','23','Tag Wise Purc','Tag Wise Purc','N','E','N')");
						goto IL_11ea;
						IL_1073:
						num2 = 276;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','00','00','','','N','L','N')");
						goto IL_1084;
						IL_1084:
						num2 = 277;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','01','01','Approval Isu','Approval Isu','Y','L','N')");
						goto IL_1095;
						IL_1095:
						num2 = 278;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','02','02','Approval Rtn','Approval Rtn','Y','L','N')");
						goto IL_10a6;
						IL_10a6:
						num2 = 279;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','03','03','Labour Work','Labour Work','Y','B','N')");
						goto IL_10b7;
						IL_10b7:
						num2 = 280;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','04','04','Fine Jv Entry','Fine Jv Entry','Y','L','N')");
						goto IL_10c8;
						IL_10c8:
						num2 = 281;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','05','05','Old Item Sales','Old Item Sales','Y','S','N')");
						goto IL_10d9;
						IL_10d9:
						num2 = 282;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','06','06','Bill Wise Rec','Bill Wise Rec','Y','S','N')");
						goto IL_10ea;
						IL_10ea:
						num2 = 283;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','07','07','Other Expenses','Other Expenses','Y','B','N')");
						goto IL_10fb;
						IL_10fb:
						num2 = 284;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','08','08','Other Income','Other Income','Y','B','N')");
						goto IL_110c;
						IL_110c:
						num2 = 285;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','09','09','Consi Rec','Consi Rec','Y','P','N')");
						goto IL_111d;
						IL_111d:
						num2 = 286;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','10','10','Consi Purc','Consi Purc','Y','P','N')");
						goto IL_112e;
						IL_112e:
						num2 = 287;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','11','11','Consi Isu','Consi Isu','Y','P','N')");
						goto IL_113f;
						IL_113f:
						num2 = 288;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','12','12','Vp Parcel','Vp Parcel','Y','S','N')");
						goto IL_1150;
						IL_1150:
						num2 = 289;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','13','13','Vp Adjust','Vp Adjust','Y','S','N')");
						goto IL_1161;
						IL_1161:
						num2 = 290;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','14','14','Card Rec','Card Rec','Y','P','N')");
						goto IL_1172;
						IL_1172:
						num2 = 291;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','15','15','Amt Out','Amt Out','Y','E','N')");
						goto IL_1183;
						IL_1183:
						num2 = 292;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','16','16','Amt In','Amt In','Y','E','N')");
						goto IL_1194;
						IL_1194:
						num2 = 293;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','17','17','Fine Purc','Fine Purc','Y','E','N')");
						goto IL_11a5;
						IL_11a5:
						num2 = 294;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','18','18','Fine Sales','Fine Sales','Y','E','N')");
						goto IL_11b6;
						IL_11b6:
						num2 = 295;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','21','21','Employee Jv','Employee Jv','Y','A','N')");
						goto IL_11c7;
						IL_11c7:
						num2 = 296;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','22','22','Service Comm','Service Comm','Y','E','N')");
						goto IL_11d8;
						IL_11d8:
						num2 = 297;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('09','ExtraTran','23','23','Tag Wise Purc','Tag Wise Purc','Y','E','N')");
						goto IL_11ea;
						IL_11ea:
						num2 = 299;
						if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
						{
							goto IL_120c;
						}
						goto IL_12ce;
						IL_120c:
						num2 = 300;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','51','51','Last Visit','Last Visit','Y','U','N')");
						goto IL_121d;
						IL_121d:
						num2 = 301;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','52','52','Stock Ledger','Stock Ledger','Y','U','N')");
						goto IL_122e;
						IL_122e:
						num2 = 302;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','53','53','Order Zoom','Order Zoom','Y','U','N')");
						goto IL_123f;
						IL_123f:
						num2 = 303;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','54','54','Tag Detail','Tag Detail','Y','U','N')");
						goto IL_1250;
						IL_1250:
						num2 = 304;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','55','55','Stock Move','Stock Move','Y','U','N')");
						goto IL_1261;
						IL_1261:
						num2 = 305;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','56','56','Delete Data','Delete Data','Y','P','N')");
						goto IL_1272;
						IL_1272:
						num2 = 306;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','57','57','Party InOut','Party InOut','Y','U','N')");
						goto IL_1283;
						IL_1283:
						num2 = 307;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','58','58','Item Balance','Item Balance','Y','U','N')");
						goto IL_1294;
						IL_1294:
						num2 = 308;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','59','59','Day Work','Day Work','Y','U','N')");
						goto IL_12a5;
						IL_12a5:
						num2 = 309;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','61','61','Bill Os Day','Bill Os Day','Y','A','N')");
						goto IL_12b6;
						IL_12b6:
						num2 = 310;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','62','62','Bill Interest','Bill Interest','Y','A','N')");
						goto IL_138a;
						IL_12ce:
						num2 = 312;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','51','51','Last Visit','Last Visit','Y','P','N')");
						goto IL_12df;
						IL_12df:
						num2 = 313;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','52','52','Stock Ledger','Stock Ledger','Y','P','N')");
						goto IL_12f0;
						IL_12f0:
						num2 = 314;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','53','53','Order Zoom','Order Zoom','Y','P','N')");
						goto IL_1301;
						IL_1301:
						num2 = 315;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','54','54','Tag Detail','Tag Detail','Y','P','N')");
						goto IL_1312;
						IL_1312:
						num2 = 316;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','55','55','Stock Move','Stock Move','Y','P','N')");
						goto IL_1323;
						IL_1323:
						num2 = 317;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','56','56','Delete Data','Delete Data','Y','P','N')");
						goto IL_1334;
						IL_1334:
						num2 = 318;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','57','57','Party InOut','Party InOut','Y','P','N')");
						goto IL_1345;
						IL_1345:
						num2 = 319;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','58','58','Item Balance','Item Balance','Y','U','N')");
						goto IL_1356;
						IL_1356:
						num2 = 320;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','59','59','Day Work','Day Work','Y','P','N')");
						goto IL_1367;
						IL_1367:
						num2 = 321;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','61','61','Bill Os Day','Bill Os Day','Y','A','N')");
						goto IL_1378;
						IL_1378:
						num2 = 322;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('10','Analysis','62','62','Bill Interest','Bill Interest','Y','A','N')");
						goto IL_138a;
						IL_138a:
						num2 = 324;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','75','75','Order Track','Order Track','Y','E','N')");
						goto IL_139b;
						IL_139b:
						num2 = 325;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','76','76','Graph Report','Graph Report','Y','E','N')");
						goto IL_13ac;
						IL_13ac:
						num2 = 326;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','77','77','ItStk Level','ItStk Level','Y','E','N')");
						goto IL_13bd;
						IL_13bd:
						num2 = 327;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','78','78','Bill Wise Profit','Bill Wise Profit','Y','E','N')");
						goto IL_13ce;
						IL_13ce:
						num2 = 328;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','79','79','User Report','User Report','Y','E','N')");
						goto IL_13df;
						IL_13df:
						num2 = 329;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','80','80','Point Report','Point Report','Y','E','N')");
						goto IL_13f0;
						IL_13f0:
						num2 = 330;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','81','81','Deisgn Move','Deisgn Move','Y','E','N')");
						goto IL_1401;
						IL_1401:
						num2 = 331;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','82','82','Movement','Movement','Y','E','N')");
						goto IL_1412;
						IL_1412:
						num2 = 332;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','83','83','Entry Check','Entry Check','Y','E','N')");
						goto IL_1423;
						IL_1423:
						num2 = 333;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','84','84','Lot Report','Lot Report','Y','E','N')");
						goto IL_1434;
						IL_1434:
						num2 = 334;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','85','85','Emp Sale','Emp Sale','Y','E','N')");
						goto IL_1445;
						IL_1445:
						num2 = 335;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('11','More','86','86','Oth Itm Rpt','Oth Itm Rpt','Y','E','N')");
						goto IL_1456;
						IL_1456:
						num2 = 336;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','01','01','Fan Sales','Fan Sales','Y','S','N')");
						goto IL_1467;
						IL_1467:
						num2 = 337;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','02','02','Fan Purc','Fan Purc','Y','S','N')");
						goto IL_1478;
						IL_1478:
						num2 = 338;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','03','03','Ho Order','Ho Order','N','S','N')");
						goto IL_1489;
						IL_1489:
						num2 = 339;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','04','05','FanAmt Out','FanAmt Out','N','S','N')");
						goto IL_149a;
						IL_149a:
						num2 = 340;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','05','05','FanAmt In','FanAmt In','N','S','N')");
						goto IL_14ab;
						IL_14ab:
						num2 = 341;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','06','06','Fan Sl Rtn','Fan Sl Rtn','N','S','N')");
						goto IL_14bc;
						IL_14bc:
						num2 = 342;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','07','07','Fan Pr Rtn','Fan Pr Rtn','N','S','N')");
						goto IL_14cd;
						IL_14cd:
						num2 = 343;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('15','Franchise','24','24','Ho Order Rpt','Ho Order Rpt','N','S','N')");
						goto IL_14de;
						IL_14de:
						num2 = 344;
						if (Operators.CompareString(DC_Main.MsMfgType, "J", false) == 0)
						{
							goto IL_1500;
						}
						goto IL_16a7;
						IL_1500:
						num2 = 345;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','00','00','','','Y','S','N')");
						goto IL_1511;
						IL_1511:
						num2 = 346;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','01','01','Melting Work','Melting Work','Y','S','N')");
						goto IL_1522;
						IL_1522:
						num2 = 347;
						if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
						{
							goto IL_1541;
						}
						goto IL_1578;
						IL_1541:
						num2 = 348;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','02','02','Kr Order Isu','Kr Order Isu','Y','S','N')");
						goto IL_1552;
						IL_1552:
						num2 = 349;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','03','03','Metal Isu','Metal Isu','Y','S','N')");
						goto IL_1563;
						IL_1563:
						num2 = 350;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','04','04','Ghat Rec','Ghat Rec','Y','S','N')");
						goto IL_159b;
						IL_1578:
						num2 = 352;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','02','02','Metal Isu','Metal Isu','Y','S','N')");
						goto IL_1589;
						IL_1589:
						num2 = 353;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','03','03','Ghat Rec','Ghat Rec','Y','S','N')");
						goto IL_159b;
						IL_159b:
						num2 = 355;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','10','10','Jadtar Isu','Jadtar Isu','Y','S','N')");
						goto IL_15ac;
						IL_15ac:
						num2 = 356;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','11','11','Jadtar Rec','Jadtar Rec','Y','S','N')");
						goto IL_15bd;
						IL_15bd:
						num2 = 357;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','12','12','Fitting Isu','Fitting Isu','Y','S','N')");
						goto IL_15ce;
						IL_15ce:
						num2 = 358;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','13','13','Fitting Rec','Fitting Rec','Y','S','N')");
						goto IL_15df;
						IL_15df:
						num2 = 359;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','14','14','Chediya Isu','Chediya Isu','Y','S','N')");
						goto IL_15f0;
						IL_15f0:
						num2 = 360;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','15','15','Chediya Rec','Chediya Rec','Y','S','N')");
						goto IL_1601;
						IL_1601:
						num2 = 361;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','16','16','Para Isu','Para Isu','Y','S','N')");
						goto IL_1612;
						IL_1612:
						num2 = 362;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','17','17','Para Rec','Para Rec','Y','S','N')");
						goto IL_1623;
						IL_1623:
						num2 = 363;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','20','20','JdtTag Entry','JdtTag Entry','Y','S','N')");
						goto IL_1634;
						IL_1634:
						num2 = 364;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','21','21','Jadtar Ledr','Jadtar Ledr','Y','S','N')");
						goto IL_1645;
						IL_1645:
						num2 = 365;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','22','22','Jadtar Rpt','Jadtar Rpt','Y','S','N')");
						goto IL_1656;
						IL_1656:
						num2 = 366;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','23','23','JdtTag Dtl','JdtTag Dtl','Y','S','N')");
						goto IL_1667;
						IL_1667:
						num2 = 367;
						if (Operators.CompareString(DC_Main.MsOrderWithJadtar, "Y", false) == 0)
						{
							goto IL_1686;
						}
						goto IL_1699;
						IL_1686:
						num2 = 368;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('12','Jadtar','24','24','Jadtar Ord','Jadtar Ord','Y','S','N')");
						goto IL_1699;
						IL_1699:
						num2 = 370;
						Mfg_Module.ItemCreate();
						goto IL_16a7;
						IL_16a7:
						num2 = 372;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('13','Crm','01','01','Cust Entry','Cust Entry','Y','A','N')");
						goto IL_16b8;
						IL_16b8:
						num2 = 373;
						DC_Main.OpenRecordSetMc("INSERT INTO MENU_DATA (MAIN_SRNO,BTN_NAME,SM_MAIN_CODE,SM_CODE,SM_MAIN_NAME,SM_NAME,SM_VIEW,SM_TYPE,TILE_ITEM) VALUES ('13','Crm','02','02','Cust Report','Cust Report','Y','A','N')");
						goto IL_16c9;
						IL_16c9:
						num2 = 374;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "DM017NEDM", false) != 0)
						{
							goto IL_16eb;
						}
						goto IL_1811;
						IL_16eb:
						num2 = 375;
						if (Operators.CompareString(DC_Main.MsMfgType, "M", false) == 0)
						{
							goto IL_170d;
						}
						goto IL_1811;
						IL_170d:
						num2 = 376;
						DC_Main.RsQry = "SELECT * FROM MFG_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('301','302','303','304','305','306','307','308','309','310','311','312','313','314','315','316','317','318','319')";
						goto IL_174b;
						IL_174b:
						num2 = 377;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1760;
						IL_1760:
						num2 = 378;
						if (DC_Main.Tbl.Rows.Count > 10)
						{
							goto IL_177f;
						}
						goto IL_1796;
						IL_177f:
						num2 = 379;
						Interaction.MsgBox((object)"You Cant Reset Mfg Master Because More Then 10 Transection in MFG_DATA First Delete It and Try...", (MsgBoxStyle)0, (object)null);
						goto IL_1811;
						IL_1796:
						num2 = 381;
						Mfg_Module.ItemCreate();
						goto IL_17a2;
						IL_17a2:
						num2 = 382;
						if (Operators.CompareString(DC_Main.MsMfgWithLot, "Y", false) == 0)
						{
							goto IL_17c1;
						}
						goto IL_17d0;
						IL_17c1:
						num2 = 383;
						Mfg_Module.Mfg_With_lot();
						goto IL_1811;
						IL_17d0:
						num2 = 385;
						if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
						{
							goto IL_17ef;
						}
						goto IL_17ff;
						IL_17ef:
						num2 = 386;
						Mfg_Module.Mfg_With_Order();
						goto IL_1811;
						IL_17ff:
						num2 = 388;
						Mfg_Module.Mfg_menu_set();
						goto IL_1811;
						IL_1811:
						num2 = 393;
						if (Operators.CompareString(DC_Main.MsItmMfg, "Y", false) == 0)
						{
							goto IL_1833;
						}
						goto IL_19ca;
						IL_1833:
						num2 = 394;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'Y' WHERE MAIN_SRNO = '06' AND SM_MAIN_CODE IN ('14','15','16','17','18')");
						goto IL_1844;
						IL_1844:
						num2 = 395;
						DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('270','275')");
						goto IL_1883;
						IL_1883:
						num2 = 396;
						DC_Main.OpenRecordSetDc("DELETE FROM BOOK_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK IN ('270','275')");
						goto IL_18c2;
						IL_18c2:
						num2 = 397;
						DC_Main.OpenRecordSetDc("DELETE FROM BOOK_IDTL WHERE MAIN_BOOK IN ('MFG ISU ITEM','MFG REC ITEM')");
						goto IL_18d3;
						IL_18d3:
						num2 = 398;
						DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ISU ITEM',1,'I','00001','CASH ON HAND')");
						goto IL_18e4;
						IL_18e4:
						num2 = 399;
						DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG ISU ITEM',2,'I','00008','PURCHASE GOLD A/C')");
						goto IL_18f5;
						IL_18f5:
						num2 = 400;
						DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','270','Mfg Isu','MFGIS','O','F','A','','MFG ISU ITEM','Y','A','N','Mfg Isu','MFG_DATA')";
						goto IL_1933;
						IL_1933:
						num2 = 401;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1944;
						IL_1944:
						num2 = 402;
						DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG REC ITEM',1,'I','00001','CASH ON HAND')");
						goto IL_1955;
						IL_1955:
						num2 = 403;
						DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG REC ITEM',2,'I','00008','PURCHASE GOLD A/C')");
						goto IL_1966;
						IL_1966:
						num2 = 404;
						DC_Main.ExeQuteDc("INSERT INTO BOOK_IDTL (MAIN_BOOK,SR_NO,INOUT_TYPE,AC_CODE,AC_NAME) VALUES ('MFG REC ITEM',3,'I','00056','LABOUR EXP A/C')");
						goto IL_1977;
						IL_1977:
						num2 = 405;
						DC_Main.RsQry = "INSERT INTO BOOK_DATA(CO_CODE,LC_CODE,CO_BOOK,BOOK_NAME,BOOK_SNAME,BOOK_INOUT,BOOK_TYPE,ITM_TYPE,BOOK_SR_NAME,MAIN_BOOK,CUR_USE,DATA_TYPE,RESET_BOOK,MENU_NAME,BOOK_TBL_NAME)  VALUES ('" + DC_Main.MCo_code + "','" + DC_Main.MLc_code + "','275','Mfg Rec','MFGRC','I','F','A','','MFG REC ITEM','Y','A','N','Mfg Rec','MFG_DATA')";
						goto IL_19b5;
						IL_19b5:
						num2 = 406;
						DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_19dc;
						IL_19ca:
						num2 = 408;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_VIEW = 'N' WHERE MAIN_SRNO = '06' AND SM_MAIN_CODE IN ('14','15','16','17','18')");
						goto IL_19dc;
						IL_19dc:
						num2 = 410;
						if ((Operators.CompareString(DC_Main.SSRegSrNo, "VS084NEBU", false) == 0) | (Operators.CompareString(DC_Main.SSRegSrNo, "HM147NEKU", false) == 0))
						{
							goto IL_1a0f;
						}
						goto IL_1a55;
						IL_1a0f:
						num2 = 411;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '03' AND SM_MAIN_CODE = '15' AND SM_MAIN_NAME = 'Stock Out'");
						goto IL_1a20;
						IL_1a20:
						num2 = 412;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '03' AND SM_MAIN_CODE = '16' AND SM_MAIN_NAME = 'Stock In'");
						goto IL_1a31;
						IL_1a31:
						num2 = 413;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '09' AND SM_MAIN_CODE = '15' AND SM_MAIN_NAME = 'Amt Out'");
						goto IL_1a42;
						IL_1a42:
						num2 = 414;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'S' WHERE MAIN_SRNO = '09' AND SM_MAIN_CODE = '16' AND SM_MAIN_NAME = 'Amt In'");
						goto IL_1a55;
						IL_1a55:
						num2 = 416;
						if (Operators.CompareString(DC_Main.SSRegSrNo, "HM777NBKU", false) == 0)
						{
							goto IL_1a74;
						}
						goto IL_1aba;
						IL_1a74:
						num2 = 417;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'B' WHERE MAIN_SRNO = '03' AND SM_MAIN_CODE = '17' AND SM_MAIN_NAME = 'Sale Booking'");
						goto IL_1a85;
						IL_1a85:
						num2 = 418;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'B' WHERE MAIN_SRNO = '03' AND SM_MAIN_CODE = '18' AND SM_MAIN_NAME = 'Purc Booking'");
						goto IL_1a96;
						IL_1a96:
						num2 = 419;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'B' WHERE MAIN_SRNO = '03' AND SM_MAIN_CODE = '19' AND SM_MAIN_NAME = 'Bul Sales'");
						goto IL_1aa7;
						IL_1aa7:
						num2 = 420;
						DC_Main.ExeQuteMc("UPDATE MENU_DATA SET SM_TYPE = 'B' WHERE MAIN_SRNO = '05' AND SM_MAIN_CODE = '17' AND SM_MAIN_NAME = 'Bul Report'");
						goto IL_1aba;
						IL_1aba:
						num2 = 422;
						Mfg_Module.Other_set();
						goto IL_1ac6;
						IL_1ac6:
						num2 = 423;
						DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE <> '01'";
						goto IL_1ad6;
						IL_1ad6:
						num2 = 424;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_1ae7;
						IL_1ae7:
						num2 = 425;
						DC_Main.RsQry = "SELECT LC_CODE FROM LOCT_MAST WHERE CO_CODE = '01' ORDER BY LC_CODE";
						goto IL_1af7;
						IL_1af7:
						num2 = 426;
						DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
						goto IL_1b0c;
						IL_1b0c:
						num2 = 427;
						if (DC_Main.Tbl.Rows.Count > 1)
						{
							goto IL_1b2d;
						}
						goto IL_1c51;
						IL_1b2d:
						num2 = 428;
						DC_Main.M = 0;
						goto IL_1c28;
						IL_1c28:
						num2 = 430;
						if (DC_Main.M < DC_Main.Tbl.Rows.Count)
						{
							goto IL_1b3e;
						}
						goto IL_1cca;
						IL_1b3e:
						num2 = 431;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '", DC_Main.Tbl.Rows[DC_Main.M]["LC_CODE"]), (object)"' AND  USER_NAME = 'ABC'"));
						goto IL_1b80;
						IL_1b80:
						num2 = 432;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_1b91;
						IL_1b91:
						num2 = 433;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','", DC_Main.Tbl.Rows[DC_Main.M]["LC_CODE"]), (object)"',MAIN_SRNO,SM_MAIN_CODE,'ABC',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA "), Interaction.IIf(Operators.CompareString(DC_Main.MsMfgType, "", false) == 0, (object)"WHERE BTN_NAME NOT IN('Jadtar','Mfg')", (object)"")), (object)" "));
						goto IL_1c04;
						IL_1c04:
						num2 = 434;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1c15;
						IL_1c15:
						num2 = 435;
						DC_Main.M++;
						goto IL_1c28;
						IL_1c51:
						num2 = 438;
						DC_Main.RsQry = "DELETE FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '00' AND  USER_NAME = 'ABC'";
						goto IL_1c61;
						IL_1c61:
						num2 = 439;
						DC_Main.ExeQuteMc(DC_Main.RsQry);
						goto IL_1c72;
						IL_1c72:
						num2 = 440;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT) SELECT '01','00',MAIN_SRNO,SM_MAIN_CODE,'ABC',BTN_NAME,SM_MAIN_NAME,'Y','Y','Y','Y' FROM MENU_DATA ", Interaction.IIf(Operators.CompareString(DC_Main.MsMfgType, "", false) == 0, (object)"WHERE BTN_NAME NOT IN('Jadtar','Mfg')", (object)"")), (object)" "));
						goto IL_1cb8;
						IL_1cb8:
						num2 = 441;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1cca;
						IL_1cca:
						num2 = 443;
						DC_Main.RsQry = "SELECT LOGIN_NAME FROM LOGIN_MAST WHERE LOGIN_NAME <> 'ABC' GROUP BY LOGIN_NAME ORDER BY LOGIN_NAME";
						goto IL_1cda;
						IL_1cda:
						num2 = 444;
						DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1cef;
						IL_1cef:
						num2 = 445;
						if (DC_Main.Tbl.Rows.Count > 1)
						{
							goto IL_1d10;
						}
						goto IL_1f95;
						IL_1d10:
						num2 = 446;
						DC_Main.M = 0;
						goto IL_1f6e;
						IL_1f6e:
						num2 = 448;
						if (DC_Main.M < DC_Main.Tbl.Rows.Count)
						{
							goto IL_1d21;
						}
						goto IL_1f95;
						IL_1d21:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_1d2a;
						IL_1d2a:
						num2 = 450;
						DC_Main.RsQry = "SELECT * FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '00' AND  USER_NAME = 'ABC' ORDER BY MAIN_SRNO,SUB_SRNO";
						goto IL_1d3a;
						IL_1d3a:
						num2 = 451;
						dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1d4c;
						IL_1d4c:
						num2 = 452;
						num5 = 0;
						goto IL_1f3c;
						IL_1f3c:
						num2 = 454;
						if (num5 < dataTable.Rows.Count)
						{
							goto IL_1d5a;
						}
						goto IL_1f5b;
						IL_1f5b:
						num2 = 463;
						DC_Main.M++;
						goto IL_1f6e;
						IL_1d5a:
						num2 = 455;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT MAIN_MENU FROM USER_SET WHERE CO_CODE = '01' AND LC_CODE = '" + DC_Main.MLc_code + "' AND USER_NAME = '"), DC_Main.Tbl.Rows[DC_Main.M]["LOGIN_NAME"]), (object)"' AND MAIN_SRNO = '"), dataTable.Rows[num5]["MAIN_SRNO"]), (object)"' AND SUB_SRNO = '"), dataTable.Rows[num5]["SUB_SRNO"]), (object)"'"));
						goto IL_1df9;
						IL_1df9:
						num2 = 456;
						DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1e0e;
						IL_1e0e:
						num2 = 457;
						if (DC_Main.Rshlp.Rows.Count == 0)
						{
							goto IL_1e2f;
						}
						goto IL_1f2f;
						IL_1e2f:
						num2 = 458;
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO USER_SET (CO_CODE,LC_CODE,MAIN_SRNO, SUB_SRNO, USER_NAME, MAIN_MENU, SUB_MENU, FRM_VIEW, FRM_EDIT, FRM_DELETE, FRM_PRINT)  VALUES ('01','" + DC_Main.MLc_code + "','"), dataTable.Rows[num5]["MAIN_SRNO"]), (object)"','"), dataTable.Rows[num5]["SUB_SRNO"]), (object)"','"), DC_Main.Tbl.Rows[DC_Main.M]["LOGIN_NAME"]), (object)"','"), dataTable.Rows[num5]["MAIN_MENU"]), (object)"','"), dataTable.Rows[num5]["SUB_MENU"]), (object)"','Y','Y','Y','Y') "));
						goto IL_1f1c;
						IL_1f1c:
						num2 = 459;
						DC_Main.OpenRecordSetMc(DC_Main.RsQry);
						goto IL_1f2f;
						end_IL_0001_2:
						break;
					}
					num2 = 469;
					Application.Exit();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 10047;
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

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_021f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0226: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 112)
		{
			string text = "";
			text = ((!Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells["Sub_Menu"].Value, (object)"", false)) ? "" : Conversions.ToString(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells["Main_Menu"].Value));
			checked
			{
				int num = ((DataGridView)DGV).Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[i].Cells["Main_Menu"].Value, (object)text, false) && !Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectEqual(((DataGridView)DGV).Rows[i].Cells["Sub_Menu"].Value, (object)"User Create", false), (object)(Operators.CompareString(cboUser.Text, "ABC", false) == 0))))
					{
						((DataGridView)DGV).Rows[i].Cells["View"].Value = false;
						((DataGridView)DGV).Rows[i].Cells["Edit"].Value = false;
						((DataGridView)DGV).Rows[i].Cells["Delete"].Value = false;
						((DataGridView)DGV).Rows[i].Cells["Print"].Value = false;
					}
				}
			}
		}
		if (!(((int)e.KeyCode == 82) & e.Control))
		{
			return;
		}
		string text2 = "";
		text2 = ((!Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells["Sub_Menu"].Value, (object)"", false)) ? "" : Conversions.ToString(((DataGridView)DGV).Rows[((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index].Cells["Main_Menu"].Value));
		checked
		{
			int num2 = ((DataGridView)DGV).Rows.Count - 1;
			for (int j = 0; j <= num2; j++)
			{
				if (Operators.ConditionalCompareObjectEqual(((DataGridView)DGV).Rows[j].Cells["Main_Menu"].Value, (object)text2, false))
				{
					((DataGridView)DGV).Rows[j].Cells["View"].Value = true;
					((DataGridView)DGV).Rows[j].Cells["Edit"].Value = true;
					((DataGridView)DGV).Rows[j].Cells["Delete"].Value = true;
					((DataGridView)DGV).Rows[j].Cells["Print"].Value = true;
				}
			}
		}
	}

	private void tConPasword_DoubleClick(object sender, EventArgs e)
	{
		if ((Operators.CompareString(DC_Main.BAllDataReSet, "Y", false) == 0) & (Operators.CompareString(tUserName.Text, "ABC", false) == 0))
		{
			((Control)Label7).Visible = true;
			((Control)tResetPwd).Visible = true;
			((Control)tResetPwd).Focus();
		}
	}

	private void tResetPwd_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 112)
		{
			return;
		}
		if (Operators.CompareString(tResetPwd.Text, "", false) == 0)
		{
			Interaction.MsgBox((object)"Please Insert Reset Passward and Try...", (MsgBoxStyle)0, (object)null);
			return;
		}
		DC_Main.RsQry = "SELECT * FROM TILE_DATA WHERE SM_MAIN_NAME = 'Opning Form'";
		DC_Main.Tbl = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count > 0)
		{
			DC_Main.RsQry = "UPDATE TILE_DATA SET SHORT_NAME = '" + tResetPwd.Text + "' WHERE SM_MAIN_NAME = 'Opning Form' ";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
		}
		else
		{
			DC_Main.RsQry = "INSERT INTO TILE_DATA(SM_MAIN_NAME,SR_NO,DISPLAY_NAME,SHORT_NAME,TILE_NAME,ITM_SHOW)  VALUES('Opning Form','00','Opning','" + tResetPwd.Text + "','tile0','N')";
			DC_Main.ExeQuteMc(DC_Main.RsQry);
		}
		Interaction.MsgBox((object)"Your Data Reset Pwd Is Save...Please Take Backup And Check", (MsgBoxStyle)0, (object)null);
	}

	private void tOldPasword_TextChanged(object sender, EventArgs e)
	{
	}
}
