using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AxCrystal;
using Crystal;
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
public class RP_PHY_STOCK : Form
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
	[AccessedThroughProperty("BtnSave")]
	private SimpleButton _BtnSave;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnPrint")]
	private SimpleButton _BtnPrint;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnAll")]
	private QButton _BtnAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnDiff")]
	private QButton _BtnDiff;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboProduct")]
	private ComboBox _cboProduct;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tItCode")]
	private TextBox _tItCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tCounterCode")]
	private TextBox _tCounterCode;

	private string EntryMode;

	private Control CurActCtrl;

	private double ColCon;

	private bool DgvLoad;

	private string PhyRptType;

	private string RsQryOp;

	private string RsQryIn;

	private string RsQryOut;

	private DataTable RsIn;

	private DataTable RsOut;

	private DataTable RsPhyStk;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string[] AryPrCode;

	private string[] AryGrCode;

	private const int cSrNo = 0;

	private const int cTagNo = 1;

	private const int cItemName = 2;

	private const int cSize = 3;

	private const int cCntr = 4;

	private const int cPcs = 5;

	private const int cGrWt = 6;

	private const int cMrp = 7;

	private const int cCompQty = 8;

	private const int cOutQty = 9;

	private const int cAprQty = 10;

	private const int cTourQty = 11;

	private const int cPhyQty = 12;

	private const int cDifQty = 13;

	private const int cDifWt = 14;

	private const int cVchSrNo = 15;

	private const int cNetWt = 16;

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
	[AccessedThroughProperty("cboItemTyp")]
	private virtual ComboBox _cboItemTyp;

	internal virtual ComboBox cboItemTyp
	{
		get
		{
			return _cboItemTyp;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboItemTyp = value;
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
	[AccessedThroughProperty("Panel1")]
	private virtual Panel _Panel1;

	internal virtual Panel Panel1
	{
		get
		{
			return _Panel1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_Panel1 = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboStockType")]
	private virtual ComboBox _cboStockType;

	internal virtual ComboBox cboStockType
	{
		get
		{
			return _cboStockType;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboStockType = value;
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

	internal virtual QButton BtnAll
	{
		[CompilerGenerated]
		get
		{
			return _BtnAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnAll_Click;
			QButton val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnAll = value;
			val = _BtnAll;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
		}
	}

	internal virtual QButton BtnDiff
	{
		[CompilerGenerated]
		get
		{
			return _BtnDiff;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnDiff_Click;
			QButton val = _BtnDiff;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnDiff = value;
			val = _BtnDiff;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
			}
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

	internal virtual ComboBox cboProduct
	{
		[CompilerGenerated]
		get
		{
			return _cboProduct;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboProduct_KeyDown);
			ComboBox val2 = _cboProduct;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_cboProduct = value;
			val2 = _cboProduct;
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
	[AccessedThroughProperty("cboGroup")]
	private virtual ComboBox _cboGroup;

	internal virtual ComboBox cboGroup
	{
		get
		{
			return _cboGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboGroup = value;
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

	internal virtual TextBox tItCode
	{
		[CompilerGenerated]
		get
		{
			return _tItCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tItCode_KeyDown);
			TextBox val2 = _tItCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
			}
			_tItCode = value;
			val2 = _tItCode;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tTagNo")]
	private virtual TextBox _tTagNo;

	internal virtual TextBox tTagNo
	{
		get
		{
			return _tTagNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tTagNo = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboSize")]
	private virtual ComboBox _cboSize;

	internal virtual ComboBox cboSize
	{
		get
		{
			return _cboSize;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboSize = value;
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

	internal virtual TextBox tCounterCode
	{
		[CompilerGenerated]
		get
		{
			return _tCounterCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(tCounterCode_KeyDown);
			EventHandler eventHandler = tCounterCode_TextChanged;
			TextBox val2 = _tCounterCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).TextChanged -= eventHandler;
			}
			_tCounterCode = value;
			val2 = _tCounterCode;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).TextChanged += eventHandler;
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

	public int newindex { get; set; }

	public RP_PHY_STOCK()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_PHY_STOCK_Load;
		((Form)this).Deactivate += RP_PHY_STOCK_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_PHY_STOCK_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_PHY_STOCK_KeyDown);
		((Form)this).Activated += RP_PHY_STOCK_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
		DgvLoad = false;
		RsQryOp = "";
		RsQryIn = "";
		RsQryOut = "";
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
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Expected O, but got Unknown
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0174: Expected O, but got Unknown
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Expected O, but got Unknown
		//IL_0182: Unknown result type (might be due to invalid IL or missing references)
		//IL_018c: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0198: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Expected O, but got Unknown
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b0: Expected O, but got Unknown
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0315: Unknown result type (might be due to invalid IL or missing references)
		//IL_031f: Expected O, but got Unknown
		//IL_0382: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Expected O, but got Unknown
		//IL_0435: Unknown result type (might be due to invalid IL or missing references)
		//IL_043f: Expected O, but got Unknown
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0554: Expected O, but got Unknown
		//IL_0671: Unknown result type (might be due to invalid IL or missing references)
		//IL_067b: Expected O, but got Unknown
		//IL_06de: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e8: Expected O, but got Unknown
		//IL_0791: Unknown result type (might be due to invalid IL or missing references)
		//IL_079b: Expected O, but got Unknown
		//IL_07fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0808: Expected O, but got Unknown
		//IL_08df: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e9: Expected O, but got Unknown
		//IL_0957: Unknown result type (might be due to invalid IL or missing references)
		//IL_0961: Expected O, but got Unknown
		//IL_0a1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a29: Expected O, but got Unknown
		//IL_0a92: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a9c: Expected O, but got Unknown
		//IL_0bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bf4: Expected O, but got Unknown
		//IL_0c89: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c93: Expected O, but got Unknown
		//IL_0d11: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d1b: Expected O, but got Unknown
		//IL_0dfd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e07: Expected O, but got Unknown
		//IL_0e70: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e7a: Expected O, but got Unknown
		//IL_0f28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f32: Expected O, but got Unknown
		//IL_0f9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fa5: Expected O, but got Unknown
		//IL_103c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1046: Expected O, but got Unknown
		//IL_1258: Unknown result type (might be due to invalid IL or missing references)
		//IL_127c: Unknown result type (might be due to invalid IL or missing references)
		//IL_12a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_12f7: Expected O, but got Unknown
		//IL_131a: Unknown result type (might be due to invalid IL or missing references)
		//IL_157d: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_15e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1612: Unknown result type (might be due to invalid IL or missing references)
		//IL_161c: Expected O, but got Unknown
		//IL_163f: Unknown result type (might be due to invalid IL or missing references)
		//IL_16b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c0: Expected O, but got Unknown
		//IL_1754: Unknown result type (might be due to invalid IL or missing references)
		//IL_175e: Expected O, but got Unknown
		//IL_17de: Unknown result type (might be due to invalid IL or missing references)
		//IL_17e8: Expected O, but got Unknown
		//IL_187f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1889: Expected O, but got Unknown
		//IL_196b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Expected O, but got Unknown
		//IL_19e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ec: Expected O, but got Unknown
		//IL_1ac7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ad1: Expected O, but got Unknown
		//IL_1b41: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b4b: Expected O, but got Unknown
		//IL_1bf9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c03: Expected O, but got Unknown
		//IL_1c70: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c7a: Expected O, but got Unknown
		//IL_1d17: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d21: Expected O, but got Unknown
		//IL_1dbe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1dc8: Expected O, but got Unknown
		//IL_1e81: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e8b: Expected O, but got Unknown
		//IL_1ef8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f02: Expected O, but got Unknown
		//IL_1fb0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1fba: Expected O, but got Unknown
		//IL_2027: Unknown result type (might be due to invalid IL or missing references)
		//IL_2031: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_PHY_STOCK));
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
		Cr = new AxCrystalReport();
		lblBook = new Label();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		DGV = new DataGridViewX();
		cboStockType = new ComboBox();
		Label1 = new Label();
		BtnAll = new QButton();
		BtnDiff = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		Label4 = new Label();
		cboProduct = new ComboBox();
		Label5 = new Label();
		cboGroup = new ComboBox();
		Label6 = new Label();
		tItCode = new TextBox();
		Label7 = new Label();
		Label8 = new Label();
		tTagNo = new TextBox();
		cboSize = new ComboBox();
		Label9 = new Label();
		tCounterCode = new TextBox();
		Label10 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)DGV).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)Cr);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 12;
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
		((Control)BtnSave).TabIndex = 1;
		BtnSave.Text = "Excel";
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
		((Control)BtnPrint).TabIndex = 0;
		BtnPrint.Text = "Print";
		((BaseButton)BtnPrint).ToolTipAnchor = (ToolTipAnchor)1;
		((AxHost)Cr).Enabled = true;
		((Control)Cr).Location = new Point(793, 3);
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
		lblBook.Text = "Physical Stock Report";
		lblBook.TextAlign = (ContentAlignment)32;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(240, 77);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(109, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(152, 78);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Location = new Point(0, 114);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 452);
		((Control)Panel1).TabIndex = 110;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
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
		((Control)DGV).Location = new Point(11, 12);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
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
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV).Size = new Size(1160, 426);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 3;
		cboStockType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboStockType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStockType).FormattingEnabled = true;
		((Control)cboStockType).Location = new Point(240, 42);
		((Control)cboStockType).Name = "cboStockType";
		((Control)cboStockType).Size = new Size(109, 22);
		((Control)cboStockType).TabIndex = 4;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(152, 43);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(82, 20);
		((Control)Label1).TabIndex = 112;
		Label1.Text = "Stock Type";
		Label1.TextAlign = (ContentAlignment)64;
		BtnAll.Appearance.Shape = new QShape((QBaseShapeType)27);
		((QControl)BtnAll).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnAll).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAll).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnAll).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnAll).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnAll).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnAll).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAll).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnAll).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnAll).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnAll).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnAll).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnAll.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnAll.Image = null;
		((QControl)BtnAll).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnAll).Location = new Point(838, 81);
		((Control)BtnAll).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnAll).Name = "BtnAll";
		((Control)BtnAll).Size = new Size(143, 37);
		((Control)BtnAll).TabIndex = 5;
		BtnAll.Text = "&All";
		((QControl)BtnDiff).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnDiff).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDiff).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnDiff).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnDiff).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnDiff).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnDiff).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDiff).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnDiff).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnDiff).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnDiff).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnDiff).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnDiff).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnDiff).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnDiff.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDiff.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDiff.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDiff.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnDiff.Image = null;
		((QControl)BtnDiff).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnDiff).Location = new Point(1000, 81);
		((Control)BtnDiff).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnDiff).Name = "BtnDiff";
		((Control)BtnDiff).Size = new Size(143, 37);
		((Control)BtnDiff).TabIndex = 11;
		BtnDiff.Text = "Diff";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(70, 42);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(70, 77);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 43);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(52, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "From";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(12, 77);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(52, 20);
		((Control)Label4).TabIndex = 123;
		Label4.Text = "To";
		Label4.TextAlign = (ContentAlignment)64;
		cboProduct.AutoCompleteMode = (AutoCompleteMode)3;
		cboProduct.AutoCompleteSource = (AutoCompleteSource)256;
		cboProduct.BackColor = Color.FromArgb(255, 224, 192);
		cboProduct.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboProduct).Font = new Font("Tahoma", 9f);
		((ListControl)cboProduct).FormattingEnabled = true;
		((Control)cboProduct).Location = new Point(428, 43);
		((Control)cboProduct).Name = "cboProduct";
		((Control)cboProduct).Size = new Size(160, 22);
		((Control)cboProduct).TabIndex = 127;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(360, 43);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(61, 20);
		((Control)Label5).TabIndex = 128;
		Label5.Text = "Product";
		Label5.TextAlign = (ContentAlignment)64;
		cboGroup.AutoCompleteSource = (AutoCompleteSource)256;
		cboGroup.BackColor = Color.FromArgb(255, 224, 192);
		cboGroup.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboGroup).Font = new Font("Tahoma", 9f);
		((ListControl)cboGroup).FormattingEnabled = true;
		((Control)cboGroup).Location = new Point(428, 77);
		((Control)cboGroup).Name = "cboGroup";
		((Control)cboGroup).Size = new Size(160, 22);
		((Control)cboGroup).TabIndex = 129;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(360, 77);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(61, 20);
		((Control)Label6).TabIndex = 130;
		Label6.Text = "Group";
		Label6.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(663, 43);
		((TextBoxBase)tItCode).MaxLength = 3;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(82, 22);
		((Control)tItCode).TabIndex = 1182;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(599, 43);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(58, 20);
		((Control)Label7).TabIndex = 1181;
		Label7.Text = "ItCode";
		Label7.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(599, 79);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(57, 20);
		((Control)Label8).TabIndex = 1185;
		Label8.Text = "TagNo";
		Label8.TextAlign = (ContentAlignment)64;
		((Control)tTagNo).Font = new Font("Tahoma", 9f);
		((Control)tTagNo).Location = new Point(663, 79);
		((TextBoxBase)tTagNo).MaxLength = 15;
		((Control)tTagNo).Name = "tTagNo";
		((Control)tTagNo).Size = new Size(82, 22);
		((Control)tTagNo).TabIndex = 1184;
		cboSize.AutoCompleteMode = (AutoCompleteMode)3;
		cboSize.AutoCompleteSource = (AutoCompleteSource)256;
		cboSize.BackColor = Color.FromArgb(255, 224, 192);
		cboSize.DropDownStyle = (ComboBoxStyle)2;
		((Control)cboSize).Font = new Font("Tahoma", 9f);
		((ListControl)cboSize).FormattingEnabled = true;
		((Control)cboSize).Location = new Point(1044, 41);
		((Control)cboSize).Name = "cboSize";
		((Control)cboSize).Size = new Size(99, 22);
		((Control)cboSize).TabIndex = 1186;
		((Control)Label9).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label9).ForeColor = Color.Black;
		Label9.ImeMode = (ImeMode)0;
		((Control)Label9).Location = new Point(987, 42);
		((Control)Label9).Name = "Label9";
		((Control)Label9).Size = new Size(51, 20);
		((Control)Label9).TabIndex = 1187;
		Label9.Text = "Size";
		Label9.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tCounterCode).BackColor = Color.White;
		((Control)tCounterCode).Font = new Font("Tahoma", 9f);
		((Control)tCounterCode).Location = new Point(838, 43);
		((TextBoxBase)tCounterCode).MaxLength = 3;
		((Control)tCounterCode).Name = "tCounterCode";
		((Control)tCounterCode).Size = new Size(82, 22);
		((Control)tCounterCode).TabIndex = 1189;
		((Control)Label10).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label10).ForeColor = Color.Black;
		Label10.ImeMode = (ImeMode)0;
		((Control)Label10).Location = new Point(755, 44);
		((Control)Label10).Name = "Label10";
		((Control)Label10).Size = new Size(77, 20);
		((Control)Label10).TabIndex = 1188;
		Label10.Text = "Counter";
		Label10.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tCounterCode);
		((Control)this).Controls.Add((Control)(object)Label10);
		((Control)this).Controls.Add((Control)(object)cboSize);
		((Control)this).Controls.Add((Control)(object)Label9);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tTagNo);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)Label7);
		((Control)this).Controls.Add((Control)(object)cboGroup);
		((Control)this).Controls.Add((Control)(object)Label6);
		((Control)this).Controls.Add((Control)(object)cboProduct);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)cboStockType);
		((Control)this).Controls.Add((Control)(object)Label1);
		((Control)this).Controls.Add((Control)(object)Panel1);
		((Control)this).Controls.Add((Control)(object)cboItemTyp);
		((Control)this).Controls.Add((Control)(object)Label3);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)BtnAll);
		((Control)this).Controls.Add((Control)(object)BtnDiff);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_PHY_STOCK";
		((Form)this).Text = "Physical Stock";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)DGV).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_PHY_STOCK_Load(object sender, EventArgs e)
	{
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Expected O, but got Unknown
		UserEdit = "Y";
		UserDelete = "Y";
		UserPrint = "Y";
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
			foreach (object control3 in ((Control)Panel1).Controls)
			{
				object objectValue2 = RuntimeHelpers.GetObjectValue(control3);
				object obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue2;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue2, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
			}
			((Form)this).ClientSize = new Size((int)Math.Round(DC_Main.MainPcW), (int)Math.Round(DC_Main.MainPcH));
			((Control)this).Dock = (DockStyle)5;
			ColorConverter colorConverter = new ColorConverter();
			if (DC_Main.MsCoTheme == 2)
			{
				object? obj2 = colorConverter.ConvertFromString("Gainsboro");
				((Form)this).BackColor = ((obj2 != null) ? ((Color)obj2) : default(Color));
				Label obj3 = lblBook;
				object? obj4 = colorConverter.ConvertFromString("MistyRose");
				((Control)obj3).BackColor = ((obj4 != null) ? ((Color)obj4) : default(Color));
				Label obj5 = lblBook;
				object? obj6 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj5).ForeColor = ((obj6 != null) ? ((Color)obj6) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewX dGV = DGV;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj10 = cboItemTyp;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				obj10.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				ComboBox obj12 = cboStockType;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj14 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV2 = DGV;
				object? obj15 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				Panel panel = Panel1;
				object? obj17 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				ComboBox obj18 = cboItemTyp;
				object? obj19 = colorConverter.ConvertFromString("233, 235, 240");
				obj18.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				ComboBox obj20 = cboStockType;
				object? obj21 = colorConverter.ConvertFromString("233, 235, 240");
				obj20.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj22 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj23 = lblBook;
				object? obj24 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj23).ForeColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj25 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				DataGridViewX dGV3 = DGV;
				object? obj26 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj27 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				Panel panel2 = Panel1;
				object? obj28 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				cboStockType.BackColor = Color.Cornsilk;
			}
			cboItemTyp.Items.Add((object)"Gold");
			cboItemTyp.Items.Add((object)"Silver");
			cboItemTyp.Items.Add((object)"Diamond");
			cboItemTyp.Items.Add((object)"Real Stone");
			cboItemTyp.Items.Add((object)"Emitation");
			cboItemTyp.Items.Add((object)"Other");
			cboItemTyp.Items.Add((object)"Platinum");
			if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
			{
				cboItemTyp.SelectedIndex = 0;
			}
			else
			{
				cboItemTyp.SelectedIndex = 1;
			}
			cboStockType.Items.Add((object)"All");
			cboStockType.Items.Add((object)"Tag");
			cboStockType.Items.Add((object)"Item");
			cboStockType.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT PR_NAME As Product,PR_CODE as Code FROM PRODUCT_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY PR_NAME";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryPrCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryPrCode[DC_Main.X] = "";
				cboProduct.Items.Add((object)"");
				int num3 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num3)
				{
					cboProduct.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Product"], (object)""));
					AryPrCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboProduct.Items.Add((object)"");
				AryPrCode[DC_Main.X] = "";
			}
			cboProduct.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT GR_NAME As GrName,GR_CODE as Code FROM GROUP_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "'  ORDER BY GR_NAME";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryGrCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryGrCode[DC_Main.X] = "";
				cboGroup.Items.Add((object)"");
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
				{
					cboGroup.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["GrName"], (object)""));
					AryGrCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["Code"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboGroup.Items.Add((object)"");
				AryGrCode[DC_Main.X] = "";
			}
			cboGroup.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT ITM_SIZE FROM BAR_DETL  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND ITM_SIZE <> '' GROUP BY ITM_SIZE  ORDER BY ITM_SIZE";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				cboSize.Items.Add((object)"");
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					cboSize.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["ITM_SIZE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboSize.Items.Add((object)"");
			}
			cboSize.SelectedIndex = 0;
			DC_Main.RsQry = "SELECT VCH_DATE FROM BAR_CAN_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' and LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '077' GROUP BY VCH_DATE ORDER BY VCH_DATE ";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count == 0)
			{
				mFromDt.Text = Strings.Format((object)DateAndTime.Now, "dd/MM/yyyy");
			}
			else
			{
				mFromDt.Text = Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["VCH_DATE"]), "dd/MM/yyyy");
			}
			mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
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
		mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		if (Operators.CompareString(DC_Main.MsMetalType, "G", false) == 0)
		{
			cboItemTyp.SelectedIndex = 0;
		}
		else
		{
			cboItemTyp.SelectedIndex = 1;
		}
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		((Form)this).Close();
	}

	private void RP_PHY_STOCK_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_PHY_STOCK_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_PHY_STOCK_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Invalid comparison between Unknown and I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode != 65)
		{
			if ((int)keyCode == 68)
			{
				BtnDiff_Click(BtnDiff, new EventArgs());
				((Control)BtnDiff).Focus();
			}
		}
		else
		{
			BtnAll_Click(BtnAll, new EventArgs());
			((Control)BtnAll).Focus();
		}
		if ((int)e.KeyCode == 27)
		{
			((Form)this).Close();
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV).Focus();
		}
	}

	private void Stk_Insert()
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT WHERE CO_CODE = '" + DC_Main.MCo_code + "'");
		DataGridViewX dGV = DGV;
		checked
		{
			int num = ((DataGridView)dGV).RowCount - 1;
			DC_Main.X = 0;
			while (DC_Main.X <= num)
			{
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("INSERT INTO TAG_STOCK_PRINT(CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,ITM_SIGN,DESIGN_NO,ITM_SIZE,TBL_CODE,ITM_QTY,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,DATA_TYPE)  SELECT CO_CODE,LC_CODE,CO_YEAR,CO_BOOK,VCH_NO,SR_NO,VCH_DATE,VCH_TYPE,INOUT_TYPE,BOOK_NAME,  IT_CODE,TAG_NO,VCH_SRNO,'+',DESIGN_NO,ITM_SIZE,TBL_CODE,1,ITM_PCS,ITM_GWT,ITM_NWT,ITM_FINE,'A'  FROM BAR_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'   AND TAG_NO ='"), ((DataGridView)dGV)[1, DC_Main.X].Value), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[15, DC_Main.X].Value))), (object)" "));
				DC_Main.ExeQuteDc(DC_Main.RsQry);
				DC_Main.X++;
			}
			dGV = null;
			DC_Main.RsQry = "SELECT * FROM TAG_STOCK_PRINT";
			DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Stk_Insert();
		string text = ((Operators.CompareString(PhyRptType, "Diff", false) != 0) ? "Physical Stock Report " : "Physical Stock Differenc Report ");
		if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
		{
			string rptName = "TagStkRpt";
			DC_Main.MsRptTitel = "RptTitel";
			DC_Main.MsRptTitelStr = "'" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			DC_Main.MsWappPrintType = "All";
			DC_Main.RptName = rptName;
			DC_Main.RptFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			UT_REPORT uT_REPORT = new UT_REPORT();
			((Control)uT_REPORT).Show();
			((Control)uT_REPORT).Focus();
		}
		else
		{
			Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\TagStkRpt.RPT";
			Cr.SelectionFormula = "{TAG_STOCK_PRINT.CO_CODE} = '" + DC_Main.MCo_code + "' AND {TAG_STOCK_PRINT.LC_CODE} = '" + DC_Main.MLc_code + "' AND {TAG_STOCK_PRINT.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {TAG_STOCK_PRINT.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
			Cr.Action = -1;
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_PHY_STOCK_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void RP_LEDR_Closed(object sender, EventArgs e)
	{
		DC_Main.ExeQuteDc("DELETE FROM TAG_STOCK_PRINT ");
		if (((ReadOnlyCollectionBase)(object)((WindowsFormsApplicationBase)MyProject.Application).OpenForms).Count <= 3)
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = true;
		}
		else
		{
			((Control)MyProject.Forms.MDI_FORM.PanelImage).Visible = false;
		}
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV).DataSource = null;
		((DataGridView)DGV).ClearSelection();
		((DataGridView)DGV).Rows.Clear();
		((DataGridView)DGV).Columns.Clear();
		((Control)DGV).Refresh();
	}

	private void DGV_FILL()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0074: Expected O, but got Unknown
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Expected O, but got Unknown
		//IL_00af: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		DGV_CLEAR();
		((DataGridView)DGV).MultiSelect = false;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV).AutoGenerateColumns = false;
		((DataGridView)DGV).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "cTagNo");
			((DataGridView)DGV).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "It Name");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Size");
			((DataGridView)DGV).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Cntr");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "Pcs");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "GrWt");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Mrp");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "Stk");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Out");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Apr");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Tur");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Phy");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "Diff");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "DiffWt");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "VchSrNo");
			((DataGridView)DGV).Columns[15].Visible = false;
			((DataGridView)DGV).Columns.Add("", "NetWt");
			((DataGridView)DGV).Columns[16].Visible = false;
			if (Operators.CompareString(PhyRptType, "Diff", false) == 0)
			{
				Dgv_Diff_Stock();
			}
			else
			{
				Dgv_Net_Stock();
			}
		}
	}

	private void Stock_Summ()
	{
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
		{
			RsQryOp = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT ,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE,C.APR_ISU,C.EMP_ISU, SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE - 1 END) AS OpPcs  from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL AS C ON A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO )LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.TAG_NO <> '' AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "));
		}
		else
		{
			RsQryOp = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT ,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE,C.APR_ISU,C.EMP_ISU, SUM(CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE - 1 END) AS OpPcs  from ((MAIN_STOCK AS A  INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO )LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.TAG_NO <> 'N' AND A.TAG_NO <> '' AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "));
		}
		ref string rsQryOp = ref RsQryOp;
		rsQryOp = rsQryOp + "AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			ref string rsQryOp2 = ref RsQryOp;
			rsQryOp2 = rsQryOp2 + "AND A.IT_CODE = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboSize.Text, "", false) != 0)
		{
			ref string rsQryOp3 = ref RsQryOp;
			rsQryOp3 = rsQryOp3 + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			ref string rsQryOp4 = ref RsQryOp;
			rsQryOp4 = rsQryOp4 + "AND A.TAG_NO = '" + tTagNo.Text + "'";
		}
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			ref string rsQryOp5 = ref RsQryOp;
			rsQryOp5 = rsQryOp5 + "AND B.PR_CODE = '" + AryPrCode[cboProduct.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboGroup.Text, "", false) != 0)
		{
			ref string rsQryOp6 = ref RsQryOp;
			rsQryOp6 = rsQryOp6 + "AND B.GR_CODE = '" + AryGrCode[cboGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(tCounterCode.Text, "", false) != 0)
		{
			ref string rsQryOp7 = ref RsQryOp;
			rsQryOp7 = rsQryOp7 + "AND C.TBL_CODE = '" + tCounterCode.Text + "'";
		}
		RsQryOp += " GROUP BY A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE,C.APR_ISU,C.EMP_ISU ";
		RsQryOp += " HAVING SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.VCH_SRNO ELSE - A.VCH_SRNO END) > 0 ORDER BY A.TAG_NO";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(RsQryOp);
		RsQryIn = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT ,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE,C.APR_ISU,C.EMP_ISU, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS InPcs from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE  AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO )LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.CO_BOOK <> '019' AND C.APR_ISU = 'N'  AND A.TAG_NO <> 'N' AND A.TAG_NO <> '' "));
		ref string rsQryIn = ref RsQryIn;
		rsQryIn = rsQryIn + "AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			ref string rsQryOp8 = ref RsQryOp;
			rsQryOp8 = rsQryOp8 + "AND A.IT_CODE = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboSize.Text, "", false) != 0)
		{
			ref string rsQryOp9 = ref RsQryOp;
			rsQryOp9 = rsQryOp9 + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			ref string rsQryOp10 = ref RsQryOp;
			rsQryOp10 = rsQryOp10 + "AND A.TAG_NO = '" + tTagNo.Text + "'";
		}
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			ref string rsQryIn2 = ref RsQryIn;
			rsQryIn2 = rsQryIn2 + "AND B.PR_CODE = '" + AryPrCode[cboProduct.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboGroup.Text, "", false) != 0)
		{
			ref string rsQryIn3 = ref RsQryIn;
			rsQryIn3 = rsQryIn3 + "AND B.GR_CODE = '" + AryGrCode[cboGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(tCounterCode.Text, "", false) != 0)
		{
			ref string rsQryIn4 = ref RsQryIn;
			rsQryIn4 = rsQryIn4 + "AND C.TBL_CODE = '" + tCounterCode.Text + "'";
		}
		RsQryIn += " GROUP BY A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE,C.APR_ISU,C.EMP_ISU ";
		ref string rsQryIn5 = ref RsQryIn;
		ref string reference = ref rsQryIn5;
		rsQryIn5 = reference + " HAVING SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.ITM_SIGN = '+' THEN 1 ELSE 0 END) ELSE 0 END) <> 0 ";
		RsIn = DC_Main.OpenRecordSetDc(RsQryIn);
		if (Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0)
		{
			RsQryOut = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT ,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) AS OutPcs from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL AS C ON A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO )LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE "), Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"' AND A.CO_BOOK <> '018' AND C.APR_ISU = 'N'  AND A.TAG_NO <> 'N' AND A.TAG_NO <> '' "));
		}
		else
		{
			RsQryOut = "SELECT A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT ,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) AS OutPcs from ((MAIN_STOCK AS A  LEFT JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO )LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.CO_BOOK <> '018' AND C.APR_ISU = 'N'  AND A.TAG_NO <> 'N' AND A.TAG_NO <> '' ";
		}
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			ref string rsQryOp11 = ref RsQryOp;
			rsQryOp11 = rsQryOp11 + "AND A.IT_CODE = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboSize.Text, "", false) != 0)
		{
			ref string rsQryOp12 = ref RsQryOp;
			rsQryOp12 = rsQryOp12 + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			ref string rsQryOp13 = ref RsQryOp;
			rsQryOp13 = rsQryOp13 + "AND A.TAG_NO = '" + tTagNo.Text + "'";
		}
		ref string rsQryOut = ref RsQryOut;
		rsQryOut = rsQryOut + "AND B.IT_TYPE ='" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			ref string rsQryOut2 = ref RsQryOut;
			rsQryOut2 = rsQryOut2 + "AND B.PR_CODE ='" + AryPrCode[cboProduct.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboGroup.Text, "", false) != 0)
		{
			ref string rsQryOut3 = ref RsQryOut;
			rsQryOut3 = rsQryOut3 + "AND B.GR_CODE = '" + AryGrCode[cboGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(tCounterCode.Text, "", false) != 0)
		{
			ref string rsQryOut4 = ref RsQryOut;
			rsQryOut4 = rsQryOut4 + "AND C.TBL_CODE = '" + tCounterCode.Text + "'";
		}
		RsQryOut += " GROUP BY A.TAG_NO,A.IT_CODE,B.IT_NAME,C.DESIGN_NO,C.ITM_SIZE,C.ITM_PCS,C.ITM_GWT,C.VCH_SRNO,C.ITM_NWT,C.ITM_FINE,C.LBR_AMT,C.OTH_AMT,C.CO_BOOK,C.VCH_NO,C.VCH_DATE,C.VCH_TYPE,C.BOOK_NAME,C.AC_CODE,C.ITM_MRP,C.KR_NAME,C.TBL_CODE ";
		ref string rsQryOut5 = ref RsQryOut;
		reference = ref rsQryOut5;
		rsQryOut5 = reference + " HAVING SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN A.ITM_SIGN = '-' THEN 1 ELSE 0 END) ELSE 0 END) <> 0 ";
		RsOut = DC_Main.OpenRecordSetDc(RsQryOut);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"SELECT A.TAG_NO,A.VCH_SRNO,COUNT(*) As PhyPcs FROM  (BAR_CAN_DETL AS A INNER JOIN BAR_DETL AS C ON A.CO_CODE = C.CO_CODE AND A.LC_CODE = C.LC_CODE AND A.TAG_NO = C.TAG_NO AND A.VCH_SRNO = C.VCH_SRNO)LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE ", Interaction.IIf(Operators.CompareString(DC_Main.MsCoStockMerge, "Y", false) == 0, (object)"", (object)("A.CO_CODE = '" + DC_Main.MCo_code + "' AND"))), (object)" A.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND A.CO_BOOK = '077'  AND A.TAG_NO <> 'N'  "));
		DC_Main.RsQry = DC_Main.RsQry + "AND B.IT_TYPE = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		if (Operators.CompareString(tItCode.Text, "", false) != 0)
		{
			ref string rsQryOp14 = ref RsQryOp;
			rsQryOp14 = rsQryOp14 + "AND A.IT_CODE = '" + tItCode.Text + "'";
		}
		if (Operators.CompareString(cboSize.Text, "", false) != 0)
		{
			ref string rsQryOp15 = ref RsQryOp;
			rsQryOp15 = rsQryOp15 + "AND C.ITM_SIZE = '" + cboSize.Text + "'";
		}
		if (Operators.CompareString(tTagNo.Text, "", false) != 0)
		{
			ref string rsQryOp16 = ref RsQryOp;
			rsQryOp16 = rsQryOp16 + "AND A.TAG_NO = '" + tTagNo.Text + "'";
		}
		if (Operators.CompareString(cboProduct.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE = '" + AryPrCode[cboProduct.SelectedIndex] + "'";
		}
		if (Operators.CompareString(cboGroup.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE = '" + AryGrCode[cboGroup.SelectedIndex] + "'";
		}
		if (Operators.CompareString(tCounterCode.Text, "", false) != 0)
		{
			DC_Main.RsQry = DC_Main.RsQry + "AND C.TBL_CODE = '" + tCounterCode.Text + "'";
		}
		DC_Main.RsQry += " GROUP BY A.TAG_NO,A.VCH_SRNO";
		RsPhyStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void Dgv_Net_Stock()
	{
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_0ddf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de9: Expected O, but got Unknown
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		DataView dataView = new DataView(RsPhyStk);
		DataView dataView2 = new DataView(RsIn);
		DataView dataView3 = new DataView(RsOut);
		DC_Main.R = 0;
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num12 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num12)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_SIZE"]);
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["TBL_CODE"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_MRP"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = 1;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)""), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"], (object)""))), (object)""));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV)[12, DC_Main.R].Value = 1;
					}
					dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)""), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"], (object)""))), (object)""));
					if (dataView3.Count > 0)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = 1;
						}
						else
						{
							((DataGridView)dGV)[12, DC_Main.R].Value = "";
							((DataGridView)dGV)[9, DC_Main.R].Value = 1;
							((DataGridView)dGV).Rows[DC_Main.R].Cells[12].Style.BackColor = Color.Maroon;
						}
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["APR_ISU"], (object)""), (object)"Y", false))
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = "";
						((DataGridView)dGV)[10, DC_Main.R].Value = 1;
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["EMP_ISU"], (object)""), (object)"Y", false))
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = "";
						((DataGridView)dGV)[11, DC_Main.R].Value = 1;
					}
					((DataGridView)dGV)[13, DC_Main.R].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value)));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_GWT"]);
					}
					else
					{
						((DataGridView)dGV)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]);
					double num13 = num2;
					DataGridViewCell val;
					object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[5, DC_Main.R]).Value);
					double num14 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num2 = num13 + num14;
					double num15 = num3;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[6, DC_Main.R]).Value);
					double num16 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num3 = num15 + num16;
					double num17 = num4;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[7, DC_Main.R]).Value);
					double num18 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num4 = num17 + num18;
					double num19 = num;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[8, DC_Main.R]).Value);
					double num20 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num = num19 + num20;
					double num21 = num5;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[12, DC_Main.R]).Value);
					double num22 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num5 = num21 + Conversions.ToDouble(Conversions.ToString(num22) ?? "");
					double num23 = num9;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
					double num24 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num9 = num23 + num24;
					double num25 = num10;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[11, DC_Main.R]).Value);
					double num26 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num10 = num25 + num26;
					double num27 = num8;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[9, DC_Main.R]).Value);
					double num28 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num8 = num27 + num28;
					double num29 = num6;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[13, DC_Main.R]).Value);
					double num30 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num6 = num29 + num30;
					double num31 = num11;
					Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[14, DC_Main.R]).Value);
					double num32 = DC_Main.Fnv(ref Value);
					val.Value = RuntimeHelpers.GetObjectValue(Value);
					num11 = num31 + num32;
					DC_Main.R++;
					dGV = null;
					DC_Main.M++;
				}
			}
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV)[2, DC_Main.R].Value = "After Physical InOut";
			((DataGridView)DGV).Rows[DC_Main.R].Cells[2].Style.ForeColor = Color.Red;
			((DataGridView)DGV).Rows[DC_Main.R].Cells[2].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
			DC_Main.R++;
			if (RsIn.Rows.Count > 0)
			{
				int num33 = RsIn.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num33)
				{
					DataGridViewX dGV2 = DGV;
					((DataGridView)dGV2).Rows.Add();
					((DataGridView)dGV2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV2)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_SIZE"]);
					((DataGridView)dGV2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["TBL_CODE"]);
					((DataGridView)dGV2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV2)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_MRP"]);
					((DataGridView)dGV2)[8, DC_Main.R].Value = 1;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", RsIn.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]))), (object)""));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV2)[12, DC_Main.R].Value = 1;
					}
					dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", RsIn.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]))), (object)""));
					if (dataView3.Count > 0)
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[12, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV2)[9, DC_Main.R].Value = 1;
						}
						else
						{
							((DataGridView)dGV2).Rows[DC_Main.R].Cells[12].Style.ForeColor = Color.Red;
							((DataGridView)dGV2).Rows[DC_Main.R].Cells[12].Style.Font = new Font("Tahoma", 9f, (FontStyle)1);
						}
					}
					if (Operators.ConditionalCompareObjectEqual(RsIn.Rows[DC_Main.M]["APR_ISU"], (object)"Y", false))
					{
						((DataGridView)dGV2)[9, DC_Main.R].Value = "";
						((DataGridView)dGV2)[10, DC_Main.R].Value = 1;
					}
					if (Operators.ConditionalCompareObjectEqual(RsIn.Rows[DC_Main.M]["EMP_ISU"], (object)"Y", false))
					{
						((DataGridView)dGV2)[9, DC_Main.R].Value = "";
						((DataGridView)dGV2)[11, DC_Main.R].Value = 1;
					}
					((DataGridView)dGV2)[13, DC_Main.R].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[8, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[9, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[12, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[10, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[11, DC_Main.R].Value)));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[13, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_GWT"]);
					}
					else
					{
						((DataGridView)dGV2)[13, DC_Main.R].Value = "";
					}
					((DataGridView)dGV2)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]);
					num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[5, DC_Main.R].Value));
					num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[6, DC_Main.R].Value));
					num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[7, DC_Main.R].Value));
					num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[8, DC_Main.R].Value));
					num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[12, DC_Main.R].Value));
					num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[10, DC_Main.R].Value));
					num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[11, DC_Main.R].Value));
					num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[9, DC_Main.R].Value));
					num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[13, DC_Main.R].Value));
					num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[14, DC_Main.R].Value));
					DC_Main.R++;
					dGV2 = null;
					DC_Main.M++;
				}
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num34 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num34].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num34].Cells[5].Value = num2;
				((DataGridView)DGV).Rows[num34].Cells[6].Value = num3;
				((DataGridView)DGV).Rows[num34].Cells[8].Value = num;
				((DataGridView)DGV).Rows[num34].Cells[9].Value = num8;
				((DataGridView)DGV).Rows[num34].Cells[10].Value = num9;
				((DataGridView)DGV).Rows[num34].Cells[11].Value = num10;
				((DataGridView)DGV).Rows[num34].Cells[12].Value = num5;
				((DataGridView)DGV).Rows[num34].Cells[13].Value = num6;
				((DataGridView)DGV).Rows[num34].Cells[14].Value = num11;
			}
		}
	}

	private void Dgv_Diff_Stock()
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		double num7 = 0.0;
		double num8 = 0.0;
		double num9 = 0.0;
		double num10 = 0.0;
		double num11 = 0.0;
		DataView dataView = new DataView(RsPhyStk);
		DataView dataView2 = new DataView(RsIn);
		DataView dataView3 = new DataView(RsOut);
		DC_Main.R = 0;
		checked
		{
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				int num12 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num12)
				{
					DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_SIZE"]);
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["TBL_CODE"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_MRP"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = 1;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)""), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"], (object)""))), (object)""));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV)[12, DC_Main.R].Value = 1;
					}
					dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", DC_Main.Rshlp.Rows[DC_Main.M]["TAG_NO"]), (object)""), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"], (object)""))), (object)""));
					if (dataView3.Count > 0)
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = 1;
						((DataGridView)dGV)[12, DC_Main.R].Value = "";
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["APR_ISU"], (object)""), (object)"Y", false))
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = "";
						((DataGridView)dGV)[10, DC_Main.R].Value = 1;
					}
					if (Operators.ConditionalCompareObjectEqual(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.M]["EMP_ISU"], (object)""), (object)"Y", false))
					{
						((DataGridView)dGV)[9, DC_Main.R].Value = "";
						((DataGridView)dGV)[11, DC_Main.R].Value = 1;
					}
					((DataGridView)dGV)[13, DC_Main.R].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value)));
					((DataGridView)dGV)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["VCH_SRNO"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[DC_Main.M]["ITM_GWT"]);
						double num13 = num2;
						DataGridViewCell val;
						object Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[5, DC_Main.R]).Value);
						double num14 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num2 = num13 + num14;
						double num15 = num3;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[6, DC_Main.R]).Value);
						double num16 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num3 = num15 + num16;
						double num17 = num4;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[7, DC_Main.R]).Value);
						double num18 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num4 = num17 + num18;
						double num19 = num;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[8, DC_Main.R]).Value);
						double num20 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num = num19 + num20;
						double num21 = num5;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[12, DC_Main.R]).Value);
						double num22 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num5 = num21 + num22;
						double num23 = num9;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[10, DC_Main.R]).Value);
						double num24 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num9 = num23 + num24;
						double num25 = num10;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[11, DC_Main.R]).Value);
						double num26 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num10 = num25 + num26;
						double num27 = num8;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[9, DC_Main.R]).Value);
						double num28 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num8 = num27 + num28;
						double num29 = num6;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[13, DC_Main.R]).Value);
						double num30 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num6 = num29 + num30;
						double num31 = num11;
						Value = RuntimeHelpers.GetObjectValue((val = ((DataGridView)dGV)[14, DC_Main.R]).Value);
						double num32 = DC_Main.Fnv(ref Value);
						val.Value = RuntimeHelpers.GetObjectValue(Value);
						num11 = num31 + num32;
						DC_Main.R++;
					}
					else
					{
						((DataGridView)dGV).Rows.RemoveAt(DC_Main.R);
					}
					dGV = null;
					DC_Main.M++;
				}
			}
			((DataGridView)DGV).Rows.Add();
			((DataGridView)DGV)[2, DC_Main.R].Value = "After Physical InOut";
			DC_Main.R++;
			if (RsIn.Rows.Count > 0)
			{
				int num33 = RsIn.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num33)
				{
					DataGridViewX dGV2 = DGV;
					((DataGridView)dGV2).Rows.Add();
					((DataGridView)dGV2)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV2)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV2)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV2)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_SIZE"]);
					((DataGridView)dGV2)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["TBL_CODE"]);
					((DataGridView)dGV2)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV2)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV2)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_MRP"]);
					((DataGridView)dGV2)[8, DC_Main.R].Value = 1;
					dataView.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", RsIn.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]))), (object)""));
					if (dataView.Count > 0)
					{
						((DataGridView)dGV2)[12, DC_Main.R].Value = 1;
					}
					dataView3.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"TAG_NO = '", RsIn.Rows[DC_Main.M]["TAG_NO"]), (object)"' AND VCH_SRNO = "), (object)Conversion.Val(RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]))), (object)""));
					if (dataView3.Count > 0)
					{
						((DataGridView)dGV2)[9, DC_Main.R].Value = 1;
						((DataGridView)dGV2)[12, DC_Main.R].Value = "";
					}
					if (Operators.ConditionalCompareObjectEqual(RsIn.Rows[DC_Main.M]["APR_ISU"], (object)"Y", false))
					{
						((DataGridView)dGV2)[9, DC_Main.R].Value = "";
						((DataGridView)dGV2)[10, DC_Main.R].Value = 1;
					}
					if (Operators.ConditionalCompareObjectEqual(RsIn.Rows[DC_Main.M]["EMP_ISU"], (object)"Y", false))
					{
						((DataGridView)dGV2)[9, DC_Main.R].Value = "";
						((DataGridView)dGV2)[11, DC_Main.R].Value = 1;
					}
					((DataGridView)dGV2)[13, DC_Main.R].Value = Math.Abs(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[8, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[9, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[10, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[11, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[12, DC_Main.R].Value)));
					((DataGridView)dGV2)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["VCH_SRNO"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[13, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV2)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsIn.Rows[DC_Main.M]["ITM_GWT"]);
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[5, DC_Main.R].Value));
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[6, DC_Main.R].Value));
						num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[7, DC_Main.R].Value));
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[8, DC_Main.R].Value));
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[12, DC_Main.R].Value));
						num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[10, DC_Main.R].Value));
						num10 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[11, DC_Main.R].Value));
						num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[9, DC_Main.R].Value));
						num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[13, DC_Main.R].Value));
						num11 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV2)[14, DC_Main.R].Value));
						DC_Main.R++;
					}
					else
					{
						((DataGridView)dGV2).Rows.RemoveAt(DC_Main.R);
					}
					dGV2 = null;
					DC_Main.M++;
				}
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num34 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num34].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num34].Cells[5].Value = num2;
				((DataGridView)DGV).Rows[num34].Cells[6].Value = num3;
				((DataGridView)DGV).Rows[num34].Cells[8].Value = num;
				((DataGridView)DGV).Rows[num34].Cells[9].Value = num8;
				((DataGridView)DGV).Rows[num34].Cells[10].Value = num9;
				((DataGridView)DGV).Rows[num34].Cells[11].Value = num10;
				((DataGridView)DGV).Rows[num34].Cells[12].Value = num5;
				((DataGridView)DGV).Rows[num34].Cells[13].Value = num6;
				((DataGridView)DGV).Rows[num34].Cells[14].Value = num11;
			}
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
					if (((uint)(columnIndex - 4) <= 2u || (uint)(columnIndex - 8) <= 8u) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 111:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00a5;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 111;
				continue;
			}
			break;
			IL_00a5:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnAll_Click(object sender, EventArgs e)
	{
		PhyRptType = "All";
		Stock_Summ();
	}

	private void BtnDiff_Click(object sender, EventArgs e)
	{
		PhyRptType = "Diff";
		Stock_Summ();
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

	private void mFromDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mFromDt).SelectionStart = 0;
		((TextBoxBase)mFromDt).SelectionLength = Strings.Len(mFromDt.Text);
	}

	private void mToDt_GotFocus(object sender, EventArgs e)
	{
		((TextBoxBase)mToDt).SelectionStart = 0;
		((TextBoxBase)mToDt).SelectionLength = Strings.Len(mToDt.Text);
	}

	private void DGV_VCH_DoubleClick(object sender, EventArgs e)
	{
	}

	private void cboProduct_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)cboGroup).Focus();
		}
	}

	private void BtnSave_Click(object sender, EventArgs e)
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
						num7 = ((DataGridView)DGV).ColumnCount - 2;
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
						num9 = ((DataGridView)DGV).ColumnCount - 2;
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

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13 || Operators.CompareString(tItCode.Text, "", false) == 0)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT A.IT_NAME As ItNameL,A.IT_CODE As ItCodeL FROM ITEM_MAST AS A WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY A.IT_CODE";
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
				tItCode.Text = DC_Main.ColValue[1];
			}
			((Control)tItCode).Focus();
		}
	}

	private void tCounterCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND TABLE_CODE = '" + tCounterCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT TABLE_CODE as CodeL,TABLE_NAME As CounterL FROM TABLE_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY TABLE_CODE";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[3];
			DC_Main.ColWidth[0] = 100.0;
			DC_Main.ColWidth[1] = 300.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tCounterCode.Text = DC_Main.ColValue[0];
				}
				((TextBoxBase)tCounterCode).SelectAll();
			}
		}
		else
		{
			((Control)BtnAll).Focus();
		}
	}

	private void tCounterCode_TextChanged(object sender, EventArgs e)
	{
	}
}
