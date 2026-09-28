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
public class RP_MFG_LEDR : Form
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
	[AccessedThroughProperty("tAcCode")]
	private TextBox _tAcCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_DETL")]
	private DataGridViewX _DGV_DETL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("BtnJmaUdhar")]
	private SimpleButton _BtnJmaUdhar;

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
	[AccessedThroughProperty("tBookCode")]
	private TextBox _tBookCode;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSerchAll")]
	private SearchControl _tSerchAll;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tSearch")]
	private TextBox _tSearch;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DGV_AC")]
	private DataGridViewX _DGV_AC;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("chkZero")]
	private CheckBox _chkZero;

	private string EntryMode;

	private Control CurActCtrl;

	private DataTable RsAcSum;

	private double ColCon;

	private string CurRpt;

	private string CurFormula;

	private string UserEdit;

	private string UserDelete;

	private string UserPrint;

	private string MainUser;

	private bool DgvAcEnter;

	private int DgvCurRow;

	private int DgvDtlRow;

	private const int cSrNo = 0;

	private const int cAcCode = 1;

	private const int cAcName = 2;

	private const int cAddress = 3;

	private const int cMobile = 4;

	private const int cDrAmt = 5;

	private const int cCrAmt = 6;

	private const int cDrGold = 7;

	private const int cCrGold = 8;

	private const int cDrSilver = 9;

	private const int cCrSilver = 10;

	private const int cAcRefBy = 11;

	private const int cAcCity = 12;

	private const int cAcKhataNo = 13;

	private const int c2SrNo = 0;

	private const int c2BookName = 1;

	private const int c2VchNo = 2;

	private const int c2VchDate = 3;

	private const int c2AcName = 4;

	private const int c2AcArea = 5;

	private const int c2DrAmt = 6;

	private const int c2Cramt = 7;

	private const int c2BalAmt = 8;

	private const int c2CrDr = 9;

	private const int c2CrGold = 10;

	private const int c2DrGold = 11;

	private const int c2BalGold = 12;

	private const int c2GlCrDr = 13;

	private const int c2CrSilver = 14;

	private const int c2DrSilver = 15;

	private const int c2BalSilver = 16;

	private const int c2SlCrDr = 17;

	private const int c2CoBook = 18;

	private const int c2AcCode = 19;

	private const int c2MainBook = 20;

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
			//IL_0014: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Expected O, but got Unknown
			EventHandler eventHandler = tAcCode_TextChanged;
			KeyEventHandler val = new KeyEventHandler(tAcCode_KeyDown);
			TextBox val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged -= eventHandler;
				((Control)val2).KeyDown -= val;
			}
			_tAcCode = value;
			val2 = _tAcCode;
			if (val2 != null)
			{
				((Control)val2).TextChanged += eventHandler;
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_DETL_CellFormatting);
			EventHandler eventHandler = DGV_DETL_DoubleClick;
			DataGridViewX val2 = _DGV_DETL;
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

	internal virtual SimpleButton BtnJmaUdhar
	{
		[CompilerGenerated]
		get
		{
			return _BtnJmaUdhar;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		[CompilerGenerated]
		set
		{
			EventHandler eventHandler = BtnJmaUdhar_Click;
			SimpleButton val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click -= eventHandler;
			}
			_BtnJmaUdhar = value;
			val = _BtnJmaUdhar;
			if (val != null)
			{
				((Control)val).Click += eventHandler;
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
	[AccessedThroughProperty("tBookName")]
	private virtual TextBox _tBookName;

	internal virtual TextBox tBookName
	{
		get
		{
			return _tBookName;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tBookName = value;
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

	internal virtual TextBox tSearch
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
			EventHandler eventHandler = TSearch_TextChanged;
			TextBox val = _tSearch;
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

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("DgvTot")]
	private virtual DataGridViewX _DgvTot;

	internal virtual DataGridViewX DgvTot
	{
		get
		{
			return _DgvTot;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_DgvTot = value;
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

	internal virtual DataGridViewX DGV_AC
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
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Expected O, but got Unknown
			//IL_0021: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected O, but got Unknown
			DataGridViewCellFormattingEventHandler val = new DataGridViewCellFormattingEventHandler(DGV_AC_CellFormatting);
			EventHandler eventHandler = DGV_AC_DoubleClick;
			DataGridViewCellEventHandler val2 = new DataGridViewCellEventHandler(DGV_AC_CellContentClick);
			DataGridViewX val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting -= val;
				((Control)val3).DoubleClick -= eventHandler;
				((DataGridView)val3).CellContentClick -= val2;
			}
			_DGV_AC = value;
			val3 = _DGV_AC;
			if (val3 != null)
			{
				((DataGridView)val3).CellFormatting += val;
				((Control)val3).DoubleClick += eventHandler;
				((DataGridView)val3).CellContentClick += val2;
			}
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tAcGrCode")]
	private virtual TextBox _tAcGrCode;

	internal virtual TextBox tAcGrCode
	{
		get
		{
			return _tAcGrCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tAcGrCode = value;
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
	[AccessedThroughProperty("tLcCode")]
	private virtual TextBox _tLcCode;

	internal virtual TextBox tLcCode
	{
		get
		{
			return _tLcCode;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tLcCode = value;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[AccessedThroughProperty("tKhataNo")]
	private virtual TextBox _tKhataNo;

	internal virtual TextBox tKhataNo
	{
		get
		{
			return _tKhataNo;
		}
		[MethodImpl(MethodImplOptions.Synchronized)]
		set
		{
			_tKhataNo = value;
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

	public int newindex { get; set; }

	public RP_MFG_LEDR()
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Expected O, but got Unknown
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Expected O, but got Unknown
		((Form)this).Load += RP_MFG_LEDR_Load;
		((Form)this).Activated += RP_MFG_LEDR_Activated;
		((Form)this).Deactivate += RP_MFG_LEDR_Deactivate;
		((Control)this).KeyPress += new KeyPressEventHandler(RP_MFG_LEDR_KeyPress);
		((Control)this).KeyDown += new KeyEventHandler(RP_MFG_LEDR_KeyDown);
		((Form)this).Closed += RP_MFG_LEDR_Closed;
		CurFormula = "";
		DgvAcEnter = false;
		DgvCurRow = 0;
		DgvDtlRow = 0;
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
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d2: Expected O, but got Unknown
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01de: Expected O, but got Unknown
		//IL_01e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ea: Expected O, but got Unknown
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_038e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_03fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0405: Expected O, but got Unknown
		//IL_04ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_04b8: Expected O, but got Unknown
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cd: Expected O, but got Unknown
		//IL_06ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_06f4: Expected O, but got Unknown
		//IL_0757: Unknown result type (might be due to invalid IL or missing references)
		//IL_0761: Expected O, but got Unknown
		//IL_080a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0814: Expected O, but got Unknown
		//IL_0877: Unknown result type (might be due to invalid IL or missing references)
		//IL_0881: Expected O, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0934: Expected O, but got Unknown
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_09a1: Expected O, but got Unknown
		//IL_0ae8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af2: Expected O, but got Unknown
		//IL_0b60: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6a: Expected O, but got Unknown
		//IL_0c19: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c23: Expected O, but got Unknown
		//IL_0c9d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca7: Expected O, but got Unknown
		//IL_0d2b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d35: Expected O, but got Unknown
		//IL_0e03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e0d: Expected O, but got Unknown
		//IL_0e9f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea9: Expected O, but got Unknown
		//IL_0f27: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f31: Expected O, but got Unknown
		//IL_1006: Unknown result type (might be due to invalid IL or missing references)
		//IL_1010: Expected O, but got Unknown
		//IL_1079: Unknown result type (might be due to invalid IL or missing references)
		//IL_1083: Expected O, but got Unknown
		//IL_1115: Unknown result type (might be due to invalid IL or missing references)
		//IL_111f: Expected O, but got Unknown
		//IL_11cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_11d7: Expected O, but got Unknown
		//IL_126e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1278: Expected O, but got Unknown
		//IL_130c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1316: Expected O, but got Unknown
		//IL_13a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ae: Expected O, but got Unknown
		//IL_143f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1449: Expected O, but got Unknown
		//IL_1624: Unknown result type (might be due to invalid IL or missing references)
		//IL_162e: Expected O, but got Unknown
		//IL_169c: Unknown result type (might be due to invalid IL or missing references)
		//IL_16a6: Expected O, but got Unknown
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_1761: Expected O, but got Unknown
		//IL_184b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1855: Expected O, but got Unknown
		//IL_18c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c7: Expected O, but got Unknown
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18cf: Expected O, but got Unknown
		//IL_1934: Unknown result type (might be due to invalid IL or missing references)
		//IL_193e: Expected O, but got Unknown
		//IL_19df: Unknown result type (might be due to invalid IL or missing references)
		//IL_19e9: Expected O, but got Unknown
		//IL_1a85: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a8f: Expected O, but got Unknown
		//IL_1b15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b1f: Expected O, but got Unknown
		//IL_1c09: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c13: Expected O, but got Unknown
		//IL_1c7c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c86: Expected O, but got Unknown
		//IL_1d15: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d1f: Expected O, but got Unknown
		//IL_1def: Unknown result type (might be due to invalid IL or missing references)
		//IL_1df9: Expected O, but got Unknown
		//IL_1e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_1e9f: Expected O, but got Unknown
		//IL_1f25: Unknown result type (might be due to invalid IL or missing references)
		//IL_1f2f: Expected O, but got Unknown
		//IL_2016: Unknown result type (might be due to invalid IL or missing references)
		//IL_2020: Expected O, but got Unknown
		//IL_2089: Unknown result type (might be due to invalid IL or missing references)
		//IL_2093: Expected O, but got Unknown
		//IL_2132: Unknown result type (might be due to invalid IL or missing references)
		//IL_213c: Expected O, but got Unknown
		//IL_21c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_21d0: Expected O, but got Unknown
		ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(RP_MFG_LEDR));
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
		BtnDelete = new SimpleButton();
		BtnCancel = new SimpleButton();
		BtnSave = new SimpleButton();
		BtnPrint = new SimpleButton();
		BtnJmaUdhar = new SimpleButton();
		FlowLayoutPanel1 = new FlowLayoutPanel();
		Cr = new AxCrystalReport();
		lblBook = new Label();
		tAcCode = new TextBox();
		tAcName = new TextBox();
		Label2 = new Label();
		DGV_DETL = new DataGridViewX();
		Label4 = new Label();
		mToDt = new MaskedTextBox();
		mFromDt = new MaskedTextBox();
		tBookCode = new TextBox();
		tBookName = new TextBox();
		Label5 = new Label();
		PnlAcSumm = new Panel();
		tKhataNo = new TextBox();
		Label1 = new Label();
		chkZero = new CheckBox();
		tSerchAll = new SearchControl();
		tSearch = new TextBox();
		DgvTot = new DataGridViewX();
		Label15 = new Label();
		DGV_AC = new DataGridViewX();
		tAcGrCode = new TextBox();
		tLcCode = new TextBox();
		((Control)PnlBotam).SuspendLayout();
		((ISupportInitialize)Cr).BeginInit();
		((ISupportInitialize)DGV_DETL).BeginInit();
		((Control)PnlAcSumm).SuspendLayout();
		((ISupportInitialize)tSerchAll.Properties).BeginInit();
		((ISupportInitialize)DgvTot).BeginInit();
		((ISupportInitialize)DGV_AC).BeginInit();
		((Control)this).SuspendLayout();
		((Control)PnlBotam).BackColor = Color.SandyBrown;
		((Control)PnlBotam).Controls.Add((Control)(object)BtnExit);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnDelete);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnCancel);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnSave);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnPrint);
		((Control)PnlBotam).Controls.Add((Control)(object)BtnJmaUdhar);
		((Control)PnlBotam).Controls.Add((Control)(object)FlowLayoutPanel1);
		((Control)PnlBotam).Dock = (DockStyle)2;
		PnlBotam.FlowDirection = (FlowDirection)2;
		((Control)PnlBotam).Location = new Point(0, 566);
		((Control)PnlBotam).Margin = new Padding(2);
		((Control)PnlBotam).Name = "PnlBotam";
		((Control)PnlBotam).Size = new Size(1309, 41);
		((Control)PnlBotam).TabIndex = 4;
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
		BtnSave.Text = "&Excel";
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
		((BaseStyleControl)BtnJmaUdhar).Appearance.Font = new Font("Franklin Gothic Book", 9.75f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.ForeColor = Color.FromArgb(192, 64, 0);
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseFont = true;
		((BaseStyleControl)BtnJmaUdhar).Appearance.Options.UseForeColor = true;
		((ImageCollectionImageOptions)BtnJmaUdhar.ImageOptions).SvgImage = (SvgImage)componentResourceManager.GetObject("BtnJmaUdhar.ImageOptions.SvgImage");
		((Control)BtnJmaUdhar).Location = new Point(730, 3);
		((BaseControl)BtnJmaUdhar).LookAndFeel.SkinName = "The Bezier";
		((BaseControl)BtnJmaUdhar).LookAndFeel.UseDefaultLookAndFeel = false;
		((Control)BtnJmaUdhar).Name = "BtnJmaUdhar";
		((Control)BtnJmaUdhar).Size = new Size(91, 37);
		((Control)BtnJmaUdhar).TabIndex = 10;
		BtnJmaUdhar.Text = "&JmUdr";
		((BaseButton)BtnJmaUdhar).ToolTipAnchor = (ToolTipAnchor)1;
		((Control)BtnJmaUdhar).Visible = false;
		FlowLayoutPanel1.FlowDirection = (FlowDirection)2;
		((Control)FlowLayoutPanel1).Location = new Point(268, 3);
		((Control)FlowLayoutPanel1).Name = "FlowLayoutPanel1";
		((Control)FlowLayoutPanel1).Size = new Size(456, 33);
		((Control)FlowLayoutPanel1).TabIndex = 1167;
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
		lblBook.Text = "Mfg Ledger";
		lblBook.TextAlign = (ContentAlignment)32;
		((TextBoxBase)tAcCode).BackColor = Color.White;
		((Control)tAcCode).Font = new Font("Tahoma", 9f);
		((Control)tAcCode).Location = new Point(339, 45);
		((TextBoxBase)tAcCode).MaxLength = 8;
		((Control)tAcCode).Name = "tAcCode";
		((Control)tAcCode).Size = new Size(78, 22);
		((Control)tAcCode).TabIndex = 2;
		((TextBoxBase)tAcName).BackColor = Color.White;
		((Control)tAcName).Font = new Font("Tahoma", 9.75f);
		((Control)tAcName).Location = new Point(421, 45);
		((TextBoxBase)tAcName).MaxLength = 8;
		((Control)tAcName).Name = "tAcName";
		((Control)tAcName).Size = new Size(272, 23);
		((Control)tAcName).TabIndex = 1129;
		((Control)Label2).BackColor = Color.Transparent;
		((Control)Label2).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label2).ForeColor = Color.Black;
		Label2.ImeMode = (ImeMode)0;
		((Control)Label2).Location = new Point(246, 46);
		((Control)Label2).Name = "Label2";
		((Control)Label2).Size = new Size(83, 20);
		((Control)Label2).TabIndex = 1132;
		Label2.Text = "Party Code";
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
		((DataGridView)DGV_DETL).BackgroundColor = Color.SeaShell;
		((DataGridView)DGV_DETL).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_DETL).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val2.Alignment = (DataGridViewContentAlignment)16;
		val2.BackColor = SystemColors.Control;
		val2.Font = new Font("Tahoma", 9.75f);
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
		((Control)DGV_DETL).Location = new Point(13, 80);
		((Control)DGV_DETL).Name = "DGV_DETL";
		DGV_DETL.PaintEnhancedSelection = false;
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
		((Control)Label4).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label4).ForeColor = Color.Black;
		Label4.ImeMode = (ImeMode)0;
		((Control)Label4).Location = new Point(32, 45);
		((Control)Label4).Name = "Label4";
		((Control)Label4).Size = new Size(44, 20);
		((Control)Label4).TabIndex = 1159;
		Label4.Text = "Date";
		Label4.TextAlign = (ContentAlignment)64;
		((TextBoxBase)mToDt).BackColor = Color.White;
		((Control)mToDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mToDt).Location = new Point(164, 44);
		mToDt.Mask = "00/00/0000";
		((Control)mToDt).Name = "mToDt";
		((Control)mToDt).Size = new Size(76, 23);
		((Control)mToDt).TabIndex = 1;
		mToDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)mFromDt).BackColor = Color.White;
		((Control)mFromDt).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)mFromDt).Location = new Point(82, 44);
		mFromDt.Mask = "00/00/0000";
		((Control)mFromDt).Name = "mFromDt";
		((Control)mFromDt).Size = new Size(76, 23);
		((Control)mFromDt).TabIndex = 0;
		mFromDt.ValidatingType = typeof(DateTime);
		((TextBoxBase)tBookCode).BackColor = Color.White;
		((Control)tBookCode).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookCode).Location = new Point(762, 46);
		((TextBoxBase)tBookCode).MaxLength = 8;
		((Control)tBookCode).Name = "tBookCode";
		((Control)tBookCode).Size = new Size(68, 23);
		((Control)tBookCode).TabIndex = 1162;
		((Control)tBookCode).Visible = false;
		((TextBoxBase)tBookName).BackColor = Color.White;
		((Control)tBookName).Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tBookName).Location = new Point(836, 46);
		((TextBoxBase)tBookName).MaxLength = 8;
		((Control)tBookName).Name = "tBookName";
		((Control)tBookName).Size = new Size(268, 23);
		((Control)tBookName).TabIndex = 1164;
		((Control)tBookName).Visible = false;
		((Control)Label5).BackColor = Color.Transparent;
		((Control)Label5).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)Label5).ForeColor = Color.Black;
		Label5.ImeMode = (ImeMode)0;
		((Control)Label5).Location = new Point(702, 46);
		((Control)Label5).Name = "Label5";
		((Control)Label5).Size = new Size(50, 20);
		((Control)Label5).TabIndex = 1163;
		Label5.Text = "Book";
		Label5.TextAlign = (ContentAlignment)64;
		((Control)Label5).Visible = false;
		((Control)PnlAcSumm).Controls.Add((Control)(object)tKhataNo);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label1);
		((Control)PnlAcSumm).Controls.Add((Control)(object)chkZero);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSerchAll);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tSearch);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DgvTot);
		((Control)PnlAcSumm).Controls.Add((Control)(object)Label15);
		((Control)PnlAcSumm).Controls.Add((Control)(object)DGV_AC);
		((Control)PnlAcSumm).Controls.Add((Control)(object)tAcGrCode);
		((Control)PnlAcSumm).Location = new Point(1, 34);
		((Control)PnlAcSumm).Name = "PnlAcSumm";
		((Control)PnlAcSumm).Size = new Size(1196, 531);
		((Control)PnlAcSumm).TabIndex = 1165;
		((TextBoxBase)tKhataNo).BackColor = Color.White;
		((Control)tKhataNo).Font = new Font("Tahoma", 9f);
		((Control)tKhataNo).Location = new Point(532, 12);
		((TextBoxBase)tKhataNo).MaxLength = 10;
		((Control)tKhataNo).Name = "tKhataNo";
		((Control)tKhataNo).Size = new Size(75, 22);
		((Control)tKhataNo).TabIndex = 1161;
		((Control)Label1).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label1).ForeColor = Color.Black;
		Label1.ImeMode = (ImeMode)0;
		((Control)Label1).Location = new Point(445, 14);
		((Control)Label1).Name = "Label1";
		((Control)Label1).Size = new Size(79, 20);
		((Control)Label1).TabIndex = 1162;
		Label1.Text = "Khata No";
		Label1.TextAlign = (ContentAlignment)64;
		((ButtonBase)chkZero).BackColor = Color.Transparent;
		((Control)chkZero).Font = new Font("Arial", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)chkZero).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)chkZero).Location = new Point(629, 14);
		((Control)chkZero).Name = "chkZero";
		((Control)chkZero).RightToLeft = (RightToLeft)0;
		((Control)chkZero).Size = new Size(141, 19);
		((Control)chkZero).TabIndex = 1160;
		((ButtonBase)chkZero).Text = "With Zero Balance";
		chkZero.TextAlign = (ContentAlignment)32;
		((ButtonBase)chkZero).UseVisualStyleBackColor = false;
		((Control)tSerchAll).Location = new Point(163, 12);
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
		((Control)tSerchAll).Size = new Size(148, 24);
		((Control)tSerchAll).TabIndex = 1;
		((TextBoxBase)tSearch).BackColor = Color.White;
		((Control)tSearch).Font = new Font("Franklin Gothic Book", 11.25f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((Control)tSearch).Location = new Point(16, 12);
		((TextBoxBase)tSearch).MaxLength = 50;
		((Control)tSearch).Name = "tSearch";
		((Control)tSearch).Size = new Size(141, 25);
		((Control)tSearch).TabIndex = 1159;
		((DataGridView)DgvTot).AllowUserToAddRows = false;
		((DataGridView)DgvTot).AllowUserToDeleteRows = false;
		((DataGridView)DgvTot).AllowUserToResizeRows = false;
		val6.BackColor = Color.PapayaWhip;
		val6.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val6.ForeColor = Color.FromArgb(64, 64, 64);
		val6.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val6.SelectionForeColor = Color.Maroon;
		((DataGridView)DgvTot).AlternatingRowsDefaultCellStyle = val6;
		((DataGridView)DgvTot).BackgroundColor = Color.Snow;
		((DataGridView)DgvTot).BorderStyle = (BorderStyle)2;
		((DataGridView)DgvTot).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val7.Alignment = (DataGridViewContentAlignment)16;
		val7.BackColor = SystemColors.Control;
		val7.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val7.ForeColor = Color.FromArgb(64, 64, 64);
		val7.SelectionBackColor = SystemColors.ScrollBar;
		val7.SelectionForeColor = Color.White;
		val7.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvTot).ColumnHeadersDefaultCellStyle = val7;
		((DataGridView)DgvTot).ColumnHeadersHeight = 30;
		((DataGridView)DgvTot).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val8.Alignment = (DataGridViewContentAlignment)16;
		val8.BackColor = SystemColors.Window;
		val8.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val8.ForeColor = Color.FromArgb(64, 64, 64);
		val8.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val8.SelectionForeColor = Color.Maroon;
		val8.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DgvTot).DefaultCellStyle = val8;
		((DataGridView)DgvTot).EnableHeadersVisualStyles = false;
		((DataGridView)DgvTot).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DgvTot).Location = new Point(15, 493);
		((Control)DgvTot).Name = "DgvTot";
		DgvTot.PaintEnhancedSelection = false;
		((DataGridView)DgvTot).ReadOnly = true;
		val9.Alignment = (DataGridViewContentAlignment)16;
		val9.BackColor = Color.MintCream;
		val9.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val9.ForeColor = SystemColors.WindowText;
		val9.SelectionBackColor = SystemColors.Highlight;
		val9.SelectionForeColor = SystemColors.HighlightText;
		val9.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DgvTot).RowHeadersDefaultCellStyle = val9;
		((DataGridView)DgvTot).RowHeadersVisible = false;
		((DataGridView)DgvTot).RowHeadersWidth = 20;
		val10.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val10.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DgvTot).RowsDefaultCellStyle = val10;
		DgvTot.ScrollBarAppearance = (eScrollBarAppearance)0;
		DgvTot.SelectAllSignVisible = false;
		((DataGridView)DgvTot).SelectionMode = (DataGridViewSelectionMode)0;
		((Control)DgvTot).Size = new Size(1160, 27);
		((DataGridView)DgvTot).StandardTab = true;
		((Control)DgvTot).TabIndex = 1158;
		((Control)Label15).Font = new Font("Franklin Gothic Book", 11.25f);
		((Control)Label15).ForeColor = Color.Black;
		Label15.ImeMode = (ImeMode)0;
		((Control)Label15).Location = new Point(317, 12);
		((Control)Label15).Name = "Label15";
		((Control)Label15).Size = new Size(72, 20);
		((Control)Label15).TabIndex = 1136;
		Label15.Text = "Ac Group";
		Label15.TextAlign = (ContentAlignment)64;
		((DataGridView)DGV_AC).AllowUserToAddRows = false;
		((DataGridView)DGV_AC).AllowUserToDeleteRows = false;
		((DataGridView)DGV_AC).AllowUserToResizeRows = false;
		val11.BackColor = Color.PapayaWhip;
		val11.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val11.ForeColor = Color.FromArgb(64, 64, 64);
		val11.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val11.SelectionForeColor = Color.Maroon;
		((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle = val11;
		((DataGridView)DGV_AC).BackgroundColor = Color.Snow;
		((DataGridView)DGV_AC).BorderStyle = (BorderStyle)2;
		((DataGridView)DGV_AC).CellBorderStyle = (DataGridViewCellBorderStyle)2;
		val12.Alignment = (DataGridViewContentAlignment)16;
		val12.BackColor = SystemColors.Control;
		val12.Font = new Font("Calibri", 12f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		val12.ForeColor = Color.FromArgb(64, 64, 64);
		val12.SelectionBackColor = SystemColors.ScrollBar;
		val12.SelectionForeColor = Color.White;
		val12.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).ColumnHeadersDefaultCellStyle = val12;
		((DataGridView)DGV_AC).ColumnHeadersHeight = 30;
		((DataGridView)DGV_AC).ColumnHeadersHeightSizeMode = (DataGridViewColumnHeadersHeightSizeMode)1;
		val13.Alignment = (DataGridViewContentAlignment)16;
		val13.BackColor = SystemColors.Window;
		val13.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val13.ForeColor = Color.FromArgb(64, 64, 64);
		val13.SelectionBackColor = Color.FromArgb(255, 192, 192);
		val13.SelectionForeColor = Color.Maroon;
		val13.WrapMode = (DataGridViewTriState)2;
		((DataGridView)DGV_AC).DefaultCellStyle = val13;
		((DataGridView)DGV_AC).EnableHeadersVisualStyles = false;
		((DataGridView)DGV_AC).GridColor = Color.FromArgb(208, 215, 229);
		((Control)DGV_AC).Location = new Point(15, 45);
		((Control)DGV_AC).Name = "DGV_AC";
		DGV_AC.PaintEnhancedSelection = false;
		((DataGridView)DGV_AC).ReadOnly = true;
		val14.Alignment = (DataGridViewContentAlignment)16;
		val14.BackColor = Color.MintCream;
		val14.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val14.ForeColor = SystemColors.WindowText;
		val14.SelectionBackColor = SystemColors.Highlight;
		val14.SelectionForeColor = SystemColors.HighlightText;
		val14.WrapMode = (DataGridViewTriState)1;
		((DataGridView)DGV_AC).RowHeadersDefaultCellStyle = val14;
		((DataGridView)DGV_AC).RowHeadersVisible = false;
		((DataGridView)DGV_AC).RowHeadersWidth = 20;
		val15.Font = new Font("Tahoma", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		val15.ForeColor = Color.FromArgb(64, 64, 64);
		((DataGridView)DGV_AC).RowsDefaultCellStyle = val15;
		DGV_AC.ScrollBarAppearance = (eScrollBarAppearance)0;
		DGV_AC.SelectAllSignVisible = false;
		((DataGridView)DGV_AC).SelectionMode = (DataGridViewSelectionMode)1;
		((Control)DGV_AC).Size = new Size(1160, 448);
		((DataGridView)DGV_AC).StandardTab = true;
		((Control)DGV_AC).TabIndex = 2;
		((TextBoxBase)tAcGrCode).BackColor = Color.White;
		((Control)tAcGrCode).Font = new Font("Tahoma", 9f);
		((Control)tAcGrCode).Location = new Point(395, 12);
		((TextBoxBase)tAcGrCode).MaxLength = 2;
		((Control)tAcGrCode).Name = "tAcGrCode";
		((Control)tAcGrCode).Size = new Size(43, 22);
		((Control)tAcGrCode).TabIndex = 4;
		tAcGrCode.TextAlign = (HorizontalAlignment)2;
		((TextBoxBase)tLcCode).BackColor = Color.White;
		((Control)tLcCode).Font = new Font("Franklin Gothic Medium Cond", 9.75f, (FontStyle)0, (GraphicsUnit)3, (byte)0);
		((TextBoxBase)tLcCode).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)tLcCode).Location = new Point(1141, 6);
		((TextBoxBase)tLcCode).MaxLength = 10;
		((Control)tLcCode).Name = "tLcCode";
		((Control)tLcCode).Size = new Size(44, 22);
		((Control)tLcCode).TabIndex = 1166;
		tLcCode.TextAlign = (HorizontalAlignment)2;
		((Control)tLcCode).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(96f, 96f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)2;
		((Form)this).BackColor = SystemColors.ButtonHighlight;
		((Form)this).ClientSize = new Size(1309, 607);
		((Control)this).Controls.Add((Control)(object)tLcCode);
		((Control)this).Controls.Add((Control)(object)PnlAcSumm);
		((Control)this).Controls.Add((Control)(object)Label2);
		((Control)this).Controls.Add((Control)(object)Cr);
		((Control)this).Controls.Add((Control)(object)tAcCode);
		((Control)this).Controls.Add((Control)(object)tAcName);
		((Control)this).Controls.Add((Control)(object)lblBook);
		((Control)this).Controls.Add((Control)(object)PnlBotam);
		((Control)this).Controls.Add((Control)(object)DGV_DETL);
		((Control)this).Controls.Add((Control)(object)Label4);
		((Control)this).Controls.Add((Control)(object)mToDt);
		((Control)this).Controls.Add((Control)(object)mFromDt);
		((Control)this).Controls.Add((Control)(object)tBookCode);
		((Control)this).Controls.Add((Control)(object)tBookName);
		((Control)this).Controls.Add((Control)(object)Label5);
		((Form)this).FormBorderStyle = (FormBorderStyle)1;
		((Form)this).KeyPreview = true;
		((Control)this).Name = "RP_MFG_LEDR";
		((Form)this).Text = "Mfg Ledger";
		((Control)PnlBotam).ResumeLayout(false);
		((ISupportInitialize)Cr).EndInit();
		((ISupportInitialize)DGV_DETL).EndInit();
		((Control)PnlAcSumm).ResumeLayout(false);
		((Control)PnlAcSumm).PerformLayout();
		((ISupportInitialize)tSerchAll.Properties).EndInit();
		((ISupportInitialize)DgvTot).EndInit();
		((ISupportInitialize)DGV_AC).EndInit();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}

	private void chkZero_CheckedChanged(object sender, EventArgs e)
	{
		AcSumm();
	}

	private void AcSumm()
	{
		DgvAcEnter = false;
		if (!chkZero.Checked)
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.KR_AC_CODE As AcCode,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.KR_AC_CODE <> '' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)(" And B.AC_GR = '" + tAcGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKhataNo.Text, "", false) == 0, (object)"", (object)("AND B.AC_KHATA_NO = '" + tKhataNo.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" "), (object)" GROUP BY A.KR_AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO "), (object)" HAVING (round(Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) + "), (object)" (round(Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End,2)) + "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end,'0.000')) + "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end,'0.00'))+ "), (object)" (format(Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end,'0.00')) <> 0 "), (object)" ORDER BY B.AC_NAME "));
		}
		else
		{
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select ROW_NUMBER() OVER (ORDER BY B.AC_NAME) AS SrNo,A.KR_AC_CODE As AcCode,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME As AC_REFBY,B.AC_CITY,B.AC_KHATA_NO,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case When SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM MFG_ISU_REC AS A LEFT JOIN AC_MAST AS B ON A.CO_CODE = B.CO_CODE And A.KR_AC_CODE = B.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.KR_AC_CODE <> '' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND A.LC_CODE = '" + tLcCode.Text + "'"))), (object)" and A.VCH_DATE <= '"), (object)Strings.Format((object)DC_Main.MsSysDate, "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(tAcGrCode.Text, "", false) == 0, (object)"", (object)("AND B.AC_GR = '" + tAcGrCode.Text + "'"))), Interaction.IIf(Operators.CompareString(tKhataNo.Text, "", false) == 0, (object)"", (object)("AND B.AC_KHATA_NO = '" + tKhataNo.Text + "'"))), Interaction.IIf(Operators.CompareString(DC_Main.MCo_UserType, "U", false) == 0, RuntimeHelpers.GetObjectValue(Interaction.IIf(Operators.CompareString(DC_Main.MsUserNotShowGr, "", false) == 0, (object)"", (object)("AND B.AC_GR NOT IN (" + DC_Main.MsUserNotShowGr + ")"))), (object)"")), (object)" "), (object)" GROUP BY A.KR_AC_CODE,B.AC_NAME,B.AC_ADD1,B.AC_MOBILE,B.AC_REF_NAME,B.AC_CITY,B.AC_KHATA_NO ORDER BY B.AC_NAME "));
		}
		RsAcSum = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DGV_FILL();
	}

	private void DGV_CLEAR()
	{
		((DataGridView)DGV_AC).DataSource = null;
	}

	private void DGV_FILL()
	{
		//IL_0cdc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce6: Expected O, but got Unknown
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_0d28: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d2d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d37: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Expected O, but got Unknown
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Expected O, but got Unknown
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Expected O, but got Unknown
		//IL_0ea1: Unknown result type (might be due to invalid IL or missing references)
		DGV_CLEAR();
		DataView dataView = new DataView(RsAcSum);
		checked
		{
			if (dataView.Count > 0)
			{
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
				((DataGridView)DGV_AC).ColumnCount = 14;
				((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
				((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
				((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
				((DataGridView)DGV_AC).Columns[1].Visible = false;
				((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AcCode";
				((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
				((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
				((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
				((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
				((DataGridView)DGV_AC).Columns[3].Visible = false;
				((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
				((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
				((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
				((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
				((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
				((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
				((DataGridView)DGV_AC).Columns[6].HeaderText = "CrAmt";
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0, (object)"0.00", (object)"N2"));
				((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
				((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
				((DataGridView)DGV_AC).Columns[5].HeaderText = "DrAmt";
				((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.SSRegSrNo, "HM376NEHM", false) == 0, (object)"0.00", (object)"N2"));
				((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
				((DataGridView)DGV_AC).Columns[8].HeaderText = "CrGold";
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
				((DataGridView)DGV_AC).Columns[7].HeaderText = "DrGold";
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
				((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
				((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"N3", (object)"N2"));
				((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
				((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
				((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
				((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"N3", (object)"N2"));
				((DataGridView)DGV_AC).Columns[11].Visible = false;
				((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
				((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
				((DataGridView)DGV_AC).Columns[12].Visible = false;
				((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
				((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
				((DataGridView)DGV_AC).Columns[13].Visible = false;
				((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
				((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
				((DataGridView)DGV_AC).DataSource = dataView;
				if (((DataGridView)DGV_AC).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[2].Value, (object)""), (object)"Total :", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).Rows.Count - 1].Cells[2].Value, (object)""), (object)"", false))))
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
				int num7 = ((DataGridView)DGV_AC).Rows.Count - 1;
				for (int i = 0; i <= num7; i++)
				{
					if (Operators.ConditionalCompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[1].Value, (object)""), (object)"Total :", false))
					{
						num += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[6].Value, (object)""));
						num2 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[5].Value, (object)""));
						num3 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[8].Value, (object)""));
						num4 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[7].Value, (object)""));
						num5 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[10].Value, (object)""));
						num6 += Conversion.Val(Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[i].Cells[9].Value, (object)""));
					}
				}
				int num8 = ((DataGridView)DGV_AC).Rows.Count - 1;
				((DataGridView)DGV_AC).Rows[num8].Cells[2].Value = "Total :";
				((DataGridView)DGV_AC).Rows[num8].Cells[6].Value = Strings.Format((object)num, "0.00");
				((DataGridView)DGV_AC).Rows[num8].Cells[5].Value = Strings.Format((object)num2, "0.00");
				((DataGridView)DGV_AC).Rows[num8].Cells[8].Value = Strings.Format((object)num3, "0.000");
				((DataGridView)DGV_AC).Rows[num8].Cells[7].Value = Strings.Format((object)num4, "0.000");
				((DataGridView)DGV_AC).Rows[num8].Cells[10].Value = Strings.Format((object)num5, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")));
				((DataGridView)DGV_AC).Rows[num8].Cells[9].Value = Strings.Format((object)num6, Conversions.ToString(Interaction.IIf(Operators.CompareString(DC_Main.MsSilverWt3Digit, "Y", false) == 0, (object)"0.000", (object)"0.00")));
			}
			((DataGridView)DgvTot).RowsDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10f, (FontStyle)0);
			((DataGridView)DgvTot).RowTemplate.Height = 25;
			if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
			{
				((DataGridView)DgvTot).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
				((DataGridView)DgvTot).RowTemplate.Height = DC_Main.MsGridRowHeight;
			}
			((DataGridView)DgvTot).ColumnHeadersVisible = false;
			((DataGridView)DgvTot).Columns.Add("", "");
			((DataGridView)DgvTot).Rows.Add();
			((DataGridView)DgvTot).ScrollBars = (ScrollBars)0;
			DC_Main.R = ((DataGridView)DGV_AC).RowCount - 1;
			if (DC_Main.R > 0)
			{
				int num9 = ((DataGridView)DGV_AC).ColumnCount - 1;
				DC_Main.i = 0;
				while (DC_Main.i <= num9)
				{
					((DataGridView)DgvTot).Columns.Add("", "");
					((DataGridView)DgvTot).Columns[DC_Main.i].Width = ((DataGridView)DGV_AC).Columns[DC_Main.i].Width;
					((DataGridView)DgvTot)[DC_Main.i, 0].Value = Operators.ConcatenateObject(((DataGridView)DGV_AC).Rows[DC_Main.R].Cells[DC_Main.i].Value, (object)"");
					((DataGridView)DgvTot).Columns[DC_Main.i].DefaultCellStyle.Alignment = ((DataGridView)DGV_AC).Columns[DC_Main.i].DefaultCellStyle.Alignment;
					if (!((DataGridView)DGV_AC).Columns[DC_Main.i].Visible)
					{
						((DataGridView)DgvTot).Columns[DC_Main.i].Visible = false;
					}
					DC_Main.i++;
				}
			}
			if (DgvCurRow > 0 && ((DataGridView)DGV_AC).Rows.Count >= DgvCurRow)
			{
				((DataGridView)DGV_AC).Rows[DgvCurRow].Cells[2].Selected = true;
			}
			if ((Operators.CompareString(DC_Main.MsRptTotShow, "Y", false) == 0) & (((DataGridView)DGV_AC).RowCount > 1))
			{
				((DataGridView)DGV_AC).Rows[((DataGridView)DGV_AC).RowCount - 1].Cells[0].Selected = true;
			}
		}
	}

	private void DGV_AC_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
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
					if ((uint)(columnIndex - 5) <= 5u && Conversions.ToDouble(((ConvertEventArgs)e).Value.ToString()) == 0.0)
					{
						((ConvertEventArgs)e).Value = "";
						e.FormattingApplied = true;
					}
					break;
				}
				case 88:
					num = -1;
					switch (num2)
					{
					case 2:
						break;
					default:
						goto IL_008e;
					}
					break;
				}
			}
			catch (object obj) when (obj is Exception && num2 != 0 && num == 0)
			{
				ProjectData.SetProjectError((Exception)obj);
				try0001_dispatch = 88;
				continue;
			}
			break;
			IL_008e:
			throw ProjectData.CreateProjectError(-2146828237);
		}
		if (num != 0)
		{
			ProjectData.ClearProjectError();
		}
	}

	private void TSearch_TextChanged(object sender, EventArgs e)
	{
		checked
		{
			if ((Operators.CompareString(tSearch.Text, "", false) == 0) & (Operators.CompareString(tSearch.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_FILL();
			}
			else if ((Operators.CompareString(tSearch.Text, "", false) != 0) & (Operators.CompareString(tSearch.Text, "SEARCH RECORD", false) != 0))
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '" + tSearch.Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AcCode";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Visible = false;
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[12].Visible = false;
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[13].Visible = false;
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
					((DataGridView)DGV_AC).DataSource = dataView;
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
				((Control)tSerchAll).ResetText();
				DGV_FILL();
			}
			else if (Operators.CompareString(((TextEdit)tSerchAll).Text, "", false) != 0)
			{
				DGV_CLEAR();
				DataView dataView = new DataView(RsAcSum);
				dataView.RowFilter = "AC_NAME Like  '%" + ((TextEdit)tSerchAll).Text + "%' OR AC_MOBILE Like '%" + ((TextEdit)tSerchAll).Text + "%' ";
				if (dataView.Count > 0)
				{
					((DataGridView)DGV_AC).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
					((DataGridView)DGV_AC).Columns[0].DataPropertyName = "SrNo";
					((DataGridView)DGV_AC).Columns[0].HeaderText = "SrNo";
					((DataGridView)DGV_AC).Columns[1].Visible = false;
					((DataGridView)DGV_AC).Columns[1].DataPropertyName = "AcCode";
					((DataGridView)DGV_AC).Columns[1].HeaderText = "Code";
					((DataGridView)DGV_AC).Columns[2].Width = (int)Math.Round(315.0 * ColCon);
					((DataGridView)DGV_AC).Columns[2].DataPropertyName = "AC_NAME";
					((DataGridView)DGV_AC).Columns[2].HeaderText = "Party Name";
					((DataGridView)DGV_AC).Columns[3].Visible = false;
					((DataGridView)DGV_AC).Columns[3].DataPropertyName = "AC_ADD1";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "Address1";
					((DataGridView)DGV_AC).Columns[4].Width = (int)Math.Round(110.0 * ColCon);
					((DataGridView)DGV_AC).Columns[4].DataPropertyName = "AC_MOBILE";
					((DataGridView)DGV_AC).Columns[4].HeaderText = "Mobile";
					((DataGridView)DGV_AC).Columns[6].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[6].DataPropertyName = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].HeaderText = "CrAmt";
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[6].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[5].Width = (int)Math.Round(125.0 * ColCon);
					((DataGridView)DGV_AC).Columns[5].DataPropertyName = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].HeaderText = "DrAmt";
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[5].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[8].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[8].DataPropertyName = "CrGold";
					((DataGridView)DGV_AC).Columns[8].HeaderText = "CrGold";
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[8].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[7].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[7].DataPropertyName = "DrGold";
					((DataGridView)DGV_AC).Columns[7].HeaderText = "DrGold";
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[7].DefaultCellStyle.Format = "N3";
					((DataGridView)DGV_AC).Columns[10].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[10].DataPropertyName = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].HeaderText = "CrSilver";
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[10].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[9].Width = (int)Math.Round(100.0 * ColCon);
					((DataGridView)DGV_AC).Columns[9].DataPropertyName = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].HeaderText = "DrSilver";
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
					((DataGridView)DGV_AC).Columns[9].DefaultCellStyle.Format = "N2";
					((DataGridView)DGV_AC).Columns[11].Visible = false;
					((DataGridView)DGV_AC).Columns[11].DataPropertyName = "AC_REFBY";
					((DataGridView)DGV_AC).Columns[3].HeaderText = "RefBy";
					((DataGridView)DGV_AC).Columns[12].Visible = false;
					((DataGridView)DGV_AC).Columns[12].DataPropertyName = "AC_CITY";
					((DataGridView)DGV_AC).Columns[12].HeaderText = "City";
					((DataGridView)DGV_AC).Columns[13].Visible = false;
					((DataGridView)DGV_AC).Columns[13].DataPropertyName = "AC_KHATA_NO";
					((DataGridView)DGV_AC).Columns[13].HeaderText = "KhataNo";
					((DataGridView)DGV_AC).DataSource = dataView;
				}
			}
		}
	}

	private void DGV_AC_DoubleClick(object sender, EventArgs e)
	{
		((Control)PnlAcSumm).Visible = false;
		((Control)tLcCode).Visible = false;
		DgvAcEnter = true;
		int columnIndex = ((DataGridView)DGV_AC).CurrentCell.ColumnIndex;
		int index = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		DgvCurRow = ((DataGridViewBand)((DataGridView)DGV_AC).CurrentRow).Index;
		tAcCode.Text = ((DataGridView)DGV_AC)[1, index].Value.ToString() ?? "";
		tAcName.Text = ((DataGridView)DGV_AC)[2, index].Value.ToString() ?? "";
		BtnExit.Text = "&Back";
		((Control)BtnDelete).Visible = true;
		DGV_DETL_FILL();
	}

	private void DGV_DETL_FILL()
	{
		//IL_027e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0288: Expected O, but got Unknown
		//IL_02ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02df: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ee: Expected O, but got Unknown
		//IL_0304: Unknown result type (might be due to invalid IL or missing references)
		//IL_0309: Unknown result type (might be due to invalid IL or missing references)
		//IL_0313: Expected O, but got Unknown
		((DataGridView)DGV_DETL).DataSource = null;
		((DataGridView)DGV_DETL).ClearSelection();
		((DataGridView)DGV_DETL).Rows.Clear();
		((DataGridView)DGV_DETL).Columns.Clear();
		((Control)DGV_DETL).Refresh();
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrSilver  FROM (MFG_ISU_REC AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE < '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)""));
		DataTable dataTable = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("Select B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.AC_CODE As AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA,  Case When SUM(A.CR_AMT-A.DR_AMT) < 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As DrAmt,  Case WHEN SUM(A.CR_AMT-A.DR_AMT) > 0 Then abs(SUM(A.CR_AMT-A.DR_AMT)) Else 0 End As CrAmt,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrGold,  Case When SUM(Case When A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'G' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrGold,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) < 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As DrSilver,  Case WHEN SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END) > 0 then abs(SUM(CASE WHEN A.IT_TYPE = 'S' THEN (CASE WHEN A.ITM_SIGN = '+' THEN A.IR_WT+A.RTN_CHOL+A.RTN_GHIS+A.ITM_GHAT+A.ITM_LOSS ELSE -A.IR_WT END )ELSE 0 END)) else 0 end As CrSilver,B.MAIN_BOOK  FROM (MFG_ISU_REC AS A LEFT JOIN BOOK_DATA AS B ON A.CO_CODE = B.CO_CODE AND A.LC_CODE = B.LC_CODE AND A.CO_BOOK = B.CO_BOOK) LEFT JOIN AC_MAST AS C ON A.CO_CODE = C.CO_CODE And A.AC_CODE = C.AC_CODE WHERE A.CO_CODE = '" + DC_Main.MCo_code + "' AND A.LC_CODE = '" + DC_Main.MLc_code + "' AND A.KR_AC_CODE = '" + tAcCode.Text + "' and A.VCH_DATE >= '" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "' AND A.VCH_DATE <= '" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "' "), Interaction.IIf(Operators.CompareString(tBookCode.Text, "", false) == 0, (object)"", (object)("AND A.CO_BOOK = '" + tBookCode.Text + "'"))), (object)""), (object)" GROUP BY B.BOOK_NAME,A.CO_BOOK,A.VCH_NO,A.VCH_DATE,A.AC_CODE,C.AC_NAME,C.AC_ADD1,C.AC_MOBILE,B.MAIN_BOOK,C.AC_AREA ORDER BY A.VCH_DATE,B.BOOK_NAME"));
		DataTable dataTable2 = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		double num6 = 0.0;
		((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font("Franklin Gothic Book", 10f, (FontStyle)1);
		if (Operators.CompareString(DC_Main.MsFontChange, "Y", false) == 0)
		{
			((DataGridView)DGV_DETL).ColumnHeadersDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle.Font = new Font(DC_Main.MsFontName, DC_Main.MsFontSize, DC_Main.MsFontStyle);
			((DataGridView)DGV_DETL).RowTemplate.Height = DC_Main.MsGridRowHeight;
		}
		((DataGridView)DGV_DETL).AutoGenerateColumns = false;
		((DataGridView)DGV_DETL).Columns.Add("", "Sr");
		checked
		{
			((DataGridView)DGV_DETL).Columns[0].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Book");
			((DataGridView)DGV_DETL).Columns[1].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "VchNo");
			((DataGridView)DGV_DETL).Columns[2].Width = (int)Math.Round(70.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Date");
			((DataGridView)DGV_DETL).Columns[3].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns.Add("", "Party Name");
			((DataGridView)DGV_DETL).Columns[4].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "Area");
			((DataGridView)DGV_DETL).Columns[5].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Amt");
			((DataGridView)DGV_DETL).Columns[6].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[6].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Amt");
			((DataGridView)DGV_DETL).Columns[7].Width = (int)Math.Round(110.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[7].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Amt");
			((DataGridView)DGV_DETL).Columns[8].Width = (int)Math.Round(120.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[8].DefaultCellStyle.Format = "N2";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[9].Width = (int)Math.Round(60.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[9].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Gold");
			((DataGridView)DGV_DETL).Columns[10].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[10].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Gold");
			((DataGridView)DGV_DETL).Columns[11].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[11].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Gold");
			((DataGridView)DGV_DETL).Columns[12].Width = (int)Math.Round(100.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[12].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[13].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[13].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns.Add("", "Cr Silver");
			((DataGridView)DGV_DETL).Columns[14].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[14].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Dr Silver");
			((DataGridView)DGV_DETL).Columns[15].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[15].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "Bal Silver");
			((DataGridView)DGV_DETL).Columns[16].Width = (int)Math.Round(90.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)64;
			((DataGridView)DGV_DETL).Columns[16].DefaultCellStyle.Format = "N3";
			((DataGridView)DGV_DETL).Columns.Add("", "CrDr");
			((DataGridView)DGV_DETL).Columns[17].Width = (int)Math.Round(50.0 * ColCon);
			((DataGridView)DGV_DETL).Columns[17].DefaultCellStyle.Alignment = (DataGridViewContentAlignment)32;
			((DataGridView)DGV_DETL).Columns[14].Visible = false;
			((DataGridView)DGV_DETL).Columns[15].Visible = false;
			((DataGridView)DGV_DETL).Columns[16].Visible = false;
			((DataGridView)DGV_DETL).Columns[17].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "CoBook");
			((DataGridView)DGV_DETL).Columns[18].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "AcCode");
			((DataGridView)DGV_DETL).Columns[19].Visible = false;
			((DataGridView)DGV_DETL).Columns.Add("", "MainBook");
			((DataGridView)DGV_DETL).Columns[20].Visible = false;
			int num7 = 0;
			if (dataTable.Rows.Count > 0)
			{
				DataGridViewX dGV_DETL = DGV_DETL;
				if (Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"])) + Conversion.Val(RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"])) != 0.0)
				{
					((DataGridView)dGV_DETL).Rows.Add();
					((DataGridView)dGV_DETL)[0, num7].Value = num7 + 1;
					((DataGridView)dGV_DETL)[1, num7].Value = "Op Balance";
					((DataGridView)dGV_DETL)[6, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrAmt"]);
					((DataGridView)dGV_DETL)[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable.Rows[0]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable.Rows[0]["CrAmt"]));
					((DataGridView)dGV_DETL)[8, num7].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[9, num7].Value = "";
					}
					((DataGridView)dGV_DETL)[11, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrGold"]);
					((DataGridView)dGV_DETL)[10, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable.Rows[0]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable.Rows[0]["CrGold"]));
					((DataGridView)dGV_DETL)[12, num7].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL)[13, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL)[13, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[13, num7].Value = "";
					}
					((DataGridView)dGV_DETL)[15, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["DrSilver"]);
					((DataGridView)dGV_DETL)[14, num7].Value = RuntimeHelpers.GetObjectValue(dataTable.Rows[0]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable.Rows[0]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable.Rows[0]["CrSilver"]));
					((DataGridView)dGV_DETL)[16, num7].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL)[17, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL)[17, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL)[17, num7].Value = "";
					}
					num7++;
				}
				dGV_DETL = null;
			}
			if (dataTable2.Rows.Count > 0)
			{
				int num8 = dataTable2.Rows.Count - 1;
				DC_Main.M = 0;
				while (DC_Main.M <= num8)
				{
					DataGridViewX dGV_DETL2 = DGV_DETL;
					((DataGridView)dGV_DETL2).Rows.Add();
					((DataGridView)dGV_DETL2)[0, num7].Value = num7 + 1;
					((DataGridView)dGV_DETL2)[1, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["BOOK_NAME"]);
					((DataGridView)dGV_DETL2)[2, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_NO"]);
					((DataGridView)dGV_DETL2)[3, num7].Value = Strings.Format(RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["VCH_DATE"]), "dd/MM/yyyy");
					((DataGridView)dGV_DETL2)[18, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CO_BOOK"]);
					((DataGridView)dGV_DETL2)[4, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_NAME"]);
					((DataGridView)dGV_DETL2)[5, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_AREA"]);
					((DataGridView)dGV_DETL2)[6, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrAmt"]);
					((DataGridView)dGV_DETL2)[7, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrAmt"]);
					num = Conversions.ToDouble(Operators.AddObject((object)num, dataTable2.Rows[DC_Main.M]["DrAmt"]));
					num2 = Conversions.ToDouble(Operators.AddObject((object)num2, dataTable2.Rows[DC_Main.M]["CrAmt"]));
					((DataGridView)dGV_DETL2)[8, num7].Value = num2 - num;
					if (Conversion.Val((object)(num2 - num)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num2 - num)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[9, num7].Value = "";
					}
					((DataGridView)dGV_DETL2)[11, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrGold"]);
					((DataGridView)dGV_DETL2)[10, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrGold"]);
					num3 = Conversions.ToDouble(Operators.AddObject((object)num3, dataTable2.Rows[DC_Main.M]["DrGold"]));
					num4 = Conversions.ToDouble(Operators.AddObject((object)num4, dataTable2.Rows[DC_Main.M]["CrGold"]));
					((DataGridView)dGV_DETL2)[12, num7].Value = num4 - num3;
					if (Conversion.Val((object)(num4 - num3)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[13, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num4 - num3)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[13, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[13, num7].Value = "";
					}
					((DataGridView)dGV_DETL2)[15, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["DrSilver"]);
					((DataGridView)dGV_DETL2)[14, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["CrSilver"]);
					num5 = Conversions.ToDouble(Operators.AddObject((object)num5, dataTable2.Rows[DC_Main.M]["DrSilver"]));
					num6 = Conversions.ToDouble(Operators.AddObject((object)num6, dataTable2.Rows[DC_Main.M]["CrSilver"]));
					((DataGridView)dGV_DETL2)[16, num7].Value = num6 - num5;
					if (Conversion.Val((object)(num6 - num5)) > 0.0)
					{
						((DataGridView)dGV_DETL2)[17, num7].Value = "Cr";
					}
					else if (Conversion.Val((object)(num6 - num5)) < 0.0)
					{
						((DataGridView)dGV_DETL2)[17, num7].Value = "Dr";
					}
					else
					{
						((DataGridView)dGV_DETL2)[17, num7].Value = "";
					}
					((DataGridView)dGV_DETL2)[19, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["AC_CODE"]);
					((DataGridView)dGV_DETL2)[20, num7].Value = RuntimeHelpers.GetObjectValue(dataTable2.Rows[DC_Main.M]["MAIN_BOOK"]);
					num7++;
					dGV_DETL2 = null;
					DC_Main.M++;
				}
				if (((DataGridView)DGV_DETL).Rows.Count >= 1 && Conversions.ToBoolean(Operators.AndObject(Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"Total : ", false), Operators.CompareObjectNotEqual(Operators.ConcatenateObject(((DataGridView)DGV_DETL).Rows[((DataGridView)DGV_DETL).Rows.Count - 1].Cells[4].Value, (object)""), (object)"", false))))
				{
					((DataGridView)DGV_DETL).Rows.Add();
					((DataGridView)DGV_DETL).Rows.Add();
				}
				int num9 = ((DataGridView)DGV_DETL).Rows.Count - 1;
				((DataGridView)DGV_DETL).Rows[num9].Cells[4].Value = "Total :";
				((DataGridView)DGV_DETL).Rows[num9].Cells[6].Value = num;
				((DataGridView)DGV_DETL).Rows[num9].Cells[7].Value = num2;
				((DataGridView)DGV_DETL).Rows[num9].Cells[8].Value = Math.Abs(num2 - num);
				if (Conversion.Val((object)(num2 - num)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[9].Value = "Cr";
				}
				else if (Conversion.Val((object)(num2 - num)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[9].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[9].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num9].Cells[11].Value = num3;
				((DataGridView)DGV_DETL).Rows[num9].Cells[10].Value = num4;
				((DataGridView)DGV_DETL).Rows[num9].Cells[12].Value = Math.Abs(num4 - num3);
				if (Conversion.Val((object)(num4 - num3)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[13].Value = "Cr";
				}
				else if (Conversion.Val((object)(num4 - num3)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[13].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[13].Value = "";
				}
				((DataGridView)DGV_DETL).Rows[num9].Cells[15].Value = num5;
				((DataGridView)DGV_DETL).Rows[num9].Cells[14].Value = num6;
				((DataGridView)DGV_DETL).Rows[num9].Cells[16].Value = Math.Abs(num6 - num5);
				if (Conversion.Val((object)(num6 - num5)) > 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[17].Value = "Cr";
				}
				else if (Conversion.Val((object)(num6 - num5)) < 0.0)
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[17].Value = "Dr";
				}
				else
				{
					((DataGridView)DGV_DETL).Rows[num9].Cells[17].Value = "";
				}
			}
			((TextBoxBase)tAcCode).SelectionStart = 0;
			((TextBoxBase)tAcCode).SelectionLength = Strings.Len(tAcCode.Text);
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
				{
					ProjectData.ClearProjectError();
					num2 = 2;
					int columnIndex = e.ColumnIndex;
					if ((uint)(columnIndex - 6) <= 2u && ((ConvertEventArgs)e).Value != null && Operators.CompareString(((ConvertEventArgs)e).Value.ToString(), "0", false) == 0)
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
					case 1882:
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
								goto IL_039c;
							case 32:
								goto IL_03ae;
							case 22:
							case 33:
							case 34:
								goto IL_03ca;
							case 35:
								goto IL_03d4;
							case 36:
								goto IL_0427;
							case 37:
								goto IL_047c;
							case 38:
								goto IL_04d4;
							case 39:
								goto IL_0542;
							case 40:
								goto IL_0585;
							case 41:
								goto IL_05b4;
							case 42:
								goto IL_05f7;
							case 43:
								goto IL_0638;
							case 44:
								goto IL_0659;
							case 45:
								goto IL_0667;
							case 46:
								goto IL_066d;
							case 47:
								goto IL_0673;
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
						IL_039c:
						num2 = 31;
						num5++;
						goto IL_03a5;
						IL_0296:
						num2 = 24;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							1,
							num6 + 1,
							((DataGridView)DGV_AC).Columns[num6].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_02de;
						IL_0347:
						num2 = 29;
						NewLateBinding.LateSet(obj, (Type)null, "Cells", new object[3]
						{
							DC_Main.i + 2,
							num5 + 1,
							((DataGridView)DGV_AC)[num5, DC_Main.i].Value.ToString()
						}, (string[])null, (Type[])null);
						goto IL_039c;
						IL_02de:
						num2 = 25;
						num6++;
						goto IL_02e7;
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
						num7 = ((DataGridView)DGV_DETL).ColumnCount - 1;
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
						num9 = ((DataGridView)DGV_DETL).RowCount - 1;
						DC_Main.i = 0;
						goto IL_026c;
						IL_026c:
						if (DC_Main.i <= num9)
						{
							goto IL_01b9;
						}
						goto IL_03ca;
						IL_01b9:
						num2 = 16;
						num10 = ((DataGridView)DGV_DETL).ColumnCount - 1;
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
						if (((DataGridView)DGV_DETL)[num11, DC_Main.i].Value != null)
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
							((DataGridView)DGV_DETL)[num11, DC_Main.i].Value.ToString()
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
							((DataGridView)DGV_DETL).Columns[num8].HeaderText
						}, (string[])null, (Type[])null);
						goto IL_018d;
						IL_018d:
						num2 = 14;
						num8++;
						goto IL_0196;
						IL_027f:
						num2 = 23;
						num12 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num6 = 0;
						goto IL_02e7;
						IL_02e7:
						if (num6 <= num12)
						{
							goto IL_0296;
						}
						goto IL_02ed;
						IL_02ed:
						num2 = 26;
						num13 = ((DataGridView)DGV_AC).RowCount - 1;
						DC_Main.i = 0;
						goto IL_03bd;
						IL_03bd:
						if (DC_Main.i <= num13)
						{
							goto IL_030a;
						}
						goto IL_03ca;
						IL_03ca:
						num2 = 34;
						colorConverter = new ColorConverter();
						goto IL_03d4;
						IL_03d4:
						num2 = 35;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "FontStyle", new object[1] { "Bold" }, (string[])null, (Type[])null, false, true);
						goto IL_0427;
						IL_0427:
						num2 = 36;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Size", new object[1] { 11 }, (string[])null, (Type[])null, false, true);
						goto IL_047c;
						IL_047c:
						num2 = 37;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { Color.Maroon }, (string[])null, (Type[])null, false, true);
						goto IL_04d4;
						IL_04d4:
						num2 = 38;
						NewLateBinding.LateSetComplex(NewLateBinding.LateGet(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Rows", new object[1] { "1:1" }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Style", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Font", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Color", new object[1] { colorConverter.ConvertFromString("DarkBlue") }, (string[])null, (Type[])null, false, true);
						goto IL_0542;
						IL_0542:
						num2 = 39;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Columns", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0585;
						IL_0585:
						num2 = 40;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05b4;
						IL_05b4:
						num2 = 41;
						NewLateBinding.LateCall(NewLateBinding.LateGet(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "EntireColumn", new object[0], (string[])null, (Type[])null, (bool[])null), (Type)null, "AutoFit", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_05f7;
						IL_05f7:
						num2 = 42;
						NewLateBinding.LateCall(NewLateBinding.LateGet(obj, (Type)null, "Cells", new object[2] { 1, 1 }, (string[])null, (Type[])null, (bool[])null), (Type)null, "Select", new object[0], (string[])null, (Type[])null, (bool[])null, true);
						goto IL_0638;
						IL_0638:
						num2 = 43;
						NewLateBinding.LateSet(obj2, (Type)null, "Visible", new object[1] { true }, (string[])null, (Type[])null);
						goto IL_0659;
						IL_0659:
						num2 = 44;
						Cursor.Current = Cursors.Default;
						goto IL_0667;
						IL_0667:
						num2 = 45;
						obj = null;
						goto IL_066d;
						IL_066d:
						num2 = 46;
						obj3 = null;
						goto IL_0673;
						IL_0673:
						num2 = 47;
						obj2 = null;
						break;
						IL_030a:
						num2 = 27;
						num14 = ((DataGridView)DGV_AC).ColumnCount - 1;
						num5 = 0;
						goto IL_03a5;
						IL_03a5:
						if (num5 <= num14)
						{
							goto IL_0324;
						}
						goto IL_03ae;
						IL_03ae:
						num2 = 32;
						DC_Main.i++;
						goto IL_03bd;
						IL_0324:
						num2 = 28;
						if (((DataGridView)DGV_AC)[num5, DC_Main.i].Value != null)
						{
							goto IL_0347;
						}
						goto IL_039c;
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
				try0001_dispatch = 1882;
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

	private void RP_MFG_LEDR_Load(object sender, EventArgs e)
	{
		//IL_019b: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a2: Expected O, but got Unknown
		DC_Main.RsQry = "Select * From USER_SET WHERE LC_CODE = '" + DC_Main.MLc_code + "' AND  USER_NAME = '" + DC_Main.MCo_User + "' AND SUB_MENU = '" + DC_Main.MsUserRightForm + "' ";
		DataTable dataTable = DC_Main.OpenRecordSetMc(DC_Main.RsQry);
		CurRpt = DC_Main.MsUserRightForm;
		lblBook.Text = CurRpt;
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
				DataGridViewX dGV_AC = DGV_AC;
				object? obj7 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_AC).BackgroundColor = ((obj7 != null) ? ((Color)obj7) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj8 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle.BackColor = ((obj8 != null) ? ((Color)obj8) : default(Color));
				DataGridViewX dGV_DETL = DGV_DETL;
				object? obj9 = colorConverter.ConvertFromString("243, 240, 239");
				((DataGridView)dGV_DETL).BackgroundColor = ((obj9 != null) ? ((Color)obj9) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle2 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj10 = colorConverter.ConvertFromString("243, 240, 239");
				alternatingRowsDefaultCellStyle2.BackColor = ((obj10 != null) ? ((Color)obj10) : default(Color));
			}
			else if (DC_Main.MsCoTheme == 3)
			{
				object? obj11 = colorConverter.ConvertFromString("200, 205, 210");
				((Form)this).BackColor = ((obj11 != null) ? ((Color)obj11) : default(Color));
				((Control)lblBook).BackColor = Color.LightSlateGray;
				((Control)lblBook).ForeColor = Color.White;
				((Control)PnlBotam).BackColor = Color.SlateGray;
				DataGridViewX dGV_AC2 = DGV_AC;
				object? obj12 = colorConverter.ConvertFromString("174, 184, 194");
				((DataGridView)dGV_AC2).BackgroundColor = ((obj12 != null) ? ((Color)obj12) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle3 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj13 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle3.BackColor = ((obj13 != null) ? ((Color)obj13) : default(Color));
				DataGridViewX dGV_DETL2 = DGV_DETL;
				object? obj14 = colorConverter.ConvertFromString("Control");
				((DataGridView)dGV_DETL2).BackgroundColor = ((obj14 != null) ? ((Color)obj14) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle4 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj15 = colorConverter.ConvertFromString("233, 235, 240");
				alternatingRowsDefaultCellStyle4.BackColor = ((obj15 != null) ? ((Color)obj15) : default(Color));
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
				DataGridViewX dGV_AC3 = DGV_AC;
				object? obj20 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_AC3).BackgroundColor = ((obj20 != null) ? ((Color)obj20) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle5 = ((DataGridView)DGV_AC).AlternatingRowsDefaultCellStyle;
				object? obj21 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle5.BackColor = ((obj21 != null) ? ((Color)obj21) : default(Color));
				DataGridViewX dGV_DETL3 = DGV_DETL;
				object? obj22 = colorConverter.ConvertFromString("Ivory");
				((DataGridView)dGV_DETL3).BackgroundColor = ((obj22 != null) ? ((Color)obj22) : default(Color));
				DataGridViewCellStyle alternatingRowsDefaultCellStyle6 = ((DataGridView)DGV_DETL).AlternatingRowsDefaultCellStyle;
				object? obj23 = colorConverter.ConvertFromString("238, 244, 236");
				alternatingRowsDefaultCellStyle6.BackColor = ((obj23 != null) ? ((Color)obj23) : default(Color));
			}
			CLEAR_DATA();
			CurActCtrl = (Control)(object)tSearch;
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
		tAcCode.Text = "";
		tAcName.Text = "";
		AcSumm();
		((Control)tSearch).Focus();
	}

	private void RP_MFG_LEDR_Activated(object sender, EventArgs e)
	{
		if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
		{
			DGV_DETL_FILL();
		}
		else
		{
			AcSumm();
		}
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
			BtnExit.Text = "E&xit";
			((Control)PnlAcSumm).Visible = true;
		}
		else
		{
			((Form)this).Close();
		}
	}

	private void RP_MFG_LEDR_Deactivate(object sender, EventArgs e)
	{
		if (Information.IsReference((object)CurActCtrl))
		{
			CurActCtrl = null;
			CurActCtrl = ((ContainerControl)this).ActiveControl;
		}
	}

	private void RP_MFG_LEDR_KeyPress(object sender, KeyPressEventArgs e)
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

	private void RP_MFG_LEDR_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 27)
		{
			if (Operators.CompareString(BtnExit.Text, "&Back", false) == 0)
			{
				((DataGridView)DGV_DETL).DataSource = null;
				((DataGridView)DGV_DETL).ClearSelection();
				((DataGridView)DGV_DETL).Rows.Clear();
				((Control)DGV_DETL).Refresh();
				BtnExit.Text = "E&xit";
			}
			else
			{
				((Form)this).Close();
			}
		}
	}

	private void BtnPrint_Click(object sender, EventArgs e)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (Operators.CompareString(UserPrint, "Y", false) != 0)
		{
			Interaction.MsgBox((object)"You Have No Print Rights.....", (MsgBoxStyle)0, (object)null);
		}
		else if (Operators.CompareString(BtnExit.Text, "E&xit", false) != 0)
		{
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "O", false) == 0)
			{
				Cr[(short)0] = "";
				Cr[(short)1] = "";
				Cr[(short)2] = "";
				Cr[(short)3] = "";
				Cr[(short)4] = "";
				Cr[(short)5] = "";
				Cr[(short)6] = "";
				Cr[(short)7] = "";
			}
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN ITM_SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -IR_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN ITM_SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN IR_WT+DM_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -IR_WT-DM_WT ELSE 0 END) END) As SilverWt FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'  AND KR_AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE < '"), (object)Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN ITM_SIGN = '+' THEN IR_WT ELSE -IR_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num2 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
				num3 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT Sum(CR_AMT - DR_AMT) as BalAmt, Sum(CASE WHEN ITM_SIGN = '+' THEN (CASE WHEN IT_TYPE = 'G' THEN IR_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'G' THEN -IR_WT ELSE 0 END) END) As GoldWt ,Sum(CASE WHEN ITM_SIGN = '+' THEN (CASE WHEN IT_TYPE = 'S' THEN IR_WT+DM_WT+RTN_CHOL+RTN_GHIS+ITM_GHAT+ITM_LOSS ELSE 0 END) ELSE (CASE WHEN IT_TYPE = 'S' THEN -IR_WT-DM_WT ELSE 0 END) END) As SilverWt FROM MFG_ISU_REC WHERE CO_CODE = '" + DC_Main.MCo_code + "' "), Interaction.IIf(Operators.CompareString(tLcCode.Text, "", false) == 0, (object)"", (object)("AND LC_CODE = '" + tLcCode.Text + "'"))), (object)" AND CO_YEAR = '"), (object)DC_Main.MCo_year), (object)"'   AND KR_AC_CODE = '"), (object)tAcCode.Text), (object)"' and VCH_DATE <= '"), (object)Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy")), (object)"' "), Interaction.IIf(Operators.CompareString(DC_Main.MsDataType, "C", false) == 0, (object)"", (object)("AND DATA_TYPE = '" + DC_Main.MsDataType + "'"))), (object)" HAVING (SUM(CR_AMT-DR_AMT) <> 0 or SUM(CASE WHEN ITM_SIGN = '+' THEN IR_WT ELSE -IR_WT END) <> 0)"));
			DC_Main.Rshlp = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
			if (DC_Main.Rshlp.Rows.Count > 0)
			{
				num4 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["BalAmt"]), "0.00"));
				num5 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["GoldWt"]), "0.000"));
				num6 = Conversions.ToDouble(Strings.Format(RuntimeHelpers.GetObjectValue(DC_Main.Rshlp.Rows[0]["SilverWt"]), "0.00"));
			}
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.RptName = "MfgLedger";
				DC_Main.MsRptTitel = "RptTitel";
				DC_Main.MsRptTitelStr = "'Mfg Ledr Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
				DC_Main.MsCrForName1 = "FromDate";
				DC_Main.MsCrForStr1 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ")";
				DC_Main.MsCrForName2 = "ToDate";
				DC_Main.MsCrForStr2 = "Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ")";
				DC_Main.MsCrForName3 = "OpBal";
				DC_Main.MsCrForVal3 = Strings.Format((object)num2, "0.000");
				DC_Main.MsCrForName4 = "ClBal";
				DC_Main.MsCrForVal4 = Strings.Format((object)num5, "0.000");
				DC_Main.MsCrForName5 = "OpAmtBal";
				DC_Main.MsCrForVal5 = Strings.Format((object)num, "0.00");
				DC_Main.MsCrForName6 = "ClAmtBal";
				DC_Main.MsCrForVal6 = Strings.Format((object)num4, "0.00");
			}
			else
			{
				Cr.ReportFileName = ((ApplicationBase)MyProject.Application).Info.DirectoryPath + "\\Report\\MfgLedger.RPT";
			}
			CurFormula = "{MFG_ISU_REC.CO_CODE} = '" + DC_Main.MCo_code + "' AND {MFG_ISU_REC.LC_CODE} = '" + DC_Main.MLc_code + "' AND {MFG_ISU_REC.CO_YEAR} = '" + DC_Main.MCo_year + "' AND {MFG_ISU_REC.KR_AC_CODE} = '" + tAcCode.Text + "' AND {MFG_ISU_REC.VCH_DATE} >= #" + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "MM/dd/yyyy") + "# AND {MFG_ISU_REC.VCH_DATE} <= #" + Strings.Format((object)Conversions.ToDate(mToDt.Text), "MM/dd/yyyy") + "# ";
			if (Operators.CompareString(DC_Main.MsCrystalRptType, "N", false) == 0)
			{
				DC_Main.MsWappPrintType = "All";
				DC_Main.RptFormula = CurFormula;
				UT_REPORT uT_REPORT = new UT_REPORT();
				((Control)uT_REPORT).Show();
				((Control)uT_REPORT).Focus();
				CurFormula = "";
				return;
			}
			Cr[(short)0] = "RptTitel = 'Mfg Ledger Report As On " + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd/MM/yyyy") + "'";
			Cr[(short)1] = "FromDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mFromDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mFromDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mFromDt.Text), "dd") + ") ";
			Cr[(short)2] = "ToDate = Date(" + Conversions.ToString(DateAndTime.Year(Conversions.ToDate(mToDt.Text))) + "," + Conversions.ToString(DateAndTime.Month(Conversions.ToDate(mToDt.Text))) + "," + Strings.Format((object)Conversions.ToDate(mToDt.Text), "dd") + ") ";
			Cr[(short)3] = ("OpBal = " + Strings.Format((object)num2, "0.000")) ?? "";
			Cr[(short)4] = ("ClBal = " + Strings.Format((object)num5, "0.000")) ?? "";
			Cr[(short)5] = ("OpAmtBal = " + Strings.Format((object)num, "0.00")) ?? "";
			Cr[(short)6] = ("ClAmtBal = " + Strings.Format((object)num4, "0.00")) ?? "";
			Cr.Destination = (DestinationConstants)0;
			Cr.WindowState = (WindowStateConstants)2;
			Cr.Action = -1;
			Cr.PageZoom(checked((short)DC_Main.MsPrintZoom));
		}
	}

	private void BtnCancel_Click(object sender, EventArgs e)
	{
		CLEAR_DATA();
	}

	private void RP_MFG_LEDR_Closed(object sender, EventArgs e)
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

	private void tAcCode_TextChanged(object sender, EventArgs e)
	{
	}

	private void tAcCode_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		//IL_01ae: Unknown result type (might be due to invalid IL or missing references)
		if ((int)e.KeyCode != 13)
		{
			return;
		}
		DC_Main.RsQry = "Select * From AC_MAST WHERE CO_CODE = '" + DC_Main.MCo_code + "'  AND AC_CODE = '" + tAcCode.Text + "'";
		DC_Main.Tbl = DC_Main.OpenRecordSetDc(DC_Main.RsQry);
		if (DC_Main.Tbl.Rows.Count == 0)
		{
			if (Operators.CompareString(DC_Main.MLc_code, "00", false) != 0)
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

	private void DGV_DETL_DoubleClick(object sender, EventArgs e)
	{
		DC_Main.RsQry = Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject(Operators.ConcatenateObject((object)("SELECT BOOK_NAME ,CO_BOOK ,BOOK_TYPE,ITM_TYPE,MAIN_BOOK,BOOK_SNAME,BOOK_INOUT,MENU_NAME  FROM BOOK_DATA WHERE CO_CODE = '" + DC_Main.MCo_code + "' AND LC_CODE = '" + DC_Main.MLc_code + "' AND CO_BOOK = '"), ((DataGridView)DGV_DETL).Rows[((DataGridViewBand)((DataGridView)DGV_DETL).CurrentRow).Index].Cells[18].Value), (object)""), (object)"' "));
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
		if ((Operators.CompareString(DC_Main.CurBookMain, "MFG REC ITEM", false) == 0) | (Operators.CompareString(DC_Main.CurBookMain, "MFG ISU ITEM", false) == 0))
		{
			TR_MFG_ITEM tR_MFG_ITEM = new TR_MFG_ITEM();
			((Form)tR_MFG_ITEM).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MFG_ITEM).Show();
			((Control)tR_MFG_ITEM).Focus();
		}
		else if (Operators.CompareString(DC_Main.MsMfgOneFormEntry, "Y", false) == 0)
		{
			TR_MFG_KR_ISU_REC tR_MFG_KR_ISU_REC = new TR_MFG_KR_ISU_REC();
			((Form)tR_MFG_KR_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MFG_KR_ISU_REC).Show();
			((Control)tR_MFG_KR_ISU_REC).Focus();
		}
		else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
		{
			TR_MFG_WITH_LOT tR_MFG_WITH_LOT = new TR_MFG_WITH_LOT();
			((Form)tR_MFG_WITH_LOT).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MFG_WITH_LOT).Show();
			((Control)tR_MFG_WITH_LOT).Focus();
		}
		else if (Operators.CompareString(DC_Main.MsMfgWithOrder, "Y", false) == 0)
		{
			if (Operators.CompareString(DC_Main.CurBookMain, "MTL ISU", false) == 0)
			{
				TR_KR_ISU tR_KR_ISU = new TR_KR_ISU();
				((Form)tR_KR_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_KR_ISU).Show();
				((Control)tR_KR_ISU).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "GHAT ISU", false) == 0)
			{
				TR_MFG_ORD_ISU tR_MFG_ORD_ISU = new TR_MFG_ORD_ISU();
				((Form)tR_MFG_ORD_ISU).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ORD_ISU).Show();
				((Control)tR_MFG_ORD_ISU).Focus();
			}
			else if (Operators.CompareString(DC_Main.CurBookMain, "GHAT REC", false) == 0)
			{
				if (Operators.CompareString(DC_Main.SSRegSrNo, "VS205NSBU", false) == 0)
				{
					TR_MFG_ORD_REC tR_MFG_ORD_REC = new TR_MFG_ORD_REC();
					((Form)tR_MFG_ORD_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_ORD_REC).Show();
					((Control)tR_MFG_ORD_REC).Focus();
				}
				else
				{
					TR_MFG_GHAT_REC tR_MFG_GHAT_REC = new TR_MFG_GHAT_REC();
					((Form)tR_MFG_GHAT_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
					((Control)tR_MFG_GHAT_REC).Show();
					((Control)tR_MFG_GHAT_REC).Focus();
				}
			}
			else
			{
				TR_MFG_ORD_REC tR_MFG_ORD_REC2 = new TR_MFG_ORD_REC();
				((Form)tR_MFG_ORD_REC2).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
				((Control)tR_MFG_ORD_REC2).Show();
				((Control)tR_MFG_ORD_REC2).Focus();
			}
		}
		else
		{
			TR_MFG_ISU_REC tR_MFG_ISU_REC = new TR_MFG_ISU_REC();
			((Form)tR_MFG_ISU_REC).MdiParent = (Form)(object)MyProject.Forms.MDI_FORM;
			((Control)tR_MFG_ISU_REC).Show();
			((Control)tR_MFG_ISU_REC).Focus();
		}
	}

	private void BtnJmaUdhar_Click(object sender, EventArgs e)
	{
	}

	private void cboEmp_KeyDown(object sender, KeyEventArgs e)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Invalid comparison between Unknown and I4
		if ((int)e.KeyCode == 13)
		{
			SendKeys.Send("{tab}");
		}
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
						tBookName.Text = DC_Main.ColValue[0];
					}
					((Control)tBookCode).Focus();
				}
			}
			else
			{
				tBookName.Text = Conversions.ToString(Operators.ConcatenateObject(DC_Main.Tbl.Rows[0]["BOOK_NAME"], (object)""));
				DGV_DETL_FILL();
			}
		}
		else
		{
			tBookName.Text = "";
			DGV_DETL_FILL();
		}
	}

	private void DGV_AC_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
	}
}
