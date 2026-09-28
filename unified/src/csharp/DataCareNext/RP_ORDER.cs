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
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;

namespace DataCareNext;

[DesignerGenerated]
public class RP_ORDER : Form
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
	[AccessedThroughProperty("DGV_AC")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearch")]
	private SearchControl _tSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboCity")]
	private ComboBox _cboCity;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("cboArea")]
	private ComboBox _cboArea;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkZero")]
	private CheckBox _chkZero;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkOpBal")]
	private CheckBox _chkOpBal;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mToDt")]
	private MaskedTextBox _mToDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("mFromDt")]
	private MaskedTextBox _mFromDt;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DEL")]
	private DevComponents.DotNetBar.Controls.DataGridViewX _DGV_DEL;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private bool DgvAcEnter;

	private int DgvCurRow;

	private string CurRpt;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private const int c1SrNo = 0;

	private const int c1BookName = 1;

	private const int c1VchNo = 2;

	private const int c1VchSr = 3;

	private const int c1DelDate = 4;

	private const int c1VchDate = 5;

	private const int c1AcName = 6;

	private const int c1AcCode = 7;

	private const int c1ValDr = 8;

	private const int c1ValCr = 9;

	private const int c1FineType = 10;

	private const int c1FineDr = 11;

	private const int c1FineCr = 12;

	private const int c1MainUser = 13;

	private const int c1DelUser = 14;

	private const int c1VchDesc = 15;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cMobile = 3;

	private const int cDelDate = 4;

	private const int cOrderAmt = 5;

	private const int cOrderAdjAmt = 6;

	private const int cOrderBalAmt = 7;

	private const int cAddress = 8;

	private const int cAcCity = 9;

	private const int cOrdItmTotal = 10;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2AcName = 4;

	private const int c2OrdAmt = 5;

	private const int c2OrdAdjAmt = 6;

	private const int c2BalAmt = 7;

	private const int c2CoBook = 8;

	private const int c2AcCode = 9;

	private const int c2MainBook = 10;

	private const int clSrNo = 0;

	private const int clLotNo = 1;

	private const int clLotDate = 2;

	private const int clEmpName = 3;

	private const int clKrName = 4;

	private const int clLotItem = 5;

	private const int clLotPcs = 6;

	private const int clLotGwt = 7;

	private const int clLotNwt = 8;

	private const int clItmPcs = 9;

	private const int clItmGwt = 10;

	private const int clItmNwt = 11;

	private const int clAdjWt = 12;

	private const int clDiffPcs = 13;

	private const int clDiffGwt = 14;

	private const int clDiffNwt = 15;

	private const int clAcCode = 16;

	private const int clLotItCode = 17;

	private const int czSrNo = 0;

	private const int czVchType = 1;

	private const int czVchNo = 2;

	private const int czVchDate = 3;

	private const int czLotNo = 4;

	private const int czItCode = 5;

	private const int czTagNo = 6;

	private const int czEmp = 7;

	private const int czLotPcs = 8;

	private const int czLotGwt = 9;

	private const int czLotNwt = 10;

	private const int czTagPcs = 11;

	private const int czTagGwt = 12;

	private const int czTagOth = 13;

	private const int czTagNwt = 14;

	private const int czCoBook = 15;

	private const int czMainBook = 16;

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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_AC
	{
		[CompilerGenerated]
		get
		{
			return _DGV_AC;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			//IL_002e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0034: Expected O, but got Unknown
			EventHandler eventHandler = DGV_DoubleClick;
			DataGridViewCellEventHandler val = new DataGridViewCellEventHandler(DGV_RowEnter);
			DataGridViewCellFormattingEventHandler val2 = new DataGridViewCellFormattingEventHandler(DGV_CellFormatting);
			KeyEventHandler val3 = new KeyEventHandler(DGV_KeyDown);
			DevComponents.DotNetBar.Controls.DataGridViewX val4 = _DGV_AC;
			if (val4 != null)
			{
				((Control)val4).DoubleClick -= eventHandler;
				((DataGridView)val4).RowEnter -= val;
				((DataGridView)val4).CellFormatting -= val2;
				((Control)val4).KeyDown -= val3;
			}
			_DGV_AC = value;
			val4 = _DGV_AC;
			if (val4 != null)
			{
				((Control)val4).DoubleClick += eventHandler;
				((DataGridView)val4).RowEnter += val;
				((DataGridView)val4).CellFormatting += val2;
				((Control)val4).KeyDown += val3;
			}
		}
	}

	internal virtual SearchControl tSearch
	{
		[CompilerGenerated]
		get
		{
			return _tSearch;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSearch_TextChanged;
			SearchControl val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSearch = value;
			val = _tSearch;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	internal virtual SearchControl tSerchAll
	{
		[CompilerGenerated]
		get
		{
			return _tSerchAll;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = tSerchAll_TextChanged;
			SearchControl val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged -= eventHandler;
			}
			_tSerchAll = value;
			val = _tSerchAll;
			if (val != null)
			{
				((Control)val).TextChanged += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("PnlAcSumm")]
	private virtual Panel _PnlAcSumm;

	internal virtual Panel PnlAcSumm
	{
		get
		{
			return _PnlAcSumm;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_PnlAcSumm = value;
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DETL
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
				((Control)val2).DoubleClick -= eventHandler;
			}
			_DGV_DETL = value;
			val2 = _DGV_DETL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
				((Control)val2).DoubleClick += eventHandler;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblCity")]
	private virtual Label _lblCity;

	internal virtual Label lblCity
	{
		get
		{
			return _lblCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblCity = value;
		}
	}

	internal virtual ComboBox cboCity
	{
		[CompilerGenerated]
		get
		{
			return _cboCity;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboCity_KeyDown);
			EventHandler eventHandler = cboCity_Click;
			EventHandler eventHandler2 = cboCity_SelectedIndexChanged;
			ComboBox val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				((Control)val2).Click -= eventHandler;
				val2.SelectedIndexChanged -= eventHandler2;
			}
			_cboCity = value;
			val2 = _cboCity;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				((Control)val2).Click += eventHandler;
				val2.SelectedIndexChanged += eventHandler2;
			}
		}
	}

	internal virtual ComboBox cboArea
	{
		[CompilerGenerated]
		get
		{
			return _cboArea;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			KeyEventHandler val = new KeyEventHandler(cboArea_KeyDown);
			EventHandler eventHandler = cboArea_SelectedIndexChanged;
			ComboBox val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown -= val;
				val2.SelectedIndexChanged -= eventHandler;
			}
			_cboArea = value;
			val2 = _cboArea;
			if (val2 != null)
			{
				((Control)val2).KeyDown += val;
				val2.SelectedIndexChanged += eventHandler;
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

	internal virtual CheckBox chkZero
	{
		[CompilerGenerated]
		get
		{
			return _chkZero;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkZero_CheckedChanged;
			CheckBox val = _chkZero;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkZero = value;
			val = _chkZero;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
			}
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
	[AccessedThroughProperty("lblMobile")]
	private virtual Label _lblMobile;

	internal virtual Label lblMobile
	{
		get
		{
			return _lblMobile;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblMobile = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("lblAdd1")]
	private virtual Label _lblAdd1;

	internal virtual Label lblAdd1
	{
		get
		{
			return _lblAdd1;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_lblAdd1 = value;
		}
	}

	internal virtual CheckBox chkOpBal
	{
		[CompilerGenerated]
		get
		{
			return _chkOpBal;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = chkOpBal_CheckedChanged;
			CheckBox val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged -= eventHandler;
			}
			_chkOpBal = value;
			val = _chkOpBal;
			if (val != null)
			{
				val.CheckedChanged += eventHandler;
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

	internal virtual DevComponents.DotNetBar.Controls.DataGridViewX DGV_DEL
	{
		[CompilerGenerated]
		get
		{
			return _DGV_DEL;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DEL_CellFormatting);
			DevComponents.DotNetBar.Controls.DataGridViewX val2 = _DGV_DEL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting -= val;
			}
			_DGV_DEL = value;
			val2 = _DGV_DEL;
			if (val2 != null)
			{
				((DataGridView)val2).CellFormatting += val;
			}
		}
	}

	public int newindex { get; set; }

	public RP_ORDER()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Activated += RP_ORDER_Activated;
		((Form)this).Load += RP_ORDER_Load;
		((Form)this).Deactivate += RP_ORDER_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_ORDER_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_ORDER_KeyDown);
		((Form)this).Closed += RP_ORDER_Closed;
		DgvAcEnter = false;
		DgvCurRow = 0;
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
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Expected O, but got Unknown
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Expected O, but got Unknown
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected O, but got Unknown
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Expected O, but got Unknown
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Expected O, but got Unknown
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Expected O, but got Unknown
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e2: Expected O, but got Unknown
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Expected O, but got Unknown
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Expected O, but got Unknown
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Expected O, but got Unknown
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0120: Unknown result type (might be due to invalid IL or missing references)
		//IL_012a: Expected O, but got Unknown
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0136: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Expected O, but got Unknown
		//IL_0150: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0166: Expected O, but got Unknown
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_0172: Expected O, but got Unknown
		//IL_0174: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Expected O, but got Unknown
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_018a: Expected O, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0196: Expected O, but got Unknown
		//IL_0198: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ae: Expected O, but got Unknown
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ba: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_0300: Unknown result type (might be due to invalid IL or missing references)
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Expected O, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_0479: Unknown result type (might be due to invalid IL or missing references)
		//IL_0483: Expected O, but got Unknown
		//IL_05a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_05aa: Expected O, but got Unknown
		//IL_060d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_06c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ca: Expected O, but got Unknown
		//IL_072d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0857: Unknown result type (might be due to invalid IL or missing references)
		//IL_0861: Expected O, but got Unknown
		//IL_0900: Unknown result type (might be due to invalid IL or missing references)
		//IL_090a: Expected O, but got Unknown
		//IL_09df: Unknown result type (might be due to invalid IL or missing references)
		//IL_09e9: Expected O, but got Unknown
		//IL_0a57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a61: Expected O, but got Unknown
		//IL_0b30: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b3a: Expected O, but got Unknown
		//IL_0bcf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bd9: Expected O, but got Unknown
		//IL_0c57: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c61: Expected O, but got Unknown
		//IL_0d43: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4d: Expected O, but got Unknown
		//IL_0db6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0dc0: Expected O, but got Unknown
		//IL_0e84: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e8e: Expected O, but got Unknown
		//IL_0efa: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f00: Expected O, but got Unknown
		//IL_0f02: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f08: Expected O, but got Unknown
		//IL_0f79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f83: Expected O, but got Unknown
		//IL_0fef: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ff5: Expected O, but got Unknown
		//IL_0ff7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffd: Expected O, but got Unknown
		//IL_11cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d5: Expected O, but got Unknown
		//IL_1271: Unknown result type (might be due to invalid IL or missing references)
		//IL_127b: Expected O, but got Unknown
		//IL_1301: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Expected O, but got Unknown
		//IL_13f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_13fc: Expected O, but got Unknown
		//IL_1465: Unknown result type (might be due to invalid IL or missing references)
		//IL_146f: Expected O, but got Unknown
		//IL_154c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1556: Expected O, but got Unknown
		//IL_15d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_15da: Expected O, but got Unknown
		//IL_16b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_16bf: Expected O, but got Unknown
		//IL_1739: Unknown result type (might be due to invalid IL or missing references)
		//IL_1743: Expected O, but got Unknown
		//IL_17f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_17fe: Expected O, but got Unknown
		//IL_1895: Unknown result type (might be due to invalid IL or missing references)
		//IL_189f: Expected O, but got Unknown
		//IL_191f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1929: Expected O, but got Unknown
		//IL_19d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_19de: Expected O, but got Unknown
		//IL_1a55: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a5f: Expected O, but got Unknown
		//IL_1ae3: Unknown result type (might be due to invalid IL or missing references)
		//IL_1aed: Expected O, but got Unknown
		//IL_1bba: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bc4: Expected O, but got Unknown
		//IL_1c60: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c6a: Expected O, but got Unknown
		//IL_1cf0: Unknown result type (might be due to invalid IL or missing references)
		//IL_1cfa: Expected O, but got Unknown
		//IL_1de1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1deb: Expected O, but got Unknown
		//IL_1e54: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e5e: Expected O, but got Unknown
		//IL_1f13: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f1d: Expected O, but got Unknown
		//IL_1fec: Unknown result type (might be due to invalid IL or missing references)
		//IL_1ff6: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_ORDER));
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
		DataGridViewCellStyle val11 = new DataGridViewCellStyle();
		DataGridViewCellStyle val12 = new DataGridViewCellStyle();
		DataGridViewCellStyle val13 = new DataGridViewCellStyle();
		DataGridViewCellStyle val14 = new DataGridViewCellStyle();
		DataGridViewCellStyle val15 = new DataGridViewCellStyle();
		PnlBotam = new FlowLayoutPanel();
		BtnExit = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnSave = new SimpleButton();
		Panel1 = new Panel();
		lblMobile = new Label();
		lblAdd1 = new Label();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		DGV_AC = new DevComponents.DotNetBar.Controls.DataGridViewX();
		tSearch = new SearchControl();
		tSerchAll = new SearchControl();
		PnlAcSumm = new Panel();
		DGV_DEL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		cboArea = new ComboBox();
		Label17 = new Label();
		cboCity = new ComboBox();
		lblCity = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		Label3 = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DevComponents.DotNetBar.Controls.DataGridViewX();
		chkZero = new CheckBox();
		chkOpBal = new CheckBox();
		((Control)PnlBotam).SuspendLayout();
		((Control)Panel1).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((ISupportInitialize)tSearch.Properties).BeginInit();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)DGV_DEL).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)Panel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 1;
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
		((Control)BtnExit).TabIndex = 0;
		BtnExit.Text = "E&xit";
		((BaseButton)BtnExit).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnCancel).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnCancel).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnCancel).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnCancel).Appearance.Options.UseForeColor = true;
		BtnCancel.ImageOptions.Location = (ImageLocation)1;
		((ImageCollectionImageOptions)BtnCancel.ImageOptions).SvgImage = Resources.grandtotalsoffrowscolumnspivottable;
		((Control)BtnCancel).Location = new Point(1118, 3);
		((BaseControl)BtnCancel).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnCancel).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnCancel).Name = "BtnCancel";
		((Control)BtnCancel).Size = new Size(91, 37);
		((Control)BtnCancel).TabIndex = 1;
		BtnCancel.Text = "&Cancel";
		((BaseButton)BtnCancel).ToolTipAnchor = (ToolTipAnchor)1;
		((BaseStyleControl)BtnPrint).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnPrint).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnPrint).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnPrint).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnPrint.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnPrint.ImageOptions.SvgImage");
		((Control)BtnPrint).Location = new Point(1021, 3);
		((BaseControl)BtnPrint).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnPrint).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnPrint).Name = "BtnPrint";
		((Control)BtnPrint).Size = new Size(91, 37);
		((Control)BtnPrint).TabIndex = 3;
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
		((Control)BtnSave).TabIndex = 2;
		BtnSave.Text = "&Excel";
		((BaseButton)BtnSave).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)Panel1).Controls.Add((Control)(object)lblMobile);
		((Control)Panel1).Controls.Add((Control)(object)lblAdd1);
		((Control)Panel1).Location = new Point(591, 3);
		((Control)Panel1).Name = "Panel1";
		((Control)Panel1).Size = new Size(327, 38);
		((Control)Panel1).TabIndex = 11;
		((Control)lblMobile).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblMobile).ForeColor = Color.White;
		lblMobile.ImeMode = (ImeMode)0;
		((Control)lblMobile).Location = new Point(23, 18);
		((Control)lblMobile).Name = "lblMobile";
		((Control)lblMobile).RightToLeft = (RightToLeft)1;
		((Control)lblMobile).Size = new Size(301, 20);
		((Control)lblMobile).TabIndex = 1140;
		lblMobile.Text = "Mobile";
		((Control)lblAdd1).Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)lblAdd1).ForeColor = Color.White;
		lblAdd1.ImeMode = (ImeMode)0;
		((Control)lblAdd1).Location = new Point(23, 0);
		((Control)lblAdd1).Name = "lblAdd1";
		((Control)lblAdd1).RightToLeft = (RightToLeft)1;
		((Control)lblAdd1).Size = new Size(301, 20);
		((Control)lblAdd1).TabIndex = 1139;
		lblAdd1.Text = "Address";
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
		lblBook.Text = "Order Zoom Report";
		lblBook.TextAlign = (ContentAlignment)32;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val.BackColor = Color.PapayaWhip;
		val.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val.ForeColor = Color.FromArgb(64, 64, 64);
		val.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val;
		((DataGridView)DGV_AC).BackgroundColor = Color.Snow;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val2.ForeColor = Color.FromArgb(64, 64, 64);
		val2.SelectionBackColor = SystemColors.ScrollBar;
		val2.SelectionForeColor = Color.White;
		val2.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val2;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val3.Alignment = (DataGridViewContentAlignment)16;
		val3.BackColor = SystemColors.Window;
		val3.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val3.ForeColor = Color.FromArgb(64, 64, 64);
		val3.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val3.SelectionForeColor = Color.Maroon;
		val3.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val3;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_AC).Location = new Point(16, 46);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		((DataGridView)DGV_AC).ReadOnly = true;
		val4.Alignment = (DataGridViewContentAlignment)16;
		val4.BackColor = Color.MintCream;
		val4.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val4.ForeColor = SystemColors.WindowText;
		val4.SelectionBackColor = SystemColors.Highlight;
		val4.SelectionForeColor = SystemColors.HighlightText;
		val4.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val4;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val5.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val5.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val5;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_AC).Size = new Size(1160, 467);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((Control)tSearch).Location = new Point(241, 11);
		((Control)tSearch).Name = "tSearch";
		((RepositoryItem)tSearch.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSearch.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSearch.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSearch.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((Control)tSearch).Size = new Size(150, 24);
		((Control)tSearch).TabIndex = 2;
		((Control)tSerchAll).Location = new Point(397, 11);
		((Control)tSerchAll).Name = "tSerchAll";
		((RepositoryItem)tSerchAll.Properties).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((RepositoryItem)tSerchAll.Properties).Appearance.ForeColor = Color.Navy;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseFont = true;
		((RepositoryItem)tSerchAll.Properties).Appearance.Options.UseForeColor = true;
		((EditorButtonCollection)tSerchAll.Properties.Buttons).AddRange((EditorButton[])(object)new EditorButton[2]
		{
			(EditorButton)new ClearButton(),
			(EditorButton)new SearchButton()
		});
		((RepositoryItemTextEdit)tSerchAll.Properties).NullValuePrompt = "Ac Or Mobile Search";
		((Control)tSerchAll).Size = new Size(150, 24);
		((Control)tSerchAll).TabIndex = 3;
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_DEL);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboArea);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label17);
		((Control)PnlAcSumm).Controls.Add((Control)(object)cboCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)lblCity);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSearch);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mToDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)mFromDt);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label3);
		((Control)PnlAcSumm).Location = new Point(-1, 33);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 529);
		((Control)PnlAcSumm).TabIndex = 0;
		((DataGridView)DGV_DEL).AllowUserToAddRows = false;
		((DataGridView)DGV_DEL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DEL).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DGV_DEL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DEL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DEL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DGV_DEL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DEL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DEL).DefaultCellStyle = val8;
		((DataGridView)DGV_DEL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DEL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DEL).Location = new Point(17, 46);
		((Control)DGV_DEL).Name = "DGV_DEL";
		DGV_DEL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DEL).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DEL).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DGV_DEL).RowHeadersVisible = false;
		((DataGridView)DGV_DEL).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DEL).RowsDefaultCellStyle = val10;
		DGV_DEL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DEL.SelectAllSignVisible = false;
		((DataGridView)DGV_DEL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DEL).Size = new Size(1159, 467);
		((DataGridView)DGV_DEL).StandardTab = true;
		((Control)DGV_DEL).TabIndex = 1157;
		((Control)DGV_DEL).Visible = false;
		cboArea.AutoCompleteMode = (AutoCompleteMode)3;
		cboArea.AutoCompleteSource = (AutoCompleteSource)256;
		cboArea.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboArea).Font = new Font("Tahoma", 9f);
		((ListControl)cboArea).FormattingEnabled = true;
		((Control)cboArea).Location = new Point(846, 14);
		((Control)cboArea).Name = "cboArea";
		((Control)cboArea).Size = new Size(111, 22);
		((Control)cboArea).TabIndex = 5;
		((Control)Label17).BackColor = Color.Transparent;
		((Control)Label17).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label17).ForeColor = Color.Black;
		Label17.ImeMode = (ImeMode)0;
		((Control)Label17).Location = new Point(763, 14);
		((Control)Label17).Name = "Label17";
		((Control)Label17).Size = new Size(74, 19);
		((Control)Label17).TabIndex = 1140;
		Label17.Text = "Area";
		Label17.TextAlign = (ContentAlignment)64;
		cboCity.AutoCompleteMode = (AutoCompleteMode)3;
		cboCity.AutoCompleteSource = (AutoCompleteSource)256;
		cboCity.BackColor = Color.FromArgb(255, 224, 192);
		((Control)cboCity).Font = new Font("Tahoma", 9f);
		((ListControl)cboCity).FormattingEnabled = true;
		((Control)cboCity).Location = new Point(640, 13);
		((Control)cboCity).Name = "cboCity";
		((Control)cboCity).Size = new Size(120, 22);
		((Control)cboCity).TabIndex = 4;
		((Control)lblCity).BackColor = Color.Transparent;
		((Control)lblCity).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)lblCity).ForeColor = Color.Black;
		lblCity.ImeMode = (ImeMode)0;
		((Control)lblCity).Location = new Point(554, 13);
		((Control)lblCity).Name = "lblCity";
		((Control)lblCity).Size = new Size(78, 19);
		((Control)lblCity).TabIndex = 1138;
		lblCity.Text = "City";
		lblCity.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(147, 11);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(65, 11);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((Control)Label3).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label3).ForeColor = Color.Black;
		Label3.ImeMode = (ImeMode)0;
		((Control)Label3).Location = new Point(15, 11);
		((Control)Label3).Name = "Label3";
		((Control)Label3).Size = new Size(44, 20);
		((Control)Label3).TabIndex = 1156;
		Label3.Text = "Date";
		Label3.TextAlign = (ContentAlignment)64;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(106, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 3;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(188, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(272, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(13, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Party Code";
		Label2.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_DETL).AllowUserToAddRows = false;
		((DataGridView)DGV_DETL).AllowUserToDeleteRows = false;
		((DataGridView)DGV_DETL).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_DETL).ColumnHeadersHeight = 30;
		((DataGridView)DGV_DETL).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_DETL).DefaultCellStyle = val13;
		((DataGridView)DGV_DETL).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_DETL).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_DETL).Location = new Point(13, 79);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
		((DataGridView)DGV_DETL).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_DETL).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_DETL).RowHeadersVisible = false;
		((DataGridView)DGV_DETL).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_DETL).RowsDefaultCellStyle = val15;
		DGV_DETL.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_DETL.SelectAllSignVisible = false;
		((DataGridView)DGV_DETL).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DGV_DETL).Size = new Size(1159, 473);
		((DataGridView)DGV_DETL).StandardTab = true;
		((Control)DGV_DETL).TabIndex = 1133;
		((ButtonBase)chkZero).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkZero).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkZero).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkZero).Location = new Point(16, 7);
		((Control)chkZero).Name = "chkZero";
		((Control)chkZero).RightToLeft = (RightToLeft)0;
		((Control)chkZero).Size = new Size(141, 19);
		((Control)chkZero).TabIndex = 2;
		((ButtonBase)chkZero).Text = "With Zero Balance";
		chkZero.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkZero).UseVisualStyleBackColor = false;
		((ButtonBase)chkOpBal).BackColor = Color.FromArgb(255, 224, 192);
		((Control)chkOpBal).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkOpBal).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkOpBal).Location = new Point(188, 7);
		((Control)chkOpBal).Name = "chkOpBal";
		((Control)chkOpBal).RightToLeft = (RightToLeft)0;
		((Control)chkOpBal).Size = new Size(141, 20);
		((Control)chkOpBal).TabIndex = 3;
		((ButtonBase)chkOpBal).Text = "Opning Balance";
		((ButtonBase)chkOpBal).UseVisualStyleBackColor = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)chkOpBal);
		((Control)this).Controls.Add((Control)(object)chkZero);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_ORDER";
		((Form)this).Text = "Order Zoom";
		((Control)PnlBotam).ResumeLayout(false);
		((Control)Panel1).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((ISupportInitialize)tSearch.Properties).EndInit();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)DGV_DEL).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void RP_ORDER_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
		{
			DeleteData();
		}
		else if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DGV_DETL_POINT_FILL();
			}
			else
			{
				PointSumm();
			}
		}
		else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DGV_DETL_LOT_FILL();
			}
			else
			{
				DGV_Lot_FILL();
			}
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			DGV_DETL_FILL();
		}
		else
		{
			AcSumm();
		}
		CurActCtrl.Focus();
	}

	private void DGV_DETL_LOT_FILL()
	{
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Expected O, but got Unknown
		//IL_01a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b4: Expected O, but got Unknown
		//IL_01ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fe: Expected O, but got Unknown
		//IL_0aba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ac4: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT A.VCH_DATE,A.CO_BOOK,A.VCH_NO,A.SR_NO,A.LOT_NO,A.IT_CODE As ItCode,A.TAG_NO,A.IT_PCS,A.IT_GWT,A.IT_NWT,0 As TagPcs,0 As TagGwt,0 As TagNwt,A.EMP_CODE,B.BOOK_SNAME,B.MAIN_BOOK FROM LOT_DETL AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE  AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.IT_SIGN = '+' AND A.LOT_NO = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' "), (object)" UNION ALL SELECT C.VCH_DATE,C.CO_BOOK,C.VCH_NO,C.SR_NO,C.LOT_NO,C.TAG_IT_CODE,C.TAG_NO,0,0,0,C.IT_PCS,C.IT_GWT,C.IT_NWT,C.EMP_CODE,D.BOOK_SNAME,D.MAIN_BOOK FROM LOT_DETL As C LEFT JOIN BOOK_DATA As D On C.CO_CODE = D.CO_CODE And C.CO_BOOK = D.CO_BOOK WHERE C.CO_CODE = '"), (object)DC_Main.MCo_code), (object)"' AND C.LC_CODE = '"), (object)DC_Main.MLc_code), (object)"' AND C.IT_SIGN = '-' AND C.LOT_NO = '"), ((DataGridView)DGV_AC)[1, ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index].Value), (object)"' ORDER BY A.VCH_DATE,A.SR_NO "));
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_DETL).MultiSelect = false;
				((DataGridView)DGV_DETL).AutoGenerateColumns = false;
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV_DETL).ColumnCount = 17;
				((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "BOOK_SNAME";
				((DataGridView)DGV_DETL).Columns[1].HeaderText = "Book";
				((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_DETL).Columns[2].HeaderText = "VchNo";
				((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_DETL).Columns[3].HeaderText = "VchDate";
				((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[4].DataPropertyName = "LOT_NO";
				((DataGridView)DGV_DETL).Columns[4].HeaderText = "LotNo";
				((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[5].DataPropertyName = "ItCode";
				((DataGridView)DGV_DETL).Columns[5].HeaderText = "ItCode";
				((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "TAG_NO";
				((DataGridView)DGV_DETL).Columns[6].HeaderText = "TagNo";
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "";
				((DataGridView)DGV_DETL).Columns[7].HeaderText = "Emp";
				((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "IT_PCS";
				((DataGridView)DGV_DETL).Columns[8].HeaderText = "LPcs";
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N0";
				((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "IT_GWT";
				((DataGridView)DGV_DETL).Columns[9].HeaderText = "LGwt";
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "IT_NWT";
				((DataGridView)DGV_DETL).Columns[10].HeaderText = "LNwt";
				((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[11].DataPropertyName = "TagPcs";
				((DataGridView)DGV_DETL).Columns[11].HeaderText = "TPcs";
				((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N0";
				((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[12].DataPropertyName = "TagGwt";
				((DataGridView)DGV_DETL).Columns[12].HeaderText = "TGwt";
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[13].DataPropertyName = "";
				((DataGridView)DGV_DETL).Columns[13].HeaderText = "TOth";
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(75.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[14].DataPropertyName = "TagNwt";
				((DataGridView)DGV_DETL).Columns[14].HeaderText = "TNwt";
				((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_DETL).Columns[15].Visible = false;
				((DataGridView)DGV_DETL).Columns[15].DataPropertyName = "CO_BOOK";
				((DataGridView)DGV_DETL).Columns[15].HeaderText = "BookCode";
				((DataGridView)DGV_DETL).Columns[16].Visible = false;
				((DataGridView)DGV_DETL).Columns[16].DataPropertyName = "MAIN_BOOK";
				((DataGridView)DGV_DETL).Columns[16].HeaderText = "MainBook";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV_DETL).DataSource = dataView;
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					dataView.AddNew();
					dataView.AddNew();
				}
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				int num5 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[4].Value, (object)""), (object)"Total :", false))
					{
						((DataGridView)DGV_DETL)[0, i].Value = i + 1;
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[11].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[12].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[14].Value, (object)""));
						((DataGridView)DGV_DETL)[13, i].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[12].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[14].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[13].Value, (object)""));
					}
				}
				int num6 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num6].Cells[4].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num6].Cells[11].Value = num;
				((DataGridView)DGV_DETL).Rows[num6].Cells[12].Value = num2;
				((DataGridView)DGV_DETL).Rows[num6].Cells[13].Value = num4;
				((DataGridView)DGV_DETL).Rows[num6].Cells[14].Value = num3;
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
		}
	}

	private void DGV_Lot_FILL()
	{
		//IL_0388: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Expected O, but got Unknown
		//IL_03c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d3: Expected O, but got Unknown
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_03f8: Expected O, but got Unknown
		//IL_040e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0413: Unknown result type (might be due to invalid IL or missing references)
		//IL_041d: Expected O, but got Unknown
		//IL_0e0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e17: Expected O, but got Unknown
		DGV_CLEAR();
		if (cboCity.SelectedIndex == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,LOT_NO) AS SrNo,A.*,B.IT_NAME,C.AC_SHORT FROM (LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.IT_SIGN = '+' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  AND A.LOT_NO IN(Select A.LOT_NO FROM LOT_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'"), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.LOT_NO HAVING SUM(CASE WHEN A.IT_SIGN = '+' THEN A.IT_NWT ELSE - A.IT_NWT END) > 0 ) "));
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.KR_CODE = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.LOT_NO = '" + ((TextEdit)tSearch).Text + "'";
			}
			DC_Main.RsQry += " ORDER BY A.VCH_DATE,LOT_NO";
		}
		else
		{
			DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,LOT_NO) AS SrNo,A.*,B.IT_NAME,C.AC_SHORT FROM (LOT_DETL AS A LEFT JOIN ITEM_MAST AS B ON A.CO_CODE = B.CO_CODE AND A.IT_CODE = B.IT_CODE)LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.IT_SIGN = '+' AND A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' ";
			if (Operators.CompareString(cboArea.Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.KR_CODE = '" + cboArea.Text + "'";
			}
			if (Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0)
			{
				DC_Main.RsQry = DC_Main.RsQry + " AND A.LOT_NO = '" + ((TextEdit)tSearch).Text + "'";
			}
			DC_Main.RsQry += "ORDER BY A.VCH_DATE,LOT_NO";
		}
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsAcSum);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnCount = 18;
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(40.0 * ColCon);
			((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_AC).Columns[1].Width = (int)Math.Round(75.0 * ColCon);
			((DataGridView)DGV_AC).Columns[1].DataPropertyName = "LOT_NO";
			((DataGridView)DGV_AC).Columns[1].HeaderText = "LotNo";
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_AC).Columns[2].DataPropertyName = "VCH_DATE";
			((DataGridView)DGV_AC).Columns[2].HeaderText = "LDate";
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_AC).Columns[3].DataPropertyName = "EMP_CODE";
			((DataGridView)DGV_AC).Columns[3].HeaderText = "Emp";
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_SHORT";
			((DataGridView)DGV_AC).Columns[4].HeaderText = "KrCod";
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(150.0 * ColCon);
			((DataGridView)DGV_AC).Columns[5].DataPropertyName = "IT_NAME";
			((DataGridView)DGV_AC).Columns[5].HeaderText = "ItCode";
			((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_AC).Columns[6].DataPropertyName = "IT_PCS";
			((DataGridView)DGV_AC).Columns[6].HeaderText = "LPcs";
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[7].DataPropertyName = "IT_GWT";
			((DataGridView)DGV_AC).Columns[7].HeaderText = "LGwt";
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[8].DataPropertyName = "IT_NWT";
			((DataGridView)DGV_AC).Columns[8].HeaderText = "LNwt";
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_AC).Columns[9].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[9].HeaderText = "TPcs";
			((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[10].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[10].HeaderText = "TGwt";
			((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[11].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[11].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[11].HeaderText = "TNwt";
			((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[12].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_AC).Columns[12].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[12].HeaderText = "DiffWt";
			((DataGridView)DGV_AC).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[13].Width = (int)Math.Round(55.0 * ColCon);
			((DataGridView)DGV_AC).Columns[13].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[13].HeaderText = "DPcs";
			((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[13].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[14].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[14].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[14].HeaderText = "DGwt";
			((DataGridView)DGV_AC).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[15].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_AC).Columns[15].DataPropertyName = "";
			((DataGridView)DGV_AC).Columns[15].HeaderText = "DNwt";
			((DataGridView)DGV_AC).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_AC).Columns[16].Visible = false;
			((DataGridView)DGV_AC).Columns[16].DataPropertyName = "AC_CODE";
			((DataGridView)DGV_AC).Columns[16].HeaderText = "AcCode";
			((DataGridView)DGV_AC).Columns[17].Visible = false;
			((DataGridView)DGV_AC).Columns[17].DataPropertyName = "IT_CODE";
			((DataGridView)DGV_AC).Columns[17].HeaderText = "ItCode";
			((DataGridView)DGV_AC).DataSource = dataView;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
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
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select A.LOT_NO,A.IT_CODE,  SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_PCS ELSE 0 END) As AdjPcs,SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_GWT ELSE 0 END) As AdjGwt,SUM(CASE WHEN A.IT_SIGN = '-' THEN A.IT_NWT ELSE 0 END) As AdjNwt   FROM LOT_DETL AS A  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND A.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" AND A.VCH_DATE >= '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' AND A.VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' GROUP BY A.LOT_NO,A.IT_CODE "));
			DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DataView dataView2 = new DataView(DC_Main.Tbl);
			int num10 = ((DataGridView)DGV_AC).Rows.Count - 1;
			for (int i = 0; i <= num10; i++)
			{
				dataView2.RowFilter = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)"LOT_NO = '", ((DataGridView)DGV_AC).Rows[i].Cells[1].Value), (object)"' "));
				if (dataView2.Count > 0)
				{
					((DataGridView)DGV_AC).Rows[i].Cells[9].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["AdjPcs"])), "0");
					((DataGridView)DGV_AC).Rows[i].Cells[10].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["AdjGwt"])), "0.000");
					((DataGridView)DGV_AC).Rows[i].Cells[11].Value = Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(dataView2[0]["AdjNwt"])), "0.000");
					((DataGridView)DGV_AC).Rows[i].Cells[13].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(dataView2[0]["AdjPcs"], (object)""));
					((DataGridView)DGV_AC).Rows[i].Cells[14].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(dataView2[0]["AdjGwt"], (object)""));
					((DataGridView)DGV_AC).Rows[i].Cells[15].Value = Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)"")) - Conversion.Val(Operators.ConcatenateObject(dataView2[0]["AdjNwt"], (object)""));
					num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[9].Value, (object)""));
					num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[10].Value, (object)""));
					num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[11].Value, (object)""));
					num7 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[13].Value, (object)""));
					num8 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[14].Value, (object)""));
					num9 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[15].Value, (object)""));
				}
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)""));
				}
			}
			int num11 = ((DataGridView)DGV_AC).Rows.Count - 1;
			((DataGridView)DGV_AC).Rows[num11].Cells[1].Value = "Total :";
			((DataGridView)DGV_AC).Rows[num11].Cells[6].Value = num;
			((DataGridView)DGV_AC).Rows[num11].Cells[7].Value = num2;
			((DataGridView)DGV_AC).Rows[num11].Cells[8].Value = num3;
			((DataGridView)DGV_AC).Rows[num11].Cells[9].Value = num4;
			((DataGridView)DGV_AC).Rows[num11].Cells[10].Value = num5;
			((DataGridView)DGV_AC).Rows[num11].Cells[11].Value = num6;
			((DataGridView)DGV_AC).Rows[num11].Cells[13].Value = num7;
			((DataGridView)DGV_AC).Rows[num11].Cells[14].Value = num8;
			((DataGridView)DGV_AC).Rows[num11].Cells[15].Value = num9;
		}
	}

	private void DGV_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlAcSumm).Visible = false;
		DgvAcEnter = true;
		int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			BtnExit.Text = "&Back";
			Label2.Text = "Lot No";
			tAcCode.Text = Conversions.ToString(((DataGridView)DGV_AC)[1, index].Value);
			((Control)tAcName).Visible = false;
			DGV_DETL_LOT_FILL();
			return;
		}
		tAcCode.Text = Conversions.ToString(((DataGridView)DGV_AC)[1, index].Value);
		tAcName.Text = Conversions.ToString(((DataGridView)DGV_AC)[2, index].Value);
		lblMobile.Text = Conversions.ToString(((DataGridView)DGV_AC)[3, index].Value);
		BtnExit.Text = "&Back";
		if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
		{
			DGV_DETL_POINT_FILL();
		}
		else
		{
			DGV_DETL_FILL();
		}
	}

	private void PointSumm()
	{
		DgvAcEnter = false;
		DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY B.CARD_NO,B.MEMB_NAME) AS SrNo,A.MEMB_CODE,B.MEMB_NAME,B.MOBILE_NO,B.CARD_NO,C.AC_ADD1,C.AC_CITY,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.TOT_POINT ELSE 0 END) as TotPoint,SUM(CASE WHEN A.ITM_SIGN = '-' THEN A.TOT_POINT ELSE 0 END) as AdjPoint,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.TOT_POINT ELSE - A.TOT_POINT END) as BalPoint,Null AS DEL_DATE  FROM (POINT_DATA AS A INNER JOIN POINT_MEMB AS B ON A.CO_CODE = B.CO_CODE AND A.POINT_CODE = B.POINT_CODE And A.MEMB_CODE = B.MEMB_CODE )LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.MEMB_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.POINT_CODE = '01' and VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  GROUP BY A.MEMB_CODE,B.MEMB_NAME,B.MOBILE_NO,B.CARD_NO,C.AC_ADD1,C.AC_CITY ORDER BY B.CARD_NO,B.MEMB_NAME ";
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_POINT_FILL();
	}

	private void DGV_POINT_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_05c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsAcSum);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnCount = 11;
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_AC).Columns[1].Visible = false;
			((DataGridView)DGV_AC).Columns[1].DataPropertyName = "MEMB_CODE";
			((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_AC).Columns[2].DataPropertyName = "MEMB_NAME";
			((DataGridView)DGV_AC).Columns[2].HeaderText = "Memb Name";
			((DataGridView)DGV_AC).Columns[8].Visible = false;
			((DataGridView)DGV_AC).Columns[8].DataPropertyName = "AC_ADD1";
			((DataGridView)DGV_AC).Columns[8].HeaderText = "Address1";
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
			((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
			((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_CITY";
			((DataGridView)DGV_AC).Columns[4].HeaderText = "City";
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[5].DataPropertyName = "TotPoint";
			((DataGridView)DGV_AC).Columns[5].HeaderText = "TotPoint";
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[6].DataPropertyName = "AdjPoint";
			((DataGridView)DGV_AC).Columns[6].HeaderText = "AdjPoint";
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[7].DataPropertyName = "BalPoint";
			((DataGridView)DGV_AC).Columns[7].HeaderText = "BalPoint";
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N0";
			((DataGridView)DGV_AC).Columns[9].Visible = false;
			((DataGridView)DGV_AC).Columns[9].DataPropertyName = "AC_CITY";
			((DataGridView)DGV_AC).Columns[9].HeaderText = "LastDate";
			((DataGridView)DGV_AC).Columns[10].Visible = false;
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV_AC).DataSource = dataView;
			if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = ((DataGridView)DGV_AC).Rows.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
				}
			}
			int num5 = ((DataGridView)DGV_AC).Rows.Count - 1;
			((DataGridView)DGV_AC).Rows[num5].Cells[1].Value = "Total :";
			((DataGridView)DGV_AC).Rows[num5].Cells[5].Value = num;
			((DataGridView)DGV_AC).Rows[num5].Cells[6].Value = num2;
			((DataGridView)DGV_AC).Rows[num5].Cells[7].Value = num3;
		}
	}

	private void RP_ORDER_Load(object sender, EventArgs e)
	{
		//IL_0189: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected O, but got Unknown
		//IL_0ff5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffc: Expected O, but got Unknown
		//IL_106c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1071: Unknown result type (might be due to invalid IL or missing references)
		//IL_107b: Expected O, but got Unknown
		//IL_112b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1130: Unknown result type (might be due to invalid IL or missing references)
		//IL_1136: Expected O, but got Unknown
		//IL_11be: Unknown result type (might be due to invalid IL or missing references)
		//IL_11c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_11cd: Expected O, but got Unknown
		//IL_123f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1244: Unknown result type (might be due to invalid IL or missing references)
		//IL_124a: Expected O, but got Unknown
		//IL_12fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1301: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Expected O, but got Unknown
		//IL_132a: Unknown result type (might be due to invalid IL or missing references)
		//IL_132f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1339: Expected O, but got Unknown
		//IL_1358: Unknown result type (might be due to invalid IL or missing references)
		//IL_135d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1367: Expected O, but got Unknown
		//IL_13e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f8: Expected O, but got Unknown
		//IL_1417: Unknown result type (might be due to invalid IL or missing references)
		//IL_141c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1426: Expected O, but got Unknown
		//IL_1445: Unknown result type (might be due to invalid IL or missing references)
		//IL_144a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1454: Expected O, but got Unknown
		//IL_14d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_14db: Unknown result type (might be due to invalid IL or missing references)
		//IL_14e5: Expected O, but got Unknown
		//IL_1504: Unknown result type (might be due to invalid IL or missing references)
		//IL_1509: Unknown result type (might be due to invalid IL or missing references)
		//IL_1513: Expected O, but got Unknown
		//IL_1532: Unknown result type (might be due to invalid IL or missing references)
		//IL_1537: Unknown result type (might be due to invalid IL or missing references)
		//IL_1541: Expected O, but got Unknown
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
			foreach (object control3 in ((Control)PnlAcSumm).Controls)
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
			foreach (object control4 in ((Control)Panel1).Controls)
			{
				object objectValue3 = RuntimeHelpers.GetObjectValue(control4);
				object obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Width", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Width", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Height", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Height", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Left", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Left", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num))) }, (string[])null, (Type[])null);
				obj = objectValue3;
				NewLateBinding.LateSet(obj, (Type)null, "Top", new object[1] { Operators.AddObject(NewLateBinding.LateGet(obj, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)Conversions.ToInteger(Operators.MultiplyObject(NewLateBinding.LateGet(objectValue3, (Type)null, "Top", new object[0], (string[])null, (Type[])null, (bool[])null), (object)num2))) }, (string[])null, (Type[])null);
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
				CheckBox obj6 = chkZero;
				object? obj7 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj6).BackColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				CheckBox obj8 = chkZero;
				object? obj9 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj8).ForeColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				CheckBox obj10 = chkOpBal;
				object? obj11 = colorConverter.ConvertFromString("MistyRose");
				((ButtonBase)obj10).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				CheckBox obj12 = chkOpBal;
				object? obj13 = colorConverter.ConvertFromString("64, 0, 64");
				((Control)obj12).ForeColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				FlowLayoutPanel pnlBotam = PnlBotam;
				object? obj14 = colorConverter.ConvertFromString("MistyRose");
				((Control)pnlBotam).BackColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL = DGV_DEL;
				object? obj15 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DEL).BackgroundColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj16 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj16 != null) ? ((Color)obj16) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC = DGV_AC;
				object? obj17 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj17 != null) ? ((Color)obj17) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj18 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj18 != null) ? ((Color)obj18) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL = DGV_DETL;
				object? obj19 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj19 != null) ? ((Color)obj19) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj20 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				ComboBox obj21 = cboCity;
				object? obj22 = colorConverter.ConvertFromString("243, 240, 239");
				obj21.BackColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				ComboBox obj23 = cboArea;
				object? obj24 = colorConverter.ConvertFromString("243, 240, 239");
				obj23.BackColor = ((obj24 != null) ? ((Color)obj24) : default(Color));
				((Control)lblAdd1).ForeColor = Color.Black;
				((Control)lblMobile).ForeColor = Color.Black;
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj25 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj25 != null) ? ((Color)obj25) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((ButtonBase)chkZero).BackColor = Color.LightSlateGray;
				((Control)chkZero).ForeColor = Color.White;
				((ButtonBase)chkOpBal).BackColor = Color.LightSlateGray;
				((Control)chkOpBal).ForeColor = Color.White;
				((ButtonBase)chkOpBal).BackColor = Color.LightSlateGray;
				((Control)PnlBotam).BackColor = Color.LightSlateGray;
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL2 = DGV_DEL;
				object? obj26 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_DEL2).BackgroundColor = ((obj26 != null) ? ((Color)obj26) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj27 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj27 != null) ? ((Color)obj27) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC2 = DGV_AC;
				object? obj28 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj28 != null) ? ((Color)obj28) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj29 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj29 != null) ? ((Color)obj29) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj30 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj30 != null) ? ((Color)obj30) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj31 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj31 != null) ? ((Color)obj31) : default(Color));
				ComboBox obj32 = cboCity;
				object? obj33 = colorConverter.ConvertFromString("233, 235, 240");
				obj32.BackColor = ((obj33 != null) ? ((Color)obj33) : default(Color));
				ComboBox obj34 = cboArea;
				object? obj35 = colorConverter.ConvertFromString("233, 235, 240");
				obj34.BackColor = ((obj35 != null) ? ((Color)obj35) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 4)
			{
				object? obj36 = colorConverter.ConvertFromString("205, 220, 220");
				((Form)this).BackColor = ((obj36 != null) ? ((Color)obj36) : default(Color));
				((Control)lblBook).BackColor = Color.Cornsilk;
				Label obj37 = lblBook;
				object? obj38 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj37).ForeColor = ((obj38 != null) ? ((Color)obj38) : default(Color));
				((ButtonBase)chkZero).BackColor = Color.Cornsilk;
				CheckBox obj39 = chkZero;
				object? obj40 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj39).ForeColor = ((obj40 != null) ? ((Color)obj40) : default(Color));
				((ButtonBase)chkOpBal).BackColor = Color.Cornsilk;
				CheckBox obj41 = chkOpBal;
				object? obj42 = colorConverter.ConvertFromString("0, 0, 192");
				((Control)obj41).ForeColor = ((obj42 != null) ? ((Color)obj42) : default(Color));
				FlowLayoutPanel pnlBotam2 = PnlBotam;
				object? obj43 = colorConverter.ConvertFromString("CadetBlue");
				((Control)pnlBotam2).BackColor = ((obj43 != null) ? ((Color)obj43) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DEL3 = DGV_DEL;
				object? obj44 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DEL3).BackgroundColor = ((obj44 != null) ? ((Color)obj44) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle7 = ((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle;
				object? obj45 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle7.BackColor = ((obj45 != null) ? ((Color)obj45) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_AC3 = DGV_AC;
				object? obj46 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj46 != null) ? ((Color)obj46) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle8 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj47 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle8.BackColor = ((obj47 != null) ? ((Color)obj47) : default(Color));
				DevComponents.DotNetBar.Controls.DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj48 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj48 != null) ? ((Color)obj48) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle9 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj49 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle9.BackColor = ((obj49 != null) ? ((Color)obj49) : default(Color));
				cboCity.BackColor = Color.Cornsilk;
				cboArea.BackColor = Color.Cornsilk;
			}
			if ((Operators.CompareString(DC_Main.MsMainFontChange, "Y", false) == 0) & (DC_Main.ScreenHight > 1.0))
			{
				int num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font = ((Control)mFromDt).Font;
				try
				{
					foreach (Control control5 in ((Control)this).Controls)
					{
						Control val3 = control5;
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
				num3 = (int)Math.Ceiling((double)((Control)mFromDt).Font.Size * (1.0 + num2));
				Font font2 = ((Control)mFromDt).Font;
				try
				{
					foreach (object control6 in ((Control)PnlAcSumm).Controls)
					{
						object objectValue4 = RuntimeHelpers.GetObjectValue(control6);
						NewLateBinding.LateSet(objectValue4, (Type)null, "Font", new object[1] { (object)new Font(font2.FontFamily, (float)num3, font2.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font2)?.Dispose();
				}
				num3 = (int)Math.Ceiling((double)((Control)lblBook).Font.Size * (1.0 + num2));
				((Control)lblBook).Font = new Font(((Control)lblBook).Font.FontFamily, (float)num3, ((Control)lblBook).Font.Style);
				num3 = (int)Math.Ceiling((double)((BaseStyleControl)BtnSave).Font.Size * (1.0 + num2));
				Font font3 = ((BaseStyleControl)BtnSave).Font;
				try
				{
					foreach (object control7 in ((Control)PnlBotam).Controls)
					{
						object objectValue5 = RuntimeHelpers.GetObjectValue(control7);
						NewLateBinding.LateSet(objectValue5, (Type)null, "Font", new object[1] { (object)new Font(font3.FontFamily, (float)num3, font3.Style) }, (string[])null, (Type[])null);
					}
				}
				finally
				{
					((IDisposable)font3)?.Dispose();
				}
				if (unchecked(Operators.CompareString(DC_Main.MsFontChange, "N", false) == 0 && 1.0 + num2 > 1.0))
				{
					num3 = (int)Math.Ceiling(9.0 * (1.0 + num2));
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DETL).Font.Style);
					((DataGridView)DGV_DETL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DETL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DETL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DETL).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_AC).Font.Style);
					((DataGridView)DGV_AC).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_AC).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_AC).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_AC).RowTemplate.Height * (1.0 + num2));
					((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle.Font.Style);
					((DataGridView)DGV_DEL).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DEL).Font.Style);
					((DataGridView)DGV_DEL).AlternatingRowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", (float)num3, ((DataGridView)DGV_DEL).Font.Style);
					((DataGridView)DGV_DEL).ColumnHeadersHeight = (int)Math.Round((double)((DataGridView)DGV_DEL).ColumnHeadersHeight * (1.0 + num2));
					((DataGridView)DGV_DEL).RowTemplate.Height = (int)Math.Round((double)((DataGridView)DGV_DEL).RowTemplate.Height * (1.0 + num2));
				}
			}
			if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
			{
				((Control)chkZero).Visible = false;
				((Control)chkOpBal).Visible = false;
				((Control)lblCity).Visible = false;
				((Control)cboCity).Visible = false;
				((Control)Label17).Visible = false;
				((Control)cboArea).Visible = false;
				((Control)DGV_DEL).Visible = true;
				((Control)tSearch).Visible = false;
				((Control)tSerchAll).Visible = false;
				((Control)DGV_AC).Visible = false;
				lblBook.Text = "Delete Record Report";
				mFromDt.Text = "01/" + Strings.Format((object)DC_Main.MsSysDate, "MM") + "/" + Strings.Format((object)DC_Main.MsSysDate, "yyyy");
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			else if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
			{
				((Control)chkZero).Visible = false;
				((Control)chkOpBal).Visible = false;
				((Control)lblCity).Visible = false;
				((Control)cboCity).Visible = false;
				((Control)Label17).Visible = false;
				((Control)cboArea).Visible = false;
				((Control)tSerchAll).Visible = false;
				mFromDt.Text = "01/01/2020";
				lblBook.Text = "Member Point Report";
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				((Control)chkZero).Visible = false;
				((Control)chkOpBal).Visible = false;
				((Control)tSerchAll).Visible = false;
				mFromDt.Text = "01/01/2020";
				lblBook.Text = "Lot Wise Report";
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			else
			{
				mFromDt.Text = "01/01/2010";
				mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
			}
			if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				lblCity.Text = "Lot Type";
				cboCity.Items.Add((object)"Panding");
				cboCity.Items.Add((object)"All");
				cboCity.SelectedIndex = 0;
				Label17.Text = "KrCode";
				DC_Main.RsQry = "SELECT KR_CODE FROM LOT_DETL WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND KR_CODE <> '' GROUP BY KR_CODE ORDER BY KR_CODE ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboArea.Items.Clear();
					cboArea.Items.Add((object)"");
					int num4 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 1;
					while (DC_Main.X <= num4)
					{
						cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["KR_CODE"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboArea.Items.Add((object)"");
				}
			}
			else
			{
				DC_Main.RsQry = "SELECT AC_CITY FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_CITY ORDER BY AC_CITY ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboCity.Items.Clear();
					int num5 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 1;
					while (DC_Main.X <= num5)
					{
						cboCity.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_CITY"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboCity.Items.Add((object)"");
				}
			}
			if (Operators.CompareString(CurRpt, "Lot Report", false) != 0)
			{
				DC_Main.RsQry = "SELECT AC_AREA FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' GROUP BY AC_AREA ORDER BY AC_AREA ";
				DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
				if (DC_Main.Rshlp.Rows.Count > 0)
				{
					cboArea.Items.Clear();
					int num6 = DC_Main.Rshlp.Rows.Count - 1;
					DC_Main.X = 1;
					while (DC_Main.X <= num6)
					{
						cboArea.Items.Add(Operators.ConcatenateObject(DC_Main.Rshlp.Rows[DC_Main.X]["AC_AREA"], (object)""));
						DC_Main.X++;
					}
				}
				else
				{
					cboArea.Items.Add((object)"");
				}
			}
			CurActCtrl = (Control)(object)mFromDt;
		}
	}

	private void AcSumm()
	{
		DgvAcEnter = false;
		if (chkOpBal.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY C.AC_NAME,A.DEL_DATE) AS SrNo,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.DEL_DATE,D.DATA_TYPE,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE 0 END) as OrderAmt,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmt,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE -B.ORD_AMT END) as BalAmt,A.TOT_AMT As OrdItmTotal  FROM ((SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE < '" + Strings.Format((object)DC_Main.MOp_dt, "MM/dd/yyyy") + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.DEL_DATE,D.DATA_TYPE,A.TOT_AMT ORDER BY C.AC_NAME,A.DEL_DATE "));
		}
		else if (chkZero.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY C.AC_NAME,A.DEL_DATE) AS SrNo,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.DEL_DATE,D.DATA_TYPE,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE 0 END) as OrderAmt,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmt,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE -B.ORD_AMT END) as BalAmt,A.TOT_AMT As OrdItmTotal  FROM ((SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,D.DATA_TYPE,A.DEL_DATE,A.TOT_AMT ORDER BY C.AC_NAME "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY C.AC_NAME,A.DEL_DATE) AS SrNo,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.DEL_DATE,D.DATA_TYPE,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE 0 END) as OrderAmt,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmt,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE -B.ORD_AMT END) as BalAmt,A.TOT_AMT As OrdItmTotal  FROM ((SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE AND A.AC_CODE = C.AC_CODE)LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), (object)" "), (object)" GROUP BY A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,A.DEL_DATE,D.DATA_TYPE,A.TOT_AMT HAVING SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE - B.ORD_AMT END)  > 0  ORDER BY C.AC_NAME "));
		}
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV_AC).DataSource = null;
		((DataGridView)DGV_AC).Columns.Clear();
		((DataGridView)DGV_AC).Rows.Clear();
	}

	private void DGV_FILL()
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0659: Unknown result type (might be due to invalid IL or missing references)
		//IL_0663: Expected O, but got Unknown
		DGV_CLEAR();
		DataView dataView = new DataView(RsAcSum);
		if (dataView.Count <= 0)
		{
			return;
		}
		((DataGridView)DGV_AC).MultiSelect = false;
		((DataGridView)DGV_AC).AutoGenerateColumns = false;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_AC).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_AC).ColumnCount = 11;
		checked
		{
			((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
			((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
			((DataGridView)DGV_AC).Columns[1].Visible = false;
			((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
			((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
			((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
			((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
			((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
			((DataGridView)DGV_AC).Columns[8].Visible = false;
			((DataGridView)DGV_AC).Columns[8].DataPropertyName = "AC_ADD1";
			((DataGridView)DGV_AC).Columns[8].HeaderText = "Address1";
			((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
			((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
			((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(125.0 * ColCon);
			((DataGridView)DGV_AC).Columns[4].DataPropertyName = "DEL_DATE";
			((DataGridView)DGV_AC).Columns[4].HeaderText = "DelDate";
			((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[5].DataPropertyName = "OrderAmt";
			((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdAdvance";
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[6].DataPropertyName = "AdjAmt";
			((DataGridView)DGV_AC).Columns[6].HeaderText = "AdjAmt";
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[7].DataPropertyName = "BalAmt";
			((DataGridView)DGV_AC).Columns[7].HeaderText = "BalAmt";
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_AC).Columns[9].Visible = false;
			((DataGridView)DGV_AC).Columns[9].DataPropertyName = "AC_CITY";
			((DataGridView)DGV_AC).Columns[9].HeaderText = "City";
			((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_AC).Columns[10].DataPropertyName = "OrdItmTotal";
			((DataGridView)DGV_AC).Columns[10].HeaderText = "OrdValue";
			((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
			if (DC_Main.ScreenHight > 1.0)
			{
				((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
			}
			((DataGridView)DGV_AC).DataSource = dataView;
			if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
			{
				dataView.AddNew();
				dataView.AddNew();
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			int num4 = ((DataGridView)DGV_AC).Rows.Count - 1;
			for (int i = 0; i <= num4; i++)
			{
				if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
				{
					num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""));
					num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
					num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
				}
			}
			int num5 = ((DataGridView)DGV_AC).Rows.Count - 1;
			((DataGridView)DGV_AC).Rows[num5].Cells[1].Value = "Total :";
			((DataGridView)DGV_AC).Rows[num5].Cells[5].Value = num;
			((DataGridView)DGV_AC).Rows[num5].Cells[6].Value = num2;
			((DataGridView)DGV_AC).Rows[num5].Cells[7].Value = num3;
		}
	}

	private void DGV_RowEnter(object sender, DataGridViewCellEventArgs e)
	{
		int try0001_dispatch = -1;
		int num2 = default(int);
		int num = default(int);
		int num3 = default(int);
		DataGridViewRow val = default(DataGridViewRow);
		while (true)
		{
			try
			{
				/*Note: ILSpy has introduced the following switch to emulate a goto from catch-block to try-block*/;
				switch (try0001_dispatch)
				{
				default:
					num2 = 1;
					if (DgvAcEnter)
					{
						goto end_IL_0001;
					}
					goto IL_0014;
				case 254:
					{
						num = num2;
						switch ((num3 <= -2) ? 1 : num3)
						{
						case 1:
							break;
						default:
							goto end_IL_0001_2;
						}
						int num4 = num + 1;
						num = 0;
						switch (num4)
						{
						case 1:
							break;
						case 2:
							goto IL_0014;
						case 3:
							goto IL_0027;
						case 4:
							goto IL_003a;
						case 5:
							goto IL_004e;
						case 6:
							goto IL_0057;
						case 7:
							goto IL_0071;
						case 8:
							goto end_IL_0001_3;
						default:
							goto end_IL_0001_2;
						case 9:
						case 10:
						case 11:
						case 12:
							goto end_IL_0001;
						}
						goto default;
					}
					IL_004e:
					ProjectData.ClearProjectError();
					num3 = -2;
					goto IL_0057;
					IL_0057:
					num2 = 6;
					val = ((DataGridView)DGV_AC).Rows[e.RowIndex];
					goto IL_0071;
					IL_003a:
					num2 = 4;
					if (e.RowIndex < 0)
					{
						goto end_IL_0001;
					}
					goto IL_004e;
					IL_0071:
					num2 = 7;
					if (val.Cells[3].Value == null)
					{
						goto end_IL_0001;
					}
					break;
					IL_0014:
					num2 = 2;
					lblAdd1.Text = "";
					goto IL_0027;
					IL_0027:
					num2 = 3;
					lblMobile.Text = "";
					goto IL_003a;
					end_IL_0001_3:
					break;
				}
				num2 = 8;
				lblMobile.Text = val.Cells[3].Value.ToString();
				break;
				end_IL_0001_2:;
			}
			catch (object obj) when (obj is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 254;
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
					ProjectData.ClearProjectError();
					num2 = 2;
					if (Operators.CompareString(CurRpt, "Delete Data", false) != 0)
					{
						int columnIndex = e.ColumnIndex;
						if (((uint)(columnIndex - 4) <= 2u || columnIndex == 10) && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 140:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00c2;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 140;
				continue;
			}
			break;
			IL_00c2:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void tSearch_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
			{
				if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) == 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
				{
					DGV_POINT_FILL();
				}
				else if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
				{
					DataView dataView = new DataView(RsAcSum);
					dataView.RowFilter = "MEMB_NAME Like  '" + ((TextEdit)tSearch).Text + "%' ";
					if (dataView.Count > 0)
					{
						((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
						((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
						((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
						((DataGridView)DGV_AC).Columns[1].Visible = false;
						((DataGridView)DGV_AC).Columns[1].DataPropertyName = "MEMB_CODE";
						((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
						((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
						((DataGridView)DGV_AC).Columns[2].DataPropertyName = "MEMB_NAME";
						((DataGridView)DGV_AC).Columns[2].HeaderText = "Memb Name";
						((DataGridView)DGV_AC).Columns[8].Visible = false;
						((DataGridView)DGV_AC).Columns[8].DataPropertyName = "AC_ADD1";
						((DataGridView)DGV_AC).Columns[8].HeaderText = "Address1";
						((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
						((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
						((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
						((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(200.0 * ColCon);
						((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_CITY";
						((DataGridView)DGV_AC).Columns[4].HeaderText = "City";
						((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(120.0 * ColCon);
						((DataGridView)DGV_AC).Columns[5].DataPropertyName = "TotPoint";
						((DataGridView)DGV_AC).Columns[5].HeaderText = "TotPoint";
						((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N0";
						((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(120.0 * ColCon);
						((DataGridView)DGV_AC).Columns[6].DataPropertyName = "AdjPoint";
						((DataGridView)DGV_AC).Columns[6].HeaderText = "AdjPoint";
						((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N0";
						((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(120.0 * ColCon);
						((DataGridView)DGV_AC).Columns[7].DataPropertyName = "BalPoint";
						((DataGridView)DGV_AC).Columns[7].HeaderText = "BalPoint";
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
						((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N0";
						((DataGridView)DGV_AC).Columns[9].Visible = false;
						((DataGridView)DGV_AC).Columns[9].DataPropertyName = "AC_CITY";
						((DataGridView)DGV_AC).Columns[9].HeaderText = "LastDate";
						((DataGridView)DGV_AC).Columns[10].Visible = false;
						((DataGridView)DGV_AC).DataSource = dataView;
					}
				}
			}
			else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				if (!((Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0)))
				{
					return;
				}
				int num = ((DataGridView)DGV_AC).Rows.Count - 1;
				for (int i = 0; i <= num; i++)
				{
					if (((DataGridView)DGV_AC)[1, i].Value.ToString().ToLower().StartsWith(((TextEdit)tSearch).Text.ToLower()))
					{
						((DataGridView)DGV_AC).CurrentCell = ((DataGridView)DGV_AC).Rows[i].Cells[1];
						((DataGridView)DGV_AC).Rows[i].Selected = true;
						break;
					}
				}
			}
			else if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) == 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(((TextEdit)tSearch).Text, "", false) != 0) & (Operators.CompareString(((TextEdit)tSearch).Text, "SEARCH RECORD", false) != 0))
			{
				DataView dataView2 = new DataView(RsAcSum);
				dataView2.RowFilter = "AC_NAME Like  '" + ((TextEdit)tSearch).Text + "%' ";
				if (dataView2.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[8].Visible = false;
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "OrderAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdAdvance";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "AdjAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "AdjAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "BalAmt";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "BalAmt";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Visible = false;
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "OrdItmTotal";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "OrdValue";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).DataSource = dataView2;
				}
			}
		}
	}

	private void tSerchAll_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) == 0)
			{
				DGV_FILL();
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '%" + ((TextEdit)tSerchAll).Text + "%' OR AC_MOBILE Like '%" + ((TextEdit)tSerchAll).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AC_CODE";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(325.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[8].Visible = false;
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "OrderAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "OrdAdvance";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "AdjAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "AdjAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "BalAmt";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "BalAmt";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Visible = false;
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(140.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "OrdItmTotal";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "OrdValue";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void DGV_DETL_FILL()
	{
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Expected O, but got Unknown
		//IL_0144: Unknown result type (might be due to invalid IL or missing references)
		//IL_0149: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0178: Expected O, but got Unknown
		//IL_018e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019d: Expected O, but got Unknown
		//IL_06cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d6: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,A.VCH_NO) AS SrNo,D.BOOK_SNAME,A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.CO_BOOK,A.AC_CODE,D.MAIN_BOOK,  SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE 0 END) as OrderAmt,SUM(CASE WHEN B.ORD_SIGN = '-' THEN B.ORD_AMT ELSE 0 END) AS AdjAmt,SUM(CASE WHEN B.ORD_SIGN = '+' THEN B.ORD_AMT ELSE -B.ORD_AMT END) as BalAmt  FROM (SL_ORD_DATA AS A LEFT JOIN SL_ORD_ADJ AS B ON A.CO_CODE = B.CO_CODE And A.LC_CODE = B.ORD_LC And A.CO_YEAR = B.ORD_YRCD And A.CO_BOOK = B.ORD_DBCD And A.VCH_NO = B.ORD_NO) LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.AC_CODE = '" + tAcCode.Text + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  GROUP BY D.BOOK_SNAME,A.VCH_NO,A.VCH_DATE,A.AC_NAME,A.CO_BOOK,A.AC_CODE,D.MAIN_BOOK  ORDER BY A.VCH_DATE,A.VCH_NO ";
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_DETL).MultiSelect = false;
				((DataGridView)DGV_DETL).AutoGenerateColumns = false;
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV_DETL).ColumnCount = 11;
				((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "BOOK_SNAME";
				((DataGridView)DGV_DETL).Columns[1].HeaderText = "Book";
				((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_DETL).Columns[2].HeaderText = "VchNo";
				((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_DETL).Columns[3].HeaderText = "VchDate";
				((DataGridView)DGV_DETL).Columns[4].Width = (int)Math.Round(300.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[4].DataPropertyName = "AC_NAME";
				((DataGridView)DGV_DETL).Columns[4].HeaderText = "Party Name";
				((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[5].DataPropertyName = "OrderAmt";
				((DataGridView)DGV_DETL).Columns[5].HeaderText = "OrderAmt";
				((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "AdjAmt";
				((DataGridView)DGV_DETL).Columns[6].HeaderText = "AdjAmt";
				((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "BalAmt";
				((DataGridView)DGV_DETL).Columns[7].HeaderText = "BalAmt";
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
				((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "CO_BOOK";
				((DataGridView)DGV_DETL).Columns[8].HeaderText = "BookCode";
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
				((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "AC_CODE";
				((DataGridView)DGV_DETL).Columns[9].HeaderText = "AcCode";
				((DataGridView)DGV_DETL).Columns[10].Visible = false;
				((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "MAIN_BOOK";
				((DataGridView)DGV_DETL).Columns[10].HeaderText = "MainBook";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV_DETL).DataSource = dataView;
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					dataView.AddNew();
					dataView.AddNew();
				}
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				for (int i = 0; i <= num4; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[4].Value, (object)""), (object)"Total :", false))
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[4].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[5].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[6].Value, (object)""));
					}
				}
				int num5 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num5].Cells[1].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num5].Cells[4].Value = num;
				((DataGridView)DGV_DETL).Rows[num5].Cells[5].Value = num2;
				((DataGridView)DGV_DETL).Rows[num5].Cells[6].Value = num3;
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
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
		int num9 = default(int);
		int num10 = default(int);
		int num11 = default(int);
		int num12 = default(int);
		int num13 = default(int);
		int num14 = default(int);
		int num15 = default(int);
		int num16 = default(int);
		int num17 = default(int);
		int num18 = default(int);
		ColorConverter colorConverter = default(ColorConverter);
		int num19 = default(int);
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
					case 2802:
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
								goto IL_0129;
							case 13:
								goto IL_0140;
							case 14:
								goto IL_0188;
							case 15:
								goto IL_0197;
							case 16:
								goto IL_01b4;
							case 17:
								goto IL_01ce;
							case 18:
								goto IL_01f1;
							case 19:
							case 20:
								goto IL_0246;
							case 21:
								goto IL_0258;
							case 23:
								goto IL_027a;
							case 24:
								goto IL_029f;
							case 25:
								goto IL_02b6;
							case 26:
								goto IL_02fe;
							case 27:
								goto IL_030d;
							case 28:
								goto IL_032a;
							case 29:
								goto IL_0344;
							case 30:
								goto IL_0365;
							case 32:
								goto IL_0390;
							case 33:
								goto IL_03b3;
							case 36:
								goto IL_041f;
							case 39:
								goto IL_0478;
							case 41:
								goto IL_0488;
							case 42:
								goto IL_04ab;
							case 45:
								goto IL_0517;
							case 31:
							case 34:
							case 35:
							case 37:
							case 38:
							case 40:
							case 43:
							case 44:
							case 46:
							case 47:
							case 48:
								goto IL_056e;
							case 49:
								goto IL_0580;
							case 51:
								goto IL_05a2;
							case 52:
								goto IL_05b9;
							case 53:
								goto IL_0601;
							case 54:
								goto IL_0610;
							case 55:
								goto IL_062d;
							case 56:
								goto IL_0647;
							case 57:
								goto IL_066a;
							case 58:
							case 59:
								goto IL_06bf;
							case 60:
								goto IL_06d1;
							case 22:
							case 50:
							case 61:
							case 62:
							case 63:
								goto IL_06ee;
							case 64:
								goto IL_06f8;
							case 65:
								goto IL_074b;
							case 66:
								goto IL_07a0;
							case 67:
								goto IL_07f8;
							case 68:
								goto IL_0866;
							case 69:
								goto IL_08a9;
							case 70:
								goto IL_08d8;
							case 71:
								goto IL_091b;
							case 72:
								goto IL_095c;
							case 73:
								goto IL_097d;
							case 74:
								goto IL_098b;
							case 75:
								goto IL_0991;
							case 76:
								goto IL_0997;
							case 77:
								goto end_IL_0001_2;
							default:
								goto end_IL_0001;
							case 3:
							case 78:
								goto end_IL_0001_3;
							}
							goto default;
						}
						IL_06bf:
						num2 = 59;
						num5++;
						goto IL_06c8;
						IL_05b9:
						num2 = 52;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_AC).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0601;
						IL_066a:
						num2 = 57;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_06bf;
						IL_0601:
						num2 = 53;
						num6++;
						goto IL_060a;
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
						if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
						{
							goto IL_0129;
						}
						goto IL_027a;
						IL_0129:
						num2 = 12;
						num7 = ((DataGridView)DGV_DEL).ColumnCount - 1;
						num8 = 0;
						goto IL_0191;
						IL_0191:
						if (num8 <= num7)
						{
							goto IL_0140;
						}
						goto IL_0197;
						IL_0197:
						num2 = 15;
						num9 = ((DataGridView)DGV_DEL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_0267;
						IL_0267:
						if (DC_Main.i <= num9)
						{
							goto IL_01b4;
						}
						goto IL_06ee;
						IL_01b4:
						num2 = 16;
						num10 = ((DataGridView)DGV_DEL).ColumnCount - 1;
						num11 = 0;
						goto IL_024f;
						IL_024f:
						if (num11 <= num10)
						{
							goto IL_01ce;
						}
						goto IL_0258;
						IL_0258:
						num2 = 21;
						DC_Main.i++;
						goto IL_0267;
						IL_01ce:
						num2 = 17;
						if (((DataGridView)DGV_DEL)[num11, DC_Main.i].Value != null)
						{
							goto IL_01f1;
						}
						goto IL_0246;
						IL_01f1:
						num2 = 18;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num11 + 1,
							((DataGridView)DGV_DEL)[num11, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_0246;
						IL_0246:
						num2 = 20;
						num11++;
						goto IL_024f;
						IL_0140:
						num2 = 13;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num8 + 1,
							((DataGridView)DGV_AC).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_0188;
						IL_0188:
						num2 = 14;
						num8++;
						goto IL_0191;
						IL_027a:
						num2 = 23;
						if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
						{
							goto IL_029f;
						}
						goto IL_05a2;
						IL_029f:
						num2 = 24;
						num12 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num13 = 0;
						goto IL_0307;
						IL_0307:
						if (num13 <= num12)
						{
							goto IL_02b6;
						}
						goto IL_030d;
						IL_030d:
						num2 = 27;
						num14 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_058f;
						IL_058f:
						if (DC_Main.i <= num14)
						{
							goto IL_032a;
						}
						goto IL_06ee;
						IL_032a:
						num2 = 28;
						num15 = ((DataGridView)DGV_DETL).ColumnCount - 1;
						num16 = 0;
						goto IL_0577;
						IL_0577:
						if (num16 <= num15)
						{
							goto IL_0344;
						}
						goto IL_0580;
						IL_0580:
						num2 = 49;
						DC_Main.i++;
						goto IL_058f;
						IL_0344:
						num2 = 29;
						if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
						{
							goto IL_0365;
						}
						goto IL_0478;
						IL_0365:
						num2 = 30;
						switch (num16)
						{
						case 9:
						case 10:
						case 12:
						case 14:
							break;
						default:
							goto IL_041f;
						}
						goto IL_0390;
						IL_041f:
						num2 = 36;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							((DataGridView)DGV_DETL)[num16, DC_Main.i].Value
						}, (string[])null, (Type[])null);
						goto IL_056e;
						IL_0390:
						num2 = 32;
						if (((DataGridView)DGV_DEL)[num16, DC_Main.i].Value != null)
						{
							goto IL_03b3;
						}
						goto IL_056e;
						IL_03b3:
						num2 = 33;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num16, DC_Main.i].Value)), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_056e;
						IL_0478:
						num2 = 39;
						if (unchecked((uint)(num16 - 5)) <= 2u)
						{
							goto IL_0488;
						}
						goto IL_0517;
						IL_0517:
						num2 = 45;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							((DataGridView)DGV_DETL)[num16, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_056e;
						IL_0488:
						num2 = 41;
						if (((DataGridView)DGV_DEL)[num16, DC_Main.i].Value != null)
						{
							goto IL_04ab;
						}
						goto IL_056e;
						IL_04ab:
						num2 = 42;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num16 + 1,
							Strings.Format((object)Conversion.Val(RuntimeHelpers.GetObjectValue(((DataGridView)DGV_DETL)[num16, DC_Main.i].Value)), "0.000")
						}, (string[])null, (Type[])null);
						goto IL_056e;
						IL_056e:
						num2 = 48;
						num16++;
						goto IL_0577;
						IL_02b6:
						num2 = 25;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num13 + 1,
							((DataGridView)DGV_DETL).Columns[num13].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02fe;
						IL_02fe:
						num2 = 26;
						num13++;
						goto IL_0307;
						IL_05a2:
						num2 = 51;
						num17 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num6 = 0;
						goto IL_060a;
						IL_060a:
						if (num6 <= num17)
						{
							goto IL_05b9;
						}
						goto IL_0610;
						IL_0610:
						num2 = 54;
						num18 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_06e0;
						IL_06e0:
						if (DC_Main.i <= num18)
						{
							goto IL_062d;
						}
						goto IL_06ee;
						IL_06ee:
						num2 = 63;
						colorConverter = new ColorConverter();
						goto IL_06f8;
						IL_06f8:
						num2 = 64;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_074b;
						IL_074b:
						num2 = 65;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_07a0;
						IL_07a0:
						num2 = 66;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_07f8;
						IL_07f8:
						num2 = 67;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0866;
						IL_0866:
						num2 = 68;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_08a9;
						IL_08a9:
						num2 = 69;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_08d8;
						IL_08d8:
						num2 = 70;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_091b;
						IL_091b:
						num2 = 71;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_095c;
						IL_095c:
						num2 = 72;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_097d;
						IL_097d:
						num2 = 73;
						Cursor.Current = Cursors.Default;
						goto IL_098b;
						IL_098b:
						num2 = 74;
						obj = null;
						goto IL_0991;
						IL_0991:
						num2 = 75;
						obj3 = null;
						goto IL_0997;
						IL_0997:
						num2 = 76;
						obj2 = null;
						break;
						IL_062d:
						num2 = 55;
						num19 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_06c8;
						IL_06c8:
						if (num5 <= num19)
						{
							goto IL_0647;
						}
						goto IL_06d1;
						IL_06d1:
						num2 = 60;
						DC_Main.i++;
						goto IL_06e0;
						IL_0647:
						num2 = 56;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_066a;
						}
						goto IL_06bf;
						end_IL_0001_2:
						break;
					}
					num2 = 77;
					GC.Collect();
					break;
				}
				end_IL_0001:;
			}
			catch (object obj4) when (obj4 is Exception && num3 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj4);
				try0001_dispatch = 2802;
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
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
			return;
		}
		Cr[(short)0] = "";
		Cr[(short)1] = "";
		Cr[(short)2] = "";
		Cr[(short)3] = "";
		Cr[(short)4] = "";
		Cr[(short)5] = "";
		Cr[(short)6] = "";
		Cr[(short)7] = "";
		double num = 0.0;
		double num2 = 0.0;
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt FROM AC_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND CO_YEAR = '" + DC_Main.MCo_year + "'  AND AC_CODE = '" + tAcCode.Text + "' and VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING SUM(CR_AMT-DR_AMT) <> 0 "));
		DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Rshlp.Rows.Count > 0)
		{
			num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
		}
		Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\JmUdAmt.RPT";
		Cr.SelectionFormula = "{AC_DATA.CO_CODE} = '" + DC_Main.MCo_code + "' AND {AC_DATA.LC_CODE} = '" + DC_Main.MLc_code + "' AND {AC_DATA.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {AC_DATA.AC_CODE} = '" + tAcCode.Text + "' AND {AC_DATA.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {AC_DATA.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
		if (Operators.CompareString(DC_Main.MsDataType, "A", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		else if (Operators.CompareString(DC_Main.MsDataType, "B", false) == 0)
		{
			Cr.SelectionFormula = Cr.SelectionFormula + " and {AC_DATA.DATA_TYPE} = '" + DC_Main.MsDataType + "'";
		}
		Cr[(short)0] = "RptTitel = 'Jama Udhar Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
		Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
		Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
		Cr[(short)3] = ("OpBal = " + Strings.Format((object)num, "0.00")) ?? "";
		Cr[(short)4] = ("ClBal = " + Strings.Format((object)num2, "0.00")) ?? "";
		Cr.Destination = (DestinationConstants)0;
		Cr.WindowState = (WindowStateConstants)2;
		Cr.Action = -1;
		Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
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
		if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
		{
			mFromDt.Text = "01/" + Strings.Format((object)DC_Main.MsSysDate, "MM") + "/" + Strings.Format((object)DC_Main.MsSysDate, "yyyy");
		}
		else
		{
			mFromDt.Text = "01/01/2010";
		}
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		BtnExit.Text = "E&xit";
		((Control)PnlAcSumm).Visible = true;
		chkZero.Checked = false;
		((TextEdit)tSearch).Text = "";
		((TextEdit)tSerchAll).Text = "";
		cboArea.Text = "";
		DgvAcEnter = false;
		if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
		{
			DeleteData();
		}
		else if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
		{
			cboCity.Text = "";
			PointSumm();
		}
		else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			cboCity.SelectedIndex = 0;
			DGV_Lot_FILL();
		}
		else
		{
			cboCity.Text = "";
			AcSumm();
		}
		((Control)tSearch).Focus();
	}

	private void BtnExit_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			((DataGridView)DGV_DETL).DataSource = null;
			((DataGridView)DGV_DETL).ClearSelection();
			((DataGridView)DGV_DETL).Rows.Clear();
			((DataGridView)DGV_DETL).Columns.Clear();
			((Control)DGV_DETL).Refresh();
			if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
			{
				PointSumm();
			}
			else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				DGV_Lot_FILL();
			}
			else
			{
				AcSumm();
			}
			BtnExit.Text = "E&xit";
			((Control)PnlAcSumm).Visible = true;
			BtnPrint.Text = "&Print";
			lblAdd1.Text = "";
			lblMobile.Text = "";
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_ORDER_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_ORDER_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_ORDER_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Invalid comparison between Unknown and I4
		//IL_0130: Unknown result type (might be due to invalid IL or missing references)
		//IL_0137: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((DataGridView)DGV_DETL).Columns.Clear();
				((Control)DGV_DETL).Refresh();
				if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
				{
					PointSumm();
				}
				else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
				{
					DGV_Lot_FILL();
				}
				else
				{
					AcSumm();
				}
				BtnExit.Text = "E&xit";
				((Control)PnlAcSumm).Visible = true;
				BtnPrint.Text = "&Print";
				lblAdd1.Text = "";
				lblMobile.Text = "";
			}
			else
			{
				((Form)this).Close();
			}
		}
		if (((int)e.KeyCode == 38) | ((int)e.KeyCode == 40))
		{
			((Control)DGV_AC).Focus();
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

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_ORDER_Closed(object sender, EventArgs e)
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

	private void DGV_DETL_POINT_FILL()
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_0140: Expected O, but got Unknown
		//IL_0172: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0181: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cb: Expected O, but got Unknown
		//IL_08be: Unknown result type (might be due to invalid IL or missing references)
		//IL_08c8: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = "Select ROW_NUMBER() OVER (ORDER BY A.VCH_DATE,A.VCH_NO) AS SrNo,D.BOOK_SNAME,A.VCH_NO,A.VCH_DATE,B.MEMB_NAME,A.CO_BOOK,A.MEMB_CODE,D.MAIN_BOOK,A.POINT_TYPE," + Conversions.ToString(DC_Main.MsOnePointVal) + " As POINT_VAL,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.TOT_POINT  Else -A.TOT_POINT End * " + Conversions.ToString(DC_Main.MsOnePointVal) + " ) As PointVal,  SUM(Case When A.ITM_SIGN = '+' THEN A.TOT_POINT ELSE 0 END) as OrderAmt,SUM(CASE WHEN A.ITM_SIGN = '-' THEN A.TOT_POINT ELSE 0 END) AS AdjAmt,SUM(CASE WHEN A.ITM_SIGN = '+' THEN A.TOT_POINT ELSE -A.TOT_POINT END) as BalAmt  FROM (POINT_DATA AS A LEFT JOIN POINT_MEMB AS B ON A.CO_CODE = B.CO_CODE And A.MEMB_CODE = B.MEMB_CODE AND A.POINT_CODE = B.POINT_CODE) LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.MEMB_CODE = '" + tAcCode.Text + "' AND A.VCH_DATE <= '" + Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy") + "'  GROUP BY D.BOOK_SNAME,A.VCH_NO,A.VCH_DATE,B.MEMB_NAME,A.CO_BOOK,A.MEMB_CODE,D.MAIN_BOOK ,A.POINT_TYPE ORDER BY A.VCH_DATE,A.VCH_NO ";
		DataTable table = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(table);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_DETL).MultiSelect = false;
				((DataGridView)DGV_DETL).AutoGenerateColumns = false;
				((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV_DETL).ColumnCount = 14;
				((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(60.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_DETL).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[1].DataPropertyName = "BOOK_SNAME";
				((DataGridView)DGV_DETL).Columns[1].HeaderText = "Book";
				((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[2].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_DETL).Columns[2].HeaderText = "VchNo";
				((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[3].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_DETL).Columns[3].HeaderText = "VchDate";
				((DataGridView)DGV_DETL).Columns[4].Visible = false;
				((DataGridView)DGV_DETL).Columns[4].DataPropertyName = "AC_NAME";
				((DataGridView)DGV_DETL).Columns[4].HeaderText = "Party Name";
				((DataGridView)DGV_DETL).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[5].DataPropertyName = "OrderAmt";
				((DataGridView)DGV_DETL).Columns[5].HeaderText = "TotPoint";
				((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[5].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[6].DataPropertyName = "AdjAmt";
				((DataGridView)DGV_DETL).Columns[6].HeaderText = "AdjPoint";
				((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[7].DataPropertyName = "BalAmt";
				((DataGridView)DGV_DETL).Columns[7].HeaderText = "BalPoint";
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[8].Visible = false;
				((DataGridView)DGV_DETL).Columns[8].DataPropertyName = "CO_BOOK";
				((DataGridView)DGV_DETL).Columns[8].HeaderText = "BookCode";
				((DataGridView)DGV_DETL).Columns[9].Visible = false;
				((DataGridView)DGV_DETL).Columns[9].DataPropertyName = "AC_CODE";
				((DataGridView)DGV_DETL).Columns[9].HeaderText = "AcCode";
				((DataGridView)DGV_DETL).Columns[10].Visible = false;
				((DataGridView)DGV_DETL).Columns[10].DataPropertyName = "MAIN_BOOK";
				((DataGridView)DGV_DETL).Columns[10].HeaderText = "MainBook";
				((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(80.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[11].DataPropertyName = "POINT_TYPE";
				((DataGridView)DGV_DETL).Columns[11].HeaderText = "PType";
				((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[12].DataPropertyName = "POINT_VAL";
				((DataGridView)DGV_DETL).Columns[12].HeaderText = "1PointVal";
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_DETL).Columns[13].DataPropertyName = "PointVal";
				((DataGridView)DGV_DETL).Columns[13].HeaderText = "AmtTotal";
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Format = "N2";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV_DETL).DataSource = dataView;
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[1].Value, (object)""), (object)"", false))))
				{
					dataView.AddNew();
					dataView.AddNew();
				}
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				double num4 = 0.0;
				int num5 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				for (int i = 0; i <= num5; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[4].Value, (object)""), (object)"Total :", false))
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[5].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[6].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[7].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[i].Cells[13].Value, (object)""));
					}
				}
				int num6 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num6].Cells[1].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num6].Cells[5].Value = num;
				((DataGridView)DGV_DETL).Rows[num6].Cells[6].Value = num2;
				((DataGridView)DGV_DETL).Rows[num6].Cells[7].Value = num - num2;
				((DataGridView)DGV_DETL).Rows[num6].Cells[13].Value = num4;
			}
			((Control)tAcCode).Focus();
			((TextBoxBase)tAcCode).SelectAll();
		}
	}

	private void DGV_DETL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
					{
						int columnIndex = e.ColumnIndex;
						if ((uint)(columnIndex - 8) <= 6u && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					else
					{
						int columnIndex2 = e.ColumnIndex;
						if ((uint)(columnIndex2 - 5) <= 2u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 207:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_0105;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 207;
				continue;
			}
			break;
			IL_0105:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(CurRpt, "Lot Report", false) == 0 || (int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			DC_Main.RsQry = "SELECT AC_NAME As AcNameL,AC_CODE As AcCodeL, AC_GR AS GroupL,AC_ADD1 As AddressL,AC_PHONE As PhoneL,AC_MOBILE As MobileL FROM AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' ORDER BY AC_NAME";
			DC_Main.RsDg = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			DC_Main.ColWidth = new double[7];
			DC_Main.ColWidth[0] = 300.0;
			DC_Main.ColWidth[1] = 100.0;
			DC_Main.ColWidth[2] = 75.0;
			DC_Main.ColWidth[3] = 300.0;
			DC_Main.ColWidth[4] = 100.0;
			DC_Main.ColWidth[5] = 100.0;
			DC_Main.HelpSelect = 1;
			((Form)MyProject.Forms.MS_HELP).ShowDialog();
			if (!DC_Main.HelpClose)
			{
				if (Operators.CompareString(DC_Main.ColValue[0], "", false) != 0)
				{
					tAcCode.Text = DC_Main.ColValue[1];
					tAcName.Text = DC_Main.ColValue[0];
					DGV_DETL_FILL();
				}
				((Control)tAcCode).Focus();
			}
		}
		else
		{
			tAcName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["AC_NAME"], (object)""));
			DGV_DETL_FILL();
			((Control)tAcCode).Focus();
		}
	}

	private void chkZero_CheckedChanged(object sender, EventArgs e)
	{
		mFromDt.Text = "01/01/2010";
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		BtnExit.Text = "E&xit";
		chkOpBal.Checked = false;
		((Control)PnlAcSumm).Visible = true;
		DgvAcEnter = false;
		AcSumm();
		((Control)tSearch).Focus();
	}

	private void cboCity_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				DGV_Lot_FILL();
			}
			else
			{
				AcSumm();
			}
		}
	}

	private void cboArea_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
			{
				DGV_Lot_FILL();
			}
			else
			{
				AcSumm();
			}
		}
	}

	private void DGV_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			DgvAcEnter = true;
			DGV_DoubleClick(DGV_AC, new EventArgs());
		}
	}

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[15].Value), (object)""), (object)"' "));
		}
		else
		{
			if (DateTime.Compare(Conversions.ToDate(((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[3].Value), DC_Main.MOp_dt) < 0)
			{
				return;
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[8].Value), (object)""), (object)"' "));
		}
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
		if (Operators.CompareString(DC_Main.CurBookMain, "SALES ORDER", false) == 0)
		{
			TR_SALE_ORD tR_SALE_ORD = new TR_SALE_ORD();
			((Form)tR_SALE_ORD).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_SALE_ORD).Show();
			((Control)tR_SALE_ORD).Focus();
		}
		else if ((Operators.CompareString(DC_Main.CurBookMain, "TAG GEN", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "JDTR TAG", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG TAG", false) == 0))
		{
			TR_TAG_OPBL tR_TAG_OPBL = new TR_TAG_OPBL();
			((Form)tR_TAG_OPBL).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_TAG_OPBL).Show();
			((Control)tR_TAG_OPBL).Focus();
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

	private void BtnF1_Click(object sender, EventArgs e)
	{
		DC_Main.LdrAcMastCode = tAcCode.Text;
		MS_ACCT mS_ACCT = new MS_ACCT();
		((Form)mS_ACCT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
		((Control)mS_ACCT).Show();
		((Control)mS_ACCT).Focus();
	}

	private void chkOpBal_CheckedChanged(object sender, EventArgs e)
	{
		mFromDt.Text = "01/01/2010";
		mToDt.Text = Conversions.ToString(DC_Main.MsSysDate);
		BtnExit.Text = "E&xit";
		chkZero.Checked = false;
		((Control)PnlAcSumm).Visible = true;
		DgvAcEnter = false;
		AcSumm();
		((Control)tSearch).Focus();
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
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		MaskedTextBox MsDate = mToDt;
		DC_Main.SetDate(ref MsDate);
		mToDt = MsDate;
		if (DC_Main.RongDate)
		{
			return;
		}
		if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
		{
			DeleteData();
		}
		else if (Operators.CompareString(CurRpt, "Point Report", false) == 0)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DGV_DETL_POINT_FILL();
			}
			else
			{
				PointSumm();
			}
		}
		else if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				DGV_DETL_LOT_FILL();
			}
			else
			{
				DGV_Lot_FILL();
			}
		}
		else if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			DGV_DETL_FILL();
		}
		else
		{
			AcSumm();
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

	private void cboCity_Click(object sender, EventArgs e)
	{
		if (Operators.CompareString(CurRpt, "Lot Report", false) == 0)
		{
			DGV_Lot_FILL();
		}
		else
		{
			AcSumm();
		}
	}

	private void DGV_DEL_CLEAR()
	{
		((DataGridView)DGV_DEL).DataSource = null;
		((DataGridView)DGV_DEL).Columns.Clear();
		((DataGridView)DGV_DEL).Rows.Clear();
	}

	private void DeleteData()
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ce: Expected O, but got Unknown
		//IL_01fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020d: Expected O, but got Unknown
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
		//IL_0232: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0257: Expected O, but got Unknown
		//IL_0a56: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a60: Expected O, but got Unknown
		DGV_DEL_CLEAR();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY DELETE_DATE,A.BOOK_NAME,SR_NO) AS SrNo,A.BOOK_NAME,A.VCH_DATE,A.VCH_NO,A.SR_NO,A.DELETE_DATE,AC_CODE,AC_NAME,  A.VCH_VAL_DR,A.VCH_VAL_CR,FINE_TYPE,VCH_FINE_DR,VCH_FINE_CR,A.MAIN_USER,DELETE_USER,VCH_DESC  FROM DELETE_DATA AS A LEFT JOIN BOOK_DATA AS D ON A.CO_CODE = D.CO_CODE AND A.LC_CODE = D.LC_CODE AND A.CO_BOOK = D.CO_BOOK  WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.DELETE_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.DELETE_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "'  "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND D.DATA_TYPE = '" + DC_Main.MsDataType + "'"))), Interaction.IIf(Operators.CompareString(cboCity.Text, "", false) == 0, (object)"", (object)("AND B.AC_CITY = '" + cboCity.Text + "'"))), Interaction.IIf(Operators.CompareString(cboArea.Text, "", false) == 0, (object)"", (object)("AND B.AC_AREA = '" + cboArea.Text + "'"))), (object)" "), (object)" ORDER BY DELETE_DATE,A.BOOK_NAME,SR_NO "));
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DataView dataView = new DataView(RsAcSum);
		checked
		{
			if (dataView.Count > 0)
			{
				((DataGridView)DGV_DEL).MultiSelect = false;
				((DataGridView)DGV_DEL).AutoGenerateColumns = false;
				((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
				if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
				{
					((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
					((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
				}
				((DataGridView)DGV_DEL).ColumnCount = 16;
				((DataGridView)DGV_DEL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_DEL).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_DEL).Columns[1].Width = (int)Math.Round(130.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[1].DataPropertyName = "BOOK_NAME";
				((DataGridView)DGV_DEL).Columns[1].HeaderText = "Book";
				((DataGridView)DGV_DEL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[2].DataPropertyName = "VCH_NO";
				((DataGridView)DGV_DEL).Columns[2].HeaderText = "VchNo";
				((DataGridView)DGV_DEL).Columns[3].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[3].DataPropertyName = "SR_NO";
				((DataGridView)DGV_DEL).Columns[3].HeaderText = "Sr.";
				((DataGridView)DGV_DEL).Columns[3].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_DEL).Columns[4].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[4].DataPropertyName = "DELETE_DATE";
				((DataGridView)DGV_DEL).Columns[4].HeaderText = "DelDate";
				((DataGridView)DGV_DEL).Columns[5].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[5].DataPropertyName = "VCH_DATE";
				((DataGridView)DGV_DEL).Columns[5].HeaderText = "VchDate";
				((DataGridView)DGV_DEL).Columns[6].Width = (int)Math.Round(240.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[6].DataPropertyName = "AC_NAME";
				((DataGridView)DGV_DEL).Columns[6].HeaderText = "AcName";
				((DataGridView)DGV_DEL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)16;
				((DataGridView)DGV_DEL).Columns[7].Visible = false;
				((DataGridView)DGV_DEL).Columns[7].DataPropertyName = "AC_CODE";
				((DataGridView)DGV_DEL).Columns[7].HeaderText = "AcCode";
				((DataGridView)DGV_DEL).Columns[8].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[8].DataPropertyName = "VCH_VAL_DR";
				((DataGridView)DGV_DEL).Columns[8].HeaderText = "DrAmt";
				((DataGridView)DGV_DEL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DEL).Columns[8].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DEL).Columns[9].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[9].DataPropertyName = "VCH_VAL_CR";
				((DataGridView)DGV_DEL).Columns[9].HeaderText = "CrAmt";
				((DataGridView)DGV_DEL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DEL).Columns[9].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DEL).Columns[10].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[10].DataPropertyName = "FINE_TYPE";
				((DataGridView)DGV_DEL).Columns[10].HeaderText = "Type";
				((DataGridView)DGV_DEL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
				((DataGridView)DGV_DEL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[11].DataPropertyName = "VCH_FINE_DR";
				((DataGridView)DGV_DEL).Columns[11].HeaderText = "DrFine";
				((DataGridView)DGV_DEL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DEL).Columns[11].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DEL).Columns[12].Width = (int)Math.Round(90.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[12].DataPropertyName = "VCH_FINE_CR";
				((DataGridView)DGV_DEL).Columns[12].HeaderText = "CrFine";
				((DataGridView)DGV_DEL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_DEL).Columns[12].DefaultCellStyle.Format = "N2";
				((DataGridView)DGV_DEL).Columns[13].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[13].DataPropertyName = "MAIN_USER";
				((DataGridView)DGV_DEL).Columns[13].HeaderText = "EntUser";
				((DataGridView)DGV_DEL).Columns[14].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[14].DataPropertyName = "DELETE_USER";
				((DataGridView)DGV_DEL).Columns[14].HeaderText = "DelUser";
				((DataGridView)DGV_DEL).Columns[15].Width = (int)Math.Round(500.0 * ColCon);
				((DataGridView)DGV_DEL).Columns[15].DataPropertyName = "VCH_DESC";
				((DataGridView)DGV_DEL).Columns[15].HeaderText = "Item Remark";
				if (DC_Main.ScreenHight > 1.0)
				{
					((DataGridView)DGV_DEL).ColumnHeadersDefaultCellStyle.Font = new Font("Arial", (float)DC_Main.HaderFont, (FontStyle)1);
				}
				((DataGridView)DGV_DEL).DataSource = dataView;
			}
		}
	}

	private void DGV_DEL_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if (Operators.CompareString(CurRpt, "Delete Data", false) == 0)
					{
						int columnIndex = e.ColumnIndex;
						if (((uint)(columnIndex - 8) <= 1u || (uint)(columnIndex - 11) <= 1u) && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
						{
							((ConvertEventArgs)e).Value = "";
							e.FormattingApplied = true;
						}
					}
					break;
				case 122:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_00b0;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 122;
				continue;
			}
			break;
			IL_00b0:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void cboCity_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	private void cboArea_SelectedIndexChanged(object sender, EventArgs e)
	{
	}
}
