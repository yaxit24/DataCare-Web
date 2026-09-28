using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using DataCareNext.My;
using DataCareNext.My.Resources;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevExpress.Utils;
using DevExpress.Utils.Svg;
using DevExpress.XtraEditors;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Qios.DevSuite.Components;

namespace DataCareNext;

[DesignerGenerated]
public class RP_DAY_WORK : Form
{
	private IContainer components;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnExit")]
	private SimpleButton _BtnExit;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnCancel")]
	private SimpleButton _BtnCancel;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnList")]
	private QButton _BtnList;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboUser")]
	private ComboBox _cboUser;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV")]
	private DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("btnExel")]
	private SimpleButton _btnExel;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int cSrNo = 0;

	private const int cBookSname = 1;

	private const int cVchNo = 2;

	private const int cAcName = 3;

	private const int cItPcs = 4;

	private const int cItmGwt = 5;

	private const int cOthWt = 6;

	private const int cItmNwt = 7;

	private const int cItFine = 8;

	private const int cItAmt = 9;

	private const int clbrAmt = 10;

	private const int cOthAmt = 11;

	private const int cNetAmt = 12;

	private const int cDiscAmt = 13;

	private const int cTaxAmt = 14;

	private const int cTotAmt = 15;

	private const int cDrAmt = 16;

	private const int cCrAmt = 17;

	private const int cDrFine = 18;

	private const int cCrFine = 19;

	private const int cDrSilver = 20;

	private const int cCrSilver = 21;

	private const int cVchDate = 22;

	private const int cMobile = 23;

	private const int cAcCode = 24;

	private const int cCoBook = 25;

	private const int cMainBook = 26;

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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDelete")]
	private virtual SimpleButton _BtnDelete;

	internal virtual SimpleButton BtnDelete
	{
		get
		{
			return _BtnDelete;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnDelete = value;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnSave")]
	private virtual SimpleButton _BtnSave;

	internal virtual SimpleButton BtnSave
	{
		get
		{
			return _BtnSave;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_BtnSave = value;
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
			EventHandler eventHandler = tAcCode_TextChanged;
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	internal virtual DataGridViewX DGV_DETL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DETL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewX val = _DGV_DETL;
			if (val != null)
			{
				((Control)val).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val = _DGV_DETL;
			if (val != null)
			{
				((Control)val).DoubleClick += eventHandler;
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

	internal virtual MaskedTextBox mToDt
	{
		[CompilerGenerated]
		get
		{
			return _mToDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mToDt_KeyDown);
			EventHandler eventHandler = mToDt_GotFocus;
			MaskedTextBox val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mToDt = value;
			val2 = _mToDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
		}
	}

	internal virtual QButton BtnList
	{
		[CompilerGenerated]
		get
		{
			return _BtnList;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnList_Click;
			QButton val = _BtnList;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnList = value;
			val = _BtnList;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual MaskedTextBox mFromDt
	{
		[CompilerGenerated]
		get
		{
			return _mFromDt;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(mFromDt_KeyDown);
			EventHandler eventHandler = mFromDt_GotFocus;
			MaskedTextBox val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).GotFocus -= eventHandler;
			}
			_mFromDt = value;
			val2 = _mFromDt;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).GotFocus += eventHandler;
			}
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboUser_KeyDown);
			ComboBox val2 = _cboUser;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboUser = value;
			val2 = _cboUser;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
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

	internal virtual TextBox tBookCode
	{
		[CompilerGenerated]
		get
		{
			return _tBookCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tBookCode_KeyDown);
			TextBox val2 = _tBookCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tBookCode = value;
			val2 = _tBookCode;
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

	internal virtual DataGridViewX DGV
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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
			}
		}
	}

	internal virtual SimpleButton btnExel
	{
		[CompilerGenerated]
		get
		{
			return _btnExel;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = btnExel_Click;
			SimpleButton val = _btnExel;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_btnExel = value;
			val = _btnExel;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	public int newindex { get; set; }

	public RP_DAY_WORK()
	{
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Expected O, but got Unknown
		((Form)this).Load += RP_DAY_WORK_Load;
		((Form)this).Activated += RP_DAY_WORK_Activated;
		((Form)this).Deactivate += RP_DAY_WORK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_DAY_WORK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_DAY_WORK_KeyDown);
		((Form)this).Closed += RP_DAY_WORK_Closed;
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
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Expected O, but got Unknown
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Expected O, but got Unknown
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
		//IL_0266: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0336: Expected O, but got Unknown
		//IL_03df: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Expected O, but got Unknown
		//IL_04f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_04fe: Expected O, but got Unknown
		//IL_061b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0625: Expected O, but got Unknown
		//IL_0688: Unknown result type (might be due to invalid IL or missing references)
		//IL_0692: Expected O, but got Unknown
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0745: Expected O, but got Unknown
		//IL_07a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b2: Expected O, but got Unknown
		//IL_085b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0865: Expected O, but got Unknown
		//IL_08c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d2: Expected O, but got Unknown
		//IL_09ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b7: Expected O, but got Unknown
		//IL_0a25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a2f: Expected O, but got Unknown
		//IL_0ade: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae8: Expected O, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Expected O, but got Unknown
		//IL_0bf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bfa: Expected O, but got Unknown
		//IL_0cc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cd2: Expected O, but got Unknown
		//IL_0d67: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d71: Expected O, but got Unknown
		//IL_0def: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df9: Expected O, but got Unknown
		//IL_0edb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee5: Expected O, but got Unknown
		//IL_0f4e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f58: Expected O, but got Unknown
		//IL_0ffe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1008: Expected O, but got Unknown
		//IL_128c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1321: Unknown result type (might be due to invalid IL or missing references)
		//IL_132b: Expected O, but got Unknown
		//IL_134e: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_13b7: Expected O, but got Unknown
		//IL_1465: Unknown result type (might be due to invalid IL or missing references)
		//IL_146f: Expected O, but got Unknown
		//IL_150f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1519: Expected O, but got Unknown
		//IL_1592: Unknown result type (might be due to invalid IL or missing references)
		//IL_159c: Expected O, but got Unknown
		//IL_165a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1664: Expected O, but got Unknown
		//IL_16e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_16eb: Expected O, but got Unknown
		//IL_17bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c5: Expected O, but got Unknown
		//IL_1861: Unknown result type (might be due to invalid IL or missing references)
		//IL_186b: Expected O, but got Unknown
		//IL_18f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fb: Expected O, but got Unknown
		//IL_19d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_19df: Expected O, but got Unknown
		//IL_1a48: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a52: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_DAY_WORK));
		DataGridViewCellStyle val = new DataGridViewCellStyle();
		DataGridViewCellStyle val2 = new DataGridViewCellStyle();
		DataGridViewCellStyle val3 = new DataGridViewCellStyle();
		DataGridViewCellStyle val4 = new DataGridViewCellStyle();
		DataGridViewCellStyle val5 = new DataGridViewCellStyle();
		DataGridViewCellStyle val6 = new DataGridViewCellStyle();
		DataGridViewCellStyle val7 = new DataGridViewCellStyle();
		DataGridViewCellStyle val8 = new DataGridViewCellStyle();
		DataGridViewCellStyle val9 = new DataGridViewCellStyle();
		DataGridViewCellStyle val10 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		btnExel = new SimpleButton();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		mToDt = new MaskedTextBox();
		BtnList = new QButton();
		Label1 = new Label();
		mFromDt = new MaskedTextBox();
		cboUser = new ComboBox();
		Label3 = new Label();
		tBookCode = new TextBox();
		Label5 = new Label();
		DGV = new DataGridViewX();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)btnExel);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 6;
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
		((Control)BtnExit).TabIndex = 7;
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
		((Control)BtnDelete).TabIndex = 6;
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
		((Control)BtnCancel).TabIndex = 5;
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
		((Control)BtnSave).TabIndex = 4;
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
		((Control)BtnPrint).TabIndex = 3;
		BtnPrint.Text = "&Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)btnExel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)btnExel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)btnExel).Appearance.Options.UseFont = true;
		((BaseStyleControl)btnExel).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)btnExel.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("btnExel.ImageOptions.SvgImage");
		((Control)btnExel).Location = new Point(730, 3);
		((BaseControl)btnExel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)btnExel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)btnExel).Name = "btnExel";
		((Control)btnExel).Size = new Size(91, 37);
		((Control)btnExel).TabIndex = 8;
		btnExel.Text = "&Excel";
		((BaseButton)btnExel).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(1247, 476);
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
		lblBook.Text = "Day Work Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(430, 47);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(66, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(502, 47);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(198, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(359, 49);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(64, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Ac Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_DETL).BackgroundColor = Color.Snow;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val3;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 82);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val5;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(144, 45);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((QControl)BtnList).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnList).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnList).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnList).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnList).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnList).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnList).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnList).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnList.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnList.Image = null;
		((QControl)BtnList).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnList).Location = new Point(751, 41);
		((Control)BtnList).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnList).Name = "BtnList";
		((Control)BtnList).Size = new Size(70, 33);
		((Control)BtnList).TabIndex = 4;
		BtnList.Text = "Ok";
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(10, 44);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(44, 20);
		((Control)Label1).TabIndex = 1167;
		Label1.Text = "Date";
		Label1.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(60, 45);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		cboUser.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboUser).Font = new Font("Tahoma", 9f);
		((ListControl)cboUser).FormattingEnabled = true;
		((Control)cboUser).Location = new Point(1037, 45);
		((Control)cboUser).Name = "cboUser";
		((Control)cboUser).Size = new Size(135, 22);
		((Control)cboUser).TabIndex = 5;
		((Control)cboUser).Visible = false;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(980, 44);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(51, 20);
		((Control)Label3).TabIndex = 1169;
		Label3.Text = "User";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Label3).Visible = false;
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(288, 47);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(60, 23);
		((Control)tBookCode).TabIndex = 2;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(234, 48);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(47, 20);
		((Control)Label5).TabIndex = 1171;
		Label5.Text = "Book";
		Label5.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val8;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(13, 83);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val10.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val10;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1160, 471);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 1172;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)DGV);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)cboUser);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)BtnList);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_DAY_WORK";
		((Form)this).Text = "Day Work Report ";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_VCH_SUMM()
	{
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected O, but got Unknown
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Expected O, but got Unknown
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Expected O, but got Unknown
		//IL_0cf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cfb: Expected O, but got Unknown
		//IL_0ed6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ee0: Expected O, but got Unknown
		//IL_3cce: Unknown result type (might be due to invalid IL or missing references)
		//IL_3cd8: Expected O, but got Unknown
		//IL_3ec1: Unknown result type (might be due to invalid IL or missing references)
		//IL_3ecb: Expected O, but got Unknown
		//IL_40d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_40db: Expected O, but got Unknown
		//IL_4174: Unknown result type (might be due to invalid IL or missing references)
		//IL_417e: Expected O, but got Unknown
		//IL_229c: Unknown result type (might be due to invalid IL or missing references)
		//IL_22a6: Expected O, but got Unknown
		//IL_35dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_35e7: Expected O, but got Unknown
		//IL_3a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_3a90: Expected O, but got Unknown
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV).Columns[0].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Book");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[1].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "VchNo");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns[2].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Ac Name");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV).Columns[3].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "Pcs");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N";
			((DataGridView)DGV).Columns.Add("", "GWt");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "OthWt");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Nwt");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Fine");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "ItAmt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "LAmt");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "OthAmt");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "NetAmt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Disc");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Tax");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(65.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "TotAmt");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "DrAmt");
			((DataGridView)DGV).Columns[16].Visible = false;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "CrAmt");
			((DataGridView)DGV).Columns[17].Visible = false;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "DrFine");
			((DataGridView)DGV).Columns[18].Visible = false;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "CrFine");
			((DataGridView)DGV).Columns[19].Visible = false;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "DrSilver");
			((DataGridView)DGV).Columns[20].Visible = false;
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "CrSilver");
			((DataGridView)DGV).Columns[21].Visible = false;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "VchDate");
			((DataGridView)DGV).Columns[22].Visible = false;
			((DataGridView)DGV).Columns.Add("", "Mobile");
			((DataGridView)DGV).Columns[23].Visible = false;
			((DataGridView)DGV).Columns.Add("", "AcCode");
			((DataGridView)DGV).Columns[24].Visible = false;
			((DataGridView)DGV).Columns.Add("", "CoBook");
			((DataGridView)DGV).Columns[25].Visible = false;
			((DataGridView)DGV).Columns.Add("", "MainBook");
			((DataGridView)DGV).Columns[26].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			DC_Main.M = 0;
			DC_Main.RsQry = "SELECT A.VCH_DATE AS WORK_DATE FROM MAIN_STOCK AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' GROUP BY A.VCH_DATE  UNION SELECT B.VCH_DATE AS WORK_DATE FROM AC_DATA AS B WHERE B.CO_CODE = '" + DC_Main.MCo_code + "' AND B.LC_CODE = '" + DC_Main.MLc_code + "' AND B.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND B.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' GROUP BY B.VCH_DATE ORDER BY A.VCH_DATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.R = 0;
			int num = 1;
			int num2 = 0;
			double num3 = default(double);
			double num4 = default(double);
			double num5 = default(double);
			double num6 = default(double);
			double num7 = default(double);
			double num8 = default(double);
			double num9 = default(double);
			double num10 = default(double);
			double num11 = default(double);
			double num12 = default(double);
			double num13 = default(double);
			double num14 = default(double);
			double num15 = default(double);
			double num16 = default(double);
			double num17 = default(double);
			double num18 = default(double);
			double num19 = default(double);
			double num20 = default(double);
			double num21 = default(double);
			double num22 = default(double);
			double num23 = default(double);
			double num24 = default(double);
			double num26 = default(double);
			double num27 = default(double);
			double num28 = default(double);
			double num29 = default(double);
			double num30 = default(double);
			double num31 = default(double);
			double num32 = default(double);
			double num33 = default(double);
			double num34 = default(double);
			double num35 = default(double);
			double num36 = default(double);
			double num37 = default(double);
			double num38 = default(double);
			double num39 = default(double);
			double num40 = default(double);
			double num41 = default(double);
			double num42 = default(double);
			double num43 = default(double);
			double num44 = default(double);
			double num45 = default(double);
			double num46 = default(double);
			double num47 = default(double);
			double num49 = default(double);
			double num50 = default(double);
			while (DC_Main.R < DC_Main.Rshlp.Rows.Count)
			{
				DataGridViewX dGV = DGV;
				((DataGridView)dGV).Rows.Add();
				((DataGridView)dGV)[0, num2].Value = num2;
				((DataGridView)dGV)[1, num2].Value = Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"], (object)"");
				((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.Blue;
				((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
				DC_Main.RsQry = "SELECT B.MAIN_BOOK As MAIN_BOOK,B.BOOK_SNAME AS BOOK_SNAME,A.VCH_DATE AS VCH_DATE,A.CO_BOOK AS CO_BOOK,A.VCH_NO AS VCH_NO,A.AC_CODE AS AC_CODE,C.AC_NAME AS AC_NAME,A.IT_TYPE AS IT_TYPE,A.SIGN AS ITM_SIGN ,SUM(A.FINE_WT) As Fine,SUM(A.DR_AMT) As NetAmt   FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DR_AMT <> 0 AND  A.FINE_WT <> 0 AND A.SIGN = '+' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "MM/dd/yyyy") + "'  GROUP BY B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME,A.IT_TYPE,A.SIGN  UNION ALL SELECT E.MAIN_BOOK,E.BOOK_SNAME,D.VCH_DATE,D.CO_BOOK,D.VCH_NO,D.AC_CODE,F.AC_NAME,D.IT_TYPE,D.SIGN ,SUM(D.FINE_WT) As Fine,SUM(D.DR_AMT) As NetAmt   FROM (AC_DATA AS D LEFT JOIN BOOK_DATA AS E ON D.CO_CODE = E.CO_CODE And D.LC_CODE = E.LC_CODE And D.CO_BOOK = E.CO_BOOK)LEFT JOIN AC_MAST AS F ON D.CO_CODE = F.CO_CODE AND D.AC_CODE = F.AC_CODE  WHERE D.CO_CODE = '" + DC_Main.MCo_code + "' AND D.LC_CODE = '" + DC_Main.MLc_code + "' AND D.CO_YEAR = '" + DC_Main.MCo_year + "' AND D.CR_AMT <> 0 AND  D.FINE_WT <> 0 AND D.SIGN = '-' AND D.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "MM/dd/yyyy") + "'  GROUP BY E.MAIN_BOOK,E.BOOK_SNAME,D.VCH_DATE,D.CO_BOOK,D.VCH_NO,D.AC_CODE,F.AC_NAME,D.IT_TYPE,D.SIGN  ORDER BY B.MAIN_BOOK, A.CO_BOOK, A.VCH_NO ";
				DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DataView dataView = new DataView(table);
				DC_Main.RsQry = "SELECT B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME,SUM(ITM_PCS) As Pcs,SUM(A.ITM_GWT) As Gwt,SUM(A.ITM_GWT-A.ITM_NWT) As OthWt,SUM(A.ITM_NWT) As Nwt,SUM(A.ITM_FINE) As Fine,  SUM(A.ITM_AMT) As ItAmt,SUM(A.LBR_AMT) AS LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.NET_AMT) As NetAmt   FROM (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TR_TYPE = 'P' AND ITM_SIGN = '+' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "MM/dd/yyyy") + "' ";
				DC_Main.RsQry += "GROUP BY B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME ";
				DC_Main.RsQry += "ORDER BY B.MAIN_BOOK, A.CO_BOOK, A.VCH_NO ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				for (num = 0; num < DC_Main.Tbl.Rows.Count; num++)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[1, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["BOOK_SNAME"], (object)"");
					((DataGridView)dGV)[2, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["VCH_NO"], (object)"");
					((DataGridView)dGV)[22, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[3, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["AC_NAME"], (object)"");
					((DataGridView)dGV)[4, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Pcs"], (object)"")), "0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[4, num2].Value = "";
					}
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Gwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[5, num2].Value = "";
					}
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Nwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[7, num2].Value = "";
					}
					((DataGridView)dGV)[6, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["OthWt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[6, num2].Value = "";
					}
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[8, num2].Value = "";
					}
					((DataGridView)dGV)[9, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["ItAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[9, num2].Value = "";
					}
					((DataGridView)dGV)[10, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["LbrAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[10, num2].Value = "";
					}
					((DataGridView)dGV)[11, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["OthAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[11, num2].Value = "";
					}
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["NetAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[12, num2].Value = "";
					}
					((DataGridView)dGV)[24, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["AC_CODE"], (object)"");
					((DataGridView)dGV)[25, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["CO_BOOK"], (object)"");
					((DataGridView)dGV)[26, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["MAIN_BOOK"], (object)"");
					num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num12 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					num14 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num16 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num18 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num20 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num24 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
				}
				dataView.RowFilter = "ITM_SIGN =  '+' AND IT_TYPE = 'G'";
				int num25 = dataView.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num25)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[1, num2].Value = "RATE CUT";
					((DataGridView)dGV)[2, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["VCH_NO"], (object)"");
					((DataGridView)dGV)[22, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[3, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["AC_NAME"], (object)"");
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[5, num2].Value = "";
					}
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[7, num2].Value = "";
					}
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[8, num2].Value = "";
					}
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["NetAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[12, num2].Value = "";
					}
					((DataGridView)dGV)[24, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["AC_CODE"], (object)"");
					((DataGridView)dGV)[25, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["CO_BOOK"], (object)"");
					((DataGridView)dGV)[26, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["MAIN_BOOK"], (object)"");
					num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num12 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num13 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					num14 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num15 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num16 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num17 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num18 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num19 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num20 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num21 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num22 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num23 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num24 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					DC_Main.M++;
				}
				if (num3 + num4 + num10 > 0.0)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[3, num2].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "dd/MM") + "  Purc Total :";
					((DataGridView)DGV).Rows[num2].Cells[3].Style.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV)[4, num2].Value = Strings.Format((object)num3, "0");
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)num4, "0.000");
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)num5, "0.000");
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)num6, "0.000");
					((DataGridView)dGV)[9, num2].Value = Strings.Format((object)num7, "0.00");
					((DataGridView)dGV)[10, num2].Value = Strings.Format((object)num8, "0.00");
					((DataGridView)dGV)[11, num2].Value = Strings.Format((object)num9, "0.00");
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)num10, "0.00");
					((DataGridView)dGV)[13, num2].Value = Strings.Format((object)num11, "0.00");
					((DataGridView)dGV)[14, num2].Value = Strings.Format((object)num12, "0.00");
					((DataGridView)dGV)[15, num2].Value = Strings.Format((object)num13, "0.00");
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.Green;
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
					num3 = 0.0;
					num4 = 0.0;
					num5 = 0.0;
					num6 = 0.0;
					num7 = 0.0;
					num8 = 0.0;
					num9 = 0.0;
					num10 = 0.0;
					num11 = 0.0;
					num12 = 0.0;
					num13 = 0.0;
				}
				DC_Main.RsQry = "SELECT B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME,SUM(ITM_PCS) As Pcs,SUM(A.ITM_GWT) As Gwt,SUM(A.ITM_GWT-A.ITM_NWT) As OthWt,SUM(A.ITM_NWT) As Nwt,SUM(A.ITM_FINE) As Fine,  SUM(A.ITM_AMT) As ItAmt,SUM(A.LBR_AMT) AS LbrAmt,SUM(A.OTH_AMT) As OthAmt,SUM(A.NET_AMT) As NetAmt   FROM (MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.TR_TYPE = 'S' AND ITM_SIGN = '-' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "MM/dd/yyyy") + "' ";
				DC_Main.RsQry += "GROUP BY B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME ";
				DC_Main.RsQry += "ORDER BY B.MAIN_BOOK, A.CO_BOOK, A.VCH_NO ";
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				for (num = 0; num < DC_Main.Tbl.Rows.Count; num++)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[1, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["BOOK_SNAME"], (object)"");
					((DataGridView)dGV)[2, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["VCH_NO"], (object)"");
					((DataGridView)dGV)[22, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[3, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["AC_NAME"], (object)"");
					((DataGridView)dGV)[4, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Pcs"], (object)"")), "0");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[4, num2].Value = "";
					}
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Gwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[5, num2].Value = "";
					}
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Nwt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[7, num2].Value = "";
					}
					((DataGridView)dGV)[6, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["OthWt"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[6, num2].Value = "";
					}
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[8, num2].Value = "";
					}
					((DataGridView)dGV)[9, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["ItAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[9, num2].Value = "";
					}
					((DataGridView)dGV)[10, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["LbrAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[10, num2].Value = "";
					}
					((DataGridView)dGV)[11, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["OthAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[11, num2].Value = "";
					}
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["NetAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[12, num2].Value = "";
					}
					((DataGridView)dGV)[24, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["AC_CODE"], (object)"");
					((DataGridView)dGV)[25, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["CO_BOOK"], (object)"");
					((DataGridView)dGV)[26, num2].Value = Operators.ConcatenateObject(DC_Main.Tbl.Rows[num]["MAIN_BOOK"], (object)"");
					num26 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num27 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num28 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num29 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num30 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num31 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num32 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num33 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num34 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num35 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num36 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					num37 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num38 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num39 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num40 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num41 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num42 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num43 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num44 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num45 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num46 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num47 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
				}
				dataView.RowFilter = "ITM_SIGN =  '-' AND IT_TYPE = 'G'";
				int num48 = dataView.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num48)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[1, num2].Value = "RATE CUT";
					((DataGridView)dGV)[2, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["VCH_NO"], (object)"");
					((DataGridView)dGV)[22, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[3, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["AC_NAME"], (object)"");
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[5, num2].Value = "";
					}
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[7, num2].Value = "";
					}
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["Fine"], (object)"")), "0.000");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[8, num2].Value = "";
					}
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataView[DC_Main.M]["NetAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[12, num2].Value = "";
					}
					((DataGridView)dGV)[24, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["AC_CODE"], (object)"");
					((DataGridView)dGV)[25, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["CO_BOOK"], (object)"");
					((DataGridView)dGV)[26, num2].Value = Operators.ConcatenateObject(dataView[DC_Main.M]["MAIN_BOOK"], (object)"");
					num26 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num27 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num28 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num29 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num30 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num31 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num32 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num33 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num34 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num35 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num36 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					num37 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, num2].Value));
					num38 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, num2].Value));
					num39 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, num2].Value));
					num40 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, num2].Value));
					num41 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, num2].Value));
					num42 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, num2].Value));
					num43 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, num2].Value));
					num44 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num45 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, num2].Value));
					num46 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, num2].Value));
					num47 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, num2].Value));
					DC_Main.M++;
				}
				if (num26 + num27 + num33 > 0.0)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[3, num2].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "dd/MM") + "  Sales Total :";
					((DataGridView)DGV).Rows[num2].Cells[3].Style.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV)[4, num2].Value = Strings.Format((object)num26, "0");
					((DataGridView)dGV)[5, num2].Value = Strings.Format((object)num27, "0.000");
					((DataGridView)dGV)[7, num2].Value = Strings.Format((object)num28, "0.000");
					((DataGridView)dGV)[8, num2].Value = Strings.Format((object)num29, "0.000");
					((DataGridView)dGV)[9, num2].Value = Strings.Format((object)num30, "0.00");
					((DataGridView)dGV)[10, num2].Value = Strings.Format((object)num31, "0.00");
					((DataGridView)dGV)[11, num2].Value = Strings.Format((object)num32, "0.00");
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)num33, "0.00");
					((DataGridView)dGV)[13, num2].Value = Strings.Format((object)num34, "0.00");
					((DataGridView)dGV)[14, num2].Value = Strings.Format((object)num35, "0.00");
					((DataGridView)dGV)[15, num2].Value = Strings.Format((object)num36, "0.00");
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.BlueViolet;
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
					num26 = 0.0;
					num27 = 0.0;
					num28 = 0.0;
					num29 = 0.0;
					num30 = 0.0;
					num31 = 0.0;
					num32 = 0.0;
					num33 = 0.0;
					num34 = 0.0;
					num35 = 0.0;
					num36 = 0.0;
				}
				DC_Main.RsQry = "SELECT B.MAIN_BOOK As MAIN_BOOK,B.BOOK_SNAME AS BOOK_SNAME,A.VCH_DATE AS VCH_DATE,A.CO_BOOK AS CO_BOOK,A.VCH_NO AS VCH_NO,A.AC_CODE AS AC_CODE,C.AC_NAME AS AC_NAME,A.IT_TYPE AS IT_TYPE,A.SIGN AS ITM_SIGN,SUM(A.DR_AMT) As NetAmt   FROM (AC_DATA AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.LC_CODE And A.CO_BOOK = B.CO_BOOK)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.DR_AMT <> 0 AND C.AC_GR IN ('45','46','47') AND A.AC_CODE <> '00056' AND A.VCH_DATE = '" + Strings.Format((object)Conversions.ToDate(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "MM/dd/yyyy") + "'  GROUP BY B.MAIN_BOOK,B.BOOK_SNAME,A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.AC_CODE,C.AC_NAME,A.IT_TYPE,A.SIGN  ORDER BY B.MAIN_BOOK, A.CO_BOOK, A.VCH_NO ";
				DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				for (num = 0; num < dataTable.Rows.Count; num++)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[1, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["BOOK_SNAME"], (object)"");
					((DataGridView)dGV)[2, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["VCH_NO"], (object)"");
					((DataGridView)dGV)[22, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["VCH_DATE"], (object)"");
					((DataGridView)dGV)[3, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["AC_NAME"], (object)"");
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)Conversion.Val(Operators.ConcatenateObject(dataTable.Rows[num]["NetAmt"], (object)"")), "0.00");
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value)) == 0.0)
					{
						((DataGridView)dGV)[12, num2].Value = "";
					}
					((DataGridView)dGV)[24, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["AC_CODE"], (object)"");
					((DataGridView)dGV)[25, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["CO_BOOK"], (object)"");
					((DataGridView)dGV)[26, num2].Value = Operators.ConcatenateObject(dataTable.Rows[num]["MAIN_BOOK"], (object)"");
					num49 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
					num50 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, num2].Value));
				}
				if (num49 > 0.0)
				{
					((DataGridView)dGV).Rows.Add();
					num2++;
					((DataGridView)dGV)[0, num2].Value = num2;
					((DataGridView)dGV)[3, num2].Value = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.R]["WORK_DATE"]), "dd/MM") + "  Total Exp :";
					((DataGridView)DGV).Rows[num2].Cells[3].Style.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)dGV)[12, num2].Value = Strings.Format((object)num49, "0.00");
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.MediumVioletRed;
					((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
					num49 = 0.0;
				}
				dGV = null;
				num2++;
				DC_Main.R++;
			}
			DataGridViewX dGV2 = DGV;
			((DataGridView)dGV2).Rows.Add();
			((DataGridView)dGV2).Rows.Add();
			num2 = ((DataGridView)dGV2).Rows.Count - 1;
			((DataGridView)dGV2)[3, num2].Value = "Total Purc : ";
			((DataGridView)dGV2)[4, num2].Value = Strings.Format((object)num14, "0");
			((DataGridView)dGV2)[5, num2].Value = Strings.Format((object)num15, "0.000");
			((DataGridView)dGV2)[7, num2].Value = Strings.Format((object)num16, "0.000");
			((DataGridView)dGV2)[8, num2].Value = Strings.Format((object)num17, "0.000");
			((DataGridView)dGV2)[9, num2].Value = Strings.Format((object)num18, "0.00");
			((DataGridView)dGV2)[10, num2].Value = Strings.Format((object)num19, "0.00");
			((DataGridView)dGV2)[11, num2].Value = Strings.Format((object)num20, "0.00");
			((DataGridView)dGV2)[12, num2].Value = Strings.Format((object)num21, "0.00");
			((DataGridView)dGV2)[13, num2].Value = Strings.Format((object)num22, "0.00");
			((DataGridView)dGV2)[14, num2].Value = Strings.Format((object)num23, "0.00");
			((DataGridView)dGV2)[15, num2].Value = Strings.Format((object)num24, "0.00");
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.Green;
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
			((DataGridView)dGV2).Rows.Add();
			num2 = ((DataGridView)dGV2).Rows.Count - 1;
			((DataGridView)dGV2)[3, num2].Value = "Total Sale : ";
			((DataGridView)dGV2)[4, num2].Value = Strings.Format((object)num37, "0");
			((DataGridView)dGV2)[5, num2].Value = Strings.Format((object)num38, "0.000");
			((DataGridView)dGV2)[7, num2].Value = Strings.Format((object)num39, "0.000");
			((DataGridView)dGV2)[8, num2].Value = Strings.Format((object)num40, "0.000");
			((DataGridView)dGV2)[9, num2].Value = Strings.Format((object)num41, "0.00");
			((DataGridView)dGV2)[10, num2].Value = Strings.Format((object)num42, "0.00");
			((DataGridView)dGV2)[11, num2].Value = Strings.Format((object)num43, "0.00");
			((DataGridView)dGV2)[12, num2].Value = Strings.Format((object)num44, "0.00");
			((DataGridView)dGV2)[13, num2].Value = Strings.Format((object)num45, "0.00");
			((DataGridView)dGV2)[14, num2].Value = Strings.Format((object)num46, "0.00");
			((DataGridView)dGV2)[15, num2].Value = Strings.Format((object)num47, "0.00");
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.BlueViolet;
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
			((DataGridView)dGV2).Rows.Add();
			num2 = ((DataGridView)dGV2).Rows.Count - 1;
			((DataGridView)dGV2)[3, num2].Value = "Diff Purc - Sale : ";
			((DataGridView)dGV2)[4, num2].Value = Strings.Format((object)(num14 - num37), "0");
			((DataGridView)dGV2)[5, num2].Value = Strings.Format((object)(num15 - num38), "0.000");
			((DataGridView)dGV2)[7, num2].Value = Strings.Format((object)(num16 - num39), "0.000");
			((DataGridView)dGV2)[8, num2].Value = Strings.Format((object)(num17 - num40), "0.000");
			((DataGridView)dGV2)[9, num2].Value = Strings.Format((object)(num18 - num41), "0.00");
			((DataGridView)dGV2)[10, num2].Value = Strings.Format((object)(num19 - num42), "0.00");
			((DataGridView)dGV2)[11, num2].Value = Strings.Format((object)(num20 - num43), "0.00");
			((DataGridView)dGV2)[12, num2].Value = Strings.Format((object)(num21 - num44), "0.00");
			((DataGridView)dGV2)[13, num2].Value = Strings.Format((object)(num22 - num45), "0.00");
			((DataGridView)dGV2)[14, num2].Value = Strings.Format((object)(num23 - num46), "0.00");
			((DataGridView)dGV2)[15, num2].Value = Strings.Format((object)(num24 - num47), "0.00");
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.Blue;
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
			((DataGridView)dGV2).Rows.Add();
			num2 = ((DataGridView)dGV2).Rows.Count - 1;
			((DataGridView)dGV2)[3, num2].Value = "Total Exp : ";
			((DataGridView)dGV2)[12, num2].Value = Strings.Format((object)num50, "0.00");
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.ForeColor = Color.MediumVioletRed;
			((DataGridView)DGV).Rows[num2].DefaultCellStyle.Font = new Font("Segoe UI", 9f, (FontStyle)1);
			dGV2 = null;
		}
	}

	private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
	{
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
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if (((uint)(columnIndex - 17) <= 4u || (uint)(columnIndex - 23) <= 2u) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 113:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00a7;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 113;
				continue;
			}
			break;
			IL_00a7:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void RP_DAY_WORK_Load(object sender, EventArgs e)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_07f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fb: Expected O, but got Unknown
		//IL_086b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0870: Unknown result type (might be due to invalid IL or missing references)
		//IL_087a: Expected O, but got Unknown
		//IL_0902: Unknown result type (might be due to invalid IL or missing references)
		//IL_0907: Unknown result type (might be due to invalid IL or missing references)
		//IL_0911: Expected O, but got Unknown
		//IL_0983: Unknown result type (might be due to invalid IL or missing references)
		//IL_0988: Unknown result type (might be due to invalid IL or missing references)
		//IL_098e: Expected O, but got Unknown
		//IL_0a40: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a45: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a4f: Expected O, but got Unknown
		//IL_0a6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a73: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a7d: Expected O, but got Unknown
		//IL_0a9c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aa1: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aab: Expected O, but got Unknown
		//IL_0b2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3c: Expected O, but got Unknown
		//IL_0b5b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Expected O, but got Unknown
		//IL_0b89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b8e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
		{
			Cr.Connect = DC_Main.CrConnect;
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
				DataGridViewX dGV = DGV;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj9 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj10 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				ComboBox obj12 = cboUser;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj14 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj15 = lblBook;
				object? obj16 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj15).ForeColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj17 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj18 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj19 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				ComboBox obj20 = cboUser;
				object? obj21 = colorConverter.ConvertFromString("Cornsilk");
				obj20.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)tAcCode).Font.Size * (1.0 + num2));
				Font font = ((Control)tAcCode).Font;
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
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
				}
			}
			cboUser.Items.Clear();
			DC_Main.RsQry = "SELECT LOGIN_NAME FROM LOGIN_MAST WHERE CO_CODE = '01' GROUP BY LOGIN_NAME ORDER BY LOGIN_NAME ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
			cboUser.Items.Clear();
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboUser.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
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
			CLEAR_DATA();
			CurActCtrl = (Control)(object)mFromDt;
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
		mFromDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		((Control)mFromDt).Focus();
	}

	private void RP_DAY_WORK_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((Control)DGV_DETL).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_DAY_WORK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_DAY_WORK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_DAY_WORK_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_DAY_WORK_Closed(object sender, EventArgs e)
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

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0208: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tAcCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				if (Operators.CompareString(DC_Main.MsAllBranchAcShow, "Y", false) == 0)
				{
					DC_Main.RsQry = "SELECT A.AC_NAME As AcNameL,A.AC_CODE As AcCodeL,B.AC_GR_NAME AS GroupL,A.AC_AREA As AreaL,A.AC_ADD1 As AddressL,A.AC_CITY As CityL,A.AC_MOBILE As MobileL FROM AC_MAST AS A LEFT JOIN AC_GROUP AS B ON A.CO_CODE = B.CO_CODE AND A.AC_GR = B.AC_GR WHERE A.CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY A.LC_CODE,A.AC_NAME";
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
						tAcCode.Text = DC_Main.ColValue[1];
						tAcName.Text = DC_Main.ColValue[0];
					}
					((Control)tAcCode).Focus();
				}
			}
			else
			{
				tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[25].Value), (object)""), (object)"' "));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (dataTable.Rows.Count <= 0)
		{
			return;
		}
		DC_Main.CurBook = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["CO_BOOK"], (object)""));
		DC_Main.CurBookName = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_NAME"], (object)""));
		DC_Main.CurBookType = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_TYPE"], (object)""));
		DC_Main.CurBookItm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["ITM_TYPE"], (object)""));
		DC_Main.CurBookMain = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MAIN_BOOK"], (object)""));
		DC_Main.CurBookSname = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_SNAME"], (object)""));
		DC_Main.CurBookInOut = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["BOOK_INOUT"], (object)""));
		DC_Main.MsUserRightForm = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["MENU_NAME"], (object)""));
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[2].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsSalesWithHmTax, "Y", false) == 0)
			{
				TR_SALE_HM tR_SALE_HM = new TR_SALE_HM();
				((Form)tR_SALE_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_HM).Show();
				((Control)tR_SALE_HM).Focus();
			}
			else
			{
				TR_SALE tR_SALE = new TR_SALE();
				((Form)tR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE).Show();
				((Control)tR_SALE).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURCHASE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MsPurcWithHmTax, "Y", false) == 0)
			{
				TR_PURC_HM tR_PURC_HM = new TR_PURC_HM();
				((Form)tR_PURC_HM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC_HM).Show();
				((Control)tR_PURC_HM).Focus();
			}
			else
			{
				TR_PURC tR_PURC = new TR_PURC();
				((Form)tR_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_PURC).Show();
				((Control)tR_PURC).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE).Show();
				((Control)tR_SALE_RTN_UAE).Focus();
			}
			else
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B SALES", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE).Show();
			((Control)tR_PR_SL_UAE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "B2B PURC", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE2 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE2).Show();
			((Control)tR_PR_SL_UAE2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "HEDGING FIX", false) == 0)
		{
			TR_PR_SL_HEDG tR_PR_SL_HEDG = new TR_PR_SL_HEDG();
			((Form)tR_PR_SL_HEDG).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_HEDG).Show();
			((Control)tR_PR_SL_HEDG).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH REC", false) == 0)
		{
			TR_CASH tR_CASH = new TR_CASH();
			((Form)tR_CASH).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH).Show();
			((Control)tR_CASH).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CASH PAY", false) == 0)
		{
			TR_CASH tR_CASH2 = new TR_CASH();
			((Form)tR_CASH2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH2).Show();
			((Control)tR_CASH2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK REC", false) == 0)
		{
			TR_CASH tR_CASH3 = new TR_CASH();
			((Form)tR_CASH3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH3).Show();
			((Control)tR_CASH3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BANK PAY", false) == 0)
		{
			TR_CASH tR_CASH4 = new TR_CASH();
			((Form)tR_CASH4).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CASH4).Show();
			((Control)tR_CASH4).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CONTRA", false) == 0)
		{
			TR_CONTRA tR_CONTRA = new TR_CONTRA();
			((Form)tR_CONTRA).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA).Show();
			((Control)tR_CONTRA).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE JV", false) == 0)
		{
			TR_CONTRA tR_CONTRA2 = new TR_CONTRA();
			((Form)tR_CONTRA2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CONTRA2).Show();
			((Control)tR_CONTRA2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ORDER CANCEL", false) == 0)
		{
			TR_SL_ORD_ADJ tR_SL_ORD_ADJ = new TR_SL_ORD_ADJ();
			((Form)tR_SL_ORD_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_ORD_ADJ).Show();
			((Control)tR_SL_ORD_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "MEMB ENTRY", false) == 0)
		{
			TR_MEMB_ENT tR_MEMB_ENT = new TR_MEMB_ENT();
			((Form)tR_MEMB_ENT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ENT).Show();
			((Control)tR_MEMB_ENT).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "MEMB ADJUST", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MEMB GOLD ADJ", false) == 0))
		{
			TR_MEMB_ADJ tR_MEMB_ADJ = new TR_MEMB_ADJ();
			((Form)tR_MEMB_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MEMB_ADJ).Show();
			((Control)tR_MEMB_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN ISSUE", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "DHIRAN RECEIVED", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "INTREST RECIVED", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LABOUR WORK", false) == 0)
		{
			TR_SALE_LBR tR_SALE_LBR = new TR_SALE_LBR();
			((Form)tR_SALE_LBR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_LBR).Show();
			((Control)tR_SALE_LBR).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "SALES RETURNE", false) == 0)
		{
			if (Operators.CompareString(DC_Main.MCo_SName, "UAE", false) == 0)
			{
				TR_SALE_RTN_UAE tR_SALE_RTN_UAE2 = new TR_SALE_RTN_UAE();
				((Form)tR_SALE_RTN_UAE2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN_UAE2).Show();
				((Control)tR_SALE_RTN_UAE2).Focus();
			}
			else
			{
				TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
				((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_SALE_RTN).Show();
				((Control)tR_SALE_RTN).Focus();
			}
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU2 = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU2).Show();
			((Control)tR_DHRN_ISU2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC2 = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC2).Show();
			((Control)tR_DHRN_INTREC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC2 = new TR_DHRN_REC();
			((Form)tR_DHRN_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC2).Show();
			((Control)tR_DHRN_REC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OLD ITEM SALES", false) == 0)
		{
			TR_PURC tR_PURC3 = new TR_PURC();
			((Form)tR_PURC3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC3).Show();
			((Control)tR_PURC3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH EXP", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC = new TR_OTH_PURC();
			((Form)tR_OTH_PURC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC).Show();
			((Control)tR_OTH_PURC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH INC", false) == 0)
		{
			TR_OTH_PURC tR_OTH_PURC2 = new TR_OTH_PURC();
			((Form)tR_OTH_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_PURC2).Show();
			((Control)tR_OTH_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BILL REC", false) == 0)
		{
			TR_BILL_TO tR_BILL_TO = new TR_BILL_TO();
			((Form)tR_BILL_TO).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BILL_TO).Show();
			((Control)tR_BILL_TO).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG TRFR", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "CUSTREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "KRREP RECEIPT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CUSTREP ISSUE", false) == 0))
		{
			TR_REP_REC tR_REP_REC = new TR_REP_REC();
			((Form)tR_REP_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_REP_REC).Show();
			((Control)tR_REP_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CON PUR", false) == 0)
		{
			TR_PR_SL_UAE tR_PR_SL_UAE3 = new TR_PR_SL_UAE();
			((Form)tR_PR_SL_UAE3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PR_SL_UAE3).Show();
			((Control)tR_PR_SL_UAE3).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "EMP JV", false) == 0)
		{
			TR_EMP_JV tR_EMP_JV = new TR_EMP_JV();
			((Form)tR_EMP_JV).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_EMP_JV).Show();
			((Control)tR_EMP_JV).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "VP PARCEL", false) == 0)
		{
			TR_VP tR_VP = new TR_VP();
			((Form)tR_VP).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_VP).Show();
			((Control)tR_VP).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "CARD ADJUST", false) == 0)
		{
			TR_CARD_REC tR_CARD_REC = new TR_CARD_REC();
			((Form)tR_CARD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_CARD_REC).Show();
			((Control)tR_CARD_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "BUL WH SALE", false) == 0)
		{
			TR_BUL_SALE tR_BUL_SALE = new TR_BUL_SALE();
			((Form)tR_BUL_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_BUL_SALE).Show();
			((Control)tR_BUL_SALE).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "E INVOICE", false) == 0)
		{
			TR_SL_EBILL tR_SL_EBILL = new TR_SL_EBILL();
			((Form)tR_SL_EBILL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_EBILL).Show();
			((Control)tR_SL_EBILL).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FTNG REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CHEDIYA REC", false) == 0))
		{
			TR_JDT_REC tR_JDT_REC = new TR_JDT_REC();
			((Form)tR_JDT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_JDT_REC).Show();
			((Control)tR_JDT_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "OTH COMM", false) == 0)
		{
			TR_OTH_COMM tR_OTH_COMM = new TR_OTH_COMM();
			((Form)tR_OTH_COMM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_OTH_COMM).Show();
			((Control)tR_OTH_COMM).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG SPLIT", false) == 0)
		{
			TR_TAG_SPLIT tR_TAG_SPLIT = new TR_TAG_SPLIT();
			((Form)tR_TAG_SPLIT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_SPLIT).Show();
			((Control)tR_TAG_SPLIT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TOUR SALES", false) == 0)
		{
			TR_TOUR_SALE tR_TOUR_SALE = new TR_TOUR_SALE();
			((Form)tR_TOUR_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TOUR_SALE).Show();
			((Control)tR_TOUR_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "AMT OUT", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "AMT IN", false) == 0))
		{
			TR_LOCT_AMT tR_LOCT_AMT = new TR_LOCT_AMT();
			((Form)tR_LOCT_AMT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LOCT_AMT).Show();
			((Control)tR_LOCT_AMT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG PURCHASE", false) == 0)
		{
			TR_PURC_HM tR_PURC_HM2 = new TR_PURC_HM();
			((Form)tR_PURC_HM2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC_HM2).Show();
			((Control)tR_PURC_HM2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "ITM LOT", false) == 0)
		{
			TR_ITM_LOT tR_ITM_LOT = new TR_ITM_LOT();
			((Form)tR_ITM_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_ITM_LOT).Show();
			((Control)tR_ITM_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LD ADJUST", false) == 0)
		{
			TR_LEDR_ADJ tR_LEDR_ADJ = new TR_LEDR_ADJ();
			((Form)tR_LEDR_ADJ).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_LEDR_ADJ).Show();
			((Control)tR_LEDR_ADJ).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "WH RTN", false) == 0)
		{
			TR_WH_SALE_RTN tR_WH_SALE_RTN = new TR_WH_SALE_RTN();
			((Form)tR_WH_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE_RTN).Show();
			((Control)tR_WH_SALE_RTN).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FINE PURC", false) == 0))
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "ITEM SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "ITEM PURC", false) == 0))
		{
			TR_SL_PR_ITEM tR_SL_PR_ITEM = new TR_SL_PR_ITEM();
			((Form)tR_SL_PR_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SL_PR_ITEM).Show();
			((Control)tR_SL_PR_ITEM).Focus();
		}
	}

	private void mToDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mToDt;
			DC_Main.SetDate(ref MsDate);
			mToDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void cboItmType_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DGV_VCH_SUMM();
		}
	}

	private void BtnList_Click(object sender, EventArgs e)
	{
		DGV_VCH_SUMM();
	}

	private void mFromDt_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			MaskedTextBox MsDate = mFromDt;
			DC_Main.SetDate(ref MsDate);
			mFromDt = MsDate;
			if (!DC_Main.RongDate)
			{
				SendKeys.Send("{tab}");
			}
		}
	}

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void cboUser_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
	}

	private void tBookCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_012a: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		if (Operators.CompareString(tBookCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = "Select * From BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '" + tBookCode.Text + "'";
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Tbl.Rows.Count == 0)
			{
				DC_Main.RsQry = "SELECT A.BOOK_NAME As BookNameL,A.CO_BOOK As BookL FROM BOOK_DATA AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY A.BOOK_NAME";
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
						tBookCode.Text = DC_Main.ColValue[1];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				SendKeys.Send("{tab}");
			}
		}
		else
		{
			SendKeys.Send("{tab}");
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
	}

	private void btnExel_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		object objectValue = RuntimeHelpers.GetObjectValue(Interaction.CreateObject("Excel.Application", ""));
		object objectValue2 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Add", new object[0], (string[])null, (Type[])null, (bool[])null));
		object objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { 1 }, (string[])null, (Type[])null, (bool[])null));
		objectValue3 = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(objectValue2, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
		NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
		checked
		{
			int num = ((DataGridView)DGV).ColumnCount - 1;
			for (int i = 0; i <= num; i++)
			{
				NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
				{
					1,
					i + 1,
					((DataGridView)DGV).Columns[i].HeaderText
				}, (string[])null, (Type[])null);
			}
			int num2 = 0;
			int num3 = ((DataGridView)DGV).RowCount - 1;
			DC_Main.i = 0;
			while (DC_Main.i <= num3)
			{
				num2++;
				int num4 = ((DataGridView)DGV).ColumnCount - 1;
				for (int j = 0; j <= num4; j++)
				{
					if (((DataGridView)DGV)[j, DC_Main.i].Value != null)
					{
						NewLateBinding.LateSet(objectValue3, (Type)null, "Cells", new object[3]
						{
							num2 + 2,
							j + 1,
							((DataGridView)DGV)[j, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
					}
				}
				DC_Main.i++;
			}
			ColorConverter colorConverter = new ColorConverter();
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateCall(NewLateBinding.LateGet(objectValue3, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
			NewLateBinding.LateSet(objectValue, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
			Cursor.Current = Cursors.Default;
			objectValue3 = null;
			objectValue2 = null;
			objectValue = null;
			GC.Collect();
		}
	}

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}
}
