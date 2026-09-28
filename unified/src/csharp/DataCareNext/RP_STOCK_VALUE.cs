using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
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
public class RP_STOCK_VALUE : Form
{
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
	[AccessedThroughProperty("DGV")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_VCH")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_VCH;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItem")]
	private QButton _BtnItem;

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

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsStkSum;

	private DataTable RsStk;

	private double ColCon;

	private bool DgvLoad;

	private string RptZoom;

	private string RptType;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private string[] AryPrCode;

	private string[] AryGrCode;

	private string[] AryTableCode;

	private const int cMSrNo = 0;

	private const int cMItCode = 1;

	private const int cMItName = 2;

	private const int cMItType = 3;

	private const int cM2Nwt = 4;

	private const int cM2AvgTouch = 5;

	private const int cM2Fine = 6;

	private const int cM2Amt = 7;

	private const int cM2AvgRate = 8;

	private const int cM3Nwt = 9;

	private const int cM3AvgTouch = 10;

	private const int cM3Fine = 11;

	private const int cM3LbrAmt = 12;

	private const int cM3AvgLbr = 13;

	private const int cM1Pcs = 14;

	private const int cM1Nwt = 15;

	private const int cM1Amt = 16;

	private const int cM1AvgRate = 17;

	private const int cM1ClPcs = 18;

	private const int cM1ClNwt = 19;

	private const int cM1ClAmt = 20;

	private const int cM3ClNwt = 21;

	private const int cM3ClFine = 22;

	private const int cM3ClAmt = 23;

	private const int cSrNo = 0;

	private const int cBookType = 1;

	private const int cLdAcName = 2;

	private const int cVchNo = 3;

	private const int cVchDate = 4;

	private const int cTagNo = 5;

	private const int cItemName = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cNetWt = 9;

	private const int cTouch = 10;

	private const int cWest = 11;

	private const int cFine = 12;

	private const int cAvgFine = 13;

	private const int cDiffFine = 14;

	private const int cAvgTouch = 15;

	private const int cSign = 16;

	private const int cBookCode = 17;

	private const int cBookName = 18;

	private const int cItCode = 19;

	private const int cAcCode = 20;

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
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			EventHandler eventHandler = DGV_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV = value;
			val2 = _DGV;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_VCH
	{
		[CompilerGenerated]
		get
		{
			return _DGV_VCH;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_VCH_CellContentClick);
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_VCH_CellFormatting);
			EventHandler eventHandler = DGV_VCH_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick -= val;
				((DataGridView)val3).CellFormatting -= val2;
				((Control)val3).DoubleClick -= eventHandler;
			}
			_DGV_VCH = value;
			val3 = _DGV_VCH;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick += val;
				((DataGridView)val3).CellFormatting += val2;
				((Control)val3).DoubleClick += eventHandler;
			}
		}
	}

	internal virtual QButton BtnItem
	{
		[CompilerGenerated]
		get
		{
			return _BtnItem;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnItem_Click;
			QButton val = _BtnItem;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnItem = value;
			val = _BtnItem;
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
	[AccessedThroughProperty("cboTable")]
	private virtual ComboBox _cboTable;

	internal virtual ComboBox cboTable
	{
		get
		{
			return _cboTable;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_cboTable = value;
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

	public int newindex { get; set; }

	public RP_STOCK_VALUE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_STOCK_VALUE_Load;
		((Form)this).Deactivate += RP_STOCK_VALUE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_STOCK_VALUE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_STOCK_VALUE_KeyDown);
		((Form)this).Activated += RP_STOCK_VALUE_Activated;
		((Form)this).Closed += RP_LEDR_Closed;
		DgvLoad = false;
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
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Unknown result type (might be due to invalid IL or missing references)
		//IL_031e: Expected O, but got Unknown
		//IL_0381: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Expected O, but got Unknown
		//IL_0434: Unknown result type (might be due to invalid IL or missing references)
		//IL_043e: Expected O, but got Unknown
		//IL_0549: Unknown result type (might be due to invalid IL or missing references)
		//IL_0553: Expected O, but got Unknown
		//IL_0670: Unknown result type (might be due to invalid IL or missing references)
		//IL_067a: Expected O, but got Unknown
		//IL_06dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e7: Expected O, but got Unknown
		//IL_0790: Unknown result type (might be due to invalid IL or missing references)
		//IL_079a: Expected O, but got Unknown
		//IL_07fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0807: Expected O, but got Unknown
		//IL_08eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f5: Expected O, but got Unknown
		//IL_0963: Unknown result type (might be due to invalid IL or missing references)
		//IL_096d: Expected O, but got Unknown
		//IL_0a3c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a46: Expected O, but got Unknown
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae5: Expected O, but got Unknown
		//IL_0b63: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6d: Expected O, but got Unknown
		//IL_0c4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c59: Expected O, but got Unknown
		//IL_0cc2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ccc: Expected O, but got Unknown
		//IL_0d7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d84: Expected O, but got Unknown
		//IL_0ded: Unknown result type (might be due to invalid IL or missing references)
		//IL_0df7: Expected O, but got Unknown
		//IL_0f5e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f68: Expected O, but got Unknown
		//IL_1004: Unknown result type (might be due to invalid IL or missing references)
		//IL_100e: Expected O, but got Unknown
		//IL_1094: Unknown result type (might be due to invalid IL or missing references)
		//IL_109e: Expected O, but got Unknown
		//IL_1185: Unknown result type (might be due to invalid IL or missing references)
		//IL_118f: Expected O, but got Unknown
		//IL_11f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_1202: Expected O, but got Unknown
		//IL_12b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_12ba: Expected O, but got Unknown
		//IL_1323: Unknown result type (might be due to invalid IL or missing references)
		//IL_132d: Expected O, but got Unknown
		//IL_13c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ce: Expected O, but got Unknown
		//IL_15e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1604: Unknown result type (might be due to invalid IL or missing references)
		//IL_1628: Unknown result type (might be due to invalid IL or missing references)
		//IL_164c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1675: Unknown result type (might be due to invalid IL or missing references)
		//IL_167f: Expected O, but got Unknown
		//IL_16a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1718: Unknown result type (might be due to invalid IL or missing references)
		//IL_1722: Expected O, but got Unknown
		//IL_17b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c0: Expected O, but got Unknown
		//IL_1840: Unknown result type (might be due to invalid IL or missing references)
		//IL_184a: Expected O, but got Unknown
		//IL_18e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18eb: Expected O, but got Unknown
		//IL_19c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_19ca: Expected O, but got Unknown
		//IL_1a37: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a41: Expected O, but got Unknown
		//IL_1b1c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b26: Expected O, but got Unknown
		//IL_1b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ba0: Expected O, but got Unknown
		//IL_1c3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c47: Expected O, but got Unknown
		//IL_1cf5: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cff: Expected O, but got Unknown
		//IL_1d8a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d94: Expected O, but got Unknown
		//IL_1e0f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e19: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_STOCK_VALUE));
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
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboItemTyp = new ComboBox();
		Label3 = new Label();
		Panel1 = new Panel();
		DGV_VCH = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboStockType = new ComboBox();
		Label1 = new Label();
		BtnItem = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		Label4 = new Label();
		cboProduct = new ComboBox();
		Label5 = new Label();
		cboGroup = new ComboBox();
		Label6 = new Label();
		Label8 = new Label();
		tItCode = new TextBox();
		cboTable = new ComboBox();
		Label7 = new Label();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV).BeginInit();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)DGV_VCH).BeginInit();
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
		((Control)BtnPrint).Visible = false;
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
		lblBook.Text = "Stock Value Repot";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV).AllowUserToAddRows = false;
		((DataGridView)DGV).AllowUserToDeleteRows = false;
		((DataGridView)DGV).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV).BackgroundColor = Color.Snow;
		((DataGridView)DGV).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 11.25f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV).ColumnHeadersHeight = 30;
		((DataGridView)DGV).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV).DefaultCellStyle = val3;
		((DataGridView)DGV).EnableHeadersVisualStyles = false;
		((DataGridView)DGV).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV).Location = new Point(10, 12);
		((Control)DGV).Name = "DGV";
		DGV.PaintEnhancedSelection = false;
		((DataGridView)DGV).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV).RowHeadersVisible = false;
		((DataGridView)DGV).RowHeadersWidth = 20;
		val5.Font = new Font("Calibri", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV).RowsDefaultCellStyle = val5;
		DGV.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV.SelectAllSignVisible = false;
		((DataGridView)DGV).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV).Size = new Size(1160, 420);
		((DataGridView)DGV).StandardTab = true;
		((Control)DGV).TabIndex = 2;
		cboItemTyp.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboItemTyp).Font = new Font("Tahoma", 9f);
		((ListControl)cboItemTyp).FormattingEnabled = true;
		((Control)cboItemTyp).Location = new Point(240, 82);
		((Control)cboItemTyp).Name = "cboItemTyp";
		((Control)cboItemTyp).Size = new Size(109, 22);
		((Control)cboItemTyp).TabIndex = 3;
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(152, 83);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(79, 20);
		((Control)Label3).TabIndex = 108;
		Label3.Text = "Item Type";
		Label3.TextAlign = (ContentAlignment)64;
		((Control)Panel1).BackColor = Color.PeachPuff;
		Panel1.BorderStyle = (BorderStyle)1;
		((Control)Panel1).Controls.Add((Control)(object)DGV);
		((Control)Panel1).Controls.Add((Control)(object)DGV_VCH);
		((Control)Panel1).Location = new Point(0, 119);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(1309, 447);
		((Control)Panel1).TabIndex = 110;
		((DataGridView)DGV_VCH).AllowUserToAddRows = false;
		((DataGridView)DGV_VCH).AllowUserToDeleteRows = false;
		((DataGridView)DGV_VCH).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_VCH).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_VCH).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_VCH).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_VCH).ColumnHeadersHeight = 30;
		((DataGridView)DGV_VCH).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_VCH).DefaultCellStyle = val8;
		((DataGridView)DGV_VCH).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_VCH).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_VCH).Location = new Point(11, 13);
		((Control)DGV_VCH).Name = "DGV_VCH";
		DGV_VCH.PaintEnhancedSelection = false;
		((DataGridView)DGV_VCH).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_VCH).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_VCH).RowHeadersVisible = false;
		((DataGridView)DGV_VCH).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_VCH).RowsDefaultCellStyle = val10;
		DGV_VCH.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_VCH.SelectAllSignVisible = false;
		((DataGridView)DGV_VCH).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_VCH).Size = new Size(1158, 419);
		((DataGridView)DGV_VCH).StandardTab = true;
		((Control)DGV_VCH).TabIndex = 3;
		cboStockType.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboStockType).Font = new Font("Tahoma", 9f);
		((ListControl)cboStockType).FormattingEnabled = true;
		((Control)cboStockType).Location = new Point(240, 47);
		((Control)cboStockType).Name = "cboStockType";
		((Control)cboStockType).Size = new Size(109, 22);
		((Control)cboStockType).TabIndex = 4;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(152, 48);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(82, 20);
		((Control)Label1).TabIndex = 112;
		Label1.Text = "Stock Type";
		Label1.TextAlign = (ContentAlignment)64;
		BtnItem.Appearance.Shape = new QShape((QBaseShapeType)27);
		((QControl)BtnItem).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnItem).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItem).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnItem).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnItem).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnItem).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnItem).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItem).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnItem).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnItem).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnItem).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnItem).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnItem.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnItem.Image = null;
		((QControl)BtnItem).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnItem).Location = new Point(1000, 85);
		((Control)BtnItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItem).Name = "BtnItem";
		((Control)BtnItem).Size = new Size(143, 37);
		((Control)BtnItem).TabIndex = 5;
		BtnItem.Text = "&Ok";
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(70, 47);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(70, 82);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((Control)Label2).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(12, 48);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(52, 20);
		((Control)Label2).TabIndex = 122;
		Label2.Text = "From";
		Label2.TextAlign = (ContentAlignment)64;
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(12, 82);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(52, 20);
		((Control)Label4).TabIndex = 123;
		Label4.Text = "To";
		Label4.TextAlign = (ContentAlignment)64;
		cboProduct.AutoCompleteMode = (AutoCompleteMode)3;
		cboProduct.AutoCompleteSource = (AutoCompleteSource)256;
		cboProduct.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboProduct).Font = new Font("Tahoma", 9f);
		((ListControl)cboProduct).FormattingEnabled = true;
		((Control)cboProduct).Location = new Point(428, 48);
		((Control)cboProduct).Name = "cboProduct";
		((Control)cboProduct).Size = new Size(160, 22);
		((Control)cboProduct).TabIndex = 127;
		((Control)Label5).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(360, 48);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(61, 20);
		((Control)Label5).TabIndex = 128;
		Label5.Text = "Product";
		Label5.TextAlign = (ContentAlignment)64;
		cboGroup.AutoCompleteMode = (AutoCompleteMode)3;
		cboGroup.AutoCompleteSource = (AutoCompleteSource)256;
		cboGroup.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboGroup).Font = new Font("Tahoma", 9f);
		((ListControl)cboGroup).FormattingEnabled = true;
		((Control)cboGroup).Location = new Point(428, 82);
		((Control)cboGroup).Name = "cboGroup";
		((Control)cboGroup).Size = new Size(160, 22);
		((Control)cboGroup).TabIndex = 129;
		((Control)Label6).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label6).ForeColor = Color.Black;
		Label6.ImeMode = (ImeMode)0;
		((Control)Label6).Location = new Point(360, 82);
		((Control)Label6).Name = "Label6";
		((Control)Label6).Size = new Size(61, 20);
		((Control)Label6).TabIndex = 130;
		Label6.Text = "Group";
		Label6.TextAlign = (ContentAlignment)64;
		((Control)Label8).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label8).ForeColor = Color.Black;
		Label8.ImeMode = (ImeMode)0;
		((Control)Label8).Location = new Point(600, 52);
		((Control)Label8).Name = "Label8";
		((Control)Label8).Size = new Size(64, 20);
		((Control)Label8).TabIndex = 1185;
		Label8.Text = "It Code";
		Label8.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tItCode).BackColor = Color.White;
		((Control)tItCode).Font = new Font("Tahoma", 9f);
		((Control)tItCode).Location = new Point(670, 51);
		((TextBoxBase)tItCode).MaxLength = 6;
		((Control)tItCode).Name = "tItCode";
		((Control)tItCode).Size = new Size(111, 22);
		((Control)tItCode).TabIndex = 1184;
		cboTable.AutoCompleteMode = (AutoCompleteMode)3;
		cboTable.AutoCompleteSource = (AutoCompleteSource)256;
		((Control)cboTable).Font = new Font("Tahoma", 9f);
		((ListControl)cboTable).FormattingEnabled = true;
		((Control)cboTable).Location = new Point(670, 83);
		cboTable.MaxLength = 25;
		((Control)cboTable).Name = "cboTable";
		((Control)cboTable).Size = new Size(111, 22);
		((Control)cboTable).TabIndex = 1182;
		((Control)Label7).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label7).ForeColor = Color.Black;
		Label7.ImeMode = (ImeMode)0;
		((Control)Label7).Location = new Point(589, 83);
		((Control)Label7).Name = "Label7";
		((Control)Label7).Size = new Size(73, 20);
		((Control)Label7).TabIndex = 1183;
		Label7.Text = "Counter";
		Label7.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)Label8);
		((Control)this).Controls.Add((Control)(object)tItCode);
		((Control)this).Controls.Add((Control)(object)cboTable);
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
		((Control)this).Controls.Add((Control)(object)BtnItem);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_STOCK_VALUE";
		((Form)this).Text = "Stock Value Repot";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void Stock_Summ(string RptType)
	{
		string text = "A.KR_FINE";
		if (Operators.CompareString(RptType, "Item", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code ,B.IT_NAME AS Name,B.IT_TYPE As ItType, SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE = 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE 0 END) ELSE 0 END) AS Cat1Pcs,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE = 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS Cat1Nwt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE = 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_AMT ELSE 0 END) ELSE 0 END) AS Cat1Amt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE = 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_PCS ELSE -ITM_PCS END) ELSE 0 END) AS Clos1Pcs,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE = 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -ITM_NWT END) ELSE 0 END) AS Clos1Nwt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT <> 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS Cat2Nwt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT <> 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS Cat2Fine,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT <> 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_AMT ELSE 0 END) ELSE 0 END) AS Cat2Amt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT = 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS Cat3Nwt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT = 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS Cat3Fine,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' THEN (CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS Clos3Nwt,SUM(CASE WHEN A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' AND B.RATE_TYPE <> 'P' AND A.ITM_AMT = 0 THEN (CASE WHEN ITM_SIGN = '+' THEN A.LBR_AMT ELSE 0 END) ELSE 0 END) AS Cat3LbrAmt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'"));
			if (cboStockType.SelectedIndex == 1)
			{
				DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
			}
			else if (cboStockType.SelectedIndex == 2)
			{
				DC_Main.RsQry += "AND A.TAG_NO = 'N'";
			}
			if (Operators.CompareString(cboProduct.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.PR_CODE =  '" + AryPrCode[cboProduct.SelectedIndex] + "'";
			}
			if (Operators.CompareString(cboGroup.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND B.GR_CODE =  '" + AryGrCode[cboGroup.SelectedIndex] + "'";
			}
			if (Operators.CompareString(tItCode.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.IT_CODE =  '" + tItCode.Text + "'";
			}
			if (Operators.CompareString(cboTable.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + "AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'";
			}
			DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE ORDER BY B.IT_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		}
		DGV_FILL();
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
			((DataGridView)DGV).Columns[0].Width = (int)Math.Round(35.0 * ColCon);
			((DataGridView)DGV).Columns.Add("", "ItCode");
			((DataGridView)DGV).Columns[1].Visible = false;
			((DataGridView)DGV).Columns.Add("", "It Name");
			((DataGridView)DGV).Columns[2].Width = (int)Math.Round(160.0 * ColCon);
			((DataGridView)DGV).Columns[2].Frozen = true;
			((DataGridView)DGV).Columns.Add("", "It Type");
			((DataGridView)DGV).Columns[3].Visible = false;
			((DataGridView)DGV).Columns.Add("", "RatNwt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "RatATh%");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "RatFine");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "RatAmt");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "RatAvg");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "FnNwt");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "FnATh%");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "FnFine");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "LbrAmt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "AvgLbr");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PPcs");
			((DataGridView)DGV).Columns[14].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "PNwt");
			((DataGridView)DGV).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "PAmt");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PAvgRt");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV).Columns.Add("", "PClPcs");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "PClNwt");
			((DataGridView)DGV).Columns[19].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[19].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "PClVal");
			((DataGridView)DGV).Columns[20].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[20].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV).Columns.Add("", "ClNwt");
			((DataGridView)DGV).Columns[21].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[21].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "ClFine");
			((DataGridView)DGV).Columns[22].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[22].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "ClVal");
			((DataGridView)DGV).Columns[23].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[23].DefaultCellStyle.Format = "N2";
			Dgv_Group_Stock();
		}
	}

	private void Dgv_Group_Stock()
	{
		DC_Main.R = 0;
		checked
		{
			if (RsStkSum.Rows.Count > 0)
			{
				int num = RsStkSum.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
					((DataGridView)dGV).Rows.Add();
					((DataGridView)dGV)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Code"]);
					((DataGridView)dGV)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["Name"]);
					((DataGridView)dGV)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["ItType"]);
					((DataGridView)dGV)[14, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat1Pcs"], (object)""));
					((DataGridView)dGV)[15, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat1Nwt"], (object)""));
					((DataGridView)dGV)[16, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat1Amt"], (object)""));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value));
					}
					((DataGridView)dGV)[18, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Clos1Pcs"], (object)""));
					((DataGridView)dGV)[19, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Clos1Nwt"], (object)""));
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, DC_Main.R].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value)) != 0.0))
					{
						((DataGridView)dGV)[20, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[18, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value));
					}
					((DataGridView)dGV)[4, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat2Nwt"], (object)""));
					((DataGridView)dGV)[6, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat2Fine"], (object)""));
					((DataGridView)dGV)[7, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat2Amt"], (object)""));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[5, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, DC_Main.R].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, DC_Main.R].Value)) * 100.0;
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value)) != 0.0)
						{
							((DataGridView)dGV)[8, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, DC_Main.R].Value));
						}
					}
					((DataGridView)dGV)[9, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat3Nwt"], (object)""));
					((DataGridView)dGV)[11, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat3Fine"], (object)""));
					((DataGridView)dGV)[12, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Cat3LbrAmt"], (object)""));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[10, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) * 100.0;
						((DataGridView)dGV)[13, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[12, DC_Main.R].Value)) / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value));
					}
					((DataGridView)dGV)[21, DC_Main.R].Value = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["Clos3Nwt"], (object)"")) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[19, DC_Main.R].Value));
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) == 0.0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) / 100.0;
						}
						else if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) != 0.0)
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[10, DC_Main.R].Value)) / 100.0;
						}
						else
						{
							((DataGridView)dGV)[22, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[21, DC_Main.R].Value));
						}
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value)) != 0.0)
						{
							((DataGridView)dGV)[23, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[22, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value));
						}
					}
					DC_Main.R++;
					dGV = null;
					DC_Main.M++;
				}
			}
			if (((DataGridView)DGV).Rows.Count >= 1)
			{
				((DataGridView)DGV).Rows.Add();
				((DataGridView)DGV).Rows.Add();
			}
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
			double num12 = 0.0;
			double num13 = 0.0;
			double num14 = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			double num17 = 0.0;
			double num18 = 0.0;
			int num19 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num19; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[14].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[15].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[16].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[18].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[20].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[21].Value, (object)""));
					num17 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[22].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
				}
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num20 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num20].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num20].Cells[14].Value = num2;
				((DataGridView)DGV).Rows[num20].Cells[15].Value = num3;
				((DataGridView)DGV).Rows[num20].Cells[16].Value = num4;
				((DataGridView)DGV).Rows[num20].Cells[18].Value = num11;
				((DataGridView)DGV).Rows[num20].Cells[20].Value = num12;
				((DataGridView)DGV).Rows[num20].Cells[4].Value = num5;
				((DataGridView)DGV).Rows[num20].Cells[6].Value = num6;
				((DataGridView)DGV).Rows[num20].Cells[7].Value = num7;
				if (unchecked(num7 != 0.0 && num6 != 0.0))
				{
					((DataGridView)DGV).Rows[num20].Cells[8].Value = Math.Round(num7 / num6, 2);
				}
				((DataGridView)DGV).Rows[num20].Cells[9].Value = num8;
				((DataGridView)DGV).Rows[num20].Cells[11].Value = num9;
				((DataGridView)DGV).Rows[num20].Cells[21].Value = num16;
				((DataGridView)DGV).Rows[num20].Cells[22].Value = num17;
				((DataGridView)DGV).Rows[num20].Cells[12].Value = num10;
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
					if ((uint)(columnIndex - 4) <= 19u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 104:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009e;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 104;
				continue;
			}
			break;
			IL_009e:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_0768: Unknown result type (might be due to invalid IL or missing references)
		//IL_0772: Expected O, but got Unknown
		//IL_07a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b3: Expected O, but got Unknown
		//IL_07c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_07d8: Expected O, but got Unknown
		//IL_07ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_07f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_07fd: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		BtnExit.Text = "&Back";
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		if (Operators.CompareString(RptZoom, "Item", false) == 0)
		{
			switch (columnIndex)
			{
			default:
				return;
			case 14:
			case 15:
			case 16:
			case 17:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN ITM_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboTable.Text, "", false) == 0, (object)"", (object)("AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"))), (object)" And C.RATE_TYPE = 'P'  AND A.ITM_SIGN = '+'  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 18:
			case 19:
			case 20:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN ITM_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboTable.Text, "", false) == 0, (object)"", (object)("AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"))), (object)" And C.RATE_TYPE = 'P'   AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN ITM_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboTable.Text, "", false) == 0, (object)"", (object)("AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"))), (object)" AND C.RATE_TYPE <> 'P' AND A.ITM_AMT <> 0 AND A.ITM_SIGN = '+'  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN ITM_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboTable.Text, "", false) == 0, (object)"", (object)("AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"))), (object)" AND C.RATE_TYPE <> 'P' AND A.ITM_AMT = 0 AND A.ITM_SIGN = '+'  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 21:
			case 22:
			case 23:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,CASE WHEN A.ITM_SIGN = '+' THEN ITM_FINE ELSE ITM_FINE END As ItmFine,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboTable.Text, "", false) == 0, (object)"", (object)("AND A.TBL_CODE =  '" + AryTableCode[cboTable.SelectedIndex] + "'"))), (object)" AND C.RATE_TYPE <> 'P'  AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			}
		}
		RsStk = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		((DataGridView)DGV_VCH).MultiSelect = false;
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_VCH).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
		((DataGridView)DGV_VCH).AutoGenerateColumns = false;
		((DataGridView)DGV_VCH).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_VCH).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Vchtype");
			((DataGridView)DGV_VCH).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Party Name");
			((DataGridView)DGV_VCH).Columns[2].Width = (int)Math.Round(160.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "VchNo");
			((DataGridView)DGV_VCH).Columns[3].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "VchDate");
			((DataGridView)DGV_VCH).Columns[4].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "TagNo");
			((DataGridView)DGV_VCH).Columns[5].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "ItName");
			((DataGridView)DGV_VCH).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_VCH).Columns.Add("", "Pcs");
			((DataGridView)DGV_VCH).Columns[7].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns.Add("", "GrWt");
			((DataGridView)DGV_VCH).Columns[8].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "NetWt");
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Touch");
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "West");
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Fine");
			((DataGridView)DGV_VCH).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Format = "N3";
			if (unchecked(columnIndex >= 14 && columnIndex <= 13))
			{
				((DataGridView)DGV_VCH).Columns.Add("", "AvgFine");
				((DataGridView)DGV_VCH).Columns[13].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_VCH).Columns.Add("", "Profit");
				((DataGridView)DGV_VCH).Columns[14].Visible = false;
				((DataGridView)DGV_VCH).Columns.Add("", "ATch%");
				((DataGridView)DGV_VCH).Columns[15].Width = (int)Math.Round(65.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV_VCH).Columns.Add("", "AvgFine");
				((DataGridView)DGV_VCH).Columns[13].Visible = false;
				((DataGridView)DGV_VCH).Columns.Add("", "Profit");
				((DataGridView)DGV_VCH).Columns[14].Visible = false;
				((DataGridView)DGV_VCH).Columns.Add("", "AvgTch");
				((DataGridView)DGV_VCH).Columns[15].Visible = false;
			}
			((DataGridView)DGV_VCH).Columns.Add("", "Sign");
			((DataGridView)DGV_VCH).Columns[16].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "CoBook");
			((DataGridView)DGV_VCH).Columns[17].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "MainBook");
			((DataGridView)DGV_VCH).Columns[18].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "ItCode");
			((DataGridView)DGV_VCH).Columns[19].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "AcCode");
			((DataGridView)DGV_VCH).Columns[20].Visible = false;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			DC_Main.R = 0;
			if (RsStk.Rows.Count > 0)
			{
				int num7 = RsStk.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num7)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
					((DataGridView)dGV_VCH).Rows.Add();
					((DataGridView)dGV_VCH)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["BOOK_SNAME"]);
					((DataGridView)dGV_VCH)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["AC_NAME"]);
					((DataGridView)dGV_VCH)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_VCH)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_VCH)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["TAG_NO"]);
					((DataGridView)dGV_VCH)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["IT_NAME"]);
					((DataGridView)dGV_VCH)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_PCS"]);
					((DataGridView)dGV_VCH)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_GWT"]);
					((DataGridView)dGV_VCH)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_NWT"]);
					((DataGridView)dGV_VCH)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_TOUCH"]);
					((DataGridView)dGV_VCH)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_WEST"]);
					((DataGridView)dGV_VCH)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ItmFine"]);
					double num8 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[10, index].Value));
					double num9 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
					((DataGridView)dGV_VCH)[15, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV)[10, index].Value));
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[15, DC_Main.R].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value)) != 0.0))
					{
						((DataGridView)dGV_VCH)[13, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[15, DC_Main.R].Value)) / 100.0;
					}
					((DataGridView)dGV_VCH)[14, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
					((DataGridView)dGV_VCH)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["ITM_SIGN"]);
					((DataGridView)dGV_VCH)[17, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_VCH)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["MAIN_BOOK"]);
					((DataGridView)dGV_VCH)[19, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["IT_CODE"]);
					((DataGridView)dGV_VCH)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[DC_Main.M]["AC_CODE"]);
					if (unchecked(columnIndex >= 14 && columnIndex <= 13))
					{
						if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_VCH)[16, DC_Main.R].Value, (object)"+", false))
						{
							num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
							num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
							num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
							num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
						}
						else
						{
							num -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
							num2 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
							num3 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
							num4 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
							num5 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
						}
					}
					else
					{
						num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
						num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
						num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
						num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
						num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
					}
					num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[14, DC_Main.R].Value));
					DC_Main.R++;
					dGV_VCH = null;
					DC_Main.M++;
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count >= 1)
			{
				((DataGridView)DGV_VCH).Rows.Add();
				((DataGridView)DGV_VCH).Rows.Add();
			}
			int num10 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			if (num10 > 1)
			{
				((DataGridView)DGV_VCH).Rows[num10].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num10].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num10].Cells[8].Value = num2;
				((DataGridView)DGV_VCH).Rows[num10].Cells[9].Value = num3;
				((DataGridView)DGV_VCH).Rows[num10].Cells[12].Value = num4;
				((DataGridView)DGV_VCH).Rows[num10].Cells[13].Value = num5;
				((DataGridView)DGV_VCH).Rows[num10].Cells[14].Value = num6;
			}
		}
	}

	private void DGV_VCH_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
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
		object obj8 = default(object);
		int num7 = default(int);
		int num8 = default(int);
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num14 = default(int);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				checked
				{
					object obj4;
					object[] obj5;
					object[] array;
					bool[] obj6;
					bool[] array2;
					object obj7;
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1899:
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
								goto IL_0054;
							case 8:
								goto IL_005d;
							case 9:
								goto IL_00b6;
							case 10:
								goto IL_00de;
							case 11:
								goto IL_0111;
							case 12:
								goto IL_0136;
							case 13:
								goto IL_014d;
							case 14:
								goto IL_0195;
							case 15:
								goto IL_01a4;
							case 16:
								goto IL_01c1;
							case 17:
								goto IL_01db;
							case 18:
								goto IL_01fe;
							case 19:
							case 20:
								goto IL_0253;
							case 21:
								goto IL_0265;
							case 23:
								goto IL_0287;
							case 24:
								goto IL_029e;
							case 25:
								goto IL_02e6;
							case 26:
								goto IL_02f5;
							case 27:
								goto IL_0312;
							case 28:
								goto IL_032c;
							case 29:
								goto IL_034f;
							case 30:
							case 31:
								goto IL_03ad;
							case 32:
								goto IL_03bf;
							case 22:
							case 33:
							case 34:
								goto IL_03db;
							case 35:
								goto IL_03e5;
							case 36:
								goto IL_0438;
							case 37:
								goto IL_048d;
							case 38:
								goto IL_04e5;
							case 39:
								goto IL_0553;
							case 40:
								goto IL_0596;
							case 41:
								goto IL_05c5;
							case 42:
								goto IL_0608;
							case 43:
								goto IL_0649;
							case 44:
								goto IL_066a;
							case 45:
								goto IL_0678;
							case 46:
								goto IL_067e;
							case 47:
								goto IL_0684;
							case 48:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 49:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_032c:
						num2 = 28;
						if (((DataGridView)DGV)[num5, DC_Main.i].Value != null)
						{
							goto IL_034f;
						}
						goto IL_03ad;
						IL_034f:
						num2 = 29;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV)[num5, DC_Main.i].Value.ToString() ?? ""
						}, (string[])null, (Type[])null);
						goto IL_03ad;
						IL_03bf:
						num2 = 32;
						DC_Main.i++;
						goto IL_03ce;
						IL_02e6:
						num2 = 25;
						num6++;
						goto IL_02ef;
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
						obj3 = Missing.Value;
						goto IL_0054;
						IL_0054:
						ProjectData.ClearProjectError();
						num3 = -2;
						goto IL_005d;
						IL_005d:
						num2 = 8;
						obj4 = NewLateBinding.LateGet(obj2, (Type)null, "Workbooks", new object[0], (string[])null, (Type[])null, (bool[])null);
						obj5 = new object[1] { obj3 };
						array = obj5;
						obj6 = new bool[1] { true };
						array2 = obj6;
						obj7 = NewLateBinding.LateGet(obj4, (Type)null, "Add", obj5, (string[])null, (Type[])null, obj6);
						if (array2[0])
						{
							obj3 = RuntimeHelpers.GetObjectValue(array[0]);
						}
						obj8 = RuntimeHelpers.GetObjectValue(obj7);
						goto IL_00b6;
						IL_03ad:
						num2 = 31;
						num5++;
						goto IL_03b6;
						IL_029e:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02e6;
						IL_00b6:
						num2 = 9;
						obj = RuntimeHelpers.GetObjectValue(NewLateBinding.LateGet(obj8, (Type)null, "Sheets", new object[1] { "sheet1" }, (string[])null, (Type[])null, (bool[])null));
						goto IL_00de;
						IL_00de:
						num2 = 10;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3] { 1, 1, "Sheet 1 content" }, (string[])null, (Type[])null);
						goto IL_0111;
						IL_0111:
						num2 = 11;
						if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
						{
							goto IL_0136;
						}
						goto IL_0287;
						IL_0136:
						num2 = 12;
						num7 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num8 = 0;
						goto IL_019e;
						IL_019e:
						if (num8 <= num7)
						{
							goto IL_014d;
						}
						goto IL_01a4;
						IL_01a4:
						num2 = 15;
						num9 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0274;
						IL_0274:
						if (DC_Main.i <= num9)
						{
							goto IL_01c1;
						}
						goto IL_03db;
						IL_01c1:
						num2 = 16;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num11 = 0;
						goto IL_025c;
						IL_025c:
						if (num11 <= num10)
						{
							goto IL_01db;
						}
						goto IL_0265;
						IL_0265:
						num2 = 21;
						DC_Main.i++;
						goto IL_0274;
						IL_01db:
						num2 = 17;
						if (((DataGridView)DGV_VCH)[num11, DC_Main.i].Value != null)
						{
							goto IL_01fe;
						}
						goto IL_0253;
						IL_01fe:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0253;
						IL_0253:
						num2 = 20;
						num11++;
						goto IL_025c;
						IL_014d:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_VCH).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0195;
						IL_0195:
						num2 = 14;
						num8++;
						goto IL_019e;
						IL_0287:
						num2 = 23;
						num12 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_02ef;
						IL_02ef:
						if (num6 <= num12)
						{
							goto IL_029e;
						}
						goto IL_02f5;
						IL_02f5:
						num2 = 26;
						num13 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_03ce;
						IL_03ce:
						if (DC_Main.i <= num13)
						{
							goto IL_0312;
						}
						goto IL_03db;
						IL_03db:
						num2 = 34;
						colorConverter = new ColorConverter();
						goto IL_03e5;
						IL_03e5:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0438;
						IL_0438:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_048d;
						IL_048d:
						num2 = 37;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04e5;
						IL_04e5:
						num2 = 38;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0553;
						IL_0553:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0596;
						IL_0596:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05c5;
						IL_05c5:
						num2 = 41;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0608;
						IL_0608:
						num2 = 42;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0649;
						IL_0649:
						num2 = 43;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_066a;
						IL_066a:
						num2 = 44;
						Cursor.Current = Cursors.Default;
						goto IL_0678;
						IL_0678:
						num2 = 45;
						obj = null;
						goto IL_067e;
						IL_067e:
						num2 = 46;
						obj8 = null;
						goto IL_0684;
						IL_0684:
						num2 = 47;
						obj2 = null;
						break;
						IL_0312:
						num2 = 27;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_03b6;
						IL_03b6:
						if (num5 <= num14)
						{
							goto IL_032c;
						}
						goto IL_03bf;
						end_IL_0001_2:
						break;
					}
					num2 = 48;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj9) when (obj9 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj9);
				try0001_dispatch = 1899;
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
	}

	private void RP_STOCK_VALUE_Load(object sender, EventArgs e)
	{
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016c: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		DC_Main.MsUserRightForm = "";
		if (dataTable.Rows.Count > 0)
		{
			UserEdit = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_EDIT"], (object)""));
			UserDelete = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_DELETE"], (object)""));
			UserPrint = Conversions.ToString(Operators.ConcatenateObject(dataTable.Rows[0]["FRM_PRINT"], (object)""));
		}
		Cr.Connect = DC_Main.CrConnect;
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
				DevComponents.DotNetBar.Controls.DataGridViewX dGV = DGV;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV).BackgroundColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_VCH).BackgroundColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj11 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)Panel1).BackColor = Color.Silver;
				ComboBox obj12 = cboItemTyp;
				object? obj13 = colorConverter.ConvertFromString("243, 240, 239");
				obj12.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				ComboBox obj14 = cboStockType;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				obj14.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				ComboBox obj16 = cboProduct;
				object? obj17 = colorConverter.ConvertFromString("243, 240, 239");
				obj16.BackColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				ComboBox obj18 = cboGroup;
				object? obj19 = colorConverter.ConvertFromString("243, 240, 239");
				obj18.BackColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj20 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV2 = DGV;
				object? obj21 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV2).BackgroundColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj22 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH2 = DGV_VCH;
				object? obj23 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_VCH2).BackgroundColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj24 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				Panel panel = Panel1;
				object? obj25 = colorConverter.ConvertFromString("174, 184, 194");
				((Control)panel).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				ComboBox obj26 = cboItemTyp;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				obj26.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				ComboBox obj28 = cboStockType;
				object? obj29 = colorConverter.ConvertFromString("233, 235, 240");
				obj28.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				ComboBox obj30 = cboProduct;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				obj30.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				ComboBox obj32 = cboGroup;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				obj32.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj34 = colorConverter.ConvertFromString("Control");
				((Form)this).BackColor = ((obj34 != null) ? ((Color)obj34) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj35 = lblBook;
				object? obj36 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj35).ForeColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj37 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj37 != null) ? ((Color)obj37) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV3 = DGV;
				object? obj38 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV3).BackgroundColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV).AlternatingRowsDefaultCellStyle;
				object? obj39 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj39 != null) ? ((Color)obj39) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH3 = DGV_VCH;
				object? obj40 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_VCH3).BackgroundColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle;
				object? obj41 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj41 != null) ? ((Color)obj41) : default(Color));
				Panel panel2 = Panel1;
				object? obj42 = colorConverter.ConvertFromString("205, 220, 220");
				((Control)panel2).BackColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				cboItemTyp.BackColor = Color.Cornsilk;
				cboStockType.BackColor = Color.Cornsilk;
				cboProduct.BackColor = Color.Cornsilk;
				cboGroup.BackColor = Color.Cornsilk;
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
			DC_Main.RsQry = "SELECT TABLE_NAME,TABLE_CODE FROM TABLE_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  ORDER BY TABLE_NAME";
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.X = 0;
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				AryTableCode = new string[DC_Main.Rshlp.Rows.Count + 1];
				AryTableCode[DC_Main.X] = "";
				cboTable.Items.Add((object)"");
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
				{
					cboTable.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["TABLE_NAME"], (object)""));
					AryTableCode[DC_Main.X + 1] = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["TABLE_CODE"], (object)""));
					DC_Main.X++;
				}
			}
			else
			{
				cboTable.Items.Add((object)"");
				AryTableCode[DC_Main.X] = "";
			}
			cboTable.SelectedIndex = 0;
			mFromDt.Text = Conversions.ToString(DC_Main.MOp_dt);
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
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
		DGV_CLEAR();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_VCH).DataSource = null;
			((DataGridView)DGV_VCH).ClearSelection();
			((DataGridView)DGV_VCH).Rows.Clear();
			((Control)DGV_VCH).Refresh();
			BtnExit.Text = "&Exit";
			((Control)DGV).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_STOCK_VALUE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_STOCK_VALUE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_STOCK_VALUE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x49 & (0 - (e.Alt ? 1 : 0))))
		{
			BtnItem_Click(BtnItem, new EventArgs());
			((Control)BtnItem).Focus();
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

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		string text = "Item Wise Stock From Date  ";
		string text2 = "ItemStkRpt";
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\" + text2 + ".RPT";
		Cr.SelectionFormula = "{MAIN_STOCK.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MAIN_STOCK.LC_CODE} = '" + DC_Main.MLc_code + "' AND {MAIN_STOCK.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MAIN_STOCK.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(cboItemTyp.Text, "", false) != 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " And {ITEM_MAST.IT_TYPE} = '" + Strings.Mid(cboItemTyp.Text, 1, 1) + "'";
		}
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {MAIN_STOCK.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = '" + text + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd/MM/yyyy") + " To " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom((short)110);
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_STOCK_VALUE_Activated(object sender, EventArgs e)
	{
		CurActCtrl.Focus();
	}

	private void RP_LEDR_Closed(object sender, EventArgs e)
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

	private void DGV_VCH_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 7) <= 8u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 103:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_009d;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 103;
				continue;
			}
			break;
			IL_009d:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void BtnBack()
	{
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		BtnExit.Text = "&Exit";
		((Control)DGV).Visible = true;
	}

	private void BtnItem_Click(object sender, EventArgs e)
	{
		RptZoom = "Item";
		RptType = "I";
		BtnBack();
		Stock_Summ("Item");
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
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[17].Value), (object)""), (object)"' "));
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
		DC_Main.CurBookVch = Conversions.ToString(Operators.ConcatenateObject(((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[3].Value, (object)""));
		if (Operators.CompareString(DC_Main.CurBookMain, "OPSTK", false) == 0)
		{
			if (Strings.Len(DC_Main.CurBookVch) != 1)
			{
				TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
				((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_TAG_OPBL).Show();
				((Control)tR_TAG_OPBL).Focus();
			}
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL2 = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL2).Show();
			((Control)tR_TAG_OPBL2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG CANCEL", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN = new TR_TAG_CAN();
			((Form)tR_TAG_CAN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN).Show();
			((Control)tR_TAG_CAN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "STOCK ADJUST", false) == 0)
		{
			TR_TAG_CAN tR_TAG_CAN2 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN2).Show();
			((Control)tR_TAG_CAN2).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "APR ISU", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON REC", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "CON ISU", false) == 0))
		{
			TR_APR_ISU tR_APR_ISU = new TR_APR_ISU();
			((Form)tR_APR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU).Show();
			((Control)tR_APR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "APR RTN", false) == 0)
		{
			TR_APR_ISU tR_APR_ISU2 = new TR_APR_ISU();
			((Form)tR_APR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_APR_ISU2).Show();
			((Control)tR_APR_ISU2).Focus();
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "KARIGAR ISSUE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "PURC RETURN", false) == 0))
		{
			TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
			((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU).Show();
			((Control)tR_KR_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "KARIGAR RECEIPT", false) == 0)
		{
			TR_PURC tR_PURC2 = new TR_PURC();
			((Form)tR_PURC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_PURC2).Show();
			((Control)tR_PURC2).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "TAG WT CHANGE", false) == 0)
		{
			TR_TAG_WT_DIFF tR_TAG_WT_DIFF = new TR_TAG_WT_DIFF();
			((Form)tR_TAG_WT_DIFF).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_WT_DIFF).Show();
			((Control)tR_TAG_WT_DIFF).Focus();
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
			TR_SALE_RTN tR_SALE_RTN = new TR_SALE_RTN();
			((Form)tR_SALE_RTN).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_RTN).Show();
			((Control)tR_SALE_RTN).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN REC", false) == 0)
		{
			TR_DHRN_ISU tR_DHRN_ISU = new TR_DHRN_ISU();
			((Form)tR_DHRN_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_ISU).Show();
			((Control)tR_DHRN_ISU).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN INT ENTRY", false) == 0)
		{
			TR_DHRN_INTREC tR_DHRN_INTREC = new TR_DHRN_INTREC();
			((Form)tR_DHRN_INTREC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_INTREC).Show();
			((Control)tR_DHRN_INTREC).Focus();
		}
		else if (Operators.CompareString(DC_Main.CurBookMain, "LOAN ISSUE", false) == 0)
		{
			TR_DHRN_REC tR_DHRN_REC = new TR_DHRN_REC();
			((Form)tR_DHRN_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_DHRN_REC).Show();
			((Control)tR_DHRN_REC).Focus();
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
			TR_TAG_CAN tR_TAG_CAN3 = new TR_TAG_CAN();
			((Form)tR_TAG_CAN3).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_CAN3).Show();
			((Control)tR_TAG_CAN3).Focus();
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
			TR_KR_ISU tR_KR_ISU2 = new TR_KR_ISU();
			((Form)tR_KR_ISU2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_KR_ISU2).Show();
			((Control)tR_KR_ISU2).Focus();
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "FAN SALE", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "FAN PURC", false) == 0))
		{
			TR_FN_INOUT tR_FN_INOUT = new TR_FN_INOUT();
			((Form)tR_FN_INOUT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FN_INOUT).Show();
			((Control)tR_FN_INOUT).Focus();
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
		else if (Operators.CompareString(DC_Main.CurBookMain, "FINE SALE", false) == 0)
		{
			TR_FINE_SL_PR tR_FINE_SL_PR = new TR_FINE_SL_PR();
			((Form)tR_FINE_SL_PR).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_FINE_SL_PR).Show();
			((Control)tR_FINE_SL_PR).Focus();
		}
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

	private void tItCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND IT_CODE = '" + tItCode.Text + "'";
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count != 0)
		{
			return;
		}
		DC_Main.RsQry = "SELECT IT_NAME As ItNameL,IT_CODE as ItCodeL,IT_TYPE as TypeL,GR_CODE As GrCodeL FROM ITEM_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' ORDER BY IT_TYPE,IT_NAME";
		DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.ColWidth = new double[5];
		DC_Main.ColWidth[0] = 300.0;
		DC_Main.ColWidth[1] = 100.0;
		DC_Main.ColWidth[2] = 100.0;
		DC_Main.ColWidth[3] = 100.0;
		DC_Main.HelpSelect = 1;
		((Form)MyProject.Forms.MS_HELP).ShowDialog();
		if (!DC_Main.HelpClose)
		{
			if (Operators.CompareString(DC_Main.ColValue[1], "", false) != 0)
			{
				tItCode.Text = DC_Main.ColValue[1];
			}
			((TextBoxBase)tItCode).SelectAll();
		}
	}
}
