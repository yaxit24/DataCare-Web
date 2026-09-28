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
public class RP_STOCK_FINE : Form
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
	[AccessedThroughProperty("BtnGroup")]
	private QButton _BtnGroup;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnItem")]
	private QButton _BtnItem;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnTrading")]
	private QButton _BtnTrading;

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

	private const int cMSrNo = 0;

	private const int cMItCode = 1;

	private const int cMItName = 2;

	private const int cMItType = 3;

	private const int cMOpNwt = 4;

	private const int cMOpFine = 5;

	private const int cMPrNwt = 6;

	private const int cMPrFine = 7;

	private const int cMInNwt = 8;

	private const int cMInFine = 9;

	private const int cMOutNwt = 10;

	private const int cMOutFine = 11;

	private const int cMSlNwt = 12;

	private const int cMSlFine = 13;

	private const int cMAvgFine = 14;

	private const int cMPfFine = 15;

	private const int cMClNwt = 16;

	private const int cMClFine = 17;

	private const int cMAvgTch = 18;

	private const int cSrNo = 0;

	private const int cBookType = 1;

	private const int cLdAcName = 2;

	private const int cVchNo = 3;

	private const int cVchDate = 4;

	private const int cTagNo = 5;

	private const int cItemName = 6;

	private const int cPcs = 7;

	private const int cGrWt = 8;

	private const int cKrNwt = 9;

	private const int cKrTch = 10;

	private const int cKrWest = 11;

	private const int cKrFine = 12;

	private const int cNetWt = 13;

	private const int cTouch = 14;

	private const int cWest = 15;

	private const int cFine = 16;

	private const int cTagPf = 17;

	private const int cAvgFine = 18;

	private const int cDiffFine = 19;

	private const int cAvgTouch = 20;

	private const int cSign = 21;

	private const int cBookCode = 22;

	private const int cBookName = 23;

	private const int cItCode = 24;

	private const int cAcCode = 25;

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
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_CellContentClick);
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			DevComponents.DotNetBar.Controls.DataGridViewX val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((DataGridView)val3).CellFormatting -= val2;
			}
			_DGV = value;
			val3 = _DGV;
			if (val3 != null)
			{
				((DataGridView)val3).CellContentClick += val;
				((Control)val3).DoubleClick += eventHandler;
				((DataGridView)val3).CellFormatting += val2;
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

	internal virtual QButton BtnGroup
	{
		[CompilerGenerated]
		get
		{
			return _BtnGroup;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnGroup_Click;
			QButton val = _BtnGroup;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnGroup = value;
			val = _BtnGroup;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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

	internal virtual QButton BtnTrading
	{
		[CompilerGenerated]
		get
		{
			return _BtnTrading;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnTrading_Click;
			QButton val = _BtnTrading;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnTrading = value;
			val = _BtnTrading;
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

	public int newindex { get; set; }

	public RP_STOCK_FINE()
	{
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		((Form)this).Load += RP_STOCK_FINE_Load;
		((Form)this).Deactivate += RP_STOCK_FINE_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_STOCK_FINE_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_STOCK_FINE_KeyDown);
		((Form)this).Activated += RP_STOCK_FINE_Activated;
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
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0306: Expected O, but got Unknown
		//IL_0369: Unknown result type (might be due to invalid IL or missing references)
		//IL_0373: Expected O, but got Unknown
		//IL_041c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0426: Expected O, but got Unknown
		//IL_0531: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_0658: Unknown result type (might be due to invalid IL or missing references)
		//IL_0662: Expected O, but got Unknown
		//IL_06c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_06cf: Expected O, but got Unknown
		//IL_0778: Unknown result type (might be due to invalid IL or missing references)
		//IL_0782: Expected O, but got Unknown
		//IL_07e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_07ef: Expected O, but got Unknown
		//IL_08c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_08d0: Expected O, but got Unknown
		//IL_093e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0948: Expected O, but got Unknown
		//IL_0a17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a21: Expected O, but got Unknown
		//IL_0ab6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac0: Expected O, but got Unknown
		//IL_0b3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b48: Expected O, but got Unknown
		//IL_0c2a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c34: Expected O, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Expected O, but got Unknown
		//IL_0d55: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d5f: Expected O, but got Unknown
		//IL_0dc8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd2: Expected O, but got Unknown
		//IL_0f39: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f43: Expected O, but got Unknown
		//IL_0fdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fe9: Expected O, but got Unknown
		//IL_106f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1079: Expected O, but got Unknown
		//IL_1160: Unknown result type (might be due to invalid IL or missing references)
		//IL_116a: Expected O, but got Unknown
		//IL_11d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11dd: Expected O, but got Unknown
		//IL_128b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1295: Expected O, but got Unknown
		//IL_12fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_1308: Expected O, but got Unknown
		//IL_15a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_15c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_15eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_160f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1638: Unknown result type (might be due to invalid IL or missing references)
		//IL_1642: Expected O, but got Unknown
		//IL_1665: Unknown result type (might be due to invalid IL or missing references)
		//IL_16c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_16ce: Expected O, but got Unknown
		//IL_18e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1904: Unknown result type (might be due to invalid IL or missing references)
		//IL_1928: Unknown result type (might be due to invalid IL or missing references)
		//IL_194c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1975: Unknown result type (might be due to invalid IL or missing references)
		//IL_197f: Expected O, but got Unknown
		//IL_19a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c05: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c29: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c4d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c71: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c9a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ca4: Expected O, but got Unknown
		//IL_1cc7: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d3e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d48: Expected O, but got Unknown
		//IL_1ddc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1de6: Expected O, but got Unknown
		//IL_1e66: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e70: Expected O, but got Unknown
		//IL_1f07: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f11: Expected O, but got Unknown
		//IL_1fe6: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff0: Expected O, but got Unknown
		//IL_205d: Unknown result type (might be due to invalid IL or missing references)
		//IL_2067: Expected O, but got Unknown
		//IL_2142: Unknown result type (might be due to invalid IL or missing references)
		//IL_214c: Expected O, but got Unknown
		//IL_21bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_21c6: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_STOCK_FINE));
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
		BtnGroup = new QButton();
		BtnItem = new QButton();
		BtnTrading = new QButton();
		mFromDt = new MaskedTextBox();
		mToDt = new MaskedTextBox();
		Label2 = new Label();
		Label4 = new Label();
		cboProduct = new ComboBox();
		Label5 = new Label();
		cboGroup = new ComboBox();
		Label6 = new Label();
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
		lblBook.Text = "Stock Fine Report";
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
		((QControl)BtnGroup).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnGroup).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroup).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnGroup).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.MidnightBlue, false);
		((QControl)BtnGroup).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnGroup).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnGroup).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnGroup).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnGroup).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnGroup.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnGroup.Image = null;
		((QControl)BtnGroup).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnGroup).Location = new Point(675, 86);
		((Control)BtnGroup).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnGroup).Name = "BtnGroup";
		((Control)BtnGroup).Size = new Size(143, 37);
		((Control)BtnGroup).TabIndex = 7;
		BtnGroup.Text = "&Group";
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
		((Control)BtnItem).Location = new Point(838, 86);
		((Control)BtnItem).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnItem).Name = "BtnItem";
		((Control)BtnItem).Size = new Size(143, 37);
		((Control)BtnItem).TabIndex = 5;
		BtnItem.Text = "&Item";
		((QControl)BtnTrading).ColorScheme.ButtonBackground1.SetColor("LunaBlue", Color.FromArgb(224, 224, 224), false);
		((QControl)BtnTrading).ColorScheme.ButtonBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrading).ColorScheme.ButtonBorder.SetColor("LunaBlue", Color.FromArgb(192, 0, 0), false);
		((QControl)BtnTrading).ColorScheme.ButtonFocusedInnerGlow.SetColor("LunaBlue", Color.FromArgb(255, 128, 0), false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBackground1.SetColor("LunaBlue", Color.White, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBackground2.SetColor("LunaBlue", Color.Gray, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTrading).ColorScheme.ButtonHotText.SetColor("LunaBlue", Color.FromArgb(64, 0, 64), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBackground1.SetColor("LunaBlue", Color.FromArgb(255, 224, 192), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBackground2.SetColor("LunaBlue", Color.FromArgb(255, 192, 128), false);
		((QControl)BtnTrading).ColorScheme.ButtonPressedBorder.SetColor("LunaBlue", Color.Maroon, false);
		((QControl)BtnTrading).ColorScheme.ButtonText.SetColor("LunaBlue", Color.White, false);
		((QColorSchemeBase)((QControl)BtnTrading).ColorScheme).CurrentTheme = "LunaOlive";
		((QColorSchemeBase)((QControl)BtnTrading).ColorScheme).InheritCurrentThemeFromGlobal = false;
		BtnTrading.Configuration.FontDefinition = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionFocused = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionHot = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Configuration.FontDefinitionPressed = new QFontDefinition("Calibri", false, false, false, false, 13f);
		BtnTrading.Image = null;
		((QControl)BtnTrading).LocalFont = new Font("Segoe UI Semibold", 9.75f, (FontStyle)1);
		((Control)BtnTrading).Location = new Point(1000, 86);
		((Control)BtnTrading).Margin = new Padding(3, 6, 3, 6);
		((Control)BtnTrading).Name = "BtnTrading";
		((Control)BtnTrading).Size = new Size(143, 37);
		((Control)BtnTrading).TabIndex = 11;
		BtnTrading.Text = "T&rading";
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
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
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
		((Control)this).Controls.Add((Control)(object)BtnGroup);
		((Control)this).Controls.Add((Control)(object)BtnItem);
		((Control)this).Controls.Add((Control)(object)BtnTrading);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_STOCK_FINE";
		((Form)this).Text = "Stock Fine Report";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV).EndInit();
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)DGV_VCH).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void DGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		//IL_188b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1895: Expected O, but got Unknown
		//IL_18c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d6: Expected O, but got Unknown
		//IL_18ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_18f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18fb: Expected O, but got Unknown
		//IL_1911: Unknown result type (might be due to invalid IL or missing references)
		//IL_1916: Unknown result type (might be due to invalid IL or missing references)
		//IL_1920: Expected O, but got Unknown
		//IL_253b: Unknown result type (might be due to invalid IL or missing references)
		//IL_2545: Expected O, but got Unknown
		((Control)DGV).Visible = false;
		BtnExit.Text = "&Back";
		((DataGridView)DGV_VCH).DataSource = null;
		((DataGridView)DGV_VCH).ClearSelection();
		((DataGridView)DGV_VCH).Rows.Clear();
		((DataGridView)DGV_VCH).Columns.Clear();
		((Control)DGV_VCH).Refresh();
		int columnIndex = ((DataGridView)DGV).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV).CurrentRow).Index;
		if (cboStockType.SelectedIndex == 1)
		{
			DC_Main.RsQry += "AND A.TAG_NO <> 'N'";
		}
		else if (cboStockType.SelectedIndex == 2)
		{
			DC_Main.RsQry += "AND A.TAG_NO = 'N'";
		}
		if (Operators.CompareString(RptZoom, "Group", false) == 0)
		{
			switch (columnIndex)
			{
			default:
				return;
			case 4:
			case 5:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 6:
			case 7:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 8:
			case 9:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 10:
			case 11:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 12:
			case 13:
			case 14:
			case 15:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 16:
			case 17:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.GR_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			}
		}
		else if (Operators.CompareString(RptZoom, "Item", false) == 0)
		{
			switch (columnIndex)
			{
			default:
				return;
			case 4:
			case 5:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 6:
			case 7:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 8:
			case 9:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 10:
			case 11:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 12:
			case 13:
			case 14:
			case 15:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "));
				break;
			case 16:
			case 17:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" AND C.IT_CODE ='"), ((DataGridView)DGV)[1, index].Value), (object)"' "), Interaction.IIf(cboStockType.SelectedIndex == 1, (object)"AND A.TAG_NO <> 'N'", (object)"")), (object)" and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			}
		}
		else
		{
			switch (columnIndex)
			{
			default:
				return;
			case 4:
			case 5:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 6:
			case 7:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'P' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 8:
			case 9:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '+' AND A.TR_TYPE = 'I' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 10:
			case 11:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'O' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 12:
			case 13:
			case 14:
			case 15:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.ITM_SIGN = '-' AND A.TR_TYPE = 'S' AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
				break;
			case 16:
			case 17:
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.BOOK_SNAME,E.AC_NAME,A.VCH_NO,A.VCH_DATE,A.TAG_NO,C.IT_NAME,A.ITM_PCS,A.ITM_GWT,A.ITM_NWT,A.KR_FINE,A.ITM_FINE,A.ITM_SIGN,A.CO_BOOK,B.MAIN_BOOK,A.IT_CODE,A.AC_CODE,C.AVG_TOUCH,A.ITM_TOUCH,A.ITM_WEST,A.KR_NWT,A.KR_TOUCH,A.KR_WEST FROM ((MAIN_STOCK AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN ITEM_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.IT_CODE = C.IT_CODE) LEFT JOIN AC_MAST AS E ON A.CO_CODE = E.CO_CODE AND A.AC_CODE = E.AC_CODE  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND C.TRAD_TYPE ='"), ((DataGridView)DGV)[1, index].Value), (object)"'and  C.IT_TYPE ='"), ((DataGridView)DGV)[3, index].Value), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)"   AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"'"));
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
			((DataGridView)DGV_VCH).Columns.Add("", "KrNwt");
			((DataGridView)DGV_VCH).Columns[9].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "KrTch");
			((DataGridView)DGV_VCH).Columns[10].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[10].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "KrWest");
			((DataGridView)DGV_VCH).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[11].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "KrFine");
			((DataGridView)DGV_VCH).Columns[12].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "NetWt");
			((DataGridView)DGV_VCH).Columns[13].Width = (int)Math.Round(85.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[13].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "Touch");
			((DataGridView)DGV_VCH).Columns[14].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[14].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "West");
			((DataGridView)DGV_VCH).Columns[15].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[15].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_VCH).Columns.Add("", "Fine");
			((DataGridView)DGV_VCH).Columns[16].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_VCH).Columns.Add("", "TagPf");
			((DataGridView)DGV_VCH).Columns[17].Width = (int)Math.Round(80.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_VCH).Columns[17].DefaultCellStyle.Format = "N3";
			if (unchecked(columnIndex == 12 || columnIndex == 13 || columnIndex == 14 || columnIndex == 15 || columnIndex == 16 || columnIndex == 17))
			{
				((DataGridView)DGV_VCH).Columns.Add("", "AvgFine");
				((DataGridView)DGV_VCH).Columns[18].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[18].DefaultCellStyle.Format = "N3";
				if (unchecked(columnIndex == 16 || columnIndex == 17))
				{
					((DataGridView)DGV_VCH).Columns.Add("", "Profit");
					((DataGridView)DGV_VCH).Columns[19].Visible = false;
				}
				else
				{
					((DataGridView)DGV_VCH).Columns.Add("", "Profit");
					((DataGridView)DGV_VCH).Columns[19].Width = (int)Math.Round(80.0 * ColCon);
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_VCH).Columns[19].DefaultCellStyle.Format = "N3";
				}
				((DataGridView)DGV_VCH).Columns.Add("", "ATch%");
				((DataGridView)DGV_VCH).Columns[20].Width = (int)Math.Round(65.0 * ColCon);
				((DataGridView)DGV_VCH).Columns[20].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_VCH).Columns[20].DefaultCellStyle.Format = "N2";
			}
			else
			{
				((DataGridView)DGV_VCH).Columns.Add("", "AvgFine");
				((DataGridView)DGV_VCH).Columns[18].Visible = false;
				((DataGridView)DGV_VCH).Columns.Add("", "Profit");
				((DataGridView)DGV_VCH).Columns[19].Visible = false;
				((DataGridView)DGV_VCH).Columns.Add("", "AvgTch");
				((DataGridView)DGV_VCH).Columns[20].Visible = false;
			}
			((DataGridView)DGV_VCH).Columns.Add("", "Sign");
			((DataGridView)DGV_VCH).Columns[21].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_VCH).Columns[21].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_VCH).Columns.Add("", "CoBook");
			((DataGridView)DGV_VCH).Columns[22].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "MainBook");
			((DataGridView)DGV_VCH).Columns[23].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "ItCode");
			((DataGridView)DGV_VCH).Columns[24].Visible = false;
			((DataGridView)DGV_VCH).Columns.Add("", "AcCode");
			((DataGridView)DGV_VCH).Columns[25].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			DC_Main.R = 0;
			if (RsStk.Rows.Count > 0)
			{
				int num10 = RsStk.Rows.Count - 1;
				for (index = 0; index <= num10; index++)
				{
					DevComponents.DotNetBar.Controls.DataGridViewX dGV_VCH = DGV_VCH;
					((DataGridView)dGV_VCH).Rows.Add();
					((DataGridView)dGV_VCH)[0, DC_Main.R].Value = DC_Main.R + 1;
					((DataGridView)dGV_VCH)[1, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["BOOK_SNAME"]);
					((DataGridView)dGV_VCH)[2, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["AC_NAME"]);
					((DataGridView)dGV_VCH)[3, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["VCH_NO"]);
					((DataGridView)dGV_VCH)[4, DC_Main.R].Value = Strings.Format(RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_VCH)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["TAG_NO"]);
					((DataGridView)dGV_VCH)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["IT_NAME"]);
					((DataGridView)dGV_VCH)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_PCS"]);
					((DataGridView)dGV_VCH)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_GWT"]);
					((DataGridView)dGV_VCH)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["KR_NWT"]);
					((DataGridView)dGV_VCH)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["KR_TOUCH"]);
					((DataGridView)dGV_VCH)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["KR_WEST"]);
					((DataGridView)dGV_VCH)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["KR_FINE"]);
					((DataGridView)dGV_VCH)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_NWT"]);
					((DataGridView)dGV_VCH)[14, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_TOUCH"]);
					((DataGridView)dGV_VCH)[15, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_WEST"]);
					((DataGridView)dGV_VCH)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_FINE"]);
					if (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value)) != 0.0)
					{
						((DataGridView)dGV_VCH)[17, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[16, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value))), "0.000");
					}
					else
					{
						((DataGridView)dGV_VCH)[17, DC_Main.R].Value = "";
					}
					unchecked
					{
						if (columnIndex == 12 || columnIndex == 13 || columnIndex == 14 || columnIndex == 15 || columnIndex == 16 || columnIndex == 17)
						{
							((DataGridView)dGV_VCH)[20, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["AVG_TOUCH"]);
							if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[20, DC_Main.R].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value)) != 0.0))
							{
								((DataGridView)dGV_VCH)[18, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value)) * Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[20, DC_Main.R].Value)) / 100.0;
							}
							((DataGridView)dGV_VCH)[19, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[16, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[18, DC_Main.R].Value));
						}
						((DataGridView)dGV_VCH)[21, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["ITM_SIGN"]);
						((DataGridView)dGV_VCH)[22, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["CO_BOOK"]);
						((DataGridView)dGV_VCH)[23, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["MAIN_BOOK"]);
						((DataGridView)dGV_VCH)[24, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["IT_CODE"]);
						((DataGridView)dGV_VCH)[25, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStk.Rows[index]["AC_CODE"]);
						if (columnIndex == 16 || columnIndex == 17)
						{
							if (Operators.ConditionalCompareObjectEqual(((DataGridView)dGV_VCH)[21, DC_Main.R].Value, (object)"+", false))
							{
								num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
								num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
								num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
								num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[16, DC_Main.R].Value));
								num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
								num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
								num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[18, DC_Main.R].Value));
								num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[17, DC_Main.R].Value));
							}
							else
							{
								num -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
								num2 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
								num3 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
								num4 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[16, DC_Main.R].Value));
								num5 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
								num6 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
								num7 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[18, DC_Main.R].Value));
								num9 -= Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[17, DC_Main.R].Value));
							}
						}
						else
						{
							num += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[7, DC_Main.R].Value));
							num2 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[8, DC_Main.R].Value));
							num3 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[13, DC_Main.R].Value));
							num4 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[16, DC_Main.R].Value));
							num5 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[9, DC_Main.R].Value));
							num6 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[12, DC_Main.R].Value));
							num7 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[18, DC_Main.R].Value));
							num9 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[17, DC_Main.R].Value));
						}
						num8 += Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV_VCH)[19, DC_Main.R].Value));
					}
					DC_Main.R++;
					dGV_VCH = null;
				}
			}
			if (((DataGridView)DGV_VCH).Rows.Count >= 1)
			{
				((DataGridView)DGV_VCH).Rows.Add();
				((DataGridView)DGV_VCH).Rows.Add();
			}
			int num11 = ((DataGridView)DGV_VCH).Rows.Count - 1;
			if (num11 > 1)
			{
				((DataGridView)DGV_VCH).Rows[num11].Cells[2].Value = "Total :";
				((DataGridView)DGV_VCH).Rows[num11].Cells[7].Value = num;
				((DataGridView)DGV_VCH).Rows[num11].Cells[8].Value = num2;
				((DataGridView)DGV_VCH).Rows[num11].Cells[13].Value = num3;
				((DataGridView)DGV_VCH).Rows[num11].Cells[16].Value = num4;
				((DataGridView)DGV_VCH).Rows[num11].Cells[9].Value = num5;
				((DataGridView)DGV_VCH).Rows[num11].Cells[12].Value = num6;
				((DataGridView)DGV_VCH).Rows[num11].Cells[17].Value = num9;
				((DataGridView)DGV_VCH).Rows[num11].Cells[18].Value = num7;
				((DataGridView)DGV_VCH).Rows[num11].Cells[19].Value = num8;
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
					switch (try0001_dispatch)
					{
					default:
						num2 = 1;
						if (Operators.CompareString(UserPrint, "Y", false) != 0)
						{
							goto IL_001e;
						}
						goto IL_0034;
					case 1891:
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
								goto IL_012e;
							case 13:
								goto IL_0145;
							case 14:
								goto IL_018d;
							case 15:
								goto IL_019c;
							case 16:
								goto IL_01b9;
							case 17:
								goto IL_01d3;
							case 18:
								goto IL_01f6;
							case 19:
							case 20:
								goto IL_024b;
							case 21:
								goto IL_025d;
							case 23:
								goto IL_027f;
							case 24:
								goto IL_0296;
							case 25:
								goto IL_02de;
							case 26:
								goto IL_02ed;
							case 27:
								goto IL_030a;
							case 28:
								goto IL_0324;
							case 29:
								goto IL_0347;
							case 30:
							case 31:
								goto IL_03a5;
							case 32:
								goto IL_03b7;
							case 22:
							case 33:
							case 34:
								goto IL_03d3;
							case 35:
								goto IL_03dd;
							case 36:
								goto IL_0430;
							case 37:
								goto IL_0485;
							case 38:
								goto IL_04dd;
							case 39:
								goto IL_054b;
							case 40:
								goto IL_058e;
							case 41:
								goto IL_05bd;
							case 42:
								goto IL_0600;
							case 43:
								goto IL_0641;
							case 44:
								goto IL_0662;
							case 45:
								goto IL_0670;
							case 46:
								goto IL_0676;
							case 47:
								goto IL_067c;
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
						IL_02de:
						num2 = 25;
						num5++;
						goto IL_02e7;
						IL_0296:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num5 + 1,
							((DataGridView)DGV).Columns[num5].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02de;
						IL_0347:
						num2 = 29;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num6 + 1,
							((DataGridView)DGV)[num6, DC_Main.i].Value.ToString() ?? ""
						}, (string[])null, (Type[])null);
						goto IL_03a5;
						IL_03a5:
						num2 = 31;
						num6++;
						goto IL_03ae;
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
						if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
						{
							goto IL_012e;
						}
						goto IL_027f;
						IL_012e:
						num2 = 12;
						num7 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num8 = 0;
						goto IL_0196;
						IL_0196:
						if (num8 <= num7)
						{
							goto IL_0145;
						}
						goto IL_019c;
						IL_019c:
						num2 = 15;
						num9 = ((DataGridView)DGV_VCH).RowCount - 1;
						DC_Main.i = 0;
						goto IL_026c;
						IL_026c:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_03d3;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_VCH).ColumnCount - 1;
						num11 = 0;
						goto IL_0254;
						IL_0254:
						if (num11 <= num10)
						{
							goto IL_01d3;
						}
						goto IL_025d;
						IL_025d:
						num2 = 21;
						DC_Main.i++;
						goto IL_026c;
						IL_01d3:
						num2 = 17;
						if (((DataGridView)DGV_VCH)[num11, DC_Main.i].Value != null)
						{
							goto IL_01f6;
						}
						goto IL_024b;
						IL_01f6:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_VCH)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_024b;
						IL_024b:
						num2 = 20;
						num11++;
						goto IL_0254;
						IL_0145:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_VCH).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_018d;
						IL_018d:
						num2 = 14;
						num8++;
						goto IL_0196;
						IL_027f:
						num2 = 23;
						num12 = ((DataGridView)DGV).ColumnCount - 1;
						num5 = 0;
						goto IL_02e7;
						IL_02e7:
						if (num5 <= num12)
						{
							goto IL_0296;
						}
						goto IL_02ed;
						IL_02ed:
						num2 = 26;
						num13 = ((DataGridView)DGV).RowCount - 1;
						DC_Main.i = 0;
						goto IL_03c6;
						IL_03c6:
						if (DC_Main.i <= num13)
						{
							goto IL_030a;
						}
						goto IL_03d3;
						IL_03d3:
						num2 = 34;
						colorConverter = new ColorConverter();
						goto IL_03dd;
						IL_03dd:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0430;
						IL_0430:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_0485;
						IL_0485:
						num2 = 37;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04dd;
						IL_04dd:
						num2 = 38;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_054b;
						IL_054b:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_058e;
						IL_058e:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05bd;
						IL_05bd:
						num2 = 41;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0600;
						IL_0600:
						num2 = 42;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0641;
						IL_0641:
						num2 = 43;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0662;
						IL_0662:
						num2 = 44;
						Cursor.Current = Cursors.Default;
						goto IL_0670;
						IL_0670:
						num2 = 45;
						obj = null;
						goto IL_0676;
						IL_0676:
						num2 = 46;
						obj3 = null;
						goto IL_067c;
						IL_067c:
						num2 = 47;
						obj2 = null;
						break;
						IL_030a:
						num2 = 27;
						num14 = ((DataGridView)DGV).ColumnCount - 1;
						num6 = 0;
						goto IL_03ae;
						IL_03ae:
						if (num6 <= num14)
						{
							goto IL_0324;
						}
						goto IL_03b7;
						IL_03b7:
						num2 = 32;
						DC_Main.i++;
						goto IL_03c6;
						IL_0324:
						num2 = 28;
						if (((DataGridView)DGV)[num6, DC_Main.i].Value != null)
						{
							goto IL_0347;
						}
						goto IL_03a5;
						end_IL_0001_2:
						break;
					}
					num2 = 48;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 1891;
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

	private void RP_STOCK_FINE_Load(object sender, EventArgs e)
	{
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Expected O, but got Unknown
		//IL_0cac: Unknown result type (might be due to invalid IL or missing references)
		//IL_0cb3: Expected O, but got Unknown
		//IL_0d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d33: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d3d: Expected O, but got Unknown
		//IL_0dc5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dca: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dd4: Expected O, but got Unknown
		//IL_0e46: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e51: Expected O, but got Unknown
		//IL_0f03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f12: Expected O, but got Unknown
		//IL_0f31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f36: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f40: Expected O, but got Unknown
		//IL_0f5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f64: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f6e: Expected O, but got Unknown
		//IL_0ff0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fff: Expected O, but got Unknown
		//IL_101e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1023: Unknown result type (might be due to invalid IL or missing references)
		//IL_102d: Expected O, but got Unknown
		//IL_104c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1051: Unknown result type (might be due to invalid IL or missing references)
		//IL_105b: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
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
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mToDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mToDt).Font;
				try
				{
					foreach (Control control4 in ((Control)this).Controls)
					{
						Control val3 = control4;
						if (unchecked(val3 is TextBox || val3 is Label || val3 is ComboBox || val3 is MaskedTextBox || val3 is SimpleButton || val3 is SearchControl || val3 is CheckBox) && Operators.CompareString(val3.Name, "lblBook", false) != 0)
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
					foreach (object control5 in ((Control)PnlBotam).Controls)
					{
						object objectValue3 = RuntimeHelpers.GetObjectValue(control5);
						NewLateBinding.LateSet(objectValue3, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
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
					((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_VCH).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_VCH).Font.Style);
					((DataGridView)DGV_VCH).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_VCH).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_VCH).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_VCH).RowTemplate.Height * (1.0 + num2));
				}
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
				int num4 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num4)
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
				int num5 = DC_Main.Rshlp.Rows.Count - 1;
				DC_Main.X = 0;
				while (DC_Main.X <= num5)
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

	private void RP_STOCK_FINE_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_STOCK_FINE_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_STOCK_FINE_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Invalid comparison between Unknown and I4
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Invalid comparison between Unknown and I4
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Invalid comparison between Unknown and I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c3: Invalid comparison between Unknown and I4
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Invalid comparison between Unknown and I4
		Keys keyCode = e.KeyCode;
		if ((int)keyCode == (0x49 & (0 - (e.Alt ? 1 : 0))))
		{
			BtnItem_Click(BtnItem, new EventArgs());
			((Control)BtnItem).Focus();
		}
		else if ((int)keyCode == (0x50 & (0 - (e.Alt ? 1 : 0))))
		{
			BtnTrading_Click(BtnTrading, new EventArgs());
			((Control)BtnTrading).Focus();
		}
		else if ((int)keyCode == (0x47 & (0 - (e.Alt ? 1 : 0))))
		{
			BtnGroup_Click(BtnGroup, new EventArgs());
			((Control)BtnGroup).Focus();
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
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_STOCK_FINE_Activated(object sender, EventArgs e)
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

	private void Stock_Summ(string RptType)
	{
		string text = "A.KR_FINE";
		switch (RptType)
		{
		case "Group":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.GR_CODE AS Code ,C.GR_NAME AS Name,B.IT_TYPE As ItType,C.AVG_FINE As ClWt,C.AVG_TOUCH,C.OP_TOUCH,C.OP_FINE, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_NWT ELSE  -A.ITM_NWT END) ELSE 0 END) AS OpNwt,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text + " ELSE -" + text + " END) ELSE 0 END) AS OpFwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS PrNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text + " ELSE 0 END) ELSE 0 END) AS PrFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS InNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text + " ELSE 0 END) ELSE 0 END) AS InFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS OutNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text + " ELSE 0 END) ELSE 0 END) AS OutFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS SlNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS SlFwt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN GROUP_MAST AS C ON B.CO_CODE = C.CO_CODE AND B.GR_CODE = C.GR_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.RATE_TYPE <> 'P' AND B.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'"));
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
			DC_Main.RsQry += "GROUP BY B.GR_CODE,C.GR_NAME,B.IT_TYPE,C.AVG_FINE,C.AVG_TOUCH,C.OP_TOUCH,C.OP_FINE ORDER BY C.GR_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Trading":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.TRAD_TYPE AS Code ,C.TRAD_NAME AS Name,B.IT_TYPE As ItType,C.AVG_FINE As ClWt,C.AVG_TOUCH,C.OP_TOUCH,C.OP_FINE, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_NWT ELSE  -A.ITM_NWT END) ELSE 0 END) AS OpNwt,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text + " ELSE -" + text + " END) ELSE 0 END) AS OpFwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS PrNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text + " ELSE 0 END) ELSE 0 END) AS PrFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS InNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text + " ELSE 0 END) ELSE 0 END) AS InFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS OutNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text + " ELSE 0 END) ELSE 0 END) AS OutFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS SlNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS SlFwt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM (MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE) LEFT JOIN BAL_GR AS C ON B.CO_CODE = C.CO_CODE AND B.TRAD_TYPE = C.TRAD_TYPE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.RATE_TYPE <> 'P' AND B.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'"));
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
			DC_Main.RsQry += "GROUP BY B.TRAD_TYPE,C.TRAD_NAME,B.IT_TYPE,C.AVG_FINE,C.AVG_TOUCH,C.OP_TOUCH,C.OP_FINE ORDER BY C.TRAD_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
		case "Item":
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT B.IT_CODE AS Code ,B.IT_NAME AS Name,B.IT_TYPE As ItType,B.AVG_FINE As ClWt,B.AVG_TOUCH,B.OP_TOUCH,B.OP_FINE, SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN  A.ITM_NWT ELSE  -A.ITM_NWT END) ELSE 0 END) AS OpNwt,SUM(CASE WHEN A.VCH_DATE <  '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' THEN (CASE WHEN ITM_SIGN = '+' THEN " + text + " ELSE -" + text + " END) ELSE 0 END) AS OpFwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS PrNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'P' THEN " + text + " ELSE 0 END) ELSE 0 END) AS PrFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS InNwt,SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '+' AND TR_TYPE = 'I' THEN " + text + " ELSE 0 END) ELSE 0 END) AS InFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS OutNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'O' THEN " + text + " ELSE 0 END) ELSE 0 END) AS OutFwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_NWT ELSE 0 END) ELSE 0 END) AS SlNwt, SUM(CASE WHEN A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  THEN (CASE WHEN ITM_SIGN = '-' AND TR_TYPE = 'S' THEN A.ITM_FINE ELSE 0 END) ELSE 0 END) AS SlFwt, SUM(CASE WHEN A.VCH_DATE <=  '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' THEN(CASE WHEN ITM_SIGN = '+' THEN A.ITM_NWT ELSE -A.ITM_NWT END) ELSE 0 END) AS ClNwt FROM MAIN_STOCK AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND B.RATE_TYPE <> 'P' AND B.IT_TYPE = '"), (object)Strings.Mid(cboItemTyp.Text, 1, 1)), (object)"'"));
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
			DC_Main.RsQry += "GROUP BY B.IT_CODE,B.IT_NAME,B.IT_TYPE,B.AVG_FINE,B.AVG_TOUCH,B.OP_TOUCH,B.OP_FINE ORDER BY B.IT_NAME";
			RsStkSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			break;
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
		//IL_0ac2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0acc: Expected O, but got Unknown
		//IL_0b3e: Unknown result type (might be due to invalid IL or missing references)
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
			((DataGridView)DGV).Columns.Add("", "Op Nwt");
			((DataGridView)DGV).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[4].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Op Fine");
			((DataGridView)DGV).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[5].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Pr Nwt");
			((DataGridView)DGV).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[6].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Pr Fine");
			((DataGridView)DGV).Columns[7].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "In Nwt");
			((DataGridView)DGV).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "In Fine");
			((DataGridView)DGV).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[9].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Out Nwt");
			((DataGridView)DGV).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Out Fine");
			((DataGridView)DGV).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Sl Nwt");
			((DataGridView)DGV).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Sl Fine");
			((DataGridView)DGV).Columns[13].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[13].DefaultCellStyle.Format = "N3";
			if (Operators.CompareString(RptType, "I", false) == 0)
			{
				((DataGridView)DGV).Columns.Add("", "Avg Fine");
				((DataGridView)DGV).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[14].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV).Columns.Add("", "Pf Fine");
				((DataGridView)DGV).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV).Columns[15].DefaultCellStyle.Format = "N3";
			}
			else
			{
				((DataGridView)DGV).Columns.Add("", "Avg Fine");
				((DataGridView)DGV).Columns[14].Visible = false;
				((DataGridView)DGV).Columns.Add("", "Pf Fine");
				((DataGridView)DGV).Columns[15].Visible = false;
			}
			((DataGridView)DGV).Columns.Add("", "Cl Nwt");
			((DataGridView)DGV).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "Cl Fine");
			((DataGridView)DGV).Columns[17].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[17].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV).Columns.Add("", "ATh%");
			((DataGridView)DGV).Columns[18].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV).Columns[18].DefaultCellStyle.Format = "N2";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (Operators.CompareString(DC_Main.MsFineStkType, "A", false) == 0)
			{
				Dgv_Group_Stock();
			}
			else if (Operators.CompareString(DC_Main.MsFineStkType, "N", false) == 0)
			{
				Dgv_Net_Stock();
			}
			else if (Operators.CompareString(DC_Main.MsFineStkType, "G", false) == 0)
			{
				Dgv_Group_Stock();
			}
			else
			{
				Interaction.MsgBox((object)"Please Select Stock Type in Setting Average Wise or Net Wise  and Try....", (MsgBoxStyle)0, (object)null);
			}
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
					double num2 = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["AVG_TOUCH"], (object)""));
					double num3 = Conversion.Val(Operators.ConcatenateObject(RsStkSum.Rows[DC_Main.M]["OP_TOUCH"], (object)""));
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpNwt"]);
					unchecked
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpNwt"])) != 0.0 && num3 != 0.0)
						{
							((DataGridView)dGV)[5, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["OpNwt"], (object)num3), (object)100);
						}
						((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrNwt"]);
						((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrFwt"]);
						((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InNwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[9, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["InNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutNwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[11, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["OutNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlNwt"]);
						((DataGridView)dGV)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlFwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[14, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["SlNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[15, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)) - Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[14, DC_Main.R].Value));
						((DataGridView)dGV)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["ClNwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["ClNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[17, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["ClNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)num2, "0.00");
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
			num4 = 0.0;
			int num18 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num18; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[8].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[10].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
					num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[13].Value, (object)""));
					num14 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[14].Value, (object)""));
					num15 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[15].Value, (object)""));
					num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[16].Value, (object)""));
					num17 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[17].Value, (object)""));
				}
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num19 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num19].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num19].Cells[4].Value = num4;
				((DataGridView)DGV).Rows[num19].Cells[5].Value = num5;
				((DataGridView)DGV).Rows[num19].Cells[6].Value = num6;
				((DataGridView)DGV).Rows[num19].Cells[7].Value = num7;
				((DataGridView)DGV).Rows[num19].Cells[8].Value = num8;
				((DataGridView)DGV).Rows[num19].Cells[9].Value = num9;
				((DataGridView)DGV).Rows[num19].Cells[10].Value = num10;
				((DataGridView)DGV).Rows[num19].Cells[11].Value = num11;
				((DataGridView)DGV).Rows[num19].Cells[12].Value = num12;
				((DataGridView)DGV).Rows[num19].Cells[13].Value = num13;
				((DataGridView)DGV).Rows[num19].Cells[14].Value = num14;
				((DataGridView)DGV).Rows[num19].Cells[15].Value = num15;
				((DataGridView)DGV).Rows[num19].Cells[16].Value = num16;
				((DataGridView)DGV).Rows[num19].Cells[17].Value = num17;
			}
		}
	}

	private void Dgv_Net_Stock()
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
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpNwt"]);
					((DataGridView)dGV)[5, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpFwt"]);
					((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrNwt"]);
					((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrFwt"]);
					((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InNwt"]);
					((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InFwt"]);
					((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutNwt"]);
					((DataGridView)dGV)[11, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutFwt"]);
					((DataGridView)dGV)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlNwt"]);
					((DataGridView)dGV)[13, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlFwt"]);
					((DataGridView)dGV)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["ClNwt"]);
					((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)));
					((DataGridView)dGV)[18, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["AVG_TOUCH"]);
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
			num2 = 0.0;
			int num14 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num14; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[8].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[10].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[13].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[16].Value, (object)""));
					num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[17].Value, (object)""));
				}
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num15 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num15].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num15].Cells[4].Value = num2;
				((DataGridView)DGV).Rows[num15].Cells[5].Value = num3;
				((DataGridView)DGV).Rows[num15].Cells[6].Value = num4;
				((DataGridView)DGV).Rows[num15].Cells[7].Value = num5;
				((DataGridView)DGV).Rows[num15].Cells[8].Value = num6;
				((DataGridView)DGV).Rows[num15].Cells[9].Value = num7;
				((DataGridView)DGV).Rows[num15].Cells[10].Value = num8;
				((DataGridView)DGV).Rows[num15].Cells[11].Value = num9;
				((DataGridView)DGV).Rows[num15].Cells[12].Value = num10;
				((DataGridView)DGV).Rows[num15].Cells[13].Value = num11;
				((DataGridView)DGV).Rows[num15].Cells[16].Value = num12;
				((DataGridView)DGV).Rows[num15].Cells[17].Value = num13;
			}
		}
	}

	private void Dgv_Fine_Stock()
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
					if (Operators.CompareString(RptType, "G", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.GR_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0  and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TR_TYPE = 'P' AND B.GR_CODE = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' GROUP BY B.GR_CODE "));
					}
					else if (Operators.CompareString(RptType, "T", false) == 0)
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.TRAD_TYPE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0  and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TR_TYPE = 'P' AND B.TRAD_TYPE = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' GROUP BY B.TRAD_TYPE "));
					}
					else
					{
						DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0  and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TR_TYPE = 'P' AND B.IT_CODE = '"), RsStkSum.Rows[DC_Main.M]["Code"]), (object)"' GROUP BY B.IT_CODE "));
					}
					DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					DC_Main.X = 0;
					double num2 = 0.0;
					double num3 = 0.0;
					double num4 = 0.0;
					while (DC_Main.X < DC_Main.Tbl.Rows.Count)
					{
						num2 = 0.0;
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TotFine"])) != 0.0))
						{
							num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TotFine"])) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.X]["TotNetWt"]));
						}
						DC_Main.X++;
					}
					((DataGridView)dGV)[4, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpNwt"]);
					unchecked
					{
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OpNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[5, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["OpNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[6, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrNwt"]);
						((DataGridView)dGV)[7, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["PrFwt"]);
						((DataGridView)dGV)[8, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InNwt"]);
						((DataGridView)dGV)[9, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["InFwt"]);
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[4, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[6, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[8, DC_Main.R].Value));
						num4 = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value));
						if (num3 != 0.0 && num4 != 0.0)
						{
							num2 = Conversions.ToDouble(Strings.Format((object)(num4 * 100.0 / num3), "0.000"));
						}
						((DataGridView)dGV)[10, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutNwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["OutNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[11, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["OutNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[12, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlNwt"]);
						if (Conversion.Val(RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["SlNwt"])) != 0.0 && num2 != 0.0)
						{
							((DataGridView)dGV)[13, DC_Main.R].Value = Operators.DivideObject(Operators.MultiplyObject(RsStkSum.Rows[DC_Main.M]["SlNwt"], (object)num2), (object)100);
						}
						((DataGridView)dGV)[16, DC_Main.R].Value = RuntimeHelpers.GetObjectValue(RsStkSum.Rows[DC_Main.M]["ClNwt"]);
						((DataGridView)dGV)[17, DC_Main.R].Value = Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[5, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[7, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[9, DC_Main.R].Value)) - (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[11, DC_Main.R].Value)) + Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[13, DC_Main.R].Value)));
						if ((Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value)) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value)) != 0.0))
						{
							((DataGridView)dGV)[18, DC_Main.R].Value = Strings.Format((object)(Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[17, DC_Main.R].Value)) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)dGV)[16, DC_Main.R].Value))), "0.000");
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
			num5 = 0.0;
			int num17 = ((DataGridView)DGV).Rows.Count - 1;
			for (int i = 0; i <= num17; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[2].Value, (object)""), (object)"Total :", false))
				{
					((DataGridView)DGV).Rows[i].Cells[0].Value = i + 1;
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[4].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[5].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[6].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[7].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[8].Value, (object)""));
					num10 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[9].Value, (object)""));
					num11 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[10].Value, (object)""));
					num12 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[11].Value, (object)""));
					num13 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[12].Value, (object)""));
					num14 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[13].Value, (object)""));
					num15 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[16].Value, (object)""));
					num16 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV).Rows[i].Cells[17].Value, (object)""));
				}
			}
			if (((DataGridView)DGV).Rows.Count - 1 > 1)
			{
				int num18 = ((DataGridView)DGV).Rows.Count - 1;
				((DataGridView)DGV).Rows[num18].Cells[2].Value = "Total :";
				((DataGridView)DGV).Rows[num18].Cells[4].Value = num5;
				((DataGridView)DGV).Rows[num18].Cells[5].Value = num6;
				((DataGridView)DGV).Rows[num18].Cells[6].Value = num7;
				((DataGridView)DGV).Rows[num18].Cells[7].Value = num8;
				((DataGridView)DGV).Rows[num18].Cells[8].Value = num9;
				((DataGridView)DGV).Rows[num18].Cells[9].Value = num10;
				((DataGridView)DGV).Rows[num18].Cells[10].Value = num11;
				((DataGridView)DGV).Rows[num18].Cells[11].Value = num12;
				((DataGridView)DGV).Rows[num18].Cells[12].Value = num13;
				((DataGridView)DGV).Rows[num18].Cells[13].Value = num14;
				((DataGridView)DGV).Rows[num18].Cells[16].Value = num15;
				((DataGridView)DGV).Rows[num18].Cells[17].Value = num16;
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
					if ((uint)(columnIndex - 4) <= 13u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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
					ProjectData.ClearProjectError();
					num2 = 2;
					switch (e.ColumnIndex)
					{
					case 7:
					case 8:
					case 13:
					case 14:
					case 15:
					case 16:
					case 18:
					case 19:
					case 20:
						if (((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
						break;
					case 9:
					case 10:
					case 11:
					case 12:
					case 17:
						break;
					}
					break;
				case 161:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00d7;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 161;
				continue;
			}
			break;
			IL_00d7:
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

	public void OpTouch()
	{
		DataTable dataTable = new DataTable();
		DataTable dataTable2 = new DataTable();
		DC_Main.ExeQuteDc("UPDATE ITEM_MAST SET OP_TOUCH = 0,OP_FINE = 0 WHERE  CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.ExeQuteDc("UPDATE GROUP_MAST SET OP_TOUCH = 0,OP_FINE = 0 WHERE  CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.ExeQuteDc("UPDATE BAL_GR SET OP_TOUCH = 0,OP_FINE = 0 WHERE  CO_CODE = '" + DC_Main.MCo_code + "'");
		DC_Main.RsQry = "Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN KR_NWT ELSE 0 END) AS TotNetWt,SUM(CASE WHEN ITM_SIGN = '+' THEN KR_FINE ELSE 0 END) AS TotFine FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.IT_TYPE IN ('G','S') AND A.KR_FINE <> 0  and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.TR_TYPE IN ('P','I') GROUP BY A.IT_CODE ";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.M = 0;
		checked
		{
			while (DC_Main.M < DC_Main.Tbl.Rows.Count)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotFine"])) != 0.0))
				{
					num = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotFine"])) * 100.0 / Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"]));
					DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND A.IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'  and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE "));
					dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
					if (dataTable2.Rows.Count > 0)
					{
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable2.Rows[0]["TotNetWt"])) * num / 100.0;
					}
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET OP_TOUCH = " + Strings.Format((object)num, "0.00") + ",OP_FINE = " + Strings.Format((object)num2, "0.000") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'")));
				}
				else
				{
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE ITEM_MAST SET OP_TOUCH = 100,OP_FINE = " + Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])), "0.000") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_CODE = '"), DC_Main.Tbl.Rows[DC_Main.M]["IT_CODE"]), (object)"'")));
				}
				DC_Main.M++;
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
			DC_Main.RsQry = "Select GR_CODE FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY GR_CODE ORDER BY GR_CODE ";
			dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				double num4 = 0.0;
				double num5 = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.M = 0;
				while (DC_Main.M < DC_Main.Tbl.Rows.Count)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["AVG_TOUCH"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["AVG_TOUCH"]));
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])) * num / 100.0;
						num4 += num3;
						num5 += num2;
					}
					DC_Main.M++;
				}
				if (num4 + num5 != 0.0)
				{
					double num = num5 * 100.0 / num4;
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE GROUP_MAST SET OP_TOUCH = " + Strings.Format((object)num, "0.000") + ",OP_FINE = " + Strings.Format((object)num5, "0.000") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND GR_CODE = '"), dataTable.Rows[i]["GR_CODE"]), (object)"'")));
				}
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
			dataTable.Rows.Clear();
			dataTable.Columns.Clear();
			dataTable2.Rows.Clear();
			dataTable2.Columns.Clear();
			DC_Main.RsQry = "Select TRAD_TYPE FROM ITEM_MAST  WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND IT_TYPE IN ('G','S') GROUP BY TRAD_TYPE ORDER BY TRAD_TYPE ";
			dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				double num4 = 0.0;
				double num5 = 0.0;
				DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.IT_CODE,B.AVG_TOUCH, SUM(CASE WHEN ITM_SIGN = '+' THEN ITM_NWT ELSE -ITM_NWT END) AS TotNetWt FROM MAIN_STOCK AS A INNER JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.CO_YEAR = '" + DC_Main.MCo_year + "' AND B.TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.IT_CODE,B.AVG_TOUCH "));
				DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				DC_Main.M = 0;
				while (DC_Main.M < DC_Main.Tbl.Rows.Count)
				{
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					if ((Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])) != 0.0) & (Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["AVG_TOUCH"])) != 0.0))
					{
						num = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["AVG_TOUCH"]));
						num3 = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"]));
						num2 = Conversion.Val(RuntimeHelpers.GetObjectValue(DC_Main.Tbl.Rows[DC_Main.M]["TotNetWt"])) * num / 100.0;
						num4 += num3;
						num5 += num2;
					}
					DC_Main.M++;
				}
				if (num4 + num5 != 0.0)
				{
					double num = num5 * 100.0 / num4;
					DC_Main.ExeQuteDc(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("UPDATE BAL_GR SET OP_TOUCH = " + Strings.Format((object)num, "0.000") + ",OP_FINE = " + Strings.Format((object)num5, "0.000") + " WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND TRAD_TYPE = '"), dataTable.Rows[i]["TRAD_TYPE"]), (object)"'")));
				}
			}
			DC_Main.Tbl.Rows.Clear();
			DC_Main.Tbl.Columns.Clear();
			dataTable.Rows.Clear();
			dataTable.Columns.Clear();
			dataTable2.Rows.Clear();
			dataTable2.Columns.Clear();
		}
	}

	private void BtnGroup_Click(object sender, EventArgs e)
	{
		RptZoom = "Group";
		RptType = "G";
		BtnBack();
		DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), DC_Main.MLc_code);
		OpTouch();
		Stock_Summ("Group");
	}

	private void BtnItem_Click(object sender, EventArgs e)
	{
		RptZoom = "Item";
		RptType = "I";
		BtnBack();
		DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), DC_Main.MLc_code);
		OpTouch();
		Stock_Summ("Item");
	}

	private void BtnTrading_Click(object sender, EventArgs e)
	{
		RptZoom = "Trading";
		RptType = "T";
		BtnBack();
		DC_Main.AvgTouch(Conversions.ToDate(mToDt.Text), DC_Main.MLc_code);
		OpTouch();
		Stock_Summ("Trading");
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
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "'  AND CO_BOOK = '"), ((DataGridView)DGV_VCH).Rows[((DataGridViewBand)((DataGridView)DGV_VCH).CurrentRow).Index].Cells[22].Value), (object)""), (object)"' "));
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
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
		else if ((Operators.CompareString(DC_Main.CurBookMain, "WH SALES", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "RATE CUT", false) == 0))
		{
			TR_WH_SALE tR_WH_SALE = new TR_WH_SALE();
			((Form)tR_WH_SALE).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_WH_SALE).Show();
			((Control)tR_WH_SALE).Focus();
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

	private void cboProduct_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			((Control)cboGroup).Focus();
		}
	}
}
